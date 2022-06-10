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
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NGridSurfaceHorizontalCrossSectionUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents PlaneValueNumericUpDown As NumericUpDown
		Private label1 As Label

		Private m_ContourLineSeries As NLineSeries
		Private m_CrossSectionPlane As NAxisConstLine

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
			Me.PlaneValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			DirectCast(Me.PlaneValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' PlaneValueNumericUpDown
			' 
			Me.PlaneValueNumericUpDown.Location = New System.Drawing.Point(12, 29)
			Me.PlaneValueNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.PlaneValueNumericUpDown.Name = "PlaneValueNumericUpDown"
			Me.PlaneValueNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.PlaneValueNumericUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PlaneValueNumericUpDown.ValueChanged += new System.EventHandler(this.PlaneValueNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 12)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(117, 13)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Horizontal Plane Value:"
			' 
			' NGridSurfaceHorizontalCrossSectionUC
			' 
			Me.Controls.Add(Me.PlaneValueNumericUpDown)
			Me.Controls.Add(Me.label1)
			Me.Name = "NGridSurfaceHorizontalCrossSectionUC"
			Me.Size = New System.Drawing.Size(180, 396)
			DirectCast(Me.PlaneValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Surface Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(Color.Gray)

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

			chart.Axis(StandardAxis.SecondaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 100.0F, 100.0F)
			chart.Axis(StandardAxis.SecondaryY).Visible = False

			m_ContourLineSeries = New NLineSeries()
			chart.Series.Add(m_ContourLineSeries)

			m_ContourLineSeries.UseXValues = True
			m_ContourLineSeries.UseZValues = True
			m_ContourLineSeries.BorderStyle.Width = New NLength(2)
			m_ContourLineSeries.BorderStyle.Color = Color.Red

			m_ContourLineSeries.DataLabelStyle.Visible = False
			m_ContourLineSeries.DisplayOnAxis(CInt(StandardAxis.PrimaryY), False)
			m_ContourLineSeries.DisplayOnAxis(CInt(StandardAxis.SecondaryY), True)
			m_ContourLineSeries.Legend.Mode = SeriesLegendMode.None

			m_CrossSectionPlane = New NAxisConstLine()
			m_CrossSectionPlane.Mode = ConstLineMode.Plane
			m_CrossSectionPlane.FillStyle = New NColorFillStyle(Color.FromArgb(25, Color.Blue))
			chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(m_CrossSectionPlane)

			 ' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.PositionValue = 10.0
			surface.Data.SetGridSize(31, 32)
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FillStyle = New NColorFillStyle(Color.YellowGreen)
			surface.Isolines.Add(New NSurfaceIsoline(10, New NStrokeStyle(2.0F, Color.Blue)))
			surface.FrameColorMode = SurfaceFrameColorMode.Uniform

			FillData(surface)

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			PlaneValueNumericUpDown.Value = 10
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

		Private Sub PlaneValueNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PlaneValueNumericUpDown.ValueChanged
			Dim value As Double = CDbl(PlaneValueNumericUpDown.Value)
			Dim surface As NGridSurfaceSeries = TryCast(nChartControl1.Charts(0).Series(1), NGridSurfaceSeries)

			If surface.Isolines.Count > 0 Then
				surface.Isolines(0).Value = value
			End If

			m_CrossSectionPlane.Value = value

			Dim path As NLevelPath = surface.GetContourForValue(value)

			m_ContourLineSeries.XValues.Clear()
			m_ContourLineSeries.ZValues.Clear()
			m_ContourLineSeries.Values.Clear()

			For Each contour As NLevelContour In path
				If contour.Count > 0 Then
					Dim index As Integer = m_ContourLineSeries.XValues.Count + 1
					Dim pointCount As Integer = contour.Count
					For i As Integer = 0 To pointCount - 1
						Dim point As NPointD = contour(i)
						m_ContourLineSeries.XValues.Add(point.X)
						m_ContourLineSeries.ZValues.Add(point.Y)
						m_ContourLineSeries.Values.Add(0)
					Next i

					m_ContourLineSeries.XValues.Add(m_ContourLineSeries.XValues(index))
					m_ContourLineSeries.ZValues.Add(m_ContourLineSeries.ZValues(index))
					m_ContourLineSeries.Values.Add(0)

					m_ContourLineSeries.XValues.Add(Double.NaN)
					m_ContourLineSeries.ZValues.Add(Double.NaN)
					m_ContourLineSeries.Values.Add(Double.NaN)
				End If
			Next contour

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace