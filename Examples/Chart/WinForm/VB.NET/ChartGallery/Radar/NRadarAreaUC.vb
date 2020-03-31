Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRadarAreaUC
		Inherits NExampleBaseUC

		Private m_Chart As NRadarChart
		Private m_RadarArea1 As NRadarSeries
		Private m_RadarArea2 As NRadarSeries
		Private WithEvents RadarArea2Button As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RadarAreaButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton2 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As Label
		Private label3 As Label
		Private WithEvents TitleAngleModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents TitleAngleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As Label
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
			Me.RadarArea2Button = New Nevron.UI.WinForm.Controls.NButton()
			Me.RadarAreaButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.BeginAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.TitleAngleModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.TitleAngleNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TitleAngleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' RadarArea2Button
			' 
			Me.RadarArea2Button.Location = New System.Drawing.Point(5, 89)
			Me.RadarArea2Button.Name = "RadarArea2Button"
			Me.RadarArea2Button.Size = New System.Drawing.Size(170, 24)
			Me.RadarArea2Button.TabIndex = 3
			Me.RadarArea2Button.Text = "Radar Area 2 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RadarArea2Button.Click += new System.EventHandler(this.RadarArea2Button_Click);
			' 
			' RadarAreaButton
			' 
			Me.RadarAreaButton.Location = New System.Drawing.Point(5, 58)
			Me.RadarAreaButton.Name = "RadarAreaButton"
			Me.RadarAreaButton.Size = New System.Drawing.Size(170, 24)
			Me.RadarAreaButton.TabIndex = 2
			Me.RadarAreaButton.Text = "Radar Area 1 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RadarAreaButton.Click += new System.EventHandler(this.RadarAreaButton_Click);
			' 
			' MarkerStyleButton1
			' 
			Me.MarkerStyleButton1.Location = New System.Drawing.Point(5, 120)
			Me.MarkerStyleButton1.Name = "MarkerStyleButton1"
			Me.MarkerStyleButton1.Size = New System.Drawing.Size(170, 24)
			Me.MarkerStyleButton1.TabIndex = 4
			Me.MarkerStyleButton1.Text = "Radar 1 Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton1.Click += new System.EventHandler(this.MarkerStyleButton1_Click);
			' 
			' MarkerStyleButton2
			' 
			Me.MarkerStyleButton2.Location = New System.Drawing.Point(5, 151)
			Me.MarkerStyleButton2.Name = "MarkerStyleButton2"
			Me.MarkerStyleButton2.Size = New System.Drawing.Size(170, 24)
			Me.MarkerStyleButton2.TabIndex = 5
			Me.MarkerStyleButton2.Text = "Radar 2 Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton2.Click += new System.EventHandler(this.MarkerStyleButton2_Click);
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(5, 28)
			Me.BeginAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.BeginAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.BeginAngleUpDown.Name = "BeginAngleUpDown"
			Me.BeginAngleUpDown.Size = New System.Drawing.Size(170, 20)
			Me.BeginAngleUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(175, 17)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Begin Angle:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(5, 202)
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
			Me.TitleAngleModeComboBox.Location = New System.Drawing.Point(5, 219)
			Me.TitleAngleModeComboBox.Name = "TitleAngleModeComboBox"
			Me.TitleAngleModeComboBox.Size = New System.Drawing.Size(170, 21)
			Me.TitleAngleModeComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleAngleModeComboBox_SelectedIndexChanged);
			' 
			' TitleAngleNumericUpDown
			' 
			Me.TitleAngleNumericUpDown.Location = New System.Drawing.Point(5, 262)
			Me.TitleAngleNumericUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.TitleAngleNumericUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.TitleAngleNumericUpDown.Name = "TitleAngleNumericUpDown"
			Me.TitleAngleNumericUpDown.Size = New System.Drawing.Size(170, 20)
			Me.TitleAngleNumericUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAngleNumericUpDown.ValueChanged += new System.EventHandler(this.TitleAngleNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(2, 243)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 17)
			Me.label1.TabIndex = 8
			Me.label1.Text = "Title Angle:"
			' 
			' NRadarAreaUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.TitleAngleNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.TitleAngleModeComboBox)
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.MarkerStyleButton2)
			Me.Controls.Add(Me.MarkerStyleButton1)
			Me.Controls.Add(Me.RadarArea2Button)
			Me.Controls.Add(Me.RadarAreaButton)
			Me.Name = "NRadarAreaUC"
			Me.Size = New System.Drawing.Size(180, 505)
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TitleAngleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Radar Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = New NRadarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(m_Chart)
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.DisplayOnLegend = nChartControl1.Legends(0)

			AddAxis("Vitamin A")
			AddAxis("Vitamin B1")
			AddAxis("Vitamin B2")
			AddAxis("Vitamin B6")
			AddAxis("Vitamin B12")
			AddAxis("Vitamin C")
			AddAxis("Vitamin D")
			AddAxis("Vitamin E")

			' create the radar series
			m_RadarArea1 = New NRadarAreaSeries()
			m_Chart.Series.Add(m_RadarArea1)
			m_RadarArea1.Name = "Series 1"
			m_RadarArea1.Values.FillRandomRange(Random, 8, 50, 90)
			m_RadarArea1.DataLabelStyle.Visible = False
			m_RadarArea1.DataLabelStyle.Format = "<value>"
			m_RadarArea1.MarkerStyle.AutoDepth = True
			m_RadarArea1.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_RadarArea1.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)

			m_RadarArea2 = New NRadarAreaSeries()
			m_Chart.Series.Add(m_RadarArea2)
			m_RadarArea2.Name = "Series 2"
			m_RadarArea2.Values.FillRandomRange(Random, 8, 0, 100)
			m_RadarArea2.DataLabelStyle.Visible = False
			m_RadarArea2.DataLabelStyle.Format = "<value>"
			m_RadarArea2.MarkerStyle.AutoDepth = True
			m_RadarArea2.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_RadarArea2.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Charts(0).Series)

			m_RadarArea1.FillStyle.SetTransparencyPercent(50)
			m_RadarArea2.FillStyle.SetTransparencyPercent(60)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' init form controls
			BeginAngleUpDown.Value = 90

			TitleAngleModeComboBox.FillFromEnum(GetType(ScaleLabelAngleMode))
			TitleAngleModeComboBox.SelectedIndex = CInt(ScaleLabelAngleMode.Scale)
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

		Private Sub UpdateTitleLabels()
			Dim mode As ScaleLabelAngleMode = CType(TitleAngleModeComboBox.SelectedIndex, ScaleLabelAngleMode)
			Dim angle As Single = CSng(TitleAngleNumericUpDown.Value)

			For i As Integer = 0 To m_Chart.Axes.Count - 1
				Dim axis As NRadarAxis = DirectCast(m_Chart.Axes(i), NRadarAxis)
				axis.TitleAngle = New NScaleLabelAngle(mode, angle)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub RadarAreaButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadarAreaButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_RadarArea1.FillStyle, fillStyleResult) Then
				m_RadarArea1.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RadarArea2Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadarArea2Button.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_RadarArea2.FillStyle, fillStyleResult) Then
				m_RadarArea2.FillStyle = fillStyleResult
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
