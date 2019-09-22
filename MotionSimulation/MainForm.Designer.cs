namespace MotionSimulation
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pb_Universe = new System.Windows.Forms.PictureBox();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.nUD_Length = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nUD_Time = new System.Windows.Forms.NumericUpDown();
            this.btn_ToCenter = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Universe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Time)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 840);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pb_Universe
            // 
            this.pb_Universe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Universe.BackColor = System.Drawing.Color.Black;
            this.pb_Universe.Location = new System.Drawing.Point(0, 27);
            this.pb_Universe.Name = "pb_Universe";
            this.pb_Universe.Size = new System.Drawing.Size(1032, 810);
            this.pb_Universe.TabIndex = 2;
            this.pb_Universe.TabStop = false;
            // 
            // lbl_Info
            // 
            this.lbl_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new System.Drawing.Point(1038, 36);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(35, 13);
            this.lbl_Info.TabIndex = 3;
            this.lbl_Info.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1084, 816);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nUD_Length
            // 
            this.nUD_Length.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUD_Length.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUD_Length.Location = new System.Drawing.Point(1084, 790);
            this.nUD_Length.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nUD_Length.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUD_Length.Name = "nUD_Length";
            this.nUD_Length.ReadOnly = true;
            this.nUD_Length.Size = new System.Drawing.Size(88, 20);
            this.nUD_Length.TabIndex = 7;
            this.nUD_Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUD_Length.ThousandsSeparator = true;
            this.nUD_Length.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nUD_Length.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUD_Length.ValueChanged += new System.EventHandler(this.nUD_Length_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1039, 737);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Scale";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1039, 766);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Time";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1038, 790);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Length";
            // 
            // nUD_Time
            // 
            this.nUD_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUD_Time.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_Time.Location = new System.Drawing.Point(1084, 764);
            this.nUD_Time.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUD_Time.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_Time.Name = "nUD_Time";
            this.nUD_Time.ReadOnly = true;
            this.nUD_Time.Size = new System.Drawing.Size(88, 20);
            this.nUD_Time.TabIndex = 11;
            this.nUD_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUD_Time.ThousandsSeparator = true;
            this.nUD_Time.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nUD_Time.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUD_Time.ValueChanged += new System.EventHandler(this.nUD_Time_ValueChanged);
            // 
            // btn_ToCenter
            // 
            this.btn_ToCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ToCenter.Location = new System.Drawing.Point(1084, 672);
            this.btn_ToCenter.Name = "btn_ToCenter";
            this.btn_ToCenter.Size = new System.Drawing.Size(88, 26);
            this.btn_ToCenter.TabIndex = 12;
            this.btn_ToCenter.Text = "To center";
            this.toolTip1.SetToolTip(this.btn_ToCenter, "Move the Mass center to the center window");
            this.btn_ToCenter.UseVisualStyleBackColor = true;
            this.btn_ToCenter.Click += new System.EventHandler(this.btn_ToCenter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 862);
            this.Controls.Add(this.btn_ToCenter);
            this.Controls.Add(this.nUD_Time);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nUD_Length);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.pb_Universe);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1200, 900);
            this.MinimumSize = new System.Drawing.Size(1200, 900);
            this.Name = "MainForm";
            this.Text = "Simulation of motion";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Universe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pb_Universe;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nUD_Length;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUD_Time;
        private System.Windows.Forms.Button btn_ToCenter;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

