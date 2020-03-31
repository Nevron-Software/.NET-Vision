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
	Public Class NRectilinearGridUC
		Inherits NExampleBaseUC

		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents GenerateDataButton As UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
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
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(9, 48)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(158, 20)
			Me.smoothShadingCheck.TabIndex = 3
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(9, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(158, 23)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' NRectilinearGridUC
			' 
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Controls.Add(Me.smoothShadingCheck)
			Me.Name = "NRectilinearGridUC"
			Me.Size = New System.Drawing.Size(176, 151)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As New NLabel("Rectilinear Grid Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 30.0F
			chart.Height = 2.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight)

			' setup axes
			Dim scaleX As New NDateTimeScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Back }
			scaleX.InflateViewRangeBegin = False
			scaleX.InflateViewRangeEnd = False

			Dim scaleZ As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Left }
			scaleZ.InflateViewRangeBegin = False
			scaleZ.InflateViewRangeEnd = False

			' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.PositionValue = 10.0
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.000"
			surface.FillMode = SurfaceFillMode.Uniform
			surface.FrameMode = SurfaceFrameMode.Mesh
			surface.ShadingMode = ShadingMode.Flat
			surface.FillStyle = New NColorFillStyle(Color.FromArgb(190, 210, 230))

			' specify that the surface should use custom X and Z values
			surface.XValuesMode = GridSurfaceValuesMode.CustomValues
			surface.ZValuesMode = GridSurfaceValuesMode.CustomValues

			surface.Data.SetGridSize(40, 20)

			GenerateXValues(surface)
			GenerateZValues(surface)
			FillData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			smoothShadingCheck.Checked = True
		End Sub

		Private Sub GenerateXValues(ByVal surface As NGridSurfaceSeries)
			Dim sizeX As Integer = surface.Data.GridSizeX

			Dim dtX As Date = Date.Now

			surface.XValues.Clear()

			For i As Integer = 0 To sizeX - 1
				surface.XValues.Add(dtX.ToOADate())
				dtX = dtX.AddMinutes(Random.Next(5, 20))
			Next i
		End Sub
		Private Sub GenerateZValues(ByVal surface As NGridSurfaceSeries)
			Dim sizeZ As Integer = surface.Data.GridSizeZ

			Dim z As Double = 7

			surface.ZValues.Clear()

			For i As Integer = 0 To sizeZ - 1
				surface.ZValues.Add(z)
				z += 0.1 + Random.NextDouble()
			Next i
		End Sub
		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 8.0
			Const dIntervalZ As Double = 8.0

			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = 0

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = Math.Sin(x * 1.2) * Math.Sin(z * 1.2)

					If y < 0 Then
						y = -y
					End If

					surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub SmoothShadingCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothShadingCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GenerateDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			GenerateXValues(surface)
			GenerateZValues(surface)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace