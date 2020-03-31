using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGaugeCustomLabelsUC : NExampleBaseUC
	{
		private System.Timers.Timer m_Timer;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		NNeedleValueIndicator m_SecondsArrow;
		NNeedleValueIndicator m_MinituesArrow;
		NNeedleValueIndicator m_HoursArrow;

		public NGaugeCustomLabelsUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Custom Labels");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
            nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
            radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(12, NRelativeUnit.ParentPercentage));
            radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);

            NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
            advGradient.BackgroundColor = Color.Black;
            advGradient.Points.Add(new NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle));
            radialGauge.BackgroundFillStyle = advGradient;

			radialGauge.SweepAngle = 360;
			radialGauge.BeginAngle = -90;
			nChartControl1.Panels.Add(radialGauge);

			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 60);
			axis.Anchor.RulerOrientation = RulerOrientation.Right;
			axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);
			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(20, Color.LightGray)), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.Interlaced = true;
			scale.StripStyles.Add(stripStyle);
			scale.MinorTickCount = 4;
			scale.MajorTickMode = MajorTickMode.CustomStep;
			scale.CustomStep = 5.0f;
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Watch);
			scale.OuterMajorTickStyle.FillStyle = new NGradientFillStyle(Color.White, Color.Beige);
			scale.OuterMajorTickStyle.LineStyle = new NStrokeStyle(Color.DarkGray);
			scale.OuterMajorTickStyle.Length = new NLength(14);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Silver));
			scale.RulerStyle.BorderStyle = new NStrokeStyle(Color.Beige);

			axis.UpdateScale();
			axis.SynchronizeScaleWithConfigurator = false;
			
			NTextStyle textStyle1 = new NTextStyle();
			textStyle1.FillStyle = new NColorFillStyle(Color.White);
			textStyle1.BorderStyle = new NStrokeStyle(1, Color.Beige);
			textStyle1.FontStyle.Style = FontStyle.Bold;
			textStyle1.FontStyle.EmSize = new NLength(22);
			NScaleLabelAngle angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

			NTextStyle textStyle2 = new NTextStyle();
			textStyle2.FillStyle = new NColorFillStyle(Color.White);
			textStyle2.BorderStyle = new NStrokeStyle(1, Color.Beige);
			textStyle2.FontStyle.Style = FontStyle.Bold;
			textStyle2.FontStyle.EmSize = new NLength(12);

			NCustomScaleDecorator customDecorator = new NCustomScaleDecorator();

			NValueScaleLabelStyle style1 = new NValueScaleLabelStyle(textStyle1, ContentAlignment.MiddleCenter, angle, new NLength(0));
			NValueScaleLabelStyle style2 = new NValueScaleLabelStyle(textStyle2, ContentAlignment.MiddleCenter, angle, new NLength(0));

			for (int i = 12; i > 0; i--)
			{
				string text = NSystem.IntToRoman(i);
				NValueScaleLabel hourLabel;

				if (i % 3 == 0)
				{
					hourLabel = new NValueScaleLabel(new NScaleValueDecorationAnchor(i * 5), text, (NValueScaleLabelStyle)style1.Clone());
				}
				else
				{
					hourLabel = new NValueScaleLabel(new NScaleValueDecorationAnchor(i * 5), text, (NValueScaleLabelStyle)style2.Clone());
				}

				customDecorator.Decorations.Add(hourLabel);
			}

			NScaleLevel textLevel = (NScaleLevel)axis.Scale.Levels[1];
			textLevel.Decorators.Clear();
			textLevel.Decorators.Add(customDecorator);

			m_HoursArrow = new NNeedleValueIndicator();
			m_HoursArrow.Value = 79;
			m_HoursArrow.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_HoursArrow.Shape.StrokeStyle.Color = Color.Red;
			m_HoursArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd;
			m_HoursArrow.OffsetFromScale = new NLength(30);
			m_HoursArrow.Width = new NLength(8);
			radialGauge.Indicators.Add(m_HoursArrow);

			m_MinituesArrow = new NNeedleValueIndicator();
			m_MinituesArrow.Value = 79;
			m_MinituesArrow.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_MinituesArrow.Shape.StrokeStyle.Color = Color.Red;
			m_MinituesArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd;
			m_MinituesArrow.OffsetFromScale = new NLength(30);
			m_MinituesArrow.Width = new NLength(5);
			radialGauge.Indicators.Add(m_MinituesArrow);

			m_SecondsArrow = new NNeedleValueIndicator();
			m_SecondsArrow.Value = 79;
			m_SecondsArrow.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_MinituesArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd;
			m_SecondsArrow.Shape.StrokeStyle.Color = Color.Red;
			m_SecondsArrow.OffsetFromScale = new NLength(10);
			m_SecondsArrow.Width = new NLength(1);
			radialGauge.Indicators.Add(m_SecondsArrow);

			nChartControl1.AutoRefresh = true;
			SynchronizeWithTime();

			m_Timer.Interval = 1000;
			m_Timer.Enabled = true;
		}

		private void SynchronizeWithTime()
		{
			DateTime now = DateTime.Now;
			m_SecondsArrow.Value = now.Second;
			m_MinituesArrow.Value = now.Minute;
			m_HoursArrow.Value = now.Hour * 5.0f + now.Minute / 12.0f;
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
			this.m_Timer = new System.Timers.Timer();
			((System.ComponentModel.ISupportInitialize)(this.m_Timer)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.m_Timer.Enabled = true;
			this.m_Timer.SynchronizingObject = this;
			this.m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
			// 
			// NGaugeCustomLabelsUC
			// 
			this.Name = "NGaugeCustomLabelsUC";
			this.Size = new System.Drawing.Size(180, 150);
			((System.ComponentModel.ISupportInitialize)(this.m_Timer)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			SynchronizeWithTime();
		}
	}
}
