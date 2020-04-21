using NingMonitor.Extension;
using NingMonitor.Handlers;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingMonitor.Models
{
    public static class PerformanceDatas
    {
        public static Dictionary<string, PerformanceItem> Items { get; } = new Dictionary<string, PerformanceItem>();

        public static void ADD(string name, SensorType sensorType, float value, string unit)
        {
            Items.AddOrUpdate(name + sensorType, new PerformanceItem(name, sensorType, value, unit));
        }

        public static void ADD(string name, CustomType dataType, float value, string unit)
        {
            Items.AddOrUpdate(name + dataType, new PerformanceItem(name, dataType, value, unit));
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static PerformanceItem GetByName(string name, CustomType dataType)
        {
            if (Items.TryGetValue(name + dataType, out PerformanceItem item))
                return item;
            else
                return new PerformanceItem(name + dataType, SensorType.Unknown, 0, "");
        }

        public static List<PerformanceItem> AllItems
        {
            get
            {
                PerformanceItem[] items = new PerformanceItem[Items.Values.Count];
                Items.Values.CopyTo(items, 0);
                return items.ToList();
            }
        }
    }

    public class PerformanceItem
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

        public PerformanceItem(string name, SensorType sensorType, float value, string unit)
        {
            Name = name;
            Value = value;
            Unit = unit;
            Type = (CustomType)Enum.Parse(typeof(CustomType), sensorType.GetHashCode().ToString());
        }

        public PerformanceItem(string name, CustomType dataType, float value, string unit)
        {
            Name = name;
            Value = value;
            Unit = unit;
            Type = dataType;
        }
    }
}
