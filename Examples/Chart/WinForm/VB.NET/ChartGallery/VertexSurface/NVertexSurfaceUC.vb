Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVertexSurfaceUC
		Inherits NExampleBaseUC
		Private WithEvents VertexPrimitiveCombo As UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing
		Private m_Surface As NVertexSurfaceSeries

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
			Me.VertexPrimitiveCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' VertexPrimitiveCombo
			' 
			Me.VertexPrimitiveCombo.ListProperties.CheckBoxDataMember = ""
			Me.VertexPrimitiveCombo.ListProperties.DataSource = Nothing
			Me.VertexPrimitiveCombo.ListProperties.DisplayMember = ""
			Me.VertexPrimitiveCombo.Location = New System.Drawing.Point(8, 27)
			Me.VertexPrimitiveCombo.Name = "VertexPrimitiveCombo"
			Me.VertexPrimitiveCombo.Size = New System.Drawing.Size(159, 21)
			Me.VertexPrimitiveCombo.TabIndex = 11
'			Me.VertexPrimitiveCombo.SelectedIndexChanged += New System.EventHandler(Me.VertexPrimitiveCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 11)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(159, 21)
			Me.label4.TabIndex = 10
			Me.label4.Text = "Vertex Primitive:"
			' 
			' NVertexSurfaceUC
			' 
			Me.Controls.Add(Me.VertexPrimitiveCombo)
			Me.Controls.Add(Me.label4)
			Me.Name = "NVertexSurfaceUC"
			Me.Size = New System.Drawing.Size(180, 956)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.RenderSurface = RenderSurface.Window

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0f
			chart.Depth = 60.0f
			chart.Height = 50.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			' setup axes
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleY.MaxTickCount = 5

			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
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
			m_Surface = New NVertexSurfaceSeries()
			chart.Series.Add(m_Surface)

			m_Surface.Name = "Surface"
			m_Surface.SyncPaletteWithAxisScale = False
			m_Surface.PaletteSteps = 8
			m_Surface.ValueFormatter.FormatSpecifier = "0.00"
			m_Surface.FillMode = SurfaceFillMode.ZoneTexture
			m_Surface.ShadingMode = ShadingMode.Smooth
			m_Surface.SmoothPalette = True

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			VertexPrimitiveCombo.FillFromEnum(GetType(VertexPrimitive))
			VertexPrimitiveCombo.SelectedIndex = CInt(Fix(VertexPrimitive.Points))
		End Sub

		Private Sub VertexPrimitiveCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VertexPrimitiveCombo.SelectedIndexChanged
			m_Surface.Data.Clear()

			Dim vertexPrimitive As VertexPrimitive = CType(VertexPrimitiveCombo.SelectedIndex, VertexPrimitive)

			m_Surface.VertexPrimitive = vertexPrimitive
			m_Surface.UseIndices = False

			Dim rand As Random = New Random()
			Dim descriptionText As String = String.Empty

			Select Case vertexPrimitive
				Case VertexPrimitive.Points
						descriptionText = "Each vertex represents a 3d point"

						m_Surface.FrameMode = SurfaceFrameMode.Dots

						For i As Integer = 0 To 999
							m_Surface.Data.AddValue(rand.Next(100), rand.Next(100), rand.Next(100))
						Next i
				Case VertexPrimitive.Lines
						descriptionText = "Each consecutive pair of vertices represents a line segment"

						m_Surface.FrameMode = SurfaceFrameMode.Dots

						For i As Integer = 0 To 19
							m_Surface.Data.AddValue(rand.Next(100), rand.Next(100), rand.Next(100))

							m_Surface.Data.AddValue(rand.Next(100), rand.Next(100), rand.Next(100))
						Next i

				Case VertexPrimitive.LineLoop, VertexPrimitive.LineStrip
						descriptionText = "Adjacent vertices are connected with a line segment"

						For i As Integer = 0 To 4
							m_Surface.Data.AddValue(rand.Next(100), rand.Next(100), rand.Next(100))
						Next i

				Case VertexPrimitive.Triangles
						descriptionText = "Each three consequtive vertices are considered a triangle"

						m_Surface.FrameMode = SurfaceFrameMode.Mesh

						Dim top As NVector3DD = New NVector3DD(0.5, 1, 0.5)
						Dim baseA As NVector3DD = New NVector3DD(0, 0, 0)
						Dim baseB As NVector3DD = New NVector3DD(1, 0, 0)
						Dim baseC As NVector3DD = New NVector3DD(1, 0, 1)
						Dim baseD As NVector3DD = New NVector3DD(0, 0, 1)

						m_Surface.Data.AddValue(top)
						m_Surface.Data.AddValue(baseA)
						m_Surface.Data.AddValue(baseB)

						m_Surface.Data.AddValue(top)
						m_Surface.Data.AddValue(baseB)
						m_Surface.Data.AddValue(baseC)

						m_Surface.Data.AddValue(top)
						m_Surface.Data.AddValue(baseC)
						m_Surface.Data.AddValue(baseD)

						m_Surface.Data.AddValue(top)
						m_Surface.Data.AddValue(baseD)
						m_Surface.Data.AddValue(baseA)
				Case VertexPrimitive.TriangleStrip
						descriptionText = "A series of connected triangles that share common vertices"

						m_Surface.FrameMode = SurfaceFrameMode.Mesh

						Dim A As NVector3DD = New NVector3DD(0, 0, 0)
						Dim B As NVector3DD = New NVector3DD(1, 0, 0)
						Dim C As NVector3DD = New NVector3DD(0, 1, 1)
						Dim D As NVector3DD = New NVector3DD(1, 1, 1)

						m_Surface.Data.AddValue(A)
						m_Surface.Data.AddValue(B)
						m_Surface.Data.AddValue(C)
						m_Surface.Data.AddValue(D)
				Case VertexPrimitive.TriangleFan
						descriptionText = "A series of connected triangles that share a common vertex"

						m_Surface.FrameMode = SurfaceFrameMode.Mesh

						m_Surface.Data.AddValue(0, 100, 0)

						Dim steps As Integer = 10

						For i As Integer = 0 To 2999
							Dim angle As Double = i * 2 * Math.PI / steps

							m_Surface.Data.AddValue(Math.Cos(angle) * 100, 0, Math.Sin(angle) * 100)
						Next i
				Case VertexPrimitive.Quads
						descriptionText = "Each for consecutive vertices form a quad"

						m_Surface.FrameMode = SurfaceFrameMode.Mesh

						Dim A As NVector3DD = New NVector3DD(0, 0, 0)
						Dim B As NVector3DD = New NVector3DD(1, 0, 0)
						Dim C As NVector3DD = New NVector3DD(0, 1, 1)
						Dim D As NVector3DD = New NVector3DD(1, 1, 1)


						m_Surface.Data.AddValue(A)
						m_Surface.Data.AddValue(B)
						m_Surface.Data.AddValue(D)
						m_Surface.Data.AddValue(C)
				Case VertexPrimitive.QuadStrip
						descriptionText = "A series of connected quads that share common vertices"

						m_Surface.FrameMode = SurfaceFrameMode.Mesh

						Dim A As NVector3DD = New NVector3DD(0, 0, 0)
						Dim B As NVector3DD = New NVector3DD(1, 0, 0)
						Dim C As NVector3DD = New NVector3DD(0, 1, 1)
						Dim D As NVector3DD = New NVector3DD(1, 1, 1)
'INSTANT VB NOTE: The local variable E was renamed since Visual Basic will not uniquely identify local variables when other local variables have the same name:
						Dim E_Renamed As NVector3DD = New NVector3DD(0, 2, 2)
						Dim F As NVector3DD = New NVector3DD(1, 2, 2)


						m_Surface.Data.AddValue(A)
						m_Surface.Data.AddValue(B)
						m_Surface.Data.AddValue(C)
						m_Surface.Data.AddValue(D)
						m_Surface.Data.AddValue(E_Renamed)
						m_Surface.Data.AddValue(F)

			End Select

			nChartControl1.Labels(0).Text = "Vertex Surface<br/><font size='10pt'>" & descriptionText & "</font>"

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace