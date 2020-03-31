Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomCommandsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1.RequiresInitialization Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Settings.JitterMode = JitterMode.Enabled
				nChartControl1.Charts.Clear()

				Dim chart As NPieChart = New NPieChart()
				nChartControl1.Panels.Add(chart)

				chart.Enable3D = True
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
				chart.Projection.Elevation = 312
				chart.BoundsMode = BoundsMode.Fit
				chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
				chart.LightModel.LightSources(0).Specular = Color.FromArgb(64, 64, 64)
				chart.LightModel.LightSources(1).Specular = Color.FromArgb(64, 64, 64)
				chart.LightModel.LightSources(2).Specular = Color.FromArgb(64, 64, 64)
				chart.Radius = New NLength(48, NRelativeUnit.ParentPercentage)
				chart.InnerRadius = New NLength(31, NRelativeUnit.ParentPercentage)

				Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
				pie.BorderStyle = New NStrokeStyle(New NLength(5), Color.White)
				pie.PieStyle = PieStyle.Torus

				Dim arrLabels As String() = New String() {"Cars", "Trains", "Airplanes", "Buses", "Bikes", "Motorcycles", "Shuttles", "Rollers", "Ski", "Surf"}

				Dim arrData As Double() = New Double(9) { 98, 80, 57, 98, 96, 84, 54, 73, 40, 53 }

				Dim i As Integer = 0
				Do While i < arrCustomColors2.Length
					pie.Values.Add(arrData(i))
					pie.Labels.Add(arrLabels(i))
					pie.FillStyles(i) = New NColorFillStyle(arrCustomColors2(i))
					pie.BorderStyles(i) = New NStrokeStyle(1, arrCustomColors2(i))

					If i = 5 Then
						pie.Detachments.Add(5)
					Else
						pie.Detachments.Add(0)
						pie.InteractivityStyles.Add(i, New NInteractivityStyle(True, String.Format("{0} ({1})", arrLabels(i), arrData(i))))
					End If
					i += 1
				Loop
			End If
		End Sub

		Protected Sub nChartControl1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Dim command As NCallbackCommand = args.Command

			Dim pieSeries As NPieSeries
			Select Case command.Name
				Case "changeColor"
					Dim idText As String = TryCast(command.Arguments("id"), String)
					If idText Is Nothing Then
						Exit Select
					End If

					Dim id As NElementAtomIdentifier = New NElementAtomIdentifier(idText)
					Dim node As NChartNode = TryCast(id.FindInDocument(nChartControl1.Document), NChartNode)
					If node Is Nothing Then
						Exit Select
					End If
					Dim hitTestResult As NHitTestResult = New NHitTestResult(node)
					If hitTestResult.ChartElement <> ChartElement.DataPoint Then
						Exit Select
					End If
					pieSeries = TryCast(hitTestResult.Series, NPieSeries)
					If pieSeries Is Nothing Then
						Exit Select
					End If

					Dim c As Color = Color.Red
					If command.Arguments("color").ToString() = "blue" Then
						c = Color.Blue
					End If
					Dim fs As NColorFillStyle = TryCast(pieSeries.FillStyles(hitTestResult.DataPointIndex), NColorFillStyle)
					If fs Is Nothing Then
						Exit Select
					End If

					pieSeries.FillStyles(hitTestResult.DataPointIndex) = New NColorFillStyle(c)

					clientSideRedrawRequired = (Not fs.Color.Equals(c))
				Case "rotate10Degrees"
					Dim rootPanel As NRootPanel = nChartControl1.Document.RootPanel
					Dim pieChart As NPieChart = TryCast(nChartControl1.Charts(0), NPieChart)
					pieChart.BeginAngle += 10
					If pieChart.BeginAngle >= 360 Then
						pieChart.BeginAngle = pieChart.BeginAngle - 360
					End If
			End Select
		End Sub

		Protected Sub nChartControl1_AsyncQueryCommandResult(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackQueryCommandResultArgs = TryCast(e, NCallbackQueryCommandResultArgs)
			Dim command As NCallbackCommand = args.Command
			Dim resultBuilder As NAjaxXmlTransportBuilder = args.ResultBuilder

			Dim pieSeries As NPieSeries
			Select Case command.Name
				Case "queryCurrentAngle"
					'	build a custom response data section
					Dim rootPanel As NRootPanel = nChartControl1.Document.RootPanel
					Dim pieChart As NPieChart = TryCast(nChartControl1.Charts(0), NPieChart)

					Dim dataSection As NAjaxXmlDataSection = New NAjaxXmlDataSection("angle")
					dataSection.Data = pieChart.BeginAngle.ToString()
					resultBuilder.AddDataSection(dataSection)

				Case "changeColor"
					'	add a built-in data section that will enforce full image refresh at the client
					If clientSideRedrawRequired AndAlso (Not resultBuilder.ContainsRedrawDataSection()) Then
						resultBuilder.AddRedrawDataSection(nChartControl1)
					End If

				Case "rotate10Degrees"
					If (Not resultBuilder.ContainsRedrawDataSection()) Then
						resultBuilder.AddRedrawDataSection(nChartControl1)
					End If
			End Select
		End Sub

		Protected Sub nChartControl1_AsyncRefresh(ByVal sender As Object, ByVal e As EventArgs)
			Dim rootPanel As NRootPanel = nChartControl1.Document.RootPanel
			Dim pieChart As NPieChart = TryCast(nChartControl1.Charts(0), NPieChart)
			pieChart.BeginAngle += 1
			If pieChart.BeginAngle >= 360 Then
				pieChart.BeginAngle = 0
			End If
		End Sub

		#Region "Fields"

		Private clientSideRedrawRequired As Boolean = False

		#End Region
	End Class
End Namespace
