Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.UI
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLargeSurfaceUC
		Inherits NExampleBaseUC

		Private label1 As Label
		Private label2 As Label
		Private WithEvents surfaceSizeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents useHardwareAccelerationCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents fillModeCombo As UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()

			surfaceSizeCombo.Items.Add("500 x 500")
			surfaceSizeCombo.Items.Add("1024 x 1024")

			fillModeCombo.Items.Add("Uniform")
			fillModeCombo.Items.Add("Zone Texture")
			fillModeCombo.Items.Add("Zone Texture - Smooth")
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

		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.surfaceSizeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.useHardwareAccelerationCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.fillModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' surfaceSizeCombo
			' 
			Me.surfaceSizeCombo.ListProperties.CheckBoxDataMember = ""
			Me.surfaceSizeCombo.ListProperties.DataSource = Nothing
			Me.surfaceSizeCombo.ListProperties.DisplayMember = ""
			Me.surfaceSizeCombo.Location = New System.Drawing.Point(6, 67)
			Me.surfaceSizeCombo.Name = "surfaceSizeCombo"
			Me.surfaceSizeCombo.Size = New System.Drawing.Size(168, 21)
			Me.surfaceSizeCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.surfaceSizeCombo.SelectedIndexChanged += new System.EventHandler(this.SurfaceSizeCombo_SelectedIndexChanged);
			' 
			' useHardwareAccelerationCheck
			' 
			Me.useHardwareAccelerationCheck.ButtonProperties.BorderOffset = 2
			Me.useHardwareAccelerationCheck.Location = New System.Drawing.Point(6, 13)
			Me.useHardwareAccelerationCheck.Name = "useHardwareAccelerationCheck"
			Me.useHardwareAccelerationCheck.Size = New System.Drawing.Size(171, 20)
			Me.useHardwareAccelerationCheck.TabIndex = 0
			Me.useHardwareAccelerationCheck.Text = "Use Hardware Acceleration"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.useHardwareAccelerationCheck.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheck_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 50)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Surface Size:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 103)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(168, 13)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Fill Mode:"
			' 
			' fillModeCombo
			' 
			Me.fillModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.fillModeCombo.ListProperties.DataSource = Nothing
			Me.fillModeCombo.ListProperties.DisplayMember = ""
			Me.fillModeCombo.Location = New System.Drawing.Point(6, 120)
			Me.fillModeCombo.Name = "fillModeCombo"
			Me.fillModeCombo.Size = New System.Drawing.Size(168, 21)
			Me.fillModeCombo.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			' 
			' NLargeSurfaceUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.fillModeCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.surfaceSizeCombo)
			Me.Controls.Add(Me.useHardwareAccelerationCheck)
			Me.Name = "NLargeSurfaceUC"
			Me.Size = New System.Drawing.Size(180, 203)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None

			' add a trackball tool so that the user can rotate the chart
			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.Cache = True

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 55.0F
			chart.Depth = 55.0F
			chart.Height = 4.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.AutoLabels = False
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleY.MaxTickCount = 5

			Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.FrameMode = SurfaceFrameMode.None
			surface.ShadingMode = ShadingMode.Smooth
			surface.AutomaticPalette = True
			surface.SyncPaletteWithAxisScale = False

			' NOTE: Cell triangulation mode is important for performance. Use Diagonal1 or Diagonal2 for faster rendering.
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1

			Dim fill As New NColorFillStyle()
			fill.MaterialStyle.Ambient = Color.FromArgb(122, 125, 110)
			fill.MaterialStyle.Diffuse = Color.FromArgb(122, 125, 110)
			fill.MaterialStyle.Specular = Color.DimGray
			surface.FillStyle = fill

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			useHardwareAccelerationCheck.Checked = True
			surfaceSizeCombo.SelectedIndex = 0
			fillModeCombo.SelectedIndex = 1
		End Sub

		Private Sub UseHardwareAccelerationCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles useHardwareAccelerationCheck.CheckedChanged
			If useHardwareAccelerationCheck.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub
		Private Sub SurfaceSizeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles surfaceSizeCombo.SelectedIndexChanged
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			Dim heightMapName As String = ""

			Select Case surfaceSizeCombo.SelectedIndex
				Case 0
					heightMapName = "HeightMap0500.png"

				Case 1
					heightMapName = "HeightMap1024.png"

				Case Else
					Return
			End Select

			Dim bitmap As Bitmap = NResourceHelper.BitmapFromResource(Me.GetType(), heightMapName, "Nevron.Examples.Chart.WinForm.Resources")
			surface.Data.InitFromBitmap(bitmap)
			bitmap.Dispose()

			nChartControl1.Refresh()
		End Sub
		Private Sub FillModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles fillModeCombo.SelectedIndexChanged
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			Select Case fillModeCombo.SelectedIndex
				Case 0
					surface.FillMode = SurfaceFillMode.Uniform

				Case 1
					surface.FillMode = SurfaceFillMode.ZoneTexture
					surface.SmoothPalette = False
					surface.PaletteSteps = 8

				Case 2
					surface.FillMode = SurfaceFillMode.ZoneTexture
					surface.SmoothPalette = True
					surface.PaletteSteps = 7
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

