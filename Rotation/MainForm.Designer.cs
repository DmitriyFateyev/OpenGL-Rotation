/*
 * Created by SharpDevelop.
 * User: Дмитрий
 * Date: 06.12.2018
 * Time: 20:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Rotation
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBoxRotation;
		private System.Windows.Forms.Label lblPitchValue;
		private System.Windows.Forms.Label lblYawValue;
		private System.Windows.Forms.Label lblRollValue;
		private System.Windows.Forms.TrackBar trckBarYawY;
		private System.Windows.Forms.TrackBar trckBarPitchZ;
		private System.Windows.Forms.Label lblYaw;
		private System.Windows.Forms.Label lblPitch;
		private System.Windows.Forms.Label lblRoll;
		private System.Windows.Forms.TrackBar trckBarRollX;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnResetRotation;
		private System.Windows.Forms.Timer timer1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.cbxAnimate = new System.Windows.Forms.CheckBox();
            this.btnResetRotation = new System.Windows.Forms.Button();
            this.groupBoxRotation = new System.Windows.Forms.GroupBox();
            this.btnSetZtoZero = new System.Windows.Forms.Button();
            this.btnSetYtoZero = new System.Windows.Forms.Button();
            this.btnSetXtoZero = new System.Windows.Forms.Button();
            this.lblPitchValue = new System.Windows.Forms.Label();
            this.lblYawValue = new System.Windows.Forms.Label();
            this.lblRollValue = new System.Windows.Forms.Label();
            this.trckBarYawY = new System.Windows.Forms.TrackBar();
            this.trckBarPitchZ = new System.Windows.Forms.TrackBar();
            this.lblYaw = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.trckBarRollX = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblM00 = new System.Windows.Forms.Label();
            this.lblM15 = new System.Windows.Forms.Label();
            this.lblM01 = new System.Windows.Forms.Label();
            this.lblM14 = new System.Windows.Forms.Label();
            this.lblM02 = new System.Windows.Forms.Label();
            this.lblM13 = new System.Windows.Forms.Label();
            this.lblM03 = new System.Windows.Forms.Label();
            this.lblM12 = new System.Windows.Forms.Label();
            this.lblM04 = new System.Windows.Forms.Label();
            this.lblM11 = new System.Windows.Forms.Label();
            this.lblM05 = new System.Windows.Forms.Label();
            this.lblM10 = new System.Windows.Forms.Label();
            this.lblM06 = new System.Windows.Forms.Label();
            this.lblM09 = new System.Windows.Forms.Label();
            this.lblM07 = new System.Windows.Forms.Label();
            this.lblM08 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBoxRotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarYawY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarPitchZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarRollX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxAnimate
            // 
            this.cbxAnimate.AutoSize = true;
            this.cbxAnimate.Location = new System.Drawing.Point(6, 435);
            this.cbxAnimate.Name = "cbxAnimate";
            this.cbxAnimate.Size = new System.Drawing.Size(64, 17);
            this.cbxAnimate.TabIndex = 2;
            this.cbxAnimate.Text = "Animate";
            this.cbxAnimate.UseVisualStyleBackColor = true;
            // 
            // btnResetRotation
            // 
            this.btnResetRotation.Location = new System.Drawing.Point(6, 369);
            this.btnResetRotation.Name = "btnResetRotation";
            this.btnResetRotation.Size = new System.Drawing.Size(91, 46);
            this.btnResetRotation.TabIndex = 1;
            this.btnResetRotation.Text = "Reset rotation";
            this.btnResetRotation.UseVisualStyleBackColor = true;
            this.btnResetRotation.Click += new System.EventHandler(this.BtnResetRotationClick);
            // 
            // groupBoxRotation
            // 
            this.groupBoxRotation.Controls.Add(this.btnSetZtoZero);
            this.groupBoxRotation.Controls.Add(this.btnSetYtoZero);
            this.groupBoxRotation.Controls.Add(this.btnSetXtoZero);
            this.groupBoxRotation.Controls.Add(this.lblPitchValue);
            this.groupBoxRotation.Controls.Add(this.lblYawValue);
            this.groupBoxRotation.Controls.Add(this.lblRollValue);
            this.groupBoxRotation.Controls.Add(this.trckBarYawY);
            this.groupBoxRotation.Controls.Add(this.trckBarPitchZ);
            this.groupBoxRotation.Controls.Add(this.lblYaw);
            this.groupBoxRotation.Controls.Add(this.lblPitch);
            this.groupBoxRotation.Controls.Add(this.lblRoll);
            this.groupBoxRotation.Controls.Add(this.trckBarRollX);
            this.groupBoxRotation.Location = new System.Drawing.Point(6, 19);
            this.groupBoxRotation.Name = "groupBoxRotation";
            this.groupBoxRotation.Size = new System.Drawing.Size(444, 160);
            this.groupBoxRotation.TabIndex = 0;
            this.groupBoxRotation.TabStop = false;
            this.groupBoxRotation.Text = "Rotation";
            // 
            // btnSetZtoZero
            // 
            this.btnSetZtoZero.Location = new System.Drawing.Point(408, 104);
            this.btnSetZtoZero.Name = "btnSetZtoZero";
            this.btnSetZtoZero.Size = new System.Drawing.Size(21, 28);
            this.btnSetZtoZero.TabIndex = 1;
            this.btnSetZtoZero.Text = "0";
            this.btnSetZtoZero.UseVisualStyleBackColor = true;
            this.btnSetZtoZero.Click += new System.EventHandler(this.btnSetZtoZero_Click);
            // 
            // btnSetYtoZero
            // 
            this.btnSetYtoZero.Location = new System.Drawing.Point(408, 59);
            this.btnSetYtoZero.Name = "btnSetYtoZero";
            this.btnSetYtoZero.Size = new System.Drawing.Size(21, 28);
            this.btnSetYtoZero.TabIndex = 1;
            this.btnSetYtoZero.Text = "0";
            this.btnSetYtoZero.UseVisualStyleBackColor = true;
            this.btnSetYtoZero.Click += new System.EventHandler(this.btnSetYtoZero_Click);
            // 
            // btnSetXtoZero
            // 
            this.btnSetXtoZero.Location = new System.Drawing.Point(408, 14);
            this.btnSetXtoZero.Name = "btnSetXtoZero";
            this.btnSetXtoZero.Size = new System.Drawing.Size(21, 28);
            this.btnSetXtoZero.TabIndex = 1;
            this.btnSetXtoZero.Text = "0";
            this.btnSetXtoZero.UseVisualStyleBackColor = true;
            this.btnSetXtoZero.Click += new System.EventHandler(this.btnSetXtoZero_Click);
            // 
            // lblPitchValue
            // 
            this.lblPitchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPitchValue.ForeColor = System.Drawing.Color.Blue;
            this.lblPitchValue.Location = new System.Drawing.Point(363, 64);
            this.lblPitchValue.Name = "lblPitchValue";
            this.lblPitchValue.Size = new System.Drawing.Size(39, 23);
            this.lblPitchValue.TabIndex = 8;
            this.lblPitchValue.Text = "0";
            // 
            // lblYawValue
            // 
            this.lblYawValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblYawValue.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblYawValue.Location = new System.Drawing.Point(363, 109);
            this.lblYawValue.Name = "lblYawValue";
            this.lblYawValue.Size = new System.Drawing.Size(39, 23);
            this.lblYawValue.TabIndex = 7;
            this.lblYawValue.Text = "0";
            // 
            // lblRollValue
            // 
            this.lblRollValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRollValue.ForeColor = System.Drawing.Color.Red;
            this.lblRollValue.Location = new System.Drawing.Point(363, 19);
            this.lblRollValue.Name = "lblRollValue";
            this.lblRollValue.Size = new System.Drawing.Size(39, 23);
            this.lblRollValue.TabIndex = 6;
            this.lblRollValue.Text = "0";
            // 
            // trckBarYawY
            // 
            this.trckBarYawY.Location = new System.Drawing.Point(34, 64);
            this.trckBarYawY.Maximum = 180;
            this.trckBarYawY.Name = "trckBarYawY";
            this.trckBarYawY.Size = new System.Drawing.Size(323, 45);
            this.trckBarYawY.TabIndex = 5;
            this.trckBarYawY.TickFrequency = 10;
            this.trckBarYawY.ValueChanged += new System.EventHandler(this.trckBarYawY_ValueChanged);
            // 
            // trckBarPitchZ
            // 
            this.trckBarPitchZ.Location = new System.Drawing.Point(34, 109);
            this.trckBarPitchZ.Maximum = 90;
            this.trckBarPitchZ.Name = "trckBarPitchZ";
            this.trckBarPitchZ.Size = new System.Drawing.Size(323, 45);
            this.trckBarPitchZ.TabIndex = 4;
            this.trckBarPitchZ.TickFrequency = 10;
            this.trckBarPitchZ.ValueChanged += new System.EventHandler(this.trckBarPitchZ_ValueChanged);
            // 
            // lblYaw
            // 
            this.lblYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblYaw.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblYaw.Location = new System.Drawing.Point(7, 109);
            this.lblYaw.Name = "lblYaw";
            this.lblYaw.Size = new System.Drawing.Size(21, 23);
            this.lblYaw.TabIndex = 3;
            this.lblYaw.Text = "Z";
            // 
            // lblPitch
            // 
            this.lblPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPitch.ForeColor = System.Drawing.Color.Blue;
            this.lblPitch.Location = new System.Drawing.Point(7, 64);
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.Size = new System.Drawing.Size(21, 23);
            this.lblPitch.TabIndex = 2;
            this.lblPitch.Text = "Y";
            // 
            // lblRoll
            // 
            this.lblRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRoll.ForeColor = System.Drawing.Color.Red;
            this.lblRoll.Location = new System.Drawing.Point(7, 19);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(23, 23);
            this.lblRoll.TabIndex = 1;
            this.lblRoll.Text = "X";
            // 
            // trckBarRollX
            // 
            this.trckBarRollX.Location = new System.Drawing.Point(34, 19);
            this.trckBarRollX.Maximum = 180;
            this.trckBarRollX.Name = "trckBarRollX";
            this.trckBarRollX.Size = new System.Drawing.Size(323, 45);
            this.trckBarRollX.TabIndex = 0;
            this.trckBarRollX.TickFrequency = 10;
            this.trckBarRollX.ValueChanged += new System.EventHandler(this.trckBarRollX_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(5, 19);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(600, 600);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblM00);
            this.groupBox1.Controls.Add(this.lblM15);
            this.groupBox1.Controls.Add(this.lblM01);
            this.groupBox1.Controls.Add(this.lblM14);
            this.groupBox1.Controls.Add(this.lblM02);
            this.groupBox1.Controls.Add(this.lblM13);
            this.groupBox1.Controls.Add(this.lblM03);
            this.groupBox1.Controls.Add(this.lblM12);
            this.groupBox1.Controls.Add(this.lblM04);
            this.groupBox1.Controls.Add(this.lblM11);
            this.groupBox1.Controls.Add(this.lblM05);
            this.groupBox1.Controls.Add(this.lblM10);
            this.groupBox1.Controls.Add(this.lblM06);
            this.groupBox1.Controls.Add(this.lblM09);
            this.groupBox1.Controls.Add(this.lblM07);
            this.groupBox1.Controls.Add(this.lblM08);
            this.groupBox1.Location = new System.Drawing.Point(6, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 178);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ModelView Matrix";
            // 
            // lblM00
            // 
            this.lblM00.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM00.ForeColor = System.Drawing.Color.Red;
            this.lblM00.Location = new System.Drawing.Point(6, 16);
            this.lblM00.Name = "lblM00";
            this.lblM00.Size = new System.Drawing.Size(93, 23);
            this.lblM00.TabIndex = 4;
            this.lblM00.Text = "0";
            // 
            // lblM15
            // 
            this.lblM15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM15.Location = new System.Drawing.Point(340, 139);
            this.lblM15.Name = "lblM15";
            this.lblM15.Size = new System.Drawing.Size(84, 23);
            this.lblM15.TabIndex = 4;
            this.lblM15.Text = "0";
            // 
            // lblM01
            // 
            this.lblM01.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM01.ForeColor = System.Drawing.Color.Red;
            this.lblM01.Location = new System.Drawing.Point(6, 57);
            this.lblM01.Name = "lblM01";
            this.lblM01.Size = new System.Drawing.Size(94, 23);
            this.lblM01.TabIndex = 4;
            this.lblM01.Text = "0";
            // 
            // lblM14
            // 
            this.lblM14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM14.Location = new System.Drawing.Point(340, 98);
            this.lblM14.Name = "lblM14";
            this.lblM14.Size = new System.Drawing.Size(84, 23);
            this.lblM14.TabIndex = 4;
            this.lblM14.Text = "0";
            // 
            // lblM02
            // 
            this.lblM02.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM02.ForeColor = System.Drawing.Color.Red;
            this.lblM02.Location = new System.Drawing.Point(6, 98);
            this.lblM02.Name = "lblM02";
            this.lblM02.Size = new System.Drawing.Size(94, 23);
            this.lblM02.TabIndex = 4;
            this.lblM02.Text = "0";
            // 
            // lblM13
            // 
            this.lblM13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM13.Location = new System.Drawing.Point(340, 57);
            this.lblM13.Name = "lblM13";
            this.lblM13.Size = new System.Drawing.Size(84, 23);
            this.lblM13.TabIndex = 4;
            this.lblM13.Text = "0";
            // 
            // lblM03
            // 
            this.lblM03.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM03.Location = new System.Drawing.Point(6, 139);
            this.lblM03.Name = "lblM03";
            this.lblM03.Size = new System.Drawing.Size(94, 23);
            this.lblM03.TabIndex = 4;
            this.lblM03.Text = "0";
            // 
            // lblM12
            // 
            this.lblM12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM12.Location = new System.Drawing.Point(340, 16);
            this.lblM12.Name = "lblM12";
            this.lblM12.Size = new System.Drawing.Size(84, 23);
            this.lblM12.TabIndex = 4;
            this.lblM12.Text = "0";
            // 
            // lblM04
            // 
            this.lblM04.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM04.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblM04.Location = new System.Drawing.Point(117, 16);
            this.lblM04.Name = "lblM04";
            this.lblM04.Size = new System.Drawing.Size(92, 23);
            this.lblM04.TabIndex = 4;
            this.lblM04.Text = "0";
            // 
            // lblM11
            // 
            this.lblM11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM11.Location = new System.Drawing.Point(227, 139);
            this.lblM11.Name = "lblM11";
            this.lblM11.Size = new System.Drawing.Size(96, 23);
            this.lblM11.TabIndex = 4;
            this.lblM11.Text = "0";
            // 
            // lblM05
            // 
            this.lblM05.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM05.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblM05.Location = new System.Drawing.Point(116, 57);
            this.lblM05.Name = "lblM05";
            this.lblM05.Size = new System.Drawing.Size(93, 23);
            this.lblM05.TabIndex = 4;
            this.lblM05.Text = "0";
            // 
            // lblM10
            // 
            this.lblM10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblM10.Location = new System.Drawing.Point(227, 98);
            this.lblM10.Name = "lblM10";
            this.lblM10.Size = new System.Drawing.Size(96, 23);
            this.lblM10.TabIndex = 4;
            this.lblM10.Text = "0";
            // 
            // lblM06
            // 
            this.lblM06.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM06.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblM06.Location = new System.Drawing.Point(116, 98);
            this.lblM06.Name = "lblM06";
            this.lblM06.Size = new System.Drawing.Size(93, 23);
            this.lblM06.TabIndex = 4;
            this.lblM06.Text = "0";
            // 
            // lblM09
            // 
            this.lblM09.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM09.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblM09.Location = new System.Drawing.Point(227, 57);
            this.lblM09.Name = "lblM09";
            this.lblM09.Size = new System.Drawing.Size(96, 23);
            this.lblM09.TabIndex = 4;
            this.lblM09.Text = "0";
            // 
            // lblM07
            // 
            this.lblM07.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM07.Location = new System.Drawing.Point(116, 139);
            this.lblM07.Name = "lblM07";
            this.lblM07.Size = new System.Drawing.Size(93, 23);
            this.lblM07.TabIndex = 4;
            this.lblM07.Text = "0";
            // 
            // lblM08
            // 
            this.lblM08.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM08.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblM08.Location = new System.Drawing.Point(227, 16);
            this.lblM08.Name = "lblM08";
            this.lblM08.Size = new System.Drawing.Size(95, 23);
            this.lblM08.TabIndex = 4;
            this.lblM08.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.groupBoxRotation);
            this.groupBox3.Controls.Add(this.btnResetRotation);
            this.groupBox3.Controls.Add(this.cbxAnimate);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(456, 626);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AnT);
            this.groupBox4.Location = new System.Drawing.Point(474, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(611, 626);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 647);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenGL Rotation";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.groupBoxRotation.ResumeLayout(false);
            this.groupBoxRotation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarYawY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarPitchZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarRollX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        private System.Windows.Forms.CheckBox cbxAnimate;
        private System.Windows.Forms.Button btnSetZtoZero;
        private System.Windows.Forms.Button btnSetYtoZero;
        private System.Windows.Forms.Button btnSetXtoZero;
        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblM00;
        private System.Windows.Forms.Label lblM15;
        private System.Windows.Forms.Label lblM01;
        private System.Windows.Forms.Label lblM14;
        private System.Windows.Forms.Label lblM02;
        private System.Windows.Forms.Label lblM13;
        private System.Windows.Forms.Label lblM03;
        private System.Windows.Forms.Label lblM12;
        private System.Windows.Forms.Label lblM04;
        private System.Windows.Forms.Label lblM11;
        private System.Windows.Forms.Label lblM05;
        private System.Windows.Forms.Label lblM10;
        private System.Windows.Forms.Label lblM06;
        private System.Windows.Forms.Label lblM09;
        private System.Windows.Forms.Label lblM07;
        private System.Windows.Forms.Label lblM08;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
