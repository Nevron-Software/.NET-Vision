using System;
using System.Drawing;
using Nevron.ThinWeb;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.Dom;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NIndicatorDragToolUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!NThinChartControl1.Initialized)
            {
                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                NThinChartControl1.Panels.Clear();

                // set a chart title
                NLabel header = new NLabel("Indicator Drag Tool");
                header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
                header.ContentAlignment = ContentAlignment.BottomRight;
                header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                                new NLength(2, NRelativeUnit.ParentPercentage));
                NThinChartControl1.Panels.Add(header);

                // create the radial gauge
                NRadialGaugePanel m_RadialGauge = new NRadialGaugePanel();
                m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
                m_RadialGauge.PaintEffect = new NGlassEffectStyle();
                m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
                m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(52, NRelativeUnit.ParentPercentage));
                m_RadialGauge.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(85, NRelativeUnit.ParentPercentage));
                m_RadialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

                // configure scale
                NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
                NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

                scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
                scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
                scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
                scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
                scale.MinorTickCount = 4;
                scale.RulerStyle.BorderStyle.Width = new NLength(0);
                scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

                // add radial gauge indicators
                NRangeIndicator rangeIndicator = new NRangeIndicator();
                rangeIndicator.Value = 20;
                rangeIndicator.FillStyle = new NGradientFillStyle(Color.Yellow, Color.Red);
                rangeIndicator.StrokeStyle.Color = Color.DarkBlue;
                rangeIndicator.EndWidth = new NLength(20);

                NInteractivityStyle interactivityStyle1 = new NInteractivityStyle();
                interactivityStyle1.Tooltip.Text = "Drag Me";
//              interactivityStyle1.ClientMouseEventAttribute.Tag = "Indicator[" + m_Indicator1.UniqueId.ToString() + "]";

                rangeIndicator.InteractivityStyle = interactivityStyle1;

                m_RadialGauge.Indicators.Add(rangeIndicator);

                NNeedleValueIndicator needleIndicator = new NNeedleValueIndicator();
                needleIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
                needleIndicator.Shape.StrokeStyle.Color = Color.Red;
                m_RadialGauge.Indicators.Add(needleIndicator);
                m_RadialGauge.SweepAngle = 270;

                // add radial gauge
                NThinChartControl1.Panels.Add(m_RadialGauge);

                // create and config ure a numeric display attached to the radial gauge
                NNumericDisplayPanel numericDisplay = new NNumericDisplayPanel();
                numericDisplay.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
                numericDisplay.ContentAlignment = ContentAlignment.TopCenter;
                numericDisplay.DisplayStyle = DisplayStyle.SevenSegmentRounded;
                numericDisplay.SegmentWidth = new NLength(2, NGraphicsUnit.Point);
                numericDisplay.SegmentGap = new NLength(1, NGraphicsUnit.Point);
                numericDisplay.CellSize = new NSizeL(new NLength(9, NGraphicsUnit.Point), new NLength(19, NGraphicsUnit.Point));
                numericDisplay.ShowDecimalSeparator = true;
				numericDisplay.ShowLeadingZeros = true;
				numericDisplay.EnableDecimalFormatting = false;
				numericDisplay.CellCountMode = DisplayCellCountMode.Auto;
				numericDisplay.CellCount = 6;
				numericDisplay.ValueFormatter = new NNumericValueFormatter("00.00");

                numericDisplay.CellAlignment = VertAlign.Top;
                numericDisplay.BackgroundFillStyle = new NColorFillStyle(Color.DimGray);
                numericDisplay.LitFillStyle = new NGradientFillStyle(Color.Lime, Color.Green);
                numericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
                numericDisplay.CellCount = 6;
                numericDisplay.Padding = new NMarginsL(3, 2, 3, 2);
                m_RadialGauge.ChildPanels.Add(numericDisplay);

                // create a sunken border around the display
                NEdgeBorderStyle borderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
                borderStyle.OuterBevelWidth = new NLength(0);
                borderStyle.MiddleBevelWidth = new NLength(0);
                numericDisplay.BorderStyle = borderStyle;

                NIndicatorDragTool indicatorDragTool = new NIndicatorDragTool();
                indicatorDragTool.IndicatorDragCallback = new IndicatorDragCallback();
                NThinChartControl1.Controller.Tools.Add(indicatorDragTool);
                NThinChartControl1.Controller.Tools.Add(new NTooltipTool());
            }

            NRangeIndicator range = (NRangeIndicator)NThinChartControl1.Gauges[0].Indicators[0];
            range.AllowDragging = EnableRangeIndicatorDraggingCheckBox.Checked;

            if (range.AllowDragging)
            {
                range.InteractivityStyle.Tooltip.Text = "Drag Me";
            }
            else
            {
                range.InteractivityStyle.Tooltip.Text = range.Range.End.ToString();
            }

            NNeedleValueIndicator needle = (NNeedleValueIndicator)NThinChartControl1.Gauges[0].Indicators[1];
            needle.AllowDragging = EnableNeedleIndicatorDraggingCheckBox.Checked;

            if (needle.AllowDragging)
            {
                needle.InteractivityStyle.Tooltip.Text = "Drag Me";
            }
            else
            {
                needle.InteractivityStyle.Tooltip.Text = needle.Value.ToString();
            }


        }

        [Serializable]
        public class IndicatorDragCallback : INIndicatorDragCallback
        {
			#region INIndicatorDragCallback Members

			void INIndicatorDragCallback.OnIndicatorValueChanged(NThinChartControl control, NGaugePanel gauge, NIndicator indicator, double oldValue, double newValue)
			{
				control.NumericDisplays[0].Value = indicator.Value;
			}

			#endregion
		}
    }
}
