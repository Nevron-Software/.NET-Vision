Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStockDataGroupingHitTestingUC
		Inherits NExampleBaseUC

		Private m_Stock As NStockSeries
		Private label1 As Label
		Private GroupInformationTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents ShowHighLowCheckBox As UI.WinForm.Controls.NCheckBox
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.GroupInformationTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.ShowHighLowCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 4)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(94, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Group Information:"
			' 
			' GroupInformationTextBox
			' 
			Me.GroupInformationTextBox.Location = New System.Drawing.Point(9, 20)
			Me.GroupInformationTextBox.Multiline = True
			Me.GroupInformationTextBox.Name = "GroupInformationTextBox"
			Me.GroupInformationTextBox.Size = New System.Drawing.Size(203, 156)
			Me.GroupInformationTextBox.TabIndex = 1
			' 
			' ShowHighLowCheckBox
			' 
			Me.ShowHighLowCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowHighLowCheckBox.Location = New System.Drawing.Point(9, 182)
			Me.ShowHighLowCheckBox.Name = "ShowHighLowCheckBox"
			Me.ShowHighLowCheckBox.Size = New System.Drawing.Size(151, 24)
			Me.ShowHighLowCheckBox.TabIndex = 20
			Me.ShowHighLowCheckBox.Text = "Show High Low"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowHighLowCheckBox.CheckedChanged += new System.EventHandler(this.ShowHighLowCheckBox_CheckedChanged);
			' 
			' NStockDataGroupingHitTestingUC
			' 
			Me.Controls.Add(Me.ShowHighLowCheckBox)
			Me.Controls.Add(Me.GroupInformationTextBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NStockDataGroupingHitTestingUC"
			Me.Size = New System.Drawing.Size(222, 414)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stock Data Grouping - Hit Testing")
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
			m_Stock.GroupingMode = StockGroupingMode.SynchronizeWithMajorTick

			' add some stock items
			Const numDataPoints As Integer = 10000
			GenerateOHLCData(m_Stock, 100.0, numDataPoints, New NRange1DD(60, 140))
			FillStockDates(m_Stock, numDataPoints, Date.Now - New TimeSpan(CInt(Fix(numDataPoints * 1.2)), 0, 0, 0))

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			AddHandler nChartControl1.MouseMove, AddressOf nChartControl1_MouseMove

			Me.ShowHighLowCheckBox.Checked = True
		End Sub

		Private Sub nChartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If result.ChartElement = ChartElement.StockGroup Then
				Dim stockGroup As NStockGroup = result.StockGroup

				Dim stringBuilder As New StringBuilder()

				stringBuilder.AppendLine("Open Value: " & stockGroup.OpenValue.ToString())
				stringBuilder.AppendLine("Open X Value: " & Date.FromOADate(stockGroup.OpenXValue).ToString("d"))

				stringBuilder.AppendLine("Close Value: " & stockGroup.CloseValue.ToString())
				stringBuilder.AppendLine("Close X Value: " & Date.FromOADate(stockGroup.CloseXValue).ToString("d"))

				stringBuilder.AppendLine("High Value: " & stockGroup.HighValue.ToString())
				stringBuilder.AppendLine("Low Value: " & stockGroup.LowValue.ToString())

				GroupInformationTextBox.Text = stringBuilder.ToString()
			Else
				GroupInformationTextBox.Text = String.Empty
			End If
		End Sub

		Private Sub ShowHighLowCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowHighLowCheckBox.CheckedChanged
			m_Stock.ShowHighLow = ShowHighLowCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace