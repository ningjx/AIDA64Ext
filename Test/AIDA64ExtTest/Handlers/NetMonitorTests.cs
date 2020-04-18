using AIDA64Ext.Handlers;
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

        [TestMethod()]
        public void Test()
        {
            PCounters.GetAllCategorysInfo("safasf.txt");
        }
    }




    public class TestData
    {
        public string Name;
        public string Help;
        public object Value;
    }
}