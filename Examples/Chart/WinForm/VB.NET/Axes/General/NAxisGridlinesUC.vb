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
	Public Class NAxisGridlinesUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LeftMajorCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BottomMajorCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents DepthMajorCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents LeftMinorCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents LeftMajor2Check As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LeftMajor1Check As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents Bottom2Check As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents Bottom1Check As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents Depth2Check As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents Depth1Check As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LeftMinor2Check As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LeftMinor1Check As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BottomColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftMajorColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DepthColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftMinorColor As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private colorDialog1 As Nevron.UI.WinForm.Controls.NColorDialog
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			LeftMajorCombo.FillFromEnum(GetType(LinePattern))
			BottomMajorCombo.FillFromEnum(GetType(LinePattern))
			DepthMajorCombo.FillFromEnum(GetType(LinePattern))
			LeftMinorCombo.FillFromEnum(GetType(LinePattern))
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(NAxisGridlinesUC))
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LeftMajorCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.LeftMajorColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.LeftMajor2Check = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LeftMajor1Check = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomMajorCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BottomColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.Bottom2Check = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.Bottom1Check = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.DepthColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.DepthMajorCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.Depth2Check = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.Depth1Check = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.LeftMinorCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.LeftMinorColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.LeftMinor2Check = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LeftMinor1Check = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.colorDialog1 = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.groupBox4.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftMajorCombo)
			Me.groupBox1.Controls.Add(Me.LeftMajorColor)
			Me.groupBox1.Controls.Add(Me.LeftMajor2Check)
			Me.groupBox1.Controls.Add(Me.LeftMajor1Check)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(7, 9)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(185, 115)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left axis major gridlines"
			' 
			' LeftMajorCombo
			' 
			Me.LeftMajorCombo.Location = New System.Drawing.Point(43, 84)
			Me.LeftMajorCombo.Name = "LeftMajorCombo"
			Me.LeftMajorCombo.Size = New System.Drawing.Size(132, 21)
			Me.LeftMajorCombo.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMajorCombo.SelectedIndexChanged += new System.EventHandler(this.LeftMajorCombo_SelectedIndexChanged);
			' 
			' LeftMajorColor
			' 
			Me.LeftMajorColor.Location = New System.Drawing.Point(7, 58)
			Me.LeftMajorColor.Name = "LeftMajorColor"
			Me.LeftMajorColor.Size = New System.Drawing.Size(168, 22)
			Me.LeftMajorColor.TabIndex = 2
			Me.LeftMajorColor.Text = "Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMajorColor.Click += new System.EventHandler(this.LeftMajorColor_Click);
			' 
			' LeftMajor2Check
			' 
			Me.LeftMajor2Check.ButtonProperties.BorderOffset = 2
			Me.LeftMajor2Check.Location = New System.Drawing.Point(7, 35)
			Me.LeftMajor2Check.Name = "LeftMajor2Check"
			Me.LeftMajor2Check.Size = New System.Drawing.Size(137, 19)
			Me.LeftMajor2Check.TabIndex = 1
			Me.LeftMajor2Check.Text = "Show at back wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMajor2Check.CheckedChanged += new System.EventHandler(this.LeftMajor2Check_CheckedChanged);
			' 
			' LeftMajor1Check
			' 
			Me.LeftMajor1Check.ButtonProperties.BorderOffset = 2
			Me.LeftMajor1Check.Location = New System.Drawing.Point(7, 16)
			Me.LeftMajor1Check.Name = "LeftMajor1Check"
			Me.LeftMajor1Check.Size = New System.Drawing.Size(137, 19)
			Me.LeftMajor1Check.TabIndex = 0
			Me.LeftMajor1Check.Text = "Show at left wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMajor1Check.CheckedChanged += new System.EventHandler(this.LeftMajor1Check_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 89)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(34, 16)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Style:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.BottomMajorCombo)
			Me.groupBox2.Controls.Add(Me.BottomColor)
			Me.groupBox2.Controls.Add(Me.Bottom2Check)
			Me.groupBox2.Controls.Add(Me.Bottom1Check)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(7, 127)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(185, 115)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Bottom axis major lines"
			' 
			' BottomMajorCombo
			' 
			Me.BottomMajorCombo.Location = New System.Drawing.Point(43, 84)
			Me.BottomMajorCombo.Name = "BottomMajorCombo"
			Me.BottomMajorCombo.Size = New System.Drawing.Size(132, 21)
			Me.BottomMajorCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomMajorCombo.SelectedIndexChanged += new System.EventHandler(this.BottomMajorCombo_SelectedIndexChanged);
			' 
			' BottomColor
			' 
			Me.BottomColor.Location = New System.Drawing.Point(7, 58)
			Me.BottomColor.Name = "BottomColor"
			Me.BottomColor.Size = New System.Drawing.Size(168, 22)
			Me.BottomColor.TabIndex = 2
			Me.BottomColor.Text = "Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomColor.Click += new System.EventHandler(this.BottomColor_Click);
			' 
			' Bottom2Check
			' 
			Me.Bottom2Check.ButtonProperties.BorderOffset = 2
			Me.Bottom2Check.Location = New System.Drawing.Point(7, 34)
			Me.Bottom2Check.Name = "Bottom2Check"
			Me.Bottom2Check.Size = New System.Drawing.Size(137, 21)
			Me.Bottom2Check.TabIndex = 1
			Me.Bottom2Check.Text = "Show at back wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bottom2Check.CheckedChanged += new System.EventHandler(this.Bottom2Check_CheckedChanged);
			' 
			' Bottom1Check
			' 
			Me.Bottom1Check.ButtonProperties.BorderOffset = 2
			Me.Bottom1Check.Location = New System.Drawing.Point(7, 15)
			Me.Bottom1Check.Name = "Bottom1Check"
			Me.Bottom1Check.Size = New System.Drawing.Size(137, 19)
			Me.Bottom1Check.TabIndex = 0
			Me.Bottom1Check.Text = "Show at floor"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bottom1Check.CheckedChanged += new System.EventHandler(this.Bottom1Check_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 89)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(34, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Style:"
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.DepthColor)
			Me.groupBox3.Controls.Add(Me.label3)
			Me.groupBox3.Controls.Add(Me.DepthMajorCombo)
			Me.groupBox3.Controls.Add(Me.Depth2Check)
			Me.groupBox3.Controls.Add(Me.Depth1Check)
			Me.groupBox3.ImageIndex = 0
			Me.groupBox3.Location = New System.Drawing.Point(7, 248)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(185, 115)
			Me.groupBox3.TabIndex = 2
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Depth axis major lines"
			' 
			' DepthColor
			' 
			Me.DepthColor.Location = New System.Drawing.Point(7, 58)
			Me.DepthColor.Name = "DepthColor"
			Me.DepthColor.Size = New System.Drawing.Size(168, 22)
			Me.DepthColor.TabIndex = 7
			Me.DepthColor.Text = "Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthColor.Click += new System.EventHandler(this.DepthColor_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 87)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(34, 16)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Style:"
			' 
			' DepthMajorCombo
			' 
			Me.DepthMajorCombo.Location = New System.Drawing.Point(43, 82)
			Me.DepthMajorCombo.Name = "DepthMajorCombo"
			Me.DepthMajorCombo.Size = New System.Drawing.Size(132, 21)
			Me.DepthMajorCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthMajorCombo.SelectedIndexChanged += new System.EventHandler(this.DepthMajorCombo_SelectedIndexChanged);
			' 
			' Depth2Check
			' 
			Me.Depth2Check.ButtonProperties.BorderOffset = 2
			Me.Depth2Check.Location = New System.Drawing.Point(7, 35)
			Me.Depth2Check.Name = "Depth2Check"
			Me.Depth2Check.Size = New System.Drawing.Size(137, 17)
			Me.Depth2Check.TabIndex = 1
			Me.Depth2Check.Text = "Show at left wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Depth2Check.CheckedChanged += new System.EventHandler(this.Depth2Check_CheckedChanged);
			' 
			' Depth1Check
			' 
			Me.Depth1Check.ButtonProperties.BorderOffset = 2
			Me.Depth1Check.Location = New System.Drawing.Point(7, 14)
			Me.Depth1Check.Name = "Depth1Check"
			Me.Depth1Check.Size = New System.Drawing.Size(137, 20)
			Me.Depth1Check.TabIndex = 0
			Me.Depth1Check.Text = "Show at floor"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Depth1Check.CheckedChanged += new System.EventHandler(this.Depth1Check_CheckedChanged);
			' 
			' groupBox4
			' 
			Me.groupBox4.Controls.Add(Me.label4)
			Me.groupBox4.Controls.Add(Me.LeftMinorCombo)
			Me.groupBox4.Controls.Add(Me.LeftMinorColor)
			Me.groupBox4.Controls.Add(Me.LeftMinor2Check)
			Me.groupBox4.Controls.Add(Me.LeftMinor1Check)
			Me.groupBox4.ImageIndex = 0
			Me.groupBox4.Location = New System.Drawing.Point(8, 370)
			Me.groupBox4.Name = "groupBox4"
			Me.groupBox4.Size = New System.Drawing.Size(185, 115)
			Me.groupBox4.TabIndex = 3
			Me.groupBox4.TabStop = False
			Me.groupBox4.Text = "Left axis minor gridlines"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(7, 89)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(33, 16)
			Me.label4.TabIndex = 10
			Me.label4.Text = "Style:"
			' 
			' LeftMinorCombo
			' 
			Me.LeftMinorCombo.Location = New System.Drawing.Point(43, 84)
			Me.LeftMinorCombo.Name = "LeftMinorCombo"
			Me.LeftMinorCombo.Size = New System.Drawing.Size(132, 21)
			Me.LeftMinorCombo.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMinorCombo.SelectedIndexChanged += new System.EventHandler(this.LeftMinorCombo_SelectedIndexChanged);
			' 
			' LeftMinorColor
			' 
			Me.LeftMinorColor.Location = New System.Drawing.Point(7, 58)
			Me.LeftMinorColor.Name = "LeftMinorColor"
			Me.LeftMinorColor.Size = New System.Drawing.Size(168, 22)
			Me.LeftMinorColor.TabIndex = 8
			Me.LeftMinorColor.Text = "Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMinorColor.Click += new System.EventHandler(this.LeftMinorColor_Click);
			' 
			' LeftMinor2Check
			' 
			Me.LeftMinor2Check.ButtonProperties.BorderOffset = 2
			Me.LeftMinor2Check.Location = New System.Drawing.Point(7, 37)
			Me.LeftMinor2Check.Name = "LeftMinor2Check"
			Me.LeftMinor2Check.Size = New System.Drawing.Size(137, 17)
			Me.LeftMinor2Check.TabIndex = 2
			Me.LeftMinor2Check.Text = "Show at back wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMinor2Check.CheckedChanged += new System.EventHandler(this.LeftMinor2Check_CheckedChanged);
			' 
			' LeftMinor1Check
			' 
			Me.LeftMinor1Check.ButtonProperties.BorderOffset = 2
			Me.LeftMinor1Check.Location = New System.Drawing.Point(7, 18)
			Me.LeftMinor1Check.Name = "LeftMinor1Check"
			Me.LeftMinor1Check.Size = New System.Drawing.Size(137, 17)
			Me.LeftMinor1Check.TabIndex = 1
			Me.LeftMinor1Check.Text = "Show at left wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMinor1Check.CheckedChanged += new System.EventHandler(this.LeftMinor1Check_CheckedChanged);
			' 
			' colorDialog1
			' 
			Me.colorDialog1.ClientSize = New System.Drawing.Size(402, 351)
			Me.colorDialog1.Color = System.Drawing.Color.Empty
			Me.colorDialog1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.colorDialog1.Icon = (DirectCast(resources.GetObject("colorDialog1.Icon"), System.Drawing.Icon))
			Me.colorDialog1.Location = New System.Drawing.Point(20, 21)
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
			' NAxisGridlinesUC
			' 
			Me.Controls.Add(Me.groupBox4)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NAxisGridlinesUC"
			Me.Size = New System.Drawing.Size(201, 495)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox4.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region


		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Gridlines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter

			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Height = 28
			m_Chart.Depth = 40
			m_Chart.BoundsMode = BoundsMode.Fit
			m_Chart.Projection.Rotation = -19
			m_Chart.Projection.Elevation = 20
			m_Chart.Projection.Type = ProjectionType.Perspective

			Dim scaleConfigurator As NStandardScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.AutoMinorTicks = False
			scaleConfigurator.MinorTickCount = 3

			Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False
			bar.Values.FillRandomRange(Random, 5, 1, 20)
			bar.WidthPercent = 20
			bar.DepthPercent = 20
			bar.Name = "Series 1"

			bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False
			bar.Values.FillRandomRange(Random, 5, 1, 20)
			bar.WidthPercent = 20
			bar.DepthPercent = 20
			bar.Name = "Series 2"

			bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False
			bar.Values.FillRandomRange(Random, 5, 1, 20)
			bar.WidthPercent = 20
			bar.DepthPercent = 20
			bar.Name = "Series 3"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LeftMajorCombo.SelectedIndex = 0
			LeftMinorCombo.SelectedIndex = 0
			BottomMajorCombo.SelectedIndex = 0
			DepthMajorCombo.SelectedIndex = 0

			Dim leftScale As NStandardScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			leftScale.AutoMinorTicks = True

			Dim bottomScale As NStandardScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			Dim depthScale As NStandardScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NStandardScaleConfigurator)

			LeftMajor1Check.Checked = leftScale.MajorGridStyle.GetShowAtWall(ChartWallType.Left)
			LeftMajor2Check.Checked = leftScale.MajorGridStyle.GetShowAtWall(ChartWallType.Back)

			LeftMinor1Check.Checked = leftScale.MinorGridStyle.GetShowAtWall(ChartWallType.Left)
			LeftMinor2Check.Checked = leftScale.MinorGridStyle.GetShowAtWall(ChartWallType.Back)

			Bottom1Check.Checked = bottomScale.MajorGridStyle.GetShowAtWall(ChartWallType.Floor)
			Bottom2Check.Checked = bottomScale.MinorGridStyle.GetShowAtWall(ChartWallType.Back)

			Depth1Check.Checked = depthScale.MajorGridStyle.GetShowAtWall(ChartWallType.Floor)
			Depth2Check.Checked = depthScale.MinorGridStyle.GetShowAtWall(ChartWallType.Left)
		End Sub

		Private Sub LeftMajor1Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftMajor1Check.CheckedChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, LeftMajor1Check.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftMajor2Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftMajor2Check.CheckedChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, LeftMajor2Check.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub Bottom1Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bottom1Check.CheckedChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, Bottom1Check.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub Bottom2Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bottom2Check.CheckedChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, Bottom2Check.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub Depth1Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Depth1Check.CheckedChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, Depth1Check.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub Depth2Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Depth2Check.CheckedChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, Depth2Check.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftMinor1Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftMinor1Check.CheckedChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MinorGridStyle.SetShowAtWall(ChartWallType.Left, LeftMinor1Check.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftMinor2Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftMinor2Check.CheckedChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MinorGridStyle.SetShowAtWall(ChartWallType.Back, LeftMinor2Check.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftMajorColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftMajorColor.Click
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			colorDialog1.Color = scaleConfigurator.MajorGridStyle.LineStyle.Color
			colorDialog1.ShowDialog()

			scaleConfigurator.MajorGridStyle.LineStyle.Color = colorDialog1.Color
			nChartControl1.Refresh()
		End Sub

		Private Sub BottomColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomColor.Click
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			colorDialog1.Color = scaleConfigurator.MajorGridStyle.LineStyle.Color
			colorDialog1.ShowDialog()

			scaleConfigurator.MajorGridStyle.LineStyle.Color = colorDialog1.Color
			nChartControl1.Refresh()
		End Sub

		Private Sub DepthColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepthColor.Click
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NStandardScaleConfigurator)

			colorDialog1.Color = scaleConfigurator.MajorGridStyle.LineStyle.Color
			colorDialog1.ShowDialog()

			scaleConfigurator.MajorGridStyle.LineStyle.Color = colorDialog1.Color
			nChartControl1.Refresh()
		End Sub

		Private Sub LeftMinorColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftMinorColor.Click
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			colorDialog1.Color = scaleConfigurator.MinorGridStyle.LineStyle.Color
			colorDialog1.ShowDialog()

			scaleConfigurator.MinorGridStyle.LineStyle.Color = colorDialog1.Color
			nChartControl1.Refresh()
		End Sub

		Private Sub LeftMajorCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftMajorCombo.SelectedIndexChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			Dim pattern As LinePattern = GetPatternFromIndex(LeftMajorCombo.SelectedIndex)
			scaleConfigurator.MajorGridStyle.LineStyle.Pattern = pattern

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomMajorCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomMajorCombo.SelectedIndexChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			Dim pattern As LinePattern = GetPatternFromIndex(BottomMajorCombo.SelectedIndex)
			scaleConfigurator.MajorGridStyle.LineStyle.Pattern = pattern

			nChartControl1.Refresh()
		End Sub

		Private Sub DepthMajorCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepthMajorCombo.SelectedIndexChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NStandardScaleConfigurator)
			Dim pattern As LinePattern = GetPatternFromIndex(DepthMajorCombo.SelectedIndex)

			scaleConfigurator.MajorGridStyle.LineStyle.Pattern = pattern

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftMinorCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftMinorCombo.SelectedIndexChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			Dim pattern As LinePattern = GetPatternFromIndex(LeftMinorCombo.SelectedIndex)

			scaleConfigurator.MinorGridStyle.LineStyle.Pattern = pattern

			nChartControl1.Refresh()
		End Sub

		Private Function GetPatternFromIndex(ByVal index As Integer) As LinePattern
			Select Case index
				Case 0
					Return LinePattern.Dot
				Case 1
					Return LinePattern.Dash
				Case 2
					Return LinePattern.DashDot
				Case 3
					Return LinePattern.DashDotDot
				Case 4
					Return LinePattern.Solid
				Case Else
					Return LinePattern.Solid
			End Select
		End Function
	End Class
End Namespace