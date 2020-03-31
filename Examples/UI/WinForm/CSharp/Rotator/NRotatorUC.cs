using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NRotatorUC.
	/// </summary>
	public class NRotatorUC : NExampleUserControl
	{
		#region Constructor

		public NRotatorUC()
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		public override void Initialize()
		{
			base.Initialize ();

			directionCombo.FillFromEnum(typeof(RotatorDirection));
			directionCombo.SelectedItem = nRotator1.Direction;

			frameDurationNumeric.Value = 3000;
			animationIntervalNumeric.Value = 50;
			animationStepsNumeric.Value = 10;

			nRotatorFrame3.Content.HyperLinkClick += new Nevron.UI.NHyperLinkEventHandler(Content_HyperLinkClick);

			startBtn_Click(null, null);
		}


		#endregion

		#region Event Handlers

		private void directionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			nRotator1.Direction = (RotatorDirection)directionCombo.SelectedItem;
		}
		private void frameDurationNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			nRotator1.FrameVisibilityDuration = (int)frameDurationNumeric.Value;
		}
		private void animationIntervalNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			nRotator1.FrameAnimationInterval = (int)animationIntervalNumeric.Value;
		}
		private void animationStepsNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			nRotator1.FrameAnimationSteps = (int)animationStepsNumeric.Value;
		}
		private void Content_HyperLinkClick(object sender, Nevron.UI.NHyperLinkEventArgs e)
		{
			Process.Start(e.Url);
		}

		private void startBtn_Click(object sender, System.EventArgs e)
		{
			nRotator1.Start();
			stopBtn.Enabled = true;
			startBtn.Enabled = false;
		}
		private void stopBtn_Click(object sender, System.EventArgs e)
		{
			nRotator1.Stop();
			stopBtn.Enabled = false;
			startBtn.Enabled = true;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NRotatorUC));
			this.nRotator1 = new Nevron.UI.WinForm.Controls.NRotator();
			this.nRotatorFrame1 = new Nevron.UI.WinForm.Controls.NRotatorFrame();
			this.nRotatorFrame2 = new Nevron.UI.WinForm.Controls.NRotatorFrame();
			this.nRotatorFrame3 = new Nevron.UI.WinForm.Controls.NRotatorFrame();
			this.label1 = new System.Windows.Forms.Label();
			this.directionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.frameDurationNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.animationIntervalNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.animationStepsNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.startBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.stopBtn = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.nRotator1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.frameDurationNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.animationIntervalNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.animationStepsNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// nRotator1
			// 
			this.nRotator1.ClientPadding = new Nevron.UI.NPadding(10);
			this.nRotator1.Frames.AddRange(new Nevron.UI.WinForm.Controls.NRotatorFrame[] {
																							  this.nRotatorFrame1,
																							  this.nRotatorFrame2,
																							  this.nRotatorFrame3});
			this.nRotator1.Location = new System.Drawing.Point(8, 8);
			this.nRotator1.Name = "nRotator1";
			this.nRotator1.Size = new System.Drawing.Size(304, 328);
			this.nRotator1.TabIndex = 0;
			this.nRotator1.Text = "nRotator1";
			// 
			// nRotatorFrame1
			// 
			this.nRotatorFrame1.Content.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRotatorFrame1.Content.Image = ((System.Drawing.Image)(resources.GetObject("nRotatorFrame1.Content.Image")));
			this.nRotatorFrame1.Content.ImageSize = new Nevron.GraphicsCore.NSize(256, 256);
			this.nRotatorFrame1.Content.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nRotatorFrame1.Content.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Bold);
			this.nRotatorFrame1.Content.Style.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.nRotatorFrame1.Content.Text = "Rotator Frame displaying large image";
			// 
			// nRotatorFrame2
			// 
			this.nRotatorFrame2.Content.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRotatorFrame2.Content.Style.Background = new Nevron.UI.NImageShape(System.Drawing.Drawing2D.SmoothingMode.Default, new Nevron.GraphicsCore.NSize(0, 0), new Nevron.UI.NPadding(0, 0, 0, 0), null, ((System.Drawing.Bitmap)(resources.GetObject("resource"))), null, -1, Nevron.UI.ImageSizeMode.Stretch, true, Nevron.UI.ImageSegment.All, new Nevron.UI.NPadding(5));
			this.nRotatorFrame2.Content.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Arial Narrow", 20F, Nevron.GraphicsCore.FontStyleEx.Regular);
			this.nRotatorFrame2.Content.Style.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.nRotatorFrame2.Content.Text = "Rotator Frame with custom background specified";
			// 
			// nRotatorFrame3
			// 
			this.nRotatorFrame3.Content.Text = "Rotator Frame with hyper-link. Click <a href=\'http://www.nevron.com\'>here</a> to " +
				"visit our web site.";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(320, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Direction:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// directionCombo
			// 
			this.directionCombo.Location = new System.Drawing.Point(320, 40);
			this.directionCombo.Name = "directionCombo";
			this.directionCombo.Size = new System.Drawing.Size(168, 22);
			this.directionCombo.TabIndex = 2;
			this.directionCombo.Text = "nComboBox1";
			this.directionCombo.SelectedIndexChanged += new System.EventHandler(this.directionCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(320, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Frame Duration:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frameDurationNumeric
			// 
			this.frameDurationNumeric.Location = new System.Drawing.Point(320, 96);
			this.frameDurationNumeric.Maximum = new System.Decimal(new int[] {
																				 5000,
																				 0,
																				 0,
																				 0});
			this.frameDurationNumeric.Minimum = new System.Decimal(new int[] {
																				 100,
																				 0,
																				 0,
																				 0});
			this.frameDurationNumeric.Name = "frameDurationNumeric";
			this.frameDurationNumeric.Size = new System.Drawing.Size(88, 20);
			this.frameDurationNumeric.TabIndex = 4;
			this.frameDurationNumeric.Value = new System.Decimal(new int[] {
																			   3000,
																			   0,
																			   0,
																			   0});
			this.frameDurationNumeric.ValueChanged += new System.EventHandler(this.frameDurationNumeric_ValueChanged);
			// 
			// animationIntervalNumeric
			// 
			this.animationIntervalNumeric.Location = new System.Drawing.Point(320, 152);
			this.animationIntervalNumeric.Maximum = new System.Decimal(new int[] {
																					 500,
																					 0,
																					 0,
																					 0});
			this.animationIntervalNumeric.Minimum = new System.Decimal(new int[] {
																					 10,
																					 0,
																					 0,
																					 0});
			this.animationIntervalNumeric.Name = "animationIntervalNumeric";
			this.animationIntervalNumeric.Size = new System.Drawing.Size(88, 20);
			this.animationIntervalNumeric.TabIndex = 6;
			this.animationIntervalNumeric.Value = new System.Decimal(new int[] {
																				   10,
																				   0,
																				   0,
																				   0});
			this.animationIntervalNumeric.ValueChanged += new System.EventHandler(this.animationIntervalNumeric_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(320, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Animation Interval:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// animationStepsNumeric
			// 
			this.animationStepsNumeric.Location = new System.Drawing.Point(320, 208);
			this.animationStepsNumeric.Maximum = new System.Decimal(new int[] {
																				  50,
																				  0,
																				  0,
																				  0});
			this.animationStepsNumeric.Minimum = new System.Decimal(new int[] {
																				  1,
																				  0,
																				  0,
																				  0});
			this.animationStepsNumeric.Name = "animationStepsNumeric";
			this.animationStepsNumeric.Size = new System.Drawing.Size(88, 20);
			this.animationStepsNumeric.TabIndex = 8;
			this.animationStepsNumeric.Value = new System.Decimal(new int[] {
																				1,
																				0,
																				0,
																				0});
			this.animationStepsNumeric.ValueChanged += new System.EventHandler(this.animationStepsNumeric_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(320, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Animation Steps:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// startBtn
			// 
			this.startBtn.Location = new System.Drawing.Point(8, 344);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(144, 32);
			this.startBtn.TabIndex = 9;
			this.startBtn.Text = "Start";
			this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
			// 
			// stopBtn
			// 
			this.stopBtn.Location = new System.Drawing.Point(160, 344);
			this.stopBtn.Name = "stopBtn";
			this.stopBtn.Size = new System.Drawing.Size(144, 32);
			this.stopBtn.TabIndex = 10;
			this.stopBtn.Text = "Stop";
			this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
			// 
			// NRotatorUC
			// 
			this.Controls.Add(this.stopBtn);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(this.animationStepsNumeric);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.animationIntervalNumeric);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.frameDurationNumeric);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.directionCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nRotator1);
			this.Name = "NRotatorUC";
			this.Size = new System.Drawing.Size(496, 392);
			((System.ComponentModel.ISupportInitialize)(this.nRotator1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.frameDurationNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.animationIntervalNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.animationStepsNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox directionCombo;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown frameDurationNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown animationIntervalNumeric;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown animationStepsNumeric;
		private Nevron.UI.WinForm.Controls.NRotatorFrame nRotatorFrame1;
		private Nevron.UI.WinForm.Controls.NRotatorFrame nRotatorFrame2;
		private Nevron.UI.WinForm.Controls.NRotatorFrame nRotatorFrame3;
		private Nevron.UI.WinForm.Controls.NButton startBtn;
		private Nevron.UI.WinForm.Controls.NButton stopBtn;
		private Nevron.UI.WinForm.Controls.NRotator nRotator1;

		#endregion
	}
}
