using System;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NAnimationSurfaceUC.
	/// </summary>
	public class NAnimationSurfaceUC : NExampleUserControl
	{
		#region Constructor

		public NAnimationSurfaceUC(MainForm f) : base(f)
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

			this.nAnimationSurface1.AnimationInfo.Steps = 20;
			this.nAnimationSurface1.AnimationInfo.Interval = 20;
		}


		#endregion

		#region Event Handlers

		private void m_FadeCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nAnimationSurface1.AnimationInfo.Fade = m_FadeCheck.Checked;
		}
		private void m_SlideCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nAnimationSurface1.AnimationInfo.Slide = m_SlideCheck.Checked;
		}
		private void m_ScrollCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nAnimationSurface1.AnimationInfo.Scroll = m_ScrollCheck.Checked;
		}
		private void m_HideCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nAnimationSurface1.AnimationInfo.Hide = m_HideCheck.Checked;
		}
		private void m_StepsNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			this.nAnimationSurface1.AnimationInfo.Steps = (int)m_StepsNumeric.Value;
		}
		private void m_IntervalNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			this.nAnimationSurface1.AnimationInfo.Interval = (int)m_IntervalNumeric.Value;
		}
		private void nButton1_Click(object sender, System.EventArgs e)
		{
			NImageAnimator.Instance.Animate(this.nAnimationSurface1);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NAnimationSurfaceUC));
			this.nAnimationSurface1 = new Nevron.UI.WinForm.Controls.NAnimationSurface();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.m_FadeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_SlideCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_IntervalNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.m_StepsNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.m_HideCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_ScrollCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_IntervalNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_StepsNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// nAnimationSurface1
			// 
			this.nAnimationSurface1.AnimationInfo.Fade = true;
			this.nAnimationSurface1.AnimationInfo.Hide = false;
			this.nAnimationSurface1.AnimationInfo.Scroll = false;
			this.nAnimationSurface1.AnimationInfo.Slide = false;
			this.nAnimationSurface1.Image.Image = ((System.Drawing.Image)(resources.GetObject("nAnimationSurface1.Image.Image")));
			this.nAnimationSurface1.Image.Margins = new NPadding(5, 5, 5, 5);
			this.nAnimationSurface1.Location = new System.Drawing.Point(8, 8);
			this.nAnimationSurface1.Name = "nAnimationSurface1";
			this.nAnimationSurface1.Size = new System.Drawing.Size(256, 280);
			this.nAnimationSurface1.TabIndex = 0;
			this.nAnimationSurface1.Text = "nAnimationSurface1";
			// 
			// nButton1
			// 
			this.nButton1.Location = new System.Drawing.Point(392, 264);
			this.nButton1.Name = "nButton1";
			this.nButton1.Size = new System.Drawing.Size(80, 24);
			this.nButton1.TabIndex = 1;
			this.nButton1.Text = "Animate";
			this.nButton1.Click += new System.EventHandler(this.nButton1_Click);
			// 
			// m_FadeCheck
			// 
			this.m_FadeCheck.Checked = true;
			this.m_FadeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_FadeCheck.Location = new System.Drawing.Point(64, 72);
			this.m_FadeCheck.Name = "m_FadeCheck";
			this.m_FadeCheck.TabIndex = 2;
			this.m_FadeCheck.Text = "Fade";
			this.m_FadeCheck.CheckedChanged += new System.EventHandler(this.m_FadeCheck_CheckedChanged);
			// 
			// m_SlideCheck
			// 
			this.m_SlideCheck.Location = new System.Drawing.Point(64, 96);
			this.m_SlideCheck.Name = "m_SlideCheck";
			this.m_SlideCheck.TabIndex = 3;
			this.m_SlideCheck.Text = "Slide";
			this.m_SlideCheck.CheckedChanged += new System.EventHandler(this.m_SlideCheck_CheckedChanged);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Controls.Add(this.m_IntervalNumeric);
			this.nGroupBox1.Controls.Add(this.label1);
			this.nGroupBox1.Controls.Add(this.m_StepsNumeric);
			this.nGroupBox1.Controls.Add(this.m_HideCheck);
			this.nGroupBox1.Controls.Add(this.m_ScrollCheck);
			this.nGroupBox1.Controls.Add(this.m_FadeCheck);
			this.nGroupBox1.Controls.Add(this.m_SlideCheck);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(272, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(200, 176);
			this.nGroupBox1.TabIndex = 4;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Options";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Interval:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_IntervalNumeric
			// 
			this.m_IntervalNumeric.Location = new System.Drawing.Point(64, 48);
			this.m_IntervalNumeric.Maximum = new System.Decimal(new int[] {
																			  1000,
																			  0,
																			  0,
																			  0});
			this.m_IntervalNumeric.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
			this.m_IntervalNumeric.Name = "m_IntervalNumeric";
			this.m_IntervalNumeric.Size = new System.Drawing.Size(56, 20);
			this.m_IntervalNumeric.TabIndex = 8;
			this.m_IntervalNumeric.Value = new System.Decimal(new int[] {
																			20,
																			0,
																			0,
																			0});
			this.m_IntervalNumeric.ValueChanged += new System.EventHandler(this.m_IntervalNumeric_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Steps:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_StepsNumeric
			// 
			this.m_StepsNumeric.Location = new System.Drawing.Point(64, 24);
			this.m_StepsNumeric.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.m_StepsNumeric.Name = "m_StepsNumeric";
			this.m_StepsNumeric.Size = new System.Drawing.Size(56, 20);
			this.m_StepsNumeric.TabIndex = 6;
			this.m_StepsNumeric.Value = new System.Decimal(new int[] {
																		 20,
																		 0,
																		 0,
																		 0});
			this.m_StepsNumeric.ValueChanged += new System.EventHandler(this.m_StepsNumeric_ValueChanged);
			// 
			// m_HideCheck
			// 
			this.m_HideCheck.Location = new System.Drawing.Point(64, 144);
			this.m_HideCheck.Name = "m_HideCheck";
			this.m_HideCheck.TabIndex = 5;
			this.m_HideCheck.Text = "Hide";
			this.m_HideCheck.CheckedChanged += new System.EventHandler(this.m_HideCheck_CheckedChanged);
			// 
			// m_ScrollCheck
			// 
			this.m_ScrollCheck.Location = new System.Drawing.Point(64, 120);
			this.m_ScrollCheck.Name = "m_ScrollCheck";
			this.m_ScrollCheck.TabIndex = 4;
			this.m_ScrollCheck.Text = "Scroll";
			this.m_ScrollCheck.CheckedChanged += new System.EventHandler(this.m_ScrollCheck_CheckedChanged);
			// 
			// NAnimationSurfaceUC
			// 
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nButton1);
			this.Controls.Add(this.nAnimationSurface1);
			this.Name = "NAnimationSurfaceUC";
			this.Size = new System.Drawing.Size(480, 304);
			this.nGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_IntervalNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_StepsNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NAnimationSurface nAnimationSurface1;
		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_FadeCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_SlideCheck;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ScrollCheck;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_StepsNumeric;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_IntervalNumeric;
		private Nevron.UI.WinForm.Controls.NCheckBox m_HideCheck;

		#endregion
	}
}
