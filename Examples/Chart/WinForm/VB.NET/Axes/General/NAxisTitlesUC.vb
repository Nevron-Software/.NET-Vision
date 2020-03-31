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
	Public Class NAxisTitlesUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents YOffsetScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents YAlignmentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents YTitleStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents YTitleTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents XOffsetScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents XAlignmentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents XTitleStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label6 As System.Windows.Forms.Label
		Private WithEvents XTitleTextBox As Nevron.UI.WinForm.Controls.NTextBox
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
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.YOffsetScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.YAlignmentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.YTitleStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.YTitleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.XOffsetScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.XAlignmentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.XTitleStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label6 = New System.Windows.Forms.Label()
			Me.XTitleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label3)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.YOffsetScrollBar)
			Me.nGroupBox1.Controls.Add(Me.YAlignmentComboBox)
			Me.nGroupBox1.Controls.Add(Me.YTitleStyleButton)
			Me.nGroupBox1.Controls.Add(Me.label1)
			Me.nGroupBox1.Controls.Add(Me.YTitleTextBox)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(7, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(172, 214)
			Me.nGroupBox1.TabIndex = 18
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Y Axis Title"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(16, 168)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(137, 15)
			Me.label3.TabIndex = 22
			Me.label3.Text = "Title Offset:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(16, 112)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(137, 15)
			Me.label2.TabIndex = 21
			Me.label2.Text = "Title Alignment:"
			' 
			' YOffsetScrollBar
			' 
			Me.YOffsetScrollBar.LargeChange = 2
			Me.YOffsetScrollBar.Location = New System.Drawing.Point(16, 184)
			Me.YOffsetScrollBar.Maximum = 30
			Me.YOffsetScrollBar.Name = "YOffsetScrollBar"
			Me.YOffsetScrollBar.Size = New System.Drawing.Size(137, 16)
			Me.YOffsetScrollBar.TabIndex = 20
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YOffsetScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.YOffsetScrollBar_ValueChanged);
			' 
			' YAlignmentComboBox
			' 
			Me.YAlignmentComboBox.Location = New System.Drawing.Point(16, 128)
			Me.YAlignmentComboBox.Name = "YAlignmentComboBox"
			Me.YAlignmentComboBox.Size = New System.Drawing.Size(137, 21)
			Me.YAlignmentComboBox.TabIndex = 19
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.YAlignmentComboBox_SelectedIndexChanged);
			' 
			' YTitleStyleButton
			' 
			Me.YTitleStyleButton.Location = New System.Drawing.Point(16, 72)
			Me.YTitleStyleButton.Name = "YTitleStyleButton"
			Me.YTitleStyleButton.Size = New System.Drawing.Size(137, 24)
			Me.YTitleStyleButton.TabIndex = 18
			Me.YTitleStyleButton.Text = "Title Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YTitleStyleButton.Click += new System.EventHandler(this.YTitleStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(137, 15)
			Me.label1.TabIndex = 17
			Me.label1.Text = "Title Text:"
			' 
			' YTitleTextBox
			' 
			Me.YTitleTextBox.ErrorMessage = Nothing
			Me.YTitleTextBox.Location = New System.Drawing.Point(16, 40)
			Me.YTitleTextBox.Name = "YTitleTextBox"
			Me.YTitleTextBox.Size = New System.Drawing.Size(137, 18)
			Me.YTitleTextBox.TabIndex = 16
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YTitleTextBox.TextChanged += new System.EventHandler(this.YTitleTextBox_TextChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.Controls.Add(Me.label5)
			Me.nGroupBox2.Controls.Add(Me.XOffsetScrollBar)
			Me.nGroupBox2.Controls.Add(Me.XAlignmentComboBox)
			Me.nGroupBox2.Controls.Add(Me.XTitleStyleButton)
			Me.nGroupBox2.Controls.Add(Me.label6)
			Me.nGroupBox2.Controls.Add(Me.XTitleTextBox)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(7, 235)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(172, 214)
			Me.nGroupBox2.TabIndex = 23
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "X Axis Title"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(16, 168)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(137, 15)
			Me.label4.TabIndex = 22
			Me.label4.Text = "Title Offset:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(16, 112)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(137, 15)
			Me.label5.TabIndex = 21
			Me.label5.Text = "Title Alignment:"
			' 
			' XOffsetScrollBar
			' 
			Me.XOffsetScrollBar.LargeChange = 2
			Me.XOffsetScrollBar.Location = New System.Drawing.Point(16, 184)
			Me.XOffsetScrollBar.Maximum = 30
			Me.XOffsetScrollBar.Name = "XOffsetScrollBar"
			Me.XOffsetScrollBar.Size = New System.Drawing.Size(137, 16)
			Me.XOffsetScrollBar.TabIndex = 20
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XOffsetScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.XOffsetScrollBar_ValueChanged);
			' 
			' XAlignmentComboBox
			' 
			Me.XAlignmentComboBox.Location = New System.Drawing.Point(16, 128)
			Me.XAlignmentComboBox.Name = "XAlignmentComboBox"
			Me.XAlignmentComboBox.Size = New System.Drawing.Size(137, 21)
			Me.XAlignmentComboBox.TabIndex = 19
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.XAlignmentComboBox_SelectedIndexChanged);
			' 
			' XTitleStyleButton
			' 
			Me.XTitleStyleButton.Location = New System.Drawing.Point(16, 72)
			Me.XTitleStyleButton.Name = "XTitleStyleButton"
			Me.XTitleStyleButton.Size = New System.Drawing.Size(137, 24)
			Me.XTitleStyleButton.TabIndex = 18
			Me.XTitleStyleButton.Text = "Title Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XTitleStyleButton.Click += new System.EventHandler(this.XTitleStyleButton_Click);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(16, 24)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(137, 15)
			Me.label6.TabIndex = 17
			Me.label6.Text = "Title Text:"
			' 
			' XTitleTextBox
			' 
			Me.XTitleTextBox.ErrorMessage = Nothing
			Me.XTitleTextBox.Location = New System.Drawing.Point(16, 40)
			Me.XTitleTextBox.Name = "XTitleTextBox"
			Me.XTitleTextBox.Size = New System.Drawing.Size(137, 18)
			Me.XTitleTextBox.TabIndex = 16
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XTitleTextBox.TextChanged += new System.EventHandler(this.XTitleTextBox_TextChanged);
			' 
			' NAxisTitlesUC
			' 
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Name = "NAxisTitlesUC"
			Me.Size = New System.Drawing.Size(188, 470)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Titles")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			scaleConfiguratorY.StripStyles.Add(stripStyle)

			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Values.FillRandom(Random, 20)
			bar.Name = "Bars"
			bar.DataLabelStyle.Visible = False

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			YTitleTextBox.Text = "Y Axis Title"
			XTitleTextBox.Text = "X Axis Title"

			YOffsetScrollBar.Value = 10
			XOffsetScrollBar.Value = 10

			YAlignmentComboBox.Items.Add("Top")
			YAlignmentComboBox.Items.Add("Middle")
			YAlignmentComboBox.Items.Add("Bottom")
			YAlignmentComboBox.SelectedIndex = 1

			XAlignmentComboBox.Items.Add("Left")
			XAlignmentComboBox.Items.Add("Center")
			XAlignmentComboBox.Items.Add("Right")
			XAlignmentComboBox.SelectedIndex = 1
		End Sub


		Private Sub YTitleStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles YTitleStyleButton.Click
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(scaleConfigurator.Title.TextStyle, textStyleResult) Then
				scaleConfigurator.Title.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub XTitleStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles XTitleStyleButton.Click
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(scaleConfigurator.Title.TextStyle, textStyleResult) Then
				scaleConfigurator.Title.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub YOffsetScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles YOffsetScrollBar.ValueChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfigurator.Title.Offset = New NLength(YOffsetScrollBar.Value, NGraphicsUnit.Pixel)

			nChartControl1.Refresh()
		End Sub

		Private Sub XOffsetScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles XOffsetScrollBar.ValueChanged
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfigurator.Title.Offset = New NLength(XOffsetScrollBar.Value, NGraphicsUnit.Pixel)

			nChartControl1.Refresh()
		End Sub

		Private Sub YTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YTitleTextBox.TextChanged
			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfiguratorY.Title.Text = YTitleTextBox.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub XTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XTitleTextBox.TextChanged
			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfiguratorX.Title.Text = XTitleTextBox.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub YAlignmentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAlignmentComboBox.SelectedIndexChanged
			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			Select Case YAlignmentComboBox.SelectedIndex
				Case 0
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleRight
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Right

				Case 1
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleCenter
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Center

				Case 2
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleLeft
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Left
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub XAlignmentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAlignmentComboBox.SelectedIndexChanged
			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			Select Case XAlignmentComboBox.SelectedIndex
				Case 0
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleLeft
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Left

				Case 1
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleCenter
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Center

				Case 2
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleRight
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Right
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
