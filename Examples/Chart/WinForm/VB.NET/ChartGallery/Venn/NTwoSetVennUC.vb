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
	Public Class NTwoSetVennUC
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
			' NTwoSetVennUC
			' 
			Me.Name = "NTwoSetVennUC"
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
			Dim title As New NLabel("Two Set Venn")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' create a Venn series
			Dim venn As NVennSeries = CType(chart.Series.Add(SeriesType.Venn), NVennSeries)

			TwoSetVenn(venn)
			TwoSetVennLabels(venn)
			TwoSetVennInteractivity(venn)

			' set a tooltip tool
			nChartControl1.Controller.Selection.Add(chart)
			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)
		End Sub

		Private Sub TwoSetVenn(ByVal venn As NVennSeries)
			venn.ClearContours()

			venn.AddVennContour(VennShape.Ellipse, New NPointF(-15, 0), New NSizeF(50, 50), 0, 0)
			venn.AddVennContour(VennShape.Ellipse, New NPointF(15, 0), New NSizeF(50, 50), 0, 1)
		End Sub

		Private Sub TwoSetVennLabels(ByVal venn As NVennSeries)
			Dim s1() As String = { "A", "AB", "B"}

			venn.ClearLabels()
			venn.LabelsTextStyle.FontStyle = New NFontStyle("Verdana", 8)

			' add labels
			venn.AddLabel(s1(0), New NPointF(-25, 0))
			venn.AddLabel(s1(1), New NPointF(0, 0))
			venn.AddLabel(s1(2), New NPointF(25, 0))
		End Sub

		Private Sub TwoSetVennInteractivity(ByVal venn As NVennSeries)
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

			arrContourIds = New Integer(){0, 1}
			interactivity = New NInteractivityStyle()
			interactivity.Tooltip.Text = "Segment AB"
			venn.SetInteractivityForSegment(arrContourIds, interactivity)
		End Sub
	End Class
End Namespace

