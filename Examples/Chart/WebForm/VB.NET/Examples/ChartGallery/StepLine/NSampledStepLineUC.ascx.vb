Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NSampledStepLineUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				' Init Form controls
				WebExamplesUtilities.FillComboWithValues(SampleDistanceDropDownList, 2, 10, 1)
				SampleDistanceDropDownList.SelectedIndex = 0

				UseXValuesCheckBox.Checked = True

				WebExamplesUtilities.FillComboWithValues(NumberOfTurnsDropDownList, 3, 20, 1)
				NumberOfTurnsDropDownList.SelectedIndex = 2

				WebExamplesUtilities.FillComboWithValues(NumberOfPointsInTurnDropDownList, 10000, 30000, 10000)
				NumberOfPointsInTurnDropDownList.SelectedIndex = 1
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Sampled Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' setup X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Floor }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleX.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' add the line
			Dim stepLine As NStepLineSeries = CType(chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			stepLine.LineSegmentShape = LineSegmentShape.Line
			stepLine.DataLabelStyle.Visible = False
			stepLine.MarkerStyle.Visible = False
			stepLine.Legend.Mode = SeriesLegendMode.None
			' instruct the series to use X values
			stepLine.UseXValues = UseXValuesCheckBox.Checked

			' update sampling parameters
			stepLine.SamplingMode = SeriesSamplingMode.Enabled
			stepLine.SampleDistance = New NLength(CSng(SampleDistanceDropDownList.SelectedIndex) + 2, NGraphicsUnit.Pixel)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			GenerateXYData(stepLine)

			NumberOfDataPointsLabel.Text = "Number of Data Points:" & (stepLine.Values.Count / 1000).ToString() & "K"

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateXYData(ByVal line As NStepLineSeries)
			Dim numberOfTurns As Integer = NumberOfTurnsDropDownList.SelectedIndex + 3
			Dim numberOfPointsInTurn As Integer = (NumberOfPointsInTurnDropDownList.SelectedIndex + 1) * 10000
			Dim i As Integer = 0
			Do While i < numberOfTurns
				AddTurn(line, numberOfPointsInTurn)
				i += 1
			Loop
		End Sub

		Private Sub AddTurn(ByVal line As NStepLineSeries, ByVal count As Integer)
			Dim rand As Random = New Random()
			Dim prevYVal As Double = 2
			Dim prevXVal As Double = 2

			Dim angle As Double = 0
			Dim phase As Double = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001
			Dim magnitude As Double = rand.NextDouble() * 5

			Dim xValues As Double() = New Double(count - 1){}
			Dim yValues As Double() = New Double(count - 1){}

			Dim valueCount As Integer = line.Values.Count
			If valueCount > 0 Then
				prevYVal = CDbl(line.Values(valueCount - 1))
				prevXVal = CDbl(line.XValues(valueCount - 1))
			End If

			Dim i As Integer = 0
			Do While i < count
				Dim yStep As Double = Math.Sin(angle) * magnitude
				Dim xStep As Double = rand.NextDouble() * magnitude

				If xStep < 0 Then
					xStep = 0
				End If

				angle += phase
				prevXVal += xStep

				yValues(i) = prevYVal + yStep
				xValues(i) = prevXVal
				i += 1
			Loop

			line.Values.AddRange(yValues)
			line.XValues.AddRange(xValues)
		End Sub
	End Class
End Namespace
