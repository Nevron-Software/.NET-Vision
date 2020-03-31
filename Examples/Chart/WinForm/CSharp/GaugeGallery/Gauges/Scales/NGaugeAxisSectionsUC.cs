using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGaugeAxisSectionsUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BlueSectionBeginUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BlueSectionEndUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RedSectionBeginUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RedSectionEndUpDown;
		private System.Windows.Forms.Timer m_Timer;
		private Nevron.UI.WinForm.Controls.NButton StopStartTimerButton;
		private System.ComponentModel.IContainer components;
		private float m_FirstIndicatorAngle = 0;
		private float m_SecondIndicatorAngle = 0;

		public NGaugeAxisSectionsUC()
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

		public override void Initialize()
		{
            nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Axis Sections");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
            nChartControl1.Panels.Add(header);

			BlueSectionBeginUpDown.Value = 0;
			BlueSectionEndUpDown.Value = 20;
			RedSectionBeginUpDown.Value = 80;
			RedSectionEndUpDown.Value = 100;

			// init form controls
			InitLinearGauge();
			InitRadialGauge();

			m_Timer.Interval = 100;
			m_Timer.Start();	
		}

		private void InitSections(NGaugePanel gaugePanel)
		{
			NGaugeAxis axis = (NGaugeAxis)gaugePanel.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

            // init text style for regular labels
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);

            // init ticks
			scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			scale.MinTickDistance = new NLength(20);
			scale.MinorTickCount = 1;
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);

            // create sections
			NScaleSectionStyle blueSection = new NScaleSectionStyle();
			blueSection.Range = new NRange1DD(0, 20);
			blueSection.SetShowAtWall(ChartWallType.Back, true);
			blueSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Blue));
			blueSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Blue);
			blueSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkBlue);
			blueSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Blue, LinePattern.Dot, 0, 2);

			NTextStyle labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NColorFillStyle(Color.Blue);
            labelStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
			blueSection.LabelTextStyle = labelStyle;

			scale.Sections.Add(blueSection);

			NScaleSectionStyle redSection = new NScaleSectionStyle();
			redSection.Range = new NRange1DD(80, 100);

			redSection.SetShowAtWall(ChartWallType.Back, true);
			redSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Red));
			redSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Red);
			redSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkRed);
			redSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NColorFillStyle(Color.Red);
            labelStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
			redSection.LabelTextStyle = labelStyle;

			scale.Sections.Add(redSection);
		}

		private void InitLinearGauge()
		{
			NLinearGaugePanel linearGauge = new NLinearGaugePanel();
			linearGauge.ContentAlignment = ContentAlignment.TopRight;
			linearGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));
			linearGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(55, NGraphicsUnit.Point));
            linearGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);
            linearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            linearGauge.PaintEffect = new NGelEffectStyle();

			nChartControl1.Panels.Add(linearGauge);

			NMarkerValueIndicator indicator1 = new NMarkerValueIndicator();
			linearGauge.Indicators.Add(indicator1);

			InitSections(linearGauge);
		}

		private void InitRadialGauge()
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			radialGauge.ContentAlignment = ContentAlignment.BottomRight;
			radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(45, NRelativeUnit.ParentPercentage));
			radialGauge.InnerRadius = new NLength(10, NGraphicsUnit.Point);
            radialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);
            radialGauge.BoundsMode = BoundsMode.Fit;
            radialGauge.AutoBorder = RadialGaugeAutoBorder.RoundedOutline;

            NGlassEffectStyle glassEffect = new NGlassEffectStyle();
            glassEffect.LightDirection = 130;
            glassEffect.EdgeOffset = new NLength(0);
            glassEffect.EdgeDepth = new NLength(30, NRelativeUnit.ParentPercentage);
            radialGauge.PaintEffect = glassEffect;

			nChartControl1.Panels.Add(radialGauge);

			NNeedleValueIndicator indicator1 = new NNeedleValueIndicator();
			radialGauge.Indicators.Add(indicator1);
			radialGauge.SweepAngle = 180;

			InitSections(radialGauge);
		}

		private void UpdateSections()
		{
			for (int i = 0; i < nChartControl1.Panels.Count; i++)
			{
				NGaugePanel panel =  nChartControl1.Panels[i] as NGaugePanel;

				if (panel != null)
				{
					NGaugeAxis axis = (NGaugeAxis)panel.Axes[0];
					NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

					if (scale.Sections.Count == 2)
					{
						NScaleSectionStyle blueSection = (NScaleSectionStyle)scale.Sections[0];
						blueSection.Range = new NRange1DD((double)BlueSectionBeginUpDown.Value, (double)BlueSectionEndUpDown.Value);

						NScaleSectionStyle redSection = (NScaleSectionStyle)scale.Sections[1];
						redSection.Range = new NRange1DD((double)RedSectionBeginUpDown.Value, (double)RedSectionEndUpDown.Value);
					}
				}
			}

			nChartControl1.Refresh();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.BlueSectionEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.RedSectionEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.RedSectionBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.BlueSectionBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.m_Timer = new System.Windows.Forms.Timer(this.components);
			this.StopStartTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.BlueSectionEndUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RedSectionEndUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RedSectionBeginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BlueSectionBeginUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Blue Section:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Begin:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "End:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 156);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "End:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 132);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Begin:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 3;
			this.label6.Text = "Red Section:";
			// 
			// BlueSectionEndUpDown
			// 
			this.BlueSectionEndUpDown.Location = new System.Drawing.Point(80, 64);
			this.BlueSectionEndUpDown.Name = "BlueSectionEndUpDown";
			this.BlueSectionEndUpDown.Size = new System.Drawing.Size(80, 20);
			this.BlueSectionEndUpDown.TabIndex = 7;
			this.BlueSectionEndUpDown.ValueChanged += new System.EventHandler(this.BlueSectionEndUpDown_ValueChanged);
			// 
			// RedSectionEndUpDown
			// 
			this.RedSectionEndUpDown.Location = new System.Drawing.Point(80, 152);
			this.RedSectionEndUpDown.Name = "RedSectionEndUpDown";
			this.RedSectionEndUpDown.Size = new System.Drawing.Size(80, 20);
			this.RedSectionEndUpDown.TabIndex = 9;
			this.RedSectionEndUpDown.ValueChanged += new System.EventHandler(this.RedSectionEndUpDown_ValueChanged);
			// 
			// RedSectionBeginUpDown
			// 
			this.RedSectionBeginUpDown.Location = new System.Drawing.Point(80, 128);
			this.RedSectionBeginUpDown.Name = "RedSectionBeginUpDown";
			this.RedSectionBeginUpDown.Size = new System.Drawing.Size(80, 20);
			this.RedSectionBeginUpDown.TabIndex = 8;
			this.RedSectionBeginUpDown.ValueChanged += new System.EventHandler(this.RedSectionBeginUpDown_ValueChanged);
			// 
			// BlueSectionBeginUpDown
			// 
			this.BlueSectionBeginUpDown.Location = new System.Drawing.Point(80, 40);
			this.BlueSectionBeginUpDown.Name = "BlueSectionBeginUpDown";
			this.BlueSectionBeginUpDown.Size = new System.Drawing.Size(80, 20);
			this.BlueSectionBeginUpDown.TabIndex = 6;
			this.BlueSectionBeginUpDown.ValueChanged += new System.EventHandler(this.BlueSectionBeginUpDown_ValueChanged);
			// 
			// timer1
			// 
			this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// StopStartTimerButton
			// 
			this.StopStartTimerButton.Location = new System.Drawing.Point(16, 192);
			this.StopStartTimerButton.Name = "StopStartTimerButton";
			this.StopStartTimerButton.Size = new System.Drawing.Size(144, 23);
			this.StopStartTimerButton.TabIndex = 10;
			this.StopStartTimerButton.Text = "Stop Timer";
			this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			// 
			// NGaugeAxisSectionsUC
			// 
			this.Controls.Add(this.StopStartTimerButton);
			this.Controls.Add(this.RedSectionEndUpDown);
			this.Controls.Add(this.RedSectionBeginUpDown);
			this.Controls.Add(this.BlueSectionEndUpDown);
			this.Controls.Add(this.BlueSectionBeginUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NGaugeAxisSectionsUC";
			this.Size = new System.Drawing.Size(176, 248);
			((System.ComponentModel.ISupportInitialize)(this.BlueSectionEndUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RedSectionEndUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RedSectionBeginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BlueSectionBeginUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void BlueSectionBeginUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		private void BlueSectionEndUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		private void RedSectionBeginUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		private void RedSectionEndUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (nChartControl1.Panels.Count < 3)
				return;

			// update linear gauge
			NGaugePanel panel =  nChartControl1.Panels[1] as NGaugePanel;
			if (panel != null)
			{
				NValueIndicator valueIndicator = (NValueIndicator)panel.Indicators[0];
				NStandardScaleConfigurator scale = (NStandardScaleConfigurator)((NGaugeAxis)panel.Axes[0]).ScaleConfigurator;
				NScaleSectionStyle blueSection = (NScaleSectionStyle)scale.Sections[0];
				NScaleSectionStyle redSection = (NScaleSectionStyle)scale.Sections[1];

				m_FirstIndicatorAngle += 0.02f;
				valueIndicator.Value = 50 - Math.Cos(m_FirstIndicatorAngle) * 50;

				if (blueSection.Range.Contains(valueIndicator.Value))
				{
					valueIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Blue);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.Blue);
				}
				else if (redSection.Range.Contains(valueIndicator.Value))
				{
					valueIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.Red);
				}
				else
				{
					valueIndicator.Shape.FillStyle = new NColorFillStyle(Color.LightGreen);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.DarkGreen);
				}
			}

			// update radial gauge
			panel =  nChartControl1.Panels[2] as NGaugePanel;
			if (panel != null)
			{
				NStandardScaleConfigurator scale = (NStandardScaleConfigurator)((NGaugeAxis)panel.Axes[0]).ScaleConfigurator;
				NValueIndicator valueIndicator = (NValueIndicator)panel.Indicators[0];
				NScaleSectionStyle blueSection = (NScaleSectionStyle)scale.Sections[0];
				NScaleSectionStyle redSection = (NScaleSectionStyle)scale.Sections[1];

				m_SecondIndicatorAngle += 0.02f;
				valueIndicator.Value = 50 - Math.Cos(m_SecondIndicatorAngle) * 50;

				if (blueSection.Range.Contains(valueIndicator.Value))
				{
					valueIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Blue);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.DarkBlue);
				}
				else if (redSection.Range.Contains(valueIndicator.Value))
				{
					valueIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.DarkRed);
				}
				else
				{
					valueIndicator.Shape.FillStyle = new NColorFillStyle(Color.LightGreen);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.DarkGreen);
				}

                valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.White);
			}

			nChartControl1.Refresh();
		}


		private void StopStartTimerButton_Click(object sender, System.EventArgs e)
		{
			if (m_Timer.Enabled)
			{
				m_Timer.Enabled = false;
				StopStartTimerButton.Text = "Start Timer";
			}
			else
			{
				m_Timer.Enabled = true;
				StopStartTimerButton.Text = "Stop Timer";
			}
		}
	}
}
