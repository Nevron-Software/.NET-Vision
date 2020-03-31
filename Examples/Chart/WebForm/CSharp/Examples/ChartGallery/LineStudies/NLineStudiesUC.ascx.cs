using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLineStudiesUC : NExampleUC
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				LineStudyDropDownList.Items.Add("Fibonacci Arcs");
				LineStudyDropDownList.Items.Add("Fibonacci Fans");
				LineStudyDropDownList.Items.Add("Fibonacci Retracements");
				LineStudyDropDownList.Items.Add("Speed Resistance Lines");
				LineStudyDropDownList.Items.Add("Quadrant Lines");
				LineStudyDropDownList.Items.Add("Trend Line");

				WebExamplesUtilities.FillComboWithEnumValues(TrendlineModeDropDownList, typeof(TrendLineMode));

				// form controls
				LineStudyDropDownList.SelectedIndex = 0;
				TrendlineModeDropDownList.SelectedIndex = 1;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = new NLabel();
			title.Text = "Line Studies - " + LineStudyDropDownList.SelectedItem.Text;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			nChartControl1.Panels.Add(title);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NAxis axis = chart.Axis(StandardAxis.PrimaryX);
			NDateTimeScaleConfigurator timeScaleConfigurator = new NDateTimeScaleConfigurator();
			axis.ScaleConfigurator = timeScaleConfigurator;
			timeScaleConfigurator.EnableUnitSensitiveFormatting = false;
			timeScaleConfigurator.LabelValueFormatter = new NDateTimeValueFormatter("MMM yy");
			timeScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			timeScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			timeScaleConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			timeScaleConfigurator.RoundToTickMin = false;
			timeScaleConfigurator.RoundToTickMax = false;
			timeScaleConfigurator.LabelGenerationMode = LabelGenerationMode.SingleLevel;

			// setup Y axis
			axis = chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);
			linearScaleConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScaleConfigurator.StripStyles.Add(stripStyle);

			Color customColor = Color.FromArgb(150, 150, 200);

			// setup the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Bar;
			stock.CandleWidth = new NLength(0.3f, NRelativeUnit.ParentPercentage);
			stock.HighLowStrokeStyle.Color = customColor;
			stock.UpStrokeStyle.Width = new NLength(0);
			stock.DownStrokeStyle.Width = new NLength(0);
			stock.UpFillStyle = new NColorFillStyle(Color.LightGreen);
			stock.DownFillStyle = new NColorFillStyle(customColor);
			stock.UseXValues = true;
			stock.InflateMargins = true;

			GenerateData(stock);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			// create line study
			NLineStudy lineStudy = null;
			Color lineColor = Color.Crimson;

			switch(LineStudyDropDownList.SelectedIndex)
			{
				case 0:
					lineStudy = new NFibonacciArcs();
					break;

				case 1:
					lineStudy = new NFibonacciFans();
					break;

				case 2:
					lineStudy = new NFibonacciRetracements();
					((NFibonacciRetracements)lineStudy).RetracementsStrokeStyle.Color = lineColor;
					break;

				case 3:
					lineStudy = new NSpeedResistanceLines();
					break;

				case 4:
					lineStudy = new NQuadrantLines();
					((NQuadrantLines)lineStudy).CentralLineStrokeStyle.Color = lineColor;
					break;

				case 5:
					lineStudy = new NTrendLine();
					break;

				default:
					return;
			}

			// attach the line study to the stock series
			lineStudy.BeginPoint = GetLowPointFromStock(stock, 20);
			lineStudy.EndPoint = GetHighPointFromStock(stock, 80);

			// set the primary line color
			lineStudy.StrokeStyle.Color = lineColor;

			InsertFinancialMarker(chart, lineStudy);
			TrendlineModeDropDownList.Enabled = lineStudy is NTrendLine;


			// set trend line mode
			NTrendLine trend = chart.Series[0] as NTrendLine;

			lineStudy.TrendLineMode = (TrendLineMode)TrendlineModeDropDownList.SelectedIndex;

			// set text visibility
			lineStudy.ShowTexts = ShowTextsCheckBox.Checked;
		}

		private NPointD GetHighPointFromStock(NStockSeries stock, int dataPointIndex)
		{
			NPointD result;

			result.X = (double)stock.XValues[dataPointIndex];
			result.Y = (double)stock.HighValues[dataPointIndex];

			return result;
		}

		private NPointD GetLowPointFromStock(NStockSeries stock, int dataPointIndex)
		{
			NPointD result;

			result.X = (double)stock.XValues[dataPointIndex];
			result.Y = (double)stock.LowValues[dataPointIndex];

			return result;
		}

		private void InsertFinancialMarker(NChart chart, NLineStudy ls)
		{
			if(chart.Series.Count > 1)
			{
				chart.Series.RemoveAt(0);
			}

			chart.Series.Insert(0, ls);
		}

		private void GenerateData(NStockSeries stock)
		{
			GenerateOHLCData(stock, 200);

			DateTime dt = new DateTime(2006, 5, 15);

			for(int i = 0; i < 200; i++)
			{
				stock.XValues.Add(dt.ToOADate());

				dt += new TimeSpan(1, 0, 0, 0);
			}

			NMarkerStyle ms1 = new NMarkerStyle();
			ms1.Visible = true;
			ms1.PointShape = PointShape.Ellipse;
			ms1.FillStyle = new NColorFillStyle(Color.Red);
			ms1.Width = new NLength(0.4f, NRelativeUnit.ParentPercentage);;
			ms1.Height = new NLength(0.4f, NRelativeUnit.ParentPercentage);;
			ms1.VertAlign = VertAlign.Bottom;
			stock.MarkerStyles[20] = ms1;

			NMarkerStyle ms2 = new NMarkerStyle();
			ms2.Visible = true;
			ms2.PointShape = PointShape.Ellipse;
			ms2.FillStyle = new NColorFillStyle(Color.Red);
			ms2.Width = new NLength(0.4f, NRelativeUnit.ParentPercentage);;
			ms2.Height = new NLength(0.4f, NRelativeUnit.ParentPercentage);;
			ms2.VertAlign = VertAlign.Top;
			stock.MarkerStyles[80] = ms2;
		}

		private void SetTrendlineMode()
		{
		}


		private void GenerateOHLCData(NStockSeries stock, double dPrevClose)
		{
			double dGrowProbability = 0.0;
			double open, high, low, close;

			stock.ClearDataPoints();
			Random random = new Random();

			for(int nIndex = 0; nIndex < 200; nIndex++)
			{
				open = dPrevClose;

				if(dPrevClose < 25)
				{
					dGrowProbability = 1.0;
				}
				else
				{
					if(((nIndex >= 20) && (nIndex <= 80)) || ((nIndex >= 120) && (nIndex <= 180)))
					{
						dGrowProbability = 0.75;
					}
					else
					{
						dGrowProbability = 0.25;
					}
				}

				if(Random.NextDouble() < dGrowProbability)
				{
					// upward price change
					close = open + (2 + (Random.NextDouble() * 20));
					high = close + (Random.NextDouble() * 10);
					low = open - (Random.NextDouble() * 10);
				}
				else
				{
					// downward price change
					close = open - (2 + (Random.NextDouble() * 20));
					high = open + (Random.NextDouble() * 10);
					low = close - (Random.NextDouble() * 10);
				}

				if(low < 1){ low = 1; }

				dPrevClose = close;

				stock.OpenValues.Add(open);
				stock.HighValues.Add(high);
				stock.LowValues.Add(low);
				stock.CloseValues.Add(close);
			}
		}
	}
}
