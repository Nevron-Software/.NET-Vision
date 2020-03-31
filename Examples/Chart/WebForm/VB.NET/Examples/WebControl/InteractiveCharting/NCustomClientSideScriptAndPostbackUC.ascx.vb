Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Image = System.Web.UI.WebControls.Image

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomClientSideScriptAndPostbackUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.ShadowStyle.Type = ShadowType.GaussianBlur
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Left)
			legend.Location = New NPointL(legend.Location.X, New NLength(50, NRelativeUnit.ParentPercentage))
			legend.ContentAlignment = ContentAlignment.BottomRight

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Transport Sales Analysis")
			header.Location = New NPointL(New NLength(97, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomLeft

			' by default the chart contains a cartesian chart which cannot display pie series
			nChartControl1.Charts.Clear()

			Dim chart As NPieChart = New NPieChart()
			chart.Enable3D = True
			nChartControl1.Charts.Add(chart)
			chart.DisplayOnLegend = nChartControl1.Legends(0)

			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)

			pie.AddDataPoint(New NDataPoint(12, "Cars", New NColorFillStyle(Color.Red)))
			pie.AddDataPoint(New NDataPoint(42, "Trains", New NColorFillStyle(Color.Gold)))
			pie.AddDataPoint(New NDataPoint(56, "Ships", New NColorFillStyle(Color.Chocolate)))
			pie.AddDataPoint(New NDataPoint(23, "Buses", New NColorFillStyle(Color.Cyan)))


			pie.InteractivityStyles.Add(0, New NInteractivityStyle("Cars", CursorType.Hand))
			pie.InteractivityStyles.Add(1, New NInteractivityStyle("Trains", CursorType.Hand))
			pie.InteractivityStyles.Add(2, New NInteractivityStyle("Ships", CursorType.Hand))
			pie.InteractivityStyles.Add(3, New NInteractivityStyle("Buses", CursorType.Hand))

			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.Legend.Format = "<label> <percent>"

			pie.PieStyle = PieStyle.SmoothEdgePie
			pie.LabelMode = PieLabelMode.Spider

			pie.LabelMode = PieLabelMode.Center
			pie.DataLabelStyle.ArrowLength = New NLength(0f, NRelativeUnit.ParentPercentage)
			pie.DataLabelStyle.ArrowPointerLength = New NLength(0f, NRelativeUnit.ParentPercentage)

			chart.LightModel.EnableLighting = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(35, NRelativeUnit.ParentPercentage), New NLength(30, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))


			 Dim imageMapResponse As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.JitteringSteps = 4

			' select the car sales by default
			If (Not IsPostBack) Then
				Dim i As Integer = 0
				Do While i < pie.Values.Count
					pie.Detachments.Add(0)
					i += 1
				Loop

				SalesOverTimeImg.ImageUrl = "NInteractiveCarSalesPage.aspx"
			End If

			ApplyImageMapAttributesToSerie(pie)

			AddHandler nChartControl1.Click, AddressOf NChartControl1_Click
		End Sub

		Protected Sub ApplyImageMapAttributesToSerie(ByVal pie As NPieSeries)
			Dim sCustomAttribute, sFader As String

			Dim interactivityStyle As NInteractivityStyle

			Dim i As Integer = 0
			Do While i < pie.Values.Count
				sFader = "bus"

				Select Case i
					Case 0
						sFader = "car"
					Case 1
						sFader = "train"
					Case 2
						sFader = "ship"
					Case 3
						sFader = "bus"
				End Select

				sCustomAttribute = "#default_mouse_click #default_mouse_move #default_title	onMouseOver=""JSFX.fadeIn('" & sFader & "')"" onMouseOut=""JSFX.fadeOut('" & sFader & "')"""

				interactivityStyle = New NInteractivityStyle()
				interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = sCustomAttribute
				interactivityStyle.GeneratePostback = True

				pie.InteractivityStyles(i) = interactivityStyle
				i += 1
			Loop
		End Sub

		Private Sub NChartControl1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim eventArgs As NPostbackEventArgs = TryCast(e, NPostbackEventArgs)
			Dim selectedNode As Object = eventArgs.Id.FindInDocument(nChartControl1.Document)

			If TypeOf selectedNode Is NDataPoint Then
				Dim dataPoint As NDataPoint = CType(selectedNode, NDataPoint)

				dataPoint(DataPointValue.PieDetachment) = 10

				Dim series As NSeries = CType(dataPoint.ParentNode, NSeries)
				series.StoreDataPoint(dataPoint.IndexInSeries, dataPoint)

				Select Case dataPoint.IndexInSeries
					Case 0
						SalesOverTimeImg.ImageUrl = "NInteractiveCarSalesPage.aspx"
					Case 1
						SalesOverTimeImg.ImageUrl = "NInteractiveTrainSalesPage.aspx"
					Case 2
						SalesOverTimeImg.ImageUrl = "NInteractiveShipSalesPage.aspx"
					Case 3
						SalesOverTimeImg.ImageUrl = "NInteractiveBusSalesPage.aspx"
				End Select
			End If
		End Sub
	End Class
End Namespace
