Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDataZoomToolUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False

				' set a chart title
				Dim title As NLabel = NThinChartControl1.Labels.AddHeader("Data Zoom Tool")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				NThinChartControl1.ServerSettings.JQuery.SourceType = JQuerySourceType.Url

				' no legend
				NThinChartControl1.Legends.Clear()

				' setup chart
				Dim chart As NChart = NThinChartControl1.Charts(0)
				chart.BoundsMode = BoundsMode.Stretch

				' setup Y axis
				Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

				' add interlace stripe
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
				stripStyle.Interlaced = True
				stripStyle.SetShowAtWall(ChartWallType.Back, True)
				stripStyle.SetShowAtWall(ChartWallType.Left, True)
				scaleY.StripStyles.Add(stripStyle)

				' setup X axis
				Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
				scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Back }
				scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

				' setup point series
				Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
				point.Name = "Point1"
				point.DataLabelStyle.Visible = False
				point.FillStyle = New NColorFillStyle(Color.FromArgb(160, DarkOrange))
				point.BorderStyle.Width = New NLength(0)
				point.Size = New NLength(2, NRelativeUnit.ParentPercentage)
				point.PointShape = PointShape.Ellipse

				' instruct the point series to use custom X values
				point.UseXValues = True

				' generate some random X values
				GenerateXYData(point)

				' apply layout
				ApplyLayoutTemplate(0, NThinChartControl1, chart, title, Nothing)

				NThinChartControl1.Controller.SetActivePanel(chart)

				NThinChartControl1.Controller.Tools.Add(New NDataZoomTool())
				NThinChartControl1.Controller.Tools.Add(New NTooltipTool())
			End If

			' configure the scrollbars and tiling
			NThinChartControl1.ServerSettings.EnableTiledZoom = UseTilingCheckBox.Checked
			NThinChartControl1.ServerSettings.TileCacheSize = 3000
			Dim chart1 As NChart = NThinChartControl1.Charts(0)

			Dim dzt As NDataZoomTool = CType(NThinChartControl1.Controller.Tools.FindToolOfType(GetType(NDataZoomTool)), NDataZoomTool)
			dzt.ZoomOutResetsAxes = ZoomOutResetsAxesCheckBox.Checked

			chart1.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = ShowScrollbarsCheckBox.Checked
			chart1.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = ShowScrollbarsCheckBox.Checked
		End Sub

		Private Sub GenerateXYData(ByVal series As NPointSeries)
			For i As Integer = 0 To 199
				Dim u1 As Double = Random.NextDouble()
				Dim u2 As Double = Random.NextDouble()

				If u1 = 0 Then
					u1 += 0.0001
				End If

				If u2 = 0 Then
					u2 += 0.0001
				End If

				Dim z0 As Double = 100 * Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2)
				Dim z1 As Double = 100 * Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2)

				series.XValues.Add(z0)
				series.Values.Add(z1)
				series.InteractivityStyles.Add(i, New NInteractivityStyle("X: " & z0.ToString("0.00") & ", Y:" & z1.ToString("0.00")))
			Next i
		End Sub
	End Class
End Namespace
