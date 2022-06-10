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
	<ToolboxItem(False)>
	Public Class NRadarAxisTitlesUC
		Inherits NExampleBaseUC

		Private m_Chart As NRadarChart
		Private m_RadarArea1 As NRadarSeries
		Private m_RadarArea2 As NRadarSeries
		Private m_Updating As Boolean
		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As Label
		Private label3 As Label
		Private WithEvents TitleAngleModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents TitleAngleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As Label
		Private label4 As Label
		Private WithEvents TitleOffsetNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label5 As Label
		Private WithEvents TitlePositionModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label6 As Label
		Private WithEvents TitleFitModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label7 As Label
		Private WithEvents TitleMaxWidthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents TitleAutomaticAlignmentCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.BeginAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.TitleAngleModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.TitleAngleNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.TitleOffsetNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.TitlePositionModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.TitleFitModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.TitleMaxWidthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.TitleAutomaticAlignmentCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TitleAngleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TitleOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TitleMaxWidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(5, 27)
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
			Me.label2.Location = New System.Drawing.Point(5, 7)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(170, 17)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Begin Angle:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(5, 116)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(90, 13)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Title Angle Mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' TitleAngleModeComboBox
			' 
			Me.TitleAngleModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.TitleAngleModeComboBox.ListProperties.DataSource = Nothing
			Me.TitleAngleModeComboBox.ListProperties.DisplayMember = ""
			Me.TitleAngleModeComboBox.Location = New System.Drawing.Point(5, 133)
			Me.TitleAngleModeComboBox.Name = "TitleAngleModeComboBox"
			Me.TitleAngleModeComboBox.Size = New System.Drawing.Size(170, 21)
			Me.TitleAngleModeComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleAngleModeComboBox_SelectedIndexChanged);
			' 
			' TitleAngleNumericUpDown
			' 
			Me.TitleAngleNumericUpDown.Location = New System.Drawing.Point(5, 179)
			Me.TitleAngleNumericUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.TitleAngleNumericUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.TitleAngleNumericUpDown.Name = "TitleAngleNumericUpDown"
			Me.TitleAngleNumericUpDown.Size = New System.Drawing.Size(170, 20)
			Me.TitleAngleNumericUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAngleNumericUpDown.ValueChanged += new System.EventHandler(this.TitleAngleNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 159)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 17)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Title Angle:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(5, 61)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(170, 17)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Title Offset:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' TitleOffsetNumericUpDown
			' 
			Me.TitleOffsetNumericUpDown.Location = New System.Drawing.Point(5, 82)
			Me.TitleOffsetNumericUpDown.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
			Me.TitleOffsetNumericUpDown.Name = "TitleOffsetNumericUpDown"
			Me.TitleOffsetNumericUpDown.Size = New System.Drawing.Size(170, 20)
			Me.TitleOffsetNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TitleOffsetNumericUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(5, 214)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(100, 13)
			Me.label5.TabIndex = 8
			Me.label5.Text = "Title Position Mode:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' TitlePositionModeComboBox
			' 
			Me.TitlePositionModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.TitlePositionModeComboBox.ListProperties.DataSource = Nothing
			Me.TitlePositionModeComboBox.ListProperties.DisplayMember = ""
			Me.TitlePositionModeComboBox.Location = New System.Drawing.Point(5, 232)
			Me.TitlePositionModeComboBox.Name = "TitlePositionModeComboBox"
			Me.TitlePositionModeComboBox.Size = New System.Drawing.Size(170, 21)
			Me.TitlePositionModeComboBox.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitlePositionModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitlePositionModeComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(5, 275)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(74, 13)
			Me.label6.TabIndex = 10
			Me.label6.Text = "Title Fit Mode:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' TitleFitModeComboBox
			' 
			Me.TitleFitModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.TitleFitModeComboBox.ListProperties.DataSource = Nothing
			Me.TitleFitModeComboBox.ListProperties.DisplayMember = ""
			Me.TitleFitModeComboBox.Location = New System.Drawing.Point(5, 292)
			Me.TitleFitModeComboBox.Name = "TitleFitModeComboBox"
			Me.TitleFitModeComboBox.Size = New System.Drawing.Size(170, 21)
			Me.TitleFitModeComboBox.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleFitModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleFitModeComboBox_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(5, 316)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(170, 17)
			Me.label7.TabIndex = 12
			Me.label7.Text = "Title Max Width:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' TitleMaxWidthNumericUpDown
			' 
			Me.TitleMaxWidthNumericUpDown.Location = New System.Drawing.Point(5, 336)
			Me.TitleMaxWidthNumericUpDown.Maximum = New Decimal(New Integer() { 500, 0, 0, 0})
			Me.TitleMaxWidthNumericUpDown.Minimum = New Decimal(New Integer() { 30, 0, 0, 0})
			Me.TitleMaxWidthNumericUpDown.Name = "TitleMaxWidthNumericUpDown"
			Me.TitleMaxWidthNumericUpDown.Size = New System.Drawing.Size(170, 20)
			Me.TitleMaxWidthNumericUpDown.TabIndex = 13
			Me.TitleMaxWidthNumericUpDown.Value = New Decimal(New Integer() { 30, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleMaxWidthNumericUpDown.ValueChanged += new System.EventHandler(this.TitleMaxWidthNumericUpDown_ValueChanged);
			' 
			' TitleAutomaticAlignmentCheckBox
			' 
			Me.TitleAutomaticAlignmentCheckBox.ButtonProperties.BorderOffset = 2
			Me.TitleAutomaticAlignmentCheckBox.Location = New System.Drawing.Point(5, 377)
			Me.TitleAutomaticAlignmentCheckBox.Name = "TitleAutomaticAlignmentCheckBox"
			Me.TitleAutomaticAlignmentCheckBox.Size = New System.Drawing.Size(163, 24)
			Me.TitleAutomaticAlignmentCheckBox.TabIndex = 14
			Me.TitleAutomaticAlignmentCheckBox.Text = "Title Automatic Alignment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAutomaticAlignmentCheckBox.CheckedChanged += new System.EventHandler(this.TitleAutomaticAlignmentCheckBox_CheckedChanged);
			' 
			' NRadarAxisTitlesUC
			' 
			Me.Controls.Add(Me.TitleAutomaticAlignmentCheckBox)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.TitleMaxWidthNumericUpDown)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.TitleFitModeComboBox)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.TitlePositionModeComboBox)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.TitleOffsetNumericUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.TitleAngleNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.TitleAngleModeComboBox)
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label2)
			Me.Name = "NRadarAxisTitlesUC"
			Me.Size = New System.Drawing.Size(180, 505)
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TitleAngleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TitleOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TitleMaxWidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Radar Axis Titles<br/><font size = '12pt'>Demonstrates various radar axis title properties</font>")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.TextFormat = TextFormat.XML

			' configure the chart
			m_Chart = New NRadarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(m_Chart)
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.DisplayOnLegend = nChartControl1.Legends(0)

			AddAxis("<b>Vitamin A</b><br/><font size='8pt'>(etinol, retinal and four carotenoids including beta carotene</font>")
			AddAxis("<b>Vitamin B1</b><br/><font size='8pt'>thiamin or vitamin B1</font>")
			AddAxis("<b>Vitamin B2</b><br/><font size='8pt'>easily absorbed micronutrient</font>")
			AddAxis("<b>Vitamin B6</b><br/><font size='8pt'>water-soluble vitamin part of the vitamin B complex group</font>")
			AddAxis("<b>Vitamin B12</b><br/><font size='8pt'>also called cobalamin, is a water-soluble vitamin</font>")
			AddAxis("<b>Vitamin C</b><br/><font size='8pt'>or L-ascorbic acid or L-ascorbate is an essential nutrient for humans</font>")
			AddAxis("<b>Vitamin D</b><br/><font size='8pt'>a group of fat-soluble secosteroids</font>")
			AddAxis("<b>Vitamin E</b><br/><font size='8pt'>refers to a group of eight fat-soluble compounds</font>")

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

			m_Updating = True

			TitleAngleModeComboBox.FillFromEnum(GetType(ScaleLabelAngleMode))
			TitleAngleModeComboBox.SelectedIndex = CInt(ScaleLabelAngleMode.View)

			TitlePositionModeComboBox.FillFromEnum(GetType(RadarTitlePositionMode))
			TitlePositionModeComboBox.SelectedIndex = CInt(RadarTitlePositionMode.Center)

			TitleFitModeComboBox.FillFromEnum(GetType(RadarTitleFitMode))
			TitleFitModeComboBox.SelectedIndex = CInt(RadarTitleFitMode.Wrap)

			TitleOffsetNumericUpDown.Value = 5
			TitleMaxWidthNumericUpDown.Value = 100


			m_Updating = False

			UpdateTitleLabels()
		End Sub

		Private Sub AddAxis(ByVal title As String)
			Dim axis As New NRadarAxis()

			' set title
			axis.Title = title
			axis.TitleTextStyle.TextFormat = TextFormat.XML

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
			If m_Updating OrElse nChartControl1 Is Nothing Then
				Return
			End If

			Dim mode As ScaleLabelAngleMode = CType(TitleAngleModeComboBox.SelectedIndex, ScaleLabelAngleMode)
			Dim angle As Single = CSng(TitleAngleNumericUpDown.Value)

			For i As Integer = 0 To m_Chart.Axes.Count - 1
				Dim axis As NRadarAxis = DirectCast(m_Chart.Axes(i), NRadarAxis)
				axis.TitleAngle = New NScaleLabelAngle(mode, angle)

				axis.TitleOffset = New NLength(CSng(TitleOffsetNumericUpDown.Value))
				axis.TitlePositionMode = CType(TitlePositionModeComboBox.SelectedIndex, RadarTitlePositionMode)
				axis.TitleFitMode = CType(TitleFitModeComboBox.SelectedIndex, RadarTitleFitMode)
				axis.TitleMaxWidth = New NLength(CSng(TitleMaxWidthNumericUpDown.Value))
				axis.TitleAutomaticAlignment = TitleAutomaticAlignmentCheckBox.Checked
			Next i

			TitleMaxWidthNumericUpDown.Enabled = TitleFitModeComboBox.SelectedIndex = CInt(RadarTitleFitMode.Wrap)

			nChartControl1.Refresh()
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

		Private Sub TitleOffsetNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TitleOffsetNumericUpDown.ValueChanged
			UpdateTitleLabels()
		End Sub

		Private Sub TitlePositionModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TitlePositionModeComboBox.SelectedIndexChanged
			UpdateTitleLabels()
		End Sub

		Private Sub TitleFitModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TitleFitModeComboBox.SelectedIndexChanged
			UpdateTitleLabels()
		End Sub

		Private Sub TitleMaxWidthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TitleMaxWidthNumericUpDown.ValueChanged
			UpdateTitleLabels()
		End Sub

		Private Sub TitleAutomaticAlignmentCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TitleAutomaticAlignmentCheckBox.CheckedChanged
			UpdateTitleLabels()
		End Sub
	End Class
End Namespace
