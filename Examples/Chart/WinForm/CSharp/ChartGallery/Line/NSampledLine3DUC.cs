using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSampledLine3DUC : NExampleBaseUC
	{
		NLineSeries m_Line;
		private Nevron.UI.WinForm.Controls.NHScrollBar SampleDistanceScroll;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NTextBox DataPointCountTextBox;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NButton ClearDataButton;
		private Nevron.UI.WinForm.Controls.NButton Add40KDataButton;
		private Nevron.UI.WinForm.Controls.NButton Add20KDataButton;
		private System.ComponentModel.Container components = null;

		public NSampledLine3DUC()
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
			this.SampleDistanceScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.DataPointCountTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ClearDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Add40KDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Add20KDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// SampleDistanceScroll
			// 
			this.SampleDistanceScroll.LargeChange = 1;
			this.SampleDistanceScroll.Location = new System.Drawing.Point(6, 30);
			this.SampleDistanceScroll.Maximum = 12;
			this.SampleDistanceScroll.Minimum = 1;
			this.SampleDistanceScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.SampleDistanceScroll.Name = "SampleDistanceScroll";
			this.SampleDistanceScroll.Size = new System.Drawing.Size(168, 18);
			this.SampleDistanceScroll.TabIndex = 16;
			this.SampleDistanceScroll.Value = 1;
			this.SampleDistanceScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SampleDistanceScroll_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 21);
			this.label2.TabIndex = 17;
			this.label2.Text = "Sample Distance:";
			// 
			// DataPointCountTextBox
			// 
			this.DataPointCountTextBox.Location = new System.Drawing.Point(6, 174);
			this.DataPointCountTextBox.Name = "DataPointCountTextBox";
			this.DataPointCountTextBox.ReadOnly = true;
			this.DataPointCountTextBox.Size = new System.Drawing.Size(168, 18);
			this.DataPointCountTextBox.TabIndex = 21;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 150);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 21);
			this.label1.TabIndex = 20;
			this.label1.Text = "Data Point Count:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// ClearDataButton
			// 
			this.ClearDataButton.Location = new System.Drawing.Point(6, 248);
			this.ClearDataButton.Name = "ClearDataButton";
			this.ClearDataButton.Size = new System.Drawing.Size(168, 23);
			this.ClearDataButton.TabIndex = 22;
			this.ClearDataButton.Text = "Clear Data";
			this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			// 
			// Add40KDataButton
			// 
			this.Add40KDataButton.Location = new System.Drawing.Point(6, 124);
			this.Add40KDataButton.Name = "Add40KDataButton";
			this.Add40KDataButton.Size = new System.Drawing.Size(168, 23);
			this.Add40KDataButton.TabIndex = 19;
			this.Add40KDataButton.Text = "Add 40,000 Data Points";
			this.Add40KDataButton.Click += new System.EventHandler(this.Add40KDataButton_Click);
			// 
			// Add20KDataButton
			// 
			this.Add20KDataButton.Location = new System.Drawing.Point(6, 95);
			this.Add20KDataButton.Name = "Add20KDataButton";
			this.Add20KDataButton.Size = new System.Drawing.Size(168, 23);
			this.Add20KDataButton.TabIndex = 18;
			this.Add20KDataButton.Text = "Add 20,000 Data Points";
			this.Add20KDataButton.Click += new System.EventHandler(this.Add20KDataButton_Click);
			// 
			// NSampledLine3DUC
			// 
			this.Controls.Add(this.DataPointCountTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ClearDataButton);
			this.Controls.Add(this.Add40KDataButton);
			this.Controls.Add(this.Add20KDataButton);
			this.Controls.Add(this.SampleDistanceScroll);
			this.Controls.Add(this.label2);
			this.Name = "NSampledLine3DUC";
			this.Size = new System.Drawing.Size(180, 322);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Sampled Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70;
			chart.Height = 70;
			chart.Depth = 70;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = new NLinearScaleConfigurator();

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// add a line series
			m_Line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Line Series";
			m_Line.InflateMargins = true;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.MarkerStyle.Visible = false;
			m_Line.UseXValues = true;
			m_Line.UseZValues = true;
            m_Line.SamplingMode = SeriesSamplingMode.Enabled;


			SampleDistanceScroll.Value = (int)m_Line.SampleDistance.Value;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			Add20KDataButton_Click(null, null);
		}

		private void UpdateCounter()
		{
			int count = m_Line.Values.Count;
			DataPointCountTextBox.Text = (count / 1000).ToString() + "K";

			if (count > 1000000)
			{
				Add20KDataButton.Enabled = false;
				Add40KDataButton.Enabled = false;
			}
			else
			{
				Add20KDataButton.Enabled = true;
				Add40KDataButton.Enabled = true;
			}
		}


		private void AddNewData(int count)
		{
			Random rand = new Random();
			double prevYVal = 0;
			double prevXVal = 0;
			double prevZVal = 0;

			double angle = 0;
			double phase = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001;
			double magnitude = rand.NextDouble() * 5;

			double[] xValues = new double[count];
			double[] yValues = new double[count];
			double[] zValues = new double[count];

			int valueCount = m_Line.Values.Count;
			if (valueCount > 0)
			{
				prevYVal = (double)m_Line.Values[valueCount - 1];
				prevXVal = (double)m_Line.XValues[valueCount - 1];
				prevZVal = (double)m_Line.ZValues[valueCount - 1];
			}

			for (int i = 0; i < count; i++)
			{
				double yStep = Math.Cos(angle) + Math.Sin(angle) * magnitude;
				double xStep = Math.Cos(angle) * magnitude;
				double zStep = Math.Sin(angle) * magnitude;

				if (xStep < 0)
				{
					xStep = 0;
				}

				angle += phase;

				yValues[i] = prevYVal + yStep;
				xValues[i] = prevXVal + xStep;
				zValues[i] = prevZVal + zStep;

				prevXVal = xValues[i];
				prevYVal = yValues[i];
				prevZVal = zValues[i];
			}

			m_Line.Values.AddRange(yValues);
			m_Line.XValues.AddRange(xValues);
			m_Line.ZValues.AddRange(zValues);

			UpdateCounter();

			nChartControl1.Refresh();
		}

		private void SampleDistanceScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Line.SampleDistance = new NLength((float)SampleDistanceScroll.Value);
			nChartControl1.Refresh();
		}

		private void Add20KDataButton_Click(object sender, EventArgs e)
		{
			AddNewData(20000);
		}

		private void Add40KDataButton_Click(object sender, EventArgs e)
		{
			AddNewData(20000);
		}

		private void ClearDataButton_Click(object sender, EventArgs e)
		{
			m_Line.Values.Clear();
			m_Line.XValues.Clear();
			m_Line.ZValues.Clear();

			UpdateCounter();

			nChartControl1.Refresh();
		}
	}
}
