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
	Partial Public Class NTriangulatedHeatMapUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Private m_HeatMap As NTriangulatedHeatMapSeries
		Private m_Points As NPointSeries
		Private WithEvents ContourDisplayModeCombo As UI.WinForm.Controls.NComboBox
		Private label4 As Label
		Private WithEvents ContourColorModeCombo As UI.WinForm.Controls.NComboBox
		Private label5 As Label
		Private WithEvents ShowFillCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents SmoothPaletteCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents InterpolateImageCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ContourStrokeStyleButton As UI.WinForm.Controls.NButton
		Private WithEvents ContourDotSizeNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label7 As Label
		Private WithEvents ShowPointsCheckBox As UI.WinForm.Controls.NCheckBox
		Private groupBox2 As GroupBox

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
			Me.ContourDisplayModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ContourColorModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.ShowFillCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SmoothPaletteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InterpolateImageCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ContourStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ContourDotSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.ShowPointsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.ContourDotSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' ContourDisplayModeCombo
			' 
			Me.ContourDisplayModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.ContourDisplayModeCombo.ListProperties.DataSource = Nothing
			Me.ContourDisplayModeCombo.ListProperties.DisplayMember = ""
			Me.ContourDisplayModeCombo.Location = New System.Drawing.Point(6, 32)
			Me.ContourDisplayModeCombo.Name = "ContourDisplayModeCombo"
			Me.ContourDisplayModeCombo.Size = New System.Drawing.Size(159, 21)
			Me.ContourDisplayModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContourDisplayModeCombo.SelectedIndexChanged += new System.EventHandler(this.ContourDisplayModeCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 16)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(159, 21)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Contour Display Mode:"
			' 
			' ContourColorModeCombo
			' 
			Me.ContourColorModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.ContourColorModeCombo.ListProperties.DataSource = Nothing
			Me.ContourColorModeCombo.ListProperties.DisplayMember = ""
			Me.ContourColorModeCombo.Location = New System.Drawing.Point(6, 70)
			Me.ContourColorModeCombo.Name = "ContourColorModeCombo"
			Me.ContourColorModeCombo.Size = New System.Drawing.Size(159, 21)
			Me.ContourColorModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContourColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.ContourColorModeCombo_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(6, 56)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(159, 21)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Contour Color Mode:"
			' 
			' ShowFillCheckBox
			' 
			Me.ShowFillCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowFillCheckBox.Location = New System.Drawing.Point(6, 200)
			Me.ShowFillCheckBox.Name = "ShowFillCheckBox"
			Me.ShowFillCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ShowFillCheckBox.TabIndex = 1
			Me.ShowFillCheckBox.Text = "Show Fill"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowFillCheckBox.CheckedChanged += new System.EventHandler(this.ShowFillCheckBox_CheckedChanged);
			' 
			' SmoothPaletteCheckBox
			' 
			Me.SmoothPaletteCheckBox.ButtonProperties.BorderOffset = 2
			Me.SmoothPaletteCheckBox.Location = New System.Drawing.Point(6, 224)
			Me.SmoothPaletteCheckBox.Name = "SmoothPaletteCheckBox"
			Me.SmoothPaletteCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.SmoothPaletteCheckBox.TabIndex = 2
			Me.SmoothPaletteCheckBox.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SmoothPaletteCheckBox.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheckBox_CheckedChanged);
			' 
			' InterpolateImageCheckBox
			' 
			Me.InterpolateImageCheckBox.ButtonProperties.BorderOffset = 2
			Me.InterpolateImageCheckBox.Location = New System.Drawing.Point(6, 248)
			Me.InterpolateImageCheckBox.Name = "InterpolateImageCheckBox"
			Me.InterpolateImageCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.InterpolateImageCheckBox.TabIndex = 3
			Me.InterpolateImageCheckBox.Text = "Interpolate Image"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InterpolateImageCheckBox.CheckedChanged += new System.EventHandler(this.InterpolateImageCheckBox_CheckedChanged);
			' 
			' ContourStrokeStyleButton
			' 
			Me.ContourStrokeStyleButton.Location = New System.Drawing.Point(6, 109)
			Me.ContourStrokeStyleButton.Name = "ContourStrokeStyleButton"
			Me.ContourStrokeStyleButton.Size = New System.Drawing.Size(159, 24)
			Me.ContourStrokeStyleButton.TabIndex = 4
			Me.ContourStrokeStyleButton.Text = "Contour Stroke Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContourStrokeStyleButton.Click += new System.EventHandler(this.ContourStrokeStyleButton_Click);
			' 
			' ContourDotSizeNumericUpDown
			' 
			Me.ContourDotSizeNumericUpDown.Location = New System.Drawing.Point(106, 139)
			Me.ContourDotSizeNumericUpDown.Name = "ContourDotSizeNumericUpDown"
			Me.ContourDotSizeNumericUpDown.Size = New System.Drawing.Size(59, 20)
			Me.ContourDotSizeNumericUpDown.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContourDotSizeNumericUpDown.ValueChanged += new System.EventHandler(this.ContourDotSizeNumericUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(6, 139)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(94, 20)
			Me.label7.TabIndex = 5
			Me.label7.Text = "Contour Dot Size:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.ContourDisplayModeCombo)
			Me.groupBox2.Controls.Add(Me.ContourColorModeCombo)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Controls.Add(Me.ContourStrokeStyleButton)
			Me.groupBox2.Controls.Add(Me.ContourDotSizeNumericUpDown)
			Me.groupBox2.Controls.Add(Me.label7)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.Location = New System.Drawing.Point(0, 0)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(179, 182)
			Me.groupBox2.TabIndex = 0
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Contour"
			' 
			' ShowPointsCheckBox
			' 
			Me.ShowPointsCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowPointsCheckBox.Location = New System.Drawing.Point(6, 272)
			Me.ShowPointsCheckBox.Name = "ShowPointsCheckBox"
			Me.ShowPointsCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ShowPointsCheckBox.TabIndex = 4
			Me.ShowPointsCheckBox.Text = "Show Points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowPointsCheckBox.CheckedChanged += new System.EventHandler(this.ShowPointsCheckBox_CheckedChanged);
			' 
			' NTriangulatedHeatMapUC
			' 
			Me.Controls.Add(Me.ShowPointsCheckBox)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.InterpolateImageCheckBox)
			Me.Controls.Add(Me.SmoothPaletteCheckBox)
			Me.Controls.Add(Me.ShowFillCheckBox)
			Me.Name = "NTriangulatedHeatMapUC"
			Me.Size = New System.Drawing.Size(179, 516)
			DirectCast(Me.ContourDotSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Triangulated Heat Map")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.RangeSelections.Add(New NRangeSelection())

			chart.BoundsMode = BoundsMode.Stretch

			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.RoundToTickMin = False
			scaleX.RoundToTickMax = False
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.RoundToTickMin = False
			scaleY.RoundToTickMax = False
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' create a point series (used to show the incoming points XY values)
			m_Points = New NPointSeries()
			chart.Series.Add(m_Points)
			m_Points.UseXValues = True
			m_Points.BorderStyle.Width = New NLength(0)
			m_Points.FillStyle = New NColorFillStyle(Color.Black)
			m_Points.Size = New NLength(2)
			m_Points.DataLabelStyle.Visible = False

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

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			' init form controls
			ContourDisplayModeCombo.FillFromEnum(GetType(ContourDisplayMode))
			ContourColorModeCombo.FillFromEnum(GetType(ContourColorMode))

			ContourDisplayModeCombo.SelectedIndex = CInt(ContourDisplayMode.Contour)
			ContourColorModeCombo.SelectedIndex = CInt(ContourColorMode.Uniform)
			ContourDotSizeNumericUpDown.Value = CDec(2)

			ShowFillCheckBox.Checked = True
			SmoothPaletteCheckBox.Checked = True
		End Sub
		''' <summary>
		''' Generates random data
		''' </summary>
		Private Sub GenerateData()
            Dim points() As NPointD = {New NPointD(0.1, 0.1), New NPointD(1.5, 1.0), New NPointD(2.5, 5), New NPointD(4, 0), New NPointD(2.5, 3.4), New NPointD(1.3, 5)}
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

		Private Sub UpdateChart()
			' contour
			m_HeatMap.ContourDisplayMode = CType(ContourDisplayModeCombo.SelectedIndex, ContourDisplayMode)
			m_HeatMap.ContourColorMode = CType(ContourColorModeCombo.SelectedIndex, ContourColorMode)
			m_HeatMap.ContourDotSize = New NSizeL(CSng(ContourDotSizeNumericUpDown.Value), CSng(ContourDotSizeNumericUpDown.Value))

			m_HeatMap.ShowFill = ShowFillCheckBox.Checked
			m_HeatMap.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked
			m_HeatMap.InterpolateImage = InterpolateImageCheckBox.Checked

			If m_HeatMap.Palette.SmoothPalette Then
				m_HeatMap.Legend.Format = "<zone_value>"
			Else
				m_HeatMap.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			m_Points.Values.Clear()
			m_Points.XValues.Clear()

			If ShowPointsCheckBox.Checked Then
				m_Points.Values.AddRange(m_HeatMap.YValues)
				m_Points.XValues.AddRange(m_HeatMap.XValues)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ContourDisplayModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ContourDisplayModeCombo.SelectedIndexChanged
			UpdateChart()
		End Sub

		Private Sub ContourColorModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ContourColorModeCombo.SelectedIndexChanged
			UpdateChart()
		End Sub

		Private Sub ShowFillCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowFillCheckBox.CheckedChanged
			UpdateChart()
		End Sub

		Private Sub SmoothPaletteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SmoothPaletteCheckBox.CheckedChanged
			UpdateChart()
		End Sub

		Private Sub InterpolateImageCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InterpolateImageCheckBox.CheckedChanged
			UpdateChart()
		End Sub

		Private Sub ContourDotSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ContourDotSizeNumericUpDown.ValueChanged
			UpdateChart()
		End Sub

		Private Sub ContourStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContourStrokeStyleButton.Click
			If m_HeatMap IsNot Nothing Then
				Dim strokeStyleResult As NStrokeStyle = Nothing

				If NStrokeStyleTypeEditor.Edit(m_HeatMap.ContourStrokeStyle, strokeStyleResult) Then
					m_HeatMap.ContourStrokeStyle = strokeStyleResult
					nChartControl1.Refresh()
				End If
			End If
		End Sub

		Private Sub ShowPointsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowPointsCheckBox.CheckedChanged
			UpdateChart()
		End Sub
	End Class
End Namespace
