using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIDA64Ext.Helper;
using AIDA64Ext.Models;
using Newtonsoft.Json;

namespace AIDA64Ext
{
    public static class Config
    {
        public static ConfigData ConfigData = new ConfigData();

        private static readonly string Path = "Config.json";

        public static void ReadConfig()
        {
            var str = FileHelper.Read(new string[] { Path });
            if (!string.IsNullOrEmpty(str))
            {
                try { ConfigData = JsonConvert.DeserializeObject<ConfigData>(str); }
                catch { }
            }
        }

        public static void SaveConfig()
        {
            FileHelper.Write(new string[] { Path }, JsonConvert.SerializeObject(ConfigData));
        }
    }

    /// <summary>
    /// 配置信息类
    /// </summary>
    public class ConfigData
    {
        public AIDAShownItems AIDAShownItems = new AIDAShownItems();
        public Dictionary<string,ScreenPositon> ScreenPositons = new Dictionary<string, ScreenPositon>();
        public bool IsAutoShowDisplayForm = false;
    }

    public class ScreenPositon
    {
        public int Top;
        public int Left;
        public int Width = 800;
        public int Height = 600;
        public string FormName;
        public string ScreenName;
    }
}
