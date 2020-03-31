Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisMinMaxUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Min Max")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Location = New NPointL(New NLength(98, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(13, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(96, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))

			chart.PaintCallback = New PaintCallback(Me)

			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.RoundToTickMin = False
			linearScaleConfigurator.RoundToTickMax = False
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash

			Dim ordinalScaleConfigurtor As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurtor.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScaleConfigurtor.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash

			NewPointSeries(chart, Color.Khaki)
			NewPointSeries(chart, Color.Green)

			GenerateData(6)
		End Sub

		#Region "Nested Classes"

		Public Class PaintCallback
			Inherits NPaintCallback
			#Region "Constructors"

			Public Sub New(ByVal userControl As NAxisMinMaxUC)
				m_UserControl = userControl
			End Sub

			#End Region

			#Region "INPaintCallback Members"

			Public Overrides Sub OnBeforePaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs)
				Dim chart As NChart = TryCast(panel, NChart)
				Dim rulerRange As NRange1DD = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange

				Dim label As NLabel = New NLabel()
				label.Location = New NPointL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
				label.ContentAlignment = ContentAlignment.BottomLeft
				label.TextStyle.FontStyle.EmSize = New NLength(10)
				label.Text = " Min[" & rulerRange.Begin & "] Max[" & rulerRange.End & "]"

				chart.ChildPanels.Add(label)
				chart.RecalcLayout(eventArgs.Context)
			End Sub

			#End Region

			#Region "Fields"

			Private m_UserControl As NAxisMinMaxUC

			#End Region
		End Class

		#End Region

		Private Function NewPointSeries(ByVal chart As NChart, ByVal color As Color) As NLineSeries
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Line Series"
			line.BorderStyle = New NStrokeStyle(color)
			line.DataLabelStyle.Visible = False
			Dim marker As NMarkerStyle = New NMarkerStyle()
			marker.PointShape = PointShape.Ellipse
			marker.Visible = True
			marker.FillStyle = New NColorFillStyle(color)
			line.MarkerStyle = marker

			Return line
		End Function

		Private Sub GenerateData(ByVal itemCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim seriesCount As Integer = chart.Series.Count

			Dim i As Integer = 0
			Do While i < seriesCount
				Dim series As NSeries = CType(chart.Series(i), NSeries)
				series.Values.FillRandomRange(Random, itemCount, -100, 100)
				i += 1
			Loop
		End Sub

		Protected Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			GenerateData(6)
		End Sub
	End Class
End Namespace
