using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
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
	/// Summary description for NStatusBarUC.
	/// </summary>
	public class NStatusBarUC : NDiagramExampleUC
	{
		#region Constructor

		public NStatusBarUC(NMainForm form) : base(form)
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
			this.showStatusBarCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.documentPropsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.docWidthTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.docHeightTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.measurementUnitButton = new Nevron.Editors.NMeasurementUnitButton();
			this.documentPropsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// showStatusBarCheckBox
			// 
			this.showStatusBarCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.showStatusBarCheckBox.Checked = true;
			this.showStatusBarCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showStatusBarCheckBox.Location = new System.Drawing.Point(8, 152);
			this.showStatusBarCheckBox.Name = "showStatusBarCheckBox";
			this.showStatusBarCheckBox.Size = new System.Drawing.Size(234, 24);
			this.showStatusBarCheckBox.TabIndex = 1;
			this.showStatusBarCheckBox.Text = "Status bar visible";
			this.showStatusBarCheckBox.CheckedChanged += new System.EventHandler(this.showStatusBarCheckBox_CheckedChanged);
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
			this.documentPropsGroup.Text = "Document properties";
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
			this.docWidthTextBox.Size = new System.Drawing.Size(184, 20);
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
			this.docHeightTextBox.Size = new System.Drawing.Size(184, 20);
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
			this.measurementUnitButton.Size = new System.Drawing.Size(232, 23);
			this.measurementUnitButton.TabIndex = 1;
			this.measurementUnitButton.Text = "Measurement Unit";
			this.measurementUnitButton.MeasurementUnitChanged += new System.EventHandler(this.measurementUnitButton_MeasurementUnitChanged);
			// 
			// NStatusBarUC
			// 
			this.Controls.Add(this.documentPropsGroup);
			this.Controls.Add(this.showStatusBarCheckBox);
			this.Name = "NStatusBarUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.showStatusBarCheckBox, 0);
			this.Controls.SetChildIndex(this.documentPropsGroup, 0);
			this.documentPropsGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Component Overrides
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Form.CommandBarsManager.Commander.StatusBar.Visible = false;
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// show the status bar
			Form.CommandBarsManager.Commander.StatusBar.Visible = true;

			// begin view init
			view.BeginInit();

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
			PauseEventsHandling();

			try
			{
				showStatusBarCheckBox.Checked = Form.CommandBarsManager.Commander.StatusBar.Visible;
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

		private void showStatusBarCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			Form.CommandBarsManager.Commander.StatusBar.Visible = showStatusBarCheckBox.Checked;
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
		private Nevron.UI.WinForm.Controls.NCheckBox showStatusBarCheckBox;

		#endregion

		#region Fields

		#endregion
	}
}
