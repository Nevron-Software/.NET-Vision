using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRadarAxisTitlesUC : NExampleBaseUC
	{
		private NRadarChart m_Chart;
		private NRadarSeries m_RadarArea1;
		private NRadarSeries m_RadarArea2;
		private bool m_Updating;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
		private Label label2;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox TitleAngleModeComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TitleAngleNumericUpDown;
		private Label label1;
		private Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TitleOffsetNumericUpDown;
		private Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox TitlePositionModeComboBox;
		private Label label6;
		private Nevron.UI.WinForm.Controls.NComboBox TitleFitModeComboBox;
		private Label label7;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TitleMaxWidthNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox TitleAutomaticAlignmentCheckBox;
		private System.ComponentModel.Container components = null;

		public NRadarAxisTitlesUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BeginAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TitleAngleModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.TitleAngleNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TitleOffsetNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.TitlePositionModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.TitleFitModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.TitleMaxWidthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.TitleAutomaticAlignmentCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleAngleNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleOffsetNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleMaxWidthNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// BeginAngleUpDown
			// 
			this.BeginAngleUpDown.Location = new System.Drawing.Point(5, 27);
			this.BeginAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.BeginAngleUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.BeginAngleUpDown.Name = "BeginAngleUpDown";
			this.BeginAngleUpDown.Size = new System.Drawing.Size(170, 20);
			this.BeginAngleUpDown.TabIndex = 1;
			this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Begin Angle:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 116);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Title Angle Mode:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// TitleAngleModeComboBox
			// 
			this.TitleAngleModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.TitleAngleModeComboBox.ListProperties.DataSource = null;
			this.TitleAngleModeComboBox.ListProperties.DisplayMember = "";
			this.TitleAngleModeComboBox.Location = new System.Drawing.Point(5, 133);
			this.TitleAngleModeComboBox.Name = "TitleAngleModeComboBox";
			this.TitleAngleModeComboBox.Size = new System.Drawing.Size(170, 21);
			this.TitleAngleModeComboBox.TabIndex = 5;
			this.TitleAngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleAngleModeComboBox_SelectedIndexChanged);
			// 
			// TitleAngleNumericUpDown
			// 
			this.TitleAngleNumericUpDown.Location = new System.Drawing.Point(5, 179);
			this.TitleAngleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.TitleAngleNumericUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.TitleAngleNumericUpDown.Name = "TitleAngleNumericUpDown";
			this.TitleAngleNumericUpDown.Size = new System.Drawing.Size(170, 20);
			this.TitleAngleNumericUpDown.TabIndex = 7;
			this.TitleAngleNumericUpDown.ValueChanged += new System.EventHandler(this.TitleAngleNumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 159);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "Title Angle:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 61);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(170, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "Title Offset:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// TitleOffsetNumericUpDown
			// 
			this.TitleOffsetNumericUpDown.Location = new System.Drawing.Point(5, 82);
			this.TitleOffsetNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.TitleOffsetNumericUpDown.Name = "TitleOffsetNumericUpDown";
			this.TitleOffsetNumericUpDown.Size = new System.Drawing.Size(170, 20);
			this.TitleOffsetNumericUpDown.TabIndex = 3;
			this.TitleOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TitleOffsetNumericUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 214);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Title Position Mode:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// TitlePositionModeComboBox
			// 
			this.TitlePositionModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.TitlePositionModeComboBox.ListProperties.DataSource = null;
			this.TitlePositionModeComboBox.ListProperties.DisplayMember = "";
			this.TitlePositionModeComboBox.Location = new System.Drawing.Point(5, 232);
			this.TitlePositionModeComboBox.Name = "TitlePositionModeComboBox";
			this.TitlePositionModeComboBox.Size = new System.Drawing.Size(170, 21);
			this.TitlePositionModeComboBox.TabIndex = 9;
			this.TitlePositionModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitlePositionModeComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 275);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Title Fit Mode:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// TitleFitModeComboBox
			// 
			this.TitleFitModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.TitleFitModeComboBox.ListProperties.DataSource = null;
			this.TitleFitModeComboBox.ListProperties.DisplayMember = "";
			this.TitleFitModeComboBox.Location = new System.Drawing.Point(5, 292);
			this.TitleFitModeComboBox.Name = "TitleFitModeComboBox";
			this.TitleFitModeComboBox.Size = new System.Drawing.Size(170, 21);
			this.TitleFitModeComboBox.TabIndex = 11;
			this.TitleFitModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleFitModeComboBox_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(5, 316);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(170, 17);
			this.label7.TabIndex = 12;
			this.label7.Text = "Title Max Width:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// TitleMaxWidthNumericUpDown
			// 
			this.TitleMaxWidthNumericUpDown.Location = new System.Drawing.Point(5, 336);
			this.TitleMaxWidthNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.TitleMaxWidthNumericUpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.TitleMaxWidthNumericUpDown.Name = "TitleMaxWidthNumericUpDown";
			this.TitleMaxWidthNumericUpDown.Size = new System.Drawing.Size(170, 20);
			this.TitleMaxWidthNumericUpDown.TabIndex = 13;
			this.TitleMaxWidthNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.TitleMaxWidthNumericUpDown.ValueChanged += new System.EventHandler(this.TitleMaxWidthNumericUpDown_ValueChanged);
			// 
			// TitleAutomaticAlignmentCheckBox
			// 
			this.TitleAutomaticAlignmentCheckBox.ButtonProperties.BorderOffset = 2;
			this.TitleAutomaticAlignmentCheckBox.Location = new System.Drawing.Point(5, 377);
			this.TitleAutomaticAlignmentCheckBox.Name = "TitleAutomaticAlignmentCheckBox";
			this.TitleAutomaticAlignmentCheckBox.Size = new System.Drawing.Size(163, 24);
			this.TitleAutomaticAlignmentCheckBox.TabIndex = 14;
			this.TitleAutomaticAlignmentCheckBox.Text = "Title Automatic Alignment";
			this.TitleAutomaticAlignmentCheckBox.CheckedChanged += new System.EventHandler(this.TitleAutomaticAlignmentCheckBox_CheckedChanged);
			// 
			// NRadarAxisTitlesUC
			// 
			this.Controls.Add(this.TitleAutomaticAlignmentCheckBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.TitleMaxWidthNumericUpDown);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.TitleFitModeComboBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.TitlePositionModeComboBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TitleOffsetNumericUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TitleAngleNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TitleAngleModeComboBox);
			this.Controls.Add(this.BeginAngleUpDown);
			this.Controls.Add(this.label2);
			this.Name = "NRadarAxisTitlesUC";
			this.Size = new System.Drawing.Size(180, 505);
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleAngleNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleOffsetNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleMaxWidthNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Radar Axis Titles<br/><font size = '12pt'>Demonstrates various radar axis title properties</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;

			// configure the chart
			m_Chart = new NRadarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];

			AddAxis("<b>Vitamin A</b><br/><font size='8pt'>(etinol, retinal and four carotenoids including beta carotene</font>");
			AddAxis("<b>Vitamin B1</b><br/><font size='8pt'>thiamin or vitamin B1</font>");
			AddAxis("<b>Vitamin B2</b><br/><font size='8pt'>easily absorbed micronutrient</font>");
			AddAxis("<b>Vitamin B6</b><br/><font size='8pt'>water-soluble vitamin part of the vitamin B complex group</font>");
			AddAxis("<b>Vitamin B12</b><br/><font size='8pt'>also called cobalamin, is a water-soluble vitamin</font>");
			AddAxis("<b>Vitamin C</b><br/><font size='8pt'>or L-ascorbic acid or L-ascorbate is an essential nutrient for humans</font>");
			AddAxis("<b>Vitamin D</b><br/><font size='8pt'>a group of fat-soluble secosteroids</font>");
			AddAxis("<b>Vitamin E</b><br/><font size='8pt'>refers to a group of eight fat-soluble compounds</font>");

			// create the radar series
			m_RadarArea1 = new NRadarAreaSeries();
			m_Chart.Series.Add(m_RadarArea1);
			m_RadarArea1.Name = "Series 1";
			m_RadarArea1.Values.FillRandomRange(Random, 8, 50, 90);
			m_RadarArea1.DataLabelStyle.Visible = false;
			m_RadarArea1.DataLabelStyle.Format = "<value>";
			m_RadarArea1.MarkerStyle.AutoDepth = true;
			m_RadarArea1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_RadarArea1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			m_RadarArea2 = new NRadarAreaSeries();
			m_Chart.Series.Add(m_RadarArea2);
			m_RadarArea2.Name = "Series 2";
			m_RadarArea2.Values.FillRandomRange(Random, 8, 0, 100);
			m_RadarArea2.DataLabelStyle.Visible = false;
			m_RadarArea2.DataLabelStyle.Format = "<value>";
			m_RadarArea2.MarkerStyle.AutoDepth = true;
			m_RadarArea2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_RadarArea2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Charts[0].Series);

			m_RadarArea1.FillStyle.SetTransparencyPercent(50);
			m_RadarArea2.FillStyle.SetTransparencyPercent(60);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// init form controls
			BeginAngleUpDown.Value = 90;

			m_Updating = true;

			TitleAngleModeComboBox.FillFromEnum(typeof(ScaleLabelAngleMode));
			TitleAngleModeComboBox.SelectedIndex = (int)ScaleLabelAngleMode.View;

			TitlePositionModeComboBox.FillFromEnum(typeof(RadarTitlePositionMode));
			TitlePositionModeComboBox.SelectedIndex = (int)RadarTitlePositionMode.Center;

			TitleFitModeComboBox.FillFromEnum(typeof(RadarTitleFitMode));
			TitleFitModeComboBox.SelectedIndex = (int)RadarTitleFitMode.Wrap;

			TitleOffsetNumericUpDown.Value = 5;
			TitleMaxWidthNumericUpDown.Value = 100;


			m_Updating = false;

			UpdateTitleLabels();
		}

		private void AddAxis(string title)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;
			axis.TitleTextStyle.TextFormat = TextFormat.XML;

			// setup scale
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			linearScale.RulerStyle.BorderStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
			linearScale.OuterMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);

			if (m_Chart.Axes.Count == 0)
			{
				// if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro;
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, true);

				// add interlaced stripe
				NScaleStripStyle strip = new NScaleStripStyle();
				strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 200, 200, 200));
				strip.Interlaced = true;
				strip.SetShowAtWall(ChartWallType.Radar, true);
				linearScale.StripStyles.Add(strip);
			}
			else
			{
				// hide labels
				linearScale.AutoLabels = false;
			}

			m_Chart.Axes.Add(axis);
		}

		private void UpdateTitleLabels()
		{
			if (m_Updating || nChartControl1 == null)
				return;

			ScaleLabelAngleMode mode = (ScaleLabelAngleMode)TitleAngleModeComboBox.SelectedIndex;
			float angle = (float)TitleAngleNumericUpDown.Value;

			for (int i = 0; i < m_Chart.Axes.Count; i++)
			{
				NRadarAxis axis = (NRadarAxis)m_Chart.Axes[i];
				axis.TitleAngle = new NScaleLabelAngle(mode, angle);

				axis.TitleOffset = new NLength((float)TitleOffsetNumericUpDown.Value);
				axis.TitlePositionMode = (RadarTitlePositionMode)TitlePositionModeComboBox.SelectedIndex;
				axis.TitleFitMode = (RadarTitleFitMode)TitleFitModeComboBox.SelectedIndex;
				axis.TitleMaxWidth = new NLength((float)TitleMaxWidthNumericUpDown.Value);
				axis.TitleAutomaticAlignment = TitleAutomaticAlignmentCheckBox.Checked;
			}

			TitleMaxWidthNumericUpDown.Enabled = TitleFitModeComboBox.SelectedIndex == (int)RadarTitleFitMode.Wrap;

			nChartControl1.Refresh();
		}

		private void BeginAngleUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Chart.BeginAngle = (float)BeginAngleUpDown.Value;
			nChartControl1.Refresh();
		}

		private void TitleAngleModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}

		private void TitleAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}

		private void TitleOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}

		private void TitlePositionModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}

		private void TitleFitModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}

		private void TitleMaxWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}

		private void TitleAutomaticAlignmentCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}
 	}
}
