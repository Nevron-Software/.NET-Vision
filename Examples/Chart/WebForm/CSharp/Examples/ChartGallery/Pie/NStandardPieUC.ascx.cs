using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardPieUC : NExampleUC
	{
		protected Label Label5;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithEnumValues(PieStyleDropDownList, typeof(PieStyle));
				PieStyleDropDownList.SelectedIndex = (int)PieStyle.Ring;

				PieLabelModeDropDownList.Items.Add("Center");
				PieLabelModeDropDownList.Items.Add("Rim");
				PieLabelModeDropDownList.Items.Add("Spider");
				PieLabelModeDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithValues(ArrowLengthDropDownList, 0, 10, 1);
				ArrowLengthDropDownList.SelectedIndex = 4;

				WebExamplesUtilities.FillComboWithValues(ArrowPointerLengthDropDownList, 0, 10, 1);
				ArrowPointerLengthDropDownList.SelectedIndex = 4;

				WebExamplesUtilities.FillComboWithValues(DepthDropDownList, 0, 100, 10);
				DepthDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 10);
				BeginAngleDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(TotalAngleDropDownList, 0, 360, 10);
				TotalAngleDropDownList.SelectedIndex = 36;

				LightsCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.FillStyle = new NColorFillStyle(Color.FromArgb(124, 255, 255, 255));
			legend.HorizontalBorderStyle.Width = new NLength(0);
			legend.VerticalBorderStyle.Width = new NLength(0);
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
			legend.Data.RowCount = 2;
			legend.Data.CellMargins = new NMarginsL(
				new NLength(6, NGraphicsUnit.Pixel),
				new NLength(3, NGraphicsUnit.Pixel),
				new NLength(6, NGraphicsUnit.Pixel),
				new NLength(3, NGraphicsUnit.Pixel));
			legend.Data.MarkSize = new NSizeL(
				new NLength(7, NGraphicsUnit.Pixel),
				new NLength(7, NGraphicsUnit.Pixel));


			// by default the control contains a Cartesian chart -> remove it and create a Pie chart
			NPieChart pieChart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(pieChart);

			pieChart.Enable3D = true;
			pieChart.DisplayOnLegend = nChartControl1.Legends[0];
			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			pieChart.Depth = DepthDropDownList.SelectedIndex * 10;
			pieChart.BoundsMode = BoundsMode.Fit;
			pieChart.Location = new NPointL(
				new NLength(12, NRelativeUnit.ParentPercentage),
				new NLength(12, NRelativeUnit.ParentPercentage));
			pieChart.Size = new NSizeL(
				new NLength(76, NRelativeUnit.ParentPercentage),
				new NLength(68, NRelativeUnit.ParentPercentage));

			pieChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 10;
			pieChart.TotalAngle = TotalAngleDropDownList.SelectedIndex * 10;
			pieChart.InnerRadius = new NLength(40);

			// setup pie series
			NPieSeries pie = (NPieSeries)pieChart.Series.Add(SeriesType.Pie);
			pie.Legend.Mode = SeriesLegendMode.DataPoints;
			pie.Legend.Format = "<label> <percent>";
			pie.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			pie.PieStyle = (PieStyle)PieStyleDropDownList.SelectedIndex;
			pie.LabelMode = (PieLabelMode)PieLabelModeDropDownList.SelectedIndex;
			pie.DataLabelStyle.ArrowLength = new NLength((float)ArrowLengthDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			pie.DataLabelStyle.ArrowPointerLength = new NLength((float)ArrowPointerLengthDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			

			pie.AddDataPoint(new NDataPoint(12, "Bikes"));
			pie.AddDataPoint(new NDataPoint(22, "Trains"));
			pie.AddDataPoint(new NDataPoint(19, "Cars"));
			pie.AddDataPoint(new NDataPoint(51, "Planes"));
			pie.AddDataPoint(new NDataPoint(23, "Buses", new NColorFillStyle(Color.Red)));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			switch (pie.LabelMode)
			{
				case PieLabelMode.Center:
					ArrowPointerLengthDropDownList.Enabled = false;
					ArrowLengthDropDownList.Enabled = false;
					break;

				case PieLabelMode.Rim:
					ArrowPointerLengthDropDownList.Enabled = true;
					ArrowLengthDropDownList.Enabled = true;
					break;

				case PieLabelMode.Spider:
					ArrowPointerLengthDropDownList.Enabled = true;
					ArrowLengthDropDownList.Enabled = true;
					break;
			}

			if (LightsCheckBox.Checked)
			{
				pieChart.LightModel.EnableLighting = true;
				pieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);
			}
			else
			{
				pieChart.LightModel.EnableLighting = false;
			}
		}
	}
}
