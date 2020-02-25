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

namespace AIDA64Ext
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = AIDA64.AIDA64Infos.Get("SMEMUTI");
            textBox2.Text = AIDA64.AIDA64Infos.Get("SCPUUTI");
            textBox3.Text = AIDA64.AIDA64Infos.Get("TCC-1-1");
        }
    }
}
