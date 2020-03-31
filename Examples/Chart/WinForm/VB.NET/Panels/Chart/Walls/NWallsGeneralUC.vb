Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NWallsGeneralUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LeftVisibleCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BackVisibleCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RightVisibleCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents FloorVisibleCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LeftBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BackBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RightBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FloorBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftFillButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BackFillButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RightFillButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FloorFillButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftWidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BackWidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents RightWidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents FloorWidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
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
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LeftBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LeftFillButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LeftWidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.LeftVisibleCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BackBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BackFillButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BackWidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.BackVisibleCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.RightBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RightFillButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RightWidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label3 = New System.Windows.Forms.Label()
			Me.RightVisibleCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.FloorBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.FloorFillButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.FloorWidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label4 = New System.Windows.Forms.Label()
			Me.FloorVisibleCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.groupBox4.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftBorderButton)
			Me.groupBox1.Controls.Add(Me.LeftFillButton)
			Me.groupBox1.Controls.Add(Me.LeftWidthScroll)
			Me.groupBox1.Controls.Add(Me.LeftVisibleCheck)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(6, 6)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(171, 135)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Wall"
			' 
			' LeftBorderButton
			' 
			Me.LeftBorderButton.Location = New System.Drawing.Point(8, 106)
			Me.LeftBorderButton.Name = "LeftBorderButton"
			Me.LeftBorderButton.Size = New System.Drawing.Size(153, 21)
			Me.LeftBorderButton.TabIndex = 4
			Me.LeftBorderButton.Text = "Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftBorderButton.Click += new System.EventHandler(this.LeftBorderButton_Click);
			' 
			' LeftFillButton
			' 
			Me.LeftFillButton.Location = New System.Drawing.Point(8, 80)
			Me.LeftFillButton.Name = "LeftFillButton"
			Me.LeftFillButton.Size = New System.Drawing.Size(153, 21)
			Me.LeftFillButton.TabIndex = 3
			Me.LeftFillButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftFillButton.Click += new System.EventHandler(this.LeftFillButton_Click);
			' 
			' LeftWidthScroll
			' 
			Me.LeftWidthScroll.Location = New System.Drawing.Point(8, 59)
			Me.LeftWidthScroll.Maximum = 110
			Me.LeftWidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftWidthScroll.Name = "LeftWidthScroll"
			Me.LeftWidthScroll.Size = New System.Drawing.Size(153, 16)
			Me.LeftWidthScroll.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftWidthScroll_Scroll);
			' 
			' LeftVisibleCheck
			' 
			Me.LeftVisibleCheck.ButtonProperties.BorderOffset = 2
			Me.LeftVisibleCheck.Location = New System.Drawing.Point(8, 17)
			Me.LeftVisibleCheck.Name = "LeftVisibleCheck"
			Me.LeftVisibleCheck.Size = New System.Drawing.Size(153, 21)
			Me.LeftVisibleCheck.TabIndex = 0
			Me.LeftVisibleCheck.Text = "Visible"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftVisibleCheck.CheckedChanged += new System.EventHandler(this.LeftVisibleCheck_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 42)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(153, 14)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Width:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.BackBorderButton)
			Me.groupBox2.Controls.Add(Me.BackFillButton)
			Me.groupBox2.Controls.Add(Me.BackWidthScroll)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.BackVisibleCheck)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(6, 147)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(171, 135)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Back Wall"
			' 
			' BackBorderButton
			' 
			Me.BackBorderButton.Location = New System.Drawing.Point(8, 106)
			Me.BackBorderButton.Name = "BackBorderButton"
			Me.BackBorderButton.Size = New System.Drawing.Size(153, 21)
			Me.BackBorderButton.TabIndex = 4
			Me.BackBorderButton.Text = "Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BackBorderButton.Click += new System.EventHandler(this.BackBorderButton_Click);
			' 
			' BackFillButton
			' 
			Me.BackFillButton.Location = New System.Drawing.Point(8, 80)
			Me.BackFillButton.Name = "BackFillButton"
			Me.BackFillButton.Size = New System.Drawing.Size(153, 21)
			Me.BackFillButton.TabIndex = 3
			Me.BackFillButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BackFillButton.Click += new System.EventHandler(this.BackFillButton_Click);
			' 
			' BackWidthScroll
			' 
			Me.BackWidthScroll.Location = New System.Drawing.Point(8, 59)
			Me.BackWidthScroll.Maximum = 110
			Me.BackWidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BackWidthScroll.Name = "BackWidthScroll"
			Me.BackWidthScroll.Size = New System.Drawing.Size(153, 16)
			Me.BackWidthScroll.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BackWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BackWidthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 42)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(116, 14)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Width:"
			' 
			' BackVisibleCheck
			' 
			Me.BackVisibleCheck.ButtonProperties.BorderOffset = 2
			Me.BackVisibleCheck.Location = New System.Drawing.Point(8, 17)
			Me.BackVisibleCheck.Name = "BackVisibleCheck"
			Me.BackVisibleCheck.Size = New System.Drawing.Size(116, 21)
			Me.BackVisibleCheck.TabIndex = 0
			Me.BackVisibleCheck.Text = "Visible"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BackVisibleCheck.CheckedChanged += new System.EventHandler(this.BackVisibleCheck_CheckedChanged);
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.RightBorderButton)
			Me.groupBox3.Controls.Add(Me.RightFillButton)
			Me.groupBox3.Controls.Add(Me.RightWidthScroll)
			Me.groupBox3.Controls.Add(Me.label3)
			Me.groupBox3.Controls.Add(Me.RightVisibleCheck)
			Me.groupBox3.ImageIndex = 0
			Me.groupBox3.Location = New System.Drawing.Point(6, 288)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(171, 135)
			Me.groupBox3.TabIndex = 2
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Right Wall"
			' 
			' RightBorderButton
			' 
			Me.RightBorderButton.Location = New System.Drawing.Point(8, 106)
			Me.RightBorderButton.Name = "RightBorderButton"
			Me.RightBorderButton.Size = New System.Drawing.Size(153, 21)
			Me.RightBorderButton.TabIndex = 4
			Me.RightBorderButton.Text = "Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RightBorderButton.Click += new System.EventHandler(this.RightBorderButton_Click);
			' 
			' RightFillButton
			' 
			Me.RightFillButton.Location = New System.Drawing.Point(8, 80)
			Me.RightFillButton.Name = "RightFillButton"
			Me.RightFillButton.Size = New System.Drawing.Size(153, 21)
			Me.RightFillButton.TabIndex = 3
			Me.RightFillButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RightFillButton.Click += new System.EventHandler(this.RightFillButton_Click);
			' 
			' RightWidthScroll
			' 
			Me.RightWidthScroll.Location = New System.Drawing.Point(8, 59)
			Me.RightWidthScroll.Maximum = 110
			Me.RightWidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.RightWidthScroll.Name = "RightWidthScroll"
			Me.RightWidthScroll.Size = New System.Drawing.Size(153, 16)
			Me.RightWidthScroll.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RightWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RightWidthScroll_Scroll);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 42)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(116, 14)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Width:"
			' 
			' RightVisibleCheck
			' 
			Me.RightVisibleCheck.ButtonProperties.BorderOffset = 2
			Me.RightVisibleCheck.Location = New System.Drawing.Point(8, 17)
			Me.RightVisibleCheck.Name = "RightVisibleCheck"
			Me.RightVisibleCheck.Size = New System.Drawing.Size(116, 21)
			Me.RightVisibleCheck.TabIndex = 0
			Me.RightVisibleCheck.Text = "Visible"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RightVisibleCheck.CheckedChanged += new System.EventHandler(this.RightVisibleCheck_CheckedChanged);
			' 
			' groupBox4
			' 
			Me.groupBox4.Controls.Add(Me.FloorBorderButton)
			Me.groupBox4.Controls.Add(Me.FloorFillButton)
			Me.groupBox4.Controls.Add(Me.FloorWidthScroll)
			Me.groupBox4.Controls.Add(Me.label4)
			Me.groupBox4.Controls.Add(Me.FloorVisibleCheck)
			Me.groupBox4.ImageIndex = 0
			Me.groupBox4.Location = New System.Drawing.Point(6, 429)
			Me.groupBox4.Name = "groupBox4"
			Me.groupBox4.Size = New System.Drawing.Size(171, 135)
			Me.groupBox4.TabIndex = 3
			Me.groupBox4.TabStop = False
			Me.groupBox4.Text = "Floor Wall"
			' 
			' FloorBorderButton
			' 
			Me.FloorBorderButton.Location = New System.Drawing.Point(8, 106)
			Me.FloorBorderButton.Name = "FloorBorderButton"
			Me.FloorBorderButton.Size = New System.Drawing.Size(153, 21)
			Me.FloorBorderButton.TabIndex = 4
			Me.FloorBorderButton.Text = "Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FloorBorderButton.Click += new System.EventHandler(this.FloorBorderButton_Click);
			' 
			' FloorFillButton
			' 
			Me.FloorFillButton.Location = New System.Drawing.Point(8, 80)
			Me.FloorFillButton.Name = "FloorFillButton"
			Me.FloorFillButton.Size = New System.Drawing.Size(153, 21)
			Me.FloorFillButton.TabIndex = 3
			Me.FloorFillButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FloorFillButton.Click += new System.EventHandler(this.FloorFillButton_Click);
			' 
			' FloorWidthScroll
			' 
			Me.FloorWidthScroll.Location = New System.Drawing.Point(8, 59)
			Me.FloorWidthScroll.Maximum = 110
			Me.FloorWidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.FloorWidthScroll.Name = "FloorWidthScroll"
			Me.FloorWidthScroll.Size = New System.Drawing.Size(153, 16)
			Me.FloorWidthScroll.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FloorWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FloorWidthScroll_Scroll);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 42)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(116, 14)
			Me.label4.TabIndex = 1
			Me.label4.Text = "Width:"
			' 
			' FloorVisibleCheck
			' 
			Me.FloorVisibleCheck.ButtonProperties.BorderOffset = 2
			Me.FloorVisibleCheck.Location = New System.Drawing.Point(8, 17)
			Me.FloorVisibleCheck.Name = "FloorVisibleCheck"
			Me.FloorVisibleCheck.Size = New System.Drawing.Size(116, 21)
			Me.FloorVisibleCheck.TabIndex = 0
			Me.FloorVisibleCheck.Text = "Visible"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FloorVisibleCheck.CheckedChanged += new System.EventHandler(this.FloorVisibleCheck_CheckedChanged);
			' 
			' NWallsGeneralUC
			' 
			Me.Controls.Add(Me.groupBox4)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NWallsGeneralUC"
			Me.Size = New System.Drawing.Size(180, 572)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox4.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			nChartControl1.Legends.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Chart Walls")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True

			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Values.FillRandom(Random, 6)
			bar.Name = "Bars"
			bar.DataLabelStyle.Visible = False

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LeftVisibleCheck.Checked = m_Chart.Wall(ChartWallType.Left).Visible
			BackVisibleCheck.Checked = m_Chart.Wall(ChartWallType.Back).Visible
			RightVisibleCheck.Checked = m_Chart.Wall(ChartWallType.Right).Visible
			FloorVisibleCheck.Checked = m_Chart.Wall(ChartWallType.Floor).Visible

			LeftWidthScroll.Value = 20
			BackWidthScroll.Value = 20
			RightWidthScroll.Value = 20
			FloorWidthScroll.Value = 20
		End Sub

		Private Sub LeftVisibleCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftVisibleCheck.CheckedChanged
			m_Chart.Wall(ChartWallType.Left).Visible = LeftVisibleCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub BackVisibleCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackVisibleCheck.CheckedChanged
			m_Chart.Wall(ChartWallType.Back).Visible = BackVisibleCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub RightVisibleCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RightVisibleCheck.CheckedChanged
			m_Chart.Wall(ChartWallType.Right).Visible = RightVisibleCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub FloorVisibleCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FloorVisibleCheck.CheckedChanged
			m_Chart.Wall(ChartWallType.Floor).Visible = FloorVisibleCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub LeftWidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftWidthScroll.ValueChanged
			m_Chart.Wall(ChartWallType.Left).Width = CSng(LeftWidthScroll.Value) / 10.0F
			nChartControl1.Refresh()
		End Sub

		Private Sub BackWidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BackWidthScroll.ValueChanged
			m_Chart.Wall(ChartWallType.Back).Width = CSng(BackWidthScroll.Value) / 10.0F
			nChartControl1.Refresh()
		End Sub

		Private Sub RightWidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles RightWidthScroll.ValueChanged
			m_Chart.Wall(ChartWallType.Right).Width = CSng(RightWidthScroll.Value) / 10.0F
			nChartControl1.Refresh()
		End Sub

		Private Sub FloorWidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles FloorWidthScroll.ValueChanged
			m_Chart.Wall(ChartWallType.Floor).Width = CSng(FloorWidthScroll.Value) / 10.0F
			nChartControl1.Refresh()
		End Sub

		Private Sub LeftFillButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftFillButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Left).FillStyle, fillStyleResult) Then
				m_Chart.Wall(ChartWallType.Left).FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BackFillButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackFillButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Back).FillStyle, fillStyleResult) Then
				m_Chart.Wall(ChartWallType.Back).FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RightFillButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RightFillButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Right).FillStyle, fillStyleResult) Then
				m_Chart.Wall(ChartWallType.Right).FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub FloorFillButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FloorFillButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Floor).FillStyle, fillStyleResult) Then
				m_Chart.Wall(ChartWallType.Floor).FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LeftBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Left).BorderStyle, strokeStyleResult) Then
				m_Chart.Wall(ChartWallType.Left).BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BackBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Back).BorderStyle, strokeStyleResult) Then
				m_Chart.Wall(ChartWallType.Back).BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RightBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RightBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Right).BorderStyle, strokeStyleResult) Then
				m_Chart.Wall(ChartWallType.Right).BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub FloorBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FloorBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Floor).BorderStyle, strokeStyleResult) Then
				m_Chart.Wall(ChartWallType.Floor).BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
