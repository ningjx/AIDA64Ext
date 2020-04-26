﻿namespace NingMonitor.Forms
{
    partial class DisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tempControl4 = new MonitorControlsLibrary.TempControl.TempControl();
            this.tempControl3 = new MonitorControlsLibrary.TempControl.TempControl();
            this.tempControl2 = new MonitorControlsLibrary.TempControl.TempControl();
            this.instrument14 = new MonitorControlsLibrary.Instrument1.Instrument1();
            this.instrument13 = new MonitorControlsLibrary.Instrument1.Instrument1();
            this.instrument12 = new MonitorControlsLibrary.Instrument1.Instrument1();
            this.instrument11 = new MonitorControlsLibrary.Instrument1.Instrument1();
            this.tempControl1 = new MonitorControlsLibrary.TempControl.TempControl();
            this.instrument21 = new MonitorControlsLibrary.Instrument2.Instrument2();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(191, 986);
            this.trackBar1.Maximum = 1500;
            this.trackBar1.Minimum = 800;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(667, 69);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 1000;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tempControl4
            // 
            this.tempControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tempControl4.Location = new System.Drawing.Point(303, 13);
            this.tempControl4.Margin = new System.Windows.Forms.Padding(4);
            this.tempControl4.Max = 100F;
            this.tempControl4.Min = 0F;
            this.tempControl4.Name = "tempControl4";
            this.tempControl4.Size = new System.Drawing.Size(65, 548);
            this.tempControl4.TabIndex = 11;
            this.tempControl4.Text = "tempControl4";
            this.tempControl4.Value = 0F;
            this.tempControl4.刷新系数 = 4;
            this.tempControl4.微分 = 0.05F;
            this.tempControl4.显示文字 = "温度";
            this.tempControl4.比例 = 0.5F;
            this.tempControl4.积分 = 0.08F;
            // 
            // tempControl3
            // 
            this.tempControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tempControl3.Location = new System.Drawing.Point(210, 13);
            this.tempControl3.Margin = new System.Windows.Forms.Padding(4);
            this.tempControl3.Max = 100F;
            this.tempControl3.Min = 0F;
            this.tempControl3.Name = "tempControl3";
            this.tempControl3.Size = new System.Drawing.Size(65, 548);
            this.tempControl3.TabIndex = 10;
            this.tempControl3.Text = "tempControl3";
            this.tempControl3.Value = 0F;
            this.tempControl3.刷新系数 = 4;
            this.tempControl3.微分 = 0.05F;
            this.tempControl3.显示文字 = "温度";
            this.tempControl3.比例 = 0.5F;
            this.tempControl3.积分 = 0.08F;
            // 
            // tempControl2
            // 
            this.tempControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tempControl2.Location = new System.Drawing.Point(116, 13);
            this.tempControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tempControl2.Max = 100F;
            this.tempControl2.Min = 0F;
            this.tempControl2.Name = "tempControl2";
            this.tempControl2.Size = new System.Drawing.Size(65, 548);
            this.tempControl2.TabIndex = 9;
            this.tempControl2.Text = "tempControl2";
            this.tempControl2.Value = 0F;
            this.tempControl2.刷新系数 = 4;
            this.tempControl2.微分 = 0.05F;
            this.tempControl2.显示文字 = "温度";
            this.tempControl2.比例 = 0.5F;
            this.tempControl2.积分 = 0.08F;
            // 
            // instrument14
            // 
            this.instrument14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument14.Location = new System.Drawing.Point(1201, 601);
            this.instrument14.Margin = new System.Windows.Forms.Padding(4);
            this.instrument14.Name = "instrument14";
            this.instrument14.Size = new System.Drawing.Size(380, 220);
            this.instrument14.TabIndex = 4;
            this.instrument14.Text = "instrument14";
            this.instrument14.刷新系数 = 4;
            this.instrument14.显示文字 = null;
            // 
            // instrument13
            // 
            this.instrument13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument13.Location = new System.Drawing.Point(806, 601);
            this.instrument13.Margin = new System.Windows.Forms.Padding(4);
            this.instrument13.Name = "instrument13";
            this.instrument13.Size = new System.Drawing.Size(380, 220);
            this.instrument13.TabIndex = 3;
            this.instrument13.Text = "instrument13";
            this.instrument13.刷新系数 = 4;
            this.instrument13.显示文字 = "CPU功率";
            // 
            // instrument12
            // 
            this.instrument12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument12.Location = new System.Drawing.Point(411, 601);
            this.instrument12.Margin = new System.Windows.Forms.Padding(4);
            this.instrument12.Name = "instrument12";
            this.instrument12.Size = new System.Drawing.Size(380, 220);
            this.instrument12.TabIndex = 2;
            this.instrument12.Text = "instrument12";
            this.instrument12.刷新系数 = 4;
            this.instrument12.显示文字 = "内存占用";
            // 
            // instrument11
            // 
            this.instrument11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument11.Location = new System.Drawing.Point(15, 601);
            this.instrument11.Margin = new System.Windows.Forms.Padding(4);
            this.instrument11.Name = "instrument11";
            this.instrument11.Size = new System.Drawing.Size(380, 220);
            this.instrument11.TabIndex = 1;
            this.instrument11.Text = "instrument11";
            this.instrument11.刷新系数 = 4;
            this.instrument11.显示文字 = "CPU占用";
            // 
            // tempControl1
            // 
            this.tempControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tempControl1.Location = new System.Drawing.Point(22, 13);
            this.tempControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tempControl1.Max = 100F;
            this.tempControl1.Min = 0F;
            this.tempControl1.Name = "tempControl1";
            this.tempControl1.Size = new System.Drawing.Size(65, 548);
            this.tempControl1.TabIndex = 0;
            this.tempControl1.Text = "tempControl1";
            this.tempControl1.Value = 0F;
            this.tempControl1.刷新系数 = 4;
            this.tempControl1.微分 = 0.05F;
            this.tempControl1.显示文字 = "CPU温度";
            this.tempControl1.比例 = 0.5F;
            this.tempControl1.积分 = 0.08F;
            // 
            // instrument21
            // 
            this.instrument21.BackColor = System.Drawing.Color.Black;
            this.instrument21.Location = new System.Drawing.Point(310, -33);
            this.instrument21.Name = "instrument21";
            this.instrument21.Size = new System.Drawing.Size(1342, 618);
            this.instrument21.TabIndex = 5;
            this.instrument21.Text = "instrument21";
            this.instrument21.Value = 1F;
            this.instrument21.刷新间隔 = 1000;
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1595, 1410);
            this.Controls.Add(this.tempControl4);
            this.Controls.Add(this.tempControl3);
            this.Controls.Add(this.tempControl2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.instrument14);
            this.Controls.Add(this.instrument13);
            this.Controls.Add(this.instrument12);
            this.Controls.Add(this.instrument11);
            this.Controls.Add(this.tempControl1);
            this.Controls.Add(this.instrument21);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayForm_FormClosing);
            this.Load += new System.EventHandler(this.DisplayForm_Load);
            this.Shown += new System.EventHandler(this.DisplayForm_Shown);
            this.DoubleClick += new System.EventHandler(this.DisplayForm_DoubleClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DisplayForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonitorControlsLibrary.TempControl.TempControl tempControl1;
        private MonitorControlsLibrary.Instrument1.Instrument1 instrument11;
        private MonitorControlsLibrary.Instrument1.Instrument1 instrument12;
        private MonitorControlsLibrary.Instrument1.Instrument1 instrument13;
        private MonitorControlsLibrary.Instrument1.Instrument1 instrument14;
        private MonitorControlsLibrary.Instrument2.Instrument2 instrument21;
        private System.Windows.Forms.TrackBar trackBar1;
        private MonitorControlsLibrary.TempControl.TempControl tempControl2;
        private MonitorControlsLibrary.TempControl.TempControl tempControl3;
        private MonitorControlsLibrary.TempControl.TempControl tempControl4;
    }
}