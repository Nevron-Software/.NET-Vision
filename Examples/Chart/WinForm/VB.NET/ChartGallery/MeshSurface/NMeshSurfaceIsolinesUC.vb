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
	Public Class NMeshSurfaceIsolinesUC
		Inherits NExampleBaseUC

		Private WithEvents BlueIsolineValueNumericUpDown As NumericUpDown
		Private label2 As Label
		Private WithEvents RedIsolineValueNumericUpDown As NumericUpDown
		Private label1 As Label
		Private components As System.ComponentModel.Container = Nothing

		Private m_RedIsoline As NSurfaceIsoline
		Private m_BlueIsoline As NSurfaceIsoline

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
			Me.BlueIsolineValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.RedIsolineValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			DirectCast(Me.BlueIsolineValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RedIsolineValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' BlueIsolineValueNumericUpDown
			' 
			Me.BlueIsolineValueNumericUpDown.Location = New System.Drawing.Point(13, 73)
			Me.BlueIsolineValueNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.BlueIsolineValueNumericUpDown.Name = "BlueIsolineValueNumericUpDown"
			Me.BlueIsolineValueNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.BlueIsolineValueNumericUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BlueIsolineValueNumericUpDown.ValueChanged += new System.EventHandler(this.BlueIsolineValueNumericUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(10, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(94, 13)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Blue Isoline Value:"
			' 
			' RedIsolineValueNumericUpDown
			' 
			Me.RedIsolineValueNumericUpDown.Location = New System.Drawing.Point(13, 27)
			Me.RedIsolineValueNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.RedIsolineValueNumericUpDown.Name = "RedIsolineValueNumericUpDown"
			Me.RedIsolineValueNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.RedIsolineValueNumericUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedIsolineValueNumericUpDown.ValueChanged += new System.EventHandler(this.RedIsolineValueNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(10, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(93, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Red Isoline Value:"
			' 
			' NMeshSurfaceIsolinesUC
			' 
			Me.Controls.Add(Me.BlueIsolineValueNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.RedIsolineValueNumericUpDown)
			Me.Controls.Add(Me.label1)
			Me.Name = "NMeshSurfaceIsolinesUC"
			Me.Size = New System.Drawing.Size(180, 300)
			DirectCast(Me.BlueIsolineValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RedIsolineValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.RenderSurface = RenderSurface.Window
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface Isolines")
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
			Dim surface As New NMeshSurfaceSeries()
			chart.Series.Add(surface)
			surface.ShadingMode = ShadingMode.Smooth
			surface.FillMode = SurfaceFillMode.ZoneTexture
			surface.FrameMode = SurfaceFrameMode.None
			surface.Data.SetGridSize(100, 100)
			surface.Palette.SmoothPalette = True

			' generate data
			GenerateSurfaceData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			m_RedIsoline = New NSurfaceIsoline()
			m_RedIsoline.StrokeStyle = New NStrokeStyle(2.0F, Color.Red)
			surface.Isolines.Add(m_RedIsoline)

			m_BlueIsoline = New NSurfaceIsoline()
			m_BlueIsoline.StrokeStyle = New NStrokeStyle(2.0F, Color.Blue)
			surface.Isolines.Add(m_BlueIsoline)

			RedIsolineValueNumericUpDown.Value = 100
			BlueIsolineValueNumericUpDown.Value = 50
		End Sub

		Private Sub GenerateSurfaceData(ByVal surface As NMeshSurfaceSeries)
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 20.0
			Const dIntervalZ As Double = 20.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			Dim pz As Double = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				Dim px As Double = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					Dim x As Double = px + Math.Sin(pz) * 0.4
					Dim z As Double = pz + Math.Cos(px) * 0.4
					Dim y As Double = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33) * 200

					If y < 0 Then
						y = - y * 0.7
					End If

					Dim tmp As Double = (1 - x * x - z * z)
					y -= tmp * tmp * 0.000001

					surface.Data.SetValue(i, j, y, x, z)
					i += 1
					px += dIncrementX
				Loop
				j += 1
				pz += dIncrementZ
			Loop
		End Sub

		Private Sub RedIsolineValueNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RedIsolineValueNumericUpDown.ValueChanged
			m_RedIsoline.Value = CDbl(RedIsolineValueNumericUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub BlueIsolineValueNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BlueIsolineValueNumericUpDown.ValueChanged
			m_BlueIsoline.Value = CDbl(BlueIsolineValueNumericUpDown.Value)
			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace