using System;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NGaugeScaleLabelsOrientationUC.xaml
	/// </summary>
	public partial class NGaugeScaleLabelsOrientationUC : NExampleBaseUC
	{
		private NRadialGaugePanel m_RadialGauge;
		private NLinearGaugePanel m_LinearGauge;

		public NGaugeScaleLabelsOrientationUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Labels Orientation";
			}
		}

		public override string Description
		{
			get
			{
				Byte[] buffer = new byte[] { (byte)149 };

				return "This example demonstrates how to set the orientation of the gauge axis labels.\r\n" +
						"You can use the angle mode combo to select the mode in which labels operate. There are three options:\r\n\r\n" +

						Encoding.GetEncoding(1252).GetString(buffer) + " Auto - the angle is automatically computed by the scale (orthogonal to the ruler at the point of the label) \r\n" +
						Encoding.GetEncoding(1252).GetString(buffer) + " Custom - the angle is specified by the user \r\n" +
						Encoding.GetEncoding(1252).GetString(buffer) + " AutoAndCustom - the angle is first automatically computed and then the custom angle specified by the user is added ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Gauge Labels Orientation");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create the radial gauge
			CreateRadialGauge();

			// create the linear gauge
			CreateLinearGauge();

			// update form controls
			NExampleHelpers.BindComboToItemSource(CustomAngleNumericComboBox, 0, 360, 10);
			CustomAngleNumericComboBox.SelectedItem = 0;

			NExampleHelpers.FillComboWithEnumValues(AngleModeComboBox, typeof(ScaleLabelAngleMode));
			AngleModeComboBox.SelectedIndex = (int)ScaleLabelAngleMode.View;
			
			BeginAngleScrollBar.Value = (int)m_RadialGauge.BeginAngle;
			SweepAngleScrollBar.Value = (int)m_RadialGauge.SweepAngle;

			LinearGaugeOrientationComboBox.Items.Add("Horizontal");
			LinearGaugeOrientationComboBox.Items.Add("Vertical");
			LinearGaugeOrientationComboBox.SelectedIndex = 1;			
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

			// configure the axis
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 100);
			axis.Anchor.RulerOrientation = RulerOrientation.Right;
			axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			AddRangeIndicatorToGauge(m_RadialGauge);

			NNeedleValueIndicator needle = new NNeedleValueIndicator(60);
			needle.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleMiddle;
			needle.OffsetFromScale = new NLength(15);
			m_RadialGauge.Indicators.Add(needle);
		}

		private void AddRangeIndicatorToGauge(NGaugePanel gauge)
		{
			// add some indicators
			NRangeIndicator rangeIndicator = new NRangeIndicator(new NRange1DD(75, 100));
			rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
			rangeIndicator.StrokeStyle.Width = new NLength(0);
			rangeIndicator.BeginWidth = new NLength(5);
			rangeIndicator.EndWidth = new NLength(10);
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

		private void UpdateScaleLabelAngle()
		{
			NScaleLabelAngle angle = new NScaleLabelAngle((ScaleLabelAngleMode)AngleModeComboBox.SelectedIndex,
															(int)CustomAngleNumericComboBox.SelectedItem,
															AllowTextFlipCheckBox.IsChecked.Value);

			// apply angle to radial gauge axis
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			scale.LabelStyle.Angle = angle;

			// apply angle to linear gauge axis
			axis = (NGaugeAxis)m_LinearGauge.Axes[0];
			scale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			scale.LabelStyle.Angle = angle;

			nChartControl1.Refresh();
		}

		private void AngleModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScaleLabelAngle();
		}

		private void CustomAngleNumericComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScaleLabelAngle();
		}

		private void AllowTextFlipCheckBox_Click(object sender, RoutedEventArgs e)
		{
			UpdateScaleLabelAngle();
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

		private void AngleModeComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
			UpdateScaleLabelAngle();
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
