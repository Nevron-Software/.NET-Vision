Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPredefinedStyleSheetsUC
		Inherits NExampleBaseUC

		Public Sub New()
			InitializeComponent()
		End Sub

		Private WithEvents PredefinedStyleSheetComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

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
			Me.PredefinedStyleSheetComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' PredefinedStyleSheetComboBox
			' 
			Me.PredefinedStyleSheetComboBox.Location = New System.Drawing.Point(12, 42)
			Me.PredefinedStyleSheetComboBox.Name = "PredefinedStyleSheetComboBox"
			Me.PredefinedStyleSheetComboBox.Size = New System.Drawing.Size(150, 21)
			Me.PredefinedStyleSheetComboBox.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PredefinedStyleSheetComboBox.SelectedIndexChanged += new System.EventHandler(this.PredefinedStyleSheetComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 23)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(115, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Predefined Style Sheet"
			' 
			' NPredefinedStyleSheetsUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.PredefinedStyleSheetComboBox)
			Me.Name = "NPredefinedStyleSheetsUC"
			Me.Size = New System.Drawing.Size(175, 288)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' configure device and interactivity
			nChartControl1.Panels.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Predefined Style Sheets")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.FitAlignment = ContentAlignment.MiddleLeft
			title.Margins = New NMarginsL(10, 10, 0, 0)
			title.DockMode = PanelDockMode.Top

			Dim dockPanel As New NDockPanel()
			dockPanel.DockMode = PanelDockMode.Fill
			dockPanel.DockMargins = New NMarginsL(20, 5, 15, 10)
			dockPanel.PositionChildPanelsInContentBounds = True
			nChartControl1.Panels.Add(dockPanel)

			Dim chart As NChart = CreateBarChart()
			chart.Enable3D = True
			chart.Location = New NPointL(5, 0)
			chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			chart.BoundsMode = BoundsMode.Fit

			dockPanel.ChildPanels.Add(chart)
			Dim gauge As NRadialGaugePanel = CreateRadialGauge()
			dockPanel.ChildPanels.Add(gauge)
			gauge.Location = New NPointL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			gauge.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(40, NRelativeUnit.ParentPercentage))

			gauge = CreateRadialGauge()
			dockPanel.ChildPanels.Add(gauge)
			gauge.Location = New NPointL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			gauge.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(40, NRelativeUnit.ParentPercentage))

			PredefinedStyleSheetComboBox.FillFromEnum(GetType(PredefinedStyleSheet))

		End Sub

		Private Function CreateBarChart() As NChart
			' setup chart
			Dim chart As NChart = New NCartesianChart()
			chart.Width = 60
			chart.Height = 25
			chart.Depth = 45
			chart.BoundsMode = BoundsMode.Fit
			chart.ContentAlignment = ContentAlignment.BottomRight
			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Projection.Elevation += 10

			' add axis labels
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)

			ordinalScale = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.Name = "Bar1"
			bar1.DataLabelStyle.Visible = True
			bar1.DataLabelStyle.Format = "<value>"
			bar1.FillStyle = New NColorFillStyle(Color.FromArgb(56, 89, 150))
			bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255)

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.MultiBarMode = MultiBarMode.Series
			bar2.Name = "Bar2"
			bar2.DataLabelStyle.Visible = True
			bar2.DataLabelStyle.Format = "<value>"
			bar2.FillStyle = New NColorFillStyle(Color.DarkGreen)
			bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210)

			' add the third bar
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.MultiBarMode = MultiBarMode.Series
			bar3.Name = "Bar3"
			bar3.DataLabelStyle.Visible = True
			bar3.DataLabelStyle.Format = "<value>"
			bar3.FillStyle = New NColorFillStyle(Color.DarkGoldenrod)
			bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210)

			' fill with random data
			Dim barCount As Integer = 6
			bar1.Values.FillRandomRange(Random, barCount, 10, 40)
			bar2.Values.FillRandomRange(Random, barCount, 30, 60)
			bar3.Values.FillRandomRange(Random, barCount, 50, 80)

			Return chart
		End Function



		Private Function CreateRadialGauge() As NRadialGaugePanel
			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.ContentAlignment = ContentAlignment.BottomCenter

			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 250)

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation)
			scale_Renamed.MinorTickCount = 4
			scale_Renamed.RulerStyle.BorderStyle.Width = New NLength(0)
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGray)
			scale_Renamed.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0, False)

			Dim scaleSection As New NScaleSectionStyle()
			scaleSection.Range = New NRange1DD(220, 260)
			scaleSection.MajorTickStrokeStyle = New NStrokeStyle(Color.Red)
			scaleSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 2)

			Dim labelStyle As New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(Color.Red, Color.DarkRed)
			labelStyle.FontStyle.Style = FontStyle.Bold
			scaleSection.LabelTextStyle = labelStyle

			scale_Renamed.Sections.Add(scaleSection)

			Dim rangeIndicator As New NRangeIndicator()
			rangeIndicator.Value = 220
			rangeIndicator.OriginMode = OriginMode.ScaleMax
			rangeIndicator.FillStyle = New NColorFillStyle(Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.BeginWidth = New NLength(2)
			rangeIndicator.EndWidth = New NLength(10)
			radialGauge.Indicators.Add(rangeIndicator)

			Dim markerIndicator As New NMarkerValueIndicator()
			markerIndicator.Value = 90
			radialGauge.Indicators.Add(markerIndicator)

			Dim needleIndictor As New NNeedleValueIndicator()
			needleIndictor.Value = 0
			needleIndictor.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			needleIndictor.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(needleIndictor)

			radialGauge.BeginAngle = -240
			radialGauge.SweepAngle = 300

			Return radialGauge
		End Function

		Private Sub PredefinedStyleSheetComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PredefinedStyleSheetComboBox.SelectedIndexChanged
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(CType(PredefinedStyleSheetComboBox.SelectedIndex, PredefinedStyleSheet))
			styleSheet.Apply(nChartControl1.Document)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
