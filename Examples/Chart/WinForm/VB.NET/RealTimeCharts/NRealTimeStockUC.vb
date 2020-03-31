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
Imports Nevron.Chart.Functions
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRealTimeStockUC
		Inherits NRealTimeExampleBaseUC

		Private WithEvents UseHardwareAccelerationCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents StopStartTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ResetButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private components As System.ComponentModel.IContainer

		Private m_LineSMA As NLineSeries
		Private m_Chart As NCartesianChart
		Private m_Stock As NStockSeries
		Private m_PrevClose As Double = 300.0
		Private m_Start As Date = Date.Now

		Private m_OpenValues() As Double
		Private m_HighValues() As Double
		Private m_LowValues() As Double
		Private m_CloseValues() As Double
		Private WithEvents NumberOfDataPointsComboBox As UI.WinForm.Controls.NComboBox
		Private m_XValues() As Double

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
			Me.ResetButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.StopStartTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.UseHardwareAccelerationCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.NumberOfDataPointsComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 103)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 16)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Number of Data Points:"
			' 
			' ResetButton
			' 
			Me.ResetButton.Location = New System.Drawing.Point(7, 71)
			Me.ResetButton.Name = "ResetButton"
			Me.ResetButton.Size = New System.Drawing.Size(153, 23)
			Me.ResetButton.TabIndex = 2
			Me.ResetButton.Text = "Reset"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 132)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(47, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Bottom:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 94)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(47, 16)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Right:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(47, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Top:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 19)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(47, 16)
			Me.label5.TabIndex = 5
			Me.label5.Text = "Left:"
			' 
			' StopStartTimerButton
			' 
			Me.StopStartTimerButton.Location = New System.Drawing.Point(7, 42)
			Me.StopStartTimerButton.Name = "StopStartTimerButton"
			Me.StopStartTimerButton.Size = New System.Drawing.Size(153, 23)
			Me.StopStartTimerButton.TabIndex = 1
			Me.StopStartTimerButton.Text = "Stop Timer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			' 
			' UseHardwareAccelerationCheckBox
			' 
			Me.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseHardwareAccelerationCheckBox.Location = New System.Drawing.Point(7, 12)
			Me.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox"
			Me.UseHardwareAccelerationCheckBox.Size = New System.Drawing.Size(170, 24)
			Me.UseHardwareAccelerationCheckBox.TabIndex = 0
			Me.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			' 
			' NumberOfDataPointsComboBox
			' 
			Me.NumberOfDataPointsComboBox.ListProperties.CheckBoxDataMember = ""
			Me.NumberOfDataPointsComboBox.ListProperties.DataSource = Nothing
			Me.NumberOfDataPointsComboBox.ListProperties.DisplayMember = ""
			Me.NumberOfDataPointsComboBox.Location = New System.Drawing.Point(10, 122)
			Me.NumberOfDataPointsComboBox.Name = "NumberOfDataPointsComboBox"
			Me.NumberOfDataPointsComboBox.Size = New System.Drawing.Size(153, 21)
			Me.NumberOfDataPointsComboBox.TabIndex = 4
			Me.NumberOfDataPointsComboBox.Text = "comboBox2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NumberOfDataPointsComboBox.SelectedIndexChanged += new System.EventHandler(this.NumberOfDataPointsComboBox_SelectedIndexChanged);
			' 
			' NRealTimeStockUC
			' 
			Me.Controls.Add(Me.NumberOfDataPointsComboBox)
			Me.Controls.Add(Me.UseHardwareAccelerationCheckBox)
			Me.Controls.Add(Me.StopStartTimerButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ResetButton)
			Me.Name = "NRealTimeStockUC"
			Me.Size = New System.Drawing.Size(183, 442)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()
			' set a chart title
			Dim title As New NLabel("Real Time Stock")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			nChartControl1.Panels.Add(title)

			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' add interlace stripes
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.StripStyles.Add(stripStyle)

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NRangeTimelineScaleConfigurator()

			' enable range selection
			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			m_Chart.RangeSelections.Add(rangeSelection)

			' enable zooming and scrolling
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = New NDateTimeAxisPagingView()

			m_LineSMA = New NLineSeries()

			' create a line series for the simple moving average
			m_Chart.Series.Add(m_LineSMA)

			m_LineSMA.Name = "SMA(20)"
			m_LineSMA.DataLabelStyle.Visible = False
			m_LineSMA.BorderStyle.Color = Color.DarkOrange
			m_LineSMA.UseXValues = True

			' create the stock series
			m_Stock = New NStockSeries()
			m_Chart.Series.Add(m_Stock)
			m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, True)

			m_Stock.Name = "Stock Data"
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Bar
			m_Stock.CandleWidth = New NLength(0.8F, NRelativeUnit.ParentPercentage)
			m_Stock.InflateMargins = True
			m_Stock.UseXValues = True
			m_Stock.UpFillStyle = New NColorFillStyle(LightOrange)
			m_Stock.UpStrokeStyle.Color = Color.Black
			m_Stock.DownFillStyle = New NColorFillStyle(DarkOrange)
			m_Stock.DownStrokeStyle.Color = Color.Black
			m_Stock.OpenValues.Name = "open"
			m_Stock.CloseValues.Name = "close"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())
			nChartControl1.Controller.Tools.Add(New NDataPanTool())

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			NumberOfDataPointsComboBox.Items.Add("1000")
			NumberOfDataPointsComboBox.Items.Add("5000")
			NumberOfDataPointsComboBox.Items.Add("10000")
			NumberOfDataPointsComboBox.SelectedIndex = 1

			AddData()

			UseHardwareAccelerationCheckBox.Checked = True
			StartTimer()
		End Sub

		Private Sub AddData()
			Dim nCount As Integer = 200
			Dim s As NStockSeries = m_Stock
			Dim open, high, low, close As Double

			If m_OpenValues Is Nothing OrElse m_OpenValues.Length < nCount Then
				m_OpenValues = New Double(nCount - 1){}
				m_HighValues = New Double(nCount - 1){}
				m_LowValues = New Double(nCount - 1){}
				m_CloseValues = New Double(nCount - 1){}
				m_XValues = New Double(nCount - 1){}
			End If

			For index As Integer = 0 To nCount - 1
				open = m_PrevClose

				If m_PrevClose < 25 OrElse Random.NextDouble() > 0.5 Then
					' upward price change
					close = open + (2 + (Random.NextDouble() * 20))
					high = close + (Random.NextDouble() * 10)
					low = open - (Random.NextDouble() * 10)
				Else
					' downward price change
					close = open - (2 + (Random.NextDouble() * 20))
					high = open + (Random.NextDouble() * 10)
					low = close - (Random.NextDouble() * 10)
				End If

				If low < 1 Then
					low = 1
				End If

				m_PrevClose = close

				m_OpenValues(index) = open
				m_HighValues(index) = high
				m_LowValues(index) = low
				m_CloseValues(index) = close
				m_XValues(index) = m_Start.ToOADate()

				' advance to next working day
				m_Start = m_Start.AddDays(1)
			Next index

			s.OpenValues.AddRange(m_OpenValues, 0, nCount)
			s.HighValues.AddRange(m_HighValues, 0, nCount)
			s.LowValues.AddRange(m_LowValues, 0, nCount)
			s.CloseValues.AddRange(m_CloseValues, 0, nCount)
			s.XValues.AddRange(m_XValues, 0, nCount)

			Dim period As Integer = 20

			' create a function calculator
			Dim fc As New NFunctionCalculator()
			fc.Arguments.Add(m_Stock.CloseValues)

			' calculate the simple moving average
			fc.Expression = "SMA(close; " & period.ToString() & ")"
			m_LineSMA.Values = fc.Calculate()
			m_LineSMA.XValues.AddRange(m_XValues, 0, nCount)

			Dim numberOfDataPoints As Integer = 1000

			Select Case NumberOfDataPointsComboBox.SelectedIndex
				Case 0
					numberOfDataPoints = 1000
				Case 1
					numberOfDataPoints = 5000
				Case 2
					numberOfDataPoints = 10000
			End Select

			If s.Values.Count > numberOfDataPoints Then
				s.OpenValues.RemoveRange(0, nCount)
				s.HighValues.RemoveRange(0, nCount)
				s.LowValues.RemoveRange(0, nCount)
				s.CloseValues.RemoveRange(0, nCount)
				s.XValues.RemoveRange(0, nCount)

				m_LineSMA.Values.RemoveRange(0, nCount)
				m_LineSMA.XValues.RemoveRange(0, nCount)
			End If
		End Sub

		Protected Overrides Sub UpdateTitle(ByVal working As Boolean, ByVal cpuUsage As Single)
			Dim title As String = "Real Time Stock"

			If working Then
				title &= " [CPU Usage - " & cpuUsage.ToString("0.") & "%]"
			End If

			nChartControl1.Labels(0).Text = title
		End Sub

		Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetButton.Click
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_PrevClose = 300
			m_Start = Date.Now

			m_Stock.OpenValues.Clear()
			m_Stock.HighValues.Clear()
			m_Stock.LowValues.Clear()
			m_Stock.CloseValues.Clear()
			m_Stock.XValues.Clear()

			m_LineSMA.Values.Clear()
			m_LineSMA.XValues.Clear()
		End Sub

		Protected Overrides Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			 MyBase.OnTimerTick(sender, e)

			AddData()

			nChartControl1.Refresh()
		End Sub

		Private Sub UseHardwareAccelerationCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseHardwareAccelerationCheckBox.CheckedChanged
			If UseHardwareAccelerationCheckBox.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub

		Private Sub StopStartTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StopStartTimerButton.Click
			ToggleTimer()

			If IsTimerRunning() Then
				StopStartTimerButton.Text = "Stop Timer"
			Else
				StopStartTimerButton.Text = "Start Timer"
			End If
		End Sub

		Private Sub NumberOfDataPointsComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NumberOfDataPointsComboBox.SelectedIndexChanged
			ResetButton_Click(Nothing, Nothing)
		End Sub
	End Class
End Namespace
