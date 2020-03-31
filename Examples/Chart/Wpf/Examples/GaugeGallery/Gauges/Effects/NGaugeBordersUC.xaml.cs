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
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NGaugeBordersUC.xaml
	/// </summary>
	public partial class NGaugeBordersUC : NExampleBaseUC
	{
		private NRadialGaugePanel m_RadialGauge;
		private NLinearGaugePanel m_LinearGauge;

		public NGaugeBordersUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Borders";
			}
		}

		public override string Description
		{
			get
			{
				Byte[] buffer = new byte[] { (byte)149 };

				return "This example demonstrates how to apply border style to gauges.\r\n"+
						"You can choose the border type from the combo \"Border Type\" combo on the right. There are three options:\r\n\r\n"+

						Encoding.GetEncoding(1252).GetString(buffer) + " Rectangular - applies a standard rectangular border to the gauges. \r\n"+
						Encoding.GetEncoding(1252).GetString(buffer) + " Rounded Rectangular - applies a standard rounded rectangular border to the gauges. You can use the corner rounding to modify rounding of the rectangle edges. \r\n"+
						Encoding.GetEncoding(1252).GetString(buffer) + " Auto - the border is applied depending on the gauge type. For radial gauges you can choose from Circle, Cut Circle and Rounded Outline. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Gauge Borders");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create the radial gauge
			CreateRadialGauge();

			// create the linear gauge
			CreateLinearGauge();

			BeginAngleScrollBar.Value = (int)m_RadialGauge.BeginAngle;
			SweepAngleScrollBar.Value = (int)m_RadialGauge.SweepAngle;

			NExampleHelpers.BindComboToItemSource(CenterRoundingNumericComboBox, 0, 100, 5);
			CenterRoundingNumericComboBox.SelectedItem = 15;

			NExampleHelpers.BindComboToItemSource(EdgeRoundingNumericComboBox, 0, 100, 5);
			EdgeRoundingNumericComboBox.SelectedItem = 10;

			NExampleHelpers.BindComboToItemSource(RoundRectRoundingComboBox, 0, 100, 5);
			RoundRectRoundingComboBox.SelectedItem = 10;

			LinearGaugeOrientationComboBox.Items.Add("Horizontal");
			LinearGaugeOrientationComboBox.Items.Add("Vertical");
			LinearGaugeOrientationComboBox.SelectedIndex = 1;

			BorderTypeComboBox.Items.Add("Rectangular");
			BorderTypeComboBox.Items.Add("Rounded Rectangular");
			BorderTypeComboBox.Items.Add("Auto");
			BorderTypeComboBox.SelectedIndex = 2;

			RadialGaugeAutoBorderTypeComboBox.Items.Add("Circle");
			RadialGaugeAutoBorderTypeComboBox.Items.Add("Cut Circle");
			RadialGaugeAutoBorderTypeComboBox.Items.Add("Rounded Outline");
			RadialGaugeAutoBorderTypeComboBox.SelectedIndex = 0;
		}

		private void ApplyScaleSectionToAxis(NLinearScaleConfigurator scale)
		{
			NScaleSectionStyle scaleSection = new NScaleSectionStyle();

			scaleSection.Range = new NRange1DD(70, 100);
			scaleSection.LabelTextStyle = new NTextStyle();
			scaleSection.LabelTextStyle.FillStyle = new NColorFillStyle(KnownArgbColorValue.DarkRed);
			scaleSection.LabelTextStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Bold);
			scaleSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkRed);

			scale.Sections.Add(scaleSection);
		}

		private void CreateLinearGauge()
		{
			m_LinearGauge = new NLinearGaugePanel();
			nChartControl1.Panels.Add(m_LinearGauge);

			// create the background panel
			NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
			advGradient.BackgroundColor = Color.Black;
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle));
			m_LinearGauge.BackgroundFillStyle = advGradient;
			m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);

			NGaugeAxis axis = (NGaugeAxis)m_LinearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor(new NLength(10, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left);
			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			AddRangeIndicatorToGauge(m_LinearGauge);
			m_LinearGauge.Indicators.Add(new NMarkerValueIndicator(60));
		}

		private void CreateRadialGauge()
		{
			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
			m_RadialGauge.PaintEffect = new NGlassEffectStyle();
			m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			nChartControl1.Panels.Add(m_RadialGauge);

			// create the radial gauge
			m_RadialGauge.SweepAngle = 270;
			m_RadialGauge.BeginAngle = -90;

			// set some background
			NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
			advGradient.BackgroundColor = Color.Black;
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle));
			m_RadialGauge.BackgroundFillStyle = advGradient;

			// configure its axis
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 100);
			axis.Anchor.RulerOrientation = RulerOrientation.Right;
			axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			AddRangeIndicatorToGauge(m_RadialGauge);

			NNeedleValueIndicator needle = new NNeedleValueIndicator(60);
			needle.OffsetFromScale = new NLength(15);
			m_RadialGauge.Indicators.Add(needle);
		}

		private void AddRangeIndicatorToGauge(NGaugePanel gauge)
		{
			// add some indicators
			NRangeIndicator rangeIndicator = new NRangeIndicator(new NRange1DD(75, 100));
			rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
			rangeIndicator.StrokeStyle.Width = new NLength(0);
			rangeIndicator.OffsetFromScale = new NLength(11);
			rangeIndicator.BeginWidth = new NLength(5);
			rangeIndicator.EndWidth = new NLength(10);
			rangeIndicator.OffsetFromScale = new NLength(15);
			rangeIndicator.PaintOrder = IndicatorPaintOrder.BeforeScale;

			gauge.Indicators.Add(rangeIndicator);
		}

		private void ConfigureScale(NLinearScaleConfigurator scale)
		{
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelFitModes = new LabelFitMode[0];
			scale.MinorTickCount = 3;
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
			scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Bold);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
		}

		private void UpdateGaugeBorders()
		{
			if (m_RadialGauge == null || m_LinearGauge == null)
				return;

			bool enableRoundRelatedControls = false;
			bool enableAutoRelatedControls = false;
			switch (BorderTypeComboBox.SelectedIndex)
			{
				case 0: // rect
					m_RadialGauge.BorderStyle.Shape = BorderShape.Rectangle;
					m_LinearGauge.BorderStyle.Shape = BorderShape.Rectangle;
					break;
				case 1: // rounded rect
					m_RadialGauge.BorderStyle.Shape = BorderShape.RoundedRect;
					m_RadialGauge.BorderStyle.CornerRounding = new NLength((int)RoundRectRoundingComboBox.SelectedItem, NGraphicsUnit.Point);
					m_LinearGauge.BorderStyle.Shape = BorderShape.RoundedRect;
					m_LinearGauge.BorderStyle.CornerRounding = new NLength((int)RoundRectRoundingComboBox.SelectedItem, NGraphicsUnit.Point);

					break;
				case 2: // auto
					enableAutoRelatedControls = true;
					m_RadialGauge.BorderStyle.Shape = BorderShape.Auto;
					m_LinearGauge.BorderStyle.Shape = BorderShape.Auto;
					break;
			}

			if (m_RadialGauge.BorderStyle.Shape == BorderShape.Auto)
			{
				// also apply auto settings

				switch (RadialGaugeAutoBorderTypeComboBox.SelectedIndex)
				{
					case 0: // circle
						m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.Circle;
						break;
					case 1: // cut circle
						enableRoundRelatedControls = true;
						m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.CutCircle;
						m_RadialGauge.CenterBorderRounding = new NLength((int)CenterRoundingNumericComboBox.SelectedItem, NGraphicsUnit.Point);
						m_RadialGauge.EdgeBorderRounding = new NLength((int)EdgeRoundingNumericComboBox.SelectedItem, NGraphicsUnit.Point);
						break;
					case 2: // rounded outline
						enableRoundRelatedControls = true;
						m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.RoundedOutline;
						m_RadialGauge.CenterBorderRounding = new NLength((int)CenterRoundingNumericComboBox.SelectedItem, NGraphicsUnit.Point);
						m_RadialGauge.EdgeBorderRounding = new NLength((int)EdgeRoundingNumericComboBox.SelectedItem, NGraphicsUnit.Point);
						break;
				}
			}

			RadialGaugeAutoBorderTypeComboBox.IsEnabled = enableAutoRelatedControls;
			CenterRoundingNumericComboBox.IsEnabled = enableRoundRelatedControls;
			EdgeRoundingNumericComboBox.IsEnabled = enableRoundRelatedControls;

			nChartControl1.Refresh();
		}

		private void BorderTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateGaugeBorders();
		}

		private void RoundRectRoundingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateGaugeBorders();
		}

		private void RadialGaugeAutoBorderTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateGaugeBorders();
		}

		private void CenterRoundingNumericComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateGaugeBorders();
		}

		private void EdgeRoundingNumericComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateGaugeBorders();
		}

		private void BeginAngleScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			m_RadialGauge.BeginAngle = (float)BeginAngleScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void SweepAngleScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			m_RadialGauge.SweepAngle = (float)SweepAngleScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void LinearGaugeOrientationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_LinearGauge.Orientation = (LinearGaugeOrientation)LinearGaugeOrientationComboBox.SelectedIndex;

			if (m_LinearGauge.Orientation == LinearGaugeOrientation.Horizontal)
			{
				m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
				m_RadialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
				m_RadialGauge.ContentAlignment = ContentAlignment.BottomCenter;

				m_LinearGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
				m_LinearGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NGraphicsUnit.Point));
				m_LinearGauge.Padding = new NMarginsL(13, 0, 13, 0);
			}
			else
			{
				m_RadialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
				m_RadialGauge.Size = new NSizeL(new NLength(45, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
				m_RadialGauge.ContentAlignment = ContentAlignment.BottomRight;

				m_LinearGauge.Location = new NPointL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
				m_LinearGauge.Size = new NSizeL(new NLength(80, NGraphicsUnit.Point), new NLength(80, NRelativeUnit.ParentPercentage));
				m_LinearGauge.Padding = new NMarginsL(0, 13, 0, 13);
			}

			nChartControl1.Refresh();
		}
	}
}
