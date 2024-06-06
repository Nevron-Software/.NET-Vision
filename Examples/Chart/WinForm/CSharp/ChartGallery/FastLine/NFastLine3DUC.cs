using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.GraphicsCore.Nurbs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
    public class NFastLine3DUC : NExampleBaseUC
    {
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Nevron.UI.WinForm.Controls.NButton StartStopTimerButton;
        private UI.WinForm.Controls.NComboBox PointCountComboBox;
        private System.ComponentModel.IContainer components = null;

        Random m_Random = new Random();
        NLabel m_Title;
        private UI.WinForm.Controls.NCheckBox EnableShaderRenderingCheck;
        private UI.WinForm.Controls.NComboBox SeriesCountComboBox;
        private Label label1;

        class NNurbsCurveInfo
        {
            /// <summary>
            /// Initiailizer constructor
            /// </summary>
            /// <param name="curve"></param>
            /// <param name="controlPointDirections"></param>
            public NNurbsCurveInfo(NNurbsCurve curve, NVector3DD[] controlPointDirections)
            {
                Curve = curve;
                ControlPointDirections = controlPointDirections;
            }

            public NNurbsCurve Curve;
            public NVector3DD[] ControlPointDirections;
        }
   
        public NFastLine3DUC()
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.EnableShaderRenderingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.PointCountComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
            this.SeriesCountComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Point Count:";
            // 
            // EnableShaderRenderingCheck
            // 
            this.EnableShaderRenderingCheck.ButtonProperties.BorderOffset = 2;
            this.EnableShaderRenderingCheck.Location = new System.Drawing.Point(12, 126);
            this.EnableShaderRenderingCheck.Name = "EnableShaderRenderingCheck";
            this.EnableShaderRenderingCheck.Size = new System.Drawing.Size(260, 21);
            this.EnableShaderRenderingCheck.TabIndex = 4;
            this.EnableShaderRenderingCheck.Text = "Enable Shader Rendering";
            this.EnableShaderRenderingCheck.CheckedChanged += new System.EventHandler(this.EnableShaderRenderingCheck_CheckedChanged);
            // 
            // PointCountComboBox
            // 
            this.PointCountComboBox.ListProperties.CheckBoxDataMember = "";
            this.PointCountComboBox.ListProperties.DataSource = null;
            this.PointCountComboBox.ListProperties.DisplayMember = "";
            this.PointCountComboBox.Location = new System.Drawing.Point(12, 82);
            this.PointCountComboBox.Name = "PointCountComboBox";
            this.PointCountComboBox.Size = new System.Drawing.Size(260, 21);
            this.PointCountComboBox.TabIndex = 3;
            this.PointCountComboBox.SelectedIndexChanged += new System.EventHandler(this.OnPointCountComboSelectedIndexChanged);
            // 
            // StartStopTimerButton
            // 
            this.StartStopTimerButton.Location = new System.Drawing.Point(12, 193);
            this.StartStopTimerButton.Name = "StartStopTimerButton";
            this.StartStopTimerButton.Size = new System.Drawing.Size(260, 21);
            this.StartStopTimerButton.TabIndex = 6;
            this.StartStopTimerButton.Text = "Stop Timer Button";
            this.StartStopTimerButton.UseVisualStyleBackColor = true;
            this.StartStopTimerButton.Click += new System.EventHandler(this.OnStartStopTimerButtonClick);
            // 
            // SeriesCountComboBox
            // 
            this.SeriesCountComboBox.ListProperties.CheckBoxDataMember = "";
            this.SeriesCountComboBox.ListProperties.DataSource = null;
            this.SeriesCountComboBox.ListProperties.DisplayMember = "";
            this.SeriesCountComboBox.Location = new System.Drawing.Point(12, 30);
            this.SeriesCountComboBox.Name = "SeriesCountComboBox";
            this.SeriesCountComboBox.Size = new System.Drawing.Size(260, 21);
            this.SeriesCountComboBox.TabIndex = 1;
            this.SeriesCountComboBox.SelectedIndexChanged += new System.EventHandler(this.SeriesCountComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Series Count:";
            // 
            // NFastLine3DUC
            // 
            this.Controls.Add(this.SeriesCountComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnableShaderRenderingCheck);
            this.Controls.Add(this.PointCountComboBox);
            this.Controls.Add(this.StartStopTimerButton);
            this.Controls.Add(this.label2);
            this.Name = "NFastLine3DUC";
            this.Size = new System.Drawing.Size(286, 564);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            // set a chart title
            // set a chart title
            m_Title = new NLabel("Fast Line 3D");
            m_Title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            m_Title.TextStyle.TextFormat = TextFormat.XML;

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Height = 50;
            chart.Depth = 50;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight);

            ConfigureLinearScale(chart.Axis((int)StandardAxis.PrimaryX));
            ConfigureLinearScale(chart.Axis((int)StandardAxis.PrimaryY));
            ConfigureLinearScale(chart.Axis((int)StandardAxis.Depth));

            AddSeries();

            // apply layout
            ConfigureStandardLayout(chart, m_Title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
            nChartControl1.Controller.Tools.Add(new NTrackballTool());

            PointCountComboBox.Items.Add("1000");
            PointCountComboBox.Items.Add("5000");
            PointCountComboBox.Items.Add("10000");
            PointCountComboBox.Items.Add("20000");
            PointCountComboBox.SelectedIndex = 0;

            EnableShaderRenderingCheck.Checked = true;

            SeriesCountComboBox.Items.Add(10);
            SeriesCountComboBox.Items.Add(100);
            SeriesCountComboBox.Items.Add(500);
            SeriesCountComboBox.SelectedIndex = 0;

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

            axis.View = new NRangeAxisView(new NRange1DD(-220, 220), true, true);
            scale.ViewRangeInflateMode = ScaleViewRangeInflateMode.MajorTickExtend;
            scale.RoundToTickMax = true;
            scale.RoundToTickMin = true;

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
        private int GetSeriesCount()
        {
            switch (SeriesCountComboBox.SelectedIndex)
            {
                case 0:
                    return 10;
                case 1:
                    return 100;
                case 2:
                    return 500;
            }

            return 0;
        }

        private int GetPointCount()
        {
            switch (PointCountComboBox.SelectedIndex)
            {
                case 0:
                    return 1000;
                case 1:
                    return 5000;
                case 2:
                    return 10000;
                case 3:
                    return 20000;
            }

            return 0;
        }

        private void AddSeries()
        {
            int seriesCount = GetSeriesCount();

            NChart chart = nChartControl1.Charts[0];
            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Bright);

            // setup the fast line series
            for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
            {
                NFastLineSeries fastLineSeries = (NFastLineSeries)chart.Series.Add(SeriesType.FastLine);

                fastLineSeries.Legend.Mode = SeriesLegendMode.None;
                fastLineSeries.Name = "Fast Line Series";
                fastLineSeries.Data.UseXValues = true;
                fastLineSeries.Data.UseZValues = true;
                // fastLineSeries.Data.UseColors = true;
                fastLineSeries.StrokeStyle.Color = palette.SeriesColors[seriesIndex % palette.SeriesColors.Count];

                int controlPointCount = 20;
                const int degree = 3;
                NVector4DD[] controlPoints = new NVector4DD[controlPointCount];
                List<double> knotsList = new List<double>();
                NVector3DD[] controlPointDirections = new NVector3DD[controlPointCount];

                for (int i = 0; i <= degree; i++)
                {
                    knotsList.Add(0);
                }
                
                for (int i = 0, j = 20; i < j; i++)
                {
                    controlPoints[i] = new NVector4DD(
                            m_Random.NextDouble() * 400 - 200,
                            m_Random.NextDouble() * 400 - 200,
                            m_Random.NextDouble() * 400 - 200,
                            1 // weight of control point: higher means stronger attraction
                        );

                    controlPointDirections[i] = new NVector3DD(
                            m_Random.NextDouble() * 4,
                            m_Random.NextDouble() * 4,
                            m_Random.NextDouble() * 4
                        );

                    double knot = (i + 1) / (double)(j - degree);
                    knotsList.Add(Math.Max(0, Math.Min(1, knot)));
                }

                double[] knots = knotsList.ToArray();
                fastLineSeries.Tag = new NNurbsCurveInfo(new NNurbsCurve(degree, knots, controlPoints), controlPointDirections);
            }
        }
        /// <summary>
        /// Adds random data to the chart
        /// </summary>
        private void AddData()
        {
            int pointCount = GetPointCount();

            m_Title.Text = "Fast Line 3D<br/><font size = '12pt'> Showing Realtime Rendering of " + (GetSeriesCount() * pointCount).ToString("#,##0", CultureInfo.InvariantCulture) + " Data Points</font>";

            unsafe
            {
                NChart chart = nChartControl1.Charts[0];

                for (int i = 0; i < chart.Series.Count; i++)
                {
                    NFastLineSeries fastLine = chart.Series[i] as NFastLineSeries;

                    if (fastLine == null)
                        continue;

                    int dataItemSize = fastLine.Data.DataItemSize;
                    fastLine.Data.SetCount(pointCount);
                    fastLine.EnableShaderRendering = true;

                    NNurbsCurveInfo nurbsCurveInfo = (NNurbsCurveInfo)fastLine.Tag;
                    NNurbsCurve nurbsCurve = nurbsCurveInfo.Curve;
                    NVector3DD[] controlPointDirections = nurbsCurveInfo.ControlPointDirections;
                    NVector4DD[] controlPoints = nurbsCurve.ControlPoints;

                    for (int j = 0; j < controlPoints.Length; j++)
                    {
                        controlPoints[j].X += controlPointDirections[j].X;
                        controlPoints[j].Y += controlPointDirections[j].Y;
                        controlPoints[j].Z += controlPointDirections[j].Z;

                        // invert x, y or z direction if points start to go out of bounds
                        if (controlPoints[j].X > 200)
                        {
                            controlPointDirections[j].X = -Math.Abs(controlPointDirections[j].X);
                        }
                        if (controlPoints[j].X < -200)
                        {
                            controlPointDirections[j].X = Math.Abs(controlPointDirections[j].X);
                        }

                        if (controlPoints[j].Y > 200)
                        {
                            controlPointDirections[j].Y = -Math.Abs(controlPointDirections[j].Y);
                        }
                        if (controlPoints[j].Y < -200)
                        {
                            controlPointDirections[j].Y = Math.Abs(controlPointDirections[j].Y);
                        }

                        if (controlPoints[j].Z > 200)
                        {
                            controlPointDirections[j].Z = -Math.Abs(controlPointDirections[j].Z);
                        }
                        if (controlPoints[j].Z < -200)
                        {
                            controlPointDirections[j].Z = Math.Abs(controlPointDirections[j].Z);
                        }
                    }

                    fixed (byte* pData = &fastLine.Data.Data[0])
                    {
                        float* pXValues = (float*)fastLine.Data.GetDataChannelPointer(ENSeriesDataChannelName.XValueF, pData);
                        float* pYValues = (float*)fastLine.Data.GetDataChannelPointer(ENSeriesDataChannelName.YValueF, pData);
                        float* pZValues = (float*)fastLine.Data.GetDataChannelPointer(ENSeriesDataChannelName.ZValueF, pData);

                        for (int j = 0; j < pointCount; j++)
                        {
                            NVector4DD vec = nurbsCurve.GetValue(j / (double)pointCount);

                            *pXValues = (float)vec.X;
                            *pYValues = (float)vec.Y;
                            *pZValues = (float)vec.Z;

                            pXValues += dataItemSize;
                            pYValues += dataItemSize;
                            pZValues += dataItemSize;
                        }
                    }

                    fastLine.Data.OnDataChanged();
                }
            }

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
            AddData();
        }

        private void OnPointCountComboSelectedIndexChanged(object sender, EventArgs e)
        {
            AddData();
        }
        private void EnableShaderRenderingCheck_CheckedChanged(object sender, EventArgs e)
        {
            NChart chart = nChartControl1.Charts[0];

            for (int i = 0; i < chart.Series.Count; i++)
            {
                NFastLineSeries fastLine = chart.Series[i] as NFastLineSeries;

                if (fastLine != null)
                {
                    fastLine.EnableShaderRendering = EnableShaderRenderingCheck.Checked;
                }
            }

            nChartControl1.Refresh();
        }

        private void SeriesCountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddSeries();
        }
    }
}

