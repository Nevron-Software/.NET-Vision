//using System.Windows.Media;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.SmartShapes;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NIndicatorPaletteUC.xaml
	/// </summary>
	public partial class NIndicatorPaletteUC : NExampleBaseUC
	{
		NRangeIndicator m_RangeIndicator;
		NNeedleValueIndicator m_NeedleIndicator;
		NPalette m_Palette;

		public NIndicatorPaletteUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Indicator Palette";
			}
		}

		public override string Description
		{
			get
			{
				return "The example shows how to attach a palette to a gauge indicator. The palette can dynamically color the gauge indicator based on its value. In the case of range indicators there is also the option to spread the palette.";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Indicator Palette");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel m_RadialGauge = new NRadialGaugePanel();
			m_RadialGauge.PaintEffect = new NGlassEffectStyle();
			m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
			m_RadialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			m_RadialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

			// configure scale
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Bold);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			scale.MinorTickCount = 4;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

			// add radial gauge indicators
			m_RangeIndicator = new NRangeIndicator();
			m_RangeIndicator.Value = 20;
			m_RangeIndicator.FillStyle = new NGradientFillStyle(Color.Yellow, Color.Red);
			m_RangeIndicator.StrokeStyle.Color = Color.DarkBlue;
			m_RangeIndicator.EndWidth = new NLength(20);
			m_RadialGauge.Indicators.Add(m_RangeIndicator);

			m_NeedleIndicator = new NNeedleValueIndicator();
			m_NeedleIndicator.Value = 79;
			m_NeedleIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_NeedleIndicator.Shape.StrokeStyle.Color = Color.Red;
			m_RadialGauge.Indicators.Add(m_NeedleIndicator);
			m_RadialGauge.SweepAngle = 270;

			// add radial gauge
			nChartControl1.Panels.Add(m_RadialGauge);

			m_Palette = new NPalette();
			m_Palette.SmoothPalette = true;
			m_Palette.PositiveColor = Color.Green;
			m_Palette.NegativeColor = Color.Red;

			m_NeedleIndicator.Palette = (NPalette)m_Palette.Clone();
			m_RangeIndicator.Palette = (NPalette)m_Palette.Clone();
			m_RangeIndicator.PaletteColorMode = PaletteColorMode.Spread;

			NExampleHelpers.FillComboWithEnumValues(PaletteSpreadModeComboBox, typeof(PaletteColorMode));
			PaletteSpreadModeComboBox.SelectedIndex = (int)PaletteColorMode.Spread;

			EnableIndicatorPaletteCheckBox.IsChecked = true;
			IndicatorsValueScrollBar.Value = m_NeedleIndicator.Value;
		}

		private void EnableIndicatorPaletteCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (EnableIndicatorPaletteCheckBox.IsChecked.Value)
			{
				m_NeedleIndicator.Palette = (NPalette)m_Palette.Clone();
				m_RangeIndicator.Palette = (NPalette)m_Palette.Clone();
			}
			else
			{
				m_NeedleIndicator.Palette = null;
				m_RangeIndicator.Palette = null;
			}

			nChartControl1.Refresh();
	
		}
		private void PaletteSpreadModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_RangeIndicator.PaletteColorMode = (PaletteColorMode)PaletteSpreadModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void IndicatorsValueScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_NeedleIndicator.Value = (double)IndicatorsValueScrollBar.Value;
			m_RangeIndicator.Value = (double)IndicatorsValueScrollBar.Value;
			nChartControl1.Refresh();
		}
	}
}
