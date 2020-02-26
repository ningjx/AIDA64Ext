using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIDA64Ext.Enums;
using AIDA64Ext.Models;
using AIDA64Ext.Handlers;
using static System.Windows.Forms.CheckedListBox;

namespace AIDA64Ext.Extension
{
    public static class Extensions
    {
        /// <summary>
        /// 给复选列表添加一个全选按钮
        /// </summary>
        /// <param name="checkedListBox"></param>
        public static void AddSeleAllItem(this CheckedListBox checkedListBox)
        {
            checkedListBox.Items.Add("全选", false);
        }

        /// <summary>
        /// 在复选列表添加AIDA数据项
        /// </summary>
        /// <param name="checkedListBox"></param>
        public static void AddAIDAItems(this CheckedListBox checkedListBox, AIDADataType aIDADataType)
        {
            List<Item> items = new List<Item>();
            switch (aIDADataType)
            {
                case AIDADataType.System:
                    items = AIDA64.AIDA64Infos.AIDA64Info.System ?? new List<Item>();
                    break;
                case AIDADataType.Temperature:
                    items = AIDA64.AIDA64Infos.AIDA64Info.Temperature ?? new List<Item>();
                    break;
                case AIDADataType.Volt:
                    items = AIDA64.AIDA64Infos.AIDA64Info.Volt ?? new List<Item>();
                    break;
                case AIDADataType.Power:
                    items = AIDA64.AIDA64Infos.AIDA64Info.Power ?? new List<Item>();
                    break;
            }
            items.ForEach(t =>
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
