using System;
using System.Diagnostics;
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
	/// Summary description for NUIPanelUC.
	/// </summary>
	public class NUIPanelUC : NExampleUserControl
	{
		#region Constructor

		public NUIPanelUC(MainForm f) : base(f)
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

			nuiPanel1.HScrollValueChanged += new EventHandler(nuiPanel1_HScrollValueChanged);
			nuiPanel1.VScrollValueChanged += new EventHandler(nuiPanel1_VScrollValueChanged);
			nuiPanel1.AutoScroll = true;
			propertyGrid1.SelectedObject = nuiPanel1;

            this.nButton1.TransparentBackground = true;
		}



		#endregion

		#region Event Handlers

		private void hScrollNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_bUpdating)
				return;

			m_bUpdating = true;
			this.nuiPanel1.HScroll.Value = (int)hScrollNumeric.Value;
			this.hScrollNumeric.Value = this.nuiPanel1.HScroll.Value;
			m_bUpdating = false;
		}

		private void vScrollNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_bUpdating)
				return;

			m_bUpdating = true;
			this.nuiPanel1.VScroll.Value = (int)vScrollNumeric.Value;
			this.vScrollNumeric.Value = this.nuiPanel1.VScroll.Value;
			m_bUpdating = false;
		}
		private void nuiPanel1_HScrollValueChanged(object sender, EventArgs e)
		{
			if(m_bUpdating)
				return;

			m_bUpdating = true;
			hScrollNumeric.Value = nuiPanel1.HScroll.Value;
			m_bUpdating = false;
		}

		private void nuiPanel1_VScrollValueChanged(object sender, EventArgs e)
		{
			if(m_bUpdating)
				return;

			m_bUpdating = true;
			vScrollNumeric.Value = nuiPanel1.VScroll.Value;
			m_bUpdating = false;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
			this.nColorPool2 = new Nevron.UI.WinForm.Controls.NColorPool();
			this.nColorPool1 = new Nevron.UI.WinForm.Controls.NColorPool();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.hScrollNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.vScrollNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.nuiPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.hScrollNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vScrollNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// nuiPanel1
			// 
			this.nuiPanel1.AutoScroll = true;
			this.nuiPanel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(191)), ((System.Byte)(219)), ((System.Byte)(255)));
			this.nuiPanel1.Border.Style = Nevron.UI.BorderStyle3D.Flat;
			this.nuiPanel1.Controls.Add(this.nColorPool2);
			this.nuiPanel1.Controls.Add(this.nColorPool1);
			this.nuiPanel1.Controls.Add(this.nCheckBox1);
			this.nuiPanel1.Controls.Add(this.nButton1);
			this.nuiPanel1.Location = new System.Drawing.Point(8, 8);
			this.nuiPanel1.Name = "nuiPanel1";
			this.nuiPanel1.Size = new System.Drawing.Size(264, 208);
			this.nuiPanel1.TabIndex = 0;
			// 
			// nColorPool2
			// 
			this.nColorPool2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nColorPool2.Color = System.Drawing.Color.Empty;
			this.nColorPool2.Hue = 0F;
			this.nColorPool2.Location = new System.Drawing.Point(184, 168);
			this.nColorPool2.Luminance = 0.5F;
			this.nColorPool2.Name = "nColorPool2";
			this.nColorPool2.Saturation = 0F;
			this.nColorPool2.Size = new System.Drawing.Size(202, 102);
			this.nColorPool2.TabIndex = 3;
			// 
			// nColorPool1
			// 
			this.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nColorPool1.Color = System.Drawing.Color.Empty;
			this.nColorPool1.Hue = 0F;
			this.nColorPool1.Location = new System.Drawing.Point(208, 232);
			this.nColorPool1.Luminance = 0.5F;
			this.nColorPool1.Name = "nColorPool1";
			this.nColorPool1.Saturation = 0F;
			this.nColorPool1.Size = new System.Drawing.Size(208, 104);
			this.nColorPool1.TabIndex = 2;
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Location = new System.Drawing.Point(8, 40);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.TabIndex = 1;
			this.nCheckBox1.Text = "nCheckBox1";
			this.nCheckBox1.TransparentBackground = true;
			// 
			// nButton1
			// 
			this.nButton1.Location = new System.Drawing.Point(8, 8);
			this.nButton1.Name = "nButton1";
			this.nButton1.TabIndex = 0;
			this.nButton1.Text = "nButton1";
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(280, 8);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(296, 344);
			this.propertyGrid1.TabIndex = 1;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// hScrollNumeric
			// 
			this.hScrollNumeric.Location = new System.Drawing.Point(88, 232);
			this.hScrollNumeric.Maximum = new System.Decimal(new int[] {
																		   10000,
																		   0,
																		   0,
																		   0});
			this.hScrollNumeric.Name = "hScrollNumeric";
			this.hScrollNumeric.Size = new System.Drawing.Size(72, 20);
			this.hScrollNumeric.TabIndex = 2;
			this.hScrollNumeric.ValueChanged += new System.EventHandler(this.hScrollNumeric_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 232);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "HScroll:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "VScroll:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// vScrollNumeric
			// 
			this.vScrollNumeric.Location = new System.Drawing.Point(88, 256);
			this.vScrollNumeric.Maximum = new System.Decimal(new int[] {
																		   10000,
																		   0,
																		   0,
																		   0});
			this.vScrollNumeric.Name = "vScrollNumeric";
			this.vScrollNumeric.Size = new System.Drawing.Size(72, 20);
			this.vScrollNumeric.TabIndex = 4;
			this.vScrollNumeric.ValueChanged += new System.EventHandler(this.vScrollNumeric_ValueChanged);
			// 
			// NUIPanelUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.vScrollNumeric);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.hScrollNumeric);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.nuiPanel1);
			this.Name = "NUIPanelUC";
			this.Size = new System.Drawing.Size(576, 352);
			this.nuiPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.hScrollNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vScrollNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal bool m_bUpdating;

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NColorPool nColorPool2;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown hScrollNumeric;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown vScrollNumeric;
		private Nevron.UI.WinForm.Controls.NColorPool nColorPool1;

		#endregion
	}
}
