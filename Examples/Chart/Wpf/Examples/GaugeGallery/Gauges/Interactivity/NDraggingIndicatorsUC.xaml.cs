using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NDraggingIndicatorsUC.xaml
	/// </summary>
	public partial class NDraggingIndicatorsUC : NExampleBaseUC
	{
		NRangeIndicator m_RadialIndicator1;
		NNeedleValueIndicator m_RadialIndicator2;
		NMarkerValueIndicator m_RadialIndicator3;

		NRangeIndicator m_HorzLinearIndicator1;
		NMarkerValueIndicator m_HorzLinearIndicator2;

		NRangeIndicator m_VertLinearIndicator1;
		NMarkerValueIndicator m_VertLinearIndicator2;

		public NDraggingIndicatorsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Dragging Indicators";
			}
		}

		public override string Description
		{
			get
			{
				return "The example shows how to enable indicator dragging and snapping features. \r\n" +
						"Press the left mouse button over a gauge indicator and begin to drag. The indicator will snap to certain values according to the value snapping mode selected from the \"Indicators Snap Mode\" combo box on the right. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Dragging Gauge Indicators");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			nChartControl1.Panels.Add(CreateHorizontalLinearGauge());
			nChartControl1.Panels.Add(CreateVerticalLinearGauge());
			nChartControl1.Panels.Add(CreateRadialGauge());

			nChartControl1.Controller.Tools.Add(new NSelectorTool());
			nChartControl1.Controller.Tools.Add(new NIndicatorDragTool());

			// Init form controls
			IndicatorsSnapModeComboBox.Items.Add("None");
			IndicatorsSnapModeComboBox.Items.Add("Ruler");
			IndicatorsSnapModeComboBox.Items.Add("Major ticks");
			IndicatorsSnapModeComboBox.Items.Add("Minor ticks");
			IndicatorsSnapModeComboBox.Items.Add("Ruler Min/Max");
			IndicatorsSnapModeComboBox.Items.Add("Numeric");

			IndicatorsSnapModeComboBox.SelectedIndex = 0;

			NExampleHelpers.BindComboToItemSource(OriginNumericComboBox, 0, 20, 1);
			OriginNumericComboBox.SelectedItem = 0;
			NExampleHelpers.BindComboToItemSource(StepNumericComboBox, 1, 20, 1);
			StepNumericComboBox.SelectedItem = 1;
		}

		private NRadialGaugePanel CreateRadialGauge()
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

			radialGauge.Location = new NPointL(new NLength(32, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(58, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			radialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);
			radialGauge.PaintEffect = new NGlassEffectStyle();
			radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);

			// configure the axis
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			ConfigureAxis(axis);

			// add some indicators
			m_RadialIndicator1 = new NRangeIndicator();
			m_RadialIndicator1.Value = 50;
			m_RadialIndicator1.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
			m_RadialIndicator1.StrokeStyle.Color = Color.DarkBlue;
			m_RadialIndicator1.EndWidth = new NLength(20);
			radialGauge.Indicators.Add(m_RadialIndicator1);

			m_RadialIndicator2 = new NNeedleValueIndicator();
			m_RadialIndicator2.Value = 79;
			m_RadialIndicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_RadialIndicator2.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(m_RadialIndicator2);
			radialGauge.SweepAngle = 270;

			m_RadialIndicator3 = new NMarkerValueIndicator();
			m_RadialIndicator3.Value = 90;
			radialGauge.Indicators.Add(m_RadialIndicator3);

			return radialGauge;
		}

		private NLinearGaugePanel CreateHorizontalLinearGauge()
		{
			NLinearGaugePanel linearGauge = new NLinearGaugePanel();

			linearGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage),
												new NLength(20, NRelativeUnit.ParentPercentage));
			linearGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage),
											new NLength(60, NGraphicsUnit.Point));

			linearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
			linearGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

			// add indicators
			m_HorzLinearIndicator1 = new NRangeIndicator();
			m_HorzLinearIndicator1.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
			m_HorzLinearIndicator1.StrokeStyle.Color = Color.DarkBlue;
			m_HorzLinearIndicator1.Value = 10;
			linearGauge.Indicators.Add(m_HorzLinearIndicator1);

			m_HorzLinearIndicator2 = new NMarkerValueIndicator();
			m_HorzLinearIndicator2.Value = 50;
			linearGauge.Indicators.Add(m_HorzLinearIndicator2);

			NGaugeAxis axis = (NGaugeAxis)linearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor();
			axis.Range = new NRange1DD(-100, 100);
			ConfigureAxis(axis);

			return linearGauge;
		}

		private NLinearGaugePanel CreateVerticalLinearGauge()
		{
			NLinearGaugePanel linearGauge = new NLinearGaugePanel();
			linearGauge.Orientation = LinearGaugeOrientation.Vertical;

			linearGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));
			linearGauge.Size = new NSizeL(new NLength(60, NGraphicsUnit.Point), new NLength(50, NRelativeUnit.ParentPercentage));
			linearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
			linearGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

			// add indicators
			m_VertLinearIndicator1 = new NRangeIndicator();
			m_VertLinearIndicator1.Value = 10;
			m_VertLinearIndicator1.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
			m_VertLinearIndicator1.StrokeStyle.Color = Color.DarkBlue;
			linearGauge.Indicators.Add(m_VertLinearIndicator1);

			m_VertLinearIndicator2 = new NMarkerValueIndicator();
			m_VertLinearIndicator2.Value = 50;
			linearGauge.Indicators.Add(m_VertLinearIndicator2);

			NGaugeAxis axis = (NGaugeAxis)linearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor();

			ConfigureAxis(axis);

			return linearGauge;
		}

		private void ConfigureAxis(NGaugeAxis axis)
		{
			NStandardScaleConfigurator configurator = (NStandardScaleConfigurator)axis.ScaleConfigurator;
			configurator.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			configurator.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			configurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Times New Roman", 10, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold);
			configurator.OuterMajorTickStyle.LineStyle.Color = Color.White;
			configurator.OuterMinorTickStyle.LineStyle.Color = Color.White;
			configurator.RulerStyle.BorderStyle.Color = Color.White;
			configurator.MinorTickCount = 4;
		}
		
		public void UpdateValueSnapper()
		{
			if (m_RadialIndicator1 != null)
			{
				m_RadialIndicator1.ValueSnapper = GetAxisValueSnapper();
				m_RadialIndicator2.ValueSnapper = GetAxisValueSnapper();
				m_RadialIndicator3.ValueSnapper = GetAxisValueSnapper();
				m_HorzLinearIndicator1.ValueSnapper = GetAxisValueSnapper();
				m_HorzLinearIndicator2.ValueSnapper = GetAxisValueSnapper();
				m_VertLinearIndicator1.ValueSnapper = GetAxisValueSnapper();
				m_VertLinearIndicator2.ValueSnapper = GetAxisValueSnapper();

				bool enableNumericControls = IndicatorsSnapModeComboBox.SelectedIndex == 5;

				OriginNumericComboBox.IsEnabled = enableNumericControls;
				StepNumericComboBox.IsEnabled = enableNumericControls;
			}
		}

		private NValueSnapper GetAxisValueSnapper()
		{
			int index = IndicatorsSnapModeComboBox.SelectedIndex;

			switch (index)
			{
				case 0: //None, snapping is disabled
					return null;
				case 1: // Ruler, values are constrained to the ruler begin and end values.
					return new NAxisRulerClampSnapper();
				case 2: // Major ticks, values are snapped to axis major ticks
					return new NAxisMajorTickSnapper();
				case 3: // Minor ticks, values are snapped to axis minor ticks
					return new NAxisMinorTickSnapper();
				case 4: // Ruler Min Max, values are snapped to the ruler min and max values
					return new NAxisRulerMinMaxSnapper();
				case 5:
					return new NNumericValueSnapper((int)OriginNumericComboBox.SelectedItem, (int)StepNumericComboBox.SelectedItem);
			}

			return null;
		}

		private void AllowDragRangeIndicatorsCheckBox_Click(object sender, RoutedEventArgs e)
		{
			if (m_RadialIndicator1 != null)
			{
				bool allowDrag = AllowDragRangeIndicatorsCheckBox.IsChecked.Value;

				m_RadialIndicator1.AllowDragging = allowDrag;
				m_HorzLinearIndicator1.AllowDragging = allowDrag;
				m_VertLinearIndicator1.AllowDragging = allowDrag;
			}
		}

		private void IndicatorsSnapModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateValueSnapper();
		}

		private void OriginNumericComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateValueSnapper();
		}

		private void StepNumericComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateValueSnapper();
		}
	}
}
