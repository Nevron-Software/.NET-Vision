﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using System.Diagnostics;
using System.Windows.Threading;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NStateIndicatorsUC.xaml
	/// </summary>
	public partial class NStateIndicatorsUC : NExampleBaseUC
	{
		int m_Gear = 1;
		double m_Speed = 0;
		double m_Rotation = 0;
		NNeedleValueIndicator m_SpeedIndicator;
		NStateIndicatorPanel m_SpeedStateIndicator;

		NNeedleValueIndicator m_RotationIndicator;
		NStateIndicatorPanel m_RotationStateIndicator;

		private DispatcherTimer m_Timer;

		public NStateIndicatorsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "State Indicators";
			}
		}

		public override string Description
		{
			get
			{
				return "The example demonstrates how to create state indicators anchored to radial gauges. In this example the speed and rotation indicators are linked with a speed and range state indicators showing whether the current values for speed or rotation are in range. " +
					"When you speed up the car (by moving the scrollbar to the bottom) - both state indicators will first turn orange when you're near the red zone on the respective axis and then red when the value enters it.";
			}
		}

		public override void Create()
		{			
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Car Dashboard<br/><font size = '9pt' style ='normal'>Demonstrates how to create state indicators anchored to gauges</font>");
			header.ContentAlignment = ContentAlignment.MiddleCenter;
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18);
			header.TextStyle.FillStyle = new NGradientFillStyle(Color.Black, Color.White);
			header.TextStyle.BorderStyle = new NStrokeStyle(Color.Gray);
			header.TextStyle.FontStyle.EmSize = new NLength(22);
			header.TextStyle.FontStyle.Style = System.Drawing.FontStyle.Bold;
			header.BoundsMode = BoundsMode.None;
			header.UseAutomaticSize = false;
			header.Size = new NSizeL(
				new NLength(60, NRelativeUnit.ParentPercentage),
				new NLength(10, NRelativeUnit.ParentPercentage));
			header.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(6, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);
			m_Timer = new DispatcherTimer();
			m_Timer.Tick += m_Timer_Tick;
			//m_Timer.Start();

			CreateSpeedGauge();
			CreateRPMGauge();		

			NRangeIndicatorState stateIndicator = new NRangeIndicatorState();

			m_Timer.Interval = new TimeSpan(50);
			m_Timer.IsEnabled = true;
		}

		void m_Timer_Tick(object sender, EventArgs e)
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

			if (m_Speed > 140)
			{
				Debug.WriteLine("Intercept");
			}
			if (m_Speed > 0)
			{
				m_SpeedStateIndicator.Value = m_Speed;
				Debug.Assert(m_SpeedStateIndicator.Value != 0);
			}

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

			// update gear
			int gearIndex = m_Gear - 1;

			// update speed
			NRange1DD orangeZone = new NRange1DD(180, 220);
			NRange1DD redZone = new NRange1DD(220, 300);

			m_Rotation = GetRotationFromSpeed();
			m_RotationIndicator.Value = m_Rotation;
			m_RotationStateIndicator.Value = m_Rotation;
			nChartControl1.Refresh();
		}

		public override void Destroy()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
				m_Timer.Tick -= m_Timer_Tick;
				m_Timer = null;
			}

			base.Destroy();		
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
			label.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, System.Drawing.FontStyle.Italic);
			label.TextStyle.FontStyle.Style = System.Drawing.FontStyle.Italic;
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

			// and a state indicator to the speed
			NGaugeModelAnchor modelAnchor = new NGaugeModelAnchor();
			modelAnchor.ModelPoint = new NPointL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(60));
			modelAnchor.Gauge = radialGauge;

			NAnchorPanel anchorPanel = new NAnchorPanel();
			anchorPanel.Anchor = modelAnchor;

			CreateSpeedStateIndicator();
			anchorPanel.ChildPanels.Add(m_SpeedStateIndicator);

			radialGauge.ChildPanels.Add(anchorPanel);

			radialGauge.BeginAngle = -240;
			radialGauge.SweepAngle = 300;
		}

		private void CreateSpeedStateIndicator()
		{
			m_SpeedStateIndicator = new NStateIndicatorPanel();
			m_SpeedStateIndicator.UseAutomaticSize = true;
			m_SpeedStateIndicator.DefaultState.ShapeSize = new NSizeL(10, 10);

			NRangeIndicatorState orangeState = new NRangeIndicatorState();
			orangeState.Shape.FillStyle = new NColorFillStyle(Color.Orange);
			orangeState.ShapeSize = new NSizeL(10, 10);
			orangeState.Range = new NRange1DD(140, 220);
			m_SpeedStateIndicator.States.Add(orangeState);

			NRangeIndicatorState redState = new NRangeIndicatorState();
			redState.Shape.FillStyle = new NColorFillStyle(Color.Red);
			redState.Range = new NRange1DD(220, 300);
			redState.ShapeSize = new NSizeL(10, 10);
			m_SpeedStateIndicator.States.Add(redState);
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
			label.TextStyle.FontStyle.Style = System.Drawing.FontStyle.Italic;
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

			// and a state indicator to the speed
			NGaugeModelAnchor modelAnchor = new NGaugeModelAnchor();
			modelAnchor.ModelPoint = new NPointL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(60));
			modelAnchor.Gauge = radialGauge;

			NAnchorPanel anchorPanel = new NAnchorPanel();
			anchorPanel.Anchor = modelAnchor;

			CreateRotationStateIndicator();
			anchorPanel.ChildPanels.Add(m_RotationStateIndicator);

			radialGauge.ChildPanels.Add(anchorPanel);
		}

		private void CreateRotationStateIndicator()
		{
			m_RotationStateIndicator = new NStateIndicatorPanel();
			m_RotationStateIndicator.UseAutomaticSize = true;
			m_RotationStateIndicator.DefaultState.ShapeSize = new NSizeL(10, 10);

			NRangeIndicatorState orangeState = new NRangeIndicatorState();
			orangeState.Shape.FillStyle = new NColorFillStyle(Color.Orange);
			orangeState.ShapeSize = new NSizeL(10, 10);
			orangeState.Range = new NRange1DD(5000, 6000);
			m_RotationStateIndicator.States.Add(orangeState);

			NRangeIndicatorState redState = new NRangeIndicatorState();
			redState.Shape.FillStyle = new NColorFillStyle(Color.Red);
			redState.Range = new NRange1DD(6000, 8000);
			redState.ShapeSize = new NSizeL(10, 10);
			m_RotationStateIndicator.States.Add(redState);
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

		private void ConfigureScale(NStandardScaleConfigurator scale, NRange1DD redRange)
		{
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 11, System.Drawing.FontStyle.Bold);
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
			labelStyle.FontStyle = new NFontStyle("Arial", 11, System.Drawing.FontStyle.Bold);
			scaleSection.LabelTextStyle = labelStyle;

			scale.Sections.Add(scaleSection);
		}

		private NRangeIndicator CreateRangeIndicator(double minValue)
		{
			NRangeIndicator rangeIndicator = new NRangeIndicator();

			rangeIndicator.Value = minValue;
			rangeIndicator.OriginMode = OriginMode.ScaleMax;
			rangeIndicator.FillStyle = new NColorFillStyle(Color.DarkRed);
			rangeIndicator.StrokeStyle.Width = new NLength(0);
			rangeIndicator.BeginWidth = new NLength(-2);
			rangeIndicator.EndWidth = new NLength(-10);

			return rangeIndicator;
		}

		private double GetSpeedFromRotation()
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

		private double GetRotationFromSpeed()
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
	}
}
