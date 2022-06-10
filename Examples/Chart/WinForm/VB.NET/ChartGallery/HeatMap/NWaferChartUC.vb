Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Partial Public Class NWaferChartUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Private m_HeatMap As NHeatMapSeries
		Private WithEvents InterpolateImageCheckBox As UI.WinForm.Controls.NCheckBox

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

		Private Sub InitializeComponent()
			Me.InterpolateImageCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' InterpolateImageCheckBox
			' 
			Me.InterpolateImageCheckBox.ButtonProperties.BorderOffset = 2
			Me.InterpolateImageCheckBox.Location = New System.Drawing.Point(12, 13)
			Me.InterpolateImageCheckBox.Name = "InterpolateImageCheckBox"
			Me.InterpolateImageCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.InterpolateImageCheckBox.TabIndex = 15
			Me.InterpolateImageCheckBox.Text = "Interpolate Image"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InterpolateImageCheckBox.CheckedChanged += new System.EventHandler(this.InterpolateImageCheckBox_CheckedChanged);
			' 
			' NWaferChartUC
			' 
			Me.Controls.Add(Me.InterpolateImageCheckBox)
			Me.Name = "NWaferChartUC"
			Me.Size = New System.Drawing.Size(186, 321)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Wafer Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' configure chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)

			m_HeatMap = New NHeatMapSeries()
			chart.Series.Add(m_HeatMap)

			Dim data As NHeatMapData = m_HeatMap.Data

			m_HeatMap.Palette.Mode = PaletteMode.AutoFixedEntryCount
			m_HeatMap.Palette.AutoPaletteColors = New NArgbColorValue() {
				New NArgbColorValue(Color.Green),
				New NArgbColorValue(Color.Red)
			}
			m_HeatMap.Palette.SmoothPalette = True

			Dim gridSizeX As Integer = 100
			Dim gridSizeY As Integer = 100
			data.SetGridSize(gridSizeX, gridSizeY)

			Dim centerX As Integer = gridSizeX \ 2
			Dim centerY As Integer = gridSizeY \ 2

			Dim radius As Integer = gridSizeX \ 2
			Dim rand As New Random()

			For y As Integer = 0 To gridSizeY - 1
				For x As Integer = 0 To gridSizeX - 1
					Dim dx As Integer = x - centerX
					Dim dy As Integer = y - centerY

					Dim pointDistance As Double = Math.Sqrt(dx * dx + dy * dy)

					If pointDistance < radius Then
						' assign value
						data.SetValue(x, y, pointDistance + rand.Next(20))
					Else
						data.SetValue(x, y, Double.NaN)
					End If
				Next x
			Next y
		End Sub

		Private Sub InterpolateImageCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InterpolateImageCheckBox.CheckedChanged
			m_HeatMap.InterpolateImage = InterpolateImageCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
