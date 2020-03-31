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
	Public Class NMeshFillStyleUC
		Inherits NExampleBaseUC

		Private WithEvents FillStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' FillStyleButton
			' 
			Me.FillStyleButton.Location = New System.Drawing.Point(4, 10)
			Me.FillStyleButton.Name = "FillStyleButton"
			Me.FillStyleButton.Size = New System.Drawing.Size(171, 27)
			Me.FillStyleButton.TabIndex = 1
			Me.FillStyleButton.Text = "Surface Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FillStyleButton.Click += new System.EventHandler(this.FillStyleButton_Click);
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(4, 45)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(163, 20)
			Me.smoothShadingCheck.TabIndex = 5
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' NMeshFillStyleUC
			' 
			Me.Controls.Add(Me.smoothShadingCheck)
			Me.Controls.Add(Me.FillStyleButton)
			Me.Name = "NMeshFillStyleUC"
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
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface With Texture")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
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

			' setup surface
			Dim surface As NMeshSurfaceSeries = CType(chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
			surface.Name = "Surface"
			surface.FrameMode = SurfaceFrameMode.None
			surface.FillMode = SurfaceFillMode.Uniform
			surface.Data.SetGridSize(50, 50)

			FillData(surface)

			Dim imageFillStyle As New NImageFillStyle(NResourceHelper.BitmapFromResource(Me.GetType(), "Marble.jpg", "Nevron.Examples.Chart.WinForm.Resources"))
			imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled
			imageFillStyle.TextureMappingStyle.HorizontalScale = 0.1F
			imageFillStyle.TextureMappingStyle.VerticalScale = 0.1F

			surface.FillStyle = imageFillStyle

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' form controls
			smoothShadingCheck.Checked = True
		End Sub

		Private Sub FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FillStyleButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(surface.FillStyle, fillStyleResult) Then
				surface.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub FillData(ByVal surface As NMeshSurfaceSeries)
			Dim x, y, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 4.4
			Const dIntervalZ As Double = 4.4
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			For j As Integer = 0 To nCountZ - 1
				For i As Integer = 0 To nCountX - 1
					x = -(dIntervalX * 0.5) + (i * dIncrementX)
					z = -(dIntervalZ * 0.5) + (j * dIncrementZ)

					y = 8 * Math.Cos(x * x) + 5 * Math.Sin(z * z)

					x += Math.Sin(j * 0.25) * 0.25
					z += Math.Cos(i * 0.25) * 0.25

					surface.Data.SetValue(i, j, y, x, z)
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