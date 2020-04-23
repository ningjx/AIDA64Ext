namespace NingMonitor.Forms
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
            this.instrument14 = new MonitorControlsLibrary.Instrument1.Instrument1();
            this.instrument13 = new MonitorControlsLibrary.Instrument1.Instrument1();
            this.instrument12 = new MonitorControlsLibrary.Instrument1.Instrument1();
            this.instrument11 = new MonitorControlsLibrary.Instrument1.Instrument1();
            this.tempControl1 = new MonitorControlsLibrary.TempControl.TempControl();
            this.instrument21 = new MonitorControlsLibrary.Instrument2.Instrument2();
            this.tempControl2 = new MonitorControlsLibrary.TempControl.TempControl();
            this.SuspendLayout();
            // 
            // instrument14
            // 
            this.instrument14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument14.Location = new System.Drawing.Point(698, 671);
            this.instrument14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.instrument14.Name = "instrument14";
            this.instrument14.Size = new System.Drawing.Size(287, 184);
            this.instrument14.TabIndex = 4;
            this.instrument14.Text = "instrument14";
            // 
            // instrument13
            // 
            this.instrument13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument13.Location = new System.Drawing.Point(236, 671);
            this.instrument13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.instrument13.Name = "instrument13";
            this.instrument13.Size = new System.Drawing.Size(287, 184);
            this.instrument13.TabIndex = 3;
            this.instrument13.Text = "instrument13";
            // 
            // instrument12
            // 
            this.instrument12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument12.Location = new System.Drawing.Point(698, 458);
            this.instrument12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.instrument12.Name = "instrument12";
            this.instrument12.Size = new System.Drawing.Size(287, 184);
            this.instrument12.TabIndex = 2;
            this.instrument12.Text = "instrument12";
            // 
            // instrument11
            // 
            this.instrument11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument11.Location = new System.Drawing.Point(236, 458);
            this.instrument11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.instrument11.Name = "instrument11";
            this.instrument11.Size = new System.Drawing.Size(287, 184);
            this.instrument11.TabIndex = 1;
            this.instrument11.Text = "instrument11";
            // 
            // tempControl1
            // 
            this.tempControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tempControl1.Location = new System.Drawing.Point(22, 13);
            this.tempControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tempControl1.Name = "tempControl1";
            this.tempControl1.Size = new System.Drawing.Size(47, 397);
            this.tempControl1.TabIndex = 0;
            this.tempControl1.Text = "tempControl1";
            // 
            // instrument21
            // 
            this.instrument21.BackColor = System.Drawing.Color.Black;
            this.instrument21.Location = new System.Drawing.Point(135, -11);
            this.instrument21.Name = "instrument21";
            this.instrument21.Size = new System.Drawing.Size(946, 476);
            this.instrument21.TabIndex = 5;
            this.instrument21.Text = "instrument21";
            // 
            // tempControl2
            // 
            this.tempControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tempControl2.Location = new System.Drawing.Point(110, 13);
            this.tempControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tempControl2.Name = "tempControl2";
            this.tempControl2.Size = new System.Drawing.Size(47, 397);
            this.tempControl2.TabIndex = 6;
            this.tempControl2.Text = "tempControl2";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1058, 1410);
            this.Controls.Add(this.tempControl2);
            this.Controls.Add(this.instrument14);
            this.Controls.Add(this.instrument13);
            this.Controls.Add(this.instrument12);
            this.Controls.Add(this.instrument11);
            this.Controls.Add(this.tempControl1);
            this.Controls.Add(this.instrument21);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayForm_FormClosing);
            this.Load += new System.EventHandler(this.DisplayForm_Load);
            this.Shown += new System.EventHandler(this.DisplayForm_Shown);
            this.DoubleClick += new System.EventHandler(this.DisplayForm_DoubleClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DisplayForm_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private MonitorControlsLibrary.TempControl.TempControl tempControl1;
        private MonitorControlsLibrary.Instrument1.Instrument1 instrument11;
        private MonitorControlsLibrary.Instrument1.Instrument1 instrument12;
        private MonitorControlsLibrary.Instrument1.Instrument1 instrument13;
        private MonitorControlsLibrary.Instrument1.Instrument1 instrument14;
        private MonitorControlsLibrary.Instrument2.Instrument2 instrument21;
        private MonitorControlsLibrary.TempControl.TempControl tempControl2;
    }
}