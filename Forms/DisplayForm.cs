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
            WindowState = FormWindowState.Maximized;    //最大化窗体 
        }

        private void DisplayForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                Close();
                StaticForms.Forms["MainForm"].Show();
            }
        }
    }
}
