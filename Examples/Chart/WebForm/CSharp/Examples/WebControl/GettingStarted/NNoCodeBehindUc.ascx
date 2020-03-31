<%@ Import namespace ="System.Drawing"%>
<%@ Import namespace ="Nevron"%>
<%@ Import namespace ="Nevron.GraphicsCore"%>
<%@ Import namespace ="Nevron.Chart"%>
<%@ Import namespace ="Nevron.Chart.WebForm"%>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
<%
	NChartControl nChartControl1 = new NChartControl();
    nChartControl1.Width = 420;
    nChartControl1.Height = 320;
    nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
    nChartControl1.Settings.JitterMode = JitterMode.Enabled;

    // set a chart title
    NLabel title = nChartControl1.Labels.AddHeader("No Code Behind");
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
	chart.Enable3D = true;
	chart.Axis(StandardAxis.Depth).Visible = false;
	chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
	chart.BoundsMode = BoundsMode.Fit;
	chart.Location = new NPointL(
		new NLength(9, NRelativeUnit.ParentPercentage),
		new NLength(12, NRelativeUnit.ParentPercentage));
	chart.Size = new NSizeL(
		new NLength(75, NRelativeUnit.ParentPercentage),
		new NLength(80, NRelativeUnit.ParentPercentage));

	// add the first bar
	NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
	bar1.Name = "Bar1";
	bar1.MultiBarMode = MultiBarMode.Series;
    bar1.DataLabelStyle.Visible = false;
    bar1.BarShape = BarShape.SmoothEdgeBar;
    bar1.HasTopEdge = false;

	// add the second bar
	NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
	bar2.Name = "Bar2";
	bar2.MultiBarMode = MultiBarMode.Stacked;
    bar2.DataLabelStyle.Visible = false;
    bar2.BarShape = BarShape.SmoothEdgeBar;
    bar2.HasTopEdge = false;
    bar2.HasBottomEdge = false;

	// add the third bar
	NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
	bar3.Name = "Bar3";
	bar3.MultiBarMode = MultiBarMode.Stacked;
    bar3.DataLabelStyle.Visible = false;
	bar3.BarShape = BarShape.SmoothEdgeBar;
    bar3.HasBottomEdge = false;
    
	Random random = new Random();
	bar1.Values.FillRandomRange(random, 5, 10, 50);
	bar2.Values.FillRandomRange(random, 5, 10, 50);
	bar3.Values.FillRandomRange(random, 5, 10, 50);

    // apply style sheet
    NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
    styleSheet.Apply(nChartControl1.Document);

    HtmlTextWriter writer = new HtmlTextWriter(Page.Response.Output);
    nChartControl1.RenderControl(writer);
	
	Page.Controls.Add(nChartControl1);
%>
<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
Demonstrates Nevron Chart for .NET used in an ASPX page with no code behind. 
This feature can be very useful when you have to port legacy ASP applications 
to ASP .NET
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
