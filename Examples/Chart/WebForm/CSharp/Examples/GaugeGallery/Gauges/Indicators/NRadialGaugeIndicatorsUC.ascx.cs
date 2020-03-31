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
using Nevron.SmartShapes;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NRadialGaugeIndicatorsUC : NExampleUC
	{
		protected NRadialGaugePanel m_RadialGauge;
		protected NRangeIndicator m_Indicator1;
		protected NNeedleValueIndicator m_Indicator2;
		protected NNumericDisplayPanel m_NumericDisplay;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
            NLabel header = new NLabel("Radial Gauge Indicators");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

            // create the radial gauge
            m_RadialGauge = new NRadialGaugePanel();
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
            m_Indicator1 = new NRangeIndicator();
            m_Indicator1.Value = 20;
            m_Indicator1.FillStyle = new NGradientFillStyle(Color.Yellow, Color.Red);
            m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
            m_Indicator1.EndWidth = new NLength(20);
            m_RadialGauge.Indicators.Add(m_Indicator1);

            m_Indicator2 = new NNeedleValueIndicator();
            m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
            m_Indicator2.Shape.StrokeStyle.Color = Color.Red;
            m_RadialGauge.Indicators.Add(m_Indicator2);
            m_RadialGauge.SweepAngle = 270;

            // add radial gauge
            nChartControl1.Panels.Add(m_RadialGauge);

            // create and configure a numeric display attached to the radial gauge
            m_NumericDisplay = new NNumericDisplayPanel();
            m_NumericDisplay.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
            m_NumericDisplay.ContentAlignment = ContentAlignment.TopCenter;
            m_NumericDisplay.DisplayStyle = DisplayStyle.SevenSegmentRounded;
            m_NumericDisplay.SegmentWidth = new NLength(2, NGraphicsUnit.Point);
            m_NumericDisplay.SegmentGap = new NLength(1, NGraphicsUnit.Point);
            m_NumericDisplay.CellSize = new NSizeL(new NLength(10, NGraphicsUnit.Point), new NLength(20, NGraphicsUnit.Point));
            m_NumericDisplay.DecimalCellSize = new NSizeL(new NLength(7, NGraphicsUnit.Point), new NLength(15, NGraphicsUnit.Point));
            m_NumericDisplay.ShowDecimalSeparator = false;
            m_NumericDisplay.CellAlignment = VertAlign.Top;
            m_NumericDisplay.BackgroundFillStyle = new NColorFillStyle(Color.DimGray);
            m_NumericDisplay.LitFillStyle = new NGradientFillStyle(Color.Lime, Color.Green);
            m_NumericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
            m_NumericDisplay.CellCount = 6;
            m_NumericDisplay.Padding = new NMarginsL(3, 2, 3, 2);
            m_RadialGauge.ChildPanels.Add(m_NumericDisplay);

            // create a sunken border around the display
            NEdgeBorderStyle borderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            borderStyle.OuterBevelWidth = new NLength(0);
            borderStyle.MiddleBevelWidth = new NLength(0);
            m_NumericDisplay.BorderStyle = borderStyle;

			// init form controls
			if(!Page.IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(ValueIndicatorDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithValues(RangeIndicatorValueDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithValues(RangeIndicatorOriginDropDownList, 0, 100, 10);

				WebExamplesUtilities.FillComboWithValues(SweepAngleDropDownList, -360, 360, 45);
				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, -360, 360, 45);

				SweepAngleDropDownList.SelectedValue = m_RadialGauge.SweepAngle.ToString();
				BeginAngleDropDownList.SelectedValue = m_RadialGauge.BeginAngle.ToString();

				WebExamplesUtilities.FillComboWithEnumValues(ValueIndicatorShapeDropDownList, typeof(SmartShape1D));
				ValueIndicatorShapeDropDownList.SelectedIndex = (int)SmartShape1D.Triangle;

				ValueIndicatorDropDownList.SelectedValue = "20";
				RangeIndicatorValueDropDownList.SelectedValue = m_Indicator1.Value.ToString();

				WebExamplesUtilities.FillComboWithEnumValues(RangeIndicatorOriginModeDropDownList, typeof(OriginMode));
				RangeIndicatorOriginModeDropDownList.SelectedIndex = 0;
				RangeIndicatorOriginDropDownList.SelectedIndex = 0;
			}
			
			m_Indicator1.Value = Convert.ToDouble(RangeIndicatorValueDropDownList.SelectedValue);
			m_Indicator1.Origin = Convert.ToDouble(RangeIndicatorOriginDropDownList.SelectedValue);
			m_Indicator1.OriginMode = (OriginMode)RangeIndicatorOriginModeDropDownList.SelectedIndex;
			m_RadialGauge.BeginAngle = (float)Convert.ToDecimal(BeginAngleDropDownList.SelectedValue);
			m_RadialGauge.SweepAngle = (float)Convert.ToDecimal(SweepAngleDropDownList.SelectedValue);

			N1DSmartShapeFactory factory = new N1DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle);		
			m_Indicator2.Shape = factory.CreateShape((SmartShape1D)ValueIndicatorShapeDropDownList.SelectedIndex);
			m_Indicator2.Value = Convert.ToDouble(ValueIndicatorDropDownList.SelectedValue);
            m_NumericDisplay.Value = m_Indicator2.Value;

			if (m_Indicator1.OriginMode != OriginMode.Custom)
			{
				RangeIndicatorOriginDropDownList.Enabled = false;
			}
			else
			{
				RangeIndicatorOriginDropDownList.Enabled = true;
			}
		}
	}
}
