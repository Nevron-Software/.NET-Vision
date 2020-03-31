<%@ Import namespace ="System.Drawing"%>
<%@ Import namespace ="Nevron"%>
<%@ Import namespace ="Nevron.GraphicsCore"%>
<%@ Import namespace ="Nevron.Chart"%>
<%@ Import namespace ="Nevron.Chart.WebForm"%>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
<%
	Dim nChartControl1 As NChartControl = New NChartControl()
	nChartControl1.Width = 420
	nChartControl1.Height = 320
	nChartControl1.BackgroundStyle.FrameStyle.Visible = False
	nChartControl1.Settings.JitterMode = JitterMode.Enabled

	' set a chart title
	Dim title As NLabel = nChartControl1.Labels.AddHeader("No Code Behind")
	title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
	title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
	title.ContentAlignment = ContentAlignment.BottomCenter
	title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

	' setup the legend
	Dim legend As NLegend = nChartControl1.Legends(0)
	legend.ContentAlignment = ContentAlignment.MiddleLeft
	legend.Location = New NPointL(New NLength(98, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))

	' setup the chart    
	Dim chart As NChart = nChartControl1.Charts(0)
	chart.Enable3D = True
	chart.Axis(StandardAxis.Depth).Visible = False
	chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
	chart.BoundsMode = BoundsMode.Fit
	chart.Location = New NPointL(New NLength(9, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
	chart.Size = New NSizeL(New NLength(75, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

	' add the first bar
	Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
	bar1.Name = "Bar1"
	bar1.MultiBarMode = MultiBarMode.Series
	bar1.DataLabelStyle.Visible = False
	bar1.BarShape = BarShape.SmoothEdgeBar
	bar1.HasTopEdge = False

	' add the second bar
	Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
	bar2.Name = "Bar2"
	bar2.MultiBarMode = MultiBarMode.Stacked
	bar2.DataLabelStyle.Visible = False
	bar2.BarShape = BarShape.SmoothEdgeBar
	bar2.HasTopEdge = False
	bar2.HasBottomEdge = False

	' add the third bar
	Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
	bar3.Name = "Bar3"
	bar3.MultiBarMode = MultiBarMode.Stacked
	bar3.DataLabelStyle.Visible = False
	bar3.BarShape = BarShape.SmoothEdgeBar
	bar3.HasBottomEdge = False

	Dim random As Random = New Random()
	bar1.Values.FillRandomRange(random, 5, 10, 50)
	bar2.Values.FillRandomRange(random, 5, 10, 50)
	bar3.Values.FillRandomRange(random, 5, 10, 50)

	' apply style sheet
	Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
	styleSheet.Apply(nChartControl1.Document)

	Dim writer As HtmlTextWriter = New HtmlTextWriter(Page.Response.Output)
	nChartControl1.RenderControl(writer)

	Page.Controls.Add(nChartControl1)
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
