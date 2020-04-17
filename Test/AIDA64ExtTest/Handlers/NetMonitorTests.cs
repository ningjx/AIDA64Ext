using AIDA64Ext.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetWorkSpeedMonitor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkSpeedMonitor.Tests
{
    [TestClass()]
    public class NetMonitorTests
    {
        [TestMethod()]
        public void StartMonitoringTest()
        {
            //NetworkAdapter networkAdapter = new NetworkAdapter();
        }

        [TestMethod()]
        public void NetMonitorTest()
        {
            PerformanceCounterCategory[] pcc = PerformanceCounterCategory.GetCategories();
            PerformanceCounterCategory memory = new PerformanceCounterCategory();
            List<string> test = new List<string>();
            for (int i = 0; i < pcc.Length; i++)
            {
                test.Add(pcc[i].CategoryName);
                if(pcc[i].CategoryName== "Memory")
                {
                    memory = pcc[i];
                }
            }
            string a = JsonConvert.SerializeObject(test);

            //var instancenames = memory.GetInstanceNames();
            var memorycounters = memory.GetCounters();

            List<TestData> datas = new List<TestData>();
            foreach(var item in memorycounters)
            {
                datas.Add(new TestData {Name = item.CounterName,Help= item.CategoryName, Value = item.RawValue });
            }
            FileHelper.Write(new string[] { "ssss.txt" }, JsonConvert.SerializeObject(datas));

            StringBuilder sb = new StringBuilder();
            string cn = null;
            for (int i = 0; i < pcc.Length; i++)
            {
                cn = pcc[i].CategoryName.ToUpper();
                //if (cn.IndexOf("PROCESSOR") != -1)
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("CategoryName:" + pcc[i].CategoryName + "\r\n");
                    sb.Append("MachineName:" + pcc[i].MachineName + "\r\n");

                    string[] instanceNames = pcc[i].GetInstanceNames();
                    for (int j = 0; j < instanceNames.Length; j++)
                    {

                        sb.Append("**** Instance Name **********\r\n");
                        sb.Append("InstanceName:" + instanceNames[j] + "\r\n");
                        try
                        {
                            PerformanceCounter[] counters = pcc[i].GetCounters(instanceNames[j]);
                            for (int k = 0; k < counters.Length; k++)
                            {
                                sb.Append("CounterName:" + counters[k].CounterName + "\r\n");
                            }
                        }
                        catch (Exception)
                        { }
                        sb.Append("**************************************************\r\n");
                    }

                    Trace.TraceInformation(sb.ToString());

                }

            }

        }
    }




    public class TestData
    {
        public string Name;
        public string Help;
        public object Value;
    }
}