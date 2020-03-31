using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStackedRadarAreaUC : NExampleBaseUC
	{
		private NRadarChart m_Chart;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox TitleAngleModeComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TitleAngleNumericUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox StackModeCombo;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;

		private System.ComponentModel.Container components = null;

		public NStackedRadarAreaUC()
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
			this.StackModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleAngleNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// BeginAngleUpDown
			// 
			this.BeginAngleUpDown.Location = new System.Drawing.Point(9, 90);
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
			this.BeginAngleUpDown.Size = new System.Drawing.Size(157, 20);
			this.BeginAngleUpDown.TabIndex = 1;
			this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Begin Angle:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 135);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Title Angle Mode:";
			// 
			// TitleAngleModeComboBox
			// 
			this.TitleAngleModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.TitleAngleModeComboBox.ListProperties.DataSource = null;
			this.TitleAngleModeComboBox.ListProperties.DisplayMember = "";
			this.TitleAngleModeComboBox.Location = new System.Drawing.Point(9, 152);
			this.TitleAngleModeComboBox.Name = "TitleAngleModeComboBox";
			this.TitleAngleModeComboBox.Size = new System.Drawing.Size(157, 21);
			this.TitleAngleModeComboBox.TabIndex = 7;
			this.TitleAngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleAngleModeComboBox_SelectedIndexChanged);
			// 
			// TitleAngleNumericUpDown
			// 
			this.TitleAngleNumericUpDown.Location = new System.Drawing.Point(9, 197);
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
			this.TitleAngleNumericUpDown.Size = new System.Drawing.Size(157, 20);
			this.TitleAngleNumericUpDown.TabIndex = 9;
			this.TitleAngleNumericUpDown.ValueChanged += new System.EventHandler(this.TitleAngleNumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 183);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Title Angle:";
			// 
			// StackModeCombo
			// 
			this.StackModeCombo.ListProperties.CheckBoxDataMember = "";
			this.StackModeCombo.ListProperties.DataSource = null;
			this.StackModeCombo.ListProperties.DisplayMember = "";
			this.StackModeCombo.Location = new System.Drawing.Point(9, 27);
			this.StackModeCombo.Name = "StackModeCombo";
			this.StackModeCombo.Size = new System.Drawing.Size(157, 21);
			this.StackModeCombo.TabIndex = 11;
			this.StackModeCombo.SelectedIndexChanged += new System.EventHandler(this.StackModeCombo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Stack Mode:";
			// 
			// NStackedRadarAreaUC
			// 
			this.Controls.Add(this.StackModeCombo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TitleAngleNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TitleAngleModeComboBox);
			this.Controls.Add(this.BeginAngleUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NStackedRadarAreaUC";
			this.Size = new System.Drawing.Size(180, 424);
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleAngleNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Radar Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = new NRadarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];

			AddAxis("Category A");
			AddAxis("Category B");
			AddAxis("Category C");
			AddAxis("Category D");
			AddAxis("Category E");

			// create the radar series
			NRadarAreaSeries radarArea0 = new NRadarAreaSeries();
			m_Chart.Series.Add(radarArea0);
			radarArea0.Name = "Series 1";
			radarArea0.Values.FillRandomRange(Random, 5, 50, 90);
			radarArea0.DataLabelStyle.Visible = false;
			radarArea0.DataLabelStyle.Format = "<value>";
			radarArea0.MarkerStyle.AutoDepth = true;
			radarArea0.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea0.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			NRadarAreaSeries radarArea1 = new NRadarAreaSeries();
			m_Chart.Series.Add(radarArea1);
			radarArea1.Name = "Series 2";
			radarArea1.Values.FillRandomRange(Random, 5, 0, 100);
			radarArea1.DataLabelStyle.Visible = false;
			radarArea1.DataLabelStyle.Format = "<value>";
			radarArea1.MarkerStyle.AutoDepth = true;
			radarArea1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			// stack the second radar area series
			radarArea1.MultiAreaMode = MultiAreaMode.Stacked;

			NRadarAreaSeries radarArea2 = new NRadarAreaSeries();
			m_Chart.Series.Add(radarArea2);
			radarArea2.Name = "Series 3";
			radarArea2.Values.FillRandomRange(Random, 5, 0, 100);
			radarArea2.DataLabelStyle.Visible = false;
			radarArea2.DataLabelStyle.Format = "<value>";
			radarArea2.MarkerStyle.AutoDepth = true;
			radarArea2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			// stack the third radar area series
			radarArea2.MultiAreaMode = MultiAreaMode.Stacked;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Charts[0].Series);

			radarArea0.FillStyle.SetTransparencyPercent(20);
			radarArea1.FillStyle.SetTransparencyPercent(20);
			radarArea2.FillStyle.SetTransparencyPercent(20);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// init form controls
			BeginAngleUpDown.Value = 90;

			TitleAngleModeComboBox.FillFromEnum(typeof(ScaleLabelAngleMode));
			TitleAngleModeComboBox.SelectedIndex = (int)ScaleLabelAngleMode.Scale;

			StackModeCombo.Items.Add("Stacked");
			StackModeCombo.Items.Add("Stacked %");
			StackModeCombo.SelectedIndex = 0;
		}

		private void AddAxis(string title)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;

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
			ScaleLabelAngleMode mode = (ScaleLabelAngleMode)TitleAngleModeComboBox.SelectedIndex;
			float angle = (float)TitleAngleNumericUpDown.Value;

			for (int i = 0; i < m_Chart.Axes.Count; i++)
			{
				NRadarAxis axis = (NRadarAxis)m_Chart.Axes[i];
				axis.TitleAngle = new NScaleLabelAngle(mode, angle);
			}

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
		private void StackModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NRadarChart chart = (NRadarChart)nChartControl1.Charts[0];
			NRadarAreaSeries series1 = (NRadarAreaSeries)chart.Series[1];
			NRadarAreaSeries series2 = (NRadarAreaSeries)chart.Series[2];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.Radar).ScaleConfigurator;

			switch (StackModeCombo.SelectedIndex)
			{
				case 0:
					series1.MultiAreaMode = MultiAreaMode.Stacked;
					series2.MultiAreaMode = MultiAreaMode.Stacked;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					series1.MultiAreaMode = MultiAreaMode.StackedPercent;
					series2.MultiAreaMode = MultiAreaMode.StackedPercent;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			nChartControl1.Refresh();
		}
 	}
}
