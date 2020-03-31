using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Chart.WinForm;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Windows;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSampledLine2DUC : NExampleBaseUC
	{
		NLineSeries m_Line;
		NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NButton Add20KDataButton;
		private Nevron.UI.WinForm.Controls.NButton Add40KDataButton;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NHScrollBar SampleDistanceScroll;
		private Nevron.UI.WinForm.Controls.NButton ClearDataButton;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NCheckBox UseXValuesCheckBox;
        private Nevron.UI.WinForm.Controls.NTextBox DataPointCountTextBox;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox GeneratorModeCombo;
		private System.ComponentModel.Container components = null;

		public NSampledLine2DUC()
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
			this.Add20KDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Add40KDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.SampleDistanceScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.ClearDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.UseXValuesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.DataPointCountTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.GeneratorModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// Add20KDataButton
			// 
			this.Add20KDataButton.Location = new System.Drawing.Point(8, 192);
			this.Add20KDataButton.Name = "Add20KDataButton";
			this.Add20KDataButton.Size = new System.Drawing.Size(163, 23);
			this.Add20KDataButton.TabIndex = 5;
			this.Add20KDataButton.Text = "Add 20,000 Data Points";
			this.Add20KDataButton.Click += new System.EventHandler(this.Add20KDataButton_Click);
			// 
			// Add40KDataButton
			// 
			this.Add40KDataButton.Location = new System.Drawing.Point(8, 221);
			this.Add40KDataButton.Name = "Add40KDataButton";
			this.Add40KDataButton.Size = new System.Drawing.Size(163, 23);
			this.Add40KDataButton.TabIndex = 6;
			this.Add40KDataButton.Text = "Add 40,000 Data Points";
			this.Add40KDataButton.Click += new System.EventHandler(this.Add40KDataButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 21);
			this.label2.TabIndex = 0;
			this.label2.Text = "Sample Distance:";
			// 
			// SampleDistanceScroll
			// 
			this.SampleDistanceScroll.LargeChange = 1;
			this.SampleDistanceScroll.Location = new System.Drawing.Point(8, 26);
			this.SampleDistanceScroll.Maximum = 12;
			this.SampleDistanceScroll.Minimum = 1;
			this.SampleDistanceScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.SampleDistanceScroll.Name = "SampleDistanceScroll";
			this.SampleDistanceScroll.Size = new System.Drawing.Size(163, 18);
			this.SampleDistanceScroll.TabIndex = 1;
			this.SampleDistanceScroll.Value = 1;
			this.SampleDistanceScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SampleDistanceScroll_ValueChanged);
			// 
			// ClearDataButton
			// 
			this.ClearDataButton.Location = new System.Drawing.Point(8, 345);
			this.ClearDataButton.Name = "ClearDataButton";
			this.ClearDataButton.Size = new System.Drawing.Size(163, 23);
			this.ClearDataButton.TabIndex = 9;
			this.ClearDataButton.Text = "Clear Data";
			this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 247);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(163, 21);
			this.label1.TabIndex = 7;
			this.label1.Text = "Data Point Count:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// UseXValuesCheckBox
			// 
			this.UseXValuesCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseXValuesCheckBox.Location = new System.Drawing.Point(8, 50);
			this.UseXValuesCheckBox.Name = "UseXValuesCheckBox";
			this.UseXValuesCheckBox.Size = new System.Drawing.Size(169, 24);
			this.UseXValuesCheckBox.TabIndex = 2;
			this.UseXValuesCheckBox.Text = "Use X Values";
			this.UseXValuesCheckBox.CheckedChanged += new System.EventHandler(this.UseXValuesCheckBox_CheckedChanged);
			// 
			// DataPointCountTextBox
			// 
			this.DataPointCountTextBox.Location = new System.Drawing.Point(8, 271);
			this.DataPointCountTextBox.Name = "DataPointCountTextBox";
			this.DataPointCountTextBox.ReadOnly = true;
			this.DataPointCountTextBox.Size = new System.Drawing.Size(163, 18);
			this.DataPointCountTextBox.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 111);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(163, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "Generator Mode:";
			// 
			// GeneratorModeCombo
			// 
			this.GeneratorModeCombo.ListProperties.CheckBoxDataMember = "";
			this.GeneratorModeCombo.ListProperties.DataSource = null;
			this.GeneratorModeCombo.ListProperties.DisplayMember = "";
			this.GeneratorModeCombo.Location = new System.Drawing.Point(8, 132);
			this.GeneratorModeCombo.Name = "GeneratorModeCombo";
			this.GeneratorModeCombo.Size = new System.Drawing.Size(163, 22);
			this.GeneratorModeCombo.TabIndex = 4;
			// 
			// NSampledLine2DUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.GeneratorModeCombo);
			this.Controls.Add(this.DataPointCountTextBox);
			this.Controls.Add(this.UseXValuesCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ClearDataButton);
			this.Controls.Add(this.SampleDistanceScroll);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Add40KDataButton);
			this.Controls.Add(this.Add20KDataButton);
			this.Name = "NSampledLine2DUC";
			this.Size = new System.Drawing.Size(180, 390);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Sampled Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			((NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// add a line series
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Line Series";
			m_Line.InflateMargins = true;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.MarkerStyle.Visible = false;
            m_Line.SamplingMode = SeriesSamplingMode.Enabled;

			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
            m_Line.UseXValues = true;

			SampleDistanceScroll.Value = (int)m_Line.SampleDistance.Value;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			GeneratorModeCombo.Items.Add("Generator 1 (Continous Y)");
			GeneratorModeCombo.Items.Add("Generator 2 (Random Y)");
			GeneratorModeCombo.SelectedIndex = 0;

            UseXValuesCheckBox.Checked = true;

			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.RangeSelections.Add(new NRangeSelection());
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = true;

			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

            Add40KDataButton_Click(null, null);
		}
		private void AddNewData(int count)
        {
			Random rand = new Random();

            double prevYVal = 0;
			double prevXVal = 0;

			int valueCount = m_Line.Values.Count;

			if (valueCount > 0)
			{
				prevYVal = (double)m_Line.Values[valueCount - 1];
				prevXVal = (double)m_Line.XValues[valueCount - 1];
			}

			double[] xValues = new double[count];
			double[] yValues = new double[count];

			double magnitude = 0.01 + rand.NextDouble() * 5;

			if (GeneratorModeCombo.SelectedIndex == 0)
			{
				// continuous
				double angle = 0;
				double phase = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001;

				for (int i = 0; i < count; i++)
				{
					double yStep = Math.Sin(angle) * magnitude;
					double xStep = 0.01 + rand.NextDouble() * magnitude;

					if (xStep < 0)
					{
						xStep = 0;
					}

					angle += phase;
					prevXVal += xStep;

					yValues[i] = prevYVal + yStep;
					xValues[i] = prevXVal;
				}

				m_Line.Values.AddRange(yValues);
				m_Line.XValues.AddRange(xValues);
			}
			else
			{
				// monotone X, random
				for (int i = 0; i < count; i++)
				{
					yValues[i] = rand.NextDouble() * magnitude;
					xValues[i] = prevXVal;
					prevXVal += 1;
				}

				m_Line.Values.AddRange(yValues);
				m_Line.XValues.AddRange(xValues);
			}

			UpdateCounter();

			nChartControl1.Refresh();
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

		private void SampleDistanceScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Line.SampleDistance = new NLength((float)SampleDistanceScroll.Value);
			nChartControl1.Refresh();
		}

        private void Add20KDataButton_Click(object sender, EventArgs e)
        {
            AddNewData(20000);
            UpdateCounter();
        }

        private void Add40KDataButton_Click(object sender, EventArgs e)
        {
            AddNewData(40000);
            UpdateCounter();
        }

        private void ClearDataButton_Click(object sender, EventArgs e)
        {
            m_Line.Values.Clear();
			m_Line.XValues.Clear();
            UpdateCounter();

            nChartControl1.Refresh();
        }

        private void UseXValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Line.UseXValues = UseXValuesCheckBox.Checked;

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
