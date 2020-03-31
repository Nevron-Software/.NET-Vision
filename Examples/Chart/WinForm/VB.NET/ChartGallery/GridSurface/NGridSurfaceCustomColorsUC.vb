Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGridSurfaceCustomColorsUC
		Inherits NExampleBaseUC
		Private WithEvents SmoothShadingCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents HasFillingCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents FrameModeCombo As UI.WinForm.Controls.NComboBox
		Private label1 As Label
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
			Me.SmoothShadingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HasFillingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.FrameModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' SmoothShadingCheckBox
			' 
			Me.SmoothShadingCheckBox.ButtonProperties.BorderOffset = 2
			Me.SmoothShadingCheckBox.Location = New System.Drawing.Point(9, 12)
			Me.SmoothShadingCheckBox.Name = "SmoothShadingCheckBox"
			Me.SmoothShadingCheckBox.Size = New System.Drawing.Size(160, 20)
			Me.SmoothShadingCheckBox.TabIndex = 1
			Me.SmoothShadingCheckBox.Text = "Smooth Shading"
'			Me.SmoothShadingCheckBox.CheckedChanged += New System.EventHandler(Me.SmoothShadingCheckBox_CheckedChanged);
			' 
			' HasFillingCheckBox
			' 
			Me.HasFillingCheckBox.ButtonProperties.BorderOffset = 2
			Me.HasFillingCheckBox.Location = New System.Drawing.Point(9, 40)
			Me.HasFillingCheckBox.Name = "HasFillingCheckBox"
			Me.HasFillingCheckBox.Size = New System.Drawing.Size(160, 20)
			Me.HasFillingCheckBox.TabIndex = 2
			Me.HasFillingCheckBox.Text = "Has Filling"
'			Me.HasFillingCheckBox.CheckedChanged += New System.EventHandler(Me.HasFillingCheckBox_CheckedChanged);
			' 
			' FrameModeCombo
			' 
			Me.FrameModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.FrameModeCombo.ListProperties.DataSource = Nothing
			Me.FrameModeCombo.ListProperties.DisplayMember = ""
			Me.FrameModeCombo.Location = New System.Drawing.Point(12, 88)
			Me.FrameModeCombo.Name = "FrameModeCombo"
			Me.FrameModeCombo.Size = New System.Drawing.Size(151, 21)
			Me.FrameModeCombo.TabIndex = 4
'			Me.FrameModeCombo.SelectedIndexChanged += New System.EventHandler(Me.FrameModeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 67)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(69, 13)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Frame Mode:"
			' 
			' NGridSurfaceCustomColorsUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.FrameModeCombo)
			Me.Controls.Add(Me.HasFillingCheckBox)
			Me.Controls.Add(Me.SmoothShadingCheckBox)
			Me.Name = "NGridSurfaceCustomColorsUC"
			Me.Size = New System.Drawing.Size(180, 300)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			'nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Grid Surface with Custom Colors")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0f
			chart.Depth = 60.0f
			chart.Height = 25.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' setup axes
			Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add the surface series
			Dim surface As NGridSurfaceSeries = New NGridSurfaceSeries()
			chart.Series.Add(surface)
			surface.ShadingMode = ShadingMode.Smooth
			surface.FillMode = SurfaceFillMode.CustomColors
			surface.FrameMode = SurfaceFrameMode.None
			surface.FrameColorMode = SurfaceFrameColorMode.CustomColors
			surface.FrameStrokeStyle.Color = Color.Red
			surface.FrameStrokeStyle.Width = New NLength(4)

			surface.Data.UseColors = True
			surface.Data.SetGridSize(50, 50)

			' define a custom palette
			surface.Palette.Clear()
			surface.Palette.Add(-3, DarkOrange)
			surface.Palette.Add(-2.5, LightOrange)
			surface.Palette.Add(-1, LightGreen)
			surface.Palette.Add(0, Turqoise)
			surface.Palette.Add(2, Blue)
			surface.Palette.Add(3, Purple)
			surface.Palette.Add(4, BeautifulRed)

			' generate data
			GenerateSurfaceData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			HasFillingCheckBox.Checked = True
			FrameModeCombo.Items.Add("None")
			FrameModeCombo.Items.Add("Mesh")
			FrameModeCombo.Items.Add("Dots")
			FrameModeCombo.SelectedIndex = 0
			SmoothShadingCheckBox.Checked = True
		End Sub

		Private Sub GenerateSurfaceData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 50.0
			Const dIntervalZ As Double = 50.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim semiWidth As Single = CSng(Math.Min(nCountX / 2, nCountZ / 2))
			Dim startColor As Color = Color.Red
			Dim endColor As Color = Color.Green

			Dim centerX As Integer = nCountX / 2
			Dim centerZ As Integer = nCountZ / 2

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = (x * z / 64.0) - Math.Sin(z / 2.4) * Math.Cos(x / 2.4)
					y = Math.Abs(y)
					Dim tmp As Double = (1 - x * x - z * z)
					y -= tmp * tmp * 0.000006

					surface.Data.SetValue(i, j, y)

					Dim dx As Integer = centerX - i
					Dim dz As Integer = centerZ - j
					Dim distance As Single = CSng(Math.Sqrt(dx * dx + dz * dz))
					surface.Data.SetColor(i, j, InterpolateColors(startColor, endColor, distance / semiWidth))
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Public Shared Function InterpolateColors(ByVal color1 As Color, ByVal color2 As Color, ByVal factor As Single) As Color
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

		Private Sub SmoothShadingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SmoothShadingCheckBox.CheckedChanged
			Dim gridSurface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			If SmoothShadingCheckBox.Checked Then
				gridSurface.ShadingMode = ShadingMode.Smooth
			Else
				gridSurface.ShadingMode = ShadingMode.Flat
			End If
			nChartControl1.Refresh()
		End Sub

		Private Sub HasFillingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HasFillingCheckBox.CheckedChanged
			Dim gridSurface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			If HasFillingCheckBox.Checked Then
				gridSurface.FillMode = SurfaceFillMode.CustomColors
			Else
				gridSurface.FillMode = SurfaceFillMode.None
			End If
			nChartControl1.Refresh()
		End Sub

		Private Sub FrameModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FrameModeCombo.SelectedIndexChanged
			Dim gridSurface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			Select Case FrameModeCombo.SelectedIndex
				Case 0 ' none
					gridSurface.FrameMode = SurfaceFrameMode.None
				Case 1 ' mesh
					gridSurface.FrameMode = SurfaceFrameMode.Mesh
				Case 2 ' dots
					gridSurface.FrameMode = SurfaceFrameMode.Dots
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace