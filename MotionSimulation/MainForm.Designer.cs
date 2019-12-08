using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pb_Universe = new System.Windows.Forms.PictureBox();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.nUD_Length = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nUD_Time = new System.Windows.Forms.NumericUpDown();
            this.btn_ToCenter = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_IsAbandoned = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nUD_Radius = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nUD_Mass = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_AddBody = new System.Windows.Forms.Button();
            this.nUD_positionY = new System.Windows.Forms.NumericUpDown();
            this.nUD_positionX = new System.Windows.Forms.NumericUpDown();
            this.nUD_speedY = new System.Windows.Forms.NumericUpDown();
            this.nUD_speedX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Universe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Time)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Radius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Mass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_positionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_positionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_speedY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_speedX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 902);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1284, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 19);
            this.toolStripStatusLabel1.Text = ".";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(45, 19);
            this.toolStripStatusLabel2.Text = "Traces";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pb_Universe
            // 
            this.pb_Universe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Universe.BackColor = System.Drawing.Color.Black;
            this.pb_Universe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Universe.BackgroundImage")));
            this.pb_Universe.InitialImage = null;
            this.pb_Universe.Location = new System.Drawing.Point(0, 42);
            this.pb_Universe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb_Universe.Name = "pb_Universe";
            this.pb_Universe.Size = new System.Drawing.Size(1051, 856);
            this.pb_Universe.TabIndex = 2;
            this.pb_Universe.TabStop = false;
            this.pb_Universe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_Universe_MouseMove);
            this.pb_Universe.Resize += new System.EventHandler(this.pb_Universe_Resize);
            // 
            // lbl_Info
            // 
            this.lbl_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new System.Drawing.Point(1054, 55);
            this.lbl_Info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(13, 20);
            this.lbl_Info.TabIndex = 3;
            this.lbl_Info.Text = ".";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1129, 868);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Розпочати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nUD_Length
            // 
            this.nUD_Length.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUD_Length.Location = new System.Drawing.Point(91, 55);
            this.nUD_Length.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nUD_Length.Size = new System.Drawing.Size(111, 26);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Час";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Довжина";
            // 
            // nUD_Time
            // 
            this.nUD_Time.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_Time.Location = new System.Drawing.Point(91, 21);
            this.nUD_Time.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nUD_Time.Size = new System.Drawing.Size(111, 26);
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
            this.btn_ToCenter.Location = new System.Drawing.Point(1129, 794);
            this.btn_ToCenter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ToCenter.Name = "btn_ToCenter";
            this.btn_ToCenter.Size = new System.Drawing.Size(132, 30);
            this.btn_ToCenter.TabIndex = 12;
            this.btn_ToCenter.Text = "У центр";
            this.toolTip1.SetToolTip(this.btn_ToCenter, "Move the Mass center to the center window");
            this.btn_ToCenter.UseVisualStyleBackColor = true;
            this.btn_ToCenter.Click += new System.EventHandler(this.btn_ToCenter_Click);
            // 
            // btn_IsAbandoned
            // 
            this.btn_IsAbandoned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_IsAbandoned.Location = new System.Drawing.Point(1129, 831);
            this.btn_IsAbandoned.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_IsAbandoned.Name = "btn_IsAbandoned";
            this.btn_IsAbandoned.Size = new System.Drawing.Size(132, 30);
            this.btn_IsAbandoned.TabIndex = 13;
            this.btn_IsAbandoned.Text = "Повернеться";
            this.btn_IsAbandoned.UseVisualStyleBackColor = true;
            this.btn_IsAbandoned.Click += new System.EventHandler(this.btn_IsAbandoned_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Y:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nUD_Radius);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.nUD_Mass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_AddBody);
            this.groupBox1.Controls.Add(this.nUD_positionY);
            this.groupBox1.Controls.Add(this.nUD_positionX);
            this.groupBox1.Controls.Add(this.nUD_speedY);
            this.groupBox1.Controls.Add(this.nUD_speedX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1059, 379);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(212, 304);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Астероїд";
            // 
            // nUD_Radius
            // 
            this.nUD_Radius.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUD_Radius.Location = new System.Drawing.Point(91, 234);
            this.nUD_Radius.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nUD_Radius.Maximum = new decimal(new int[] {
            999000000,
            0,
            0,
            0});
            this.nUD_Radius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_Radius.Name = "nUD_Radius";
            this.nUD_Radius.Size = new System.Drawing.Size(111, 26);
            this.nUD_Radius.TabIndex = 32;
            this.nUD_Radius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUD_Radius.ThousandsSeparator = true;
            this.nUD_Radius.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nUD_Radius.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 236);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "Радиус, м:";
            // 
            // nUD_Mass
            // 
            this.nUD_Mass.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUD_Mass.Location = new System.Drawing.Point(70, 202);
            this.nUD_Mass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nUD_Mass.Maximum = new decimal(new int[] {
            215752192,
            23,
            0,
            0});
            this.nUD_Mass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_Mass.Name = "nUD_Mass";
            this.nUD_Mass.Size = new System.Drawing.Size(132, 26);
            this.nUD_Mass.TabIndex = 30;
            this.nUD_Mass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUD_Mass.ThousandsSeparator = true;
            this.nUD_Mass.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nUD_Mass.Value = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Вага, т:";
            // 
            // btn_AddBody
            // 
            this.btn_AddBody.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddBody.Location = new System.Drawing.Point(70, 266);
            this.btn_AddBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_AddBody.Name = "btn_AddBody";
            this.btn_AddBody.Size = new System.Drawing.Size(132, 30);
            this.btn_AddBody.TabIndex = 28;
            this.btn_AddBody.Text = "Додати";
            this.btn_AddBody.UseVisualStyleBackColor = true;
            this.btn_AddBody.Click += new System.EventHandler(this.btn_AddBody_Click);
            // 
            // nUD_positionY
            // 
            this.nUD_positionY.Increment = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nUD_positionY.Location = new System.Drawing.Point(48, 169);
            this.nUD_positionY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nUD_positionY.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nUD_positionY.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.nUD_positionY.Name = "nUD_positionY";
            this.nUD_positionY.Size = new System.Drawing.Size(154, 26);
            this.nUD_positionY.TabIndex = 27;
            this.nUD_positionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUD_positionY.ThousandsSeparator = true;
            this.nUD_positionY.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nUD_positionY.Value = new decimal(new int[] {
            700000000,
            0,
            0,
            0});
            // 
            // nUD_positionX
            // 
            this.nUD_positionX.Increment = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nUD_positionX.Location = new System.Drawing.Point(48, 136);
            this.nUD_positionX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nUD_positionX.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nUD_positionX.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.nUD_positionX.Name = "nUD_positionX";
            this.nUD_positionX.Size = new System.Drawing.Size(154, 26);
            this.nUD_positionX.TabIndex = 26;
            this.nUD_positionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUD_positionX.ThousandsSeparator = true;
            this.nUD_positionX.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nUD_positionX.Value = new decimal(new int[] {
            884467000,
            0,
            0,
            0});
            // 
            // nUD_speedY
            // 
            this.nUD_speedY.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUD_speedY.Location = new System.Drawing.Point(48, 80);
            this.nUD_speedY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nUD_speedY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_speedY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_speedY.Name = "nUD_speedY";
            this.nUD_speedY.Size = new System.Drawing.Size(154, 26);
            this.nUD_speedY.TabIndex = 25;
            this.nUD_speedY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUD_speedY.ThousandsSeparator = true;
            this.nUD_speedY.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nUD_speedY.Value = new decimal(new int[] {
            810,
            0,
            0,
            -2147483648});
            // 
            // nUD_speedX
            // 
            this.nUD_speedX.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUD_speedX.Location = new System.Drawing.Point(48, 47);
            this.nUD_speedX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nUD_speedX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_speedX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_speedX.Name = "nUD_speedX";
            this.nUD_speedX.Size = new System.Drawing.Size(154, 26);
            this.nUD_speedX.TabIndex = 24;
            this.nUD_speedX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUD_speedX.ThousandsSeparator = true;
            this.nUD_speedX.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nUD_speedX.Value = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Позиція, м:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 138);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Х:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 171);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Швидкість, м/с:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Х:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.nUD_Time);
            this.groupBox2.Controls.Add(this.nUD_Length);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(1059, 693);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(212, 91);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Масштаб";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 926);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_IsAbandoned);
            this.Controls.Add(this.btn_ToCenter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.pb_Universe);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1192, 964);
            this.Name = "MainForm";
            this.Text = "Задача тіл";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Universe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Time)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Radius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Mass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_positionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_positionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_speedY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_speedX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pb_Universe;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nUD_Length;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUD_Time;
        private System.Windows.Forms.Button btn_ToCenter;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btn_IsAbandoned;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nUD_positionX;
        private System.Windows.Forms.NumericUpDown nUD_speedY;
        private System.Windows.Forms.NumericUpDown nUD_speedX;
        private System.Windows.Forms.NumericUpDown nUD_positionY;
        private System.Windows.Forms.Button btn_AddBody;
        private System.Windows.Forms.NumericUpDown nUD_Mass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.NumericUpDown nUD_Radius;
        private System.Windows.Forms.Label label10;
    }
}

