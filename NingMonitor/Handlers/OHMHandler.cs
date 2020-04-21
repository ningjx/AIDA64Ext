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
    public static class OHMHandler
    {
        static readonly Computer computer = new Computer();
        static readonly UpdateVisitor updateVisitor = new UpdateVisitor();
        static OHMHandler()
        {
            PerformanceHandler.Start();
            computer.CPUEnabled = true;
            computer.FanControllerEnabled = true;
            computer.GPUEnabled = true;
            computer.HDDEnabled = true;
            computer.MainboardEnabled = true;
            computer.RAMEnabled = true;
            computer.Open();
            Timer timer = new Timer(1000)
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
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "V");
                                break;
                            case SensorType.Clock:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "MHz");
                                break;
                            case SensorType.Fan:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "RPM");
                                break;
                            case SensorType.Flow:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "L/h");
                                break;
                            case SensorType.Power:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "W");
                                break;
                            case SensorType.Data:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "GB");
                                break;
                            case SensorType.Factor:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "");
                                break;
                            case SensorType.SmallData:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "MB");
                                break;
                            case SensorType.Temperature:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "°C");
                                break;
                            case SensorType.Throughput:
                                if (computer.Hardware[i].Sensors[j].Value < 1)
                                    PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value * 0x400 ?? 0, "KB/s");
                                else
                                    PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "MB/s");
                                break;
                            default:
                                PerformanceDatas.ADD(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].SensorType, computer.Hardware[i].Sensors[j].Value ?? 0, "%");
                                break;
                        }
                    }
                }
                GotData?.Invoke();
            }
            catch{}
        }

        public static void Start()
        {

        }

        public delegate void GotDataHandler();

        public static event GotDataHandler GotData;
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
