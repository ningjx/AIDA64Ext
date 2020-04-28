namespace AIDA64Ext.Forms
{
    partial class TestForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.timeControl1 = new MonitorControlsLibrary.TimeControl();
            this.netSpeedControl1 = new MonitorControlsLibrary.NetSpeedControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timeControl1
            // 
            this.timeControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.timeControl1.Location = new System.Drawing.Point(12, 12);
            this.timeControl1.Name = "timeControl1";
            this.timeControl1.Size = new System.Drawing.Size(635, 224);
            this.timeControl1.TabIndex = 0;
            this.timeControl1.Text = "timeControl1";
            this.timeControl1.Click += new System.EventHandler(this.timeControl1_Click);
            // 
            // netSpeedControl1
            // 
            this.netSpeedControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.netSpeedControl1.Download = "0.00 KB/s";
            this.netSpeedControl1.DownloadBigger = true;
            this.netSpeedControl1.Location = new System.Drawing.Point(476, 312);
            this.netSpeedControl1.Name = "netSpeedControl1";
            this.netSpeedControl1.Size = new System.Drawing.Size(249, 75);
            this.netSpeedControl1.TabIndex = 3;
            this.netSpeedControl1.Text = "netSpeedControl1";
            this.netSpeedControl1.Upload = "0.00 KB/s";
            // 
            // TestForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(849, 544);
            this.Controls.Add(this.netSpeedControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeControl1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MonitorControlsLibrary.TimeControl timeControl1;
        private System.Windows.Forms.Button button1;
        private MonitorControlsLibrary.NetSpeedControl netSpeedControl1;
    }
}