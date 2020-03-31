Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NImageMapPostbackResponseUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			ConfigureControl(nChartControl1, "HTML Image Map with Postback " & Constants.vbCrLf & "(Server Events) in 3D mode")
			nChartControl1.Charts(0).Enable3D = True

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.JitteringSteps = 4

			ConfigureControl(nChartControl2, "HTML Image Map with Postback " & Constants.vbCrLf & "(Server Events) in 2D mode")

			AddHandler nChartControl1.Click, AddressOf NChartControl1_Click
			AddHandler nChartControl2.Click, AddressOf NChartControl2_Click
		End Sub

		Private Sub ConfigureControl(ByVal control As NChartControl, ByVal sLabel As String)
			control.BackgroundStyle.FrameStyle.Visible = False

			' generate image map respones
			Dim imageMapResponse As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			control.ServerSettings.BrowserResponseSettings.BrowserResponsePairs.Clear()
			control.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse

			' set a chart title
			Dim title As NLabel = control.Labels.AddHeader(sLabel)
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = control.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)
			legend.Data.ExpandMode = LegendExpandMode.ColsFixed
			legend.Data.ColCount = 2
			legend.ShadowStyle.Type = ShadowType.GaussianBlur

			Dim chart As NPieChart = New NPieChart()
			control.Charts.Clear()
			control.Charts.Add(chart)
			chart.DisplayOnLegend = legend
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(25, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))

			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.PieStyle = PieStyle.SmoothEdgePie
			pie.LabelMode = PieLabelMode.Rim
			pie.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.Legend.Format = "<label> <percent>"
			pie.DataLabelStyle.ArrowLength = New NLength(0f, NRelativeUnit.ParentPercentage)
			pie.DataLabelStyle.ArrowPointerLength = New NLength(0f, NRelativeUnit.ParentPercentage)

			pie.AddDataPoint(New NDataPoint(12, "Cars"))
			pie.AddDataPoint(New NDataPoint(42, "Trains"))
			pie.AddDataPoint(New NDataPoint(56, "Airplanes"))
			pie.AddDataPoint(New NDataPoint(23, "Buses"))

			pie.InteractivityStyles.Add(0, New NInteractivityStyle("Cars", CursorType.Hand))
			pie.InteractivityStyles.Add(1, New NInteractivityStyle("Trains", CursorType.Hand))
			pie.InteractivityStyles.Add(2, New NInteractivityStyle("Airplanes", CursorType.Hand))
			pie.InteractivityStyles.Add(3, New NInteractivityStyle("Buses", CursorType.Hand))

			Dim postbackAttribute As NPostbackAttribute = New NPostbackAttribute()
			Dim i As Integer = 0
			Do While i < pie.InteractivityStyles.Count
				CType(pie.InteractivityStyles(i), NInteractivityStyle).InteractivityAttributes.Add(postbackAttribute)
				pie.Detachments.Add(0)
				i += 1
			Loop

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(control.Document)
		End Sub

		Private Sub NChartControl1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim eventArgs As NPostbackEventArgs = CType(e, NPostbackEventArgs)

			Dim dp As NDataPoint = TryCast(eventArgs.Id.FindInDocument(nChartControl1.Document), NDataPoint)

			If Not dp Is Nothing Then
				Dim dataItemID As Integer = dp.IndexInSeries

				Dim pie As NPieSeries = CType(chart.Series(0), NPieSeries)
				pie.Detachments(dataItemID) = 10
			End If
		End Sub

		Private Sub NChartControl2_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim chart As NChart = nChartControl2.Charts(0)
			Dim eventArgs As NPostbackEventArgs = CType(e, NPostbackEventArgs)

			Dim dp As NDataPoint = TryCast(eventArgs.Id.FindInDocument(nChartControl2.Document), NDataPoint)

			If Not dp Is Nothing Then
				Dim dataItemID As Integer = dp.IndexInSeries

				Dim pie As NPieSeries = CType(chart.Series(0), NPieSeries)
				pie.Detachments(dataItemID) = 10
			End If
		End Sub
	End Class
End Namespace
