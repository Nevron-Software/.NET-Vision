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
	/// Interaction logic for NGaugeHitTestingUC.xaml
	/// </summary>
	public partial class NGaugeHitTestingUC : NExampleBaseUC
	{
		public NGaugeHitTestingUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Hit Testing";
			}
		}

		public override string Description
		{
			get
			{
				return "The example demonstrates how to hit test a gauge at runtime.\r\n"+
				"Move the mouse over a gauge element and the text box on the right side will show the gauge element beneath the mouse. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Hit Testing");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
			radialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
			radialGauge.PaintEffect = new NGlassEffectStyle();
			radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			radialGauge.BackgroundFillStyle = new NAdvancedGradientFillStyle(AdvancedGradientScheme.WhiteOnBlack, 0);

			radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			radialGauge.PositionChildPanelsInContentBounds = true;

			// configure scale
			NLinearScaleConfigurator scale = ((NGaugeAxis)radialGauge.Axes[0]).ScaleConfigurator as NLinearScaleConfigurator;
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelFitModes = new LabelFitMode[0];
			scale.MinorTickCount = 3;
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
			scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);

			nChartControl1.Panels.Add(radialGauge);

			NRangeIndicator indicator1 = new NRangeIndicator();
			indicator1.Value = 50;
			indicator1.FillStyle = new NColorFillStyle(Color.LightBlue);
			indicator1.StrokeStyle.Color = Color.DarkBlue;
			indicator1.EndWidth = new NLength(20);
			radialGauge.Indicators.Add(indicator1);

			NNeedleValueIndicator indicator2 = new NNeedleValueIndicator();
			indicator2.Value = 79;
			indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			indicator2.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(indicator2);
			radialGauge.SweepAngle = 270;

			NMarkerValueIndicator indicator3 = new NMarkerValueIndicator();
			indicator3.Value = 90;
			radialGauge.Indicators.Add(indicator3);

			// subscribe for control events
			nChartControl1.PreviewMouseMove += new MouseEventHandler(nChartControl1_PreviewMouseMove);
			nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			nChartControl1.Controller.Tools.Clear();
		}

		public override void Destroy()
		{
			nChartControl1.PreviewMouseMove -= new MouseEventHandler(nChartControl1_PreviewMouseMove);
			base.Destroy();
		}

		void nChartControl1_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			System.Windows.Point p = e.GetPosition(nChartControl1);
			NHitTestResult hitTestResult = (NHitTestResult)nChartControl1.HitTest((int)p.X, (int)p.Y);

			switch (hitTestResult.ChartElement)
			{
				case ChartElement.GaugeAxis:
					NGaugeAxis gaugeAxis = hitTestResult.GaugeAxis;
					CurrentElementTextBox.Text = "Gauge Axis Range: [" + gaugeAxis.Range.Begin.ToString() + ", " + gaugeAxis.Range.End.ToString() + "]";
					break;
				case ChartElement.GaugeMarker:
					NMarkerValueIndicator markerValueIndicator = hitTestResult.MarkerValueIndicator;
					CurrentElementTextBox.Text = "Gauge Marker Value: " + markerValueIndicator.Value.ToString();
					break;
				case ChartElement.GaugeNeedle:
					NNeedleValueIndicator needleIndicator = hitTestResult.NeedleValueIndicator;
					CurrentElementTextBox.Text = "Gauge Needle Value: " + needleIndicator.Value.ToString();
					break;
				case ChartElement.GaugeRange:
					NRangeIndicator rangeIndicator = hitTestResult.RangeIndicator;
					CurrentElementTextBox.Text = "Gauge range: [" + rangeIndicator.Range.Begin.ToString() + ", " + rangeIndicator.Range.End.ToString() + "]";
					break;
				default:
					CurrentElementTextBox.Text = "";
					break;
			}
		}		 
	}
}
