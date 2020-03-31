using System;
using System.Resources;
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
	public class NStockStickUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowOpen;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowClose;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowHighLow;
		private Nevron.UI.WinForm.Controls.NButton DownStickLine;
		private Nevron.UI.WinForm.Controls.NButton UpStickLine;
		private Nevron.UI.WinForm.Controls.NButton ShadowButton;
		private System.ComponentModel.Container components = null;

		public NStockStickUC()
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
			this.ShowOpen = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowClose = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.DownStickLine = new Nevron.UI.WinForm.Controls.NButton();
			this.UpStickLine = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowHighLow = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// ShowOpen
			// 
			this.ShowOpen.ButtonProperties.BorderOffset = 2;
			this.ShowOpen.Location = new System.Drawing.Point(6, 10);
			this.ShowOpen.Name = "ShowOpen";
			this.ShowOpen.Size = new System.Drawing.Size(167, 24);
			this.ShowOpen.TabIndex = 0;
			this.ShowOpen.Text = "Show Open";
			this.ShowOpen.CheckedChanged += new System.EventHandler(this.ShowOpen_CheckedChanged);
			// 
			// ShowClose
			// 
			this.ShowClose.ButtonProperties.BorderOffset = 2;
			this.ShowClose.Location = new System.Drawing.Point(6, 34);
			this.ShowClose.Name = "ShowClose";
			this.ShowClose.Size = new System.Drawing.Size(167, 24);
			this.ShowClose.TabIndex = 1;
			this.ShowClose.Text = "Show Close";
			this.ShowClose.CheckedChanged += new System.EventHandler(this.ShowClose_CheckedChanged);
			// 
			// DownStickLine
			// 
			this.DownStickLine.Location = new System.Drawing.Point(6, 120);
			this.DownStickLine.Name = "DownStickLine";
			this.DownStickLine.Size = new System.Drawing.Size(167, 23);
			this.DownStickLine.TabIndex = 4;
			this.DownStickLine.Text = "Down Stick Line...";
			this.DownStickLine.Click += new System.EventHandler(this.DownStickLine_Click);
			// 
			// UpStickLine
			// 
			this.UpStickLine.Location = new System.Drawing.Point(6, 90);
			this.UpStickLine.Name = "UpStickLine";
			this.UpStickLine.Size = new System.Drawing.Size(167, 23);
			this.UpStickLine.TabIndex = 3;
			this.UpStickLine.Text = "Up Stick Line...";
			this.UpStickLine.Click += new System.EventHandler(this.UpStickLine_Click);
			// 
			// ShowHighLow
			// 
			this.ShowHighLow.ButtonProperties.BorderOffset = 2;
			this.ShowHighLow.Location = new System.Drawing.Point(6, 58);
			this.ShowHighLow.Name = "ShowHighLow";
			this.ShowHighLow.Size = new System.Drawing.Size(167, 24);
			this.ShowHighLow.TabIndex = 2;
			this.ShowHighLow.Text = "Show High Low";
			this.ShowHighLow.CheckedChanged += new System.EventHandler(this.ShowHighLow_CheckedChanged);
			// 
			// ShadowButton
			// 
			this.ShadowButton.Location = new System.Drawing.Point(6, 150);
			this.ShadowButton.Name = "ShadowButton";
			this.ShadowButton.Size = new System.Drawing.Size(167, 23);
			this.ShadowButton.TabIndex = 5;
			this.ShadowButton.Text = "Shadow...";
			this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			// 
			// NStockStickUC
			// 
			this.Controls.Add(this.ShadowButton);
			this.Controls.Add(this.ShowHighLow);
			this.Controls.Add(this.DownStickLine);
			this.Controls.Add(this.UpStickLine);
			this.Controls.Add(this.ShowClose);
			this.Controls.Add(this.ShowOpen);
			this.Name = "NStockStickUC";
			this.Size = new System.Drawing.Size(180, 196);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stick Stock Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];

			// setup X axis
			NValueTimelineScaleConfigurator scaleX = new NValueTimelineScaleConfigurator();
			scaleX.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
			scaleX.FirstRow.UseGridStyle = true;
			scaleX.FirstRow.InnerTickStyle.Visible = false;
			scaleX.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
			scaleX.SecondRow.UseGridStyle = true;
			scaleX.SecondRow.InnerTickStyle.Visible = false;
			scaleX.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
			scaleX.ThirdRow.UseGridStyle = true;
			scaleX.ThirdRow.InnerTickStyle.Visible = false;
			// calendar
			NWeekDayRule wdr = new NWeekDayRule(WeekDayBit.All);
			wdr.Saturday = false;
			wdr.Sunday = false;
			scaleX.Calendar.Rules.Add(wdr);
			scaleX.EnableCalendar = true;
			// set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.OuterMajorTickStyle.Length = new NLength(3, NGraphicsUnit.Point);
			scaleY.InnerMajorTickStyle.Visible = false;

			NFillStyle stripFill = new NColorFillStyle(Color.FromArgb(234, 233, 237));
			NScaleStripStyle stripStyle = new NScaleStripStyle(stripFill, null, true, 1, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			// add a stock series
			m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.UpStrokeStyle.Width = new NLength(1, NGraphicsUnit.Point);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownStrokeStyle.Width = new NLength(1, NGraphicsUnit.Point);
			m_Stock.DownStrokeStyle.Color = Color.Crimson;
			m_Stock.CandleWidth = new NLength(1.3f, NRelativeUnit.ParentPercentage);
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;

			// add some stock items
			const int count = 50;
			GenerateOHLCData(m_Stock, 100.0, count, new NRange1DD(60, 140));
			FillStockDates(m_Stock, count);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			ShowHighLow.Checked = true;
			ShowOpen.Checked = true;
			ShowClose.Checked = true;
		}

		private void GenerateStockData(NStockSeries s, int nCount)
		{
			double prevclose = 300;
			double open, high, low, close;

			s.ClearDataPoints();

			for(int nIndex = 0; nIndex < nCount; nIndex++)
			{
				open = prevclose;

				if(prevclose < 25 || Random.NextDouble()  > 0.5)
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

				prevclose = close;

				s.OpenValues.Add(open);
				s.HighValues.Add(high);
				s.LowValues.Add(low);
				s.CloseValues.Add(close);
			}
		}

		private void ShowOpen_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Stock.ShowOpen = ShowOpen.Checked;
			nChartControl1.Refresh();
		}
		private void ShowClose_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Stock.ShowClose = ShowClose.Checked;
			nChartControl1.Refresh();
		}
		private void ShowHighLow_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Stock.ShowHighLow = ShowHighLow.Checked;
			nChartControl1.Refresh();
		}
		private void UpStickLine_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Stock.UpStrokeStyle, out strokeStyleResult))
			{
				m_Stock.UpStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void DownStickLine_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Stock.DownStrokeStyle, out strokeStyleResult))
			{
				m_Stock.DownStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void ShadowButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;

			if(NShadowStyleTypeEditor.Edit(m_Stock.ShadowStyle, out shadowStyleResult))
			{
				m_Stock.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}