Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NStockDataGroupingUC
		Inherits NExampleBaseUC

		Private m_Stock As NStockSeries
		Private WithEvents GroupingModeComboBox As UI.WinForm.Controls.NComboBox
		Private label2 As Label
		Private label1 As Label
		Private WithEvents MinGroupDistanceUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private WithEvents CustomDateTimeSpanComboBox As UI.WinForm.Controls.NComboBox
		Private WithEvents GroupPercentWidthNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label
		Private WithEvents ShowHighLowCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowOpenCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowCloseCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowAsStickCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowDataLabelsCheckBox As UI.WinForm.Controls.NCheckBox
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
			Me.GroupingModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.MinGroupDistanceUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.CustomDateTimeSpanComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.GroupPercentWidthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ShowHighLowCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowOpenCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowCloseCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowAsStickCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowDataLabelsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.MinGroupDistanceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.GroupPercentWidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' GroupingModeComboBox
			' 
			Me.GroupingModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.GroupingModeComboBox.ListProperties.DataSource = Nothing
			Me.GroupingModeComboBox.ListProperties.DisplayMember = ""
			Me.GroupingModeComboBox.Location = New System.Drawing.Point(11, 29)
			Me.GroupingModeComboBox.Name = "GroupingModeComboBox"
			Me.GroupingModeComboBox.Size = New System.Drawing.Size(151, 21)
			Me.GroupingModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GroupingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupingModeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(11, 12)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(83, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Grouping Mode:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(11, 57)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 13)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Min Group Distance:"
			' 
			' MinGroupDistanceUpDown
			' 
			Me.MinGroupDistanceUpDown.Location = New System.Drawing.Point(11, 74)
			Me.MinGroupDistanceUpDown.Minimum = New Decimal(New Integer() { 5, 0, 0, 0})
			Me.MinGroupDistanceUpDown.Name = "MinGroupDistanceUpDown"
			Me.MinGroupDistanceUpDown.Size = New System.Drawing.Size(151, 20)
			Me.MinGroupDistanceUpDown.TabIndex = 3
			Me.MinGroupDistanceUpDown.Value = New Decimal(New Integer() { 20, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinGroupDistanceUpDown.ValueChanged += new System.EventHandler(this.MinGroupDistanceUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(11, 101)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(125, 13)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Custom Date Time Span:"
			' 
			' CustomDateTimeSpanComboBox
			' 
			Me.CustomDateTimeSpanComboBox.ListProperties.CheckBoxDataMember = ""
			Me.CustomDateTimeSpanComboBox.ListProperties.DataSource = Nothing
			Me.CustomDateTimeSpanComboBox.ListProperties.DisplayMember = ""
			Me.CustomDateTimeSpanComboBox.Location = New System.Drawing.Point(11, 118)
			Me.CustomDateTimeSpanComboBox.Name = "CustomDateTimeSpanComboBox"
			Me.CustomDateTimeSpanComboBox.Size = New System.Drawing.Size(151, 21)
			Me.CustomDateTimeSpanComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomDateTimeSpanComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomDateTimeSpanComboBox_SelectedIndexChanged);
			' 
			' GroupPercentWidthNumericUpDown
			' 
			Me.GroupPercentWidthNumericUpDown.Location = New System.Drawing.Point(11, 163)
			Me.GroupPercentWidthNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.GroupPercentWidthNumericUpDown.Name = "GroupPercentWidthNumericUpDown"
			Me.GroupPercentWidthNumericUpDown.Size = New System.Drawing.Size(151, 20)
			Me.GroupPercentWidthNumericUpDown.TabIndex = 7
			Me.GroupPercentWidthNumericUpDown.Value = New Decimal(New Integer() { 50, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GroupPercentWidthNumericUpDown.ValueChanged += new System.EventHandler(this.GroupPercentWidthNumericUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(11, 146)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(110, 13)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Group Percent Width:"
			' 
			' ShowHighLowCheckBox
			' 
			Me.ShowHighLowCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowHighLowCheckBox.Location = New System.Drawing.Point(11, 237)
			Me.ShowHighLowCheckBox.Name = "ShowHighLowCheckBox"
			Me.ShowHighLowCheckBox.Size = New System.Drawing.Size(151, 24)
			Me.ShowHighLowCheckBox.TabIndex = 9
			Me.ShowHighLowCheckBox.Text = "Show High Low"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowHighLowCheckBox.CheckedChanged += new System.EventHandler(this.ShowHighLowCheckBox_CheckedChanged);
			' 
			' ShowOpenCheckBox
			' 
			Me.ShowOpenCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowOpenCheckBox.Location = New System.Drawing.Point(11, 261)
			Me.ShowOpenCheckBox.Name = "ShowOpenCheckBox"
			Me.ShowOpenCheckBox.Size = New System.Drawing.Size(151, 24)
			Me.ShowOpenCheckBox.TabIndex = 10
			Me.ShowOpenCheckBox.Text = "Show Open"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowOpenCheckBox.CheckedChanged += new System.EventHandler(this.ShowOpenCheckBox_CheckedChanged);
			' 
			' ShowCloseCheckBox
			' 
			Me.ShowCloseCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowCloseCheckBox.Location = New System.Drawing.Point(11, 285)
			Me.ShowCloseCheckBox.Name = "ShowCloseCheckBox"
			Me.ShowCloseCheckBox.Size = New System.Drawing.Size(151, 24)
			Me.ShowCloseCheckBox.TabIndex = 11
			Me.ShowCloseCheckBox.Text = "Show Close"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowCloseCheckBox.CheckedChanged += new System.EventHandler(this.ShowCloseCheckBox_CheckedChanged);
			' 
			' ShowAsStickCheckBox
			' 
			Me.ShowAsStickCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowAsStickCheckBox.Location = New System.Drawing.Point(11, 213)
			Me.ShowAsStickCheckBox.Name = "ShowAsStickCheckBox"
			Me.ShowAsStickCheckBox.Size = New System.Drawing.Size(151, 24)
			Me.ShowAsStickCheckBox.TabIndex = 8
			Me.ShowAsStickCheckBox.Text = "Draw as Stick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowAsStickCheckBox.CheckedChanged += new System.EventHandler(this.ShowAsStickCheckBox_CheckedChanged);
			' 
			' ShowDataLabelsCheckBox
			' 
			Me.ShowDataLabelsCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowDataLabelsCheckBox.Location = New System.Drawing.Point(11, 189)
			Me.ShowDataLabelsCheckBox.Name = "ShowDataLabelsCheckBox"
			Me.ShowDataLabelsCheckBox.Size = New System.Drawing.Size(151, 24)
			Me.ShowDataLabelsCheckBox.TabIndex = 12
			Me.ShowDataLabelsCheckBox.Text = "Show Data Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDataLabelsCheckBox.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheckBox_CheckedChanged);
			' 
			' NStockDataGroupingUC
			' 
			Me.Controls.Add(Me.ShowDataLabelsCheckBox)
			Me.Controls.Add(Me.ShowAsStickCheckBox)
			Me.Controls.Add(Me.ShowCloseCheckBox)
			Me.Controls.Add(Me.ShowOpenCheckBox)
			Me.Controls.Add(Me.ShowHighLowCheckBox)
			Me.Controls.Add(Me.GroupPercentWidthNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.CustomDateTimeSpanComboBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.MinGroupDistanceUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.GroupingModeComboBox)
			Me.Controls.Add(Me.label2)
			Me.Name = "NStockDataGroupingUC"
			Me.Size = New System.Drawing.Size(176, 376)
			DirectCast(Me.MinGroupDistanceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.GroupPercentWidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stock Data Grouping")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch

			Dim rs As New NRangeSelection()
			rs.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rs)

			' setup X axis
			Dim scaleX As New NValueTimelineScaleConfigurator()
			scaleX.FirstRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.FirstRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(225, 225, 225))
			scaleX.FirstRow.UseGridStyle = True
			scaleX.FirstRow.InnerTickStyle.Visible = False
			scaleX.SecondRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.SecondRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(215, 215, 215))
			scaleX.SecondRow.UseGridStyle = True
			scaleX.SecondRow.InnerTickStyle.Visible = False
			scaleX.ThirdRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.ThirdRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(205, 205, 205))
			scaleX.ThirdRow.UseGridStyle = True
			scaleX.ThirdRow.InnerTickStyle.Visible = False

			' calendar
			Dim wdr As New NWeekDayRule(WeekDayBit.All)
			wdr.Saturday = False
			wdr.Sunday = False
			scaleX.Calendar.Rules.Add(wdr)
			scaleX.EnableCalendar = True

			' set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.OuterMajorTickStyle.Length = New NLength(3, NGraphicsUnit.Point)
			scaleY.InnerMajorTickStyle.Visible = False

			Dim stripFill As NFillStyle = New NColorFillStyle(Color.FromArgb(234, 233, 237))
			Dim stripStyle As New NScaleStripStyle(stripFill, Nothing, True, 1, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			stripStyle.Interlaced = True
			scaleY.StripStyles.Add(stripStyle)

			' setup stock series
			m_Stock = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.UpFillStyle = New NColorFillStyle(Color.White)
			m_Stock.UpStrokeStyle.Color = Color.Black
			m_Stock.DownFillStyle = New NColorFillStyle(Color.Crimson)
			m_Stock.DownStrokeStyle.Color = Color.Crimson
			m_Stock.HighLowStrokeStyle.Color = Color.Black
			m_Stock.CandleWidth = New NLength(1.2F, NRelativeUnit.ParentPercentage)
			m_Stock.UseXValues = True
			m_Stock.InflateMargins = True
			m_Stock.DataLabelStyle.Format = "open - <open>" & ControlChars.CrLf & "close - <close>"

			' add some stock items
			Const numDataPoints As Integer = 10000
			GenerateOHLCData(m_Stock, 100.0, numDataPoints, New NRange1DD(60, 140))
			FillStockDates(m_Stock, numDataPoints, Date.Now - New TimeSpan(CInt(Math.Truncate(numDataPoints * 1.2)), 0, 0, 0))

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' update form controls
			CustomDateTimeSpanComboBox.Items.Add("1 Week")
			CustomDateTimeSpanComboBox.Items.Add("2 Weeks")
			CustomDateTimeSpanComboBox.Items.Add("1 Month")
			CustomDateTimeSpanComboBox.Items.Add("3 Months")

			GroupingModeComboBox.FillFromEnum(GetType(StockGroupingMode))

			CustomDateTimeSpanComboBox.SelectedIndex = 2
			GroupingModeComboBox.SelectedIndex = CInt(StockGroupingMode.AutoDateTimeSpan)

			ShowHighLowCheckBox.Checked = True
			ShowOpenCheckBox.Checked = True
			ShowCloseCheckBox.Checked = True
			ShowAsStickCheckBox.Checked = False
			ShowOpenCheckBox.Enabled = False
			ShowCloseCheckBox.Enabled = False
		End Sub

		Private Sub GroupingModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GroupingModeComboBox.SelectedIndexChanged
			If m_Stock Is Nothing Then
				Return
			End If

			MinGroupDistanceUpDown.Enabled = False
			CustomDateTimeSpanComboBox.Enabled = False
			GroupPercentWidthNumericUpDown.Enabled = True

			Select Case GroupingModeComboBox.SelectedIndex
				Case CInt(StockGroupingMode.None)
					m_Stock.GroupingMode = StockGroupingMode.None
					GroupPercentWidthNumericUpDown.Enabled = False
				Case CInt(StockGroupingMode.AutoDateTimeSpan)
					m_Stock.GroupingMode = StockGroupingMode.AutoDateTimeSpan
					MinGroupDistanceUpDown.Enabled = True
				Case CInt(StockGroupingMode.CustomDateTimeSpan)
					m_Stock.GroupingMode = StockGroupingMode.CustomDateTimeSpan
					CustomDateTimeSpanComboBox.Enabled = True
				Case CInt(StockGroupingMode.SynchronizeWithMajorTick)
					m_Stock.GroupingMode = StockGroupingMode.SynchronizeWithMajorTick
				Case Else
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub MinGroupDistanceUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MinGroupDistanceUpDown.ValueChanged
			If m_Stock Is Nothing Then
				Return
			End If

			m_Stock.MinAutoGroupLength = New NLength(CSng(MinGroupDistanceUpDown.Value), NGraphicsUnit.Point)
			nChartControl1.Refresh()
		End Sub

		Private Sub CustomDateTimeSpanComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CustomDateTimeSpanComboBox.SelectedIndexChanged
			If m_Stock Is Nothing Then
				Return
			End If

			Select Case CustomDateTimeSpanComboBox.SelectedIndex
				Case 0 ' 1 Week
					m_Stock.CustomGroupStep = New NDateTimeSpan(1, NDateTimeUnit.Week)
				Case 1 ' 2 Weeks
					m_Stock.CustomGroupStep = New NDateTimeSpan(2, NDateTimeUnit.Week)
				Case 2 ' 1 Month
					m_Stock.CustomGroupStep = New NDateTimeSpan(1, NDateTimeUnit.Month)
				Case 3 ' 3 Months
					m_Stock.CustomGroupStep = New NDateTimeSpan(3, NDateTimeUnit.Month)
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub GroupPercentWidthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GroupPercentWidthNumericUpDown.ValueChanged
			If m_Stock Is Nothing Then
				Return
			End If

			m_Stock.GroupPercentWidth = CSng(GroupPercentWidthNumericUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowHighLowCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowHighLowCheckBox.CheckedChanged
			If m_Stock Is Nothing Then
				Return
			End If

			m_Stock.ShowHighLow = ShowHighLowCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowOpenCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowOpenCheckBox.CheckedChanged
			If m_Stock Is Nothing Then
				Return
			End If

			m_Stock.ShowOpen = ShowOpenCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowCloseCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowCloseCheckBox.CheckedChanged
			If m_Stock Is Nothing Then
				Return
			End If

			m_Stock.ShowClose = ShowCloseCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowAsStickCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowAsStickCheckBox.CheckedChanged
			If m_Stock Is Nothing Then
				Return
			End If

			m_Stock.CandleStyle = If(ShowAsStickCheckBox.Checked, CandleStyle.Stick, CandleStyle.Bar)
			nChartControl1.Refresh()

			ShowOpenCheckBox.Enabled = ShowAsStickCheckBox.Checked
			ShowCloseCheckBox.Enabled = ShowAsStickCheckBox.Checked
		End Sub

		Private Sub ShowDataLabelsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataLabelsCheckBox.CheckedChanged
			If m_Stock Is Nothing Then
				Return
			End If

			m_Stock.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace