using DotNetPID;
using System.Drawing;
using System.Windows.Forms;

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
            PID.StepEvent += PID_PIDOutEvent_Float;
        }

        private float PID_PIDOutEvent_Float(float value, float per)
        {
            SetTempForPID(value);
            return 0;
        }

        PID PID = PID.Create(0.05, 0.3, 0.02, 10, PIDType.Positional);
        Bitmap cover = new Bitmap(TempControlReasource.temCover);
        Bitmap temBack = new Bitmap(TempControlReasource.temBack);
        Bitmap topCover = new Bitmap(TempControlReasource.topCover);
        float scale;
        string lable = "温度";
        SolidBrush drawBrush = new SolidBrush(Color.White);
        Point coverPoistion;
        float tem;
        protected override void OnPaint(PaintEventArgs pe)
        {
            //获取控件缩放比
            scale = (float)Width / temBack.Width;
            pe.Graphics.DrawImage(temBack, 0, 0, temBack.Width * scale, temBack.Height * scale);
            Font font = new Font("Consloas", 11 * scale);
            Font font1 = new Font("Consloas", 14 * scale);
            pe.Graphics.DrawString(显示文字, font, drawBrush, 5 * scale, 382 * scale);
            //pe.Graphics.DrawString(tem.ToString("f2").PadLeft(5,'0')+ "℃", font, drawBrush,  3 * scale, 360 * scale);

            if (temperature < Min)
                coverPoistion = new Point(0, 0);
            else if (temperature > Max)
                coverPoistion = new Point(0, -348);
            else
                coverPoistion = new Point(0, -(int)((temperature - Min) * (348 / (Max-Min))));
            TranslateImage(pe, cover, 0, 0, coverPoistion, scale);
            pe.Graphics.DrawString(temperature.ToString("f0").PadLeft(2, ' ')/* + "℃"*/, font1, drawBrush, 8* scale, (346 + coverPoistion.Y) * scale);
            pe.Graphics.DrawImage(topCover, 0, 0, topCover.Width * scale, topCover.Height * scale);
        }

        int skip = 0;
        private void SetTempForPID(float temp)
        {
            //if (this.tem == temp || temp == 0)
            //    return;
            //this.tem = temp;
            //Refresh();
            //return;
            }

        public float Min { get; set; } = 0;

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
            lable = text;
            PID.Restart(currentTemp, temp);
            currentTemp = temp;
        }
    }
}
