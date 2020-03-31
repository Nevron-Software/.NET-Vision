using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NExportBaseUC.
	/// </summary>
	public abstract class NExportBaseUC : NDiagramExampleUC
	{
		#region Constructors

		public NExportBaseUC(NMainForm form)
			: base(form)
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
			this.btnExport = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// btnGenerateDxf
			// 
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnExport.Location = new System.Drawing.Point(8, 475);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(234, 23);
			this.btnExport.TabIndex = 5;
			this.btnExport.Text = "Export to ...";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// NExporterBaseUC
			// 
			this.Controls.Add(this.btnExport);
			this.Name = "NExportBaseUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.btnExport, 0);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;

			// init document
			document.BeginInit();
			CreateDiagram();
			document.EndInit();
			
			// end view init
			view.EndInit();
		}
		protected override void CreateDefaultFlowDiagram()
		{
			base.CreateDefaultFlowDiagram();

			// create a rectangle shape
			NRectangleShape rect = new NRectangleShape(new NRectangleF(10, 10, 100, 60));
			rect.Text = "Non-image exportable shape";
			rect.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal,
				GradientVariant.Variant1,
				Color.FromArgb(0xff, 0x55, 0x55),
				Color.FromArgb(0x66, 0x00, 0x00));

			// protect from export
			NAbilities protection = rect.Protection;
			protection.Export = true;
			rect.Protection = protection;

			// add it to the active layer
			document.ActiveLayer.AddChild(rect);
		}

		#endregion

		#region Abstract

		protected abstract string ErrorMessage
		{
			get;
		}
		protected abstract string Export();

		#endregion

		#region Overridable

		protected virtual void CreateDiagram()
		{
			CreateDefaultFlowDiagram();
		}

		#endregion

		#region Event Handlers

		private void btnExport_Click(object sender, EventArgs e)
		{
			string fileName = Export();

			try
			{
				Process.Start(fileName);
			}
			catch
			{
				MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		internal Nevron.UI.WinForm.Controls.NButton btnExport;

		#endregion
	}
}