Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NInteractivePieChartUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private m_Pie As NPieSeries
		Private m_DefaultFillStyles() As NFillStyle

		Public Sub New()
			InitializeComponent()
		End Sub


		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NInteractivePieChartUC
			' 
			Me.Name = "NInteractivePieChartUC"
			Me.Size = New System.Drawing.Size(180, 72)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Exploded Pie Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = New NPieChart()
			nChartControl1.Panels.Add(chart)

			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			chart.Location = New NPointL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))

			m_Pie = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			m_Pie.PieEdgePercent = 30

			m_Pie.AddDataPoint(New NDataPoint(12, "Cars"))
			m_Pie.AddDataPoint(New NDataPoint(42, "Trains"))
			m_Pie.AddDataPoint(New NDataPoint(56, "Airplanes"))
			m_Pie.AddDataPoint(New NDataPoint(23, "Buses"))

			For i As Integer = 0 To m_Pie.Values.Count - 1
				m_Pie.Detachments.Add(0)
			Next i

			m_DefaultFillStyles = New NFillStyle(3){}
			Dim palette As New NChartPalette()
			palette.SetPredefinedPalette(ChartPredefinedPalette.Winter)

			m_DefaultFillStyles(0) = New NColorFillStyle(palette.SeriesColors(0))
			m_DefaultFillStyles(1) = New NColorFillStyle(palette.SeriesColors(1))
			m_DefaultFillStyles(2) = New NColorFillStyle(palette.SeriesColors(2))
			m_DefaultFillStyles(3) = New NColorFillStyle(palette.SeriesColors(3))

			For i As Integer = 0 To m_DefaultFillStyles.Length - 1
				m_Pie.FillStyles(i) = m_DefaultFillStyles(i)
			Next i

			SetPieDefaultFillStyles()

			m_Pie.PieStyle = PieStyle.SmoothEdgePie

			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints
			m_Pie.Legend.Format = "<label> <percent>"

			' subscribe for control events
			AddHandler nChartControl1.MouseDown, AddressOf ChartControl_MouseDown
			AddHandler nChartControl1.MouseMove, AddressOf ChartControl_MouseMove
		End Sub

		Private Sub SetPieDefaultFillStyles()
			For i As Integer = 0 To m_Pie.FillStyles.Count - 1
				If DirectCast(m_Pie.Detachments(i), Double) <= 0 Then
					m_Pie.FillStyles(i) = m_DefaultFillStyles(i)
				End If
			Next i
		End Sub

		Private Sub ChartControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
			If e.Button <> MouseButtons.Left Then
				Return
			End If

			Dim hitTestResult As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If hitTestResult.ChartElement = ChartElement.DataPoint Then
				For i As Integer = 0 To m_Pie.Detachments.Count - 1
					m_Pie.Detachments(i) = 0.0F
				Next i

				SetPieDefaultFillStyles()

				m_Pie.FillStyles(hitTestResult.DataPointIndex) = New NColorFillStyle(Color.Red)
				m_Pie.Detachments(hitTestResult.DataPointIndex) = 5.0F

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ChartControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
			Dim hitTestResult As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If hitTestResult.ChartElement = ChartElement.DataPoint Then
				If DirectCast(m_Pie.Detachments(hitTestResult.DataPointIndex), Double) > 0 Then
					Return
				End If

				SetPieDefaultFillStyles()
				m_Pie.FillStyles(hitTestResult.DataPointIndex) = New NColorFillStyle(Color.Orange)
			Else
				SetPieDefaultFillStyles()
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
