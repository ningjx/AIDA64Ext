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
            long func(long count, string aa)
            {
                return count;
            }
            List<PCounterInfo> pCounterInfos = new List<PCounterInfo>
            {
                new PCounterInfo("Network Interface","Bytes Received/sec",CustomType.Download,"KB/s",func),
                new PCounterInfo("Network Interface","Bytes Sent/sec",CustomType.Download,"KB/s"),
            };
            pCounters = new PCounters(pCounterInfos);
            pCounters.ReciveData += PCounters_ReciveData;
            pCounters.Start();
        }

        private static void PCounters_ReciveData(List<CountersResult> datas)
        {
            for(int i=0;i< datas.Count; i++)
            {
                PerformanceParams.ADD(datas[i].CounterName, datas[i].Type, datas[i].Count, datas[i].Unit);
            }
        }

    }
}
