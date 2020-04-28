using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MonitorControlsLibrary
{
    public partial class TimeControl : BaseControl
    {
        private Timer Timer = new Timer(1000);

        public TimeControl()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(0, 0, 0, 0);
            CheckForIllegalCrossThreadCalls = false;
            Timer.AutoReset = true;
            Timer.Elapsed += RefreshData;
            Timer.Enabled = true;
        }

        private void RefreshData(object sender, ElapsedEventArgs e)
        {
            Refresh();
        }

        private float scale;

        private SolidBrush SolidBrush = new SolidBrush(Color.FromArgb(255, 255, 255));

        private bool kick;
        protected override void OnPaint(PaintEventArgs pe)
        {
            scale = (float)Width / 1080;
            Font timeFont = new Font("等线", 150 * scale, FontStyle.Bold);
            Font secFont = new Font("等线", 50 * scale, FontStyle.Bold);
            Font dateFont = new Font("等线", 30 * scale, FontStyle.Bold);
            pe.Graphics.DrawString(DateTime.Now.ToString("hh mm"), timeFont, SolidBrush, 0, 0);
            pe.Graphics.DrawString(DateTime.Now.ToString("ss"), secFont, SolidBrush, 800 * scale, 170 * scale);
            if (kick)
            {
                pe.Graphics.DrawString(":", timeFont, SolidBrush, 340 * scale, -30 * scale);
                kick = false;
            }
            else
            {
                kick = true;
            }
            pe.Graphics.DrawString($"{DateTime.Now:yyyy/MM/dd} {ChinaDate.GetChineseDateTime()} {DateTime.Now:ddd}", dateFont, SolidBrush, 90 * scale, 270 * scale);
        }
    }

    public static class ChinaDate
    {
        private static ChineseLunisolarCalendar ChineseCalendar = new ChineseLunisolarCalendar();
        ///<return s></return s>
        private static string[] months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };

        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days1 = { "初", "十", "廿", "三" };
        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };
        ///<summary>
        /// 返回农历月
        ///</summary>
        ///<param name="month">月份</param>
        ///<return s></return s>
        private static string GetLunisolarMonth(int month)
        {
            if (month < 13 && month > 0)
            {
                return months[month - 1];
            }

            throw new ArgumentOutOfRangeException("无效的月份!");
        }

        ///<summary>
        /// 返回农历日
        ///</summary>
        ///<param name="day">天</param>
        ///<return s></return s>
        private static string GetLunisolarDay(int day)
        {
            if (day > 0 && day < 32)
            {
                if (day != 20 && day != 30)
                {
                    return string.Concat(days1[(day - 1) / 10], days[(day - 1) % 10]);
                }
                else
                {
                    return string.Concat(days[(day - 1) / 10], days1[1]);
                }
            }

            throw new ArgumentOutOfRangeException("无效的日!");
        }

        ///<summary>
        /// 根据公历获取农历日期
        ///</summary>
        ///<param name="datetime">公历日期</param>
        ///<return s></return s>
        public static string GetChineseDateTime()
        {
            DateTime datetime = DateTime.Now;
            int year = ChineseCalendar.GetYear(datetime);
            int month = ChineseCalendar.GetMonth(datetime);
            int day = ChineseCalendar.GetDayOfMonth(datetime);
            //获取闰月， 0 则表示没有闰月
            int leapMonth = ChineseCalendar.GetLeapMonth(year);

            bool isleap = false;

            if (leapMonth > 0)
            {
                if (leapMonth == month)
                {
                    //闰月
                    isleap = true;
                    month--;
                }
                else if (month > leapMonth)
                {
                    month--;
                }
            }

            return string.Concat(GetLunisolarMonth(month), "月", GetLunisolarDay(day));
        }
    }
}
