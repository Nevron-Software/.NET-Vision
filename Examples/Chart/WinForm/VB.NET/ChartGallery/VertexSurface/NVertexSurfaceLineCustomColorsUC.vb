Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVertexSurfaceLineCustomColorsUC
		Inherits NExampleBaseUC
		Private WithEvents DataPointCountPerLineComboBox As UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private WithEvents NumberOfLinesUpDown As UI.WinForm.Controls.NNumericUpDown
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
			Me.DataPointCountPerLineComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.NumberOfLinesUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			CType(Me.NumberOfLinesUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' DataPointCountPerLineComboBox
			' 
			Me.DataPointCountPerLineComboBox.ListProperties.CheckBoxDataMember = ""
			Me.DataPointCountPerLineComboBox.ListProperties.DataSource = Nothing
			Me.DataPointCountPerLineComboBox.ListProperties.DisplayMember = ""
			Me.DataPointCountPerLineComboBox.Location = New System.Drawing.Point(8, 27)
			Me.DataPointCountPerLineComboBox.Name = "DataPointCountPerLineComboBox"
			Me.DataPointCountPerLineComboBox.Size = New System.Drawing.Size(159, 21)
			Me.DataPointCountPerLineComboBox.TabIndex = 11
'			Me.DataPointCountPerLineComboBox.SelectedIndexChanged += New System.EventHandler(Me.DataPointCountPerLineComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 11)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(159, 21)
			Me.label4.TabIndex = 10
			Me.label4.Text = "Data Points per Line:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 72)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(91, 21)
			Me.label1.TabIndex = 12
			Me.label1.Text = "Number of Lines:"
			' 
			' NumberOfLinesUpDown
			' 
			Me.NumberOfLinesUpDown.Location = New System.Drawing.Point(8, 91)
			Me.NumberOfLinesUpDown.Maximum = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.NumberOfLinesUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.NumberOfLinesUpDown.Name = "NumberOfLinesUpDown"
			Me.NumberOfLinesUpDown.Size = New System.Drawing.Size(159, 20)
			Me.NumberOfLinesUpDown.TabIndex = 13
			Me.NumberOfLinesUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'			Me.NumberOfLinesUpDown.ValueChanged += New System.EventHandler(Me.NumberOfLinesUpDown_ValueChanged);
			' 
			' NVertexSurfaceLineCustomColorsUC
			' 
			Me.Controls.Add(Me.NumberOfLinesUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.DataPointCountPerLineComboBox)
			Me.Controls.Add(Me.label4)
			Me.Name = "NVertexSurfaceLineCustomColorsUC"
			Me.Size = New System.Drawing.Size(180, 956)
			CType(Me.NumberOfLinesUpDown, System.ComponentModel.ISupportInitialize).EndInit()
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
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Vertex Surface Series<br/><font size='10pt'>Used to draw lines with very large amount of data and custom color per vertex</font>")
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

			DataPointCountPerLineComboBox.Items.Add("10K")
			DataPointCountPerLineComboBox.Items.Add("100K")
			DataPointCountPerLineComboBox.Items.Add("500K")

			DataPointCountPerLineComboBox.SelectedIndex = 1
			NumberOfLinesUpDown.Value = 7

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			UpdateData()
		End Sub

		Private Sub UpdateData()
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim dataPointCount As Integer = 0
			Select Case DataPointCountPerLineComboBox.SelectedIndex
				Case 0
					dataPointCount = 10000
				Case 1
					dataPointCount = 100000
				Case 2
					dataPointCount = 500000
			End Select

			Dim lineCount As Integer = CInt(Fix(NumberOfLinesUpDown.Value))
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series.Clear()
			Dim random As Random = New Random()

			Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Fresh)

			Dim lineIndex As Integer = 0
			Do While lineIndex < lineCount
				' setup surface series
				Dim surface As NVertexSurfaceSeries = New NVertexSurfaceSeries()
				chart.Series.Add(surface)

				surface.Name = "Surface"
				surface.SyncPaletteWithAxisScale = False
				surface.PaletteSteps = 8
				surface.ValueFormatter.FormatSpecifier = "0.00"
				surface.FillMode = SurfaceFillMode.CustomColors
				surface.FrameMode = SurfaceFrameMode.Dots
				surface.FrameColorMode = SurfaceFrameColorMode.CustomColors
				surface.VertexPrimitive = VertexPrimitive.LineStrip
				surface.Data.UseColors = True
				surface.Data.SetCapacity(dataPointCount)

				Dim x As Double = 0.1
				Dim y As Double = 0
				Dim z As Double = 0
				Dim a As Double = 10.0
				Dim b As Double = 18 + lineIndex ' 28.0 - ;
				Dim c As Double = (lineIndex + 3) / 3.0 '8.0
				Dim t As Double = lineIndex * (0.01 / lineCount) + 0.01


				Dim color1 As Color = palette.SeriesColors(lineIndex Mod palette.SeriesColors.Count)
				Dim color2 As Color = palette.SeriesColors((lineIndex + 1) Mod palette.SeriesColors.Count)

				Dim dataPointIndex As Integer = 0
				Do While dataPointIndex < dataPointCount
					Dim xt As Single = CSng(x + t * a * (y - x))
					Dim yt As Single = CSng(y + t * (x * (b - z) - y))
					Dim zt As Single = CSng(z + t * (x * y - c * z))

					surface.Data.AddValueColor(xt, yt, zt, InterpolateColor(color1, color2, CSng((yt + 40.0) / 80.0)))
					x = xt
					y = yt
					z = zt
					dataPointIndex += 1
				Loop


				' notify series that data has changed as we've modified it directly using pointers
				surface.Data.SetCount(dataPointCount)
				lineIndex += 1
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

		''' <summary>
		''' Returns a color between begin and end color. The coff parameter must be in the range [0, 1].
		''' </summary>
		''' <param name="begin"></param>
		''' <param name="end"></param>
		''' <param name="coeff"></param>
		''' <returns></returns>
		Public Shared Function InterpolateColor(ByVal color1 As Color, ByVal color2 As Color, ByVal factor As Single) As Color
			If factor > 1.0F Then
				factor = 1.0F
			End If

			Dim num1 As Integer = (CInt(color1.R))
			Dim num2 As Integer = (CInt(color1.G))
			Dim num3 As Integer = (CInt(color1.B))

			Dim num4 As Integer = (CInt(color2.R))
			Dim num5 As Integer = (CInt(color2.G))
			Dim num6 As Integer = (CInt(color2.B))

			Dim num7 As Byte = CByte(((CSng(num1)) + ((CSng(num4 - num1)) * factor)))
			Dim num8 As Byte = CByte(((CSng(num2)) + ((CSng(num5 - num2)) * factor)))
			Dim num9 As Byte = CByte(((CSng(num3)) + ((CSng(num6 - num3)) * factor)))

			Return Color.FromArgb(num7, num8, num9)
		End Function


		Private Sub DataPointCountPerLineComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataPointCountPerLineComboBox.SelectedIndexChanged
			UpdateData()
		End Sub

		Private Sub NumberOfLinesUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NumberOfLinesUpDown.ValueChanged
			UpdateData()
		End Sub
	End Class
End Namespace