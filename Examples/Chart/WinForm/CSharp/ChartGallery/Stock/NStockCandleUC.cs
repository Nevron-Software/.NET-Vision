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
	public class NStockCandleUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;
		private Nevron.UI.WinForm.Controls.NButton UpColor;
		private Nevron.UI.WinForm.Controls.NButton DownColor;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowHighLowLine;
		private Nevron.UI.WinForm.Controls.NButton HighLowLineColor;
		private Nevron.UI.WinForm.Controls.NButton DownLineColor;
		private Nevron.UI.WinForm.Controls.NButton UpLineColor;
		private Nevron.UI.WinForm.Controls.NButton ShadowButton;
		private System.ComponentModel.Container components = null;

		public NStockCandleUC()
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
			this.UpColor = new Nevron.UI.WinForm.Controls.NButton();
			this.DownColor = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowHighLowLine = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.HighLowLineColor = new Nevron.UI.WinForm.Controls.NButton();
			this.DownLineColor = new Nevron.UI.WinForm.Controls.NButton();
			this.UpLineColor = new Nevron.UI.WinForm.Controls.NButton();
			this.ShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// UpColor
			// 
			this.UpColor.Location = new System.Drawing.Point(5, 10);
			this.UpColor.Name = "UpColor";
			this.UpColor.Size = new System.Drawing.Size(170, 23);
			this.UpColor.TabIndex = 0;
			this.UpColor.Text = "Up Candle Fill Style...";
			this.UpColor.Click += new System.EventHandler(this.UpColor_Click);
			// 
			// DownColor
			// 
			this.DownColor.Location = new System.Drawing.Point(5, 79);
			this.DownColor.Name = "DownColor";
			this.DownColor.Size = new System.Drawing.Size(170, 23);
			this.DownColor.TabIndex = 2;
			this.DownColor.Text = "Down Candle Fill Style...";
			this.DownColor.Click += new System.EventHandler(this.DownColor_Click);
			// 
			// ShowHighLowLine
			// 
			this.ShowHighLowLine.ButtonProperties.BorderOffset = 2;
			this.ShowHighLowLine.Location = new System.Drawing.Point(5, 176);
			this.ShowHighLowLine.Name = "ShowHighLowLine";
			this.ShowHighLowLine.Size = new System.Drawing.Size(170, 24);
			this.ShowHighLowLine.TabIndex = 5;
			this.ShowHighLowLine.Text = "Show High Low Line";
			this.ShowHighLowLine.CheckedChanged += new System.EventHandler(this.ShowHighLowLine_CheckedChanged);
			// 
			// HighLowLineColor
			// 
			this.HighLowLineColor.Location = new System.Drawing.Point(5, 149);
			this.HighLowLineColor.Name = "HighLowLineColor";
			this.HighLowLineColor.Size = new System.Drawing.Size(170, 23);
			this.HighLowLineColor.TabIndex = 4;
			this.HighLowLineColor.Text = "High Low Line...";
			this.HighLowLineColor.Click += new System.EventHandler(this.HighLowLineColor_Click);
			// 
			// DownLineColor
			// 
			this.DownLineColor.Location = new System.Drawing.Point(5, 107);
			this.DownLineColor.Name = "DownLineColor";
			this.DownLineColor.Size = new System.Drawing.Size(170, 23);
			this.DownLineColor.TabIndex = 3;
			this.DownLineColor.Text = "Down Candle Border...";
			this.DownLineColor.Click += new System.EventHandler(this.DownLineColor_Click);
			// 
			// UpLineColor
			// 
			this.UpLineColor.Location = new System.Drawing.Point(5, 38);
			this.UpLineColor.Name = "UpLineColor";
			this.UpLineColor.Size = new System.Drawing.Size(170, 23);
			this.UpLineColor.TabIndex = 1;
			this.UpLineColor.Text = "Up Candle Border...";
			this.UpLineColor.Click += new System.EventHandler(this.UpLineColor_Click);
			// 
			// ShadowButton
			// 
			this.ShadowButton.Location = new System.Drawing.Point(5, 229);
			this.ShadowButton.Name = "ShadowButton";
			this.ShadowButton.Size = new System.Drawing.Size(170, 23);
			this.ShadowButton.TabIndex = 6;
			this.ShadowButton.Text = "Shadow...";
			this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			// 
			// NStockCandleUC
			// 
			this.Controls.Add(this.ShadowButton);
			this.Controls.Add(this.DownLineColor);
			this.Controls.Add(this.UpLineColor);
			this.Controls.Add(this.HighLowLineColor);
			this.Controls.Add(this.ShowHighLowLine);
			this.Controls.Add(this.DownColor);
			this.Controls.Add(this.UpColor);
			this.Name = "NStockCandleUC";
			this.Size = new System.Drawing.Size(180, 278);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Candle Stock Chart");
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
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back };
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			// setup stock series
			m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.UpFillStyle = new NColorFillStyle(Color.White);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownFillStyle = new NColorFillStyle(Color.Crimson);
			m_Stock.DownStrokeStyle.Color = Color.Crimson;
			m_Stock.HighLowStrokeStyle.Color = Color.Black;
			m_Stock.CandleWidth = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;

			// add some stock items
			const int numDataPoints = 50;
			GenerateOHLCData(m_Stock, 100.0, numDataPoints, new NRange1DD(60, 140));
			FillStockDates(m_Stock, numDataPoints);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			ShowHighLowLine.Checked = true;
		}

		private void UpColor_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Stock.UpFillStyle, out fillStyleResult))
			{
				m_Stock.UpFillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void UpLineColor_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Stock.UpStrokeStyle, out strokeStyleResult))
			{
				m_Stock.UpStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void DownColor_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Stock.DownFillStyle, out fillStyleResult))
			{
				m_Stock.DownFillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void DownLineColor_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Stock.DownStrokeStyle, out strokeStyleResult))
			{
				m_Stock.DownStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void HighLowLineColor_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Stock.HighLowStrokeStyle, out strokeStyleResult))
			{
				m_Stock.HighLowStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void ShowHighLowLine_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Stock.ShowHighLow = ShowHighLowLine.Checked;
			nChartControl1.Refresh();
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
