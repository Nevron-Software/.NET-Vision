Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomSeriesUC
		Inherits NExampleBaseUC
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
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
			' NCustomSeriesUC
			' 
			Me.Name = "NCustomSeriesUC"
			Me.Size = New System.Drawing.Size(188, 181)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Custom Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' obtain a reference to the default chart
			Dim chart As NChart = nChartControl1.Charts(0)

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

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		<Serializable> _
		Private Class MyCustomBezierSeries
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

			#Region "INCustomSeriesCallback"

			''' <summary>
			''' Returns the X and Y axis ranges
			''' </summary>
			''' <param name="rangeX"></param>
			''' <param name="rangeY"></param>
            Public Sub GetAxisRanges(<System.Runtime.InteropServices.Out()> ByRef rangeX As NRange1DD, <System.Runtime.InteropServices.Out()> ByRef rangeY As NRange1DD) Implements INCustomSeriesCallback.GetAxisRanges

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
			''' <summary>
			''' Performs custom painting
			''' </summary>
			''' <param name="context"></param>
			''' <param name="graphics"></param>
            Public Sub Paint2D(ByVal context As NChartRenderingContext2D, ByVal graphics As NGraphics) Implements INCustomSeriesCallback.Paint2D
                Dim vecView As NVector3DF = New NVector3DF()
                Dim vecModel As NVector3DF = New NVector3DF()
                Dim rulerX As NScaleRuler = m_Chart.Axis(m_Series.HorizontalAxes(0)).Scale.Ruler
                Dim rulerY As NScaleRuler = m_Chart.Axis(m_Series.VerticalAxes(0)).Scale.Ruler

                ' current number of accumulated Bezier points
                Dim bpCount As Integer = 0

                ' accumulated Bezier points
                Dim bezierPoints As PointF() = New PointF(3) {}

                Dim i As Integer = 0
                Do While i < Points.Length
                    ' Transform values to chart model coorinates
                    vecModel.X = rulerX.LogicalToScale(Points(i).X)
                    vecModel.Y = rulerY.LogicalToScale(Points(i).Y)

                    ' Transform model coordinates to view coordinates
                    m_Chart.TransformModelToClient(vecModel, vecView)

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