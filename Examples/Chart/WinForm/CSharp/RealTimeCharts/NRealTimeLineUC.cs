using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRealTimeLineUC : NRealTimeExampleBaseUC 
	{
		private IContainer components;
		
		NLineSeries m_Line1;
		NLineSeries m_Line2;
		NLineSeries m_Line3;
		Random m_Random = new Random();

		double[] m_ValueArray1;
		double[] m_ValueArray2;
		double[] m_ValueArray3;

		int m_MaxCount = 25000;
		int m_NewDataPointsPerTick = 4000;
		double m_Angle1;
		double m_Angle2;
		double m_Angle3;

		private NCheckBox UseHardwareAccelerationCheckBox;
		private NButton StopStartTimerButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private NNumericUpDown Frequency1NumericUpDown;
		private NNumericUpDown Frequency2NumericUpDown;
		private NNumericUpDown Frequency3NumericUpDown;
		private NNumericUpDown Amplitude3NumericUpDown;
		private NNumericUpDown Amplitude2NumericUpDown;
		private NNumericUpDown Amplitude1NumericUpDown;
        private Label label4;
        private Label label5;
		private NNumericUpDown Noise3NumericUpDown;
		private NNumericUpDown Noise2NumericUpDown;
		private NNumericUpDown Noise1NumericUpDown;
		private Label label7;
		private Label label8;
		private Label label9;
        private Label label6;
		

		public NRealTimeLineUC()
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
			this.UseHardwareAccelerationCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.StopStartTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Frequency1NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.Frequency2NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.Frequency3NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.Amplitude3NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.Amplitude2NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.Amplitude1NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.Noise3NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.Noise2NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.Noise1NumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Frequency1NumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Frequency2NumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Frequency3NumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Amplitude3NumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Amplitude2NumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Amplitude1NumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Noise3NumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Noise2NumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Noise1NumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// UseHardwareAccelerationCheckBox
			// 
			this.UseHardwareAccelerationCheckBox.AutoSize = true;
			this.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseHardwareAccelerationCheckBox.Location = new System.Drawing.Point(10, 11);
			this.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox";
			this.UseHardwareAccelerationCheckBox.Size = new System.Drawing.Size(156, 17);
			this.UseHardwareAccelerationCheckBox.TabIndex = 0;
			this.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration";
			this.UseHardwareAccelerationCheckBox.UseVisualStyleBackColor = true;
			this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			// 
			// StopStartTimerButton
			// 
			this.StopStartTimerButton.Location = new System.Drawing.Point(10, 34);
			this.StopStartTimerButton.Name = "StopStartTimerButton";
			this.StopStartTimerButton.Size = new System.Drawing.Size(161, 23);
			this.StopStartTimerButton.TabIndex = 0;
			this.StopStartTimerButton.Text = "Stop Timer";
			this.StopStartTimerButton.UseVisualStyleBackColor = true;
			this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Frequency 1:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Frequency 2:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 166);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Frequency 3:";
			// 
			// Frequency1NumericUpDown
			// 
			this.Frequency1NumericUpDown.Location = new System.Drawing.Point(92, 105);
			this.Frequency1NumericUpDown.Name = "Frequency1NumericUpDown";
			this.Frequency1NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Frequency1NumericUpDown.TabIndex = 3;
			this.Frequency1NumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// Frequency2NumericUpDown
			// 
			this.Frequency2NumericUpDown.Location = new System.Drawing.Point(92, 133);
			this.Frequency2NumericUpDown.Name = "Frequency2NumericUpDown";
			this.Frequency2NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Frequency2NumericUpDown.TabIndex = 5;
			this.Frequency2NumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// Frequency3NumericUpDown
			// 
			this.Frequency3NumericUpDown.Location = new System.Drawing.Point(92, 159);
			this.Frequency3NumericUpDown.Name = "Frequency3NumericUpDown";
			this.Frequency3NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Frequency3NumericUpDown.TabIndex = 7;
			this.Frequency3NumericUpDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			// 
			// Amplitude3NumericUpDown
			// 
			this.Amplitude3NumericUpDown.Location = new System.Drawing.Point(92, 270);
			this.Amplitude3NumericUpDown.Name = "Amplitude3NumericUpDown";
			this.Amplitude3NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Amplitude3NumericUpDown.TabIndex = 13;
			this.Amplitude3NumericUpDown.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
			// 
			// Amplitude2NumericUpDown
			// 
			this.Amplitude2NumericUpDown.Location = new System.Drawing.Point(92, 244);
			this.Amplitude2NumericUpDown.Name = "Amplitude2NumericUpDown";
			this.Amplitude2NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Amplitude2NumericUpDown.TabIndex = 11;
			this.Amplitude2NumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// Amplitude1NumericUpDown
			// 
			this.Amplitude1NumericUpDown.Location = new System.Drawing.Point(92, 216);
			this.Amplitude1NumericUpDown.Name = "Amplitude1NumericUpDown";
			this.Amplitude1NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Amplitude1NumericUpDown.TabIndex = 9;
			this.Amplitude1NumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 277);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Amplitude 3:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 251);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Amplitude 2:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 223);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(65, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Amplitude 1:";
			// 
			// Noise3NumericUpDown
			// 
			this.Noise3NumericUpDown.Location = new System.Drawing.Point(92, 389);
			this.Noise3NumericUpDown.Name = "Noise3NumericUpDown";
			this.Noise3NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Noise3NumericUpDown.TabIndex = 19;
			this.Noise3NumericUpDown.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
			// 
			// Noise2NumericUpDown
			// 
			this.Noise2NumericUpDown.Location = new System.Drawing.Point(92, 363);
			this.Noise2NumericUpDown.Name = "Noise2NumericUpDown";
			this.Noise2NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Noise2NumericUpDown.TabIndex = 17;
			this.Noise2NumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// Noise1NumericUpDown
			// 
			this.Noise1NumericUpDown.Location = new System.Drawing.Point(92, 335);
			this.Noise1NumericUpDown.Name = "Noise1NumericUpDown";
			this.Noise1NumericUpDown.Size = new System.Drawing.Size(83, 20);
			this.Noise1NumericUpDown.TabIndex = 15;
			this.Noise1NumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 396);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Noise 3:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 370);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "Noise 2:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(7, 342);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Noise 1:";
			// 
			// NRealTimeLineUC
			// 
			this.Controls.Add(this.Noise3NumericUpDown);
			this.Controls.Add(this.Noise2NumericUpDown);
			this.Controls.Add(this.Noise1NumericUpDown);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.Amplitude3NumericUpDown);
			this.Controls.Add(this.Amplitude2NumericUpDown);
			this.Controls.Add(this.Amplitude1NumericUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.Frequency3NumericUpDown);
			this.Controls.Add(this.Frequency2NumericUpDown);
			this.Controls.Add(this.Frequency1NumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.UseHardwareAccelerationCheckBox);
			this.Controls.Add(this.StopStartTimerButton);
			this.Name = "NRealTimeLineUC";
			this.Size = new System.Drawing.Size(180, 506);
			((System.ComponentModel.ISupportInitialize)(this.Frequency1NumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Frequency2NumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Frequency3NumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Amplitude3NumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Amplitude2NumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Amplitude1NumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Noise3NumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Noise2NumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Noise1NumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Real Time Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NCartesianChart chart = new NCartesianChart();
		
			nChartControl1.Panels.Add(chart);
			chart.BoundsMode = BoundsMode.Stretch;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Black);
//			styleSheet.Apply(nChartControl1.Document);

			NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
			ConfigureAxis(axis1, 0, 30, "Signal 1");

			NAxis axis2 = chart.Axis(StandardAxis.SecondaryY);
			ConfigureAxis(axis2, 35, 65, "Signal 2");

			NAxis axis3 = ((NCartesianAxisCollection)chart.Axes).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontRight);
			ConfigureAxis(axis3, 70, 100, "Signal 3");

			m_Line1 = CreateLineSeries();
			chart.Series.Add(m_Line1);

			m_Line2 = CreateLineSeries();
			chart.Series.Add(m_Line2);
			m_Line2.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Line2.DisplayOnAxis(StandardAxis.SecondaryY, true);

			m_Line3 = CreateLineSeries();
			chart.Series.Add(m_Line3);
			m_Line3.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Line3.DisplayOnAxis(axis3.AxisId, true);

			m_ValueArray1 = new double[m_NewDataPointsPerTick];
			m_ValueArray2 = new double[m_NewDataPointsPerTick];
			m_ValueArray3 = new double[m_NewDataPointsPerTick];

			ConfigureStandardLayout(chart, title, null);

			UseHardwareAccelerationCheckBox.Checked = true;
			StartTimer();
		}

		private void ConfigureAxis(NAxis axis, float beginPercent, float endPercent, string title)
		{
			NLinearScaleConfigurator scale = new NLinearScaleConfigurator();
			scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			axis.ScaleConfigurator = scale;
			axis.View = new NRangeAxisView(new NRange1DD(-1.5, 1.5), true, true);
			axis.ScaleConfigurator.Title.Text = title;
			axis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false);
			axis.Anchor.BeginPercent = beginPercent;
			axis.Anchor.EndPercent = endPercent;
            axis.Visible = true;
		}

		private NLineSeries CreateLineSeries()
		{
			NLineSeries lineSeries = new NLineSeries();

			lineSeries.Values.Capacity = m_MaxCount;
			lineSeries.XValues.Capacity = m_MaxCount;
			lineSeries.DataLabelStyle.Visible = false;
			lineSeries.SamplingMode = SeriesSamplingMode.Enabled;
			lineSeries.SampleDistance = new NLength(1, NGraphicsUnit.Pixel);

			return lineSeries;
		}

		protected override void UpdateTitle(bool working, float cpuUsage)
		{
            string title = "Real Time Line";

            if (working)
            {
                title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
            }

            nChartControl1.Labels[0].Text = title;
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
            base.OnTimerTick(sender, e);

			// first accumulate the new data in arrays for faster processing
			int newDataPoints = m_NewDataPointsPerTick;

            double angleStep1 = (Math.PI * 2 / m_MaxCount) * (int)Frequency1NumericUpDown.Value;
			double angleStep2 = (Math.PI * 2 / m_MaxCount) * (int)Frequency2NumericUpDown.Value;
			double angleStep3 = (Math.PI * 2 / m_MaxCount) * (int)Frequency3NumericUpDown.Value;

            double amplitude1 = Math.Min(1, (double)Amplitude1NumericUpDown.Value * 0.01);
			double amplitude2 = Math.Min(1, (double)Amplitude2NumericUpDown.Value * 0.01);
			double amplitude3 = Math.Min(1, (double)Amplitude3NumericUpDown.Value * 0.01);

			double noise1 = (double)Noise1NumericUpDown.Value * 0.02;
			double noise2 = (double)Noise2NumericUpDown.Value * 0.02;
			double noise3 = (double)Noise3NumericUpDown.Value * 0.02;

			// generate new data
			Random random = m_Random;
			double[] valueArray1 = m_ValueArray1;
			double[] valueArray2 = m_ValueArray2;
			double[] valueArray3 = m_ValueArray3;

			for (int i = 0; i < newDataPoints; i++)
			{
				valueArray1[i] = (Math.Sin(m_Angle1) + (random.NextDouble() - 0.5) * noise1) * amplitude1;
				valueArray2[i] = (Math.Sin(m_Angle2) + (random.NextDouble() - 0.5) * noise2) * amplitude2;
				valueArray3[i] = (Math.Sin(m_Angle3) + (random.NextDouble() - 0.5) * noise3) * amplitude3;

				m_Angle1 += angleStep1;
				m_Angle2 += angleStep2;
				m_Angle3 += angleStep3;
			}

			int valueIndex = 0;
			int itemsToAdd = newDataPoints;
			int originShift = newDataPoints;

			// then add the new data
			if (m_Line1.Values.Count < m_MaxCount)
			{
				// the line series can accumulate the new data
				int valueCount = Math.Min(m_MaxCount - m_Line1.Values.Count, newDataPoints);

				m_Line1.Values.AddRange(m_ValueArray1, valueIndex, valueCount);
				m_Line2.Values.AddRange(m_ValueArray2, valueIndex, valueCount);
				m_Line3.Values.AddRange(m_ValueArray3, valueIndex, valueCount);

				valueIndex += valueCount;
				itemsToAdd -= valueCount;
				originShift -= valueCount;
			}

			if (itemsToAdd > 0)
			{
				// capacity reached
				int count = m_Line1.Values.Count - m_Line1.DataPointOriginIndex;
				int valueCount = Math.Min(count, itemsToAdd);

				m_Line1.Values.SetRange(m_Line1.DataPointOriginIndex, m_ValueArray1, valueIndex, valueCount);
				m_Line2.Values.SetRange(m_Line2.DataPointOriginIndex, m_ValueArray2, valueIndex, valueCount);
				m_Line3.Values.SetRange(m_Line3.DataPointOriginIndex, m_ValueArray3, valueIndex, valueCount);

				itemsToAdd -= valueCount;

				if (itemsToAdd > 0)
				{
					valueIndex += valueCount;

					m_Line1.Values.SetRange(0, m_ValueArray1, valueIndex, itemsToAdd);
					m_Line2.Values.SetRange(0, m_ValueArray2, valueIndex, itemsToAdd);
					m_Line3.Values.SetRange(0, m_ValueArray3, valueIndex, itemsToAdd);
				}
			}

			m_Line1.DataPointOriginIndex += originShift;
			m_Line2.DataPointOriginIndex += originShift;
			m_Line3.DataPointOriginIndex += originShift;

			m_Line1.DataPointOriginIndex %= m_MaxCount;
			m_Line2.DataPointOriginIndex %= m_MaxCount;
			m_Line3.DataPointOriginIndex %= m_MaxCount;

			nChartControl1.Refresh();
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

        private void UseHardwareAccelerationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseHardwareAccelerationCheckBox.Checked)
            {
                nChartControl1.Settings.RenderSurface = RenderSurface.Window;
            }
            else
            {
                nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
            }
        }
	}
}
