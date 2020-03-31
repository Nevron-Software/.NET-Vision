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
	Public Class NAxisTicksUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private colorDialog1 As Nevron.UI.WinForm.Controls.NColorDialog
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label6 As System.Windows.Forms.Label
		Private WithEvents OuterMajorTickColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents OuterMajorTickLengthScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ShowOuterMajorTicksCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents ShowInnerMajorTicksCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents InnerMajorTickColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents InnerMajorTickLengthScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label2 As System.Windows.Forms.Label
		Private nGroupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents ShowOuterMinorTicksCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents OuterMinorTickLengthScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents OuterMinorTickColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowInnerMinorTicksCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InnerMinorTickLengthScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents InnerMinorTickColorButton As Nevron.UI.WinForm.Controls.NButton
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
			Dim resources As New System.Resources.ResourceManager(GetType(NAxisTicksUC))
			Me.colorDialog1 = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ShowOuterMajorTicksCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.OuterMajorTickColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.OuterMajorTickLengthScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ShowInnerMajorTicksCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.InnerMajorTickColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.InnerMajorTickLengthScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ShowOuterMinorTicksCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.OuterMinorTickColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.OuterMinorTickLengthScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nGroupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ShowInnerMinorTicksCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.InnerMinorTickColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.InnerMinorTickLengthScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.nGroupBox4.SuspendLayout()
			Me.SuspendLayout()
			' 
			' colorDialog1
			' 
			Me.colorDialog1.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.colorDialog1.ClientSize = New System.Drawing.Size(396, 324)
			Me.colorDialog1.Color = System.Drawing.Color.Empty
			Me.colorDialog1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.colorDialog1.Icon = (DirectCast(resources.GetObject("colorDialog1.Icon"), System.Drawing.Icon))
			Me.colorDialog1.Location = New System.Drawing.Point(88, 88)
			Me.colorDialog1.MaximizeBox = False
			Me.colorDialog1.MinimizeBox = False
			Me.colorDialog1.Name = "colorDialog1"
			Me.colorDialog1.ShowCaptionImage = False
			Me.colorDialog1.ShowInTaskbar = False
			Me.colorDialog1.Sizable = False
			Me.colorDialog1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.colorDialog1.Text = "Edit Color"
			Me.colorDialog1.Visible = False
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.ShowOuterMajorTicksCheckBox)
			Me.nGroupBox1.Controls.Add(Me.label6)
			Me.nGroupBox1.Controls.Add(Me.OuterMajorTickColorButton)
			Me.nGroupBox1.Controls.Add(Me.OuterMajorTickLengthScrollBar)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(5, 6)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(149, 133)
			Me.nGroupBox1.TabIndex = 16
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Major Outer Ticks"
			' 
			' ShowOuterMajorTicksCheckBox
			' 
			Me.ShowOuterMajorTicksCheckBox.Location = New System.Drawing.Point(10, 22)
			Me.ShowOuterMajorTicksCheckBox.Name = "ShowOuterMajorTicksCheckBox"
			Me.ShowOuterMajorTicksCheckBox.Size = New System.Drawing.Size(116, 22)
			Me.ShowOuterMajorTicksCheckBox.TabIndex = 0
			Me.ShowOuterMajorTicksCheckBox.Text = "Show Ticks"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowOuterMajorTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowOuterMajorTicksCheckBox_CheckedChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 48)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(116, 19)
			Me.label6.TabIndex = 1
			Me.label6.Text = "Tick Length:"
			' 
			' OuterMajorTickColorButton
			' 
			Me.OuterMajorTickColorButton.Location = New System.Drawing.Point(8, 96)
			Me.OuterMajorTickColorButton.Name = "OuterMajorTickColorButton"
			Me.OuterMajorTickColorButton.Size = New System.Drawing.Size(125, 22)
			Me.OuterMajorTickColorButton.TabIndex = 3
			Me.OuterMajorTickColorButton.Text = "Tick Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OuterMajorTickColorButton.Click += new System.EventHandler(this.OuterMajorTickColorButton_Click);
			' 
			' OuterMajorTickLengthScrollBar
			' 
			Me.OuterMajorTickLengthScrollBar.LargeChange = 2
			Me.OuterMajorTickLengthScrollBar.Location = New System.Drawing.Point(8, 72)
			Me.OuterMajorTickLengthScrollBar.Maximum = 20
			Me.OuterMajorTickLengthScrollBar.Name = "OuterMajorTickLengthScrollBar"
			Me.OuterMajorTickLengthScrollBar.Size = New System.Drawing.Size(116, 16)
			Me.OuterMajorTickLengthScrollBar.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OuterMajorTickLengthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.OuterMajorTickLengthScrollBar_ValueChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.ShowInnerMajorTicksCheckBox)
			Me.nGroupBox2.Controls.Add(Me.label1)
			Me.nGroupBox2.Controls.Add(Me.InnerMajorTickColorButton)
			Me.nGroupBox2.Controls.Add(Me.InnerMajorTickLengthScrollBar)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(5, 150)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(149, 133)
			Me.nGroupBox2.TabIndex = 17
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Major Inner Ticks"
			' 
			' ShowInnerMajorTicksCheckBox
			' 
			Me.ShowInnerMajorTicksCheckBox.Location = New System.Drawing.Point(10, 22)
			Me.ShowInnerMajorTicksCheckBox.Name = "ShowInnerMajorTicksCheckBox"
			Me.ShowInnerMajorTicksCheckBox.Size = New System.Drawing.Size(116, 22)
			Me.ShowInnerMajorTicksCheckBox.TabIndex = 0
			Me.ShowInnerMajorTicksCheckBox.Text = "Show Ticks"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowInnerMajorTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowInnerMajorTicksCheckBox_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 48)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(116, 19)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Tick Length:"
			' 
			' InnerMajorTickColorButton
			' 
			Me.InnerMajorTickColorButton.Location = New System.Drawing.Point(8, 96)
			Me.InnerMajorTickColorButton.Name = "InnerMajorTickColorButton"
			Me.InnerMajorTickColorButton.Size = New System.Drawing.Size(125, 22)
			Me.InnerMajorTickColorButton.TabIndex = 3
			Me.InnerMajorTickColorButton.Text = "Tick Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InnerMajorTickColorButton.Click += new System.EventHandler(this.InnerMajorTickColorButton_Click);
			' 
			' InnerMajorTickLengthScrollBar
			' 
			Me.InnerMajorTickLengthScrollBar.LargeChange = 2
			Me.InnerMajorTickLengthScrollBar.Location = New System.Drawing.Point(8, 72)
			Me.InnerMajorTickLengthScrollBar.Maximum = 20
			Me.InnerMajorTickLengthScrollBar.Name = "InnerMajorTickLengthScrollBar"
			Me.InnerMajorTickLengthScrollBar.Size = New System.Drawing.Size(116, 16)
			Me.InnerMajorTickLengthScrollBar.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InnerMajorTickLengthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.InnerMajorTickLengthScrollBar_ValueChanged);
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.ShowOuterMinorTicksCheckBox)
			Me.nGroupBox3.Controls.Add(Me.label2)
			Me.nGroupBox3.Controls.Add(Me.OuterMinorTickColorButton)
			Me.nGroupBox3.Controls.Add(Me.OuterMinorTickLengthScrollBar)
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(5, 294)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(149, 133)
			Me.nGroupBox3.TabIndex = 18
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Minor Outer Ticks"
			' 
			' ShowOuterMinorTicksCheckBox
			' 
			Me.ShowOuterMinorTicksCheckBox.Location = New System.Drawing.Point(10, 22)
			Me.ShowOuterMinorTicksCheckBox.Name = "ShowOuterMinorTicksCheckBox"
			Me.ShowOuterMinorTicksCheckBox.Size = New System.Drawing.Size(116, 22)
			Me.ShowOuterMinorTicksCheckBox.TabIndex = 0
			Me.ShowOuterMinorTicksCheckBox.Text = "Show Ticks"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowOuterMinorTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowOuterMinorTicksCheckBox_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(116, 19)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Tick Length:"
			' 
			' OuterMinorTickColorButton
			' 
			Me.OuterMinorTickColorButton.Location = New System.Drawing.Point(8, 96)
			Me.OuterMinorTickColorButton.Name = "OuterMinorTickColorButton"
			Me.OuterMinorTickColorButton.Size = New System.Drawing.Size(125, 22)
			Me.OuterMinorTickColorButton.TabIndex = 3
			Me.OuterMinorTickColorButton.Text = "Tick Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OuterMinorTickColorButton.Click += new System.EventHandler(this.OuterMinorTickColorButton_Click);
			' 
			' OuterMinorTickLengthScrollBar
			' 
			Me.OuterMinorTickLengthScrollBar.LargeChange = 2
			Me.OuterMinorTickLengthScrollBar.Location = New System.Drawing.Point(8, 72)
			Me.OuterMinorTickLengthScrollBar.Maximum = 20
			Me.OuterMinorTickLengthScrollBar.Name = "OuterMinorTickLengthScrollBar"
			Me.OuterMinorTickLengthScrollBar.Size = New System.Drawing.Size(116, 16)
			Me.OuterMinorTickLengthScrollBar.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OuterMinorTickLengthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.OuterMinorTickLengthScrollBar_ValueChanged);
			' 
			' nGroupBox4
			' 
			Me.nGroupBox4.Controls.Add(Me.ShowInnerMinorTicksCheckBox)
			Me.nGroupBox4.Controls.Add(Me.label3)
			Me.nGroupBox4.Controls.Add(Me.InnerMinorTickColorButton)
			Me.nGroupBox4.Controls.Add(Me.InnerMinorTickLengthScrollBar)
			Me.nGroupBox4.ImageIndex = 0
			Me.nGroupBox4.Location = New System.Drawing.Point(5, 438)
			Me.nGroupBox4.Name = "nGroupBox4"
			Me.nGroupBox4.Size = New System.Drawing.Size(149, 133)
			Me.nGroupBox4.TabIndex = 19
			Me.nGroupBox4.TabStop = False
			Me.nGroupBox4.Text = "Minor Inner Ticks"
			' 
			' ShowInnerMinorTicksCheckBox
			' 
			Me.ShowInnerMinorTicksCheckBox.Location = New System.Drawing.Point(10, 22)
			Me.ShowInnerMinorTicksCheckBox.Name = "ShowInnerMinorTicksCheckBox"
			Me.ShowInnerMinorTicksCheckBox.Size = New System.Drawing.Size(116, 22)
			Me.ShowInnerMinorTicksCheckBox.TabIndex = 0
			Me.ShowInnerMinorTicksCheckBox.Text = "Show Ticks"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowInnerMinorTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowInnerMinorTicksCheckBox_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 48)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(116, 19)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Tick Length:"
			' 
			' InnerMinorTickColorButton
			' 
			Me.InnerMinorTickColorButton.Location = New System.Drawing.Point(8, 96)
			Me.InnerMinorTickColorButton.Name = "InnerMinorTickColorButton"
			Me.InnerMinorTickColorButton.Size = New System.Drawing.Size(125, 22)
			Me.InnerMinorTickColorButton.TabIndex = 3
			Me.InnerMinorTickColorButton.Text = "Tick Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InnerMinorTickColorButton.Click += new System.EventHandler(this.InnerMinorTickColorButton_Click);
			' 
			' InnerMinorTickLengthScrollBar
			' 
			Me.InnerMinorTickLengthScrollBar.LargeChange = 2
			Me.InnerMinorTickLengthScrollBar.Location = New System.Drawing.Point(8, 72)
			Me.InnerMinorTickLengthScrollBar.Maximum = 20
			Me.InnerMinorTickLengthScrollBar.Name = "InnerMinorTickLengthScrollBar"
			Me.InnerMinorTickLengthScrollBar.Size = New System.Drawing.Size(116, 16)
			Me.InnerMinorTickLengthScrollBar.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InnerMinorTickLengthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.InnerMinorTickLengthScrollBar_ValueChanged);
			' 
			' NAxisTicksUC
			' 
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox4)
			Me.Controls.Add(Me.nGroupBox3)
			Me.Name = "NAxisTicksUC"
			Me.Size = New System.Drawing.Size(159, 587)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.nGroupBox4.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Ticks")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MinorTickCount = 3

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Values.FillRandom(Random, 5)
			bar.FillStyle = New NColorFillStyle(Color.DarkOrchid)
			bar.DataLabelStyle.Format = "<value>"
			bar.Name = "Bars"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			OuterMajorTickLengthScrollBar.Value = CInt(Math.Truncate(linearScale.OuterMajorTickStyle.Length.Value))
			InnerMajorTickLengthScrollBar.Value = CInt(Math.Truncate(linearScale.InnerMajorTickStyle.Length.Value))
			OuterMinorTickLengthScrollBar.Value = CInt(Math.Truncate(linearScale.OuterMinorTickStyle.Length.Value))
			InnerMinorTickLengthScrollBar.Value = CInt(Math.Truncate(linearScale.InnerMinorTickStyle.Length.Value))

			ShowOuterMajorTicksCheckBox.Checked = True
			ShowInnerMajorTicksCheckBox.Checked = True
			ShowOuterMinorTicksCheckBox.Checked = True
			ShowInnerMinorTicksCheckBox.Checked = True
		End Sub

		Private Sub ShowOuterMajorTicksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowOuterMajorTicksCheckBox.CheckedChanged
            Dim width1 As Integer

            If (ShowOuterMajorTicksCheckBox.Checked) Then
                width1 = OuterMajorTickLengthScrollBar.Value
            Else
                width1 = 0
            End If


            Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
            linearScale.OuterMajorTickStyle.Length = New NLength(width1, linearScale.OuterMajorTickStyle.Length.MeasurementUnit)

            nChartControl1.Refresh()

        End Sub

		Private Sub OuterMajorTickLengthScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles OuterMajorTickLengthScrollBar.ValueChanged
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.OuterMajorTickStyle.Length = New NLength(OuterMajorTickLengthScrollBar.Value, linearScale.OuterMajorTickStyle.Length.MeasurementUnit)

			nChartControl1.Refresh()
		End Sub

		Private Sub OuterMajorTickColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OuterMajorTickColorButton.Click
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			colorDialog1.Color = linearScale.OuterMajorTickStyle.LineStyle.Color

			colorDialog1.ShowDialog()

			linearScale.OuterMajorTickStyle.LineStyle.Color = colorDialog1.Color

			nChartControl1.Refresh()
		End Sub

		Private Sub ShowInnerMajorTicksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowInnerMajorTicksCheckBox.CheckedChanged
            Dim width1 As Integer

            If (ShowInnerMajorTicksCheckBox.Checked) Then
                width1 = InnerMajorTickLengthScrollBar.Value
            Else
                width1 = 0
            End If

            Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
            linearScale.InnerMajorTickStyle.Length = New NLength(width1, linearScale.InnerMajorTickStyle.Length.MeasurementUnit)

            nChartControl1.Refresh()
        End Sub

		Private Sub InnerMajorTickLengthScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles InnerMajorTickLengthScrollBar.ValueChanged
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.InnerMajorTickStyle.Length = New NLength(InnerMajorTickLengthScrollBar.Value, linearScale.InnerMajorTickStyle.Length.MeasurementUnit)

			nChartControl1.Refresh()
		End Sub

		Private Sub InnerMajorTickColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InnerMajorTickColorButton.Click
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			colorDialog1.Color = linearScale.InnerMajorTickStyle.LineStyle.Color

			colorDialog1.ShowDialog()
			linearScale.InnerMajorTickStyle.LineStyle.Color = colorDialog1.Color

			nChartControl1.Refresh()
		End Sub

		Private Sub ShowOuterMinorTicksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowOuterMinorTicksCheckBox.CheckedChanged
            Dim width1 As Integer

            If (ShowOuterMinorTicksCheckBox.Checked) Then
                width1 = OuterMinorTickLengthScrollBar.Value
            Else
                width1 = 0
            End If

            Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
            linearScale.OuterMinorTickStyle.Length = New NLength(width1, linearScale.OuterMinorTickStyle.Length.MeasurementUnit)

            nChartControl1.Refresh()
        End Sub

		Private Sub OuterMinorTickLengthScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles OuterMinorTickLengthScrollBar.ValueChanged
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.OuterMinorTickStyle.Length = New NLength(OuterMinorTickLengthScrollBar.Value, linearScale.OuterMinorTickStyle.Length.MeasurementUnit)

			nChartControl1.Refresh()
		End Sub

		Private Sub OuterMinorTickColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OuterMinorTickColorButton.Click
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			colorDialog1.Color = linearScale.OuterMinorTickStyle.LineStyle.Color

			colorDialog1.ShowDialog()

			linearScale.OuterMinorTickStyle.LineStyle.Color = colorDialog1.Color

			nChartControl1.Refresh()
		End Sub

		Private Sub ShowInnerMinorTicksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowInnerMinorTicksCheckBox.CheckedChanged
            Dim width1 As Integer

            If (ShowInnerMinorTicksCheckBox.Checked) Then
                width1 = InnerMinorTickLengthScrollBar.Value
            Else
                width1 = 0
            End If

            Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
            linearScale.InnerMinorTickStyle.Length = New NLength(width1, linearScale.InnerMinorTickStyle.Length.MeasurementUnit)

            nChartControl1.Refresh()
        End Sub

		Private Sub InnerMinorTickLengthScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles InnerMinorTickLengthScrollBar.ValueChanged
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.InnerMinorTickStyle.Length = New NLength(InnerMinorTickLengthScrollBar.Value, linearScale.InnerMinorTickStyle.Length.MeasurementUnit)

			nChartControl1.Refresh()
		End Sub

		Private Sub InnerMinorTickColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InnerMinorTickColorButton.Click
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			colorDialog1.Color = linearScale.InnerMinorTickStyle.LineStyle.Color

			colorDialog1.ShowDialog()

			linearScale.InnerMinorTickStyle.LineStyle.Color = colorDialog1.Color

			nChartControl1.Refresh()
		End Sub


	End Class
End Namespace
