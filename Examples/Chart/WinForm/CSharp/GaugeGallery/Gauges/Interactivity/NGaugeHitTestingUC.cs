using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGaugeHitTestingUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox CurrentElementTextBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NGaugeHitTestingUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

		}

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Hit Testing");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
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
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold | FontStyle.Italic);
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
			nChartControl1.MouseMove += new MouseEventHandler(ChartControl_MouseMove);
		}

		private void ChartControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			NHitTestResult hitTestResult = nChartControl1.HitTest(e.X, e.Y);

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

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.CurrentElementTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current Element:";
			// 
			// CurrentElementTextBox
			// 
			this.CurrentElementTextBox.Enabled = false;
			this.CurrentElementTextBox.Location = new System.Drawing.Point(8, 40);
			this.CurrentElementTextBox.Name = "CurrentElementTextBox";
			this.CurrentElementTextBox.Size = new System.Drawing.Size(156, 18);
			this.CurrentElementTextBox.TabIndex = 1;
			// 
			// NGaugeHitTestingUC
			// 
			this.Controls.Add(this.CurrentElementTextBox);
			this.Controls.Add(this.label1);
			this.Name = "NGaugeHitTestingUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
