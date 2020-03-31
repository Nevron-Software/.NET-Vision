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
	Public Class NConstLineLabelsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LeftValue As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomValue As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label3 As Label
		Private WithEvents LeftTitleAlignmentCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As Label
		Private WithEvents LeftTitleTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label5 As Label
		Private WithEvents BottomTitleTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label6 As Label
		Private WithEvents BottomTitleAlignmentCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BottomAxisTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftAxisTextStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomAxisTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label5 = New System.Windows.Forms.Label()
			Me.BottomValue = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BottomTitleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.BottomTitleAlignmentCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LeftAxisTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.LeftTitleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LeftTitleAlignmentCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.LeftValue = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox2.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.BottomAxisTextStyleButton)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Controls.Add(Me.BottomValue)
			Me.groupBox2.Controls.Add(Me.BottomTitleTextBox)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.label6)
			Me.groupBox2.Controls.Add(Me.BottomTitleAlignmentCombo)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 241)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(174, 241)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Bottom Axis Const Line"
			' 
			' BottomAxisTextStyleButton
			' 
			Me.BottomAxisTextStyleButton.Location = New System.Drawing.Point(13, 148)
			Me.BottomAxisTextStyleButton.Name = "BottomAxisTextStyleButton"
			Me.BottomAxisTextStyleButton.Size = New System.Drawing.Size(148, 21)
			Me.BottomAxisTextStyleButton.TabIndex = 49
			Me.BottomAxisTextStyleButton.Text = "Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomAxisTextStyleButton.Click += new System.EventHandler(this.BottomAxisTextStyleButton_Click);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(10, 106)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(49, 15)
			Me.label5.TabIndex = 48
			Me.label5.Text = "Text:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BottomValue
			' 
			Me.BottomValue.Location = New System.Drawing.Point(13, 38)
			Me.BottomValue.Maximum = 110
			Me.BottomValue.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomValue.Name = "BottomValue"
			Me.BottomValue.Size = New System.Drawing.Size(140, 17)
			Me.BottomValue.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomValue_Scroll);
			' 
			' BottomTitleTextBox
			' 
			Me.BottomTitleTextBox.Location = New System.Drawing.Point(11, 124)
			Me.BottomTitleTextBox.Name = "BottomTitleTextBox"
			Me.BottomTitleTextBox.Size = New System.Drawing.Size(150, 18)
			Me.BottomTitleTextBox.TabIndex = 47
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomTitleTextBox.TextChanged += new System.EventHandler(this.BottomTitleTextBox_TextChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(13, 20)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(140, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Value:"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(13, 65)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(148, 15)
			Me.label6.TabIndex = 46
			Me.label6.Text = "Content Alignment:"
			' 
			' BottomTitleAlignmentCombo
			' 
			Me.BottomTitleAlignmentCombo.Location = New System.Drawing.Point(13, 82)
			Me.BottomTitleAlignmentCombo.Name = "BottomTitleAlignmentCombo"
			Me.BottomTitleAlignmentCombo.Size = New System.Drawing.Size(148, 21)
			Me.BottomTitleAlignmentCombo.TabIndex = 45
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomTitleAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.BottomTitleAlignmentCombo_SelectedIndexChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftAxisTextStyleButton)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.LeftTitleTextBox)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.LeftTitleAlignmentCombo)
			Me.groupBox1.Controls.Add(Me.LeftValue)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(174, 241)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Axis Const Line"
			' 
			' LeftAxisTextStyleButton
			' 
			Me.LeftAxisTextStyleButton.Location = New System.Drawing.Point(13, 141)
			Me.LeftAxisTextStyleButton.Name = "LeftAxisTextStyleButton"
			Me.LeftAxisTextStyleButton.Size = New System.Drawing.Size(148, 21)
			Me.LeftAxisTextStyleButton.TabIndex = 45
			Me.LeftAxisTextStyleButton.Text = "Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftAxisTextStyleButton.Click += new System.EventHandler(this.LeftAxisTextStyleButton_Click);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(10, 99)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(49, 15)
			Me.label4.TabIndex = 44
			Me.label4.Text = "Text:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LeftTitleTextBox
			' 
			Me.LeftTitleTextBox.Location = New System.Drawing.Point(11, 117)
			Me.LeftTitleTextBox.Name = "LeftTitleTextBox"
			Me.LeftTitleTextBox.Size = New System.Drawing.Size(150, 18)
			Me.LeftTitleTextBox.TabIndex = 43
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftTitleTextBox.TextChanged += new System.EventHandler(this.LeftTitleTextBox_TextChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(13, 58)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(148, 15)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Content Alignment:"
			' 
			' LeftTitleAlignmentCombo
			' 
			Me.LeftTitleAlignmentCombo.Location = New System.Drawing.Point(13, 75)
			Me.LeftTitleAlignmentCombo.Name = "LeftTitleAlignmentCombo"
			Me.LeftTitleAlignmentCombo.Size = New System.Drawing.Size(148, 21)
			Me.LeftTitleAlignmentCombo.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftTitleAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.LeftTitleAlignmentCombo_SelectedIndexChanged);
			' 
			' LeftValue
			' 
			Me.LeftValue.Location = New System.Drawing.Point(13, 38)
			Me.LeftValue.Maximum = 110
			Me.LeftValue.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftValue.Name = "LeftValue"
			Me.LeftValue.Size = New System.Drawing.Size(148, 17)
			Me.LeftValue.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftValue_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(13, 20)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(148, 16)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Value:"
			' 
			' NConstLineLabelsUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NConstLineLabelsUC"
			Me.Size = New System.Drawing.Size(174, 539)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Const Lines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' configure the x scale
			Dim xScale As New NLinearScaleConfigurator()
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale

			' configure the y scale
			Dim yScale As New NLinearScaleConfigurator()

			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			yScale.StripStyles.Add(stripStyle)

			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale

			' Create a point series
			Dim pnt As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			pnt.InflateMargins = True
			pnt.UseXValues = True
			pnt.Name = "Series 1"
			pnt.DataLabelStyle.Visible = False

			' Add some data
			pnt.Values.Add(31)
			pnt.Values.Add(67)
			pnt.Values.Add(12)
			pnt.Values.Add(84)
			pnt.Values.Add(90)

			pnt.XValues.Add(5)
			pnt.XValues.Add(36)
			pnt.XValues.Add(51)
			pnt.XValues.Add(76)
			pnt.XValues.Add(93)

			' Add a constline for the left axis
			Dim cl1 As NAxisConstLine = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
			cl1.StrokeStyle.Color = Color.SteelBlue
			cl1.StrokeStyle.Width = New NLength(1.5F)
			cl1.FillStyle = New NColorFillStyle(New NArgbColor(125, Color.SteelBlue))
			cl1.Value = 40

			' Add a constline for the bottom axis
			Dim cl2 As NAxisConstLine = m_Chart.Axis(StandardAxis.PrimaryX).ConstLines.Add()
			cl2.StrokeStyle.Color = Color.SteelBlue
			cl2.StrokeStyle.Width = New NLength(1.5F)
			cl2.FillStyle = New NColorFillStyle(New NArgbColor(125, Color.SteelBlue))
			cl2.Value = 60

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LeftValue.Value = CInt(Fix(cl1.Value))
			BottomValue.Value = CInt(Fix(cl2.Value))

			LeftTitleAlignmentCombo.FillFromEnum(GetType(ContentAlignment))
			LeftTitleAlignmentCombo.SelectedIndex = 0

			BottomTitleAlignmentCombo.FillFromEnum(GetType(ContentAlignment))
			BottomTitleAlignmentCombo.SelectedIndex = 0

			LeftTitleTextBox.Text = "Left Axis Const Line Title"
			BottomTitleTextBox.Text = "Bottom Axis Const Line Title"

			nChartControl1.Refresh()
		End Sub


		Private Sub LeftValue_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftValue.ValueChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			cl.Value = LeftValue.Value

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomValue_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BottomValue.ValueChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)

			cl.Value = BottomValue.Value

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftTitleAlignmentCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftTitleAlignmentCombo.SelectedIndexChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)
			cl.TextAlignment = DirectCast(System.Enum.Parse(GetType(ContentAlignment), LeftTitleAlignmentCombo.SelectedItem.ToString()), ContentAlignment)

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftTitleTextBox.TextChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)
			cl.Text = LeftTitleTextBox.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftAxisTextStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LeftAxisTextStyleButton.Click
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			Dim textStyle As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(cl.TextStyle, textStyle) Then
				cl.TextStyle = textStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BottomTitleAlignmentCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BottomTitleAlignmentCombo.SelectedIndexChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)
			cl.TextAlignment = DirectCast(System.Enum.Parse(GetType(ContentAlignment), BottomTitleAlignmentCombo.SelectedItem.ToString()), ContentAlignment)

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BottomTitleTextBox.TextChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)
			cl.Text = BottomTitleTextBox.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomAxisTextStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BottomAxisTextStyleButton.Click
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)
			Dim textStyle As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(cl.TextStyle, textStyle) Then
				cl.TextStyle = textStyle
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
