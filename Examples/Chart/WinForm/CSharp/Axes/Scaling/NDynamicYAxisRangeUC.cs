using System;
using System.Resources;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Collections;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Windows;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NDynamicYAxisRangeUC : NExampleBaseUC
	{
		private Label label2;
		private UI.WinForm.Controls.NComboBox ChartTypeComboBox;
		private System.ComponentModel.Container components = null;

		public NDynamicYAxisRangeUC()
		{
			// This call is required by the Windows.Forms Form Designer.
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
			this.label2 = new System.Windows.Forms.Label();
			this.ChartTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Chart Type:";
			// 
			// ChartTypeComboBox
			// 
			this.ChartTypeComboBox.ListProperties.CheckBoxDataMember = "";
			this.ChartTypeComboBox.ListProperties.DataSource = null;
			this.ChartTypeComboBox.ListProperties.DisplayMember = "";
			this.ChartTypeComboBox.Location = new System.Drawing.Point(13, 30);
			this.ChartTypeComboBox.Name = "ChartTypeComboBox";
			this.ChartTypeComboBox.Size = new System.Drawing.Size(153, 21);
			this.ChartTypeComboBox.TabIndex = 3;
			this.ChartTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartTypeComboBox_SelectedIndexChanged);
			// 
			// NDynamicYAxisRangeUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ChartTypeComboBox);
			this.Name = "NDynamicYAxisRangeUC";
			this.Size = new System.Drawing.Size(205, 304);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Dynamic Y Axis Range");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];

			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;

			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rangeSelection);

			ChartTypeComboBox.Items.Add("Area");
			ChartTypeComboBox.Items.Add("Bar");
			ChartTypeComboBox.Items.Add("Box And Whiskers");
			ChartTypeComboBox.Items.Add("Error Bar");
			ChartTypeComboBox.Items.Add("Float Bar");
			ChartTypeComboBox.Items.Add("Line");
			ChartTypeComboBox.Items.Add("Point");
			ChartTypeComboBox.Items.Add("Stock");

			ChartTypeComboBox.SelectedIndex = 0;

			// enable interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());
		}

		private void ChartTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Series.Clear();
			const int numDataPoints = 50;

			switch (ChartTypeComboBox.SelectedIndex)
			{
				case 0: // Area
					{
						NAreaSeries area = new NAreaSeries();
						area.DataLabelStyle.Visible = false;
						area.VerticalAxisRangeMode = AxisRangeMode.ViewRange;

						GenerateData(area, 100.0, numDataPoints, new NRange1DD(60, 140));
						chart.Series.Add(area);
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NValueTimelineScaleConfigurator();
					}
					break;
				case 1:	// Bar
					{
						NBarSeries bar = new NBarSeries();
						bar.DataLabelStyle.Visible = false;
						bar.VerticalAxisRangeMode = AxisRangeMode.ViewRange;

						GenerateData(bar, 100.0, numDataPoints, new NRange1DD(60, 140));
						chart.Series.Add(bar);
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NValueTimelineScaleConfigurator();
					}
					break;
				case 2: // Box And Whiskers
					{
						NBoxAndWhiskersSeries boxAndWhiskers = new NBoxAndWhiskersSeries();
						boxAndWhiskers.VerticalAxisRangeMode = AxisRangeMode.ViewRange;

						for (int i = 0; i < 40; i++)
						{
							double boxLower = 1000 + Random.NextDouble() * 200;
							double boxUpper = boxLower + 200 + Random.NextDouble() * 200;
							double whiskersLower = boxLower - (20 + Random.NextDouble() * 300);
							double whiskersUpper = boxUpper + (20 + Random.NextDouble() * 300);

							double IQR = (boxUpper - boxLower);
							double median = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5;
							double average = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5;

							boxAndWhiskers.UpperBoxValues.Add(boxUpper);
							boxAndWhiskers.LowerBoxValues.Add(boxLower);
							boxAndWhiskers.UpperWhiskerValues.Add(whiskersUpper);
							boxAndWhiskers.LowerWhiskerValues.Add(whiskersLower);
							boxAndWhiskers.MedianValues.Add(median);
							boxAndWhiskers.AverageValues.Add(average);

							int outliersCount = Random.Next(5);

							NDoubleList outliers = new NDoubleList();

							for (int k = 0; k < outliersCount; k++)
							{
								double dOutlier = 0;

								if (Random.NextDouble() > 0.5)
								{
									dOutlier = boxUpper + IQR * 1.5 + Random.NextDouble() * 100;
								}
								else
								{
									dOutlier = boxLower - IQR * 1.5 - Random.NextDouble() * 100;
								}

								outliers.Add(dOutlier);
							}

							boxAndWhiskers.OutlierValues.Add(outliers);
						}

						chart.Series.Add(boxAndWhiskers);
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
					}
					break;
				case 3: // Error Bar
					{
						NErrorBarSeries errorBar = new NErrorBarSeries();
						errorBar.VerticalAxisRangeMode = AxisRangeMode.ViewRange;
						
						double y;
						double x = 50.0;

						for(int i = 0; i < 50; i++)
						{
							y = 20 + Random.NextDouble() * 30;
							x += 2.0 + Random.NextDouble() * 2;

							errorBar.Values.Add(y);
							errorBar.LowerErrorsY.Add(1 + Random.NextDouble());
							errorBar.UpperErrorsY.Add(1 + Random.NextDouble());

							errorBar.XValues.Add(x);
							errorBar.LowerErrorsX.Add(1 + Random.NextDouble());
							errorBar.UpperErrorsX.Add(1 + Random.NextDouble());
						}

						chart.Series.Add(errorBar);
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
					}
					break;
				case 4: // "Float Bar");
					{
						NFloatBarSeries floatBar = new NFloatBarSeries();

						floatBar.VerticalAxisRangeMode = AxisRangeMode.ViewRange;

						// generate Y values
						for(int i = 0; i < 100; i++)
						{
							double dBeginValue = Random.NextDouble() * 5;
							double dEndValue = dBeginValue + 2 + Random.NextDouble();
							floatBar.Values.Add(dBeginValue);
							floatBar.EndValues.Add(dEndValue);
						}

						// generate X values
						DateTime dt = new DateTime(2022, 5, 24, 11, 0, 0);

						for(int i = 0; i < 100; i++)
						{
							dt = dt.AddHours(12 + Random.NextDouble() * 60);

							floatBar.XValues.Add(dt);
						}

						chart.Series.Add(floatBar);
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NValueTimelineScaleConfigurator();
					}
					break;
				case 5: // Line
					{
						NLineSeries line = new NLineSeries();
						line.DataLabelStyle.Visible = false;
						line.VerticalAxisRangeMode = AxisRangeMode.ViewRange;

						GenerateData(line, 100.0, numDataPoints, new NRange1DD(60, 140));
						chart.Series.Add(line);
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NValueTimelineScaleConfigurator();
					}
					break;
				case 6: // Point
					{
						NPointSeries point = new NPointSeries();
						point.DataLabelStyle.Visible = false;
						point.VerticalAxisRangeMode = AxisRangeMode.ViewRange;
						point.Size = new NLength(5);

						GenerateData(point, 100.0, numDataPoints, new NRange1DD(60, 140));
						chart.Series.Add(point);
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
					}
					break;
				case 7: // Stock
					{
						// setup stock series
						NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
						stock.DataLabelStyle.Visible = false;
						stock.UpFillStyle = new NColorFillStyle(Color.White);
						stock.UpStrokeStyle.Color = Color.Black;
						stock.DownFillStyle = new NColorFillStyle(Color.Crimson);
						stock.DownStrokeStyle.Color = Color.Crimson;
						stock.HighLowStrokeStyle.Color = Color.Black;
						stock.CandleWidth = new NLength(1.2f, NRelativeUnit.ParentPercentage);
						stock.UseXValues = true;
						stock.InflateMargins = true;
						stock.VerticalAxisRangeMode = AxisRangeMode.ViewRange;

						// add some stock items
						GenerateOHLCData(stock, 100.0, numDataPoints, new NRange1DD(60, 140));
						FillStockDates(stock, numDataPoints);
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NValueTimelineScaleConfigurator();
					}
					break;
			}

			nChartControl1.Refresh();
		}
		internal void GenerateData(NXYScatterSeries xyScatterSeries, double value, int nCount, NRange1DD range)
		{
			xyScatterSeries.ClearDataPoints();
			DateTime dt = new DateTime(2009, 1, 5);

			for (int nIndex = 0; nIndex < nCount; nIndex++)
			{
				bool upward = false;

				if (range.Begin > value)
				{
					upward = true;
				}
				else if (range.End < value)
				{
					upward = false;
				}
				else
				{
					upward = Random.NextDouble() > 0.5;
				}

				xyScatterSeries.Values.Add(value);

				if (upward)
				{
					value += (2 + (Random.NextDouble() * 20));
				}
				else
				{
					value -= (2 + (Random.NextDouble() * 20));
				}
				
				while (true)
				{
					dt = dt.AddDays(1);

					if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
					{
						xyScatterSeries.XValues.Add(dt.ToOADate());
						break;
					}
				}
			}
		}
		internal void FillDates(NXYScatterSeries xyScatterSeries, int count, DateTime startDate)
		{
			xyScatterSeries.XValues.Clear();

			DateTime dt = startDate;

			for (int i = 0; i < count; )
			{
				if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
				{
					xyScatterSeries.XValues.Add(dt.ToOADate());
					i++;
				}

				dt = dt.AddDays(1);
			}
		}
	}
}
