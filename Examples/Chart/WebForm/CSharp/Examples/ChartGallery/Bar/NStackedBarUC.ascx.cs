using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Dom;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStackedBarUC : NExampleUC
	{
		protected NChart nChart;
		protected NBarSeries nBar1;
		protected NBarSeries nBar2;
		protected NBarSeries nBar3;


		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			nChart = nChartControl1.Charts[0];
			nChart.Enable3D = true;
			nChart.Axis(StandardAxis.Depth).Visible = false;
            nChart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlace stripe
            NLinearScaleConfigurator scaleY = nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			// add the first bar
			nBar1 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar1.Name = "Bar1";
			nBar1.MultiBarMode = MultiBarMode.Series;
			nBar1.DataLabelStyle.VertAlign = VertAlign.Center;
			nBar1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			nBar1.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			nBar1.Values.ValueFormatter = new NNumericValueFormatter("0");

			// add the second bar
			nBar2 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar2.Name = "Bar2";
			nBar2.MultiBarMode = MultiBarMode.Stacked;
			nBar2.DataLabelStyle.VertAlign = VertAlign.Center;
			nBar2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			nBar2.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			nBar2.Values.ValueFormatter = new NNumericValueFormatter("0");

			// add the third bar
			nBar3 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar3.Name = "Bar3";
			nBar3.MultiBarMode = MultiBarMode.Stacked;
			nBar3.DataLabelStyle.VertAlign = VertAlign.Center;
			nBar3.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			nBar3.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			nBar3.Values.ValueFormatter = new NNumericValueFormatter("0");

			// apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, nChart, title, nChartControl1.Legends[0]);

			if (!IsPostBack)
			{
				// fill the data labels combos
				FirstBarLabelsDropDownList.Items.Add("Value");
				FirstBarLabelsDropDownList.Items.Add("Total");
				FirstBarLabelsDropDownList.Items.Add("Cumulative");
				FirstBarLabelsDropDownList.Items.Add("Percent");
				FirstBarLabelsDropDownList.Items.Add("No Label");
				FirstBarLabelsDropDownList.SelectedIndex = 0;

				SecondBarLabelsDropDownList.Items.Add("Value");
				SecondBarLabelsDropDownList.Items.Add("Total");
				SecondBarLabelsDropDownList.Items.Add("Cumulative");
				SecondBarLabelsDropDownList.Items.Add("Percent");
				SecondBarLabelsDropDownList.Items.Add("No Label");
				SecondBarLabelsDropDownList.SelectedIndex = 0;

				ThirdBarLabelsDropDownList.Items.Add("Value");
				ThirdBarLabelsDropDownList.Items.Add("Total");
				ThirdBarLabelsDropDownList.Items.Add("Cumulative");
				ThirdBarLabelsDropDownList.Items.Add("Percent");
				ThirdBarLabelsDropDownList.Items.Add("No Label");
				ThirdBarLabelsDropDownList.SelectedIndex = 0;

				StackStyleDropDownList.Items.Add("Stacked");
				StackStyleDropDownList.Items.Add("Stacked %");
				StackStyleDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, typeof(BarShape));
				BarShapeDropDownList.SelectedIndex = 0;

				PositiveDataCheckBox.Checked = true;
			}

			nBar1.DataLabelStyle.Format = GetDataLabelsFormatString(FirstBarLabelsDropDownList);
			nBar2.DataLabelStyle.Format = GetDataLabelsFormatString(SecondBarLabelsDropDownList);
			nBar3.DataLabelStyle.Format = GetDataLabelsFormatString(ThirdBarLabelsDropDownList);

			switch (StackStyleDropDownList.SelectedIndex)
			{
				case 0:
					nBar2.MultiBarMode = MultiBarMode.Stacked; 
					nBar3.MultiBarMode = MultiBarMode.Stacked;
					break;

				case 1:
					nBar2.MultiBarMode = MultiBarMode.StackedPercent; 
					nBar3.MultiBarMode = MultiBarMode.StackedPercent;

					scaleY.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			BarShape shape = (BarShape)BarShapeDropDownList.SelectedIndex;
			nBar1.BarShape = shape;
			nBar2.BarShape = shape;
			nBar3.BarShape = shape;

			bool bEnable = (shape.Equals(BarShape.SmoothEdgeBar)) || (shape.Equals(BarShape.CutEdgeBar));

			ArrayList arrControls = new ArrayList();
			arrControls.Add(FirstHasTopEdgeCheckBox);
			arrControls.Add(FirstHasBottomEdgeCheckBox);

			arrControls.Add(SecondHasTopEdgeCheckBox);
			arrControls.Add(SecondHasBottomEdgeCheckBox);

			arrControls.Add(ThirdHasTopEdgeCheckBox);
			arrControls.Add(ThirdHasBottomEdgeCheckBox);
        
			foreach (CheckBox check in arrControls)
			{
				check.Enabled = bEnable;
			}

			if (bEnable)
			{
				nBar1.HasTopEdge = FirstHasTopEdgeCheckBox.Checked;
				nBar1.HasBottomEdge = FirstHasBottomEdgeCheckBox.Checked;
				nBar2.HasTopEdge = SecondHasTopEdgeCheckBox.Checked;
				nBar2.HasBottomEdge = SecondHasBottomEdgeCheckBox.Checked;
				nBar3.HasTopEdge = ThirdHasTopEdgeCheckBox.Checked;
				nBar3.HasBottomEdge = ThirdHasBottomEdgeCheckBox.Checked;
			}

			if (PositiveDataCheckBox.Checked)
			{
				GeneratePositiveData();
			}
			else
			{
				GeneratePositiveAndNegativeData();
			}

			this.PositiveDataButton.Click += new EventHandler(this.PositiveDataButton_Click);
			this.PositivAndNegativeDataButton.Click += new EventHandler(this.PositiveAndNegativeDataButton_Click);
		}

		private void PositiveDataButton_Click(object sender, EventArgs e)
		{
			GeneratePositiveData();
			PositiveDataCheckBox.Checked = false;
 		}

		private void PositiveAndNegativeDataButton_Click(object sender, EventArgs e)
		{
			GeneratePositiveAndNegativeData();
			PositiveDataCheckBox.Checked = true;
		}

		private void GeneratePositiveData()
		{
			nBar1.Values.FillRandomRange(Random, 5, 20, 100);
			nBar2.Values.FillRandomRange(Random, 5, 20, 100);
			nBar3.Values.FillRandomRange(Random, 5, 20, 100);
		}

		private void GeneratePositiveAndNegativeData()
		{
			nBar1.Values.FillRandomRange(Random, 5, -100, 100);
			nBar2.Values.FillRandomRange(Random, 5, -100, 100);
			nBar3.Values.FillRandomRange(Random, 5, -100, 100);
		}

		string GetDataLabelsFormatString(DropDownList list)
		{
			switch (list.SelectedIndex)
			{
				case 0:
					return "<value>";

				case 1:
					return "<total>";

				case 2:
					return "<cumulative>";

				case 3:
					return "<percent>";
			}

			return "";
		}
	}
}
