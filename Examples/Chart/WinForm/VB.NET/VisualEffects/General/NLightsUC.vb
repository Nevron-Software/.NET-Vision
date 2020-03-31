Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Text
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLightsUC
		Inherits NExampleBaseUC
		Private WithEvents CustomLightModelCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PredefinedLightModelCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents UseCustomLightModelButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents UsePredefinedLightModelButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			CustomLightModelCombo.Items.Add("Directional Light")
			CustomLightModelCombo.Items.Add("Point Light")
			CustomLightModelCombo.Items.Add("Point Light in Camera Space")
			CustomLightModelCombo.Items.Add("Spot Light")
			CustomLightModelCombo.Items.Add("Multiple Light Sources")

			PredefinedLightModelCombo.FillFromEnum(GetType(PredefinedLightModel))
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.CustomLightModelCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.PredefinedLightModelCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.UseCustomLightModelButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.UsePredefinedLightModelButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.SuspendLayout()
			' 
			' CustomLightModelCombo
			' 
			Me.CustomLightModelCombo.Location = New System.Drawing.Point(11, 37)
			Me.CustomLightModelCombo.Name = "CustomLightModelCombo"
			Me.CustomLightModelCombo.Size = New System.Drawing.Size(189, 21)
			Me.CustomLightModelCombo.TabIndex = 1
'			Me.CustomLightModelCombo.SelectedIndexChanged += New System.EventHandler(Me.CustomLightModelCombo_SelectedIndexChanged);
			' 
			' PredefinedLightModelCombo
			' 
			Me.PredefinedLightModelCombo.Location = New System.Drawing.Point(11, 94)
			Me.PredefinedLightModelCombo.Name = "PredefinedLightModelCombo"
			Me.PredefinedLightModelCombo.Size = New System.Drawing.Size(189, 21)
			Me.PredefinedLightModelCombo.TabIndex = 3
'			Me.PredefinedLightModelCombo.SelectedIndexChanged += New System.EventHandler(Me.PredefinedLightModelCombo_SelectedIndexChanged);
			' 
			' UseCustomLightModelButton
			' 
			Me.UseCustomLightModelButton.ButtonProperties.BorderOffset = 2
			Me.UseCustomLightModelButton.Location = New System.Drawing.Point(11, 7)
			Me.UseCustomLightModelButton.Name = "UseCustomLightModelButton"
			Me.UseCustomLightModelButton.Size = New System.Drawing.Size(189, 24)
			Me.UseCustomLightModelButton.TabIndex = 0
			Me.UseCustomLightModelButton.Text = "Use Custom Light Model:"
'			Me.UseCustomLightModelButton.CheckedChanged += New System.EventHandler(Me.UseCustomLightModelButton_CheckedChanged);
			' 
			' UsePredefinedLightModelButton
			' 
			Me.UsePredefinedLightModelButton.ButtonProperties.BorderOffset = 2
			Me.UsePredefinedLightModelButton.Location = New System.Drawing.Point(11, 67)
			Me.UsePredefinedLightModelButton.Name = "UsePredefinedLightModelButton"
			Me.UsePredefinedLightModelButton.Size = New System.Drawing.Size(189, 24)
			Me.UsePredefinedLightModelButton.TabIndex = 2
			Me.UsePredefinedLightModelButton.Text = "Use Predefined Light Model:"
'			Me.UsePredefinedLightModelButton.CheckedChanged += New System.EventHandler(Me.UsePredefinedLightModelButton_CheckedChanged);
			' 
			' NLightsUC
			' 
			Me.Controls.Add(Me.UsePredefinedLightModelButton)
			Me.Controls.Add(Me.UseCustomLightModelButton)
			Me.Controls.Add(Me.PredefinedLightModelCombo)
			Me.Controls.Add(Me.CustomLightModelCombo)
			Me.Name = "NLightsUC"
			Me.Size = New System.Drawing.Size(213, 157)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Lighting in 3D")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' remove legends
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Width = 60
			chart.Height = 30
			chart.Depth = 60

			' setup X axis
			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
			axisX.Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Horizontal)
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.RoundToTickMin = False
			scaleX.RoundToTickMax = False
			axisX.ScaleConfigurator = scaleX

			' setup Y axis
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Vertical)
			Dim scaleY As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType(){}
			scaleY.RoundToTickMin = False
			scaleY.RoundToTickMax = False
			scaleY.MinTickDistance = New NLength(15, NGraphicsUnit.Point)

			' setup Z axis
			Dim axisZ As NAxis = chart.Axis(StandardAxis.Depth)
			axisZ.Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Depth)
			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleZ.RoundToTickMin = False
			scaleZ.RoundToTickMax = False
			axisZ.ScaleConfigurator = scaleZ

			' setup chart walls
			For Each wall As NChartWall In chart.Walls
				wall.VisibilityMode = WallVisibilityMode.Auto
			Next wall

			' create chart series
			CreateSurface(chart)
			CreateSpheres(chart)
			CreateBoxes(chart)


			CustomLightModelCombo.SelectedIndex = 1
			PredefinedLightModelCombo.SelectedIndex = 1
			UseCustomLightModelButton.Checked = True
		End Sub

		Private Sub CreateBoxes(ByVal chart As NChart)
			Dim shape As NShapeSeries = New NShapeSeries()
			chart.Series.Add(shape)
			shape.DataLabelStyle.Visible = False
			shape.InflateMargins = True
			shape.Shape = BarShape.Bar
			shape.UseXValues = True
			shape.UseZValues = True
			shape.XSizesUnits = MeasurementUnits.Model
			shape.YSizesUnits = MeasurementUnits.Model
			shape.ZSizesUnits = MeasurementUnits.Model

			Dim color As Color = Color.FromArgb(147, 120, 197)

			shape.FillStyle = New NColorFillStyle(color)
			shape.BorderStyle.Color = color

			shape.Values.Add(440)
			shape.XValues.Add(20)
			shape.ZValues.Add(25)
			shape.XSizes.Add(4)
			shape.YSizes.Add(4)
			shape.ZSizes.Add(4)

			shape.Values.Add(480)
			shape.XValues.Add(14)
			shape.ZValues.Add(25)
			shape.XSizes.Add(3)
			shape.YSizes.Add(3)
			shape.ZSizes.Add(3)

			shape.Values.Add(500)
			shape.XValues.Add(8)
			shape.ZValues.Add(25)
			shape.XSizes.Add(2)
			shape.YSizes.Add(2)
			shape.ZSizes.Add(2)
		End Sub
		Private Sub CreateSpheres(ByVal chart As NChart)
			Dim shape As NShapeSeries = New NShapeSeries()
			chart.Series.Add(shape)
			shape.DataLabelStyle.Visible = False
			shape.InflateMargins = True
			shape.Shape = BarShape.Ellipsoid
			shape.UseXValues = True
			shape.UseZValues = True
			shape.XSizesUnits = MeasurementUnits.Model
			shape.YSizesUnits = MeasurementUnits.Model
			shape.ZSizesUnits = MeasurementUnits.Model
			shape.FillStyle = New NColorFillStyle(Color.FromArgb(202, 100, 92))
			shape.BorderStyle = New NStrokeStyle(0, Color.White)

			shape.Values.Add(200)
			shape.XValues.Add(10)
			shape.ZValues.Add(10)
			shape.XSizes.Add(8)
			shape.YSizes.Add(8)
			shape.ZSizes.Add(8)
		End Sub
		Private Sub CreateSurface(ByVal chart As NChart)
			Dim surface As NGridSurfaceSeries = New NGridSurfaceSeries()
			chart.Series.Add(surface)
			surface.Name = "Surface"
			surface.FillMode = SurfaceFillMode.Uniform
			surface.FrameMode = SurfaceFrameMode.None
			surface.ShadingMode = ShadingMode.Smooth
			surface.Data.SetGridSize(30, 30)
			surface.SyncPaletteWithAxisScale = False
			surface.ValueFormatter.FormatSpecifier = "0.00"

			Dim color As Color = Color.FromArgb(190, 130, 189)

			Dim fillStyle As NFillStyle = New NColorFillStyle()
			Dim material As NMaterialStyle = fillStyle.MaterialStyle
			material.Ambient = color
			material.Diffuse = color
			material.Specular = Color.FromArgb(120, 120, 120)
			material.Emissive = Color.Black
			material.Shininess = 10

			surface.FillStyle = fillStyle

			FillSurfaceData(surface)
		End Sub
		Private Sub FillSurfaceData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 30.0
			Const dIntervalZ As Double = 30.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = (x * x) - (z * z)
					y += 200 * Math.Sin(x / 4.0) * Math.Cos(z / 4.0)

					surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub DirectionalLight(ByVal chart As NChart)
			Dim light As NDirectionalLightSource = New NDirectionalLightSource()

			light.CoordinateMode = LightSourceCoordinateMode.Model
			light.Direction = New NVector3DF(-2, -4, -3)
			light.Ambient = Color.FromArgb(60, 60, 60)
			light.Diffuse = Color.FromArgb(230, 230, 230)
			light.Specular = Color.FromArgb(50, 50, 50)

			chart.LightModel.LightSources.Clear()
			chart.LightModel.LightSources.Add(light)
			chart.LightModel.EnableLighting = True
			chart.LightModel.LocalViewpointLighting = True
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(60, 60, 60)
		End Sub
		Private Sub PointLight(ByVal chart As NChart)
			Dim light As NPointLightSource = New NPointLightSource()

			light.CoordinateMode = LightSourceCoordinateMode.Model
			light.Position = New NVector3DF(9, 36, 14)
			light.Ambient = Color.FromArgb(100, 100, 100)
			light.Diffuse = Color.FromArgb(210, 210, 210)
			light.Specular = Color.FromArgb(70, 70, 70)
			light.ConstantAttenuation = 0.6f
			light.LinearAttenuation = 0.004f
			light.QuadraticAttenuation = 0.0002f

			chart.LightModel.LightSources.Clear()
			chart.LightModel.LightSources.Add(light)
			chart.LightModel.EnableLighting = True
			chart.LightModel.LocalViewpointLighting = True
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(60, 60, 60)
		End Sub
		Private Sub PointLightInCameraSpace(ByVal chart As NChart)
			Dim light As NPointLightSource = New NPointLightSource()

			light.CoordinateMode = LightSourceCoordinateMode.Camera
			light.Position = New NVector3DF(0, 0, 0)
			light.Ambient = Color.FromArgb(100, 100, 100)
			light.Diffuse = Color.FromArgb(210, 210, 210)
			light.Specular = Color.FromArgb(90, 90, 90)
			light.ConstantAttenuation = 0.3f
			light.LinearAttenuation = 0.0003f
			light.QuadraticAttenuation = 0.00003f

			chart.LightModel.LightSources.Clear()
			chart.LightModel.LightSources.Add(light)
			chart.LightModel.EnableLighting = True
			chart.LightModel.LocalViewpointLighting = True
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(60, 60, 60)
		End Sub
		Private Sub MultipleLightSources(ByVal chart As NChart)
			Dim light1 As NPointLightSource = New NPointLightSource()
			light1.CoordinateMode = LightSourceCoordinateMode.Model
			light1.Position = New NVector3DF(0, 36, 16)
			light1.Ambient = Color.FromArgb(60, 0, 0)
			light1.Diffuse = Color.FromArgb(110, 20, 20)
			light1.Specular = Color.FromArgb(80, 60, 60)
			light1.ConstantAttenuation = 0.6f
			light1.LinearAttenuation = 0.004f
			light1.QuadraticAttenuation = 0.0002f

			Dim light2 As NPointLightSource = New NPointLightSource()
			light2.CoordinateMode = LightSourceCoordinateMode.Model
			light2.Position = New NVector3DF(13.85f, 36, -8)
			light2.Ambient = Color.FromArgb(0, 60, 0)
			light2.Diffuse = Color.FromArgb(20, 110, 20)
			light2.Specular = Color.FromArgb(60, 80, 60)
			light2.ConstantAttenuation = 0.6f
			light2.LinearAttenuation = 0.004f
			light2.QuadraticAttenuation = 0.0002f

			Dim light3 As NPointLightSource = New NPointLightSource()
			light3.CoordinateMode = LightSourceCoordinateMode.Model
			light3.Position = New NVector3DF(-13.85f, 36, -8)
			light3.Ambient = Color.FromArgb(0, 0, 60)
			light3.Diffuse = Color.FromArgb(20, 20, 110)
			light3.Specular = Color.FromArgb(60, 60, 80)
			light3.ConstantAttenuation = 0.6f
			light3.LinearAttenuation = 0.004f
			light3.QuadraticAttenuation = 0.0002f

			Dim light4 As NPointLightSource = New NPointLightSource()
			light4.CoordinateMode = LightSourceCoordinateMode.Camera
			light4.Position = New NVector3DF(0, 0, 0)
			light4.Ambient = Color.FromArgb(0, 0, 0)
			light4.Diffuse = Color.FromArgb(90, 90, 90)
			light4.Specular = Color.FromArgb(80, 80, 80)
			light4.ConstantAttenuation = 0.9f
			light4.LinearAttenuation = 0.0004f
			light4.QuadraticAttenuation = 0.0f

			chart.LightModel.LightSources.Clear()
			chart.LightModel.LightSources.Add(light1)
			chart.LightModel.LightSources.Add(light2)
			chart.LightModel.LightSources.Add(light3)
			chart.LightModel.LightSources.Add(light4)
			chart.LightModel.EnableLighting = True
			chart.LightModel.LocalViewpointLighting = True
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(60, 60, 60)
		End Sub
		Private Sub SpotLight(ByVal chart As NChart)
			Dim light As NSpotLightSource = New NSpotLightSource()

			light.CoordinateMode = LightSourceCoordinateMode.Model
			light.Position = New NVector3DF(14, 30, 14)
			light.Direction = New NVector3DF(-0.5f, -1, -0.4f)
			light.Ambient = Color.FromArgb(50, 50, 50)
			light.Diffuse = Color.FromArgb(180, 180, 210)
			light.Specular = Color.FromArgb(80, 80, 80)
			light.ConstantAttenuation = 0.3f
			light.LinearAttenuation = 0.001f
			light.QuadraticAttenuation = 0.0001f
			light.SpotCutoff = 45
			light.SpotExponent = 15

			chart.LightModel.LightSources.Clear()
			chart.LightModel.LightSources.Add(light)
			chart.LightModel.EnableLighting = True
			chart.LightModel.LocalViewpointLighting = True
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(100, 100, 100)
		End Sub

		Private Sub CustomLightModelCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CustomLightModelCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Select Case CustomLightModelCombo.SelectedIndex
				Case 0
					DirectionalLight(chart)

				Case 1
					PointLight(chart)

				Case 2
					PointLightInCameraSpace(chart)

				Case 3
					SpotLight(chart)

				Case 4
					MultipleLightSources(chart)
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub PredefinedLightModelCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PredefinedLightModelCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim lm As PredefinedLightModel = CType(PredefinedLightModelCombo.SelectedIndex, PredefinedLightModel)

			chart.LightModel.SetPredefinedLightModel(lm)

			nChartControl1.Refresh()
		End Sub
		Private Sub UseCustomLightModelButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UseCustomLightModelButton.CheckedChanged
			CustomLightModelCombo.Enabled = True
			PredefinedLightModelCombo.Enabled = False

			CustomLightModelCombo_SelectedIndexChanged(Nothing, Nothing)

			nChartControl1.Refresh()
		End Sub
		Private Sub UsePredefinedLightModelButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UsePredefinedLightModelButton.CheckedChanged
			CustomLightModelCombo.Enabled = False
			PredefinedLightModelCombo.Enabled = True

			PredefinedLightModelCombo_SelectedIndexChanged(Nothing, Nothing)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
