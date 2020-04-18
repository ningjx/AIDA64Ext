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
    //ublic class ConfigHandle:BaseConfig
    //
    //   public new ConfigData Config = new ConfigData();
    //
    //
    //ublic static class SysConfig
    //
    //   //public static ConfigHandle ConfigHandle = new ConfigHandle();
    //   public static ConfigData Config = new ConfigData();
    //
    
    public static class Config//: IConfig
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

    public class ConfigData
    {
        public AIDAShownItems AIDAShownItems = new AIDAShownItems();
        public List<ScreenPositon> ScreenPositons = new List<ScreenPositon>();
    }

    public class ScreenPositon
    {
        public int Top;
        public int Left;
        public string FormName;
        public string ScreenName;
    }
}
