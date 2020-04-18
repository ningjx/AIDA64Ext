using AIDA64Ext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDA64Ext.Handlers
{
    public static class PerformanceHandler
    {
        private static PCounters pCounters;
        static PerformanceHandler()
        {
            
            List<PCounterInfo> pCounterInfos = new List<PCounterInfo>
            {
                new PCounterInfo("Network Interface","Bytes Received/sec",CustomType.Download,"KB/s",NetFunc),
                new PCounterInfo("Network Interface","Bytes Sent/sec",CustomType.Download,"KB/s",NetFunc),
            };
            pCounters = new PCounters(pCounterInfos);
            pCounters.ReciveData += PCounters_ReciveData;
            pCounters.Start();
        }

        private static void PCounters_ReciveData(List<CountersResult> datas)
        {
            for(int i=0;i< datas.Count; i++)
            {
                PerformanceParams.ADD(datas[i].InstanceName+ " "+datas[i].CounterName, datas[i].Type, datas[i].Value, datas[i].Unit);
            }
        }

        private static void NetFunc(long count, out float currCount, out string unit)
        {
            if ((currCount = count / 1024F) < 1024)
            {
                unit = "KB/s";
                return;
            }
            else
            {
                currCount /= 1024F;
                unit = "MB/s";
                return;
            }
        }

        public static void Start() { }
    }
}
