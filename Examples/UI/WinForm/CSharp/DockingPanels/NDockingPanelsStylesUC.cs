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
	/// Summary description for NDockingPanelsStylesUC.
	/// </summary>
	public class NDockingPanelsStylesUC : NDockingPanelsBasicFeaturesUC
	{
		#region Constructor

		public NDockingPanelsStylesUC(MainForm f) : base(f)
		{
			// This call is required by the Windows.Forms Form Designer.
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

			m_ExampleFormType = typeof(NStylesForm);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}

	/// <summary>
	/// Summary description for NStylesForm.
	/// </summary>
	public class NStylesForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NStylesForm()
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

		protected override void InitPanels()
		{
			base.InitPanels();

			NDockingPanelHost host = new NDockingPanelHost();
			NDockingPanel panel = new NDockingPanel();
			panel.Text = "Properties";
			panel.TabInfo.Text = "Properties";
			panel.TabInfo.ImageIndex = 3;

			m_PropertyBrowser.Visible = true;

			m_PropertyBrowser.Dock = DockStyle.Fill;
			panel.Controls.Add(m_PropertyBrowser);
			host.AddChild(panel);
			m_Container.RootZone.AddChild(host);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			PopulateStylesCombo();
		}


		#endregion

		#region Implementation

		internal void PopulateStylesCombo()
		{
			nComboBox1.Items.Clear();
			nComboBox1.SelectedIndexChanged += new EventHandler(OnComboSelectedIndexChanged);

			nComboBox1.Items.Add(m_DockManager.CaptionStyle);
			nComboBox1.Items.Add(m_DockManager.SplitterStyle);
			nComboBox1.Items.Add(m_DockManager.TabStyle);

			nComboBox1.SelectedIndex = 0;
		}


		#endregion

		#region Event Handlers

		private void OnComboSelectedIndexChanged(object sender, EventArgs args)
		{
			m_PropertyGrid.SelectedObject = nComboBox1.SelectedItem;
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
			this.Text = "Appearance Styles Example";
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
