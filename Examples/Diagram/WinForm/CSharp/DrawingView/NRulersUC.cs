using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.UI.WinForm.Controls;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NRulersUC.
	/// </summary>
	public class NRulersUC : NDiagramExampleUC
	{
		#region Constructor

		public NRulersUC(NMainForm form) : base(form)
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
			this.label1 = new System.Windows.Forms.Label();
			this.appearanceGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.fontButton = new Nevron.UI.WinForm.Controls.NButton();
			this.paddingNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.sizeNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.originNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.generalGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.measurementUnitButton = new Nevron.Editors.NMeasurementUnitButton();
			this.label4 = new System.Windows.Forms.Label();
			this.ticksStepNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.colorsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.coordinateHighlightColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label9 = new System.Windows.Forms.Label();
			this.frameColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label8 = new System.Windows.Forms.Label();
			this.backColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label7 = new System.Windows.Forms.Label();
			this.textColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label6 = new System.Windows.Forms.Label();
			this.minorTicksColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label5 = new System.Windows.Forms.Label();
			this.majorTicksColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.highlightColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label12 = new System.Windows.Forms.Label();
			this.majorTicksGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ticksStepModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.rulerPropertiesPanel = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.selectRulerPanel = new System.Windows.Forms.Panel();
			this.vRulerRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.hRulerRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.appearanceGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.paddingNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.originNumeric)).BeginInit();
			this.generalGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ticksStepNumeric)).BeginInit();
			this.colorsGroup.SuspendLayout();
			this.majorTicksGroup.SuspendLayout();
			this.rulerPropertiesPanel.SuspendLayout();
			this.panel3.SuspendLayout();
			this.selectRulerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Size:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// appearanceGroup
			// 
			this.appearanceGroup.Controls.Add(this.fontButton);
			this.appearanceGroup.Controls.Add(this.paddingNumeric);
			this.appearanceGroup.Controls.Add(this.label2);
			this.appearanceGroup.Controls.Add(this.sizeNumeric);
			this.appearanceGroup.Controls.Add(this.label1);
			this.appearanceGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.appearanceGroup.ImageIndex = 0;
			this.appearanceGroup.Location = new System.Drawing.Point(0, 216);
			this.appearanceGroup.Name = "appearanceGroup";
			this.appearanceGroup.Size = new System.Drawing.Size(248, 112);
			this.appearanceGroup.TabIndex = 0;
			this.appearanceGroup.TabStop = false;
			this.appearanceGroup.Text = "Appearance";
			// 
			// fontButton
			// 
			this.fontButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.fontButton.Location = new System.Drawing.Point(8, 80);
			this.fontButton.Name = "fontButton";
			this.fontButton.Size = new System.Drawing.Size(232, 23);
			this.fontButton.TabIndex = 4;
			this.fontButton.Text = "Font...";
			this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
			// 
			// paddingNumeric
			// 
			this.paddingNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.paddingNumeric.Location = new System.Drawing.Point(128, 48);
			this.paddingNumeric.Name = "paddingNumeric";
			this.paddingNumeric.Size = new System.Drawing.Size(110, 22);
			this.paddingNumeric.TabIndex = 3;
			this.paddingNumeric.ValueChanged += new System.EventHandler(this.paddingNumeric_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Padding:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sizeNumeric
			// 
			this.sizeNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sizeNumeric.Location = new System.Drawing.Point(128, 24);
			this.sizeNumeric.Name = "sizeNumeric";
			this.sizeNumeric.Size = new System.Drawing.Size(110, 22);
			this.sizeNumeric.TabIndex = 1;
			this.sizeNumeric.ValueChanged += new System.EventHandler(this.sizeNumeric_ValueChanged);
			// 
			// originNumeric
			// 
			this.originNumeric.Location = new System.Drawing.Point(128, 16);
			this.originNumeric.Name = "originNumeric";
			this.originNumeric.Size = new System.Drawing.Size(112, 22);
			this.originNumeric.TabIndex = 1;
			this.originNumeric.ValueChanged += new System.EventHandler(this.originNumeric_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Origin:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// generalGroup
			// 
			this.generalGroup.Controls.Add(this.measurementUnitButton);
			this.generalGroup.Controls.Add(this.label3);
			this.generalGroup.Controls.Add(this.originNumeric);
			this.generalGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.generalGroup.ImageIndex = 0;
			this.generalGroup.Location = new System.Drawing.Point(0, 416);
			this.generalGroup.Name = "generalGroup";
			this.generalGroup.Size = new System.Drawing.Size(248, 80);
			this.generalGroup.TabIndex = 2;
			this.generalGroup.TabStop = false;
			this.generalGroup.Text = "General";
			// 
			// measurementUnitButton
			// 
			this.measurementUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.measurementUnitButton.ArrowClickOptions = false;
			this.measurementUnitButton.ArrowWidth = 14;
			this.measurementUnitButton.DialogResult = System.Windows.Forms.DialogResult.No;
			this.measurementUnitButton.Location = new System.Drawing.Point(8, 48);
			this.measurementUnitButton.Name = "measurementUnitButton";
			this.measurementUnitButton.Size = new System.Drawing.Size(230, 23);
			this.measurementUnitButton.TabIndex = 4;
			this.measurementUnitButton.Text = "Measurement Unit";
			this.measurementUnitButton.MeasurementUnitChanged += new System.EventHandler(this.measurementUnitButton_MeasurementUnitChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "Major ticks fixed step:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ticksStepNumeric
			// 
			this.ticksStepNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ticksStepNumeric.Enabled = false;
			this.ticksStepNumeric.Location = new System.Drawing.Point(128, 56);
			this.ticksStepNumeric.Maximum = new System.Decimal(new int[] {
																			 1000,
																			 0,
																			 0,
																			 0});
			this.ticksStepNumeric.Name = "ticksStepNumeric";
			this.ticksStepNumeric.Size = new System.Drawing.Size(110, 22);
			this.ticksStepNumeric.TabIndex = 2;
			this.ticksStepNumeric.ValueChanged += new System.EventHandler(this.ticksStepNumeric_ValueChanged);
			// 
			// colorsGroup
			// 
			this.colorsGroup.Controls.Add(this.label10);
			this.colorsGroup.Controls.Add(this.coordinateHighlightColorButton);
			this.colorsGroup.Controls.Add(this.label9);
			this.colorsGroup.Controls.Add(this.frameColorButton);
			this.colorsGroup.Controls.Add(this.label8);
			this.colorsGroup.Controls.Add(this.backColorButton);
			this.colorsGroup.Controls.Add(this.label7);
			this.colorsGroup.Controls.Add(this.textColorButton);
			this.colorsGroup.Controls.Add(this.label6);
			this.colorsGroup.Controls.Add(this.minorTicksColorButton);
			this.colorsGroup.Controls.Add(this.label5);
			this.colorsGroup.Controls.Add(this.majorTicksColorButton);
			this.colorsGroup.Controls.Add(this.highlightColorButton);
			this.colorsGroup.Controls.Add(this.label12);
			this.colorsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.colorsGroup.ImageIndex = 0;
			this.colorsGroup.Location = new System.Drawing.Point(0, 0);
			this.colorsGroup.Name = "colorsGroup";
			this.colorsGroup.Size = new System.Drawing.Size(248, 216);
			this.colorsGroup.TabIndex = 0;
			this.colorsGroup.TabStop = false;
			this.colorsGroup.Text = "Colors";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 154);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 23);
			this.label10.TabIndex = 10;
			this.label10.Text = "Coordinate highlight:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// coordinateHighlightColorButton
			// 
			this.coordinateHighlightColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.coordinateHighlightColorButton.ArrowClickOptions = false;
			this.coordinateHighlightColorButton.ArrowWidth = 14;
			this.coordinateHighlightColorButton.Location = new System.Drawing.Point(128, 154);
			this.coordinateHighlightColorButton.Name = "coordinateHighlightColorButton";
			this.coordinateHighlightColorButton.Size = new System.Drawing.Size(110, 22);
			this.coordinateHighlightColorButton.TabIndex = 11;
			this.coordinateHighlightColorButton.ColorChanged += new System.EventHandler(this.coordinateHighlightColorButton_ColorChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 128);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 23);
			this.label9.TabIndex = 8;
			this.label9.Text = "Frame:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frameColorButton
			// 
			this.frameColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.frameColorButton.ArrowClickOptions = false;
			this.frameColorButton.ArrowWidth = 14;
			this.frameColorButton.Location = new System.Drawing.Point(128, 128);
			this.frameColorButton.Name = "frameColorButton";
			this.frameColorButton.Size = new System.Drawing.Size(110, 22);
			this.frameColorButton.TabIndex = 9;
			this.frameColorButton.ColorChanged += new System.EventHandler(this.frameColorButton_ColorChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 102);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 23);
			this.label8.TabIndex = 6;
			this.label8.Text = "Back color:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// backColorButton
			// 
			this.backColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.backColorButton.ArrowClickOptions = false;
			this.backColorButton.ArrowWidth = 14;
			this.backColorButton.Location = new System.Drawing.Point(128, 102);
			this.backColorButton.Name = "backColorButton";
			this.backColorButton.Size = new System.Drawing.Size(110, 22);
			this.backColorButton.TabIndex = 7;
			this.backColorButton.ColorChanged += new System.EventHandler(this.backColorButton_ColorChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 76);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 23);
			this.label7.TabIndex = 4;
			this.label7.Text = "Text:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textColorButton
			// 
			this.textColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textColorButton.ArrowClickOptions = false;
			this.textColorButton.ArrowWidth = 14;
			this.textColorButton.Location = new System.Drawing.Point(128, 76);
			this.textColorButton.Name = "textColorButton";
			this.textColorButton.Size = new System.Drawing.Size(110, 22);
			this.textColorButton.TabIndex = 5;
			this.textColorButton.ColorChanged += new System.EventHandler(this.textColorButton_ColorChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 2;
			this.label6.Text = "Minor ticks:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// minorTicksColorButton
			// 
			this.minorTicksColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.minorTicksColorButton.ArrowClickOptions = false;
			this.minorTicksColorButton.ArrowWidth = 14;
			this.minorTicksColorButton.Location = new System.Drawing.Point(128, 50);
			this.minorTicksColorButton.Name = "minorTicksColorButton";
			this.minorTicksColorButton.Size = new System.Drawing.Size(110, 22);
			this.minorTicksColorButton.TabIndex = 3;
			this.minorTicksColorButton.ColorChanged += new System.EventHandler(this.minorTicksColorButton_ColorChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Major ticks:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// majorTicksColorButton
			// 
			this.majorTicksColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.majorTicksColorButton.ArrowClickOptions = false;
			this.majorTicksColorButton.ArrowWidth = 14;
			this.majorTicksColorButton.Location = new System.Drawing.Point(128, 24);
			this.majorTicksColorButton.Name = "majorTicksColorButton";
			this.majorTicksColorButton.Size = new System.Drawing.Size(110, 22);
			this.majorTicksColorButton.TabIndex = 1;
			this.majorTicksColorButton.ColorChanged += new System.EventHandler(this.majorTicksColorButton_ColorChanged);
			// 
			// highlightColorButton
			// 
			this.highlightColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.highlightColorButton.ArrowClickOptions = false;
			this.highlightColorButton.ArrowWidth = 14;
			this.highlightColorButton.Location = new System.Drawing.Point(128, 180);
			this.highlightColorButton.Name = "highlightColorButton";
			this.highlightColorButton.Size = new System.Drawing.Size(110, 22);
			this.highlightColorButton.TabIndex = 13;
			this.highlightColorButton.ColorChanged += new System.EventHandler(this.highlightColorButton_ColorChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 180);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 23);
			this.label12.TabIndex = 12;
			this.label12.Text = "Range highlight:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// majorTicksGroup
			// 
			this.majorTicksGroup.Controls.Add(this.ticksStepModeComboBox);
			this.majorTicksGroup.Controls.Add(this.label4);
			this.majorTicksGroup.Controls.Add(this.ticksStepNumeric);
			this.majorTicksGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.majorTicksGroup.ImageIndex = 0;
			this.majorTicksGroup.Location = new System.Drawing.Point(0, 328);
			this.majorTicksGroup.Name = "majorTicksGroup";
			this.majorTicksGroup.Size = new System.Drawing.Size(248, 88);
			this.majorTicksGroup.TabIndex = 1;
			this.majorTicksGroup.TabStop = false;
			this.majorTicksGroup.Text = "Major ticks step mode";
			// 
			// ticksStepModeComboBox
			// 
			this.ticksStepModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ticksStepModeComboBox.Location = new System.Drawing.Point(8, 24);
			this.ticksStepModeComboBox.Name = "ticksStepModeComboBox";
			this.ticksStepModeComboBox.Size = new System.Drawing.Size(232, 22);
			this.ticksStepModeComboBox.TabIndex = 0;
			this.ticksStepModeComboBox.Text = "nComboBox1";
			this.ticksStepModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ticksStepModeComboBox_SelectedIndexChanged);
			// 
			// rulerPropertiesPanel
			// 
			this.rulerPropertiesPanel.Controls.Add(this.generalGroup);
			this.rulerPropertiesPanel.Controls.Add(this.majorTicksGroup);
			this.rulerPropertiesPanel.Controls.Add(this.appearanceGroup);
			this.rulerPropertiesPanel.Controls.Add(this.colorsGroup);
			this.rulerPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rulerPropertiesPanel.Location = new System.Drawing.Point(0, 40);
			this.rulerPropertiesPanel.Name = "rulerPropertiesPanel";
			this.rulerPropertiesPanel.Size = new System.Drawing.Size(248, 560);
			this.rulerPropertiesPanel.TabIndex = 30;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.rulerPropertiesPanel);
			this.panel3.Controls.Add(this.selectRulerPanel);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(248, 600);
			this.panel3.TabIndex = 32;
			// 
			// selectRulerPanel
			// 
			this.selectRulerPanel.Controls.Add(this.vRulerRadioButton);
			this.selectRulerPanel.Controls.Add(this.hRulerRadioButton);
			this.selectRulerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectRulerPanel.Location = new System.Drawing.Point(0, 0);
			this.selectRulerPanel.Name = "selectRulerPanel";
			this.selectRulerPanel.Size = new System.Drawing.Size(248, 40);
			this.selectRulerPanel.TabIndex = 0;
			// 
			// vRulerRadioButton
			// 
			this.vRulerRadioButton.Location = new System.Drawing.Point(120, 8);
			this.vRulerRadioButton.Name = "vRulerRadioButton";
			this.vRulerRadioButton.TabIndex = 1;
			this.vRulerRadioButton.Text = "Vertical ruler";
			this.vRulerRadioButton.CheckedChanged += new System.EventHandler(this.vRulerRadioButton_CheckedChanged);
			// 
			// hRulerRadioButton
			// 
			this.hRulerRadioButton.Location = new System.Drawing.Point(8, 8);
			this.hRulerRadioButton.Name = "hRulerRadioButton";
			this.hRulerRadioButton.TabIndex = 0;
			this.hRulerRadioButton.Text = "Horizontal ruler";
			this.hRulerRadioButton.CheckedChanged += new System.EventHandler(this.hRulerRadioButton_CheckedChanged);
			// 
			// NRulersUC
			// 
			this.Controls.Add(this.panel3);
			this.Name = "NRulersUC";
			this.Size = new System.Drawing.Size(248, 700);
			this.Controls.SetChildIndex(this.panel3, 0);
			this.appearanceGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.paddingNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.originNumeric)).EndInit();
			this.generalGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ticksStepNumeric)).EndInit();
			this.colorsGroup.ResumeLayout(false);
			this.majorTicksGroup.ResumeLayout(false);
			this.rulerPropertiesPanel.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.selectRulerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			document.HistoryService.Pause();;
			CreateDefaultFlowDiagram();
			document.HistoryService.Resume();

			// init form controls
			InitFormControls();

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

		private void InitFormControls()
		{
			PauseEventsHandling();

			ticksStepModeComboBox.FillFromEnum(typeof(AutoStepMode));
			ticksStepModeComboBox.SelectedItem = AutoStepMode.Normal;

			hRulerRadioButton.Checked = true;
			curRuler = view.HorizontalRuler;
			UpdateFromRuler(curRuler);

			ResumeEventsHandling();
		}
			
		private void UpdateFromRuler(NRuler ruler)
		{
			PauseEventsHandling();
			try
			{
				originNumeric.Value = (int)ruler.Origin;
				sizeNumeric.Value = (int)ruler.Size;
				paddingNumeric.Value = (int)ruler.Padding;

				ticksStepModeComboBox.SelectedItem = ruler.MajorTicksStepMode;
				ticksStepNumeric.Value = (int)ruler.FixedMajorTicksStep;

				majorTicksColorButton.Color = ruler.MajorTicksColor;
				minorTicksColorButton.Color = ruler.MinorTicksColor;
				textColorButton.Color = ruler.TextColor;
				backColorButton.Color = ruler.BackColor;
				frameColorButton.Color = ruler.FrameColor;
				coordinateHighlightColorButton.Color = ruler.HighlightCoordinateColor;
				highlightColorButton.Color = ruler.HighlightRangeColor;
			
				measurementUnitButton.SetSystemManagerAndUnit(NMeasurementSystemManager.DefaultMeasurementSystemManager, ruler.MeasurementUnit);
			}
			finally
			{
				ResumeEventsHandling();
			}
		}

		#endregion

		#region Event Handlers

		private void hRulerRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!hRulerRadioButton.Checked)
				return;

			curRuler = view.HorizontalRuler;
			UpdateFromRuler(curRuler);
		}

		private void vRulerRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!vRulerRadioButton.Checked)
				return;

			curRuler = view.VerticalRuler;
			UpdateFromRuler(curRuler);
		}

		private void originNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.Origin = (float)originNumeric.Value;
			view.Refresh();
		}

		private void ticksStepNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.FixedMajorTicksStep = (float)ticksStepNumeric.Value;
			view.Refresh();
		}

		private void sizeNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.Size = (int)sizeNumeric.Value;
			view.Refresh();
		}

		private void paddingNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.Padding = (int)paddingNumeric.Value;
			view.Refresh();
		}

		private void fontButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			FontDialog dialog = new FontDialog();
			dialog.Font = curRuler.TextFontStyle.CreateFont(view.MeasurementUnitConverter);
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			curRuler.TextFontStyle = new NFontStyle(dialog.Font);
			view.Refresh();
		}

		private void majorTicksColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.MajorTicksColor = majorTicksColorButton.Color;
			view.Refresh();
		}

		private void minorTicksColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.MinorTicksColor = minorTicksColorButton.Color;
			view.Refresh();
		}

		private void textColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.TextColor = textColorButton.Color;
			view.Refresh();
		}

		private void backColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.BackColor = backColorButton.Color;
			view.Refresh();
		}

		private void frameColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.FrameColor = frameColorButton.Color;
			view.Refresh();
		}

		private void coordinateHighlightColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.HighlightCoordinateColor = coordinateHighlightColorButton.Color;
			view.Refresh();
		}
		
		private void highlightColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (curRuler == null)
				return;

			curRuler.HighlightRangeColor = highlightColorButton.Color;
			view.Refresh();
		}

		private void ticksStepModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ((AutoStepMode) ticksStepModeComboBox.SelectedItem == AutoStepMode.Fixed)
			{
				ticksStepNumeric.Enabled = true;
			}
			else
			{
				ticksStepNumeric.Enabled = false;
			}

			if (EventsHandlingPaused)
				return;

			if (curRuler == null)
				return;

			if (ticksStepModeComboBox.SelectedIndex == -1)
				return;

			curRuler.MajorTicksStepMode = (AutoStepMode) ticksStepModeComboBox.SelectedItem;
			if (curRuler.MajorTicksStepMode == AutoStepMode.Fixed)
			{
				try
				{
					ticksStepNumeric.Value = (decimal)curRuler.GetUsedMajorTickStep();
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					ticksStepNumeric.Value = ticksStepNumeric.Maximum;
				}
			}

			document.RefreshAllViews();
		}
		
		private void measurementUnitButton_MeasurementUnitChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			try
			{
				curRuler.MeasurementUnit = measurementUnitButton.MeasurementUnit;
			}
			finally
			{
				ResumeEventsHandling();
			}
			
			view.SmartRefresh();
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label12;
		private Nevron.UI.WinForm.Controls.NColorButton coordinateHighlightColorButton;
		private Nevron.UI.WinForm.Controls.NColorButton highlightColorButton;
		private Nevron.Editors.NMeasurementUnitButton measurementUnitButton;
		private Nevron.UI.WinForm.Controls.NComboBox ticksStepModeComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown originNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ticksStepNumeric;
		private Nevron.UI.WinForm.Controls.NButton fontButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown paddingNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown sizeNumeric;
		private Nevron.UI.WinForm.Controls.NColorButton frameColorButton;
		private Nevron.UI.WinForm.Controls.NColorButton backColorButton;
		private Nevron.UI.WinForm.Controls.NColorButton textColorButton;
		private Nevron.UI.WinForm.Controls.NColorButton minorTicksColorButton;
		private Nevron.UI.WinForm.Controls.NColorButton majorTicksColorButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel3;
		private Nevron.UI.WinForm.Controls.NRadioButton vRulerRadioButton;
		private Nevron.UI.WinForm.Controls.NRadioButton hRulerRadioButton;
		private Nevron.UI.WinForm.Controls.NGroupBox appearanceGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox generalGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox colorsGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox majorTicksGroup;
		private System.Windows.Forms.Panel selectRulerPanel;
		private System.Windows.Forms.Panel rulerPropertiesPanel;
		
		#endregion		

		#region Fields

		private NRuler curRuler;

		#endregion
	}
}
