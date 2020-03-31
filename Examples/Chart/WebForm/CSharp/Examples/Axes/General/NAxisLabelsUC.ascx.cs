
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;

using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAxisLabelsUC : NExampleUC
	{

		private NChart m_Chart;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(YLabelGenerationModeDropDownList, typeof(LabelGenerationMode));
				WebExamplesUtilities.FillComboWithEnumValues(XLabelGenerationModeDropDownList, typeof(LabelGenerationMode));
				WebExamplesUtilities.FillComboWithValues(XTicksPerLabelDropDownList, 1, 10, 1);
				WebExamplesUtilities.FillComboWithValues(YTicksPerLabelDropDownList, 1, 10, 1);
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Labels");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// remove all legends
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(4, NRelativeUnit.ParentPercentage),
				new NLength(13, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(82, NRelativeUnit.ParentPercentage));

			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfiguratorY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleConfiguratorY.MaxTickCount = 50;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle();
            stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            scaleConfiguratorY.StripStyles.Add(stripStyle);

			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfiguratorX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleConfiguratorX.AutoLabels = false;
			scaleConfiguratorX.Labels.Add("France");
			scaleConfiguratorX.Labels.Add("Italy");
			scaleConfiguratorX.Labels.Add("Germany");
			scaleConfiguratorX.Labels.Add("Norway");
			scaleConfiguratorX.Labels.Add("Spain");
			scaleConfiguratorX.Labels.Add("Belgium");
			scaleConfiguratorX.Labels.Add("Greece");
			scaleConfiguratorX.Labels.Add("Austria");
			scaleConfiguratorX.Labels.Add("Sweden");
			scaleConfiguratorX.Labels.Add("Finland");
			scaleConfiguratorX.Labels.Add("Poland");
			scaleConfiguratorX.Labels.Add("Denmark");

			NBarSeries series1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			series1.Name = "Product A";
			series1.DataLabelStyle.Visible = false;
			GenerateData(series1.Values, 12);

			NBarSeries series2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			series2.MultiBarMode = MultiBarMode.Clustered;
			series2.Name = "Product B";
			series2.DataLabelStyle.Visible = false;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			GenerateData(series2.Values, 12);
			UpdateScale();
		}

		private void GenerateData(NDataSeriesDouble dataSeries, int count)
		{
			for(int i = 0; i < count; i++)
			{
				dataSeries.Add(Random.NextDouble() * 59 + 1);
			}
		}

		private LabelFitMode[] GetLabelFitModesFromListBox(CheckBoxList listBox)
		{
			ArrayList arrFitModes = new ArrayList();

			for(int i = 0; i < listBox.Items.Count; i++)
			{
				ListItem item = listBox.Items[i];

				if(item.Selected)
				{
					arrFitModes.Add((LabelFitMode)i);
				}
			}

			return (LabelFitMode[])arrFitModes.ToArray(typeof(LabelFitMode));
		}


		private void UpdateScale()
		{
			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfiguratorY.LabelGenerationMode = (LabelGenerationMode)YLabelGenerationModeDropDownList.SelectedIndex;
			scaleConfiguratorY.NumberOfTicksPerLabel = Convert.ToInt32(YTicksPerLabelDropDownList.SelectedValue);
			scaleConfiguratorY.LabelFitModes = GetLabelFitModesFromListBox(YLabelFitModesList);

			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfiguratorX.LabelGenerationMode = (LabelGenerationMode)XLabelGenerationModeDropDownList.SelectedIndex;
			scaleConfiguratorX.NumberOfTicksPerLabel = Convert.ToInt32(XTicksPerLabelDropDownList.SelectedValue);
			scaleConfiguratorX.LabelFitModes = GetLabelFitModesFromListBox(XLabelFitModesList);
		}
	}
}
