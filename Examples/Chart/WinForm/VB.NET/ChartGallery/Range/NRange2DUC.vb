Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRange2DUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing

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
			' NRange2DUC
			' 
			Me.Name = "NRange2DUC"
			Me.Size = New System.Drawing.Size(180, 86)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("2D Range Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim linearScale As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.InnerMajorTickStyle.Visible = False

			' setup Y axis
			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.InnerMajorTickStyle.Visible = False

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' setup shape series
			Dim rangeSeries As NRangeSeries = CType(chart.Series.Add(SeriesType.Range), NRangeSeries)
			rangeSeries.DataLabelStyle.Visible = False
			rangeSeries.UseXValues = True
			rangeSeries.FillStyle = New NColorFillStyle(DarkOrange)
			rangeSeries.BorderStyle.Color = Color.DarkRed

			' fill data
			FillData(rangeSeries)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)
		End Sub

		Private Shared Sub FillData(ByVal rangeSeries As NRangeSeries)
			Dim arrIntervals() As Double = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 15, 30, 60 }
			Dim arrValues() As Double = { 4180, 13687, 18618, 19634, 17981, 7190, 16369, 3212, 4122, 9200, 6461, 3435 }

			Dim count As Integer = Math.Min(arrIntervals.Length, arrValues.Length)
			Dim x As Double = 0

			For i As Integer = 0 To count - 1
				Dim dInterval As Double = arrIntervals(i)
				Dim dValue As Double = arrValues(i)

				rangeSeries.Values.Add(0)
				rangeSeries.XValues.Add(x)

				x += dInterval

				rangeSeries.Y2Values.Add(dValue / dInterval)
				rangeSeries.X2Values.Add(x)
			Next i
		End Sub
	End Class
End Namespace
