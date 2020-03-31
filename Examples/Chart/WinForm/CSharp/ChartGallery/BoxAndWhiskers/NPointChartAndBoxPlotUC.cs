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
	public class NPointChartAndBoxPlotUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox ShowAverageCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowOutliersCheck;
		private System.ComponentModel.Container components = null;

		public NPointChartAndBoxPlotUC()
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
			this.ShowAverageCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowOutliersCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ShowAverageCheck
			// 
			this.ShowAverageCheck.ButtonProperties.BorderOffset = 2;
			this.ShowAverageCheck.Location = new System.Drawing.Point(9, 8);
			this.ShowAverageCheck.Name = "ShowAverageCheck";
			this.ShowAverageCheck.Size = new System.Drawing.Size(144, 21);
			this.ShowAverageCheck.TabIndex = 0;
			this.ShowAverageCheck.Text = "Show Average";
			this.ShowAverageCheck.CheckedChanged += new System.EventHandler(this.ShowAverageCheck_CheckedChanged);
			// 
			// ShowOutliersCheck
			// 
			this.ShowOutliersCheck.ButtonProperties.BorderOffset = 2;
			this.ShowOutliersCheck.Location = new System.Drawing.Point(9, 32);
			this.ShowOutliersCheck.Name = "ShowOutliersCheck";
			this.ShowOutliersCheck.Size = new System.Drawing.Size(144, 21);
			this.ShowOutliersCheck.TabIndex = 1;
			this.ShowOutliersCheck.Text = "Show Outliers";
			this.ShowOutliersCheck.CheckedChanged += new System.EventHandler(this.ShowOutliersCheck_CheckedChanged);
			// 
			// NPointChartAndBoxPlotUC
			// 
			this.Controls.Add(this.ShowOutliersCheck);
			this.Controls.Add(this.ShowAverageCheck);
			this.Name = "NPointChartAndBoxPlotUC";
			this.Size = new System.Drawing.Size(180, 129);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// create a guide line to align the chart bottoms
			NSideGuideline bottomChartGuideline = new NSideGuideline(PanelSide.Bottom);
			nChartControl1.Document.RootPanel.Guidelines.Add(bottomChartGuideline);
            
			// top panel
			NDockPanel topPanel = new NDockPanel();
			topPanel.DockMode = PanelDockMode.Top;
			topPanel.Size = new NSizeL(new NLength(0), new NLength(20, NRelativeUnit.ParentPercentage));

			// bottom panel
			NDockPanel bottomPanel = new NDockPanel();
			bottomPanel.DockMode = PanelDockMode.Bottom;
			bottomPanel.Size = new NSizeL(new NLength(0), new NLength(20, NRelativeUnit.ParentPercentage));

			// center panel
			NDockPanel centerPanel = new NDockPanel();
			centerPanel.DockMode = PanelDockMode.Fill;

			// left panel
			NDockPanel leftPanel = new NDockPanel();
			leftPanel.DockMode = PanelDockMode.Left;
			leftPanel.Size = new NSizeL(new NLength(40.0f, NGraphicsUnit.Point), new NLength(0));

			// right panel
			NDockPanel rightPanel = new NDockPanel();
			rightPanel.DockMode = PanelDockMode.Right;
			rightPanel.Size = new NSizeL(new NLength(40.0f, NGraphicsUnit.Point), new NLength(0));

			// middle panel
			NDockPanel middlePanel = new NDockPanel();
			middlePanel.DockMode = PanelDockMode.Right;
			middlePanel.Size = new NSizeL(new NLength(10.0f, NGraphicsUnit.Point), new NLength(0));

			// right chart panel
			NDockPanel rightChartPanel = new NDockPanel();
			rightChartPanel.Size = new NSizeL(new NLength(10.0f, NRelativeUnit.ParentPercentage), new NLength(0));
			rightChartPanel.DockMode = PanelDockMode.Right;

			// left chart panel
			NDockPanel leftChartPanel = new NDockPanel();
			leftChartPanel.Size = new NSizeL(new NLength(10.0f, NRelativeUnit.ParentPercentage), new NLength(0));
			leftChartPanel.DockMode = PanelDockMode.Fill;

			// chart title
			NLabel title = new NLabel("Data Distribution");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.DockMode = PanelDockMode.Top;
			title.Padding = new NMarginsL(5, 8, 5, 4);

			// create point chart
			NChart pointChart = new NCartesianChart();
			pointChart.BoundsMode = BoundsMode.Stretch;
			pointChart.DockMode = PanelDockMode.Fill; 
			bottomChartGuideline.Targets.Add(pointChart);

			// create box and whiskers chart
			NChart boxChart = new NCartesianChart();
			boxChart.BoundsMode = BoundsMode.Stretch;
			boxChart.DockMode = PanelDockMode.Fill;
			bottomChartGuideline.Targets.Add(boxChart);

			// arrange panels
			nChartControl1.Panels.Add(topPanel);
			nChartControl1.Panels.Add(bottomPanel);
			nChartControl1.Panels.Add(centerPanel);

			centerPanel.ChildPanels.Add(rightPanel);
			centerPanel.ChildPanels.Add(rightChartPanel);
			centerPanel.ChildPanels.Add(middlePanel);
			centerPanel.ChildPanels.Add(leftPanel);
			centerPanel.ChildPanels.Add(leftChartPanel);

			topPanel.ChildPanels.Add(title);
			leftChartPanel.ChildPanels.Add(pointChart);
			rightChartPanel.ChildPanels.Add(boxChart);

			SetupCharts(pointChart, boxChart);

			ShowAverageCheck.Checked = true;
			ShowOutliersCheck.Checked = true;
		}

		private void SetupCharts(NChart pointChart, NChart boxChart)
		{
			// data
			double[] arrValues = {	204.5, 190.6, 199.7, 131.8, 143.4,
									215.1, 228.0, 209.2, 183.8, 169.5,
									212.0, 254.9, 222.3, 201.0, 215.4,
									191.3, 181.5, 207.0, 199.0, 210.0 };

			// setup point chart
			NStandardScaleConfigurator scaleConfigurator;
			scaleConfigurator = pointChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;
			scaleConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);

			scaleConfigurator = pointChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NStandardScaleConfigurator;
			scaleConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);

			// setup point series
			NPointSeries point = (NPointSeries)pointChart.Series.Add(SeriesType.Point);
			point.InflateMargins = true;
			point.DataLabelStyle.Visible = false;
			point.Size = new NLength(10, NGraphicsUnit.Point);
			point.PointShape = PointShape.Ellipse;
			point.FillStyle = new NColorFillStyle(Color.Yellow);
			point.BorderStyle = new NStrokeStyle(GreyBlue);
			point.Values.AddRange(arrValues);

			// setup box and whiskers chart
			boxChart.Width = 10;
			boxChart.Axis(StandardAxis.PrimaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, false);
			boxChart.Axis(StandardAxis.PrimaryX).Visible = false;

			// setup box and whiskers series
			NBoxAndWhiskersSeries boxSeries = (NBoxAndWhiskersSeries)boxChart.Series.Add(SeriesType.BoxAndWhiskers);
			boxSeries.InflateMargins = true;
			boxSeries.DataLabelStyle.Visible = false;
			boxSeries.FillStyle = new NColorFillStyle(DarkOrange);
			boxSeries.OutliersSize = new NLength(3, NGraphicsUnit.Point);

			// create a box and whiskers data point and initialize it from the point series
			NBoxAndWhiskersDataPoint bwdp = new NBoxAndWhiskersDataPoint(point.Values, true, true);
			boxSeries.AddDataPoint(bwdp);

			// synchronize axes
			NAxis axis1 = pointChart.Axis(StandardAxis.PrimaryY);
			NAxis axis2 = boxChart.Axis(StandardAxis.PrimaryY);
			axis1.Slaves.Add(axis2);
			axis2.Slaves.Add(axis1);

			// set an axis stripe for the interquartile range
			double dQ1 = (double)bwdp[DataPointValue.LowerBoxValue];
			double dQ3 = (double)bwdp[DataPointValue.UpperBoxValue];

			NAxisStripe boxStripe = axis1.Stripes.Add(dQ1, dQ3);
			boxStripe.FillStyle = new NColorFillStyle(Color.FromArgb(150, LightGreen));

			// set an axis stripe for the min / max range
			double dMin = (double)bwdp[DataPointValue.LowerWhiskerValue];
			double dMax = (double)bwdp[DataPointValue.UpperWhiskerValue];
			NAxisStripe whiskersStripe = axis1.Stripes.Add(dMin, dMax);
			whiskersStripe.FillStyle = new NColorFillStyle(Color.FromArgb(70, LightGreen));
		}

		void UpdateBoxAndWhiskers()
		{
			NChart pointChart = nChartControl1.Charts[0];
			NChart boxChart = nChartControl1.Charts[1];

			NPointSeries pointSeries = (NPointSeries)pointChart.Series[0];
			NBoxAndWhiskersSeries boxSeries = (NBoxAndWhiskersSeries)boxChart.Series[0];

			bool showAverage = ShowAverageCheck.Checked;
			bool showOutliers = ShowOutliersCheck.Checked;

			NBoxAndWhiskersDataPoint bwdp = new NBoxAndWhiskersDataPoint(pointSeries.Values, showAverage, showOutliers);
			boxSeries.ClearDataPoints();
			boxSeries.AddDataPoint(bwdp);
		}


		private void ShowAverageCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateBoxAndWhiskers();

			nChartControl1.Refresh();
		}

		private void ShowOutliersCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateBoxAndWhiskers();

			nChartControl1.Refresh();
		}
	}
}