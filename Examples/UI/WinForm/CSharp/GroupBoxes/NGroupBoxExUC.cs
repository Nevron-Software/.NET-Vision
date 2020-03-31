using System;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;


namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NGroupBoxEx.
	/// </summary>
	public class NGroupBoxExUC : NExampleUserControl
	{
		#region Constructor

		public NGroupBoxExUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Component Designer generated code

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NGroupBoxExUC));
			this.nGroupBoxEx1 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
			this.nRadioButton1 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nColorPool1 = new Nevron.UI.WinForm.Controls.NColorPool();
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).BeginInit();
			this.nGroupBoxEx1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nGroupBoxEx1
			// 
			this.nGroupBoxEx1.Controls.Add(this.nRadioButton1);
			this.nGroupBoxEx1.Controls.Add(this.nCheckBox1);
			this.nGroupBoxEx1.Controls.Add(this.nColorPool1);
			this.nGroupBoxEx1.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(153)), ((System.Byte)(204)), ((System.Byte)(255)));
			this.nGroupBoxEx1.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText;
			this.nGroupBoxEx1.FillInfo.GradientAngle = 45F;
			this.nGroupBoxEx1.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista;
			this.nGroupBoxEx1.HeaderFillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(102)), ((System.Byte)(204)));
			this.nGroupBoxEx1.HeaderFillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText;
			this.nGroupBoxEx1.HeaderFillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista;
			this.nGroupBoxEx1.HeaderItem.Image = ((System.Drawing.Image)(resources.GetObject("nGroupBoxEx1.HeaderItem.Image")));
			this.nGroupBoxEx1.HeaderItem.ImageSize = new Nevron.GraphicsCore.NSize(24, 24);
			this.nGroupBoxEx1.HeaderItem.Text = "NGroupBoxEx";
			this.nGroupBoxEx1.HeaderStrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(51)), ((System.Byte)(153)));
			this.nGroupBoxEx1.HeaderStrokeInfo.Rounding = 5;
			this.nGroupBoxEx1.Location = new System.Drawing.Point(16, 16);
			this.nGroupBoxEx1.Name = "nGroupBoxEx1";
			this.nGroupBoxEx1.Size = new System.Drawing.Size(432, 272);
			this.nGroupBoxEx1.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(102)), ((System.Byte)(204)));
			this.nGroupBoxEx1.StrokeInfo.PenWidth = 5;
			this.nGroupBoxEx1.StrokeInfo.Rounding = 5;
			this.nGroupBoxEx1.TabIndex = 0;
			this.nGroupBoxEx1.Text = "nGroupBoxEx1";
			// 
			// nRadioButton1
			// 
			this.nRadioButton1.Location = new System.Drawing.Point(264, 152);
			this.nRadioButton1.Name = "nRadioButton1";
			this.nRadioButton1.TabIndex = 5;
			this.nRadioButton1.Text = "nRadioButton1";
			this.nRadioButton1.TransparentBackground = true;
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Location = new System.Drawing.Point(264, 104);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.TabIndex = 4;
			this.nCheckBox1.Text = "nCheckBox1";
			this.nCheckBox1.TransparentBackground = true;
			// 
			// nColorPool1
			// 
			this.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nColorPool1.Color = System.Drawing.Color.Empty;
			this.nColorPool1.Hue = 0F;
			this.nColorPool1.Location = new System.Drawing.Point(48, 96);
			this.nColorPool1.Luminance = 0.5F;
			this.nColorPool1.Name = "nColorPool1";
			this.nColorPool1.Saturation = 0F;
			this.nColorPool1.Size = new System.Drawing.Size(202, 102);
			this.nColorPool1.TabIndex = 2;
			// 
			// NGroupBoxExUC
			// 
			this.Controls.Add(this.nGroupBoxEx1);
			this.Name = "NGroupBoxExUC";
			this.Size = new System.Drawing.Size(512, 352);
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).EndInit();
			this.nGroupBoxEx1.ResumeLayout(false);
			this.ResumeLayout(false);

		}


		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx1;
		private Nevron.UI.WinForm.Controls.NColorPool nColorPool1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton1;

		#endregion
	}
}
