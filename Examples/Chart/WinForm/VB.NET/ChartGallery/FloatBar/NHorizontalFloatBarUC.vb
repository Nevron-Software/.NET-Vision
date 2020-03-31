Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NHorizontalFloatBarUC
		Inherits NExampleBaseUC

		Private label2 As System.Windows.Forms.Label
		Private WithEvents WidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.WidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 9)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(128, 16)
			Me.label2.TabIndex = 13
			Me.label2.Text = "Width %:"
			' 
			' WidthScroll
			' 
			Me.WidthScroll.LargeChange = 1
			Me.WidthScroll.Location = New System.Drawing.Point(9, 27)
			Me.WidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WidthScroll.Name = "WidthScroll"
			Me.WidthScroll.Size = New System.Drawing.Size(160, 18)
			Me.WidthScroll.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			' 
			' NHorizontalFloatBarUC
			' 
			Me.Controls.Add(Me.WidthScroll)
			Me.Controls.Add(Me.label2)
			Me.Name = "NHorizontalFloatBarUC"
			Me.Size = New System.Drawing.Size(180, 86)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Gantt")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Projection.ViewerRotation = 270
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup the value axis
			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			dateTimeScale.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back }

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back }
			stripStyle.Interlaced = True
			dateTimeScale.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = dateTimeScale
			chart.Axis(StandardAxis.PrimaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True, 0, 100)

			' label the X axis
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.Labels.Add("Market Research")
			ordinalScale.Labels.Add("Specifications")
			ordinalScale.Labels.Add("Architecture")
			ordinalScale.Labels.Add("Project Planning")
			ordinalScale.Labels.Add("Detailed Design")
			ordinalScale.Labels.Add("Development")
			ordinalScale.Labels.Add("Test Plan")
			ordinalScale.Labels.Add("Testing and QA")
			ordinalScale.Labels.Add("Documentation")

			' create a floatbar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.BeginValues.ValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			floatBar.EndValues.ValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			floatBar.DataLabelStyle.Visible = False

			AddDataPoint(floatBar, New Date(2009, 2, 2), New Date(2009, 2, 16))
			AddDataPoint(floatBar, New Date(2009, 2, 16), New Date(2009, 3, 2))
			AddDataPoint(floatBar, New Date(2009, 3, 2), New Date(2009, 3, 16))
			AddDataPoint(floatBar, New Date(2009, 3, 9), New Date(2009, 3, 23))
			AddDataPoint(floatBar, New Date(2009, 3, 16), New Date(2009, 3, 30))
			AddDataPoint(floatBar, New Date(2009, 3, 23), New Date(2009, 4, 27))
			AddDataPoint(floatBar, New Date(2009, 4, 13), New Date(2009, 4, 27))
			AddDataPoint(floatBar, New Date(2009, 4, 20), New Date(2009, 5, 4))
			AddDataPoint(floatBar, New Date(2009, 4, 27), New Date(2009, 5, 4))

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			WidthScroll.Value = CInt(Math.Truncate(floatBar.WidthPercent))
		End Sub

		Private Sub AddDataPoint(ByVal floatBar As NFloatBarSeries, ByVal dtBegin As Date, ByVal dtEnd As Date)
			floatBar.BeginValues.Add(dtBegin.ToOADate())
			floatBar.EndValues.Add(dtEnd.ToOADate())
		End Sub

		Private Sub WidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroll.ValueChanged
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.WidthPercent = WidthScroll.Value
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace