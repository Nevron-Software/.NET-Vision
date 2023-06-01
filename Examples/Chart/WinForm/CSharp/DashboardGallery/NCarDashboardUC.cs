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
	public class NCarDashboardUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer m_Timer;
		private System.ComponentModel.IContainer components;
		private Nevron.UI.WinForm.Controls.NVScrollBar GasScrollBar;

		private int m_Gear = 1;
		private float m_Speed = 0;
		private float m_Rotation = 0;
		private NNeedleValueIndicator m_SpeedIndicator;
		private NNeedleValueIndicator m_RotationIndicator;

		public NCarDashboardUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

				if (m_Timer != null)
				{
					m_Timer.Stop();
					m_Timer.Tick -= new EventHandler(timer1_Tick);
					m_Timer.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Car Dashboard");
			header.ContentAlignment = ContentAlignment.MiddleCenter;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.TextStyle.FillStyle = new NGradientFillStyle(Color.Black, Color.White);
			header.TextStyle.BorderStyle = new NStrokeStyle(Color.Gray);
			header.TextStyle.FontStyle.EmSize = new NLength(22);
			header.TextStyle.FontStyle.Style = FontStyle.Bold;
			header.BoundsMode = BoundsMode.None;
			header.UseAutomaticSize = false;
			header.Size = new NSizeL(
				new NLength(60, NRelativeUnit.ParentPercentage),
				new NLength(10, NRelativeUnit.ParentPercentage));
			header.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(6, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			CreateSpeedGauge();
			CreateRPMGauge();

			nChartControl1.AutoRefresh = true;

			m_Timer.Interval = 50;
			m_Timer.Start();
		}

		private void CreateSpeedGauge()
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.BackgroundFillStyle = CreateAdvancedGradient();
			radialGauge.ContentAlignment = ContentAlignment.BottomRight;
            radialGauge.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            radialGauge.Size = new NSizeL(new NLength(45, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
		
			NLabel label = new NLabel("km/h");
			label.ContentAlignment = ContentAlignment.BottomCenter;
            label.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic); 
			label.TextStyle.FontStyle.Style = FontStyle.Italic;
			label.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			label.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			label.BoundsMode = BoundsMode.Fit;
			label.UseAutomaticSize = false;
			label.Size = new NSizeL(
				new NLength(60, NRelativeUnit.ParentPercentage),
				new NLength(7, NRelativeUnit.ParentPercentage));
			label.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(55, NRelativeUnit.ParentPercentage));
			label.Cache = true;

            radialGauge.ChildPanels.Add(label);
            nChartControl1.Panels.Add(radialGauge);
		
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 250);

			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            ConfigureScale(scale, new NRange1DD(220, 260));
            radialGauge.Indicators.Add(CreateRangeIndicator(220));

			NMarkerValueIndicator indicator3 = new NMarkerValueIndicator();
			indicator3.Value = 90;
			radialGauge.Indicators.Add(indicator3);

			m_SpeedIndicator = new NNeedleValueIndicator();
			m_SpeedIndicator.Value = 0;
			m_SpeedIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_SpeedIndicator.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(m_SpeedIndicator);

			radialGauge.BeginAngle = -240;
			radialGauge.SweepAngle = 300;
		}

        private NFillStyle CreateAdvancedGradient()
        {
            NAdvancedGradientFillStyle agfs = new NAdvancedGradientFillStyle();

            agfs.BackgroundColor = Color.FromArgb(234, 234, 234);

            NAdvancedGradientPoint point1 = new NAdvancedGradientPoint();
            point1.X = 50;
            point1.Y = 50;
            point1.Color = Color.FromArgb(51, 51, 51);
            point1.Intensity = 70;
            agfs.Points.Add(point1);

            NAdvancedGradientPoint point2 = new NAdvancedGradientPoint();
            point2.X = 50;
            point2.Y = 50;
            point2.Color = Color.FromArgb(41, 41, 41);
            point2.Intensity = 50;
            agfs.Points.Add(point2);

            return agfs;
        }

		private void CreateRPMGauge()
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.BackgroundFillStyle = CreateAdvancedGradient();
            radialGauge.ContentAlignment = ContentAlignment.BottomRight;
            radialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            radialGauge.Size = new NSizeL(new NLength(45, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

			NLabel label = new NLabel("RPM");
			label.ContentAlignment = ContentAlignment.BottomCenter;
			label.TextStyle.FontStyle.Name = "Palatino Linotype";
			label.TextStyle.FontStyle.Style = FontStyle.Italic;
			label.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			label.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			label.BoundsMode = BoundsMode.Fit;
			label.UseAutomaticSize = false;
			label.Size = new NSizeL(
				new NLength(60, NRelativeUnit.ParentPercentage),
				new NLength(7, NRelativeUnit.ParentPercentage));
			label.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(55, NRelativeUnit.ParentPercentage));
			label.Cache = true;

            radialGauge.ChildPanels.Add(label);
            nChartControl1.Panels.Add(radialGauge);

			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 7000);

			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            ConfigureScale(scale, new NRange1DD(6000, 7000));
			radialGauge.Indicators.Add(CreateRangeIndicator(6000));

			m_RotationIndicator = new NNeedleValueIndicator();
			m_RotationIndicator.Value = 79;
			m_RotationIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_RotationIndicator.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(m_RotationIndicator);
			
			radialGauge.BeginAngle = -240;
			radialGauge.SweepAngle = 300;
		}

		private void ConfigureScale(NStandardScaleConfigurator scale, NRange1DD redRange)
        {
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 11, FontStyle.Bold);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
            scale.MinorTickCount = 1;
            scale.RulerStyle.BorderStyle.Width = new NLength(0);
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.SlateGray));

            NScaleSectionStyle scaleSection = new NScaleSectionStyle();
            scaleSection.Range = redRange;
            scaleSection.MajorTickFillStyle = new NColorFillStyle(Color.Red);
            scaleSection.MinorTickFillStyle = new NColorFillStyle(Color.Red);

            NTextStyle labelStyle = new NTextStyle();
            labelStyle.FillStyle = new NGradientFillStyle(Color.Red, Color.DarkRed);
            labelStyle.FontStyle = new NFontStyle("Arial", 11, FontStyle.Bold);
            scaleSection.LabelTextStyle = labelStyle;

            scale.Sections.Add(scaleSection);
        }

        private NRangeIndicator CreateRangeIndicator(double minValue)
        {
            NRangeIndicator rangeIndicator = new NRangeIndicator();

            rangeIndicator.Value = minValue;
            rangeIndicator.OriginMode = OriginMode.ScaleMax;
            rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
            rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.BeginWidth = new NLength(2);
            rangeIndicator.EndWidth = new NLength(10);
            
            return rangeIndicator;
        }

		private float GetSpeedFromRotation()
		{
			switch (m_Gear)
			{
				case 1:
					return m_Rotation * 0.005f;
				case 2:
					return m_Rotation * 0.01f;
				case 3:
					return m_Rotation * 0.015f;
				case 4:
					return m_Rotation * 0.02f;
				case 5:
					return m_Rotation * 0.034f;
			}

			return 0;
		}

		private float GetRotationFromSpeed()
		{
			switch (m_Gear)
			{
				case 1:
					return m_Speed / 0.005f;
				case 2:
					return m_Speed / 0.01f;
				case 3:
					return m_Speed / 0.015f;
				case 4:
					return m_Speed / 0.02f;
				case 5:
					return m_Speed / 0.034f;
			}

			return 0;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			m_Rotation += GasScrollBar.Value;

			if (m_Rotation < 0)
			{
				m_Rotation = 0;
			}
			else if (m_Rotation > 7000)
			{
				m_Rotation = 7000;
			}

			m_Speed = GetSpeedFromRotation();
			m_SpeedIndicator.Value = m_Speed;

			// change gear
			if (m_Rotation < 1000)
			{
				m_Gear--;
			}
			else if (m_Rotation > 3500)
			{
				m_Gear++;
			}

			if (m_Gear < 1)
				m_Gear = 1;
			if (m_Gear > 5)
				m_Gear = 5;

			m_Rotation = GetRotationFromSpeed();
			m_RotationIndicator.Value = m_Rotation;
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.GasScrollBar = new Nevron.UI.WinForm.Controls.NVScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_Timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// GasScrollBar
			// 
			this.GasScrollBar.Location = new System.Drawing.Point(24, 16);
			this.GasScrollBar.Maximum = 200;
			this.GasScrollBar.Minimum = -200;
			this.GasScrollBar.MinimumSize = new System.Drawing.Size(16, 32);
			this.GasScrollBar.Name = "GasScrollBar";
			this.GasScrollBar.Size = new System.Drawing.Size(16, 208);
			this.GasScrollBar.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Speed Up";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Slow Down";
			// 
			// timer1
			// 
			this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// NCarDashboardUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GasScrollBar);
			this.Name = "NCarDashboardUC";
			this.Size = new System.Drawing.Size(180, 405);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
