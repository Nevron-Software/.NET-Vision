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
	Public Class NAxisViewRangeInflateUC
		Inherits NExampleBaseUC

		Private m_Updating As Boolean
		Private LogicalInflateGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private AbsoluteInflateGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LogicalInflateMaxNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As Label
		Private WithEvents LogicalInflateMinNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label6 As Label
		Private label5 As Label
		Private label4 As Label
		Private WithEvents AbsoluteInflateMaxNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As Label
		Private label3 As Label
		Private WithEvents AbsoluteInflateMinNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents InflateViewRangeMinCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InflateViewRangeMaxCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label7 As Label
		Private WithEvents ViewRangeInflateModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.LogicalInflateGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LogicalInflateMaxNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.LogicalInflateMinNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			Me.AbsoluteInflateGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.AbsoluteInflateMaxNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.AbsoluteInflateMinNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.InflateViewRangeMinCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InflateViewRangeMaxCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.ViewRangeInflateModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.LogicalInflateGroupBox.SuspendLayout()
			DirectCast(Me.LogicalInflateMaxNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.LogicalInflateMinNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.AbsoluteInflateGroupBox.SuspendLayout()
			DirectCast(Me.AbsoluteInflateMaxNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.AbsoluteInflateMinNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' LogicalInflateGroupBox
			' 
			Me.LogicalInflateGroupBox.Controls.Add(Me.LogicalInflateMaxNumericUpDown)
			Me.LogicalInflateGroupBox.Controls.Add(Me.label1)
			Me.LogicalInflateGroupBox.Controls.Add(Me.LogicalInflateMinNumericUpDown)
			Me.LogicalInflateGroupBox.Controls.Add(Me.label6)
			Me.LogicalInflateGroupBox.ImageIndex = 0
			Me.LogicalInflateGroupBox.Location = New System.Drawing.Point(3, 116)
			Me.LogicalInflateGroupBox.Name = "LogicalInflateGroupBox"
			Me.LogicalInflateGroupBox.Size = New System.Drawing.Size(176, 74)
			Me.LogicalInflateGroupBox.TabIndex = 4
			Me.LogicalInflateGroupBox.TabStop = False
			Me.LogicalInflateGroupBox.Text = "Logical Inflate"
			' 
			' LogicalInflateMaxNumericUpDown
			' 
			Me.LogicalInflateMaxNumericUpDown.Location = New System.Drawing.Point(74, 43)
			Me.LogicalInflateMaxNumericUpDown.Name = "LogicalInflateMaxNumericUpDown"
			Me.LogicalInflateMaxNumericUpDown.Size = New System.Drawing.Size(65, 20)
			Me.LogicalInflateMaxNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LogicalInflateMaxNumericUpDown.ValueChanged += new System.EventHandler(this.LogicalInflateMaxNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 50)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(62, 13)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Inflate Max:"
			' 
			' LogicalInflateMinNumericUpDown
			' 
			Me.LogicalInflateMinNumericUpDown.Location = New System.Drawing.Point(74, 17)
			Me.LogicalInflateMinNumericUpDown.Name = "LogicalInflateMinNumericUpDown"
			Me.LogicalInflateMinNumericUpDown.Size = New System.Drawing.Size(65, 20)
			Me.LogicalInflateMinNumericUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LogicalInflateMinNumericUpDown.ValueChanged += new System.EventHandler(this.LogicalInflateMinNumericUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(9, 24)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(59, 13)
			Me.label6.TabIndex = 0
			Me.label6.Text = "Inflate Min:"
			' 
			' AbsoluteInflateGroupBox
			' 
			Me.AbsoluteInflateGroupBox.Controls.Add(Me.label5)
			Me.AbsoluteInflateGroupBox.Controls.Add(Me.label4)
			Me.AbsoluteInflateGroupBox.Controls.Add(Me.AbsoluteInflateMaxNumericUpDown)
			Me.AbsoluteInflateGroupBox.Controls.Add(Me.label2)
			Me.AbsoluteInflateGroupBox.Controls.Add(Me.label3)
			Me.AbsoluteInflateGroupBox.Controls.Add(Me.AbsoluteInflateMinNumericUpDown)
			Me.AbsoluteInflateGroupBox.ImageIndex = 0
			Me.AbsoluteInflateGroupBox.Location = New System.Drawing.Point(3, 196)
			Me.AbsoluteInflateGroupBox.Name = "AbsoluteInflateGroupBox"
			Me.AbsoluteInflateGroupBox.Size = New System.Drawing.Size(176, 81)
			Me.AbsoluteInflateGroupBox.TabIndex = 5
			Me.AbsoluteInflateGroupBox.TabStop = False
			Me.AbsoluteInflateGroupBox.Text = "Absolute Inflate"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(145, 53)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(16, 13)
			Me.label5.TabIndex = 5
			Me.label5.Text = "pt"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(145, 27)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(16, 13)
			Me.label4.TabIndex = 2
			Me.label4.Text = "pt"
			' 
			' AbsoluteInflateMaxNumericUpDown
			' 
			Me.AbsoluteInflateMaxNumericUpDown.Location = New System.Drawing.Point(74, 46)
			Me.AbsoluteInflateMaxNumericUpDown.Name = "AbsoluteInflateMaxNumericUpDown"
			Me.AbsoluteInflateMaxNumericUpDown.Size = New System.Drawing.Size(65, 20)
			Me.AbsoluteInflateMaxNumericUpDown.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AbsoluteInflateMaxNumericUpDown.ValueChanged += new System.EventHandler(this.AbsoluteInflateMaxNumericUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(9, 53)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(62, 13)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Inflate Max:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(9, 27)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(59, 13)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Inflate Min:"
			' 
			' AbsoluteInflateMinNumericUpDown
			' 
			Me.AbsoluteInflateMinNumericUpDown.Location = New System.Drawing.Point(74, 20)
			Me.AbsoluteInflateMinNumericUpDown.Name = "AbsoluteInflateMinNumericUpDown"
			Me.AbsoluteInflateMinNumericUpDown.Size = New System.Drawing.Size(65, 20)
			Me.AbsoluteInflateMinNumericUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AbsoluteInflateMinNumericUpDown.ValueChanged += new System.EventHandler(this.AbsoluteInflateMinNumericUpDown_ValueChanged);
			' 
			' InflateViewRangeMinCheckBox
			' 
			Me.InflateViewRangeMinCheckBox.AutoSize = True
			Me.InflateViewRangeMinCheckBox.ButtonProperties.BorderOffset = 2
			Me.InflateViewRangeMinCheckBox.Location = New System.Drawing.Point(15, 69)
			Me.InflateViewRangeMinCheckBox.Name = "InflateViewRangeMinCheckBox"
			Me.InflateViewRangeMinCheckBox.Size = New System.Drawing.Size(75, 17)
			Me.InflateViewRangeMinCheckBox.TabIndex = 2
			Me.InflateViewRangeMinCheckBox.Text = "Inflate Min"
			Me.InflateViewRangeMinCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateViewRangeMinCheckBox.CheckedChanged += new System.EventHandler(this.InflateViewRangeMinCheckBox_CheckedChanged);
			' 
			' InflateViewRangeMaxCheckBox
			' 
			Me.InflateViewRangeMaxCheckBox.AutoSize = True
			Me.InflateViewRangeMaxCheckBox.ButtonProperties.BorderOffset = 2
			Me.InflateViewRangeMaxCheckBox.Location = New System.Drawing.Point(15, 89)
			Me.InflateViewRangeMaxCheckBox.Name = "InflateViewRangeMaxCheckBox"
			Me.InflateViewRangeMaxCheckBox.Size = New System.Drawing.Size(78, 17)
			Me.InflateViewRangeMaxCheckBox.TabIndex = 3
			Me.InflateViewRangeMaxCheckBox.Text = "Inflate Max"
			Me.InflateViewRangeMaxCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateViewRangeMaxCheckBox.CheckedChanged += new System.EventHandler(this.InflateViewRangeMaxCheckBox_CheckedChanged);
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(15, 18)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(130, 13)
			Me.label7.TabIndex = 0
			Me.label7.Text = "View Range Inflate Mode:"
			' 
			' ViewRangeInflateModeComboBox
			' 
			Me.ViewRangeInflateModeComboBox.Location = New System.Drawing.Point(15, 34)
			Me.ViewRangeInflateModeComboBox.Name = "ViewRangeInflateModeComboBox"
			Me.ViewRangeInflateModeComboBox.Size = New System.Drawing.Size(164, 21)
			Me.ViewRangeInflateModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ViewRangeInflateModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ViewRangeInflateModeComboBox_SelectedIndexChanged);
			' 
			' NAxisViewRangeInflateUC
			' 
			Me.Controls.Add(Me.ViewRangeInflateModeComboBox)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.InflateViewRangeMaxCheckBox)
			Me.Controls.Add(Me.InflateViewRangeMinCheckBox)
			Me.Controls.Add(Me.AbsoluteInflateGroupBox)
			Me.Controls.Add(Me.LogicalInflateGroupBox)
			Me.Name = "NAxisViewRangeInflateUC"
			Me.Size = New System.Drawing.Size(192, 394)
			Me.LogicalInflateGroupBox.ResumeLayout(False)
			Me.LogicalInflateGroupBox.PerformLayout()
			DirectCast(Me.LogicalInflateMaxNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.LogicalInflateMinNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.AbsoluteInflateGroupBox.ResumeLayout(False)
			Me.AbsoluteInflateGroupBox.PerformLayout()
			DirectCast(Me.AbsoluteInflateMaxNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.AbsoluteInflateMinNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region


		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As New NLabel("Bank Product and Service Volume Change vs. Last Year<br/> <font size = '9pt'>Demonstrates how to use the view range inflate mode property</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.DockMode = PanelDockMode.Top
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			title.Margins = New NMarginsL(10, 10, 10, 10)

			nChartControl1.Panels.Add(title)

			' add some data to the control
			Dim chart As New NCartesianChart()
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch

			Dim bar As New NBarSeries()
			bar.DataLabelStyle.Visible = False

			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)

			bar.Values.Add(100)
			bar.FillStyles(0) = New NColorFillStyle(palette.SeriesColors(0))

			bar.Values.Add(200)
			bar.FillStyles(1) = New NColorFillStyle(palette.SeriesColors(0))

			bar.Values.Add(1100)
			bar.FillStyles(2) = New NColorFillStyle(palette.SeriesColors(0))

			bar.Values.Add(-200)
			bar.FillStyles(3) = New NColorFillStyle(palette.SeriesColors(1))

			bar.Values.Add(200)
			bar.FillStyles(4) = New NColorFillStyle(palette.SeriesColors(1))

			bar.Values.Add(1800)
			bar.FillStyles(5) = New NColorFillStyle(palette.SeriesColors(1))

			bar.Values.Add(1000)
			bar.FillStyles(6) = New NColorFillStyle(palette.SeriesColors(1))

			bar.Values.Add(-320)
			bar.FillStyles(7) = New NColorFillStyle(palette.SeriesColors(1))

			chart.Series.Add(bar)

			chart.Margins = New NMarginsL(10, 0, 10, 10)

			' configure y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' configure the x axis
			Dim hierarchicalScale As New NHierarchicalScaleConfigurator()
			hierarchicalScale.CreateSeparatorForEachLevel = False

			' create utilization group
			Dim utilization As New NHierarchicalScaleNode(0, "Cash Utilisation")

			utilization.LabelStyle.TickMode = RangeLabelTickMode.Separators
			utilization.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(13)
			utilization.LabelStyle.TextStyle.FontStyle.Style = FontStyle.Bold

			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at ATM", True, False))
			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at desk", True, False))
			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at other banks' ATM networks", True, False))
			hierarchicalScale.Nodes.Add(utilization)

			' create payments group
			Dim payments As New NHierarchicalScaleNode(0, "Payments")

			payments.LabelStyle.TickMode = RangeLabelTickMode.Separators
			payments.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(13)
			payments.LabelStyle.TextStyle.FontStyle.Style = FontStyle.Bold

			payments.ChildNodes.Add(CreateSubScaleNode("Cheque", True, False))
			payments.ChildNodes.Add(CreateSubScaleNode("Direct debit", True, False))
			payments.ChildNodes.Add(CreateSubScaleNode("External wire transfer", True, False))
			payments.ChildNodes.Add(CreateSubScaleNode("Internal wire transfer", True, False))
			payments.ChildNodes.Add(CreateSubScaleNode("Standing order ", True, True))
			hierarchicalScale.Nodes.Add(payments)

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = hierarchicalScale
			nChartControl1.Panels.Add(chart)

			' update form controls			
			Dim yAxis As NAxis = nChartControl1.Charts(0).Axis(StandardAxis.PrimaryY)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NNumericScaleConfigurator = CType(yAxis.ScaleConfigurator, NNumericScaleConfigurator)
			scale_Renamed.Title.Text = "Volume in Thousands USD"

			m_Updating = True

			InflateViewRangeMinCheckBox.Checked = scale_Renamed.InflateViewRangeBegin
			InflateViewRangeMaxCheckBox.Checked = scale_Renamed.InflateViewRangeEnd

			ViewRangeInflateModeComboBox.FillFromEnum(GetType(ScaleViewRangeInflateMode))
			ViewRangeInflateModeComboBox.SelectedIndex = CInt(scale_Renamed.ViewRangeInflateMode)

			LogicalInflateMinNumericUpDown.Value = CDec(scale_Renamed.LogicalInflate.Begin)
			LogicalInflateMaxNumericUpDown.Value = CDec(scale_Renamed.LogicalInflate.End)

			AbsoluteInflateMinNumericUpDown.Value = CDec(scale_Renamed.AbsoluteInflate.Begin.Value)
			AbsoluteInflateMaxNumericUpDown.Value = CDec(scale_Renamed.AbsoluteInflate.End.Value)

			m_Updating = False

			UpdateScale()
		End Sub

		Private Function CreateSubScaleNode(ByVal text As String, ByVal beginSeparator As Boolean, ByVal endSeparator As Boolean) As NHierarchicalScaleNode
			Dim node As New NHierarchicalScaleNode(1, text)

			If beginSeparator AndAlso endSeparator Then
				node.LabelStyle.TickMode = RangeLabelTickMode.Separators
			ElseIf beginSeparator Then
				node.LabelStyle.TickMode = RangeLabelTickMode.BeginSeparator
			ElseIf endSeparator Then
				node.LabelStyle.TickMode = RangeLabelTickMode.EndSeparator
			End If

			Return node
		End Function

		Private Sub UpdateScale()
			If m_Updating Then
				Return
			End If

			m_Updating = True

			Dim yAxis As NAxis = nChartControl1.Charts(0).Axis(StandardAxis.PrimaryY)

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NNumericScaleConfigurator = CType(yAxis.ScaleConfigurator, NNumericScaleConfigurator)

			scale_Renamed.ViewRangeInflateMode = CType(ViewRangeInflateModeComboBox.SelectedIndex, ScaleViewRangeInflateMode)
			scale_Renamed.InflateViewRangeBegin = InflateViewRangeMinCheckBox.Checked
			scale_Renamed.InflateViewRangeEnd = InflateViewRangeMaxCheckBox.Checked

			Select Case scale_Renamed.ViewRangeInflateMode
				Case ScaleViewRangeInflateMode.MajorTick
				Case ScaleViewRangeInflateMode.Logical
					scale_Renamed.LogicalInflate = New NRange1DD(CDbl(LogicalInflateMinNumericUpDown.Value), CDbl(LogicalInflateMaxNumericUpDown.Value))
				Case ScaleViewRangeInflateMode.Absolute
					scale_Renamed.AbsoluteInflate = New NRange1DL(New NLength(CSng(AbsoluteInflateMinNumericUpDown.Value), NGraphicsUnit.Point), New NLength(CSng(AbsoluteInflateMaxNumericUpDown.Value), NGraphicsUnit.Point))
			End Select

			' assign scale configurator to y axis
			yAxis.ScaleConfigurator = scale_Renamed

			' update controls state
			Dim logicalInflate As Boolean = scale_Renamed.ViewRangeInflateMode = ScaleViewRangeInflateMode.Logical
			LogicalInflateMinNumericUpDown.Enabled = logicalInflate
			LogicalInflateMaxNumericUpDown.Enabled = logicalInflate

			Dim absoluteInflate As Boolean = scale_Renamed.ViewRangeInflateMode = ScaleViewRangeInflateMode.Absolute
			AbsoluteInflateMinNumericUpDown.Enabled = absoluteInflate
			AbsoluteInflateMaxNumericUpDown.Enabled = absoluteInflate

			m_Updating = False

			nChartControl1.Refresh()
		End Sub

		Private Sub ViewRangeInflateModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ViewRangeInflateModeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub InflateViewRangeMinCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InflateViewRangeMinCheckBox.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub InflateViewRangeMaxCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InflateViewRangeMaxCheckBox.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub LogicalInflateMinNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LogicalInflateMinNumericUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub LogicalInflateMaxNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LogicalInflateMaxNumericUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub AbsoluteInflateMinNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AbsoluteInflateMinNumericUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub AbsoluteInflateMaxNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AbsoluteInflateMaxNumericUpDown.ValueChanged
			UpdateScale()
		End Sub
	End Class
End Namespace