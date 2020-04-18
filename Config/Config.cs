using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIDA64Ext.Helper;
using AIDA64Ext.Models;
using Newtonsoft.Json;

namespace AIDA64Ext.Config
{
    public class ConfigHandle:BaseConfig
    {
        public new ConfigData Config = new ConfigData();
    }

    public static class SysConfig
    {
        public static ConfigHandle ConfigHandle = new ConfigHandle();
    }
    
    public class ConfigData: IConfig
    {
        public AIDAShownItems AIDAShownItems = new AIDAShownItems();
    }
}
