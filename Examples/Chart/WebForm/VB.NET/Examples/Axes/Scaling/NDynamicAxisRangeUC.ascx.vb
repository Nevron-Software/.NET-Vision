Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDynamicAxisRangeUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim chart As NChart = nChartControl1.Charts(0)

			If (Not IsPostBack) Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False

				' set a chart title
				Dim title As NLabel = nChartControl1.Labels.AddHeader("Dynamic Axis Range")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				' no legend
				nChartControl1.Legends.Clear()

				' setup chart
				chart.BoundsMode = BoundsMode.Stretch

				Dim line As NLineSeries = New NLineSeries()
				line.DataLabelStyle.Visible = False
				line.VerticalAxisRangeMode = AxisRangeMode.ViewRange

				GenerateData(line, 100.0, 100, New NRange1DD(60, 140))
				chart.Series.Add(line)
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

				WebExamplesUtilities.FillComboWithEnumNames(VerticalAxisRangeModeDropDownList, GetType(AxisRangeMode))
				VerticalAxisRangeModeDropDownList.SelectedIndex = CInt(Fix(AxisRangeMode.ViewRange))

				Dim [step] As Integer = 10

				For beginValue As Integer = 0 To 99 Step [step]
					IntervalDropDownList.Items.Add(beginValue.ToString() & " - " & (beginValue + [step]).ToString())
				Next beginValue
			End If

				Dim start As Double = IntervalDropDownList.SelectedIndex * 10

				' assign new range
				chart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(New NRange1DD(start, start + 10), True, True)

				' assign the range mode
				chart.Series(0).VerticalAxisRangeMode = CType(VerticalAxisRangeModeDropDownList.SelectedIndex, AxisRangeMode)
		End Sub

		Public Shared Sub GenerateData(ByVal xyScatterSeries As NXYScatterSeries, ByVal value As Double, ByVal nCount As Integer, ByVal range As NRange1DD)
			xyScatterSeries.ClearDataPoints()
			Dim dt As DateTime = New DateTime(2009, 1, 5)

			Dim nIndex As Integer = 0
			Do While nIndex < nCount
				Dim upward As Boolean = False

				If range.Begin > value Then
					upward = True
				ElseIf range.End < value Then
					upward = False
				Else
					upward = Random.NextDouble() > 0.5
				End If

				xyScatterSeries.Values.Add(value)

				If upward Then
					value += (2 + (Random.NextDouble() * 20))
				Else
					value -= (2 + (Random.NextDouble() * 20))
				End If

				xyScatterSeries.XValues.Add(nIndex)
				nIndex += 1
			Loop
		End Sub
	End Class
End Namespace
