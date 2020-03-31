using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAnimationThemes1UC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // init form controls
                ChartTypeCombo.Items.Add("Bar");
                ChartTypeCombo.Items.Add("Line");
                ChartTypeCombo.Items.Add("Area");
                ChartTypeCombo.SelectedIndex = 0;

			    WebExamplesUtilities.FillComboWithEnumValues(AnimationThemeTypeCombo, typeof(AnimationThemeType));
			    AnimationThemeTypeCombo.SelectedIndex = (int)AnimationThemeType.ScaleAndFade;

                WebExamplesUtilities.FillComboWithValues(AxesAnimationDurationCombo, 1, 10, 1);
                AxesAnimationDurationCombo.SelectedIndex = 2;
                WebExamplesUtilities.FillComboWithValues(WallsAnimationDurationCombo, 1, 10, 1);
                WallsAnimationDurationCombo.SelectedIndex = 2;
                WebExamplesUtilities.FillComboWithValues(SeriesAnimationDurationCombo, 1, 10, 1);
                SeriesAnimationDurationCombo.SelectedIndex = 2;
            }

            nChartControl1.Panels.Clear();
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = new NLabel("Animation Themes");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.DockMode = PanelDockMode.Top;
			nChartControl1.Panels.Add(title);

			NDockPanel contentPanel = new NDockPanel();
			nChartControl1.Panels.Add(contentPanel);

			contentPanel.DockMode = PanelDockMode.Fill;

			// configure the chart
			NCartesianChart chart = new NCartesianChart();
			contentPanel.ChildPanels.Add(chart);
			chart.Location = new NPointL(0, 0);
			chart.Size = new NSizeL(new NLength(100, NRelativeUnit.ParentPercentage),
									new NLength(60, NRelativeUnit.ParentPercentage));
			chart.Enable3D = false;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);
			chart.Margins = new NMarginsL(5, 5, 5, 5);
			chart.BoundsMode = BoundsMode.Stretch;
			chart.DockMode = PanelDockMode.Fill;

			// configure axes
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Labels.Add("2004");
			ordinalScale.Labels.Add("2005");
			ordinalScale.Labels.Add("2006");
			ordinalScale.Labels.Add("2007");
			ordinalScale.Labels.Add("2008");
			ordinalScale.Labels.Add("2009");

			// add interlace stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.Title.Text = "Sales in Thousands USD";
			linearScale.MinTickDistance = new NLength(15);
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // create  series
            NSeries series1 = null, series2 = null, series3 = null;
			switch (ChartTypeCombo.SelectedIndex)
			{
				case 0: // Bar
                    series1 = (NSeries)chart.Series.Add(SeriesType.Bar);
                    series2 = (NSeries)chart.Series.Add(SeriesType.Bar);
                    series3 = (NSeries)chart.Series.Add(SeriesType.Bar);

                    ((NBarSeries)series1).MultiBarMode = MultiBarMode.Clustered;
                    ((NBarSeries)series2).MultiBarMode = MultiBarMode.Clustered;
                    ((NBarSeries)series3).MultiBarMode = MultiBarMode.Clustered;
					break;
				case 1: // Line
                    series1 = (NSeries)chart.Series.Add(SeriesType.Line);
                    series2 = (NSeries)chart.Series.Add(SeriesType.Line);
                    series3 = (NSeries)chart.Series.Add(SeriesType.Line);

                    ((NLineSeries)series1).MultiLineMode = MultiLineMode.Stacked;
                    ((NLineSeries)series2).MultiLineMode = MultiLineMode.Stacked;
                    ((NLineSeries)series3).MultiLineMode = MultiLineMode.Stacked;
					
					break;
				case 2: // Area
                    series1 = (NSeries)chart.Series.Add(SeriesType.Area);
                    series2 = (NSeries)chart.Series.Add(SeriesType.Area);
                    series3 = (NSeries)chart.Series.Add(SeriesType.Area);

                    ((NAreaSeries)series1).MultiAreaMode = MultiAreaMode.Stacked;
                    ((NAreaSeries)series2).MultiAreaMode = MultiAreaMode.Stacked;
                    ((NAreaSeries)series3).MultiAreaMode = MultiAreaMode.Stacked;					
					break;
			}

			// configure common settings
			series1.Name = "Company A";
			series1.DataLabelStyle.Visible = false;

			series2.Name = "Company B";
			series2.DataLabelStyle.Visible = false;

			series3.Name = "Company C";
			series3.DataLabelStyle.Visible = false;

            // fill with random data
            series1.Values.FillRandomRange(Random, 6, 10, 100);
            series2.Values.FillRandomRange(Random, 6, 10, 100);
            series3.Values.FillRandomRange(Random, 6, 10, 100);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

            // apply animation theme             
			NAnimationTheme animationTheme = new NAnimationTheme();

			animationTheme.AnimateSeriesSequentially = SequentialSeriesCheckBox.Checked;
			animationTheme.AnimateDataPointsSequentially = SequentialDataPointsCheckBox.Checked;
			animationTheme.AnimateChartsSequentially = SequentialChartsCheckBox.Checked;

			animationTheme.WallsAnimationDuration = (float)(WallsAnimationDurationCombo.SelectedIndex + 1);
            animationTheme.AxesAnimationDuration = (float)(AxesAnimationDurationCombo.SelectedIndex + 1);
            animationTheme.SeriesAnimationDuration = (float)(SeriesAnimationDurationCombo.SelectedIndex + 1);

			animationTheme.AnimationThemeType = (AnimationThemeType)AnimationThemeTypeCombo.SelectedIndex;
			animationTheme.Apply(nChartControl1.Document);

            NImageResponse swfResponse = new NImageResponse();
            swfResponse.ImageFormat = new NSwfImageFormat();
//            swfResponse.StreamImageToBrowser = true;
            nChartControl1.ImageAcquisitionMode = ClientSideImageAcquisitionMode.TempFile;
            nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse;
        }
  	}
}
