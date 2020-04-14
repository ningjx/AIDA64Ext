using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDA64Ext.Models
{
    public class OHMData
    {
        public Dictionary<string, OHMItem> Items { get; } = new Dictionary<string, OHMItem>();

        public void ADD(string name, SensorType type, float value, string unit)
        {
            if (Items.Keys.Contains(name+ type))
                Items[name + type] = new OHMItem(name, type, value, unit);
            else
                Items.Add(name + type, new OHMItem(name,type, value, unit));
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public OHMItem GetByName(string name, SensorType type)
        {
            if (Items.TryGetValue(name+ type, out OHMItem item))
                return item;
            else
                return new OHMItem(name+ type, SensorType.Unknown, 0, "");
        }

        public List<OHMItem> AllItems { get {
                OHMItem[] items = new OHMItem[Items.Values.Count];
                Items.Values.CopyTo(items, 0);
                return items.ToList();
            } }
    }

    public class OHMItem
    {
        public string Unit = string.Empty;
        public float Value;
        public string Name = string.Empty;
        public SensorType Type;

        public OHMItem(string name, SensorType type,float value, string unit)
        {
            Name = name;
            Value = value;
            Unit = unit;
            Type = type;
        }
    }
}
