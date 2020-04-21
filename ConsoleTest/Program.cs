using AIDA64Ext.Handlers;
using AIDA64Ext.Models;
using System;
using System.Threading;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //PCounters.GetAllCategorysInfo("safasf.txt");
            //Console.WriteLine("计数器输出完成，按任意键退出");
            //Console.ReadKey();
            OHMHandler.Start();
            PerformanceHandler.Start();
            while (true)
            {
                Console.Clear();
                PerformanceDatas.AllItems.ForEach(t => Console.WriteLine($"{t.Name} {t.Type.ToString()} {t.Value.ToString("f2")}{t.Unit}"));
                Thread.Sleep(1000);
            }
        }
    }
}
