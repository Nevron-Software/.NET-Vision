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
	Public Partial Class NSampledLine3DUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' Init Form controls
				WebExamplesUtilities.FillComboWithValues(SampleDistanceDropDownList, 1, 10, 1)
				SampleDistanceDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(NumberOfTurnsDropDownList, 3, 20, 1)
				NumberOfTurnsDropDownList.SelectedIndex = 2

				WebExamplesUtilities.FillComboWithValues(NumberOfPointsInTurnDropDownList, 10000, 30000, 10000)
				NumberOfPointsInTurnDropDownList.SelectedIndex = 1
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Sampled Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 50
			chart.Height = 50
			chart.Depth = 50
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			' add the line
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.DataLabelStyle.Visible = False
			line.BorderStyle.Color = DarkOrange
			line.MarkerStyle.Visible = False
			line.Name = "Line Series"
			line.Legend.Mode = SeriesLegendMode.None

			' update sampling parameters
			line.SamplingMode = SeriesSamplingMode.Enabled
			line.SampleDistance = New NLength(CSng(SampleDistanceDropDownList.SelectedIndex) + 1, NGraphicsUnit.Pixel)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			GenerateXYZData(line)
			NumberOfDataPointsLabel.Text = "Number of Data Points:" & (line.Values.Count / 1000).ToString() & "K"

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateXYZData(ByVal line As NLineSeries)
			Dim numberOfTurns As Integer = NumberOfTurnsDropDownList.SelectedIndex + 3
			Dim numberOfPointsInTurn As Integer = (NumberOfPointsInTurnDropDownList.SelectedIndex + 1) * 10000
			Dim i As Integer = 0
			Do While i < numberOfTurns
				AddTurn(line, numberOfPointsInTurn)
				i += 1
			Loop
		End Sub

		Private Sub AddTurn(ByVal line As NLineSeries, ByVal count As Integer)
			Dim rand As Random = New Random()
			Dim prevYVal As Double = 0
			Dim prevXVal As Double = 0
			Dim prevZVal As Double = 0

			Dim angle As Double = 0
			Dim phase As Double = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001
			Dim magnitude As Double = rand.NextDouble() * 5

			Dim xValues As Double() = New Double(count - 1){}
			Dim yValues As Double() = New Double(count - 1){}
			Dim zValues As Double() = New Double(count - 1){}

			Dim valueCount As Integer = line.Values.Count
			If valueCount > 0 Then
				prevYVal = CDbl(line.Values(valueCount - 1))
				prevXVal = CDbl(line.XValues(valueCount - 1))
				prevZVal = CDbl(line.ZValues(valueCount - 1))
			End If

			Dim i As Integer = 0
			Do While i < count
				Dim yStep As Double = Math.Cos(angle) + Math.Sin(angle) * magnitude
				Dim xStep As Double = Math.Cos(angle) * magnitude
				Dim zStep As Double = Math.Sin(angle) * magnitude

				If xStep < 0 Then
					xStep = 0
				End If

				angle += phase

				yValues(i) = prevYVal + yStep
				xValues(i) = prevXVal + xStep
				zValues(i) = prevZVal + zStep

				prevXVal = xValues(i)
				prevYVal = yValues(i)
				prevZVal = zValues(i)
				i += 1
			Loop

			line.Values.AddRange(yValues)
			line.XValues.AddRange(xValues)
			line.ZValues.AddRange(zValues)
		End Sub
	End Class
End Namespace
