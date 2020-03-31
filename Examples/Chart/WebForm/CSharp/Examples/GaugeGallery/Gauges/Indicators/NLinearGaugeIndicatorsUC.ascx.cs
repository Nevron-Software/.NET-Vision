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
	public partial class NLinearGaugeIndicatorsUC : NExampleUC
	{
		protected NLinearGaugePanel m_LinearGauge;
		protected NMarkerValueIndicator m_Indicator2;
		protected NRangeIndicator m_Indicator1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

		    // set a chart title
            NLabel header = new NLabel("Linear Gauge Indicators");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

            // create a linear gauge
            m_LinearGauge = new NLinearGaugePanel();
            nChartControl1.Panels.Add(m_LinearGauge);
            m_LinearGauge.ContentAlignment = ContentAlignment.MiddleCenter;
            m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            m_LinearGauge.PaintEffect = new NGelEffectStyle();
            m_LinearGauge.BackgroundFillStyle = new NGradientFillStyle(Color.Gray, Color.Black);

            m_LinearGauge.Axes.Clear();

            NRange1DD celsiusRange = new NRange1DD(-40, 60);

            // add celsius and farenheit axes
            NGaugeAxis celsiusAxis = new NGaugeAxis();
            celsiusAxis.Range = celsiusRange;
            celsiusAxis.Anchor = new NModelGaugeAxisAnchor(new NLength(-5), VertAlign.Center, RulerOrientation.Left, 0, 100);
            m_LinearGauge.Axes.Add(celsiusAxis);

            NGaugeAxis farenheitAxis = new NGaugeAxis();
            farenheitAxis.Range = new NRange1DD(CelsiusToFarenheit(celsiusRange.Begin), CelsiusToFarenheit(celsiusRange.End));
            farenheitAxis.Anchor = new NModelGaugeAxisAnchor(new NLength(5), VertAlign.Center, RulerOrientation.Right, 0, 100);
            m_LinearGauge.Axes.Add(farenheitAxis);

            // configure the scales
            NLinearScaleConfigurator celsiusScale = (NLinearScaleConfigurator)celsiusAxis.ScaleConfigurator;
            ConfigureScale(celsiusScale, "°C");
            celsiusScale.Sections.Add(CreateSection(Color.Red, Color.Red, new NRange1DD(40, 60)));
            celsiusScale.Sections.Add(CreateSection(Color.Blue, Color.SkyBlue, new NRange1DD(-40, -20)));

            NLinearScaleConfigurator farenheitScale = (NLinearScaleConfigurator)farenheitAxis.ScaleConfigurator;
            ConfigureScale(farenheitScale, "°F");

            farenheitScale.Sections.Add(CreateSection(Color.Red, Color.Red, new NRange1DD(CelsiusToFarenheit(40), CelsiusToFarenheit(60))));
            farenheitScale.Sections.Add(CreateSection(Color.Blue, Color.SkyBlue, new NRange1DD(CelsiusToFarenheit(-40), CelsiusToFarenheit(-20))));

            // now add two indicators
            m_Indicator1 = new NRangeIndicator();
            m_Indicator1.Value = 10;
            m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
            m_Indicator1.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.LightBlue, Color.Blue);
            m_LinearGauge.Indicators.Add(m_Indicator1);

            m_Indicator2 = new NMarkerValueIndicator();
            m_Indicator2.Value = 33;
            m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
            m_Indicator2.Shape.StrokeStyle.Color = Color.DarkRed;
            m_LinearGauge.Indicators.Add(m_Indicator2);

			// init form controls
			if(!Page.IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(RangeIndicatorOriginModeDropDownList, typeof(OriginMode));
				RangeIndicatorOriginModeDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithEnumValues(ValueIndicatorShapeDropDownList, typeof(SmartShape2D));
				ValueIndicatorShapeDropDownList.SelectedIndex = (int)SmartShape2D.Triangle;

				WebExamplesUtilities.FillComboWithEnumValues(GaugeOrientationDropDownList, typeof(LinearGaugeOrientation));
				GaugeOrientationDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(ValueIndicatorDropDownList, -20, 60, 10);
				WebExamplesUtilities.FillComboWithValues(RangeIndicatorValueDropDownList, -20, 60, 10);
				WebExamplesUtilities.FillComboWithValues(RangeIndicatorOriginDropDownList, -20, 60, 10);
				RangeIndicatorOriginDropDownList.SelectedIndex = 5;

				RangeIndicatorValueDropDownList.SelectedValue = m_Indicator1.Value.ToString();
				ValueIndicatorDropDownList.SelectedValue = m_Indicator2.Value.ToString();
			}

			m_LinearGauge.Orientation = (LinearGaugeOrientation)GaugeOrientationDropDownList.SelectedIndex;

            if (m_LinearGauge.Orientation == LinearGaugeOrientation.Horizontal)
            {
                m_LinearGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
                m_LinearGauge.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
            }
            else
            {
                m_LinearGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(54, NRelativeUnit.ParentPercentage));
                m_LinearGauge.Size = new NSizeL(new NLength(37, NRelativeUnit.ParentPercentage), new NLength(85, NRelativeUnit.ParentPercentage));
            }
			m_Indicator1.OriginMode = (OriginMode)RangeIndicatorOriginModeDropDownList.SelectedIndex;
			m_Indicator1.Origin = Convert.ToDouble(RangeIndicatorOriginDropDownList.SelectedValue);
			m_Indicator1.Value = Convert.ToDouble(RangeIndicatorValueDropDownList.SelectedValue);

            N2DSmartShapeFactory factory = new N2DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle);
            m_Indicator2.Shape = factory.CreateShape((SmartShape2D)ValueIndicatorShapeDropDownList.SelectedIndex);
			m_Indicator2.Value = Convert.ToDouble(ValueIndicatorDropDownList.SelectedValue);
				
			if (m_Indicator1.OriginMode != OriginMode.Custom)
			{
				RangeIndicatorOriginDropDownList.Enabled = false;
			}
			else
			{
				RangeIndicatorOriginDropDownList.Enabled = true;
			}
		}

		public static double FarenheitToCelsius(double farenheit)
		{
			return (farenheit - 32.0) * 5.0 / 9.0;
		}

		public static double CelsiusToFarenheit(double celsius)
		{
			return (celsius * 9.0) / 5.0 + 32.0f;
		}

        private NScaleSectionStyle CreateSection(Color tickColor, Color labelColor, NRange1DD range)
        {
            NScaleSectionStyle scaleSection = new NScaleSectionStyle();
            scaleSection.Range = range;
            scaleSection.LabelTextStyle = new NTextStyle(new NFontStyle(), tickColor);
            scaleSection.MajorTickFillStyle = new NColorFillStyle(tickColor);

            NTextStyle labelStyle = new NTextStyle();
            labelStyle.FillStyle = new NColorFillStyle(labelColor);
            labelStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
            scaleSection.LabelTextStyle = labelStyle;

            return scaleSection;
        }

        private void ConfigureScale(NLinearScaleConfigurator scale, string text)
        {
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90);
            scale.MinorTickCount = 4;
            scale.RulerStyle.BorderStyle.Width = new NLength(0);
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.DarkGray));

            scale.Title.RulerAlignment = HorzAlign.Left;
            scale.Title.Text = text;
            scale.Title.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 0);
            scale.Title.TextStyle.FontStyle.EmSize = new NLength(12);
            scale.Title.TextStyle.FontStyle.Style = FontStyle.Bold;
            scale.Title.TextStyle.FillStyle = new NGradientFillStyle(Color.White, Color.LightBlue);
            scale.Title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            scale.RoundToTickMax = false;
            scale.RoundToTickMin = false;
        }
	}
}
