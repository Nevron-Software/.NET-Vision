using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NGridUC.
	/// </summary>
	public class NGridUC : NDiagramExampleUC
	{
		#region Constructor

		public NGridUC(NMainForm form) : base(form)
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
			this.horzStripesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.measurementUnitButton = new Nevron.Editors.NMeasurementUnitButton();
			this.visibleCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.originYNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.originXNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.showOriginCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.cellHeightNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.cellWidthNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.minorLinesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.majorLinesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.vertStripesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.gridStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cellSizeModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.originYNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.originXNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cellHeightNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cellWidthNumeric)).BeginInit();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// horzStripesButton
			// 
			this.horzStripesButton.Location = new System.Drawing.Point(8, 55);
			this.horzStripesButton.Name = "horzStripesButton";
			this.horzStripesButton.Size = new System.Drawing.Size(112, 23);
			this.horzStripesButton.TabIndex = 2;
			this.horzStripesButton.Text = "Horizontal stripes...";
			this.horzStripesButton.Click += new System.EventHandler(this.horzStripesButton_Click);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.measurementUnitButton);
			this.nGroupBox1.Controls.Add(this.visibleCheck);
			this.nGroupBox1.Controls.Add(this.originYNumeric);
			this.nGroupBox1.Controls.Add(this.label4);
			this.nGroupBox1.Controls.Add(this.originXNumeric);
			this.nGroupBox1.Controls.Add(this.label5);
			this.nGroupBox1.Controls.Add(this.showOriginCheck);
			this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(0, 0);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(256, 184);
			this.nGroupBox1.TabIndex = 0;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "General";
			// 
			// measurementUnitButton
			// 
			this.measurementUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.measurementUnitButton.ArrowClickOptions = false;
			this.measurementUnitButton.ArrowWidth = 14;
			this.measurementUnitButton.DialogResult = System.Windows.Forms.DialogResult.No;
			this.measurementUnitButton.Location = new System.Drawing.Point(8, 144);
			this.measurementUnitButton.Name = "measurementUnitButton";
			this.measurementUnitButton.Size = new System.Drawing.Size(240, 23);
			this.measurementUnitButton.TabIndex = 6;
			this.measurementUnitButton.Text = "Measurement Unit";
			this.measurementUnitButton.MeasurementUnitChanged += new System.EventHandler(this.measurementUnitButton_MeasurementUnitChanged);
			// 
			// visibleCheck
			// 
			this.visibleCheck.Location = new System.Drawing.Point(16, 16);
			this.visibleCheck.Name = "visibleCheck";
			this.visibleCheck.Size = new System.Drawing.Size(80, 24);
			this.visibleCheck.TabIndex = 0;
			this.visibleCheck.Text = "Visible";
			this.visibleCheck.CheckedChanged += new System.EventHandler(this.visibleCheck_CheckedChanged);
			// 
			// originYNumeric
			// 
			this.originYNumeric.Location = new System.Drawing.Point(88, 110);
			this.originYNumeric.Minimum = new System.Decimal(new int[] {
																		   100,
																		   0,
																		   0,
																		   -2147483648});
			this.originYNumeric.Name = "originYNumeric";
			this.originYNumeric.Size = new System.Drawing.Size(64, 22);
			this.originYNumeric.TabIndex = 5;
			this.originYNumeric.ValueChanged += new System.EventHandler(this.originYNumeric_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "OriginY:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// originXNumeric
			// 
			this.originXNumeric.Location = new System.Drawing.Point(88, 80);
			this.originXNumeric.Minimum = new System.Decimal(new int[] {
																		   100,
																		   0,
																		   0,
																		   -2147483648});
			this.originXNumeric.Name = "originXNumeric";
			this.originXNumeric.Size = new System.Drawing.Size(64, 22);
			this.originXNumeric.TabIndex = 3;
			this.originXNumeric.ValueChanged += new System.EventHandler(this.originXNumeric_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 82);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 19);
			this.label5.TabIndex = 2;
			this.label5.Text = "OriginX:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// showOriginCheck
			// 
			this.showOriginCheck.Location = new System.Drawing.Point(16, 48);
			this.showOriginCheck.Name = "showOriginCheck";
			this.showOriginCheck.Size = new System.Drawing.Size(80, 24);
			this.showOriginCheck.TabIndex = 1;
			this.showOriginCheck.Text = "Show origin";
			this.showOriginCheck.CheckedChanged += new System.EventHandler(this.showOriginCheck_CheckedChanged);
			// 
			// cellHeightNumeric
			// 
			this.cellHeightNumeric.Enabled = false;
			this.cellHeightNumeric.Location = new System.Drawing.Point(88, 84);
			this.cellHeightNumeric.Maximum = new System.Decimal(new int[] {
																			  1000,
																			  0,
																			  0,
																			  0});
			this.cellHeightNumeric.Name = "cellHeightNumeric";
			this.cellHeightNumeric.Size = new System.Drawing.Size(64, 22);
			this.cellHeightNumeric.TabIndex = 5;
			this.cellHeightNumeric.ValueChanged += new System.EventHandler(this.cellHeightNumeric_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "Cell height:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cellWidthNumeric
			// 
			this.cellWidthNumeric.Enabled = false;
			this.cellWidthNumeric.Location = new System.Drawing.Point(88, 54);
			this.cellWidthNumeric.Maximum = new System.Decimal(new int[] {
																			 1000,
																			 0,
																			 0,
																			 0});
			this.cellWidthNumeric.Name = "cellWidthNumeric";
			this.cellWidthNumeric.Size = new System.Drawing.Size(64, 22);
			this.cellWidthNumeric.TabIndex = 3;
			this.cellWidthNumeric.ValueChanged += new System.EventHandler(this.cellWidthNumeric_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Cell width:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.minorLinesButton);
			this.nGroupBox2.Controls.Add(this.majorLinesButton);
			this.nGroupBox2.Controls.Add(this.vertStripesButton);
			this.nGroupBox2.Controls.Add(this.gridStyleCombo);
			this.nGroupBox2.Controls.Add(this.label1);
			this.nGroupBox2.Controls.Add(this.horzStripesButton);
			this.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(0, 184);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(256, 128);
			this.nGroupBox2.TabIndex = 1;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Appearance";
			// 
			// minorLinesButton
			// 
			this.minorLinesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.minorLinesButton.Location = new System.Drawing.Point(128, 87);
			this.minorLinesButton.Name = "minorLinesButton";
			this.minorLinesButton.Size = new System.Drawing.Size(120, 23);
			this.minorLinesButton.TabIndex = 5;
			this.minorLinesButton.Text = "Minor lines...";
			this.minorLinesButton.Click += new System.EventHandler(this.minorLinesButton_Click);
			// 
			// majorLinesButton
			// 
			this.majorLinesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.majorLinesButton.Location = new System.Drawing.Point(128, 55);
			this.majorLinesButton.Name = "majorLinesButton";
			this.majorLinesButton.Size = new System.Drawing.Size(120, 23);
			this.majorLinesButton.TabIndex = 4;
			this.majorLinesButton.Text = "Major lines...";
			this.majorLinesButton.Click += new System.EventHandler(this.majorLinesButton_Click);
			// 
			// vertStripesButton
			// 
			this.vertStripesButton.Location = new System.Drawing.Point(8, 87);
			this.vertStripesButton.Name = "vertStripesButton";
			this.vertStripesButton.Size = new System.Drawing.Size(112, 23);
			this.vertStripesButton.TabIndex = 3;
			this.vertStripesButton.Text = "Vertical stripes...";
			this.vertStripesButton.Click += new System.EventHandler(this.vertStripesButton_Click);
			// 
			// gridStyleCombo
			// 
			this.gridStyleCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridStyleCombo.Location = new System.Drawing.Point(88, 24);
			this.gridStyleCombo.Name = "gridStyleCombo";
			this.gridStyleCombo.Size = new System.Drawing.Size(160, 22);
			this.gridStyleCombo.TabIndex = 1;
			this.gridStyleCombo.Text = "nComboBox1";
			this.gridStyleCombo.SelectedIndexChanged += new System.EventHandler(this.gridStyleCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Grid style:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.label6);
			this.nGroupBox3.Controls.Add(this.cellHeightNumeric);
			this.nGroupBox3.Controls.Add(this.cellWidthNumeric);
			this.nGroupBox3.Controls.Add(this.label2);
			this.nGroupBox3.Controls.Add(this.label3);
			this.nGroupBox3.Controls.Add(this.cellSizeModeComboBox);
			this.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(0, 312);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(256, 120);
			this.nGroupBox3.TabIndex = 2;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Cell sizing";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 27);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Mode:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cellSizeModeComboBox
			// 
			this.cellSizeModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cellSizeModeComboBox.Location = new System.Drawing.Point(88, 24);
			this.cellSizeModeComboBox.Name = "cellSizeModeComboBox";
			this.cellSizeModeComboBox.Size = new System.Drawing.Size(160, 22);
			this.cellSizeModeComboBox.TabIndex = 1;
			this.cellSizeModeComboBox.Text = "nComboBox1";
			this.cellSizeModeComboBox.SelectedIndexChanged += new System.EventHandler(this.cellSizeModeComboBox_SelectedIndexChanged);
			// 
			// NGridUC
			// 
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NGridUC";
			this.Size = new System.Drawing.Size(256, 624);
			this.Controls.SetChildIndex(this.nGroupBox1, 0);
			this.Controls.SetChildIndex(this.nGroupBox2, 0);
			this.Controls.SetChildIndex(this.nGroupBox3, 0);
			this.nGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.originYNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.originXNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cellHeightNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cellWidthNumeric)).EndInit();
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
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

			// update the form from the grid
			UpdateFromGrid();

			// end view init
			view.EndInit();
		}

		protected override void ResetExample()
		{
			view.Reset();
			base.ResetExample();
		}


		#endregion

		#region Implementation

		private void UpdateFromGrid()
		{
			PauseEventsHandling();

			showOriginCheck.Checked = view.Grid.ShowOrigin;
			visibleCheck.Checked = view.Grid.Visible;

			originXNumeric.Value = (decimal)view.Grid.Origin.X;
			originYNumeric.Value = (decimal)view.Grid.Origin.Y;

			measurementUnitButton.SetSystemManagerAndUnit(NMeasurementSystemManager.DefaultMeasurementSystemManager, view.Grid.MeasurementUnit);

			cellSizeModeComboBox.FillFromEnum(typeof(AutoStepMode));
			cellSizeModeComboBox.SelectedItem = view.Grid.CellSizeMode;

			cellWidthNumeric.Value = (decimal)view.Grid.FixedCellSize.Width;
			cellHeightNumeric.Value = (decimal)view.Grid.FixedCellSize.Height;

			gridStyleCombo.FillFromEnum(typeof(GridStyle));
			gridStyleCombo.SelectedItem = view.Grid.GridStyle;

			ResumeEventsHandling();
		}

		#endregion

		#region Event Handlers

		private void cellWidthNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float width = (float)cellWidthNumeric.Value;
			float height = (float)view.Grid.GetUsedCellSize().Height;
			view.Grid.FixedCellSize = new NSizeF(width, height);

			view.SmartRefresh();
		}

		private void cellHeightNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float width = (float)view.Grid.GetUsedCellSize().Width;
			float height = (float)cellHeightNumeric.Value;
			view.Grid.FixedCellSize = new NSizeF(width, height);

			view.SmartRefresh();
		}

		private void originXNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float x = (float)originXNumeric.Value;
			float y = view.Grid.Origin.Y;
			view.Grid.Origin = new NPointF(x, y);

			view.SmartRefresh();
		}

		private void originYNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float x = (float)view.Grid.Origin.X;
			float y = (float)originYNumeric.Value;
			view.Grid.Origin = new NPointF(x, y);

			view.SmartRefresh();
		}

		private void showOriginCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			view.Grid.ShowOrigin = showOriginCheck.Checked;
			view.SmartRefresh();
		}

		private void gridStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			GridStyle style = (GridStyle)gridStyleCombo.SelectedItem;
			view.Grid.GridStyle = style;
			view.SmartRefresh();
		}

		private void horzStripesButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle style = view.Grid.HorizontalStripesFillStyle;
			if (!NFillStyleTypeEditor.Edit(style, out style))
				return;

			view.Grid.HorizontalStripesFillStyle = style;
			view.SmartRefresh();
		}

		private void vertStripesButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle style = view.Grid.VerticalStripesFillStyle;
			if (!NFillStyleTypeEditor.Edit(style, out style))
				return;

			view.Grid.VerticalStripesFillStyle = style;
			view.SmartRefresh();
		}

		private void majorLinesButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle style = view.Grid.MajorLinesStrokeStyle;
			if (!NStrokeStyleTypeEditor.Edit(style, out style))
				return;

			view.Grid.MajorLinesStrokeStyle = style;
			view.SmartRefresh();
		}

		private void minorLinesButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle style = view.Grid.MinorLinesStrokeStyle;
			if (!NStrokeStyleTypeEditor.Edit(style, out style))
				return;

			view.Grid.MinorLinesStrokeStyle = style;
			view.SmartRefresh();
		}

		private void visibleCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			view.Grid.Visible = visibleCheck.Checked;
			view.SmartRefresh();
		}

		private void cellSizeModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cellSizeModeComboBox.SelectedIndex == -1)
				return;

			view.Grid.CellSizeMode = (AutoStepMode) cellSizeModeComboBox.SelectedItem;
			if (view.Grid.CellSizeMode == AutoStepMode.Fixed)
			{
				try
				{
					cellWidthNumeric.Value = (decimal) view.Grid.GetUsedCellSize().Width;
					cellHeightNumeric.Value = (decimal) view.Grid.GetUsedCellSize().Height;
				}
				catch(Exception ex)
				{
					Debug.WriteLine(ex.Message);
					cellWidthNumeric.Value = cellWidthNumeric.Maximum;
					cellHeightNumeric.Value = cellHeightNumeric.Maximum;
				}

				this.cellWidthNumeric.Enabled = true;
				this.cellHeightNumeric.Enabled = true;
			}
			else
			{
				this.cellWidthNumeric.Enabled = false;
				this.cellHeightNumeric.Enabled = false;
			}

			document.RefreshAllViews();
		}

		private void measurementUnitButton_MeasurementUnitChanged(object sender, EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			view.Grid.MeasurementUnit = measurementUnitButton.MeasurementUnit;
			UpdateFromGrid();
		}


		#endregion

		#region Designer Fields

		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Nevron.UI.WinForm.Controls.NComboBox cellSizeModeComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox gridStyleCombo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NCheckBox visibleCheck;
		private Nevron.UI.WinForm.Controls.NNumericUpDown originYNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown originXNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown cellHeightNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown cellWidthNumeric;
		private Nevron.UI.WinForm.Controls.NCheckBox showOriginCheck;
		private Nevron.UI.WinForm.Controls.NButton horzStripesButton;
		private Nevron.UI.WinForm.Controls.NButton vertStripesButton;
		private Nevron.UI.WinForm.Controls.NButton minorLinesButton;
		private Nevron.UI.WinForm.Controls.NButton majorLinesButton;
		private System.Windows.Forms.Label label6;
		private Nevron.Editors.NMeasurementUnitButton measurementUnitButton;
		private System.ComponentModel.Container components = null;

		#endregion
	}
}