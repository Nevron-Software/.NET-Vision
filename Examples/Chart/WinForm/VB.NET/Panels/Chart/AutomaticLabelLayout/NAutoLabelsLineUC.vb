﻿Imports System
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
	Public Class NAutoLabelsLineUC
		Inherits NExampleBaseUC

		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EnableInitialPositioningCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableLabelAdjustmentCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.SuspendLayout()
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(9, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(166, 24)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' EnableInitialPositioningCheck
			' 
			Me.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2
			Me.EnableInitialPositioningCheck.Location = New System.Drawing.Point(9, 49)
			Me.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck"
			Me.EnableInitialPositioningCheck.Size = New System.Drawing.Size(166, 21)
			Me.EnableInitialPositioningCheck.TabIndex = 16
			Me.EnableInitialPositioningCheck.Text = "Enable Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			' 
			' EnableLabelAdjustmentCheck
			' 
			Me.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2
			Me.EnableLabelAdjustmentCheck.Location = New System.Drawing.Point(9, 80)
			Me.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck"
			Me.EnableLabelAdjustmentCheck.Size = New System.Drawing.Size(166, 21)
			Me.EnableLabelAdjustmentCheck.TabIndex = 15
			Me.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			' 
			' NAutoLabelsLineUC
			' 
			Me.Controls.Add(Me.EnableInitialPositioningCheck)
			Me.Controls.Add(Me.EnableLabelAdjustmentCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Name = "NAutoLabelsLineUC"
			Me.Size = New System.Drawing.Size(180, 157)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)

			' configure Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' add interlaced stripe for Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' line series
			Dim series1 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			series1.InflateMargins = True
			series1.MarkerStyle.Visible = True
			series1.MarkerStyle.FillStyle = New NColorFillStyle(DarkOrange)
			series1.MarkerStyle.PointShape = PointShape.Ellipse
			series1.MarkerStyle.Width = New NLength(1.0F, NRelativeUnit.ParentPercentage)
			series1.MarkerStyle.Height = New NLength(1.0F, NRelativeUnit.ParentPercentage)

			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowLength = New NLength(10)
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange


			chart.LabelLayout.EnableInitialPositioning = True
			chart.LabelLayout.EnableLabelAdjustment = True

			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(New NLength(1.3F, NRelativeUnit.ParentPercentage), New NLength(1.3F, NRelativeUnit.ParentPercentage))
			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = True

			' fill with random data
			GenerateData(series1)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			EnableInitialPositioningCheck.Checked = True
			EnableLabelAdjustmentCheck.Checked = True
		End Sub

		Private Sub GenerateData(ByVal series As NSeries)
			series.Values.Clear()

			For i As Integer = 0 To 29
				Dim value As Double = Math.Sin(i * 0.2) * 10 + Random.NextDouble() * 2
				series.Values.Add(value)
			Next i
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			GenerateData(series)

			nChartControl1.Refresh()
		End Sub

		Private Sub EnableInitialPositioningCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableInitialPositioningCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub EnableLabelAdjustmentCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableLabelAdjustmentCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace