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
	Public Class NMultiSeriesLineUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Line1 As NLineSeries
		Private m_Line2 As NLineSeries
		Private m_Line3 As NLineSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents ChartDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LineDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.ChartDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.LineDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(167, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Chart Depth:"
			' 
			' ChartDepthScroll
			' 
			Me.ChartDepthScroll.LargeChange = 5
			Me.ChartDepthScroll.Location = New System.Drawing.Point(7, 31)
			Me.ChartDepthScroll.Maximum = 50
			Me.ChartDepthScroll.Minimum = 1
			Me.ChartDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ChartDepthScroll.Name = "ChartDepthScroll"
			Me.ChartDepthScroll.Size = New System.Drawing.Size(167, 16)
			Me.ChartDepthScroll.TabIndex = 1
			Me.ChartDepthScroll.Value = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChartDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ChartDepthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 63)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(167, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Line Depth %:"
			' 
			' LineDepthScroll
			' 
			Me.LineDepthScroll.Location = New System.Drawing.Point(7, 87)
			Me.LineDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LineDepthScroll.Name = "LineDepthScroll"
			Me.LineDepthScroll.Size = New System.Drawing.Size(167, 16)
			Me.LineDepthScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineDepthScroll_Scroll);
			' 
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(7, 133)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(167, 22)
			Me.NewDataButton.TabIndex = 4
			Me.NewDataButton.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' NMultiSeriesLineUC
			' 
			Me.Controls.Add(Me.NewDataButton)
			Me.Controls.Add(Me.LineDepthScroll)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ChartDepthScroll)
			Me.Name = "NMultiSeriesLineUC"
			Me.Size = New System.Drawing.Size(180, 171)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Multi Series Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Width = 60
			m_Chart.Height = 25
			m_Chart.Depth = 45
			m_Chart.Projection.Type = ProjectionType.Perspective
			m_Chart.Projection.Elevation = 28
			m_Chart.Projection.Rotation = -17
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			' show the X axis gridlines
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)

			' add the first line
			m_Line1 = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line1.MultiLineMode = MultiLineMode.Series
			m_Line1.LineSegmentShape = LineSegmentShape.Tape
			m_Line1.DataLabelStyle.Visible = False
			m_Line1.DepthPercent = 50
			m_Line1.Name = "Line 1"

			' add the second line
			m_Line2 = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line2.MultiLineMode = MultiLineMode.Series
			m_Line2.LineSegmentShape = LineSegmentShape.Tape
			m_Line2.DataLabelStyle.Visible = False
			m_Line2.DepthPercent = 50
			m_Line2.Name = "Line 2"

			' add the third line
			m_Line3 = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line3.MultiLineMode = MultiLineMode.Series
			m_Line3.LineSegmentShape = LineSegmentShape.Tape
			m_Line3.DataLabelStyle.Visible = False
			m_Line3.DepthPercent = 50
			m_Line3.Name = "Line 3"

			GenerateData()

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub


		Private Sub GenerateData()
			m_Line1.Values.FillRandom(Random, 7)
			m_Line2.Values.FillRandom(Random, 7)
			m_Line3.Values.FillRandom(Random, 7)
		End Sub

		Private Sub ChartDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ChartDepthScroll.ValueChanged
			m_Chart.Depth = CSng(ChartDepthScroll.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub LineDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LineDepthScroll.ValueChanged
			m_Line1.DepthPercent = LineDepthScroll.Value
			m_Line2.DepthPercent = LineDepthScroll.Value
			m_Line3.DepthPercent = LineDepthScroll.Value

			nChartControl1.Refresh()
		End Sub

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			GenerateData()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
