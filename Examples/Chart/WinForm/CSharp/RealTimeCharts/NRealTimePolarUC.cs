using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRealTimePolarUC : NRealTimeExampleBaseUC
	{
		private NButton StopStartTimerButton;
		private NCheckBox UseHardwareAccelerationCheckBox;
		private IContainer components;
		private NPolarPointSeries m_PolarSeries;
		private NAxisConstLine[] m_RadarRay;

		public NRealTimePolarUC()
		{
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
			this.components = new System.ComponentModel.Container();
			this.StopStartTimerButton = new NButton();
			this.UseHardwareAccelerationCheckBox = new NCheckBox();
			this.SuspendLayout();

			// 
			// StopStartTimerButton
			// 
			this.StopStartTimerButton.Location = new System.Drawing.Point(14, 42);
			this.StopStartTimerButton.Name = "StopStartTimerButton";
			this.StopStartTimerButton.Size = new System.Drawing.Size(169, 23);
			this.StopStartTimerButton.TabIndex = 1;
			this.StopStartTimerButton.Text = "Stop Timer";
			this.StopStartTimerButton.UseVisualStyleBackColor = true;
			this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			// 
			// UseHardwareAccelerationCheckBox
			// 
			this.UseHardwareAccelerationCheckBox.AutoSize = true;
			this.UseHardwareAccelerationCheckBox.Location = new System.Drawing.Point(14, 19);
			this.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox";
			this.UseHardwareAccelerationCheckBox.Size = new System.Drawing.Size(156, 17);
			this.UseHardwareAccelerationCheckBox.TabIndex = 0;
			this.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration";
			this.UseHardwareAccelerationCheckBox.UseVisualStyleBackColor = true;
			this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			// 
			// NRealTimePolarUC
			// 
			this.Controls.Add(this.UseHardwareAccelerationCheckBox);
			this.Controls.Add(this.StopStartTimerButton);
			this.Name = "NRealTimePolarUC";
			this.Size = new System.Drawing.Size(192, 266);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Real Time Polar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NPolarChart chart = new NPolarChart();

			nChartControl1.Panels.Add(chart);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.InnerRadius = new NLength(10, NGraphicsUnit.Point);
			chart.Width = 70.0f;
			chart.Height = 70.0f;

			Color gridColor = Color.Green;

			NPolarAxis polarAngleAxis = (NPolarAxis)chart.Axis(StandardAxis.PolarAngle);
			NAngularScaleConfigurator angleScale = (NAngularScaleConfigurator)polarAngleAxis.ScaleConfigurator;
			angleScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			angleScale.MajorGridStyle.LineStyle.Color = gridColor;
			angleScale.OuterMajorTickStyle.LineStyle.Color = gridColor;
			angleScale.InnerMajorTickStyle.LineStyle.Color = gridColor;
			angleScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(gridColor);
			angleScale.RulerStyle.BorderStyle.Color = gridColor;
			angleScale.LabelFitModes = new LabelFitMode[0];

			m_RadarRay = new NAxisConstLine[10];

			for (int i = 0; i < m_RadarRay.Length; i++)
			{
				m_RadarRay[i] = new NAxisConstLine();
				m_RadarRay[i].StrokeStyle.Color = Color.FromArgb((byte)((1.0 - ((float)i / m_RadarRay.Length)) * 255), gridColor);
				polarAngleAxis.ConstLines.Add(m_RadarRay[i]);
			}

			// setup polar axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.AutoLabels = false;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			linearScale.MajorGridStyle.LineStyle.Color = gridColor;
			linearScale.InnerMajorTickStyle.Width = new NLength(0);
			linearScale.OuterMajorTickStyle.Width = new NLength(0);
			linearScale.RulerStyle.BorderStyle.Width = new NLength(0);
					
			// create three polar point series
			m_PolarSeries = new NPolarPointSeries();
			m_PolarSeries.Name = "Polar";
			m_PolarSeries.BorderStyle.Width = new NLength(0);
			m_PolarSeries.PointShape = PointShape.Bar;
			m_PolarSeries.Size = new NLength(4, NGraphicsUnit.Point);
			m_PolarSeries.Angles.ValueFormatter = new NNumericValueFormatter("0.00");
			m_PolarSeries.DataLabelStyle.Visible = false;
			m_PolarSeries.DataLabelStyle.Format = "<value> - <angle_in_degrees>";

			// change the storage type to array to increase performance
			m_PolarSeries.FillStyles.StorageType = IndexedStorageType.Array;

			Random rand = new Random();

			for (int i = 0; i < 360; i++)
			{
				m_PolarSeries.Values.Add(rand.Next(100));
				m_PolarSeries.Angles.Add(i);
				m_PolarSeries.FillStyles[i] = new NColorFillStyle(Color.FromArgb(0, Color.Green));
			}

			// add the series to the chart
			chart.Series.Add(m_PolarSeries);

			ConfigureStandardLayout(chart, title, null);

			UseHardwareAccelerationCheckBox.Checked = true;
			StartTimer();
		}

		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Polar";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
			base.OnTimerTick(sender, e);

			// decrease the alpha of all colors
			int count = m_PolarSeries.Values.Count;
			int speed = 5;
			NColorFillStyle colorFill;

			for (int i = 0; i < count; i++)
			{
				colorFill = (NColorFillStyle)m_PolarSeries.FillStyles[i];
				Color color = colorFill.Color;

				if (color.A > 0)
				{
					colorFill.Color = Color.FromArgb((byte)Math.Max(0, color.A - speed), color);
				}
			}

			for (int i = 0; i < speed; i++)
			{
				// first shift the value of all others
				for (int j = m_RadarRay.Length - 1; j > 0; j--)
				{
					m_RadarRay[j].Value = m_RadarRay[j - 1].Value;
				}

				m_RadarRay[0].Value++;

				if (m_RadarRay[0].Value >= 360)
				{
					m_RadarRay[0].Value = 0;
				}

				colorFill = (NColorFillStyle)m_PolarSeries.FillStyles[(int)m_RadarRay[0].Value];
				colorFill.Color = Color.FromArgb(255, colorFill.Color);
			}

			nChartControl1.Refresh();
		}

		private void UseHardwareAccelerationCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			nChartControl1.Settings.RenderSurface = UseHardwareAccelerationCheckBox.Checked ? RenderSurface.Window : RenderSurface.Bitmap;
		}

		private void StopStartTimerButton_Click(object sender, EventArgs e)
		{
			ToggleTimer();

			if (IsTimerRunning())
			{
				StopStartTimerButton.Text = "Stop Timer";
			}
			else
			{
				StopStartTimerButton.Text = "Start Timer";
			}
		}
	}
}
