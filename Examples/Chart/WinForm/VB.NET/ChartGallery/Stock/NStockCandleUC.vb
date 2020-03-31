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
	Public Class NStockCandleUC
		Inherits NExampleBaseUC

		Private m_Stock As NStockSeries
		Private WithEvents UpColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DownColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowHighLowLine As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HighLowLineColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DownLineColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents UpLineColor As Nevron.UI.WinForm.Controls.NButton
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
			Me.UpColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.DownColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowHighLowLine = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HighLowLineColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.DownLineColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.UpLineColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' UpColor
			' 
			Me.UpColor.Location = New System.Drawing.Point(5, 10)
			Me.UpColor.Name = "UpColor"
			Me.UpColor.Size = New System.Drawing.Size(170, 23)
			Me.UpColor.TabIndex = 0
			Me.UpColor.Text = "Up Candle Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpColor.Click += new System.EventHandler(this.UpColor_Click);
			' 
			' DownColor
			' 
			Me.DownColor.Location = New System.Drawing.Point(5, 79)
			Me.DownColor.Name = "DownColor"
			Me.DownColor.Size = New System.Drawing.Size(170, 23)
			Me.DownColor.TabIndex = 2
			Me.DownColor.Text = "Down Candle Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownColor.Click += new System.EventHandler(this.DownColor_Click);
			' 
			' ShowHighLowLine
			' 
			Me.ShowHighLowLine.ButtonProperties.BorderOffset = 2
			Me.ShowHighLowLine.Location = New System.Drawing.Point(5, 176)
			Me.ShowHighLowLine.Name = "ShowHighLowLine"
			Me.ShowHighLowLine.Size = New System.Drawing.Size(170, 24)
			Me.ShowHighLowLine.TabIndex = 5
			Me.ShowHighLowLine.Text = "Show High Low Line"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowHighLowLine.CheckedChanged += new System.EventHandler(this.ShowHighLowLine_CheckedChanged);
			' 
			' HighLowLineColor
			' 
			Me.HighLowLineColor.Location = New System.Drawing.Point(5, 149)
			Me.HighLowLineColor.Name = "HighLowLineColor"
			Me.HighLowLineColor.Size = New System.Drawing.Size(170, 23)
			Me.HighLowLineColor.TabIndex = 4
			Me.HighLowLineColor.Text = "High Low Line..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HighLowLineColor.Click += new System.EventHandler(this.HighLowLineColor_Click);
			' 
			' DownLineColor
			' 
			Me.DownLineColor.Location = New System.Drawing.Point(5, 107)
			Me.DownLineColor.Name = "DownLineColor"
			Me.DownLineColor.Size = New System.Drawing.Size(170, 23)
			Me.DownLineColor.TabIndex = 3
			Me.DownLineColor.Text = "Down Candle Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownLineColor.Click += new System.EventHandler(this.DownLineColor_Click);
			' 
			' UpLineColor
			' 
			Me.UpLineColor.Location = New System.Drawing.Point(5, 38)
			Me.UpLineColor.Name = "UpLineColor"
			Me.UpLineColor.Size = New System.Drawing.Size(170, 23)
			Me.UpLineColor.TabIndex = 1
			Me.UpLineColor.Text = "Up Candle Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpLineColor.Click += new System.EventHandler(this.UpLineColor_Click);
			' 
			' ShadowButton
			' 
			Me.ShadowButton.Location = New System.Drawing.Point(5, 229)
			Me.ShadowButton.Name = "ShadowButton"
			Me.ShadowButton.Size = New System.Drawing.Size(170, 23)
			Me.ShadowButton.TabIndex = 6
			Me.ShadowButton.Text = "Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			' 
			' NStockCandleUC
			' 
			Me.Controls.Add(Me.ShadowButton)
			Me.Controls.Add(Me.DownLineColor)
			Me.Controls.Add(Me.UpLineColor)
			Me.Controls.Add(Me.HighLowLineColor)
			Me.Controls.Add(Me.ShowHighLowLine)
			Me.Controls.Add(Me.DownColor)
			Me.Controls.Add(Me.UpColor)
			Me.Name = "NStockCandleUC"
			Me.Size = New System.Drawing.Size(180, 278)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Candle Stock Chart")
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
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back }
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

			' add some stock items
			Const numDataPoints As Integer = 50
			GenerateOHLCData(m_Stock, 100.0, numDataPoints, New NRange1DD(60, 140))
			FillStockDates(m_Stock, numDataPoints)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			ShowHighLowLine.Checked = True
		End Sub

		Private Sub UpColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpColor.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Stock.UpFillStyle, fillStyleResult) Then
				m_Stock.UpFillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub UpLineColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpLineColor.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Stock.UpStrokeStyle, strokeStyleResult) Then
				m_Stock.UpStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub DownColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownColor.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Stock.DownFillStyle, fillStyleResult) Then
				m_Stock.DownFillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub DownLineColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownLineColor.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Stock.DownStrokeStyle, strokeStyleResult) Then
				m_Stock.DownStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub HighLowLineColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HighLowLineColor.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Stock.HighLowStrokeStyle, strokeStyleResult) Then
				m_Stock.HighLowStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub ShowHighLowLine_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowHighLowLine.CheckedChanged
			m_Stock.ShowHighLow = ShowHighLowLine.Checked
			nChartControl1.Refresh()
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
