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
	public partial class NRulesSizeUC : NExampleUC
	{

		private NChart nChart;
		private int nCustomAxisId;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithPercents(RedAxisEndPercentDropDownList, 1);
				WebExamplesUtilities.FillComboWithPercents(BlueAxisEndPercentDropDownList, 1);

				RedAxisEndPercentDropDownList.SelectedIndex = 40;
				BlueAxisEndPercentDropDownList.SelectedIndex = 60;
			}

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Docking and Anchor Percentages<br/> <font size = '9pt'>Demonstrates how to dock axes without creating a new zone level</font>");
			header.TextStyle.TextFormat = TextFormat.XML;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

            nChart = nChartControl1.Charts[0];
			nChart.Enable3D = true;
            nChart.BoundsMode = BoundsMode.Fit;
            nChart.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            nChart.Size = new NSizeL(new NLength(96, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

            // apply predefined lighting and projection
            nChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

            // configure primary Y
            NAxis primaryY = nChart.Axis(StandardAxis.PrimaryY);
            primaryY.Anchor.BeginPercent = 0;
            primaryY.Anchor.EndPercent = 30;

            // configure secondary Y
            NAxis secondaryY = nChart.Axis(StandardAxis.SecondaryY);
            secondaryY.Visible = true;
            secondaryY.Anchor.BeginPercent = 30;
            secondaryY.Anchor.EndPercent = 70;

            // configure a custom axis docked to the front left left chart zone
            NAxis customY = ((NCartesianAxisCollection)nChart.Axes).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft);
            customY.Visible = true;
            customY.Anchor.BeginPercent = 70;
            customY.Anchor.EndPercent = 100;
            nCustomAxisId = customY.AxisId;

            // Setup the line series
            NLineSeries l1 = (NLineSeries)nChart.Series.Add(SeriesType.Line);
            l1.Values.FillRandom(Random, 5);
            l1.LineSegmentShape = LineSegmentShape.Tape;
            l1.DataLabelStyle.Format = "<value>";

            NLineSeries l2 = (NLineSeries)nChart.Series.Add(SeriesType.Line);
            l2.Values.FillRandom(Random, 5);
            l2.LineSegmentShape = LineSegmentShape.Tape;
            l2.DataLabelStyle.Format = "<value>";
            l2.DisplayOnAxis(StandardAxis.SecondaryY, true);
            l2.DisplayOnAxis(StandardAxis.PrimaryY, false);

            NLineSeries l3 = (NLineSeries)nChart.Series.Add(SeriesType.Line);
            l3.Values.FillRandom(Random, 5);
            l3.LineSegmentShape = LineSegmentShape.Tape;
            l3.DataLabelStyle.Format = "<value>";
            l3.DisplayOnAxis(nCustomAxisId, true);
            l3.DisplayOnAxis(StandardAxis.PrimaryY, false);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // set up the appearance of the axes according to the filling/stroke 
            // applied to the line series from the style sheet
            primaryY.ScaleConfigurator = ConfigureScale(l1.FillStyle, l1.BorderStyle.Color);
            secondaryY.ScaleConfigurator = ConfigureScale(l2.FillStyle, l2.BorderStyle.Color);
            customY.ScaleConfigurator = ConfigureScale(l3.FillStyle, l3.BorderStyle.Color);

			RecalcAxes();
		}

        private NLinearScaleConfigurator ConfigureScale(NFillStyle rulerFillStyle, Color tickColor)
        {
            NLinearScaleConfigurator scale = new NLinearScaleConfigurator();

            scale.RulerStyle.FillStyle = (NFillStyle)rulerFillStyle.Clone();
            scale.RulerStyle.Shape = ScaleLevelShape.Bar;
            scale.RulerStyle.Height = new NLength(5, NGraphicsUnit.Point);
            scale.RulerStyle.BorderStyle.Color = tickColor;
            scale.OuterMajorTickStyle.LineStyle.Color = tickColor;
            scale.InnerMajorTickStyle.LineStyle.Color = tickColor;
            scale.MajorGridStyle.LineStyle.Color = tickColor;

            NScaleStripStyle strip = new NScaleStripStyle();
            strip.StrokeStyle = null;
            strip.FillStyle = (NFillStyle)rulerFillStyle.Clone();
            strip.FillStyle.SetTransparencyPercent(80);
            strip.SetShowAtWall(ChartWallType.Back, true);
            strip.SetShowAtWall(ChartWallType.Left, true);
            scale.StripStyles.Add(strip);

            scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            scale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

            return scale;
        }

		private void RecalcAxes()
		{
			int bottomAxisEnd = Convert.ToInt32(RedAxisEndPercentDropDownList.SelectedIndex);
			int middleAxisBegin = Convert.ToInt32(RedAxisEndPercentDropDownList.SelectedIndex);
			int middleAxisEnd = Convert.ToInt32(BlueAxisEndPercentDropDownList.SelectedIndex);
			int topAxisBegin = Convert.ToInt32(BlueAxisEndPercentDropDownList.SelectedIndex);

			// red axis
			NAxis axis = nChart.Axis(StandardAxis.PrimaryY);
			axis.Anchor.EndPercent = middleAxisBegin;

			// green axis
			axis = nChart.Axis(StandardAxis.SecondaryY);
			axis.Anchor.BeginPercent = middleAxisBegin;
			axis.Anchor.EndPercent = middleAxisEnd;

			// blue axis
			axis = nChart.Axis(nCustomAxisId);
			axis.Anchor.BeginPercent = topAxisBegin;
		}
	}
}
