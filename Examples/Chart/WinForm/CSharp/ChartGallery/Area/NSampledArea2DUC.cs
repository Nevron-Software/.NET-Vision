using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSampledArea2DUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NAreaSeries m_Area;
		private Nevron.UI.WinForm.Controls.NTextBox DataPointCountTextBox;
		private Nevron.UI.WinForm.Controls.NCheckBox UseXValuesCheckBox;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NButton ClearDataButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar SampleDistanceScroll;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NButton Add40KDataButton;
		private Nevron.UI.WinForm.Controls.NButton Add20KDataButton;
		private System.ComponentModel.Container components = null;

        public NSampledArea2DUC()
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
			this.DataPointCountTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.UseXValuesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ClearDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SampleDistanceScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.Add40KDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Add20KDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// DataPointCountTextBox
			// 
			this.DataPointCountTextBox.Location = new System.Drawing.Point(18, 166);
			this.DataPointCountTextBox.Name = "DataPointCountTextBox";
			this.DataPointCountTextBox.ReadOnly = true;
			this.DataPointCountTextBox.Size = new System.Drawing.Size(144, 18);
			this.DataPointCountTextBox.TabIndex = 6;
			// 
			// UseXValuesCheckBox
			// 
			this.UseXValuesCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseXValuesCheckBox.Location = new System.Drawing.Point(21, 50);
			this.UseXValuesCheckBox.Name = "UseXValuesCheckBox";
			this.UseXValuesCheckBox.Size = new System.Drawing.Size(150, 24);
			this.UseXValuesCheckBox.TabIndex = 2;
			this.UseXValuesCheckBox.Text = "Use X Values";
			this.UseXValuesCheckBox.CheckedChanged += new System.EventHandler(this.UseXValuesCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 142);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 21);
			this.label1.TabIndex = 5;
			this.label1.Text = "Data Point Count:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// ClearDataButton
			// 
			this.ClearDataButton.Location = new System.Drawing.Point(18, 240);
			this.ClearDataButton.Name = "ClearDataButton";
			this.ClearDataButton.Size = new System.Drawing.Size(144, 23);
			this.ClearDataButton.TabIndex = 7;
			this.ClearDataButton.Text = "Clear Data";
			this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			// 
			// SampleDistanceScroll
			// 
			this.SampleDistanceScroll.LargeChange = 1;
			this.SampleDistanceScroll.Location = new System.Drawing.Point(21, 26);
			this.SampleDistanceScroll.Maximum = 12;
			this.SampleDistanceScroll.Minimum = 1;
			this.SampleDistanceScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.SampleDistanceScroll.Name = "SampleDistanceScroll";
			this.SampleDistanceScroll.Size = new System.Drawing.Size(144, 18);
			this.SampleDistanceScroll.TabIndex = 1;
			this.SampleDistanceScroll.Value = 1;
			this.SampleDistanceScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SampleDistanceScroll_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(21, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 21);
			this.label2.TabIndex = 0;
			this.label2.Text = "Sample Distance:";
			// 
			// Add40KDataButton
			// 
			this.Add40KDataButton.Location = new System.Drawing.Point(18, 116);
			this.Add40KDataButton.Name = "Add40KDataButton";
			this.Add40KDataButton.Size = new System.Drawing.Size(144, 23);
			this.Add40KDataButton.TabIndex = 4;
			this.Add40KDataButton.Text = "Add 40,000 Data Points";
			this.Add40KDataButton.Click += new System.EventHandler(this.Add40KDataButton_Click);
			// 
			// Add20KDataButton
			// 
			this.Add20KDataButton.Location = new System.Drawing.Point(18, 87);
			this.Add20KDataButton.Name = "Add20KDataButton";
			this.Add20KDataButton.Size = new System.Drawing.Size(144, 23);
			this.Add20KDataButton.TabIndex = 3;
			this.Add20KDataButton.Text = "Add 20,000 Data Points";
			this.Add20KDataButton.Click += new System.EventHandler(this.Add20KDataButton_Click);
			// 
			// NSampledArea2DUC
			// 
			this.Controls.Add(this.DataPointCountTextBox);
			this.Controls.Add(this.UseXValuesCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ClearDataButton);
			this.Controls.Add(this.SampleDistanceScroll);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Add40KDataButton);
			this.Controls.Add(this.Add20KDataButton);
			this.Name = "NSampledArea2DUC";
			this.Size = new System.Drawing.Size(180, 277);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Sampled Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // apply linear scaling to the x axis
			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add the area series
			m_Area = (NAreaSeries)m_Chart.Series.Add(SeriesType.Area);
			m_Area.Name = "Area Series";
            m_Area.DataLabelStyle.Visible = false;
            m_Area.MarkerStyle.Visible = false;
            m_Area.SamplingMode = SeriesSamplingMode.Enabled;
			m_Area.UseXValues = true;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			UseXValuesCheckBox.Checked = true;

			Add40KDataButton_Click(null, null);
		}

		private void AddNewData(int count)
		{
			Random rand = new Random();
			double prevXVal = 0;
			double prevYVal = 0;

			double angle = 0;
			double phase = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001;
			double magnitude = rand.NextDouble() * 5;

			double[] xValues = new double[count];
			double[] yValues = new double[count];

			int valueCount = m_Area.Values.Count;
			if (valueCount > 0)
			{
				prevXVal = (double)m_Area.XValues[valueCount - 1];
				prevYVal = (double)m_Area.Values[valueCount - 1];
			}


			for (int i = 0; i < count; i++)
			{
				double yStep = prevYVal + Math.Sin(angle) * magnitude;
				double xStep = rand.NextDouble() * magnitude;

				if (xStep < 0)
				{
					xStep = 0;
				}

				angle += phase;
				prevXVal += xStep;

				yValues[i] = yStep;
				xValues[i] = prevXVal;
			}

			valueCount = m_Area.Values.Count;
			for (int i = 0; i < valueCount - 1; i++)
			{
				double prevVal = (double)m_Area.XValues[i];
				double nextVal = (double)m_Area.XValues[i + 1];
				Debug.Assert(prevVal <= nextVal);
			}

			m_Area.Values.AddRange(yValues);
			m_Area.XValues.AddRange(xValues);

			UpdateCounter();

			nChartControl1.Refresh();
		}

		private void SampleDistanceScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Area.SampleDistance = new NLength((float)SampleDistanceScroll.Value);
			nChartControl1.Refresh();
		}

		private void UpdateCounter()
		{
			int count = m_Area.Values.Count;
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

		private void Add20KDataButton_Click(object sender, EventArgs e)
		{
			AddNewData(20000);
		}

		private void Add40KDataButton_Click(object sender, EventArgs e)
		{
			AddNewData(40000);
		}

		private void ClearDataButton_Click(object sender, EventArgs e)
		{
			m_Area.Values.Clear();
			UpdateCounter();

			nChartControl1.Refresh();
		}

		private void UseXValuesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Area.UseXValues = UseXValuesCheckBox.Checked;

			if (UseXValuesCheckBox.Checked)
			{
				m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			}
			else
			{
				m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NOrdinalScaleConfigurator();
			}

			nChartControl1.Refresh();
		}
	}
}