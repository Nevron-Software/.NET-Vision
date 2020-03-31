using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NDocumentViewForm.
	/// </summary>
	public class NDocumentViewForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NDocumentViewForm()
		{
			InitializeComponent();

			m_PropertyGrid.SelectedObject = m_DockManager.DocumentStyle;

			m_DockManager.DocumentStyle.AllowTabReorder = false;
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
		protected override void InitPanels()
		{
			m_DockManager.DocumentStyle.ImageList = MainForm.StandardImages;
			m_DockManager.DocumentManager.ActiveDocumentChanged += new DocumentEventHandler(DocumentManager_ActiveDocumentChanged);

			NUIDocument doc;
			TextBox tb;

			Label lb = new Label();
			lb.Dock = DockStyle.Fill;
			lb.BackColor = Color.SaddleBrown;

			tb = GetTextBox();
			tb.BorderStyle = BorderStyle.None;
			tb.Text = "Text";
			tb.ScrollBars = ScrollBars.Both;
			tb.WordWrap = false;
			doc = new NUIDocument("Document 1", -1, tb);
			m_DockManager.DocumentManager.AddDocument(doc);

			tb = GetTextBox();
			tb.BorderStyle = BorderStyle.None;
			tb.Text = "Document 2";
			doc = new NUIDocument("Document 2", 0, tb);
			m_DockManager.DocumentManager.AddDocument(doc);

			tb = GetTextBox(); 
			tb.BorderStyle = BorderStyle.None;
			tb.Text = "Document 3";
			doc = new NUIDocument("Document 3", 0, tb);
			m_DockManager.DocumentManager.AddDocument(doc);

			NDockingPanel panel;

			panel = new NDockingPanel();
			panel.Caption.ImageIndex = 0;
			panel.Caption.ImageList = MainForm.ActionImages;
			panel.Caption.ImageSize = new Size(20, 20);
			panel.Controls.Add(GetTextBox());
			panel.PerformDock(m_DockManager.DocumentManager.DocumentViewHost, DockStyle.Bottom);

			panel = new NDockingPanel();
			panel.Text = "Document Style";
			panel.TabInfo.Text = "Document Style";
			m_PropertyGrid.Dock = DockStyle.Fill;
			panel.Controls.Add(m_PropertyGrid);
			panel.PerformDock(m_DockManager.RootContainer.RootZone, DockStyle.Right);
		}

		protected override void InitCommandBars()
		{
			base.InitCommandBars();

			NCommand comm, comm1;
			NMenuBar bar = nCommandBarsManager1.Toolbars.GetMenu();

			comm = new NCommand();
			comm.Properties.Text = "Document";
			bar.Commands.Add(comm);

			comm1 = new NCommand();
			comm1.Properties.Text = "&New Document";
			comm1.Properties.ID = 0;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.Text = "&Close Document";
			comm1.Properties.ID = 1;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.Text = "Close &All Documents";
			comm1.Properties.ID = 2;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.Text = "Close All &But Active";
			comm1.Properties.ID = 8;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.BeginGroup = true;
			comm1.Properties.Text = "Tile &Horizontally";
			comm1.Properties.ID = 3;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.Text = "Tile &Vertically";
			comm1.Properties.ID = 4;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.Text = "Ca&scade";
			comm1.Properties.ID = 5;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.Text = "Arrange &Icons";
			comm1.Properties.ID = 6;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.BeginGroup = true;
			comm1.Properties.Text = "&Documents...";
			comm1.Properties.ID = 7;
			comm.Commands.Add(comm1);
		}
		protected override void nCommandBarsManager1_CommandClicked(object sender, CommandEventArgs e)
		{
			NCommand comm = e.Command;
			int id = comm.Properties.ID;

			NDocumentManager manager = m_DockManager.DocumentManager;

			switch(id)
			{
				case 0:
					for(int i = 0; i < 1; i++)
					{
						int index = manager.Documents.Length + 1;
						TextBox tb = GetTextBox();
						tb.BorderStyle = BorderStyle.None;

						NUIDocument doc = new NUIDocument("Document " + index.ToString(), 0, tb);
						manager.AddDocument(doc);
					}
					break;
				case 1:
					manager.CloseActiveDocument();
					break;
				case 2:
					manager.CloseAllDocuments();
					break;
				case 3:
					manager.LayoutMdi(MdiLayout.TileHorizontal);
					break;
				case 4:
					manager.LayoutMdi(MdiLayout.TileVertical);
					break;
				case 5:
					manager.LayoutMdi(MdiLayout.Cascade);
					break;
				case 6:
					manager.LayoutMdi(MdiLayout.ArrangeIcons);
					break;
				case 7:
					manager.ShowDocumentsEditor();
					break;
				case 8:
					manager.CloseAllButActive();
					break;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			//m_DockManager.DocumentManager.Documents[0].Activate();
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
			// NDocumentViewForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Name = "NDocumentViewForm";
			this.Text = "Document View Example";

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion

		private void DocumentManager_ActiveDocumentChanged(object sender, DocumentEventArgs e)
		{
			Debug.WriteLine("Document changed...");
		}
	}
}
