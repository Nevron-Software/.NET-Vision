Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Text
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVolumeIndicatorsUC
		Inherits NExampleBaseUC

		Private Const numDataPoits As Integer = 200
		Private Const prevCloseValue As Double = 100
		Private Const prevVolumeValue As Double = 100
		Private m_Stock As NStockSeries
		Private m_Volume As NAreaSeries
		Private m_Line As NLineSeries
		Private m_Function As NFunctionCalculator
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private m_ExpressionLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_NewDataBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_FunctionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private m_ParameterLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_ParameterScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_Function = New NFunctionCalculator()
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
			Me.m_NewDataBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ParameterLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_ParameterScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_ExpressionLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_FunctionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' m_NewDataBtn
			' 
			Me.m_NewDataBtn.Location = New System.Drawing.Point(7, 200)
			Me.m_NewDataBtn.Name = "m_NewDataBtn"
			Me.m_NewDataBtn.Size = New System.Drawing.Size(169, 22)
			Me.m_NewDataBtn.TabIndex = 9
			Me.m_NewDataBtn.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			' 
			' m_ParameterLabel
			' 
			Me.m_ParameterLabel.Location = New System.Drawing.Point(134, 150)
			Me.m_ParameterLabel.Name = "m_ParameterLabel"
			Me.m_ParameterLabel.ReadOnly = True
			Me.m_ParameterLabel.Size = New System.Drawing.Size(42, 18)
			Me.m_ParameterLabel.TabIndex = 8
			' 
			' m_ParameterScroll
			' 
			Me.m_ParameterScroll.LargeChange = 1
			Me.m_ParameterScroll.Location = New System.Drawing.Point(7, 150)
			Me.m_ParameterScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.m_ParameterScroll.Name = "m_ParameterScroll"
			Me.m_ParameterScroll.Size = New System.Drawing.Size(121, 18)
			Me.m_ParameterScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ParameterScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.StartValueScroll_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 130)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(169, 16)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Parameter:"
			' 
			' m_ExpressionLabel
			' 
			Me.m_ExpressionLabel.Location = New System.Drawing.Point(7, 87)
			Me.m_ExpressionLabel.Name = "m_ExpressionLabel"
			Me.m_ExpressionLabel.ReadOnly = True
			Me.m_ExpressionLabel.Size = New System.Drawing.Size(169, 18)
			Me.m_ExpressionLabel.TabIndex = 11
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 68)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(169, 17)
			Me.label2.TabIndex = 10
			Me.label2.Text = "Expression:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 8)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(169, 16)
			Me.label3.TabIndex = 13
			Me.label3.Text = "Function:"
			' 
			' m_FunctionCombo
			' 
			Me.m_FunctionCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_FunctionCombo.ListProperties.DataSource = Nothing
			Me.m_FunctionCombo.ListProperties.DisplayMember = ""
			Me.m_FunctionCombo.Location = New System.Drawing.Point(7, 26)
			Me.m_FunctionCombo.Name = "m_FunctionCombo"
			Me.m_FunctionCombo.Size = New System.Drawing.Size(169, 21)
			Me.m_FunctionCombo.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			' 
			' NVolumeIndicatorsUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_FunctionCombo)
			Me.Controls.Add(Me.m_ExpressionLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.m_NewDataBtn)
			Me.Controls.Add(Me.m_ParameterLabel)
			Me.Controls.Add(Me.m_ParameterScroll)
			Me.Controls.Add(Me.label1)
			Me.Name = "NVolumeIndicatorsUC"
			Me.Size = New System.Drawing.Size(180, 235)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Volume Indicators<br/><font size = '10pt'>Demonstrates how to use build in financial functions</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the legend position
			nChartControl1.Legends(0).Location = New NPointL(New NLength(95, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup charts
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			SetupTimeScale(chart.Axis(StandardAxis.PrimaryX))
			SetupStockChart(chart)
			SetupVolumeChart(chart)
			SetupIndicatorChart(chart)

			' generate data
			GenerateData()

			' form controls
			m_FunctionCombo.Items.Add("Accumulation Distribution")
			m_FunctionCombo.Items.Add("Chaikin Oscillator")
			m_FunctionCombo.Items.Add("Ease of Movement")
			m_FunctionCombo.Items.Add("Money Flow Index")
			m_FunctionCombo.Items.Add("Negative Volume Index")
			m_FunctionCombo.Items.Add("On Balance Volume")
			m_FunctionCombo.Items.Add("Positive Volume Index")
			m_FunctionCombo.Items.Add("Price and Volume Trend")

			m_FunctionCombo.SelectedIndex = 0
			m_ParameterScroll.Value = 10
		End Sub

		Private Sub SetupStockChart(ByVal chart As NCartesianChart)
			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 50, 100)
			axisY.ScaleConfigurator = scaleY
			axisY.Visible = True

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

			Dim axisY As NAxis = chart.Axis(StandardAxis.SecondaryY)
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 25, 45)
			axisY.ScaleConfigurator = scaleY
			axisY.Visible = True

			' setup the volume series
			m_Volume = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			m_Volume.Name = "Volume"
			m_Volume.Legend.Mode = SeriesLegendMode.None
			m_Volume.FillStyle = New NColorFillStyle(Color.YellowGreen)
			m_Volume.DataLabelStyle.Visible = False
			m_Volume.Values.Name = "volume"
			m_Volume.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_Volume.DisplayOnAxis(axisY.AxisId, True)
			m_Volume.UseXValues = True
		End Sub
		Private Sub SetupIndicatorChart(ByVal chart As NCartesianChart)
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim axes As NCartesianAxisCollection = CType(chart.Axes, NCartesianAxisCollection)
			Dim axisY As NAxis = axes.AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft)
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 0, 20)
			axisY.ScaleConfigurator = scaleY
			axisY.Visible = True

			' Add line series for function
			m_Line = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.DataLabelStyle.Visible = False
			m_Line.BorderStyle.Color = Color.Blue
			m_Line.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_Line.DisplayOnAxis(axisY.AxisId, True)
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
			Dim nParam As Integer = m_ParameterScroll.Value
			Dim sb As New StringBuilder()

			m_Function.Arguments.Clear()

			Select Case m_FunctionCombo.SelectedIndex
				Case 0
					m_Function.Arguments.Add(m_Volume.Values)
					m_Function.Arguments.Add(m_Stock.CloseValues)
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.Append("ACCDIST(close; high; low; volume)")
					m_Line.Name = "Accumulation Distribution"
					m_ParameterScroll.Enabled = False
					m_ParameterLabel.Enabled = False

				Case 1
					m_Function.Arguments.Add(m_Volume.Values)
					m_Function.Arguments.Add(m_Stock.CloseValues)
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.Append("CHOSC(close; high; low; volume; 3; 10)")
					m_Line.Name = "Chaikin Oscillator"
					m_ParameterScroll.Enabled = False
					m_ParameterLabel.Enabled = False

				Case 2
					m_Function.Arguments.Add(m_Volume.Values)
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.Append("EMV(high; low; volume)")
					m_Line.Name = "Ease of Movement"
					m_ParameterScroll.Enabled = False
					m_ParameterLabel.Enabled = False

				Case 3
					m_Function.Arguments.Add(m_Volume.Values)
					m_Function.Arguments.Add(m_Stock.CloseValues)
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.AppendFormat("MFI(close; high; low; volume; {0})", nParam)
					m_Line.Name = "Money Flow Index"
					m_ParameterScroll.Enabled = True
					m_ParameterLabel.Enabled = True

				Case 4
					m_Function.Arguments.Add(m_Volume.Values)
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("NVI(close; volume; {0})", nParam)
					m_Line.Name = "Negative Volume Index"
					m_ParameterScroll.Enabled = True
					m_ParameterLabel.Enabled = True

				Case 5
					m_Function.Arguments.Add(m_Volume.Values)
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("OBV(close; volume; {0})", prevVolumeValue)
					m_Line.Name = "On Balance Volume"
					m_ParameterScroll.Enabled = False
					m_ParameterLabel.Enabled = False

				Case 6
					m_Function.Arguments.Add(m_Volume.Values)
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("PVI(close; volume; {0})", nParam)
					m_Line.Name = "Positive Volume Index"
					m_ParameterScroll.Enabled = True
					m_ParameterLabel.Enabled = True

				Case 7
					m_Function.Arguments.Add(m_Volume.Values)
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.Append("PVT(close; volume; 0)")
					m_Line.Name = "Price and Volume Trend"
					m_ParameterScroll.Enabled = False
					m_ParameterLabel.Enabled = False

				Case Else
					Debug.Assert(False)
					Return
			End Select

			m_Function.Expression = sb.ToString()

			m_ParameterLabel.Text = nParam.ToString()
			m_ExpressionLabel.Text = m_Function.Expression
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

		Private Sub NewDataBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_NewDataBtn.Click
			GenerateData()
			CalculateFunction()

			nChartControl1.Refresh()
		End Sub
		Private Sub StartValueScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles m_ParameterScroll.ValueChanged
			UpdateExpression()
			CalculateFunction()

			nChartControl1.Refresh()
		End Sub
		Private Sub FunctionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FunctionCombo.SelectedIndexChanged
			UpdateExpression()
			CalculateFunction()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace