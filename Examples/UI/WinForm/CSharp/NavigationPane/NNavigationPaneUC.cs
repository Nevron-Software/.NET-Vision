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
	/// Summary description for NNavigationPaneUC.
	/// </summary>
	public class NNavigationPaneUC : NExampleUserControl
	{
		#region Constructor

		public NNavigationPaneUC(MainForm f) : base(f)
		{
			InitializeComponent();

			DockPadding.All = 4;

			Dock = DockStyle.Fill;

			m_ContextMenu = new NContextMenu();
			Nevron.UI.WinForm.Controls.NCommand comm;

			for(int i = 1; i < 5; i++)
			{
				comm = new Nevron.UI.WinForm.Controls.NCommand();
				comm.Properties.Text = "Context Menu Command " + i.ToString();
				m_ContextMenu.Commands.Add(comm);
			}
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

			m_arrImages = new Image[8];
			m_arrSmallImages = new Image[8];
			m_arrTexts = new string[8];

			Label lb;

			Type t = GetType();
			string path = "Nevron.Examples.UI.WinForm.Resources.Images.NavigationPane";

			m_arrImages[0] = NResourceHelper.BitmapFromResource(t, "Mail.png", path);
			m_arrImages[1] = NResourceHelper.BitmapFromResource(t, "Calendar.png", path);
			m_arrImages[2] = NResourceHelper.BitmapFromResource(t, "Contacts.png", path);
			m_arrImages[3] = NResourceHelper.BitmapFromResource(t, "Tasks.png", path);
			m_arrImages[4] = NResourceHelper.BitmapFromResource(t, "Notes.png", path);
			m_arrImages[5] = NResourceHelper.BitmapFromResource(t, "Folders.png", path);
			m_arrImages[6] = NResourceHelper.BitmapFromResource(t, "Shortcuts.png", path);
			m_arrImages[7] = NResourceHelper.BitmapFromResource(t, "Journal.png", path);

			m_arrSmallImages[0] = NResourceHelper.BitmapFromResource(t, "MailSmall.png", path);
			m_arrSmallImages[1] = NResourceHelper.BitmapFromResource(t, "CalendarSmall.png", path);
			m_arrSmallImages[2] = NResourceHelper.BitmapFromResource(t, "ContactsSmall.png", path);
			m_arrSmallImages[3] = NResourceHelper.BitmapFromResource(t, "TasksSmall.png", path);
			m_arrSmallImages[4] = NResourceHelper.BitmapFromResource(t, "NotesSmall.png", path);
			m_arrSmallImages[5] = NResourceHelper.BitmapFromResource(t, "FoldersSmall.png", path);
			m_arrSmallImages[6] = NResourceHelper.BitmapFromResource(t, "ShortcutsSmall.png", path);
			m_arrSmallImages[7] = NResourceHelper.BitmapFromResource(t, "JournalSmall.png", path);

			m_arrTexts[0] = "Mail";
			m_arrTexts[1] = "Calendar";
			m_arrTexts[2] = "Contacts";
			m_arrTexts[3] = "Tasks";
			m_arrTexts[4] = "Notes";
			m_arrTexts[5] = "Folders List";
			m_arrTexts[6] = "Shortcuts";
			m_arrTexts[7] = "Journal";

			m_Pane = new NNavigationPane();
			m_Pane.Dock = DockStyle.Left;

			for(int i = 0; i < 8; i++)
			{
				NNavigationPaneBand band = new NNavigationPaneBand();
				band.ContextMenu = m_ContextMenu;
				lb = new Label();
				lb.Text = m_arrTexts[i];
                band.TooltipText = "Sample tooltip for '" + m_arrTexts[i] + "' band";
				lb.Dock = DockStyle.Fill;
				lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				lb.Parent = band;

				band.Image = m_arrImages[i];
				band.SmallImage = m_arrSmallImages[i];

				m_Pane.Controls.Add(band);

				band.Text = m_arrTexts[i];
			}

			m_Pane.Parent = this;
			m_Pane.ButtonsPreferredHeight = 96;

			NSplitter splitter = new NSplitter();
			splitter.Dock = DockStyle.Left;
			splitter.Parent = this;
			splitter.BringToFront();

			this.optionsCommandCheck.Checked = true;
		}


		#endregion

		#region Event Handlers

		private void optionsCommandCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Pane.DisplayOptionsCommand = optionsCommandCheck.Checked;
		}

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_Pane == null)
				return;

			m_Pane.AllowStackResize = nCheckBox1.Checked;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.optionsCommandCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// optionsCommandCheck
			// 
			this.optionsCommandCheck.ButtonProperties.BorderOffset = 2;
			this.optionsCommandCheck.Location = new System.Drawing.Point(312, 0);
			this.optionsCommandCheck.Name = "optionsCommandCheck";
			this.optionsCommandCheck.Size = new System.Drawing.Size(168, 24);
			this.optionsCommandCheck.TabIndex = 1;
			this.optionsCommandCheck.Text = "Display Options Command";
			this.optionsCommandCheck.CheckedChanged += new System.EventHandler(this.optionsCommandCheck_CheckedChanged);
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.ButtonProperties.BorderOffset = 2;
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(312, 24);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(168, 24);
			this.nCheckBox1.TabIndex = 2;
			this.nCheckBox1.Text = "Allow Stack Resize";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// NNavigationPaneUC
			// 
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.optionsCommandCheck);
			this.Name = "NNavigationPaneUC";
			this.Size = new System.Drawing.Size(480, 408);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NNavigationPane m_Pane;
		internal Image[] m_arrImages;
		internal Image[] m_arrSmallImages;
		internal string[] m_arrTexts;
		internal NContextMenu m_ContextMenu;
		private Nevron.UI.WinForm.Controls.NCheckBox optionsCommandCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
