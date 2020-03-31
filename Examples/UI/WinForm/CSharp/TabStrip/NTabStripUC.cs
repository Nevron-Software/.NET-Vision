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
	/// Summary description for NTabStripUC.
	/// </summary>
	public class NTabStripUC : NExampleUserControl
	{
		#region Constructor

		public NTabStripUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
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

			NTab tab;

			foreach(NTabStrip strip in Controls)
			{
				strip.PaletteInheritance = PaletteInheritance.None;
				strip.ImageList = m_ImageList;

				for(int i = 0; i < 5; i++)
				{
					tab = new NTab();
					tab.ImageIndex = i;
					strip.Tabs.Add(tab);
				}
			}

			this.nTabStrip5.ShowFocusRect = false;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NTabStripUC));
			this.nTabStrip1 = new Nevron.UI.WinForm.Controls.NTabStrip();
			this.nTabStrip2 = new Nevron.UI.WinForm.Controls.NTabStrip();
			this.nTabStrip3 = new Nevron.UI.WinForm.Controls.NTabStrip();
			this.nTabStrip4 = new Nevron.UI.WinForm.Controls.NTabStrip();
			this.nTabStrip5 = new Nevron.UI.WinForm.Controls.NTabStrip();
			this.m_ImageList = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// nTabStrip1
			// 
			this.nTabStrip1.Cursor = System.Windows.Forms.Cursors.Default;
			this.nTabStrip1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nTabStrip1.Location = new System.Drawing.Point(0, 0);
			this.nTabStrip1.Name = "nTabStrip1";
			this.nTabStrip1.Selectable = true;
			this.nTabStrip1.SelectedIndex = -1;
			this.nTabStrip1.Size = new System.Drawing.Size(448, 25);
			this.nTabStrip1.TabIndex = 0;
			this.nTabStrip1.Text = "nTabStrip1";
			// 
			// nTabStrip2
			// 
			this.nTabStrip2.Cursor = System.Windows.Forms.Cursors.Default;
			this.nTabStrip2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nTabStrip2.Location = new System.Drawing.Point(0, 25);
			this.nTabStrip2.Name = "nTabStrip2";
			this.nTabStrip2.Palette.UseThemes = false;
			this.nTabStrip2.Selectable = true;
			this.nTabStrip2.SelectedIndex = -1;
			this.nTabStrip2.Size = new System.Drawing.Size(448, 69);
			this.nTabStrip2.TabIndex = 1;
			this.nTabStrip2.Text = "nTabStrip2";
			this.nTabStrip2.TextOrientation = Nevron.UI.TextOrientation.Vertical90;
			// 
			// nTabStrip3
			// 
			this.nTabStrip3.Cursor = System.Windows.Forms.Cursors.Default;
			this.nTabStrip3.Dock = System.Windows.Forms.DockStyle.Left;
			this.nTabStrip3.Location = new System.Drawing.Point(0, 94);
			this.nTabStrip3.Name = "nTabStrip3";
			this.nTabStrip3.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
			this.nTabStrip3.Selectable = true;
			this.nTabStrip3.SelectedIndex = -1;
			this.nTabStrip3.Size = new System.Drawing.Size(70, 219);
			this.nTabStrip3.TabAlign = Nevron.UI.WinForm.Controls.TabAlign.Right;
			this.nTabStrip3.TabCurveWidth = 0;
			this.nTabStrip3.TabIndex = 2;
			this.nTabStrip3.Text = "nTabStrip3";
			// 
			// nTabStrip4
			// 
			this.nTabStrip4.Cursor = System.Windows.Forms.Cursors.Default;
			this.nTabStrip4.Dock = System.Windows.Forms.DockStyle.Right;
			this.nTabStrip4.Location = new System.Drawing.Point(423, 94);
			this.nTabStrip4.Name = "nTabStrip4";
			this.nTabStrip4.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Energy;
			this.nTabStrip4.Selectable = true;
			this.nTabStrip4.SelectedIndex = -1;
			this.nTabStrip4.Size = new System.Drawing.Size(25, 219);
			this.nTabStrip4.TabAlign = Nevron.UI.WinForm.Controls.TabAlign.Left;
			this.nTabStrip4.TabFitMode = Nevron.UI.WinForm.Controls.TabFitMode.Shrink;
			this.nTabStrip4.TabIndex = 3;
			this.nTabStrip4.TabStyle = Nevron.UI.WinForm.Controls.TabStyle.Buttons;
			this.nTabStrip4.Text = "nTabStrip4";
			// 
			// nTabStrip5
			// 
			this.nTabStrip5.AllowTabReorder = true;
			this.nTabStrip5.Cursor = System.Windows.Forms.Cursors.Default;
			this.nTabStrip5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.nTabStrip5.Location = new System.Drawing.Point(0, 313);
			this.nTabStrip5.Name = "nTabStrip5";
			this.nTabStrip5.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Standard;
			this.nTabStrip5.Selectable = true;
			this.nTabStrip5.SelectedIndex = -1;
			this.nTabStrip5.Size = new System.Drawing.Size(448, 23);
			this.nTabStrip5.TabAlign = Nevron.UI.WinForm.Controls.TabAlign.Bottom;
			this.nTabStrip5.TabFitMode = Nevron.UI.WinForm.Controls.TabFitMode.Shrink;
			this.nTabStrip5.TabIndex = 4;
			this.nTabStrip5.TabStyle = Nevron.UI.WinForm.Controls.TabStyle.MultiDocument;
			this.nTabStrip5.Text = "nTabStrip5";
			// 
			// m_ImageList
			// 
			this.m_ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImageList.ImageStream")));
			this.m_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// NTabStripUC
			// 
			this.Controls.Add(this.nTabStrip4);
			this.Controls.Add(this.nTabStrip3);
			this.Controls.Add(this.nTabStrip2);
			this.Controls.Add(this.nTabStrip1);
			this.Controls.Add(this.nTabStrip5);
			this.Name = "NTabStripUC";
			this.Size = new System.Drawing.Size(448, 336);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.IContainer components;
		private Nevron.UI.WinForm.Controls.NTabStrip nTabStrip1;
		private Nevron.UI.WinForm.Controls.NTabStrip nTabStrip2;
		private Nevron.UI.WinForm.Controls.NTabStrip nTabStrip3;
		private Nevron.UI.WinForm.Controls.NTabStrip nTabStrip4;
		private System.Windows.Forms.ImageList m_ImageList;
		private Nevron.UI.WinForm.Controls.NTabStrip nTabStrip5;

		#endregion
	}
}
