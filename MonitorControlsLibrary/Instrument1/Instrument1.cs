using DotNetPID;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MonitorControlsLibrary.Instrument1
{
    public partial class Instrument1 : BaseControl
    {
        PID PID = PID.Create(0.05, 0.2, 0.02, 10, PIDType.Positional);

        public Instrument1()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(0, 0, 0, 0);
            CheckForIllegalCrossThreadCalls = false;
            PID.StepEvent += PID_PIDOutEvent_Float;
        }

        private float PID_PIDOutEvent_Float(float value, float per)
        {
            SetValueForPID(value);
            return 0;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //获取控件缩放比
            scale = (float)Width / back.Width;
            pe.Graphics.DrawImage(back, 0, 0, back.Width * scale, back.Height * scale);
            int buf = (int)(value / max * 10);
            //绘制仪表
            switch (Math.Round(value / max * 10))
            {
                case 0:
                    pe.Graphics.DrawImage(p0, 0, 0, p0.Width * scale, p0.Height * scale);
                    break;
                case 1:
                    pe.Graphics.DrawImage(p1, 0, 0, p1.Width * scale, p1.Height * scale);
                    break;
                case 2:
                    pe.Graphics.DrawImage(p2, 0, 0, p2.Width * scale, p2.Height * scale);
                    break;
                case 3:
                    pe.Graphics.DrawImage(p3, 0, 0, p3.Width * scale, p3.Height * scale);
                    break;
                case 4:
                    pe.Graphics.DrawImage(p4, 0, 0, p4.Width * scale, p4.Height * scale);
                    break;
                case 5:
                    pe.Graphics.DrawImage(p5, 0, 0, p5.Width * scale, p5.Height * scale);
                    break;
                case 6:
                    pe.Graphics.DrawImage(p6, 0, 0, p6.Width * scale, p6.Height * scale);
                    break;
                case 7:
                    pe.Graphics.DrawImage(p7, 0, 0, p7.Width * scale, p7.Height * scale);
                    break;
                case 8:
                    pe.Graphics.DrawImage(p8, 0, 0, p8.Width * scale, p8.Height * scale);
                    break;
                case 9:
                    pe.Graphics.DrawImage(p9, 0, 0, p9.Width * scale, p9.Height * scale);
                    break;
                case 10:
                    pe.Graphics.DrawImage(p10, 0, 0, p10.Width * scale, p10.Height * scale);
                    break;
                default:
                    pe.Graphics.DrawImage(p0, 0, 0, p0.Width * scale, p0.Height * scale);
                    break;
            }

            Font font = new Font("Consloas", 20 * scale, FontStyle.Bold);

            SolidBrush drawBrush;
            if (buf < 5)
            {
                drawBrush = new SolidBrush(Color.FromArgb(26, 255, 0));
            }
            else if (buf < 8)
            {
                drawBrush = new SolidBrush(Color.FromArgb(255, 196, 0));
            }
            else
            {
                drawBrush = new SolidBrush(Color.FromArgb(255, 0, 0));
            }

            //pe.Graphics.DrawString($"{(value*10F).ToString("f2").PadLeft(5,'0')}%\n{lable}", font, drawBrush, 200 * scale, 100 * scale);
            pe.Graphics.DrawString($"{value.ToString("f2").PadLeft(7, ' ')}{unit}\n{显示文字}", font, drawBrush, 150 * scale, 100 * scale);

            if (buf < 5)//绘制绿色指针
            {
                RotateImage(pe, spinGreen, InterpolPhyToAngle((float)value, 0, max, 0, 180), spinPosition, beta,d, scale);
            }
            else if (buf < 8)
            {
                RotateImage(pe, spinYellow, InterpolPhyToAngle((float)value, 0, max, 0, 180), spinPosition, beta, d, scale);
            }
            else//绘制红色指针
            {
                RotateImage(pe, spinRed, InterpolPhyToAngle((float)value, 0, max, 0, 180), spinPosition, beta, d, scale);
            }
        }

        private int skip = 0;
        private void SetValueForPID(float value)
        {
            skip++;
            if (skip > 刷新系数)
            {
                skip = 0;
                if (value == this.value || value == 0)
                    return;
                this.value = value;
                Refresh();
            }
        }

        public int 刷新系数 { get; set; } = 4;

        public string 显示文字 { get; set; }

        public void SetValue(float value, string unit, float max)
        {
            if (value == this.value || value == 0)
                return;
            this.unit = unit;
            this.max = max;
            this.value = value;
            Refresh();
        }

        private float currentValue;
        /// <summary>
        /// 赋值（带PID算法）CPU占用有点高
        /// </summary>
        /// <param name="text">显示的lable</param>
        /// <param name="value">数值</param>
        /// <param name="unit">单位</param>
        /// <param name="max">最大值</param>
        public void SetValueWithPID(string text, float value, string unit, float max)
        {
            value = value > max ? max : value;
            value = value < 0 ? 0 : value;
            //value *= 10;//0-100
            if (value == 0 || value == this.value || currentValue == value)
                return;
            if (text != null)
                显示文字 = text;
            this.unit = unit;
            this.max = max;
            PID.Restart(currentValue, value);
            currentValue = value;
        }
    }
}
