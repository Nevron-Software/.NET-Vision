Imports System.ComponentModel
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Editors
Imports Nevron.GraphicsCore


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NConstLines3DUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private label1 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LeftStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents LeftPropsButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftFillFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftValue As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents EndXScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents UseBeginEndXCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BeginXScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents EndZScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label2 As System.Windows.Forms.Label
		Private WithEvents UseBeginEndZCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents BeginZScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			LeftStyleCombo.FillFromEnum(GetType(ConstLineMode))
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
			Me.EndZScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.UseBeginEndZCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.BeginZScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.EndXScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label7 = New System.Windows.Forms.Label()
			Me.UseBeginEndXCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.BeginXScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.LeftFillFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LeftValue = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.LeftPropsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LeftStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.EndZScroll)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.UseBeginEndZCheck)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.BeginZScroll)
			Me.groupBox1.Controls.Add(Me.EndXScroll)
			Me.groupBox1.Controls.Add(Me.label7)
			Me.groupBox1.Controls.Add(Me.UseBeginEndXCheck)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.BeginXScroll)
			Me.groupBox1.Controls.Add(Me.LeftFillFillStyleButton)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.LeftValue)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.LeftPropsButton)
			Me.groupBox1.Controls.Add(Me.LeftStyleCombo)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(187, 418)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Axis Const Line"
			' 
			' EndZScroll
			' 
			Me.EndZScroll.Location = New System.Drawing.Point(7, 383)
			Me.EndZScroll.Maximum = 110
			Me.EndZScroll.Name = "EndZScroll"
			Me.EndZScroll.Size = New System.Drawing.Size(148, 18)
			Me.EndZScroll.TabIndex = 16
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndZScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.EndZScroll_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 367)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(148, 14)
			Me.label2.TabIndex = 15
			Me.label2.Text = "End X Value:"
			' 
			' UseBeginEndZCheck
			' 
			Me.UseBeginEndZCheck.ButtonProperties.BorderOffset = 2
			Me.UseBeginEndZCheck.Location = New System.Drawing.Point(7, 298)
			Me.UseBeginEndZCheck.Name = "UseBeginEndZCheck"
			Me.UseBeginEndZCheck.Size = New System.Drawing.Size(148, 21)
			Me.UseBeginEndZCheck.TabIndex = 14
			Me.UseBeginEndZCheck.Text = "Use Begin-End Z Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseBeginEndZCheck.CheckedChanged += new System.EventHandler(this.UseBeginEndZCheck_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(7, 323)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(148, 16)
			Me.label4.TabIndex = 13
			Me.label4.Text = "Begin Z Value:"
			' 
			' BeginZScroll
			' 
			Me.BeginZScroll.Location = New System.Drawing.Point(7, 341)
			Me.BeginZScroll.Maximum = 110
			Me.BeginZScroll.Name = "BeginZScroll"
			Me.BeginZScroll.Size = New System.Drawing.Size(148, 18)
			Me.BeginZScroll.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginZScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginZScroll_ValueChanged);
			' 
			' EndXScroll
			' 
			Me.EndXScroll.Location = New System.Drawing.Point(7, 252)
			Me.EndXScroll.Maximum = 110
			Me.EndXScroll.Name = "EndXScroll"
			Me.EndXScroll.Size = New System.Drawing.Size(148, 18)
			Me.EndXScroll.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndXScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.EndXScroll_Scroll);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(7, 236)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(148, 14)
			Me.label7.TabIndex = 10
			Me.label7.Text = "End X Value:"
			' 
			' UseBeginEndXCheck
			' 
			Me.UseBeginEndXCheck.ButtonProperties.BorderOffset = 2
			Me.UseBeginEndXCheck.Location = New System.Drawing.Point(7, 167)
			Me.UseBeginEndXCheck.Name = "UseBeginEndXCheck"
			Me.UseBeginEndXCheck.Size = New System.Drawing.Size(148, 21)
			Me.UseBeginEndXCheck.TabIndex = 9
			Me.UseBeginEndXCheck.Text = "Use Begin-End X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseBeginEndXCheck.CheckedChanged += new System.EventHandler(this.UseBeginEndXCheck_CheckedChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(7, 192)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(148, 16)
			Me.label5.TabIndex = 8
			Me.label5.Text = "Begin X Value:"
			' 
			' BeginXScroll
			' 
			Me.BeginXScroll.Location = New System.Drawing.Point(7, 210)
			Me.BeginXScroll.Maximum = 110
			Me.BeginXScroll.Name = "BeginXScroll"
			Me.BeginXScroll.Size = New System.Drawing.Size(148, 18)
			Me.BeginXScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginXScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginXScroll_Scroll);
			' 
			' LeftFillFillStyleButton
			' 
			Me.LeftFillFillStyleButton.Location = New System.Drawing.Point(7, 108)
			Me.LeftFillFillStyleButton.Name = "LeftFillFillStyleButton"
			Me.LeftFillFillStyleButton.Size = New System.Drawing.Size(148, 21)
			Me.LeftFillFillStyleButton.TabIndex = 6
			Me.LeftFillFillStyleButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftFillFillStyleButton.Click += new System.EventHandler(this.LeftFillFillStyleButton_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 63)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(148, 15)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Style:"
			' 
			' LeftValue
			' 
			Me.LeftValue.Location = New System.Drawing.Point(7, 38)
			Me.LeftValue.Maximum = 110
			Me.LeftValue.Name = "LeftValue"
			Me.LeftValue.Size = New System.Drawing.Size(148, 17)
			Me.LeftValue.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftValue_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 20)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(148, 16)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Value:"
			' 
			' LeftPropsButton
			' 
			Me.LeftPropsButton.Location = New System.Drawing.Point(7, 131)
			Me.LeftPropsButton.Name = "LeftPropsButton"
			Me.LeftPropsButton.Size = New System.Drawing.Size(148, 21)
			Me.LeftPropsButton.TabIndex = 2
			Me.LeftPropsButton.Text = "Line Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftPropsButton.Click += new System.EventHandler(this.LeftPropsButton_Click);
			' 
			' LeftStyleCombo
			' 
			Me.LeftStyleCombo.Location = New System.Drawing.Point(7, 80)
			Me.LeftStyleCombo.Name = "LeftStyleCombo"
			Me.LeftStyleCombo.Size = New System.Drawing.Size(148, 21)
			Me.LeftStyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LeftStyleCombo_SelectedIndexChanged);
			' 
			' NConstLines3DUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NConstLines3DUC"
			Me.Size = New System.Drawing.Size(187, 573)
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
			m_Chart.Enable3D = True

			' configure the axes
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = New NLinearScaleConfigurator()

			Dim linearScale As New NLinearScaleConfigurator()

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale

			' apply predefined lighting and projection
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' apply 1:1:1 aspect
			m_Chart.Depth = 70
			m_Chart.Width = 70
			m_Chart.Height = 70
			m_Chart.BoundsMode = BoundsMode.Fit

			' Create a point series
			Dim pnt As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			pnt.InflateMargins = True
			pnt.UseXValues = True
			pnt.UseZValues = True
			pnt.Name = "Series 1"
			pnt.DataLabelStyle.Visible = False

			' Add some data
			pnt.Values.Add(31)
			pnt.Values.Add(67)
			pnt.Values.Add(12)
			pnt.Values.Add(84)
			pnt.Values.Add(90)

			pnt.XValues.Add(5)
			pnt.XValues.Add(27)
			pnt.XValues.Add(49)
			pnt.XValues.Add(78)
			pnt.XValues.Add(93)

			pnt.ZValues.Add(9)
			pnt.ZValues.Add(57)
			pnt.ZValues.Add(89)
			pnt.ZValues.Add(31)
			pnt.ZValues.Add(49)

			' Add a constline for the left axis
			Dim constLine As NAxisConstLine = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
			constLine.StrokeStyle.Color = Color.Blue
			constLine.FillStyle = New NColorFillStyle(New NArgbColor(125, Color.SteelBlue))
			constLine.Value = 50.0

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LeftStyleCombo.SelectedIndex = CInt(ConstLineMode.Plane)
			LeftValue.Value = CInt(Fix(constLine.Value))

			BeginXScroll.Value = 10
			EndXScroll.Value = 80
			BeginXScroll.Enabled = False
			EndXScroll.Enabled = False

			BeginZScroll.Value = 10
			EndZScroll.Value = 80
			BeginZScroll.Enabled = False
			EndZScroll.Enabled = False

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftPropsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftPropsButton.Click
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(cl.StrokeStyle, strokeStyleResult) Then
				cl.StrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LeftValue_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftValue.ValueChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			cl.Value = LeftValue.Value

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftFillFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftFillFillStyleButton.Click
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(cl.FillStyle, fillStyleResult) Then
				cl.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LeftStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftStyleCombo.SelectedIndexChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			Select Case LeftStyleCombo.SelectedIndex
				Case 0
					cl.Mode = ConstLineMode.Line
					LeftFillFillStyleButton.Enabled = False

				Case 1
					cl.Mode = ConstLineMode.Plane
					LeftFillFillStyleButton.Enabled = True
			End Select

			nChartControl1.Refresh()
		End Sub


		Private Sub UseBeginEndXCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseBeginEndXCheck.CheckedChanged
			UpdateReferenceAxisRanges()
			nChartControl1.Refresh()
		End Sub

		Private Sub BeginXScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BeginXScroll.ValueChanged
			UpdateReferenceAxisRanges()
			nChartControl1.Refresh()
		End Sub

		Private Sub EndXScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles EndXScroll.ValueChanged
			UpdateReferenceAxisRanges()
			nChartControl1.Refresh()
		End Sub

		Private Sub UseBeginEndZCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseBeginEndZCheck.CheckedChanged
			UpdateReferenceAxisRanges()
			nChartControl1.Refresh()
		End Sub

		Private Sub BeginZScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BeginZScroll.ValueChanged
			UpdateReferenceAxisRanges()
			nChartControl1.Refresh()
		End Sub

		Private Sub EndZScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles EndZScroll.ValueChanged
			UpdateReferenceAxisRanges()
			nChartControl1.Refresh()
		End Sub


		Private Sub UpdateReferenceAxisRanges()
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			cl.ReferenceRanges.Clear()

			If UseBeginEndXCheck.Checked Then
				Dim axisX As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
				Dim refBeginValue As Double = BeginXScroll.Value
				Dim refEndValue As Double = EndXScroll.Value
				cl.ReferenceRanges.Add(New NReferenceAxisRange(axisX, refBeginValue, refEndValue))

				BeginXScroll.Enabled = True
				EndXScroll.Enabled = True
			Else
				BeginXScroll.Enabled = False
				EndXScroll.Enabled = False
			End If

			If UseBeginEndZCheck.Checked Then
				Dim axisZ As NAxis = m_Chart.Axis(StandardAxis.Depth)
				Dim refBeginValue As Double = BeginZScroll.Value
				Dim refEndValue As Double = EndZScroll.Value
				cl.ReferenceRanges.Add(New NReferenceAxisRange(axisZ, refBeginValue, refEndValue))

				BeginZScroll.Enabled = True
				EndZScroll.Enabled = True
			Else
				BeginZScroll.Enabled = False
				EndZScroll.Enabled = False
			End If
		End Sub

	End Class
End Namespace
