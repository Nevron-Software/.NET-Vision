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
	<ToolboxItem(False)>
	Public Class NFourSetVennUC
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
			' NFourSetVennUC
			' 
			Me.Name = "NFourSetVennUC"
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
			Dim title As New NLabel("Four Set Venn")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' create a Venn series
			Dim venn As NVennSeries = CType(chart.Series.Add(SeriesType.Venn), NVennSeries)

			FourSetVenn(venn)
			FourSetVennLabels(venn)
			FourSetVennInteractivity(venn)

			' set a tooltip tool
			nChartControl1.Controller.Selection.Add(chart)
			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)
		End Sub

		Private Sub FourSetVenn(ByVal venn As NVennSeries)
			venn.ClearContours()

			venn.AddVennContour(VennShape.Ellipse, New NPointF(-12.5F, -10F), New NSizeF(60, 35), 135, 0)
			venn.AddVennContour(VennShape.Ellipse, New NPointF(12.5F, -10F), New NSizeF(60, 35), 45, 1)
			venn.AddVennContour(VennShape.Ellipse, New NPointF(-2.5F, 5), New NSizeF(60, 35), 135, 2)
			venn.AddVennContour(VennShape.Ellipse, New NPointF(2.5F, 5), New NSizeF(60, 35), 45, 3)
		End Sub
		Private Sub FourSetVennLabels(ByVal venn As NVennSeries)
			Dim centreLabel As String = "ABCD"
			Dim s1() As String = { "A", "B", "C", "D" }
			Dim s2() As String = { "AC", "CD", "BD", "AD", "AB", "BC" }
			Dim s3() As String = { "ACD", "BCD", "ABD", "ABC"}

			venn.ClearLabels()
			venn.LabelsTextStyle.FontStyle = New NFontStyle("Verdana", 8)

			' add centre label
			venn.AddLabel(centreLabel, New NPointF(0, -8))

			' add layer 1 labels
			venn.AddLabel(s1(0), New NPointF(-12.5F - 15F, -10F + 10F))
			venn.AddLabel(s1(1), New NPointF(12.5F + 15F, -10F + 10F))
			venn.AddLabel(s1(2), New NPointF(-2.5F - 15F, 5F + 16F))
			venn.AddLabel(s1(3), New NPointF(2.5F + 15F, 5F + 16F))

			' add layer 2 labels
			venn.AddLabel(s2(0), New NPointF(-12.5F - 9F, -10F + 19F))
			venn.AddLabel(s2(1), New NPointF(0, -10F + 24F))
			venn.AddLabel(s2(2), New NPointF(12.5F + 9F, -10F + 19F))
			venn.AddLabel(s2(3), New NPointF(2.5F - 18F, 5F - 18F))
			venn.AddLabel(s2(4), New NPointF(0, -10F - 16F))
			venn.AddLabel(s2(5), New NPointF(-2.5F + 18F, 5F - 18F))

			' add layer 3 labels
			venn.AddLabel(s3(0), New NPointF(-12.5F + 1F, -10F + 10F))
			venn.AddLabel(s3(1), New NPointF(12.5F - 1F, -10F + 10F))
			venn.AddLabel(s3(2), New NPointF(2.5F - 10F, 5F - 21.5F))
			venn.AddLabel(s3(3), New NPointF(-2.5F + 10F, 5F - 21.5F))
		End Sub
		Private Sub FourSetVennInteractivity(ByVal venn As NVennSeries)
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

			arrContourIds = New Integer(){0, 1, 2, 3}
			interactivity = New NInteractivityStyle()
			interactivity.Tooltip.Text = "Segment ABCD"
			venn.SetInteractivityForSegment(arrContourIds, interactivity)
		End Sub
	End Class
End Namespace

