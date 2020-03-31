using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NFormCustomCaptionButtonsUC.
	/// </summary>
	public class NFormCustomCaptionButtonsUC : NExampleUserControl
	{
		#region Constructor

		public NFormCustomCaptionButtonsUC(MainForm f) : base(f)
		{
			InitializeComponent();

			m_arrButtons = new ArrayList();

			m_GlyphCombo.FillFromEnum(typeof(CommonGlyphs));
			m_GlyphCombo.SelectedIndex = 0;
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


		#endregion

		#region Event Handlers

		private void m_AddButton_Click(object sender, System.EventArgs e)
		{
			NFrameCaptionButton button = new NFrameCaptionButton();
			button.Glyph = (CommonGlyphs)m_GlyphCombo.SelectedItem;
			button.GlyphSize = new Size((int)m_GlyphWidthNumeric.Value, (int)m_GlyphHeightNumeric.Value);
			m_arrButtons.Add(button);
		}
		private void m_ShowFormButton_Click(object sender, System.EventArgs e)
		{
			NForm f = new NForm();
			f.FrameAppearance = NUIManager.GetPredefinedFrame(PredefinedFrame.Simple);
			f.StartPosition = FormStartPosition.CenterParent;
			f.Text = "Custom Caption Buttons";
			f.Palette.Copy(NUIManager.Palette);
			f.CaptionButtonClicked += new NUIItemEventHandler(f_CaptionButtonClicked);

			foreach(NFrameCaptionButton button in m_arrButtons)
				f.CustomButtons.Add(button);

			f.ShowDialog();
		}
		private void m_ClearButton_Click(object sender, System.EventArgs e)
		{
			m_arrButtons.Clear();
		}
		private void f_CaptionButtonClicked(object sender, NUIItemEventArgs e)
		{
			//MessageBox.Show("Caption button clicked...");
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_GlyphCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_GlyphWidthNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.m_GlyphHeightNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.m_AddButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ShowFormButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ClearButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_GlyphWidthNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_GlyphHeightNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// m_GlyphCombo
			// 
			this.m_GlyphCombo.Location = new System.Drawing.Point(72, 24);
			this.m_GlyphCombo.Name = "m_GlyphCombo";
			this.m_GlyphCombo.Size = new System.Drawing.Size(128, 24);
			this.m_GlyphCombo.TabIndex = 0;
			this.m_GlyphCombo.Text = "nComboBox1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Style:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.m_GlyphHeightNumeric);
			this.nGroupBox1.Controls.Add(this.m_GlyphWidthNumeric);
			this.nGroupBox1.Controls.Add(this.label3);
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Controls.Add(this.m_GlyphCombo);
			this.nGroupBox1.Controls.Add(this.label1);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(224, 112);
			this.nGroupBox1.TabIndex = 2;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Glyph";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Width:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Height:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_GlyphWidthNumeric
			// 
			this.m_GlyphWidthNumeric.Location = new System.Drawing.Point(72, 56);
			this.m_GlyphWidthNumeric.Name = "m_GlyphWidthNumeric";
			this.m_GlyphWidthNumeric.Size = new System.Drawing.Size(72, 20);
			this.m_GlyphWidthNumeric.TabIndex = 4;
			this.m_GlyphWidthNumeric.Value = new System.Decimal(new int[] {
																			  8,
																			  0,
																			  0,
																			  0});
			// 
			// m_GlyphHeightNumeric
			// 
			this.m_GlyphHeightNumeric.Location = new System.Drawing.Point(72, 80);
			this.m_GlyphHeightNumeric.Name = "m_GlyphHeightNumeric";
			this.m_GlyphHeightNumeric.Size = new System.Drawing.Size(72, 20);
			this.m_GlyphHeightNumeric.TabIndex = 5;
			this.m_GlyphHeightNumeric.Value = new System.Decimal(new int[] {
																			   8,
																			   0,
																			   0,
																			   0});
			// 
			// m_AddButton
			// 
			this.m_AddButton.Location = new System.Drawing.Point(144, 128);
			this.m_AddButton.Name = "m_AddButton";
			this.m_AddButton.Size = new System.Drawing.Size(88, 24);
			this.m_AddButton.TabIndex = 3;
			this.m_AddButton.Text = "Add Button";
			this.m_AddButton.Click += new System.EventHandler(this.m_AddButton_Click);
			// 
			// m_ShowFormButton
			// 
			this.m_ShowFormButton.Location = new System.Drawing.Point(144, 192);
			this.m_ShowFormButton.Name = "m_ShowFormButton";
			this.m_ShowFormButton.Size = new System.Drawing.Size(88, 24);
			this.m_ShowFormButton.TabIndex = 4;
			this.m_ShowFormButton.Text = "Show Form...";
			this.m_ShowFormButton.Click += new System.EventHandler(this.m_ShowFormButton_Click);
			// 
			// m_ClearButton
			// 
			this.m_ClearButton.Location = new System.Drawing.Point(144, 160);
			this.m_ClearButton.Name = "m_ClearButton";
			this.m_ClearButton.Size = new System.Drawing.Size(88, 24);
			this.m_ClearButton.TabIndex = 5;
			this.m_ClearButton.Text = "Clear Buttons";
			this.m_ClearButton.Click += new System.EventHandler(this.m_ClearButton_Click);
			// 
			// NFormCustomCaptionButtonsUC
			// 
			this.Controls.Add(this.m_ClearButton);
			this.Controls.Add(this.m_ShowFormButton);
			this.Controls.Add(this.m_AddButton);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NFormCustomCaptionButtonsUC";
			this.Size = new System.Drawing.Size(256, 248);
			this.nGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_GlyphWidthNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_GlyphHeightNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NComboBox m_GlyphCombo;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_GlyphWidthNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_GlyphHeightNumeric;
		private Nevron.UI.WinForm.Controls.NButton m_AddButton;
		private Nevron.UI.WinForm.Controls.NButton m_ShowFormButton;
		private Nevron.UI.WinForm.Controls.NButton m_ClearButton;

		internal ArrayList m_arrButtons;

		#endregion
	}
}
