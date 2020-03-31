Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPanelZoomToolUC
		Inherits NExampleBaseUC

		Private m_PanelZoomTool As NPanelZoomTool
		Private WithEvents ZoomInFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ZoomOutFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PreserveAspectRatioCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ZoomInBoundsOnlyCheckBox As UI.WinForm.Controls.NCheckBox
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
			Me.ZoomInFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ZoomOutFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PreserveAspectRatioCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ZoomInBoundsOnlyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ZoomInFillStyleButton
			' 
			Me.ZoomInFillStyleButton.Location = New System.Drawing.Point(7, 11)
			Me.ZoomInFillStyleButton.Name = "ZoomInFillStyleButton"
			Me.ZoomInFillStyleButton.Size = New System.Drawing.Size(160, 23)
			Me.ZoomInFillStyleButton.TabIndex = 0
			Me.ZoomInFillStyleButton.Text = "Zoom In Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomInFillStyleButton.Click += new System.EventHandler(this.ZoomInFillStyleButton_Click);
			' 
			' ZoomOutFillStyleButton
			' 
			Me.ZoomOutFillStyleButton.Location = New System.Drawing.Point(7, 43)
			Me.ZoomOutFillStyleButton.Name = "ZoomOutFillStyleButton"
			Me.ZoomOutFillStyleButton.Size = New System.Drawing.Size(160, 23)
			Me.ZoomOutFillStyleButton.TabIndex = 1
			Me.ZoomOutFillStyleButton.Text = "Zoom Out Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomOutFillStyleButton.Click += new System.EventHandler(this.ZoomOutFillStyleButton_Click);
			' 
			' PreserveAspectRatioCheckBox
			' 
			Me.PreserveAspectRatioCheckBox.ButtonProperties.BorderOffset = 2
			Me.PreserveAspectRatioCheckBox.Location = New System.Drawing.Point(7, 70)
			Me.PreserveAspectRatioCheckBox.Name = "PreserveAspectRatioCheckBox"
			Me.PreserveAspectRatioCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.PreserveAspectRatioCheckBox.TabIndex = 2
			Me.PreserveAspectRatioCheckBox.Text = "Preserve Aspect Ratio"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PreserveAspectRatioCheckBox.CheckedChanged += new System.EventHandler(this.PreserveAspectRatioCheckBox_CheckedChanged);
			' 
			' ZoomInBoundsOnlyCheckBox
			' 
			Me.ZoomInBoundsOnlyCheckBox.ButtonProperties.BorderOffset = 2
			Me.ZoomInBoundsOnlyCheckBox.Location = New System.Drawing.Point(7, 94)
			Me.ZoomInBoundsOnlyCheckBox.Name = "ZoomInBoundsOnlyCheckBox"
			Me.ZoomInBoundsOnlyCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.ZoomInBoundsOnlyCheckBox.TabIndex = 3
			Me.ZoomInBoundsOnlyCheckBox.Text = "Zoom In Bounds Only"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomInBoundsOnlyCheckBox.CheckedChanged += new System.EventHandler(this.ZoomInBoundsOnlyCheckBox_CheckedChanged);
			' 
			' NPanelZoomToolUC
			' 
			Me.Controls.Add(Me.ZoomInBoundsOnlyCheckBox)
			Me.Controls.Add(Me.PreserveAspectRatioCheckBox)
			Me.Controls.Add(Me.ZoomOutFillStyleButton)
			Me.Controls.Add(Me.ZoomInFillStyleButton)
			Me.Name = "NPanelZoomToolUC"
			Me.Size = New System.Drawing.Size(180, 664)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Panel Zoom Tool")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 25.0F
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
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.FillMode = SurfaceFillMode.None
			surface.FrameMode = SurfaceFrameMode.Mesh
			surface.Data.SetGridSize(30, 30)
			surface.SyncPaletteWithAxisScale = False
			surface.ValueFormatter.FormatSpecifier = "0.00"

			FillData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			m_PanelZoomTool = New NPanelZoomTool()
			nChartControl1.Controller.Selection.SelectedObjects.Add(chart)
			nChartControl1.Controller.Tools.Add(m_PanelZoomTool)

			PreserveAspectRatioCheckBox.Checked = True
			ZoomInBoundsOnlyCheckBox.Checked = True
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

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

					surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub ZoomInFillStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ZoomInFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_PanelZoomTool.ZoomInFillStyle, fillStyleResult) Then
				m_PanelZoomTool.ZoomInFillStyle = fillStyleResult
			End If
		End Sub

		Private Sub ZoomOutFillStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ZoomOutFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_PanelZoomTool.ZoomOutFillStyle, fillStyleResult) Then
				m_PanelZoomTool.ZoomOutFillStyle = fillStyleResult
			End If
		End Sub

		Private Sub PreserveAspectRatioCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PreserveAspectRatioCheckBox.CheckedChanged
			If m_PanelZoomTool IsNot Nothing Then
				m_PanelZoomTool.PreserveAspect = PreserveAspectRatioCheckBox.Checked
			End If
		End Sub

		Private Sub ZoomInBoundsOnlyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ZoomInBoundsOnlyCheckBox.CheckedChanged
			If m_PanelZoomTool IsNot Nothing Then
				m_PanelZoomTool.ZoomInBoundsOnly = ZoomInBoundsOnlyCheckBox.Checked
			End If
		End Sub
	End Class
End Namespace
