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
	public partial class NCustomScaleDecorationsUC : NExampleUC
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(HotZoneBeginDropDownList, 55, 85, 5);
				WebExamplesUtilities.FillComboWithValues(ColdZoneEndDropDownList, 5, 45, 5);

				HotZoneBeginDropDownList.SelectedIndex = 3;
				ColdZoneEndDropDownList.SelectedIndex = 4;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Temperature Measurements <br/><font size = '8pt'>Demonstrates how to Custom Program the Scale</font>");
			header.TextStyle.TextFormat = TextFormat.XML;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.Mode = LegendMode.Disabled;
			NChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(95, NRelativeUnit.ParentPercentage),
				new NLength(85, NRelativeUnit.ParentPercentage));

			
			// create a point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.DataLabelStyle.Visible = false;
			point.MarkerStyle.Visible = false;
			point.Size = new NLength(5, NGraphicsUnit.Point);
			Random rand = new Random();
			for (int i = 0; i < 30; i++)
			{
				point.Values.Add(5 + rand.Next(90));
			}

			NAxis primaryY = chart.Axis(StandardAxis.PrimaryY);
			primaryY.View = new NRangeAxisView(new NRange1DD(0, 100), true, true);
			NLinearScaleConfigurator linearScale = primaryY.ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;

			UpdateScale();
		}

		private void UpdateScale()
		{
			NAxis primaryY = nChartControl1.Charts[0].Axis(StandardAxis.PrimaryY);
			NRange1DD hotZoneRange = new NRange1DD(Convert.ToDouble(HotZoneBeginDropDownList.SelectedValue), 100);
			NRange1DD coldZoneRange = new NRange1DD(0, Convert.ToDouble(ColdZoneEndDropDownList.SelectedValue));

			NScaleSectionStyle hotZoneSection = new NScaleSectionStyle();
			hotZoneSection.Range = hotZoneRange;
			hotZoneSection.LabelTextStyle = new NTextStyle(new NFontStyle(), Color.Red);
			hotZoneSection.MajorTickStrokeStyle = new NStrokeStyle(1, Color.Red);
			hotZoneSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Red));
			hotZoneSection.SetShowAtWall(ChartWallType.Back, true);

			NScaleSectionStyle coldZoneSection = new NScaleSectionStyle();
			coldZoneSection.Range = coldZoneRange;
			coldZoneSection.LabelTextStyle = new NTextStyle(new NFontStyle(), Color.Blue);
			coldZoneSection.MajorTickStrokeStyle = new NStrokeStyle(1, Color.Blue);
			coldZoneSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Blue));
			coldZoneSection.SetShowAtWall(ChartWallType.Back, true);

			NStandardScaleConfigurator configurator = (NStandardScaleConfigurator)primaryY.ScaleConfigurator;

			configurator.Sections.Clear();
			configurator.Sections.Add(hotZoneSection);
			configurator.Sections.Add(coldZoneSection);

			// first use the scale configurator to output some definition
			primaryY.SynchronizeScaleWithConfigurator = true;
			primaryY.InvalidateScale();
			primaryY.UpdateScale();
			primaryY.SynchronizeScaleWithConfigurator = false;

			// manually program the scale
			NScaleLevel scaleLevel;
			NCustomScaleDecorator customScaleDecorator;
			NScaleRangeDecorationAnchor anchor;
			NScaleLevelSeparator separator;
			NValueScaleLabel label;
			NNumericDoubleStepRangeSampler rangeSampler;
			NClampedRangeSampler clampedRangeSampler;
			NScaleTickFactory tickFactory;
			NSampledScaleDecorator sampledDecorator;;

			// create the hot zone

			// add a level separator
			scaleLevel = new NScaleLevel();
			customScaleDecorator = new NCustomScaleDecorator();

			anchor = new NScaleRangeDecorationAnchor(hotZoneRange);
			separator = new NScaleLevelSeparator(0, anchor, ScaleLevelShape.Line, null, new NStrokeStyle(1, Color.Red), new NLength(0), new NLength(0), new NLength(0), new NLength(0), null, null, null, false);
			customScaleDecorator.Decorations.Add(separator);

			// create a value scale label
			label = new NValueScaleLabel();
			label.Text = "Hot Zone";
			label.Anchor = new NRulerValueDecorationAnchor(HorzAlign.Right, new NLength(0));
			label.Offset = new NLength(6, NGraphicsUnit.Point);
			label.Style.TextStyle.FillStyle = new NColorFillStyle(Color.Red);
			label.Style.ContentAlignment = ContentAlignment.TopRight;
			label.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90, true);

			customScaleDecorator.Decorations.Add(label);
			scaleLevel.Decorators.Add(customScaleDecorator);

			// add a some ticks
            rangeSampler = new NNumericDoubleStepRangeSampler(new NCustomNumericStepProvider(5));
			rangeSampler.UseCustomOrigin = true;
			rangeSampler.CustomOrigin = 0;
			clampedRangeSampler = new NClampedRangeSampler(rangeSampler, hotZoneRange);

            tickFactory = new NScaleTickFactory(0, ScaleTickShape.Line,
                        new NLength(0),
                        new NSizeL(new NLength(1), new NLength(5, NGraphicsUnit.Point)),
                        new NConstValueProvider(new NColorFillStyle(Color.Red)),
                        new NConstValueProvider(new NStrokeStyle(1, Color.Red)),
                        HorzAlign.Left);

			sampledDecorator = new NSampledScaleDecorator(clampedRangeSampler, tickFactory);
			scaleLevel.Decorators.Add(sampledDecorator);

			// create the cold zone
			// add a level separator
			customScaleDecorator = new NCustomScaleDecorator();

			anchor = new NScaleRangeDecorationAnchor(coldZoneRange);
            separator = new NScaleLevelSeparator(0, anchor, ScaleLevelShape.Line, null, new NStrokeStyle(1, Color.Blue));
            customScaleDecorator.Decorations.Add(separator);

			// create a value scale label
			label = new NValueScaleLabel();
			label.Text = "Cold Zone";
			label.Anchor = new NRulerValueDecorationAnchor(HorzAlign.Left, new NLength(0));
			label.Offset = new NLength(6, NGraphicsUnit.Point);
			label.Style.TextStyle.FillStyle = new NColorFillStyle(Color.Blue);
			label.Style.ContentAlignment = ContentAlignment.TopLeft;
			label.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90, true);

			customScaleDecorator.Decorations.Add(label);
			scaleLevel.Decorators.Add(customScaleDecorator);

			// add a some ticks
            rangeSampler = new NNumericDoubleStepRangeSampler(new NCustomNumericStepProvider(5));
			clampedRangeSampler = new NClampedRangeSampler(rangeSampler, coldZoneRange);

            tickFactory = new NScaleTickFactory(0, ScaleTickShape.Line,
                                    new NLength(0),
                                    new NSizeL(new NLength(1), new NLength(5, NGraphicsUnit.Point)),
                                    new NConstValueProvider(new NColorFillStyle(Color.Red)),
                                    new NConstValueProvider(new NStrokeStyle(1, Color.Blue)),
                                    HorzAlign.Left);

			sampledDecorator = new NSampledScaleDecorator(clampedRangeSampler, tickFactory);
			scaleLevel.Decorators.Add(sampledDecorator);

			primaryY.Scale.Levels.Add(scaleLevel);

			UpdateData(hotZoneRange, coldZoneRange);

		}
		
		private void UpdateData(NRange1DD hotZoneRange, NRange1DD coldZoneRange)
		{
			NPointSeries point = nChartControl1.Charts[0].Series[0] as NPointSeries;

			for (int i = 0; i < point.Values.Count; i++)
			{
				if (hotZoneRange.Contains((double)point.Values[i]))
				{
					point.FillStyles[i] = new NColorFillStyle(Color.Red);
				}
				else if (coldZoneRange.Contains((double)point.Values[i]))
				{
					point.FillStyles[i] = new NColorFillStyle(Color.Blue);
				}
				else
				{
					point.FillStyles[i] = new NColorFillStyle(Color.SpringGreen);
				}
			}
		}

		protected void HotZoneBeginDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		protected void ColdZoneEndDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}
	}
}
