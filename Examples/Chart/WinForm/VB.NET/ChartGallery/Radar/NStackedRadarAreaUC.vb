Imports System
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
	<ToolboxItem(False)>
	Public Class NStackedRadarAreaUC
		Inherits NExampleBaseUC

		Private m_Chart As NRadarChart
		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents TitleAngleModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents TitleAngleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents StackModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private label2 As Label
		Private label3 As Label
		Private label4 As Label

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
			Me.StackModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TitleAngleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(9, 90)
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
			Me.label2.Location = New System.Drawing.Point(9, 70)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(157, 17)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Begin Angle:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(9, 135)
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
			Me.TitleAngleModeComboBox.Location = New System.Drawing.Point(9, 152)
			Me.TitleAngleModeComboBox.Name = "TitleAngleModeComboBox"
			Me.TitleAngleModeComboBox.Size = New System.Drawing.Size(157, 21)
			Me.TitleAngleModeComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleAngleModeComboBox_SelectedIndexChanged);
			' 
			' TitleAngleNumericUpDown
			' 
			Me.TitleAngleNumericUpDown.Location = New System.Drawing.Point(9, 197)
			Me.TitleAngleNumericUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.TitleAngleNumericUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.TitleAngleNumericUpDown.Name = "TitleAngleNumericUpDown"
			Me.TitleAngleNumericUpDown.Size = New System.Drawing.Size(157, 20)
			Me.TitleAngleNumericUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TitleAngleNumericUpDown.ValueChanged += new System.EventHandler(this.TitleAngleNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 183)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(157, 17)
			Me.label1.TabIndex = 8
			Me.label1.Text = "Title Angle:"
			' 
			' StackModeCombo
			' 
			Me.StackModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.StackModeCombo.ListProperties.DataSource = Nothing
			Me.StackModeCombo.ListProperties.DisplayMember = ""
			Me.StackModeCombo.Location = New System.Drawing.Point(9, 27)
			Me.StackModeCombo.Name = "StackModeCombo"
			Me.StackModeCombo.Size = New System.Drawing.Size(157, 21)
			Me.StackModeCombo.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StackModeCombo.SelectedIndexChanged += new System.EventHandler(this.StackModeCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(9, 11)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(152, 16)
			Me.label4.TabIndex = 10
			Me.label4.Text = "Stack Mode:"
			' 
			' NStackedRadarAreaUC
			' 
			Me.Controls.Add(Me.StackModeCombo)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.TitleAngleNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.TitleAngleModeComboBox)
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NStackedRadarAreaUC"
			Me.Size = New System.Drawing.Size(180, 424)
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TitleAngleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stacked Radar Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = New NRadarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(m_Chart)
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.DisplayOnLegend = nChartControl1.Legends(0)

			AddAxis("Category A")
			AddAxis("Category B")
			AddAxis("Category C")
			AddAxis("Category D")
			AddAxis("Category E")

			' create the radar series
			Dim radarArea0 As New NRadarAreaSeries()
			m_Chart.Series.Add(radarArea0)
			radarArea0.Name = "Series 1"
			radarArea0.Values.FillRandomRange(Random, 5, 50, 90)
			radarArea0.DataLabelStyle.Visible = False
			radarArea0.DataLabelStyle.Format = "<value>"
			radarArea0.MarkerStyle.AutoDepth = True
			radarArea0.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			radarArea0.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)

			Dim radarArea1 As New NRadarAreaSeries()
			m_Chart.Series.Add(radarArea1)
			radarArea1.Name = "Series 2"
			radarArea1.Values.FillRandomRange(Random, 5, 0, 100)
			radarArea1.DataLabelStyle.Visible = False
			radarArea1.DataLabelStyle.Format = "<value>"
			radarArea1.MarkerStyle.AutoDepth = True
			radarArea1.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			radarArea1.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			' stack the second radar area series
			radarArea1.MultiAreaMode = MultiAreaMode.Stacked

			Dim radarArea2 As New NRadarAreaSeries()
			m_Chart.Series.Add(radarArea2)
			radarArea2.Name = "Series 3"
			radarArea2.Values.FillRandomRange(Random, 5, 0, 100)
			radarArea2.DataLabelStyle.Visible = False
			radarArea2.DataLabelStyle.Format = "<value>"
			radarArea2.MarkerStyle.AutoDepth = True
			radarArea2.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			radarArea2.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			' stack the third radar area series
			radarArea2.MultiAreaMode = MultiAreaMode.Stacked

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Charts(0).Series)

			radarArea0.FillStyle.SetTransparencyPercent(20)
			radarArea1.FillStyle.SetTransparencyPercent(20)
			radarArea2.FillStyle.SetTransparencyPercent(20)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' init form controls
			BeginAngleUpDown.Value = 90

			TitleAngleModeComboBox.FillFromEnum(GetType(ScaleLabelAngleMode))
			TitleAngleModeComboBox.SelectedIndex = CInt(ScaleLabelAngleMode.Scale)

			StackModeCombo.Items.Add("Stacked")
			StackModeCombo.Items.Add("Stacked %")
			StackModeCombo.SelectedIndex = 0
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
		Private Sub StackModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles StackModeCombo.SelectedIndexChanged
			Dim chart As NRadarChart = CType(nChartControl1.Charts(0), NRadarChart)
			Dim series1 As NRadarAreaSeries = CType(chart.Series(1), NRadarAreaSeries)
			Dim series2 As NRadarAreaSeries = CType(chart.Series(2), NRadarAreaSeries)
			Dim scale As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.Radar).ScaleConfigurator, NStandardScaleConfigurator)

			Select Case StackModeCombo.SelectedIndex
				Case 0
					series1.MultiAreaMode = MultiAreaMode.Stacked
					series2.MultiAreaMode = MultiAreaMode.Stacked
					scale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.General)

				Case 1
					series1.MultiAreaMode = MultiAreaMode.StackedPercent
					series2.MultiAreaMode = MultiAreaMode.StackedPercent
					scale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Percentage)
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
