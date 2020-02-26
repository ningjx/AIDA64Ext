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
            AIDA64.AIDA64Infos.AIDA64Info.System?.ForEach(t => {
                if (Config.Config.AIDAShownItems.Contains(t.Label))
                    checkedListBox1.Items.Add(t.Label, true);
                else
                    checkedListBox1.Items.Add(t.Label, false);
            });
            AIDA64.AIDA64Infos.AIDA64Info.Temperature?.ForEach(t => {
                if (Config.Config.AIDAShownItems.Contains(t.Label))
                    checkedListBox2.Items.Add(t.Label, true);
                else
                    checkedListBox2.Items.Add(t.Label, false);
            });
            AIDA64.AIDA64Infos.AIDA64Info.Volt?.ForEach(t => {
                if (Config.Config.AIDAShownItems.Contains(t.Label))
                    checkedListBox3.Items.Add(t.Label, true);
                else
                    checkedListBox3.Items.Add(t.Label, false);
            });
            AIDA64.AIDA64Infos.AIDA64Info.Power?.ForEach(t => {
                if (Config.Config.AIDAShownItems.Contains(t.Label))
                    checkedListBox4.Items.Add(t.Label, true);
                else
                    checkedListBox4.Items.Add(t.Label, false);
            });
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                items.Add(item.ToString());
            }
            Config.Config.AIDAShownItems.AIDA64Data.System.Clear();
            items.ForEach(t=>Config.Config.AIDAShownItems.AIDA64Data.System.Add(AIDA64.GetItemByLabel(t)));
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (var item in checkedListBox2.CheckedItems)
            {
                items.Add(item.ToString());
            }
            Config.Config.AIDAShownItems.AIDA64Data.Temperature.Clear();
            items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Temperature.Add(AIDA64.GetItemByLabel(t)));
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (var item in checkedListBox3.CheckedItems)
            {
                items.Add(item.ToString());
            }
            Config.Config.AIDAShownItems.AIDA64Data.Volt.Clear();
            items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Volt.Add(AIDA64.GetItemByLabel(t)));
        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (var item in checkedListBox4.CheckedItems)
            {
                items.Add(item.ToString());
            }
            Config.Config.AIDAShownItems.AIDA64Data.Power.Clear();
            items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Power.Add(AIDA64.GetItemByLabel(t)));
        }
    }
}
