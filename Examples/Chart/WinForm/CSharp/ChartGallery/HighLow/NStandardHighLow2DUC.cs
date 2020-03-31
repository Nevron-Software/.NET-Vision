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
	public class NStandardHighLow2DUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NHighLowSeries m_HighLow;
		private Nevron.UI.WinForm.Controls.NCheckBox DropLinesCheck;
		private Nevron.UI.WinForm.Controls.NButton HighAreaFEButton;
		private Nevron.UI.WinForm.Controls.NButton LowAreaFEButton;
		private Nevron.UI.WinForm.Controls.NButton ShadowButton;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton LabelStyleButton;
		private System.ComponentModel.Container components = null;

		public NStandardHighLow2DUC()
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
			}
			base.Dispose(disposing);
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
			this.LowAreaFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LabelStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// HighAreaFEButton
			// 
			this.HighAreaFEButton.Location = new System.Drawing.Point(9, 9);
			this.HighAreaFEButton.Name = "HighAreaFEButton";
			this.HighAreaFEButton.Size = new System.Drawing.Size(161, 24);
			this.HighAreaFEButton.TabIndex = 41;
			this.HighAreaFEButton.Text = "High Area Fill Style...";
			this.HighAreaFEButton.Click += new System.EventHandler(this.AreaFEButton_Click);
			// 
			// DropLinesCheck
			// 
			this.DropLinesCheck.ButtonProperties.BorderOffset = 2;
			this.DropLinesCheck.Location = new System.Drawing.Point(9, 166);
			this.DropLinesCheck.Name = "DropLinesCheck";
			this.DropLinesCheck.Size = new System.Drawing.Size(161, 21);
			this.DropLinesCheck.TabIndex = 40;
			this.DropLinesCheck.Text = "Drop Lines";
			this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			// 
			// LowAreaFEButton
			// 
			this.LowAreaFEButton.Location = new System.Drawing.Point(9, 40);
			this.LowAreaFEButton.Name = "LowAreaFEButton";
			this.LowAreaFEButton.Size = new System.Drawing.Size(161, 24);
			this.LowAreaFEButton.TabIndex = 0;
			this.LowAreaFEButton.Text = "Low Area Fill Style...";
			this.LowAreaFEButton.Click += new System.EventHandler(this.LowAreaFEButton_Click);
			// 
			// ShadowButton
			// 
			this.ShadowButton.Location = new System.Drawing.Point(9, 71);
			this.ShadowButton.Name = "ShadowButton";
			this.ShadowButton.Size = new System.Drawing.Size(161, 24);
			this.ShadowButton.TabIndex = 50;
			this.ShadowButton.Text = "Shadow ...";
			this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(9, 102);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(161, 24);
			this.MarkerStyleButton.TabIndex = 51;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// LabelStyleButton
			// 
			this.LabelStyleButton.Location = new System.Drawing.Point(9, 133);
			this.LabelStyleButton.Name = "LabelStyleButton";
			this.LabelStyleButton.Size = new System.Drawing.Size(161, 24);
			this.LabelStyleButton.TabIndex = 52;
			this.LabelStyleButton.Text = "Data Label Style...";
			this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			// 
			// NStandardHighLow2DUC
			// 
			this.Controls.Add(this.LabelStyleButton);
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.ShadowButton);
			this.Controls.Add(this.HighAreaFEButton);
			this.Controls.Add(this.DropLinesCheck);
			this.Controls.Add(this.LowAreaFEButton);
			this.Name = "NStandardHighLow2DUC";
			this.Size = new System.Drawing.Size(180, 270);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D High Low Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add a High-Low series
			m_HighLow = (NHighLowSeries)m_Chart.Series.Add(SeriesType.HighLow);
			m_HighLow.Name = "High-Low Series";
			m_HighLow.Legend.Mode = SeriesLegendMode.SeriesLogic;
			m_HighLow.HighFillStyle = new NColorFillStyle(GreyBlue);
			m_HighLow.LowFillStyle = new NColorFillStyle(DarkOrange);
			m_HighLow.DataLabelStyle.Visible = false;
			m_HighLow.DataLabelStyle.Format = "<high_value>:<low_value>";
			m_HighLow.LowValues.ValueFormatter = new NNumericValueFormatter("0.#");
			m_HighLow.HighValues.ValueFormatter = new NNumericValueFormatter("0.#");

			GenerateData();

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);
		}

		private void GenerateData()
		{
			m_HighLow.ClearDataPoints();

			for (int i = 0; i < 20; i++)
			{
				double d1 = Math.Log(i + 1) + 0.1 * Random.NextDouble();
				double d2 = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble();

				m_HighLow.HighValues.Add(d1);
				m_HighLow.LowValues.Add(d2);
			}
		}

		private void AreaFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_HighLow.HighFillStyle, out fillStyleResult))
			{
				m_HighLow.HighFillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LowAreaFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_HighLow.LowFillStyle, out fillStyleResult))
			{
				m_HighLow.LowFillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void ShadowButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;

			if (NShadowStyleTypeEditor.Edit(m_HighLow.ShadowStyle, out shadowStyleResult))
			{
				m_HighLow.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MarkerStyleButton_Click(object sender, System.EventArgs e)
		{
			NMarkerStyle markerStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NMarkerStyleTypeEditor.Edit(series.MarkerStyle, out markerStyleResult))
			{
				series.MarkerStyle = markerStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LabelStyleButton_Click(object sender, System.EventArgs e)
		{
			NDataLabelStyle styleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, out styleResult))
			{
				series.DataLabelStyle = styleResult;
				nChartControl1.Refresh();
			}
		}
		private void DropLinesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_HighLow.DropLines = DropLinesCheck.Checked;
			nChartControl1.Refresh();
		}
	}
}