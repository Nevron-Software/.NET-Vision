Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeHitTestingUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private CurrentElementTextBox As Nevron.UI.WinForm.Controls.NTextBox
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

		End Sub

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Gauge Hit Testing")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()
			radialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.BackgroundFillStyle = New NAdvancedGradientFillStyle(AdvancedGradientScheme.WhiteOnBlack, 0)

			radialGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			radialGauge.PositionChildPanelsInContentBounds = True

			' configure scale
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = TryCast(DirectCast(radialGauge.Axes(0), NGaugeAxis).ScaleConfigurator, NLinearScaleConfigurator)
			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale_Renamed.LabelFitModes = New LabelFitMode(){}
			scale_Renamed.MinorTickCount = 3
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale_Renamed.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale_Renamed.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold Or FontStyle.Italic)
			scale_Renamed.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)

			nChartControl1.Panels.Add(radialGauge)

			Dim indicator1 As New NRangeIndicator()
			indicator1.Value = 50
			indicator1.FillStyle = New NColorFillStyle(Color.LightBlue)
			indicator1.StrokeStyle.Color = Color.DarkBlue
			indicator1.EndWidth = New NLength(20)
			radialGauge.Indicators.Add(indicator1)

			Dim indicator2 As New NNeedleValueIndicator()
			indicator2.Value = 79
			indicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			indicator2.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(indicator2)
			radialGauge.SweepAngle = 270

			Dim indicator3 As New NMarkerValueIndicator()
			indicator3.Value = 90
			radialGauge.Indicators.Add(indicator3)

			' subscribe for control events
			AddHandler nChartControl1.MouseMove, AddressOf ChartControl_MouseMove
		End Sub

		Private Sub ChartControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
			Dim hitTestResult As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			Select Case hitTestResult.ChartElement
				Case ChartElement.GaugeAxis
					Dim gaugeAxis As NGaugeAxis = hitTestResult.GaugeAxis
					CurrentElementTextBox.Text = "Gauge Axis Range: [" & gaugeAxis.Range.Begin.ToString() & ", " & gaugeAxis.Range.End.ToString() & "]"
				Case ChartElement.GaugeMarker
					Dim markerValueIndicator As NMarkerValueIndicator = hitTestResult.MarkerValueIndicator
					CurrentElementTextBox.Text = "Gauge Marker Value: " & markerValueIndicator.Value.ToString()
				Case ChartElement.GaugeNeedle
					Dim needleIndicator As NNeedleValueIndicator = hitTestResult.NeedleValueIndicator
					CurrentElementTextBox.Text = "Gauge Needle Value: " & needleIndicator.Value.ToString()
				Case ChartElement.GaugeRange
					Dim rangeIndicator As NRangeIndicator = hitTestResult.RangeIndicator
					CurrentElementTextBox.Text = "Gauge range: [" & rangeIndicator.Range.Begin.ToString() & ", " & rangeIndicator.Range.End.ToString() & "]"
				Case Else
					CurrentElementTextBox.Text = ""
			End Select
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
			Me.CurrentElementTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Current Element:"
			' 
			' CurrentElementTextBox
			' 
			Me.CurrentElementTextBox.Enabled = False
			Me.CurrentElementTextBox.Location = New System.Drawing.Point(8, 40)
			Me.CurrentElementTextBox.Name = "CurrentElementTextBox"
			Me.CurrentElementTextBox.Size = New System.Drawing.Size(156, 18)
			Me.CurrentElementTextBox.TabIndex = 1
			' 
			' NGaugeHitTestingUC
			' 
			Me.Controls.Add(Me.CurrentElementTextBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NGaugeHitTestingUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region
	End Class
End Namespace
