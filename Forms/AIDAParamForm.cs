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
using AIDA64Ext.Models;
using AIDA64Ext.Config;
using AIDA64Ext.Extension;
using AIDA64Ext.Enums;

namespace AIDA64Ext.Forms
{
    public partial class AIDAParamForm : Form
    {
        public AIDAParamForm()
        {
            InitializeComponent();

        }

        private void AIDAParamForm_Load(object sender, EventArgs e)
        {
            checkedListBox1.CheckOnClick = true;
            checkedListBox2.CheckOnClick = true;
            checkedListBox3.CheckOnClick = true;
            checkedListBox4.CheckOnClick = true;

            tabPage1.Text += $"({AIDA64.AIDA64Infos.AIDA64Info.System?.Count??0})";
            tabPage2.Text += $"({AIDA64.AIDA64Infos.AIDA64Info.Temperature?.Count??0})";
            tabPage3.Text += $"({AIDA64.AIDA64Infos.AIDA64Info.Volt?.Count??0})";
            tabPage4.Text += $"({AIDA64.AIDA64Infos.AIDA64Info.Power?.Count??0})";

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
            //AIDA64.AIDA64Infos.AIDA64Info.System?.ForEach(t => {
            //    if (Config.Config.AIDAShownItems.Contains(t.Label))
            //        checkedListBox1.Items.Add(t.Label, true);
            //    else
            //        checkedListBox1.Items.Add(t.Label, false);
            //});
            //AIDA64.AIDA64Infos.AIDA64Info.Temperature?.ForEach(t => {
            //    if (Config.Config.AIDAShownItems.Contains(t.Label))
            //        checkedListBox2.Items.Add(t.Label, true);
            //    else
            //        checkedListBox2.Items.Add(t.Label, false);
            //});
            //AIDA64.AIDA64Infos.AIDA64Info.Volt?.ForEach(t => {
            //    if (Config.Config.AIDAShownItems.Contains(t.Label))
            //        checkedListBox3.Items.Add(t.Label, true);
            //    else
            //        checkedListBox3.Items.Add(t.Label, false);
            //});
            //AIDA64.AIDA64Infos.AIDA64Info.Power?.ForEach(t => {
            //    if (Config.Config.AIDAShownItems.Contains(t.Label))
            //        checkedListBox4.Items.Add(t.Label, true);
            //    else
            //        checkedListBox4.Items.Add(t.Label, false);
            //});
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkedListBox1.CheckedItems.Contains("全选"))
            //{
            //    checkedListBox1.Items.SyncAllItems(AIDADataType.System);
            //    checkedListBox1.SetAllSelected();
            //}
            //else
                checkedListBox1.CheckedItems.SyncSeletedItems(AIDADataType.System);
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkedListBox2.CheckedItems.Contains("全选"))
            //{
            //    checkedListBox2.Items.SyncAllItems(AIDADataType.Temperature);
            //    checkedListBox2.SetAllSelected();
            //}
            //else
                checkedListBox2.CheckedItems.SyncSeletedItems(AIDADataType.Temperature);
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkedListBox3.CheckedItems.Contains("全选"))
            //{
            //    checkedListBox3.Items.SyncAllItems(AIDADataType.Volt);
            //    checkedListBox3.SetAllSelected();
            //}
            //else
                checkedListBox3.CheckedItems.SyncSeletedItems(AIDADataType.Volt);
        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkedListBox4.CheckedItems.Contains("全选"))
            //{
            //    checkedListBox4.Items.SyncAllItems(AIDADataType.Power);
            //    checkedListBox4.SetAllSelected();
            //}  
            //else
                checkedListBox4.CheckedItems.SyncSeletedItems(AIDADataType.Power);
        }
    }
}
