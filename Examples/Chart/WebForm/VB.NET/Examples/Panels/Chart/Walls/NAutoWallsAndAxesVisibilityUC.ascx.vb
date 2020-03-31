Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAutoWallsAndAxesVisibilityUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Chart Walls<br/><font size = '9pt'>Demonstrates how to enable automatic wall visibility and automatic axis anchors</font>")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			nChartControl1.Panels.Add(title)

			Dim chart As NChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)
			chart.Enable3D = True
			chart.Width = 55
			chart.Height = 25
			chart.Depth = 40
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			' add interlaced stripe to the Y axis
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left, ChartWallType.Right, ChartWallType.Front }

			Dim scaleY As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleY.StripStyles.Add(stripStyle)

			' create several series
			For i As Integer = 0 To 3
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.Values.FillRandom(Random, 6)
				bar.DataLabelStyle.Visible = False
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' update form controls
			If (Not IsPostBack) Then
				RotationTextBox.Text = chart.Projection.Rotation.ToString()
				ElevationTextBox.Text = chart.Projection.Elevation.ToString()
				LightsInCameraSpaceCheckBox.Checked = True
				AutoWallsVisibilityCheckBox.Checked = True

				AxisAnchorsModeDropDownList.Items.Add("Best Visibility")
				AxisAnchorsModeDropDownList.Items.Add("Auto Side")
				AxisAnchorsModeDropDownList.Items.Add("Manual")
				AxisAnchorsModeDropDownList.SelectedIndex = 0
			End If

			' configure lights
			Dim lightSource As NPointLightSource = New NPointLightSource()
			lightSource.Position = New NVector3DF(2, 2, 50)
			lightSource.Ambient = Color.FromArgb(64, 64, 64)
			lightSource.Diffuse = Color.FromArgb(255, 255, 255)
			lightSource.Specular = Color.FromArgb(100, 100, 100)

			chart.LightModel.LightSources.Clear()
			chart.LightModel.LightSources.Add(lightSource)
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(0, 0, 0)

			If LightsInCameraSpaceCheckBox.Checked Then
				lightSource.CoordinateMode = LightSourceCoordinateMode.Camera
				lightSource.Position = New NVector3DF(0, 0, 50)
			Else
				lightSource.CoordinateMode = LightSourceCoordinateMode.Model
				lightSource.Position = New NVector3DF(100, 95, 110)
			End If

			chart.Projection.Rotation = CSng(Convert.ToDouble(RotationTextBox.Text))
			chart.Projection.Elevation = CSng(Convert.ToDouble(ElevationTextBox.Text))


			' update walls visiblity
			If AutoWallsVisibilityCheckBox.Checked Then
				For Each wall As NChartWall In chart.Walls
					wall.VisibilityMode = WallVisibilityMode.Auto
				Next wall
			Else
				chart.Wall(ChartWallType.Left).VisibilityMode = WallVisibilityMode.Visible
				chart.Wall(ChartWallType.Back).VisibilityMode = WallVisibilityMode.Visible
				chart.Wall(ChartWallType.Floor).VisibilityMode = WallVisibilityMode.Visible
				chart.Wall(ChartWallType.Front).VisibilityMode = WallVisibilityMode.Hidden
				chart.Wall(ChartWallType.Top).VisibilityMode = WallVisibilityMode.Hidden
				chart.Wall(ChartWallType.Right).VisibilityMode = WallVisibilityMode.Hidden
			End If

			' update axis anchors
			Dim anchorY As NAxisAnchor = Nothing
			Dim anchorX As NAxisAnchor = Nothing
			Dim anchorZ As NAxisAnchor = Nothing

			Select Case AxisAnchorsModeDropDownList.SelectedIndex
				Case 0
					anchorY = New NBestVisibilityAxisAnchor(AxisOrientation.Vertical)
					anchorX = New NBestVisibilityAxisAnchor(AxisOrientation.Horizontal)
					anchorZ = New NBestVisibilityAxisAnchor(AxisOrientation.Depth)

				Case 1
					anchorY = New NAutoSideAxisAnchor(AxisOrientation.Vertical)
					anchorX = New NAutoSideAxisAnchor(AxisOrientation.Horizontal)
					anchorZ = New NAutoSideAxisAnchor(AxisOrientation.Depth)

				Case 2
					anchorY = New NDockAxisAnchor(AxisDockZone.FrontLeft)
					anchorX = New NDockAxisAnchor(AxisDockZone.FrontBottom)
					anchorZ = New NDockAxisAnchor(AxisDockZone.BottomRight)
			End Select

			chart.Axis(StandardAxis.PrimaryY).Anchor = anchorY
			chart.Axis(StandardAxis.PrimaryX).Anchor = anchorX
			chart.Axis(StandardAxis.Depth).Anchor = anchorZ

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
