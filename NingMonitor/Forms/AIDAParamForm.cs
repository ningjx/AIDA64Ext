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
using NingMonitor.Models;
using NingMonitor.Extension;
using NingMonitor.Enums;

namespace NingMonitor.Forms
{
    public partial class AIDAParamForm : Form
    {
        public AIDAParamForm()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            //this.WindowState = FormWindowState.Maximized;    //最大化窗体 
        }

        private void AIDAParamForm_Load(object sender, EventArgs e)
        {
            checkedListBox1.CheckOnClick = true;
            checkedListBox2.CheckOnClick = true;
            checkedListBox3.CheckOnClick = true;
            checkedListBox4.CheckOnClick = true;

            tabPage1.Text += $"({AIDA64Handler.AIDA64Infos.AIDA64Info.System?.Count ?? 0})";
            tabPage2.Text += $"({AIDA64Handler.AIDA64Infos.AIDA64Info.Temperature?.Count ?? 0})";
            tabPage3.Text += $"({AIDA64Handler.AIDA64Infos.AIDA64Info.Volt?.Count ?? 0})";
            tabPage4.Text += $"({AIDA64Handler.AIDA64Infos.AIDA64Info.Power?.Count ?? 0})";

            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            checkedListBox4.Items.Clear();

            //checkedListBox1.AddSeleAllItem();
            //checkedListBox2.AddSeleAllItem();
            //checkedListBox3.AddSeleAllItem();
            //checkedListBox4.AddSeleAllItem();

            checkedListBox1.AddAIDAItems(AIDADataType.System);
            checkedListBox2.AddAIDAItems(AIDADataType.Temperature);
            checkedListBox3.AddAIDAItems(AIDADataType.Volt);
            checkedListBox4.AddAIDAItems(AIDADataType.Power);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.CheckedItems.SyncSeletedItems(AIDADataType.System);
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox2.CheckedItems.SyncSeletedItems(AIDADataType.Temperature);
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox3.CheckedItems.SyncSeletedItems(AIDADataType.Volt);
        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox4.CheckedItems.SyncSeletedItems(AIDADataType.Power);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            Dispose();
            StaticForms.Forms["MainForm"].Show();
        }

        private void AIDAParamForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Dispose();
                StaticForms.Forms["MainForm"].Show();
            }
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Dispose();
                StaticForms.Forms["MainForm"].Show();
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void AIDAParamForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            StaticForms.Forms["MainForm"].Show();
        }
    }
}
