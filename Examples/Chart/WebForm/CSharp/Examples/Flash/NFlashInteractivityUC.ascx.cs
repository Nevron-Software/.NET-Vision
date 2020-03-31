using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NFlashInteractivityUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

            nChartControl1.Panels.Clear();
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = new NLabel("Flash Interactivity");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.DockMode = PanelDockMode.Top;
            title.InteractivityStyle.UrlLink.Url = "http://www.apple.com";
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
            NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);

            bar1.MultiBarMode = MultiBarMode.Clustered;
            bar2.MultiBarMode = MultiBarMode.Clustered;
            bar3.MultiBarMode = MultiBarMode.Clustered;

			// configure common settings
			bar1.Name = "Apple";
            bar2.InteractivityStyle.UrlLink.Url = "http://www.apple.com";
			bar1.DataLabelStyle.Visible = false;

			bar2.Name = "Nokia";
            bar2.InteractivityStyle.UrlLink.Url = "http://www.nokia.com";
			bar2.DataLabelStyle.Visible = false;

			bar3.Name = "HTC";
            bar3.InteractivityStyle.UrlLink.Url = "http://www.htc.com";
			bar3.DataLabelStyle.Visible = false;

            // fill with random data
            bar1.Values.FillRandomRange(Random, 6, 10, 100);
            bar2.Values.FillRandomRange(Random, 6, 10, 100);
            bar3.Values.FillRandomRange(Random, 6, 10, 100);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

            // apply animation theme             
			NAnimationTheme animationTheme = new NAnimationTheme();

			animationTheme.AnimateSeriesSequentially = true;
			animationTheme.AnimateDataPointsSequentially = false;
			animationTheme.AnimateChartsSequentially = false;

			animationTheme.WallsAnimationDuration = 1;
            animationTheme.AxesAnimationDuration = 1;
            animationTheme.SeriesAnimationDuration = 1;

			animationTheme.AnimationThemeType = AnimationThemeType.ScaleAndFade;
		//	animationTheme.Apply(nChartControl1.Document);

            NImageResponse swfResponse = new NImageResponse();
            swfResponse.ImageFormat = new NSwfImageFormat();

            nChartControl1.ImageAcquisitionMode = ClientSideImageAcquisitionMode.TempFile;
            nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse;
        }
  	}
}
