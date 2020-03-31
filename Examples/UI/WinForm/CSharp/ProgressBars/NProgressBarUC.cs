using System;
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
	/// Summary description for NProgressBarUC.
	/// </summary>
	public class NProgressBarUC : NExampleUserControl
	{
		#region Constructor

		public NProgressBarUC(MainForm f) : base(f)
		{
			InitializeComponent();
			m_iSuspendUpdate = 0;
		}


		#endregion

		#region Implementation

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

			++m_iSuspendUpdate;

			nProgressBar1.Properties.Value = 20;

			m_StyleCombo.FillFromEnum(typeof(Nevron.UI.WinForm.Controls.ProgressBarStyle), false);
			m_StyleCombo.SelectedItem = Nevron.UI.WinForm.Controls.ProgressBarStyle.Solid;

			m_OrientationCombo.FillFromEnum(typeof(Orientation), false);
			m_OrientationCombo.SelectedItem = Orientation.Horizontal;

			m_ValueNumeric.Value = nProgressBar1.Properties.Value;

			--m_iSuspendUpdate;
		}


		#endregion

		#region Event Handlers

		private void m_ValueNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			nProgressBar1.Properties.Value = (int)m_ValueNumeric.Value;
		}
		private void m_StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			Nevron.UI.WinForm.Controls.ProgressBarStyle style = (Nevron.UI.WinForm.Controls.ProgressBarStyle)m_StyleCombo.SelectedItem;
			nProgressBar1.Properties.Style = style;
		}
		private void m_BorderButton_Click(object sender, System.EventArgs e)
		{
			nProgressBar1.Border.ShowEditor();
		}
		private void m_SegmentsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			nProgressBar1.Properties.Segments = m_SegmentsCheck.Checked;
		}
		private void m_SegmentStepNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			nProgressBar1.Properties.SegmentStep = (int)m_SegmentStepNumeric.Value;
		}
		private void m_PaletteButton_Click(object sender, System.EventArgs e)
		{
			nProgressBar1.Palette.ShowEditor();
			nProgressBar1.Refresh();
		}

		private void m_OrientationCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			Orientation orientation = (Orientation)m_OrientationCombo.SelectedItem;
			nProgressBar1.Properties.Orientation = orientation;
		}

		private void m_ShowTextCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			nProgressBar1.Properties.ShowText = m_ShowTextCheck.Checked;
		}
		private void m_TextEdit_TextChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			nProgressBar1.Properties.Text = m_TextEdit.Text;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_ValueNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.nProgressBar1 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_SegmentsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_SegmentStepNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.m_PaletteButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.m_OrientationCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_TextEdit = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_ShowTextCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.m_ValueNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_SegmentStepNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// m_BorderButton
			// 
			this.m_BorderButton.Location = new System.Drawing.Point(136, 256);
			this.m_BorderButton.Name = "m_BorderButton";
			this.m_BorderButton.TabIndex = 0;
			this.m_BorderButton.Text = "Border...";
			this.m_BorderButton.Click += new System.EventHandler(this.m_BorderButton_Click);
			// 
			// m_StyleCombo
			// 
			this.m_StyleCombo.Location = new System.Drawing.Point(136, 152);
			this.m_StyleCombo.Name = "m_StyleCombo";
			this.m_StyleCombo.Size = new System.Drawing.Size(176, 22);
			this.m_StyleCombo.TabIndex = 1;
			this.m_StyleCombo.Text = "nComboBox1";
			this.m_StyleCombo.SelectedIndexChanged += new System.EventHandler(this.m_StyleCombo_SelectedIndexChanged);
			// 
			// m_ValueNumeric
			// 
			this.m_ValueNumeric.Location = new System.Drawing.Point(136, 64);
			this.m_ValueNumeric.Name = "m_ValueNumeric";
			this.m_ValueNumeric.Size = new System.Drawing.Size(72, 20);
			this.m_ValueNumeric.TabIndex = 2;
			this.m_ValueNumeric.ValueChanged += new System.EventHandler(this.m_ValueNumeric_ValueChanged);
			// 
			// nProgressBar1
			// 
			this.nProgressBar1.Location = new System.Drawing.Point(8, 8);
			this.nProgressBar1.Name = "nProgressBar1";
			this.nProgressBar1.Properties.Text = "";
			this.nProgressBar1.Size = new System.Drawing.Size(280, 24);
			this.nProgressBar1.TabIndex = 3;
			this.nProgressBar1.Text = "nProgressBar1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Value:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Style:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_SegmentsCheck
			// 
			this.m_SegmentsCheck.Location = new System.Drawing.Point(232, 216);
			this.m_SegmentsCheck.Name = "m_SegmentsCheck";
			this.m_SegmentsCheck.Size = new System.Drawing.Size(96, 24);
			this.m_SegmentsCheck.TabIndex = 24;
			this.m_SegmentsCheck.Text = "Segments";
			this.m_SegmentsCheck.CheckedChanged += new System.EventHandler(this.m_SegmentsCheck_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 26;
			this.label3.Text = "Segment Step:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_SegmentStepNumeric
			// 
			this.m_SegmentStepNumeric.Location = new System.Drawing.Point(136, 88);
			this.m_SegmentStepNumeric.Minimum = new System.Decimal(new int[] {
																				 4,
																				 0,
																				 0,
																				 0});
			this.m_SegmentStepNumeric.Name = "m_SegmentStepNumeric";
			this.m_SegmentStepNumeric.Size = new System.Drawing.Size(72, 20);
			this.m_SegmentStepNumeric.TabIndex = 25;
			this.m_SegmentStepNumeric.Value = new System.Decimal(new int[] {
																			   20,
																			   0,
																			   0,
																			   0});
			this.m_SegmentStepNumeric.ValueChanged += new System.EventHandler(this.m_SegmentStepNumeric_ValueChanged);
			// 
			// m_PaletteButton
			// 
			this.m_PaletteButton.Location = new System.Drawing.Point(224, 256);
			this.m_PaletteButton.Name = "m_PaletteButton";
			this.m_PaletteButton.TabIndex = 27;
			this.m_PaletteButton.Text = "Palette...";
			this.m_PaletteButton.Click += new System.EventHandler(this.m_PaletteButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(64, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 29;
			this.label4.Text = "Orientation:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_OrientationCombo
			// 
			this.m_OrientationCombo.Location = new System.Drawing.Point(136, 184);
			this.m_OrientationCombo.Name = "m_OrientationCombo";
			this.m_OrientationCombo.Size = new System.Drawing.Size(176, 22);
			this.m_OrientationCombo.TabIndex = 28;
			this.m_OrientationCombo.Text = "nComboBox1";
			this.m_OrientationCombo.SelectedIndexChanged += new System.EventHandler(this.m_OrientationCombo_SelectedIndexChanged);
			// 
			// m_TextEdit
			// 
			this.m_TextEdit.Location = new System.Drawing.Point(136, 120);
			this.m_TextEdit.Name = "m_TextEdit";
			this.m_TextEdit.Size = new System.Drawing.Size(176, 20);
			this.m_TextEdit.TabIndex = 30;
			this.m_TextEdit.Text = "";
			this.m_TextEdit.TextChanged += new System.EventHandler(this.m_TextEdit_TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(48, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 31;
			this.label5.Text = "Text:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_ShowTextCheck
			// 
			this.m_ShowTextCheck.Location = new System.Drawing.Point(136, 216);
			this.m_ShowTextCheck.Name = "m_ShowTextCheck";
			this.m_ShowTextCheck.Size = new System.Drawing.Size(96, 24);
			this.m_ShowTextCheck.TabIndex = 32;
			this.m_ShowTextCheck.Text = "Show Text";
			this.m_ShowTextCheck.CheckedChanged += new System.EventHandler(this.m_ShowTextCheck_CheckedChanged);
			// 
			// NProgressBarUC
			// 
			this.Controls.Add(this.m_ShowTextCheck);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_TextEdit);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_OrientationCombo);
			this.Controls.Add(this.m_PaletteButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_SegmentStepNumeric);
			this.Controls.Add(this.m_SegmentsCheck);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nProgressBar1);
			this.Controls.Add(this.m_ValueNumeric);
			this.Controls.Add(this.m_StyleCombo);
			this.Controls.Add(this.m_BorderButton);
			this.Name = "NProgressBarUC";
			this.Size = new System.Drawing.Size(384, 296);
			((System.ComponentModel.ISupportInitialize)(this.m_ValueNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_SegmentStepNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_ValueNumeric;
		private Nevron.UI.WinForm.Controls.NButton m_BorderButton;
		private Nevron.UI.WinForm.Controls.NComboBox m_StyleCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NCheckBox m_SegmentsCheck;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_SegmentStepNumeric;
		private Nevron.UI.WinForm.Controls.NButton m_PaletteButton;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox m_OrientationCombo;
		private Nevron.UI.WinForm.Controls.NTextBox m_TextEdit;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowTextCheck;

		#endregion
	}
}
