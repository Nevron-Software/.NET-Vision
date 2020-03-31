using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Extensions; 
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NImageExportUC.
	/// </summary>
	public class NImageExportUC : NDiagramExampleUC
	{
		#region Constructors

		public NImageExportUC(NMainForm form) : base(form)
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
			this.showImageExportDialogButton = new Nevron.UI.WinForm.Controls.NButton();
			this.documentPropsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.docWidthTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.docHeightTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.measurementUnitButton = new Nevron.Editors.NMeasurementUnitButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.documentPropsGroup.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// showImageExportDialogButton
			// 
			this.showImageExportDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.showImageExportDialogButton.Location = new System.Drawing.Point(8, 24);
			this.showImageExportDialogButton.Name = "showImageExportDialogButton";
			this.showImageExportDialogButton.Size = new System.Drawing.Size(234, 23);
			this.showImageExportDialogButton.TabIndex = 0;
			this.showImageExportDialogButton.Text = "Show Image Export Dialog...";
			this.showImageExportDialogButton.Click += new System.EventHandler(this.showImageExportDialogButton_Click);
			// 
			// documentPropsGroup
			// 
			this.documentPropsGroup.Controls.Add(this.label1);
			this.documentPropsGroup.Controls.Add(this.docWidthTextBox);
			this.documentPropsGroup.Controls.Add(this.docHeightTextBox);
			this.documentPropsGroup.Controls.Add(this.label2);
			this.documentPropsGroup.Controls.Add(this.label8);
			this.documentPropsGroup.Controls.Add(this.measurementUnitButton);
			this.documentPropsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.documentPropsGroup.ImageIndex = 0;
			this.documentPropsGroup.Location = new System.Drawing.Point(0, 0);
			this.documentPropsGroup.Name = "documentPropsGroup";
			this.documentPropsGroup.Size = new System.Drawing.Size(250, 144);
			this.documentPropsGroup.TabIndex = 0;
			this.documentPropsGroup.TabStop = false;
			this.documentPropsGroup.Text = "Document Properties";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Width:";
			// 
			// docWidthTextBox
			// 
			this.docWidthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.docWidthTextBox.ErrorMessage = null;
			this.docWidthTextBox.Location = new System.Drawing.Point(56, 88);
			this.docWidthTextBox.Name = "docWidthTextBox";
			this.docWidthTextBox.ReadOnly = true;
			this.docWidthTextBox.Size = new System.Drawing.Size(186, 20);
			this.docWidthTextBox.TabIndex = 3;
			this.docWidthTextBox.Text = "";
			// 
			// docHeightTextBox
			// 
			this.docHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.docHeightTextBox.ErrorMessage = null;
			this.docHeightTextBox.Location = new System.Drawing.Point(56, 112);
			this.docHeightTextBox.Name = "docHeightTextBox";
			this.docHeightTextBox.ReadOnly = true;
			this.docHeightTextBox.Size = new System.Drawing.Size(186, 20);
			this.docHeightTextBox.TabIndex = 5;
			this.docHeightTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Height:";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(8, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(234, 16);
			this.label8.TabIndex = 0;
			this.label8.Text = "Document measurement unit:";
			// 
			// measurementUnitButton
			// 
			this.measurementUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.measurementUnitButton.ArrowClickOptions = false;
			this.measurementUnitButton.DialogResult = System.Windows.Forms.DialogResult.No;
			this.measurementUnitButton.Location = new System.Drawing.Point(8, 48);
			this.measurementUnitButton.Name = "measurementUnitButton";
			this.measurementUnitButton.Size = new System.Drawing.Size(234, 23);
			this.measurementUnitButton.TabIndex = 1;
			this.measurementUnitButton.Text = "Measurement Unit";
			this.measurementUnitButton.MeasurementUnitChanged += new System.EventHandler(this.measurementUnitButton_MeasurementUnitChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.showImageExportDialogButton);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 144);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(250, 64);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Image Export Actions";
			// 
			// NImageExporterUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.documentPropsGroup);
			this.Name = "NImageExportUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.documentPropsGroup, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.documentPropsGroup.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
			CreateDefaultFlowDiagram();
			document.EndInit();
		
			// init form controls
			InitFormControls();
			
			// end view init
			view.EndInit();
		}

		protected override void AttachToEvents()
		{
			document.EventSinkService.NodePropertyChanged += new NodePropertyEventHandler(EventSinkService_NodePropertyChanged);
			document.EventSinkService.NodeBoundsChanged += new NodeEventHandler(EventSinkService_NodeBoundsChanged);

			base.AttachToEvents();
		}

		protected override void DetachFromEvents()
		{
			document.EventSinkService.NodePropertyChanged -= new NodePropertyEventHandler(EventSinkService_NodePropertyChanged);
			document.EventSinkService.NodeBoundsChanged -= new NodeEventHandler(EventSinkService_NodeBoundsChanged);

			base.DetachFromEvents();
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

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			try
			{
				measurementUnitButton.SetSystemManagerAndUnit(NMeasurementSystemManager.DefaultMeasurementSystemManager, document.MeasurementUnit);
				UpdateDocumentProperties();
			}
			finally
			{
				ResumeEventsHandling();	
			}
		}
		
		private void UpdateDocumentProperties()
		{
			docWidthTextBox.Text = document.Width.ToString() + " " + document.MeasurementUnit.Abbreviation;
			docHeightTextBox.Text = document.Height.ToString() + " " + document.MeasurementUnit.Abbreviation;
		}

		#endregion

		#region Event Handlers

		private void showImageExportDialogButton_Click(object sender, System.EventArgs e)
		{
			NImageExporter imageExporter = new NImageExporter(document);

			// register selection bounds
			NNodeList nodes = view.Selection.Nodes;
			if (nodes.Count != 0)
				imageExporter.KnownBoundsTable.Add("Selected nodes", NFunctions.ComputeNodesBounds(nodes, null));

			imageExporter.ShowDialog();
		}

		private void measurementUnitButton_MeasurementUnitChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			try
			{
				document.MeasurementUnit = measurementUnitButton.MeasurementUnit;
				document.RefreshAllViews();
			}
			finally
			{
				ResumeEventsHandling();
				UpdateDocumentProperties();
			}
		}


		private void EventSinkService_NodePropertyChanged(NNodePropertyEventArgs args)
		{
			if (EventsHandlingPaused)
				return;

			if (!(args.Node is NDocument))
				return;
			
			UpdateDocumentProperties();
		}

		private void EventSinkService_NodeBoundsChanged(NNodeEventArgs args)
		{
			if (!(args.Node is NDocument))
				return;
			
			UpdateDocumentProperties();
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox documentPropsGroup;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox docWidthTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox docHeightTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		private Nevron.Editors.NMeasurementUnitButton measurementUnitButton;
		private System.Windows.Forms.GroupBox groupBox1;

		private Nevron.UI.WinForm.Controls.NButton showImageExportDialogButton;

		#endregion
	}
}