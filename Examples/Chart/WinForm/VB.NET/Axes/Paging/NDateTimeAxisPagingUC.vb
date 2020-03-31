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
	Public Class NDateTimeAxisPagingUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents BottomAxisPageSizeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label11 As System.Windows.Forms.Label
		Private label14 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents SmallChangeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents AutoSmallChangeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowScrollbarCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents StartDateTimePicker As Nevron.UI.WinForm.Controls.NDateTimePicker

		Private m_Chart As NChart
		Private m_Updating As Boolean

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
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
			Me.StartDateTimePicker = New Nevron.UI.WinForm.Controls.NDateTimePicker()
			Me.BottomAxisPageSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label11 = New System.Windows.Forms.Label()
			Me.label14 = New System.Windows.Forms.Label()
			Me.ShowScrollbarCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SmallChangeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.AutoSmallChangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.BottomAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.SmallChangeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.StartDateTimePicker)
			Me.groupBox2.Controls.Add(Me.BottomAxisPageSizeNumericUpDown)
			Me.groupBox2.Controls.Add(Me.label11)
			Me.groupBox2.Controls.Add(Me.label14)
			Me.groupBox2.Controls.Add(Me.ShowScrollbarCheckBox)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.SmallChangeNumericUpDown)
			Me.groupBox2.Controls.Add(Me.AutoSmallChangeCheckBox)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 0)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(248, 216)
			Me.groupBox2.TabIndex = 0
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Bottom Axis"
			' 
			' StartDateTimePicker
			' 
			Me.StartDateTimePicker.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.StartDateTimePicker.CalendarForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.StartDateTimePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb((CByte(235)), (CByte(235)), (CByte(235)))
			Me.StartDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb((CByte(76)), (CByte(76)), (CByte(76)))
			Me.StartDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb((CByte(242)), (CByte(242)), (CByte(242)))
			Me.StartDateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb((CByte(127)), (CByte(127)), (CByte(127)))
			Me.StartDateTimePicker.ForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.StartDateTimePicker.Location = New System.Drawing.Point(8, 72)
			Me.StartDateTimePicker.Name = "StartDateTimePicker"
			Me.StartDateTimePicker.Size = New System.Drawing.Size(232, 20)
			Me.StartDateTimePicker.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
			' 
			' BottomAxisPageSizeNumericUpDown
			' 
			Me.BottomAxisPageSizeNumericUpDown.Location = New System.Drawing.Point(160, 19)
			Me.BottomAxisPageSizeNumericUpDown.Maximum = New System.Decimal(New Integer() { 30, 0, 0, 0})
			Me.BottomAxisPageSizeNumericUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.BottomAxisPageSizeNumericUpDown.Name = "BottomAxisPageSizeNumericUpDown"
			Me.BottomAxisPageSizeNumericUpDown.Size = New System.Drawing.Size(85, 20)
			Me.BottomAxisPageSizeNumericUpDown.TabIndex = 1
			Me.BottomAxisPageSizeNumericUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
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
			Me.label14.Size = New System.Drawing.Size(136, 16)
			Me.label14.TabIndex = 0
			Me.label14.Text = "Page Size (in months)"
			' 
			' ShowScrollbarCheckBox
			' 
			Me.ShowScrollbarCheckBox.Location = New System.Drawing.Point(8, 120)
			Me.ShowScrollbarCheckBox.Name = "ShowScrollbarCheckBox"
			Me.ShowScrollbarCheckBox.TabIndex = 4
			Me.ShowScrollbarCheckBox.Text = "Show Scrollbar"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowScrollbarCheckBox.CheckedChanged += new System.EventHandler(this.ShowScrollbarCheckBox_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 172)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(136, 16)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Small Change (in days):"
			' 
			' SmallChangeNumericUpDown
			' 
			Me.SmallChangeNumericUpDown.Location = New System.Drawing.Point(160, 168)
			Me.SmallChangeNumericUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.SmallChangeNumericUpDown.Name = "SmallChangeNumericUpDown"
			Me.SmallChangeNumericUpDown.Size = New System.Drawing.Size(85, 20)
			Me.SmallChangeNumericUpDown.TabIndex = 7
			Me.SmallChangeNumericUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SmallChangeNumericUpDown.ValueChanged += new System.EventHandler(this.SmallChangeNumericUpDown_ValueChanged);
			' 
			' AutoSmallChangeCheckBox
			' 
			Me.AutoSmallChangeCheckBox.Location = New System.Drawing.Point(8, 144)
			Me.AutoSmallChangeCheckBox.Name = "AutoSmallChangeCheckBox"
			Me.AutoSmallChangeCheckBox.Size = New System.Drawing.Size(136, 24)
			Me.AutoSmallChangeCheckBox.TabIndex = 5
			Me.AutoSmallChangeCheckBox.Text = "Auto Small Change"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AutoSmallChangeCheckBox.CheckedChanged += new System.EventHandler(this.AutoSmallChangeCheckBox_CheckedChanged);
			' 
			' NDateTimeAxisPagingUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Name = "NDateTimeAxisPagingUC"
			Me.Size = New System.Drawing.Size(248, 288)
			Me.groupBox2.ResumeLayout(False)
			DirectCast(Me.BottomAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.SmallChangeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Date / Time Axis Paging")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' configure the X and Y axes to use linear scale without tick rounding
			Dim timelineScale As New NValueTimelineScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timelineScale
			timelineScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = False
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ShowSliders = False

			' add interlace stripe to the X axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			timelineScale.StripStyles.Add(stripStyle)

			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False

			' add interlace stripe to the Y axis
			stripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' configure a XY scatter point chart
			Dim point As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			point.UseXValues = True
			point.Size = New NLength(5, NGraphicsUnit.Point)
			point.DataLabelStyle.Visible = False

			point.Values.FillRandomRange(Random, 100, 0, 100)

			Dim now As Date = Date.Now

			' add data for ten thousand days from now
			For i As Integer = 0 To 999
				point.XValues.Add(now.Add(New TimeSpan(i * 10, 0, 0, 0, 0)))
			Next i

			' configure the x and y axis paging
			Dim dateTimePagingView As New NDateTimeAxisPagingView(now, New NDateTimeSpan(1, NDateTimeUnit.Month))
			dateTimePagingView.Enabled = True
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = dateTimePagingView

			' subscribe for the scrollbar value changed event
			AddHandler m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.BeginValueChanged, AddressOf ScrollbarValueChanged

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			m_Updating = True
			StartDateTimePicker.Value = now
			BottomAxisPageSizeNumericUpDown.Value = 2
			ShowScrollbarCheckBox.Checked = True
			AutoSmallChangeCheckBox.Checked = True
			m_Updating = False

			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Refresh()

			UpdateAxis()
		End Sub

		Private Sub UpdateAxis()
			If m_Chart Is Nothing OrElse m_Updating Then
				Return
			End If

			m_Updating = True
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim pagingView As NDateTimeAxisPagingView = TryCast(axis.PagingView, NDateTimeAxisPagingView)

			If pagingView IsNot Nothing Then
				axis.ScrollBar.Visible = ShowScrollbarCheckBox.Checked
				pagingView.Begin = StartDateTimePicker.Value
				pagingView.Length = New NDateTimeSpan(CInt(Math.Truncate(BottomAxisPageSizeNumericUpDown.Value)), NDateTimeUnit.Month)
				pagingView.AutoSmallChange = AutoSmallChangeCheckBox.Checked
				pagingView.SmallChange = New NDateTimeSpan(CLng(Math.Truncate(SmallChangeNumericUpDown.Value)), NDateTimeUnit.Day)
			End If

			nChartControl1.Refresh()
			m_Updating = False
		End Sub

		Private Sub ScrollbarValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			Me.StartDateTimePicker.Value = Date.FromOADate(m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.BeginValue)
		End Sub

		Private Sub ShowScrollbarCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowScrollbarCheckBox.CheckedChanged
			UpdateAxis()
		End Sub

		Private Sub AutoSmallChangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoSmallChangeCheckBox.CheckedChanged
			UpdateAxis()
			SmallChangeNumericUpDown.Enabled = Not AutoSmallChangeCheckBox.Checked
		End Sub

		Private Sub SmallChangeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SmallChangeNumericUpDown.ValueChanged
			UpdateAxis()
		End Sub

		Private Sub BottomAxisPageSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomAxisPageSizeNumericUpDown.ValueChanged
			UpdateAxis()
		End Sub

		Private Sub StartDateTimePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartDateTimePicker.ValueChanged
			UpdateAxis()
		End Sub
	End Class
End Namespace
