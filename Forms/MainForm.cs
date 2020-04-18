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
            StaticForms.Forms.Add("MainForm", this);
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            //WindowState = FormWindowState.Maximized;    //最大化窗体 
            Task.Run(() => { AIDA64.Start(); 
                OHM.Start(); });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AIDAParamForm form = new AIDAParamForm();
            form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StutasForm stutasForm = new StutasForm();
            stutasForm.Show();
            Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayForm displayForm = new DisplayForm();
            displayForm.Show();
            Hide();
        }
    }
}
