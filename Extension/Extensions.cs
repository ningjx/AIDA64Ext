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
using AIDA64Ext.Config;

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
                if (SysConfig.ConfigHandle.Config.AIDAShownItems.Contains(t.Label))
                    checkedListBox.Items.Add(t.Label, true);
                else
                    checkedListBox.Items.Add(t.Label, false);
            });
        }

        /// <summary>
        /// 将选择的项目同步到<see cref="AIDAShownItems"/>中
        /// </summary>
        /// <param name="checkedItemCollection"></param>
        /// <param name="aIDADataType"></param>
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
                    SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.System.Clear();
                    items.ForEach(t => SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.System.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Temperature:
                    SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Temperature.Clear();
                    items.ForEach(t => SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Temperature.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Volt:
                    SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Volt.Clear();
                    items.ForEach(t => SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Volt.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Power:
                    SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Power.Clear();
                    items.ForEach(t => SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Power.Add(AIDA64.GetItemByLabel(t)));
                    break;
            }
        }

        /// <summary>
        /// 同步列表所有项目到<see cref="AIDAShownItems"/>中
        /// </summary>
        /// <param name="objectCollection"></param>
        /// <param name="aIDADataType"></param>
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
                    SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.System.Clear();
                    items.ForEach(t => SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.System.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Temperature:
                    SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Temperature.Clear();
                    items.ForEach(t => SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Temperature.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Volt:
                    SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Volt.Clear();
                    items.ForEach(t => SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Volt.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Power:
                    SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Power.Clear();
                    items.ForEach(t => SysConfig.ConfigHandle.Config.AIDAShownItems.AIDA64Data.Power.Add(AIDA64.GetItemByLabel(t)));
                    break;
            }
        }

        /// <summary>
        /// 选中所有项目
        /// </summary>
        /// <param name="checkedListBox"></param>
        public static void SetAllSelected(this CheckedListBox checkedListBox)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        public static string[] GetByCount(this string[] data, int count)
        {
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = data[i];
            }
            return result;
        }
    }
}
