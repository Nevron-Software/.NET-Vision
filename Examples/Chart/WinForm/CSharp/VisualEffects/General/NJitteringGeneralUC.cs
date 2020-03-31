using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NJitteringGeneralUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableJitteringCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NNumericUpDown JitteringDeviationUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox JitteringStepsComboBox;
		private System.ComponentModel.Container components = null;

		public NJitteringGeneralUC()
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
			this.EnableJitteringCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.JitteringDeviationUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.JitteringStepsComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			((System.ComponentModel.ISupportInitialize)(this.JitteringDeviationUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// EnableJitteringCheckBox
			// 
			this.EnableJitteringCheckBox.Location = new System.Drawing.Point(11, 12);
			this.EnableJitteringCheckBox.Name = "EnableJitteringCheckBox";
			this.EnableJitteringCheckBox.Size = new System.Drawing.Size(120, 21);
			this.EnableJitteringCheckBox.TabIndex = 0;
			this.EnableJitteringCheckBox.Text = "Enable jittering";
			this.EnableJitteringCheckBox.CheckedChanged += new System.EventHandler(this.EnableJitteringCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Jittering steps:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 3;
			this.label6.Text = "Jittering deviation:";
			// 
			// JitteringDeviationUpDown
			// 
			this.JitteringDeviationUpDown.DecimalPlaces = 1;
			this.JitteringDeviationUpDown.Increment = new System.Decimal(new int[] {
																					   1,
																					   0,
																					   0,
																					   65536});
			this.JitteringDeviationUpDown.Location = new System.Drawing.Point(11, 124);
			this.JitteringDeviationUpDown.Name = "JitteringDeviationUpDown";
			this.JitteringDeviationUpDown.Size = new System.Drawing.Size(110, 20);
			this.JitteringDeviationUpDown.TabIndex = 4;
			this.JitteringDeviationUpDown.ValueChanged += new System.EventHandler(this.JitteringDeviationUpDown_ValueChanged);
			// 
			// JitteringStepsComboBox
			// 
			this.JitteringStepsComboBox.Location = new System.Drawing.Point(11, 66);
			this.JitteringStepsComboBox.Name = "JitteringStepsComboBox";
			this.JitteringStepsComboBox.Size = new System.Drawing.Size(110, 21);
			this.JitteringStepsComboBox.TabIndex = 2;
			this.JitteringStepsComboBox.SelectedIndexChanged += new System.EventHandler(this.JitteringStepsComboBox_SelectedIndexChanged);
			// 
			// JitteringGeneralUC
			// 
			this.Controls.Add(this.JitteringStepsComboBox);
			this.Controls.Add(this.JitteringDeviationUpDown);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EnableJitteringCheckBox);
			this.Name = "JitteringGeneralUC";
			this.Size = new System.Drawing.Size(175, 183);
			((System.ComponentModel.ISupportInitialize)(this.JitteringDeviationUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Jittering / Blur Effect");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Depth = 34;
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
			m_Chart.Projection.Type = ProjectionType.Perspective;
			m_Chart.Projection.Elevation = 17;
			m_Chart.Projection.Rotation = -10;

			Color c = Color.FromArgb(128, 128, 192);
			m_Chart.Wall(ChartWallType.Left).FillStyle = new NGradientFillStyle(GradientStyle.DiagonalDown, GradientVariant.Variant3, c, Color.White);
			m_Chart.Wall(ChartWallType.Floor).FillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, c, Color.White);
			m_Chart.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(GradientStyle.DiagonalDown, GradientVariant.Variant3, c, Color.White);

			NBubbleSeries bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			bubble.InflateMargins = false;
			bubble.DataLabelStyle.Visible = false;
			bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			bubble.BubbleShape = PointShape.Sphere;

			bubble.AddDataPoint(new NBubbleDataPoint(10, 10, "B1", new NColorFillStyle(Color.DarkGoldenrod)));
			bubble.AddDataPoint(new NBubbleDataPoint(15, 20, "B2", new NColorFillStyle(Color.IndianRed)));
			bubble.AddDataPoint(new NBubbleDataPoint(12, 25, "B3", new NColorFillStyle(Color.DarkMagenta)));
			bubble.AddDataPoint(new NBubbleDataPoint(8, 15, "B4", new NColorFillStyle(Color.DarkOrchid)));

			NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.Name = "Stack 1";
			bar.DataLabelStyle.Visible = false;
			bar.BarShape = BarShape.Cylinder;
			bar.WidthPercent = 60;
			bar.DepthPercent = 60;
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			bar.Values.FillRandomRange(Random, 4, 5, 15);

			bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.MultiBarMode = MultiBarMode.Stacked;
			bar.Name = "Stack 2";
			bar.DataLabelStyle.Visible = false;
			bar.BarShape = BarShape.Cylinder;
			bar.WidthPercent = 60;
			bar.DepthPercent = 60;
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.FillStyle = new NColorFillStyle(Color.Yellow);
			bar.Values.FillRandomRange(Random, 4, 5, 15);

			bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.MultiBarMode = MultiBarMode.Stacked;
			bar.Name = "Stack 3";
			bar.DataLabelStyle.Visible = false;
			bar.BarShape = BarShape.Cylinder;
			bar.WidthPercent = 60;
			bar.DepthPercent = 60;
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.FillStyle = new NColorFillStyle(Color.MediumSeaGreen);
			bar.Values.FillRandomRange(Random, 4, 5, 15);

			// init form controls
			for(int i = 2; i < 17; i++)
			{
				JitteringStepsComboBox.Items.Add(i.ToString());
			}

			JitteringStepsComboBox.SelectedIndex = nChartControl1.Settings.JitteringSteps - 2;
			JitteringDeviationUpDown.Value = (decimal)nChartControl1.Settings.JitteringDeviation;
			JitteringStepsComboBox.Enabled = false;
			JitteringDeviationUpDown.Enabled = false;
			EnableJitteringCheckBox.Checked = false;
		}

		private void EnableJitteringCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			JitteringStepsComboBox.Enabled = EnableJitteringCheckBox.Checked;
			JitteringDeviationUpDown.Enabled = EnableJitteringCheckBox.Checked;

            nChartControl1.Settings.JitterMode = EnableJitteringCheckBox.Checked ? JitterMode.Enabled : JitterMode.Disabled;

			if (EnableJitteringCheckBox.Checked)
			{
				nChartControl1.Settings.JitteringSteps = JitteringStepsComboBox.SelectedIndex + 2;
				nChartControl1.Settings.JitteringDeviation = (float)JitteringDeviationUpDown.Value;
			}

			nChartControl1.Refresh();
		}

		private void JitteringStepsComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EnableJitteringCheckBox.Checked)
			{
				nChartControl1.Settings.JitteringSteps = JitteringStepsComboBox.SelectedIndex + 2;
				nChartControl1.Settings.JitteringDeviation = Decimal.ToSingle(JitteringDeviationUpDown.Value);

				nChartControl1.Refresh();
			}		
		}

		private void JitteringDeviationUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (EnableJitteringCheckBox.Checked)
			{
				nChartControl1.Settings.JitteringSteps = JitteringStepsComboBox.SelectedIndex + 2;
				nChartControl1.Settings.JitteringDeviation = Decimal.ToSingle(JitteringDeviationUpDown.Value);

				nChartControl1.Refresh();
			}			
		}
	}
}
