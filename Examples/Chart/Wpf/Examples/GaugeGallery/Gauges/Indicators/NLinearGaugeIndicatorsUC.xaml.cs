using System.Windows.Controls;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.SmartShapes;

namespace Nevron.Examples.Chart.Wpf
{	
	public partial class NLinearGaugeIndicatorsUC : NExampleBaseUC
	{
		NLinearGaugePanel m_LinearGauge;
		NMarkerValueIndicator m_Indicator2;
		NRangeIndicator m_Indicator1;

		public NLinearGaugeIndicatorsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Linear Gauge Indicators";
			}
		}

		public override string Description
		{
			get
			{
				return "This example demonstrates how to add indicators to a NLinearGaugePanel.\r\n" +
					"Additional features demonstrated by the example are the ability to dock gauge axes in gauge model space\r\n" +
					"\r\n" +
					"You can use the controls on the right side to modify marker and range indicators. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Linear Gauge Indicators");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create a linear gauge
			m_LinearGauge = new NLinearGaugePanel();
			nChartControl1.Panels.Add(m_LinearGauge);
			m_LinearGauge.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			m_LinearGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			m_LinearGauge.PaintEffect = new NGelEffectStyle();
			m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
			m_LinearGauge.BackgroundFillStyle = new NGradientFillStyle(System.Drawing.Color.Gray, System.Drawing.Color.Black);

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
			celsiusScale.Sections.Add(CreateSection(System.Drawing.Color.Red, System.Drawing.Color.Red, new NRange1DD(40, 60)));
			celsiusScale.Sections.Add(CreateSection(System.Drawing.Color.Blue, System.Drawing.Color.SkyBlue, new NRange1DD(-40, -20)));

			NLinearScaleConfigurator farenheitScale = (NLinearScaleConfigurator)farenheitAxis.ScaleConfigurator;
			ConfigureScale(farenheitScale, "°F");

			farenheitScale.Sections.Add(CreateSection(System.Drawing.Color.Red, System.Drawing.Color.Red, new NRange1DD(CelsiusToFarenheit(40), CelsiusToFarenheit(60))));
			farenheitScale.Sections.Add(CreateSection(System.Drawing.Color.Blue, System.Drawing.Color.SkyBlue, new NRange1DD(CelsiusToFarenheit(-40), CelsiusToFarenheit(-20))));

			// now add two indicators
			m_Indicator1 = new NRangeIndicator();
			m_Indicator1.Value = 10;
			m_Indicator1.StrokeStyle.Color = System.Drawing.Color.DarkBlue;
			m_Indicator1.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, System.Drawing.Color.LightBlue, System.Drawing.Color.Blue);
			m_LinearGauge.Indicators.Add(m_Indicator1);

			m_Indicator2 = new NMarkerValueIndicator();
			m_Indicator2.Value = 33;
			m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, System.Drawing.Color.White, System.Drawing.Color.Red);
			m_Indicator2.Shape.StrokeStyle.Color = System.Drawing.Color.DarkRed;
			m_LinearGauge.Indicators.Add(m_Indicator2);

			// init form controls

			NExampleHelpers.BindComboToItemSource(ValueIndicatorComboBox, -20, 60, 1);
			ValueIndicatorComboBox.SelectedItem = (int)m_Indicator2.Value;
			
			NExampleHelpers.BindComboToItemSource(RangeIndicatorValueComboBox, -20, 60, 1);
			RangeIndicatorValueComboBox.SelectedItem = (int)m_Indicator1.Value;
			
			NExampleHelpers.BindComboToItemSource(MarkerWidthComboBox, 1, 40, 1);
			MarkerWidthComboBox.SelectedItem = (int)m_Indicator2.Width.Value;

			NExampleHelpers.BindComboToItemSource(MarkerHeightComboBox, 1, 40, 1);
			MarkerHeightComboBox.SelectedItem = (int)m_Indicator2.Height.Value;

			NExampleHelpers.FillComboWithEnumValues(RangeIndicatorOriginModeComboBox, typeof(OriginMode));
			RangeIndicatorOriginModeComboBox.SelectedIndex = 0;

			NExampleHelpers.BindComboToItemSource(RangeIndicatorOriginComboBox, -20, 60, 1);
			RangeIndicatorOriginComboBox.SelectedItem = (int)m_Indicator1.Origin;

			NExampleHelpers.FillComboWithEnumValues(ValueIndicatorShapeComboBox, typeof(SmartShape2D));
			ValueIndicatorShapeComboBox.SelectedIndex = (int)SmartShape2D.Triangle;

			NExampleHelpers.FillComboWithEnumValues(GaugeOrientationCombo, typeof(LinearGaugeOrientation));			
			GaugeOrientationCombo.SelectedIndex = 0;
			
		}

		private void ValueIndicatorShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			N2DSmartShapeFactory factory = new N2DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle);
			m_Indicator2.Shape = factory.CreateShape((SmartShape2D)ValueIndicatorShapeComboBox.SelectedIndex);
			nChartControl1.Refresh();
		}
		
		private void GaugeOrientationCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_LinearGauge.Orientation = (LinearGaugeOrientation)GaugeOrientationCombo.SelectedIndex;

			if (m_LinearGauge.Orientation == LinearGaugeOrientation.Horizontal)
			{
				m_LinearGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(130, NGraphicsUnit.Point));
				m_LinearGauge.Padding = new NMarginsL(20, 0, 10, 0);
			}
			else
			{
				m_LinearGauge.Size = new NSizeL(new NLength(130, NGraphicsUnit.Point), new NLength(80, NRelativeUnit.ParentPercentage));
				m_LinearGauge.Padding = new NMarginsL(0, 10, 0, 20);
			}
			nChartControl1.Refresh();
		}

		private void RangeIndicatorOriginModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator1.OriginMode = (OriginMode)RangeIndicatorOriginModeComboBox.SelectedIndex;
			if (m_Indicator1.OriginMode != OriginMode.Custom)
			{
				RangeIndicatorOriginComboBox.IsEnabled = false;
			}
			else
			{
				RangeIndicatorOriginComboBox.IsEnabled = true;
			}

			nChartControl1.Refresh();	
		}

		private NScaleSectionStyle CreateSection(System.Drawing.Color tickColor, System.Drawing.Color labelColor, NRange1DD range)
		{
			NScaleSectionStyle scaleSection = new NScaleSectionStyle();
			scaleSection.Range = range;
			scaleSection.LabelTextStyle = new NTextStyle(new NFontStyle(), tickColor);
			scaleSection.MajorTickFillStyle = new NColorFillStyle(tickColor);

			NTextStyle labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NColorFillStyle(labelColor);
			labelStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Bold);
			scaleSection.LabelTextStyle = labelStyle;

			return scaleSection;
		}

		private void ConfigureScale(NLinearScaleConfigurator scale, string text)
		{
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Bold);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(System.Drawing.Color.White);
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90);
			scale.MinorTickCount = 4;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(System.Drawing.Color.FromArgb(40, System.Drawing.Color.DarkGray));

			scale.Title.RulerAlignment = HorzAlign.Left;
			scale.Title.Text = text;
			scale.Title.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 0);
			scale.Title.TextStyle.FontStyle.EmSize = new NLength(16);
			scale.Title.TextStyle.FontStyle.Style = System.Drawing.FontStyle.Bold;
			scale.Title.TextStyle.FillStyle = new NGradientFillStyle(System.Drawing.Color.White, System.Drawing.Color.LightBlue);
			scale.Title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			scale.RoundToTickMax = false;
			scale.RoundToTickMin = false;
		}

		public static double FarenheitToCelsius(double farenheit)
		{
			return (farenheit - 32.0) * 5.0 / 9.0;
		}

		public static double CelsiusToFarenheit(double celsius)
		{
			return (celsius * 9.0) / 5.0 + 32.0f;
		}

		private void ValueIndicatorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator2.Value = (int)ValueIndicatorComboBox.SelectedValue;
			nChartControl1.Refresh();
		}

		private void MarkerWidthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator2.Width = new NLength((int)MarkerWidthComboBox.SelectedValue);
			nChartControl1.Refresh();
		}

		private void MarkerHeightComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator2.Height = new NLength((int)MarkerHeightComboBox.SelectedValue);
			nChartControl1.Refresh();
		}

		private void RangeIndicatorValueComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator1.Value = (int)RangeIndicatorValueComboBox.SelectedValue;
			nChartControl1.Refresh();
		}

		private void RangeIndicatorOriginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator1.Origin = (int)RangeIndicatorOriginComboBox.SelectedValue;
			nChartControl1.Refresh();
		}
	}
}
