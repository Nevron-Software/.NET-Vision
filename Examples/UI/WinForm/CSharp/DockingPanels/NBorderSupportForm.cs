using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NComplexLayoutForm.
	/// </summary>
	public class NBorderSupportForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NBorderSupportForm()
		{
			InitializeComponent();

			Size = new Size(800, 600);
			m_PropertyGrid.SelectedObject = m_DockManager.DocumentStyle;
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

		protected override void InitCommandBars()
		{
			base.InitCommandBars ();

			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultCommandStyle = CommandStyle.Text;

			NCommand comm = new NCommand();
			comm.Properties.Text = "Border...";
			comm.Properties.ID = 0;
			tb.Commands.Add(comm);

			nCommandBarsManager1.Toolbars.Add(tb);
		}

		protected override void InitPanels()
		{
			NDockingPanel panel, panel1;

			panel1 = new NDockingPanel();
			panel1.PerformDock(m_DockManager.RootContainer.RootZone, DockStyle.Left);

			/*NCaptionButton btn = new NCaptionButton();
			btn.Text = ">";
			panel1.Caption.Buttons.Add(btn);
			panel1.CaptionButtonClicked += new CaptionEventHandler(panel1_CaptionButtonClicked);*/

			panel = new NDockingPanel();
			panel.PerformDock(panel1.ParentZone, DockStyle.Bottom);
		}

		protected override void nCommandBarsManager1_CommandClicked(object sender, CommandEventArgs e)
		{
			NCommand comm = e.Command;
			if(comm.Properties.ID != 0)
				return;

			NDockingPanel panel = (NDockingPanel)m_DockManager.Panels[0];

			NControlBorder border = new NControlBorder();
			border.Copy(panel.Border);

			if(border.ShowEditor() != DialogResult.OK)
				return;

			foreach(NDockingPanel panel1 in m_DockManager.Panels)
				panel1.Border.Copy(border);
		}



		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Text = "Auto Hide Support Example";
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion

		private void panel1_CaptionButtonClicked(object sender, CaptionEventArgs e)
		{
			MessageBox.Show("My caption button...");
		}
	}
}
