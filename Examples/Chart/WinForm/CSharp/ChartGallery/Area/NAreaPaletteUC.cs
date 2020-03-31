using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Dom;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAreaPaletteUC : NExampleBaseUC
	{
		private NChart m_Chart;
        NAreaSeries m_Area;
        double[] m_IndicatorPhase;
		NRange1DD m_AxisRange;
        private Timer timer1;
		private UI.WinForm.Controls.NCheckBox InvertAxisCheckBox;
		private UI.WinForm.Controls.NCheckBox SmoothPaletteCheckBox;
		private UI.WinForm.Controls.NButton StartStopTimerButton;
        private UI.WinForm.Controls.NCheckBox Enable3DCheckBox;
		private IContainer components;

		public NAreaPaletteUC()
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.InvertAxisCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SmoothPaletteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
            this.Enable3DCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InvertAxisCheckBox
            // 
            this.InvertAxisCheckBox.ButtonProperties.BorderOffset = 2;
            this.InvertAxisCheckBox.ButtonProperties.ShowFocusRect = false;
            this.InvertAxisCheckBox.ButtonProperties.WrapText = true;
            this.InvertAxisCheckBox.Location = new System.Drawing.Point(9, 12);
            this.InvertAxisCheckBox.Name = "InvertAxisCheckBox";
            this.InvertAxisCheckBox.Size = new System.Drawing.Size(139, 18);
            this.InvertAxisCheckBox.TabIndex = 2;
            this.InvertAxisCheckBox.Text = "Invert Axis";
            this.InvertAxisCheckBox.CheckedChanged += new System.EventHandler(this.InvertAxisCheckBox_CheckedChanged);
            // 
            // SmoothPaletteCheckBox
            // 
            this.SmoothPaletteCheckBox.ButtonProperties.BorderOffset = 2;
            this.SmoothPaletteCheckBox.ButtonProperties.ShowFocusRect = false;
            this.SmoothPaletteCheckBox.ButtonProperties.WrapText = true;
            this.SmoothPaletteCheckBox.Location = new System.Drawing.Point(9, 34);
            this.SmoothPaletteCheckBox.Name = "SmoothPaletteCheckBox";
            this.SmoothPaletteCheckBox.Size = new System.Drawing.Size(139, 18);
            this.SmoothPaletteCheckBox.TabIndex = 3;
            this.SmoothPaletteCheckBox.Text = "Smooth Palette";
            this.SmoothPaletteCheckBox.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheckBox_CheckedChanged);
            // 
            // StartStopTimerButton
            // 
            this.StartStopTimerButton.Location = new System.Drawing.Point(9, 91);
            this.StartStopTimerButton.Name = "StartStopTimerButton";
            this.StartStopTimerButton.Size = new System.Drawing.Size(152, 32);
            this.StartStopTimerButton.TabIndex = 5;
            this.StartStopTimerButton.Text = "Stop Timer";
            this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
            // 
            // Enable3DCheckBox
            // 
            this.Enable3DCheckBox.ButtonProperties.BorderOffset = 2;
            this.Enable3DCheckBox.ButtonProperties.ShowFocusRect = false;
            this.Enable3DCheckBox.ButtonProperties.WrapText = true;
            this.Enable3DCheckBox.Location = new System.Drawing.Point(9, 56);
            this.Enable3DCheckBox.Name = "Enable3DCheckBox";
            this.Enable3DCheckBox.Size = new System.Drawing.Size(139, 18);
            this.Enable3DCheckBox.TabIndex = 4;
            this.Enable3DCheckBox.Text = "Enable 3D";
            this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
            // 
            // NAreaPaletteUC
            // 
            this.Controls.Add(this.Enable3DCheckBox);
            this.Controls.Add(this.StartStopTimerButton);
            this.Controls.Add(this.SmoothPaletteCheckBox);
            this.Controls.Add(this.InvertAxisCheckBox);
            this.Name = "NAreaPaletteUC";
            this.Size = new System.Drawing.Size(170, 358);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Area Palette");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NAxis yAxis = m_Chart.Axis(StandardAxis.PrimaryY);
            NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle strip = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            strip.Interlaced = true;
            //linearScale.Strips.Add(strip);

            // setup a area series
            m_Area = new NAreaSeries();
            m_Area.InflateMargins = true;
            m_Area.DataLabelStyle.Visible = false;
            m_Area.BorderStyle.Width = new NLength(0);
            m_Area.Legend.Mode = SeriesLegendMode.None;

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(60, Color.Yellow);
            palette.Add(120, Color.Red);

			m_Area.Palette = palette;

            m_AxisRange = new NRange1DD(0, 130);

            // limit the axis range to 0, 130
            yAxis.View = new NRangeAxisView(m_AxisRange, true, true);
            m_Chart.Series.Add(m_Area);

            int indicatorCount = 10;
            m_IndicatorPhase = new double[indicatorCount];

            // add some data to the area series
            for (int i = 0; i < indicatorCount; i++)
            {
                m_IndicatorPhase[i] = i * 30;
                m_Area.Values.Add(0);
            }

			SmoothPaletteCheckBox.Checked = true;

			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Random random = new Random();

			for (int i = 0; i < m_Area.Values.Count; i++)
			{
				double value = (m_AxisRange.Begin + m_AxisRange.End) / 2.0 + Math.Sin(m_IndicatorPhase[i] * NMath.Degree2Rad) * m_AxisRange.GetLength() / 2 + random.Next(20);
				value = m_AxisRange.GetValueInRange(value);

				m_Area.Values[i] = value;
				m_IndicatorPhase[i] += 10;
			}

			nChartControl1.Refresh();
		}

		private void StartStopTimerButton_Click(object sender, EventArgs e)
		{
			if (StartStopTimerButton.Text.StartsWith("Stop"))
			{
				StartStopTimerButton.Text = "Start Timer";
				timer1.Stop();
			}
			else
			{
				timer1.Start();
				StartStopTimerButton.Text = "Stop Timer";
			}
		}

		private void SmoothPaletteCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Area.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void InvertAxisCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisCheckBox.Checked;
			nChartControl1.Refresh();
		}

        private void Enable3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Chart.Enable3D = Enable3DCheckBox.Checked;
            nChartControl1.Refresh();
        }
	}
}
