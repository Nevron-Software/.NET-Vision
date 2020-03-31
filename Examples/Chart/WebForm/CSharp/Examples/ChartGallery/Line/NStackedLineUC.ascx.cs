using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStackedLineUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// fill the data labels combos
				FirstLineLabelsDropDownList.Items.Add("Value");
				FirstLineLabelsDropDownList.Items.Add("Total");
				FirstLineLabelsDropDownList.Items.Add("Cumulative");
				FirstLineLabelsDropDownList.Items.Add("Percent");
				FirstLineLabelsDropDownList.SelectedIndex = 0;

				SecondLineLabelsDropDownList.Items.Add("Value");
				SecondLineLabelsDropDownList.Items.Add("Total");
				SecondLineLabelsDropDownList.Items.Add("Cumulative");
				SecondLineLabelsDropDownList.Items.Add("Percent");
				SecondLineLabelsDropDownList.SelectedIndex = 0;

				ThirdLineLabelsDropDownList.Items.Add("Value");
				ThirdLineLabelsDropDownList.Items.Add("Total");
				ThirdLineLabelsDropDownList.Items.Add("Cumulative");
				ThirdLineLabelsDropDownList.Items.Add("Percent");
				ThirdLineLabelsDropDownList.SelectedIndex = 0;

				StackStyleDropDownList.Items.Add("Stacked");
				StackStyleDropDownList.Items.Add("Stacked %");
				StackStyleDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// modify the chart margins and fitting strategy
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// add interlace stripe
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Data.MarkSize = new NSizeL(4, 10);
			legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.FillStyle = new NColorFillStyle(Color.FromArgb(127, 255, 255, 255));
			legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

			// add the first line
			NLineSeries line1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line1.MultiLineMode = MultiLineMode.Series;
			line1.Name = "Orange";
			line1.DataLabelStyle.ArrowLength = new NLength(0, NRelativeUnit.ParentPercentage);
			line1.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			line1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			line1.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			line1.DataLabelStyle.TextStyle.BackplaneStyle.FillStyle = new NColorFillStyle(Color.OldLace);
			line1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.OuterBorderColor = Color.DarkOrange;
			line1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.DarkOrange;
			line1.BorderStyle.Color = Color.DarkOrange;
			line1.Values.ValueFormatter = new NNumericValueFormatter("0.#");

			// add the second line
			NLineSeries line2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line2.MultiLineMode = MultiLineMode.Stacked;
			line2.Name = "Green";
			line2.DataLabelStyle.ArrowLength = new NLength(0, NRelativeUnit.ParentPercentage);
			line2.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			line2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			line2.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			line2.DataLabelStyle.TextStyle.BackplaneStyle.FillStyle = new NColorFillStyle(Color.Honeydew);
			line2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.OuterBorderColor = Color.LimeGreen;
			line2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.LimeGreen;
			line2.BorderStyle.Color = Color.LimeGreen;
			line2.FillStyle = new NColorFillStyle(Color.LimeGreen);
			line2.Values.ValueFormatter = new NNumericValueFormatter("0.#");

			// add the third line
			NLineSeries line3 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line3.MultiLineMode = MultiLineMode.Stacked;
			line3.Name = "Blue";
			line3.DataLabelStyle.ArrowLength = new NLength(0, NRelativeUnit.ParentPercentage);
			line3.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			line3.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			line3.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			line3.DataLabelStyle.TextStyle.BackplaneStyle.FillStyle = new NColorFillStyle(Color.Azure);
			line3.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.OuterBorderColor = Color.RoyalBlue;
			line3.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.RoyalBlue;
			line3.BorderStyle.Color = Color.RoyalBlue;
			line3.FillStyle = new NColorFillStyle(Color.RoyalBlue);
			line3.Values.ValueFormatter = new NNumericValueFormatter("0.#");

			switch (StackStyleDropDownList.SelectedIndex)
			{
				case 0:
					line2.MultiLineMode = MultiLineMode.Stacked;
					line3.MultiLineMode = MultiLineMode.Stacked;

					// fill with random data
					line1.Values.FillRandomRange(Random, 7, 10, 80);
					line2.Values.FillRandomRange(Random, 7, 10, 80);
					line3.Values.FillRandomRange(Random, 7, 10, 80);
					break;

				case 1:
					line2.MultiLineMode = MultiLineMode.StackedPercent;
					line3.MultiLineMode = MultiLineMode.StackedPercent;

					// fill with random data
					line1.Values.FillRandomRange(Random, 7, 0, 100);
					line2.Values.FillRandomRange(Random, 7, 0, 100);
					line3.Values.FillRandomRange(Random, 7, 0, 100);

					// set the left axis to show percents
					linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
					linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 7);
					
					linearScaleConfigurator.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			SetDataLabelFormat(line1, FirstLineLabelsDropDownList.SelectedIndex);
			SetDataLabelFormat(line2, SecondLineLabelsDropDownList.SelectedIndex);
			SetDataLabelFormat(line3, ThirdLineLabelsDropDownList.SelectedIndex);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		private void SetDataLabelFormat(NLineSeries line, int index)
		{
			switch (index)
			{
				case 0: 
					line.DataLabelStyle.Format = "<value>";
					break;

				case 1:
					line.DataLabelStyle.Format = "<total>";
					break;

				case 2:
					line.DataLabelStyle.Format = "<cumulative>";
					break;

				case 3:
					line.DataLabelStyle.Format = "<percent>";
					break;
			}
		}
	}
}