using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAxisSectionsUC : NExampleUC
	{

		private NCartesianChart m_Chart;

		private NScaleSectionStyle m_FirstVerticalSection;
		private NScaleSectionStyle m_SecondVerticalSection;
		private NScaleSectionStyle m_FirstHorizontalSection;
		private NScaleSectionStyle m_SecondHorizontalSection;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Sections");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(12, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(93, NRelativeUnit.ParentPercentage),
				new NLength(85, NRelativeUnit.ParentPercentage));

			// create a point series
			NPointSeries point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.Legend.Mode = SeriesLegendMode.None;
			point.DataLabelStyle.Visible = false;
			point.MarkerStyle.Visible = false;
			point.Size = new NLength(5, NGraphicsUnit.Point);
			point.Values.FillRandom(Random, 30);
			point.ShadowStyle.Type = ShadowType.GaussianBlur;
			point.ShadowStyle.Offset = new NPointL(3, 3);
			point.ShadowStyle.FadeLength = new NLength(5);
			point.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);
			point.InflateMargins = true;

			// tell the x axis to display major and minor grid lines
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MinorTickCount = 1;

			// tell the y axis to display major and minor grid lines
			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MinorTickCount = 1;

			NTextStyle labelStyle;

			// configure the first horizontal section
			m_FirstHorizontalSection = new NScaleSectionStyle();
			m_FirstHorizontalSection.Range = new NRange1DD(2, 8);
			m_FirstHorizontalSection.SetShowAtWall(ChartWallType.Back, true);
			m_FirstHorizontalSection.SetShowAtWall(ChartWallType.Floor, true);
			m_FirstHorizontalSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Red));
			m_FirstHorizontalSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Red);
			m_FirstHorizontalSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkRed);
			m_FirstHorizontalSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 1);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Red, Color.DarkRed);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			m_FirstHorizontalSection.LabelTextStyle = labelStyle;

			// configure the second horizontal section
			m_SecondHorizontalSection = new NScaleSectionStyle();
			m_SecondHorizontalSection.Range = new NRange1DD(14, 18);
			m_SecondHorizontalSection.SetShowAtWall(ChartWallType.Back, true);
			m_SecondHorizontalSection.SetShowAtWall(ChartWallType.Floor, true);
			m_SecondHorizontalSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Green));
			m_SecondHorizontalSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Green);
			m_SecondHorizontalSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkGreen);
			m_SecondHorizontalSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Green, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Green, Color.DarkGreen);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			m_SecondHorizontalSection.LabelTextStyle = labelStyle;

			// configure the first vertical section
			m_FirstVerticalSection = new NScaleSectionStyle();
			m_FirstVerticalSection.Range = new NRange1DD(20, 40);
			m_FirstVerticalSection.SetShowAtWall(ChartWallType.Back, true);
			m_FirstVerticalSection.SetShowAtWall(ChartWallType.Left, true);
			m_FirstVerticalSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Blue));
			m_FirstVerticalSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Blue);
			m_FirstVerticalSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkBlue);
			m_FirstVerticalSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Blue, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Blue, Color.DarkBlue);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			m_FirstVerticalSection.LabelTextStyle = labelStyle;

			// configure the second vertical section
			m_SecondVerticalSection = new NScaleSectionStyle();
			m_SecondVerticalSection.Range = new NRange1DD(70, 90);
			m_SecondVerticalSection.SetShowAtWall(ChartWallType.Back, true);
			m_SecondVerticalSection.SetShowAtWall(ChartWallType.Left, true);
			m_SecondVerticalSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Orange));
			m_SecondVerticalSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Orange);
			m_SecondVerticalSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkOrange);
			m_SecondVerticalSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Orange, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Orange, Color.DarkOrange);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			m_SecondVerticalSection.LabelTextStyle = labelStyle;

			if(!Page.IsPostBack)
			{
				ShowFirstHorizontalSectionCheck.Checked = true;
				ShowSecondHorizontalSectionCheck.Checked = true;
				ShowFirstVerticalSectionCheck.Checked = true;
				ShowSecondVerticalSectionCheck.Checked = true;
			}
			UpdateSections();
		}

		private void UpdateSections()
		{
			NStandardScaleConfigurator standardScale;
					
			// configure horizontal axis sections
			standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			standardScale.Sections.Clear();

			if (ShowFirstHorizontalSectionCheck.Checked)
			{
				standardScale.Sections.Add(m_FirstHorizontalSection);
			}

			if (ShowSecondHorizontalSectionCheck.Checked)
			{
				standardScale.Sections.Add(m_SecondHorizontalSection);
			}

			// configure vertical axis sections
			standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			standardScale.Sections.Clear();

			if (ShowFirstVerticalSectionCheck.Checked)
			{
				standardScale.Sections.Add(m_FirstVerticalSection);
			}

			if (ShowSecondVerticalSectionCheck.Checked)
			{
				standardScale.Sections.Add(m_SecondVerticalSection);
			}
		}

		protected void ShowFirstVerticalSectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		protected void ShowSecondVerticalSectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		protected void ShowFirstHorizontalSectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		protected void ShowSecondHorizontalSectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}
	}
}
