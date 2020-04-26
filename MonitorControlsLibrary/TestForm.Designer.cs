namespace MonitorControlsLibrary
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
            this.SuspendLayout();
            // 
            // instrument21
            // 
            this.instrument21.BackColor = System.Drawing.Color.Black;
            this.instrument21.Location = new System.Drawing.Point(133, 76);
            this.instrument21.Name = "instrument21";
            this.instrument21.Size = new System.Drawing.Size(953, 464);
            this.instrument21.TabIndex = 0;
            this.instrument21.Text = "instrument21";
            this.instrument21.Value = 1F;
            this.instrument21.刷新间隔 = 1000;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 777);
            this.Controls.Add(this.instrument21);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Instrument2.Instrument2 instrument21;
    }
}