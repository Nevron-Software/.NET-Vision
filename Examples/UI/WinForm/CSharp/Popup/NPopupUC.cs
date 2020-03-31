using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;
using Nevron.GraphicsCore;
using Nevron.GraphicsCore.Text;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NPopupUC.
	/// </summary>
	public class NPopupUC : NExampleUserControl
	{
		#region Constructor

		public NPopupUC()
		{
			InitializeComponent();
		}
        public NPopupUC(MainForm f) : base(f)
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

				m_Popup.Dispose();
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize ();

			m_Popup = new NPopup();
			m_Popup.Owner = m_MainForm;
			m_Popup.Size = new NSize(250, 220);
			m_Popup.SizeStyle = PopupSizeStyle.BottomRight;
			m_Popup.Padding = new NPadding(4);

			propertyGrid.SelectedObject = m_Popup;
		}


		#endregion

		#region Event Handlers

		private void showBtn_Click(object sender, System.EventArgs e)
		{
			if(nRadioButton1.Checked)
			{
				m_Popup.PlacementTarget = nRadioButton1;
			}
			else
			{
				m_Popup.PlacementTarget = nRadioButton2;
			}

			if(this.nCheckBox1.Checked)
			{
				NCalculator calc = new NCalculator();
				calc.Dock = DockStyle.Fill;
				calc.BackColor = Color.Transparent;
				m_Popup.HostedControl = calc;
			}
			else
			{
				m_Popup.HostedControl = null;
			}

			m_Popup.Display();
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.showBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.nRadioButton1 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton2 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// propertyGrid
			// 
			this.propertyGrid.CommandsVisibleIfAvailable = true;
			this.propertyGrid.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.propertyGrid.HelpBackColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(230)), ((System.Byte)(230)));
			this.propertyGrid.HelpForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.propertyGrid.LargeButtons = false;
			this.propertyGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(230)), ((System.Byte)(230)));
			this.propertyGrid.Location = new System.Drawing.Point(248, 8);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(271, 312);
			this.propertyGrid.TabIndex = 5;
			this.propertyGrid.Text = "propertyGrid1";
			this.propertyGrid.ToolbarVisible = false;
			this.propertyGrid.ViewBackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.propertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			// 
			// showBtn
			// 
			this.showBtn.ButtonProperties.WrapText = true;
			this.showBtn.Location = new System.Drawing.Point(248, 328);
			this.showBtn.Name = "showBtn";
			this.showBtn.Size = new System.Drawing.Size(272, 32);
			this.showBtn.TabIndex = 3;
			this.showBtn.Text = "Show";
			this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
			// 
			// nRadioButton1
			// 
			this.nRadioButton1.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton1.ButtonProperties.BorderOffset = 2;
			this.nRadioButton1.Checked = true;
			this.nRadioButton1.Location = new System.Drawing.Point(16, 24);
			this.nRadioButton1.Name = "nRadioButton1";
			this.nRadioButton1.Size = new System.Drawing.Size(192, 128);
			this.nRadioButton1.TabIndex = 5;
			this.nRadioButton1.TabStop = true;
			this.nRadioButton1.Text = "Placement Target 1";
			this.nRadioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nRadioButton2
			// 
			this.nRadioButton2.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton2.ButtonProperties.BorderOffset = 2;
			this.nRadioButton2.Location = new System.Drawing.Point(16, 168);
			this.nRadioButton2.Name = "nRadioButton2";
			this.nRadioButton2.Size = new System.Drawing.Size(192, 128);
			this.nRadioButton2.TabIndex = 6;
			this.nRadioButton2.Text = "Placement Target 2";
			this.nRadioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.nRadioButton1);
			this.nGroupBox1.Controls.Add(this.nRadioButton2);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(224, 312);
			this.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox1.TabIndex = 8;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Placement Targets";
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.ButtonProperties.BorderOffset = 2;
			this.nCheckBox1.Location = new System.Drawing.Point(24, 328);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(192, 24);
			this.nCheckBox1.TabIndex = 9;
			this.nCheckBox1.Text = "Host Calculator";
			// 
			// NPopupUC
			// 
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.showBtn);
			this.Controls.Add(this.propertyGrid);
			this.Name = "NPopupUC";
			this.Size = new System.Drawing.Size(528, 368);
			this.nGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NPopup m_Popup;

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton showBtn;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton1;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private System.Windows.Forms.PropertyGrid propertyGrid;

		#endregion
	}
}
