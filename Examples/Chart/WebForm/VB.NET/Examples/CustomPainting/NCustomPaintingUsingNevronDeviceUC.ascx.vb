Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomPaintingUsingNevronDeviceUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				ShowDownwardArrowsCheckBox.Checked = True
				ShowUpwardArrowsCheckBox.Checked = True
				ShowEqualSignsCheckBox.Checked = True
			End If

			ConfigureChart("Custom Painting with Nevron Device")
			ChangeData()
		End Sub

		#Region "Drawing Helpers"

		Protected Shared Function CalcEdgeRectSize(ByVal fWidth As Single, ByVal fHeight As Single) As Single
			Dim fEdgePercent As Single = 30.0f
			Dim fMinDimension As Single = Math.Min(fWidth, fHeight)

			Return fMinDimension * (fEdgePercent / 50.0f)
		End Function

		Protected Shared Function GetArrowPath(ByVal rect As RectangleF, ByVal bUpArrow As Boolean) As GraphicsPath
			Dim lines As PointF() = New PointF(6){}

			Dim rcArrowModel As RectangleF = New RectangleF(-50, -50, 100, 100)

			Dim fArrowHeadWidth As Single = rcArrowModel.Width * 30.0f / 100.0f
			Dim fArrowRectHeight As Single = rcArrowModel.Height * 30.0f / 100.0f
			Dim fArrowHeadEnd As Single = rcArrowModel.Left + fArrowHeadWidth

			lines(0) = New PointF(rcArrowModel.Right, rcArrowModel.Bottom - (rcArrowModel.Height - fArrowRectHeight) / 2)
			lines(1) = New PointF(fArrowHeadEnd, lines(0).Y)
			lines(2) = New PointF(fArrowHeadEnd, rcArrowModel.Bottom)
			lines(3) = New PointF(rcArrowModel.Left, rcArrowModel.Top + rcArrowModel.Height / 2)
			lines(4) = New PointF(fArrowHeadEnd, rcArrowModel.Top)
			lines(5) = New PointF(fArrowHeadEnd, rcArrowModel.Top + (rcArrowModel.Height - fArrowRectHeight) / 2)
			lines(6) = New PointF(rcArrowModel.Right, lines(5).Y)

			Dim path As GraphicsPath = New GraphicsPath()

			path.AddLines(lines)
			path.CloseAllFigures()

			Dim matrix As Matrix = New Matrix()
			matrix.Reset()

			If bUpArrow Then
				matrix.Rotate(90, MatrixOrder.Append)
			Else
				matrix.Rotate(-90, MatrixOrder.Append)
			End If

			matrix.Scale(rect.Width / rcArrowModel.Width, rect.Height / rcArrowModel.Height)
			matrix.Translate(rect.Left + rect.Width / 2.0f, rect.Top + rect.Height / 2.0f, MatrixOrder.Append)

			path.Transform(matrix)
			matrix.Dispose()

			Return path
		End Function

		Protected Shared Function GetRoundRectanglePath(ByVal rect As RectangleF) As GraphicsPath
			Dim fEdgeM2 As Single = CalcEdgeRectSize(rect.Width, rect.Height)

			Dim path As GraphicsPath = New GraphicsPath()

			path.AddArc(rect.Right - fEdgeM2, rect.Bottom - fEdgeM2, fEdgeM2, fEdgeM2, 0, 90)
			path.AddArc(rect.Left, rect.Bottom - fEdgeM2, fEdgeM2, fEdgeM2, 90, 90)
			path.AddArc(rect.Left, rect.Top, fEdgeM2, fEdgeM2, 180, 90)
			path.AddArc(rect.Right - fEdgeM2, rect.Top, fEdgeM2, fEdgeM2, 270, 90)

			path.CloseAllFigures()

			Return path
		End Function

		#End Region

		#Region "Chart Configuration"

		Protected Sub ChangeData()
			Dim nBarCount As Integer = 10
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.ClearDataPoints()

			Dim dp As NDataPoint = New NDataPoint()

			Dim i As Integer = 0
			Do While i < nBarCount
				dp(DataPointValue.Value) = nBarCount / 2 - Random.Next(nBarCount)

				bar.AddDataPoint(dp)
				i += 1
			Loop
		End Sub

		Protected Sub ConfigureChart(ByVal title As String)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader(title)
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomCenter
			header.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Legends.Clear()

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' add bar and change bar color
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red)
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.BarShape = BarShape.Cylinder
			bar.ShadowStyle.Offset = New NPointL(3, 3)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.DataLabelStyle.Visible = False

			chart.PaintCallback = New PaintCallback(ShowDownwardArrowsCheckBox.Checked, ShowUpwardArrowsCheckBox.Checked, ShowEqualSignsCheckBox.Checked)
		End Sub

		#End Region

		#Region "Nested Classes"

		Public Class PaintCallback
			Inherits NPaintCallback
			#Region "Constructors"

			Public Sub New(ByVal showDownwardArrows As Boolean, ByVal showUpwardArrows As Boolean, ByVal showEqualSigns As Boolean)
				Me.showDownwardArrows = showDownwardArrows
				Me.showUpwardArrows = showUpwardArrows
				Me.showEqualSigns = showEqualSigns
			End Sub

			#End Region

			#Region "NPaintCallback Members"

			Public Overrides Sub OnAfterPaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs)
				Dim graphics As NGraphics = eventArgs.Graphics

				Dim dPreviousValue, dCurrentValue As Double
				Dim nBarCount As Integer = 10
				Dim chart As NChart = TryCast(panel, NChart)
				Dim bar As NBarSeries = CType(chart.Series(0), NBarSeries)

				Dim horzAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
				Dim vertAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)

				Dim vecClientPoint As NVector3DF = New NVector3DF()
				Dim vecModelPoint As NVector3DF = New NVector3DF()

				Dim nBarSize As Integer = CInt(Fix(chart.ContentArea.Width * CInt(Fix(bar.WidthPercent)))) / (nBarCount * 200)

				' init pens and brushes
				Dim rectStrokeStyle As NStrokeStyle = New NStrokeStyle(1, Color.DarkBlue)
				Dim rectFillStyle As NFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.LightBlue), Color.FromArgb(125, Color.DarkBlue))

				Dim lightingFilter As NLightingImageFilter = New NLightingImageFilter()

				Dim positiveArrowStrokeStyle As NStrokeStyle = New NStrokeStyle(1, Color.DarkGreen)
				Dim positiveArrowFillStyle As NFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Green, Color.DarkGreen)
				positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingFilter)

				Dim equalSignStrokeStyle As NStrokeStyle = New NStrokeStyle(1, Color.DarkGray)
				Dim equalSignFillStyle As NFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Gray, Color.DarkGray)
				positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingFilter)

				Dim negativeArrowStrokeStyle As NStrokeStyle = New NStrokeStyle(1, Color.DarkRed)
				Dim negativeArrowFillStyle As NFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Red, Color.DarkRed)
				positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingFilter)

				Dim i As Integer = 1
				Do While i < bar.Values.Count
					dPreviousValue = CDbl(bar.Values(i - 1))
					dCurrentValue = CDbl(bar.Values(i))

					vecModelPoint.X = horzAxis.TransformScaleToModel(False, i)
					vecModelPoint.Y = vertAxis.TransformScaleToModel(False, CSng(CDbl(bar.Values(i))))
					vecModelPoint.Z = 0

					If (Not chart.TransformModelToView(vecModelPoint, vecClientPoint)) Then
						Continue Do
					End If

					Dim rcArrowRect As RectangleF = New RectangleF(vecClientPoint.X - nBarSize, vecClientPoint.Y - nBarSize, 2 * nBarSize, 2 * nBarSize)

					If rcArrowRect.Width <= 0 OrElse rcArrowRect.Height <= 0 Then
						Continue Do
					End If

					If (Not DisplayMark(dCurrentValue, dPreviousValue)) Then
						Continue Do
					End If

					' draw arrow background
					Dim path As GraphicsPath = GetRoundRectanglePath(rcArrowRect)

					graphics.PaintPath(rectFillStyle, rectStrokeStyle, path)

					path.Dispose()

					rcArrowRect.Inflate(-5, -5)

					' draw the arrow itself
					If rcArrowRect.Width <= 0 OrElse rcArrowRect.Height <= 0 Then
						Continue Do
					End If

					If dCurrentValue < dPreviousValue Then
						' draw negative arrow
						path = GetArrowPath(rcArrowRect, False)

						graphics.PaintPath(negativeArrowFillStyle, negativeArrowStrokeStyle, path)

						path.Dispose()
					ElseIf dCurrentValue > dPreviousValue Then
						' draw positive arrow
						path = GetArrowPath(rcArrowRect, True)

						graphics.PaintPath(positiveArrowFillStyle, positiveArrowStrokeStyle, path)

						path.Dispose()
					Else
						' draw equal sign
						Dim rect As NRectangleF = New NRectangleF(rcArrowRect.Left, rcArrowRect.Top, rcArrowRect.Width, rcArrowRect.Height / 3.0f)

						graphics.PaintRectangle(equalSignFillStyle, equalSignStrokeStyle, rect)

						rect = New NRectangleF(rcArrowRect.Left, rcArrowRect.Bottom - rect.Height, rcArrowRect.Width, rect.Height)

						graphics.PaintRectangle(equalSignFillStyle, equalSignStrokeStyle, rect)
					End If
					i += 1
				Loop
			End Sub

			#End Region

			#Region "Implementation"

			Private Function DisplayMark(ByVal dCurrentValue As Double, ByVal dPreviousValue As Double) As Boolean
				If dCurrentValue < dPreviousValue Then
					Return showDownwardArrows
				ElseIf dCurrentValue > dPreviousValue Then
					Return showUpwardArrows
				Else
					Return showEqualSigns
				End If
			End Function

			#End Region

			#Region "Fields"

			Private showDownwardArrows As Boolean
			Private showUpwardArrows As Boolean
			Private showEqualSigns As Boolean

			#End Region
		End Class

		#End Region
	End Class
End Namespace

