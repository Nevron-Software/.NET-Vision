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
	Public Class NAutoLabelsAreaUC
		Inherits NExampleBaseUC

		Private WithEvents EnableLabelAdjustmentCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EnableDataPointSafeguardCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.EnableLabelAdjustmentCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.EnableDataPointSafeguardCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' EnableLabelAdjustmentCheck
			' 
			Me.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2
			Me.EnableLabelAdjustmentCheck.Location = New System.Drawing.Point(5, 50)
			Me.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck"
			Me.EnableLabelAdjustmentCheck.Size = New System.Drawing.Size(171, 21)
			Me.EnableLabelAdjustmentCheck.TabIndex = 6
			Me.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(5, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(171, 24)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' EnableDataPointSafeguardCheck
			' 
			Me.EnableDataPointSafeguardCheck.ButtonProperties.BorderOffset = 2
			Me.EnableDataPointSafeguardCheck.Location = New System.Drawing.Point(5, 83)
			Me.EnableDataPointSafeguardCheck.Name = "EnableDataPointSafeguardCheck"
			Me.EnableDataPointSafeguardCheck.Size = New System.Drawing.Size(171, 21)
			Me.EnableDataPointSafeguardCheck.TabIndex = 10
			Me.EnableDataPointSafeguardCheck.Text = "Enable Data Point Safeguard"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableDataPointSafeguardCheck.CheckedChanged += new System.EventHandler(this.EnableDataPointSafeguardCheck_CheckedChanged);
			' 
			' NAutoLabelsAreaUC
			' 
			Me.Controls.Add(Me.EnableDataPointSafeguardCheck)
			Me.Controls.Add(Me.EnableLabelAdjustmentCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Name = "NAutoLabelsAreaUC"
			Me.Size = New System.Drawing.Size(180, 148)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Height = 30
			chart.Depth = 5
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)

			' configure X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' configure Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' hide the Z axis
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe for Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' area series
			Dim series1 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			series1.InflateMargins = True
			series1.UseXValues = True
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowLength = New NLength(10)
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange

			' disable initial label positioning
			chart.LabelLayout.EnableInitialPositioning = False

			' enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = True

			' enable the data point safesuard and set its size
			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(New NLength(1.3F, NRelativeUnit.ParentPercentage), New NLength(1.3F, NRelativeUnit.ParentPercentage))

			' fill with random data
			GenerateData(series1)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			EnableLabelAdjustmentCheck.Checked = True
			EnableDataPointSafeguardCheck.Checked = True
		End Sub

		Private Sub GenerateData(ByVal series As NAreaSeries)
			series.Values.Clear()
			series.XValues.Clear()

			Dim xvalue As Double = 10

			For i As Integer = 0 To 23
				Dim value As Double = Math.Sin(i * 0.4) * 5 + Random.NextDouble() * 3
				xvalue += 1 + Random.NextDouble() * 20

				series.Values.Add(value)
				series.XValues.Add(xvalue)
			Next i
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NAreaSeries = CType(chart.Series(0), NAreaSeries)

			GenerateData(series)

			nChartControl1.Refresh()
		End Sub
		Private Sub EnableLabelAdjustmentCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableLabelAdjustmentCheck.CheckedChanged
			EnableDataPointSafeguardCheck.Enabled = EnableLabelAdjustmentCheck.Checked

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub EnableDataPointSafeguardCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableDataPointSafeguardCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series(0).LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheck.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace