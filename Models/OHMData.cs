using AIDA64Ext.Extension;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDA64Ext.Models
{
    public static class PerformanceParams
    {
        public static Dictionary<string, OHMItem> Items { get; } = new Dictionary<string, OHMItem>();

        public static void ADD(string name, SensorType sensorType, float value, string unit)
        {
            Items.AddOrUpdate(name + sensorType, new OHMItem(name, sensorType, value, unit));
        }

        public static void ADD(string name, CustomType dataType, float value, string unit)
        {
            Items.AddOrUpdate(name + dataType, new OHMItem(name, dataType, value, unit));
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static OHMItem GetByName(string name, CustomType dataType)
        {
            if (Items.TryGetValue(name + dataType, out OHMItem item))
                return item;
            else
                return new OHMItem(name + dataType, SensorType.Unknown, 0, "");
        }

        public static List<OHMItem> AllItems
        {
            get
            {
                OHMItem[] items = new OHMItem[Items.Values.Count];
                Items.Values.CopyTo(items, 0);
                return items.ToList();
            }
        }
    }

    public class OHMItem
    {
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit = string.Empty;

        /// <summary>
        /// 值
        /// </summary>
        public float Value;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// 类型
        /// </summary>
        public CustomType Type;

        public OHMItem(string name, SensorType sensorType, float value, string unit)
        {
            Name = name;
            Value = value;
            Unit = unit;
            Type = (CustomType)Enum.Parse(typeof(CustomType), sensorType.GetHashCode().ToString());
        }

        public OHMItem(string name, CustomType dataType, float value, string unit)
        {
            Name = name;
            Value = value;
            Unit = unit;
            Type = dataType;
        }
    }

    public enum CustomType
    {
        Voltage, // V
        Clock, // MHz
        Temperature, // °C
        Load, // %
        Fan, // RPM
        Flow, // L/h
        Control, // %
        Level, // %
        Factor, // 1
        Power, // W
        Data, // GB = 2^30 Bytes    
        SmallData, // MB = 2^20 Bytes
        Throughput, // MB/s = 2^20 Bytes/s
        Download,
        Upload,
        Unknown = 99
    }
}
