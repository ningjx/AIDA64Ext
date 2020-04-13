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
        static PersistentSettings persistentSettings = new PersistentSettings();
        static UnitManager unitManager = new UnitManager(persistentSettings);
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
                                        if (unitManager.TemperatureUnit == TemperatureUnit.Fahrenheit)
                                        {
                                            formatted = string.Format("{0:F1} °F",
                                              UnitManager.CelsiusToFahrenheit(sensor.Value));
                                        }
                                        else
                                        {
                                            formatted = string.Format("{0:F1} °C", sensor.Value);
                                        }
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

    class PersistentSettings : ISettings
    {

        private IDictionary<string, string> settings =
          new Dictionary<string, string>();

        public void Load(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fileName);
            }
            catch
            {
                try
                {
                    File.Delete(fileName);
                }
                catch { }

                string backupFileName = fileName + ".backup";
                try
                {
                    doc.Load(backupFileName);
                }
                catch
                {
                    try
                    {
                        File.Delete(backupFileName);
                    }
                    catch { }

                    return;
                }
            }

            XmlNodeList list = doc.GetElementsByTagName("appSettings");
            foreach (XmlNode node in list)
            {
                XmlNode parent = node.ParentNode;
                if (parent != null && parent.Name == "configuration" &&
                  parent.ParentNode is XmlDocument)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name == "add")
                        {
                            XmlAttributeCollection attributes = child.Attributes;
                            XmlAttribute keyAttribute = attributes["key"];
                            XmlAttribute valueAttribute = attributes["value"];
                            if (keyAttribute != null && valueAttribute != null &&
                              keyAttribute.Value != null)
                            {
                                settings.Add(keyAttribute.Value, valueAttribute.Value);
                            }
                        }
                    }
                }
            }
        }

        public void Save(string fileName)
        {

            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement configuration = doc.CreateElement("configuration");
            doc.AppendChild(configuration);
            XmlElement appSettings = doc.CreateElement("appSettings");
            configuration.AppendChild(appSettings);
            foreach (KeyValuePair<string, string> keyValuePair in settings)
            {
                XmlElement add = doc.CreateElement("add");
                add.SetAttribute("key", keyValuePair.Key);
                add.SetAttribute("value", keyValuePair.Value);
                appSettings.AppendChild(add);
            }

            byte[] file;
            using (var memory = new MemoryStream())
            {
                using (var writer = new StreamWriter(memory, Encoding.UTF8))
                {
                    doc.Save(writer);
                }
                file = memory.ToArray();
            }

            string backupFileName = fileName + ".backup";
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(backupFileName);
                }
                catch { }
                try
                {
                    File.Move(fileName, backupFileName);
                }
                catch { }
            }

            using (var stream = new FileStream(fileName,
              FileMode.Create, FileAccess.Write))
            {
                stream.Write(file, 0, file.Length);
            }

            try
            {
                File.Delete(backupFileName);
            }
            catch { }
        }

        public bool Contains(string name)
        {
            return settings.ContainsKey(name);
        }

        public void SetValue(string name, string value)
        {
            settings[name] = value;
        }

        public string GetValue(string name, string value)
        {
            string result;
            if (settings.TryGetValue(name, out result))
                return result;
            else
                return value;
        }

        public void Remove(string name)
        {
            settings.Remove(name);
        }

        public void SetValue(string name, int value)
        {
            settings[name] = value.ToString();
        }

        public int GetValue(string name, int value)
        {
            string str;
            if (settings.TryGetValue(name, out str))
            {
                int parsedValue;
                if (int.TryParse(str, out parsedValue))
                    return parsedValue;
                else
                    return value;
            }
            else
            {
                return value;
            }
        }

        public void SetValue(string name, float value)
        {
            settings[name] = value.ToString(CultureInfo.InvariantCulture);
        }

        public float GetValue(string name, float value)
        {
            string str;
            if (settings.TryGetValue(name, out str))
            {
                float parsedValue;
                if (float.TryParse(str, NumberStyles.Float,
                  CultureInfo.InvariantCulture, out parsedValue))
                    return parsedValue;
                else
                    return value;
            }
            else
            {
                return value;
            }
        }

        public void SetValue(string name, bool value)
        {
            settings[name] = value ? "true" : "false";
        }

        public bool GetValue(string name, bool value)
        {
            string str;
            if (settings.TryGetValue(name, out str))
            {
                return str == "true";
            }
            else
            {
                return value;
            }
        }

        public void SetValue(string name, Color color)
        {
            settings[name] = color.ToArgb().ToString("X8");
        }

        public Color GetValue(string name, Color value)
        {
            string str;
            if (settings.TryGetValue(name, out str))
            {
                int parsedValue;
                if (int.TryParse(str, NumberStyles.HexNumber,
                  CultureInfo.InvariantCulture, out parsedValue))
                    return Color.FromArgb(parsedValue);
                else
                    return value;
            }
            else
            {
                return value;
            }
        }
    }

    enum TemperatureUnit
    {
        Celsius = 0,
        Fahrenheit = 1
    }

    class UnitManager
    {

        private PersistentSettings settings;
        private TemperatureUnit temperatureUnit;

        public UnitManager(PersistentSettings settings)
        {
            this.settings = settings;
            this.temperatureUnit = (TemperatureUnit)settings.GetValue("TemperatureUnit",
              (int)TemperatureUnit.Celsius);
        }

        public TemperatureUnit TemperatureUnit
        {
            get { return temperatureUnit; }
            set
            {
                this.temperatureUnit = value;
                this.settings.SetValue("TemperatureUnit", (int)temperatureUnit);
            }
        }

        public static float? CelsiusToFahrenheit(float? valueInCelsius)
        {
            return valueInCelsius * 1.8f + 32;
        }
    }
}
