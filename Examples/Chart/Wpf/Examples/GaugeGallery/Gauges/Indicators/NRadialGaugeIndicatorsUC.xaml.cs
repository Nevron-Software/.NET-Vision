using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.SmartShapes;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NRadialGaugeIndicatorsUC.xaml
	/// </summary>
	public partial class NRadialGaugeIndicatorsUC : NExampleBaseUC
	{
		NRadialGaugePanel m_RadialGauge;
		NRangeIndicator m_Indicator1;
		NNeedleValueIndicator m_Indicator2;
		NNumericDisplayPanel m_NumericDisplay;

		public NRadialGaugeIndicatorsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Radial Gauge Indicators";
			}
		}

		public override string Description
		{
			get
			{
				return "The example demonstrates the functionality of the NRadialGaugePanel.\r\n" +
					   "Use the Begin and Sweep angle to tilt and sweep the gauge and its axis and indicators.\r\n" +
					   "\r\n" +
					   "You can also modify the parameters of the range and needle indicators.";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Radial Gauge Indicators");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
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
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90);
			scale.MinorTickCount = 4;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

			// add radial gauge indicators
			m_Indicator1 = new NRangeIndicator();
			m_Indicator1.Value = 20;
			m_Indicator1.FillStyle = new NGradientFillStyle(GradientStyle.StartToEnd, GradientVariant.Variant1, Color.Yellow, Color.Red);
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
			m_Indicator1.EndWidth = new NLength(20);
			m_RadialGauge.Indicators.Add(m_Indicator1);

			m_Indicator2 = new NNeedleValueIndicator();
			m_Indicator2.Value = 79;
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
			m_NumericDisplay.SegmentWidth = new NLength(2, NGraphicsUnit.Point);
			m_NumericDisplay.SegmentGap = new NLength(1, NGraphicsUnit.Point);
			m_NumericDisplay.CellSize = new NSizeL(new NLength(15, NGraphicsUnit.Point), new NLength(30, NGraphicsUnit.Point));
			m_NumericDisplay.DecimalCellSize = new NSizeL(new NLength(10, NGraphicsUnit.Point), new NLength(20, NGraphicsUnit.Point));
			m_NumericDisplay.ShowDecimalSeparator = false;
			m_NumericDisplay.CellAlignment = VertAlign.Top;
			m_NumericDisplay.BackgroundFillStyle = new NColorFillStyle(Color.DimGray);
			m_NumericDisplay.LitFillStyle = new NGradientFillStyle(Color.Lime, Color.Green);
			m_NumericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
			m_NumericDisplay.CellCount = 6;
			m_NumericDisplay.Padding = new NMarginsL(6, 3, 6, 3);
			m_RadialGauge.ChildPanels.Add(m_NumericDisplay);

			// create a sunken border around the display
			NEdgeBorderStyle borderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
			borderStyle.OuterBevelWidth = new NLength(0);
			borderStyle.MiddleBevelWidth = new NLength(0);
			m_NumericDisplay.BorderStyle = borderStyle;

			// init form controls

			NExampleHelpers.BindComboToItemSource(SweepAngleComboBox, -360, 360, 10);
			SweepAngleComboBox.SelectedItem = (int)m_RadialGauge.SweepAngle;
			
			NExampleHelpers.BindComboToItemSource(BeginAngleComboBox, -360, 360, 10);
			BeginAngleComboBox.SelectedItem = (int)m_RadialGauge.BeginAngle;

			NExampleHelpers.FillComboWithEnumValues(ValueIndicatorShapeComboBox, typeof(SmartShape1D));
			ValueIndicatorShapeComboBox.SelectedIndex = (int)SmartShape1D.Arrow2;

			NExampleHelpers.BindComboToItemSource(ValueIndicatorComboBox, 0, 100, 1);
			ValueIndicatorComboBox.SelectedItem = (int)m_Indicator2.Value;
			
			NExampleHelpers.BindComboToItemSource(RangeIndicatorValueComboBox, 0, 100, 5);
			RangeIndicatorValueComboBox.SelectedItem = (int)m_Indicator1.Value;

			NExampleHelpers.FillComboWithEnumValues(RangeIndicatorOriginModeComboBox, typeof(OriginMode));
			RangeIndicatorOriginModeComboBox.SelectedIndex = 0;

			NExampleHelpers.BindComboToItemSource(NeedleWidthComboBox, -20, 60, 5);
			NeedleWidthComboBox.SelectedItem = (int)m_Indicator2.Width.Value;

			NExampleHelpers.BindComboToItemSource(RangeIndicatorOriginComboBox, 0, 100, 5);
			RangeIndicatorOriginComboBox.SelectedItem = (int)m_Indicator1.Origin;
		}

		private void SweepAngleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_RadialGauge.SweepAngle = (int)SweepAngleComboBox.SelectedItem;
			nChartControl1.Refresh();
		}

		private void BeginAngleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_RadialGauge.BeginAngle = (int)BeginAngleComboBox.SelectedItem;
			nChartControl1.Refresh();
		}

		private void RangeIndicatorOriginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator1.Origin = (int)RangeIndicatorOriginComboBox.SelectedItem;
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

		private void RangeIndicatorValueComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator1.Value = (int)RangeIndicatorValueComboBox.SelectedItem;
			nChartControl1.Refresh();
		}

		private void NeedleWidthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator2.Width = new NLength((int)NeedleWidthComboBox.SelectedItem);
			nChartControl1.Refresh();
		}

		private void ValueIndicatorShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			N1DSmartShapeFactory factory = new N1DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle);
			m_Indicator2.Shape = factory.CreateShape((SmartShape1D)ValueIndicatorShapeComboBox.SelectedIndex);
			nChartControl1.Refresh();
		}

		private void ValueIndicatorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_Indicator2.Value = (int)ValueIndicatorComboBox.SelectedItem;
			m_NumericDisplay.Value = m_Indicator2.Value;
			nChartControl1.Refresh();
		}
	}
}
