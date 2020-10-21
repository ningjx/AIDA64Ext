using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorControlsLibrary
{
    public partial class NetSpeedControl : BaseControl
    {
        public NetSpeedControl()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(0, 0, 0);
            CheckForIllegalCrossThreadCalls = false;
        }
        private SolidBrush SolidBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
        private float scale;
        protected override void OnPaint(PaintEventArgs e)
        {
            scale = (float)Width / 400;
            Font bigFont = new Font("等线", 40 * scale, FontStyle.Bold);
            Font smallFont = new Font("等线", 20 * scale, FontStyle.Bold);
            if (DownloadBigger)
            {
                //e.Graphics.DrawString("△" + Upload, smallFont, SolidBrush, (int)(100 * scale), 0);
                e.Graphics.DrawString("△" + Upload, smallFont, SolidBrush, 0, 0);
                e.Graphics.DrawString("▼" + Download, bigFont, SolidBrush, 0, smallFont.Height);
            }
            else
            {
                e.Graphics.DrawString("▲" + Upload, bigFont, SolidBrush,0, 0);
                //e.Graphics.DrawString("▽" + Download, smallFont, SolidBrush, (int)(100 * scale), bigFont.Height);
                e.Graphics.DrawString("▽" + Download, smallFont, SolidBrush, 0, bigFont.Height);
            }
        }

        public string Download { get; set; } = "0.00 KB/s";
        public string Upload { get; set; } = "0.00 KB/s";
        public bool DownloadBigger { get; set; } = true;

        public void SetNetSpeed(float down,string downUnit,float up,string upUnit)
        {
            if (downUnit.Contains("M") && !upUnit.Contains("M"))
                DownloadBigger = true;
            else if(downUnit.Contains("M") && upUnit.Contains("M") && down> up)
                DownloadBigger = true;
            else if(!downUnit.Contains("M") && !upUnit.Contains("M") && down > up)
                DownloadBigger = true;
            else
                DownloadBigger = false;
            Download = down.ToString("f2") + downUnit;
            Upload = up.ToString("f2") + upUnit;
            Refresh();
        }
    }
}
