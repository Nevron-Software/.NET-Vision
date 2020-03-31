Imports System
Imports System.Resources
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStockStickUC
		Inherits NExampleBaseUC

		Private m_Stock As NStockSeries
		Private WithEvents ShowOpen As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowClose As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowHighLow As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DownStickLine As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents UpStickLine As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShadowButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.ShowOpen = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowClose = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.DownStickLine = New Nevron.UI.WinForm.Controls.NButton()
			Me.UpStickLine = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowHighLow = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ShowOpen
			' 
			Me.ShowOpen.ButtonProperties.BorderOffset = 2
			Me.ShowOpen.Location = New System.Drawing.Point(6, 10)
			Me.ShowOpen.Name = "ShowOpen"
			Me.ShowOpen.Size = New System.Drawing.Size(167, 24)
			Me.ShowOpen.TabIndex = 0
			Me.ShowOpen.Text = "Show Open"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowOpen.CheckedChanged += new System.EventHandler(this.ShowOpen_CheckedChanged);
			' 
			' ShowClose
			' 
			Me.ShowClose.ButtonProperties.BorderOffset = 2
			Me.ShowClose.Location = New System.Drawing.Point(6, 34)
			Me.ShowClose.Name = "ShowClose"
			Me.ShowClose.Size = New System.Drawing.Size(167, 24)
			Me.ShowClose.TabIndex = 1
			Me.ShowClose.Text = "Show Close"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowClose.CheckedChanged += new System.EventHandler(this.ShowClose_CheckedChanged);
			' 
			' DownStickLine
			' 
			Me.DownStickLine.Location = New System.Drawing.Point(6, 120)
			Me.DownStickLine.Name = "DownStickLine"
			Me.DownStickLine.Size = New System.Drawing.Size(167, 23)
			Me.DownStickLine.TabIndex = 4
			Me.DownStickLine.Text = "Down Stick Line..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownStickLine.Click += new System.EventHandler(this.DownStickLine_Click);
			' 
			' UpStickLine
			' 
			Me.UpStickLine.Location = New System.Drawing.Point(6, 90)
			Me.UpStickLine.Name = "UpStickLine"
			Me.UpStickLine.Size = New System.Drawing.Size(167, 23)
			Me.UpStickLine.TabIndex = 3
			Me.UpStickLine.Text = "Up Stick Line..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpStickLine.Click += new System.EventHandler(this.UpStickLine_Click);
			' 
			' ShowHighLow
			' 
			Me.ShowHighLow.ButtonProperties.BorderOffset = 2
			Me.ShowHighLow.Location = New System.Drawing.Point(6, 58)
			Me.ShowHighLow.Name = "ShowHighLow"
			Me.ShowHighLow.Size = New System.Drawing.Size(167, 24)
			Me.ShowHighLow.TabIndex = 2
			Me.ShowHighLow.Text = "Show High Low"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowHighLow.CheckedChanged += new System.EventHandler(this.ShowHighLow_CheckedChanged);
			' 
			' ShadowButton
			' 
			Me.ShadowButton.Location = New System.Drawing.Point(6, 150)
			Me.ShadowButton.Name = "ShadowButton"
			Me.ShadowButton.Size = New System.Drawing.Size(167, 23)
			Me.ShadowButton.TabIndex = 5
			Me.ShadowButton.Text = "Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			' 
			' NStockStickUC
			' 
			Me.Controls.Add(Me.ShadowButton)
			Me.Controls.Add(Me.ShowHighLow)
			Me.Controls.Add(Me.DownStickLine)
			Me.Controls.Add(Me.UpStickLine)
			Me.Controls.Add(Me.ShowClose)
			Me.Controls.Add(Me.ShowOpen)
			Me.Name = "NStockStickUC"
			Me.Size = New System.Drawing.Size(180, 196)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stick Stock Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)

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

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.OuterMajorTickStyle.Length = New NLength(3, NGraphicsUnit.Point)
			scaleY.InnerMajorTickStyle.Visible = False

			Dim stripFill As NFillStyle = New NColorFillStyle(Color.FromArgb(234, 233, 237))
			Dim stripStyle As New NScaleStripStyle(stripFill, Nothing, True, 1, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			stripStyle.Interlaced = True
			scaleY.StripStyles.Add(stripStyle)

			' add a stock series
			m_Stock = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.CandleStyle = CandleStyle.Stick
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.UpStrokeStyle.Width = New NLength(1, NGraphicsUnit.Point)
			m_Stock.UpStrokeStyle.Color = Color.Black
			m_Stock.DownStrokeStyle.Width = New NLength(1, NGraphicsUnit.Point)
			m_Stock.DownStrokeStyle.Color = Color.Crimson
			m_Stock.CandleWidth = New NLength(1.3F, NRelativeUnit.ParentPercentage)
			m_Stock.UseXValues = True
			m_Stock.InflateMargins = True

			' add some stock items
			Const count As Integer = 50
			GenerateOHLCData(m_Stock, 100.0, count, New NRange1DD(60, 140))
			FillStockDates(m_Stock, count)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			ShowHighLow.Checked = True
			ShowOpen.Checked = True
			ShowClose.Checked = True
		End Sub

		Private Sub GenerateStockData(ByVal s As NStockSeries, ByVal nCount As Integer)
			Dim prevclose As Double = 300
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			For nIndex As Integer = 0 To nCount - 1
				open = prevclose

				If prevclose < 25 OrElse Random.NextDouble() > 0.5 Then
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

				prevclose = close

				s.OpenValues.Add(open)
				s.HighValues.Add(high)
				s.LowValues.Add(low)
				s.CloseValues.Add(close)
			Next nIndex
		End Sub

		Private Sub ShowOpen_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowOpen.CheckedChanged
			m_Stock.ShowOpen = ShowOpen.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowClose_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowClose.CheckedChanged
			m_Stock.ShowClose = ShowClose.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowHighLow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowHighLow.CheckedChanged
			m_Stock.ShowHighLow = ShowHighLow.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub UpStickLine_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpStickLine.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Stock.UpStrokeStyle, strokeStyleResult) Then
				m_Stock.UpStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub DownStickLine_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownStickLine.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Stock.DownStrokeStyle, strokeStyleResult) Then
				m_Stock.DownStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub ShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShadowButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing

			If NShadowStyleTypeEditor.Edit(m_Stock.ShadowStyle, shadowStyleResult) Then
				m_Stock.ShadowStyle = shadowStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace