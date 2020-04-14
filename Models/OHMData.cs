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

        public void ADD(string name, float value, string unit)
        {
            if (Items.Keys.Contains(name))
                Items[name] = new OHMItem(name, value, unit);
            else
                Items.Add(name,new OHMItem(name, value, unit));
        }

        public OHMItem GetByName(string name)
        {
            if (Items.TryGetValue(name, out OHMItem item))
                return item;
            else
                return new OHMItem(name, 0, "");
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

        public OHMItem(string name, float value, string unit)
        {
            Name = name;
            Value = value;
            Unit = unit;
        }
    }
}
