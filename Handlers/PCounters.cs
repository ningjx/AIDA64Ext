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
        private List<CounterSets> CountersSets = new List<CounterSets>();
        private Dictionary<string, CountersResult> CounterResults = new Dictionary<string, CountersResult>();
        private bool Lock = false;
        public PCounters(List<PCounterInfo> pCounterInfos, int miSec = 1000)
        {
            foreach (var item in pCounterInfos)
            {
                CountersSets.Add(new CounterSets(item));
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
            if (Lock)
                return;
            Lock = true;
            foreach (var counterSet in CountersSets)
            {
                foreach (var counter in counterSet.CounterDatas)
                {
                    counter.Value = counter.Counter.NextSample().RawValue;
                    counter.Count = counter.Value - counter.OldValue;
                    counter.OldValue = counter.Value;
                    CounterResults.AddOrUpdate(counter.InstanceName + counter.CounterName, new CountersResult(counter));
                }
            }
            ReciveData?.Invoke(CounterResults.Values.ToList());
            Lock = false;
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
        public string InstanceName;

        public CustomType Type;
        public string Unit;
        public DealDataHandler Func;
        public PCounterInfo(string categoryName, string counterName, CustomType type, string unit, DealDataHandler func = null, string instanceName = null)
        {
            CategoryName = categoryName;
            CounterName = counterName;
            Type = type;
            Unit = unit;
            Func = func;
            InstanceName = instanceName;
        }
    }

    public delegate void DealDataHandler(long count, out long currCount, out string currUnit);

    public class CounterSets
    {
        public List<CounterData> CounterDatas = new List<CounterData>();
        public string CategoryName;
        public string CounterName;
        public string InstanceName;
        public CustomType Type;
        public string Unit;
        public DealDataHandler Func;

        public CounterSets(PCounterInfo info)
        {
            Type = info.Type;
            Unit = info.Unit;
            Func = info.Func;
            CategoryName = info.CategoryName;
            CounterName = info.CounterName;
            InstanceName = info.InstanceName;
            if (info.InstanceName == null)
            {
                PerformanceCounterCategory category = new PerformanceCounterCategory(CategoryName);
                foreach (string name in category.GetInstanceNames())
                {
                    CounterDatas.Add(new CounterData(new PerformanceCounter(CategoryName, CounterName, name), Type, Unit, Func));
                }
            }
            else
                CounterDatas.Add(new CounterData(new PerformanceCounter(CategoryName, CounterName, InstanceName), Type, Unit, Func));
        }
    }

    public class CounterData
    {
        public long Value;
        public long OldValue;
        public long Count;
        public string CategoryName;
        public string CounterName;
        public string InstanceName;
        public PerformanceCounter Counter;
        public CustomType Type;
        public string Unit;
        public DealDataHandler Func;
        public CounterData(PerformanceCounter counter, CustomType type, string unit, DealDataHandler func)
        {
            Counter = counter;
            InstanceName = counter.InstanceName;
            CounterName = counter.CounterName;
            CategoryName = counter.CategoryName;
            Type = type;
            Unit = unit;
            Func = func;
        }
    }

    public class CountersResult
    {
        public string CategoryName;
        public string CounterName;
        public string InstanceName;
        public long Count;
        public CustomType Type;
        public string Unit;
        public DealDataHandler Func;
        public CountersResult(CounterData data)
        {
            CategoryName = data.CategoryName;
            CounterName = data.CounterName;
            InstanceName = data.InstanceName;
            Count = data.Count;
            Type = data.Type;
            Unit = data.Unit;
            Func = data.Func;
            Func?.Invoke(Count, out Count, out Unit);
        }
    }
}
