using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLegendGeneralUC : NExampleUC
	{
		protected NLegend m_Legend;
		const int numberOfDataPoints = 5;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LegendModeDropDownList.Items.Add("Disabled");
				LegendModeDropDownList.Items.Add("Automatic");
				LegendModeDropDownList.Items.Add("Manual");
				LegendModeDropDownList.SelectedIndex = 1;

				PredefinedStyleDropDownList.Items.Add("Top");
				PredefinedStyleDropDownList.Items.Add("Bottom");
				PredefinedStyleDropDownList.Items.Add("Left");
				PredefinedStyleDropDownList.Items.Add("Right");
				PredefinedStyleDropDownList.Items.Add("Top right");
				PredefinedStyleDropDownList.Items.Add("Top left");
				PredefinedStyleDropDownList.SelectedIndex = 4;

				ExpandModeDropDownList.Items.Add("Rows only");
				ExpandModeDropDownList.Items.Add("Cols only");
				ExpandModeDropDownList.Items.Add("Rows fixed");
				ExpandModeDropDownList.Items.Add("Cols fixed");
				ExpandModeDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(ManualItemsDropDownList, 1, 20, 1);
				ManualItemsDropDownList.SelectedIndex = 5;

				WebExamplesUtilities.FillComboWithValues(RowCountDropDownList, 1, 10, 1);
				RowCountDropDownList.SelectedIndex = 5;

				WebExamplesUtilities.FillComboWithValues(ColCountDropDownList, 1, 10, 1);
				ColCountDropDownList.SelectedIndex = 5;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.Settings.JitteringSteps = 4;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Legend General");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			NBarSeries barSeries = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			barSeries.DataLabelStyle.Visible = false;
			barSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			barSeries.Legend.Format = "<label> <percent>";
			barSeries.Values.FillRandom(Random, numberOfDataPoints);

			for (int i = 0; i < numberOfDataPoints; i++)
			{
				barSeries.Labels.Add("Item " + i.ToString());
			}

			// setup the legend
			m_Legend = nChartControl1.Legends[0];
			m_Legend.FillStyle.SetTransparencyPercent(50);
			m_Legend.Mode = ((LegendMode)LegendModeDropDownList.SelectedIndex);

			if (m_Legend.Mode != LegendMode.Manual)
			{
				ManualItemsDropDownList.Enabled = false;
			}
			else
			{
				NLegendItemCellData legendItemCellData;
				ManualItemsDropDownList.Enabled = true;

				// fill some manual legend data items.
				int manualItemCount = ManualItemsDropDownList.SelectedIndex + 1;
				for (int i = 0; i < manualItemCount; i++)
				{
					legendItemCellData = new NLegendItemCellData();

					legendItemCellData.Text = "Manual item " + i.ToString();
					legendItemCellData.MarkShape = LegendMarkShape.Rectangle;

					Color itemColor = WebExamplesUtilities.RandomColor();

					legendItemCellData.MarkFillStyle = new NColorFillStyle(itemColor);
					
					m_Legend.Data.Items.Add(legendItemCellData);
				}
			}

			m_Legend.Header.Text = LegendHeaderTextBox.Text;
			m_Legend.Footer.Text = LegendFooterTextBox.Text;

			m_Legend.SetPredefinedLegendStyle((PredefinedLegendStyle)PredefinedStyleDropDownList.SelectedIndex);
			m_Legend.Data.ExpandMode = (LegendExpandMode)ExpandModeDropDownList.SelectedIndex;

			if (m_Legend.Data.ExpandMode == LegendExpandMode.ColsOnly || m_Legend.Data.ExpandMode == LegendExpandMode.RowsOnly)
			{
				RowCountDropDownList.Enabled = false;
				ColCountDropDownList.Enabled = false;
			}
			else if (m_Legend.Data.ExpandMode == LegendExpandMode.RowsFixed)
			{
				RowCountDropDownList.Enabled = true;
				ColCountDropDownList.Enabled = false;

				m_Legend.Data.RowCount = RowCountDropDownList.SelectedIndex + 1;
			}
			else if (m_Legend.Data.ExpandMode == LegendExpandMode.ColsFixed)
			{
				RowCountDropDownList.Enabled = false;
				ColCountDropDownList.Enabled = true;

				m_Legend.Data.ColCount = ColCountDropDownList.SelectedIndex + 1;
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);
		}

		protected void PredefinedStyleDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_Legend.SetPredefinedLegendStyle((PredefinedLegendStyle)PredefinedStyleDropDownList.SelectedIndex);		

			ExpandModeDropDownList.SelectedIndex = (int)m_Legend.Data.ExpandMode;

			RowCountDropDownList.Enabled = false;
			ColCountDropDownList.Enabled = false;
		}
	}
}
