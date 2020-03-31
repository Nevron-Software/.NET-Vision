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
	/// Interaction logic for NGaugeTooltipsUC.xaml
	/// </summary>
	public partial class NGaugeTooltipsUC : NExampleBaseUC
	{
		NRangeIndicator m_Indicator1;
		NNeedleValueIndicator m_Indicator2;
		NMarkerValueIndicator m_Indicator3;
		NGaugeAxis m_Axis;

		public NGaugeTooltipsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Tooltips";
			}
		}

		public override string Description
		{
			get
			{
				return "This example demonstrates how to assign tooltips to gauge elements.\r\n" +
						"Move the mouse over a gauge element to show its tooltip.";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Tooltips");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
			radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			radialGauge.PaintEffect = new NGlassEffectStyle();
			radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			radialGauge.BackgroundFillStyle = new NAdvancedGradientFillStyle(AdvancedGradientScheme.WhiteOnBlack, 0);

			// configure scale
			NLinearScaleConfigurator scale = ((NGaugeAxis)radialGauge.Axes[0]).ScaleConfigurator as NLinearScaleConfigurator;
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelFitModes = new LabelFitMode[0];
			scale.MinorTickCount = 3;
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
			scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);

			m_Axis = (NGaugeAxis)radialGauge.Axes[0];

			nChartControl1.Panels.Add(radialGauge);

			m_Indicator1 = new NRangeIndicator();
			m_Indicator1.Value = 50;
			m_Indicator1.FillStyle = new NColorFillStyle(Color.LightBlue);
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
			m_Indicator1.EndWidth = new NLength(20);
			radialGauge.Indicators.Add(m_Indicator1);

			m_Indicator2 = new NNeedleValueIndicator();
			m_Indicator2.Value = 79;
			m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_Indicator2.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(m_Indicator2);
			radialGauge.SweepAngle = 270;

			m_Indicator3 = new NMarkerValueIndicator();
			m_Indicator3.Value = 90;
			radialGauge.Indicators.Add(m_Indicator3);

			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// init form controls
			UpdateTooltips();
		}

		private void UpdateTooltips()
		{
			if (m_Axis == null)
				return;

			m_Indicator1.InteractivityStyle.Tooltip.Text = RangeTooltipTextBox.Text;
			m_Indicator2.InteractivityStyle.Tooltip.Text = NeedleTooltipTextBox.Text;
			m_Indicator3.InteractivityStyle.Tooltip.Text = MarkerTooltipTextBox.Text;
			m_Axis.InteractivityStyle.Tooltip.Text = ScaleTooltipTextBox.Text;
		}

		private void NeedleTooltipTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			UpdateTooltips();
		}

		private void MarkerTooltipTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			UpdateTooltips();
		}

		private void RangeTooltipTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			UpdateTooltips();
		}

		private void ScaleTooltipTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			UpdateTooltips();
		}
	}
}
