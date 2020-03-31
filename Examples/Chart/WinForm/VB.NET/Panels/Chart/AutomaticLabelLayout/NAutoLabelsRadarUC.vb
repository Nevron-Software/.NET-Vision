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

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAutoLabelsRadarUC
		Inherits NExampleBaseUC

		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EnableInitialPositioningCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableLabelAdjustmentCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents StackRadarAreasCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.EnableInitialPositioningCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableLabelAdjustmentCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.StackRadarAreasCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(4, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(171, 24)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' EnableInitialPositioningCheck
			' 
			Me.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2
			Me.EnableInitialPositioningCheck.Location = New System.Drawing.Point(4, 47)
			Me.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck"
			Me.EnableInitialPositioningCheck.Size = New System.Drawing.Size(166, 21)
			Me.EnableInitialPositioningCheck.TabIndex = 12
			Me.EnableInitialPositioningCheck.Text = "Enable Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			' 
			' EnableLabelAdjustmentCheck
			' 
			Me.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2
			Me.EnableLabelAdjustmentCheck.Location = New System.Drawing.Point(4, 78)
			Me.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck"
			Me.EnableLabelAdjustmentCheck.Size = New System.Drawing.Size(166, 21)
			Me.EnableLabelAdjustmentCheck.TabIndex = 11
			Me.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			' 
			' StackRadarAreasCheck
			' 
			Me.StackRadarAreasCheck.ButtonProperties.BorderOffset = 2
			Me.StackRadarAreasCheck.Location = New System.Drawing.Point(5, 148)
			Me.StackRadarAreasCheck.Name = "StackRadarAreasCheck"
			Me.StackRadarAreasCheck.Size = New System.Drawing.Size(166, 21)
			Me.StackRadarAreasCheck.TabIndex = 13
			Me.StackRadarAreasCheck.Text = "Stack Radar Areas"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StackRadarAreasCheck.CheckedChanged += new System.EventHandler(this.StackRadarAreasCheck_CheckedChanged);
			' 
			' NAutoLabelsRadarUC
			' 
			Me.Controls.Add(Me.StackRadarAreasCheck)
			Me.Controls.Add(Me.EnableInitialPositioningCheck)
			Me.Controls.Add(Me.EnableLabelAdjustmentCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Name = "NAutoLabelsRadarUC"
			Me.Size = New System.Drawing.Size(180, 262)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Radar Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As New NRadarChart()
			nChartControl1.Charts.Add(chart)

			AddRadarAxis(chart, "Category A")
			AddRadarAxis(chart, "Category B")
			AddRadarAxis(chart, "Category C")
			AddRadarAxis(chart, "Category D")
			AddRadarAxis(chart, "Category E")
			AddRadarAxis(chart, "Category F")
			AddRadarAxis(chart, "Category G")

			' radar area series 1
			Dim series1 As NRadarAreaSeries = CType(chart.Series.Add(SeriesType.RadarArea), NRadarAreaSeries)
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.BorderStyle.Color = DarkOrange
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange

			' radar area series 2
			Dim series2 As NRadarAreaSeries = CType(chart.Series.Add(SeriesType.RadarArea), NRadarAreaSeries)
			series2.FillStyle = New NColorFillStyle(LightOrange)
			series2.BorderStyle.Color = LightOrange
			series2.DataLabelStyle.Visible = True
			series2.DataLabelStyle.VertAlign = VertAlign.Top
			series2.DataLabelStyle.ArrowStrokeStyle.Color = LightOrange
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = LightOrange

			' label layout settings
			chart.LabelLayout.EnableInitialPositioning = True
			chart.LabelLayout.EnableLabelAdjustment = True

			Dim safeguardSize As New NSizeL(New NLength(1.3F, NRelativeUnit.ParentPercentage), New NLength(1.3F, NRelativeUnit.ParentPercentage))

			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = False
			series1.LabelLayout.DataPointSafeguardSize = safeguardSize

			series2.LabelLayout.EnableDataPointSafeguard = True
			series2.LabelLayout.UseLabelLocations = True
			series2.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series2.LabelLayout.InvertLocationsIfIgnored = False
			series2.LabelLayout.DataPointSafeguardSize = safeguardSize

			' fill with random data
			GenerateData(series1, series2)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			EnableInitialPositioningCheck.Checked = True
			EnableLabelAdjustmentCheck.Checked = True
			StackRadarAreasCheck.Checked = False
		End Sub

		Private Sub AddRadarAxis(ByVal chart As NRadarChart, ByVal title As String)
			Dim axis As New NRadarAxis()

			' set title
			axis.Title = title

			' the axis scale should start from 0
			axis.View = New NRangeAxisView(New NRange1DD(0, 0), True, False)

			' setup scale
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RulerStyle.BorderStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)
			linearScale.OuterMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)

			If chart.Axes.Count = 0 Then
				' if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, True)

				' add interlaced stripe
				Dim strip As New NScaleStripStyle()
				strip.FillStyle = New NColorFillStyle(Color.FromArgb(64, 200, 200, 200))
				strip.Interlaced = True
				strip.SetShowAtWall(ChartWallType.Radar, True)
				linearScale.StripStyles.Add(strip)
			Else
				' hide labels
				linearScale.AutoLabels = False
			End If

			chart.Axes.Add(axis)
		End Sub

		Private Sub GenerateData(ByVal series0 As NSeries, ByVal series1 As NSeries)
			series0.Values.FillRandomRange(Random, 7, 30.0, 80.0)
			series1.Values.FillRandomRange(Random, 7, 20.0, 60.0)
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series0 As NSeries = CType(chart.Series(0), NSeries)
			Dim series1 As NSeries = CType(chart.Series(1), NSeries)

			GenerateData(series0, series1)

			nChartControl1.Refresh()
		End Sub

		Private Sub EnableInitialPositioningCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableInitialPositioningCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub EnableLabelAdjustmentCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableLabelAdjustmentCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub StackRadarAreasCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles StackRadarAreasCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim radarArea As NRadarAreaSeries = CType(chart.Series(1), NRadarAreaSeries)

			If StackRadarAreasCheck.Checked Then
				radarArea.MultiAreaMode = MultiAreaMode.Stacked
			Else
				radarArea.MultiAreaMode = MultiAreaMode.Series
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace