using AIDA64Ext.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIDA64Ext
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.ReadConfig();
            using (MainForm form = new MainForm())
            {
                form.FormClosed += delegate (Object sender, FormClosedEventArgs e)
                {
                    //记忆窗体位置
                    foreach(var item in StaticForms.Forms.Values)
                    {
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
    }
}
