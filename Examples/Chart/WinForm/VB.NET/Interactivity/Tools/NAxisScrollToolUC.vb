Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAxisScrollToolUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private m_ChartStockValues As NCartesianChart
		Private m_ChartStockVolumes As NCartesianChart
		Private m_Stock As NStockSeries
		Private m_Volume As NBarSeries
		Private m_DataZoomTool As NDataZoomTool
		Private m_AxisScrollTool As NAxisScrollTool

		Private label1 As System.Windows.Forms.Label
		Private WithEvents AnimateZoomingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents PagingViewResetModeComboBox As Nevron.UI.WinForm.Controls.NComboBox

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
			Me.PagingViewResetModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.AnimateZoomingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(144, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Paging View Reset Mode:"
			' 
			' PagingViewResetModeComboBox
			' 
			Me.PagingViewResetModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PagingViewResetModeComboBox.ListProperties.DataSource = Nothing
			Me.PagingViewResetModeComboBox.ListProperties.DisplayMember = ""
			Me.PagingViewResetModeComboBox.Location = New System.Drawing.Point(8, 26)
			Me.PagingViewResetModeComboBox.Name = "PagingViewResetModeComboBox"
			Me.PagingViewResetModeComboBox.Size = New System.Drawing.Size(160, 21)
			Me.PagingViewResetModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PagingViewResetModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PagingViewResetModeComboBox_SelectedIndexChanged);
			' 
			' AnimateZoomingCheckBox
			' 
			Me.AnimateZoomingCheckBox.ButtonProperties.BorderOffset = 2
			Me.AnimateZoomingCheckBox.Location = New System.Drawing.Point(11, 53)
			Me.AnimateZoomingCheckBox.Name = "AnimateZoomingCheckBox"
			Me.AnimateZoomingCheckBox.Size = New System.Drawing.Size(141, 24)
			Me.AnimateZoomingCheckBox.TabIndex = 12
			Me.AnimateZoomingCheckBox.Text = "Animate Zooming"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AnimateZoomingCheckBox.CheckedChanged += new System.EventHandler(this.AnimateZoomingCheckBox_CheckedChanged);
			' 
			' NAxisScrollToolUC
			' 
			Me.Controls.Add(Me.AnimateZoomingCheckBox)
			Me.Controls.Add(Me.PagingViewResetModeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NAxisScrollToolUC"
			Me.Size = New System.Drawing.Size(180, 200)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' disable the legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Scroll Tool")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure stock and volume charts
			ConfigureStockValuesChart()
			ConfigureStockVolumesChart()

			' Configure axes
			ConfigureAxes()

			' configure cursors
			ConfigureAxisCursors()

			' configure range selections
			ConfigureRangeSelections()

			' add a guide line on the left
			Dim guideLine As New NSideGuideline(PanelSide.Left)

			guideLine.Targets.Add(m_ChartStockValues)
			guideLine.Targets.Add(m_ChartStockVolumes)

			nChartControl1.Document.RootPanel.Guidelines.Add(guideLine)

			' configure interactivity
			m_DataZoomTool = New NDataZoomTool()
			m_DataZoomTool.AlwaysZoomIn = False

			m_AxisScrollTool = New NAxisScrollTool()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NDataCursorTool())
			nChartControl1.Controller.Tools.Add(m_AxisScrollTool)
			nChartControl1.Controller.Tools.Add(m_DataZoomTool)

			PagingViewResetModeComboBox.FillFromEnum(GetType(PagingViewResetMode))
			PagingViewResetModeComboBox.SelectedIndex = 0
		End Sub

		Private Sub ConfigureStockValuesChart()
			m_ChartStockValues = CType(nChartControl1.Charts(0), NCartesianChart)

			m_ChartStockValues.Location = New NPointL(New NLength(7, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_ChartStockValues.Size = New NSizeL(New NLength(84, NRelativeUnit.ParentPercentage), New NLength(35, NRelativeUnit.ParentPercentage))
			m_ChartStockValues.BoundsMode = BoundsMode.Stretch
			m_ChartStockValues.Wall(ChartWallType.Back).FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.FromArgb(230, 230, 230))

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Visible = False
			m_ChartStockValues.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

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
			m_ChartStockValues.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' create stock series
			m_Stock = CType(m_ChartStockValues.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.Name = "Stock Prices"
			m_Stock.UpFillStyle = New NColorFillStyle(Color.FromArgb(149, 171, 238))
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue
			m_Stock.DownFillStyle = New NColorFillStyle(Color.White)
			m_Stock.DownStrokeStyle.Color = Color.RoyalBlue
			m_Stock.HighLowStrokeStyle.Color = Color.RoyalBlue
			m_Stock.InflateMargins = True
			m_Stock.UseXValues = True
			m_Stock.CandleWidth = New NLength(1.6F, NRelativeUnit.ParentPercentage)

			' show the date time value in the legend
			m_Stock.Legend.Format = "<xvalue>"
			m_Stock.XValues.ValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			m_Stock.Legend.Mode = SeriesLegendMode.DataPoints

			' configure data labels 
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.DataLabelStyle.Format = "<xvalue>"
			m_Stock.DataLabelStyle.VertAlign = VertAlign.Center

			' add stock date time values
			GenerateOHLCData(m_Stock, 150, 12 * 4)

			' add stock date time values
			For nMonth As Integer = 1 To 12
				For nDay As Integer = 1 To 28 Step 7
					m_Stock.XValues.Add((New Date(2003, nMonth, nDay)).ToOADate())
				Next nDay
			Next nMonth
		End Sub

		Protected Sub ConfigureStockVolumesChart()
			m_ChartStockVolumes = New NCartesianChart()
			nChartControl1.Panels.Add(m_ChartStockVolumes)

			m_ChartStockVolumes.Location = New NPointL(New NLength(7, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
			m_ChartStockVolumes.Size = New NSizeL(New NLength(84, NRelativeUnit.ParentPercentage), New NLength(35, NRelativeUnit.ParentPercentage))
			m_ChartStockVolumes.BoundsMode = BoundsMode.Stretch
			m_ChartStockVolumes.Wall(ChartWallType.Back).FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.FromArgb(230, 230, 230))

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Visible = False
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

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
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' enable paging and scrollbar
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).PagingView = New NDateTimeAxisPagingView()
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True

			' add a Bar series for the Volume values
			m_Volume = CType(m_ChartStockVolumes.Series.Add(SeriesType.Bar), NBarSeries)
			m_Volume.Name = "Volume"
			m_Volume.DataLabelStyle.Visible = False
			m_Volume.DataLabelStyle.Format = "<xvalue>"
			m_Volume.DataLabelStyle.VertAlign = VertAlign.Center
			m_Volume.UseXValues = True
			m_Volume.InflateMargins = True
			m_Volume.FillStyle = New NColorFillStyle(Color.FromArgb(119, 208, 151))

			' add some stock items
			For i As Integer = 0 To m_Stock.Values.Count - 1
				m_Volume.Values.Add(100 + Random.Next(1000))
				m_Volume.XValues.Add(m_Stock.XValues(i))
			Next i
		End Sub

		Private Sub ConfigureAxes()
			Dim primaryStockVolumesXAxis As NAxis = m_ChartStockVolumes.Axis(StandardAxis.PrimaryX)
			Dim primaryStockValuesXAxis As NAxis = m_ChartStockValues.Axis(StandardAxis.PrimaryX)

			primaryStockVolumesXAxis.Slaves.Add(primaryStockValuesXAxis)
			primaryStockValuesXAxis.Slaves.Add(primaryStockVolumesXAxis)
		End Sub

		Private Sub ConfigureAxisCursors()
			Dim stockValueAxisCursor As New NAxisCursor()
			Dim stockVolumeAxisCursor As New NAxisCursor()

			stockValueAxisCursor.BeginEndAxis = CInt(StandardAxis.PrimaryY)
			stockVolumeAxisCursor.BeginEndAxis = CInt(StandardAxis.PrimaryY)

			' each cursor is master of the other. When the users click on one of the 
			' charts this will result in an automatic update of the other cursor
			stockValueAxisCursor.Slaves.Add(stockVolumeAxisCursor)
			stockVolumeAxisCursor.Slaves.Add(stockValueAxisCursor)

			m_ChartStockValues.Axis(StandardAxis.PrimaryX).Cursors.Add(stockValueAxisCursor)
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).Cursors.Add(stockVolumeAxisCursor)
		End Sub

		Private Sub ConfigureRangeSelections()
			Dim stockValueRangeSelection As New NRangeSelection()
			Dim stockVolumeRangeSelection As New NRangeSelection()

			stockValueRangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			stockVolumeRangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()

			' each range selection is master of the other. When the users click on one of the 
			' charts this will result in an automatic update of the other range selection.
			stockValueRangeSelection.Slaves.Add(stockVolumeRangeSelection)
			stockVolumeRangeSelection.Slaves.Add(stockValueRangeSelection)

			m_ChartStockValues.RangeSelections.Add(stockValueRangeSelection)
			m_ChartStockVolumes.RangeSelections.Add(stockVolumeRangeSelection)
		End Sub

		Private Sub PagingViewResetModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagingViewResetModeComboBox.SelectedIndexChanged
			Dim resetMode As PagingViewResetMode = CType(PagingViewResetModeComboBox.SelectedIndex, PagingViewResetMode)

			m_ChartStockValues.Axis(StandardAxis.PrimaryX).PagingView.ResetMode = resetMode
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).PagingView.ResetMode = resetMode
		End Sub

		Private Sub AnimateZoomingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AnimateZoomingCheckBox.CheckedChanged
			m_DataZoomTool.AnimateZooming = AnimateZoomingCheckBox.Checked
		End Sub
	End Class
End Namespace
