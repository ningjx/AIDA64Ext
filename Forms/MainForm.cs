﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIDA64Ext.Extension;
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
            Task.Run(() => { //AIDA64.Start(); 
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

        private bool displayShown = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (displayShown)
            {
                button4.Text = "显示参数屏幕";
                StaticForms.Forms["DisplayForm"].Hide();
                displayShown = false;
            }
            else
            {
                button4.Text = "隐藏参数屏幕";
                if (StaticForms.Forms.Keys.Contains("DisplayForm"))
                {
                    StaticForms.Forms["DisplayForm"].Show();
                    displayShown = true;
                }
                else
                {
                    DisplayForm DisplayForm = new DisplayForm();
                    DisplayForm.Show();
                    displayShown = true;
                    StaticForms.Forms.AddOrUpdate("DisplayForm", DisplayForm);
                }
            }
        }
    }
}
