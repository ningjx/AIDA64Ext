using NingMonitor.Handlers;
using NingMonitor.Models;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace NingMonitor.Forms
{
    public partial class DisplayForm : Form
    {
        readonly Timer timer3000 = new Timer(3000);
        readonly Timer timer1000 = new Timer(1000);
        public DisplayForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            timer3000.Elapsed += OHMHandler_GotData;
            timer3000.AutoReset = true;
            timer3000.Enabled = true;

            timer1000.Elapsed += OHMHandler_GotData2;
            timer1000.AutoReset = true;
            timer1000.Enabled = true;
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            this.Width = 1080;
            this.Height = 1920;
            //instrument21.刷新间隔 = 500;
        }

        private void DisplayForm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private bool formBorderStyle = false;
        private void DisplayForm_DoubleClick(object sender, EventArgs e)
        {
            if (formBorderStyle)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                formBorderStyle = false;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                formBorderStyle = true;
            }
        }

        private void DisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void DisplayForm_Shown(object sender, EventArgs e)
        {
            //OHMHandler.GotData += OHMHandler_GotData;
        }

        private void OHMHandler_GotData(object sender, System.Timers.ElapsedEventArgs e)
        {
            tempControl1.SetValueWithPID(PerformanceDatas.GetByName("CPU Core #1", CustomType.Temperature).Value);// "CPU温度",);
            var item1 = PerformanceDatas.GetByName("CPU Total", CustomType.Load);
            instrument11.SetValueWithPID(item1.Value, item1.Unit, 100, "CPU占用");

            //instrument21.Value = item1.Value;

            var item2 = PerformanceDatas.GetByName("Memory", CustomType.Load);
            instrument12.SetValueWithPID(item2.Value, item2.Unit, 100, "内存占用");

            var item3 = PerformanceDatas.GetByName("CPU Package", CustomType.Power);
            instrument13.SetValueWithPID(item3.Value, item3.Unit, 100, "CPU功率");

            var item4 = PerformanceDatas.GetByName("Intel[R] Wireless-AC 9560 Bytes Received/sec", CustomType.Download);
            
            var item5 = PerformanceDatas.GetByName("Intel[R] Wireless-AC 9560 Bytes Sent/sec", CustomType.Upload);

            netSpeedControl1.SetNetSpeed(item4.Value, item4.Unit, item5.Value, item5.Unit);
        }

        private void OHMHandler_GotData2(object sender, System.Timers.ElapsedEventArgs e)
        {
            var item1 = PerformanceDatas.GetByName("CPU Total", CustomType.Load);

            instrument21.Value = item1.Value;
        }
    }
}
