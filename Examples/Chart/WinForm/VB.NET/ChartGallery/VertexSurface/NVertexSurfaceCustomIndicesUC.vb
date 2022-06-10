Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVertexSurfaceCustomIndicesUC
		Inherits NExampleBaseUC
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
			Me.SuspendLayout()
			' 
			' NVertexSurfaceCustomIndicesUC
			' 
			Me.Name = "NVertexSurfaceCustomIndicesUC"
			Me.Size = New System.Drawing.Size(180, 956)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.RenderSurface = RenderSurface.Window
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed
			nChartControl1.Settings.JitterMode = JitterMode.Disabled
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Vertex Surface Series<br/><font size='10pt'>Used to draw a pyramid that reuses vertex data to draw the side triangles.</font>")
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

			' turn off lighting to improve performance
			chart.LightModel.EnableLighting = False

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
			Dim surface As NVertexSurfaceSeries = New NVertexSurfaceSeries()
			chart.Series.Add(surface)

			surface.Name = "Surface"
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FillMode = SurfaceFillMode.CustomColors
			surface.UseIndices = True
			surface.FrameMode = SurfaceFrameMode.None
			surface.VertexPrimitive = VertexPrimitive.Triangles
			surface.Data.UseColors = True

			' top
			surface.Data.AddValueColor(New NVector3DD(0.5, 1, 0.5), Color.Red)
			surface.Data.AddValueColor(New NVector3DD(0, 0, 0), Color.Green)
			surface.Data.AddValueColor(New NVector3DD(1, 0, 0), Color.Green)
			surface.Data.AddValueColor(New NVector3DD(1, 0, 1), Color.Blue)
			surface.Data.AddValueColor(New NVector3DD(0, 0, 1), Color.Blue)

			' first triangle
			surface.Indices.Add(0)
			surface.Indices.Add(1)
			surface.Indices.Add(2)

			' second triangle
			surface.Indices.Add(0)
			surface.Indices.Add(2)
			surface.Indices.Add(3)

			' third triangle
			surface.Indices.Add(0)
			surface.Indices.Add(3)
			surface.Indices.Add(4)

			' fourth triangle
			surface.Indices.Add(0)
			surface.Indices.Add(4)
			surface.Indices.Add(1)



			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)
		End Sub
	End Class
End Namespace