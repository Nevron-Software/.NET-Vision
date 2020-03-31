Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAutoUpdateUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False
				NThinChartControl1.Panels.Clear()
				Dim frame As NStandardFrameStyle = TryCast(NThinChartControl1.BackgroundStyle.FrameStyle, NStandardFrameStyle)
				frame.InnerBorderWidth = New NLength(0)

				' set a chart title
				' set a chart title
				Dim title As NLabel = NThinChartControl1.Labels.AddHeader("Auto Update")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				' setup Line chart
				Dim chart As NCartesianChart = New NCartesianChart()
				NThinChartControl1.Panels.Add(chart)
				Dim rangeTimeline As NRangeTimelineScaleConfigurator = New NRangeTimelineScaleConfigurator()
				rangeTimeline.FirstRow.MinTickDistance = New NLength(40)
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = rangeTimeline

				' setup Y axis
				Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

				' add interlace stripe
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
				stripStyle.Interlaced = True
				stripStyle.SetShowAtWall(ChartWallType.Back, True)
				stripStyle.SetShowAtWall(ChartWallType.Left, True)
				scaleY.StripStyles.Add(stripStyle)

				Dim line As NLineSeries = New NLineSeries()
				line.UseXValues = True
				line.DataLabelStyle.Visible = False
				line.BorderStyle.Color = Color.DarkOrange
				line.BorderStyle.Width = New NLength(2)
				chart.Series.Add(line)

				' generate some data
				GenerateNewData()

				NThinChartControl1.AutoUpdateCallback = New NAutoUpdateCallback()
				ApplyLayoutTemplate(0, NThinChartControl1, chart, title, Nothing)

				NThinChartControl1.ServerSettings.EnableTiledZoom = True
				NThinChartControl1.ServerSettings.AutoUpdateInterval = 200
				NThinChartControl1.ServerSettings.EnableAutoUpdate = True
			End If

			If (Not IsPostBack) Then
				AutoUpdateIntervalTextBox.Text = NThinChartControl1.ServerSettings.AutoUpdateInterval.ToString()
			End If
		End Sub

		<Serializable> _
		Public Class NAutoUpdateCallback
            Implements INAutoUpdateCallback
			#Region "INAutoUpdateCallback Members"

			Private Sub OnAutoUpdate(ByVal control As NAspNetThinWebControl) Implements INAutoUpdateCallback.OnAutoUpdate
				Dim chartControl As NThinChartControl = CType(control, NThinChartControl)
				Dim line As NLineSeries = CType(chartControl.Charts(0).Series(0), NLineSeries)

				If line Is Nothing Then
					Return
				End If

				If line.Values.Count = 0 Then
					Return
				End If

				Dim dPrev As Double = CDbl(line.Values(line.Values.Count - 1))

				Dim yValue As Double = GenerateDataPoint(dPrev, New NRange1DD(50, 350))

				line.Values.RemoveAt(0)
				line.XValues.RemoveAt(0)

				line.Values.Add(yValue)
				line.XValues.Add(DateTime.Now.ToOADate())

				chartControl.UpdateView()
			End Sub

			Private Sub OnAutoUpdateStateChanged(ByVal control As NAspNetThinWebControl) Implements INAutoUpdateCallback.OnAutoUpdateStateChanged
				Throw New NotImplementedException()
			End Sub

			#End Region
		End Class
		''' <summary>
		''' Generates new random data
		''' </summary>
		Private Sub GenerateNewData()
			Dim line As NLineSeries = CType(NThinChartControl1.Charts(0).Series(0), NLineSeries)

            Dim count As Integer = 100
            Dim now As DateTime

            now = DateTime.Now

            Dim dt As DateTime = now.AddMilliseconds(-count * 50)
			Dim prevValue As Double = 100
			Dim value As Double

			Dim i As Integer = 0
			Do While i < count
				value = GenerateDataPoint(prevValue, New NRange1DD(50, 350))
                dt = dt.AddMilliseconds(50)

				line.Values.Add(value)
                line.XValues.Add(dt.ToOADate())

				prevValue = value
				i += 1
			Loop
		End Sub
		''' <summary>
		''' Generates a new data point
		''' </summary>
		''' <param name="dPrev"></param>
		''' <param name="range"></param>
		''' <returns></returns>
		Protected Shared Function GenerateDataPoint(ByVal dPrev As Double, ByVal range As NRange1DD) As Double
			Dim value As Double = dPrev
			Dim upward As Boolean = False
			If dPrev <= range.Begin Then
				upward = True
			Else
				If dPrev >= range.End Then
					upward = False
				Else
					upward = WebExamplesUtilities.rand.NextDouble() > 0.5
				End If
			End If
			If upward Then
				' upward value change
				value = value + (2 + (WebExamplesUtilities.rand.NextDouble() * 10))
			Else
				' downward value change
				value = value - (2 + (WebExamplesUtilities.rand.NextDouble() * 10))
			End If

			Return value
		End Function

		Protected Sub ToggleAutoUpdateButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			If ToggleAutoUpdateButton.Text.StartsWith("Stop") Then
				NThinChartControl1.ServerSettings.EnableAutoUpdate = False
				ToggleAutoUpdateButton.Text = "Start Auto Update"
			Else
				NThinChartControl1.ServerSettings.EnableAutoUpdate = True
				ToggleAutoUpdateButton.Text = "Stop Auto Update"
			End If
		End Sub
		Protected Sub SetAutoUpdateIntervalButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim autoUpdateInterval As Integer = Int32.Parse(AutoUpdateIntervalTextBox.Text)
				NThinChartControl1.ServerSettings.AutoUpdateInterval = autoUpdateInterval
			Catch e1 As Exception
			End Try
		End Sub
	End Class
End Namespace
