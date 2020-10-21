using DotNetPID;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

        //0-100
        public void SetValue(float value)
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


            buffer[0] = 400 - (int)(value * 4);


            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] >= 1)
                    points[i] = new Point(900 - i * 3, buffer[i]);
            }
            //this.value = value;
            Refresh();
            lockValue = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //pe.Graphics.DrawCurve()
            //pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pe.Graphics.DrawCurve(maskPen, points);
            //pe.Graphics.DrawLines(maskPen, points);
            pe.Graphics.DrawString($"{points.First().X}  {points.First().Y}", new Font("宋体", 20), new SolidBrush(Color.White), 10, 10);
        }
    }
}
