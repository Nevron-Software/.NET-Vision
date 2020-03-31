Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NServerSideEventsToolUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim serverMouseEventTool As NServerMouseEventTool

			If (Not NThinChartControl1.Initialized) Then
				' enable jittering (full scene antialiasing)
				NThinChartControl1.Settings.JitterMode = JitterMode.Enabled
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False

				' set a chart title
				Dim title As NLabel = NThinChartControl1.Labels.AddHeader("Server Side Events Tool")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				title.ContentAlignment = ContentAlignment.BottomRight
				title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

				' setup legend
				Dim legend As NLegend = NThinChartControl1.Legends(0)
				legend.FillStyle.SetTransparencyPercent(50)
				legend.Data.ExpandMode = LegendExpandMode.RowsFixed
				legend.Data.RowCount = 2
				legend.ContentAlignment = ContentAlignment.TopLeft
				legend.Location = New NPointL(New NLength(99, NRelativeUnit.ParentPercentage), New NLength(99, NRelativeUnit.ParentPercentage))

				' by default the control contains a Cartesian chart -> remove it and create a Pie chart
				Dim chart As NChart = New NPieChart()
				NThinChartControl1.Charts.Clear()
				NThinChartControl1.Charts.Add(chart)

				' configure the chart
				chart.Enable3D = True
				chart.DisplayOnLegend = NThinChartControl1.Legends(0)
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
				chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
				chart.BoundsMode = BoundsMode.Fit
				chart.Location = New NPointL(New NLength(12, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(76, NRelativeUnit.ParentPercentage), New NLength(68, NRelativeUnit.ParentPercentage))

				' add a pie serires
				Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
				pie.PieStyle = PieStyle.SmoothEdgePie
				pie.PieEdgePercent = 50
				pie.DataLabelStyle.Visible = False
				pie.Legend.Mode = SeriesLegendMode.DataPoints
				pie.Legend.Format = "<label> <percent>"
				pie.Legend.TextStyle.FontStyle = New NFontStyle("Arial", 8)

				pie.AddDataPoint(New NDataPoint(0, "Ships"))
				pie.AddDataPoint(New NDataPoint(0, "Trains"))
				pie.AddDataPoint(New NDataPoint(0, "Cars"))
				pie.AddDataPoint(New NDataPoint(0, "Buses"))
				pie.AddDataPoint(New NDataPoint(0, "Airplanes"))

				pie.Values.FillRandomRange(Random, pie.Values.Count, 1, 20)
				Dim i As Integer = 0
				Do While i < pie.Values.Count
					pie.Detachments.Add(0)
					i += 1
				Loop

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(NThinChartControl1.Document)

				' configure the controller
				serverMouseEventTool = New NServerMouseEventTool()
				NThinChartControl1.Controller.Tools.Add(serverMouseEventTool)
			Else
				serverMouseEventTool = TryCast(NThinChartControl1.Controller.Tools(0), NServerMouseEventTool)
			End If

			' subscribe / unsubscribe to mouse down
			If MouseDownCheckBox.Checked Then
				serverMouseEventTool.MouseDown = New NDetachPieSliceMouseEventCallback()
			Else
				serverMouseEventTool.MouseDown = Nothing
			End If

			' subscribe / unsubscribe to mouse move
			If MouseMoveCheckBox.Checked Then
				serverMouseEventTool.MouseMove = New NDetachPieSliceMouseEventCallback()
			Else
				serverMouseEventTool.MouseMove = Nothing
			End If

			' subscribe / unsubscribe to mouse up
			If MouseUpCheckBox.Checked Then
				serverMouseEventTool.MouseUp = New NDetachPieSliceMouseEventCallback()
			Else
				serverMouseEventTool.MouseUp = Nothing
			End If

			''' // subscribe / unsubscribe to mouse hover
			If MouseOverCheckBox.Checked Then
				serverMouseEventTool.MouseOver = New NDetachPieSliceMouseEventCallback()
			Else
				serverMouseEventTool.MouseOver = Nothing
			End If

			' subscribe / unsubscribe to mouse leave
			If MouseLeaveCheckBox.Checked Then
				serverMouseEventTool.MouseLeave = New NCollapseAllPieSlicesMouseEventCallback()
			Else
				serverMouseEventTool.MouseLeave = Nothing
			End If

			' subscribe / unsubscribe to mouse enter
			If MouseEnterCheckBox.Checked Then
				serverMouseEventTool.MouseEnter = New NDetachAllPieSlicesMouseEventCallback()
			Else
				serverMouseEventTool.MouseEnter = Nothing
			End If
		End Sub

		<Serializable> _
		Public Class NDetachPieSliceMouseEventCallback
            Implements INMouseEventCallback
			#Region "INMouseEventCallback Members"

			Private Sub OnMouseEvent(ByVal control As NAspNetThinWebControl, ByVal e As NBrowserMouseEventArgs) Implements INMouseEventCallback.OnMouseEvent
				Dim chartControl As NThinChartControl = CType(control, NThinChartControl)

				Dim pieChart As NPieChart = CType(chartControl.Charts(0), NPieChart)
				Dim hitTestResult As NHitTestResult = chartControl.HitTest(e.X, e.Y)

				Dim dataPointIndex As Integer = hitTestResult.DataPointIndex

				' collapse all pie slices
				Dim pieSeries As NPieSeries = CType(pieChart.Series(0), NPieSeries)
				Dim i As Integer = 0
				Do While i < pieSeries.Values.Count
					pieSeries.Detachments(i) = 0
					i += 1
				Loop

				' expand the one that's hit
				If dataPointIndex <> -1 Then
					pieSeries.Detachments(dataPointIndex) = 5.0f
				End If

				chartControl.UpdateView()
			End Sub

			#End Region
		End Class

		<Serializable> _
		Public Class NDetachAllPieSlicesMouseEventCallback
            Implements INMouseEventCallback
			#Region "INMouseEventCallback Members"

			Private Sub OnMouseEvent(ByVal control As NAspNetThinWebControl, ByVal e As NBrowserMouseEventArgs) Implements INMouseEventCallback.OnMouseEvent
				Dim chartControl As NThinChartControl = CType(control, NThinChartControl)

				Dim pieChart As NPieChart = CType(chartControl.Charts(0), NPieChart)
				Dim pieSeries As NPieSeries = CType(pieChart.Series(0), NPieSeries)

				Dim i As Integer = 0
				Do While i < pieSeries.Values.Count
					pieSeries.Detachments(i) = 5.0f
					i += 1
				Loop

				chartControl.UpdateView()
			End Sub

			#End Region
		End Class

		<Serializable> _
		Public Class NCollapseAllPieSlicesMouseEventCallback
            Implements INMouseEventCallback
			#Region "INMouseEventCallback Members"

			Private Sub OnMouseEvent(ByVal control As NAspNetThinWebControl, ByVal e As NBrowserMouseEventArgs) Implements INMouseEventCallback.OnMouseEvent
				Dim chartControl As NThinChartControl = CType(control, NThinChartControl)

				Dim pieChart As NPieChart = CType(chartControl.Charts(0), NPieChart)

				Dim pieSeries As NPieSeries = CType(pieChart.Series(0), NPieSeries)

				Dim i As Integer = 0
				Do While i < pieSeries.Values.Count
					pieSeries.Detachments(i) = 0
					i += 1
				Loop

				chartControl.UpdateView()
			End Sub

			#End Region
		End Class
	End Class
End Namespace
