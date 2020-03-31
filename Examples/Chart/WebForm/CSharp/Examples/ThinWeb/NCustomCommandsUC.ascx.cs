using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.SmartShapes;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NCustomCommandsUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!nChartControl1.Initialized)
            {
                nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                nChartControl1.Panels.Clear();
                nChartControl1.StateId = "Gauge1";

                // set a chart title
                NLabel header = new NLabel("Custom Commands");
                header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
                header.ContentAlignment = ContentAlignment.BottomRight;
                header.DockMode = PanelDockMode.Top;
                header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                                new NLength(2, NRelativeUnit.ParentPercentage));
                nChartControl1.Panels.Add(header);

                // create the radial gauge
                NRadialGaugePanel radialGauge = new NRadialGaugePanel();
                nChartControl1.Panels.Add(radialGauge);
                radialGauge.DockMode = PanelDockMode.Fill;
                radialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
                radialGauge.SweepAngle = 270;
                radialGauge.BeginAngle = -225;
                radialGauge.CapStyle.Visible = false;

                // configure the gauge scale
                NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
                NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

                scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
                scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Italic);
                scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.Black);
                scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
                scale.MinorTickCount = 4;
                scale.RulerStyle.BorderStyle.Width = new NLength(0);
                scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

                // create the knob indicator
                NKnobIndicator knobIndicator = new NKnobIndicator();
                knobIndicator.OffsetFromScale = new NLength(-3);

                // apply fill style to the marker
                NAdvancedGradientFillStyle advancedGradientFill = new NAdvancedGradientFillStyle();
                advancedGradientFill.BackgroundColor = Color.Red;
                advancedGradientFill.Points.Add(new NAdvancedGradientPoint(Color.White, 20, 20, 0, 100, AGPointShape.Circle));
                knobIndicator.MarkerShape.FillStyle = advancedGradientFill;

                // add the knob indicator to the indicators collection of the gauge
                radialGauge.Indicators.Add(knobIndicator);

                // update the knob marker shape
                N2DSmartShapeFactory factory = new N2DSmartShapeFactory(knobIndicator.MarkerShape.FillStyle, knobIndicator.MarkerShape.StrokeStyle, knobIndicator.MarkerShape.ShadowStyle);
                knobIndicator.MarkerShape = factory.CreateShape(SmartShape2D.Ellipse);
                // update the outer rim style
			    knobIndicator.OuterRimStyle.Pattern = CircularRimPattern.RoundHandleSmall;
			    // update the inner rim style
			    knobIndicator.InnerRimStyle.Pattern = CircularRimPattern.Circle;

                NIndicatorDragTool indicatorDragTool = new NIndicatorDragTool();
                indicatorDragTool.IndicatorDragCallback = new IndicatorDragCallback();
                nChartControl1.Controller.Tools.Add(indicatorDragTool);
            }
		}

        [Serializable]
        public class IndicatorDragCallback : INIndicatorDragCallback
        {
			#region INIndicatorDragCallback Members

			void INIndicatorDragCallback.OnIndicatorValueChanged(NThinChartControl control, NGaugePanel gauge, NIndicator indicator, double oldValue, double newValue)
			{
				control.AddCustomClientCommand(newValue.ToString("00.00"));
			}

			#endregion
		}
	}
}
