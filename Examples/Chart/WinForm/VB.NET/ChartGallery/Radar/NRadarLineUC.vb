Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NRadarLineUC
		Inherits NExampleBaseUC

		Private m_Radar1 As NRadarSeries
		Private m_Radar2 As NRadarSeries
		Private m_Chart As NRadarChart
		Private WithEvents RadarLineButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RadarLine2Button As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton2 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As Label
		Private label1 As Label
		Private WithEvents TitleAngleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private WithEvents TitleAngleModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.RadarLineButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RadarLine2Button = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.BeginAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.TitleAngleNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.TitleAngleModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TitleAngleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' RadarLineButton
			' 
			Me.RadarLineButton.Location = New System.Drawing.Point(9, 59)
			Me.RadarLineButton.Name = "RadarLineButton"
			Me.RadarLineButton.Size = New System.Drawing.Size(157, 24)
			Me.RadarLineButton.TabIndex = 2
			Me.RadarLineButton.Text = "Radar Line 1..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RadarLineButton.Click += new System.EventHandler(this.RadarLineButton_Click);
			' 
			' RadarLine2Button
			' 
			Me.RadarLine2Button.Location = New System.Drawing.Point(9, 90)
			Me.RadarLine2Button.Name = "RadarLine2Button"
			Me.RadarLine2Button.Size = New System.Drawing.Size(157, 24)
			Me.RadarLine2Button.TabIndex = 3
			Me.RadarLine2Button.Text = "Radar Line 2..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RadarLine2Button.Click += new System.EventHandler(this.RadarLine2Button_Click);
			' 
			' MarkerStyleButton2
			' 
			Me.MarkerStyleButton2.Location = New System.Drawing.Point(9, 152)
			Me.MarkerStyleButton2.Name = "MarkerStyleButton2"
			Me.MarkerStyleButton2.Size = New System.Drawing.Size(157, 24)
			Me.MarkerStyleButton2.TabIndex = 5
			Me.MarkerStyleButton2.Text = "Radar 2 Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton2.Click += new System.EventHandler(this.MarkerStyleButton2_Click);
			' 
			' MarkerStyleButton1
			' 
			Me.MarkerStyleButton1.Location = New System.Drawing.Point(9, 121)
			Me.MarkerStyleButton1.Name = "MarkerStyleButton1"
			Me.MarkerStyleButton1.Size = New System.Drawing.Size(157, 24)
			Me.MarkerStyleButton1.TabIndex = 4
			Me.MarkerStyleButton1.Text = "Radar 1 Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton1.Click += new System.EventHandler(this.MarkerStyleButton1_Click);
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(9, 29)
			Me.BeginAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.BeginAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.BeginAngleUpDown.Name = "BeginAngleUpDown"
			Me.BeginAngleUpDown.Size = New System.Drawing.Size(157, 20)
			Me.BeginAngleUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 9)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(162, 17)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Begin Angle:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 230)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(157, 17)
			Me.label1.TabIndex = 8
			Me.label1.Text = "Title Angle:"
			' 
			' TitleAngleNumericUpDown
			' 
			Me.TitleAngleNumericUpDown.Location = New System.Drawing.Point(12, 249)
			Me.TitleAngleNumericUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.TitleAngleNumericUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.TitleAngleNumericUpDown.Name = "TitleAngleNumericUpDown"
			Me.TitleAngleNumericUpDown.Size = New System.Drawing.Size(157, 20)
			Me.TitleAngleNumericUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAngleNumericUpDown.ValueChanged += new System.EventHandler(this.TitleAngleNumericUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 189)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(90, 13)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Title Angle Mode:"
			' 
			' TitleAngleModeComboBox
			' 
			Me.TitleAngleModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.TitleAngleModeComboBox.ListProperties.DataSource = Nothing
			Me.TitleAngleModeComboBox.ListProperties.DisplayMember = ""
			Me.TitleAngleModeComboBox.Location = New System.Drawing.Point(12, 206)
			Me.TitleAngleModeComboBox.Name = "TitleAngleModeComboBox"
			Me.TitleAngleModeComboBox.Size = New System.Drawing.Size(157, 21)
			Me.TitleAngleModeComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleAngleModeComboBox_SelectedIndexChanged);
			' 
			' NRadarLineUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.TitleAngleNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.TitleAngleModeComboBox)
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.MarkerStyleButton2)
			Me.Controls.Add(Me.MarkerStyleButton1)
			Me.Controls.Add(Me.RadarLine2Button)
			Me.Controls.Add(Me.RadarLineButton)
			Me.Name = "NRadarLineUC"
			Me.Size = New System.Drawing.Size(180, 459)
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TitleAngleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Radar Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = New NRadarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(m_Chart)
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.DisplayOnLegend = nChartControl1.Legends(0)

			' set some axis labels
			AddAxis("Vitamin A")
			AddAxis("Vitamin B1")
			AddAxis("Vitamin B2")
			AddAxis("Vitamin B6")
			AddAxis("Vitamin B12")
			AddAxis("Vitamin C")
			AddAxis("Vitamin D")
			AddAxis("Vitamin E")

			m_Radar1 = New NRadarLineSeries()
			m_Chart.Series.Add(m_Radar1)
			m_Radar1.Name = "Series 1"
			m_Radar1.Values.FillRandomRange(Random, 8, 50, 90)
			m_Radar1.DataLabelStyle.Visible = False
			m_Radar1.DataLabelStyle.Format = "<value>"
			m_Radar1.MarkerStyle.Visible = True
			m_Radar1.MarkerStyle.PointShape = PointShape.Cylinder
			m_Radar1.MarkerStyle.Width = New NLength(1.6F, NRelativeUnit.ParentPercentage)
			m_Radar1.MarkerStyle.Height = New NLength(1.6F, NRelativeUnit.ParentPercentage)

			m_Radar2 = New NRadarLineSeries()
			m_Chart.Series.Add(m_Radar2)
			m_Radar2.Name = "Series 2"
			m_Radar2.Values.FillRandomRange(Random, 8, 0, 100)
			m_Radar2.DataLabelStyle.Visible = False
			m_Radar2.DataLabelStyle.Format = "<value>"
			m_Radar2.MarkerStyle.Visible = True
			m_Radar2.MarkerStyle.PointShape = PointShape.Cylinder
			m_Radar2.MarkerStyle.Width = New NLength(1.6F, NRelativeUnit.ParentPercentage)
			m_Radar2.MarkerStyle.Height = New NLength(1.6F, NRelativeUnit.ParentPercentage)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Charts(0).Series)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' init form controls
			BeginAngleUpDown.Value = 90

			TitleAngleModeComboBox.FillFromEnum(GetType(ScaleLabelAngleMode))
			TitleAngleModeComboBox.SelectedIndex = CInt(ScaleLabelAngleMode.Scale)
		End Sub

		Private Sub UpdateTitleLabels()
			Dim mode As ScaleLabelAngleMode = CType(TitleAngleModeComboBox.SelectedIndex, ScaleLabelAngleMode)
			Dim angle As Single = CSng(TitleAngleNumericUpDown.Value)

			For i As Integer = 0 To m_Chart.Axes.Count - 1
				Dim axis As NRadarAxis = DirectCast(m_Chart.Axes(i), NRadarAxis)
				axis.TitleAngle = New NScaleLabelAngle(mode, angle)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub AddAxis(ByVal title As String)
			Dim axis As New NRadarAxis()

			' set title
			axis.Title = title

			' setup scale
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RulerStyle.BorderStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)
			linearScale.OuterMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)

			If m_Chart.Axes.Count = 0 Then
				' if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, True)

				' add interlaced stripe
				Dim strip As New NScaleStripStyle()
				strip.FillStyle = New NColorFillStyle(Color.FromArgb(64, 200, 200, 200))
				strip.Interlaced = True
				strip.SetShowAtWall(ChartWallType.Radar, True)
				linearScale.StripStyles.Add(strip)
			Else
				' hide labels
				linearScale.AutoLabels = False
			End If

			m_Chart.Axes.Add(axis)
		End Sub

		Private Sub RadarLineButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadarLineButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Radar1.BorderStyle, strokeStyleResult) Then
				m_Radar1.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RadarLine2Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadarLine2Button.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Radar2.BorderStyle, strokeStyleResult) Then
				m_Radar2.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MarkerStyleButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerStyleButton1.Click
			Dim markerStyleResult As NMarkerStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NMarkerStyleTypeEditor.Edit(series.MarkerStyle, markerStyleResult) Then
				series.MarkerStyle = markerStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MarkerStyleButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerStyleButton2.Click
			Dim markerStyleResult As NMarkerStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(1), NSeries)

			If NMarkerStyleTypeEditor.Edit(series.MarkerStyle, markerStyleResult) Then
				series.MarkerStyle = markerStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BeginAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BeginAngleUpDown.ValueChanged
			m_Chart.BeginAngle = CSng(BeginAngleUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub TitleAngleModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TitleAngleModeComboBox.SelectedIndexChanged
			UpdateTitleLabels()
		End Sub

		Private Sub TitleAngleNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TitleAngleNumericUpDown.ValueChanged
			UpdateTitleLabels()
		End Sub
	End Class
End Namespace
