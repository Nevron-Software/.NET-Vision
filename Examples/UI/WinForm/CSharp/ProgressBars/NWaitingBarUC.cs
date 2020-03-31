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
	/// Summary description for NWaitingBarUC.
	/// </summary>
	public class NWaitingBarUC : NExampleUserControl
	{
		#region Constructor

		public NWaitingBarUC(MainForm f) : base(f)
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

			m_StyleCombo.FillFromEnum(typeof(Nevron.UI.WinForm.Controls.ProgressBarStyle), false);
			m_StyleCombo.SelectedItem = Nevron.UI.WinForm.Controls.ProgressBarStyle.Solid;

			m_OrientationCombo.FillFromEnum(typeof(Orientation), false);
			m_OrientationCombo.SelectedItem = Orientation.Horizontal;
			nhScrollBar1.Value = 100 - nWaitingBar1.Properties.Interval;

			m_WaitSizeNumeric.Value = nWaitingBar1.Properties.WaitSize;
			m_StepNumeric.Value = nWaitingBar1.Properties.Step;

			textEdit.Text = "Installing... Please, wait!";

			--m_iSuspendUpdate;

			this.nWaitingBar1.BeginWait();
		}


		#endregion

		#region Event Handlers

		private void m_StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			Nevron.UI.WinForm.Controls.ProgressBarStyle style = (Nevron.UI.WinForm.Controls.ProgressBarStyle)m_StyleCombo.SelectedItem;
			nWaitingBar1.Properties.Style = style;
		}
		private void m_OrientationCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			Orientation orientation = (Orientation)m_OrientationCombo.SelectedItem;
			nWaitingBar1.Properties.Orientation = orientation;
		}
		private void m_BorderButton_Click(object sender, System.EventArgs e)
		{
			nWaitingBar1.Border.ShowEditor();
		}
		private void m_PaletteButton_Click(object sender, System.EventArgs e)
		{
			nWaitingBar1.Palette.ShowEditor();
		}
		private void m_BeginWaitButton_Click(object sender, System.EventArgs e)
		{
			nWaitingBar1.BeginWait();
		}
		private void m_EndWaitButton_Click(object sender, System.EventArgs e)
		{
			nWaitingBar1.EndWait();
		}

		private void nhScrollBar1_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			nWaitingBar1.Properties.Interval = 100 - nhScrollBar1.Value;
		}
		private void m_WaitSizeNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			nWaitingBar1.Properties.WaitSize = (int)m_WaitSizeNumeric.Value;
		}
		private void m_IncrementButton_Click(object sender, System.EventArgs e)
		{
			nWaitingBar1.Properties.Position += 1;
		}
		private void m_StepNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;
			nWaitingBar1.Properties.Step = (int)m_StepNumeric.Value;
		}

		private void textEdit_TextChanged(object sender, System.EventArgs e)
		{
			nWaitingBar1.Properties.Text = textEdit.Text;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nWaitingBar1 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.label4 = new System.Windows.Forms.Label();
			this.m_OrientationCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_PaletteButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.m_StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_BeginWaitButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_EndWaitButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nhScrollBar1 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_WaitSizeNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.m_StepNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.m_IncrementButton = new Nevron.UI.WinForm.Controls.NButton();
			this.textEdit = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.m_WaitSizeNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_StepNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// nWaitingBar1
			// 
			this.nWaitingBar1.Location = new System.Drawing.Point(16, 16);
			this.nWaitingBar1.Name = "nWaitingBar1";
			this.nWaitingBar1.Size = new System.Drawing.Size(312, 24);
			this.nWaitingBar1.TabIndex = 0;
			this.nWaitingBar1.Text = "nWaitingBar1";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(48, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 23);
			this.label4.TabIndex = 35;
			this.label4.Text = "Orientation:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_OrientationCombo
			// 
			this.m_OrientationCombo.Location = new System.Drawing.Point(144, 144);
			this.m_OrientationCombo.Name = "m_OrientationCombo";
			this.m_OrientationCombo.Size = new System.Drawing.Size(176, 22);
			this.m_OrientationCombo.TabIndex = 34;
			this.m_OrientationCombo.Text = "nComboBox1";
			this.m_OrientationCombo.SelectedIndexChanged += new System.EventHandler(this.m_OrientationCombo_SelectedIndexChanged);
			// 
			// m_PaletteButton
			// 
			this.m_PaletteButton.Location = new System.Drawing.Point(232, 304);
			this.m_PaletteButton.Name = "m_PaletteButton";
			this.m_PaletteButton.TabIndex = 33;
			this.m_PaletteButton.Text = "Palette...";
			this.m_PaletteButton.Click += new System.EventHandler(this.m_PaletteButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 32;
			this.label2.Text = "Style:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_StyleCombo
			// 
			this.m_StyleCombo.Location = new System.Drawing.Point(144, 112);
			this.m_StyleCombo.Name = "m_StyleCombo";
			this.m_StyleCombo.Size = new System.Drawing.Size(176, 22);
			this.m_StyleCombo.TabIndex = 31;
			this.m_StyleCombo.Text = "nComboBox1";
			this.m_StyleCombo.SelectedIndexChanged += new System.EventHandler(this.m_StyleCombo_SelectedIndexChanged);
			// 
			// m_BorderButton
			// 
			this.m_BorderButton.Location = new System.Drawing.Point(144, 304);
			this.m_BorderButton.Name = "m_BorderButton";
			this.m_BorderButton.TabIndex = 30;
			this.m_BorderButton.Text = "Border...";
			this.m_BorderButton.Click += new System.EventHandler(this.m_BorderButton_Click);
			// 
			// m_BeginWaitButton
			// 
			this.m_BeginWaitButton.Location = new System.Drawing.Point(336, 16);
			this.m_BeginWaitButton.Name = "m_BeginWaitButton";
			this.m_BeginWaitButton.TabIndex = 36;
			this.m_BeginWaitButton.Text = "Begin Wait";
			this.m_BeginWaitButton.Click += new System.EventHandler(this.m_BeginWaitButton_Click);
			// 
			// m_EndWaitButton
			// 
			this.m_EndWaitButton.Location = new System.Drawing.Point(336, 48);
			this.m_EndWaitButton.Name = "m_EndWaitButton";
			this.m_EndWaitButton.TabIndex = 37;
			this.m_EndWaitButton.Text = "End Wait";
			this.m_EndWaitButton.Click += new System.EventHandler(this.m_EndWaitButton_Click);
			// 
			// nhScrollBar1
			// 
			this.nhScrollBar1.Location = new System.Drawing.Point(144, 176);
			this.nhScrollBar1.Name = "nhScrollBar1";
			this.nhScrollBar1.Size = new System.Drawing.Size(176, 17);
			this.nhScrollBar1.TabIndex = 38;
			this.nhScrollBar1.Text = "nhScrollBar1";
			this.nhScrollBar1.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.nhScrollBar1_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(72, 176);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 39;
			this.label1.Text = "Speed:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(72, 240);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 41;
			this.label3.Text = "Wait Size:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_WaitSizeNumeric
			// 
			this.m_WaitSizeNumeric.Location = new System.Drawing.Point(144, 240);
			this.m_WaitSizeNumeric.Name = "m_WaitSizeNumeric";
			this.m_WaitSizeNumeric.Size = new System.Drawing.Size(72, 20);
			this.m_WaitSizeNumeric.TabIndex = 40;
			this.m_WaitSizeNumeric.ValueChanged += new System.EventHandler(this.m_WaitSizeNumeric_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(72, 272);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 43;
			this.label5.Text = "Step:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_StepNumeric
			// 
			this.m_StepNumeric.Location = new System.Drawing.Point(144, 272);
			this.m_StepNumeric.Name = "m_StepNumeric";
			this.m_StepNumeric.Size = new System.Drawing.Size(72, 20);
			this.m_StepNumeric.TabIndex = 42;
			this.m_StepNumeric.ValueChanged += new System.EventHandler(this.m_StepNumeric_ValueChanged);
			// 
			// m_IncrementButton
			// 
			this.m_IncrementButton.Location = new System.Drawing.Point(336, 80);
			this.m_IncrementButton.Name = "m_IncrementButton";
			this.m_IncrementButton.TabIndex = 44;
			this.m_IncrementButton.Text = "Increment";
			this.m_IncrementButton.Click += new System.EventHandler(this.m_IncrementButton_Click);
			// 
			// textEdit
			// 
			this.textEdit.Location = new System.Drawing.Point(144, 208);
			this.textEdit.Name = "textEdit";
			this.textEdit.Size = new System.Drawing.Size(176, 18);
			this.textEdit.TabIndex = 45;
			this.textEdit.TextChanged += new System.EventHandler(this.textEdit_TextChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(72, 208);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 46;
			this.label6.Text = "Text:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NWaitingBarUC
			// 
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textEdit);
			this.Controls.Add(this.m_IncrementButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_StepNumeric);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_WaitSizeNumeric);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nhScrollBar1);
			this.Controls.Add(this.m_EndWaitButton);
			this.Controls.Add(this.m_BeginWaitButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_OrientationCombo);
			this.Controls.Add(this.m_PaletteButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_StyleCombo);
			this.Controls.Add(this.m_BorderButton);
			this.Controls.Add(this.nWaitingBar1);
			this.Name = "NWaitingBarUC";
			this.Size = new System.Drawing.Size(424, 336);
			((System.ComponentModel.ISupportInitialize)(this.m_WaitSizeNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_StepNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar1;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox m_OrientationCombo;
		private Nevron.UI.WinForm.Controls.NButton m_PaletteButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox m_StyleCombo;
		private Nevron.UI.WinForm.Controls.NButton m_BorderButton;
		private Nevron.UI.WinForm.Controls.NButton m_BeginWaitButton;
		private Nevron.UI.WinForm.Controls.NButton m_EndWaitButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar nhScrollBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_WaitSizeNumeric;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_StepNumeric;
		private Nevron.UI.WinForm.Controls.NTextBox textEdit;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NButton m_IncrementButton;

		#endregion
	}
}
