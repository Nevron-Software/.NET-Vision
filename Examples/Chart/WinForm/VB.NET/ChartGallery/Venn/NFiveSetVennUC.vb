Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NFiveSetVennUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.IContainer = Nothing

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


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NFiveSetVennUC
			' 
			Me.Name = "NFiveSetVennUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' remove all panels
			nChartControl1.Panels.Clear()

			' create a Venn chart
			Dim chart As NChart = New NVennChart()

			' create a title
			Dim title As New NLabel("Five Set Venn")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' create a Venn series
			Dim venn As NVennSeries = CType(chart.Series.Add(SeriesType.Venn), NVennSeries)

			FiveSetVenn(venn)
			FiveSetVennLabels(venn)
			FiveSetVennInteractivity(venn)

			' set a tooltip tool
			nChartControl1.Controller.Selection.Add(chart)
			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)
		End Sub

		Private Sub FiveSetVenn(ByVal venn As NVennSeries)
			Const nSetCount As Integer = 5
			Const fStartAngle As Single = -(CSng(Math.PI) / 2)
			Const fScale As Single = 7
			Const fCenterX As Single = 0
			Const fCenterY As Single = 0
			Dim fIncrementAngle As Single = CSng(2 * Math.PI / nSetCount)

			venn.ClearContours()

			For i As Integer = 0 To nSetCount - 1
				Dim fAngle As Single = fStartAngle + i * fIncrementAngle
				Dim x As Single = CSng(Math.Round(fCenterX + Math.Cos(fAngle) * fScale, 1))
				Dim y As Single = CSng(Math.Round(fCenterY + Math.Sin(fAngle) * fScale, 1))

				Dim fVennAngle As Single = Rad2Degree(fAngle - 2 * fIncrementAngle)
				venn.AddVennContour(VennShape.Ellipse, New NPointF(x, y), New NSizeF(70, 35), fVennAngle, i)
			Next i
		End Sub
		Private Sub FiveSetVennLabels(ByVal venn As NVennSeries)
			Const nCount As Integer = 5
			Dim s1() As String = { "A", "B", "C", "D", "E" }
			Dim s2() As String = { "AC", "BD", "CE", "DA", "EB" }
			Dim s3() As String = { "ABCD", "BCDE", "CDEA", "DEAB", "EABC" }

			venn.ClearLabels()
			venn.LabelsTextStyle.FontStyle = New NFontStyle("Verdana", 8)

			' add the center label
			venn.AddLabel("ABCDE", New NPointF(0, 0))

			' add layer 1 labels, angle is in radians
			Dim points() As NPointF = CalculateLabelPositions(nCount, 35, -1.1F)
			For i As Integer = 0 To nCount - 1
				venn.AddLabel(s1(i), points(i))
			Next i

			' add layer 2 labels, angle is in radians
			points = CalculateLabelPositions(nCount, 25, -1.3F)
			For i As Integer = 0 To nCount - 1
				venn.AddLabel(s2(i), points(i))
			Next i

			' add layer 4 labels, angle is in radians
			points = CalculateLabelPositions(nCount, 17.5F, -0.5F)
			For i As Integer = 0 To nCount - 1
				venn.AddLabel(s3(i), points(i))
			Next i
		End Sub
		Private Sub FiveSetVennInteractivity(ByVal venn As NVennSeries)
			Dim arrContourIds() As Integer
			Dim interactivity As NInteractivityStyle

			' set the default tooltip
			venn.InteractivityStyle.Tooltip.Text = "Venn Diagram"
			venn.InteractivityStyle.Cursor.Type = CursorType.No

			' clear previous interactivity objects
			venn.ClearSegmentInteractivityStyles()

			' Set tooltips and cursors for particular segments
			arrContourIds = New Integer(){0}
			interactivity = New NInteractivityStyle()
			interactivity.Tooltip.Text = "Segment A"
			venn.SetInteractivityForSegment(arrContourIds, interactivity)

			arrContourIds = New Integer(){1}
			interactivity = New NInteractivityStyle()
			interactivity.Tooltip.Text = "Segment B"
			venn.SetInteractivityForSegment(arrContourIds, interactivity)

			arrContourIds = New Integer(){2}
			interactivity = New NInteractivityStyle()
			interactivity.Tooltip.Text = "Segment C"
			venn.SetInteractivityForSegment(arrContourIds, interactivity)

			arrContourIds = New Integer(){3}
			interactivity = New NInteractivityStyle()
			interactivity.Tooltip.Text = "Segment D"
			venn.SetInteractivityForSegment(arrContourIds, interactivity)

			arrContourIds = New Integer(){4}
			interactivity = New NInteractivityStyle()
			interactivity.Tooltip.Text = "Segment E"
			venn.SetInteractivityForSegment(arrContourIds, interactivity)

			arrContourIds = New Integer(){0, 1, 2, 3, 4}
			interactivity = New NInteractivityStyle()
			interactivity.Tooltip.Text = "Segment ABCDE"
			venn.SetInteractivityForSegment(arrContourIds, interactivity)
		End Sub

		Private Function CalculateLabelPositions(ByVal nSetCount As Integer, ByVal fRadius As Single, ByVal fStartAngleInRadians As Single) As NPointF()
			Dim fIncrementAngle As Single = CSng(2 * Math.PI / nSetCount)
			Dim fCenterX As Single = 0
			Dim fCenterY As Single = 0

			Dim points(nSetCount - 1) As NPointF

			For i As Integer = 0 To nSetCount - 1
				Dim fAngle As Single = fStartAngleInRadians + i * fIncrementAngle
				Dim x As Single = CSng(Math.Round(fCenterX + Math.Cos(fAngle) * fRadius, 1))
				Dim y As Single = CSng(Math.Round(fCenterY + Math.Sin(fAngle) * fRadius, 1))

				points(i) = New NPointF(x, y)
			Next i

			Return points
		End Function

		Private Function Rad2Degree(ByVal fRadians As Single) As Single
			Return CSng(((fRadians) * 180.0F) / (3.1415926535F))
		End Function
	End Class
End Namespace

