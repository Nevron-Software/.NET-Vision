Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Dom

Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Class NChartZoomHttpHandler
		Implements IHttpHandler
		Public Sub New()
		End Sub

		#Region "IHttpHandler Implementation"

		Private Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
			Dim populationDataId As Integer
			Dim dataPointId As Integer
			If context.Request("id") Is Nothing Then
				Return
			End If

			Dim tokens As String() = context.Request("id").Split(New Char() {":"c}, StringSplitOptions.RemoveEmptyEntries)
			If tokens.Length <> 2 Then
				Return
			End If

			If (Not Integer.TryParse(tokens(0), populationDataId)) Then
				Return
			End If
			If (Not Integer.TryParse(tokens(1), dataPointId)) Then
				Return
			End If

			Dim data As NCustomToolsData.NData = NCustomToolsData.Read()

			Dim ms As MemoryStream = New MemoryStream()
			Dim chartSize As NSize = New NSize(500, 200)
			Dim document As NDocument = CreateDocument(chartSize, data, populationDataId, dataPointId)
			Dim imageFormat As NPngImageFormat = New NPngImageFormat()
			Using image As INImage = CreateImage(document, chartSize, imageFormat)
				document.Refresh()
				image.SaveToStream(ms, imageFormat)
			End Using

			Dim bytes As Byte() = ms.GetBuffer()
			context.Response.ContentType = "image/png"
			context.Response.OutputStream.Write(bytes, 0, bytes.Length)
			context.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate)
		End Sub

		Private ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
			Get
				Return True
			End Get
		End Property

		#End Region

		Private Function CreateDocument(ByVal chartSize As NSize, ByVal data As NCustomToolsData.NData, ByVal populationDataId As Integer, ByVal dataPointId As Integer) As NDocument
			Dim document As NDocument = New NDocument()
			document.RootPanel.Charts.Clear()

			' set a chart title
			Dim sex As String
			Dim total As String
			If populationDataId = data.TotalFemaleData.Id Then
				sex = "Female"
				total = String.Format("{0:0,#} +/-{1:0,#}", data.TotalFemaleData.Rows(dataPointId).Value, data.TotalFemaleData.Rows(dataPointId).Error)
			Else
				sex = "Male"
				total = String.Format("{0:0,#} +/-{1:0,#}", data.TotalMaleData.Rows(dataPointId).Value, data.TotalMaleData.Rows(dataPointId).Error)
			End If
			Dim header As NLabel = document.RootPanel.Labels.AddHeader(String.Format("{0}, {1}, Population Data per Race<br/><font size='9pt'>Total of All Races: {2}</font>", sex, data.AgeRanges(dataPointId).Title, total))
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 13, FontStyle.Italic)
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

			' add the chart
			Dim chart As NCartesianChart = New NCartesianChart()
			document.RootPanel.Charts.Add(chart)

			chart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft)
			chart.Margins = New NMarginsL(9, 40, 9, 9)
			chart.Location = New NPointL(New NLength(0, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			chart.Width = chartSize.Width + 180
			chart.Height = chartSize.Height

			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.LabelValueFormatter = New NNumericValueFormatter("0,,.#M")

			Dim scaleX As NOrdinalScaleConfigurator = New NOrdinalScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.CustomTicks
			scaleX.CustomLabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }
			scaleX.CustomLabelsLevelOffset = New NLength(4)

			Dim barSeries As NBarSeries = TryCast(chart.Series.Add(SeriesType.Bar), NBarSeries)
			barSeries.DataLabelStyle.Visible = False

			Dim length As Integer = data.Races.Count
			Dim i As Integer = 0
			Do While i < length
				Dim race As NCustomToolsData.NRace = data.Races(i)
				Dim value As Double
				If populationDataId = race.MaleData.Id Then
					value = race.MaleData.Rows(dataPointId).Value
				Else
					value = race.FemaleData.Rows(dataPointId).Value
				End If
				barSeries.Values.Add(value)
				Dim vl As NCustomValueLabel = New NCustomValueLabel(i, race.Title)
				vl.Style.ContentAlignment = ContentAlignment.MiddleRight
				scaleX.CustomLabels.Add(vl)
				i += 1
			Loop

			Return document
		End Function

		Protected Function CreateImage(ByVal document As NDocument, ByVal size As NSize, ByVal imageFormat As NPngImageFormat) As INImage
			Dim imageFormatProvider As INImageFormatProvider = New NChartRasterImageFormatProvider(document)
			Return imageFormatProvider.ProvideImage(size, NResolution.ScreenResolution, imageFormat)
		End Function
	End Class
End Namespace
