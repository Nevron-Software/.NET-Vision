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

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NFloatBarPaletteUC
		Inherits NExampleBaseUC

		Private m_FloatBar As NFloatBarSeries
		Private m_Chart As NChart

		Private WithEvents Enable3DCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents SmoothPaletteCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents InvertAxisCheckBox As UI.WinForm.Controls.NCheckBox
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
			Me.Enable3DCheckBox.TabIndex = 7
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
			Me.SmoothPaletteCheckBox.TabIndex = 6
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
			Me.InvertAxisCheckBox.TabIndex = 5
			Me.InvertAxisCheckBox.Text = "Invert Axis"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertAxisCheckBox.CheckedChanged += new System.EventHandler(this.InvertAxisCheckBox_CheckedChanged);
			' 
			' NFloatBarPaletteUC
			' 
			Me.Controls.Add(Me.Enable3DCheckBox)
			Me.Controls.Add(Me.SmoothPaletteCheckBox)
			Me.Controls.Add(Me.InvertAxisCheckBox)
			Me.Name = "NFloatBarPaletteUC"
			Me.Size = New System.Drawing.Size(180, 305)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Float Bar Palette")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			For i As Integer = 0 To monthLetters.Length - 1
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
			Next i

			' add interlaced stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' create the float bar series
			m_FloatBar = CType(m_Chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			m_FloatBar.DataLabelStyle.Visible = False
			m_FloatBar.DataLabelStyle.VertAlign = VertAlign.Center
			m_FloatBar.DataLabelStyle.Format = "<begin> - <end>"

			' add bars
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(2, 10))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(5, 16))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(9, 17))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(12, 21))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(8, 18))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(7, 18))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(3, 11))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(5, 12))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(8, 17))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(6, 15))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(3, 10))
			m_FloatBar.AddDataPoint(New NFloatBarDataPoint(1, 7))

			Dim palette As New NPalette()
			palette.Clear()
			palette.Mode = PaletteMode.Custom
			palette.Add(0, Color.Green)
			palette.Add(10, Color.Yellow)
			palette.Add(20, Color.Red)

			m_FloatBar.Palette = palette

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			SmoothPaletteCheckBox.Checked = True
			Enable3DCheckBox.Checked = True
		End Sub

		Private Sub Enable3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Enable3DCheckBox.CheckedChanged
			m_Chart.Enable3D = Enable3DCheckBox.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub SmoothPaletteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SmoothPaletteCheckBox.CheckedChanged
			m_FloatBar.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub InvertAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InvertAxisCheckBox.CheckedChanged
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisCheckBox.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
