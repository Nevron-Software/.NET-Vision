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
	/// Summary description for NCustomExpanderUC.
	/// </summary>
	public class NCustomExpanderUC : NExampleUserControl
	{
		#region Constructor

		public NCustomExpanderUC(MainForm f) : base(f)
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NCustomExpanderUC));
			this.nExpander1 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nShadowDecorator2 = new Nevron.UI.WinForm.Controls.NShadowDecorator();
			this.nComboBox2 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nExpander2 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nShadowDecorator1 = new Nevron.UI.WinForm.Controls.NShadowDecorator();
			this.nComboBox1 = new Nevron.UI.WinForm.Controls.NComboBox();
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).BeginInit();
			this.nExpander1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).BeginInit();
			this.nExpander2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator1)).BeginInit();
			this.SuspendLayout();
			// 
			// nExpander1
			// 
			this.nExpander1.ArrowImageSet.CollapseHot = ((System.Drawing.Image)(resources.GetObject("nExpander1.ArrowImageSet.CollapseHot")));
			this.nExpander1.ArrowImageSet.CollapseNormal = ((System.Drawing.Image)(resources.GetObject("nExpander1.ArrowImageSet.CollapseNormal")));
			this.nExpander1.ArrowImageSet.ExpandHot = ((System.Drawing.Image)(resources.GetObject("nExpander1.ArrowImageSet.ExpandHot")));
			this.nExpander1.ArrowImageSet.ExpandNormal = ((System.Drawing.Image)(resources.GetObject("nExpander1.ArrowImageSet.ExpandNormal")));
			this.nExpander1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.nExpander1.Controls.Add(this.nShadowDecorator2);
			this.nExpander1.Controls.Add(this.nComboBox2);
			this.nExpander1.DrawBorder = true;
			this.nExpander1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander1.HeaderImage")));
			this.nExpander1.HeaderImageSize = new System.Drawing.Size(28, 28);
			this.nExpander1.Location = new System.Drawing.Point(8, 8);
			this.nExpander1.Name = "nExpander1";
			this.nExpander1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
			this.nExpander1.Palette.ControlBorder = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(170)));
			this.nExpander1.Palette.ControlLight = System.Drawing.Color.WhiteSmoke;
			this.nExpander1.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nExpander1.Size = new System.Drawing.Size(216, 176);
			this.nExpander1.TabIndex = 0;
			this.nExpander1.Text = "nExpander1";
			// 
			// nShadowDecorator2
			// 
			this.nShadowDecorator2.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Gel;
			this.nShadowDecorator2.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(51)), ((System.Byte)(0)));
			this.nShadowDecorator2.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(204)));
			this.nShadowDecorator2.Location = new System.Drawing.Point(12, 72);
			this.nShadowDecorator2.Name = "nShadowDecorator2";
			this.nShadowDecorator2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
			this.nShadowDecorator2.Palette.ControlBorder = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(170)));
			this.nShadowDecorator2.Palette.ControlLight = System.Drawing.Color.WhiteSmoke;
			this.nShadowDecorator2.ShadowInfo.Draw = false;
			this.nShadowDecorator2.Size = new System.Drawing.Size(192, 96);
			this.nShadowDecorator2.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(153)));
			this.nShadowDecorator2.StrokeInfo.PenWidth = 5;
			this.nShadowDecorator2.StrokeInfo.Rounding = 10;
			this.nShadowDecorator2.TabIndex = 3;
			this.nShadowDecorator2.Text = "nShadowDecorator2";
			// 
			// nComboBox2
			// 
			this.nComboBox2.Location = new System.Drawing.Point(12, 40);
			this.nComboBox2.Name = "nComboBox2";
			this.nComboBox2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
			this.nComboBox2.Palette.ControlBorder = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(170)));
			this.nComboBox2.Palette.ControlLight = System.Drawing.Color.WhiteSmoke;
			this.nComboBox2.Size = new System.Drawing.Size(192, 22);
			this.nComboBox2.TabIndex = 2;
			this.nComboBox2.Text = "nComboBox2";
			// 
			// nExpander2
			// 
			this.nExpander2.ArrowImageSet.CollapseHot = ((System.Drawing.Image)(resources.GetObject("nExpander2.ArrowImageSet.CollapseHot")));
			this.nExpander2.ArrowImageSet.CollapseNormal = ((System.Drawing.Image)(resources.GetObject("nExpander2.ArrowImageSet.CollapseNormal")));
			this.nExpander2.ArrowImageSet.ExpandHot = ((System.Drawing.Image)(resources.GetObject("nExpander2.ArrowImageSet.ExpandHot")));
			this.nExpander2.ArrowImageSet.ExpandNormal = ((System.Drawing.Image)(resources.GetObject("nExpander2.ArrowImageSet.ExpandNormal")));
			this.nExpander2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(214)), ((System.Byte)(223)), ((System.Byte)(247)));
			this.nExpander2.Controls.Add(this.nShadowDecorator1);
			this.nExpander2.Controls.Add(this.nComboBox1);
			this.nExpander2.DrawBorder = true;
			this.nExpander2.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander2.HeaderImage")));
			this.nExpander2.HeaderImageSize = new System.Drawing.Size(28, 28);
			this.nExpander2.Location = new System.Drawing.Point(8, 208);
			this.nExpander2.Name = "nExpander2";
            this.nExpander2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
			this.nExpander2.Palette.ControlBorder = System.Drawing.SystemColors.ActiveCaptionText;
			this.nExpander2.Palette.ControlLight = System.Drawing.Color.FromArgb(((System.Byte)(214)), ((System.Byte)(223)), ((System.Byte)(247)));
			this.nExpander2.Palette.ControlText = System.Drawing.SystemColors.ActiveCaptionText;
			this.nExpander2.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nExpander2.Size = new System.Drawing.Size(216, 192);
			this.nExpander2.TabIndex = 1;
			this.nExpander2.Text = "nExpander2";
			// 
			// nShadowDecorator1
			// 
			this.nShadowDecorator1.BackColor = System.Drawing.Color.Transparent;
			this.nShadowDecorator1.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Gel;
			this.nShadowDecorator1.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(255)));
			this.nShadowDecorator1.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(204)), ((System.Byte)(236)), ((System.Byte)(255)));
			this.nShadowDecorator1.Location = new System.Drawing.Point(8, 72);
			this.nShadowDecorator1.Name = "nShadowDecorator1";
            this.nShadowDecorator1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
			this.nShadowDecorator1.Palette.ControlBorder = System.Drawing.SystemColors.ActiveCaptionText;
			this.nShadowDecorator1.Palette.ControlLight = System.Drawing.Color.FromArgb(((System.Byte)(214)), ((System.Byte)(223)), ((System.Byte)(247)));
			this.nShadowDecorator1.Palette.ControlText = System.Drawing.SystemColors.ActiveCaptionText;
			this.nShadowDecorator1.ShadowInfo.Draw = false;
			this.nShadowDecorator1.Size = new System.Drawing.Size(192, 96);
			this.nShadowDecorator1.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(153)));
			this.nShadowDecorator1.StrokeInfo.PenWidth = 5;
			this.nShadowDecorator1.StrokeInfo.Rounding = 10;
			this.nShadowDecorator1.TabIndex = 1;
			this.nShadowDecorator1.Text = "nShadowDecorator1";
			// 
			// nComboBox1
			// 
			this.nComboBox1.Location = new System.Drawing.Point(8, 40);
			this.nComboBox1.Name = "nComboBox1";
            this.nComboBox1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
			this.nComboBox1.Palette.ControlBorder = System.Drawing.SystemColors.ActiveCaptionText;
			this.nComboBox1.Palette.ControlLight = System.Drawing.Color.FromArgb(((System.Byte)(214)), ((System.Byte)(223)), ((System.Byte)(247)));
			this.nComboBox1.Palette.ControlText = System.Drawing.SystemColors.ActiveCaptionText;
			this.nComboBox1.Size = new System.Drawing.Size(192, 22);
			this.nComboBox1.TabIndex = 0;
			this.nComboBox1.Text = "nComboBox1";
			// 
			// NCustomExpanderUC
			// 
			this.Controls.Add(this.nExpander2);
			this.Controls.Add(this.nExpander1);
			this.Name = "NCustomExpanderUC";
			this.Size = new System.Drawing.Size(240, 416);
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).EndInit();
			this.nExpander1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).EndInit();
			this.nExpander2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private Nevron.UI.WinForm.Controls.NExpander nExpander1;
		private Nevron.UI.WinForm.Controls.NExpander nExpander2;
		private Nevron.UI.WinForm.Controls.NComboBox nComboBox1;
		private Nevron.UI.WinForm.Controls.NShadowDecorator nShadowDecorator1;
		private Nevron.UI.WinForm.Controls.NShadowDecorator nShadowDecorator2;
		private Nevron.UI.WinForm.Controls.NComboBox nComboBox2;

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
