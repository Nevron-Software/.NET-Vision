using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStandardHighLowUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NHScrollBar DepthScroll;
		private Nevron.UI.WinForm.Controls.NCheckBox DropLinesCheck;
		private Nevron.UI.WinForm.Controls.NButton HighAreaFEButton;
		private Nevron.UI.WinForm.Controls.NButton LowAreaFEButton;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton LabelStyleButton;
		private System.ComponentModel.Container components = null;

		public NStandardHighLowUC()
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
			this.HighAreaFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DropLinesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.DepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.LowAreaFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LabelStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// HighAreaFEButton
			// 
			this.HighAreaFEButton.Location = new System.Drawing.Point(8, 87);
			this.HighAreaFEButton.Name = "HighAreaFEButton";
			this.HighAreaFEButton.Size = new System.Drawing.Size(163, 24);
			this.HighAreaFEButton.TabIndex = 41;
			this.HighAreaFEButton.Text = "High Area Fill Style...";
			this.HighAreaFEButton.Click += new System.EventHandler(this.AreaFEButton_Click);
			// 
			// DropLinesCheck
			// 
			this.DropLinesCheck.ButtonProperties.BorderOffset = 2;
			this.DropLinesCheck.Location = new System.Drawing.Point(8, 47);
			this.DropLinesCheck.Name = "DropLinesCheck";
			this.DropLinesCheck.Size = new System.Drawing.Size(163, 23);
			this.DropLinesCheck.TabIndex = 40;
			this.DropLinesCheck.Text = "Drop Lines";
			this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(163, 16);
			this.label3.TabIndex = 33;
			this.label3.Text = "Depth %:";
			// 
			// DepthScroll
			// 
			this.DepthScroll.Location = new System.Drawing.Point(8, 25);
			this.DepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.DepthScroll.Name = "DepthScroll";
			this.DepthScroll.Size = new System.Drawing.Size(163, 16);
			this.DepthScroll.TabIndex = 32;
			this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			// 
			// LowAreaFEButton
			// 
			this.LowAreaFEButton.Location = new System.Drawing.Point(8, 119);
			this.LowAreaFEButton.Name = "LowAreaFEButton";
			this.LowAreaFEButton.Size = new System.Drawing.Size(163, 24);
			this.LowAreaFEButton.TabIndex = 0;
			this.LowAreaFEButton.Text = "Low Area Fill Style...";
			this.LowAreaFEButton.Click += new System.EventHandler(this.LowAreaFEButton_Click);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(8, 147);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(163, 24);
			this.MarkerStyleButton.TabIndex = 52;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// LabelStyleButton
			// 
			this.LabelStyleButton.Location = new System.Drawing.Point(8, 178);
			this.LabelStyleButton.Name = "LabelStyleButton";
			this.LabelStyleButton.Size = new System.Drawing.Size(163, 24);
			this.LabelStyleButton.TabIndex = 53;
			this.LabelStyleButton.Text = "Data Label Style...";
			this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			// 
			// NStandardHighLowUC
			// 
			this.Controls.Add(this.LabelStyleButton);
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.HighAreaFEButton);
			this.Controls.Add(this.DropLinesCheck);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.DepthScroll);
			this.Controls.Add(this.LowAreaFEButton);
			this.Name = "NStandardHighLowUC";
			this.Size = new System.Drawing.Size(180, 229);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D High Low Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			NHighLowSeries highLow = (NHighLowSeries)chart.Series.Add(SeriesType.HighLow);
			highLow.Name = "High-Low Series";
			highLow.HighFillStyle = new NColorFillStyle(GreyBlue);
			highLow.LowFillStyle = new NColorFillStyle(DarkOrange);
			highLow.HighBorderStyle = new NStrokeStyle(GreyBlue);
			highLow.LowBorderStyle = new NStrokeStyle(DarkOrange);
			highLow.Legend.Mode = SeriesLegendMode.SeriesLogic;
			highLow.DataLabelStyle.Visible = false;
			highLow.DataLabelStyle.Format = "<high_value>:<low_value>";
			highLow.LowValues.ValueFormatter = new NNumericValueFormatter("0.#");
			highLow.HighValues.ValueFormatter = new NNumericValueFormatter("0.#");

			GenerateData(highLow);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// init form controls
			DepthScroll.Value = (int)highLow.DepthPercent;
		}

		private void GenerateData(NHighLowSeries highLow)
		{
			highLow.ClearDataPoints();

			for (int i = 0; i < 20; i++)
			{
				double d1 = Math.Log(i + 1) + 0.1 * Random.NextDouble();
				double d2 = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble();

				highLow.HighValues.Add(d1);
				highLow.LowValues.Add(d2);
			}
		}

		private void DepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NHighLowSeries highLow = (NHighLowSeries)nChartControl1.Charts[0].Series[0];
			highLow.DepthPercent = DepthScroll.Value;
			nChartControl1.Refresh();
		}
		private void DropLinesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NHighLowSeries highLow = (NHighLowSeries)nChartControl1.Charts[0].Series[0];
			highLow.DropLines = DropLinesCheck.Checked;
			nChartControl1.Refresh();
		}
		private void AreaFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NHighLowSeries highLow = (NHighLowSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(highLow.HighFillStyle, out fillStyleResult))
			{
				highLow.HighFillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LowAreaFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NHighLowSeries highLow = (NHighLowSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(highLow.LowFillStyle, out fillStyleResult))
			{
				highLow.LowFillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MarkerStyleButton_Click(object sender, System.EventArgs e)
		{
			NMarkerStyle markerStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NMarkerStyleTypeEditor.Edit(series.MarkerStyle, out markerStyleResult))
			{
				series.MarkerStyle = markerStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LabelStyleButton_Click(object sender, System.EventArgs e)
		{
			NDataLabelStyle styleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, out styleResult))
			{
				series.DataLabelStyle = styleResult;
				nChartControl1.Refresh();
			}
		}
	}
}