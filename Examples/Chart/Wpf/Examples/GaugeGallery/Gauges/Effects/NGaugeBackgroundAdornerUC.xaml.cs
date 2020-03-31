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
	/// Interaction logic for NGaugeBackgroundAdornerUC.xaml
	/// </summary>
	public partial class NGaugeBackgroundAdornerUC : NExampleBaseUC
	{
		private NRadialGaugePanel m_RadialGauge;
		private NLinearGaugePanel m_LinearGauge;

		public NGaugeBackgroundAdornerUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Background Adorner";
			}
		}

		public override string Description
		{
			get
			{
				return "This example demonstrates how to apply gauge background adorners which are helpful when you want to display more visually appealing gauges. In this example the gauges combine a background adorner and a glass cap effect. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Gauge Background Adorner");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create the radial gauge
			CreateRadialGauge();

			// create the linear gauge
			CreateLinearGauge();

			// update form controls
			
			NExampleHelpers.BindComboToItemSource(LeftMarginComboBox, 0, 100, 5);
			LeftMarginComboBox.SelectedItem = 0;
			NExampleHelpers.BindComboToItemSource(TopMarginComboBox, 0, 100, 5);
			TopMarginComboBox.SelectedItem = 55;
			NExampleHelpers.BindComboToItemSource(RightMarginComboBox, 0, 100, 5);
			RightMarginComboBox.SelectedItem = 0;
			NExampleHelpers.BindComboToItemSource(BottomMarginComboBox, 0, 100, 5);
			BottomMarginComboBox.SelectedItem = 0;

			NExampleHelpers.FillComboWithEnumValues(AdornerShapeComboBox, typeof(GaugeBackroundAdornerShape));
			AdornerShapeComboBox.SelectedIndex = 0;

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
			m_LinearGauge.BackgroundFillStyle = new NColorFillStyle(Color.Black);
			m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);

			NGaugeAxis axis = (NGaugeAxis)m_LinearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor(new NLength(10, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left);
			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			AddRangeIndicatorToGauge(m_LinearGauge);
			m_LinearGauge.Indicators.Add(new NMarkerValueIndicator(60));
		}

		private NGaugeBackgroundAdorner CreateBackgroundAdorner()
		{
			GaugeBackroundAdornerShape shape = (GaugeBackroundAdornerShape)AdornerShapeComboBox.SelectedIndex;

			if (LeftMarginComboBox.SelectedItem == null ||
				TopMarginComboBox.SelectedItem == null ||
				RightMarginComboBox.SelectedItem == null ||
				BottomMarginComboBox.SelectedItem == null)
				return null;

			NMarginsL margins = new NMarginsL(new NLength((int)LeftMarginComboBox.SelectedItem, NRelativeUnit.ParentPercentage),
												new NLength((int)TopMarginComboBox.SelectedItem, NRelativeUnit.ParentPercentage),
												new NLength((int)RightMarginComboBox.SelectedItem, NRelativeUnit.ParentPercentage),
												new NLength((int)BottomMarginComboBox.SelectedItem, NRelativeUnit.ParentPercentage));

			NGaugeBackgroundAdorner adorner = new NGaugeBackgroundAdorner();
			adorner.FillStyle = new NGradientFillStyle(Color.FromArgb(0, Color.Black), Color.FromArgb(120, Color.LightGreen));
			adorner.Shape = shape;
			adorner.Margins = margins;

			return adorner;
		}

		private void UpdateEffects()
		{
			if (m_LinearGauge == null || m_RadialGauge == null)
				return;

			NGaugeBackgroundAdorner adorner = CreateBackgroundAdorner();
			if (adorner != null)
			{
				m_LinearGauge.BackgroundAdorner = adorner;
				m_RadialGauge.BackgroundAdorner = adorner;
			}

			nChartControl1.Refresh();
		}

		private void CreateRadialGauge()
		{
			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
			nChartControl1.Panels.Add(m_RadialGauge);

			// create the radial gauge
			m_RadialGauge.BeginAngle = -225;
			m_RadialGauge.SweepAngle = 270;

			// set some background
			m_RadialGauge.BackgroundFillStyle = new NColorFillStyle(Color.Black); ;
			m_RadialGauge.PaintEffect = new NGlassEffectStyle();
			m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);

			// configure the axis
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

			LinearGaugeOrientationComboBox.SelectedIndex = 0;
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
			rangeIndicator.PaintOrder = IndicatorPaintOrder.AfterScale;

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

		private void AdornerShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateEffects();
		}

		private void LeftMarginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateEffects();
		}

		private void TopMarginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateEffects();
		}

		private void RightMarginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateEffects();
		}

		private void BottomMarginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateEffects();
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
