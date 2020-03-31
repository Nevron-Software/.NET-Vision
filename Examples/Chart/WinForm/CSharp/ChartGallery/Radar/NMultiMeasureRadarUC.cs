using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NMultiMeasureRadarUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public NMultiMeasureRadarUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
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
			this.SuspendLayout();
			// 
			// NMultiMeasureRadarUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "NMultiMeasureRadarUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Montana County Comparison<br/><font size = '9pt'>Demonstrates how to create a multi measure radar chart</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(0, 5, 0, 5);
			nChartControl1.Panels.Add(title);

			NLegend legend = new NLegend();
			legend.DockMode = PanelDockMode.Right;
			legend.Margins = new NMarginsL(5, 0, 5, 0);
			nChartControl1.Panels.Add(legend);

			// setup chart
			NRadarChart radarChart = new NRadarChart();
			radarChart.Margins = new NMarginsL(5, 0, 0, 5);
			nChartControl1.Panels.Add(radarChart);
			radarChart.DisplayOnLegend = legend;
			radarChart.DockMode = PanelDockMode.Fill;
			radarChart.RadarMode = RadarMode.MultiMeasure;
			radarChart.InnerRadius = new NLength(10, NRelativeUnit.ParentPercentage);

			// set some axis labels
			AddAxis(radarChart, "Population", true);
			AddAxis(radarChart, "Housing Units", true);
			AddAxis(radarChart, "Water", false);
			AddAxis(radarChart, "Land", true);
			AddAxis(radarChart, "Population\r\nDensity", false);
			AddAxis(radarChart, "Housing\r\nDensity", false);

			// sample data
			object[] data = new object[]{ 
				"Cascade County", 80357, 35225, 13.75, 2697.90, 29.8, 13.1,
				"Custer County", 11696, 5360, 10.09, 3783.13, 3.1, 1.4,
				"Dawson County", 9059, 4168, 9.99, 2373.14, 3.8, 1.8,
				"Jefferson County", 10049, 4199, 2.19, 1656.64, 6.1, 2.5,
				"Missoula County", 95802, 41319, 20.37, 2597.97, 36.9, 15.9,
				"Powell County", 7180, 2930, 6.74, 2325.94, 3.1, 1.3 };

			for (int i = 0; i < 6; i++)
			{
				NRadarLineSeries radarLine = new NRadarLineSeries();
				radarChart.Series.Add(radarLine);

				int baseIndex = i * 7;
				radarLine.Name = data[baseIndex].ToString();
				baseIndex = baseIndex + 1;

				for (int j = 0; j < 6; j++)
				{
					radarLine.Values.Add(System.Convert.ToDouble(data[baseIndex]));
					baseIndex = baseIndex + 1;
				}

				radarLine.DataLabelStyle.Visible = false;
				radarLine.MarkerStyle.Width = new NLength(4);
				radarLine.MarkerStyle.Height = new NLength(4);
				radarLine.MarkerStyle.Visible = true;
				radarLine.BorderStyle.Width = new NLength(2);
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);
		}

		private void AddAxis(NRadarChart radar, string title, bool applyKFormatting)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;
			radar.Axes.Add(axis);

			if (applyKFormatting)
			{
				NLinearScaleConfigurator linearScale = axis.ScaleConfigurator as NLinearScaleConfigurator;
				linearScale.LabelValueFormatter = new NNumericValueFormatter("0,K");
			}
		}
	}
}
