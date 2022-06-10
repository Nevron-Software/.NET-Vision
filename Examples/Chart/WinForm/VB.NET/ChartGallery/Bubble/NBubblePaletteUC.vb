Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NBubblePaletteUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
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
			' NBubblePaletteUC
			' 
			Me.Name = "NBubblePaletteUC"
			Me.Size = New System.Drawing.Size(180, 389)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bubble Palette")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add a bubble series
			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bubble.Legend.Format = "Size <size>, Value <value>"
			m_Bubble.MinSize = New NLength(7.0F, NRelativeUnit.ParentPercentage)
			m_Bubble.MaxSize = New NLength(16.0F, NRelativeUnit.ParentPercentage)

			For i As Integer = 0 To 9
				m_Bubble.Values.Add(i)
				m_Bubble.Sizes.Add(i * 10 + 10)
			Next i

			m_Bubble.InflateMargins = True

			Dim palette As New NPalette()
			palette.SmoothPalette = True
			palette.Clear()
			palette.Add(0, Color.Green)
			palette.Add(60, Color.Yellow)
			palette.Add(120, Color.Red)

			m_Bubble.Palette = palette

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

		End Sub
	End Class
End Namespace
