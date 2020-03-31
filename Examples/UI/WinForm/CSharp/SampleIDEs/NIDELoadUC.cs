using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NVS2005UC.
	/// </summary>
	public class NIDELoadUC : NExampleUserControl
	{
		#region Constructor

		public NIDELoadUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}
		static NIDELoadUC()
		{
			Type t = typeof(NIDELoadUC);
			string path = "Nevron.Examples.UI.WinForm.SampleIDEs.Bitmaps";
			StandardImageList = NResourceHelper.ImageListFromBitmap(t, new Size(16, 16), Color.Magenta, "IDEStandard.bmp", path);
			SolutionExplorerImageList = NResourceHelper.ImageListFromBitmap(t, new Size(16, 16), Color.Magenta, "SolutionExplorer.bmp", path);
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

		#region Implementation

		internal static bool IsFileBrowsable(FileInfo info)
		{
			string name = info.Extension.ToLower();
			int length = m_arrBrowsableFiles.Length;

			for(int i = 0; i < length; i++)
			{
				if(name == m_arrBrowsableFiles[i])
					return true;
			}

			return false;
		}

		internal static bool IsDirectoryBrowsable(DirectoryInfo info)
		{
			string name = info.Name;
			int length = m_arrNonBrowsableDirectories.Length;

			for(int i = 0; i < length; i++)
			{
				if(name == m_arrNonBrowsableDirectories[i])
					return false;
			}

			return true;
		}


		#endregion

		#region Event Handlers

		private void m_LoadButton_Click(object sender, System.EventArgs e)
		{
			TreeNode node = m_MainForm.NavigationTreeControl.NavigationTree.SelectedNode;
			if(node == null)
				return;

			//System.Windows.Forms.Cursor c = System.Windows.Forms.Cursor.Current;
			//System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			Form f = null;

			switch(node.Text)
			{
				case "Visual Studio":
					f = new NVisualStudioIDE(this);
					break;
			}

			f.Show();

			//System.Windows.Forms.Cursor.Current = c;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_LoadButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// m_LoadButton
			// 
			this.m_LoadButton.Location = new System.Drawing.Point(8, 16);
			this.m_LoadButton.Name = "m_LoadButton";
			this.m_LoadButton.Size = new System.Drawing.Size(184, 24);
			this.m_LoadButton.TabIndex = 0;
			this.m_LoadButton.Text = "Load Sample IDE";
			this.m_LoadButton.Click += new System.EventHandler(this.m_LoadButton_Click);
			// 
			// NIDELoadUC
			// 
			this.Controls.Add(this.m_LoadButton);
			this.Name = "NIDELoadUC";
			this.Size = new System.Drawing.Size(200, 56);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private NButton m_LoadButton;

		internal static ImageList StandardImageList;
		internal static ImageList SolutionExplorerImageList;

		internal static string[] m_arrBrowsableFiles = new string[]{".cs", ".ico", ".bmp"};
		internal static string[] m_arrNonBrowsableDirectories = new string[]{"bin", "obj", "HTML", "CustomPalettes"};

		#endregion

		internal enum RangeID
		{
			Standard,
			MenuBar
		}
		internal enum CommandID
		{
			//standard ids
			NewProject,
			NewBlankSolution,
			AddNewItem,
			AddExistingItem,
			AddWindowsForm,
			AddInheritedForm,
			AddUsercontrol,
			AddInheritedControl,
			AddComponent,
			AddClass,
			Open,
			Save,
			SaveAll,
			Cut,
			Copy,
			Paste,
			Undo,
			Redo,
			NavigateBackward,
			NavigateForward,
			StartContinue,
			SolutionConfigurations,
			SolutionExplorer,
			Properties,
			ObjectBrowser,
			Toolbox,
			ClassView,
			ServerExplorer,
			ResourceView,
			TaskList,
			Output,
			CommandWindow,
			FindSymbolResults,
			Exit,
			SelectAll
		}
	}
}
