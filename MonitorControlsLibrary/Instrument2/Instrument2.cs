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
        PID PID = new PID(0.05F, 0.05F, 0.02F);
        Timer Timer = new Timer(30);
        public Instrument2()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Black;
            CheckForIllegalCrossThreadCalls = false;
            PID.PIDOutEvent_Float += PID_PIDOutEvent_Float;

            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
            Timer.AutoReset = true;
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lockValue)
                return;
            lockValue = true;
            value = value < 1 ? 1 : value;

            for (int i = 300; i > 0; i--)
            {
                if (i < buffer.Length)
                    buffer[i] = buffer[i - 1];
            }


            buffer[0] = (int)((400 - (int)(value * 4))* scale);


            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] >= 1)
                    points[i] = new Point((int)((900 - i * 3 + 90) * scale), (int)(buffer[i]+50*scale));
            }
            //this.value = value;
            Refresh();
            lockValue = false;
        }

        Bitmap back = new Bitmap(Instrument2Resource.back);
        //每三个像素绘制一个点，每秒绘制30个点，十秒钟300个点，900像素
        //纵向400像素
        int[] buffer = new int[300];
        Point[] points = new Point[300];
        bool lockValue = false;
        Pen maskPen = new Pen(Color.LightGreen, 2);
        float value;
        private void PID_PIDOutEvent_Float(float value)
        {
            SetValue(value);
        }

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
