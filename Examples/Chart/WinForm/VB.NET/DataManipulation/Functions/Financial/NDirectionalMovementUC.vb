Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports System.Text
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDirectionalMovementUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Stock As NStockSeries
		Private m_LineDIPos As NLineSeries
		Private m_LineDINeg As NLineSeries
		Private m_LineADX As NLineSeries
		Private m_Calc As NFunctionCalculator
		Private label1 As System.Windows.Forms.Label
		Private m_DIPosLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private m_DINegLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private m_ADXLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private m_PeriodLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_PeriodScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents m_NewDataBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_ShowPosCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_ShowNegCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_ShowADXCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_Calc = New NFunctionCalculator()
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
			Me.m_PeriodScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.m_PeriodLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_NewDataBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ShowPosCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_ShowNegCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_ShowADXCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_DIPosLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_DINegLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_ADXLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 12)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(42, 14)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Period:"
			' 
			' m_PeriodScroll
			' 
			Me.m_PeriodScroll.Location = New System.Drawing.Point(55, 9)
			Me.m_PeriodScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.m_PeriodScroll.Name = "m_PeriodScroll"
			Me.m_PeriodScroll.Size = New System.Drawing.Size(66, 18)
			Me.m_PeriodScroll.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_PeriodScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PeriodScroll_Scroll);
			' 
			' m_PeriodLabel
			' 
			Me.m_PeriodLabel.Location = New System.Drawing.Point(123, 9)
			Me.m_PeriodLabel.Name = "m_PeriodLabel"
			Me.m_PeriodLabel.ReadOnly = True
			Me.m_PeriodLabel.Size = New System.Drawing.Size(43, 18)
			Me.m_PeriodLabel.TabIndex = 4
			' 
			' m_NewDataBtn
			' 
			Me.m_NewDataBtn.Location = New System.Drawing.Point(7, 246)
			Me.m_NewDataBtn.Name = "m_NewDataBtn"
			Me.m_NewDataBtn.Size = New System.Drawing.Size(161, 22)
			Me.m_NewDataBtn.TabIndex = 5
			Me.m_NewDataBtn.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			' 
			' m_ShowPosCheck
			' 
			Me.m_ShowPosCheck.ButtonProperties.BorderOffset = 2
			Me.m_ShowPosCheck.Location = New System.Drawing.Point(7, 45)
			Me.m_ShowPosCheck.Name = "m_ShowPosCheck"
			Me.m_ShowPosCheck.Size = New System.Drawing.Size(75, 23)
			Me.m_ShowPosCheck.TabIndex = 6
			Me.m_ShowPosCheck.Text = "Show +DI"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ShowPosCheck.CheckedChanged += new System.EventHandler(this.ShowPosCheck_CheckedChanged);
			' 
			' m_ShowNegCheck
			' 
			Me.m_ShowNegCheck.ButtonProperties.BorderOffset = 2
			Me.m_ShowNegCheck.Location = New System.Drawing.Point(7, 103)
			Me.m_ShowNegCheck.Name = "m_ShowNegCheck"
			Me.m_ShowNegCheck.Size = New System.Drawing.Size(77, 22)
			Me.m_ShowNegCheck.TabIndex = 7
			Me.m_ShowNegCheck.Text = "Show -DI"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ShowNegCheck.CheckedChanged += new System.EventHandler(this.ShowNegCheck_CheckedChanged);
			' 
			' m_ShowADXCheck
			' 
			Me.m_ShowADXCheck.ButtonProperties.BorderOffset = 2
			Me.m_ShowADXCheck.Location = New System.Drawing.Point(7, 160)
			Me.m_ShowADXCheck.Name = "m_ShowADXCheck"
			Me.m_ShowADXCheck.Size = New System.Drawing.Size(80, 24)
			Me.m_ShowADXCheck.TabIndex = 8
			Me.m_ShowADXCheck.Text = "Show ADX"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ShowADXCheck.CheckedChanged += new System.EventHandler(this.ShowADXCheck_CheckedChanged);
			' 
			' m_DIPosLabel
			' 
			Me.m_DIPosLabel.Location = New System.Drawing.Point(7, 72)
			Me.m_DIPosLabel.Name = "m_DIPosLabel"
			Me.m_DIPosLabel.ReadOnly = True
			Me.m_DIPosLabel.Size = New System.Drawing.Size(160, 18)
			Me.m_DIPosLabel.TabIndex = 9
			' 
			' m_DINegLabel
			' 
			Me.m_DINegLabel.Location = New System.Drawing.Point(7, 127)
			Me.m_DINegLabel.Name = "m_DINegLabel"
			Me.m_DINegLabel.ReadOnly = True
			Me.m_DINegLabel.Size = New System.Drawing.Size(159, 18)
			Me.m_DINegLabel.TabIndex = 10
			' 
			' m_ADXLabel
			' 
			Me.m_ADXLabel.Location = New System.Drawing.Point(7, 184)
			Me.m_ADXLabel.Name = "m_ADXLabel"
			Me.m_ADXLabel.ReadOnly = True
			Me.m_ADXLabel.Size = New System.Drawing.Size(161, 18)
			Me.m_ADXLabel.TabIndex = 11
			' 
			' NDirectionalMovementUC
			' 
			Me.Controls.Add(Me.m_ADXLabel)
			Me.Controls.Add(Me.m_DINegLabel)
			Me.Controls.Add(Me.m_DIPosLabel)
			Me.Controls.Add(Me.m_ShowADXCheck)
			Me.Controls.Add(Me.m_ShowNegCheck)
			Me.Controls.Add(Me.m_ShowPosCheck)
			Me.Controls.Add(Me.m_NewDataBtn)
			Me.Controls.Add(Me.m_PeriodLabel)
			Me.Controls.Add(Me.m_PeriodScroll)
			Me.Controls.Add(Me.label1)
			Me.Name = "NDirectionalMovementUC"
			Me.Size = New System.Drawing.Size(180, 289)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Directional Movement")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

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
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup primary Y axis
			Dim axisY1 As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			axisY1.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 45, 100)

			Dim scaleY1 As NLinearScaleConfigurator = CType(axisY1.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY1.RulerStyle.Height = New NLength(2, NGraphicsUnit.Pixel)
			scaleY1.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY1.InnerMajorTickStyle.LineStyle.Width = New NLength(0)

			' setup secondary Y axis
			Dim axisY2 As NAxis = m_Chart.Axis(StandardAxis.SecondaryY)
			axisY2.Visible = True
			axisY2.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 0, 40)

			Dim scaleY2 As NLinearScaleConfigurator = CType(axisY2.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY2.RulerStyle.Height = New NLength(2, NGraphicsUnit.Pixel)
			scaleY2.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY2.InnerMajorTickStyle.LineStyle.Width = New NLength(0)

			Dim color1 As Color = Color.FromArgb(100, 100, 150)
			Dim color2 As Color = Color.FromArgb(200, 120, 120)
			Dim color3 As Color = Color.FromArgb(100, 150, 100)

			' setup the stock series
			m_Stock = CType(m_Chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Stick
			m_Stock.UpStrokeStyle.Color = color1
			m_Stock.DownStrokeStyle.Color = color2
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.CandleWidth = New NLength(0.5F, NRelativeUnit.ParentPercentage)
			m_Stock.UseXValues = True
			m_Stock.InflateMargins = True

			' Add line series for ADX
			m_LineADX = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_LineADX.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_LineADX.DisplayOnAxis(StandardAxis.SecondaryY, True)
			m_LineADX.BorderStyle.Color = Color.LimeGreen
			m_LineADX.Name = "ADX"
			m_LineADX.DataLabelStyle.Visible = False
			m_LineADX.UseXValues = True

			' Add line series for +DI
			m_LineDIPos = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_LineDIPos.MultiLineMode = MultiLineMode.Overlapped
			m_LineDIPos.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_LineDIPos.DisplayOnAxis(StandardAxis.SecondaryY, True)
			m_LineDIPos.BorderStyle.Color = color2
			m_LineDIPos.Name = "+DI"
			m_LineDIPos.DataLabelStyle.Visible = False
			m_LineDIPos.UseXValues = True

			' Add line series for -DI
			m_LineDINeg = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_LineDINeg.MultiLineMode = MultiLineMode.Overlapped
			m_LineDINeg.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_LineDINeg.DisplayOnAxis(StandardAxis.SecondaryY, True)
			m_LineDINeg.BorderStyle.Color = color1
			m_LineDINeg.Name = "-DI"
			m_LineDINeg.DataLabelStyle.Visible = False
			m_LineDINeg.UseXValues = True

			' add arguments for function calculator
			m_Stock.CloseValues.Name = "close"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"
			m_Calc.Arguments.Add(m_Stock.CloseValues)
			m_Calc.Arguments.Add(m_Stock.HighValues)
			m_Calc.Arguments.Add(m_Stock.LowValues)

			' form controls
			m_PeriodScroll.Value = 14
			m_ShowPosCheck.Checked = True
			m_ShowNegCheck.Checked = True
			m_ShowADXCheck.Checked = True

			GenerateData()
			UpdateFunctions()
		End Sub

		Private Sub GenerateData()
			Const initialPrice As Double = 100
			Const numDataPoits As Integer = 100

			GenerateOHLCData(m_Stock, initialPrice, numDataPoits)
			FillStockDates(m_Stock, numDataPoits, New Date(2010, 1, 11))
			CopyStockDates()
		End Sub
		Private Sub UpdateFunctions()
			Dim sb As New StringBuilder()
			Dim nPeriod As Integer = m_PeriodScroll.Value

			sb.AppendFormat("DI_POS(close; high; low; {0})", nPeriod)
			m_Calc.Expression = sb.ToString()
			m_LineDIPos.Values = m_Calc.Calculate()
			m_DIPosLabel.Text = m_Calc.Expression

			sb.Remove(0, sb.Length)
			sb.AppendFormat("DI_NEG(close; high; low; {0})", nPeriod)
			m_Calc.Expression = sb.ToString()
			m_LineDINeg.Values = m_Calc.Calculate()
			m_DINegLabel.Text = m_Calc.Expression

			sb.Remove(0, sb.Length)
			sb.AppendFormat("MMA(DMI(close; high; low; {0}); {0})", nPeriod)
			m_Calc.Expression = sb.ToString()
			m_LineADX.Values = m_Calc.Calculate()
			m_ADXLabel.Text = m_Calc.Expression

			m_PeriodLabel.Text = nPeriod.ToString()
		End Sub
		Private Sub CopyStockDates()
			m_LineADX.XValues.Clear()
			m_LineADX.XValues.AddRange(m_Stock.XValues)

			m_LineDINeg.XValues.Clear()
			m_LineDINeg.XValues.AddRange(m_Stock.XValues)

			m_LineDIPos.XValues.Clear()
			m_LineDIPos.XValues.AddRange(m_Stock.XValues)
		End Sub

		Private Sub NewDataBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_NewDataBtn.Click
			GenerateData()
			UpdateFunctions()
			nChartControl1.Refresh()
		End Sub
		Private Sub PeriodScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles m_PeriodScroll.ValueChanged
			UpdateFunctions()
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowPosCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowPosCheck.CheckedChanged
			m_LineDIPos.Visible = m_ShowPosCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowNegCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowNegCheck.CheckedChanged
			m_LineDINeg.Visible = m_ShowNegCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowADXCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowADXCheck.CheckedChanged
			m_LineADX.Visible = m_ShowADXCheck.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace