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
        public AIDA64Infos()
        {
            AIDA64Info = new AIDA64Data();
        }

        [JsonProperty("AIDA64Info")]
        public AIDA64Data AIDA64Info { get; set; }

        public string Get(string id)
        {
            return AIDA64Info.Get(id);
        }
    }

    public class AIDA64Data
    {
        /// <summary>
        /// 系统
        /// </summary>
        [JsonProperty("sys")]
        public List<Item> System { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        [JsonProperty("temp")]
        public List<Item> Temperature { get; set; }

        /// <summary>
        /// 电压
        /// </summary>
        [JsonProperty("volt")]
        public List<Item> Volt { get; set; }

        /// <summary>
        /// 功耗
        /// </summary>
        [JsonProperty("pwr")]
        public List<Item> Power { get; set; }

        public string Get(string id)
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
            Item item = allItems.Where(t => t.ID == id).FirstOrDefault();
            if (item == null)
                return "null";
            return item.Value;
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
