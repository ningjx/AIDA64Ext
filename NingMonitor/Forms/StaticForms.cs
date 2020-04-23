using NingMonitor.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NingMonitor
{
    public static class StaticForms
    {
        public static StaticFormsDic Forms = new StaticFormsDic();
    }

    public class StaticFormsDic : Dictionary<string, Form>
    {
        public new Form this[string key]
        {
            get
            {
                if (base.ContainsKey(key) && base[key].IsDisposed == false)
                {
                    return base[key];
                }
                else if(base.ContainsKey(key) && base[key].IsDisposed == true)
                {
                    Remove(key);
                    return null;
                }
                else
                    return null;
            }
            set
            {
                if (base.ContainsKey(key))
                {
                    base[key] = value;
                }
            }
        }

        public new bool TryGetValue(string key, out Form value)
        {
            value = null;
            if (base.ContainsKey(key))
            {
                value = base[key];
                return true;
            }
            else
            {
                return false;
            }
        }

        public new bool ContainsKey(string key)
        {
            if (base.ContainsKey(key))
            {
                if (base[key].IsDisposed == true)
                {
                    Remove(key);
                    return false;
                }
                else
                    return true;
            }
            else
            {
                return false;
            }
        }
    }

    //public class MyForm : Form
    //{
    //    public new void Dispose()
    //    {
    //        Config.ConfigData.ScreenPositons.AddOrUpdate(Name, new ScreenPositon { 
    //            FormName = Name,
    //            Top = Top,
    //            Left = Left,
    //            Width = Width,
    //            Height = Height,
    //            ScreenName = Screen.FromControl(this).DeviceName.Replace("\\", "").Replace(".", "")
    //        });
    //        base.Dispose();
    //    }

    //    public new void Close()
    //    {
    //        Config.ConfigData.ScreenPositons.AddOrUpdate(Name, new ScreenPositon
    //        {
    //            FormName = Name,
    //            Top = Top,
    //            Left = Left,
    //            Width = Width,
    //            Height = Height,
    //            ScreenName = Screen.FromControl(this).DeviceName.Replace("\\", "").Replace(".", "")
    //        });
    //        base.Close();
    //    }
    //}
}
