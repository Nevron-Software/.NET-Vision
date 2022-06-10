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
	<ToolboxItem(False)>
	Public Class NMeshEmptyPointsUC
		Inherits NExampleBaseUC

		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.SuspendLayout()
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(13, 19)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(153, 20)
			Me.smoothShadingCheck.TabIndex = 4
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' NMeshEmptyPointsUC
			' 
			Me.Controls.Add(Me.smoothShadingCheck)
			Me.Name = "NMeshEmptyPointsUC"
			Me.Size = New System.Drawing.Size(180, 88)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface With Empty Data Points")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 25.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			' setup axes
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
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.FillMode = SurfaceFillMode.Zone
			surface.PositionValue = 0.5
			surface.Data.SetGridSize(20, 20)
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.00"

			FillData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			smoothShadingCheck.Checked = True
		End Sub

		Private Sub FillData(ByVal surface As NMeshSurfaceSeries)
			Dim x, y, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 8.0
			Const dIntervalZ As Double = 8.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			For j As Integer = 0 To nCountZ - 1
				For i As Integer = 0 To nCountX - 1
					x = -(dIntervalX / 2) + (i * dIncrementX)
					z = -(dIntervalZ / 2) + (j * dIncrementZ)

					y = Math.Log(Math.Abs(x) * Math.Abs(z))

					x += Math.Sin(j / 2.0) / 2.2
					z += Math.Cos(i / 2.0) / 2.2

					If y > -7 Then
						surface.Data.SetValue(i, j, y, x, z)
					Else
						surface.Data.SetValue(i, j, DBNull.Value, DBNull.Value, DBNull.Value)
					End If
				Next i
			Next j
		End Sub

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