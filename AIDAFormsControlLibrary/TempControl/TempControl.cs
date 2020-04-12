﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIDAFormsControlLibrary.TempControl
{
    public partial class TempControl : BaseControl
    {
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
            SetTemp(value);
        }

        PID PID = new PID(0.1F, 0.02F, 0.1F);
        //Bitmap back = new Bitmap(TempControlReasource.back);
        Bitmap cover = new Bitmap(TempControlReasource.temCover);
        Bitmap temBack = new Bitmap(TempControlReasource.temBack);
        Bitmap topCover = new Bitmap(TempControlReasource.topCover);
        float scale;
        string lable = "温度";
        SolidBrush drawBrush = new SolidBrush(Color.White);
        Point coverPoistion;
        int x, y;
        double tem;
        protected override void OnPaint(PaintEventArgs pe)
        {
            //获取控件缩放比
            scale = (float)Width / temBack.Width;
            pe.Graphics.DrawImage(temBack, 0, 0, temBack.Width * scale, temBack.Height * scale);
            Font font = new Font("宋体", 8 * scale);
            pe.Graphics.DrawString(lable, font, drawBrush,  5 * scale, 382 * scale);
            //pe.Graphics.DrawString(tem.ToString("f2").PadLeft(5,'0')+ "℃", font, drawBrush,  3 * scale, 360 * scale);

            if(tem<20)
                coverPoistion = new Point(0, 0);
            else if(tem>90)
                coverPoistion = new Point(0, -348);
            else
                coverPoistion = new Point(0, -(int)((tem-20)* (348/70D)));
            TranslateImage(pe, cover, 0, 0, coverPoistion, scale);
            pe.Graphics.DrawString(tem.ToString("f2").PadLeft(5, '0') + "℃", font, drawBrush, 3 * scale, (360+coverPoistion.Y )* scale);
            pe.Graphics.DrawImage(topCover, 0, 0, topCover.Width * scale, topCover.Height * scale);
        }

        double tartemp;
        public void SetTempDelay(double temp)
        {
            if (temp == tem)
                return;
            tartemp = temp;
            if (Math.Abs( temp - tem) > 1)
            {
                if(temp> tem)
                {
                    Action action = () => {
                        while (tartemp == temp && tem < temp)
                        {
                            tem+=0.1;
                            Refresh();
                            Thread.Sleep(10);
                        }
                    };
                    this.Invoke(action);
                }
                else
                {
                    Action action = () => {
                        while (tartemp == temp && tem > temp)
                        {
                            tem-=0.1;
                            Refresh();
                            Thread.Sleep(10);
                        }
                    };
                    this.Invoke(action);
                }
            }
            else
            {
                tem = temp;
                Refresh();
            }
        }

        public void SetTemp(double temp)
        {
            if (temp == 0)
                return;
            this.tem = temp;
            Refresh();
        }

        float currentTemp;
        public void SetTempWithPID(float temp)
        {
            if (temp == 0)
                return;
            PID.SetWithPID(currentTemp, temp);
            currentTemp = temp;
        }

        public void SetLable(string lable)
        {
            this.lable = lable;
        }

    }
}
