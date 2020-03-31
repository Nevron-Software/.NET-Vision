Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Editors
Imports Nevron.GraphicsCore


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NConstLines2DUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LeftIncludeInAxisRangeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BottomUseBeginEndCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BottomBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftPropsButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LeftValue As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomValue As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftBeginScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomBeginScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftEndScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomEndScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftUseBeginEndCheck As UI.WinForm.Controls.NCheckBox
		Private WithEvents BottomIncludeInAxisRangeCheck As UI.WinForm.Controls.NCheckBox
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
			Me.LeftUseBeginEndCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LeftEndScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label7 = New System.Windows.Forms.Label()
			Me.LeftIncludeInAxisRangeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.LeftBeginScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.LeftValue = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.LeftPropsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomIncludeInAxisRangeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BottomEndScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label8 = New System.Windows.Forms.Label()
			Me.BottomUseBeginEndCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.BottomBeginScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BottomBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BottomValue = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftUseBeginEndCheck)
			Me.groupBox1.Controls.Add(Me.LeftEndScroll)
			Me.groupBox1.Controls.Add(Me.label7)
			Me.groupBox1.Controls.Add(Me.LeftIncludeInAxisRangeCheck)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.LeftBeginScroll)
			Me.groupBox1.Controls.Add(Me.LeftValue)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.LeftPropsButton)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(174, 277)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Axis Const Line"
			' 
			' LeftUseBeginEndCheck
			' 
			Me.LeftUseBeginEndCheck.ButtonProperties.BorderOffset = 2
			Me.LeftUseBeginEndCheck.Location = New System.Drawing.Point(13, 115)
			Me.LeftUseBeginEndCheck.Name = "LeftUseBeginEndCheck"
			Me.LeftUseBeginEndCheck.Size = New System.Drawing.Size(148, 21)
			Me.LeftUseBeginEndCheck.TabIndex = 4
			Me.LeftUseBeginEndCheck.Text = "Use Begin-End Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftUseBeginEndCheck.CheckedChanged += new System.EventHandler(this.LeftUseBeginEndCheck_CheckedChanged);
			' 
			' LeftEndScroll
			' 
			Me.LeftEndScroll.Location = New System.Drawing.Point(13, 200)
			Me.LeftEndScroll.Maximum = 110
			Me.LeftEndScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftEndScroll.Name = "LeftEndScroll"
			Me.LeftEndScroll.Size = New System.Drawing.Size(148, 18)
			Me.LeftEndScroll.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftEndScroll_Scroll);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(13, 182)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(148, 14)
			Me.label7.TabIndex = 7
			Me.label7.Text = "End Value:"
			' 
			' LeftIncludeInAxisRangeCheck
			' 
			Me.LeftIncludeInAxisRangeCheck.ButtonProperties.BorderOffset = 2
			Me.LeftIncludeInAxisRangeCheck.Location = New System.Drawing.Point(13, 65)
			Me.LeftIncludeInAxisRangeCheck.Name = "LeftIncludeInAxisRangeCheck"
			Me.LeftIncludeInAxisRangeCheck.Size = New System.Drawing.Size(148, 21)
			Me.LeftIncludeInAxisRangeCheck.TabIndex = 2
			Me.LeftIncludeInAxisRangeCheck.Text = "Include in axis range"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftIncludeInAxisRangeCheck.CheckedChanged += new System.EventHandler(this.LeftIncludeInAxisRangeCheck_CheckedChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(13, 140)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(148, 16)
			Me.label5.TabIndex = 5
			Me.label5.Text = "Begin Value:"
			' 
			' LeftBeginScroll
			' 
			Me.LeftBeginScroll.Location = New System.Drawing.Point(13, 160)
			Me.LeftBeginScroll.Maximum = 110
			Me.LeftBeginScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftBeginScroll.Name = "LeftBeginScroll"
			Me.LeftBeginScroll.Size = New System.Drawing.Size(148, 18)
			Me.LeftBeginScroll.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftBeginScroll_Scroll);
			' 
			' LeftValue
			' 
			Me.LeftValue.Location = New System.Drawing.Point(13, 44)
			Me.LeftValue.Maximum = 130
			Me.LeftValue.Minimum = -20
			Me.LeftValue.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftValue.Name = "LeftValue"
			Me.LeftValue.Size = New System.Drawing.Size(148, 17)
			Me.LeftValue.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftValue_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(13, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(148, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Value:"
			' 
			' LeftPropsButton
			' 
			Me.LeftPropsButton.Location = New System.Drawing.Point(13, 90)
			Me.LeftPropsButton.Name = "LeftPropsButton"
			Me.LeftPropsButton.Size = New System.Drawing.Size(148, 21)
			Me.LeftPropsButton.TabIndex = 3
			Me.LeftPropsButton.Text = "Line Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftPropsButton.Click += new System.EventHandler(this.LeftPropsButton_Click);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.BottomIncludeInAxisRangeCheck)
			Me.groupBox2.Controls.Add(Me.BottomEndScroll)
			Me.groupBox2.Controls.Add(Me.label8)
			Me.groupBox2.Controls.Add(Me.BottomUseBeginEndCheck)
			Me.groupBox2.Controls.Add(Me.label6)
			Me.groupBox2.Controls.Add(Me.BottomBeginScroll)
			Me.groupBox2.Controls.Add(Me.BottomBorderButton)
			Me.groupBox2.Controls.Add(Me.BottomValue)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 277)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(174, 277)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Bottom Axis Const Line"
			' 
			' BottomIncludeInAxisRangeCheck
			' 
			Me.BottomIncludeInAxisRangeCheck.ButtonProperties.BorderOffset = 2
			Me.BottomIncludeInAxisRangeCheck.Location = New System.Drawing.Point(13, 63)
			Me.BottomIncludeInAxisRangeCheck.Name = "BottomIncludeInAxisRangeCheck"
			Me.BottomIncludeInAxisRangeCheck.Size = New System.Drawing.Size(148, 21)
			Me.BottomIncludeInAxisRangeCheck.TabIndex = 2
			Me.BottomIncludeInAxisRangeCheck.Text = "Include in axis range"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomIncludeInAxisRangeCheck.CheckedChanged += new System.EventHandler(this.BottomIncludeInAxisRangeCheck_CheckedChanged);
			' 
			' BottomEndScroll
			' 
			Me.BottomEndScroll.Location = New System.Drawing.Point(13, 199)
			Me.BottomEndScroll.Maximum = 110
			Me.BottomEndScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomEndScroll.Name = "BottomEndScroll"
			Me.BottomEndScroll.Size = New System.Drawing.Size(140, 18)
			Me.BottomEndScroll.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomEndScroll_Scroll);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(13, 180)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(140, 15)
			Me.label8.TabIndex = 7
			Me.label8.Text = "End Value:"
			' 
			' BottomUseBeginEndCheck
			' 
			Me.BottomUseBeginEndCheck.ButtonProperties.BorderOffset = 2
			Me.BottomUseBeginEndCheck.Location = New System.Drawing.Point(13, 113)
			Me.BottomUseBeginEndCheck.Name = "BottomUseBeginEndCheck"
			Me.BottomUseBeginEndCheck.Size = New System.Drawing.Size(140, 21)
			Me.BottomUseBeginEndCheck.TabIndex = 4
			Me.BottomUseBeginEndCheck.Text = "Use Begin-End Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomUseBeginEndCheck.CheckedChanged += new System.EventHandler(this.BottomUseBeginEndCheck_CheckedChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(13, 138)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(140, 16)
			Me.label6.TabIndex = 5
			Me.label6.Text = "Begin Value:"
			' 
			' BottomBeginScroll
			' 
			Me.BottomBeginScroll.Location = New System.Drawing.Point(13, 158)
			Me.BottomBeginScroll.Maximum = 110
			Me.BottomBeginScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomBeginScroll.Name = "BottomBeginScroll"
			Me.BottomBeginScroll.Size = New System.Drawing.Size(140, 18)
			Me.BottomBeginScroll.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomBeginScroll_Scroll);
			' 
			' BottomBorderButton
			' 
			Me.BottomBorderButton.Location = New System.Drawing.Point(13, 88)
			Me.BottomBorderButton.Name = "BottomBorderButton"
			Me.BottomBorderButton.Size = New System.Drawing.Size(140, 21)
			Me.BottomBorderButton.TabIndex = 3
			Me.BottomBorderButton.Text = "Line Props"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomBorderButton.Click += new System.EventHandler(this.BottomBorderButton_Click);
			' 
			' BottomValue
			' 
			Me.BottomValue.Location = New System.Drawing.Point(13, 42)
			Me.BottomValue.Maximum = 130
			Me.BottomValue.Minimum = -20
			Me.BottomValue.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomValue.Name = "BottomValue"
			Me.BottomValue.Size = New System.Drawing.Size(140, 17)
			Me.BottomValue.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomValue_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(13, 22)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(140, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Value:"
			' 
			' NConstLines2DUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NConstLines2DUC"
			Me.Size = New System.Drawing.Size(174, 561)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
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
			LeftBeginScroll.Value = 10
			LeftEndScroll.Value = 80
			BottomBeginScroll.Value = 10
			BottomEndScroll.Value = 80
			LeftBeginScroll.Enabled = False
			LeftEndScroll.Enabled = False
			BottomBeginScroll.Enabled = False
			BottomEndScroll.Enabled = False

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

		Private Sub BottomBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomBorderButton.Click
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)
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

		Private Sub BottomValue_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BottomValue.ValueChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)

			cl.Value = BottomValue.Value

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftBeginScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftBeginScroll.ValueChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			If cl.ReferenceRanges.Count > 0 Then
				Dim refAxisRange As NReferenceAxisRange = DirectCast(cl.ReferenceRanges(0), NReferenceAxisRange)
				refAxisRange.BeginValue = LeftBeginScroll.Value
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LeftEndScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftEndScroll.ValueChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			If cl.ReferenceRanges.Count > 0 Then
				Dim refAxisRange As NReferenceAxisRange = DirectCast(cl.ReferenceRanges(0), NReferenceAxisRange)
				refAxisRange.EndValue = LeftEndScroll.Value
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BottomBeginScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BottomBeginScroll.ValueChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)

			If cl.ReferenceRanges.Count > 0 Then
				Dim refAxisRange As NReferenceAxisRange = DirectCast(cl.ReferenceRanges(0), NReferenceAxisRange)
				refAxisRange.BeginValue = BottomBeginScroll.Value
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BottomEndScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BottomEndScroll.ValueChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)

			If cl.ReferenceRanges.Count > 0 Then
				Dim refAxisRange As NReferenceAxisRange = DirectCast(cl.ReferenceRanges(0), NReferenceAxisRange)
				refAxisRange.EndValue = BottomEndScroll.Value
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BottomUseBeginEndCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomUseBeginEndCheck.CheckedChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)

			If BottomUseBeginEndCheck.Checked Then
				Dim referenceAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
				Dim refBeginValue As Double = BottomBeginScroll.Value
				Dim refEndValue As Double = BottomEndScroll.Value
				cl.ReferenceRanges.Add(New NReferenceAxisRange(referenceAxis, refBeginValue, refEndValue))

				BottomBeginScroll.Enabled = True
				BottomEndScroll.Enabled = True
			Else
				cl.ReferenceRanges.Clear()

				BottomBeginScroll.Enabled = False
				BottomEndScroll.Enabled = False
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftUseBeginEndCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftUseBeginEndCheck.CheckedChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			If LeftUseBeginEndCheck.Checked Then
				Dim referenceAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
				Dim refBeginValue As Double = LeftBeginScroll.Value
				Dim refEndValue As Double = LeftEndScroll.Value
				cl.ReferenceRanges.Add(New NReferenceAxisRange(referenceAxis, refBeginValue, refEndValue))

				LeftBeginScroll.Enabled = True
				LeftEndScroll.Enabled = True
			Else
				cl.ReferenceRanges.Clear()

				LeftBeginScroll.Enabled = False
				LeftEndScroll.Enabled = False
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftIncludeInAxisRangeCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftIncludeInAxisRangeCheck.CheckedChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)
			cl.IncludeInAxisRange = LeftIncludeInAxisRangeCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomIncludeInAxisRangeCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BottomIncludeInAxisRangeCheck.CheckedChanged
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryX).ConstLines(0), NAxisConstLine)
			cl.IncludeInAxisRange = BottomIncludeInAxisRangeCheck.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
