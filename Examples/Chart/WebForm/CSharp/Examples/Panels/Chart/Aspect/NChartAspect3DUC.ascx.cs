using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NChartAspect3DUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Chart Aspect 3D");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(10, 10, 10, 0);
			nChartControl1.Panels.Add(title);

			// setup chart
			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			chart.DockMode = PanelDockMode.Fill;
			chart.Margins = new NMarginsL(new NLength(10));
			chart.Padding = new NMarginsL(2);

			chart.Enable3D = true;
			chart.Width = 50;
			chart.Height = 50;
			chart.Depth = 50;
			chart.BoundsMode = BoundsMode.Fit;
			chart.ContentAlignment = ContentAlignment.BottomRight;
			chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			chart.Wall(ChartWallType.Back).Width = 0.01f;
			chart.Wall(ChartWallType.Floor).Width = 0.01f;
			chart.Wall(ChartWallType.Left).Width = 0.01f;

			// apply predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

			// add axis labels
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Labels.Add("Miami");
			ordinalScale.Labels.Add("Chicago");
			ordinalScale.Labels.Add("Los Angeles");
			ordinalScale.Labels.Add("New York");
			ordinalScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

			ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add interlace stripe to the Y axis
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			int barsCount = 7;

			// add the first bar
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.MultiBarMode = MultiBarMode.Series;
			bar1.Name = "Bar1";
			bar1.DataLabelStyle.Visible = false;
			bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255);

			// add the second bar
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.MultiBarMode = MultiBarMode.Series;
			bar2.Name = "Bar2";
			bar2.DataLabelStyle.Visible = false;
			bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210);

			// add the third bar
			NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar3.MultiBarMode = MultiBarMode.Series;
			bar3.Name = "Bar3";
			bar3.DataLabelStyle.Visible = false;
			bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210);

			// add the second bar
			NBarSeries bar4 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar4.MultiBarMode = MultiBarMode.Series;
			bar4.Name = "Bar4";
			bar4.DataLabelStyle.Visible = false;
			bar4.BorderStyle.Color = Color.FromArgb(255, 210, 210);

			// fill with random data
			bar1.Values.FillRandomRange(Random, barsCount, 10, 40);
			bar2.Values.FillRandomRange(Random, barsCount, 30, 60);
			bar3.Values.FillRandomRange(Random, barsCount, 50, 80);
			bar4.Values.FillRandomRange(Random, barsCount, 70, 100);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithValues(XProportionDropDownList, 1, 5, 1);
				XProportionDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(YProportionDropDownList, 1, 5, 1);
				YProportionDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(DepthProportionDropDownList, 1, 5, 1);
				DepthProportionDropDownList.SelectedIndex = 0;

				Fit3DAxisContentCheckBox.Checked = true;
				ShowContentAreaCheckBox.Checked = false;
			}

			chart.Width = (XProportionDropDownList.SelectedIndex + 1) * 10;
			chart.Height = (YProportionDropDownList.SelectedIndex + 1) * 10;
			chart.Depth = (DepthProportionDropDownList.SelectedIndex + 1) * 10;

			float max = Math.Max(Math.Max(chart.Width, chart.Height), chart.Depth);

			float scale = 50 / max;

			chart.Width *= scale;
			chart.Height *= scale;
			chart.Depth *= scale;

			chart.Fit3DAxisContent = Fit3DAxisContentCheckBox.Checked;

			if (ShowContentAreaCheckBox.Checked)
			{
				chart.BorderStyle = new NStrokeBorderStyle();
			}
			else
			{
				chart.BorderStyle = null;
			}
		}
	}
}
