Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NHighLowPaletteUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_HighLow As NHighLowSeries
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
			Me.Enable3DCheckBox.TabIndex = 10
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
			Me.SmoothPaletteCheckBox.TabIndex = 9
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
			Me.InvertAxisCheckBox.TabIndex = 8
			Me.InvertAxisCheckBox.Text = "Invert Axis"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertAxisCheckBox.CheckedChanged += new System.EventHandler(this.InvertAxisCheckBox_CheckedChanged);
			' 
			' NHighLowPaletteUC
			' 
			Me.Controls.Add(Me.Enable3DCheckBox)
			Me.Controls.Add(Me.SmoothPaletteCheckBox)
			Me.Controls.Add(Me.InvertAxisCheckBox)
			Me.Name = "NHighLowPaletteUC"
			Me.Size = New System.Drawing.Size(180, 270)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("High Low Palette")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add a High-Low series
			m_HighLow = CType(m_Chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			m_HighLow.Legend.Mode = SeriesLegendMode.None
			m_HighLow.DataLabelStyle.Visible = False

			GenerateData()

			Dim palette As New NPalette()
			palette.Clear()
			palette.Mode = PaletteMode.Custom
			palette.Add(0, Color.Green)
			palette.Add(1.5, Color.Yellow)
			palette.Add(3, Color.Red)

			m_HighLow.Palette = palette

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			SmoothPaletteCheckBox.Checked = True
			Enable3DCheckBox.Checked = True
		End Sub

		Private Sub GenerateData()
			m_HighLow.ClearDataPoints()

			For i As Integer = 0 To 19
				Dim d1 As Double = Math.Log(i + 1) + 0.1 * Random.NextDouble()
				Dim d2 As Double = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble()

				m_HighLow.HighValues.Add(d1)
				m_HighLow.LowValues.Add(d2)
			Next i
		End Sub

		Private Sub InvertAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InvertAxisCheckBox.CheckedChanged
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub SmoothPaletteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SmoothPaletteCheckBox.CheckedChanged
			m_HighLow.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub Enable3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Enable3DCheckBox.CheckedChanged
			m_Chart.Enable3D = Enable3DCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace