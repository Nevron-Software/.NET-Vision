Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NMultiSeriesAreaUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Area1 As NAreaSeries
		Private m_Area2 As NAreaSeries
		Private m_Area3 As NAreaSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents ChartDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents AreaDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents AreaTransparencyScroll As Nevron.UI.WinForm.Controls.NHScrollBar
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
			Me.AreaDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ChartDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label3 = New System.Windows.Forms.Label()
			Me.AreaTransparencyScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.SuspendLayout()
			' 
			' AreaDepthScroll
			' 
			Me.AreaDepthScroll.Location = New System.Drawing.Point(6, 67)
			Me.AreaDepthScroll.Maximum = 110
			Me.AreaDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.AreaDepthScroll.Name = "AreaDepthScroll"
			Me.AreaDepthScroll.Size = New System.Drawing.Size(168, 16)
			Me.AreaDepthScroll.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.AreaDepthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 50)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(168, 16)
			Me.label2.TabIndex = 11
			Me.label2.Text = "Area Depth %:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 5)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 16)
			Me.label1.TabIndex = 9
			Me.label1.Text = "Chart Depth:"
			' 
			' ChartDepthScroll
			' 
			Me.ChartDepthScroll.Location = New System.Drawing.Point(6, 22)
			Me.ChartDepthScroll.Maximum = 60
			Me.ChartDepthScroll.Minimum = 1
			Me.ChartDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ChartDepthScroll.Name = "ChartDepthScroll"
			Me.ChartDepthScroll.Size = New System.Drawing.Size(168, 16)
			Me.ChartDepthScroll.TabIndex = 8
			Me.ChartDepthScroll.Value = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChartDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ChartDepthScroll_Scroll);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 96)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(168, 14)
			Me.label3.TabIndex = 13
			Me.label3.Text = "Area Transparency"
			' 
			' AreaTransparencyScroll
			' 
			Me.AreaTransparencyScroll.Location = New System.Drawing.Point(6, 112)
			Me.AreaTransparencyScroll.Maximum = 110
			Me.AreaTransparencyScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.AreaTransparencyScroll.Name = "AreaTransparencyScroll"
			Me.AreaTransparencyScroll.Size = New System.Drawing.Size(168, 16)
			Me.AreaTransparencyScroll.TabIndex = 14
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaTransparencyScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.AreaTransparencyScroll_Scroll);
			' 
			' NMultiSeriesAreaUC
			' 
			Me.Controls.Add(Me.AreaTransparencyScroll)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.AreaDepthScroll)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ChartDepthScroll)
			Me.Name = "NMultiSeriesAreaUC"
			Me.Size = New System.Drawing.Size(180, 181)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Multi Series Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' apply predefined projection and lighting
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Width = 65.0F
			m_Chart.Height = 40.0F
			m_Chart.Depth = 40.0F

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add the first area
			m_Area1 = CType(m_Chart.Series.Add(SeriesType.Area), NAreaSeries)
			m_Area1.MultiAreaMode = MultiAreaMode.Series
			m_Area1.DataLabelStyle.Visible = False
			m_Area1.Name = "Area 1"
			m_Area1.Values.FillRandomRange(Random, 15, 10, 40)

			' add the second area
			m_Area2 = CType(m_Chart.Series.Add(SeriesType.Area), NAreaSeries)
			m_Area2.MultiAreaMode = MultiAreaMode.Series
			m_Area2.DataLabelStyle.Visible = False
			m_Area2.Name = "Area 2"
			m_Area2.Values.FillRandomRange(Random, 15, 30, 60)

			' add the third area
			m_Area3 = CType(m_Chart.Series.Add(SeriesType.Area), NAreaSeries)
			m_Area3.MultiAreaMode = MultiAreaMode.Series
			m_Area3.DataLabelStyle.Visible = False
			m_Area3.Name = "Area 3"
			m_Area3.Values.FillRandomRange(Random, 15, 50, 80)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub ChartDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ChartDepthScroll.ValueChanged
			m_Chart.Depth = CSng(ChartDepthScroll.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub AreaDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles AreaDepthScroll.ValueChanged
			m_Area1.DepthPercent = AreaDepthScroll.Value
			m_Area2.DepthPercent = AreaDepthScroll.Value
			m_Area3.DepthPercent = AreaDepthScroll.Value

			nChartControl1.Refresh()
		End Sub

		Private Sub AreaTransparencyScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles AreaTransparencyScroll.ValueChanged
			m_Area1.FillStyle.SetTransparencyPercent(AreaTransparencyScroll.Value)
			m_Area2.FillStyle.SetTransparencyPercent(AreaTransparencyScroll.Value)
			m_Area3.FillStyle.SetTransparencyPercent(AreaTransparencyScroll.Value)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace