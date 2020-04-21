using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NingMonitor.Handlers;

namespace NingMonitor.Forms
{
    public partial class StutasForm : Form
    {
        public StutasForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            //this.WindowState = FormWindowState.Maximized;    //最大化窗体 
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var items = Config.ConfigData.AIDAShownItems.AIDA64Data.Items;
            string infos = string.Empty;
            items?.ForEach(t =>
            {
                var item = AIDA64Handler.GetItemByLabel(t.Label);
                infos += $"{item.Label}:{item.Value}\n";
            });
            richTextBox1.Text = infos;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void StutasForm_Load(object sender, EventArgs e)
        {

        }

        private void StutasForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Dispose();
                StaticForms.Forms["MainForm"].Show();
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            StutasForm_KeyPress(sender, e);
        }
    }
}
