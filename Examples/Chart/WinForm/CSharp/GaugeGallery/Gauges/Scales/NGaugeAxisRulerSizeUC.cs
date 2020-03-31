using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGaugeAxisRulerSizeUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		NRadialGaugePanel m_RadialGauge;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox RedAxisTextBox;
		private Nevron.UI.WinForm.Controls.NHScrollBar RedAxisPercentScrollBar;

		public NGaugeAxisRulerSizeUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

		}

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Axis Ruler Size");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
            nChartControl1.Panels.Add(header);

			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
            m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			m_RadialGauge.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
            m_RadialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);
            NGelEffectStyle gelEffect = new NGelEffectStyle(PaintEffectShape.Ellipse);
            gelEffect.Margins = new NMarginsL(new NLength(0), new NLength(0), new NLength(0), new NLength(50, NRelativeUnit.ParentPercentage));

            m_RadialGauge.PaintEffect = gelEffect;
            nChartControl1.Panels.Add(m_RadialGauge);

			m_RadialGauge.Axes.Clear();

            // create the first axis
			NGaugeAxis axis1 = new NGaugeAxis();
			axis1.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, 0, 70);
			NStandardScaleConfigurator scale1 = (NStandardScaleConfigurator)axis1.ScaleConfigurator;
			scale1.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale1.MinorTickCount = 3;
			scale1.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
            scale1.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
            scale1.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
            scale1.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale1.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

			m_RadialGauge.Axes.Add(axis1);

            // create the second axis
			NGaugeAxis axis2 = new NGaugeAxis();
			axis2.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, false, 75, 95);
			NStandardScaleConfigurator scale2 = (NStandardScaleConfigurator)axis2.ScaleConfigurator;
            scale2.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale2.MinorTickCount = 3;
            scale2.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
            scale2.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Blue);
            scale2.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
            scale2.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale2.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			
			m_RadialGauge.Axes.Add(axis2);

            // add indicators
			NRangeIndicator rangeIndicator = new NRangeIndicator();
			rangeIndicator.Value = 50;
			rangeIndicator.FillStyle = new NGradientFillStyle(Color.Orange, Color.Red);
			rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.OffsetFromScale = new NLength(3);
            rangeIndicator.BeginWidth = new NLength(6);
            rangeIndicator.EndWidth = new NLength(12);
			m_RadialGauge.Indicators.Add(rangeIndicator);

			NNeedleValueIndicator needleValueIndicator1 = new NNeedleValueIndicator();
			needleValueIndicator1.Value = 79;
			needleValueIndicator1.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.White, Color.Red);
			needleValueIndicator1.Shape.StrokeStyle.Color = Color.Red;
			needleValueIndicator1.Axis = axis1;
			needleValueIndicator1.OffsetFromScale = new NLength(2);
			m_RadialGauge.Indicators.Add(needleValueIndicator1);
			m_RadialGauge.SweepAngle = 360;

			NNeedleValueIndicator needleValueIndicator2 = new NNeedleValueIndicator();
			needleValueIndicator2.Value = 79;
			needleValueIndicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.White, Color.Blue);
			needleValueIndicator2.Shape.StrokeStyle.Color = Color.Blue;
			needleValueIndicator2.Axis = axis2;
			needleValueIndicator2.OffsetFromScale = new NLength(2);
			m_RadialGauge.Indicators.Add(needleValueIndicator2);

            RedAxisPercentScrollBar.Value = 70;
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
			this.RedAxisPercentScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.RedAxisTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// RedAxisPercentScrollBar
			// 
			this.RedAxisPercentScrollBar.Location = new System.Drawing.Point(3, 38);
			this.RedAxisPercentScrollBar.Maximum = 80;
			this.RedAxisPercentScrollBar.Minimum = 10;
			this.RedAxisPercentScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.RedAxisPercentScrollBar.Name = "RedAxisPercentScrollBar";
			this.RedAxisPercentScrollBar.Size = new System.Drawing.Size(123, 16);
			this.RedAxisPercentScrollBar.TabIndex = 0;
			this.RedAxisPercentScrollBar.Value = 10;
			this.RedAxisPercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RedAxisPercentScrollBar_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Red Axis Percent:";
			// 
			// RedAxisTextBox
			// 
			this.RedAxisTextBox.Enabled = false;
			this.RedAxisTextBox.Location = new System.Drawing.Point(129, 36);
			this.RedAxisTextBox.Name = "RedAxisTextBox";
			this.RedAxisTextBox.Size = new System.Drawing.Size(48, 18);
			this.RedAxisTextBox.TabIndex = 2;
			// 
			// NGaugeAxisRulerSizeUC
			// 
			this.Controls.Add(this.RedAxisTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RedAxisPercentScrollBar);
			this.Name = "NGaugeAxisRulerSizeUC";
			this.Size = new System.Drawing.Size(180, 216);
			this.ResumeLayout(false);

		}
		#endregion

		private void RedAxisPercentScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NGaugeAxis axis1 = (NGaugeAxis)m_RadialGauge.Axes[0];
			NGaugeAxis axis2 = (NGaugeAxis)m_RadialGauge.Axes[1];

			axis1.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, 0, RedAxisPercentScrollBar.Value - 5);
			axis2.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, false, RedAxisPercentScrollBar.Value, 95);
			RedAxisTextBox.Text = RedAxisPercentScrollBar.Value.ToString();

			nChartControl1.Refresh();				
		}
	}
}
