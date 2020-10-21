using NingMonitor.Handlers;
using NingMonitor.Models;
using OpenHardwareMonitor.Hardware;
using PerformanceTools;
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
        readonly Timer timer = new Timer(1000);
        public DisplayForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            OHMHandler_GotData();
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            this.Width = 1080;
            this.Height = 1920;
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

        private void OHMHandler_GotData()
        {
            tempControl1.SetTempWithPID("CPU温度", PerformanceDatas.GetByName("CPU Core #1", CustomType.Temperature).Value);
            var item1 = PerformanceDatas.GetByName("CPU Total", CustomType.Load);
            instrument11.SetValueWithPID("CPU占用", item1.Value, item1.Unit, 100);
            var item2 = PerformanceDatas.GetByName("Memory", CustomType.Load);
            instrument12.SetValueWithPID("内存占用", item2.Value, item2.Unit, 100);

            var item3 = PerformanceDatas.GetByName("CPU Package", CustomType.Power);
            instrument13.SetValueWithPID("CPU功率", item3.Value, item3.Unit, 100);
        }
    }
}
