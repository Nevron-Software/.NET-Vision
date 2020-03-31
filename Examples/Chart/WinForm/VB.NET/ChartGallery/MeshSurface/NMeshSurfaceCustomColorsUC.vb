Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Resources
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NMeshSurfaceCustomColorsUC
		Inherits NExampleBaseUC
		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
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
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(3, 12)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(163, 20)
			Me.smoothShadingCheck.TabIndex = 5
			Me.smoothShadingCheck.Text = "Smooth Shading"
'			Me.smoothShadingCheck.CheckedChanged += New System.EventHandler(Me.SmoothShadingCheck_CheckedChanged);
			' 
			' NMeshSurfaceCustomColorsUC
			' 
			Me.Controls.Add(Me.smoothShadingCheck)
			Me.Name = "NMeshSurfaceCustomColorsUC"
			Me.Size = New System.Drawing.Size(180, 164)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface With Custom Colors")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
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
			surface.Data.SetGridSize(50, 50)

			FillData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' form controls
			smoothShadingCheck.Checked = True
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

			surface.Data.UseColors = True
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

		Private Sub SmoothShadingCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothShadingCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace