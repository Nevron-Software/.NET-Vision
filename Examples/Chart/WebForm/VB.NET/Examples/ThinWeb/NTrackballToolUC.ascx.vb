Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTrackballToolUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				' enable jittering (full scene antialiasing)
				NThinChartControl1.Settings.JitterMode = JitterMode.Enabled
				NThinChartControl1.Panels.Clear()

				' apply background image border
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False

				' set a chart title
				Dim title As NLabel = New NLabel()
				NThinChartControl1.Panels.Add(title)
				title.DockMode = PanelDockMode.Top
				title.TextStyle.TextFormat = TextFormat.XML
				title.Padding = New NMarginsL(4, 6, 4, 6)
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				' configure the legend
				Dim legend As NLegend = New NLegend()
				NThinChartControl1.Panels.Add(legend)
				legend.DockMode = PanelDockMode.Right
				legend.Padding = New NMarginsL(1, 1, 3, 3)
				legend.FillStyle.SetTransparencyPercent(50)
				legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

				' configure the chart
				Dim chart As NCartesianChart = New NCartesianChart()
				NThinChartControl1.Panels.Add(chart)
				chart.Enable3D = True
				chart.Fit3DAxisContent = True
				chart.DisplayOnLegend = legend
				chart.BoundsMode = BoundsMode.Fit
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
				chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
				chart.DockMode = PanelDockMode.Fill
				chart.Padding = New NMarginsL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

				' update the inital label text
				title.Text = "Trackball Tool<br/><font size='10pt'> Rotation[" & chart.Projection.Rotation.ToString() & "], Elevation [" & chart.Projection.Elevation.ToString() & "]</font>"

				' setup the X axis
				Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
				Dim scaleX As NOrdinalScaleConfigurator = CType(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
				scaleX.MajorTickMode = MajorTickMode.AutoMaxCount

				' add interlaced stripe for the Y axis
				Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
				Dim scaleY As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
				stripStyle.Interlaced = True
				stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
				scaleY.StripStyles.Add(stripStyle)

				' hide the depth axis
				chart.Axis(StandardAxis.Depth).Visible = False

				' add a bar series and fill it with data
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.Name = "Simple Bar Chart"
				bar.BarShape = BarShape.SmoothEdgeBar
				bar.Legend.Mode = SeriesLegendMode.DataPoints
				bar.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
				bar.DataLabelStyle.Visible = False

				bar.AddDataPoint(New NDataPoint(16, "Spain"))
				bar.AddDataPoint(New NDataPoint(42, "France"))
				bar.AddDataPoint(New NDataPoint(56, "Germany"))
				bar.AddDataPoint(New NDataPoint(23, "Italy"))
				bar.AddDataPoint(New NDataPoint(47, "UK"))
				bar.AddDataPoint(New NDataPoint(38, "Sweden"))

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(bar)

				Dim tbt As NTrackballTool = New NTrackballTool()
				tbt.Exclusive = True
				tbt.Enabled = True

				tbt.TrackballCallback = New TrackballCallback()

				NThinChartControl1.Controller.SetActivePanel(chart)
				NThinChartControl1.Controller.Tools.Add(tbt)
			End If
		End Sub

		<Serializable> _
		Public Class TrackballCallback
            Implements INTrackballCallback
			#Region "INTrackballCallback Members"

			Private Sub OnTrackball(ByVal control As NThinChartControl, ByVal chart As NChart, ByVal oldRotation As Single, ByVal oldElevation As Single) Implements INTrackballCallback.OnTrackball
				control.Labels(0).Text = "Trackball Tool<br/><font size='10pt'> Rotation[" & chart.Projection.Rotation.ToString() & "], Elevation [" & chart.Projection.Elevation.ToString() & "]</font>"
				control.UpdateView()
			End Sub

			#End Region
		End Class
	End Class
End Namespace
