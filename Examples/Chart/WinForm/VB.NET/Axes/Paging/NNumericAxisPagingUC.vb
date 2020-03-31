Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NNumericAxisPagingUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label11 As System.Windows.Forms.Label
		Private label14 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents LeftAxisPageSizeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents LeftAxisPageValueNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BottomAxisPageSizeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BottomAxisPageValueNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ShowLeftScrollBarCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowBottomScrollbarCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents LeftAxisSmallChangeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label4 As System.Windows.Forms.Label
		Private WithEvents BottomAxisSmallChangeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BottomUseAutoSmallChangeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LeftUseAutoSmallChangeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.LeftAxisSmallChangeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LeftUseAutoSmallChangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowLeftScrollBarCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LeftAxisPageValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.LeftAxisPageSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomAxisPageValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.BottomAxisPageSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label11 = New System.Windows.Forms.Label()
			Me.label14 = New System.Windows.Forms.Label()
			Me.ShowBottomScrollbarCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.BottomAxisSmallChangeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.BottomUseAutoSmallChangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.LeftAxisSmallChangeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.LeftAxisPageValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.LeftAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.BottomAxisPageValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.BottomAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.BottomAxisSmallChangeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftAxisSmallChangeNumericUpDown)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.LeftUseAutoSmallChangeCheckBox)
			Me.groupBox1.Controls.Add(Me.ShowLeftScrollBarCheckBox)
			Me.groupBox1.Controls.Add(Me.LeftAxisPageValueNumericUpDown)
			Me.groupBox1.Controls.Add(Me.LeftAxisPageSizeNumericUpDown)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(192, 176)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Axis"
			' 
			' LeftAxisSmallChangeNumericUpDown
			' 
			Me.LeftAxisSmallChangeNumericUpDown.Location = New System.Drawing.Point(100, 130)
			Me.LeftAxisSmallChangeNumericUpDown.Maximum = New System.Decimal(New Integer() { 20, 0, 0, 0})
			Me.LeftAxisSmallChangeNumericUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.LeftAxisSmallChangeNumericUpDown.Name = "LeftAxisSmallChangeNumericUpDown"
			Me.LeftAxisSmallChangeNumericUpDown.Size = New System.Drawing.Size(85, 20)
			Me.LeftAxisSmallChangeNumericUpDown.TabIndex = 7
			Me.LeftAxisSmallChangeNumericUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftAxisSmallChangeNumericUpDown.ValueChanged += new System.EventHandler(this.LeftAxisSmallChangeNumericUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 136)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(83, 23)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Small Change:"
			' 
			' LeftUseAutoSmallChangeCheckBox
			' 
			Me.LeftUseAutoSmallChangeCheckBox.Location = New System.Drawing.Point(8, 108)
			Me.LeftUseAutoSmallChangeCheckBox.Name = "LeftUseAutoSmallChangeCheckBox"
			Me.LeftUseAutoSmallChangeCheckBox.Size = New System.Drawing.Size(136, 24)
			Me.LeftUseAutoSmallChangeCheckBox.TabIndex = 5
			Me.LeftUseAutoSmallChangeCheckBox.Text = "Auto Small Change"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftUseAutoSmallChangeCheckBox.CheckedChanged += new System.EventHandler(this.LeftUseAutoSmallChangeCheckBox_CheckedChanged);
			' 
			' ShowLeftScrollBarCheckBox
			' 
			Me.ShowLeftScrollBarCheckBox.Location = New System.Drawing.Point(8, 86)
			Me.ShowLeftScrollBarCheckBox.Name = "ShowLeftScrollBarCheckBox"
			Me.ShowLeftScrollBarCheckBox.TabIndex = 4
			Me.ShowLeftScrollBarCheckBox.Text = "Show Scrollbar"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLeftScrollBarCheckBox.CheckedChanged += new System.EventHandler(this.ShowLeftScrollBarCheckBox_CheckedChanged);
			' 
			' LeftAxisPageValueNumericUpDown
			' 
			Me.LeftAxisPageValueNumericUpDown.Location = New System.Drawing.Point(100, 52)
			Me.LeftAxisPageValueNumericUpDown.Name = "LeftAxisPageValueNumericUpDown"
			Me.LeftAxisPageValueNumericUpDown.Size = New System.Drawing.Size(85, 20)
			Me.LeftAxisPageValueNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftAxisPageValueNumericUpDown.ValueChanged += new System.EventHandler(this.LeftAxisPageValueNumericUpDown_ValueChanged);
			' 
			' LeftAxisPageSizeNumericUpDown
			' 
			Me.LeftAxisPageSizeNumericUpDown.Location = New System.Drawing.Point(100, 25)
			Me.LeftAxisPageSizeNumericUpDown.Name = "LeftAxisPageSizeNumericUpDown"
			Me.LeftAxisPageSizeNumericUpDown.Size = New System.Drawing.Size(85, 20)
			Me.LeftAxisPageSizeNumericUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftAxisPageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.LeftAxisPageSizeNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 56)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(66, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Page Value:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 29)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(66, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Page Size:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.BottomAxisPageValueNumericUpDown)
			Me.groupBox2.Controls.Add(Me.BottomAxisPageSizeNumericUpDown)
			Me.groupBox2.Controls.Add(Me.label11)
			Me.groupBox2.Controls.Add(Me.label14)
			Me.groupBox2.Controls.Add(Me.ShowBottomScrollbarCheckBox)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.BottomAxisSmallChangeNumericUpDown)
			Me.groupBox2.Controls.Add(Me.BottomUseAutoSmallChangeCheckBox)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 176)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(192, 183)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Bottom Axis"
			' 
			' BottomAxisPageValueNumericUpDown
			' 
			Me.BottomAxisPageValueNumericUpDown.Location = New System.Drawing.Point(100, 47)
			Me.BottomAxisPageValueNumericUpDown.Name = "BottomAxisPageValueNumericUpDown"
			Me.BottomAxisPageValueNumericUpDown.Size = New System.Drawing.Size(85, 20)
			Me.BottomAxisPageValueNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomAxisPageValueNumericUpDown.ValueChanged += new System.EventHandler(this.BottomAxisPageValueNumericUpDown_ValueChanged);
			' 
			' BottomAxisPageSizeNumericUpDown
			' 
			Me.BottomAxisPageSizeNumericUpDown.Location = New System.Drawing.Point(100, 19)
			Me.BottomAxisPageSizeNumericUpDown.Name = "BottomAxisPageSizeNumericUpDown"
			Me.BottomAxisPageSizeNumericUpDown.Size = New System.Drawing.Size(85, 20)
			Me.BottomAxisPageSizeNumericUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomAxisPageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.BottomAxisPageSizeNumericUpDown_ValueChanged);
			' 
			' label11
			' 
			Me.label11.Location = New System.Drawing.Point(8, 51)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(66, 16)
			Me.label11.TabIndex = 2
			Me.label11.Text = "Page Value:"
			' 
			' label14
			' 
			Me.label14.Location = New System.Drawing.Point(8, 23)
			Me.label14.Name = "label14"
			Me.label14.Size = New System.Drawing.Size(66, 16)
			Me.label14.TabIndex = 0
			Me.label14.Text = "Page Size:"
			' 
			' ShowBottomScrollbarCheckBox
			' 
			Me.ShowBottomScrollbarCheckBox.Location = New System.Drawing.Point(8, 86)
			Me.ShowBottomScrollbarCheckBox.Name = "ShowBottomScrollbarCheckBox"
			Me.ShowBottomScrollbarCheckBox.TabIndex = 4
			Me.ShowBottomScrollbarCheckBox.Text = "Show Scrollbar"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowBottomScrollbarCheckBox.CheckedChanged += new System.EventHandler(this.ShowBottomScrollbarCheckBox_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 134)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(83, 23)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Small Change:"
			' 
			' BottomAxisSmallChangeNumericUpDown
			' 
			Me.BottomAxisSmallChangeNumericUpDown.Location = New System.Drawing.Point(100, 130)
			Me.BottomAxisSmallChangeNumericUpDown.Maximum = New System.Decimal(New Integer() { 20, 0, 0, 0})
			Me.BottomAxisSmallChangeNumericUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.BottomAxisSmallChangeNumericUpDown.Name = "BottomAxisSmallChangeNumericUpDown"
			Me.BottomAxisSmallChangeNumericUpDown.Size = New System.Drawing.Size(85, 20)
			Me.BottomAxisSmallChangeNumericUpDown.TabIndex = 7
			Me.BottomAxisSmallChangeNumericUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomAxisSmallChangeNumericUpDown.ValueChanged += new System.EventHandler(this.BottomAxisSmallChangeNumericUpDown_ValueChanged);
			' 
			' BottomUseAutoSmallChangeCheckBox
			' 
			Me.BottomUseAutoSmallChangeCheckBox.Location = New System.Drawing.Point(8, 106)
			Me.BottomUseAutoSmallChangeCheckBox.Name = "BottomUseAutoSmallChangeCheckBox"
			Me.BottomUseAutoSmallChangeCheckBox.Size = New System.Drawing.Size(136, 24)
			Me.BottomUseAutoSmallChangeCheckBox.TabIndex = 5
			Me.BottomUseAutoSmallChangeCheckBox.Text = "Auto Small Change"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomUseAutoSmallChangeCheckBox.CheckedChanged += new System.EventHandler(this.BottomUseAutoSmallChangeCheckBox_CheckedChanged);
			' 
			' NNumericAxisPagingUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NNumericAxisPagingUC"
			Me.Size = New System.Drawing.Size(192, 593)
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.LeftAxisSmallChangeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.LeftAxisPageValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.LeftAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			DirectCast(Me.BottomAxisPageValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.BottomAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.BottomAxisSmallChangeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Numeric Axis Paging")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' configure the X and Y axes to use linear scale without tick rounding
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False

			' add interlace stripe to the X axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = False
			linearScale = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMin = False
			linearScale.RoundToTickMax = False

			' add interlace stripe to the Y axis
			stripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.ResetButton.Visible = False

			' configure a XY scatter point chart
			Dim point As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			point.UseXValues = True
			point.Size = New NLength(5, NGraphicsUnit.Point)
			point.DataLabelStyle.Visible = False

			point.Values.FillRandomRange(Random, 200, 0, 100)
			point.XValues.FillRandomRange(Random, 200, 0, 100)

			' configure the x and y axis paging
			Dim numericPagingView As NNumericAxisPagingView

			numericPagingView = New NNumericAxisPagingView(New NRange1DD(0, 20))
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = numericPagingView

			numericPagingView = New NNumericAxisPagingView(New NRange1DD(0, 20))
			m_Chart.Axis(StandardAxis.PrimaryY).PagingView = numericPagingView

			' subscribe for the scrollbar value changed event
			AddHandler m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.BeginValueChanged, AddressOf BottomAxisScrollbarValueChanged
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ShowSliders = False
			AddHandler m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.BeginValueChanged, AddressOf LeftAxisScrollbarValueChanged
			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.ShowSliders = False

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			LeftAxisPageSizeNumericUpDown.Value = 20
			LeftAxisPageValueNumericUpDown.Value = 10
			BottomAxisPageSizeNumericUpDown.Value = 20
			BottomAxisPageValueNumericUpDown.Value = 10

			ShowLeftScrollBarCheckBox.Checked = True
			ShowBottomScrollbarCheckBox.Checked = True
			LeftUseAutoSmallChangeCheckBox.Checked = True
			BottomUseAutoSmallChangeCheckBox.Checked = True

			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateAxes()
			If m_Chart Is Nothing Then
				Return
			End If

			Dim pagingView As NNumericAxisPagingView
			Dim axis As NAxis

			axis = m_Chart.Axis(StandardAxis.PrimaryY)
			pagingView = TryCast(axis.PagingView, NNumericAxisPagingView)

			If pagingView IsNot Nothing Then
				axis.ScrollBar.Visible = ShowLeftScrollBarCheckBox.Checked
				pagingView.Length = CDbl(LeftAxisPageSizeNumericUpDown.Value)
				pagingView.Begin = CDbl(LeftAxisPageValueNumericUpDown.Value)
				pagingView.AutoSmallChange = LeftUseAutoSmallChangeCheckBox.Checked
				pagingView.SmallChange = CDbl(LeftAxisSmallChangeNumericUpDown.Value)
			End If

			axis = m_Chart.Axis(StandardAxis.PrimaryX)
			pagingView = TryCast(axis.PagingView, NNumericAxisPagingView)

			If pagingView IsNot Nothing Then
				axis.ScrollBar.Visible = ShowBottomScrollbarCheckBox.Checked
				pagingView.Begin = CDbl(BottomAxisPageValueNumericUpDown.Value)
				pagingView.Length = CDbl(BottomAxisPageSizeNumericUpDown.Value)
				pagingView.AutoSmallChange = BottomUseAutoSmallChangeCheckBox.Checked
				pagingView.SmallChange = CDbl(BottomAxisSmallChangeNumericUpDown.Value)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftAxisPageSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftAxisPageSizeNumericUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub LeftAxisPageValueNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftAxisPageValueNumericUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub BottomAxisPageSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomAxisPageSizeNumericUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub BottomAxisPageValueNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomAxisPageValueNumericUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub ShowLeftScrollBarCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowLeftScrollBarCheckBox.CheckedChanged
			UpdateAxes()
		End Sub

		Private Sub ShowBottomScrollbarCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowBottomScrollbarCheckBox.CheckedChanged
			UpdateAxes()
		End Sub

		Private Sub LeftUseAutoSmallChangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftUseAutoSmallChangeCheckBox.CheckedChanged
			UpdateAxes()
			LeftAxisSmallChangeNumericUpDown.Enabled = Not LeftUseAutoSmallChangeCheckBox.Checked
		End Sub

		Private Sub LeftAxisSmallChangeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftAxisSmallChangeNumericUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub BottomUseAutoSmallChangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomUseAutoSmallChangeCheckBox.CheckedChanged
			UpdateAxes()
			BottomAxisSmallChangeNumericUpDown.Enabled = Not BottomUseAutoSmallChangeCheckBox.Checked
		End Sub

		Private Sub BottomAxisSmallChangeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomAxisSmallChangeNumericUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub BottomAxisScrollbarValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			If m_Chart Is Nothing Then
				Return
			End If

			Me.BottomAxisPageValueNumericUpDown.Value = CDec(m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.BeginValue)
		End Sub

		Private Sub LeftAxisScrollbarValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			If m_Chart Is Nothing Then
				Return
			End If

			Me.LeftAxisPageValueNumericUpDown.Value = CDec(m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.BeginValue)
		End Sub
	End Class
End Namespace
