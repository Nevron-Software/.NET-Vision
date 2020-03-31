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
Imports Nevron.Chart.Functions
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomPaintingBase
		Inherits NExampleBaseUC
		Implements INPaintCallback

		Private components As System.ComponentModel.Container = Nothing
		Protected m_Chart As NChart
		Protected m_Bar As NBarSeries
		Protected m_nBarCount As Integer = 10

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
			' NCustomPaintingBase
			' 
			Me.Name = "NCustomPaintingBase"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Drawing Helpers"

		Protected Shared Function CalcEdgeRectSize(ByVal fWidth As Single, ByVal fHeight As Single) As Single
			Dim fEdgePercent As Single = 30.0F
			Dim fMinDimension As Single = Math.Min(fWidth, fHeight)

			Return fMinDimension * (fEdgePercent / 50.0F)
		End Function

		Protected Shared Function GetArrowPath(ByVal rect As RectangleF, ByVal bUpArrow As Boolean) As GraphicsPath
			Dim lines(6) As PointF

			Dim rcArrowModel As New RectangleF(-50, -50, 100, 100)

			Dim fArrowHeadWidth As Single = rcArrowModel.Width * 30.0F / 100.0F
			Dim fArrowRectHeight As Single = rcArrowModel.Height * 30.0F / 100.0F
			Dim fArrowHeadEnd As Single = rcArrowModel.Left + fArrowHeadWidth

			lines(0) = New PointF(rcArrowModel.Right, rcArrowModel.Bottom - (rcArrowModel.Height - fArrowRectHeight) / 2)
			lines(1) = New PointF(fArrowHeadEnd, lines(0).Y)
			lines(2) = New PointF(fArrowHeadEnd, rcArrowModel.Bottom)
			lines(3) = New PointF(rcArrowModel.Left, rcArrowModel.Top + rcArrowModel.Height \ 2)
			lines(4) = New PointF(fArrowHeadEnd, rcArrowModel.Top)
			lines(5) = New PointF(fArrowHeadEnd, rcArrowModel.Top + (rcArrowModel.Height - fArrowRectHeight) / 2)
			lines(6) = New PointF(rcArrowModel.Right, lines(5).Y)

			Dim path As New GraphicsPath()

			path.AddLines(lines)
			path.CloseAllFigures()

			Dim matrix As New Matrix()
			matrix.Reset()

			If bUpArrow Then
				matrix.Rotate(90, MatrixOrder.Append)
			Else
				matrix.Rotate(-90, MatrixOrder.Append)
			End If

			matrix.Scale(rect.Width \ rcArrowModel.Width, rect.Height \ rcArrowModel.Height)
			matrix.Translate(rect.Left + rect.Width / 2.0F, rect.Top + rect.Height / 2.0F, MatrixOrder.Append)

			path.Transform(matrix)
			matrix.Dispose()

			Return path
		End Function

		Protected Shared Function GetRoundRectanglePath(ByVal rect As RectangleF) As GraphicsPath
			Dim fEdgeM2 As Single = CalcEdgeRectSize(rect.Width, rect.Height)

			Dim path As New GraphicsPath()

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
			m_Bar.ClearDataPoints()

			Dim dp As New NDataPoint()

			For i As Integer = 0 To m_nBarCount - 1
				dp(DataPointValue.Value) = m_nBarCount \ 2 - Random.Next(m_nBarCount)

				m_Bar.AddDataPoint(dp)
			Next i

			nChartControl1.Refresh()
		End Sub

		Protected Sub ConfigureChart(ByVal titleText As String)
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader(titleText)
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.TextFormat = TextFormat.XML
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add bar and change bar color
			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)

			m_Bar.Name = "Bar Series"
			m_Bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red)
			m_Bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Bar.BarShape = BarShape.Cylinder
			m_Bar.ShadowStyle.Offset = New NPointL(3, 3)
			m_Bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			m_Bar.ShadowStyle.FadeLength = New NLength(5)
			m_Bar.DataLabelStyle.Visible = False

			m_Chart.PaintCallback = Me
			' Configure interactivity
			nChartControl1.Controller.Selection.Add(m_Chart)
			nChartControl1.Controller.Tools.Add(New NTrackballTool())
		End Sub

		''' <summary>
		''' Occurs before the panel is painted.
		''' </summary>
		''' <param name="panel"></param>
		''' <param name="eventArgs"></param>
		Public Overridable Sub OnBeforePaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs) Implements INPaintCallback.OnBeforePaint
		End Sub

		''' <summary>
		''' Occurs after the panel is painted.
		''' </summary>
		''' <param name="panel"></param>
		''' <param name="eventArgs"></param>
		Public Overridable Sub OnAfterPaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs) Implements INPaintCallback.OnAfterPaint

		End Sub


		#End Region
	End Class
End Namespace
