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
	Public Class NLargeMeshSurfaceUC
		Inherits NExampleBaseUC

		Private WithEvents useHardwareAccelerationCheck As UI.WinForm.Controls.NCheckBox
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
			Me.useHardwareAccelerationCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' useHardwareAccelerationCheck
			' 
			Me.useHardwareAccelerationCheck.ButtonProperties.BorderOffset = 2
			Me.useHardwareAccelerationCheck.Location = New System.Drawing.Point(5, 7)
			Me.useHardwareAccelerationCheck.Name = "useHardwareAccelerationCheck"
			Me.useHardwareAccelerationCheck.Size = New System.Drawing.Size(171, 20)
			Me.useHardwareAccelerationCheck.TabIndex = 5
			Me.useHardwareAccelerationCheck.Text = "Use Hardware Acceleration"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.useHardwareAccelerationCheck.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheck_CheckedChanged);
			' 
			' NLargeMeshSurfaceUC
			' 
			Me.Controls.Add(Me.useHardwareAccelerationCheck)
			Me.Name = "NLargeMeshSurfaceUC"
			Me.Size = New System.Drawing.Size(180, 88)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface with 1000000 Data Points")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 50.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			' setup axes
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleY.MaxTickCount = 5

			Dim linearScale As New NLinearScaleConfigurator()
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

			' setup surface series
			Dim surface As NMeshSurfaceSeries = CType(chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
			surface.Name = "Surface"
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.CellTriangulationMode = MeshSurfaceCellTriangulationMode.Diagonal1
			surface.FrameMode = SurfaceFrameMode.None
			surface.FillMode = SurfaceFillMode.ZoneTexture
			surface.ShadingMode = ShadingMode.Smooth
			surface.SmoothPalette = True

			surface.Data.SetGridSize(1000, 1000)

			FillData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			useHardwareAccelerationCheck.Checked = True
		End Sub

		Private Sub FillData(ByVal surface As NMeshSurfaceSeries)
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Dim x, y, z As Double
			Dim dAngle As Double = 0
			Dim dRadius As Double = 100.0
			Dim dElevation As Double = 0

			For j As Integer = 0 To nCountZ - 1
				For i As Integer = 0 To nCountX - 1
					x = dRadius * Math.Cos(dAngle) * (1 + i)
					z = dRadius * Math.Sin(dAngle) * (1 + i)
					y = dElevation + Math.Sin(i * 0.1) + Math.Sin(i * 0.004) * 5

					surface.Data.SetValue(i, j, y, x, z)
				Next i

				If j < 700 Then
					dRadius -= 0.1
				Else
					dRadius += 0.1
				End If

				dElevation += 0.2
				dAngle += 0.008 * Math.PI
			Next j
		End Sub

		Private Sub UseHardwareAccelerationCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles useHardwareAccelerationCheck.CheckedChanged
			If useHardwareAccelerationCheck.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub
	End Class
End Namespace