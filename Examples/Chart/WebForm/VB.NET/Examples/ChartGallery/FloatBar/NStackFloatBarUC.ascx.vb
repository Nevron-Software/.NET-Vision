Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStackFloatBarUC
		Inherits NExampleUC
		''' <summary>
		''' Constrols the number of data points
		''' </summary>
		Private Const DataPointCount As Integer = 8

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stack Float Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount

			' add interlaced stripe to the Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			scaleY.StripStyles.Add(stripStyle)

			' setup the floatbar series
			Dim floatbar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Series
			floatbar.Name = "Floatbar"
			floatbar.FillStyle = New NColorFillStyle(Color.SandyBrown)
			floatbar.DataLabelStyle.Visible = False

			' setup the bar series
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Name = "Bar 1"
			bar1.MultiBarMode = MultiBarMode.Stacked
			bar1.FillStyle = New NColorFillStyle(Color.Green)
			bar1.DataLabelStyle.Visible = False

			' setup the bar series
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.Name = "Bar 2"
			bar2.MultiBarMode = MultiBarMode.Stacked
			bar2.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			bar2.DataLabelStyle.Visible = False

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, GetType(BarShape))
				BarShapeDropDownList.SelectedIndex = 0

				DataTypeDropDownList.Items.Add("Positive Data")
				DataTypeDropDownList.Items.Add("Positive and Negative Data")
				DataTypeDropDownList.SelectedIndex = 0
			End If

			Dim selectedShape As BarShape = CType(BarShapeDropDownList.SelectedIndex, BarShape)

			floatbar.BarShape = selectedShape
			bar1.BarShape = selectedShape
			bar2.BarShape = selectedShape

			If DataTypeDropDownList.SelectedIndex = 0 Then
				GeneratePosData()
			Else
				GeneratePosNegData()
			End If

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Function GetRandValue(ByVal min As Double, ByVal max As Double) As Double
			If max < min Then
				Dim temp As Double = min
				min = max
				max = temp
			End If

			Return min + Random.NextDouble() * (max - min)
		End Function

		Private Function SetRandSign(ByVal val As Double) As Double
			If Random.NextDouble() > 0.5 Then
				Return val
			End If

			Return -val
		End Function


		Private Sub GeneratePosData()
			Dim floatbar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			Dim bar1 As NBarSeries = CType(nChartControl1.Charts(0).Series(1), NBarSeries)
			Dim bar2 As NBarSeries = CType(nChartControl1.Charts(0).Series(2), NBarSeries)

			floatbar.BeginValues.Clear()
			floatbar.EndValues.Clear()
			bar1.Values.Clear()
			bar2.Values.Clear()

			For i As Integer = 0 To DataPointCount - 1
				floatbar.BeginValues.Add(GetRandValue(1, 4))
				floatbar.EndValues.Add(GetRandValue(6, 9))
				bar1.Values.Add(GetRandValue(3, 7))
				bar2.Values.Add(GetRandValue(3, 7))
			Next i
		End Sub

		Private Sub GeneratePosNegData()
			Dim floatbar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			Dim bar1 As NBarSeries = CType(nChartControl1.Charts(0).Series(1), NBarSeries)
			Dim bar2 As NBarSeries = CType(nChartControl1.Charts(0).Series(2), NBarSeries)

			floatbar.BeginValues.Clear()
			floatbar.EndValues.Clear()
			bar1.Values.Clear()
			bar2.Values.Clear()

			For i As Integer = 0 To DataPointCount - 1
				floatbar.BeginValues.Add(GetRandValue(-10, 10))
				floatbar.EndValues.Add(SetRandSign(GetRandValue(10, 20)))
				bar1.Values.Add(SetRandSign(GetRandValue(5, 10)))
				bar2.Values.Add(SetRandSign(GetRandValue(5, 10)))
			Next i
		End Sub
	End Class
End Namespace
