using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
	public class NFastPoint2DUC : NExampleBaseUC
	{
        private Label label1;
        private Label label2;
        private Nevron.UI.WinForm.Controls.NNumericUpDown PointSizeNumericUpDown;
        private Timer timer1;
        private Nevron.UI.WinForm.Controls.NButton StartStopTimerButton;
        private Nevron.UI.WinForm.Controls.NComboBox PointCountCombo;
        private System.ComponentModel.IContainer components = null;

        NVector2DF[] m_DriftSpeeds;
        float m_Phase;
        NFastPointSeries m_FastPoint;
        NLabel m_Title;

        Random m_Random = new Random();

        public NFastPoint2DUC()
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
				if (components != null) 
				{
					components.Dispose();
				}
                if (timer1 != null)
                {
                    timer1.Stop();
                    timer1.Tick -= new EventHandler(OnTimerTick);
                    timer1.Dispose();
                }
            }
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PointSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
            this.PointCountCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PointSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Point Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Point Count:";
            // 
            // PointSizeNumericUpDown
            // 
            this.PointSizeNumericUpDown.Location = new System.Drawing.Point(17, 35);
            this.PointSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PointSizeNumericUpDown.Name = "PointSizeNumericUpDown";
            this.PointSizeNumericUpDown.Size = new System.Drawing.Size(236, 20);
            this.PointSizeNumericUpDown.TabIndex = 1;
            this.PointSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PointSizeNumericUpDown.ValueChanged += new System.EventHandler(this.OnPointSizeNumericUpDownValueChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // StartStopTimerButton
            // 
            this.StartStopTimerButton.Location = new System.Drawing.Point(17, 174);
            this.StartStopTimerButton.Name = "StartStopTimerButton";
            this.StartStopTimerButton.Size = new System.Drawing.Size(236, 21);
            this.StartStopTimerButton.TabIndex = 4;
            this.StartStopTimerButton.Text = "Stop Timer Button";
            this.StartStopTimerButton.UseVisualStyleBackColor = true;
            this.StartStopTimerButton.Click += new System.EventHandler(this.OnStartStopTimerButtonClick);
            // 
            // PointCountCombo
            // 
            this.PointCountCombo.ListProperties.CheckBoxDataMember = "";
            this.PointCountCombo.ListProperties.DataSource = null;
            this.PointCountCombo.ListProperties.DisplayMember = "";
            this.PointCountCombo.Location = new System.Drawing.Point(17, 94);
            this.PointCountCombo.Name = "PointCountCombo";
            this.PointCountCombo.Size = new System.Drawing.Size(236, 21);
            this.PointCountCombo.TabIndex = 3;
            this.PointCountCombo.SelectedIndexChanged += new System.EventHandler(this.OnPointCountComboSelectedIndexChanged);
            // 
            // NFastPoint2DUC
            // 
            this.Controls.Add(this.PointCountCombo);
            this.Controls.Add(this.StartStopTimerButton);
            this.Controls.Add(this.PointSizeNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NFastPoint2DUC";
            this.Size = new System.Drawing.Size(266, 564);
            ((System.ComponentModel.ISupportInitialize)(this.PointSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			m_Title = new NLabel("Fast Point 2D");
            m_Title.TextStyle.TextFormat = TextFormat.XML;
            m_Title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

            ConfigureLinearScale(chart.Axis((int)StandardAxis.PrimaryX));
            ConfigureLinearScale(chart.Axis((int)StandardAxis.PrimaryY));

			// setup the fast point series
			m_FastPoint = (NFastPointSeries)chart.Series.Add(SeriesType.FastPoint);
			m_FastPoint.Name = "FastPoint Series";

			// apply layout
			ConfigureStandardLayout(chart, m_Title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            PointSizeNumericUpDown.Value = (decimal)Math.Round(Math.Min(1, m_FastPoint.Size.Value));

            PointCountCombo.Items.Add("100K");
            PointCountCombo.Items.Add("500K");
            PointCountCombo.Items.Add("1M");
            PointCountCombo.Items.Add("2M");
            PointCountCombo.Items.Add("10M");
            PointCountCombo.SelectedIndex = 2;

            AddData();
            timer1.Start();

            nChartControl1.Settings.RenderSurface = RenderSurface.Window;
        }
        /// <summary>
        /// Applies a linear scale and an interlaced stripe at the specified axis
        /// </summary>
        /// <param name="axis"></param>
        private void ConfigureLinearScale(NAxis axis)
        {
            // add interlaced stripe to the Y axis
            NLinearScaleConfigurator scale = new NLinearScaleConfigurator();

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Right, true);
            stripStyle.SetShowAtWall(ChartWallType.Front, true);
            stripStyle.SetShowAtWall(ChartWallType.Floor, true);
            stripStyle.SetShowAtWall(ChartWallType.Top, true);

            stripStyle.Interlaced = true;
            scale.StripStyles.Add(stripStyle);

            axis.ScaleConfigurator = scale;
            axis.Visible = true;
        }
		/// <summary>
		/// Gets a random velocity vector
		/// </summary>
		/// <returns></returns>
        private NVector2DF GetRandomVelocity()
        {
            NVector2DF result;

            result.X = 0.001f + 0.003f * (float)m_Random.NextDouble();
            result.Y = 0.001f + 0.003f * (float)m_Random.NextDouble();

            if (m_Random.NextDouble() < 0.5)
            {
                result.X = -result.X;
            }

            if (m_Random.NextDouble() < 0.5)
            {
                result.Y = -result.Y;
            }

            return result;
        }
        /// <summary>
        /// Gets the number of random points
        /// </summary>
        /// <returns></returns>
        private int GetPointCount()
        {
            switch (PointCountCombo.SelectedIndex)
            {
                case 0:
                    return 100000;
                case 1:
                    return 500000;
                case 2:
                    return 1000000;
                case 3:
                    return 2000000;
                case 4:
                    return 10000000;
                default:
                    return 100000;
            }
        }
        /// <summary>
        /// Adds random data to the chart
        /// </summary>
        private void AddData()
        {
            int pointCount = GetPointCount();
           
            m_DriftSpeeds = new NVector2DF[pointCount];

            m_FastPoint.Data.UseXValues = true;
            m_FastPoint.Data.UseColors = true;
            m_FastPoint.Data.SetCount(pointCount);

            NVector3DF yaxis = new NVector3DF(0, 1, 0);

            unsafe
            {
                int count = m_FastPoint.Data.Count;
                int dataItemSize = m_FastPoint.Data.DataItemSize;

                fixed (byte* pData = &m_FastPoint.Data.Data[0])
                {
                    float* pXValues = (float*)m_FastPoint.Data.GetDataChannelPointer(ENSeriesDataChannelName.XValueF, pData);
                    float* pYValues = (float*)m_FastPoint.Data.GetDataChannelPointer(ENSeriesDataChannelName.YValueF, pData);
                    uint* pColor = (uint*)m_FastPoint.Data.GetDataChannelPointer(ENSeriesDataChannelName.Color, pData);
                    {
                        for (int i = 0; i < pointCount; i++)
                        {
                            float x = (float)(2 * Random.NextDouble() - 1);
                            float y = (float)(2 * Random.NextDouble() - 1);

                            if (x * x + y * y < 1)
                            {
                                m_DriftSpeeds[i] = GetRandomVelocity();

                                *pXValues = x;
                                *pYValues = y;
                            }

                            uint red = (uint)(255 * m_Random.NextDouble());
                            uint green = (uint)(255 * m_Random.NextDouble());
                            uint blue = (uint)(255 * m_Random.NextDouble());

                            *pColor = (uint)(0xFF000000 | (red << 16) | (green << 8) | blue);

                            pXValues += dataItemSize;
                            pYValues += dataItemSize;
                            pColor += dataItemSize;
                        }
                    }
                }

                m_FastPoint.Data.OnDataChanged();
            }

            nChartControl1.Refresh();
        }

        private void OnPointSizeNumericUpDownValueChanged(object sender, EventArgs e)
        {
            m_FastPoint.Size = new NLength((int)PointSizeNumericUpDown.Value);
            nChartControl1.Refresh();
        }

        void OnStartStopTimerButtonClick(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;

            if (timer1.Enabled)
            {
                StartStopTimerButton.Text = "Stop Timer";
            }
            else
            {
                StartStopTimerButton.Text = "Start Timer";
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            // spin the points
            unsafe
            {
                fixed (byte* pData = &m_FastPoint.Data.Data[0])
                {
                    int count = m_FastPoint.Data.Count;
                    int dataItemSize = m_FastPoint.Data.DataItemSize;

                    float* pXValues = (float*)m_FastPoint.Data.GetDataChannelPointer(ENSeriesDataChannelName.XValueF, pData);
                    float* pYValues = (float*)m_FastPoint.Data.GetDataChannelPointer(ENSeriesDataChannelName.YValueF, pData);
                    NVector2DF[] driftSpeeds = m_DriftSpeeds;

                    // modify the data
                    for (int i = 0; i < count; i++)
                    {
                        NVector2DF v;

                        v.X = *pXValues + driftSpeeds[i].X;
                        v.Y = *pYValues + driftSpeeds[i].Y;

                        if ((v.X * v.X + v.Y * v.Y) > 1)
                        {
                            // When outside the sphere, change to a random velocity,
                            // and multiply the point by 0.9997 to move it back
                            // towards the inside of the sphere.  Using a value
                            // close to 1 allows the sphere to get a little
                            // fuzzy.
                            m_DriftSpeeds[i] = GetRandomVelocity();
                            v.X *= 0.9997f;
                            v.Y *= 0.9997f;
                        }
                        else if (m_Random.Next() < 0.001)
                        {
                            // change to a new random velocity, with a small probability
                            m_DriftSpeeds[i] = GetRandomVelocity();
                        }

                        *pXValues = v.X;
                        *pYValues = v.Y;

                        pXValues += dataItemSize;
                        pYValues += dataItemSize;
                    }

                    m_FastPoint.Data.OnDataChanged();
                }
            }

            nChartControl1.Refresh();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPointCountComboSelectedIndexChanged(object sender, EventArgs e)
        {
            m_Title.Text = "Fast Point 2D<br/><font size = '12pt'> Showing Realtime Rendering of " + GetPointCount().ToString("#,##0", CultureInfo.InvariantCulture) + " Data Points</font>";
            AddData();
        }
    }
}

