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
	public partial class NAxisModelCrossingUC : NExampleUC
	{

		private NChart m_Chart;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithPercents(LengthBottomAxisDropDownList, 10);
				WebExamplesUtilities.FillComboWithPercents(LengthLeftAxisDropDownList, 10);
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Model Crossing <br/> <font size = '9pt'>Demonstrates how to use the model cross anchor</font>");
			header.TextStyle.TextFormat = TextFormat.XML;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(7, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(7, NRelativeUnit.ParentPercentage),
				new NLength(18, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(86, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

            // configure scales
            NLinearScaleConfigurator yScaleConfigurator = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle yStripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            yStripStyle.SetShowAtWall(ChartWallType.Back, true);
            yStripStyle.Interlaced = true;
            yScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            yScaleConfigurator.StripStyles.Add(yStripStyle);

            NLinearScaleConfigurator xScaleConfigurator = new NLinearScaleConfigurator();
            NScaleStripStyle xStripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            xStripStyle.SetShowAtWall(ChartWallType.Back, true);
            xStripStyle.Interlaced = true;
            xScaleConfigurator.StripStyles.Add(xStripStyle);
            xScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScaleConfigurator;

			// cross X and Y axes
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor = new NCrossAxisAnchor(AxisOrientation.Horizontal, new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), 0));
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor.RulerOrientation = RulerOrientation.Right;
			m_Chart.Axis(StandardAxis.PrimaryY).Anchor = new NCrossAxisAnchor(AxisOrientation.Vertical, new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), 0));

			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;

			// setup bubble series
			NBubbleSeries bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			bubble.Name = "Bubble Series";
			bubble.InflateMargins = true;
			bubble.DataLabelStyle.Visible = false;
			bubble.UseXValues = true;
            bubble.ShadowStyle.Type = ShadowType.GaussianBlur;
			bubble.BubbleShape = PointShape.Sphere;
			bubble.Legend.Mode = SeriesLegendMode.None;

			// fill with random data
			bubble.Values.FillRandomRange(Random, 10, -20, 20);
			bubble.XValues.FillRandomRange(Random, 10, -20, 20);
			bubble.Sizes.FillRandomRange(Random, 10, 1, 6);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			UpdateCrossings();
		}

		private void UpdateCrossings()
		{
			NAxis xAxis = m_Chart.Axis(StandardAxis.PrimaryX);
			NAxis yAxis = m_Chart.Axis(StandardAxis.PrimaryY);

			NCrossAxisAnchor crossAnchor; 
			
			// update the x axis anchor
			crossAnchor = new NCrossAxisAnchor();
			xAxis.Anchor = crossAnchor;
			crossAnchor.AxisOrientation = AxisOrientation.Horizontal;
			crossAnchor.Crossings.Add(new NModelAxisCrossing(yAxis, (HorzAlign)BottomAxisDropDownList.SelectedIndex, new NLength(LengthBottomAxisDropDownList.SelectedIndex *10, NRelativeUnit.ParentPercentage)));
				
			// update the y axis anchor
			crossAnchor = new NCrossAxisAnchor();
			crossAnchor.AxisOrientation = AxisOrientation.Vertical;
			yAxis.Anchor = crossAnchor;
			crossAnchor.Crossings.Add(new NModelAxisCrossing(xAxis, (HorzAlign)LeftAxisAligmentDropDownList.SelectedIndex, new NLength(LengthLeftAxisDropDownList.SelectedIndex*10, NRelativeUnit.ParentPercentage)));
		}
	}
}
