using System;
using System.Drawing;

using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NRulerCapsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Axis Ruler Caps<br/> <font size = '9pt'>Demonstrates how to change the caps of the axis ruler</font>");
			header.DockMode = PanelDockMode.Top;
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			header.FitAlignment = ContentAlignment.MiddleLeft;
			header.Margins = new NMarginsL(5, 0, 0, 5);

			nChartControl1.Panels.Add(header);

			NCartesianChart chart = new NCartesianChart();
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(5, 10, 10, 5);
			nChartControl1.Panels.Add(chart);

			Random random = new Random();

			// feed some random data 
			NPointSeries point = new NPointSeries();
			point.DataLabelStyle.Visible = false;
			point.UseXValues = true;
			point.Size = new NLength(5);
			point.BorderStyle.Width = new NLength(0);

			// fill in some random data
			for (int j = 0; j < 30; j++)
			{
				point.Values.Add(5 + random.Next(90));
				point.XValues.Add(5 + random.Next(90));
			}

			chart.Series.Add(point);

			// configure scales
			NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
			xScale.RoundToTickMax = true;
			xScale.RoundToTickMin = true;
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			xScale.ScaleBreaks.Add(new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Orange)), null, new NLength(10)), new NRange1DD(29, 41)));

			// add an interlaced strip to the X axis
			NScaleStripStyle xInterlacedStrip = new NScaleStripStyle();
			xInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
			xInterlacedStrip.Interlaced = true;
			xInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
			xScale.StripStyles.Add(xInterlacedStrip);

			NCartesianAxis xAxis = (NCartesianAxis)chart.Axis(StandardAxis.PrimaryX);
			xAxis.ScaleConfigurator = xScale;
			xAxis.View = new NRangeAxisView(new NRange1DD(0, 100));

			NDockAxisAnchor xAxisAnchor = new NDockAxisAnchor(AxisDockZone.FrontBottom);
			xAxisAnchor.BeforeSpace = new NLength(10);
			xAxis.Anchor = xAxisAnchor;

			NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();
			yScale.RoundToTickMax = true;
			yScale.RoundToTickMin = true;
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			yScale.ScaleBreaks.Add(new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Orange)), null, new NLength(10)), new NRange1DD(29, 41)));

			// add an interlaced strip to the Y axis
			NScaleStripStyle yInterlacedStrip = new NScaleStripStyle();
			yInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
			yInterlacedStrip.Interlaced = true;
			yInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
			yScale.StripStyles.Add(yInterlacedStrip);

			NCartesianAxis yAxis = (NCartesianAxis)chart.Axis(StandardAxis.PrimaryY);
			yAxis.ScaleConfigurator = yScale;
			yAxis.View = new NRangeAxisView(new NRange1DD(0, 100));

			NDockAxisAnchor yAxisAnchor = new NDockAxisAnchor(AxisDockZone.FrontLeft);
			yAxisAnchor.BeforeSpace = new NLength(10);
			yAxis.Anchor = yAxisAnchor;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// update form controls
			if (!IsPostBack)
			{
				PaintOnScaleBreaksCheckBox.Checked = false;

				WebExamplesUtilities.FillComboWithEnumValues(BeginCapStyleDropDownList, typeof(CapStyle));
				BeginCapStyleDropDownList.SelectedIndex = (int)CapStyle.Ellipse;

				WebExamplesUtilities.FillComboWithEnumValues(ScaleBreakCapStyleDropDownList, typeof(CapStyle));
				ScaleBreakCapStyleDropDownList.SelectedIndex = (int)CapStyle.LeftCrossLine;

				WebExamplesUtilities.FillComboWithEnumValues(EndCapStyleDropDownList, typeof(CapStyle));
				EndCapStyleDropDownList.SelectedIndex = (int)CapStyle.Arrow;
			}

			UpdateRulerStyleForAxis(xAxis);
			UpdateRulerStyleForAxis(yAxis);
		}

		private void UpdateRulerStyleForAxis(NAxis axis)
		{
			// Update the ruler caps for the axis from form controls
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			// apply style to begin and end caps
			scale.RulerStyle.BeginCapStyle.Style = (CapStyle)BeginCapStyleDropDownList.SelectedIndex;
			scale.RulerStyle.EndCapStyle.Style = (CapStyle)EndCapStyleDropDownList.SelectedIndex;
			scale.RulerStyle.ScaleBreakCapStyle.Style = (CapStyle)ScaleBreakCapStyleDropDownList.SelectedIndex;
			scale.RulerStyle.PaintOnScaleBreaks = PaintOnScaleBreaksCheckBox.Checked;
		}

	}
}
