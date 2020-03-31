Imports System
Imports System.Resources
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
	Public Class NValueTimelineScaleUC
		Inherits NExampleBaseUC

		Private m_Chart As NCartesianChart
		Private m_Stock As NStockSeries

		Private WithEvents DailyDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents WeeklyDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MonthlyDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents YearyDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FirstRowVisibleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SecondRowVisibleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ThirdRowVisibleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.DailyDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.WeeklyDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MonthlyDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.YearyDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.FirstRowVisibleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SecondRowVisibleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ThirdRowVisibleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' DailyDataButton
			' 
			Me.DailyDataButton.Location = New System.Drawing.Point(13, 100)
			Me.DailyDataButton.Name = "DailyDataButton"
			Me.DailyDataButton.Size = New System.Drawing.Size(153, 23)
			Me.DailyDataButton.TabIndex = 4
			Me.DailyDataButton.Text = "Daily Data"
			Me.DailyDataButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DailyDataButton.Click += new System.EventHandler(this.DailyDataButton_Click);
			' 
			' WeeklyDataButton
			' 
			Me.WeeklyDataButton.Location = New System.Drawing.Point(13, 129)
			Me.WeeklyDataButton.Name = "WeeklyDataButton"
			Me.WeeklyDataButton.Size = New System.Drawing.Size(153, 23)
			Me.WeeklyDataButton.TabIndex = 6
			Me.WeeklyDataButton.Text = "Weekly Data"
			Me.WeeklyDataButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WeeklyDataButton.Click += new System.EventHandler(this.WeeklyDataButton_Click);
			' 
			' MonthlyDataButton
			' 
			Me.MonthlyDataButton.Location = New System.Drawing.Point(13, 158)
			Me.MonthlyDataButton.Name = "MonthlyDataButton"
			Me.MonthlyDataButton.Size = New System.Drawing.Size(153, 23)
			Me.MonthlyDataButton.TabIndex = 7
			Me.MonthlyDataButton.Text = "Monthly Data"
			Me.MonthlyDataButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MonthlyDataButton.Click += new System.EventHandler(this.MonthlyDataButton_Click);
			' 
			' YearyDataButton
			' 
			Me.YearyDataButton.Location = New System.Drawing.Point(13, 187)
			Me.YearyDataButton.Name = "YearyDataButton"
			Me.YearyDataButton.Size = New System.Drawing.Size(153, 23)
			Me.YearyDataButton.TabIndex = 8
			Me.YearyDataButton.Text = "Yearly Data"
			Me.YearyDataButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YearyDataButton.Click += new System.EventHandler(this.YearyDataButton_Click);
			' 
			' FirstRowVisibleCheckBox
			' 
			Me.FirstRowVisibleCheckBox.AutoSize = True
			Me.FirstRowVisibleCheckBox.ButtonProperties.BorderOffset = 2
			Me.FirstRowVisibleCheckBox.Location = New System.Drawing.Point(13, 10)
			Me.FirstRowVisibleCheckBox.Name = "FirstRowVisibleCheckBox"
			Me.FirstRowVisibleCheckBox.Size = New System.Drawing.Size(103, 17)
			Me.FirstRowVisibleCheckBox.TabIndex = 19
			Me.FirstRowVisibleCheckBox.Text = "First Row Visible"
			Me.FirstRowVisibleCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.FirstRowVisibleCheckBox_CheckedChanged);
			' 
			' SecondRowVisibleCheckBox
			' 
			Me.SecondRowVisibleCheckBox.AutoSize = True
			Me.SecondRowVisibleCheckBox.ButtonProperties.BorderOffset = 2
			Me.SecondRowVisibleCheckBox.Location = New System.Drawing.Point(13, 33)
			Me.SecondRowVisibleCheckBox.Name = "SecondRowVisibleCheckBox"
			Me.SecondRowVisibleCheckBox.Size = New System.Drawing.Size(121, 17)
			Me.SecondRowVisibleCheckBox.TabIndex = 18
			Me.SecondRowVisibleCheckBox.Text = "Second Row Visible"
			Me.SecondRowVisibleCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.SecondRowVisibleCheckBox_CheckedChanged);
			' 
			' ThirdRowVisibleCheckBox
			' 
			Me.ThirdRowVisibleCheckBox.AutoSize = True
			Me.ThirdRowVisibleCheckBox.ButtonProperties.BorderOffset = 2
			Me.ThirdRowVisibleCheckBox.Location = New System.Drawing.Point(13, 56)
			Me.ThirdRowVisibleCheckBox.Name = "ThirdRowVisibleCheckBox"
			Me.ThirdRowVisibleCheckBox.Size = New System.Drawing.Size(108, 17)
			Me.ThirdRowVisibleCheckBox.TabIndex = 17
			Me.ThirdRowVisibleCheckBox.Text = "Third Row Visible"
			Me.ThirdRowVisibleCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.ThirdRowVisibleCheckBox_CheckedChanged);
			' 
			' NValueTimelineScaleUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.FirstRowVisibleCheckBox)
			Me.Controls.Add(Me.SecondRowVisibleCheckBox)
			Me.Controls.Add(Me.ThirdRowVisibleCheckBox)
			Me.Controls.Add(Me.YearyDataButton)
			Me.Controls.Add(Me.MonthlyDataButton)
			Me.Controls.Add(Me.WeeklyDataButton)
			Me.Controls.Add(Me.DailyDataButton)
			Me.Name = "NValueTimelineScaleUC"
			Me.Size = New System.Drawing.Size(178, 232)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Value Timeline Scale<br/><font size = '9pt'>Demonstrates how to use a timeline scale to show date/time information on the X axis</font>")
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' setup chart
			m_Chart = New NCartesianChart()
			nChartControl1.Panels.Add(m_Chart)
			m_Chart.DockMode = PanelDockMode.Fill
			m_Chart.Margins = New NMarginsL(10, 0, 10, 10)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.LightModel.EnableLighting = False
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Wall(ChartWallType.Floor).Visible = False
			m_Chart.Wall(ChartWallType.Left).Visible = False
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Height = 40

			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			m_Chart.RangeSelections.Add(rangeSelection)

			' setup X axis
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			axis.ScrollBar.Visible = True
			Dim timeLineScale As New NValueTimelineScaleConfigurator()
			timeLineScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			timeLineScale.SecondRow.GridStyle.SetShowAtWall(ChartWallType.Back, True)
			timeLineScale.ThirdRow.GridStyle.SetShowAtWall(ChartWallType.Back, True)
			axis.ScaleConfigurator = timeLineScale

			' setup primary Y axis
			axis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			' configure ticks and grid lines
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.InnerMajorTickStyle.Length = New NLength(0)

			' add interlaced stripe 
			Dim stripStyle As New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' Setup the stock series
			m_Stock = CType(m_Chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Stick
			m_Stock.CandleWidth = New NLength(0.5F, NRelativeUnit.ParentPercentage)
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.CloseValues.Name = "close"
			m_Stock.UseXValues = True

			' configure interactivity
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			' update form controls
			FirstRowVisibleCheckBox.Checked = True
			SecondRowVisibleCheckBox.Checked = True
			ThirdRowVisibleCheckBox.Checked = True

			' generate some data
			MonthlyDataButton_Click(Nothing, Nothing)
		End Sub

		Private Sub UpdateScale()
			Dim timelineScale As NValueTimelineScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NValueTimelineScaleConfigurator)

			timelineScale.FirstRow.Visible = FirstRowVisibleCheckBox.Checked
			timelineScale.SecondRow.Visible = SecondRowVisibleCheckBox.Checked
			timelineScale.ThirdRow.Visible = ThirdRowVisibleCheckBox.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub GenerateData(ByVal dtStart As Date, ByVal dtEnd As Date, ByVal span As NDateTimeSpan)
			Dim count As Long = span.GetSpanCountInRange(New NDateTimeRange(dtStart, dtEnd))

			GenerateOHLCData(m_Stock, 100, CInt(count))
			m_Stock.XValues.Clear()

			Dim dtNow As Date = dtStart

			For i As Integer = 0 To m_Stock.Values.Count - 1
				m_Stock.XValues.Add(dtNow.ToOADate())
				dtNow = span.Add(dtNow)
			Next i

			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = False

			nChartControl1.Refresh()
		End Sub

		Private Sub DailyDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DailyDataButton.Click
			' generate data for 30 days
			Dim dtNow As Date = Date.Now
			Dim dtEnd As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 17, 0, 0, 0)
			Dim dtStart As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)

			GenerateData(dtStart, dtEnd, New NDateTimeSpan(5, NDateTimeUnit.Minute))
		End Sub

		Private Sub WeeklyDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles WeeklyDataButton.Click
			' generate data for 30 weeks
			Dim dtNow As Date = Date.Now
			Dim dtEnd As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
			Dim dtStart As Date = NDateTimeUnit.Week.Add(dtEnd, -30)

			GenerateData(dtStart, dtEnd, New NDateTimeSpan(1, NDateTimeUnit.Day))
		End Sub

		Private Sub MonthlyDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MonthlyDataButton.Click
			' generate data for 30 months 
			Dim dtNow As Date = Date.Now
			Dim dtEnd As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
			Dim dtStart As Date = NDateTimeUnit.Month.Add(dtEnd, -30)

			GenerateData(dtStart, dtEnd, New NDateTimeSpan(1, NDateTimeUnit.Week))
		End Sub

		Private Sub YearyDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles YearyDataButton.Click
			' generate data for 30 years
			Dim dtNow As Date = Date.Now
			Dim dtEnd As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
			Dim dtStart As Date = NDateTimeUnit.Year.Add(dtEnd, -30)

			GenerateData(dtStart, dtEnd, New NDateTimeSpan(1, NDateTimeUnit.Month))
		End Sub

		Private Sub FirstRowVisibleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstRowVisibleCheckBox.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub SecondRowVisibleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondRowVisibleCheckBox.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub ThirdRowVisibleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ThirdRowVisibleCheckBox.CheckedChanged
			UpdateScale()
		End Sub
	End Class
End Namespace
