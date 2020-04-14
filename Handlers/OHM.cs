using AIDA64Ext.Models;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace AIDA64Ext.Handlers
{
    /// <summary>
    /// OpenHardwareMonitor
    /// </summary>
    public static class OHM
    {
        static Computer computer = new Computer();
        public static OHMData OHMData = new OHMData();
        static UpdateVisitor updateVisitor = new UpdateVisitor();
        static OHM()
        {
            computer.CPUEnabled = true;
            computer.FanControllerEnabled = true;
            computer.GPUEnabled = true;
            computer.HDDEnabled = true;
            computer.MainboardEnabled = true;
            computer.RAMEnabled = true;
            computer.Open();
            //Timer_Elapsed(null, null);
            Timer timer = new Timer(500)
            {
                AutoReset = true,
                Enabled = true,
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.Start();
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        switch (computer.Hardware[i].Sensors[j].SensorType)
                        {
                            case SensorType.Voltage:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "V");
                                break;
                            case SensorType.Clock:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "MHz");
                                break;
                            case SensorType.Fan:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "RPM");
                                break;
                            case SensorType.Flow:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "L/h");
                                break;
                            case SensorType.Power:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "W");
                                break;
                            case SensorType.Data:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "GB");
                                break;
                            case SensorType.Factor:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "");
                                break;
                            case SensorType.SmallData:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "MB");
                                break;
                            case SensorType.Temperature:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "°C");
                                break;
                            case SensorType.Throughput:
                                if (computer.Hardware[i].Sensors[j].Value < 1)
                                    OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value * 0x400 ?? 0, "KB/s");
                                else
                                    OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "MB/s");
                                break;
                            default:
                                OHMData.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "%");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void Start()
        {

        }
    }

    class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware)
                subHardware.Accept(this);
        }

        public void VisitSensor(ISensor sensor) { }

        public void VisitParameter(IParameter parameter) { }
    }
}
