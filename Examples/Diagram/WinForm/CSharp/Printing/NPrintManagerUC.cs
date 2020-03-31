using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Extensions; 
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NPrintManagerUC.
	/// </summary>
	public class NPrintManagerUC : NDiagramExampleUC
	{
		#region Constructor

		public NPrintManagerUC(NMainForm form) : base(form)
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
			this.showPrintPreviewButton = new Nevron.UI.WinForm.Controls.NButton();
			this.showPageSetupButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label8 = new System.Windows.Forms.Label();
			this.measurementUnitButton = new Nevron.Editors.NMeasurementUnitButton();
			this.documentPropsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.docWidthTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.docHeightTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.documentPropsGroup.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// showPrintPreviewButton
			// 
			this.showPrintPreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.showPrintPreviewButton.Location = new System.Drawing.Point(8, 56);
			this.showPrintPreviewButton.Name = "showPrintPreviewButton";
			this.showPrintPreviewButton.Size = new System.Drawing.Size(232, 23);
			this.showPrintPreviewButton.TabIndex = 0;
			this.showPrintPreviewButton.Text = "Show Print Preview...";
			this.showPrintPreviewButton.Click += new System.EventHandler(this.showPrintPreviewButton_Click);
			// 
			// showPageSetupButton
			// 
			this.showPageSetupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.showPageSetupButton.Location = new System.Drawing.Point(8, 24);
			this.showPageSetupButton.Name = "showPageSetupButton";
			this.showPageSetupButton.Size = new System.Drawing.Size(232, 23);
			this.showPageSetupButton.TabIndex = 1;
			this.showPageSetupButton.Text = "Show Page Setup...";
			this.showPageSetupButton.Click += new System.EventHandler(this.showPageSetupButton_Click);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(8, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(234, 16);
			this.label8.TabIndex = 30;
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
			this.measurementUnitButton.Size = new System.Drawing.Size(232, 23);
			this.measurementUnitButton.TabIndex = 29;
			this.measurementUnitButton.Text = "Measurement Unit";
			this.measurementUnitButton.MeasurementUnitChanged += new System.EventHandler(this.measurementUnitButton_MeasurementUnitChanged);
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
			this.documentPropsGroup.TabIndex = 31;
			this.documentPropsGroup.TabStop = false;
			this.documentPropsGroup.Text = "Document Properties";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 87);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Width:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// docWidthTextBox
			// 
			this.docWidthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.docWidthTextBox.ErrorMessage = null;
			this.docWidthTextBox.Location = new System.Drawing.Point(56, 88);
			this.docWidthTextBox.Name = "docWidthTextBox";
			this.docWidthTextBox.ReadOnly = true;
			this.docWidthTextBox.Size = new System.Drawing.Size(184, 20);
			this.docWidthTextBox.TabIndex = 0;
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
			this.docHeightTextBox.Size = new System.Drawing.Size(184, 20);
			this.docHeightTextBox.TabIndex = 0;
			this.docHeightTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 111);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Height:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.showPageSetupButton);
			this.groupBox1.Controls.Add(this.showPrintPreviewButton);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 144);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(250, 96);
			this.groupBox1.TabIndex = 32;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Printing Actions";
			// 
			// NPrintManagerUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.documentPropsGroup);
			this.Name = "NPrintManagerUC";
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
			rect.Text = "Non-printable shape";
			rect.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal,
				GradientVariant.Variant1,
				Color.FromArgb(0xff, 0x55, 0x55),
				Color.FromArgb(0x66, 0x00, 0x00));
			
			// protect from printing
			NAbilities protection = rect.Protection;
			protection.Print = true;
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

		private void showPageSetupButton_Click(object sender, System.EventArgs e)
		{
			NPrintManager printManager = new NPrintManager(document);
			printManager.ShowPageSetup();
		}

		private void showPrintPreviewButton_Click(object sender, System.EventArgs e)
		{
			NPrintManager printManager = new NPrintManager(document);
			printManager.ShowPrintPreview();
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

			if (! (args.Node is NDocument))
				return;
			
			UpdateDocumentProperties();
		}

		private void EventSinkService_NodeBoundsChanged(NNodeEventArgs args)
		{
			if (! (args.Node is NDocument))
				return;
			
			UpdateDocumentProperties();
		}

		
		#endregion

		#region Design Fields

		private Nevron.UI.WinForm.Controls.NButton showPageSetupButton;
		private System.Windows.Forms.Label label8;
		private Nevron.Editors.NMeasurementUnitButton measurementUnitButton;
		private Nevron.UI.WinForm.Controls.NGroupBox documentPropsGroup;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox docWidthTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox docHeightTextBox;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton showPrintPreviewButton;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;

		#endregion
	}
}