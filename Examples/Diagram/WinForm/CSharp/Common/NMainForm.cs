using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;

using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// The NMainForm class represents the main form of the diagram examples browser
	/// </summary>
	public class NMainForm : NExamplesForm
	{
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public NMainForm()
		{
			InitializeComponent();
			InitFromConfig(new NDiagramExamplesConfig());
			InitializeDiagramExamplesComponents();
		}
		
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// NMainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "NMainForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion

		#region Main Entry Point
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			NMainForm MainForm = new NMainForm();
			Application.Run(MainForm);
		}
		#endregion

		#region Component Overrides
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#endregion

		#region Designer Fields

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		#endregion
	
		#region Overrides

		protected override NExamplesDockManager CreateDockManager()
		{
			return new NDiagramExamplesDockManager();
		}
		protected override void LayoutExample()
		{
			base.LayoutExample();
			
			NDiagramExamplesDockManager diagramDockManager = DockManager as NDiagramExamplesDockManager;
			NDiagramExamplesLayoutStrategy diagramLayoutStrategy = Config.LayoutStrategy as NDiagramExamplesLayoutStrategy;

			if (CurrentExampleEntity == null)
				return;

			if (CurrentExampleEntity.LayoutType == currentLayoutType)
				return;

			currentLayoutType = CurrentExampleEntity.LayoutType;

			INDockZone zone = diagramDockManager.m_ExamplePanel.ParentZone;
			if (zone == null)
				return;

			if (CurrentExampleEntity.LayoutType == "Wide")
			{
				diagramLayoutStrategy.WideScreenExampleZone.AddChild(zone);
				((NDiagramExampleUC)CurrentExampleControl).commonControlsPanel.Width = 260;
				((NDiagramExampleUC)CurrentExampleControl).commonControlsPanel.Dock = DockStyle.Right;
			}
			else
			{
				diagramDockManager.m_Container.RootZone.AddChild(zone);
				((NDiagramExampleUC)CurrentExampleControl).commonControlsPanel.Height = 80;
				((NDiagramExampleUC)CurrentExampleControl).commonControlsPanel.Dock = DockStyle.Bottom;
			}
		}
		protected override void ClearExample(bool clearAll)
		{
			base.ClearExample(clearAll);

			document.Reset();
			view.Reset();
		}		

		
		#endregion

		#region Implementation

		/// <summary>
		/// 
		/// </summary>
		private void InitializeDiagramExamplesComponents()
		{
			NDiagramExamplesDockManager dockManager = (NDiagramExamplesDockManager)this.DockManager;

			// create the view
			view = new NDrawingView();
			view.Dock = System.Windows.Forms.DockStyle.Fill;

			// create the document
			document = new NDrawingDocument();
			view.Document = document;

			// create the event log
			eventLogControl = new NEventLogUC();
			dockManager.EventLogPanel.Controls.Add(eventLogControl);
			eventLogControl.Dock = System.Windows.Forms.DockStyle.Fill;
			eventLogControl.Form = this;

			// create the property browser
			propertyBrowser = new NPropertyBrowser();
			propertyBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			propertyBrowser.View = view;
			dockManager.DiagramExplorerPanel.Controls.Add(propertyBrowser);

			// create the diagram designer panel
			Panel designerPanel = new Panel();
			designerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			designerPanel.Controls.Add(view);
			dockManager.DiagramDesignerPanel.Controls.Add(designerPanel);

			// create the command bars manager
			commandBarsManager = new NDiagramCommandBarsManager();
			commandBarsManager.View = view;
			commandBarsManager.ParentControl = designerPanel;

			// create the status bar
			NDiagramStatusBar statusBar = new NDiagramStatusBar();
			statusBar.Visible = false;
			statusBar.View = view;
			commandBarsManager.StatusBar = statusBar;
			Controls.Add(statusBar);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Obtains a reference to the document view
		/// </summary>
		public NDrawingView View
		{ 
			get
			{ 
				return view; 
			} 
		}
		/// <summary>
		/// Obtains a reference to the document 
		/// </summary>
		public NDrawingDocument Document
		{
			get
			{ 
				return document; 
			}
			set
			{ 
				document = value; 
			}
		}
		/// <summary>
		/// Obtains a reference to the command bars manager
		/// </summary>
		public NDiagramCommandBarsManager CommandBarsManager
		{ 
			get 
			{ 
				return commandBarsManager; 
			} 
		}
		/// <summary>
		/// Obtains a reference to the property browser
		/// </summary>
		public NPropertyBrowser PropertyBrowser
		{ 
			get 
			{ 
				return propertyBrowser;
			} 
		}

		#endregion

		#region Fields

		private NDiagramCommandBarsManager commandBarsManager;
		private NDrawingDocument document;
		private NDrawingView view;

		private NEventLogUC eventLogControl;
		private NPropertyBrowser propertyBrowser;
		private string currentLayoutType;

		#endregion
	}
}