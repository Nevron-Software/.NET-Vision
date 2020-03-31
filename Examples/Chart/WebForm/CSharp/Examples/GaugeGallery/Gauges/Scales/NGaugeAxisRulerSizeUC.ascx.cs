using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Examples.Framework.WebForm;
using Nevron.UI;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm.Examples.GaugeGallery
{
	public partial class NGaugeAxisRulerSizeUC : NExampleUC
	{
		protected NRadialGaugePanel m_RadialGauge;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(RedAxisPercentDropDownList, 10, 70, 10);
				RedAxisPercentDropDownList.SelectedIndex = 6;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Axis Ruler Size");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

            // create the radial gauge
            m_RadialGauge = new NRadialGaugePanel();
            m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
            m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(52, NRelativeUnit.ParentPercentage));
            m_RadialGauge.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(85, NRelativeUnit.ParentPercentage));
            m_RadialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);
            NGelEffectStyle gelEffect = new NGelEffectStyle(PaintEffectShape.Ellipse);
            gelEffect.Margins = new NMarginsL(new NLength(0), new NLength(0), new NLength(0), new NLength(50, NRelativeUnit.ParentPercentage));

            m_RadialGauge.PaintEffect = gelEffect;
            nChartControl1.Panels.Add(m_RadialGauge);

            m_RadialGauge.Axes.Clear();

            // create the first axis
            NGaugeAxis axis1 = new NGaugeAxis();
            axis1.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, 0, 70);
            NStandardScaleConfigurator scale1 = (NStandardScaleConfigurator)axis1.ScaleConfigurator;
            scale1.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale1.MinorTickCount = 3;
            scale1.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
            scale1.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
            scale1.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
            scale1.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale1.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

            m_RadialGauge.Axes.Add(axis1);

            // create the second axis
            NGaugeAxis axis2 = new NGaugeAxis();
            axis2.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, false, 75, 95);
            NStandardScaleConfigurator scale2 = (NStandardScaleConfigurator)axis2.ScaleConfigurator;
            scale2.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale2.MinorTickCount = 3;
            scale2.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
            scale2.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Blue);
            scale2.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
            scale2.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale2.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

            m_RadialGauge.Axes.Add(axis2);

            // add indicators
            NRangeIndicator rangeIndicator = new NRangeIndicator();
            rangeIndicator.Value = 50;
            rangeIndicator.FillStyle = new NGradientFillStyle(Color.Orange, Color.Red);
            rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.OffsetFromScale = new NLength(3);
            rangeIndicator.BeginWidth = new NLength(6);
            rangeIndicator.EndWidth = new NLength(12);
            m_RadialGauge.Indicators.Add(rangeIndicator);

            NNeedleValueIndicator needleValueIndicator1 = new NNeedleValueIndicator();
            needleValueIndicator1.Value = 79;
            needleValueIndicator1.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.White, Color.Red);
            needleValueIndicator1.Shape.StrokeStyle.Color = Color.Red;
            needleValueIndicator1.Axis = axis1;
            needleValueIndicator1.OffsetFromScale = new NLength(2);
            m_RadialGauge.Indicators.Add(needleValueIndicator1);
            m_RadialGauge.SweepAngle = 360;

            NNeedleValueIndicator needleValueIndicator2 = new NNeedleValueIndicator();
            needleValueIndicator2.Value = 79;
            needleValueIndicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.White, Color.Blue);
            needleValueIndicator2.Shape.StrokeStyle.Color = Color.Blue;
            needleValueIndicator2.Axis = axis2;
            needleValueIndicator2.OffsetFromScale = new NLength(-2);
            m_RadialGauge.Indicators.Add(needleValueIndicator2);

			axis1.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, 0, (float)Convert.ToDecimal(RedAxisPercentDropDownList.SelectedValue) - 5);
			axis2.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, false, (float)Convert.ToDecimal(RedAxisPercentDropDownList.SelectedValue), 95);
		}
	}
}
