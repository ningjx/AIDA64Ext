using NingMonitor.Extension;
using NingMonitor.Handlers;
using NingMonitor.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NingMonitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Config.ReadConfig();
                Task.Run(() => { OHMHandler.Start(); });
                using (MainForm form = new MainForm())
                {
                    form.FormClosed += delegate (object sender, FormClosedEventArgs e)
                    {
                        //记忆窗体位置
                        foreach (var item in StaticForms.Forms.Values)
                        {
                            if (item == null || item.IsDisposed == true)
                                continue;
                            Config.ConfigData.ScreenPositons.AddOrUpdate(item.Name, new ScreenPositon
                            {
                                FormName = item.Name,
                                Top = item.Top,
                                Left = item.Left,
                                Width = item.Width,
                                Height = item.Height,
                                ScreenName = Screen.FromControl(item).DeviceName.Replace("\\", "").Replace(".", "")
                            });
                        }
                        Config.SaveConfig();
                        Application.Exit();
                    };
                    Application.Run(form);
                }
            }
            catch (Exception ex)
            {
                Config.SaveConfig();
                FileHelper.Write(new string[] { "ErrorLog.txt" }, ex.ToString());
            }
        }
    }
}
