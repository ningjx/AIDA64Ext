﻿using NingMonitor.Models;
using PerformanceTools;
using System.Collections.Generic;

namespace NingMonitor.Handlers
{
    public static class PerformanceHandler
    {
        private static readonly PerformanceCounters pCounters;
        static PerformanceHandler()
        {

            List<CounterConfig> pCounterInfos = new List<CounterConfig>
            {
                new CounterConfig("Network Interface","Bytes Received/sec",CustomType.Download,NetFunc),
                new CounterConfig("Network Interface","Bytes Sent/sec",CustomType.Upload,NetFunc),
            };
            pCounters = new PerformanceCounters(pCounterInfos, 1000);
            pCounters.ReciveData += PCounters_ReciveData;
            pCounters.Start();
        }

        private static void PCounters_ReciveData(List<CountersResult> datas)
        {
            for (int i = 0; i < datas.Count; i++)
            {
                PerformanceDatas.ADD(datas[i].InstanceName + " " + datas[i].CounterName, datas[i].Type, datas[i].Value, datas[i].Unit);
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
