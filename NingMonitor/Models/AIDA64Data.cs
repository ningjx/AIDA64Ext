using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AIDA64Ext.Models
{
    public class AIDA64Infos
    {
        [JsonProperty("AIDA64Info")]
        public AIDA64Data AIDA64Info { get; set; } = new AIDA64Data();
    }

    public class AIDA64Data
    {
        /// <summary>
        /// 系统
        /// </summary>
        [JsonProperty("sys")]
        public List<Item> System { get; set; } = new List<Item>();

        /// <summary>
        /// 温度
        /// </summary>
        [JsonProperty("temp")]
        public List<Item> Temperature { get; set; } = new List<Item>();

        /// <summary>
        /// 电压
        /// </summary>
        [JsonProperty("volt")]
        public List<Item> Volt { get; set; } = new List<Item>();

        /// <summary>
        /// 功耗
        /// </summary>
        [JsonProperty("pwr")]
        public List<Item> Power { get; set; } = new List<Item>();

        public List<Item> Items
        {
            get
            {
                List<Item> allItems = new List<Item>();
                if (System != null)
                    allItems.AddRange(System);
                if (Temperature != null)
                    allItems.AddRange(Temperature);
                if (Volt != null)
                    allItems.AddRange(Volt);
                if (Power != null)
                    allItems.AddRange(Power);
                return allItems;
            }
        }
    }

    public class Item
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
