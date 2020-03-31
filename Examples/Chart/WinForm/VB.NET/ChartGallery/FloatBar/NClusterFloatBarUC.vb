Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NClusterFloatBarUC
		Inherits NExampleBaseUC

		Private WithEvents BarGapScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BarWidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BarDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents FloatbarDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents FloatbarGapScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private components As System.ComponentModel.IContainer = Nothing

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

		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.BarGapScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BarWidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BarDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.FloatbarDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.FloatbarGapScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' BarGapScroll
			' 
			Me.BarGapScroll.Location = New System.Drawing.Point(8, 40)
			Me.BarGapScroll.Maximum = 110
			Me.BarGapScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BarGapScroll.Name = "BarGapScroll"
			Me.BarGapScroll.Size = New System.Drawing.Size(163, 16)
			Me.BarGapScroll.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BarGapScroll_Scroll);
			' 
			' BarWidthScroll
			' 
			Me.BarWidthScroll.Location = New System.Drawing.Point(8, 96)
			Me.BarWidthScroll.Maximum = 110
			Me.BarWidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BarWidthScroll.Name = "BarWidthScroll"
			Me.BarWidthScroll.Size = New System.Drawing.Size(163, 16)
			Me.BarWidthScroll.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BarWidthScroll_Scroll);
			' 
			' BarDepthScroll
			' 
			Me.BarDepthScroll.Location = New System.Drawing.Point(8, 152)
			Me.BarDepthScroll.Maximum = 110
			Me.BarDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BarDepthScroll.Name = "BarDepthScroll"
			Me.BarDepthScroll.Size = New System.Drawing.Size(163, 16)
			Me.BarDepthScroll.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BarDepthScroll_Scroll);
			' 
			' FloatbarDepthScroll
			' 
			Me.FloatbarDepthScroll.Location = New System.Drawing.Point(8, 264)
			Me.FloatbarDepthScroll.Maximum = 110
			Me.FloatbarDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.FloatbarDepthScroll.Name = "FloatbarDepthScroll"
			Me.FloatbarDepthScroll.Size = New System.Drawing.Size(163, 16)
			Me.FloatbarDepthScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FloatbarDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FloatbarDepthScroll_Scroll);
			' 
			' FloatbarGapScroll
			' 
			Me.FloatbarGapScroll.Location = New System.Drawing.Point(8, 208)
			Me.FloatbarGapScroll.Maximum = 110
			Me.FloatbarGapScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.FloatbarGapScroll.Name = "FloatbarGapScroll"
			Me.FloatbarGapScroll.Size = New System.Drawing.Size(163, 16)
			Me.FloatbarGapScroll.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FloatbarGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FloatbarGapScroll_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(163, 16)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Bar Gap Percent:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 240)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(163, 16)
			Me.label5.TabIndex = 6
			Me.label5.Text = "Floatbar Depth Percent:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 184)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(163, 16)
			Me.label4.TabIndex = 7
			Me.label4.Text = "Floatbar Gap Percent:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 128)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(163, 16)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Bar Depth Percent:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 72)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(163, 16)
			Me.label2.TabIndex = 9
			Me.label2.Text = "Bar Width Percent:"
			' 
			' NClusterFloatBarUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.FloatbarGapScroll)
			Me.Controls.Add(Me.FloatbarDepthScroll)
			Me.Controls.Add(Me.BarDepthScroll)
			Me.Controls.Add(Me.BarWidthScroll)
			Me.Controls.Add(Me.BarGapScroll)
			Me.Controls.Add(Me.label1)
			Me.Name = "NClusterFloatBarUC"
			Me.Size = New System.Drawing.Size(180, 320)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Cluster Float Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe to the Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			scaleY.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' setup the bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar series"
			bar.DataLabelStyle.Visible = False
			bar.Values.FillRandomRange(Random, 8, 7, 15)

			' setup the floatbar series
			Dim floatbar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Clustered
			floatbar.Name = "Floatbar series"
			floatbar.DataLabelStyle.Visible = False

			floatbar.AddDataPoint(New NFloatBarDataPoint(3.1, 5.2))
			floatbar.AddDataPoint(New NFloatBarDataPoint(4.0, 6.1))
			floatbar.AddDataPoint(New NFloatBarDataPoint(2.0, 6.4))
			floatbar.AddDataPoint(New NFloatBarDataPoint(5.3, 7.3))
			floatbar.AddDataPoint(New NFloatBarDataPoint(3.8, 8.4))
			floatbar.AddDataPoint(New NFloatBarDataPoint(4.0, 7.7))
			floatbar.AddDataPoint(New NFloatBarDataPoint(2.9, 4.1))
			floatbar.AddDataPoint(New NFloatBarDataPoint(5.0, 7.2))

			' init form controls
			BarGapScroll.Value = CInt(Math.Truncate(bar.GapPercent))
			BarWidthScroll.Value = CInt(Math.Truncate(bar.WidthPercent))
			BarDepthScroll.Value = CInt(Math.Truncate(bar.DepthPercent))
			FloatbarGapScroll.Value = CInt(Math.Truncate(floatbar.GapPercent))
			FloatbarDepthScroll.Value = CInt(Math.Truncate(floatbar.DepthPercent))

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub BarGapScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BarGapScroll.ValueChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.GapPercent = BarGapScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub BarWidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BarWidthScroll.ValueChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.WidthPercent = BarWidthScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub BarDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BarDepthScroll.ValueChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.DepthPercent = BarDepthScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub FloatbarGapScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles FloatbarGapScroll.ValueChanged
			Dim floatbar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(1), NFloatBarSeries)
			floatbar.GapPercent = FloatbarGapScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub FloatbarDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles FloatbarDepthScroll.ValueChanged
			Dim floatbar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(1), NFloatBarSeries)
			floatbar.DepthPercent = FloatbarDepthScroll.Value
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

