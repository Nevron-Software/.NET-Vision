Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVertexSurfaceFillCustomColorsUC
		Inherits NExampleBaseUC
		Private WithEvents CubeSideSizeComboBox As UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
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
			Me.CubeSideSizeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' CubeSideSizeComboBox
			' 
			Me.CubeSideSizeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.CubeSideSizeComboBox.ListProperties.DataSource = Nothing
			Me.CubeSideSizeComboBox.ListProperties.DisplayMember = ""
			Me.CubeSideSizeComboBox.Location = New System.Drawing.Point(3, 28)
			Me.CubeSideSizeComboBox.Name = "CubeSideSizeComboBox"
			Me.CubeSideSizeComboBox.Size = New System.Drawing.Size(159, 21)
			Me.CubeSideSizeComboBox.TabIndex = 13
'			Me.CubeSideSizeComboBox.SelectedIndexChanged += New System.EventHandler(Me.CubeSideSizeComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(3, 12)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(159, 21)
			Me.label4.TabIndex = 12
			Me.label4.Text = "Cube Size:"
			' 
			' NVertexSurfaceFillCustomColorsUC
			' 
			Me.Controls.Add(Me.CubeSideSizeComboBox)
			Me.Controls.Add(Me.label4)
			Me.Name = "NVertexSurfaceFillCustomColorsUC"
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
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Vertex Surface Series<br/><font size='10pt'>Used to draw objects with with custom color per vertex</font>")
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
			scaleY.RoundToTickMax = False
			scaleY.RoundToTickMin = False

			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			scaleX.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			scaleX.RoundToTickMax = False
			scaleX.RoundToTickMin = False
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleZ.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			scaleZ.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleZ.RoundToTickMax = False
			scaleZ.RoundToTickMin = False
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			For i As Integer = 1 To 9
				CubeSideSizeComboBox.Items.Add(i.ToString() & "x" & i.ToString())
			Next i

			CubeSideSizeComboBox.SelectedIndex = 4

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			UpdateData()
		End Sub

		Private Sub UpdateData()
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series.Clear()
			Dim random As Random = New Random()

			' setup surface series
			Dim surface As NVertexSurfaceSeries = New NVertexSurfaceSeries()
			chart.Series.Add(surface)

			surface.Name = "Surface"
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FillMode = SurfaceFillMode.CustomColors
			surface.FrameMode = SurfaceFrameMode.None
			surface.VertexPrimitive = VertexPrimitive.Triangles
			surface.Data.UseColors = True
			surface.UseIndices = True


			Dim cubeSide As Integer = (CubeSideSizeComboBox.SelectedIndex + 1)

			Dim dataPointCount As Integer = 8 * CInt(Fix(Math.Pow(cubeSide, 3)))
			Dim rand As Random = New Random()

			surface.Data.SetCapacity(dataPointCount)

			Dim currentIndex As UInteger = 0

				' left
				' right
				' front
				' back
				' top
			Dim cubeIndices As UInteger() = New UInteger() { 0, 1, 3, 0, 3, 2, 2, 0, 4, 2, 4, 6, 1, 3, 5, 3, 7, 5, 0, 1, 4, 1, 5, 4, 2, 6, 3, 3,6, 7, 4, 5, 6, 5, 7, 6 }

			' generate all vertexes and colors
			Dim x As Integer = 0
			Do While x < cubeSide
				Dim x1 As Double = x + 0.1
				Dim x2 As Double = x + 1 - 0.1

				Dim r1 As Integer = CByte(x1 * 255.0 / cubeSide)
				Dim r2 As Integer = CByte(x1 * 255.0 / cubeSide)

				Dim y As Integer = 0
				Do While y < cubeSide
					Dim y1 As Double = y + 0.1
					Dim y2 As Double = y + 1 - 0.1

					Dim g1 As Integer = CByte(y1 * 255.0 / cubeSide)
					Dim g2 As Integer = CByte(y1 * 255.0 / cubeSide)

					Dim z As Integer = 0
					Do While z < cubeSide
						Dim z1 As Double = z + 0.1
						Dim z2 As Double = z + 1 - 0.1

						Dim b1 As Integer = CByte(z1 * 255.0 / cubeSide)
						Dim b2 As Integer = CByte(z1 * 255.0 / cubeSide)

						surface.Data.AddValueColor(New NVector3DD(x1, y1, z1), Color.FromArgb(r1, g1, b1))
						surface.Data.AddValueColor(New NVector3DD(x2, y1, z1), Color.FromArgb(r2, g1, b1))
						surface.Data.AddValueColor(New NVector3DD(x1, y2, z1), Color.FromArgb(r1, g2, b1))
						surface.Data.AddValueColor(New NVector3DD(x2, y2, z1), Color.FromArgb(r2, g2, b1))
						surface.Data.AddValueColor(New NVector3DD(x1, y1, z2), Color.FromArgb(r1, g1, b2))
						surface.Data.AddValueColor(New NVector3DD(x2, y1, z2), Color.FromArgb(r2, g1, b2))
						surface.Data.AddValueColor(New NVector3DD(x1, y2, z2), Color.FromArgb(r1, g2, b2))
						surface.Data.AddValueColor(New NVector3DD(x2, y2, z2), Color.FromArgb(r2, g2, b2))

						' add indicess
						Dim i As Integer = 0
						Do While i < cubeIndices.Length
							surface.Indices.Add(currentIndex + cubeIndices(i))
							i += 1
						Loop

						currentIndex += 8
						z += 1
					Loop
					y += 1
				Loop
				x += 1
			Loop

			nChartControl1.Refresh()
		End Sub
		''' <summary>
		''' Generates a random color
		''' </summary>
		''' <param name="random"></param>
		''' <returns></returns>
		Public Shared Function GetRandomColor(ByVal random As Random) As Color
			Return Color.FromArgb(random.Next(255), random.Next(255), random.Next(255))
		End Function

		Private Sub CubeSideSizeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CubeSideSizeComboBox.SelectedIndexChanged
			UpdateData()
		End Sub
	End Class
End Namespace