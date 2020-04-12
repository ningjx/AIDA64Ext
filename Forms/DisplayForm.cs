using AIDA64Ext.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIDA64Ext.Forms
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
        }
        private void DisplayForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            //WindowState = FormWindowState.Maximized;    //最大化窗体 
            tempControl1.SetLable("CPU温度");
            instrument11.SetLable("内存占用");
            instrument12.SetLable("CPU占用");
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
            tempControl1.SetTempWithPID(Convert.ToInt32(AIDA64.GetItemByLabel("CPU Package").Value));
            instrument11.SetValueWithPID(Convert.ToInt32(AIDA64.GetItemByLabel("Memory Utilization").Value)/100F);
            instrument12.SetValueWithPID(Convert.ToInt32(AIDA64.GetItemByLabel("CPU Utilization").Value)/100F);

            //tempControl1.SetTemp(Convert.ToInt32(AIDA64.GetItemByLabel("CPU Package").Value));
            //instrument11.SetValue(Convert.ToInt32(AIDA64.GetItemByLabel("Memory Utilization").Value) / 100F);
            //instrument12.SetValue(Convert.ToInt32(AIDA64.GetItemByLabel("CPU Utilization").Value) / 100F);
        }
    }
}
