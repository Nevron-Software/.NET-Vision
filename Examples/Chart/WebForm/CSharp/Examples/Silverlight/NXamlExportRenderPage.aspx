<%@ Page language="C#" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Import namespace ="System.Drawing"%>
<%@ Import namespace ="Nevron.UI.WebForm.Controls"%>
<%@ Import namespace ="Nevron.Chart.WebForm"%>
<%@ Import namespace ="Nevron.Chart"%>
<%@ Import namespace ="Nevron"%>
<%@ Import namespace ="Nevron.GraphicsCore"%>
<%
		NChartControl nChartControl1 = new NChartControl();

        nChartControl1.Page = this;
		nChartControl1.Width = 400;
		nChartControl1.Height = 300;
        nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

        // set a chart title
        NLabel title = nChartControl1.Labels.AddHeader("XAML Export");
        title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
        title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
        title.ContentAlignment = ContentAlignment.BottomCenter;
        title.Location = new NPointL(
            new NLength(50, NRelativeUnit.ParentPercentage),
            new NLength(2, NRelativeUnit.ParentPercentage));

        // setup the legend
        NLegend legend = nChartControl1.Legends[0];
        legend.ContentAlignment = ContentAlignment.MiddleLeft;
        legend.Location = new NPointL(
			new NLength(98, NRelativeUnit.ParentPercentage),
			new NLength(50, NRelativeUnit.ParentPercentage));

        // setup the chart
		NChart chart = nChartControl1.Charts[0];
        chart.BoundsMode = BoundsMode.Fit;
        chart.Location = new NPointL(
            new NLength(6, NRelativeUnit.ParentPercentage),
            new NLength(14, NRelativeUnit.ParentPercentage));
        chart.Size = new NSizeL(
            new NLength(75, NRelativeUnit.ParentPercentage),
            new NLength(80, NRelativeUnit.ParentPercentage));

		// add the first bar
		NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
		bar1.Name = "Bar1";
		bar1.MultiBarMode = MultiBarMode.Series;
        bar1.BarShape = BarShape.SmoothEdgeBar;
        bar1.DataLabelStyle.Visible = false;

		// add the second bar
		NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
		bar2.Name = "Bar2";
		bar2.MultiBarMode = MultiBarMode.StackedPercent;
        bar2.BarShape = BarShape.SmoothEdgeBar;
        bar2.DataLabelStyle.Visible = false;

		// add the third bar
		NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
		bar3.Name = "Bar3";
		bar3.MultiBarMode = MultiBarMode.StackedPercent;
        bar3.BarShape = BarShape.SmoothEdgeBar;
        bar3.DataLabelStyle.Visible = false;

		System.Random random = new System.Random();

		bar1.Values.FillRandomRange(random,  5, 10, 30);
		bar2.Values.FillRandomRange(random, 5, 10, 30);
		bar3.Values.FillRandomRange(random, 5, 10, 30);

        // apply style sheet
        NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
        styleSheet.Apply(nChartControl1.Document);
    
		nChartControl1.ServerSettings.BrowserResponseSettings.BrowserResponsePairs.Clear();
		nChartControl1.ImageAcquisitionMode = ClientSideImageAcquisitionMode.TempFile;

		NImageResponse imageResponse = new NImageResponse();
        imageResponse.ImageFormat = new NXamlImageFormat();
		imageResponse.StreamImageToBrowser = true;
		nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse;

		nChartControl1.RenderControl(null);
%>