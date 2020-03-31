<%@ Page language="c#" %>
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
		nChartControl1.Width = 420;
		nChartControl1.Height = 320;
        nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

        // set a chart title
        NLabel title = nChartControl1.Labels.AddHeader("HTML Image Map and Binary Streaming");
        title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
        title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
        title.ContentAlignment = ContentAlignment.BottomCenter;
        title.Location = new NPointL(
            new NLength(50, NRelativeUnit.ParentPercentage),
            new NLength(2, NRelativeUnit.ParentPercentage));

        // setup the legend
        NLegend legend = nChartControl1.Legends[0];
        legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);

        // setup a pie chart
		NPieChart chart = new NPieChart();
		nChartControl1.Charts.Clear();
		nChartControl1.Charts.Add(chart);
        chart.DisplayOnLegend = legend;
        chart.Location = new NPointL(
			new NLength(10, NRelativeUnit.ParentPercentage),
			new NLength(17, NRelativeUnit.ParentPercentage));
        chart.Size = new NSizeL(
			new NLength(80, NRelativeUnit.ParentPercentage),
			new NLength(66, NRelativeUnit.ParentPercentage));
		chart.InnerRadius = new NLength(20, NRelativeUnit.ParentPercentage);

        // add a pie series
        NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
        
        pie.PieStyle = PieStyle.Torus;
        pie.LabelMode = PieLabelMode.Rim;
        pie.DataLabelStyle.Format = "<label> <percent>";
        pie.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
        pie.Legend.Mode = SeriesLegendMode.DataPoints;
        pie.Legend.Format = "<label> <value>";
        pie.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);

        pie.AddDataPoint(new NDataPoint(12, "Metals"));
		pie.AddDataPoint(new NDataPoint(42, "Glass"));
        pie.AddDataPoint(new NDataPoint(23, "Plastics"));
		pie.AddDataPoint(new NDataPoint(56, "Paper"));
        pie.AddDataPoint(new NDataPoint(23, "Other"));

        // apply style sheet
        NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
        styleSheet.Apply(nChartControl1.Document);
    
		// configure the chart to binary stream the image
		NImageResponse imageResponse = new NImageResponse();
		imageResponse.StreamImageToBrowser = true;
		
		nChartControl1.ServerSettings.BrowserResponseSettings.BrowserResponsePairs.Clear();
		nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse;
		nChartControl1.RenderControl(null);
%>
