using DotNetPID;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
namespace MonitorControlsLibrary.Instrument2
{
    public partial class Instrument2 : BaseControl
    {
        PID PID = PID.Create(0.05, 0.3, 0.02, 10, PIDType.Positional);
        public Instrument2()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Black;
            CheckForIllegalCrossThreadCalls = false;
            PID.StepEvent += PID_PIDOutEvent_Float;
        }
        //每三个像素绘制一个点，每秒绘制30个点，十秒钟300个点，900像素
        //纵向400像素
        int[] buffer = new int[300];
        Point[] points = new Point[300];
        bool lockValue = false;
        Pen maskPen = new Pen(Color.LightGreen, 2);
        private float PID_PIDOutEvent_Float(float value, float per)
        {
            SetValue(value);
            return 0;
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
