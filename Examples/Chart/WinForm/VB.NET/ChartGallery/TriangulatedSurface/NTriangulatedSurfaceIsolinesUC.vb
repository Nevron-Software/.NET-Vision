Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports Nevron.UI
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NTriangulatedSurfaceIsolinesUC
		Inherits NExampleBaseUC

		Private label1 As Label
		Private WithEvents RedIsolineValueNumericUpDown As NumericUpDown
		Private WithEvents BlueIsolineValueNumericUpDown As NumericUpDown
		Private label2 As Label
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.RedIsolineValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.BlueIsolineValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			DirectCast(Me.RedIsolineValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.BlueIsolineValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(10, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(93, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Red Isoline Value:"
			' 
			' RedIsolineValueNumericUpDown
			' 
			Me.RedIsolineValueNumericUpDown.Location = New System.Drawing.Point(13, 27)
			Me.RedIsolineValueNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.RedIsolineValueNumericUpDown.Name = "RedIsolineValueNumericUpDown"
			Me.RedIsolineValueNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.RedIsolineValueNumericUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedIsolineValueNumericUpDown.ValueChanged += new System.EventHandler(this.RedIsolineValueNumericUpDown_ValueChanged);
			' 
			' BlueIsolineValueNumericUpDown
			' 
			Me.BlueIsolineValueNumericUpDown.Location = New System.Drawing.Point(13, 73)
			Me.BlueIsolineValueNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.BlueIsolineValueNumericUpDown.Name = "BlueIsolineValueNumericUpDown"
			Me.BlueIsolineValueNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.BlueIsolineValueNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BlueIsolineValueNumericUpDown.ValueChanged += new System.EventHandler(this.BlueIsolineValueNumericUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(10, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(94, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Blue Isoline Value:"
			' 
			' NTriangulatedSurfaceIsolinesUC
			' 
			Me.Controls.Add(Me.BlueIsolineValueNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.RedIsolineValueNumericUpDown)
			Me.Controls.Add(Me.label1)
			Me.Name = "NTriangulatedSurfaceIsolinesUC"
			Me.Size = New System.Drawing.Size(180, 496)
			DirectCast(Me.RedIsolineValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.BlueIsolineValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Triangulated Surface Isolines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Fit
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 10.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Projection.Elevation = 45
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.RoundToTickMax = False
			scaleY.RoundToTickMin = False
			scaleY.MinTickDistance = New NLength(10, NGraphicsUnit.Point)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Back }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' setup X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.RoundToTickMax = False
			scaleX.RoundToTickMin = False
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As New NLinearScaleConfigurator()
			scaleZ.RoundToTickMax = False
			scaleZ.RoundToTickMin = False
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Left }
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' add the surface series
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series.Add(SeriesType.TriangulatedSurface), NTriangulatedSurfaceSeries)
			surface.Name = "Surface"
			surface.Legend.Mode = SeriesLegendMode.None
			surface.SyncPaletteWithAxisScale = False
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FrameMode = SurfaceFrameMode.None
			surface.Palette.SmoothPalette = True
			surface.FillStyle = New NColorFillStyle(Color.YellowGreen)

			FillData()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			m_RedIsoline = New NSurfaceIsoline()
			m_RedIsoline.StrokeStyle = New NStrokeStyle(2.0F, Color.Red)
			surface.Isolines.Add(m_RedIsoline)

			m_BlueIsoline = New NSurfaceIsoline()
			m_BlueIsoline.StrokeStyle = New NStrokeStyle(2.0F, Color.Blue)
			surface.Isolines.Add(m_BlueIsoline)

			RedIsolineValueNumericUpDown.Value = 100
			BlueIsolineValueNumericUpDown.Value = 50
		End Sub

		Private Sub FillData()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			Dim stream As Stream = Nothing
			Dim reader As BinaryReader = Nothing

			Try
				' fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(Me.GetType().Assembly, "DataXYZ.bin", "Nevron.Examples.Chart.WinForm.Resources")
				reader = New BinaryReader(stream)

				Dim nDataPointsCount As Integer = CInt(stream.Length) \ 12

				' fill Y values
				For i As Integer = 0 To nDataPointsCount - 1
					surface.Values.Add(reader.ReadSingle())
				Next i

				' fill X values
				For i As Integer = 0 To nDataPointsCount - 1
					surface.XValues.Add(reader.ReadSingle())
				Next i

				' fill Z values
				For i As Integer = 0 To nDataPointsCount - 1
					surface.ZValues.Add(reader.ReadSingle())
				Next i
			Finally
				If reader IsNot Nothing Then
					reader.Close()
				End If

				If stream IsNot Nothing Then
					stream.Close()
				End If
			End Try
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
