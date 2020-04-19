namespace AIDA64Ext.Forms
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.instrument14 = new AIDAFormsControlLibrary.Instrument1.Instrument1();
            this.instrument13 = new AIDAFormsControlLibrary.Instrument1.Instrument1();
            this.instrument12 = new AIDAFormsControlLibrary.Instrument1.Instrument1();
            this.instrument11 = new AIDAFormsControlLibrary.Instrument1.Instrument1();
            this.tempControl1 = new AIDAFormsControlLibrary.TempControl.TempControl();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // instrument14
            // 
            this.instrument14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument14.Location = new System.Drawing.Point(539, 348);
            this.instrument14.Name = "instrument14";
            this.instrument14.Size = new System.Drawing.Size(278, 148);
            this.instrument14.TabIndex = 4;
            this.instrument14.Text = "instrument14";
            // 
            // instrument13
            // 
            this.instrument13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument13.Location = new System.Drawing.Point(231, 348);
            this.instrument13.Name = "instrument13";
            this.instrument13.Size = new System.Drawing.Size(278, 148);
            this.instrument13.TabIndex = 3;
            this.instrument13.Text = "instrument13";
            // 
            // instrument12
            // 
            this.instrument12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument12.Location = new System.Drawing.Point(539, 158);
            this.instrument12.Name = "instrument12";
            this.instrument12.Size = new System.Drawing.Size(278, 148);
            this.instrument12.TabIndex = 2;
            this.instrument12.Text = "instrument12";
            this.instrument12.Click += new System.EventHandler(this.instrument12_Click);
            // 
            // instrument11
            // 
            this.instrument11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.instrument11.Location = new System.Drawing.Point(231, 158);
            this.instrument11.Name = "instrument11";
            this.instrument11.Size = new System.Drawing.Size(278, 148);
            this.instrument11.TabIndex = 1;
            this.instrument11.Text = "instrument11";
            // 
            // tempControl1
            // 
            this.tempControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tempControl1.Location = new System.Drawing.Point(106, 43);
            this.tempControl1.Name = "tempControl1";
            this.tempControl1.Size = new System.Drawing.Size(59, 506);
            this.tempControl1.TabIndex = 0;
            this.tempControl1.Text = "tempControl1";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1080, 1421);
            this.Controls.Add(this.instrument14);
            this.Controls.Add(this.instrument13);
            this.Controls.Add(this.instrument12);
            this.Controls.Add(this.instrument11);
            this.Controls.Add(this.tempControl1);
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayForm_FormClosing);
            this.Load += new System.EventHandler(this.DisplayForm_Load);
            this.DoubleClick += new System.EventHandler(this.DisplayForm_DoubleClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DisplayForm_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private AIDAFormsControlLibrary.TempControl.TempControl tempControl1;
        private System.Windows.Forms.Timer timer1;
        private AIDAFormsControlLibrary.Instrument1.Instrument1 instrument11;
        private AIDAFormsControlLibrary.Instrument1.Instrument1 instrument12;
        private AIDAFormsControlLibrary.Instrument1.Instrument1 instrument13;
        private AIDAFormsControlLibrary.Instrument1.Instrument1 instrument14;
    }
}