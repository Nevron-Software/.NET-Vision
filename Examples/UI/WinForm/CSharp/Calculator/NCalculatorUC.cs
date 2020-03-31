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
	/// Summary description for NCalculatorUC.
	/// </summary>
	public class NCalculatorUC : NExampleUserControl
	{
		#region Constructor

		public NCalculatorUC()
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


		#endregion

		#region Event Handlers

		private void digitGroupCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nCalculator1.DigitGroupSeparator = digitGroupCheck.Checked;
			nCalculator2.DigitGroupSeparator = digitGroupCheck.Checked;
		}
		private void showDisplayCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nCalculator1.ShowDisplay = showDisplayCheck.Checked;
			nCalculator2.ShowDisplay = showDisplayCheck.Checked;
		}
		private void buttonFontBtn_Click(object sender, System.EventArgs e)
		{
			FontDialog dlg = new FontDialog();
			dlg.Font = nCalculator1.ButtonFont;

			if(dlg.ShowDialog() != DialogResult.OK)
				return;

			nCalculator1.ButtonFont = dlg.Font;
			nCalculator2.ButtonFont = dlg.Font;
		}
		private void nButton1_Click(object sender, System.EventArgs e)
		{
			nCalculator1.ButtonFont = null;
			nCalculator2.ButtonFont = null;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nCalculator1 = new Nevron.UI.WinForm.Controls.NCalculator();
			this.nCalculator2 = new Nevron.UI.WinForm.Controls.NCalculator();
			this.calcInstancesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.buttonFontBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.digitGroupCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.showDisplayCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.nCalculator1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nCalculator2)).BeginInit();
			this.calcInstancesGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// nCalculator1
			// 
			this.nCalculator1.Location = new System.Drawing.Point(8, 16);
			this.nCalculator1.Name = "nCalculator1";
			this.nCalculator1.Size = new System.Drawing.Size(245, 213);
			this.nCalculator1.TabIndex = 0;
			this.nCalculator1.Text = "nCalculator1";
			// 
			// nCalculator2
			// 
			this.nCalculator2.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(204)));
			this.nCalculator2.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(153)), ((System.Byte)(102)));
			this.nCalculator2.Location = new System.Drawing.Point(264, 16);
			this.nCalculator2.Name = "nCalculator2";
            this.nCalculator2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
			this.nCalculator2.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
			this.nCalculator2.Palette.ControlBorder = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(102)), ((System.Byte)(0)));
			this.nCalculator2.Palette.ControlDark = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(153)), ((System.Byte)(102)));
			this.nCalculator2.Palette.ControlLight = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(153)));
			this.nCalculator2.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nCalculator2.Size = new System.Drawing.Size(243, 213);
			this.nCalculator2.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(102)), ((System.Byte)(0)));
			this.nCalculator2.StrokeInfo.PenWidth = 3;
			this.nCalculator2.StrokeInfo.Rounding = 5;
			this.nCalculator2.TabIndex = 1;
			this.nCalculator2.Text = "nCalculator2";
			// 
			// calcInstancesGroup
			// 
			this.calcInstancesGroup.Controls.Add(this.nCalculator1);
			this.calcInstancesGroup.Controls.Add(this.nCalculator2);
			this.calcInstancesGroup.ImageIndex = 0;
			this.calcInstancesGroup.Location = new System.Drawing.Point(8, 8);
			this.calcInstancesGroup.Name = "calcInstancesGroup";
			this.calcInstancesGroup.Size = new System.Drawing.Size(512, 232);
			this.calcInstancesGroup.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.calcInstancesGroup.TabIndex = 2;
			this.calcInstancesGroup.TabStop = false;
			this.calcInstancesGroup.Text = "Calculator Instances";
			// 
			// buttonFontBtn
			// 
			this.buttonFontBtn.Location = new System.Drawing.Point(8, 312);
			this.buttonFontBtn.Name = "buttonFontBtn";
			this.buttonFontBtn.Size = new System.Drawing.Size(88, 24);
			this.buttonFontBtn.TabIndex = 3;
			this.buttonFontBtn.Text = "Button Font...";
			this.buttonFontBtn.Click += new System.EventHandler(this.buttonFontBtn_Click);
			// 
			// digitGroupCheck
			// 
			this.digitGroupCheck.ButtonProperties.BorderOffset = 2;
			this.digitGroupCheck.Checked = true;
			this.digitGroupCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.digitGroupCheck.Location = new System.Drawing.Point(8, 256);
			this.digitGroupCheck.Name = "digitGroupCheck";
			this.digitGroupCheck.Size = new System.Drawing.Size(192, 24);
			this.digitGroupCheck.TabIndex = 4;
			this.digitGroupCheck.Text = "Digit Group Separator";
			this.digitGroupCheck.CheckedChanged += new System.EventHandler(this.digitGroupCheck_CheckedChanged);
			// 
			// showDisplayCheck
			// 
			this.showDisplayCheck.ButtonProperties.BorderOffset = 2;
			this.showDisplayCheck.Checked = true;
			this.showDisplayCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDisplayCheck.Location = new System.Drawing.Point(8, 280);
			this.showDisplayCheck.Name = "showDisplayCheck";
			this.showDisplayCheck.Size = new System.Drawing.Size(192, 24);
			this.showDisplayCheck.TabIndex = 5;
			this.showDisplayCheck.Text = "Show Display";
			this.showDisplayCheck.CheckedChanged += new System.EventHandler(this.showDisplayCheck_CheckedChanged);
			// 
			// nButton1
			// 
			this.nButton1.Location = new System.Drawing.Point(104, 312);
			this.nButton1.Name = "nButton1";
			this.nButton1.Size = new System.Drawing.Size(104, 24);
			this.nButton1.TabIndex = 6;
			this.nButton1.Text = "Reset Button Font";
			this.nButton1.Click += new System.EventHandler(this.nButton1_Click);
			// 
			// NCalculatorUC
			// 
			this.Controls.Add(this.nButton1);
			this.Controls.Add(this.showDisplayCheck);
			this.Controls.Add(this.digitGroupCheck);
			this.Controls.Add(this.buttonFontBtn);
			this.Controls.Add(this.calcInstancesGroup);
			this.Name = "NCalculatorUC";
			this.Size = new System.Drawing.Size(528, 344);
			((System.ComponentModel.ISupportInitialize)(this.nCalculator1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nCalculator2)).EndInit();
			this.calcInstancesGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NCalculator nCalculator1;
		private Nevron.UI.WinForm.Controls.NCalculator nCalculator2;
		private Nevron.UI.WinForm.Controls.NGroupBox calcInstancesGroup;
		private Nevron.UI.WinForm.Controls.NButton buttonFontBtn;
		private Nevron.UI.WinForm.Controls.NCheckBox digitGroupCheck;
		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private Nevron.UI.WinForm.Controls.NCheckBox showDisplayCheck;

		#endregion
	}
}
