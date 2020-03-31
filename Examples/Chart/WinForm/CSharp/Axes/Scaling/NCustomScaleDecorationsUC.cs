using System;
using System.ComponentModel;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomScaleDecorationsUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown HotZoneBeginUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ColdZoneEndUpDown;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NCustomScaleDecorationsUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

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
			this.label2 = new System.Windows.Forms.Label();
			this.HotZoneBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ColdZoneEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.HotZoneBeginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColdZoneEndUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hot Zone Begin:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Cold Zone End:";
			// 
			// HotZoneBeginUpDown
			// 
			this.HotZoneBeginUpDown.Location = new System.Drawing.Point(8, 40);
			this.HotZoneBeginUpDown.Maximum = new System.Decimal(new int[] {
																			   85,
																			   0,
																			   0,
																			   0});
			this.HotZoneBeginUpDown.Minimum = new System.Decimal(new int[] {
																			   55,
																			   0,
																			   0,
																			   0});
			this.HotZoneBeginUpDown.Name = "HotZoneBeginUpDown";
			this.HotZoneBeginUpDown.Size = new System.Drawing.Size(120, 20);
			this.HotZoneBeginUpDown.TabIndex = 1;
			this.HotZoneBeginUpDown.Value = new System.Decimal(new int[] {
																			 70,
																			 0,
																			 0,
																			 0});
			this.HotZoneBeginUpDown.ValueChanged += new System.EventHandler(this.HotZoneBeginUpDown_ValueChanged);
			// 
			// ColdZoneEndUpDown
			// 
			this.ColdZoneEndUpDown.Location = new System.Drawing.Point(8, 104);
			this.ColdZoneEndUpDown.Maximum = new System.Decimal(new int[] {
																			  45,
																			  0,
																			  0,
																			  0});
			this.ColdZoneEndUpDown.Minimum = new System.Decimal(new int[] {
																			  5,
																			  0,
																			  0,
																			  0});
			this.ColdZoneEndUpDown.Name = "ColdZoneEndUpDown";
			this.ColdZoneEndUpDown.Size = new System.Drawing.Size(120, 20);
			this.ColdZoneEndUpDown.TabIndex = 3;
			this.ColdZoneEndUpDown.Value = new System.Decimal(new int[] {
																			25,
																			0,
																			0,
																			0});
			this.ColdZoneEndUpDown.ValueChanged += new System.EventHandler(this.ColdZoneEndUpDown_ValueChanged);
			// 
			// NCustomScaleDecorationsUC
			// 
			this.Controls.Add(this.ColdZoneEndUpDown);
			this.Controls.Add(this.HotZoneBeginUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NCustomScaleDecorationsUC";
			this.Size = new System.Drawing.Size(136, 296);
			((System.ComponentModel.ISupportInitialize)(this.HotZoneBeginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColdZoneEndUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Temperature Measurements <br/><font size = '12pt'>Demonstrates how to Custom Program the Scale</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.SendToBack();
			title.DockMode = PanelDockMode.Top;

			NLegend legend = nChartControl1.Legends[0];
			legend.Mode = LegendMode.Disabled;
			NChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.DockMode = PanelDockMode.Fill;
			chart.DockMargins = new NMarginsL(2, 2, 10, 10);

			// create a point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.DataLabelStyle.Visible = false;
			point.MarkerStyle.Visible = false;
			point.Size = new NLength(5, NGraphicsUnit.Point);

			Random rand = new Random();
			for (int i = 0; i < 30; i++)
			{
				point.Values.Add(5 + rand.Next(90));
			}

			NAxis primaryY = chart.Axis(StandardAxis.PrimaryY);
			primaryY.View = new NRangeAxisView(new NRange1DD(0, 100), true, true);
			NLinearScaleConfigurator linearScale = primaryY.ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;

			UpdateScale();

			nChartControl1.Refresh();
		}

		private void UpdateScale()
		{
			if (nChartControl1 == null)
				return;

			NAxis primaryY = nChartControl1.Charts[0].Axis(StandardAxis.PrimaryY);
			NRange1DD hotZoneRange = new NRange1DD((double)HotZoneBeginUpDown.Value, 100);
			NRange1DD coldZoneRange = new NRange1DD(0, (double)ColdZoneEndUpDown.Value);

			NScaleSectionStyle hotZoneSection = new NScaleSectionStyle();
			hotZoneSection.Range = hotZoneRange;
			hotZoneSection.LabelTextStyle = new NTextStyle(new NFontStyle(), Color.Red);
			hotZoneSection.MajorTickStrokeStyle = new NStrokeStyle(1, Color.Red);
			hotZoneSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Red));
			hotZoneSection.SetShowAtWall(ChartWallType.Back, true);

			NScaleSectionStyle coldZoneSection = new NScaleSectionStyle();
			coldZoneSection.Range = coldZoneRange;
			coldZoneSection.LabelTextStyle = new NTextStyle(new NFontStyle(), Color.Blue);
			coldZoneSection.MajorTickStrokeStyle = new NStrokeStyle(1, Color.Blue);
			coldZoneSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Blue));
			coldZoneSection.SetShowAtWall(ChartWallType.Back, true);

			NStandardScaleConfigurator configurator = (NStandardScaleConfigurator)primaryY.ScaleConfigurator;

			configurator.Sections.Clear();
			configurator.Sections.Add(hotZoneSection);
			configurator.Sections.Add(coldZoneSection);

			// first use the scale configurator to output some definition
			primaryY.SynchronizeScaleWithConfigurator = true;
			primaryY.InvalidateScale();
			primaryY.UpdateScale();
			primaryY.SynchronizeScaleWithConfigurator = false;

			// manually program the scale
			NScaleLevel scaleLevel;
			NCustomScaleDecorator customScaleDecorator;
			NScaleRangeDecorationAnchor anchor;
			NScaleLevelSeparator separator;
			NValueScaleLabel label;
			NNumericDoubleStepRangeSampler rangeSampler;
			NClampedRangeSampler clampedRangeSampler;
			NScaleTickFactory tickFactory;
			NSampledScaleDecorator sampledDecorator;

			// create the hot zone

			// add a level separator
			scaleLevel = new NScaleLevel();
			customScaleDecorator = new NCustomScaleDecorator();

			anchor = new NScaleRangeDecorationAnchor(hotZoneRange);
			separator = new NScaleLevelSeparator(0, anchor, ScaleLevelShape.Line, null, new NStrokeStyle(1, Color.Red));
			customScaleDecorator.Decorations.Add(separator);

			// create a value scale label
			label = new NValueScaleLabel();
			label.Text = "Hot Zone";
			label.Anchor = new NRulerValueDecorationAnchor(HorzAlign.Right, new NLength(0));
			label.Style.TextStyle.FillStyle = new NColorFillStyle(Color.Red);
			label.Offset = new NLength(6, NGraphicsUnit.Point);
			label.Style.ContentAlignment = ContentAlignment.TopRight;
            label.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90, true);

			customScaleDecorator.Decorations.Add(label);
			scaleLevel.Decorators.Add(customScaleDecorator);

			// add a some ticks
			rangeSampler = new NNumericDoubleStepRangeSampler(new NCustomNumericStepProvider(5));
			rangeSampler.UseCustomOrigin = true;
			rangeSampler.CustomOrigin = 0;
			clampedRangeSampler = new NClampedRangeSampler(rangeSampler, hotZoneRange);

			tickFactory = new NScaleTickFactory(0, ScaleTickShape.Line,
									new NLength(0), 
									new NSizeL(new NLength(1), new NLength(5, NGraphicsUnit.Point)), 
									new NConstValueProvider(new NColorFillStyle(Color.Red)),
									new NConstValueProvider(new NStrokeStyle(1, Color.Red)),
									HorzAlign.Left);

			sampledDecorator = new NSampledScaleDecorator(clampedRangeSampler, tickFactory);
			scaleLevel.Decorators.Add(sampledDecorator);

			// create the cold zone
			// add a level separator
			customScaleDecorator = new NCustomScaleDecorator();

			anchor = new NScaleRangeDecorationAnchor(coldZoneRange);
			separator = new NScaleLevelSeparator(0, anchor, ScaleLevelShape.Line, null, new NStrokeStyle(1, Color.Blue));
			customScaleDecorator.Decorations.Add(separator);

			// create a value scale label
			label = new NValueScaleLabel();
			label.Text = "Cold Zone";
			label.Anchor = new NRulerValueDecorationAnchor(HorzAlign.Left, new NLength(0));
			label.Style.TextStyle.FillStyle = new NColorFillStyle(Color.Blue);
			label.Style.ContentAlignment = ContentAlignment.TopLeft;
			label.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90, true);
			label.Offset = new NLength(6, NGraphicsUnit.Point);

			customScaleDecorator.Decorations.Add(label);
			scaleLevel.Decorators.Add(customScaleDecorator);

			// add a some ticks
			rangeSampler = new NNumericDoubleStepRangeSampler(new NCustomNumericStepProvider(5));
			clampedRangeSampler = new NClampedRangeSampler(rangeSampler, coldZoneRange);
			tickFactory = new NScaleTickFactory(0,
												ScaleTickShape.Line,
												new NLength(0), 
												new NSizeL(new NLength(1), new NLength(5, NGraphicsUnit.Point)),
												new NConstValueProvider(new NColorFillStyle(Color.Red)),
												new NConstValueProvider(new NStrokeStyle(1, Color.Blue)), 
												HorzAlign.Left);

			sampledDecorator = new NSampledScaleDecorator(clampedRangeSampler, tickFactory);
			scaleLevel.Decorators.Add(sampledDecorator);

			primaryY.Scale.Levels.Add(scaleLevel);

			UpdateData(hotZoneRange, coldZoneRange);

			nChartControl1.Refresh();
		}

		private void UpdateData(NRange1DD hotZoneRange, NRange1DD coldZoneRange)
		{
			NPointSeries point = nChartControl1.Charts[0].Series[0] as NPointSeries;

			for (int i = 0; i < point.Values.Count; i++)
			{
				if (hotZoneRange.Contains((double)point.Values[i]))
				{
					point.FillStyles[i] = new NColorFillStyle(Color.Red);
				}
				else if (coldZoneRange.Contains((double)point.Values[i]))
				{
					point.FillStyles[i] = new NColorFillStyle(Color.Blue);
				}
				else
				{
					point.FillStyles[i] = new NColorFillStyle(Color.SpringGreen);
				}
			}
		}

		private void ColdZoneEndUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void HotZoneBeginUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}
	}
}
