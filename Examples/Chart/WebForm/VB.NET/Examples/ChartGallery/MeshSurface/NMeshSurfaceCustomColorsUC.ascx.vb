Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NMeshSurfaceCustomColorsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Settings.JitterMode = JitterMode.Enabled
				nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed

				nChartControl1.Controller.Tools.Clear()
				nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
				nChartControl1.Controller.Tools.Add(New NTrackballTool())

				' set a chart title
				Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface With Custom Colors")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				title.ContentAlignment = ContentAlignment.BottomCenter
				title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

				' no legend
				nChartControl1.Legends.Clear()

				' configure the chart
				Dim chart As NChart = nChartControl1.Charts(0)
				chart.Enable3D = True
				chart.Width = 55.0f
				chart.Depth = 55.0f
				chart.Height = 55.0f
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

				chart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(New NRange1DD(-120, 120), True, True)
				chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(-120, 120), True, True)
				chart.Axis(StandardAxis.Depth).View = New NRangeAxisView(New NRange1DD(-120, 120), True, True)

				' setup axes
				Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
				linearScale.RoundToTickMax = False
				linearScale.RoundToTickMin = False
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

				linearScale = New NLinearScaleConfigurator()
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
				linearScale.RoundToTickMax = False
				linearScale.RoundToTickMin = False
				chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale

				' setup surface
				Dim surface As NMeshSurfaceSeries = CType(chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
				surface.Name = "Surface"
				surface.FrameMode = SurfaceFrameMode.None
				surface.FillMode = SurfaceFillMode.CustomColors
				surface.ShadingMode = ShadingMode.Smooth

				surface.Data.UseColors = True
				surface.Data.SetGridSize(50, 50)

				FillData(surface)

				' apply layout
				ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

				chart.LightModel.EnableLighting = False
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
			End If
		End Sub

		Private Sub FillData(ByVal surface As NMeshSurfaceSeries)
			Dim m As Integer = 200
			Dim n As Integer = 100

			Dim lastM As Integer = m - 1
			Dim lastN As Integer = n - 1

			Dim centerX As Double = 0
			Dim centerZ As Double = 0
			Dim centerY As Double = 0

			Dim radius1 As Double = 100.0
			Dim radius2 As Double = 10.0

			Dim beginAlpha As Double = 0
			Dim endAlpha As Double = NMath.PI2
			Dim alphaStep As Double = 2 * NMath.PI2 / m

			Dim beginBeta As Double = 0
			Dim endBeta As Double = NMath.PI2
			Dim betaStep As Double = NMath.PI2 / n

			Dim arrPrecomputedData As NVector2DD() = New NVector2DD(m - 1){}

			Dim i As Integer = 0
			Do While i < m
				' calculate the current angle, its cos and sin
				Dim alpha As Double
				If (i = lastM) Then
					alpha = endAlpha
				Else
					alpha = (beginAlpha + i * alphaStep)
				End If

				arrPrecomputedData(i).X = Math.Cos(alpha)
				arrPrecomputedData(i).Y = Math.Sin(alpha)
				i += 1
			Loop

			Dim vertexIndex As Integer = 0

			surface.Data.SetGridSize(m, n)

			Dim beginColor As Color = Color.Red
			Dim endColor As Color = Color.Blue

			Dim offset As Single = -100

			Dim j As Integer = 0
			Do While j < n
				' calculate the current beta angle
				Dim beta As Double
				If (j = lastN) Then
					beta = endBeta
				Else
					beta = (beginBeta + j * betaStep)
				End If
				Dim fCosBeta As Double = CSng(Math.Cos(beta))
				Dim fSinBeta As Double = CSng(Math.Sin(beta))

				offset = -100

				i = 0
				Do While i < m
					Dim fCosAlpha As Double = arrPrecomputedData(i).X
					Dim fSinAlpha As Double = arrPrecomputedData(i).Y

					Dim fx As Double = fCosBeta * radius2 + radius1

					Dim dx As Double = fx * fCosAlpha
					Dim dz As Double = fx * fSinAlpha
					Dim dy As Double = -(fSinBeta * radius2)

					Dim x As Double = centerX + dx
					Dim y As Double = centerY + dy + offset
					Dim z As Double = centerZ + dz

					offset += 1

					surface.Data.SetValue(i, j, y, x, z)

					Dim length As Double = Math.Sqrt(dx * dx + dz * dz + dy * dy)
					surface.Data.SetColor(i, j, InterpolateColors(beginColor, endColor, CSng(i) / CSng(100))) '(length - (radius1 - radius2)) / radius2));

					vertexIndex += 1
					i += 1
				Loop
				j += 1
			Loop
		End Sub

		Public Shared Function InterpolateColors(ByVal color1 As Color, ByVal color2 As Color, ByVal factor As Double) As Color
			If factor > 1.0f Then
				factor = 1.0f
			End If

			Dim num1 As Integer = (CInt(Fix(color1.R)))
			Dim num2 As Integer = (CInt(Fix(color1.G)))
			Dim num3 As Integer = (CInt(Fix(color1.B)))

			Dim num4 As Integer = (CInt(Fix(color2.R)))
			Dim num5 As Integer = (CInt(Fix(color2.G)))
			Dim num6 As Integer = (CInt(Fix(color2.B)))

			Dim num7 As Byte = CByte(((CSng(num1)) + ((CSng(num4 - num1)) * factor)))
			Dim num8 As Byte = CByte(((CSng(num2)) + ((CSng(num5 - num2)) * factor)))
			Dim num9 As Byte = CByte(((CSng(num3)) + ((CSng(num6 - num3)) * factor)))

			Return Color.FromArgb(num7, num8, num9)
		End Function

	End Class
End Namespace
