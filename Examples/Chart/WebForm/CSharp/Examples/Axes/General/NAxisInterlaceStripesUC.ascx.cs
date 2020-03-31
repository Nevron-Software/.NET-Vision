using System;
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
	public partial class NAxisInterlaceStripesUC : NExampleUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private NScaleStripStyle m_YAxisInterlaceStyle;
		private NScaleStripStyle m_XAxisInterlaceStyle;
		private NCartesianChart m_Chart;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Interlaced Stripes");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			NLineSeries line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			line.Name = "Line Series";
            line.DataLabelStyle.Format = "<value>";
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Sphere;
			line.MarkerStyle.FillStyle = new NColorFillStyle(Color.Red);
			line.LineSegmentShape = LineSegmentShape.Tape;
			line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Point);
			line.BorderStyle.Color = Color.DarkSlateBlue;
			line.DataLabelStyle.Visible = false;
			line.Legend.Mode = SeriesLegendMode.None;
			line.Values.FillRandom(Random, 20);
			line.ShadowStyle.Type = ShadowType.GaussianBlur;
			line.ShadowStyle.Offset = new NPointL(3, 3);
			line.ShadowStyle.FadeLength = new NLength(5);
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);

			m_YAxisInterlaceStyle = new NScaleStripStyle();
			m_YAxisInterlaceStyle.SetShowAtWall(ChartWallType.Back, true);
			m_YAxisInterlaceStyle.SetShowAtWall(ChartWallType.Left, true);
			m_YAxisInterlaceStyle.Interlaced = true;
			m_YAxisInterlaceStyle.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.FromArgb(125, Color.PaleTurquoise), Color.FromArgb(125, Color.MediumAquamarine));
			m_YAxisInterlaceStyle.Begin = 0;
			m_YAxisInterlaceStyle.End = 10;
			m_YAxisInterlaceStyle.Infinite = true;
			m_YAxisInterlaceStyle.Interval = 1;
			m_YAxisInterlaceStyle.Length = 1;

			m_XAxisInterlaceStyle = new NScaleStripStyle();
			m_XAxisInterlaceStyle.SetShowAtWall(ChartWallType.Back, true);
			m_XAxisInterlaceStyle.SetShowAtWall(ChartWallType.Floor, true);
			m_XAxisInterlaceStyle.Interlaced = true;
			m_XAxisInterlaceStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.SteelBlue), Color.FromArgb(125, Color.SlateGray));
			m_XAxisInterlaceStyle.Begin = 0;
			m_XAxisInterlaceStyle.End = 10;
			m_XAxisInterlaceStyle.Infinite = true;
			m_XAxisInterlaceStyle.Interval = 1;
			m_XAxisInterlaceStyle.Length = 1;

			if(!Page.IsPostBack)
			{
				YAxisInterlacedStripesCheckBox.Checked = true;
			}

			UpdateInterlaceStirpes();
		}

		private void UpdateInterlaceStirpes()
		{
			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.StripStyles.Clear();
			if (YAxisInterlacedStripesCheckBox.Checked)
			{
				standardScale.StripStyles.Add(m_YAxisInterlaceStyle);
			}

			m_YAxisInterlaceStyle.Begin = 0;
			m_YAxisInterlaceStyle.End = 10;
			m_YAxisInterlaceStyle.Infinite = true;
			m_YAxisInterlaceStyle.Length = 1;
			m_YAxisInterlaceStyle.Interval = 1;
			
			standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			standardScale.StripStyles.Clear();
			if (XAxisInterlacedStripesCheckBox.Checked)
			{
				standardScale.StripStyles.Add(m_XAxisInterlaceStyle);
			}

			m_XAxisInterlaceStyle.Begin = 0;
			m_XAxisInterlaceStyle.End = 10;
			m_XAxisInterlaceStyle.Infinite = true;
			m_XAxisInterlaceStyle.Length = 1;
			m_XAxisInterlaceStyle.Interval = 1;

		}
	}
}
