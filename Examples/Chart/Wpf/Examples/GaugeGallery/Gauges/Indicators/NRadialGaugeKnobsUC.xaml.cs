using System;
using System.Drawing;
using System.Windows.Controls;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.SmartShapes;


namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NRadialGaugeKnobsUC.xaml
	/// </summary>
	public partial class NRadialGaugeKnobsUC : NExampleBaseUC
	{
		bool m_Updating;
		NRadialGaugePanel m_RadialGauge;
		NNumericDisplayPanel m_NumericDisplay;


		public NRadialGaugeKnobsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Knob Indicator";
			}
		}

		public override string Description
		{
			get
			{
				return "The example demonstrates how to add knob indicators to radial gauges.\r\n" +
						"Use the controls on the right to modify different settings for the knob inner and outer rim as well as knob marker. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Radial Gauge Knob Indicators");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.DockMode = PanelDockMode.Top;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			header.Margins = new NMarginsL(5, 5, 5, 5);

			nChartControl1.Panels.Add(header);

			NDockPanel panelContainer = new NDockPanel();
			panelContainer.DockMode = PanelDockMode.Fill;

			// create the knob indicator
			NKnobIndicator knobIndicator = new NKnobIndicator();
			knobIndicator.OffsetFromScale = new NLength(-5);
			knobIndicator.OuterRimStyle.PatternRepeatCount = 5;
			knobIndicator.InnerRimStyle.PatternRepeatCount = 5;
			//knobIndicator.InnerRimStyle.Offset = new NLength(10);
			
			// apply fill style to the marker
			NAdvancedGradientFillStyle advancedGradientFill = new NAdvancedGradientFillStyle();
			advancedGradientFill.BackgroundColor = Color.Red;
			advancedGradientFill.Points.Add(new NAdvancedGradientPoint(Color.White, 20, 20, 0, 100, AGPointShape.Circle));
			knobIndicator.MarkerShape.FillStyle = advancedGradientFill;
			knobIndicator.ValueChanged += knobIndicator_ValueChanged;

			m_RadialGauge = CreateRadialGauge(knobIndicator);
			m_NumericDisplay = CreateNumericDisplay();

			panelContainer.ChildPanels.Add(m_NumericDisplay);
			panelContainer.ChildPanels.Add(m_RadialGauge);

			panelContainer.Margins = new NMarginsL(10, 10, 10, 10);
			nChartControl1.Panels.Add(panelContainer);

			nChartControl1.Controller.Tools.Add(new NSelectorTool());
			nChartControl1.Controller.Tools.Add(new NIndicatorDragTool());

			m_Updating = true;

			// Init form controls 
			NExampleHelpers.FillComboWithEnumValues(MarkerShapeComboBox, typeof(SmartShape2D));
			MarkerShapeComboBox.SelectedIndex = (int)SmartShape2D.Ellipse;

			NExampleHelpers.BindComboToItemSource(MarkerOffsetComboBox, -100, 100, 5);
			MarkerOffsetComboBox.SelectedItem = (int)knobIndicator.OffsetFromScale.Value;

			NExampleHelpers.FillComboWithEnumValues(MarkerPaintOrderComboBox, typeof(KnobMarkerPaintOrder));
			MarkerPaintOrderComboBox.SelectedIndex = (int)knobIndicator.MarkerPaintOrder;

			// outer rim
			NExampleHelpers.FillComboWithEnumValues(OuterRimPatternComboBox, typeof(CircularRimPattern));
			OuterRimPatternComboBox.SelectedIndex = (int)knobIndicator.OuterRimStyle.Pattern;

			NExampleHelpers.BindComboToItemSource(OuterRimPatternRepeatCountComboBox, 0, 100, 5);
			OuterRimPatternRepeatCountComboBox.SelectedItem = (int)knobIndicator.OuterRimStyle.PatternRepeatCount;

			NExampleHelpers.BindComboToItemSource(OuterRimRadiusOffsetComboBox, 0, 100, 5);
			OuterRimRadiusOffsetComboBox.SelectedItem = (int)knobIndicator.OuterRimStyle.Offset.Value;

			// inner rim
			NExampleHelpers.FillComboWithEnumValues(InnerRimPatternComboBox, typeof(CircularRimPattern));
			InnerRimPatternComboBox.SelectedIndex = (int)knobIndicator.InnerRimStyle.Pattern;

			NExampleHelpers.BindComboToItemSource(InnerRimPatternRepeatCountComboBox, 0, 100, 5);
			InnerRimPatternRepeatCountComboBox.SelectedItem = (int)knobIndicator.InnerRimStyle.PatternRepeatCount;

			NExampleHelpers.BindComboToItemSource(InnerRimRadiusOffsetComboBox, 0, 100, 5);
			InnerRimRadiusOffsetComboBox.SelectedItem = (int)knobIndicator.InnerRimStyle.Offset.Value;

			m_Updating = false;

			OuterRimPatternRepeatCountComboBox.SelectedItem = 6;
		}	

		private NRadialGaugePanel CreateRadialGauge(NKnobIndicator knobIndicator)
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

			radialGauge.Size = new NSizeL(new NLength(0), new NLength(50, NRelativeUnit.ParentPercentage));
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			radialGauge.DockMode = PanelDockMode.Fill;
			radialGauge.SweepAngle = 270;
			radialGauge.BeginAngle = -225;
			radialGauge.CapStyle.Visible = false;

			radialGauge.Indicators.Add(knobIndicator);

			// configure scale
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Italic);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.Black);
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			scale.MinorTickCount = 4;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

			return radialGauge;
		}

		private NNumericDisplayPanel CreateNumericDisplay()
		{
			NNumericDisplayPanel numericDisplay = new NNumericDisplayPanel();
			numericDisplay.Size = new NSizeL(new NLength(0), new NLength(50, NRelativeUnit.ParentPercentage));
			numericDisplay.DockMode = PanelDockMode.Bottom;
			numericDisplay.BoundsMode = BoundsMode.Fit;
			numericDisplay.Margins = new NMarginsL(10, 10, 10, 10);
			numericDisplay.ContentAlignment = ContentAlignment.MiddleCenter;

			return numericDisplay;
		}

		private void UpdateKnob()
		{
			if (m_Updating)
				return;

			NKnobIndicator knob = m_RadialGauge.Indicators[0] as NKnobIndicator;

			// update the knob marker shape
			N2DSmartShapeFactory factory = new N2DSmartShapeFactory(knob.MarkerShape.FillStyle, knob.MarkerShape.StrokeStyle, knob.MarkerShape.ShadowStyle);
			knob.MarkerShape = factory.CreateShape((SmartShape2D)MarkerShapeComboBox.SelectedIndex);
			knob.OffsetFromScale = new NLength((int)MarkerOffsetComboBox.SelectedItem, NGraphicsUnit.Point);
			knob.MarkerPaintOrder = (KnobMarkerPaintOrder)MarkerPaintOrderComboBox.SelectedIndex;

			// update the outer rim style
			knob.OuterRimStyle.Pattern = (CircularRimPattern)OuterRimPatternComboBox.SelectedIndex;
			knob.OuterRimStyle.PatternRepeatCount = (int)OuterRimPatternRepeatCountComboBox.SelectedItem;
			knob.OuterRimStyle.Offset = new NLength((int)OuterRimRadiusOffsetComboBox.SelectedItem, NGraphicsUnit.Point);

			// update the inner rim style
			knob.InnerRimStyle.Pattern = (CircularRimPattern)InnerRimPatternComboBox.SelectedIndex;
			knob.InnerRimStyle.PatternRepeatCount = (int)InnerRimPatternRepeatCountComboBox.SelectedItem;
			knob.InnerRimStyle.Offset = new NLength((int)InnerRimRadiusOffsetComboBox.SelectedItem, NGraphicsUnit.Point);

			nChartControl1.Refresh();
		}

		void knobIndicator_ValueChanged(object sender, EventArgs e)
		{
			if (m_RadialGauge == null)
				return;

			m_NumericDisplay.Value = ((NIndicator)m_RadialGauge.Indicators[0]).Value;
		}

		private void MarkerShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}

		private void MarkerOffsetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}

		private void MarkerPaintOrderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}

		private void OuterRimPatternComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}

		private void OuterRimPatternRepeatCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}

		private void OuterRimRadiusOffsetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}

		private void InnerRimPatternComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}

		private void InnerRimPatternRepeatCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}

		private void InnerRimRadiusOffsetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateKnob();
		}
	}
}
