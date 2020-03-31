using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLineStudiesUC : NExampleBaseUC
	{
		private int m_nMinIndex1;
		private int m_nMaxIndex1;
		private int m_nMinIndex2;
		private int m_nMaxIndex2;
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton m_NewDataBtn;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox FinancialMarkerCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowTextsCheck;
		private Nevron.UI.WinForm.Controls.NButton TextStyleButton;
		private System.Windows.Forms.Label label1;
		private UI.WinForm.Controls.NCheckBox IncludeInMinMaxCalculationCheckBox;
		private Nevron.UI.WinForm.Controls.NComboBox TrendlineModeCombo;

		public NLineStudiesUC()
		{
			InitializeComponent();

			TrendlineModeCombo.FillFromEnum(typeof(TrendLineMode));

			FinancialMarkerCombo.Items.Add("Fibonacci Arcs");
			FinancialMarkerCombo.Items.Add("Fibonacci Fans");
			FinancialMarkerCombo.Items.Add("Fibonacci Retracements");
			FinancialMarkerCombo.Items.Add("Speed Resistance Lines");
			FinancialMarkerCombo.Items.Add("Quadrant Lines");
			FinancialMarkerCombo.Items.Add("Trend Line");
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
			this.label3 = new System.Windows.Forms.Label();
			this.FinancialMarkerCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_NewDataBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowTextsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.TextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.TrendlineModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.IncludeInMinMaxCalculationCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(169, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Line Study:";
			// 
			// FinancialMarkerCombo
			// 
			this.FinancialMarkerCombo.ListProperties.CheckBoxDataMember = "";
			this.FinancialMarkerCombo.ListProperties.DataSource = null;
			this.FinancialMarkerCombo.ListProperties.DisplayMember = "";
			this.FinancialMarkerCombo.Location = new System.Drawing.Point(6, 29);
			this.FinancialMarkerCombo.Name = "FinancialMarkerCombo";
			this.FinancialMarkerCombo.Size = new System.Drawing.Size(169, 22);
			this.FinancialMarkerCombo.TabIndex = 1;
			this.FinancialMarkerCombo.SelectedIndexChanged += new System.EventHandler(this.FinancialMarkerCombo_SelectedIndexChanged);
			// 
			// m_NewDataBtn
			// 
			this.m_NewDataBtn.Location = new System.Drawing.Point(6, 244);
			this.m_NewDataBtn.Name = "m_NewDataBtn";
			this.m_NewDataBtn.Size = new System.Drawing.Size(169, 22);
			this.m_NewDataBtn.TabIndex = 7;
			this.m_NewDataBtn.Text = "Generate New Data";
			this.m_NewDataBtn.Click += new System.EventHandler(this.GenerateDataBtn_Click);
			// 
			// ShowTextsCheck
			// 
			this.ShowTextsCheck.ButtonProperties.BorderOffset = 2;
			this.ShowTextsCheck.Location = new System.Drawing.Point(6, 145);
			this.ShowTextsCheck.Name = "ShowTextsCheck";
			this.ShowTextsCheck.Size = new System.Drawing.Size(169, 20);
			this.ShowTextsCheck.TabIndex = 5;
			this.ShowTextsCheck.Text = "Show Texts";
			this.ShowTextsCheck.CheckedChanged += new System.EventHandler(this.ShowTextsCheck_CheckedChanged);
			// 
			// TextStyleButton
			// 
			this.TextStyleButton.Location = new System.Drawing.Point(6, 172);
			this.TextStyleButton.Name = "TextStyleButton";
			this.TextStyleButton.Size = new System.Drawing.Size(169, 22);
			this.TextStyleButton.TabIndex = 6;
			this.TextStyleButton.Text = "Text Style...";
			this.TextStyleButton.Click += new System.EventHandler(this.TextStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Trendline Mode:";
			// 
			// TrendlineModeCombo
			// 
			this.TrendlineModeCombo.ListProperties.CheckBoxDataMember = "";
			this.TrendlineModeCombo.ListProperties.DataSource = null;
			this.TrendlineModeCombo.ListProperties.DisplayMember = "";
			this.TrendlineModeCombo.Location = new System.Drawing.Point(6, 102);
			this.TrendlineModeCombo.Name = "TrendlineModeCombo";
			this.TrendlineModeCombo.Size = new System.Drawing.Size(169, 22);
			this.TrendlineModeCombo.TabIndex = 4;
			this.TrendlineModeCombo.SelectedIndexChanged += new System.EventHandler(this.TrendlineModeCombo_SelectedIndexChanged);
			// 
			// IncludeInMinMaxCalculationCheckBox
			// 
			this.IncludeInMinMaxCalculationCheckBox.ButtonProperties.BorderOffset = 2;
			this.IncludeInMinMaxCalculationCheckBox.Location = new System.Drawing.Point(6, 54);
			this.IncludeInMinMaxCalculationCheckBox.Name = "IncludeInMinMaxCalculationCheckBox";
			this.IncludeInMinMaxCalculationCheckBox.Size = new System.Drawing.Size(181, 20);
			this.IncludeInMinMaxCalculationCheckBox.TabIndex = 2;
			this.IncludeInMinMaxCalculationCheckBox.Text = "Include in Min Max Calculation";
			this.IncludeInMinMaxCalculationCheckBox.CheckedChanged += new System.EventHandler(this.IncludeInMinMaxCalculationCheckBox_CheckedChanged);
			// 
			// NLineStudiesUC
			// 
			this.Controls.Add(this.IncludeInMinMaxCalculationCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TrendlineModeCombo);
			this.Controls.Add(this.TextStyleButton);
			this.Controls.Add(this.ShowTextsCheck);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.FinancialMarkerCombo);
			this.Controls.Add(this.m_NewDataBtn);
			this.Name = "NLineStudiesUC";
			this.Size = new System.Drawing.Size(187, 303);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Line Studies");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.LightModel.EnableLighting = false;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Height = 40;
			chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			// setup X axis
			NAxis axis = chart.Axis(StandardAxis.PrimaryX);
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			axis.ScaleConfigurator = dateTimeScale;

			dateTimeScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, false);
			dateTimeScale.InnerMajorTickStyle.Length = new NLength(0);
			dateTimeScale.RoundToTickMin = true;
			dateTimeScale.RoundToTickMax = true;
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2;
			dateTimeScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };

			// setup primary Y axis
			axis = chart.Axis(StandardAxis.PrimaryY);
			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
			standardScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			standardScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);

			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			standardScale.StripStyles.Add(stripStyle);
			standardScale.InnerMajorTickStyle.Length = new NLength(0);

			Color customColor = Color.FromArgb(150, 150, 200);

			// setup the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Bar;
			stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			stock.HighLowStrokeStyle.Color = customColor;
			stock.UpStrokeStyle.Width = new NLength(0);
			stock.DownStrokeStyle.Width = new NLength(0);
			stock.UpFillStyle = new NColorFillStyle(Color.LightGreen);
			stock.DownFillStyle = new NColorFillStyle(customColor);
			stock.Legend.Mode = SeriesLegendMode.SeriesLogic;
			stock.UseXValues = true;
			stock.InflateMargins = true;

			GenerateData();

			// form controls
			ShowTextsCheck.Checked = true;
			FinancialMarkerCombo.SelectedIndex = 2;
			TrendlineModeCombo.SelectedIndex = 2;
		}

		private void InsertFinancialMarker(NChart chart, NLineStudy ls)
		{
			if (chart.Series.Count > 1)
			{
				chart.Series.RemoveAt(0);
			}

			chart.Series.Insert(0, ls);
		}

		private void GenerateData()
		{
			const int dataCount = 240;

			NChart chart = nChartControl1.Charts[0];
			NStockSeries stock = (NStockSeries)chart.Series[chart.Series.Count - 1];

			GenerateStockData(stock, dataCount, 1000);

			// find the points where line studies should be attached
			m_nMinIndex1 = FindLocalMin(stock, 20);
			m_nMaxIndex1 = FindLocalMax(stock, 100);
			m_nMinIndex2 = FindLocalMin(stock, 120);
			m_nMaxIndex2 = FindLocalMax(stock, 200);

			NLineStudy lineStudy = chart.Series[0] as NLineStudy;
			if (lineStudy != null)
			{
				UpdateLineStudyAnchor(stock, lineStudy);
			}
		}

		private int FindLocalMin(NStockSeries stock, int index)
		{
			double minValue = (double)stock.LowValues[index];
			int minIndex = index;

			int from = Math.Max(0, index - 10);
			int to = Math.Min(index + 10, stock.LowValues.Count - 1);

			for (int i = from; i <= to; i++)
			{
				double value = (double)stock.LowValues[i];
				if (value < minValue)
				{
					minValue = value;
					minIndex = i;
				}
			}

			return minIndex;
		}

		private int FindLocalMax(NStockSeries stock, int index)
		{
			double maxValue = (double)stock.HighValues[index];
			int maxIndex = index;

			int from = Math.Max(0, index - 10);
			int to = Math.Min(index + 10, stock.LowValues.Count - 1);

			for (int i = from; i <= to; i++)
			{
				double value = (double)stock.HighValues[i];
				if (value > maxValue)
				{
					maxValue = value;
					maxIndex = i;
				}
			}

			return maxIndex;
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

		private void UpdateLineStudyAnchor(NStockSeries stock, NLineStudy lineStudy)
		{
			switch (FinancialMarkerCombo.SelectedIndex)
			{
				case 0: // Fibonacci Arcs
				case 1: // Fibonacci Fans
				case 2: // Fibonacci Retracements
				case 3: // Speed Resistance Lines
				case 4: // Quadrant Lines
					lineStudy.BeginPoint = GetLowPointFromStock(stock, m_nMinIndex1);
					lineStudy.EndPoint = GetHighPointFromStock(stock, m_nMaxIndex2);
					break;

				case 5: // Trend Line
					lineStudy.BeginPoint = GetLowPointFromStock(stock, m_nMinIndex1);
					lineStudy.EndPoint = GetLowPointFromStock(stock, m_nMaxIndex2);
					break;
			}
		}

		private void SetTextVisibility()
		{
			NChart chart = nChartControl1.Charts[0];
			NLineStudy lineStudy = chart.Series[0] as NLineStudy;

			if (lineStudy != null)
			{
				lineStudy.ShowTexts = ShowTextsCheck.Checked;
			}
		}

		private void SetTrendlineMode()
		{
			NChart chart = nChartControl1.Charts[0];
			NLineStudy trend = chart.Series[0] as NLineStudy;

			if (trend != null)
			{
				trend.TrendLineMode = (TrendLineMode)TrendlineModeCombo.SelectedIndex;
			}
		}

		private void GenerateStockData(NStockSeries stock, int count, double dPrevClose)
		{
			DateTime dt = new DateTime(2006, 5, 15);
			double dGrowProbability = 0.0;
			double open, high, low, close;

			stock.ClearDataPoints();

			for (int nIndex = 0; nIndex < count; nIndex++)
			{
				open = dPrevClose;

				if ((nIndex % 100) <= 20)
				{
					// downtrend
					dGrowProbability = 0.20;
				}
				else
				{
					// uptrend
					dGrowProbability = 0.75;
				}

				if (Random.NextDouble() < dGrowProbability)
				{
					// upward price change
					close = open + 2 + (Random.NextDouble() * 20);
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

				if (low < 1) { low = 1; }

				dPrevClose = close;

				stock.OpenValues.Add(open);
				stock.HighValues.Add(high);
				stock.LowValues.Add(low);
				stock.CloseValues.Add(close);
				stock.XValues.Add(dt.ToOADate());

				dt += new TimeSpan(1, 0, 0, 0);
			}
		}

		private void FinancialMarkerCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NStockSeries stock = (NStockSeries)chart.Series[chart.Series.Count - 1];
			NLineStudy lineStudy = null;
			Color lineColor = Color.Crimson;

			switch (FinancialMarkerCombo.SelectedIndex)
			{
				case 0:
					lineStudy = new NFibonacciArcs();
					TrendlineModeCombo.Enabled = false;
					break;

				case 1:
					lineStudy = new NFibonacciFans();
					TrendlineModeCombo.Enabled = true;
					break;

				case 2:
					lineStudy = new NFibonacciRetracements();
					((NFibonacciRetracements)lineStudy).RetracementsStrokeStyle.Color = lineColor;
					TrendlineModeCombo.Enabled = true;
					break;

				case 3:
					lineStudy = new NSpeedResistanceLines();
					TrendlineModeCombo.Enabled = true;
					break;

				case 4:
					lineStudy = new NQuadrantLines();
					((NQuadrantLines)lineStudy).CentralLineStrokeStyle.Color = lineColor;
					TrendlineModeCombo.Enabled = false;
					break;

				case 5:
					lineStudy = new NTrendLine();
					TrendlineModeCombo.Enabled = true;
					break;

				default:
					return;
			}

			UpdateLineStudyAnchor(stock, lineStudy);

			// set the primary line color
			lineStudy.StrokeStyle.Color = lineColor;

			InsertFinancialMarker(chart, lineStudy);
			SetTextVisibility();
			lineStudy.TrendLineMode = (TrendLineMode)TrendlineModeCombo.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void TrendlineModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTrendlineMode();
			nChartControl1.Refresh();
		}

		private void ShowTextsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			SetTextVisibility();
			nChartControl1.Refresh();
		}

		private void GenerateDataBtn_Click(object sender, System.EventArgs e)
		{
			GenerateData();

			nChartControl1.Refresh();
		}

		private void TextStyleButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NLineStudy lineStudy = chart.Series[0] as NLineStudy;

			if (lineStudy == null)
				return;

			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(lineStudy.TextStyle, out textStyleResult))
			{
				lineStudy.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void IncludeInMinMaxCalculationCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NLineStudy lineStudy = chart.Series[0] as NLineStudy;

			if (lineStudy != null)
			{
				lineStudy.IncludeInMinMaxCalculation = IncludeInMinMaxCalculationCheckBox.Checked;
				nChartControl1.Refresh();
			}
		}
	}
}