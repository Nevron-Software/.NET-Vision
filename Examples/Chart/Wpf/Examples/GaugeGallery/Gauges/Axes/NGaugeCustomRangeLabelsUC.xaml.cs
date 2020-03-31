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
	/// Interaction logic for NGaugeCustomRangeLabelsUC.xaml
	/// </summary>
	public partial class NGaugeCustomRangeLabelsUC : NExampleBaseUC
	{
		NLinearGaugePanel m_LinearGauge;
		NRadialGaugePanel m_RadialGauge;

		public NGaugeCustomRangeLabelsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Custom Range Labels";
			}
		}

		public override string Description
		{
			get
			{
				return "This example demonstrates how to add custom range labels to gauge axes. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Gauge Custom Range Labels<br/><font size = '9pt'>Demonstrates how to use custom range labels to denote ranges on a scale</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.ContentAlignment = System.Drawing.ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create the radial gauge
			CreateRadialGauge();

			// create the linear gauge
			CreateLinearGauge();

			// init form controls
			BeginAngleScrollBar.Value = (int)m_RadialGauge.BeginAngle;
			SweepAngleScrollBar.Value = (int)m_RadialGauge.SweepAngle;

			LinearGaugeOrientationComboBox.Items.Add("Horizontal");
			LinearGaugeOrientationComboBox.Items.Add("Vertical");
			LinearGaugeOrientationComboBox.SelectedIndex = 1;

			ShowMinRangeCheckBox.IsChecked = true;
			ShowMaxRangeCheckBox.IsChecked = true;
		}

		private void CreateLinearGauge()
		{
			m_LinearGauge = new NLinearGaugePanel();
			nChartControl1.Panels.Add(m_LinearGauge);

			// create the background panel
			NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
			advGradient.BackgroundColor = Color.Black;
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle));
			m_LinearGauge.BackgroundFillStyle = advGradient;
			m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);

			NGaugeAxis axis = (NGaugeAxis)m_LinearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor(new NLength(20, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left);
			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
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
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle));
			m_RadialGauge.BackgroundFillStyle = advGradient;

			// configure the axis
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 100);
			axis.Anchor.RulerOrientation = RulerOrientation.Right;
			axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			NNeedleValueIndicator needle = new NNeedleValueIndicator(60);
			needle.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleMiddle;
			needle.OffsetFromScale = new NLength(15);
			m_RadialGauge.Indicators.Add(needle);
		}

		private void ConfigureScale(NLinearScaleConfigurator scale)
		{
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelFitModes = new LabelFitMode[0];
			scale.MinorTickCount = 3;
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
			scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, System.Drawing.FontStyle.Bold);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
		}

		private void UpdateAxisRanges()
		{
			NLinearScaleConfigurator linearGaugeScale = ((NGaugeAxis)m_LinearGauge.Axes[0]).ScaleConfigurator as NLinearScaleConfigurator;
			NLinearScaleConfigurator radialGaugeScale = ((NGaugeAxis)m_RadialGauge.Axes[0]).ScaleConfigurator as NLinearScaleConfigurator;

			linearGaugeScale.CustomLabels.Clear();
			linearGaugeScale.Sections.Clear();

			radialGaugeScale.CustomLabels.Clear();
			radialGaugeScale.Sections.Clear();

			if (ShowMinRangeCheckBox.IsChecked.Value)
			{
				ApplyScaleSectionToAxis(linearGaugeScale, "Min", new NRange1DD(0, 20), Color.LightBlue);
				ApplyScaleSectionToAxis(radialGaugeScale, "Min", new NRange1DD(0, 20), Color.LightBlue);
			}

			if (ShowMaxRangeCheckBox.IsChecked.Value)
			{
				ApplyScaleSectionToAxis(linearGaugeScale, "Max", new NRange1DD(80, 100), Color.Red);
				ApplyScaleSectionToAxis(radialGaugeScale, "Max", new NRange1DD(80, 100), Color.Red);
			}

			nChartControl1.Refresh();
		}

		private void ApplyScaleSectionToAxis(NLinearScaleConfigurator scale, string text, NRange1DD range, Color color)
		{
			NScaleSectionStyle scaleSection = new NScaleSectionStyle();

			scaleSection.Range = range;
			scaleSection.LabelTextStyle = new NTextStyle();
			scaleSection.LabelTextStyle.FillStyle = new NColorFillStyle(color);
			scaleSection.LabelTextStyle.FontStyle = new NFontStyle("Arial", 10, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
			scaleSection.MajorTickStrokeStyle = new NStrokeStyle(color);

			scale.Sections.Add(scaleSection);

			NCustomRangeLabel rangeLabel = new NCustomRangeLabel(range, text);
			rangeLabel.Style.WrapText = false;
			rangeLabel.Style.KeepInsideRuler = false;
			rangeLabel.Style.StrokeStyle.Color = color;
			rangeLabel.Style.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			rangeLabel.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			rangeLabel.Style.TickMode = RangeLabelTickMode.Center;

			scale.CustomLabels.Add(rangeLabel);
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

		private void SweepAngleScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			m_RadialGauge.SweepAngle = (float)SweepAngleScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void BeginAngleScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			m_RadialGauge.BeginAngle = (float)BeginAngleScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void ShowMinRangeCheckBox_Click(object sender, RoutedEventArgs e)
		{
			UpdateAxisRanges();
		}

		private void ShowMaxRangeCheckBox_Click(object sender, RoutedEventArgs e)
		{
			UpdateAxisRanges();
		}
	}
}
