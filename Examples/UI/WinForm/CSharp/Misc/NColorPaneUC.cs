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
	/// Summary description for NColorPaneUC.
	/// </summary>
	public class NColorPaneUC : NExampleUserControl
	{
		#region Constructor

		public NColorPaneUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

		public override void Initialize()
		{
			base.Initialize ();

			++m_iSuspendUpdate;

			m_PreviewLabel.BackColor = Color.White;

			m_ShowTooltipsCheck.Checked = nColorPane1.ShowTooltips;
			m_SelectableCheck.Checked = nColorPane1.Selectable;

			m_ColorChangeStyle.FillFromEnum(typeof(ColorChangeStyle), true);
			m_ColorChangeStyle.SelectedItem = nColorPane1.ChangeStyle;

			this.nColorPane1.CommandSize = new Size(21, 21);

			m_CellWidthNumeric.Value = nColorPane1.CommandSize.Width;
			m_CellHeightNumeric.Value = nColorPane1.CommandSize.Height;

			m_PreviewLabel.BackColor = nColorPane1.Color;

			--m_iSuspendUpdate;
		}

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

		private void nColorPane1_ColorChanged(object sender, System.EventArgs e)
		{
			m_PreviewLabel.BackColor = nColorPane1.Color;
		}

		private void m_CellWidthNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			Size sz = new Size((int)m_CellWidthNumeric.Value, nColorPane1.CommandSize.Height);
			nColorPane1.CommandSize = sz;
		}

		private void m_CellHeightNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			Size sz = new Size(nColorPane1.CommandSize.Width, (int)m_CellHeightNumeric.Value);
			nColorPane1.CommandSize = sz;
		}

		private void m_ColorChangeStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			object o = m_ColorChangeStyle.SelectedItem;
			if(o == null)
				return;

			nColorPane1.ChangeStyle = (ColorChangeStyle)o;
		}

		private void m_ShowTooltipsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nColorPane1.ShowTooltips = m_ShowTooltipsCheck.Checked;
		}

		private void m_SelectableCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nColorPane1.Selectable = m_SelectableCheck.Checked;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nColorPane1 = new Nevron.UI.WinForm.Controls.NColorPane();
			this.m_CellWidthNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_CellHeightNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.m_PreviewLabel = new System.Windows.Forms.Label();
			this.m_ColorChangeStyle = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_ShowTooltipsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_SelectableCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.m_CellWidthNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_CellHeightNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// nColorPane1
			// 
			this.nColorPane1.Color = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nColorPane1.CommandSize = new System.Drawing.Size(21, 21);
			this.nColorPane1.ImageSize = new System.Drawing.Size(12, 12);
			this.nColorPane1.Location = new System.Drawing.Point(8, 8);
			this.nColorPane1.Name = "nColorPane1";
			this.nColorPane1.Size = new System.Drawing.Size(305, 308);
			this.nColorPane1.TabIndex = 0;
			this.nColorPane1.Text = "nColorPane1";
			this.nColorPane1.ColorChanged += new System.EventHandler(this.nColorPane1_ColorChanged);
			// 
			// m_CellWidthNumeric
			// 
			this.m_CellWidthNumeric.Location = new System.Drawing.Point(112, 320);
			this.m_CellWidthNumeric.Maximum = new System.Decimal(new int[] {
																			   30,
																			   0,
																			   0,
																			   0});
			this.m_CellWidthNumeric.Minimum = new System.Decimal(new int[] {
																			   4,
																			   0,
																			   0,
																			   0});
			this.m_CellWidthNumeric.Name = "m_CellWidthNumeric";
			this.m_CellWidthNumeric.Size = new System.Drawing.Size(88, 20);
			this.m_CellWidthNumeric.TabIndex = 1;
			this.m_CellWidthNumeric.Value = new System.Decimal(new int[] {
																			 4,
																			 0,
																			 0,
																			 0});
			this.m_CellWidthNumeric.ValueChanged += new System.EventHandler(this.m_CellWidthNumeric_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 320);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Cell Width:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 344);
			this.label2.Name = "label2";
			this.label2.TabIndex = 4;
			this.label2.Text = "Cell Height:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_CellHeightNumeric
			// 
			this.m_CellHeightNumeric.Location = new System.Drawing.Point(112, 344);
			this.m_CellHeightNumeric.Maximum = new System.Decimal(new int[] {
																				30,
																				0,
																				0,
																				0});
			this.m_CellHeightNumeric.Minimum = new System.Decimal(new int[] {
																				4,
																				0,
																				0,
																				0});
			this.m_CellHeightNumeric.Name = "m_CellHeightNumeric";
			this.m_CellHeightNumeric.Size = new System.Drawing.Size(88, 20);
			this.m_CellHeightNumeric.TabIndex = 3;
			this.m_CellHeightNumeric.Value = new System.Decimal(new int[] {
																			  4,
																			  0,
																			  0,
																			  0});
			this.m_CellHeightNumeric.ValueChanged += new System.EventHandler(this.m_CellHeightNumeric_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(320, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 24);
			this.label3.TabIndex = 5;
			this.label3.Text = "Preview:";
			// 
			// m_PreviewLabel
			// 
			this.m_PreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_PreviewLabel.Location = new System.Drawing.Point(320, 204);
			this.m_PreviewLabel.Name = "m_PreviewLabel";
			this.m_PreviewLabel.Size = new System.Drawing.Size(120, 112);
			this.m_PreviewLabel.TabIndex = 6;
			// 
			// m_ColorChangeStyle
			// 
			this.m_ColorChangeStyle.ListProperties.ColumnOnLeft = false;
			this.m_ColorChangeStyle.Location = new System.Drawing.Point(112, 368);
			this.m_ColorChangeStyle.Name = "m_ColorChangeStyle";
			this.m_ColorChangeStyle.Size = new System.Drawing.Size(168, 21);
			this.m_ColorChangeStyle.TabIndex = 7;
			this.m_ColorChangeStyle.SelectedIndexChanged += new System.EventHandler(this.m_ColorChangeStyle_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 368);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Color Change Style";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_ShowTooltipsCheck
			// 
			this.m_ShowTooltipsCheck.Location = new System.Drawing.Point(112, 400);
			this.m_ShowTooltipsCheck.Name = "m_ShowTooltipsCheck";
			this.m_ShowTooltipsCheck.TabIndex = 9;
			this.m_ShowTooltipsCheck.Text = "Show Tooltips";
			this.m_ShowTooltipsCheck.CheckedChanged += new System.EventHandler(this.m_ShowTooltipsCheck_CheckedChanged);
			// 
			// m_SelectableCheck
			// 
			this.m_SelectableCheck.Location = new System.Drawing.Point(216, 400);
			this.m_SelectableCheck.Name = "m_SelectableCheck";
			this.m_SelectableCheck.TabIndex = 10;
			this.m_SelectableCheck.Text = "Selectable";
			this.m_SelectableCheck.CheckedChanged += new System.EventHandler(this.m_SelectableCheck_CheckedChanged);
			// 
			// NColorPaneUC
			// 
			this.Controls.Add(this.m_SelectableCheck);
			this.Controls.Add(this.m_ShowTooltipsCheck);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_ColorChangeStyle);
			this.Controls.Add(this.m_PreviewLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_CellHeightNumeric);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_CellWidthNumeric);
			this.Controls.Add(this.nColorPane1);
			this.Name = "NColorPaneUC";
			this.Size = new System.Drawing.Size(448, 424);
			((System.ComponentModel.ISupportInitialize)(this.m_CellWidthNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_CellHeightNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NColorPane nColorPane1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label m_PreviewLabel;
		private NNumericUpDown m_CellWidthNumeric;
		private NComboBox m_ColorChangeStyle;
		private System.Windows.Forms.Label label4;
		private NCheckBox m_ShowTooltipsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_SelectableCheck;
		private NNumericUpDown m_CellHeightNumeric;

		#endregion
	}
}
