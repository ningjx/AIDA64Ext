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
            this.timeControl1 = new MonitorControlsLibrary.TimeControl();
            this.SuspendLayout();
            // 
            // timeControl1
            // 
            this.timeControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.timeControl1.Location = new System.Drawing.Point(44, 94);
            this.timeControl1.Name = "timeControl1";
            this.timeControl1.Size = new System.Drawing.Size(635, 551);
            this.timeControl1.TabIndex = 0;
            this.timeControl1.Text = "timeControl1";
            this.timeControl1.Click += new System.EventHandler(this.timeControl1_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 704);
            this.Controls.Add(this.timeControl1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MonitorControlsLibrary.TimeControl timeControl1;
    }
}