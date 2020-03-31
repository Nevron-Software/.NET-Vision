using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Editors;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NMultipleViewsUC.
	/// </summary>
	public class NMultipleViewsUC : NDiagramExampleUC
	{
		#region Constructor

		public NMultipleViewsUC(NMainForm form) : base(form)
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
			this.nNumericUpDown1 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).BeginInit();
			// 
			// nNumericUpDown1
			// 
			this.nNumericUpDown1.Location = new System.Drawing.Point(0, 0);
			this.nNumericUpDown1.Name = "nNumericUpDown1";
			this.nNumericUpDown1.Size = new System.Drawing.Size(120, 22);
			this.nNumericUpDown1.TabIndex = 0;
			// 
			// NMultipleViewsUC
			// 
			this.Name = "NMultipleViewsUC";
			this.Size = new System.Drawing.Size(240, 576);
			((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).EndInit();

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			view.DocumentPadding = new Nevron.Diagram.NMargins(20);
			view.ViewportOrigin = new NPointF(-12, -12);
			view.Grid.Visible = false;
			view.GlobalVisibility.ShowPorts = false;

			// init document
			document.BeginInit();
			CreateDefaultFlowDiagram();
			document.EndInit();

			// init form controls
			InitFormControls();

			// end view init
			view.EndInit(); 
		}

		#endregion

		#region Implementation

		private void InitFormControls()
		{
			// create the second view and attach it to the document
			NDrawingView secondView = new NDrawingView();
			secondView.Grid.Visible = false;
			secondView.GlobalVisibility.ShowPorts = false;
			secondView.Size = new Size(300, this.Height / 2);
			secondView.Dock = DockStyle.Top;
			secondView.Document = document;

			// create the third view and attach it to the document
			NDrawingView thirdView = new NDrawingView();
			thirdView.Grid.Visible = false;
			thirdView.GlobalVisibility.ShowPorts = false;
			thirdView.Dock = DockStyle.Fill;
			thirdView.Document = document;

			// create a splitter
			Splitter splitter = new Splitter();
			splitter.Dock = DockStyle.Top;

			// update the form controls
			Controls.Clear();
			Controls.Add(thirdView);
			Controls.Add(splitter);
			Controls.Add(secondView);
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown1;

		#endregion
	}
}