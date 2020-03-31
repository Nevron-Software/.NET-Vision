Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Editors
Imports Nevron.GraphicsCore


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStripesUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents LeftBeginScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftEndScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftShowAtBackCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LeftShowAtLeftCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents BottomShowAtFloorCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BottomShowAtBackCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BottomFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BottomEndScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomBeginScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftIncludeInAxisRangeCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents BottomIncludeInAxisRangeCheckBox As UI.WinForm.Controls.NCheckBox
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
			Me.LeftBeginScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.LeftShowAtLeftCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LeftShowAtBackCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LeftFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LeftEndScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.BottomShowAtFloorCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BottomShowAtBackCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BottomFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BottomEndScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BottomBeginScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.LeftIncludeInAxisRangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BottomIncludeInAxisRangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' LeftBeginScroll
			' 
			Me.LeftBeginScroll.Location = New System.Drawing.Point(9, 45)
			Me.LeftBeginScroll.Maximum = 130
			Me.LeftBeginScroll.Minimum = -20
			Me.LeftBeginScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftBeginScroll.Name = "LeftBeginScroll"
			Me.LeftBeginScroll.Size = New System.Drawing.Size(128, 16)
			Me.LeftBeginScroll.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftBeginScroll_Scroll);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftIncludeInAxisRangeCheckBox)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.LeftShowAtLeftCheck)
			Me.groupBox1.Controls.Add(Me.LeftShowAtBackCheck)
			Me.groupBox1.Controls.Add(Me.LeftFillStyleButton)
			Me.groupBox1.Controls.Add(Me.LeftEndScroll)
			Me.groupBox1.Controls.Add(Me.LeftBeginScroll)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(8, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(151, 220)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Axis Stripe"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 66)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(128, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "End Value:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 23)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(128, 17)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Begin Value:"
			' 
			' LeftShowAtLeftCheck
			' 
			Me.LeftShowAtLeftCheck.ButtonProperties.BorderOffset = 2
			Me.LeftShowAtLeftCheck.Location = New System.Drawing.Point(9, 185)
			Me.LeftShowAtLeftCheck.Name = "LeftShowAtLeftCheck"
			Me.LeftShowAtLeftCheck.Size = New System.Drawing.Size(128, 18)
			Me.LeftShowAtLeftCheck.TabIndex = 4
			Me.LeftShowAtLeftCheck.Text = "Show At Left Wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftShowAtLeftCheck.CheckedChanged += new System.EventHandler(this.LeftShowAtLeftCheck_CheckedChanged);
			' 
			' LeftShowAtBackCheck
			' 
			Me.LeftShowAtBackCheck.ButtonProperties.BorderOffset = 2
			Me.LeftShowAtBackCheck.Location = New System.Drawing.Point(9, 160)
			Me.LeftShowAtBackCheck.Name = "LeftShowAtBackCheck"
			Me.LeftShowAtBackCheck.Size = New System.Drawing.Size(128, 20)
			Me.LeftShowAtBackCheck.TabIndex = 3
			Me.LeftShowAtBackCheck.Text = "Show At Back Wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftShowAtBackCheck.CheckedChanged += new System.EventHandler(this.LeftShowAtBackCheck_CheckedChanged);
			' 
			' LeftFillStyleButton
			' 
			Me.LeftFillStyleButton.Location = New System.Drawing.Point(9, 133)
			Me.LeftFillStyleButton.Name = "LeftFillStyleButton"
			Me.LeftFillStyleButton.Size = New System.Drawing.Size(128, 22)
			Me.LeftFillStyleButton.TabIndex = 2
			Me.LeftFillStyleButton.Text = "Stripe Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftFillStyleButton.Click += new System.EventHandler(this.LeftFillStyleButton_Click);
			' 
			' LeftEndScroll
			' 
			Me.LeftEndScroll.Location = New System.Drawing.Point(9, 87)
			Me.LeftEndScroll.Maximum = 130
			Me.LeftEndScroll.Minimum = -20
			Me.LeftEndScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftEndScroll.Name = "LeftEndScroll"
			Me.LeftEndScroll.Size = New System.Drawing.Size(128, 16)
			Me.LeftEndScroll.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftEndScroll_Scroll);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.BottomIncludeInAxisRangeCheckBox)
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.BottomShowAtFloorCheck)
			Me.groupBox2.Controls.Add(Me.BottomShowAtBackCheck)
			Me.groupBox2.Controls.Add(Me.BottomFillStyleButton)
			Me.groupBox2.Controls.Add(Me.BottomEndScroll)
			Me.groupBox2.Controls.Add(Me.BottomBeginScroll)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(8, 235)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(151, 220)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Bottom Axis Stripe"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 80)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(69, 16)
			Me.label3.TabIndex = 13
			Me.label3.Text = "End Value:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(9, 23)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(71, 17)
			Me.label4.TabIndex = 12
			Me.label4.Text = "Begin Value:"
			' 
			' BottomShowAtFloorCheck
			' 
			Me.BottomShowAtFloorCheck.ButtonProperties.BorderOffset = 2
			Me.BottomShowAtFloorCheck.Location = New System.Drawing.Point(9, 187)
			Me.BottomShowAtFloorCheck.Name = "BottomShowAtFloorCheck"
			Me.BottomShowAtFloorCheck.Size = New System.Drawing.Size(129, 19)
			Me.BottomShowAtFloorCheck.TabIndex = 11
			Me.BottomShowAtFloorCheck.Text = "Show At Floor"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomShowAtFloorCheck.CheckedChanged += new System.EventHandler(this.BottomShowAtFloorCheck_CheckedChanged);
			' 
			' BottomShowAtBackCheck
			' 
			Me.BottomShowAtBackCheck.ButtonProperties.BorderOffset = 2
			Me.BottomShowAtBackCheck.Location = New System.Drawing.Point(9, 159)
			Me.BottomShowAtBackCheck.Name = "BottomShowAtBackCheck"
			Me.BottomShowAtBackCheck.Size = New System.Drawing.Size(128, 19)
			Me.BottomShowAtBackCheck.TabIndex = 10
			Me.BottomShowAtBackCheck.Text = "Show At Back Wall"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomShowAtBackCheck.CheckedChanged += new System.EventHandler(this.BottomShowAtBackCheck_CheckedChanged);
			' 
			' BottomFillStyleButton
			' 
			Me.BottomFillStyleButton.Location = New System.Drawing.Point(9, 128)
			Me.BottomFillStyleButton.Name = "BottomFillStyleButton"
			Me.BottomFillStyleButton.Size = New System.Drawing.Size(128, 22)
			Me.BottomFillStyleButton.TabIndex = 9
			Me.BottomFillStyleButton.Text = "Stripe Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomFillStyleButton.Click += new System.EventHandler(this.BottomFillStyleButton_Click);
			' 
			' BottomEndScroll
			' 
			Me.BottomEndScroll.Location = New System.Drawing.Point(9, 103)
			Me.BottomEndScroll.Maximum = 130
			Me.BottomEndScroll.Minimum = -20
			Me.BottomEndScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomEndScroll.Name = "BottomEndScroll"
			Me.BottomEndScroll.Size = New System.Drawing.Size(128, 16)
			Me.BottomEndScroll.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomEndScroll_Scroll);
			' 
			' BottomBeginScroll
			' 
			Me.BottomBeginScroll.Location = New System.Drawing.Point(9, 49)
			Me.BottomBeginScroll.Maximum = 130
			Me.BottomBeginScroll.Minimum = -20
			Me.BottomBeginScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomBeginScroll.Name = "BottomBeginScroll"
			Me.BottomBeginScroll.Size = New System.Drawing.Size(128, 16)
			Me.BottomBeginScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomBeginScroll_Scroll);
			' 
			' LeftIncludeInAxisRangeCheckBox
			' 
			Me.LeftIncludeInAxisRangeCheckBox.ButtonProperties.BorderOffset = 2
			Me.LeftIncludeInAxisRangeCheckBox.Location = New System.Drawing.Point(9, 108)
			Me.LeftIncludeInAxisRangeCheckBox.Name = "LeftIncludeInAxisRangeCheckBox"
			Me.LeftIncludeInAxisRangeCheckBox.Size = New System.Drawing.Size(128, 20)
			Me.LeftIncludeInAxisRangeCheckBox.TabIndex = 7
			Me.LeftIncludeInAxisRangeCheckBox.Text = "Include in axis range"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftIncludeInAxisRangeCheckBox.CheckedChanged += new System.EventHandler(this.LeftIncludeInAxisRangeCheckBox_CheckedChanged);
			' 
			' BottomIncludeInAxisRangeCheckBox
			' 
			Me.BottomIncludeInAxisRangeCheckBox.ButtonProperties.BorderOffset = 2
			Me.BottomIncludeInAxisRangeCheckBox.Location = New System.Drawing.Point(9, 74)
			Me.BottomIncludeInAxisRangeCheckBox.Name = "BottomIncludeInAxisRangeCheckBox"
			Me.BottomIncludeInAxisRangeCheckBox.Size = New System.Drawing.Size(128, 20)
			Me.BottomIncludeInAxisRangeCheckBox.TabIndex = 8
			Me.BottomIncludeInAxisRangeCheckBox.Text = "Include in axis range"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomIncludeInAxisRangeCheckBox.CheckedChanged += new System.EventHandler(this.BottomIncludeInAxisRange_CheckedChanged);
			' 
			' NStripesUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NStripesUC"
			Me.Size = New System.Drawing.Size(169, 463)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region


		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Stripes")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True

			' apply predefined lighting and projection
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = New NLinearScaleConfigurator()

			' configure the x and y scales
			Dim yScale As New NLinearScaleConfigurator()

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			yScale.StripStyles.Add(stripStyle)

			' display major grid lines at back and left walls
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale

			Dim xScale As New NLinearScaleConfigurator()
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale

			' Create a point series
			Dim pnt As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			pnt.InflateMargins = True
			pnt.UseXValues = True
			pnt.Name = "Series 1"
			pnt.DataLabelStyle.Format = "<value>"

			' Add some data
			pnt.Values.Add(3.1)
			pnt.Values.Add(6.7)
			pnt.Values.Add(1.2)
			pnt.Values.Add(8.4)
			pnt.Values.Add(9.0)
			pnt.XValues.Add(0.5)
			pnt.XValues.Add(1.8)
			pnt.XValues.Add(2.6)
			pnt.XValues.Add(3.1)
			pnt.XValues.Add(4.4)

			' Add stripes for the left and the bottom axes
			Dim s1 As NAxisStripe = m_Chart.Axis(StandardAxis.PrimaryY).Stripes.Add(2, 3)
			s1.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.SteelBlue))
			Dim s2 As NAxisStripe = m_Chart.Axis(StandardAxis.PrimaryX).Stripes.Add(2, 3)
			s2.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.SteelBlue))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LeftBeginScroll.Value = CInt(Fix(s1.From * 10))
			LeftEndScroll.Value = CInt(Fix(s1.To * 10))
			BottomBeginScroll.Value = CInt(Fix(s2.From * 20))
			BottomEndScroll.Value = CInt(Fix(s2.To * 20))

			LeftShowAtBackCheck.Checked = True
			LeftShowAtLeftCheck.Checked = True
			BottomShowAtBackCheck.Checked = True
			BottomShowAtFloorCheck.Checked = True

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftBeginScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftBeginScroll.ValueChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)

			stripe.From = LeftBeginScroll.Value / 10.0

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftEndScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftEndScroll.ValueChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)

			stripe.To = LeftEndScroll.Value / 10.0

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomBeginScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BottomBeginScroll.ValueChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)

			stripe.From = BottomBeginScroll.Value / 20.0

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomEndScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BottomEndScroll.ValueChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)

			stripe.To = BottomEndScroll.Value / 20.0

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftFillStyleButton.Click
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(stripe.FillStyle, fillStyleResult) Then
				stripe.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BottomFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomFillStyleButton.Click
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(stripe.FillStyle, fillStyleResult) Then
				stripe.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LeftShowAtBackCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftShowAtBackCheck.CheckedChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)

			stripe.SetShowAtWall(ChartWallType.Back, LeftShowAtBackCheck.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftShowAtLeftCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftShowAtLeftCheck.CheckedChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)

			stripe.SetShowAtWall(ChartWallType.Left, LeftShowAtLeftCheck.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomShowAtBackCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomShowAtBackCheck.CheckedChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)

			stripe.SetShowAtWall(ChartWallType.Back, BottomShowAtBackCheck.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomShowAtFloorCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomShowAtFloorCheck.CheckedChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)

			stripe.SetShowAtWall(ChartWallType.Floor, BottomShowAtFloorCheck.Checked)

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomIncludeInAxisRange_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BottomIncludeInAxisRangeCheckBox.CheckedChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)

			stripe.IncludeFromValueInAxisRange = BottomIncludeInAxisRangeCheckBox.Checked
			stripe.IncludeToValueInAxisRange = BottomIncludeInAxisRangeCheckBox.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftIncludeInAxisRangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftIncludeInAxisRangeCheckBox.CheckedChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)

			stripe.IncludeFromValueInAxisRange = LeftIncludeInAxisRangeCheckBox.Checked
			stripe.IncludeToValueInAxisRange = LeftIncludeInAxisRangeCheckBox.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace