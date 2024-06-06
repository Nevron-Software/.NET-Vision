using Nevron.Chart;
using Nevron.Chart.Functions;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
    public class NFastBar3DUC : NExampleBaseUC
    {
        private Label label2;
        private Timer timer1;
        private Nevron.UI.WinForm.Controls.NButton StartStopTimerButton;
        private UI.WinForm.Controls.NComboBox BarGridCombo;
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Represents a fast point series
        /// </summary>
        class NPulsePoint
        {
            public double X;
            public double Y;
            public double Intensity;
            public double WaveLength;
            public double Phase;
            public double PhaseStep;
            public double PhaseSin;
        };

        Random m_Random = new Random();
        const int m_MaxPulsePoints = 5;
        double[] m_SinTable = new double[360];
        NFastBarSeries m_FastBar;
        NLabel m_Title;
        NPulsePoint[] m_PulsePoints;
        private UI.WinForm.Controls.NCheckBox EnableShaderRenderingCheck;
        private UI.WinForm.Controls.NCheckBox EnableLightingCheckBox;
        private UI.WinForm.Controls.NCheckBox UseCustomColorsCheckBox;
        int m_GridSize;

        public NFastBar3DUC()
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
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
            this.BarGridCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.EnableShaderRenderingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.EnableLightingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.UseCustomColorsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Point Count:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // StartStopTimerButton
            // 
            this.StartStopTimerButton.Location = new System.Drawing.Point(14, 161);
            this.StartStopTimerButton.Name = "StartStopTimerButton";
            this.StartStopTimerButton.Size = new System.Drawing.Size(232, 21);
            this.StartStopTimerButton.TabIndex = 5;
            this.StartStopTimerButton.Text = "Stop Timer Button";
            this.StartStopTimerButton.UseVisualStyleBackColor = true;
            this.StartStopTimerButton.Click += new System.EventHandler(this.OnStartStopTimerButtonClick);
            // 
            // BarGridCombo
            // 
            this.BarGridCombo.ListProperties.CheckBoxDataMember = "";
            this.BarGridCombo.ListProperties.DataSource = null;
            this.BarGridCombo.ListProperties.DisplayMember = "";
            this.BarGridCombo.Location = new System.Drawing.Point(14, 33);
            this.BarGridCombo.Name = "BarGridCombo";
            this.BarGridCombo.Size = new System.Drawing.Size(232, 21);
            this.BarGridCombo.TabIndex = 1;
            this.BarGridCombo.SelectedIndexChanged += new System.EventHandler(this.OnPointCountComboSelectedIndexChanged);
            // 
            // EnableShaderRenderingCheck
            // 
            this.EnableShaderRenderingCheck.ButtonProperties.BorderOffset = 2;
            this.EnableShaderRenderingCheck.Location = new System.Drawing.Point(14, 67);
            this.EnableShaderRenderingCheck.Name = "EnableShaderRenderingCheck";
            this.EnableShaderRenderingCheck.Size = new System.Drawing.Size(232, 21);
            this.EnableShaderRenderingCheck.TabIndex = 2;
            this.EnableShaderRenderingCheck.Text = "Enable Shader Rendering";
            this.EnableShaderRenderingCheck.CheckedChanged += new System.EventHandler(this.EnableShaderRenderingCheck_CheckedChanged);
            // 
            // EnableLightingCheckBox
            // 
            this.EnableLightingCheckBox.ButtonProperties.BorderOffset = 2;
            this.EnableLightingCheckBox.Location = new System.Drawing.Point(14, 89);
            this.EnableLightingCheckBox.Name = "EnableLightingCheckBox";
            this.EnableLightingCheckBox.Size = new System.Drawing.Size(232, 21);
            this.EnableLightingCheckBox.TabIndex = 3;
            this.EnableLightingCheckBox.Text = "Enable Lighting";
            this.EnableLightingCheckBox.CheckedChanged += new System.EventHandler(this.EnableLightingCheckBox_CheckedChanged);
            // 
            // UseCustomColorsCheckBox
            // 
            this.UseCustomColorsCheckBox.ButtonProperties.BorderOffset = 2;
            this.UseCustomColorsCheckBox.Location = new System.Drawing.Point(14, 111);
            this.UseCustomColorsCheckBox.Name = "UseCustomColorsCheckBox";
            this.UseCustomColorsCheckBox.Size = new System.Drawing.Size(232, 21);
            this.UseCustomColorsCheckBox.TabIndex = 4;
            this.UseCustomColorsCheckBox.Text = "Use Custom Colors";
            this.UseCustomColorsCheckBox.CheckedChanged += new System.EventHandler(this.UseCustomColorsCheckBox_CheckedChanged);
            // 
            // NFastBar3DUC
            // 
            this.Controls.Add(this.UseCustomColorsCheckBox);
            this.Controls.Add(this.EnableLightingCheckBox);
            this.Controls.Add(this.EnableShaderRenderingCheck);
            this.Controls.Add(this.BarGridCombo);
            this.Controls.Add(this.StartStopTimerButton);
            this.Controls.Add(this.label2);
            this.Name = "NFastBar3DUC";
            this.Size = new System.Drawing.Size(266, 564);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            // set a chart title
            // set a chart title
            m_Title = new NLabel("Fast Bar 3D");
            m_Title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            m_Title.TextStyle.TextFormat = TextFormat.XML;

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Height = 10;
            chart.Depth = 50;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

            chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(-2, 2));

            ConfigureLinearScale(chart.Axis((int)StandardAxis.PrimaryX));
            ConfigureLinearScale(chart.Axis((int)StandardAxis.PrimaryY));
            ConfigureLinearScale(chart.Axis((int)StandardAxis.Depth));

			// setup the fast bar series
			m_FastBar = (NFastBarSeries)chart.Series.Add(SeriesType.FastBar);
			m_FastBar.Name = "FastBar Series";
            m_FastBar.Data.UseXValues = true;
            m_FastBar.Data.UseZValues = true;
            m_FastBar.Data.UseColors = true;
            m_FastBar.Color = new NColorFillStyle(Color.Red);

            // precalculate sinus table
            for (int i = 0; i < 360; i++)
            {
                m_SinTable[i] = Math.Sin(i * Math.PI / 180);
            }

            // apply layout
            ConfigureStandardLayout(chart, m_Title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
            nChartControl1.Controller.Tools.Add(new NTrackballTool());

            BarGridCombo.Items.Add("100x100");
            BarGridCombo.Items.Add("500x500");
            BarGridCombo.Items.Add("1000x1000");
            BarGridCombo.Items.Add("2000x2000");
            BarGridCombo.SelectedIndex = 0;

            EnableShaderRenderingCheck.Checked = m_FastBar.EnableShaderRendering;
            EnableLightingCheckBox.Checked = chart.LightModel.EnableLighting;
            UseCustomColorsCheckBox.Checked = m_FastBar.Data.UseColors;

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
        }
        /// <summary>
        /// Adds random data to the chart
        /// </summary>
        private void AddData()
        {
            switch (BarGridCombo.SelectedIndex)
            {
                case 0:
                    m_GridSize = 100;
                    break;
                case 1:
                    m_GridSize = 500;
                    break;
                case 2:
                    m_GridSize = 1000;
                    break;
                case 3:
                    m_GridSize = 2000;
                    break;
            }

            int pointCount = m_GridSize * m_GridSize;

            m_Title.Text = "Fast Bar 3D<br/><font size = '12pt'> Showing Realtime Rendering of " + (m_GridSize * m_GridSize).ToString("#,##0", CultureInfo.InvariantCulture) + " Data Points</font>";

            m_FastBar.BarWidthMode = BarWidthMode.Logical;
            m_FastBar.LogicalBarWidth = 1.0;
            m_FastBar.BarDepthMode = BarDepthMode.Logical;
            m_FastBar.LogicalBarDepth = 1.0;

            m_FastBar.Data.UseXValues = true;
            m_FastBar.Data.UseZValues = true;

            m_FastBar.Data.SetCount(pointCount);
            m_FastBar.EnableShaderRendering = true;
            m_FastBar.Color = new NColorFillStyle(Color.Red);

            m_PulsePoints = new NPulsePoint[m_MaxPulsePoints];

            for (int i = 0; i < m_MaxPulsePoints; i++)
            {
                NPulsePoint pulsePoint = new NPulsePoint();

                pulsePoint.X = m_GridSize * m_Random.NextDouble();
                pulsePoint.Y = m_GridSize * m_Random.NextDouble();
                pulsePoint.Intensity = Math.Max(0.25, m_Random.NextDouble());
                pulsePoint.WaveLength = m_Random.NextDouble() * m_GridSize / 4.0;
                pulsePoint.Phase = m_Random.NextDouble() * Math.PI * 2;
                pulsePoint.PhaseStep = Math.Max(0.2, m_Random.NextDouble()) * Math.PI / 10;
                pulsePoint.PhaseSin = Math.Sin(pulsePoint.Phase);

                m_PulsePoints[i] = pulsePoint;
            }

            unsafe
            {
                int count = m_FastBar.Data.Count;
                int dataItemSize = m_FastBar.Data.DataItemSize;

                fixed (byte* pData = &m_FastBar.Data.Data[0])
                {
                    float* pXValues = (float*)m_FastBar.Data.GetDataChannelPointer(ENSeriesDataChannelName.XValueF, pData);
                    float* pZValues = (float*)m_FastBar.Data.GetDataChannelPointer(ENSeriesDataChannelName.ZValueF, pData);

                    for (int i = 0; i < pointCount; i++)
                    {
                        int row = i / m_GridSize;
                        int col = i % m_GridSize;

                        float x = col;
                        float z = row;

                        *pXValues = x;
                        *pZValues = z;

                        pXValues += dataItemSize;
                        pZValues += dataItemSize;
                    }
                }
            }

            OnTimerTick(null, null);

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
            for (int i = 0; i < m_MaxPulsePoints; i++)
            {
                NPulsePoint pulsePoint = m_PulsePoints[i];

                pulsePoint.Phase += pulsePoint.PhaseStep;
                pulsePoint.PhaseSin = Math.Sin(pulsePoint.Phase);
            }

            // spin the points
            unsafe
            {
                fixed (byte* pData = &m_FastBar.Data.Data[0])
                {
                    int pointCount = m_FastBar.Data.Count;
                    int dataItemSize = m_FastBar.Data.DataItemSize;

                    float* pYValues = (float*)m_FastBar.Data.GetDataChannelPointer(ENSeriesDataChannelName.YValueF, pData);
                    bool useColor = m_FastBar.Data.UseColors;
                    uint* pColor = null;
                    
                    if (useColor)
                    {
                        pColor = (uint*)m_FastBar.Data.GetDataChannelPointer(ENSeriesDataChannelName.Color, pData);
                    }                    

                    NArgbColorValue color1 = new NArgbColorValue(Color.Blue);
                    NArgbColorValue color2 = new NArgbColorValue(Color.Red);
                    const float value1 = -1;
                    const float value2 = 1;
                    float valueDistance = value2 - value1;

                    int r1 = color1.R;
                    int g1 = color1.G;
                    int b1 = color1.B;

                    int rDiff = (color2.R - color1.R);
                    int gDiff = (color2.G - color1.G);
                    int bDiff = (color2.B - color1.B);
                    NPulsePoint[] pulsePoints = m_PulsePoints;

                    for (int i = 0; i < pointCount; i++)
                    {
                        int row = i / m_GridSize;
                        int col = i % m_GridSize;

                        double sum = 0;

                        float x = col;
                        float z = row;

                        for (int j = 0; j < pulsePoints.Length; j++)
                        {
                            NPulsePoint pulsePoint = pulsePoints[j];

                            double dx = pulsePoint.X - row;
                            double dy = pulsePoint.Y - col;

                            double distance = Math.Sqrt(dx * dx + dy * dy);
                            double waveFactor = (distance - (int)(distance / pulsePoint.WaveLength) * pulsePoint.WaveLength) / pulsePoint.WaveLength;
                            waveFactor = m_SinTable[(int)(waveFactor * 360)];

                            // waveFactor = 1.0f;
                            sum += (pulsePoint.Intensity) * waveFactor * pulsePoint.PhaseSin * (1 - Math.Min(1, distance / m_GridSize));
                        }

                        // create a color between coor1 and color 2
                        if (useColor)
                        {
                            float factor = Math.Min(1, Math.Max(0, (*pYValues - value1) / valueDistance));

                            int r = (byte)(r1 + (int)(rDiff * factor));
                            int g = (byte)(g1 + (int)(gDiff * factor));
                            int b = (byte)(b1 + (int)(bDiff * factor));

                            *pColor = (uint)(0xFF000000 | (r << 16) | (g << 8) | b);
                        }

                        *pYValues = Math.Min(2, (float)sum);
                        pYValues += dataItemSize;
                        pColor += dataItemSize;
                    }
                }
            }

            m_FastBar.Data.OnDataChanged();
            nChartControl1.Refresh();
        }

        private void OnPointCountComboSelectedIndexChanged(object sender, EventArgs e)
        {
            AddData();
        }
        private void EnableShaderRenderingCheck_CheckedChanged(object sender, EventArgs e)
        {
            m_FastBar.EnableShaderRendering = EnableShaderRenderingCheck.Checked;
            nChartControl1.Refresh();
        }

        private void EnableLightingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nChartControl1.Charts[0].LightModel.EnableLighting = EnableLightingCheckBox.Checked;
            nChartControl1.Refresh();
        }

        private void UseCustomColorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_FastBar.Data.UseColors = UseCustomColorsCheckBox.Checked;
            nChartControl1.Refresh();
        }
    }
}

