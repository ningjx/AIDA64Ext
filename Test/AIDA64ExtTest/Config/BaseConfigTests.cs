using Microsoft.VisualStudio.TestTools.UnitTesting;
using AIDA64Ext.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDA64Ext.Config.Tests
{
    [TestClass()]
    public class BaseConfigTests
    {
        [TestMethod()]
        public void BaseConfigTest()
        {
            ConfigTest test = new ConfigTest();
            test.ConfigData.TemConfig = "666";
        }

        public class ConfigTest : BaseConfig
        {
            public ConfigData ConfigData
            {
                get
                {
                    return base.Config as ConfigData;
                }
                set
                {
                    base.Config = value;
                }
            }

            public ConfigTest()
            {
                base.Type = typeof(ConfigData);
            }

        }

        public class ConfigData : IConfig
        {
            public string TemConfig = string.Empty;
        }
    }
}