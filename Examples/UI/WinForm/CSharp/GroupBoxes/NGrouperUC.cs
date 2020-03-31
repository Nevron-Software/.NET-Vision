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
	/// Summary description for NGrouperUC.
	/// </summary>
	public class NGrouperUC : NExampleUserControl
	{
		#region Constructor

		public NGrouperUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
			nGrouper3.StrokeInfo.RoundingEdges = RoundingEdges.TopLeft | RoundingEdges.TopRight;
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
            base.Initialize();

            nButton1.TransparentBackground = true;
        }


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NGrouperUC));
			this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.nTextBox2 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nGrouper3 = new Nevron.UI.WinForm.Controls.NGrouper();
			((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
			this.nGrouper1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nGrouper3)).BeginInit();
			this.SuspendLayout();
			// 
			// nGrouper1
			// 
			this.nGrouper1.Controls.Add(this.nButton1);
			this.nGrouper1.Controls.Add(this.nTextBox2);
			this.nGrouper1.Controls.Add(this.label2);
			this.nGrouper1.Controls.Add(this.nTextBox1);
			this.nGrouper1.Controls.Add(this.label1);
			this.nGrouper1.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(90)), ((System.Byte)(125)), ((System.Byte)(222)));
			this.nGrouper1.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(155)), ((System.Byte)(186)), ((System.Byte)(247)));
			this.nGrouper1.FillInfo.GradientAngle = 15F;
			this.nGrouper1.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nGrouper1.FooterFillInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(51)), ((System.Byte)(153)));
			this.nGrouper1.FooterFillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Solid;
			this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper1.FooterItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))));
			this.nGrouper1.FooterItem.Text = "Provide user name and password";
			this.nGrouper1.FooterStrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(45)), ((System.Byte)(150)));
			this.nGrouper1.HeaderFillInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(51)), ((System.Byte)(153)));
			this.nGrouper1.HeaderFillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Solid;
			this.nGrouper1.HeaderItem.Image = ((System.Drawing.Image)(resources.GetObject("nGrouper1.HeaderItem.Image")));
			this.nGrouper1.HeaderItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper1.HeaderItem.ImageSize = new Nevron.GraphicsCore.NSize(32, 32);
			this.nGrouper1.HeaderItem.ImageTextRelation = Nevron.UI.ImageTextRelation.TextBeforeImage;
			this.nGrouper1.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
			this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))));
			this.nGrouper1.HeaderItem.Text = "Login";
			this.nGrouper1.HeaderItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nGrouper1.HeaderItem.TreatAsOneEntity = false;
			this.nGrouper1.HeaderStrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(45)), ((System.Byte)(150)));
			this.nGrouper1.Location = new System.Drawing.Point(8, 8);
			this.nGrouper1.Name = "nGrouper1";
			this.nGrouper1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
			this.nGrouper1.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nGrouper1.Size = new System.Drawing.Size(232, 216);
			this.nGrouper1.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(45)), ((System.Byte)(150)));
			this.nGrouper1.TabIndex = 0;
			this.nGrouper1.Text = "nGrouper1";
			// 
			// nButton1
			// 
			this.nButton1.Location = new System.Drawing.Point(128, 128);
			this.nButton1.Name = "nButton1";
			this.nButton1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
			this.nButton1.Size = new System.Drawing.Size(72, 24);
			this.nButton1.TabIndex = 4;
			this.nButton1.Text = "Login";
			// 
			// nTextBox2
			// 
			this.nTextBox2.Location = new System.Drawing.Point(96, 104);
			this.nTextBox2.Name = "nTextBox2";
			this.nTextBox2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
			this.nTextBox2.PasswordChar = '*';
			this.nTextBox2.Size = new System.Drawing.Size(104, 18);
			this.nTextBox2.TabIndex = 3;
			this.nTextBox2.Text = "Password";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(8, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nTextBox1
			// 
			this.nTextBox1.Location = new System.Drawing.Point(96, 80);
			this.nTextBox1.Name = "nTextBox1";
			this.nTextBox1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
			this.nTextBox1.Size = new System.Drawing.Size(104, 18);
			this.nTextBox1.TabIndex = 1;
			this.nTextBox1.Text = "User";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nGrouper3
			// 
			this.nGrouper3.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(221)), ((System.Byte)(221)), ((System.Byte)(221)));
			this.nGrouper3.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.nGrouper3.FooterFillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(90)), ((System.Byte)(89)), ((System.Byte)(89)));
			this.nGrouper3.FooterFillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(48)), ((System.Byte)(47)), ((System.Byte)(47)));
			this.nGrouper3.FooterFillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nGrouper3.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper3.FooterItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))));
			this.nGrouper3.FooterItem.Text = "Footer";
			this.nGrouper3.FooterStrokeInfo.Draw = false;
			this.nGrouper3.HeaderFillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(48)), ((System.Byte)(47)), ((System.Byte)(47)));
			this.nGrouper3.HeaderFillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(90)), ((System.Byte)(89)), ((System.Byte)(89)));
			this.nGrouper3.HeaderFillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nGrouper3.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
			this.nGrouper3.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))));
			this.nGrouper3.HeaderItem.Text = "Header";
			this.nGrouper3.HeaderStrokeInfo.Draw = false;
			this.nGrouper3.HeaderStrokeInfo.Rounding = 5;
			this.nGrouper3.Location = new System.Drawing.Point(240, 8);
			this.nGrouper3.Name = "nGrouper3";
			this.nGrouper3.ShadowInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(51)), ((System.Byte)(51)));
			this.nGrouper3.Size = new System.Drawing.Size(240, 216);
			this.nGrouper3.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nGrouper3.StrokeInfo.Rounding = 5;
			this.nGrouper3.TabIndex = 2;
			this.nGrouper3.Text = "nGrouper3";
			// 
			// NGrouperUC
			// 
			this.Controls.Add(this.nGrouper3);
			this.Controls.Add(this.nGrouper1);
			this.Name = "NGrouperUC";
			this.Size = new System.Drawing.Size(488, 232);
			((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
			this.nGrouper1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nGrouper3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGrouper nGrouper1;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox2;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private Nevron.UI.WinForm.Controls.NGrouper nGrouper3;

		#endregion
	}
}
