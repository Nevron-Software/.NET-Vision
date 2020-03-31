using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NPaletteColorPane.
	/// </summary>
	public class NPaletteColorPaneUC : NExampleUserControl
	{
		#region Constructor

		public NPaletteColorPaneUC(MainForm f) : base(f)
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

			NArgbColorValuePalette palette = new NArgbColorValuePalette();
			palette.SetPredefinedPalette(PredefinedPalette.Office2003);

			paletteColorPane1.ColorPalette = palette;
			paletteColorPane1.MouseLeave +=new EventHandler(paletteColorPane1_MouseLeave);
		}



		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.paletteColorPane1 = new Nevron.UI.WinForm.Controls.NPaletteColorPane();
			this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nPaletteColorPane1 = new Nevron.UI.WinForm.Controls.NPaletteColorPane();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
			this.nEntryContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
			this.nEntryContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// paletteColorPane1
			// 
			this.paletteColorPane1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
			this.paletteColorPane1.Location = new System.Drawing.Point(109, 3);
			this.paletteColorPane1.Name = "paletteColorPane1";
			this.paletteColorPane1.Selectable = true;
			this.paletteColorPane1.Size = new System.Drawing.Size(179, 117);
			this.paletteColorPane1.TabIndex = 2;
			// 
			// nEntryContainer1
			// 
			this.nEntryContainer1.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer1.EntryControl = this.paletteColorPane1;
			this.nEntryContainer1.Item.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(204)), ((System.Byte)(0)), ((System.Byte)(0))));
			this.nEntryContainer1.Item.Style.TextShadowStyle = new Nevron.GraphicsCore.NShadowStyle(Nevron.GraphicsCore.ShadowType.LinearBlur, new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(128))), 1, 1, 1F, 1);
			this.nEntryContainer1.Location = new System.Drawing.Point(8, 8);
			this.nEntryContainer1.Name = "nEntryContainer1";
			this.nEntryContainer1.Size = new System.Drawing.Size(296, 128);
			this.nEntryContainer1.TabIndex = 4;
			this.nEntryContainer1.Text = "Office 2003 Palette:";
			// 
			// nEntryContainer2
			// 
			this.nEntryContainer2.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer2.EntryControl = this.nPaletteColorPane1;
			this.nEntryContainer2.Item.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(204)), ((System.Byte)(0)), ((System.Byte)(0))));
			this.nEntryContainer2.Item.Style.TextShadowStyle = new Nevron.GraphicsCore.NShadowStyle(Nevron.GraphicsCore.ShadowType.LinearBlur, new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(128))), 1, 1, 1F, 1);
			this.nEntryContainer2.Location = new System.Drawing.Point(8, 144);
			this.nEntryContainer2.Name = "nEntryContainer2";
			this.nEntryContainer2.Size = new System.Drawing.Size(296, 152);
			this.nEntryContainer2.TabIndex = 5;
			this.nEntryContainer2.Text = "Color Dialog Palette:";
			// 
			// nPaletteColorPane1
			// 
			this.nPaletteColorPane1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
			this.nPaletteColorPane1.Location = new System.Drawing.Point(111, 3);
			this.nPaletteColorPane1.Name = "nPaletteColorPane1";
			this.nPaletteColorPane1.PredefinedPalette = Nevron.GraphicsCore.PredefinedPalette.Default;
			this.nPaletteColorPane1.Selectable = true;
			this.nPaletteColorPane1.Size = new System.Drawing.Size(177, 141);
			this.nPaletteColorPane1.TabIndex = 2;
			// 
			// NPaletteColorPaneUC
			// 
			this.Controls.Add(this.nEntryContainer2);
			this.Controls.Add(this.nEntryContainer1);
			this.Name = "NPaletteColorPaneUC";
			this.Size = new System.Drawing.Size(312, 304);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
			this.nEntryContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
			this.nEntryContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
		private Nevron.UI.WinForm.Controls.NPaletteColorPane nPaletteColorPane1;
		private Nevron.UI.WinForm.Controls.NPaletteColorPane paletteColorPane1;

		#endregion

		private void paletteColorPane1_MouseLeave(object sender, EventArgs e)
		{
		}
	}
}