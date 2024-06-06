Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomSeriesUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Custom Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup Y axis
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' configure X axis
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

			' add a custom series and set its callback object
			Dim customSeries As NCustomSeries = New NCustomSeries()
			chart.Series.Add(customSeries)

			' create a paint callback object for the custom series
			Dim callback As MyCustomBezierSeries = New MyCustomBezierSeries(chart, customSeries)
			customSeries.Callback = callback
			callback.Points = New NPointF() { New NPointF(10, 20), New NPointF(55, 60), New NPointF(65, 180), New NPointF(110, 102), New NPointF(150, 99), New NPointF(225, 180), New NPointF(190, 202), New NPointF(160, 221), New NPointF(230, 45), New NPointF(200, 21) }


			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Public Class MyCustomBezierSeries
            Implements INCustomSeriesCallback
			#Region "Constructors"

			Public Sub New(ByVal chart As NChart, ByVal series As NCustomSeries)
				m_Chart = chart
				m_Series = series

				PointFill = New NColorFillStyle(Color.Red)
				ControlPointFill = New NColorFillStyle(Color.DarkOliveGreen)
				BezierStroke = New NStrokeStyle(1, Color.Indigo)
				TangentStroke = New NStrokeStyle(1, Color.OliveDrab)
			End Sub

			#End Region

			#Region "INCustomSeriesCallback Members"

            Private Sub GetAxisRanges(<System.Runtime.InteropServices.Out()> ByRef rangeX As NRange1DD, <System.Runtime.InteropServices.Out()> ByRef rangeY As NRange1DD) Implements INCustomSeriesCallback.GetAxisRanges
                If (Points Is Nothing) OrElse (Points.Length = 0) Then
                    rangeX.Begin = Double.NaN
                    rangeX.End = Double.NaN
                    rangeY.Begin = Double.NaN
                    rangeY.End = Double.NaN
                Else
                    'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
                    'ORIGINAL LINE: rangeX.End = rangeX.Begin = Points[0].X;
                    rangeX.End = rangeX.Begin = Points(0).X
                    'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
                    'ORIGINAL LINE: rangeY.End = rangeY.Begin = Points[0].Y;
                    rangeY.End = rangeY.Begin = Points(0).Y

                    Dim i As Integer = 1
                    Do While i < Points.Length
                        Dim point As NPointF = Points(i)

                        If point.X > rangeX.End Then
                            rangeX.End = point.X
                        ElseIf point.X < rangeX.Begin Then
                            rangeX.Begin = point.X
                        End If

                        If point.Y > rangeY.End Then
                            rangeY.End = point.Y
                        ElseIf point.Y < rangeY.Begin Then
                            rangeY.Begin = point.Y
                        End If
                        i += 1
                    Loop

                    rangeX.Inflate(0.1 * rangeX.GetLength())
                    rangeY.Inflate(0.1 * rangeY.GetLength())
                End If
            End Sub

			Private Sub Paint2D(ByVal context As NChartRenderingContext2D, ByVal graphics As NGraphics) Implements INCustomSeriesCallback.Paint2D
				Dim vecView As NVector3DF = New NVector3DF()
				Dim vecModel As NVector3DF = New NVector3DF()
				Dim rulerX As NScaleRuler = m_Chart.Axis(m_Series.HorizontalAxes(0)).Scale.Ruler
				Dim rulerY As NScaleRuler = m_Chart.Axis(m_Series.VerticalAxes(0)).Scale.Ruler

				' current number of accumulated Bezier points
				Dim bpCount As Integer = 0

				' accumulated Bezier points
				Dim bezierPoints As PointF() = New PointF(3){}

				Dim i As Integer = 0
				Do While i < Points.Length
					' Transform values to chart model coorinates
					vecModel.X = rulerX.LogicalToScale(Points(i).X)
					vecModel.Y = rulerY.LogicalToScale(Points(i).Y)

					' Transform model coordinates to view coordinates
					m_Chart.TransformModelToView(vecModel, vecView)

					' Draw the current point
					Dim isControlPoint As Boolean = (i Mod 3) <> 0
					If isControlPoint Then
						Dim rect As NRectangleF = New NRectangleF(vecView.X - 3, vecView.Y - 3, 6, 6)
						graphics.PaintEllipse(ControlPointFill, Nothing, rect)
					Else
						Dim rect As NRectangleF = New NRectangleF(vecView.X - 5, vecView.Y - 5, 10, 10)
						graphics.PaintEllipse(PointFill, Nothing, rect)
					End If

					' Accumulate Bezier point
					bezierPoints(bpCount) = New PointF(vecView.X, vecView.Y)
					bpCount += 1

					If bpCount = 4 Then
						' Draw tangents
						graphics.DrawLine(TangentStroke, New NPointF(bezierPoints(0)), New NPointF(bezierPoints(1)))
						graphics.DrawLine(TangentStroke, New NPointF(bezierPoints(2)), New NPointF(bezierPoints(3)))

						' Draw Bezier line
						Dim path As GraphicsPath = New GraphicsPath()
						path.AddBezier(bezierPoints(0), bezierPoints(1), bezierPoints(2), bezierPoints(3))
						graphics.PaintPath(Nothing, BezierStroke, path)
						path.Dispose()

						' Update accumultaed points
						bezierPoints(0) = bezierPoints(3)
						bpCount = 1
					End If
					i += 1
				Loop
			End Sub

			#End Region

			#Region "Fields"

			Private m_Chart As NChart
			Private m_Series As NCustomSeries
			Public Points As NPointF()
			Public PointFill As NFillStyle
			Public ControlPointFill As NFillStyle
			Public BezierStroke As NStrokeStyle
			Public TangentStroke As NStrokeStyle

			#End Region
		End Class
	End Class
End Namespace
