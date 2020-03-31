Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDataPanToolUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False

				' set a chart title
				Dim title As NLabel = NThinChartControl1.Labels.AddHeader("Data Pan Tool")
				title.TextStyle.TextFormat = GraphicsCore.TextFormat.XML
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

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
				scaleY.RoundToTickMax = False
				scaleY.RoundToTickMin = False

				' setup X axis
				Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
				scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Back }
				scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
				scaleX.RoundToTickMax = False
				scaleX.RoundToTickMin = False

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

				NThinChartControl1.RecalcLayout()
				chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(New NRange1DD(-0.5, 0.5), 0.0001)
				chart.Axis(StandardAxis.PrimaryY).PagingView.ZoomIn(New NRange1DD(-0.5, 0.5), 0.0001)

				' apply layout
				ApplyLayoutTemplate(0, NThinChartControl1, chart, title, Nothing)

				NThinChartControl1.Controller.SetActivePanel(chart)
			End If

			' code common for load/postback
			NThinChartControl1.ServerSettings.EnableTiledZoom = UseTilingCheckBox.Checked
			Dim chart1 As NChart = NThinChartControl1.Charts(0)

			chart1.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = ShowScrollbarsCheckBox.Checked
			chart1.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = ShowScrollbarsCheckBox.Checked

			Dim dataPanTool As NDataPanTool = New NDataPanTool()

			If UpdateRangeInTitleCheckBox.Checked Then
				dataPanTool.DataPanCallback = New MyDataPanCallback()
				NThinChartControl1.ScrollCallback = New MyScrollCallback()

				NThinChartControl1.RecalcLayout()
				NThinChartControl1.Labels(0).Text = FormatLabel(chart1.Axis(StandardAxis.PrimaryX).Scale.RulerRange, chart1.Axis(StandardAxis.PrimaryY).Scale.RulerRange)
			Else
				dataPanTool.DataPanCallback = Nothing
				NThinChartControl1.ScrollCallback = Nothing
				NThinChartControl1.Labels(0).Text = "Data Pan Tool"
			End If

			NThinChartControl1.Controller.Tools.Clear()
			NThinChartControl1.Controller.Tools.Add(dataPanTool)

			If UpdateRangeInTitleCheckBox.Checked Then
				NThinChartControl1.Labels(0).Text = FormatLabel(chart1.Axis(StandardAxis.PrimaryX).Scale.RulerRange, chart1.Axis(StandardAxis.PrimaryY).Scale.RulerRange)
			End If
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="xRange"></param>
		''' <param name="yRange"></param>
		''' <returns></returns>
		Private Shared Function FormatLabel(ByVal xRange As NRange1DD, ByVal yRange As NRange1DD) As String
			Dim valueFormat As String = "0.00"
			Return "Data Pan Tool <br/><font size='12pt'>XRange[" & xRange.Begin.ToString(valueFormat) & ", " & xRange.End.ToString(valueFormat) & "], YRange[" & yRange.Begin.ToString(valueFormat) & ", " & yRange.End.ToString(valueFormat) & "]</font>"
		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="series"></param>
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

				Dim z0 As Double = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2)
				Dim z1 As Double = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2)

				series.XValues.Add(z0)
				series.Values.Add(z1)
			Next i
		End Sub

		<Serializable> _
		Public Class MyDataPanCallback
            Implements INDataPanCallback
			#Region "INDataPanCallback Members"

			Private Sub OnDataPan(ByVal control As NThinChartControl, ByVal chart As NCartesianChart, ByVal horzAxis As NAxis, ByVal vertAxis As NAxis) Implements INDataPanCallback.OnDataPan
				control.RecalcLayout()

				Dim label As NLabel = control.Labels(0)
				label.Text = FormatLabel(horzAxis.Scale.RulerRange, vertAxis.Scale.RulerRange)

				control.Update()
			End Sub

			#End Region
		End Class

		<Serializable> _
		Public Class MyScrollCallback
            Implements INScrollbarCallback
			#Region "INScrollbarCallback Members"

			Private Sub OnScroll(ByVal control As NThinChartControl, ByVal chart As NCartesianChart, ByVal axis As NAxis) Implements INScrollbarCallback.OnScroll
				control.RecalcLayout()

				Dim horzAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
				Dim vertAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)

				Dim label As NLabel = control.Labels(0)
				label.Text = FormatLabel(horzAxis.Scale.RulerRange, vertAxis.Scale.RulerRange)

				control.Update()
			End Sub

			#End Region
		End Class


	End Class
End Namespace
