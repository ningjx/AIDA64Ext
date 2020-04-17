using System;
using System.Timers;
using System.Collections;
using System.Diagnostics;

namespace NetWorkSpeedMonitor
{
    /// <summary>
    /// The NetworkMonitor class monitors network speed for each network adapter on the computer,
    /// using classes for Performance counter in .NET library.
    /// </summary>
    public class NetMonitor
    {
        private Timer timer;                // The timer event executes every second to refresh the values in adapters.
        private ArrayList adapters;            // The list of adapters on the computer.
        private ArrayList monitoredAdapters;// The list of currently monitored adapters.

        public NetMonitor()
        {
            this.adapters = new ArrayList();
            this.monitoredAdapters = new ArrayList();
            EnumerateNetworkAdapters();

            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }
        /// <summary>
        /// 网卡列表
        /// </summary>
        private void EnumerateNetworkAdapters()
        {
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");

            foreach (string name in category.GetInstanceNames())
            {
                // This one exists on every computer.
                if (name == "MS TCP Loopback interface")
                    continue;
                // Create an instance of NetworkAdapter class, and create performance counters for it.
                NetworkAdapter adapter = new NetworkAdapter(name)
                {
                    dlCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", name),
                    ulCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", name)
                };
                this.adapters.Add(adapter);    // Add it to ArrayList adapter
            }
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (NetworkAdapter adapter in this.monitoredAdapters)
                adapter.Refresh();
        }

        /// <summary>
        /// Get instances of NetworkAdapter for installed adapters on this computer.
        /// </summary>
        public NetworkAdapter[] Adapters
        {
            get { return (NetworkAdapter[])this.adapters.ToArray(typeof(NetworkAdapter)); }
        }

        /// <summary>
        /// Enable the timer and add all adapters to the monitoredAdapters list, 
        /// unless the adapters list is empty.
        /// </summary>
        public void StartMonitoring(NetworkAdapter adapter=null)
        {
            if (adapter == null && this.adapters.Count > 0)
            {
                foreach (NetworkAdapter ad in this.adapters)
                    if (!this.monitoredAdapters.Contains(ad))
                    {
                        this.monitoredAdapters.Add(ad);
                        ad.Init();
                    }

                timer.Enabled = true;
            }
            else if(adapter !=null)
            {
                if (!this.monitoredAdapters.Contains(adapter))
                {
                    this.monitoredAdapters.Add(adapter);
                    adapter.Init();
                }
                timer.Enabled = true;
            }

        }

        /// <summary>
        /// Remove the specified adapter from the monitoredAdapters list, and 
        /// disable the timer if the monitoredAdapters list is empty.
        /// </summary>
        public void StopMonitoring(NetworkAdapter adapter = null)
        {
            if (adapter == null)
            {
                this.monitoredAdapters.Clear();
                timer.Enabled = false;
                return;
            }
            if (this.monitoredAdapters.Contains(adapter))
                this.monitoredAdapters.Remove(adapter);
            if (this.monitoredAdapters.Count == 0)
                timer.Enabled = false;
        }
    }

    /// <summary>
    /// Represents a network adapter installed on the machine.
    /// Properties of this class can be used to obtain current network speed.
    /// </summary>
    public class NetworkAdapter
    {
        /// <summary>
        /// Instances of this class are supposed to be created only in an NetworkMonitor.
        /// </summary>
        internal NetworkAdapter(string name)
        {
            this.name = name;
        }

        private long dlSpeed, ulSpeed;         // Download/Upload speed in bytes per second.
        private long dlValue, ulValue;         // Download/Upload counter value in bytes.
        private long dlValueOld, ulValueOld; // Download/Upload counter value one second earlier, in bytes.

        internal string name;                                // The name of the adapter.
        internal PerformanceCounter dlCounter, ulCounter;    // Performance counters to monitor download and upload speed.
        /// <summary>
        /// Preparations for monitoring.
        /// </summary>
        internal void Init()
        {
            // Since dlValueOld and ulValueOld are used in method refresh() to calculate network speed, they must have be initialized.
            this.dlValueOld = this.dlCounter.NextSample().RawValue;
            this.ulValueOld = this.ulCounter.NextSample().RawValue;
        }
        /// <summary>
        /// Obtain new sample from performance counters, and refresh the values saved in dlSpeed, ulSpeed, etc.
        /// This method is supposed to be called only in NetworkMonitor, one time every second.
        /// </summary>
        internal void Refresh()
        {
            this.dlValue = this.dlCounter.NextSample().RawValue;
            this.ulValue = this.ulCounter.NextSample().RawValue;

            // Calculates download and upload speed.
            this.dlSpeed = this.dlValue - this.dlValueOld;
            this.ulSpeed = this.ulValue - this.ulValueOld;

            this.dlValueOld = this.dlValue;
            this.ulValueOld = this.ulValue;
        }
        /// <summary>
        /// Overrides method to return the name of the adapter.
        /// </summary>
        /// <returns>The name of the adapter.</returns>
        public override string ToString()
        {
            return this.name;
        }
        /// <summary>
        /// The name of the network adapter.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }
        /// <summary>
        /// Current download speed in bytes per second.
        /// </summary>
        public long DownloadSpeed
        {
            get { return this.dlSpeed; }
        }
        /// <summary>
        /// Current upload speed in bytes per second.
        /// </summary>
        public long UploadSpeed
        {
            get { return this.ulSpeed; }
        }
        /// <summary>
        /// Current download speed in kbytes per second.
        /// </summary>
        public double DownloadSpeedKBps
        {
            get { return this.dlSpeed / 1024.0; }
        }
        /// <summary>
        /// Current upload speed in kbytes per second.
        /// </summary>
        public double UploadSpeedKBps
        {
            get { return this.ulSpeed / 1024.0; }
        }
    }
}