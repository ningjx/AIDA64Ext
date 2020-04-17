using AIDA64Ext.Extension;
using AIDA64Ext.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AIDA64Ext.Handlers
{
    /// <summary>
    /// 一堆性能计数器
    /// </summary>
    public class PCounters
    {
        private Timer timer = new Timer();
        private List<PCounterData> Counters = new List<PCounterData>();
        private Dictionary<string, CountersResult> CounterResults = new Dictionary<string, CountersResult>();

        public PCounters(List<PCounterInfo> pCounterInfos, int miSec = 30, string instanceName = null)
        {
            foreach (var item in pCounterInfos)
            {
                Counters.Add(new PCounterData(item));
            }
            timer.Interval = miSec;
            timer.AutoReset = true;
            timer.Elapsed += GetData;
            timer.Enabled = true;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void GetData(object sender, ElapsedEventArgs e)
        {
            foreach (var counter in Counters)
            {
                counter.Value = counter.Counter.NextSample().RawValue;
                counter.Count = counter.Value - counter.Value;
                counter.OldValue = counter.Value;

                CounterResults.AddOrUpdate(counter.CounterName, new CountersResult(counter));
            }
            ReciveData?.Invoke(CounterResults.Values.ToList());
        }

        public void SetTimerInterval(int miSec)
        {
            if (miSec > 0)
            {
                timer.Stop();
                timer.Interval = miSec;
                timer.Start();
            }
        }

        public delegate void RefreshHandler(List<CountersResult> datas);

        public event RefreshHandler ReciveData;
    }

    public class PCounterInfo
    {
        public string CategoryName;
        public string CounterName;
        public CustomType Type;
        public string Unit;
        public DealDataHandler Func;
        public PCounterInfo(string categoryName, string counterName, CustomType type, string unit, DealDataHandler func = null)
        {
            CategoryName = categoryName;
            CounterName = counterName;
            Type = type;
            Unit = unit;
            Func = func;
        }
    }

    public delegate long DealDataHandler(long count,string unit);

    public class PCounterData
    {
        public PerformanceCounter Counter;

        public long Value;
        public long OldValue;
        public long Count;
        public string CategoryName;
        public string CounterName;
        public CustomType Type;
        public string Unit;
        public DealDataHandler Func;
        public PCounterData(string categoryName, string counterName, CustomType type, string unit, DealDataHandler func = null)
        {
            CategoryName = categoryName;
            CounterName = counterName;
            Counter = new PerformanceCounter(categoryName, counterName);
            Type = type;
            Unit = unit;
            Func = func;
        }

        public PCounterData(PCounterInfo info)
        {
            CategoryName = info.CategoryName;
            CounterName = info.CounterName;
            Counter = new PerformanceCounter(info.CategoryName, info.CounterName);
            Type = info.Type;
            Unit = info.Unit;
            Func = info.Func;
            if (Func != null)
            {
                Count = Func.Invoke(Count,Unit);
            }
        }
    }

    public class CountersResult
    {
        public string CategoryName;
        public string CounterName;
        public long Count;
        public CustomType Type;
        public string Unit;

        public CountersResult(PCounterData data)
        {
            CategoryName = data.CategoryName;
            CounterName = data.CounterName;
            Count = data.Count;
            Type = data.Type;
            Unit = data.Unit;
        }
    }
}
