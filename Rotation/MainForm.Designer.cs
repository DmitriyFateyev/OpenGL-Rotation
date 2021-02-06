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
		private System.Windows.Forms.SplitContainer splitContainer1;
		private Tao.Platform.Windows.SimpleOpenGlControl AnT;
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
		private System.Windows.Forms.GroupBox groupBoxTranslation;
		private System.Windows.Forms.Label lblZTranslation;
		private System.Windows.Forms.Label lblYTranslation;
		private System.Windows.Forms.Label lblXTranslation;
		private System.Windows.Forms.TrackBar trckBarZ;
		private System.Windows.Forms.TrackBar trckBarY;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblX;
		private System.Windows.Forms.TrackBar trckBarX;
		private System.Windows.Forms.Button btnResetTranslation;
		private System.Windows.Forms.Button btnResetRotation;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lblQuatZ;
		private System.Windows.Forms.Label lblQuatY;
		private System.Windows.Forms.Label lblQuatX;
		private System.Windows.Forms.Label lblQuatW;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelQuat;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Label lblM00;
		private System.Windows.Forms.Label lblM12;
		private System.Windows.Forms.Label lblM08;
		private System.Windows.Forms.Label lblM04;
		private System.Windows.Forms.Label lblM15;
		private System.Windows.Forms.Label lblM14;
		private System.Windows.Forms.Label lblM13;
		private System.Windows.Forms.Label lblM11;
		private System.Windows.Forms.Label lblM10;
		private System.Windows.Forms.Label lblM09;
		private System.Windows.Forms.Label lblM07;
		private System.Windows.Forms.Label lblM06;
		private System.Windows.Forms.Label lblM05;
		private System.Windows.Forms.Label lblM03;
		private System.Windows.Forms.Label lblM02;
		private System.Windows.Forms.Label lblM01;
		private System.Windows.Forms.GroupBox groupBox1;
		
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbxAnimate = new System.Windows.Forms.CheckBox();
            this.btnResetTranslation = new System.Windows.Forms.Button();
            this.btnResetRotation = new System.Windows.Forms.Button();
            this.groupBoxTranslation = new System.Windows.Forms.GroupBox();
            this.lblZTranslation = new System.Windows.Forms.Label();
            this.lblYTranslation = new System.Windows.Forms.Label();
            this.lblXTranslation = new System.Windows.Forms.Label();
            this.trckBarZ = new System.Windows.Forms.TrackBar();
            this.trckBarY = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.trckBarX = new System.Windows.Forms.TrackBar();
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tbX = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbE2RM0 = new System.Windows.Forms.Label();
            this.lbE2RM15 = new System.Windows.Forms.Label();
            this.lbE2RM1 = new System.Windows.Forms.Label();
            this.lbE2RM14 = new System.Windows.Forms.Label();
            this.lbE2RM2 = new System.Windows.Forms.Label();
            this.lbE2RM13 = new System.Windows.Forms.Label();
            this.lbE2RM3 = new System.Windows.Forms.Label();
            this.lbE2RM12 = new System.Windows.Forms.Label();
            this.lbE2RM4 = new System.Windows.Forms.Label();
            this.lbE2RM11 = new System.Windows.Forms.Label();
            this.lbE2RM5 = new System.Windows.Forms.Label();
            this.lbE2RM10 = new System.Windows.Forms.Label();
            this.lbE2RM6 = new System.Windows.Forms.Label();
            this.lbE2RM9 = new System.Windows.Forms.Label();
            this.lbE2RM7 = new System.Windows.Forms.Label();
            this.lbE2RM8 = new System.Windows.Forms.Label();
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
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuatZ = new System.Windows.Forms.Label();
            this.labelQuat = new System.Windows.Forms.Label();
            this.lblQuatY = new System.Windows.Forms.Label();
            this.lblQuatX = new System.Windows.Forms.Label();
            this.lblQuatW = new System.Windows.Forms.Label();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxTranslation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarX)).BeginInit();
            this.groupBoxRotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarYawY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarPitchZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarRollX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbxAnimate);
            this.splitContainer1.Panel1.Controls.Add(this.btnResetTranslation);
            this.splitContainer1.Panel1.Controls.Add(this.btnResetRotation);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxTranslation);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxRotation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(984, 881);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbxAnimate
            // 
            this.cbxAnimate.AutoSize = true;
            this.cbxAnimate.Location = new System.Drawing.Point(453, 82);
            this.cbxAnimate.Name = "cbxAnimate";
            this.cbxAnimate.Size = new System.Drawing.Size(64, 17);
            this.cbxAnimate.TabIndex = 2;
            this.cbxAnimate.Text = "Animate";
            this.cbxAnimate.UseVisualStyleBackColor = true;
            // 
            // btnResetTranslation
            // 
            this.btnResetTranslation.Location = new System.Drawing.Point(453, 127);
            this.btnResetTranslation.Name = "btnResetTranslation";
            this.btnResetTranslation.Size = new System.Drawing.Size(91, 45);
            this.btnResetTranslation.TabIndex = 1;
            this.btnResetTranslation.Text = "Reset translation";
            this.btnResetTranslation.UseVisualStyleBackColor = true;
            this.btnResetTranslation.Click += new System.EventHandler(this.BtnResetTranslationClick);
            // 
            // btnResetRotation
            // 
            this.btnResetRotation.Location = new System.Drawing.Point(453, 14);
            this.btnResetRotation.Name = "btnResetRotation";
            this.btnResetRotation.Size = new System.Drawing.Size(91, 46);
            this.btnResetRotation.TabIndex = 1;
            this.btnResetRotation.Text = "Reset rotation";
            this.btnResetRotation.UseVisualStyleBackColor = true;
            this.btnResetRotation.Click += new System.EventHandler(this.BtnResetRotationClick);
            // 
            // groupBoxTranslation
            // 
            this.groupBoxTranslation.Controls.Add(this.lblZTranslation);
            this.groupBoxTranslation.Controls.Add(this.lblYTranslation);
            this.groupBoxTranslation.Controls.Add(this.lblXTranslation);
            this.groupBoxTranslation.Controls.Add(this.trckBarZ);
            this.groupBoxTranslation.Controls.Add(this.trckBarY);
            this.groupBoxTranslation.Controls.Add(this.label4);
            this.groupBoxTranslation.Controls.Add(this.label5);
            this.groupBoxTranslation.Controls.Add(this.lblX);
            this.groupBoxTranslation.Controls.Add(this.trckBarX);
            this.groupBoxTranslation.Location = new System.Drawing.Point(550, 12);
            this.groupBoxTranslation.Name = "groupBoxTranslation";
            this.groupBoxTranslation.Size = new System.Drawing.Size(423, 160);
            this.groupBoxTranslation.TabIndex = 0;
            this.groupBoxTranslation.TabStop = false;
            this.groupBoxTranslation.Text = "Translation";
            // 
            // lblZTranslation
            // 
            this.lblZTranslation.Location = new System.Drawing.Point(363, 112);
            this.lblZTranslation.Name = "lblZTranslation";
            this.lblZTranslation.Size = new System.Drawing.Size(39, 23);
            this.lblZTranslation.TabIndex = 8;
            this.lblZTranslation.Text = "-200";
            // 
            // lblYTranslation
            // 
            this.lblYTranslation.Location = new System.Drawing.Point(363, 64);
            this.lblYTranslation.Name = "lblYTranslation";
            this.lblYTranslation.Size = new System.Drawing.Size(39, 23);
            this.lblYTranslation.TabIndex = 7;
            this.lblYTranslation.Text = "0";
            // 
            // lblXTranslation
            // 
            this.lblXTranslation.Location = new System.Drawing.Point(363, 19);
            this.lblXTranslation.Name = "lblXTranslation";
            this.lblXTranslation.Size = new System.Drawing.Size(39, 23);
            this.lblXTranslation.TabIndex = 6;
            this.lblXTranslation.Text = "0";
            // 
            // trckBarZ
            // 
            this.trckBarZ.Location = new System.Drawing.Point(48, 109);
            this.trckBarZ.Maximum = 100;
            this.trckBarZ.Name = "trckBarZ";
            this.trckBarZ.Size = new System.Drawing.Size(309, 45);
            this.trckBarZ.TabIndex = 5;
            this.trckBarZ.TickFrequency = 10;
            this.trckBarZ.Scroll += new System.EventHandler(this.TrckBarZScroll);
            // 
            // trckBarY
            // 
            this.trckBarY.Location = new System.Drawing.Point(48, 64);
            this.trckBarY.Maximum = 100;
            this.trckBarY.Name = "trckBarY";
            this.trckBarY.Size = new System.Drawing.Size(309, 45);
            this.trckBarY.TabIndex = 4;
            this.trckBarY.TickFrequency = 10;
            this.trckBarY.Scroll += new System.EventHandler(this.TrckBarYScroll);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Z";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.Location = new System.Drawing.Point(7, 19);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(35, 23);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "X";
            // 
            // trckBarX
            // 
            this.trckBarX.Location = new System.Drawing.Point(48, 19);
            this.trckBarX.Maximum = 100;
            this.trckBarX.Name = "trckBarX";
            this.trckBarX.Size = new System.Drawing.Size(309, 45);
            this.trckBarX.TabIndex = 0;
            this.trckBarX.TickFrequency = 10;
            this.trckBarX.Scroll += new System.EventHandler(this.TrckBarXScroll);
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
            this.groupBoxRotation.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRotation.Name = "groupBoxRotation";
            this.groupBoxRotation.Size = new System.Drawing.Size(435, 160);
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
            this.trckBarYawY.Scroll += new System.EventHandler(this.TrckBarYawScroll);
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
            this.trckBarPitchZ.Scroll += new System.EventHandler(this.TrckBarPitchScroll);
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
            this.trckBarRollX.Scroll += new System.EventHandler(this.TrckBarRollScroll);
            this.trckBarRollX.ValueChanged += new System.EventHandler(this.trckBarRollX_ValueChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tbX);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.lblQuatZ);
            this.splitContainer2.Panel1.Controls.Add(this.labelQuat);
            this.splitContainer2.Panel1.Controls.Add(this.lblQuatY);
            this.splitContainer2.Panel1.Controls.Add(this.lblQuatX);
            this.splitContainer2.Panel1.Controls.Add(this.lblQuatW);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.AnT);
            this.splitContainer2.Size = new System.Drawing.Size(984, 705);
            this.splitContainer2.SplitterDistance = 266;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 1;
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(68, 10);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(48, 20);
            this.tbX.TabIndex = 6;
            this.tbX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbX_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbE2RM0);
            this.groupBox2.Controls.Add(this.lbE2RM15);
            this.groupBox2.Controls.Add(this.lbE2RM1);
            this.groupBox2.Controls.Add(this.lbE2RM14);
            this.groupBox2.Controls.Add(this.lbE2RM2);
            this.groupBox2.Controls.Add(this.lbE2RM13);
            this.groupBox2.Controls.Add(this.lbE2RM3);
            this.groupBox2.Controls.Add(this.lbE2RM12);
            this.groupBox2.Controls.Add(this.lbE2RM4);
            this.groupBox2.Controls.Add(this.lbE2RM11);
            this.groupBox2.Controls.Add(this.lbE2RM5);
            this.groupBox2.Controls.Add(this.lbE2RM10);
            this.groupBox2.Controls.Add(this.lbE2RM6);
            this.groupBox2.Controls.Add(this.lbE2RM9);
            this.groupBox2.Controls.Add(this.lbE2RM7);
            this.groupBox2.Controls.Add(this.lbE2RM8);
            this.groupBox2.Location = new System.Drawing.Point(3, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 110);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "euler2RM";
            // 
            // lbE2RM0
            // 
            this.lbE2RM0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM0.Location = new System.Drawing.Point(11, 16);
            this.lbE2RM0.Name = "lbE2RM0";
            this.lbE2RM0.Size = new System.Drawing.Size(56, 23);
            this.lbE2RM0.TabIndex = 4;
            this.lbE2RM0.Text = "0";
            // 
            // lbE2RM15
            // 
            this.lbE2RM15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM15.Location = new System.Drawing.Point(202, 85);
            this.lbE2RM15.Name = "lbE2RM15";
            this.lbE2RM15.Size = new System.Drawing.Size(47, 23);
            this.lbE2RM15.TabIndex = 4;
            this.lbE2RM15.Text = "0";
            // 
            // lbE2RM1
            // 
            this.lbE2RM1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM1.Location = new System.Drawing.Point(10, 39);
            this.lbE2RM1.Name = "lbE2RM1";
            this.lbE2RM1.Size = new System.Drawing.Size(57, 23);
            this.lbE2RM1.TabIndex = 4;
            this.lbE2RM1.Text = "0";
            // 
            // lbE2RM14
            // 
            this.lbE2RM14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM14.Location = new System.Drawing.Point(202, 62);
            this.lbE2RM14.Name = "lbE2RM14";
            this.lbE2RM14.Size = new System.Drawing.Size(47, 23);
            this.lbE2RM14.TabIndex = 4;
            this.lbE2RM14.Text = "0";
            // 
            // lbE2RM2
            // 
            this.lbE2RM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM2.Location = new System.Drawing.Point(10, 62);
            this.lbE2RM2.Name = "lbE2RM2";
            this.lbE2RM2.Size = new System.Drawing.Size(57, 23);
            this.lbE2RM2.TabIndex = 4;
            this.lbE2RM2.Text = "0";
            // 
            // lbE2RM13
            // 
            this.lbE2RM13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM13.Location = new System.Drawing.Point(202, 39);
            this.lbE2RM13.Name = "lbE2RM13";
            this.lbE2RM13.Size = new System.Drawing.Size(47, 23);
            this.lbE2RM13.TabIndex = 4;
            this.lbE2RM13.Text = "0";
            // 
            // lbE2RM3
            // 
            this.lbE2RM3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM3.Location = new System.Drawing.Point(10, 85);
            this.lbE2RM3.Name = "lbE2RM3";
            this.lbE2RM3.Size = new System.Drawing.Size(57, 23);
            this.lbE2RM3.TabIndex = 4;
            this.lbE2RM3.Text = "0";
            // 
            // lbE2RM12
            // 
            this.lbE2RM12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM12.Location = new System.Drawing.Point(202, 16);
            this.lbE2RM12.Name = "lbE2RM12";
            this.lbE2RM12.Size = new System.Drawing.Size(47, 23);
            this.lbE2RM12.TabIndex = 4;
            this.lbE2RM12.Text = "0";
            // 
            // lbE2RM4
            // 
            this.lbE2RM4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM4.Location = new System.Drawing.Point(74, 16);
            this.lbE2RM4.Name = "lbE2RM4";
            this.lbE2RM4.Size = new System.Drawing.Size(55, 23);
            this.lbE2RM4.TabIndex = 4;
            this.lbE2RM4.Text = "0";
            // 
            // lbE2RM11
            // 
            this.lbE2RM11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM11.Location = new System.Drawing.Point(134, 85);
            this.lbE2RM11.Name = "lbE2RM11";
            this.lbE2RM11.Size = new System.Drawing.Size(59, 23);
            this.lbE2RM11.TabIndex = 4;
            this.lbE2RM11.Text = "0";
            // 
            // lbE2RM5
            // 
            this.lbE2RM5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM5.Location = new System.Drawing.Point(73, 39);
            this.lbE2RM5.Name = "lbE2RM5";
            this.lbE2RM5.Size = new System.Drawing.Size(56, 23);
            this.lbE2RM5.TabIndex = 4;
            this.lbE2RM5.Text = "0";
            // 
            // lbE2RM10
            // 
            this.lbE2RM10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM10.Location = new System.Drawing.Point(134, 62);
            this.lbE2RM10.Name = "lbE2RM10";
            this.lbE2RM10.Size = new System.Drawing.Size(59, 23);
            this.lbE2RM10.TabIndex = 4;
            this.lbE2RM10.Text = "0";
            // 
            // lbE2RM6
            // 
            this.lbE2RM6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM6.Location = new System.Drawing.Point(73, 62);
            this.lbE2RM6.Name = "lbE2RM6";
            this.lbE2RM6.Size = new System.Drawing.Size(56, 23);
            this.lbE2RM6.TabIndex = 4;
            this.lbE2RM6.Text = "0";
            // 
            // lbE2RM9
            // 
            this.lbE2RM9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM9.Location = new System.Drawing.Point(134, 39);
            this.lbE2RM9.Name = "lbE2RM9";
            this.lbE2RM9.Size = new System.Drawing.Size(59, 23);
            this.lbE2RM9.TabIndex = 4;
            this.lbE2RM9.Text = "0";
            // 
            // lbE2RM7
            // 
            this.lbE2RM7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM7.Location = new System.Drawing.Point(73, 85);
            this.lbE2RM7.Name = "lbE2RM7";
            this.lbE2RM7.Size = new System.Drawing.Size(56, 23);
            this.lbE2RM7.TabIndex = 4;
            this.lbE2RM7.Text = "0";
            // 
            // lbE2RM8
            // 
            this.lbE2RM8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbE2RM8.Location = new System.Drawing.Point(135, 16);
            this.lbE2RM8.Name = "lbE2RM8";
            this.lbE2RM8.Size = new System.Drawing.Size(58, 23);
            this.lbE2RM8.TabIndex = 4;
            this.lbE2RM8.Text = "0";
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
            this.groupBox1.Location = new System.Drawing.Point(3, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 110);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ModelView Matrix";
            // 
            // lblM00
            // 
            this.lblM00.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM00.Location = new System.Drawing.Point(11, 16);
            this.lblM00.Name = "lblM00";
            this.lblM00.Size = new System.Drawing.Size(56, 23);
            this.lblM00.TabIndex = 4;
            this.lblM00.Text = "0";
            // 
            // lblM15
            // 
            this.lblM15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM15.Location = new System.Drawing.Point(202, 85);
            this.lblM15.Name = "lblM15";
            this.lblM15.Size = new System.Drawing.Size(47, 23);
            this.lblM15.TabIndex = 4;
            this.lblM15.Text = "0";
            // 
            // lblM01
            // 
            this.lblM01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM01.Location = new System.Drawing.Point(10, 39);
            this.lblM01.Name = "lblM01";
            this.lblM01.Size = new System.Drawing.Size(57, 23);
            this.lblM01.TabIndex = 4;
            this.lblM01.Text = "0";
            // 
            // lblM14
            // 
            this.lblM14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM14.Location = new System.Drawing.Point(202, 62);
            this.lblM14.Name = "lblM14";
            this.lblM14.Size = new System.Drawing.Size(47, 23);
            this.lblM14.TabIndex = 4;
            this.lblM14.Text = "0";
            // 
            // lblM02
            // 
            this.lblM02.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM02.Location = new System.Drawing.Point(10, 62);
            this.lblM02.Name = "lblM02";
            this.lblM02.Size = new System.Drawing.Size(57, 23);
            this.lblM02.TabIndex = 4;
            this.lblM02.Text = "0";
            // 
            // lblM13
            // 
            this.lblM13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM13.Location = new System.Drawing.Point(202, 39);
            this.lblM13.Name = "lblM13";
            this.lblM13.Size = new System.Drawing.Size(47, 23);
            this.lblM13.TabIndex = 4;
            this.lblM13.Text = "0";
            // 
            // lblM03
            // 
            this.lblM03.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM03.Location = new System.Drawing.Point(10, 85);
            this.lblM03.Name = "lblM03";
            this.lblM03.Size = new System.Drawing.Size(57, 23);
            this.lblM03.TabIndex = 4;
            this.lblM03.Text = "0";
            // 
            // lblM12
            // 
            this.lblM12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM12.Location = new System.Drawing.Point(202, 16);
            this.lblM12.Name = "lblM12";
            this.lblM12.Size = new System.Drawing.Size(47, 23);
            this.lblM12.TabIndex = 4;
            this.lblM12.Text = "0";
            // 
            // lblM04
            // 
            this.lblM04.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM04.Location = new System.Drawing.Point(74, 16);
            this.lblM04.Name = "lblM04";
            this.lblM04.Size = new System.Drawing.Size(55, 23);
            this.lblM04.TabIndex = 4;
            this.lblM04.Text = "0";
            // 
            // lblM11
            // 
            this.lblM11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM11.Location = new System.Drawing.Point(134, 85);
            this.lblM11.Name = "lblM11";
            this.lblM11.Size = new System.Drawing.Size(59, 23);
            this.lblM11.TabIndex = 4;
            this.lblM11.Text = "0";
            // 
            // lblM05
            // 
            this.lblM05.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM05.Location = new System.Drawing.Point(73, 39);
            this.lblM05.Name = "lblM05";
            this.lblM05.Size = new System.Drawing.Size(56, 23);
            this.lblM05.TabIndex = 4;
            this.lblM05.Text = "0";
            // 
            // lblM10
            // 
            this.lblM10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM10.Location = new System.Drawing.Point(134, 62);
            this.lblM10.Name = "lblM10";
            this.lblM10.Size = new System.Drawing.Size(59, 23);
            this.lblM10.TabIndex = 4;
            this.lblM10.Text = "0";
            // 
            // lblM06
            // 
            this.lblM06.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM06.Location = new System.Drawing.Point(73, 62);
            this.lblM06.Name = "lblM06";
            this.lblM06.Size = new System.Drawing.Size(56, 23);
            this.lblM06.TabIndex = 4;
            this.lblM06.Text = "0";
            // 
            // lblM09
            // 
            this.lblM09.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM09.Location = new System.Drawing.Point(134, 39);
            this.lblM09.Name = "lblM09";
            this.lblM09.Size = new System.Drawing.Size(59, 23);
            this.lblM09.TabIndex = 4;
            this.lblM09.Text = "0";
            // 
            // lblM07
            // 
            this.lblM07.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM07.Location = new System.Drawing.Point(73, 85);
            this.lblM07.Name = "lblM07";
            this.lblM07.Size = new System.Drawing.Size(56, 23);
            this.lblM07.TabIndex = 4;
            this.lblM07.Text = "0";
            // 
            // lblM08
            // 
            this.lblM08.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblM08.Location = new System.Drawing.Point(135, 16);
            this.lblM08.Name = "lblM08";
            this.lblM08.Size = new System.Drawing.Size(58, 23);
            this.lblM08.TabIndex = 4;
            this.lblM08.Text = "0";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Z:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "X:";
            // 
            // lblQuatZ
            // 
            this.lblQuatZ.Location = new System.Drawing.Point(33, 54);
            this.lblQuatZ.Name = "lblQuatZ";
            this.lblQuatZ.Size = new System.Drawing.Size(29, 23);
            this.lblQuatZ.TabIndex = 3;
            this.lblQuatZ.Text = "0";
            // 
            // labelQuat
            // 
            this.labelQuat.Location = new System.Drawing.Point(12, 10);
            this.labelQuat.Name = "labelQuat";
            this.labelQuat.Size = new System.Drawing.Size(24, 23);
            this.labelQuat.TabIndex = 2;
            this.labelQuat.Text = "W:";
            // 
            // lblQuatY
            // 
            this.lblQuatY.Location = new System.Drawing.Point(33, 40);
            this.lblQuatY.Name = "lblQuatY";
            this.lblQuatY.Size = new System.Drawing.Size(29, 23);
            this.lblQuatY.TabIndex = 3;
            this.lblQuatY.Text = "0";
            // 
            // lblQuatX
            // 
            this.lblQuatX.Location = new System.Drawing.Point(33, 25);
            this.lblQuatX.Name = "lblQuatX";
            this.lblQuatX.Size = new System.Drawing.Size(29, 23);
            this.lblQuatX.TabIndex = 3;
            this.lblQuatX.Text = "0";
            // 
            // lblQuatW
            // 
            this.lblQuatW.Location = new System.Drawing.Point(33, 10);
            this.lblQuatW.Name = "lblQuatW";
            this.lblQuatW.Size = new System.Drawing.Size(29, 23);
            this.lblQuatW.TabIndex = 3;
            this.lblQuatW.Text = "1";
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(3, 3);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(700, 700);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 881);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rotation";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxTranslation.ResumeLayout(false);
            this.groupBoxTranslation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarX)).EndInit();
            this.groupBoxRotation.ResumeLayout(false);
            this.groupBoxRotation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarYawY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarPitchZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarRollX)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbE2RM0;
        private System.Windows.Forms.Label lbE2RM15;
        private System.Windows.Forms.Label lbE2RM1;
        private System.Windows.Forms.Label lbE2RM14;
        private System.Windows.Forms.Label lbE2RM2;
        private System.Windows.Forms.Label lbE2RM13;
        private System.Windows.Forms.Label lbE2RM3;
        private System.Windows.Forms.Label lbE2RM12;
        private System.Windows.Forms.Label lbE2RM4;
        private System.Windows.Forms.Label lbE2RM11;
        private System.Windows.Forms.Label lbE2RM5;
        private System.Windows.Forms.Label lbE2RM10;
        private System.Windows.Forms.Label lbE2RM6;
        private System.Windows.Forms.Label lbE2RM9;
        private System.Windows.Forms.Label lbE2RM7;
        private System.Windows.Forms.Label lbE2RM8;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.CheckBox cbxAnimate;
        private System.Windows.Forms.Button btnSetZtoZero;
        private System.Windows.Forms.Button btnSetYtoZero;
        private System.Windows.Forms.Button btnSetXtoZero;
    }
}
