Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Editors
Imports Nevron.GraphicsCore


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStripeLabelsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents LeftBeginScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftEndScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents BottomEndScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomBeginScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomTitleTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label5 As Label
		Private WithEvents BottomTitleTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label6 As Label
		Private WithEvents BottomTitleAlignmentCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents LeftTitleTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label7 As Label
		Private WithEvents LeftTitleTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label8 As Label
		Private WithEvents LeftTitleAlignmentCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.LeftTitleTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label7 = New System.Windows.Forms.Label()
			Me.LeftTitleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label8 = New System.Windows.Forms.Label()
			Me.LeftTitleAlignmentCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.LeftEndScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomTitleTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label5 = New System.Windows.Forms.Label()
			Me.BottomTitleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.BottomTitleAlignmentCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.BottomEndScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BottomBeginScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' LeftBeginScroll
			' 
			Me.LeftBeginScroll.Location = New System.Drawing.Point(9, 41)
			Me.LeftBeginScroll.Maximum = 110
			Me.LeftBeginScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftBeginScroll.Name = "LeftBeginScroll"
			Me.LeftBeginScroll.Size = New System.Drawing.Size(148, 16)
			Me.LeftBeginScroll.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftBeginScroll_Scroll);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftTitleTextStyleButton)
			Me.groupBox1.Controls.Add(Me.label7)
			Me.groupBox1.Controls.Add(Me.LeftTitleTextBox)
			Me.groupBox1.Controls.Add(Me.label8)
			Me.groupBox1.Controls.Add(Me.LeftTitleAlignmentCombo)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.LeftEndScroll)
			Me.groupBox1.Controls.Add(Me.LeftBeginScroll)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(174, 240)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Axis Stripe"
			' 
			' LeftTitleTextStyleButton
			' 
			Me.LeftTitleTextStyleButton.Location = New System.Drawing.Point(9, 201)
			Me.LeftTitleTextStyleButton.Name = "LeftTitleTextStyleButton"
			Me.LeftTitleTextStyleButton.Size = New System.Drawing.Size(148, 21)
			Me.LeftTitleTextStyleButton.TabIndex = 54
			Me.LeftTitleTextStyleButton.Text = "Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftTitleTextStyleButton.Click += new System.EventHandler(this.LeftTitleTextStyleButton_Click);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(6, 159)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(49, 15)
			Me.label7.TabIndex = 53
			Me.label7.Text = "Text:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LeftTitleTextBox
			' 
			Me.LeftTitleTextBox.Location = New System.Drawing.Point(7, 177)
			Me.LeftTitleTextBox.Name = "LeftTitleTextBox"
			Me.LeftTitleTextBox.Size = New System.Drawing.Size(150, 18)
			Me.LeftTitleTextBox.TabIndex = 52
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftTitleTextBox.TextChanged += new System.EventHandler(this.LeftTitleTextBox_TextChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(9, 118)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(148, 15)
			Me.label8.TabIndex = 51
			Me.label8.Text = "Content Alignment:"
			' 
			' LeftTitleAlignmentCombo
			' 
			Me.LeftTitleAlignmentCombo.Location = New System.Drawing.Point(9, 135)
			Me.LeftTitleAlignmentCombo.Name = "LeftTitleAlignmentCombo"
			Me.LeftTitleAlignmentCombo.Size = New System.Drawing.Size(148, 21)
			Me.LeftTitleAlignmentCombo.TabIndex = 50
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftTitleAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.LeftTitleAlignmentCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 67)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(148, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "End Value:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 23)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(148, 17)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Begin Value:"
			' 
			' LeftEndScroll
			' 
			Me.LeftEndScroll.Location = New System.Drawing.Point(9, 86)
			Me.LeftEndScroll.Maximum = 110
			Me.LeftEndScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftEndScroll.Name = "LeftEndScroll"
			Me.LeftEndScroll.Size = New System.Drawing.Size(148, 16)
			Me.LeftEndScroll.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftEndScroll_Scroll);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.BottomTitleTextStyleButton)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Controls.Add(Me.BottomTitleTextBox)
			Me.groupBox2.Controls.Add(Me.label6)
			Me.groupBox2.Controls.Add(Me.BottomTitleAlignmentCombo)
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.BottomEndScroll)
			Me.groupBox2.Controls.Add(Me.BottomBeginScroll)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 240)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(174, 263)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Bottom Axis Stripe"
			' 
			' BottomTitleTextStyleButton
			' 
			Me.BottomTitleTextStyleButton.Location = New System.Drawing.Point(9, 211)
			Me.BottomTitleTextStyleButton.Name = "BottomTitleTextStyleButton"
			Me.BottomTitleTextStyleButton.Size = New System.Drawing.Size(148, 21)
			Me.BottomTitleTextStyleButton.TabIndex = 54
			Me.BottomTitleTextStyleButton.Text = "Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomTitleTextStyleButton.Click += new System.EventHandler(this.BottomTitleTextStyleButton_Click);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(6, 169)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(49, 15)
			Me.label5.TabIndex = 53
			Me.label5.Text = "Text:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BottomTitleTextBox
			' 
			Me.BottomTitleTextBox.Location = New System.Drawing.Point(7, 187)
			Me.BottomTitleTextBox.Name = "BottomTitleTextBox"
			Me.BottomTitleTextBox.Size = New System.Drawing.Size(150, 18)
			Me.BottomTitleTextBox.TabIndex = 52
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomTitleTextBox.TextChanged += new System.EventHandler(this.BottomTitleTextBox_TextChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(9, 128)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(148, 15)
			Me.label6.TabIndex = 51
			Me.label6.Text = "Content Alignment:"
			' 
			' BottomTitleAlignmentCombo
			' 
			Me.BottomTitleAlignmentCombo.Location = New System.Drawing.Point(9, 145)
			Me.BottomTitleAlignmentCombo.Name = "BottomTitleAlignmentCombo"
			Me.BottomTitleAlignmentCombo.Size = New System.Drawing.Size(148, 21)
			Me.BottomTitleAlignmentCombo.TabIndex = 50
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomTitleAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.BottomTitleAlignmentCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 80)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(148, 16)
			Me.label3.TabIndex = 13
			Me.label3.Text = "End Value:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(9, 23)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(148, 17)
			Me.label4.TabIndex = 12
			Me.label4.Text = "Begin Value:"
			' 
			' BottomEndScroll
			' 
			Me.BottomEndScroll.Location = New System.Drawing.Point(9, 99)
			Me.BottomEndScroll.Maximum = 110
			Me.BottomEndScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomEndScroll.Name = "BottomEndScroll"
			Me.BottomEndScroll.Size = New System.Drawing.Size(148, 16)
			Me.BottomEndScroll.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomEndScroll_Scroll);
			' 
			' BottomBeginScroll
			' 
			Me.BottomBeginScroll.Location = New System.Drawing.Point(9, 41)
			Me.BottomBeginScroll.Maximum = 110
			Me.BottomBeginScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomBeginScroll.Name = "BottomBeginScroll"
			Me.BottomBeginScroll.Size = New System.Drawing.Size(148, 16)
			Me.BottomBeginScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomBeginScroll_Scroll);
			' 
			' NStripeLabelsUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NStripeLabelsUC"
			Me.Size = New System.Drawing.Size(174, 539)
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

			LeftTitleAlignmentCombo.FillFromEnum(GetType(ContentAlignment))
			LeftTitleAlignmentCombo.SelectedItem = ContentAlignment.TopLeft.ToString()

			BottomTitleAlignmentCombo.FillFromEnum(GetType(ContentAlignment))
			BottomTitleAlignmentCombo.SelectedItem = ContentAlignment.TopLeft.ToString()

			LeftTitleTextBox.Text = "Left Axis Const Line Title"
			BottomTitleTextBox.Text = "Bottom Axis Const Line Title"

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

		Private Sub LeftFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(stripe.FillStyle, fillStyleResult) Then
				stripe.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BottomFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(stripe.FillStyle, fillStyleResult) Then
				stripe.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LeftTitleAlignmentCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftTitleAlignmentCombo.SelectedIndexChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)
			stripe.TextAlignment = DirectCast(System.Enum.Parse(GetType(ContentAlignment), LeftTitleAlignmentCombo.SelectedItem.ToString()), ContentAlignment)

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftTitleTextBox.TextChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)
			stripe.Text = LeftTitleTextBox.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftTitleTextStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LeftTitleTextStyleButton.Click
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe)

			Dim textStyle As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(stripe.TextStyle, textStyle) Then
				stripe.TextStyle = textStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BottomTitleAlignmentCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BottomTitleAlignmentCombo.SelectedIndexChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)
			stripe.TextAlignment = DirectCast(System.Enum.Parse(GetType(ContentAlignment), BottomTitleAlignmentCombo.SelectedItem.ToString()), ContentAlignment)

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BottomTitleTextBox.TextChanged
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)
			stripe.Text = BottomTitleTextBox.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomTitleTextStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BottomTitleTextStyleButton.Click
			Dim stripe As NAxisStripe = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe)
			Dim textStyle As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(stripe.TextStyle, textStyle) Then
				stripe.TextStyle = textStyle
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace