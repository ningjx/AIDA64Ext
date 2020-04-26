using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MonitorControlsLibrary.TempControl
{
    public partial class TempControl : BaseControl
    {
        private Bitmap cover = new Bitmap(TempControlReasource.temCover);
        private Bitmap temBack = new Bitmap(TempControlReasource.temBack);
        private Bitmap topCover = new Bitmap(TempControlReasource.topCover);

        private PID PID = new PID(0.5F, 0.08F, 0.05F);
        private float scale;
        private SolidBrush drawBrush = new SolidBrush(Color.White);
        private Point coverPoistion;
        private float temperature;
        private int skip = 0;

        public TempControl()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(0, 0, 0, 0);
            Control.CheckForIllegalCrossThreadCalls = false;
            PID.PIDOutEvent_Float += PID_PIDOutEvent_Float;
        }

        private void PID_PIDOutEvent_Float(float value)
        {
            skip++;
            if (skip > 刷新系数)
            {
                skip = 0;
                if (temperature == value || value == 0)
                    return;
                temperature = value;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //获取控件缩放比
            scale = (float)Width / temBack.Width;
            pe.Graphics.DrawImage(temBack, 0, 0, temBack.Width * scale, temBack.Height * scale);
            Font font = new Font("宋体", 8 * scale);
            pe.Graphics.DrawString(显示文字, font, drawBrush, 5 * scale, 382 * scale);
            //pe.Graphics.DrawString(tem.ToString("f2").PadLeft(5,'0')+ "℃", font, drawBrush,  3 * scale, 360 * scale);

            if (temperature < 20)
                coverPoistion = new Point(0, 0);
            else if (temperature > 90)
                coverPoistion = new Point(0, -348);
            else
                coverPoistion = new Point(0, -(int)((temperature - 20) * (348 / 70D)));
            TranslateImage(pe, cover, 0, 0, coverPoistion, scale);
            pe.Graphics.DrawString(temperature.ToString("f2").PadLeft(5, '0') + "℃", font, drawBrush, 3 * scale, (360 + coverPoistion.Y) * scale);
            pe.Graphics.DrawImage(topCover, 0, 0, topCover.Width * scale, topCover.Height * scale);
        }

        public int 刷新系数 { get; set; } = 4;

        public string 显示文字 { get; set; } = "温度";

        public float 比例 { get { return this.PID.Kp; } set { this.PID.Kp = value; } }
        public float 积分 { get { return this.PID.Ki; } set { this.PID.Ki = value; } }
        public float 微分 { get { return this.PID.Kd; } set { this.PID.Kd = value; } }


        public float Value
        {
            get { return temperature; }
            set
            {
                if (temperature == value || value == 0)
                    return;
                temperature = value;
                Refresh();
            }
        }

        private float currentTemp;

        /// <summary>
        /// CUP占用有点高
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        public void SetValueWithPID(float value, string text = null)
        {
            value = value < 0 ? 0 : value;
            if (this.temperature == value || value == 0 || currentTemp == value)
                return;
            if (text != null)
                显示文字 = text;
            PID.SetWithPID(currentTemp, value);
            currentTemp = value;
        }
    }
}
