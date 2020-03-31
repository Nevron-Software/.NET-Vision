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
	Public Class NGridFrameUC
		Inherits NExampleBaseUC
		Private m_Chart As NChart
		Private m_Surface As NGridSurfaceSeries
		Private WithEvents paletteFrameCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents smoothPaletteCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents lineStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents antialiasCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.paletteFrameCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.smoothPaletteCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.antialiasCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.lineStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' paletteFrameCheck
			' 
			Me.paletteFrameCheck.ButtonProperties.BorderOffset = 2
			Me.paletteFrameCheck.Location = New System.Drawing.Point(10, 10)
			Me.paletteFrameCheck.Name = "paletteFrameCheck"
			Me.paletteFrameCheck.Size = New System.Drawing.Size(157, 20)
			Me.paletteFrameCheck.TabIndex = 0
			Me.paletteFrameCheck.Text = "Palette Frame"
'			Me.paletteFrameCheck.CheckedChanged += New System.EventHandler(Me.paletteFrameCheck_CheckedChanged);
			' 
			' smoothPaletteCheck
			' 
			Me.smoothPaletteCheck.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck.Enabled = False
			Me.smoothPaletteCheck.Location = New System.Drawing.Point(10, 39)
			Me.smoothPaletteCheck.Name = "smoothPaletteCheck"
			Me.smoothPaletteCheck.Size = New System.Drawing.Size(157, 20)
			Me.smoothPaletteCheck.TabIndex = 1
			Me.smoothPaletteCheck.Text = "Smooth Palette"
'			Me.smoothPaletteCheck.CheckedChanged += New System.EventHandler(Me.smoothPaletteCheck_CheckedChanged);
			' 
			' antialiasCheck
			' 
			Me.antialiasCheck.ButtonProperties.BorderOffset = 2
			Me.antialiasCheck.Location = New System.Drawing.Point(10, 68)
			Me.antialiasCheck.Name = "antialiasCheck"
			Me.antialiasCheck.Size = New System.Drawing.Size(157, 21)
			Me.antialiasCheck.TabIndex = 2
			Me.antialiasCheck.Text = "Antialiasing"
'			Me.antialiasCheck.CheckedChanged += New System.EventHandler(Me.antialiasCheck_CheckedChanged);
			' 
			' lineStyleButton
			' 
			Me.lineStyleButton.Location = New System.Drawing.Point(10, 100)
			Me.lineStyleButton.Name = "lineStyleButton"
			Me.lineStyleButton.Size = New System.Drawing.Size(157, 27)
			Me.lineStyleButton.TabIndex = 3
			Me.lineStyleButton.Text = "Line Style..."
'			Me.lineStyleButton.Click += New System.EventHandler(Me.lineStyleButton_Click);
			' 
			' NGridFrameUC
			' 
			Me.Controls.Add(Me.lineStyleButton)
			Me.Controls.Add(Me.antialiasCheck)
			Me.Controls.Add(Me.paletteFrameCheck)
			Me.Controls.Add(Me.smoothPaletteCheck)
			Me.Name = "NGridFrameUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Wireframe Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Width = 60.0f
			m_Chart.Depth = 60.0f
			m_Chart.Height = 25.0f
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' setup axes
			Dim ordinalScale As NOrdinalScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add the surface series
			m_Surface = CType(m_Chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			m_Surface.Name = "Surface"
			m_Surface.FillMode = SurfaceFillMode.None
			m_Surface.FrameMode = SurfaceFrameMode.Mesh
			m_Surface.Data.SetGridSize(30, 30)
			m_Surface.SyncPaletteWithAxisScale = False
			m_Surface.ValueFormatter.FormatSpecifier = "0.00"

			FillData()

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' inti form controls
			smoothPaletteCheck.Checked = True
			paletteFrameCheck.Checked = True
			antialiasCheck.Checked = True
		End Sub

		Private Sub FillData()
			Dim y, x, z As Double
			Dim nCountX As Integer = m_Surface.Data.GridSizeX
			Dim nCountZ As Integer = m_Surface.Data.GridSizeZ

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

					m_Surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub


		Private Sub paletteFrameCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles paletteFrameCheck.CheckedChanged
			If paletteFrameCheck.Checked Then
				m_Surface.FrameColorMode = SurfaceFrameColorMode.Zone
				m_Surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			Else
				m_Surface.FrameColorMode = SurfaceFrameColorMode.Uniform
				m_Surface.Legend.Mode = SeriesLegendMode.Series
			End If

			nChartControl1.Refresh()

			smoothPaletteCheck.Enabled = paletteFrameCheck.Checked
		End Sub

		Private Sub smoothPaletteCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothPaletteCheck.CheckedChanged
			If smoothPaletteCheck.Checked Then
				m_Surface.SmoothPalette = True
				m_Surface.PaletteSteps = 7
				m_Surface.Legend.Format = "<zone_value>"
			Else
				m_Surface.SmoothPalette = False
				m_Surface.PaletteSteps = 8
				m_Surface.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub antialiasCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles antialiasCheck.CheckedChanged
			If antialiasCheck.Checked Then
				nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.AntiAlias
			Else
				nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			End If
			nChartControl1.Refresh()
		End Sub

		Private Sub lineStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lineStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle

			If NStrokeStyleTypeEditor.Edit(m_Surface.FrameStrokeStyle, strokeStyleResult) Then
				m_Surface.FrameStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace