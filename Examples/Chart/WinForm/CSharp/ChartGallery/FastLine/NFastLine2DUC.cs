using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
    public class NFastLine2DUC : NExampleBaseUC
    {
        private Label label2;
        private Timer timer1;
        private Nevron.UI.WinForm.Controls.NButton StartStopTimerButton;
        private UI.WinForm.Controls.NComboBox PointCountPerChannelComboBox;
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Represents the state of the channel, this class is used to store additional information about the
        /// channel and to generate some random data
        /// </summary>
        [Serializable]
        class NChannelInfo
        {
            /// <summary>
            /// Initializer constructor
            /// </summary>
            /// <param name="minColor"></param>
            /// <param name="maxColor"></param>
            /// <param name="addRandom"></param>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <param name="cycleCount"></param>
            public NChannelInfo(Color color, bool addRandom, float min, float max, int cycleCount)
            {
                AddRandom = addRandom;

                MinValue = min;
                MaxValue = max;
                CycleCount = cycleCount;

                MaxColor = color;
                MinColor = Color.FromArgb((int)(color.R * 0.2), (int)(color.G * 0.2), (int)(color.B * 0.2));
            }
            /// <summary>
            /// Resets the state of the channel
            /// </summary>
            public void Reset()
            {
                Phase = 0;
                CurrentPointIndex = 0;
                CurrentXValue = 0;
            }

            public readonly bool AddRandom;
            public readonly float MinValue;
            public readonly float MaxValue;
            public float Phase;
            public readonly Color MinColor;
            public readonly Color MaxColor;

            public int CurrentPointIndex;
            public int CurrentXValue;
            public readonly int CycleCount;
        };

        Random m_Random = new Random();
        int m_MaxPointCount;

        NLabel m_Title;
        private UI.WinForm.Controls.NCheckBox EnableShaderRenderingCheck;
        private UI.WinForm.Controls.NCheckBox UseCustomColorsCheckBox;

        public NFastLine2DUC()
        {
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
                if (timer1 != null)
                {
                    timer1.Stop();
                    timer1.Tick -= new EventHandler(OnTimerTick);
                    timer1.Dispose();
                }
            }
            base.Dispose(disposing);
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
            this.PointCountPerChannelComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.EnableShaderRenderingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.UseCustomColorsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Point Count per Channel:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // StartStopTimerButton
            // 
            this.StartStopTimerButton.Location = new System.Drawing.Point(14, 185);
            this.StartStopTimerButton.Name = "StartStopTimerButton";
            this.StartStopTimerButton.Size = new System.Drawing.Size(248, 21);
            this.StartStopTimerButton.TabIndex = 5;
            this.StartStopTimerButton.Text = "Stop Timer Button";
            this.StartStopTimerButton.UseVisualStyleBackColor = true;
            this.StartStopTimerButton.Click += new System.EventHandler(this.OnStartStopTimerButtonClick);
            // 
            // PointCountPerChannelComboBox
            // 
            this.PointCountPerChannelComboBox.ListProperties.CheckBoxDataMember = "";
            this.PointCountPerChannelComboBox.ListProperties.DataSource = null;
            this.PointCountPerChannelComboBox.ListProperties.DisplayMember = "";
            this.PointCountPerChannelComboBox.Location = new System.Drawing.Point(14, 35);
            this.PointCountPerChannelComboBox.Name = "PointCountPerChannelComboBox";
            this.PointCountPerChannelComboBox.Size = new System.Drawing.Size(248, 21);
            this.PointCountPerChannelComboBox.TabIndex = 1;
            this.PointCountPerChannelComboBox.SelectedIndexChanged += new System.EventHandler(this.OnPointCountPerChannelComboBoxSelectedIndexChanged);
            // 
            // EnableShaderRenderingCheck
            // 
            this.EnableShaderRenderingCheck.ButtonProperties.BorderOffset = 2;
            this.EnableShaderRenderingCheck.Location = new System.Drawing.Point(14, 67);
            this.EnableShaderRenderingCheck.Name = "EnableShaderRenderingCheck";
            this.EnableShaderRenderingCheck.Size = new System.Drawing.Size(248, 21);
            this.EnableShaderRenderingCheck.TabIndex = 2;
            this.EnableShaderRenderingCheck.Text = "Enable Shader Rendering";
            this.EnableShaderRenderingCheck.CheckedChanged += new System.EventHandler(this.EnableShaderRenderingCheck_CheckedChanged);
            // 
            // UseCustomColorsCheckBox
            // 
            this.UseCustomColorsCheckBox.ButtonProperties.BorderOffset = 2;
            this.UseCustomColorsCheckBox.Location = new System.Drawing.Point(14, 88);
            this.UseCustomColorsCheckBox.Name = "UseCustomColorsCheckBox";
            this.UseCustomColorsCheckBox.Size = new System.Drawing.Size(248, 21);
            this.UseCustomColorsCheckBox.TabIndex = 4;
            this.UseCustomColorsCheckBox.Text = "Use Custom Colors";
            this.UseCustomColorsCheckBox.CheckedChanged += new System.EventHandler(this.UseCustomColorsCheckBox_CheckedChanged);
            // 
            // NFastLine2DUC
            // 
            this.Controls.Add(this.UseCustomColorsCheckBox);
            this.Controls.Add(this.EnableShaderRenderingCheck);
            this.Controls.Add(this.PointCountPerChannelComboBox);
            this.Controls.Add(this.StartStopTimerButton);
            this.Controls.Add(this.label2);
            this.Name = "NFastLine2DUC";
            this.Size = new System.Drawing.Size(282, 564);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public override void Initialize()
        {
            base.Initialize();

            // configure the chart
            nChartControl1.Panels.Clear();

            // set a chart title
            m_Title = new NLabel("Fast Line 2D");
            m_Title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            m_Title.TextStyle.TextFormat = TextFormat.XML;
            m_Title.DockMode = PanelDockMode.Top;
            m_Title.Margins = new NMarginsL(0, 20, 0, 20);

            nChartControl1.Document.RootPanel.ChildPanels.Add(m_Title);

            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Bright);

            // setup the fast line series
            NChart[] charts = new NChart[] {    CreateChart(new NChannelInfo[] { new NChannelInfo(palette.SeriesColors[0], true, 50, 200, 14), new NChannelInfo(palette.SeriesColors[1], false, 100, 400, 10) }),
                                                            CreateChart(new NChannelInfo[] { new NChannelInfo(palette.SeriesColors[2], true, 100, 300, 13), new NChannelInfo(palette.SeriesColors[3], false, 50, 140, 15) }),
                                                            CreateChart(new NChannelInfo[] { new NChannelInfo(palette.SeriesColors[4], true, 100, 200, 17), new NChannelInfo(palette.SeriesColors[5], false, 0, 100, 8) }) };

            float chartPercentage = 100 / charts.Length;
            float chartBegin = 0;

            NDockPanel chartsPanel = new NDockPanel();
            chartsPanel.DockMode = PanelDockMode.Fill;
            chartsPanel.Margins = new NMarginsL(20);
            nChartControl1.Panels.Add(chartsPanel);

            for (int i = 0; i < charts.Length; i++)
            {
                NChart chart = charts[i];

                chartsPanel.ChildPanels.Add(chart);

                chart.Location = new NPointL(new NLength(0), new NLength(chartBegin, NRelativeUnit.ParentPercentage));
                chart.Size = new NSizeL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(chartPercentage, NRelativeUnit.ParentPercentage));
                chart.Margins = new NMarginsL(20, 0, 20, 20);

                chartBegin += chartPercentage;
            }

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            PointCountPerChannelComboBox.Items.Add("10000");
            PointCountPerChannelComboBox.Items.Add("20000");
            PointCountPerChannelComboBox.Items.Add("50000");
            PointCountPerChannelComboBox.Items.Add("100000");
            PointCountPerChannelComboBox.SelectedIndex = 0;

            EnableShaderRenderingCheck.Checked = true;
            UseCustomColorsCheckBox.Checked = true;

            timer1.Start();

            nChartControl1.Settings.RenderSurface = RenderSurface.Window;
        }
        /// <summary>
        /// Creates a chart
        /// </summary>
        /// <param name="channelInfos"></param>
        /// <returns></returns>
        private NCartesianChart CreateChart(NChannelInfo[] channelInfos)
        {
            NCartesianChart chart = new NCartesianChart();
            chart.BoundsMode = BoundsMode.Stretch;
            chart.Fit2DAxisContentMode = Fit2DAxisContentMode.LabelsHeight;

            // hide the x/y axes, we're going to use custom axes
            NCartesianAxis axisX = (NCartesianAxis)chart.Axis(StandardAxis.PrimaryX);
            ConfigureLinearScale(axisX);

            NLinearScaleConfigurator scaleX = (NLinearScaleConfigurator)axisX.ScaleConfigurator;
            scaleX.RoundToTickMax = false;
            scaleX.RoundToTickMin = false;

            NCartesianAxis axisY = (NCartesianAxis)chart.Axis(StandardAxis.PrimaryY);
            ConfigureLinearScale(axisY);

            for (int i = 0; i < channelInfos.Length; i++)
            {
                NChannelInfo channelInfo = channelInfos[i];
                NFastLineSeries fastLine = new NFastLineSeries();

                fastLine.DataPointOriginIndex = 0;

                fastLine.Data.UseXValues = true;

                fastLine.Tag = channelInfo;

                chart.Series.Add(fastLine);
            }

            return chart;
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

            stripStyle.Interlaced = false;
            scale.StripStyles.Add(stripStyle);

            axis.ScaleConfigurator = scale;
        }
        /// <summary>
        /// Adds random data to the chart
        /// </summary>
        private void AddData()
        {
            unsafe
            {
                for (int i = 0; i < nChartControl1.Charts.Count; i++)
                {
                    NChart chart = nChartControl1.Charts[i];

                    for (int j = 0; j < chart.Series.Count; j++)
                    {
                        NFastLineSeries fastLine = chart.Series[j] as NFastLineSeries;
                        AddSeriesData(fastLine);
                    }
                }
            }

            nChartControl1.Refresh();
        }
        /// <summary>
        /// Adds data per channel
        /// </summary>
        /// <param name="fastLineSeries"></param>
        private void AddSeriesData(NFastLineSeries fastLineSeries)
        {
            NChannelInfo channelInfo = (NChannelInfo)fastLineSeries.Tag;

            // spin the points
            unsafe
            {
                // always set the count before pinning the data as it may get resized and 
                // this will lead to code that corrupts memory
                int pointCountPerTick = m_MaxPointCount / 100;

                int currentPointCount = fastLineSeries.Data.Count;
                currentPointCount = Math.Min(m_MaxPointCount, currentPointCount + pointCountPerTick);

                fastLineSeries.Data.SetCount(currentPointCount);

                fixed (byte* pData = &fastLineSeries.Data.Data[0])
                {
                    int dataItemSize = fastLineSeries.Data.DataItemSize;

                    NArgbColorValue minColor = new NArgbColorValue(channelInfo.MinColor);
                    NArgbColorValue maxColor = new NArgbColorValue(channelInfo.MaxColor);
                    float orgValueDistance = channelInfo.MaxValue - channelInfo.MinValue;
                    float randomDistance = 0;
                    float valueDistance = orgValueDistance;

                    if (channelInfo.AddRandom)
                    {
                        randomDistance = (channelInfo.CycleCount * valueDistance) / m_MaxPointCount;
                        valueDistance /= 4;
                    }

                    float randomNoise = valueDistance / 2;

                    int r1 = minColor.R;
                    int g1 = minColor.G;
                    int b1 = minColor.B;

                    int rDiff = (maxColor.R - minColor.R);
                    int gDiff = (maxColor.G - minColor.G);
                    int bDiff = (maxColor.B - minColor.B);

                    float minValue = channelInfo.MinValue;
                    float maxValue = channelInfo.MaxValue;

                    float cycleCount = m_MaxPointCount / 10.0f;
                    bool directionPositive = true;
                    bool useColor = fastLineSeries.Data.UseColors;

                    int currentPointIndex = channelInfo.CurrentPointIndex;
                    int currentXValue = channelInfo.CurrentXValue;
                    
                    if ((currentPointIndex + pointCountPerTick) > m_MaxPointCount)
                    {
                        // the data point origin index
                        fastLineSeries.DataPointOriginIndex = (currentPointIndex + pointCountPerTick) % m_MaxPointCount;
                    }

                    float* pYValuesOrg = (float*)fastLineSeries.Data.GetDataChannelPointer(ENSeriesDataChannelName.YValueF, pData, 0);
                    float* pXValuesOrg = (float*)fastLineSeries.Data.GetDataChannelPointer(ENSeriesDataChannelName.XValueF, pData, 0);
                    uint* pColorOrg = null;
                    uint* pColor = null;
                    if (useColor)
                    {
                        pColorOrg = (uint*)fastLineSeries.Data.GetDataChannelPointer(ENSeriesDataChannelName.Color, pData, 0);
                    }

                    for (int currentPoint = 0; currentPoint < pointCountPerTick; currentPoint++)
                    {
                        int pointIndex = currentPointIndex % m_MaxPointCount;

                        float* pYValues = pYValuesOrg + pointIndex * dataItemSize; 
                        float* pXValues = pXValuesOrg + pointIndex * dataItemSize;
                        if (useColor)
                        {
                            pColor = pColorOrg + pointIndex * dataItemSize;
                        }

                        // calculate value
                        float phase = ((currentPointIndex % cycleCount) / cycleCount) * NMath.PI2 + channelInfo.Phase;
                        float value = minValue + (float)Math.Sin(phase) * valueDistance;

                        if (channelInfo.AddRandom)
                        {
                            if (directionPositive)
                            {
                                minValue += (float)m_Random.NextDouble() * randomDistance;
                            }
                            else
                            {
                                minValue -= (float)m_Random.NextDouble() * randomDistance;
                            }
                        }

                        value += (float)(randomNoise * (0.5 - m_Random.NextDouble()));

                        if (value > channelInfo.MaxValue)
                        {
                            directionPositive = false;
                        }
                        else if (value < channelInfo.MinValue)
                        {
                            directionPositive = true;
                        }

                        *pYValues = value;
                        *pXValues = currentXValue;

                        // calculate color
                        if (useColor)
                        {
                            float factor = Math.Min(1, Math.Max(0, (value - channelInfo.MinValue) / orgValueDistance));

                            uint r = (byte)(r1 + (int)(rDiff * factor));
                            uint g = (byte)(g1 + (int)(gDiff * factor));
                            uint b = (byte)(b1 + (int)(bDiff * factor));

                            *pColor = 0xFF000000 | (r << 16) | (g << 8) | b;
                            pColor += dataItemSize;
                        }

                        currentPointIndex++;
                        currentXValue++;
                    }

                    channelInfo.CurrentPointIndex = currentPointIndex;
                    channelInfo.CurrentXValue = currentXValue;
                }
            }

            fastLineSeries.Data.OnDataChanged();
        }
        /// <summary>
        /// 
        /// </summary>
        private void ResetData()
        {
            for (int i = 0; i < nChartControl1.Charts.Count; i++)
            {
                NChart chart = nChartControl1.Charts[i];

                for (int j = 0; j < chart.Series.Count; j++)
                {
                    NFastLineSeries fastLine = chart.Series[j] as NFastLineSeries;

                    if (fastLine != null)
                    {
                        fastLine.DataPointOriginIndex = 0;
                        fastLine.Data.UseColors = UseCustomColorsCheckBox.Checked;
                        fastLine.Data.SetCount(0);
                        ((NChannelInfo)fastLine.Tag).Reset();
                    }
                }
            }

            nChartControl1.Refresh();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            AddData();
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
        private void EnableShaderRenderingCheck_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < nChartControl1.Charts.Count; i++)
            {
                NChart chart = nChartControl1.Charts[i];

                for (int j = 0; j < chart.Series.Count; j++)
                {
                    NFastLineSeries fastLine = chart.Series[j] as NFastLineSeries;

                    if (fastLine != null)
                    {
                        fastLine.EnableShaderRendering = EnableShaderRenderingCheck.Checked;
                    }
                }
            }

            nChartControl1.Refresh();
        }
        private void UseCustomColorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ResetData();
        }

        private void OnPointCountPerChannelComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (PointCountPerChannelComboBox.SelectedIndex)
            {
                case 0:
                    m_MaxPointCount = 10000;
                    break;
                case 1:
                    m_MaxPointCount = 20000;
                    break;
                case 2:
                    m_MaxPointCount = 50000;
                    break;
                case 3:
                    m_MaxPointCount = 100000;
                    break;
                default:
                    m_MaxPointCount = 0;
                    break;
            }

            ResetData();

            m_Title.Text = "Fast Line 2D<br/><font size = '12pt'> Showing Realtime Rendering of " + (m_MaxPointCount * 6).ToString("#,##0", CultureInfo.InvariantCulture) + " Data Points in 6 Channels</font>";
            nChartControl1.Refresh();
        }
    }
}

