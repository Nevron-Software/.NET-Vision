using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NPanAndZoomControlUC.
	/// </summary>
	public class NPanAndZoomControlUC : NDiagramExampleUC
	{
		#region Constructor

		public NPanAndZoomControlUC(NMainForm form) : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panAndZoomControl = new Nevron.Diagram.WinForm.NPanAndZoomControl();
			this.showZoomNavigatorCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.showViewportBandCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// panAndZoomControl
			// 
			this.panAndZoomControl.Dock = System.Windows.Forms.DockStyle.Top;
			// TODO: Code generation for 'this.panAndZoomControl.LargeZoomChangeFactor' failed because of Exception 'Invalid Primitive Type: System.UInt32. Only CLS compliant primitive types can be used. Consider using CodeObjectCreateExpression.'.
			this.panAndZoomControl.Location = new System.Drawing.Point(0, 0);
			this.panAndZoomControl.MasterView = null;
			this.panAndZoomControl.Name = "panAndZoomControl";
			this.panAndZoomControl.Size = new System.Drawing.Size(250, 240);
			this.panAndZoomControl.TabIndex = 1;
			// 
			// showZoomNavigatorCheck
			// 
			this.showZoomNavigatorCheck.Location = new System.Drawing.Point(8, 248);
			this.showZoomNavigatorCheck.Name = "showZoomNavigatorCheck";
			this.showZoomNavigatorCheck.Size = new System.Drawing.Size(144, 24);
			this.showZoomNavigatorCheck.TabIndex = 2;
			this.showZoomNavigatorCheck.Text = "Show Zoom Navigator";
			this.showZoomNavigatorCheck.CheckedChanged += new System.EventHandler(this.showZoomNavigatorCheck_CheckedChanged);
			// 
			// showViewportBandCheck
			// 
			this.showViewportBandCheck.Location = new System.Drawing.Point(8, 280);
			this.showViewportBandCheck.Name = "showViewportBandCheck";
			this.showViewportBandCheck.Size = new System.Drawing.Size(144, 24);
			this.showViewportBandCheck.TabIndex = 3;
			this.showViewportBandCheck.Text = "Show Viewport Band";
			this.showViewportBandCheck.CheckedChanged += new System.EventHandler(this.showViewportBandCheck_CheckedChanged);
			// 
			// NPanAndZoomControlUC
			// 
			this.Controls.Add(this.showViewportBandCheck);
			this.Controls.Add(this.showZoomNavigatorCheck);
			this.Controls.Add(this.panAndZoomControl);
			this.Name = "NPanAndZoomControlUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.panAndZoomControl, 0);
			this.Controls.SetChildIndex(this.showZoomNavigatorCheck, 0);
			this.Controls.SetChildIndex(this.showViewportBandCheck, 0);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init document
			document.BeginInit();
			CreateDefaultFlowDiagram();
			document.EndInit();

			// init form controls
			PauseEventsHandling();
			
			showZoomNavigatorCheck.Checked = true;
			showViewportBandCheck.Checked = true;
			
			ResumeEventsHandling();

			// end view init
			view.EndInit();

			// set the master view of the pan and zoom control
			panAndZoomControl.MasterView = view;
		}

		#endregion

		#region Event Handlers

		private void showZoomNavigatorCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			panAndZoomControl.ShowZoomNavigator = showZoomNavigatorCheck.Checked;
		}

		private void showViewportBandCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			this.panAndZoomControl.ViewportPreview.Band.Visible = showViewportBandCheck.Checked;
			this.panAndZoomControl.ViewportPreview.SmartRefresh(); 
		}

		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.Diagram.WinForm.NPanAndZoomControl panAndZoomControl;
		private Nevron.UI.WinForm.Controls.NCheckBox showZoomNavigatorCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox showViewportBandCheck;

		#endregion
	}
}