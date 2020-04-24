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
        float scale;
        Timer Timer = new Timer(1000);
        public Instrument2()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Black;
            CheckForIllegalCrossThreadCalls = false;

            pixPerTime = 90 / (1000 / micSec);

            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
            Timer.AutoReset = true;
        }
        public void SetFreq(int micSec)
        {
            this.micSec = micSec;
            Timer.Interval = micSec;
            pixPerTime = 90 / (1000 / micSec);
        }

        public void Start()
        {
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lockValue)
                return;
            lockValue = true;
            value = value < 1 ? 1 : value;
            points = new Point[900];

            //向右位移
            for (int i = 900; i > 0; i--)
            {
                if (i < buffer.Length)
                    buffer[i] = buffer[i - 1];
            }
            //插入0
            buffer[0] = (int)((400 - (int)(value * 4))* scale);

            int count = 10000 / micSec;
            for (int i = 0; i < count; i++)
            {
                if (buffer[i] >= 1)
                    points[i] = new Point((int)((900 - i * pixPerTime + 90) * scale), (int)(buffer[i]+50*scale));
            }
            Refresh();
            lockValue = false;
        }

        Bitmap back = new Bitmap(Instrument2Resource.back);
        //横向900像素
        //纵向400像素
        int[] buffer = new int[900];
        Point[] points = new Point[900];
        bool lockValue = false;
        Pen maskPen = new Pen(Color.LightGreen, 2);
        float value;

        int micSec = 1000;
        int pixPerTime;

        //0-100
        public void SetValue(float value)
        {
            this.value = value;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            scale = (float)Width / back.Width; 
            pe.Graphics.DrawImage(back, 0, 0, back.Width * scale, back.Height * scale);
            //pe.Graphics.DrawCurve()
            //pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //HashSet<Point> set = new HashSet<Point>();
            int i = 0;
            for (i = 0; i< points.Length; i++)
            {
                if (points[i].Y == 0)
                    break;
                //set.Add(points[i]);
            }
            //if(set.Count>0)
            //    pe.Graphics.DrawCurve(maskPen, set.ToArray());
            Point[] currPoints = points.Take(i).ToArray();
            if (currPoints.Length > 1)
                pe.Graphics.DrawCurve(maskPen, currPoints);
            //pe.Graphics.DrawLines(maskPen, points);
            //pe.Graphics.DrawString($"{points.First().X}  {points.First().Y}", new Font("宋体", 20), new SolidBrush(Color.White), 10, 10);
        }
    }
}
