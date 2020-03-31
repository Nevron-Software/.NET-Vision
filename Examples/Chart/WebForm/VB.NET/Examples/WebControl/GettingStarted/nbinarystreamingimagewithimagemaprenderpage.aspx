<%@ Page language="vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Import namespace ="System.Drawing"%>
<%@ Import namespace ="Nevron.UI.WebForm.Controls"%>
<%@ Import namespace ="Nevron.Chart.WebForm"%>
<%@ Import namespace ="Nevron.Chart"%>
<%@ Import namespace ="Nevron"%>
<%@ Import namespace ="Nevron.GraphicsCore"%>
<%
	Dim nChartControl1 As NChartControl = New NChartControl()
	nChartControl1.Page = Me
	nChartControl1.Width = 420
	nChartControl1.Height = 320
	nChartControl1.BackgroundStyle.FrameStyle.Visible = False

	' set a chart title
	Dim title As NLabel = nChartControl1.Labels.AddHeader("HTML Image Map and Binary Streaming")
	title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
	title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
	title.ContentAlignment = ContentAlignment.BottomCenter
	title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

	' setup the legend
	Dim legend As NLegend = nChartControl1.Legends(0)
	legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)

	' setup a pie chart
	Dim chart As NPieChart = New NPieChart()
	nChartControl1.Charts.Clear()
	nChartControl1.Charts.Add(chart)
	chart.DisplayOnLegend = legend
	chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(17, NRelativeUnit.ParentPercentage))
	chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(66, NRelativeUnit.ParentPercentage))
	chart.InnerRadius = New NLength(20, NRelativeUnit.ParentPercentage)

	' add a pie series
	Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)

	pie.PieStyle = PieStyle.Torus
	pie.LabelMode = PieLabelMode.Rim
	pie.DataLabelStyle.Format = "<label> <percent>"
	pie.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
	pie.Legend.Mode = SeriesLegendMode.DataPoints
	pie.Legend.Format = "<label> <value>"
	pie.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)

	pie.AddDataPoint(New NDataPoint(12, "Metals"))
	pie.AddDataPoint(New NDataPoint(42, "Glass"))
	pie.AddDataPoint(New NDataPoint(23, "Plastics"))
	pie.AddDataPoint(New NDataPoint(56, "Paper"))
	pie.AddDataPoint(New NDataPoint(23, "Other"))

	' apply style sheet
	Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
	styleSheet.Apply(nChartControl1.Document)

	' configure the chart to binary stream the image
	Dim imageResponse As NImageResponse = New NImageResponse()
	imageResponse.StreamImageToBrowser = True

	nChartControl1.ServerSettings.BrowserResponseSettings.BrowserResponsePairs.Clear()
	nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse
	nChartControl1.RenderControl(Nothing)
%>
