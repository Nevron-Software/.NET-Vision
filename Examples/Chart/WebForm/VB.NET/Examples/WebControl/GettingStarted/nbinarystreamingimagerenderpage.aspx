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
		Dim title As NLabel = nChartControl1.Labels.AddHeader("Binary Streaming Image")
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
		chart.BoundsMode = BoundsMode.Fit
		chart.Location = New NPointL(New NLength(6, NRelativeUnit.ParentPercentage), New NLength(14, NRelativeUnit.ParentPercentage))
		chart.Size = New NSizeL(New NLength(75, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

		' add the first bar
		Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
		bar1.Name = "Bar1"
		bar1.MultiBarMode = MultiBarMode.Series
		bar1.BarShape = BarShape.SmoothEdgeBar
		bar1.DataLabelStyle.Visible = False

		' add the second bar
		Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
		bar2.Name = "Bar2"
		bar2.MultiBarMode = MultiBarMode.StackedPercent
		bar2.BarShape = BarShape.SmoothEdgeBar
		bar2.DataLabelStyle.Visible = False

		' add the third bar
		Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
		bar3.Name = "Bar3"
		bar3.MultiBarMode = MultiBarMode.StackedPercent
		bar3.BarShape = BarShape.SmoothEdgeBar
		bar3.DataLabelStyle.Visible = False

		Dim random As System.Random = New System.Random()

		bar1.Values.FillRandomRange(random, 5, 10, 30)
		bar2.Values.FillRandomRange(random, 5, 10, 30)
		bar3.Values.FillRandomRange(random, 5, 10, 30)

		' apply style sheet
		Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
		styleSheet.Apply(nChartControl1.Document)

		nChartControl1.ServerSettings.BrowserResponseSettings.BrowserResponsePairs.Clear()

		Dim imageResponse As NImageResponse = New NImageResponse()
		imageResponse.StreamImageToBrowser = True
		nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse

		nChartControl1.RenderControl(Nothing)
%>
