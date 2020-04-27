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
namespace MonitorControlsLibrary.Instrument2
{
    public partial class Instrument2 : BaseControl
    {
        private float scale;
        private Timer Timer = new Timer(1000);
        private Bitmap back = new Bitmap(Instrument2Resource.back);
        //横向900像素，纵向400像素
        private int[] buffer = new int[900];
        private Point[] points = new Point[900];
        private bool lockValue = false;
        private Pen maskPen = new Pen(Color.FromArgb(26, 255, 0), 2);
        private int micSec = 1000;
        private int pointCount;
        private int pixPerTime;//每次刷新间隔的像素数量，横向每秒钟90个像素
        public Instrument2()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Black;
            CheckForIllegalCrossThreadCalls = false;

            pixPerTime = 90 / (1000 / micSec);

            Timer.Elapsed += Timer_Elapsed;
            //Timer.Enabled = true;
            Timer.AutoReset = true;
            pointCount = 10000 / micSec + 1;
        }

        /// <summary>
        /// 设置刷新间隔时间(毫秒)
        /// </summary>
        public int 刷新间隔
        {
            get
            {
                return micSec;
            }
            set
            {
                this.micSec = value < 12 ? 12 : value;
                this.micSec = value < 10000 ? value : 10000;
                Timer.Interval = micSec;
                pointCount = 10000 / micSec + 1;
                pixPerTime = (int)(90 * (micSec / 1000.0));
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lockValue)
                return;
            lockValue = true;
            Value = Value < 1 ? 1 : Value;
            Value = Value > 100 ? 100 : Value;
            points = new Point[900];
            //向右位移
            for (int i = pointCount; i > 0; i--)
            {
                if (i < buffer.Length)
                    buffer[i] = buffer[i - 1];
            }
            //插入0
            buffer[0] = (int)((400 - (int)(Value * 4)) * scale);


            for (int i = 0; i < pointCount; i++)
            {
                if (buffer[i] >= 1)
                    points[i] = new Point((int)((900 - i * pixPerTime + 90) * scale), (int)(buffer[i] + 50 * scale));
            }
            Refresh();
            lockValue = false;
        }

        /// <summary>
        /// 0-100
        /// </summary>
        public float Value { get; set; }

        private int currDrawPosition;
        protected override void OnPaint(PaintEventArgs pe)
        {
            scale = (float)Width / back.Width;
            pe.Graphics.DrawImage(back, 0, 0, back.Width * scale, back.Height * scale);
            if (currDrawPosition < pointCount)
            {
                currDrawPosition++;
                if (currDrawPosition > 1)
                {
                    Point[] currPoints = points.Take(currDrawPosition - 1).ToArray();
                    if (currPoints.Length > 1)
                        pe.Graphics.DrawCurve(maskPen, currPoints);
                }
            }
            else
            {
                Point[] currPoints = points.Take(pointCount).ToArray();
                pe.Graphics.DrawCurve(maskPen, currPoints);
            }
        }
    }
}
