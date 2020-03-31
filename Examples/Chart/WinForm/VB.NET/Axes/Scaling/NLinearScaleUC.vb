Imports System
Imports System.Resources
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Collections
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLinearScaleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Line As NLineSeries
		Private m_Updating As Boolean
		Private WithEvents AutoMaxCountRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents AutoMinDistanceRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents CustomStepRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents CustomStepsRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents CustomTicksRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents MaxCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents MinDistanceUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents CustomStepUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents GenerateRandomDataButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			m_Updating = True

			' This call is required by the Windows.Forms Form Designer.
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
			Me.AutoMaxCountRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.AutoMinDistanceRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.CustomStepRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.CustomStepsRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.CustomTicksRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.MaxCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.MinDistanceUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.CustomStepUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.GenerateRandomDataButton = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.MaxCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.MinDistanceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.CustomStepUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' AutoMaxCountRadioButton
			' 
			Me.AutoMaxCountRadioButton.Location = New System.Drawing.Point(11, 21)
			Me.AutoMaxCountRadioButton.Name = "AutoMaxCountRadioButton"
			Me.AutoMaxCountRadioButton.TabIndex = 0
			Me.AutoMaxCountRadioButton.Text = "AutoMaxCount"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AutoMaxCountRadioButton.CheckedChanged += new System.EventHandler(this.AutoMaxCountRadioButton_CheckedChanged);
			' 
			' AutoMinDistanceRadioButton
			' 
			Me.AutoMinDistanceRadioButton.Location = New System.Drawing.Point(9, 78)
			Me.AutoMinDistanceRadioButton.Name = "AutoMinDistanceRadioButton"
			Me.AutoMinDistanceRadioButton.Size = New System.Drawing.Size(135, 24)
			Me.AutoMinDistanceRadioButton.TabIndex = 3
			Me.AutoMinDistanceRadioButton.Text = "AutoMinDistance"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AutoMinDistanceRadioButton.CheckedChanged += new System.EventHandler(this.AutoMinDistanceRadioButton_CheckedChanged);
			' 
			' CustomStepRadioButton
			' 
			Me.CustomStepRadioButton.Location = New System.Drawing.Point(7, 135)
			Me.CustomStepRadioButton.Name = "CustomStepRadioButton"
			Me.CustomStepRadioButton.Size = New System.Drawing.Size(135, 24)
			Me.CustomStepRadioButton.TabIndex = 7
			Me.CustomStepRadioButton.Text = "Custom Step"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomStepRadioButton.CheckedChanged += new System.EventHandler(this.CustomStepRadioButton_CheckedChanged);
			' 
			' CustomStepsRadioButton
			' 
			Me.CustomStepsRadioButton.Location = New System.Drawing.Point(8, 196)
			Me.CustomStepsRadioButton.Name = "CustomStepsRadioButton"
			Me.CustomStepsRadioButton.Size = New System.Drawing.Size(135, 24)
			Me.CustomStepsRadioButton.TabIndex = 10
			Me.CustomStepsRadioButton.Text = "Custom Steps"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomStepsRadioButton.CheckedChanged += new System.EventHandler(this.CustomStepsRadioButton_CheckedChanged);
			' 
			' CustomTicksRadioButton
			' 
			Me.CustomTicksRadioButton.Location = New System.Drawing.Point(7, 224)
			Me.CustomTicksRadioButton.Name = "CustomTicksRadioButton"
			Me.CustomTicksRadioButton.Size = New System.Drawing.Size(135, 24)
			Me.CustomTicksRadioButton.TabIndex = 11
			Me.CustomTicksRadioButton.Text = "Custom Ticks"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomTicksRadioButton.CheckedChanged += new System.EventHandler(this.CustomTicksRadioButton_CheckedChanged);
			' 
			' MaxCountUpDown
			' 
			Me.MaxCountUpDown.Location = New System.Drawing.Point(103, 46)
			Me.MaxCountUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.MaxCountUpDown.Name = "MaxCountUpDown"
			Me.MaxCountUpDown.Size = New System.Drawing.Size(66, 20)
			Me.MaxCountUpDown.TabIndex = 2
			Me.MaxCountUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaxCountUpDown.ValueChanged += new System.EventHandler(this.MaxCountUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(11, 41)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(82, 23)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Max Count:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(11, 100)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(82, 23)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Min Distance:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' MinDistanceUpDown
			' 
			Me.MinDistanceUpDown.Location = New System.Drawing.Point(103, 105)
			Me.MinDistanceUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.MinDistanceUpDown.Name = "MinDistanceUpDown"
			Me.MinDistanceUpDown.Size = New System.Drawing.Size(66, 20)
			Me.MinDistanceUpDown.TabIndex = 5
			Me.MinDistanceUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinDistanceUpDown.ValueChanged += new System.EventHandler(this.MinDistanceUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(173, 100)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(17, 23)
			Me.label4.TabIndex = 6
			Me.label4.Text = "pt"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(11, 159)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(78, 23)
			Me.label5.TabIndex = 8
			Me.label5.Text = "Custom Step:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' CustomStepUpDown
			' 
			Me.CustomStepUpDown.Location = New System.Drawing.Point(103, 164)
			Me.CustomStepUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.CustomStepUpDown.Name = "CustomStepUpDown"
			Me.CustomStepUpDown.Size = New System.Drawing.Size(66, 20)
			Me.CustomStepUpDown.TabIndex = 9
			Me.CustomStepUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomStepUpDown.ValueChanged += new System.EventHandler(this.CustomStepUpDown_ValueChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.CustomTicksRadioButton)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.CustomStepsRadioButton)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.CustomStepUpDown)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.CustomStepRadioButton)
			Me.groupBox1.Controls.Add(Me.AutoMinDistanceRadioButton)
			Me.groupBox1.Controls.Add(Me.AutoMaxCountRadioButton)
			Me.groupBox1.Controls.Add(Me.MinDistanceUpDown)
			Me.groupBox1.Controls.Add(Me.MaxCountUpDown)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(205, 260)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Major Tick Modes"
			' 
			' GenerateRandomDataButton
			' 
			Me.GenerateRandomDataButton.Location = New System.Drawing.Point(4, 269)
			Me.GenerateRandomDataButton.Name = "GenerateRandomDataButton"
			Me.GenerateRandomDataButton.Size = New System.Drawing.Size(199, 23)
			Me.GenerateRandomDataButton.TabIndex = 1
			Me.GenerateRandomDataButton.Text = "Generate Random Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateRandomDataButton.Click += new System.EventHandler(this.GenerateRandomDataButton_Click);
			' 
			' NLinearScaleUC
			' 
			Me.Controls.Add(Me.GenerateRandomDataButton)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NLinearScaleUC"
			Me.Size = New System.Drawing.Size(205, 304)
			DirectCast(Me.MaxCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.MinDistanceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.CustomStepUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Linear Scale")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' configure the y axis
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' add a strip line style
			Dim stripStyle As New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Legend.Mode = SeriesLegendMode.None
			m_Line.InflateMargins = False
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.PointShape = PointShape.Ellipse
			m_Line.MarkerStyle.Width = New NLength(5, NGraphicsUnit.Point)
			m_Line.MarkerStyle.Height = New NLength(5, NGraphicsUnit.Point)
			m_Line.MarkerStyle.AutoDepth = True
			m_Line.DataLabelStyle.Format = "<value>"
			m_Line.DataLabelStyle.ArrowStrokeStyle.Color = Color.CornflowerBlue

			m_Line.Values.FillRandomRange(Random, 10, 0, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' update controls
			AutoMinDistanceRadioButton.Checked = True
			MaxCountUpDown.Value = CDec(linearScale.MaxTickCount)
			MinDistanceUpDown.Value = CDec(linearScale.MinTickDistance.Value)
			CustomStepUpDown.Value = CDec(linearScale.CustomStep)

			m_Updating = False

			UpdateScale()
		End Sub

		Private Sub UpdateScale()
			If m_Updating Then
				Return
			End If

			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			If linearScale Is Nothing Then
				Return
			End If

			linearScale.MaxTickCount = CInt(Math.Truncate(MaxCountUpDown.Value))
			linearScale.MinTickDistance = New NLength(CSng(MinDistanceUpDown.Value), NGraphicsUnit.Point)
			linearScale.CustomStep = CDbl(CustomStepUpDown.Value)

			' update the custom ticks to match the values of the line series
			Dim values(m_Line.Values.Count - 1) As Double
			m_Line.Values.CopyTo(values, 0)
			linearScale.CustomMajorTicks = New NDoubleList(values)

			linearScale.CustomSteps.Clear()
			linearScale.CustomSteps.Add(10)
			linearScale.CustomSteps.Add(20)

			If AutoMaxCountRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.AutoMaxCount
			ElseIf AutoMinDistanceRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.AutoMinDistance
			ElseIf CustomStepRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.CustomStep
			ElseIf CustomStepsRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.CustomSteps
			ElseIf CustomTicksRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.CustomTicks
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub MaxCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaxCountUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub MinDistanceUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinDistanceUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub CustomStepUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomStepUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub AutoMaxCountRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoMaxCountRadioButton.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub AutoMinDistanceRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoMinDistanceRadioButton.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub CustomStepRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomStepRadioButton.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub CustomStepsRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomStepsRadioButton.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub CustomTicksRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomTicksRadioButton.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub GenerateRandomDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateRandomDataButton.Click
			m_Line.Values.FillRandomRange(Random, 10, 0, 100)

			UpdateScale()
		End Sub
	End Class
End Namespace
