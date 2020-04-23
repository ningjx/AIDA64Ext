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
            this.instrument21 = new MonitorControlsLibrary.Instrument2.Instrument2();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // instrument21
            // 
            this.instrument21.BackColor = System.Drawing.Color.Black;
            this.instrument21.Location = new System.Drawing.Point(109, 40);
            this.instrument21.Name = "instrument21";
            this.instrument21.Size = new System.Drawing.Size(795, 441);
            this.instrument21.TabIndex = 0;
            this.instrument21.Text = "instrument21";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(157, 545);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(685, 69);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 704);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.instrument21);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonitorControlsLibrary.Instrument2.Instrument2 instrument21;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}