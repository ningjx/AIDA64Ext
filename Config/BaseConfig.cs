using AIDA64Ext.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDA64Ext
{
    public class BaseConfig
    {
        public BaseConfig()
        {
            //InitConfig();
        }
        private object Buffer;
        public IConfig Config
        {
            get
            {
                if (Buffer == null)
                    InitConfig();
                return Buffer as IConfig;
            }
            set
            {
                //this.Type = value.GetType();
                SetValue(value);
            }
        }
        public string[] path = new string[] { "Config" };
        public virtual Type Type { get; set; }

        private void SetValue(object value)
        {
            if (Buffer == null)
                return;
            Buffer = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(value), Type);
            SaveConfig();
        }


        private void InitConfig()
        {
            string configStr = FileHelper.Read(path);
            if (!string.IsNullOrEmpty(configStr))
            {
                Buffer = JsonConvert.DeserializeObject(configStr, Type);
            }
            else
                Buffer =  Activator.CreateInstance(this.Type);
        }

        private void SaveConfig()
        {
            path.Write(JsonConvert.SerializeObject(Buffer));
        }
    }

    public interface IConfig
    {
        
    }
}
