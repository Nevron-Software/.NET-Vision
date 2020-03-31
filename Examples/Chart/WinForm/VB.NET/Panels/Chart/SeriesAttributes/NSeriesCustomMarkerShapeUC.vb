Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.SmartShapes


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NSeriesCustomMarkerShapeUC
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
			' NSeriesCustomMarkerShapeUC
			' 
			Me.Name = "NSeriesCustomMarkerShapeUC"
			Me.Size = New System.Drawing.Size(180, 437)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Series Marker Attribute")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.Depth).Visible = False

			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.LineSegmentShape = LineSegmentShape.Tape
			line.InflateMargins = True
			line.DepthPercent = 50
			line.Legend.Mode = SeriesLegendMode.DataPoints
			line.Name = "Line Series"
			line.Values.FillRandom(Random, 6)
			line.DataLabelStyle.Visible = False
			line.ShadowStyle.Type = ShadowType.GaussianBlur
			line.ShadowStyle.Offset = New NPointL(2, 2)
			line.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0)
			line.ShadowStyle.FadeLength = New NLength(5)
			line.MarkerStyle.Visible = True

			Dim marker As New NMarkerStyle()
			marker.FillStyle = New NColorFillStyle(Color.Red)
			marker.PointShape = PointShape.Custom

			' Create a custom shape for this marker
			Dim factory As New N2DSmartShapeFactory(New NColorFillStyle(Color.Red), New NStrokeStyle(1.0F, Color.Black), Nothing)
			marker.CustomShape = factory.CreateShape(SmartShape2D.Trapezoid)
			marker.Visible = True
			line.MarkerStyles(3) = marker

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
