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
    public static class AIDA64
    {
        public static AIDA64Infos AIDA64Infos = new AIDA64Infos();

        static AIDA64()
        {
            Timer timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MemoryMappedFile memory = MemoryMappedFile.OpenExisting("AIDA64_SensorValues");
            MemoryMappedViewAccessor visitor = memory.CreateViewAccessor();
            long size = visitor.Capacity;
            byte[] bytes = new byte[size];
            for (int i = 0; i < size; i++)
            {
                bytes[i] = visitor.ReadByte(i);
            }
            string info = $"<AIDA64Info>{Encoding.Default.GetString(bytes).Replace('\0', ' ')}</AIDA64Info>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(info);
            string json = JsonConvert.SerializeXmlNode(doc);
            AIDA64Infos = JsonConvert.DeserializeObject<AIDA64Infos>(json);
            visitor.Dispose();
            memory.Dispose();
        }
    }
}
