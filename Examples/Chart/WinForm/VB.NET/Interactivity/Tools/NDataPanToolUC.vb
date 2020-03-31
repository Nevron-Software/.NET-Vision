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
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDataPanToolUC
		Inherits NExampleBaseUC

		Private m_DataPanTool As NDataPanTool
		Private WithEvents RepaintChartWhileDraggingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents XAxisPageSizeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private WithEvents YAxisPageSizeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ShowScrollbarSlidersCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing
		Private m_Update As Boolean

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
			Me.RepaintChartWhileDraggingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.XAxisPageSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.YAxisPageSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ShowScrollbarSlidersCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.XAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.YAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' RepaintChartWhileDraggingCheckBox
			' 
			Me.RepaintChartWhileDraggingCheckBox.ButtonProperties.BorderOffset = 2
			Me.RepaintChartWhileDraggingCheckBox.Location = New System.Drawing.Point(8, 8)
			Me.RepaintChartWhileDraggingCheckBox.Name = "RepaintChartWhileDraggingCheckBox"
			Me.RepaintChartWhileDraggingCheckBox.Size = New System.Drawing.Size(163, 34)
			Me.RepaintChartWhileDraggingCheckBox.TabIndex = 0
			Me.RepaintChartWhileDraggingCheckBox.Text = "Repaint Chart while Dragging"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RepaintChartWhileDraggingCheckBox.CheckedChanged += new System.EventHandler(this.RepaintChartWhileDraggingCheckBox_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 83)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(144, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "X axis page size:"
			' 
			' XAxisPageSizeNumericUpDown
			' 
			Me.XAxisPageSizeNumericUpDown.Location = New System.Drawing.Point(8, 102)
			Me.XAxisPageSizeNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.XAxisPageSizeNumericUpDown.Name = "XAxisPageSizeNumericUpDown"
			Me.XAxisPageSizeNumericUpDown.Size = New System.Drawing.Size(89, 20)
			Me.XAxisPageSizeNumericUpDown.TabIndex = 2
			Me.XAxisPageSizeNumericUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAxisPageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.XAxisPageSizeNumericUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 126)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(144, 16)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Y axis page size:"
			' 
			' YAxisPageSizeNumericUpDown
			' 
			Me.YAxisPageSizeNumericUpDown.Location = New System.Drawing.Point(8, 145)
			Me.YAxisPageSizeNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.YAxisPageSizeNumericUpDown.Name = "YAxisPageSizeNumericUpDown"
			Me.YAxisPageSizeNumericUpDown.Size = New System.Drawing.Size(89, 20)
			Me.YAxisPageSizeNumericUpDown.TabIndex = 4
			Me.YAxisPageSizeNumericUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAxisPageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.YAxisPageSizeNumericUpDown_ValueChanged);
			' 
			' ShowScrollbarSlidersCheckBox
			' 
			Me.ShowScrollbarSlidersCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowScrollbarSlidersCheckBox.Location = New System.Drawing.Point(8, 33)
			Me.ShowScrollbarSlidersCheckBox.Name = "ShowScrollbarSlidersCheckBox"
			Me.ShowScrollbarSlidersCheckBox.Size = New System.Drawing.Size(163, 34)
			Me.ShowScrollbarSlidersCheckBox.TabIndex = 5
			Me.ShowScrollbarSlidersCheckBox.Text = "Show Scrollbar Sliders"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowScrollbarSlidersCheckBox.CheckedChanged += new System.EventHandler(this.ShowScrollbarSlidersCheckBox_CheckedChanged);
			' 
			' NDataPanToolUC
			' 
			Me.Controls.Add(Me.ShowScrollbarSlidersCheckBox)
			Me.Controls.Add(Me.YAxisPageSizeNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.XAxisPageSizeNumericUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.RepaintChartWhileDraggingCheckBox)
			Me.Name = "NDataPanToolUC"
			Me.Size = New System.Drawing.Size(180, 424)
			DirectCast(Me.XAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.YAxisPageSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Data Pan Tool<br/><font size = '12pt'>Demonstrates how to configure scrollbars with sliders and to enable data panning</font>")
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(10, 10, 10, 10)
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' configure the chart
			Dim chart As New NCartesianChart()
			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(10, 0, 10, 10)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			nChartControl1.Panels.Add(chart)

			' add some dummy data
			Dim pointSeries As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			pointSeries.UseXValues = True
			pointSeries.Name = "Point Series"
			pointSeries.BorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)

			pointSeries.BorderStyle.Color = Color.DarkRed
			pointSeries.DataLabelStyle.Visible = False
			pointSeries.Size = New NLength(5, NGraphicsUnit.Point)

			Dim dp As New NDataPoint()

			' add xy values
			For i As Integer = 0 To 199
				dp(DataPointValue.X) = Random.Next(100)
				dp(DataPointValue.Y) = Random.Next(100)
				dp(DataPointValue.Label) = "Item" & i.ToString()
				pointSeries.AddDataPoint(dp)
			Next i

			' configure chart axes
			' set the primary X axis in FixedPageSize mode
			Dim pageSize As Double = 10
			Dim primaryX As NAxis = chart.Axis(StandardAxis.PrimaryX)

			Dim linearScale As New NLinearScaleConfigurator()
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add an interlaced strip to the Y axis
			Dim xInterlacedStrip As New NScaleStripStyle()
			xInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			xInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			linearScale.StripStyles.Add(xInterlacedStrip)

			primaryX.ScaleConfigurator = linearScale
			Dim xPagingView As New NNumericAxisPagingView(New NRange1DD(0, pageSize))
			xPagingView.MinPageLength = 1.0
			primaryX.PagingView = xPagingView
			primaryX.ScrollBar.Visible = True
			AddHandler primaryX.ScrollBar.ViewRangeChanged, AddressOf OnXViewRangeChanged

			' set the primary Y axis in FixedPageSize mode
			Dim primaryY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			linearScale = New NLinearScaleConfigurator()
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			' add an interlaced strip to the Y axis
			Dim yInterlacedStrip As New NScaleStripStyle()
			yInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			yInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			linearScale.StripStyles.Add(yInterlacedStrip)

			primaryY.ScaleConfigurator = linearScale
			Dim yPagingView As New NNumericAxisPagingView(New NRange1DD(0, pageSize))
			yPagingView.MinPageLength = 1.0
			primaryY.PagingView = yPagingView
			primaryY.ScrollBar.Visible = True
			AddHandler primaryY.ScrollBar.ViewRangeChanged, AddressOf OnYViewRangeChanged

			' disable the reset button
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = False
			chart.Axis(StandardAxis.PrimaryY).ScrollBar.ResetButton.Visible = False

			m_DataPanTool = New NDataPanTool()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(m_DataPanTool)
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())

			AddHandler m_DataPanTool.Cancel, AddressOf OnCancel

			' init form controls
			XAxisPageSizeNumericUpDown.Value = CDec(10)
			YAxisPageSizeNumericUpDown.Value = CDec(10)
			ShowScrollbarSlidersCheckBox.Checked = True

			RepaintChartWhileDraggingCheckBox.Checked = m_DataPanTool.RepaintChartWhileDragging
		End Sub

		Private Sub RepaintChartWhileDraggingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepaintChartWhileDraggingCheckBox.CheckedChanged
			m_DataPanTool.RepaintChartWhileDragging = RepaintChartWhileDraggingCheckBox.Checked
		End Sub

		Private Sub OnXViewRangeChanged(ByVal sender As Object, ByVal e As EventArgs)
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim chart As NCartesianChart = TryCast(nChartControl1.Charts(0), NCartesianChart)
			If chart IsNot Nothing Then
				m_Update = True
				XAxisPageSizeNumericUpDown.Value = CDec(chart.Axis(StandardAxis.PrimaryX).ScrollBar.ViewRange.GetLength())
				m_Update = False
			End If
		End Sub

		Private Sub OnYViewRangeChanged(ByVal sender As Object, ByVal e As EventArgs)
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim chart As NCartesianChart = TryCast(nChartControl1.Charts(0), NCartesianChart)
			If chart IsNot Nothing Then
				m_Update = True
				YAxisPageSizeNumericUpDown.Value = CDec(chart.Axis(StandardAxis.PrimaryY).ScrollBar.ViewRange.GetLength())
				m_Update = False
			End If
		End Sub

		Private Sub ShowScrollbarSlidersCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowScrollbarSlidersCheckBox.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim chart As NCartesianChart = TryCast(nChartControl1.Charts(0), NCartesianChart)
			If chart IsNot Nothing Then
				chart.Axis(StandardAxis.PrimaryX).ScrollBar.ShowSliders = ShowScrollbarSlidersCheckBox.Checked
				chart.Axis(StandardAxis.PrimaryY).ScrollBar.ShowSliders = ShowScrollbarSlidersCheckBox.Checked

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub XAxisPageSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAxisPageSizeNumericUpDown.ValueChanged
			If nChartControl1 Is Nothing OrElse m_Update Then
				Return
			End If

			Dim chart As NCartesianChart = TryCast(nChartControl1.Charts(0), NCartesianChart)
			If chart IsNot Nothing Then
				Dim pagingView As NNumericAxisPagingView = TryCast(chart.Axis(StandardAxis.PrimaryX).PagingView, NNumericAxisPagingView)
				pagingView.Length = CDbl(XAxisPageSizeNumericUpDown.Value)

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub YAxisPageSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAxisPageSizeNumericUpDown.ValueChanged
			If nChartControl1 Is Nothing OrElse m_Update Then
				Return
			End If

			Dim chart As NCartesianChart = TryCast(nChartControl1.Charts(0), NCartesianChart)
			If chart IsNot Nothing Then
				Dim pagingView As NNumericAxisPagingView = TryCast(chart.Axis(StandardAxis.PrimaryY).PagingView, NNumericAxisPagingView)
				pagingView.Length = CDbl(YAxisPageSizeNumericUpDown.Value)

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub OnCancel(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1 Is Nothing Then
				Return
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
