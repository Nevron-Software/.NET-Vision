using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRealTimePointUC : NRealTimeExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox UseHardwareAccelerationCheckBox;
		private Nevron.UI.WinForm.Controls.NButton StopStartTimerButton;
		private Nevron.UI.WinForm.Controls.NButton ResetButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.IContainer components;
		private UI.WinForm.Controls.NComboBox DataPointsPerSphereComboBox;
		private int m_Counter;

		/// <summary>
		/// Helper class that represents a random sphere
		/// </summary>
		[Serializable]
		class NSphereInfo
		{
			/// <summary>
			/// Default constructor
			/// </summary>
			public NSphereInfo()
			{
			}
			/// <summary>
			/// Initializer constructor
			/// </summary>
			/// <param name="factor"></param>
			public NSphereInfo(int factor)
			{
				Random rand = new System.Random();

				m_CenterX = rand.NextDouble() * 200.0 - 100.0;
				m_CenterY = rand.NextDouble() * 200.0 - 100.0;
				m_CenterZ = rand.NextDouble() * 200.0 - 100.0;

				m_BeginColor = Color.FromArgb((byte)(rand.NextDouble() * 255), (byte)(rand.NextDouble() * 255), (byte)(rand.NextDouble () * 255));
				m_EndColor = Color.FromArgb((byte)(rand.NextDouble() * 255), (byte)(rand.NextDouble() * 255), (byte)(rand.NextDouble() * 255));

				m_Radius = 1;
				m_RadiusIncrement = rand.NextDouble() * 3.0 + 0.1;

				m_MaxLongitude = 10 * (factor + 1);
				m_MaxLatitude = 10 * (factor + 1);

				int numDataPoints = 2 + (m_MaxLatitude * m_MaxLongitude);

				m_XValues = new double[numDataPoints];
				m_YValues = new double[numDataPoints];
				m_ZValues = new double[numDataPoints];
			}
			/// <summary>
			/// Adds the sphere to the specified point series
			/// </summary>
			/// <param name="point"></param>
			public void AddSphere(NPointSeries point)
			{
				m_Radius += m_RadiusIncrement;
				m_Counter++;

				double x, y, z;

				point.FillStyle = new NColorFillStyle(InterpolateColors(m_BeginColor, m_EndColor, (float)(m_Counter / 100.0)));
				point.Values.Clear();
				point.XValues.Clear();
				point.ZValues.Clear();

				int dataPointIndex = 0;

				double[] xValues = m_XValues;
				double[] yValues = m_YValues;
				double[] zValues = m_ZValues;

				// top vertex
				yValues[dataPointIndex] = (m_CenterY + m_Radius);
				xValues[dataPointIndex] = m_CenterX;
				zValues[dataPointIndex] = m_CenterZ;
				dataPointIndex++;

				// bottom vertex
				yValues[dataPointIndex] = m_CenterY - m_Radius;
				xValues[dataPointIndex] = m_CenterX;
				zValues[dataPointIndex] = m_CenterZ;
				dataPointIndex++;

				int nPitch = m_MaxLongitude + 1;

				double pitchInc = (180.0 / (double)m_MaxLongitude) * NMath.Degree2Rad;
				double rotInc = (360.0 / (double)m_MaxLatitude) * NMath.Degree2Rad;

				for (int pitch = 1; pitch <= m_MaxLongitude; pitch++)     // Generate all "intermediate vertices":
				{
					double res = m_Radius * Math.Sin((float)pitch * pitchInc);

					if (res < 0)
					{
						res = -res;
					}
					
					y = m_Radius * Math.Cos(pitch * pitchInc);

					for (int latitude = 0; latitude < m_MaxLatitude; latitude++)
					{
						x = res * Math.Cos(latitude * rotInc);
						z = res * Math.Sin(latitude * rotInc);

						yValues[dataPointIndex] = m_CenterY + y;
						xValues[dataPointIndex] = m_CenterX + x;
						zValues[dataPointIndex] = m_CenterZ + z;

						dataPointIndex++;
					}
				}

				if (point.XValues.Count > 0)
				{
					point.Values.SetRange(0, yValues);
					point.XValues.SetRange(0, xValues);
					point.ZValues.SetRange(0, zValues);
				}
				else
				{
					point.Values.AddRange(yValues);
					point.XValues.AddRange(xValues);
					point.ZValues.AddRange(zValues);
				}
			}

			public static Color InterpolateColors(Color color1, Color color2, float factor)
			{
				int num1 = ((int)color1.R);
				int num2 = ((int)color1.G);
				int num3 = ((int)color1.B);

				int num4 = ((int)color2.R);
				int num5 = ((int)color2.G);
				int num6 = ((int)color2.B);

				byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * factor)));
				byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * factor)));
				byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * factor)));

				return Color.FromArgb(num7, num8, num9);
			}

			double m_CenterX;
			double m_CenterY;
			double m_CenterZ;
			double m_Radius;
			double m_RadiusIncrement;
			Color m_BeginColor;
			Color m_EndColor;
			public int m_Counter;

			int m_MaxLongitude;
			int m_MaxLatitude;

			double[] m_XValues;
			double[] m_YValues;
			double[] m_ZValues;
		}

		public NRealTimePointUC()
		{
			InitializeComponent();

			m_Counter = 0;
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
			this.ResetButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.StopStartTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.UseHardwareAccelerationCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.DataPointsPerSphereComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Data Points Per Sphere:";
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(7, 71);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(153, 23);
			this.ResetButton.TabIndex = 2;
			this.ResetButton.Text = "Reset";
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Bottom:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Right:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Top:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Left:";
			// 
			// StopStartTimerButton
			// 
			this.StopStartTimerButton.Location = new System.Drawing.Point(7, 42);
			this.StopStartTimerButton.Name = "StopStartTimerButton";
			this.StopStartTimerButton.Size = new System.Drawing.Size(153, 23);
			this.StopStartTimerButton.TabIndex = 1;
			this.StopStartTimerButton.Text = "Stop Timer";
			this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			// 
			// UseHardwareAccelerationCheckBox
			// 
			this.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseHardwareAccelerationCheckBox.Location = new System.Drawing.Point(7, 12);
			this.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox";
			this.UseHardwareAccelerationCheckBox.Size = new System.Drawing.Size(153, 24);
			this.UseHardwareAccelerationCheckBox.TabIndex = 0;
			this.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration";
			this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			// 
			// DataPointsPerSphereComboBox
			// 
			this.DataPointsPerSphereComboBox.ListProperties.CheckBoxDataMember = "";
			this.DataPointsPerSphereComboBox.ListProperties.DataSource = null;
			this.DataPointsPerSphereComboBox.ListProperties.DisplayMember = "";
			this.DataPointsPerSphereComboBox.Location = new System.Drawing.Point(7, 122);
			this.DataPointsPerSphereComboBox.Name = "DataPointsPerSphereComboBox";
			this.DataPointsPerSphereComboBox.Size = new System.Drawing.Size(153, 21);
			this.DataPointsPerSphereComboBox.TabIndex = 4;
			this.DataPointsPerSphereComboBox.Text = "comboBox2";
			this.DataPointsPerSphereComboBox.SelectedIndexChanged += new System.EventHandler(this.DataPointsPerSphereComboBox_SelectedIndexChanged);
			// 
			// NRealTimePointUC
			// 
			this.Controls.Add(this.DataPointsPerSphereComboBox);
			this.Controls.Add(this.UseHardwareAccelerationCheckBox);
			this.Controls.Add(this.StopStartTimerButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ResetButton);
			this.Name = "NRealTimePointUC";
			this.Size = new System.Drawing.Size(178, 442);
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Real Time Point");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// do not update automatic legends
			nChartControl1.ServiceManager.LegendUpdateService.UpdateAutoLegends();
			nChartControl1.ServiceManager.LegendUpdateService.Stop();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Enable3D = true;

			// make the aspect 1:1:1
			chart.Width = 50.0f;
			chart.Height = 50.0f;
			chart.Depth = 50.0f;

			// configure the y axis
			NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			linearScale.MajorGridStyle.LineStyle.Color = Color.LightSteelBlue;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.InnerMajorTickStyle.Visible = false;
			linearScale.LabelFitModes = new LabelFitMode[0];

			// configure the axes
			ConfigureAxis(chart.Axis(StandardAxis.PrimaryX));
			ConfigureAxis(chart.Axis(StandardAxis.PrimaryY));
			ConfigureAxis(chart.Axis(StandardAxis.Depth));

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			DataPointsPerSphereComboBox.Items.Add("100");
			DataPointsPerSphereComboBox.Items.Add("1000");
			DataPointsPerSphereComboBox.Items.Add("10000");
			DataPointsPerSphereComboBox.SelectedIndex = 0;

			UseHardwareAccelerationCheckBox.Checked = true;
			StartTimer();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="axis"></param>
		private static void ConfigureAxis(NAxis axis)
		{
			// configure the x axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.LabelFitModes = new LabelFitMode[0];

			axis.ScaleConfigurator = linearScale;
			axis.View = new NRangeAxisView(new NRange1DD(-200, 200), true, true);
		}

		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Point";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		private void ResetButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			chart.Series.Clear();

			nChartControl1.Refresh();
		}

		private void NumberOfDataPointsUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			ResetButton_Click(null, null);
		}

		protected override void  OnTimerTick(object sender, EventArgs e)
		{
 			base.OnTimerTick(sender, e);

			NChart chart = nChartControl1.Charts[0];
			
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);

			if (m_Counter == 0)
			{
				NPointSeries point = new NPointSeries();

				point.Size = new NLength(2);
				point.EnableDepthSort = false;
				point.DataLabelStyle.Visible = false;
				point.UseXValues = true;
				point.UseZValues = true;

				// turn off point border to improve performance
				point.BorderStyle.Width = new NLength(0);
				point.PointShape = PointShape.Bar;

				point.Tag = new NSphereInfo(DataPointsPerSphereComboBox.SelectedIndex);

				chart.Series.Add(point);
				m_Counter = 10;
			}

			m_Counter--;

			int count = chart.Series.Count;

			for (int i = count - 1; i >= 0; i--)
			{
				NPointSeries point = (NPointSeries)chart.Series[i];

				NSphereInfo info = (NSphereInfo)point.Tag;

				if (info.m_Counter == 100)
				{
					chart.Series.RemoveAt(i);
				}
				else
				{
					info.AddSphere(point);
				}
			}

			nChartControl1.Refresh();
		}

		private static Color ColorFromValue(double value)
		{
			return Color.FromArgb((byte)(value * 25), (byte)(value * 25), (byte)(value * 25));
		}

		private void UseHardwareAccelerationCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(UseHardwareAccelerationCheckBox.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
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

		private void DataPointsPerSphereComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ResetButton_Click(null, null);
		}
	}
}
