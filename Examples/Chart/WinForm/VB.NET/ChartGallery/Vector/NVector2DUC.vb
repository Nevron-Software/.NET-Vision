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
	Public Class NVector2DUC
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
			' NVector2DUC
			' 
			Me.Name = "NVector2DUC"
			Me.Size = New System.Drawing.Size(180, 128)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("2D Vector Field")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = False
			chart.Width = 55.0F
			chart.Height = 55.0F

			' setup X axis
			Dim linearScale As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.RoundToTickMin = False
			linearScale.RoundToTickMax = False
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { }
			linearScale.InnerMajorTickStyle.Visible = False

			' setup Y axis
			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.RoundToTickMin = False
			linearScale.RoundToTickMax = False
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { }
			linearScale.InnerMajorTickStyle.Visible = False

			' setup shape series
			Dim vectorSeries As NVectorSeries = CType(chart.Series.Add(SeriesType.Vector), NVectorSeries)
			vectorSeries.FillStyle = New NColorFillStyle(Color.Red)
			vectorSeries.BorderStyle.Color = Color.DarkRed
			vectorSeries.DataLabelStyle.Visible = False
			vectorSeries.InflateMargins = True
			vectorSeries.UseXValues = True
			vectorSeries.MinArrowHeadSize = New NSizeL(2, 3)
			vectorSeries.MaxArrowHeadSize = New NSizeL(4, 6)

			' fill data
			FillData(vectorSeries)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)
		End Sub

		Private Sub FillData(ByVal vectorSeries As NVectorSeries)
			Dim x As Double = 0, y As Double = 0
			Dim k As Integer = 0

			For i As Integer = 0 To 9
				x = 1
				y += 1

				For j As Integer = 0 To 9
					x += 1

					Dim dx As Double = Math.Sin(x / 3.0) * Math.Cos((x - y) / 4.0)
					Dim dy As Double = Math.Cos(y / 8.0) * Math.Cos(y / 4.0)

					vectorSeries.XValues.Add(x)
					vectorSeries.Values.Add(y)
					vectorSeries.X2Values.Add(x + dx)
					vectorSeries.Y2Values.Add(y + dy)

					vectorSeries.BorderStyles(k) = New NStrokeStyle(1, ColorFromVector(dx, dy))
					k += 1
				Next j
			Next i
		End Sub
		Private Function ColorFromVector(ByVal dx As Double, ByVal dy As Double) As Color
			Dim length As Double = Math.Sqrt(dx * dx + dy * dy)

			Dim sq2 As Double = Math.Sqrt(2)

			Dim r As Integer = CInt(Math.Truncate((255 / sq2) * length))
			Dim g As Integer = 20
			Dim b As Integer = CInt(Math.Truncate((255 / sq2) * (sq2 - length)))

			Return Color.FromArgb(r, g, b)
		End Function
	End Class
End Namespace
