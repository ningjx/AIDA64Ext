using NingMonitor.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingMonitor
{
    public class BaseConfig
    {
        public IConfig Config;
        public string[] Path = new string[] { "Config" };
        public virtual Type Type { get; set; }

        public virtual bool ReadConfig()
        {
            var str = FileHelper.Read(Path);
            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    Config = (IConfig)JsonConvert.DeserializeObject(str, Type);
                    return true;
                }
                catch (Exception ex)
                {
                    FileHelper.Write_Append(new string[] { "Log.txt" }, ex.ToString());
                    Config = (IConfig)Activator.CreateInstance(this.Type);
                    return false;
                }
            }
            else
            {
                Config = (IConfig)Activator.CreateInstance(this.Type);
                return false;
            }
        }
        public virtual bool SaveConfig()
        {
            try
            {
                FileHelper.Write(Path, JsonConvert.SerializeObject(Config));
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.Write_Append(new string[] { "Log.txt" }, ex.ToString());
                return false;
            }
        }
    }

    public interface IConfig
    {

    }
}
