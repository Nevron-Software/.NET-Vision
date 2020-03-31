Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Partial Public Class NTriangulatedHeatMapContourUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents ClipContourCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowLabelBackgroundCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents AllowLabelsToFlipCheckBox As UI.WinForm.Controls.NCheckBox
		Private label9 As Label
		Private WithEvents LabelDistanceUpDown As UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ShowContourLabelsCheckBox As UI.WinForm.Controls.NCheckBox
		Private m_HeatMap As NTriangulatedHeatMapSeries

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
			Me.ClipContourCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowLabelBackgroundCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AllowLabelsToFlipCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.LabelDistanceUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ShowContourLabelsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.LabelDistanceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ClipContourCheckBox
			' 
			Me.ClipContourCheckBox.ButtonProperties.BorderOffset = 2
			Me.ClipContourCheckBox.Location = New System.Drawing.Point(13, 114)
			Me.ClipContourCheckBox.Name = "ClipContourCheckBox"
			Me.ClipContourCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ClipContourCheckBox.TabIndex = 10
			Me.ClipContourCheckBox.Text = "Clip Contour"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClipContourCheckBox.CheckedChanged += new System.EventHandler(this.ClipContourCheckBox_CheckedChanged);
			' 
			' ShowLabelBackgroundCheckBox
			' 
			Me.ShowLabelBackgroundCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowLabelBackgroundCheckBox.Location = New System.Drawing.Point(13, 81)
			Me.ShowLabelBackgroundCheckBox.Name = "ShowLabelBackgroundCheckBox"
			Me.ShowLabelBackgroundCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ShowLabelBackgroundCheckBox.TabIndex = 9
			Me.ShowLabelBackgroundCheckBox.Text = "Show Label Background"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLabelBackgroundCheckBox.CheckedChanged += new System.EventHandler(this.ShowLabelBackgroundCheckBox_CheckedChanged);
			' 
			' AllowLabelsToFlipCheckBox
			' 
			Me.AllowLabelsToFlipCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowLabelsToFlipCheckBox.Location = New System.Drawing.Point(13, 48)
			Me.AllowLabelsToFlipCheckBox.Name = "AllowLabelsToFlipCheckBox"
			Me.AllowLabelsToFlipCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.AllowLabelsToFlipCheckBox.TabIndex = 8
			Me.AllowLabelsToFlipCheckBox.Text = "Allow Labels To Flip"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowLabelsToFlipCheckBox.CheckedChanged += new System.EventHandler(this.AllowLabelsToFlipCheckBox_CheckedChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(13, 144)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(96, 20)
			Me.label9.TabIndex = 11
			Me.label9.Text = "Label Distance:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LabelDistanceUpDown
			' 
			Me.LabelDistanceUpDown.Location = New System.Drawing.Point(114, 144)
			Me.LabelDistanceUpDown.Name = "LabelDistanceUpDown"
			Me.LabelDistanceUpDown.Size = New System.Drawing.Size(62, 20)
			Me.LabelDistanceUpDown.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelDistanceUpDown.ValueChanged += new System.EventHandler(this.LabelDistanceUpDown_ValueChanged);
			' 
			' ShowContourLabelsCheckBox
			' 
			Me.ShowContourLabelsCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowContourLabelsCheckBox.Location = New System.Drawing.Point(13, 15)
			Me.ShowContourLabelsCheckBox.Name = "ShowContourLabelsCheckBox"
			Me.ShowContourLabelsCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ShowContourLabelsCheckBox.TabIndex = 7
			Me.ShowContourLabelsCheckBox.Text = "Show Contour Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowContourLabelsCheckBox.CheckedChanged += new System.EventHandler(this.ShowContourLabelsCheckBox_CheckedChanged);
			' 
			' NTriangulatedHeatMapContourUC
			' 
			Me.Controls.Add(Me.ClipContourCheckBox)
			Me.Controls.Add(Me.ShowLabelBackgroundCheckBox)
			Me.Controls.Add(Me.AllowLabelsToFlipCheckBox)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.LabelDistanceUpDown)
			Me.Controls.Add(Me.ShowContourLabelsCheckBox)
			Me.Name = "NTriangulatedHeatMapContourUC"
			Me.Size = New System.Drawing.Size(179, 516)
			DirectCast(Me.LabelDistanceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Triangulated Heat Map Contour Labels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.BoundsMode = BoundsMode.Stretch
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			' create the heat map 
			' create the heat map 
			m_HeatMap = New NTriangulatedHeatMapSeries()
			chart.Series.Add(m_HeatMap)

			m_HeatMap.Palette.Add(0.0, Color.Purple)
			m_HeatMap.Palette.Add(1.5, Color.MediumSlateBlue)
			m_HeatMap.Palette.Add(3.0, Color.CornflowerBlue)
			m_HeatMap.Palette.Add(4.5, Color.LimeGreen)
			m_HeatMap.Palette.Add(6.0, Color.LightGreen)
			m_HeatMap.Palette.Add(7.5, Color.Yellow)
			m_HeatMap.Palette.Add(9.0, Color.Orange)
			m_HeatMap.Palette.Add(10.5, Color.Red)

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
            Dim points() As NPointD = {New NPointD(3.1, 0.1), New NPointD(1.5, 2.0), New NPointD(1.5, 0.5), New NPointD(2, 0), New NPointD(1.5, 3.4), New NPointD(1.3, 3)}
			Dim pointsIntensity() As Double = { 30, 10, 30, 20, 40, 20 }

			Dim rand As New Random()

			For x As Double = 0.0 To 5 Step 0.5
				For y As Double = 0.0 To 5 Step 0.5
					Dim pointX As Double
					Dim pointY As Double

					If x = 0 OrElse y = 0 OrElse x = 5 OrElse y = 5 Then
						pointX = x
						pointY = y
					Else
						pointX = x + rand.NextDouble() * 0.2
						pointY = y + rand.NextDouble() * 0.2
					End If

					Dim intensity As Double = 0
					For i As Integer = 0 To points.Length - 1
						Dim dx As Double = points(i).X - pointX
						Dim dy As Double = points(i).Y - pointY

						Dim distance As Double = Math.Sqrt(dx * dx + dy * dy)
						intensity += pointsIntensity(i) / (1 + distance * distance)
					Next i

					m_HeatMap.Values.Add(intensity)
					m_HeatMap.XValues.Add(pointX)
					m_HeatMap.YValues.Add(pointY)
				Next y
			Next x
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
