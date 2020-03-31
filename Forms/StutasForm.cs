using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIDA64Ext.Handlers;

namespace AIDA64Ext.Forms
{
    public partial class StutasForm : Form
    {
        public StutasForm()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var items = Config.Config.AIDAShownItems.AIDA64Data.Items;
            string infos = string.Empty;
            items?.ForEach(t =>
            {
                var item = AIDA64.GetItemByLabel(t.Label);
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
    }
}
