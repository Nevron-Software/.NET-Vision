using System;
using System.Resources;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NValueTimelineScaleAdvancedUC : NExampleBaseUC
	{
		NCartesianChart m_Chart;
		NStockSeries m_Stock;

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox ThirdRowVisibleCheckBox;
		private Nevron.UI.WinForm.Controls.NComboBox ThirdRowModeComboBox;
		private System.Windows.Forms.Label label12;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ThirdRowUnitCountUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox ThirdRowUnitComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox SecondRowVisibleCheckBox;
		private Nevron.UI.WinForm.Controls.NComboBox SecondRowModeComboBox;
		private System.Windows.Forms.Label label8;
		private Nevron.UI.WinForm.Controls.NComboBox SecondRowUnitComboBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NNumericUpDown SecondRowUnitCountUpDown;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox FirstRowVisibleCheckBox;
		private Nevron.UI.WinForm.Controls.NComboBox FirstRowModeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox FirstRowUnitComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private NButton ThirdRowTextStyleButton;
		private NButton SecondRowTextStyleButton;
		private NButton FirstRowTextStyleButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown FirstRowUnitCountUpDown;

		public NValueTimelineScaleAdvancedUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label2 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ThirdRowVisibleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ThirdRowModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.ThirdRowUnitCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ThirdRowUnitComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.SecondRowVisibleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SecondRowModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.SecondRowUnitComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SecondRowUnitCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.FirstRowVisibleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.FirstRowModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.FirstRowUnitComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.FirstRowUnitCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.FirstRowTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SecondRowTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ThirdRowTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ThirdRowUnitCountUpDown)).BeginInit();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SecondRowUnitCountUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FirstRowUnitCountUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mode:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 73);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 13);
			this.label11.TabIndex = 3;
			this.label11.Text = "Unit:";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 95);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(37, 16);
			this.label10.TabIndex = 5;
			this.label10.Text = "Count:";
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.ThirdRowTextStyleButton);
			this.nGroupBox2.Controls.Add(this.ThirdRowVisibleCheckBox);
			this.nGroupBox2.Controls.Add(this.ThirdRowModeComboBox);
			this.nGroupBox2.Controls.Add(this.label12);
			this.nGroupBox2.Controls.Add(this.ThirdRowUnitCountUpDown);
			this.nGroupBox2.Controls.Add(this.ThirdRowUnitComboBox);
			this.nGroupBox2.Controls.Add(this.label10);
			this.nGroupBox2.Controls.Add(this.label11);
			this.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(0, 314);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(235, 164);
			this.nGroupBox2.TabIndex = 13;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Third Row";
			// 
			// ThirdRowVisibleCheckBox
			// 
			this.ThirdRowVisibleCheckBox.AutoSize = true;
			this.ThirdRowVisibleCheckBox.ButtonProperties.BorderOffset = 2;
			this.ThirdRowVisibleCheckBox.Location = new System.Drawing.Point(6, 18);
			this.ThirdRowVisibleCheckBox.Name = "ThirdRowVisibleCheckBox";
			this.ThirdRowVisibleCheckBox.Size = new System.Drawing.Size(108, 17);
			this.ThirdRowVisibleCheckBox.TabIndex = 0;
			this.ThirdRowVisibleCheckBox.Text = "Third Row Visible";
			this.ThirdRowVisibleCheckBox.UseVisualStyleBackColor = true;
			this.ThirdRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.ThirdRowVisibleCheckBox_CheckedChanged);
			// 
			// ThirdRowModeComboBox
			// 
			this.ThirdRowModeComboBox.Location = new System.Drawing.Point(65, 39);
			this.ThirdRowModeComboBox.Name = "ThirdRowModeComboBox";
			this.ThirdRowModeComboBox.Size = new System.Drawing.Size(156, 21);
			this.ThirdRowModeComboBox.TabIndex = 2;
			this.ThirdRowModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdRowModeComboBox_SelectedIndexChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 47);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(37, 13);
			this.label12.TabIndex = 1;
			this.label12.Text = "Mode:";
			// 
			// ThirdRowUnitCountUpDown
			// 
			this.ThirdRowUnitCountUpDown.Location = new System.Drawing.Point(65, 91);
			this.ThirdRowUnitCountUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.ThirdRowUnitCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ThirdRowUnitCountUpDown.Name = "ThirdRowUnitCountUpDown";
			this.ThirdRowUnitCountUpDown.Size = new System.Drawing.Size(156, 20);
			this.ThirdRowUnitCountUpDown.TabIndex = 6;
			this.ThirdRowUnitCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ThirdRowUnitCountUpDown.ValueChanged += new System.EventHandler(this.ThirdRowUnitCountUpDown_ValueChanged);
			// 
			// ThirdRowUnitComboBox
			// 
			this.ThirdRowUnitComboBox.Location = new System.Drawing.Point(65, 65);
			this.ThirdRowUnitComboBox.Name = "ThirdRowUnitComboBox";
			this.ThirdRowUnitComboBox.Size = new System.Drawing.Size(156, 21);
			this.ThirdRowUnitComboBox.TabIndex = 4;
			this.ThirdRowUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdRowUnitComboBox_SelectedIndexChanged);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.SecondRowTextStyleButton);
			this.nGroupBox1.Controls.Add(this.SecondRowVisibleCheckBox);
			this.nGroupBox1.Controls.Add(this.SecondRowModeComboBox);
			this.nGroupBox1.Controls.Add(this.label8);
			this.nGroupBox1.Controls.Add(this.SecondRowUnitComboBox);
			this.nGroupBox1.Controls.Add(this.label7);
			this.nGroupBox1.Controls.Add(this.label6);
			this.nGroupBox1.Controls.Add(this.SecondRowUnitCountUpDown);
			this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(0, 149);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(235, 165);
			this.nGroupBox1.TabIndex = 12;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Second Row";
			// 
			// SecondRowVisibleCheckBox
			// 
			this.SecondRowVisibleCheckBox.AutoSize = true;
			this.SecondRowVisibleCheckBox.ButtonProperties.BorderOffset = 2;
			this.SecondRowVisibleCheckBox.Location = new System.Drawing.Point(6, 19);
			this.SecondRowVisibleCheckBox.Name = "SecondRowVisibleCheckBox";
			this.SecondRowVisibleCheckBox.Size = new System.Drawing.Size(121, 17);
			this.SecondRowVisibleCheckBox.TabIndex = 0;
			this.SecondRowVisibleCheckBox.Text = "Second Row Visible";
			this.SecondRowVisibleCheckBox.UseVisualStyleBackColor = true;
			this.SecondRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.SecondRowVisibleCheckBox_CheckedChanged);
			// 
			// SecondRowModeComboBox
			// 
			this.SecondRowModeComboBox.Location = new System.Drawing.Point(65, 40);
			this.SecondRowModeComboBox.Name = "SecondRowModeComboBox";
			this.SecondRowModeComboBox.Size = new System.Drawing.Size(156, 21);
			this.SecondRowModeComboBox.TabIndex = 2;
			this.SecondRowModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondRowModeComboBox_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 1;
			this.label8.Text = "Mode:";
			// 
			// SecondRowUnitComboBox
			// 
			this.SecondRowUnitComboBox.Location = new System.Drawing.Point(65, 66);
			this.SecondRowUnitComboBox.Name = "SecondRowUnitComboBox";
			this.SecondRowUnitComboBox.Size = new System.Drawing.Size(156, 21);
			this.SecondRowUnitComboBox.TabIndex = 4;
			this.SecondRowUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondRowUnitComboBox_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 74);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Unit:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Count:";
			// 
			// SecondRowUnitCountUpDown
			// 
			this.SecondRowUnitCountUpDown.Location = new System.Drawing.Point(65, 92);
			this.SecondRowUnitCountUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.SecondRowUnitCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SecondRowUnitCountUpDown.Name = "SecondRowUnitCountUpDown";
			this.SecondRowUnitCountUpDown.Size = new System.Drawing.Size(156, 20);
			this.SecondRowUnitCountUpDown.TabIndex = 6;
			this.SecondRowUnitCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SecondRowUnitCountUpDown.ValueChanged += new System.EventHandler(this.SecondRowUnitCountUpDown_ValueChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.FirstRowTextStyleButton);
			this.groupBox2.Controls.Add(this.FirstRowVisibleCheckBox);
			this.groupBox2.Controls.Add(this.FirstRowModeComboBox);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.FirstRowUnitComboBox);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.FirstRowUnitCountUpDown);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(235, 149);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "First Row";
			// 
			// FirstRowVisibleCheckBox
			// 
			this.FirstRowVisibleCheckBox.AutoSize = true;
			this.FirstRowVisibleCheckBox.ButtonProperties.BorderOffset = 2;
			this.FirstRowVisibleCheckBox.Location = new System.Drawing.Point(6, 19);
			this.FirstRowVisibleCheckBox.Name = "FirstRowVisibleCheckBox";
			this.FirstRowVisibleCheckBox.Size = new System.Drawing.Size(103, 17);
			this.FirstRowVisibleCheckBox.TabIndex = 0;
			this.FirstRowVisibleCheckBox.Text = "First Row Visible";
			this.FirstRowVisibleCheckBox.UseVisualStyleBackColor = true;
			this.FirstRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.FirstRowVisibleCheckBox_CheckedChanged);
			// 
			// FirstRowModeComboBox
			// 
			this.FirstRowModeComboBox.Location = new System.Drawing.Point(65, 40);
			this.FirstRowModeComboBox.Name = "FirstRowModeComboBox";
			this.FirstRowModeComboBox.Size = new System.Drawing.Size(156, 21);
			this.FirstRowModeComboBox.TabIndex = 2;
			this.FirstRowModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstRowModeComboBox_SelectedIndexChanged);
			// 
			// FirstRowUnitComboBox
			// 
			this.FirstRowUnitComboBox.Location = new System.Drawing.Point(65, 66);
			this.FirstRowUnitComboBox.Name = "FirstRowUnitComboBox";
			this.FirstRowUnitComboBox.Size = new System.Drawing.Size(156, 21);
			this.FirstRowUnitComboBox.TabIndex = 4;
			this.FirstRowUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstRowUnitComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Unit:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Count:";
			// 
			// FirstRowUnitCountUpDown
			// 
			this.FirstRowUnitCountUpDown.Location = new System.Drawing.Point(65, 92);
			this.FirstRowUnitCountUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.FirstRowUnitCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.FirstRowUnitCountUpDown.Name = "FirstRowUnitCountUpDown";
			this.FirstRowUnitCountUpDown.Size = new System.Drawing.Size(156, 20);
			this.FirstRowUnitCountUpDown.TabIndex = 6;
			this.FirstRowUnitCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.FirstRowUnitCountUpDown.ValueChanged += new System.EventHandler(this.FirstRowUnitCountUpDown_ValueChanged);
			// 
			// FirstRowTextStyleButton
			// 
			this.FirstRowTextStyleButton.Location = new System.Drawing.Point(9, 118);
			this.FirstRowTextStyleButton.Name = "FirstRowTextStyleButton";
			this.FirstRowTextStyleButton.Size = new System.Drawing.Size(212, 23);
			this.FirstRowTextStyleButton.TabIndex = 7;
			this.FirstRowTextStyleButton.Text = "First Row Text Style...";
			this.FirstRowTextStyleButton.Click += new System.EventHandler(this.FirstRowTextStyleButton_Click);
			// 
			// SecondRowTextStyleButton
			// 
			this.SecondRowTextStyleButton.Location = new System.Drawing.Point(6, 118);
			this.SecondRowTextStyleButton.Name = "SecondRowTextStyleButton";
			this.SecondRowTextStyleButton.Size = new System.Drawing.Size(215, 23);
			this.SecondRowTextStyleButton.TabIndex = 8;
			this.SecondRowTextStyleButton.Text = "Second Row Text Style...";
			this.SecondRowTextStyleButton.Click += new System.EventHandler(this.SecondRowTextStyleButton_Click);
			// 
			// ThirdRowTextStyleButton
			// 
			this.ThirdRowTextStyleButton.Location = new System.Drawing.Point(6, 117);
			this.ThirdRowTextStyleButton.Name = "ThirdRowTextStyleButton";
			this.ThirdRowTextStyleButton.Size = new System.Drawing.Size(215, 23);
			this.ThirdRowTextStyleButton.TabIndex = 9;
			this.ThirdRowTextStyleButton.Text = "Third Row Text Style...";
			this.ThirdRowTextStyleButton.Click += new System.EventHandler(this.ThirdRowTextStyleButton_Click);
			// 
			// NValueTimelineScaleAdvancedUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "NValueTimelineScaleAdvancedUC";
			this.Size = new System.Drawing.Size(235, 587);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ThirdRowUnitCountUpDown)).EndInit();
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SecondRowUnitCountUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FirstRowUnitCountUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Range Timeline Scale Advanced<br/><font size = '9pt'>Demonstrates how to use a timeline scale to show date/time information on the X axis</font>");
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(0, 10, 0, 10);
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(header);

			// setup chart
			m_Chart = new NCartesianChart();
			nChartControl1.Panels.Add(m_Chart);
			m_Chart.DockMode = PanelDockMode.Fill;
			m_Chart.Margins = new NMarginsL(10, 0, 10, 10);
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.EnableLighting = false;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Height = 40;

			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			m_Chart.RangeSelections.Add(rangeSelection);

			// setup X axis
			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryX);
			axis.ScrollBar.Visible = true;
			NValueTimelineScaleConfigurator timeLineScale = new NValueTimelineScaleConfigurator();
			timeLineScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			timeLineScale.SecondRow.GridStyle.SetShowAtWall(ChartWallType.Back, true);
			timeLineScale.ThirdRow.GridStyle.SetShowAtWall(ChartWallType.Back, true);
			axis.ScaleConfigurator = timeLineScale;

			// setup primary Y axis
			axis = m_Chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);
			linearScale.InnerMajorTickStyle.Length = new NLength(0);

			// add interlaced stripe 
			NScaleStripStyle stripStyle = new NScaleStripStyle();
			stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// Setup the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue;
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.CloseValues.Name = "close";
			m_Stock.UseXValues = true;

			// configure interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// generate some data
			MonthlyDataButton_Click(null, null);

			// init form controls
			FirstRowModeComboBox.FillFromEnum(typeof(TimelineScaleRowTickMode));
			FirstRowModeComboBox.SelectedIndex = (int)TimelineScaleRowTickMode.AutoMinDistance;
			FirstRowUnitComboBox.FillFromEnum(typeof(DateTimeUnit));
			FirstRowUnitComboBox.SelectedIndex = 0;
			FirstRowUnitCountUpDown.Value = 1;
			FirstRowVisibleCheckBox.Checked = true;

			SecondRowModeComboBox.FillFromEnum(typeof(TimelineScaleRowTickMode));
			SecondRowModeComboBox.SelectedIndex = (int)TimelineScaleRowTickMode.AutoMinDistance;
			SecondRowUnitComboBox.FillFromEnum(typeof(DateTimeUnit));
			SecondRowUnitComboBox.SelectedIndex = 0;
			SecondRowUnitCountUpDown.Value = 1;
			SecondRowVisibleCheckBox.Checked = true;

			ThirdRowModeComboBox.FillFromEnum(typeof(TimelineScaleRowTickMode));
			ThirdRowModeComboBox.SelectedIndex = (int)TimelineScaleRowTickMode.AutoMinDistance;
			ThirdRowUnitComboBox.FillFromEnum(typeof(DateTimeUnit));
			ThirdRowUnitComboBox.SelectedIndex = 0;
			ThirdRowUnitCountUpDown.Value = 1;
			ThirdRowVisibleCheckBox.Checked = true;
		}

		private void UpdateScale()
		{
			if (m_Chart == null)
				return;

			ConfigureScaleRow(0, FirstRowVisibleCheckBox, FirstRowModeComboBox, FirstRowUnitComboBox, FirstRowUnitCountUpDown);
			ConfigureScaleRow(1, SecondRowVisibleCheckBox, SecondRowModeComboBox, SecondRowUnitComboBox, SecondRowUnitCountUpDown);
			ConfigureScaleRow(2, ThirdRowVisibleCheckBox, ThirdRowModeComboBox, ThirdRowUnitComboBox, ThirdRowUnitCountUpDown);

			nChartControl1.Refresh();
		}

		private void ConfigureScaleRow(int rowIndex, NCheckBox visibleCheckBox, NComboBox rowModeComboBox, NComboBox rowUnitComboBox, NNumericUpDown rowUnitCountUpDown)
		{
			NValueTimelineScaleConfigurator valueTimelineScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NValueTimelineScaleConfigurator;
			NTimelineScaleRow scaleRow;

			if (rowIndex == 0)
			{
				scaleRow = valueTimelineScale.FirstRow;
			}
			else if (rowIndex == 1)
			{
				scaleRow = valueTimelineScale.SecondRow;
			}
			else
			{
				scaleRow = valueTimelineScale.ThirdRow;
			}

			scaleRow.Visible = visibleCheckBox.Checked;

			bool enableUnitControls = false;
			switch ((TimelineScaleRowTickMode)rowModeComboBox.SelectedIndex)
			{
				case TimelineScaleRowTickMode.AutoMinDistance:
					scaleRow.TickMode = TimelineScaleRowTickMode.AutoMinDistance;
					break;
				case TimelineScaleRowTickMode.AutoMaxCount:
					scaleRow.TickMode = TimelineScaleRowTickMode.AutoMaxCount;
					break;
				case TimelineScaleRowTickMode.Custom:
					enableUnitControls = true;
					scaleRow.TickMode = TimelineScaleRowTickMode.Custom;
					scaleRow.CustomStep = new NDateTimeSpan((int)rowUnitCountUpDown.Value, NDateTimeUnit.GetFromEnum((DateTimeUnit)rowUnitComboBox.SelectedIndex));
					break;
			}

			rowUnitComboBox.Enabled = enableUnitControls;
			rowUnitCountUpDown.Enabled = enableUnitControls;
		}
		
		private void GenerateData(DateTime dtStart, DateTime dtEnd, NDateTimeSpan span)
		{
			long count = span.GetSpanCountInRange(new NDateTimeRange(dtStart, dtEnd));

			GenerateOHLCData(m_Stock, 100, (int)count);
			m_Stock.XValues.Clear();

			DateTime dtNow = dtStart;

			for (int i = 0; i < m_Stock.Values.Count; i++)
			{
				m_Stock.XValues.Add(dtNow.ToOADate());
				dtNow = span.Add(dtNow);
			}

			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = false;

			nChartControl1.Refresh();
		}

		private void DailyDataButton_Click(object sender, EventArgs e)
		{
			// generate data for 30 days
			DateTime dtNow = DateTime.Now;
			DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 17, 0, 0, 0);
			DateTime dtStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);

			GenerateData(dtStart, dtEnd, new NDateTimeSpan(5, NDateTimeUnit.Minute));
		}

		private void WeeklyDataButton_Click(object sender, EventArgs e)
		{
			// generate data for 30 weeks
			DateTime dtNow = DateTime.Now;
			DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
			DateTime dtStart = NDateTimeUnit.Week.Add(dtEnd, -30);

			GenerateData(dtStart, dtEnd, new NDateTimeSpan(1, NDateTimeUnit.Day));
		}

		private void MonthlyDataButton_Click(object sender, EventArgs e)
		{
			// generate data for 30 months 
			DateTime dtNow = DateTime.Now;
			DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
			DateTime dtStart = NDateTimeUnit.Month.Add(dtEnd, -30);

			GenerateData(dtStart, dtEnd, new NDateTimeSpan(1, NDateTimeUnit.Week));
		}

		private void YearyDataButton_Click(object sender, EventArgs e)
		{
			// generate data for 30 years
			DateTime dtNow = DateTime.Now;
			DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
			DateTime dtStart = NDateTimeUnit.Year.Add(dtEnd, -30);

			GenerateData(dtStart, dtEnd, new NDateTimeSpan(1, NDateTimeUnit.Month));
		}

		private void FirstRowVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void FirstRowModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void FirstRowUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void FirstRowUnitCountUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void SecondRowVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void SecondRowModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void SecondRowUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void SecondRowUnitCountUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void ThirdRowVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void ThirdRowModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void ThirdRowUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void ThirdRowUnitCountUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void FirstRowTextStyleButton_Click(object sender, EventArgs e)
		{
			NValueTimelineScaleConfigurator valueTimelineScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NValueTimelineScaleConfigurator;
			NTextStyle result = null;

			if (NTextStyleTypeEditor.Edit(valueTimelineScale.FirstRow.LabelStyle.TextStyle, out result))
			{
				valueTimelineScale.FirstRow.LabelStyle.TextStyle = result;
				nChartControl1.Refresh();
			}
		}

		private void SecondRowTextStyleButton_Click(object sender, EventArgs e)
		{
			NValueTimelineScaleConfigurator valueTimelineScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NValueTimelineScaleConfigurator;
			NTextStyle result = null;

			if (NTextStyleTypeEditor.Edit(valueTimelineScale.SecondRow.LabelStyle.TextStyle, out result))
			{
				valueTimelineScale.SecondRow.LabelStyle.TextStyle = result;
				nChartControl1.Refresh();
			}
		}

		private void ThirdRowTextStyleButton_Click(object sender, EventArgs e)
		{
			NValueTimelineScaleConfigurator valueTimelineScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NValueTimelineScaleConfigurator;
			NTextStyle result = null;

			if (NTextStyleTypeEditor.Edit(valueTimelineScale.ThirdRow.LabelStyle.TextStyle, out result))
			{
				valueTimelineScale.ThirdRow.LabelStyle.TextStyle = result;
				nChartControl1.Refresh();
			}
		}
	}
}
