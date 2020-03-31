using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NRadarAxisTitlesUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                // init example controls
                WebExamplesUtilities.FillComboWithValues(TitleOffsetDropDownList, 0, 50, 5);
                TitleOffsetDropDownList.SelectedIndex = 1;

                WebExamplesUtilities.FillComboWithEnumValues(TitleAngleModeDropDownList, typeof(ScaleLabelAngleMode));
                TitleAngleModeDropDownList.SelectedIndex = (int)ScaleLabelAngleMode.View;

                WebExamplesUtilities.FillComboWithValues(TitleAngleDropDownList, 0, 360, 10);
                TitleAngleDropDownList.SelectedIndex = 0;

                WebExamplesUtilities.FillComboWithEnumValues(TitlePositionModeDropDownList, typeof(RadarTitlePositionMode));
                TitlePositionModeDropDownList.SelectedIndex = (int)RadarTitlePositionMode.Center;

                WebExamplesUtilities.FillComboWithEnumValues(TitleFitModeDropDownList, typeof(RadarTitleFitMode));
                TitleFitModeDropDownList.SelectedIndex = (int)RadarTitleFitMode.Wrap;

                WebExamplesUtilities.FillComboWithValues(TitleMaxWidthDropDownList, 30, 200, 10);
                TitleMaxWidthDropDownList.SelectedIndex = 2;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Radar Axis Titles");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            title.DockMode = PanelDockMode.Top;
            title.Margins = new NMarginsL(10, 10, 10, 10);

            // hide the legend
            nChartControl1.Legends[0].Visible = false;

            // configure the chart
            NRadarChart chart = new NRadarChart();
            nChartControl1.Charts.Clear();
            nChartControl1.Charts.Add(chart);
			chart.DockMode = PanelDockMode.Fill;
            chart.Margins = new NMarginsL(10, 0, 10, 10);
            chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
            chart.DisplayOnLegend = nChartControl1.Legends[0];

            AddAxis(chart, "<b>Vitamin A</b><br/><font size='7pt'>etinol or retinal</font>");
            AddAxis(chart, "<b>Vitamin B1</b><br/><font size='7pt'>thiamin or vitamin B1</font>");
            AddAxis(chart, "<b>Vitamin B12</b><br/><font size='7pt'>also called cobalamin</font>");
            AddAxis(chart, "<b>Vitamin C</b><br/><font size='7pt'>L-ascorbic acid or L-ascorbate</font>");
            AddAxis(chart, "<b>Vitamin D</b><br/><font size='7pt'>group of fat-soluble secosteroids</font>");
            AddAxis(chart, "<b>Vitamin E</b><br/><font size='7pt'>group of eight fat-soluble compounds</font>");

            // create the radar series
            NRadarAreaSeries m_RadarArea1 = new NRadarAreaSeries();
            chart.Series.Add(m_RadarArea1);
            m_RadarArea1.Name = "Series 1";
            m_RadarArea1.Values.FillRandomRange(Random, 8, 50, 90);
            m_RadarArea1.DataLabelStyle.Visible = false;
            m_RadarArea1.DataLabelStyle.Format = "<value>";
            m_RadarArea1.MarkerStyle.AutoDepth = true;
            m_RadarArea1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            m_RadarArea1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

            NRadarAreaSeries m_RadarArea2 = new NRadarAreaSeries();
            chart.Series.Add(m_RadarArea2);
            m_RadarArea2.Name = "Series 2";
            m_RadarArea2.Values.FillRandomRange(Random, 8, 0, 100);
            m_RadarArea2.DataLabelStyle.Visible = false;
            m_RadarArea2.DataLabelStyle.Format = "<value>";
            m_RadarArea2.MarkerStyle.AutoDepth = true;
            m_RadarArea2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            m_RadarArea2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Bright);
            styleSheet.Apply(nChartControl1.Charts[0].Series);

            m_RadarArea1.FillStyle.SetTransparencyPercent(50);
            m_RadarArea2.FillStyle.SetTransparencyPercent(60);

            // update title labels
			ScaleLabelAngleMode mode = (ScaleLabelAngleMode)TitleAngleModeDropDownList.SelectedIndex;
			float angle = (float)TitleAngleDropDownList.SelectedIndex * 10;

            for (int i = 0; i < chart.Axes.Count; i++)
			{
                NRadarAxis axis = (NRadarAxis)chart.Axes[i];

				axis.TitleAngle = new NScaleLabelAngle(mode, angle);
				axis.TitleOffset = new NLength((float)TitleOffsetDropDownList.SelectedIndex * 5);
				axis.TitlePositionMode = (RadarTitlePositionMode)TitlePositionModeDropDownList.SelectedIndex;
				axis.TitleFitMode = (RadarTitleFitMode)TitleFitModeDropDownList.SelectedIndex;
				axis.TitleMaxWidth = new NLength((float)TitleMaxWidthDropDownList.SelectedIndex * 10 + 30);
				axis.TitleAutomaticAlignment = TitleAutomaticAlignmentCheck.Checked;
			}

            TitleMaxWidthDropDownList.Enabled = TitleFitModeDropDownList.SelectedIndex == (int)RadarTitleFitMode.Wrap;
		}

        private void AddAxis(NRadarChart chart, string title)
        {
            NRadarAxis axis = new NRadarAxis();

            // set title
            axis.Title = title;
            axis.TitleTextStyle.TextFormat = TextFormat.XML;
            axis.TitleTextStyle.FontStyle.EmSize = new NLength(8);

            // setup scale
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

            linearScale.RulerStyle.BorderStyle.Color = Color.Silver;
            linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver;
            linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver;
            linearScale.InnerMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
            linearScale.OuterMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);

            if (chart.Axes.Count == 0)
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

            chart.Axes.Add(axis);
        }
	}
}