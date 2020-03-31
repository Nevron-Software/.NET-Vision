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
	Public Class NAutoLabelsClusterStackBarUC
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
			Me.EnableInitialPositioningCheck.Location = New System.Drawing.Point(9, 51)
			Me.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck"
			Me.EnableInitialPositioningCheck.Size = New System.Drawing.Size(166, 21)
			Me.EnableInitialPositioningCheck.TabIndex = 14
			Me.EnableInitialPositioningCheck.Text = "Enable Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			' 
			' EnableLabelAdjustmentCheck
			' 
			Me.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2
			Me.EnableLabelAdjustmentCheck.Location = New System.Drawing.Point(9, 82)
			Me.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck"
			Me.EnableLabelAdjustmentCheck.Size = New System.Drawing.Size(166, 19)
			Me.EnableLabelAdjustmentCheck.TabIndex = 13
			Me.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			' 
			' NAutoLabelsClusterStackBarUC
			' 
			Me.Controls.Add(Me.EnableInitialPositioningCheck)
			Me.Controls.Add(Me.EnableLabelAdjustmentCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Name = "NAutoLabelsClusterStackBarUC"
			Me.Size = New System.Drawing.Size(180, 265)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Cluster Stack Bar Chart")
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

			Dim dataPointSafeguardSize As New NSizeL(New NLength(1.3F, NRelativeUnit.ParentPercentage), New NLength(1.3F, NRelativeUnit.ParentPercentage))

			' series 1
			Dim series1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series1.Name = "Bar 1"
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Center

			' series 2
			Dim series2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series2.Name = "Bar 2"
			series2.MultiBarMode = MultiBarMode.Stacked
			series2.FillStyle = New NColorFillStyle(LightOrange)
			series2.DataLabelStyle.Visible = True
			series2.DataLabelStyle.VertAlign = VertAlign.Center

			' series 3
			Dim series3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series3.Name = "Bar 3"
			series3.MultiBarMode = MultiBarMode.Clustered
			series3.FillStyle = New NColorFillStyle(LightGreen)
			series3.DataLabelStyle.Visible = True
			series3.DataLabelStyle.VertAlign = VertAlign.Top
			series3.DataLabelStyle.ArrowLength = New NLength(10)

			' generate random data
			GenerateData(chart)

			' enable initial labels positioning
			chart.LabelLayout.EnableInitialPositioning = True

			' enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = True

			' series 1 data points must not be overlapped
			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize

			' do not use label location proposals for series 1
			series1.LabelLayout.UseLabelLocations = False

			' series 2 data points must not be overlapped
			series2.LabelLayout.EnableDataPointSafeguard = True
			series2.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize

			' do not use label location proposals for series 2
			series2.LabelLayout.UseLabelLocations = False

			' series 3 data points must not be overlapped
			series3.LabelLayout.EnableDataPointSafeguard = True
			series3.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize

			' series 3 data labels can be placed above and below the origin point
			series3.LabelLayout.UseLabelLocations = True
			series3.LabelLayout.LabelLocations = New LabelLocation() { LabelLocation.Top, LabelLocation.Bottom }
			series3.LabelLayout.InvertLocationsIfIgnored = False
			series3.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' init form controls
			EnableInitialPositioningCheck.Checked = True
			EnableLabelAdjustmentCheck.Checked = True
		End Sub

		Private Sub GenerateData(ByVal chart As NChart)
			CType(chart.Series(0), NSeries).Values.FillRandomRange(Random, 10, 5.0, 20.0)
			CType(chart.Series(1), NSeries).Values.FillRandomRange(Random, 10, 5.0, 20.0)
			CType(chart.Series(2), NSeries).Values.FillRandomRange(Random, 10, 10.0, 20.0)
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)

			GenerateData(chart)

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