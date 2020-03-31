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
	/// Summary description for NFormUC.
	/// </summary>
	public class NFormUC : NExampleUserControl
	{
		#region Constructor

		public NFormUC(MainForm f) : base(f)
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

			m_CustomAppearance = new NFrameAppearance();
			m_Properties.SelectedObject = m_CustomAppearance;

			m_PredefinedFrameCombo.FillFromEnum(typeof(PredefinedFrame));
			m_PredefinedFrameCombo.SelectedIndex = 0;
		}


		#endregion

		#region Implementation
		#endregion

		#region Event Handlers

		private void m_ShowFormButton_Click(object sender, System.EventArgs e)
		{
			NFrameAppearance appearance;

			if(m_PredefinedRadio.Checked)
			{
				appearance = NUIManager.GetPredefinedFrame((PredefinedFrame)m_PredefinedFrameCombo.SelectedItem);
			}
			else
				appearance = m_CustomAppearance;

			NForm form = new NForm();
			form.UseGlassIfEnabled = CommonTriState.False;
			form.EnableSkinning = false;
			form.Palette.Copy(NUIManager.Palette);
			form.Text = "Custom Form Example";
			form.FrameAppearance = appearance;
			form.ShowCaptionImage = true;
			form.StartPosition = FormStartPosition.CenterParent;
			form.ShowDialog();
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_PredefinedFrameCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_ShowFormButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_Properties = new System.Windows.Forms.PropertyGrid();
			this.m_PredefinedRadio = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
			this.nLineControl2 = new Nevron.UI.WinForm.Controls.NLineControl();
			this.m_CustomRadio = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nLineControl3 = new Nevron.UI.WinForm.Controls.NLineControl();
			this.SuspendLayout();
			// 
			// m_PredefinedFrameCombo
			// 
			this.m_PredefinedFrameCombo.Location = new System.Drawing.Point(96, 32);
			this.m_PredefinedFrameCombo.Name = "m_PredefinedFrameCombo";
			this.m_PredefinedFrameCombo.Size = new System.Drawing.Size(216, 22);
			this.m_PredefinedFrameCombo.TabIndex = 0;
			this.m_PredefinedFrameCombo.Text = "nComboBox1";
			// 
			// m_ShowFormButton
			// 
			this.m_ShowFormButton.Location = new System.Drawing.Point(352, 448);
			this.m_ShowFormButton.Name = "m_ShowFormButton";
			this.m_ShowFormButton.Size = new System.Drawing.Size(104, 23);
			this.m_ShowFormButton.TabIndex = 3;
			this.m_ShowFormButton.Text = "Show Form...";
			this.m_ShowFormButton.Click += new System.EventHandler(this.m_ShowFormButton_Click);
			// 
			// m_Properties
			// 
			this.m_Properties.CommandsVisibleIfAvailable = true;
			this.m_Properties.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.m_Properties.LargeButtons = false;
			this.m_Properties.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.m_Properties.Location = new System.Drawing.Point(96, 104);
			this.m_Properties.Name = "m_Properties";
			this.m_Properties.Size = new System.Drawing.Size(360, 312);
			this.m_Properties.TabIndex = 0;
			this.m_Properties.Text = "propertyGrid1";
			this.m_Properties.ToolbarVisible = false;
			this.m_Properties.ViewBackColor = System.Drawing.SystemColors.Window;
			this.m_Properties.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// m_PredefinedRadio
			// 
			this.m_PredefinedRadio.Checked = true;
			this.m_PredefinedRadio.Location = new System.Drawing.Point(8, 8);
			this.m_PredefinedRadio.Name = "m_PredefinedRadio";
			this.m_PredefinedRadio.Size = new System.Drawing.Size(80, 24);
			this.m_PredefinedRadio.TabIndex = 4;
			this.m_PredefinedRadio.TabStop = true;
			this.m_PredefinedRadio.Text = "Predefined";
			// 
			// nLineControl1
			// 
			this.nLineControl1.Location = new System.Drawing.Point(96, 16);
			this.nLineControl1.Name = "nLineControl1";
			this.nLineControl1.Size = new System.Drawing.Size(360, 2);
			this.nLineControl1.Text = "nLineControl1";
			// 
			// nLineControl2
			// 
			this.nLineControl2.Location = new System.Drawing.Point(96, 88);
			this.nLineControl2.Name = "nLineControl2";
			this.nLineControl2.Size = new System.Drawing.Size(360, 2);
			this.nLineControl2.Text = "nLineControl2";
			// 
			// m_CustomRadio
			// 
			this.m_CustomRadio.Location = new System.Drawing.Point(8, 80);
			this.m_CustomRadio.Name = "m_CustomRadio";
			this.m_CustomRadio.Size = new System.Drawing.Size(80, 24);
			this.m_CustomRadio.TabIndex = 7;
			this.m_CustomRadio.Text = "Custom";
			// 
			// nLineControl3
			// 
			this.nLineControl3.Location = new System.Drawing.Point(96, 432);
			this.nLineControl3.Name = "nLineControl3";
			this.nLineControl3.Size = new System.Drawing.Size(360, 2);
			this.nLineControl3.Text = "nLineControl3";
			// 
			// NFormUC
			// 
			this.Controls.Add(this.nLineControl3);
			this.Controls.Add(this.nLineControl2);
			this.Controls.Add(this.m_CustomRadio);
			this.Controls.Add(this.nLineControl1);
			this.Controls.Add(this.m_PredefinedRadio);
			this.Controls.Add(this.m_Properties);
			this.Controls.Add(this.m_ShowFormButton);
			this.Controls.Add(this.m_PredefinedFrameCombo);
			this.Name = "NFormUC";
			this.Size = new System.Drawing.Size(472, 480);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NFrameAppearance m_CustomAppearance;

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NComboBox m_PredefinedFrameCombo;
		private Nevron.UI.WinForm.Controls.NButton m_ShowFormButton;
		private System.Windows.Forms.PropertyGrid m_Properties;
		private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
		private Nevron.UI.WinForm.Controls.NLineControl nLineControl2;
		private Nevron.UI.WinForm.Controls.NRadioButton m_PredefinedRadio;
		private Nevron.UI.WinForm.Controls.NRadioButton m_CustomRadio;
		private Nevron.UI.WinForm.Controls.NLineControl nLineControl3;

		#endregion
	}
}
