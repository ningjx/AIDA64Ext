using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIDA64Ext.Enums;
using AIDA64Ext.Handlers;
using static System.Windows.Forms.CheckedListBox;

namespace AIDA64Ext.Extension
{
    public static class Extensions
    {
        public static void AddSeleAllItem(this CheckedListBox checkedListBox)
        {
            checkedListBox.Items.Add("全选", false);
        }

        public static void AddAIDAItems(this CheckedListBox checkedListBox)
        {
            AIDA64.AIDA64Infos.AIDA64Info.System?.ForEach(t =>
            {
                if (Config.Config.AIDAShownItems.Contains(t.Label))
                    checkedListBox.Items.Add(t.Label, true);
                else
                    checkedListBox.Items.Add(t.Label, false);
            });
        }

        public static void SyncSeletedItems(this CheckedItemCollection checkedItemCollection, AIDADataType aIDADataType)
        {
            List<string> items = new List<string>();
            foreach (var item in checkedItemCollection)
            {
                items.Add(item.ToString());
            }
            switch (aIDADataType)
            {
                case AIDADataType.System:
                    Config.Config.AIDAShownItems.AIDA64Data.System.Clear();
                    items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.System.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Temperature:
                    Config.Config.AIDAShownItems.AIDA64Data.Temperature.Clear();
                    items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Temperature.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Volt:
                    Config.Config.AIDAShownItems.AIDA64Data.Volt.Clear();
                    items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Volt.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Power:
                    Config.Config.AIDAShownItems.AIDA64Data.Power.Clear();
                    items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Power.Add(AIDA64.GetItemByLabel(t)));
                    break;
            }
        }

        public static void SyncAllItems(this ObjectCollection objectCollection, AIDADataType aIDADataType)
        {
            List<string> items = new List<string>();
            foreach (var item in objectCollection)
            {
                items.Add(item.ToString());
            }
            switch (aIDADataType)
            {
                case AIDADataType.System:
                    Config.Config.AIDAShownItems.AIDA64Data.System.Clear();
                    items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.System.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Temperature:
                    Config.Config.AIDAShownItems.AIDA64Data.Temperature.Clear();
                    items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Temperature.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Volt:
                    Config.Config.AIDAShownItems.AIDA64Data.Volt.Clear();
                    items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Volt.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Power:
                    Config.Config.AIDAShownItems.AIDA64Data.Power.Clear();
                    items.ForEach(t => Config.Config.AIDAShownItems.AIDA64Data.Power.Add(AIDA64.GetItemByLabel(t)));
                    break;
            }
        }

        public static void SetAllSelected(this CheckedListBox checkedListBox)
        {
            for(int i = 0;i< checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetSelected(i, true);
            }
        }
    }
}
