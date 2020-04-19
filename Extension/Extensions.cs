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
using System.Diagnostics;
using Microsoft.Win32;

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
                if (Config.ConfigData.AIDAShownItems.Contains(t.Label))
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
                    Config.ConfigData.AIDAShownItems.AIDA64Data.System.Clear();
                    items.ForEach(t => Config.ConfigData.AIDAShownItems.AIDA64Data.System.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Temperature:
                    Config.ConfigData.AIDAShownItems.AIDA64Data.Temperature.Clear();
                    items.ForEach(t => Config.ConfigData.AIDAShownItems.AIDA64Data.Temperature.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Volt:
                    Config.ConfigData.AIDAShownItems.AIDA64Data.Volt.Clear();
                    items.ForEach(t => Config.ConfigData.AIDAShownItems.AIDA64Data.Volt.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Power:
                    Config.ConfigData.AIDAShownItems.AIDA64Data.Power.Clear();
                    items.ForEach(t => Config.ConfigData.AIDAShownItems.AIDA64Data.Power.Add(AIDA64.GetItemByLabel(t)));
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
                    Config.ConfigData.AIDAShownItems.AIDA64Data.System.Clear();
                    items.ForEach(t => Config.ConfigData.AIDAShownItems.AIDA64Data.System.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Temperature:
                    Config.ConfigData.AIDAShownItems.AIDA64Data.Temperature.Clear();
                    items.ForEach(t => Config.ConfigData.AIDAShownItems.AIDA64Data.Temperature.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Volt:
                    Config.ConfigData.AIDAShownItems.AIDA64Data.Volt.Clear();
                    items.ForEach(t => Config.ConfigData.AIDAShownItems.AIDA64Data.Volt.Add(AIDA64.GetItemByLabel(t)));
                    break;
                case AIDADataType.Power:
                    Config.ConfigData.AIDAShownItems.AIDA64Data.Power.Clear();
                    items.ForEach(t => Config.ConfigData.AIDAShownItems.AIDA64Data.Power.Add(AIDA64.GetItemByLabel(t)));
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

        public static void AddOrUpdate<K, V>(this Dictionary<K, V> dic, K key, V value)
        {
            if (dic.Keys.Contains(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }


        /// <summary>
        /// 将本程序设为开启自启
        /// </summary>
        /// <param name="onOff">自启开关</param>
        /// <returns></returns>
        public static bool SetAutoStart(bool onOff)
        {
            bool isOk = false;
            string appName = Process.GetCurrentProcess().MainModule.ModuleName;
            string appPath = Process.GetCurrentProcess().MainModule.FileName;
            isOk = SetAutoStart(onOff, appName, appPath);
            return isOk;
        }

        /// <summary>
        /// 保存窗体位置
        /// </summary>
        /// <param name="form"></param>
        public static void SaveScreenObject(this Form form)
        {
            string CurrentScreenName = Screen.FromControl(form).DeviceName.Replace("\\", "").Replace(".", "");
            Config.ConfigData.ScreenPositons.AddOrUpdate(CurrentScreenName, new ScreenPositon
            {
                ScreenName = CurrentScreenName,
                FormName = form.Name,
                Top = form.Top,
                Left = form.Left,
                Width = form.Width,
                Height = form.Height
            });
        }

        /// <summary>
        /// 设置窗体的位置
        /// </summary>
        /// <param name="form"></param>
        public static void SetFormPosition(this Form form, bool isFullScreen)
        {
            if (!Config.ConfigData.ScreenPositons.TryGetValue(form.Name, out ScreenPositon info))
            {
                return;
            }
            if (isFullScreen)
            {
                var screen = Screen.AllScreens.FirstOrDefault(t => t.DeviceName.Replace("\\", "").Replace(".", "") == info.ScreenName);
                if (screen != null)
                {
                    form.Top = screen.WorkingArea.Top;
                    form.Left = screen.WorkingArea.Left;
                }
                form.FormBorderStyle = FormBorderStyle.None;
                form.WindowState = FormWindowState.Maximized;
                return;
            }
            if (Screen.AllScreens.Select(t => t.DeviceName.Replace("\\", "").Replace(".", "")).Contains(info.ScreenName))
            {
                form.Top = info.Top;
                form.Left = info.Left;
                form.Width = info.Width;
                form.Height = info.Height;
            }
        }

        /// <summary>
        /// 将应用程序设为，或不设为开机启动
        /// </summary>
        /// <param name="onOff">自启开关</param>
        /// <param name="appName">应用程序名</param>
        /// <param name="appPath">应用程序完全路径</param>
        private static bool SetAutoStart(bool onOff, string appName, string appPath)
        {
            bool isOk = true;
            //如果从没有设为开机启动设置到要设为开机启动
            if (!IsExistKey(appName) && onOff)
            {
                isOk = SelfRunning(onOff, appName, @appPath);
            }
            //如果从设为开机启动设置到不要设为开机启动
            else if (IsExistKey(appName) && !onOff)
            {
                isOk = SelfRunning(onOff, appName, @appPath);
            }
            return isOk;
        }

        /// <summary>
        /// 判断注册键值对是否存在，即是否处于开机启动状态
        /// </summary>
        /// <param name="keyName">键值名</param>
        /// <returns></returns>
        private static bool IsExistKey(string keyName)
        {
            try
            {
                bool _exist = false;
                RegistryKey local = Registry.LocalMachine;
                RegistryKey runs = local.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (runs == null)
                {
                    RegistryKey key2 = local.CreateSubKey("SOFTWARE");
                    RegistryKey key3 = key2.CreateSubKey("Microsoft");
                    RegistryKey key4 = key3.CreateSubKey("Windows");
                    RegistryKey key5 = key4.CreateSubKey("CurrentVersion");
                    RegistryKey key6 = key5.CreateSubKey("Run");
                    runs = key6;
                }
                string[] runsName = runs.GetValueNames();
                foreach (string strName in runsName)
                {
                    if (strName.ToUpper() == keyName.ToUpper())
                    {
                        _exist = true;
                        return _exist;
                    }
                }
                return _exist;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 写入或删除注册表键值对,即设为开机启动或开机不启动
        /// </summary>
        /// <param name="isStart">是否开机启动</param>
        /// <param name="exeName">应用程序名</param>
        /// <param name="path">应用程序路径带程序名</param>
        /// <returns></returns>
        private static bool SelfRunning(bool isStart, string exeName, string path)
        {
            try
            {
                RegistryKey local = Registry.LocalMachine;
                RegistryKey key = local.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (key == null)
                {
                    local.CreateSubKey("SOFTWARE//Microsoft//Windows//CurrentVersion//Run");
                }
                //若开机自启动则添加键值对
                if (isStart)
                {
                    key.SetValue(exeName, path);
                    key.Close();
                }
                else//否则删除键值对
                {
                    string[] keyNames = key.GetValueNames();
                    foreach (string keyName in keyNames)
                    {
                        if (keyName.ToUpper() == exeName.ToUpper())
                        {
                            key.DeleteValue(exeName);
                            key.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
                return false;
                //throw;
            }

            return true;
        }
    }
}
