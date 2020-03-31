Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGridContourUC
		Inherits NExampleBaseUC

		Private WithEvents PaletteFrameCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SmoothPaletteCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowFrameCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowFillingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DrawContourBorderCheckBox As UI.WinForm.Controls.NCheckBox
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
			Me.PaletteFrameCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SmoothPaletteCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowFrameCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowFillingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.DrawContourBorderCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' paletteFrameCheck
			' 
			Me.PaletteFrameCheck.ButtonProperties.BorderOffset = 2
			Me.PaletteFrameCheck.Location = New System.Drawing.Point(10, 73)
			Me.PaletteFrameCheck.Name = "paletteFrameCheck"
			Me.PaletteFrameCheck.Size = New System.Drawing.Size(160, 19)
			Me.PaletteFrameCheck.TabIndex = 2
			Me.PaletteFrameCheck.Text = "Palette Frame"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PaletteFrameCheck.CheckedChanged += new System.EventHandler(this.paletteFrameCheck_CheckedChanged);
			' 
			' smoothPaletteCheck
			' 
			Me.SmoothPaletteCheck.ButtonProperties.BorderOffset = 2
			Me.SmoothPaletteCheck.Location = New System.Drawing.Point(10, 99)
			Me.SmoothPaletteCheck.Name = "smoothPaletteCheck"
			Me.SmoothPaletteCheck.Size = New System.Drawing.Size(160, 19)
			Me.SmoothPaletteCheck.TabIndex = 3
			Me.SmoothPaletteCheck.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SmoothPaletteCheck.CheckedChanged += new System.EventHandler(this.smoothPaletteCheck_CheckedChanged);
			' 
			' showFrameCheck
			' 
			Me.ShowFrameCheck.ButtonProperties.BorderOffset = 2
			Me.ShowFrameCheck.Location = New System.Drawing.Point(10, 36)
			Me.ShowFrameCheck.Name = "showFrameCheck"
			Me.ShowFrameCheck.Size = New System.Drawing.Size(160, 19)
			Me.ShowFrameCheck.TabIndex = 1
			Me.ShowFrameCheck.Text = "Show Frame"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowFrameCheck.CheckedChanged += new System.EventHandler(this.showFrameCheck_CheckedChanged);
			' 
			' showFillingCheck
			' 
			Me.ShowFillingCheck.ButtonProperties.BorderOffset = 2
			Me.ShowFillingCheck.Location = New System.Drawing.Point(10, 10)
			Me.ShowFillingCheck.Name = "showFillingCheck"
			Me.ShowFillingCheck.Size = New System.Drawing.Size(160, 20)
			Me.ShowFillingCheck.TabIndex = 0
			Me.ShowFillingCheck.Text = "Show Filling"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowFillingCheck.CheckedChanged += new System.EventHandler(this.showFillingCheck_CheckedChanged);
			' 
			' DrawContourBorderCheckBox
			' 
			Me.DrawContourBorderCheckBox.ButtonProperties.BorderOffset = 2
			Me.DrawContourBorderCheckBox.Location = New System.Drawing.Point(10, 139)
			Me.DrawContourBorderCheckBox.Name = "DrawContourBorderCheckBox"
			Me.DrawContourBorderCheckBox.Size = New System.Drawing.Size(160, 19)
			Me.DrawContourBorderCheckBox.TabIndex = 4
			Me.DrawContourBorderCheckBox.Text = "Draw Contour Border"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DrawContourBorderCheckBox.CheckedChanged += new System.EventHandler(this.DrawContourBorderCheckBox_CheckedChanged);
			' 
			' NGridContourUC
			' 
			Me.Controls.Add(Me.DrawContourBorderCheckBox)
			Me.Controls.Add(Me.ShowFillingCheck)
			Me.Controls.Add(Me.ShowFrameCheck)
			Me.Controls.Add(Me.PaletteFrameCheck)
			Me.Controls.Add(Me.SmoothPaletteCheck)
			Me.Name = "NGridContourUC"
			Me.Size = New System.Drawing.Size(180, 231)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed

			' set a chart title
			Dim title As New NLabel("Contour Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 70.0F
			chart.Depth = 70.0F
			chart.Height = 0.1F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop)
			chart.LightModel.EnableLighting = False

			' hide chart walls
			chart.Wall(ChartWallType.Back).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False

			' setup Y axis
			chart.Axis(StandardAxis.PrimaryY).Visible = False

			' setup X axis
			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
			axisX.Anchor = New NDockAxisAnchor(AxisDockZone.FrontTop)
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.InnerMajorTickStyle.Visible = False
			scaleX.RoundToTickMin = False
			scaleX.RoundToTickMax = False
			axisX.ScaleConfigurator = scaleX

			' setup Z axis
			Dim axisZ As NAxis = chart.Axis(StandardAxis.Depth)
			axisZ.Anchor = New NDockAxisAnchor(AxisDockZone.TopRight)
			Dim scaleZ As New NLinearScaleConfigurator()
			scaleZ.InnerMajorTickStyle.Visible = False
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType(){}
			scaleZ.RoundToTickMin = False
			scaleZ.RoundToTickMax = False
			axisZ.ScaleConfigurator = scaleZ

			' add a surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Contour"
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.ValueFormatter = New NNumericValueFormatter("0.0")
			surface.FillMode = SurfaceFillMode.Zone
			surface.FrameMode = SurfaceFrameMode.Contour
			surface.ShadingMode = ShadingMode.Flat
			surface.DrawFlat = True
			surface.Data.SetGridSize(31, 31)

			' setup a custom palette
			surface.AutomaticPalette = False
			surface.Palette.Clear()

			surface.Palette.Add(0.0, Color.Purple)
			surface.Palette.Add(1.5, Color.MediumSlateBlue)
			surface.Palette.Add(3.0, Color.CornflowerBlue)
			surface.Palette.Add(4.5, Color.LimeGreen)
			surface.Palette.Add(6.0, Color.LightGreen)
			surface.Palette.Add(7.5, Color.Yellow)
			surface.Palette.Add(9.0, Color.Orange)
			surface.Palette.Add(10.5, Color.Red)
			surface.Palette.Add(100, Color.Red)

			' fill the surface with data
			FillData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' setup form controls
			ShowFillingCheck.Checked = True
			ShowFrameCheck.Checked = True
			PaletteFrameCheck.Checked = True
			SmoothPaletteCheck.Checked = True
			DrawContourBorderCheckBox.Checked = True
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 10.0
			Const dIntervalZ As Double = 10.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2)
					y += 3.0 * Math.Sin(x) * Math.Cos(z)

					surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub paletteFrameCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PaletteFrameCheck.CheckedChanged
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			If PaletteFrameCheck.Checked Then
				surface.FrameColorMode = SurfaceFrameColorMode.Zone
			Else
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub smoothPaletteCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SmoothPaletteCheck.CheckedChanged
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			If SmoothPaletteCheck.Checked Then
				surface.SmoothPalette = True
				surface.Legend.Format = "<zone_value>"
			Else
				surface.SmoothPalette = False
				surface.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub showFillingCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowFillingCheck.CheckedChanged
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			If ShowFillingCheck.Checked Then
				surface.FillMode = SurfaceFillMode.Zone
			Else
				surface.FillMode = SurfaceFillMode.None
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub showFrameCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowFrameCheck.CheckedChanged
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			If ShowFrameCheck.Checked Then
				surface.FrameMode = SurfaceFrameMode.Contour
				PaletteFrameCheck.Enabled = True
				DrawContourBorderCheckBox.Enabled = True
			Else
				surface.FrameMode = SurfaceFrameMode.None
				PaletteFrameCheck.Enabled = False
				DrawContourBorderCheckBox.Enabled = False
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub DrawContourBorderCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DrawContourBorderCheckBox.CheckedChanged
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)
			surface.DrawContourBorder = DrawContourBorderCheckBox.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace