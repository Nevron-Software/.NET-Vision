using System;
using System.Reflection;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

using Nevron.Globalization;
using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;
using Nevron.Examples.Framework.WinForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : NExamplesForm
	{
		#region Constructor

		public MainForm()
		{
			InitializeComponent();

			InitFromConfig(new NUIExamplesConfig());

			Size = new Size(800, 600);
		}

		static MainForm()
		{
			Type t = typeof(MainForm);
			string path = "Nevron.Examples.UI.WinForm.Resources";

			StandardImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Silver, "Standard.bmp", path);
			ActionImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Magenta, "Action.bmp", path);
			LayoutImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Magenta, "Layout.bmp", path);
			ToolsImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Magenta, "Tools.bmp", path);
			ViewImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Magenta, "View.bmp", path);
			TestImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Magenta, "Test.bmp", path);
			FormatImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Magenta, "Format.bmp", path);
			MiscImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Magenta, "Misc.bmp", path);
			DockingImages = NResourceHelper.ImageListFromBitmap(typeof(MainForm), new Size(16, 16), Color.Magenta, "Docking.bmp", path);
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

		public override void LoadNavigationTree()
		{
			TreeView tree = NavigationTreeControl.NavigationTree;
			tree.Nodes.Clear();

			NExampleFolderEntity rootFolder = NExamplesHelper.LoadExamplesTree(Config.EmbeddedResourcesAssembly, Config.TreeResource, Config.TreeResourcePath);
			tree.Nodes.Add(LoadTreeFolder( string.Empty, rootFolder ));
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.Name = "MainForm";
			this.Text = "MainForm";

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		internal static ImageList StandardImages;
		internal static ImageList ActionImages;
		internal static ImageList LayoutImages;
		internal static ImageList ToolsImages;
		internal static ImageList ViewImages;
		internal static ImageList FormatImages;
		internal static ImageList MiscImages;
		internal static ImageList DockingImages;
		internal static ImageList TestImages;

		#endregion

		#region Main

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Application.DoEvents();
			MainForm form = new MainForm();

			//try
			//{
				Application.Run(form);
			//}
			/*catch
			{
			}*/
		 }

		#endregion
	}
}
