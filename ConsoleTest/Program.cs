using AIDA64Ext.Handlers;
using Newtonsoft.Json;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OHM.Start();
            //Thread.Sleep(2000);
            //var test2 = JsonConvert.SerializeObject(OHM.OHMData.AllItems);
            while (true)
            {
                
                
       
                
           
                
                Console.Clear();
                //var item1 = OHM.OHMData.GetByName("CPU Total", SensorType.Load);
                //var item2 = OHM.OHMData.GetByName("Memory", SensorType.Load);
                //Console.Write($"{item1.Value}{item1.Unit}");
                //Console.Write($"{item2.Value}{item2.Unit}");
                OHM.OHMData.AllItems.ForEach(t => Console.WriteLine($"{t.Name} {t.Type.ToString()} {t.Value.ToString("f2")}{t.Unit}"));
                Thread.Sleep(500);
            }
        }
    }
}
