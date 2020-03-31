Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPolarAngleAxisPositionUC
		Inherits NExampleBaseUC

		Private m_CustomAxisId As Integer
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents DockDegreeAxisCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DockGradAxisCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label3 As Label
		Private WithEvents DegreeAxisCrossValueUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As Label
		Private WithEvents GradAxisCrossValueUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label6 As Label

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.DegreeAxisCrossValueUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.DockDegreeAxisCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.GradAxisCrossValueUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.DockGradAxisCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BeginAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			Me.nGroupBox1.SuspendLayout()
			DirectCast(Me.DegreeAxisCrossValueUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox2.SuspendLayout()
			DirectCast(Me.GradAxisCrossValueUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label3)
			Me.nGroupBox1.Controls.Add(Me.DegreeAxisCrossValueUpDown)
			Me.nGroupBox1.Controls.Add(Me.DockDegreeAxisCheckBox)
			Me.nGroupBox1.Location = New System.Drawing.Point(13, 41)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(167, 78)
			Me.nGroupBox1.TabIndex = 2
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Degree Axis (Red)"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(5, 49)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(71, 17)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Cross Value:"
			' 
			' DegreeAxisCrossValueUpDown
			' 
			Me.DegreeAxisCrossValueUpDown.Location = New System.Drawing.Point(82, 46)
			Me.DegreeAxisCrossValueUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.DegreeAxisCrossValueUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.DegreeAxisCrossValueUpDown.Name = "DegreeAxisCrossValueUpDown"
			Me.DegreeAxisCrossValueUpDown.Size = New System.Drawing.Size(77, 20)
			Me.DegreeAxisCrossValueUpDown.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DegreeAxisCrossValueUpDown.ValueChanged += new System.EventHandler(this.DegreeAxisCrossValueUpDown_ValueChanged);
			' 
			' DockDegreeAxisCheckBox
			' 
			Me.DockDegreeAxisCheckBox.ButtonProperties.BorderOffset = 2
			Me.DockDegreeAxisCheckBox.Location = New System.Drawing.Point(6, 19)
			Me.DockDegreeAxisCheckBox.Name = "DockDegreeAxisCheckBox"
			Me.DockDegreeAxisCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.DockDegreeAxisCheckBox.TabIndex = 0
			Me.DockDegreeAxisCheckBox.Text = "Dock"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DockDegreeAxisCheckBox.CheckedChanged += new System.EventHandler(this.DockDegreeAxisCheckBox_CheckedChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.label1)
			Me.nGroupBox2.Controls.Add(Me.GradAxisCrossValueUpDown)
			Me.nGroupBox2.Controls.Add(Me.DockGradAxisCheckBox)
			Me.nGroupBox2.Location = New System.Drawing.Point(13, 125)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(167, 78)
			Me.nGroupBox2.TabIndex = 3
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Grad Axis (Green)"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 52)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(71, 17)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Cross Value:"
			' 
			' GradAxisCrossValueUpDown
			' 
			Me.GradAxisCrossValueUpDown.Location = New System.Drawing.Point(82, 49)
			Me.GradAxisCrossValueUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.GradAxisCrossValueUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.GradAxisCrossValueUpDown.Name = "GradAxisCrossValueUpDown"
			Me.GradAxisCrossValueUpDown.Size = New System.Drawing.Size(77, 20)
			Me.GradAxisCrossValueUpDown.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GradAxisCrossValueUpDown.ValueChanged += new System.EventHandler(this.GradAxisCrossValueUpDown_ValueChanged);
			' 
			' DockGradAxisCheckBox
			' 
			Me.DockGradAxisCheckBox.ButtonProperties.BorderOffset = 2
			Me.DockGradAxisCheckBox.Location = New System.Drawing.Point(6, 19)
			Me.DockGradAxisCheckBox.Name = "DockGradAxisCheckBox"
			Me.DockGradAxisCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.DockGradAxisCheckBox.TabIndex = 0
			Me.DockGradAxisCheckBox.Text = "Dock"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DockGradAxisCheckBox.CheckedChanged += new System.EventHandler(this.DockGradAxisCheckBox_CheckedChanged);
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(95, 8)
			Me.BeginAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.BeginAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.BeginAngleUpDown.Name = "BeginAngleUpDown"
			Me.BeginAngleUpDown.Size = New System.Drawing.Size(74, 20)
			Me.BeginAngleUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(10, 11)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(162, 17)
			Me.label6.TabIndex = 0
			Me.label6.Text = "Begin Angle:"
			' 
			' NPolarAngleAxisPositionUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NPolarAngleAxisPositionUC"
			Me.Size = New System.Drawing.Size(180, 335)
			Me.nGroupBox1.ResumeLayout(False)
			DirectCast(Me.DegreeAxisCrossValueUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox2.ResumeLayout(False)
			DirectCast(Me.GradAxisCrossValueUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Angle Axis Position")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim polar As New NPolarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(polar)
			polar.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			polar.DisplayOnLegend = nChartControl1.Legends(0)
			polar.Depth = 5
			polar.Width = 70.0F
			polar.Height = 70.0F

			' create a polar line series
			Dim series1 As New NPolarLineSeries()
			polar.Series.Add(series1)
			series1.Name = "Series 1"
			series1.CloseContour = True
			series1.DataLabelStyle.Visible = False
			series1.MarkerStyle.Visible = False
			series1.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series1.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve1(series1, 50)

			' create a polar line series
			Dim series2 As New NPolarLineSeries()
			polar.Series.Add(series2)
			series2.Name = "Series 2"
			series2.CloseContour = True
			series2.DataLabelStyle.Visible = False
			series2.MarkerStyle.Visible = False
			series2.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series2.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve2(series2, 100)

			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(polar.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			Dim strip As New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.Beige)
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.StripStyles.Add(strip)

			' setup polar angle axis
			Dim degreeScale As NAngularScaleConfigurator = CType(polar.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			degreeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			degreeScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			degreeScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)

			' add a second value axes
			Dim valueAxis As NPolarAxis = CType(polar.Axis(StandardAxis.Polar), NPolarAxis)

			Dim primaryAxis As NPolarAxis = CType(polar.Axis(StandardAxis.PolarAngle), NPolarAxis)
			Dim secondaryAxis As NPolarAxis = CType(polar.Axes, NPolarAxisCollection).AddCustomAxis(PolarAxisOrientation.Angle)

			Dim gradScale As New NAngularScaleConfigurator()
			gradScale.AngleUnit = NAngleUnit.Grad
			gradScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			gradScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)
			secondaryAxis.ScaleConfigurator = gradScale
			m_CustomAxisId = secondaryAxis.AxisId

			Dim secondaryAnchor As New NCrossPolarAxisAnchor(PolarAxisOrientation.Angle)
			secondaryAnchor.Crossings.Add(New NValueAxisCrossing(valueAxis, 10))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' color code the axes and series after the stylesheet is applied
			ApplyColorToAxis(primaryAxis, Color.Red)
			ApplyColorToAxis(secondaryAxis, Color.Green)

			series1.BorderStyle.Width = New NLength(2)
			series2.BorderStyle.Width = New NLength(2)

			DockDegreeAxisCheckBox.Checked = True
			DockGradAxisCheckBox.Checked = False
			DegreeAxisCrossValueUpDown.Value = 70
			GradAxisCrossValueUpDown.Value = 50
		End Sub

		Private Sub ApplyColorToAxis(ByVal axis As NAxis, ByVal color As Color)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			scale_Renamed.RulerStyle.BorderStyle.Color = color
			scale_Renamed.OuterMajorTickStyle.LineStyle.Color = color
			scale_Renamed.OuterMinorTickStyle.LineStyle.Color = color
			scale_Renamed.InnerMajorTickStyle.LineStyle.Color = color
			scale_Renamed.InnerMinorTickStyle.LineStyle.Color = color
			scale_Renamed.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(color)

			axis.InvalidateScale()
		End Sub


		Private Sub UpdateAxes()
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart Is Nothing Then
				Return
			End If

			Dim valueAxis As NAxis = polarChart.Axis(StandardAxis.Polar)
			Dim degreeAxis As NAxis = polarChart.Axis(StandardAxis.PolarAngle)
			Dim gradAxis As NAxis = polarChart.Axis(m_CustomAxisId)

			If DockDegreeAxisCheckBox.Checked Then
				degreeAxis.Anchor = New NDockPolarAxisAnchor()
				DegreeAxisCrossValueUpDown.Enabled = False
			Else
				degreeAxis.Anchor = New NCrossPolarAxisAnchor(PolarAxisOrientation.Angle, New NValueAxisCrossing(valueAxis, CDbl(DegreeAxisCrossValueUpDown.Value)))
				DegreeAxisCrossValueUpDown.Enabled = True
			End If

			If DockGradAxisCheckBox.Checked Then
				gradAxis.Anchor = New NDockPolarAxisAnchor()
				GradAxisCrossValueUpDown.Enabled = False
			Else
				gradAxis.Anchor = New NCrossPolarAxisAnchor(PolarAxisOrientation.Angle, New NValueAxisCrossing(valueAxis, CDbl(GradAxisCrossValueUpDown.Value)))
				GradAxisCrossValueUpDown.Enabled = True
			End If

			nChartControl1.Refresh()
		End Sub

		Friend Shared Sub Curve1(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			For i As Integer = 0 To count - 1
				Dim angle As Double = i * angleStep
				Dim radius As Double = 100 * Math.Cos(angle)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
			Next i
		End Sub

		Friend Shared Sub Curve2(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			For i As Integer = 0 To count - 1
				Dim angle As Double = i * angleStep
				Dim radius As Double = 33 + 100 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle)

				radius = Math.Abs(radius)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
			Next i
		End Sub

		Private Sub DockDegreeAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DockDegreeAxisCheckBox.CheckedChanged
			UpdateAxes()
		End Sub

		Private Sub DegreeAxisCrossValueUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DegreeAxisCrossValueUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub DockGradAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DockGradAxisCheckBox.CheckedChanged
			UpdateAxes()
		End Sub

		Private Sub GradAxisCrossValueUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GradAxisCrossValueUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub BeginAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BeginAngleUpDown.ValueChanged
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart IsNot Nothing Then
				polarChart.BeginAngle = CSng(BeginAngleUpDown.Value)
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
