Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRulerCapsUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents BeginCapComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents EndCapComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PaintOnScaleBreaks As Nevron.UI.WinForm.Controls.NCheckBox
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents WidthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents HeightNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents ScaleBreakCapComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label5 As Label

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
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.BeginCapComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.EndCapComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.PaintOnScaleBreaks = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.WidthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.HeightNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ScaleBreakCapComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			DirectCast(Me.WidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.HeightNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 12)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(85, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Begin Cap Style:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 115)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(77, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "End Cap Style:"
			' 
			' BeginCapComboBox
			' 
			Me.BeginCapComboBox.Location = New System.Drawing.Point(12, 28)
			Me.BeginCapComboBox.Name = "BeginCapComboBox"
			Me.BeginCapComboBox.Size = New System.Drawing.Size(175, 21)
			Me.BeginCapComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginCapComboBox.SelectedIndexChanged += new System.EventHandler(this.BeginCapComboBox_SelectedIndexChanged);
			' 
			' EndCapComboBox
			' 
			Me.EndCapComboBox.Location = New System.Drawing.Point(12, 130)
			Me.EndCapComboBox.Name = "EndCapComboBox"
			Me.EndCapComboBox.Size = New System.Drawing.Size(175, 21)
			Me.EndCapComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndCapComboBox.SelectedIndexChanged += new System.EventHandler(this.EndCapComboBox_SelectedIndexChanged);
			' 
			' PaintOnScaleBreaks
			' 
			Me.PaintOnScaleBreaks.AutoSize = True
			Me.PaintOnScaleBreaks.ButtonProperties.BorderOffset = 2
			Me.PaintOnScaleBreaks.Location = New System.Drawing.Point(12, 166)
			Me.PaintOnScaleBreaks.Name = "PaintOnScaleBreaks"
			Me.PaintOnScaleBreaks.Size = New System.Drawing.Size(131, 17)
			Me.PaintOnScaleBreaks.TabIndex = 6
			Me.PaintOnScaleBreaks.Text = "Paint on Scale Breaks"
			Me.PaintOnScaleBreaks.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PaintOnScaleBreaks.CheckedChanged += new System.EventHandler(this.PaintOnScaleBreaks_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(15, 224)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(38, 13)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Width:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(15, 251)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(41, 13)
			Me.label4.TabIndex = 9
			Me.label4.Text = "Height:"
			' 
			' WidthNumericUpDown
			' 
			Me.WidthNumericUpDown.Location = New System.Drawing.Point(92, 217)
			Me.WidthNumericUpDown.Name = "WidthNumericUpDown"
			Me.WidthNumericUpDown.Size = New System.Drawing.Size(95, 20)
			Me.WidthNumericUpDown.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthNumericUpDown.ValueChanged += new System.EventHandler(this.WidthNumericUpDown_ValueChanged);
			' 
			' HeightNumericUpDown
			' 
			Me.HeightNumericUpDown.Location = New System.Drawing.Point(92, 244)
			Me.HeightNumericUpDown.Name = "HeightNumericUpDown"
			Me.HeightNumericUpDown.Size = New System.Drawing.Size(95, 20)
			Me.HeightNumericUpDown.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HeightNumericUpDown.ValueChanged += new System.EventHandler(this.HeightNumericUpDown_ValueChanged);
			' 
			' ScaleBreakCapComboBox
			' 
			Me.ScaleBreakCapComboBox.Location = New System.Drawing.Point(12, 79)
			Me.ScaleBreakCapComboBox.Name = "ScaleBreakCapComboBox"
			Me.ScaleBreakCapComboBox.Size = New System.Drawing.Size(175, 21)
			Me.ScaleBreakCapComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ScaleBreakCapComboBox.SelectedIndexChanged += new System.EventHandler(this.ScaleBreakCapStyleComboBox_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(12, 63)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(116, 13)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Scale Break Cap Style:"
			' 
			' NRulerCapsUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.ScaleBreakCapComboBox)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.HeightNumericUpDown)
			Me.Controls.Add(Me.WidthNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.PaintOnScaleBreaks)
			Me.Controls.Add(Me.EndCapComboBox)
			Me.Controls.Add(Me.BeginCapComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NRulerCapsUC"
			Me.Size = New System.Drawing.Size(203, 288)
			DirectCast(Me.WidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.HeightNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As New NLabel("Axis Ruler Caps<br/> <font size = '9pt'>Demonstrates how to change the caps of the axis ruler</font>")
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10, 10, 10, 10)
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.FitAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(title)

			Dim chart As New NCartesianChart()
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch
			chart.Margins = New NMarginsL(10, 0, 20, 10)
			nChartControl1.Panels.Add(chart)

'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()

			' feed some random data 
			Dim point As New NPointSeries()
			point.DataLabelStyle.Visible = False
			point.UseXValues = True
			point.Size = New NLength(5)
			point.BorderStyle.Width = New NLength(0)

			' fill in some random data
			For j As Integer = 0 To 29
				point.Values.Add(5 + random_Renamed.Next(90))
				point.XValues.Add(5 + random_Renamed.Next(90))
			Next j

			chart.Series.Add(point)

			' configure scales
			Dim xScale As New NLinearScaleConfigurator()
			xScale.RoundToTickMax = True
			xScale.RoundToTickMin = True
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			xScale.ScaleBreaks.Add(New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Orange)), Nothing, New NLength(10)), New NRange1DD(29, 41)))

			' add an interlaced strip to the X axis
			Dim xInterlacedStrip As New NScaleStripStyle()
			xInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			xInterlacedStrip.Interlaced = True
			xInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			xScale.StripStyles.Add(xInterlacedStrip)

			Dim xAxis As NCartesianAxis = CType(chart.Axis(StandardAxis.PrimaryX), NCartesianAxis)
			xAxis.ScaleConfigurator = xScale
			xAxis.View = New NRangeAxisView(New NRange1DD(0, 100))

			Dim xAxisAnchor As New NDockAxisAnchor(AxisDockZone.FrontBottom)
			xAxisAnchor.BeforeSpace = New NLength(10)
			xAxis.Anchor = xAxisAnchor

			Dim yScale As New NLinearScaleConfigurator()
			yScale.RoundToTickMax = True
			yScale.RoundToTickMin = True
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScale.ScaleBreaks.Add(New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Orange)), Nothing, New NLength(10)), New NRange1DD(29, 41)))

			' add an interlaced strip to the Y axis
			Dim yInterlacedStrip As New NScaleStripStyle()
			yInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			yInterlacedStrip.Interlaced = True
			yInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			yScale.StripStyles.Add(yInterlacedStrip)

			Dim yAxis As NCartesianAxis = CType(chart.Axis(StandardAxis.PrimaryY), NCartesianAxis)
			yAxis.ScaleConfigurator = yScale
			yAxis.View = New NRangeAxisView(New NRange1DD(0, 100))

			Dim yAxisAnchor As New NDockAxisAnchor(AxisDockZone.FrontLeft)
			yAxisAnchor.BeforeSpace = New NLength(10)
			yAxis.Anchor = yAxisAnchor

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' Init form controls
			BeginCapComboBox.FillFromEnum(GetType(CapStyle))
			EndCapComboBox.FillFromEnum(GetType(CapStyle))
			ScaleBreakCapComboBox.FillFromEnum(GetType(CapStyle))

			BeginCapComboBox.SelectedIndex = CInt(CapStyle.Ellipse)
			EndCapComboBox.SelectedIndex = CInt(CapStyle.Arrow)
			ScaleBreakCapComboBox.SelectedIndex = CInt(CapStyle.LeftCrossLine)
			WidthNumericUpDown.Value = CDec(5)
			HeightNumericUpDown.Value = CDec(5)
		End Sub

		Private Sub UpdateRulerStyles()
			Dim chart As NChart = nChartControl1.Charts(0)

			UpdateRulerStyleForAxis(chart.Axis(StandardAxis.PrimaryX))
			UpdateRulerStyleForAxis(chart.Axis(StandardAxis.PrimaryY))

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateRulerStyleForAxis(ByVal axis As NAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			' apply style to begin and end caps
			scale_Renamed.RulerStyle.BeginCapStyle.Style = CType(BeginCapComboBox.SelectedIndex, CapStyle)
			scale_Renamed.RulerStyle.EndCapStyle.Style = CType(EndCapComboBox.SelectedIndex, CapStyle)
			scale_Renamed.RulerStyle.ScaleBreakCapStyle.Style = CType(ScaleBreakCapComboBox.SelectedIndex, CapStyle)
			scale_Renamed.RulerStyle.PaintOnScaleBreaks = PaintOnScaleBreaks.Checked

			' apply cap style sizes
			Dim capSize As New NSizeL(CSng(WidthNumericUpDown.Value), CSng(HeightNumericUpDown.Value))
			scale_Renamed.RulerStyle.BeginCapStyle.Size = capSize
			scale_Renamed.RulerStyle.EndCapStyle.Size = capSize
			scale_Renamed.RulerStyle.ScaleBreakCapStyle.Size = capSize
		End Sub

		Private Sub BeginCapComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BeginCapComboBox.SelectedIndexChanged
			UpdateRulerStyles()
		End Sub

		Private Sub EndCapComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EndCapComboBox.SelectedIndexChanged
			UpdateRulerStyles()
		End Sub

		Private Sub WidthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles WidthNumericUpDown.ValueChanged
			UpdateRulerStyles()
		End Sub

		Private Sub HeightNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HeightNumericUpDown.ValueChanged
			UpdateRulerStyles()
		End Sub

		Private Sub PaintOnScaleBreaks_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PaintOnScaleBreaks.CheckedChanged
			UpdateRulerStyles()
		End Sub

		Private Sub ScaleBreakCapStyleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ScaleBreakCapComboBox.SelectedIndexChanged
			UpdateRulerStyles()
		End Sub
	End Class
End Namespace
