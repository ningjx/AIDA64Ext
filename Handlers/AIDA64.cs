using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using AIDA64Ext.Models;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;

namespace AIDA64Ext.Handlers
{
    [Obsolete]
    public static class AIDA64
    {
        public static AIDA64Infos AIDA64Infos = new AIDA64Infos();

        public static void Start()
        {

        }

        static AIDA64()
        {
            Timer timer = new Timer(500)
            {
                AutoReset = true,
                Enabled = true,
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                MemoryMappedFile memory = MemoryMappedFile.OpenExisting("AIDA64_SensorValues");
                MemoryMappedViewAccessor visitor = memory.CreateViewAccessor();
                long size = visitor.Capacity;
                byte[] bytes = new byte[size];
                for (int i = 0; i < size; i++)
                {
                    bytes[i] = visitor.ReadByte(i);
                }
                visitor.Dispose();
                memory.Dispose();
                string info = $"<AIDA64Info>{Encoding.Default.GetString(bytes).Replace('\0', ' ')}</AIDA64Info>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(info);
                string json = JsonConvert.SerializeXmlNode(doc);
                AIDA64Infos = JsonConvert.DeserializeObject<AIDA64Infos>(json);
            }
            catch{}
        }

        public static AIDA64Infos GetInfos()
        {
            MemoryMappedFile memory = MemoryMappedFile.OpenExisting("AIDA64_SensorValues");
            MemoryMappedViewAccessor visitor = memory.CreateViewAccessor();
            long size = visitor.Capacity;
            byte[] bytes = new byte[size];
            for (int i = 0; i < size; i++)
            {
                bytes[i] = visitor.ReadByte(i);
            }
            visitor.Dispose();
            memory.Dispose();
            string info = $"<AIDA64Info>{Encoding.Default.GetString(bytes).Replace('\0', ' ')}</AIDA64Info>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(info);
            string json = JsonConvert.SerializeXmlNode(doc);
            return JsonConvert.DeserializeObject<AIDA64Infos>(json);
        }

        public static Item GetItemByLabel(string label)
        {
            return AllItems.Where(t => t.Label == label).FirstOrDefault() ?? new Item();
        }

        public static Item GetItemById(string id)
        {
            return AllItems.Where(t => t.ID == id).FirstOrDefault() ?? new Item();
        }

        private static List<Item> AllItems
        {
            get
            {
                List<Item> allItems = new List<Item>();
                if (AIDA64Infos.AIDA64Info.System != null)
                    allItems.AddRange(AIDA64Infos.AIDA64Info.System);
                if (AIDA64Infos.AIDA64Info.Temperature != null)
                    allItems.AddRange(AIDA64Infos.AIDA64Info.Temperature);
                if (AIDA64Infos.AIDA64Info.Volt != null)
                    allItems.AddRange(AIDA64Infos.AIDA64Info.Volt);
                if (AIDA64Infos.AIDA64Info.Power != null)
                    allItems.AddRange(AIDA64Infos.AIDA64Info.Power);
                return allItems;
            }
        }
    }
}
