using AIDA64Ext.Extension;
using AIDA64Ext.Handlers;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace AIDA64Ext.Models
{
    public class PerformanceData
    {
        public Dictionary<string, OHMItem> Items { get; } = new Dictionary<string, OHMItem>();

        public void ADD(string name, SensorType sensorType, float value, string unit)
        {
            Items.AddOrUpdate(name + sensorType, new OHMItem(name, sensorType, value, unit));
        }

        public void ADD(string name, CustomType dataType, float value, string unit)
        {
            Items.AddOrUpdate(name + dataType, new OHMItem(name, dataType, value, unit));
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public OHMItem GetByName(string name, CustomType dataType)
        {
            if (Items.TryGetValue(name + dataType, out OHMItem item))
                return item;
            else
                return new OHMItem(name + dataType, SensorType.Unknown, 0, "");
        }

        public List<OHMItem> AllItems
        {
            get
            {
                OHMItem[] items = new OHMItem[Items.Values.Count];
                Items.Values.CopyTo(items, 0);
                return items.ToList();
            }
        }
    }
}
