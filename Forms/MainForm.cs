using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIDA64Ext.Forms;
using AIDA64Ext.Handlers;

namespace AIDA64Ext
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AIDA64.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AIDAParamForm form = new AIDAParamForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StutasForm stutasForm = new StutasForm();
            stutasForm.Show();
        }
    }
}
