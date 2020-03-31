Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NSmoothAreaPaletteUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_SmoothArea As NSmoothAreaSeries

		Private Const nValuesCount As Integer = 6
		Private WithEvents Enable3DCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents SmoothPaletteCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents InvertAxisCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.IContainer = Nothing

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


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.Enable3DCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SmoothPaletteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InvertAxisCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' Enable3DCheckBox
			' 
			Me.Enable3DCheckBox.ButtonProperties.BorderOffset = 2
			Me.Enable3DCheckBox.ButtonProperties.ShowFocusRect = False
			Me.Enable3DCheckBox.ButtonProperties.WrapText = True
			Me.Enable3DCheckBox.Location = New System.Drawing.Point(9, 56)
			Me.Enable3DCheckBox.Name = "Enable3DCheckBox"
			Me.Enable3DCheckBox.Size = New System.Drawing.Size(139, 18)
			Me.Enable3DCheckBox.TabIndex = 13
			Me.Enable3DCheckBox.Text = "Enable 3D"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
			' 
			' SmoothPaletteCheckBox
			' 
			Me.SmoothPaletteCheckBox.ButtonProperties.BorderOffset = 2
			Me.SmoothPaletteCheckBox.ButtonProperties.ShowFocusRect = False
			Me.SmoothPaletteCheckBox.ButtonProperties.WrapText = True
			Me.SmoothPaletteCheckBox.Location = New System.Drawing.Point(9, 34)
			Me.SmoothPaletteCheckBox.Name = "SmoothPaletteCheckBox"
			Me.SmoothPaletteCheckBox.Size = New System.Drawing.Size(139, 18)
			Me.SmoothPaletteCheckBox.TabIndex = 12
			Me.SmoothPaletteCheckBox.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SmoothPaletteCheckBox.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheckBox_CheckedChanged);
			' 
			' InvertAxisCheckBox
			' 
			Me.InvertAxisCheckBox.ButtonProperties.BorderOffset = 2
			Me.InvertAxisCheckBox.ButtonProperties.ShowFocusRect = False
			Me.InvertAxisCheckBox.ButtonProperties.WrapText = True
			Me.InvertAxisCheckBox.Location = New System.Drawing.Point(9, 12)
			Me.InvertAxisCheckBox.Name = "InvertAxisCheckBox"
			Me.InvertAxisCheckBox.Size = New System.Drawing.Size(139, 18)
			Me.InvertAxisCheckBox.TabIndex = 11
			Me.InvertAxisCheckBox.Text = "Invert Axis"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertAxisCheckBox.CheckedChanged += new System.EventHandler(this.InvertAxisCheckBox_CheckedChanged);
			' 
			' NSmoothAreaPaletteUC
			' 
			Me.Controls.Add(Me.Enable3DCheckBox)
			Me.Controls.Add(Me.SmoothPaletteCheckBox)
			Me.Controls.Add(Me.InvertAxisCheckBox)
			Me.Name = "NSmoothAreaPaletteUC"
			Me.Size = New System.Drawing.Size(180, 320)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Smooth Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legends
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Width = 65
			m_Chart.Height = 40
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' setup axes
			Dim linearScaleX As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleX

			Dim linearScaleY As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleY.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlaced stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleY.StripStyles.Add(stripStyle)

			' add the area series
			m_SmoothArea = New NSmoothAreaSeries()
			m_Chart.Series.Add(m_SmoothArea)

			m_SmoothArea.DataLabelStyle.Visible = False
			m_SmoothArea.MarkerStyle.Visible = False
			m_SmoothArea.UseXValues = True

			Dim palette As New NPalette()
			palette.Clear()
			palette.Mode = PaletteMode.Custom
			palette.Add(0, Color.Green)
			palette.Add(5, Color.Yellow)
			palette.Add(10, Color.Red)

			m_SmoothArea.Palette = palette

			GenerateYValues(nValuesCount)
			GenerateXValues(nValuesCount)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
			SmoothPaletteCheckBox.Checked = True
			Enable3DCheckBox.Checked = True
		End Sub

		Private Sub GenerateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.Values.Clear()

			For i As Integer = 0 To nCount - 1
				series.Values.Add(5 + Random.NextDouble() * 10)
			Next i
		End Sub
		Private Sub GenerateXValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NXYScatterSeries = CType(chart.Series(0), NXYScatterSeries)

			series.XValues.Clear()

			Dim x As Double = 120

			For i As Integer = 0 To nCount - 1
				x += 10 + Random.NextDouble() * 10

				series.XValues.Add(x)
			Next i
		End Sub

		Private Sub InvertAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InvertAxisCheckBox.CheckedChanged
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub SmoothPaletteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SmoothPaletteCheckBox.CheckedChanged
			m_SmoothArea.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub Enable3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Enable3DCheckBox.CheckedChanged
			m_Chart.Enable3D = Enable3DCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

