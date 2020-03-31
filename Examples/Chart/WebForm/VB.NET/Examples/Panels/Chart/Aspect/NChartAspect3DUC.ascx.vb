Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NChartAspect3DUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Chart Aspect 3D")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10, 10, 10, 0)
			nChartControl1.Panels.Add(title)

			' setup chart
			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(New NLength(10))
			chart.Padding = New NMarginsL(2)

			chart.Enable3D = True
			chart.Width = 50
			chart.Height = 50
			chart.Depth = 50
			chart.BoundsMode = BoundsMode.Fit
			chart.ContentAlignment = ContentAlignment.BottomRight
			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			chart.Wall(ChartWallType.Back).Width = 0.01f
			chart.Wall(ChartWallType.Floor).Width = 0.01f
			chart.Wall(ChartWallType.Left).Width = 0.01f

			' apply predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)

			' add axis labels
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.Labels.Add("Miami")
			ordinalScale.Labels.Add("Chicago")
			ordinalScale.Labels.Add("Los Angeles")
			ordinalScale.Labels.Add("New York")
			ordinalScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			ordinalScale = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlace stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim barsCount As Integer = 7

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.Name = "Bar1"
			bar1.DataLabelStyle.Visible = False
			bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255)

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.MultiBarMode = MultiBarMode.Series
			bar2.Name = "Bar2"
			bar2.DataLabelStyle.Visible = False
			bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210)

			' add the third bar
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.MultiBarMode = MultiBarMode.Series
			bar3.Name = "Bar3"
			bar3.DataLabelStyle.Visible = False
			bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210)

			' add the second bar
			Dim bar4 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar4.MultiBarMode = MultiBarMode.Series
			bar4.Name = "Bar4"
			bar4.DataLabelStyle.Visible = False
			bar4.BorderStyle.Color = Color.FromArgb(255, 210, 210)

			' fill with random data
			bar1.Values.FillRandomRange(Random, barsCount, 10, 40)
			bar2.Values.FillRandomRange(Random, barsCount, 30, 60)
			bar3.Values.FillRandomRange(Random, barsCount, 50, 80)
			bar4.Values.FillRandomRange(Random, barsCount, 70, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			If (Not IsPostBack) Then
				' init form controls
				WebExamplesUtilities.FillComboWithValues(XProportionDropDownList, 1, 5, 1)
				XProportionDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(YProportionDropDownList, 1, 5, 1)
				YProportionDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(DepthProportionDropDownList, 1, 5, 1)
				DepthProportionDropDownList.SelectedIndex = 0

				Fit3DAxisContentCheckBox.Checked = True
				ShowContentAreaCheckBox.Checked = False
			End If

			chart.Width = (XProportionDropDownList.SelectedIndex + 1) * 10
			chart.Height = (YProportionDropDownList.SelectedIndex + 1) * 10
			chart.Depth = (DepthProportionDropDownList.SelectedIndex + 1) * 10

			Dim max As Single = Math.Max(Math.Max(chart.Width, chart.Height), chart.Depth)

			Dim scale As Single = 50 / max

			chart.Width *= scale
			chart.Height *= scale
			chart.Depth *= scale

			chart.Fit3DAxisContent = Fit3DAxisContentCheckBox.Checked

			If ShowContentAreaCheckBox.Checked Then
				chart.BorderStyle = New NStrokeBorderStyle()
			Else
				chart.BorderStyle = Nothing
			End If
		End Sub
	End Class
End Namespace
