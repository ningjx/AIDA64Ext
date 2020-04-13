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
        static OHM()
        {
            UpdateVisitor updateVisitor = new UpdateVisitor();
            computer.CPUEnabled = true;
            computer.FanControllerEnabled = true;
            computer.GPUEnabled = true;
            computer.HDDEnabled = true;
            computer.MainboardEnabled = true;
            computer.RAMEnabled = true;
            computer.Open();
            computer.Accept(updateVisitor);

            Timer timer = new Timer(500)
            {
                AutoReset = true,
                Enabled = true,
            };
            timer.Elapsed += Timer_Elapsed;
            //timer.Start();
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                foreach (var item in computer.Hardware)
                {
                    foreach (var sensor in item.Sensors)
                    {
                        if ((sensor.SensorType != SensorType.Load && sensor.SensorType != SensorType.Control && sensor.SensorType != SensorType.Level) || !sensor.Value.HasValue)
                        {
                            string formatted;
                            if (sensor.Value.HasValue)
                            {
                                string format = "";
                                switch (sensor.SensorType)
                                {
                                    case SensorType.Voltage:
                                        format = "{0:F3} V";
                                        break;
                                    case SensorType.Clock:
                                        format = "{0:F0} MHz";
                                        break;
                                    case SensorType.Fan:
                                        format = "{0:F0} RPM";
                                        break;
                                    case SensorType.Flow:
                                        format = "{0:F0} L/h";
                                        break;
                                    case SensorType.Power:
                                        format = "{0:F1} W";
                                        break;
                                    case SensorType.Data:
                                        format = "{0:F1} GB";
                                        break;
                                    case SensorType.Factor:
                                        format = "{0:F3}";
                                        break;
                                    case SensorType.SmallData:
                                        format = "{0:F1} MB";
                                        break;
                                }

                                switch (sensor.SensorType)
                                {
                                    case SensorType.Temperature:
                                        formatted = string.Format("{0:F1} °C", sensor.Value);
                                        break;
                                    case SensorType.Throughput:
                                        if (sensor.Value < 1)
                                        {
                                            formatted =
                                              string.Format("{0:F1} KB/s", sensor.Value * 0x400);
                                        }
                                        else
                                        {
                                            formatted =
                                              string.Format("{0:F1} MB/s", sensor.Value);
                                        }
                                        break;
                                    default:
                                        formatted = string.Format(format, sensor.Value);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            //百分比
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
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
