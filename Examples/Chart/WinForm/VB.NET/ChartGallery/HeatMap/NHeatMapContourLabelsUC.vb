Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Partial Public Class NHeatMapContourLabelsUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Private m_HeatMap As NHeatMapSeries
		Private label9 As Label
		Private WithEvents LabelDistanceUpDown As UI.WinForm.Controls.NNumericUpDown
		Private WithEvents AllowLabelsToFlipCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowLabelBackgroundCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ClipContourCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowContourLabelsCheckBox As UI.WinForm.Controls.NCheckBox

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
			Me.ShowContourLabelsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.LabelDistanceUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.AllowLabelsToFlipCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowLabelBackgroundCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ClipContourCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.LabelDistanceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ShowContourLabelsCheckBox
			' 
			Me.ShowContourLabelsCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowContourLabelsCheckBox.Location = New System.Drawing.Point(3, -1)
			Me.ShowContourLabelsCheckBox.Name = "ShowContourLabelsCheckBox"
			Me.ShowContourLabelsCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ShowContourLabelsCheckBox.TabIndex = 0
			Me.ShowContourLabelsCheckBox.Text = "Show Contour Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowContourLabelsCheckBox.CheckedChanged += new System.EventHandler(this.ShowContourLabelsCheckBox_CheckedChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(3, 128)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(96, 20)
			Me.label9.TabIndex = 5
			Me.label9.Text = "Label Distance:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LabelDistanceUpDown
			' 
			Me.LabelDistanceUpDown.Location = New System.Drawing.Point(104, 128)
			Me.LabelDistanceUpDown.Name = "LabelDistanceUpDown"
			Me.LabelDistanceUpDown.Size = New System.Drawing.Size(62, 20)
			Me.LabelDistanceUpDown.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelDistanceUpDown.ValueChanged += new System.EventHandler(this.LabelDistanceUpDown_ValueChanged);
			' 
			' AllowLabelsToFlipCheckBox
			' 
			Me.AllowLabelsToFlipCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowLabelsToFlipCheckBox.Location = New System.Drawing.Point(3, 32)
			Me.AllowLabelsToFlipCheckBox.Name = "AllowLabelsToFlipCheckBox"
			Me.AllowLabelsToFlipCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.AllowLabelsToFlipCheckBox.TabIndex = 1
			Me.AllowLabelsToFlipCheckBox.Text = "Allow Labels To Flip"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowLabelsToFlipCheckBox.CheckedChanged += new System.EventHandler(this.AllowLabelsToFlipCheckBox_CheckedChanged);
			' 
			' ShowLabelBackgroundCheckBox
			' 
			Me.ShowLabelBackgroundCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowLabelBackgroundCheckBox.Location = New System.Drawing.Point(3, 65)
			Me.ShowLabelBackgroundCheckBox.Name = "ShowLabelBackgroundCheckBox"
			Me.ShowLabelBackgroundCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ShowLabelBackgroundCheckBox.TabIndex = 2
			Me.ShowLabelBackgroundCheckBox.Text = "Show Label Background"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLabelBackgroundCheckBox.CheckedChanged += new System.EventHandler(this.ShowLabelBackgroundCheckBox_CheckedChanged);
			' 
			' ClipContourCheckBox
			' 
			Me.ClipContourCheckBox.ButtonProperties.BorderOffset = 2
			Me.ClipContourCheckBox.Location = New System.Drawing.Point(3, 98)
			Me.ClipContourCheckBox.Name = "ClipContourCheckBox"
			Me.ClipContourCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ClipContourCheckBox.TabIndex = 3
			Me.ClipContourCheckBox.Text = "Clip Contour"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClipContourCheckBox.CheckedChanged += new System.EventHandler(this.ClipContourCheckBox_CheckedChanged);
			' 
			' NHeatMapContourLabelsUC
			' 
			Me.Controls.Add(Me.ClipContourCheckBox)
			Me.Controls.Add(Me.ShowLabelBackgroundCheckBox)
			Me.Controls.Add(Me.AllowLabelsToFlipCheckBox)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.LabelDistanceUpDown)
			Me.Controls.Add(Me.ShowContourLabelsCheckBox)
			Me.Name = "NHeatMapContourLabelsUC"
			Me.Size = New System.Drawing.Size(179, 516)
			DirectCast(Me.LabelDistanceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Heat Map Contour")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.BoundsMode = BoundsMode.Stretch
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			' create the heat map 
			m_HeatMap = New NHeatMapSeries()
			chart.Series.Add(m_HeatMap)

			m_HeatMap.Palette.Add(0.0, Color.Purple)
			m_HeatMap.Palette.Add(1.5, Color.MediumSlateBlue)
			m_HeatMap.Palette.Add(3.0, Color.CornflowerBlue)
			m_HeatMap.Palette.Add(4.5, Color.LimeGreen)
			m_HeatMap.Palette.Add(6.0, Color.LightGreen)
			m_HeatMap.Palette.Add(7.5, Color.Yellow)
			m_HeatMap.Palette.Add(9.0, Color.Orange)
			m_HeatMap.Palette.Add(10.5, Color.Red)
			m_HeatMap.Palette.SmoothPalette = True
			m_HeatMap.XValuesMode = HeatMapValuesMode.OriginAndStep
			m_HeatMap.YValuesMode = HeatMapValuesMode.OriginAndStep

			m_HeatMap.ContourDisplayMode = ContourDisplayMode.Contour
			m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic
			m_HeatMap.Legend.Format = "<zone_value>"

			GenerateData()

			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			ShowContourLabelsCheckBox.Checked = True
			AllowLabelsToFlipCheckBox.Checked = m_HeatMap.ContourLabelStyle.AllowLabelToFlip
			LabelDistanceUpDown.Value = CDec(m_HeatMap.ContourLabelStyle.LabelDistance.Value)
			ShowLabelBackgroundCheckBox.Checked = m_HeatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible
			ClipContourCheckBox.Checked = m_HeatMap.ContourLabelStyle.ClipContour
		End Sub

		Private Sub GenerateData()
			Dim data As NHeatMapData = m_HeatMap.Data

			Dim GridStepX As Integer = 100
			Dim GridStepY As Integer = 100
			data.SetGridSize(GridStepX, GridStepY)

			Const dIntervalX As Double = 10.0
			Const dIntervalZ As Double = 10.0
			Dim dIncrementX As Double = (dIntervalX / GridStepX)
			Dim dIncrementZ As Double = (dIntervalZ / GridStepY)

			Dim y, x, z As Double

			z = -(dIntervalZ / 2)

			Dim centerX As Integer = CInt(Math.Truncate(GridStepX / 2.0))
			Dim centerY As Integer = CInt(Math.Truncate(GridStepY / 2.0))

			Dim col As Integer = 0
			Do While col < GridStepX
				x = -(dIntervalX / 2)

				Dim row As Integer = 0
				Do While row < GridStepY
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2)
					y += 3.0 * Math.Sin(x) * Math.Cos(z)

					data.SetValue(row, col, y)
					row += 1
					x += dIncrementX
				Loop
				col += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub ShowContourLabelsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowContourLabelsCheckBox.CheckedChanged
			m_HeatMap.ContourLabelStyle.Visible = ShowContourLabelsCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub LabelDistanceUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelDistanceUpDown.ValueChanged
			m_HeatMap.ContourLabelStyle.LabelDistance = New NLength(CSng(LabelDistanceUpDown.Value), NGraphicsUnit.Point)
			nChartControl1.Refresh()
		End Sub
		Private Sub AllowLabelsToFlipCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowLabelsToFlipCheckBox.CheckedChanged
			m_HeatMap.ContourLabelStyle.AllowLabelToFlip = AllowLabelsToFlipCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowLabelBackgroundCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowLabelBackgroundCheckBox.CheckedChanged
			m_HeatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible = ShowLabelBackgroundCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ClipContourCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ClipContourCheckBox.CheckedChanged
			m_HeatMap.ContourLabelStyle.ClipContour = ClipContourCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
