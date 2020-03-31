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
Imports Nevron.Chart.Functions
Imports System.Text

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NSideGuidelineUC
		Inherits NExampleBaseUC

		Private Const numDataPoits As Integer = 200
		Private Const prevCloseValue As Double = 100
		Private Const prevVolumeValue As Double = 100
		Private m_Stock As NStockSeries
		Private m_Volume As NAreaSeries
		Private m_Line As NLineSeries
		Private m_Function As NFunctionCalculator
		Private m_StockChart As NCartesianChart
		Private m_VolumeChart As NCartesianChart
		Private m_IndicatorChart As NCartesianChart
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents AlignLeftSidesCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents AlignRightSidesCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ChangeDataButton As UI.WinForm.Controls.NButton
		Private m_Header As NLabel

		Public Sub New()
			m_Function = New NFunctionCalculator()
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
			Me.AlignLeftSidesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AlignRightSidesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' AlignLeftSidesCheckBox
			' 
			Me.AlignLeftSidesCheckBox.ButtonProperties.BorderOffset = 2
			Me.AlignLeftSidesCheckBox.Location = New System.Drawing.Point(5, 17)
			Me.AlignLeftSidesCheckBox.Name = "AlignLeftSidesCheckBox"
			Me.AlignLeftSidesCheckBox.Size = New System.Drawing.Size(170, 21)
			Me.AlignLeftSidesCheckBox.TabIndex = 7
			Me.AlignLeftSidesCheckBox.Text = "Align Left Sides"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AlignLeftSidesCheckBox.CheckedChanged += new System.EventHandler(this.AlignLeftSidesCheckBox_CheckedChanged);
			' 
			' AlignRightSidesCheckBox
			' 
			Me.AlignRightSidesCheckBox.ButtonProperties.BorderOffset = 2
			Me.AlignRightSidesCheckBox.Location = New System.Drawing.Point(5, 44)
			Me.AlignRightSidesCheckBox.Name = "AlignRightSidesCheckBox"
			Me.AlignRightSidesCheckBox.Size = New System.Drawing.Size(170, 21)
			Me.AlignRightSidesCheckBox.TabIndex = 8
			Me.AlignRightSidesCheckBox.Text = "Align Right Sides"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AlignRightSidesCheckBox.CheckedChanged += new System.EventHandler(this.AlignRightSidesCheckBox_CheckedChanged);
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(5, 82)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(170, 23)
			Me.ChangeDataButton.TabIndex = 9
			Me.ChangeDataButton.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' NSideGuidelineUC
			' 
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Controls.Add(Me.AlignRightSidesCheckBox)
			Me.Controls.Add(Me.AlignLeftSidesCheckBox)
			Me.Name = "NSideGuidelineUC"
			Me.Size = New System.Drawing.Size(180, 542)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()


			nChartControl1.Panels.Clear()

			' set a chart title
			m_Header = nChartControl1.Labels.AddHeader("Volume Indicators<br/><font size = '10pt'>Demonstrates how to align panels</font>")
			m_Header.TextStyle.TextFormat = TextFormat.XML
			m_Header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			m_Header.ContentAlignment = ContentAlignment.BottomCenter
			m_Header.Margins = New NMarginsL(10, 10, 10, 10)
			m_Header.DockMode = PanelDockMode.Top

			Dim containerPanel As New NDockPanel()
			containerPanel.DockMode = PanelDockMode.Fill
			containerPanel.Margins = New NMarginsL(10, 0, 10, 10)
			nChartControl1.Panels.Add(containerPanel)

			m_StockChart = New NCartesianChart()
			m_StockChart.Axis(StandardAxis.PrimaryX).Visible = False
			m_StockChart.DockMode = PanelDockMode.Top
			m_StockChart.BoundsMode = BoundsMode.Stretch
			m_StockChart.Size = New NSizeL(New NLength(0), New NLength(33, NRelativeUnit.ParentPercentage))
			m_StockChart.Margins = New NMarginsL(10, 0, 10, 10)
			containerPanel.ChildPanels.Add(m_StockChart)

			m_VolumeChart = New NCartesianChart()
			m_VolumeChart.Axis(StandardAxis.PrimaryX).Visible = False
			m_VolumeChart.DockMode = PanelDockMode.Top
			m_VolumeChart.BoundsMode = BoundsMode.Stretch
			m_VolumeChart.Size = New NSizeL(New NLength(0), New NLength(33, NRelativeUnit.ParentPercentage))
			m_VolumeChart.Margins = New NMarginsL(10, 0, 10, 10)
			containerPanel.ChildPanels.Add(m_VolumeChart)

			m_IndicatorChart = New NCartesianChart()
			m_IndicatorChart.DockMode = PanelDockMode.Top
			m_IndicatorChart.BoundsMode = BoundsMode.Stretch
			m_IndicatorChart.Size = New NSizeL(New NLength(0), New NLength(33, NRelativeUnit.ParentPercentage))
			m_IndicatorChart.Margins = New NMarginsL(10, 0, 10, 10)
			containerPanel.ChildPanels.Add(m_IndicatorChart)

			' setup charts
			SetupTimeScale(m_IndicatorChart.Axis(StandardAxis.PrimaryX))
			SetupStockChart(m_StockChart)
			SetupVolumeChart(m_VolumeChart)
			SetupIndicatorChart(m_IndicatorChart)

			' generate data
			UpdateExpression()
			GenerateData()
			CalculateFunction()

			AlignLeftSidesCheckBox.Checked = True
			AlignRightSidesCheckBox.Checked = True
		End Sub

		Private Sub SetupStockChart(ByVal chart As NCartesianChart)
			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.ScaleConfigurator = scaleY

			' setup the stock series
			m_Stock = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.Name = "Price"
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Stick

			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue
			m_Stock.OpenValues.Name = "open"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"
			m_Stock.CloseValues.Name = "close"
			m_Stock.CandleWidth = New NLength(0.5F, NRelativeUnit.ParentPercentage)
			m_Stock.UseXValues = True
			m_Stock.InflateMargins = True
		End Sub
		Private Sub SetupVolumeChart(ByVal chart As NCartesianChart)
			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)
			chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator = scaleY
			chart.Axis(StandardAxis.SecondaryY).Visible = True

			' setup the volume series
			m_Volume = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			m_Volume.Name = "Volume"
			m_Volume.Legend.Mode = SeriesLegendMode.None
			m_Volume.FillStyle = New NColorFillStyle(Color.YellowGreen)
			m_Volume.DataLabelStyle.Visible = False
			m_Volume.Values.Name = "volume"
			m_Volume.UseXValues = True
			m_Volume.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_Volume.DisplayOnAxis(StandardAxis.SecondaryY, True)
		End Sub
		Private Sub SetupIndicatorChart(ByVal chart As NCartesianChart)
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' Add line series for function
			m_Line = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.DataLabelStyle.Visible = False
			m_Line.BorderStyle.Color = Color.Blue
			m_Line.UseXValues = True
		End Sub
		Private Sub SetupTimeScale(ByVal axis As NAxis)
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

			axis.ScaleConfigurator = scaleX
		End Sub

		Private Sub UpdateExpression()
			Dim sb As New StringBuilder()

			m_Function.Arguments.Clear()

			m_Function.Arguments.Add(m_Volume.Values)
			m_Function.Arguments.Add(m_Stock.CloseValues)
			m_Function.Arguments.Add(m_Stock.HighValues)
			m_Function.Arguments.Add(m_Stock.LowValues)
			sb.Append("ACCDIST(close; high; low; volume)")
			m_Line.Name = "Accumulation Distribution"

			m_Function.Expression = sb.ToString()
		End Sub
		Private Sub CalculateFunction()
			m_Line.Values = m_Function.Calculate()
		End Sub
		Private Sub GenerateData()
			GenerateOHLCData(m_Stock, prevCloseValue, numDataPoits)
			FillStockDates(m_Stock, numDataPoits, New Date(2010, 1, 11))
			GenerateVolumeData(m_Volume, prevVolumeValue, numDataPoits)

			m_Volume.XValues.Clear()
			m_Volume.XValues.AddRange(m_Stock.XValues)

			m_Line.XValues.Clear()
			m_Line.XValues.AddRange(m_Stock.XValues)
		End Sub
		Private Sub GenerateVolumeData(ByVal series As NSeries, ByVal dValue As Double, ByVal nCount As Integer)
			m_Volume.ClearDataPoints()

			For i As Integer = 0 To nCount - 1
				If dValue <= 0 Then
					dValue += 15
				End If

				m_Volume.Values.Add(dValue)

				dValue += 10 * (0.5 - Random.NextDouble())
			Next i
		End Sub

		Private Sub UpdateGuidelines()
			If nChartControl1 Is Nothing Then
				Return
			End If

			nChartControl1.Document.RootPanel.Guidelines.Clear()

			If AlignLeftSidesCheckBox.Checked Then
				Dim leftSideGuideline As New NSideGuideline(PanelSide.Left)

				leftSideGuideline.Targets.Add(m_StockChart)
				leftSideGuideline.Targets.Add(m_VolumeChart)
				leftSideGuideline.Targets.Add(m_IndicatorChart)

				nChartControl1.Document.RootPanel.Guidelines.Add(leftSideGuideline)
			End If

			If AlignRightSidesCheckBox.Checked Then
				Dim rightSideGuideline As New NSideGuideline(PanelSide.Right)

				rightSideGuideline.Targets.Add(m_StockChart)
				rightSideGuideline.Targets.Add(m_VolumeChart)
				rightSideGuideline.Targets.Add(m_IndicatorChart)

				nChartControl1.Document.RootPanel.Guidelines.Add(rightSideGuideline)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub AlignLeftSidesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AlignLeftSidesCheckBox.CheckedChanged
			UpdateGuidelines()
		End Sub

		Private Sub AlignRightSidesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AlignRightSidesCheckBox.CheckedChanged
			UpdateGuidelines()
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ChangeDataButton.Click
			GenerateData()
			CalculateFunction()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
