using AIDA64Ext.Handlers;
using AIDA64Ext.Models;
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

namespace AIDA64Ext.Forms
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void Start()
        {
            Task.Run(() => {
                tempControl1.SetTempWithPID("CPU温度", 99);
                instrument11.SetValueWithPID("CPU占用", 100, "%", 100);
                instrument12.SetValueWithPID("内存占用", 100, "%", 100);
                Thread.Sleep(3000);
                tempControl1.SetTempWithPID("CPU温度", 0);
                instrument11.SetValueWithPID("CPU占用", 0, "%", 100);
                instrument12.SetValueWithPID("内存占用", 0, "%", 100);
                Thread.Sleep(2000);
                timer1.Enabled = true;
                timer1.Start();
            });
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            //WindowState = FormWindowState.Maximized;    //最大化窗体 

            this.Width = 1080;
            this.Height = 1920;
        }

        private void DisplayForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                Dispose();
                StaticForms.Forms["MainForm"].Show();
            }
        }

        private void DisplayForm_DoubleClick(object sender, EventArgs e)
        {
            Dispose();
            StaticForms.Forms["MainForm"].Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //tempControl1.SetTempWithPID(Convert.ToInt32(AIDA64.GetItemByLabel("CPU Package").Value));
            //instrument11.SetValueWithPID(Convert.ToInt32(AIDA64.GetItemById("SMEMUTI").Value)/100F);
            //instrument12.SetValueWithPID(Convert.ToInt32(AIDA64.GetItemById("SCPUUTI").Value)/100F);
            //instrument13.SetValueWithPID((float)Convert.ToDouble(AIDA64.GetItemById("SDSK1WRITESPD").Value)/100F);
            //instrument14.SetValueWithPID((float)Convert.ToDouble(AIDA64.GetItemById("SNIC5DLRATE").Value)/100F);
            
            tempControl1.SetTempWithPID("CPU温度", PerformanceParams.GetByName("CPU Core #1", CustomType.Temperature).Value);
            var item1 = PerformanceParams.GetByName("CPU Total", CustomType.Load);
            instrument11.SetValueWithPID("CPU占用", item1.Value, item1.Unit, 100);
            var item2 = PerformanceParams.GetByName("Memory", CustomType.Load);
            instrument12.SetValueWithPID("内存占用", item2.Value,item2.Unit,100);

            var item3 = PerformanceParams.GetByName("CPU Package", CustomType.Power);
            instrument13.SetValueWithPID("CPU功率", item3.Value, item3.Unit, 100);
            //instrument13.SetValueWithPID(OHM.OHMData.GetByName("CPU Package",SensorType.Temperature).Value);
            //instrument14.SetValueWithPID(OHM.OHMData.GetByName("CPU Package", SensorType.Temperature).Value);

            //tempControl1.SetTemp(Convert.ToInt32(AIDA64.GetItemByLabel("CPU Package").Value));
            //instrument11.SetValue(Convert.ToInt32(AIDA64.GetItemByLabel("Memory Utilization").Value) / 100F);
            //instrument12.SetValue(Convert.ToInt32(AIDA64.GetItemByLabel("CPU Utilization").Value) / 100F);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
