Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomScaleDecorationsUC
		Inherits NExampleBaseUC
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents HotZoneBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ColdZoneEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.HotZoneBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ColdZoneEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			CType(Me.HotZoneBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ColdZoneEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Hot Zone Begin:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 80)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(100, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Cold Zone End:"
			' 
			' HotZoneBeginUpDown
			' 
			Me.HotZoneBeginUpDown.Location = New System.Drawing.Point(8, 40)
			Me.HotZoneBeginUpDown.Maximum = New System.Decimal(New Integer() { 85, 0, 0, 0})
			Me.HotZoneBeginUpDown.Minimum = New System.Decimal(New Integer() { 55, 0, 0, 0})
			Me.HotZoneBeginUpDown.Name = "HotZoneBeginUpDown"
			Me.HotZoneBeginUpDown.Size = New System.Drawing.Size(120, 20)
			Me.HotZoneBeginUpDown.TabIndex = 1
			Me.HotZoneBeginUpDown.Value = New System.Decimal(New Integer() { 70, 0, 0, 0})
'			Me.HotZoneBeginUpDown.ValueChanged += New System.EventHandler(Me.HotZoneBeginUpDown_ValueChanged);
			' 
			' ColdZoneEndUpDown
			' 
			Me.ColdZoneEndUpDown.Location = New System.Drawing.Point(8, 104)
			Me.ColdZoneEndUpDown.Maximum = New System.Decimal(New Integer() { 45, 0, 0, 0})
			Me.ColdZoneEndUpDown.Minimum = New System.Decimal(New Integer() { 5, 0, 0, 0})
			Me.ColdZoneEndUpDown.Name = "ColdZoneEndUpDown"
			Me.ColdZoneEndUpDown.Size = New System.Drawing.Size(120, 20)
			Me.ColdZoneEndUpDown.TabIndex = 3
			Me.ColdZoneEndUpDown.Value = New System.Decimal(New Integer() { 25, 0, 0, 0})
'			Me.ColdZoneEndUpDown.ValueChanged += New System.EventHandler(Me.ColdZoneEndUpDown_ValueChanged);
			' 
			' NCustomScaleDecorationsUC
			' 
			Me.Controls.Add(Me.ColdZoneEndUpDown)
			Me.Controls.Add(Me.HotZoneBeginUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NCustomScaleDecorationsUC"
			Me.Size = New System.Drawing.Size(136, 296)
			CType(Me.HotZoneBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ColdZoneEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Temperature Measurements <br/><font size = '12pt'>Demonstrates how to Custom Program the Scale</font>")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.TextFormat = TextFormat.XML
			title.SendToBack()
			title.DockMode = PanelDockMode.Top

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Disabled
			Dim chart As NChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.DockMode = PanelDockMode.Fill
			chart.DockMargins = New NMarginsL(2, 2, 10, 10)

			' create a point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point Series"
			point.DataLabelStyle.Visible = False
			point.MarkerStyle.Visible = False
			point.Size = New NLength(5, NGraphicsUnit.Point)

			Dim rand As Random = New Random()
			For i As Integer = 0 To 29
				point.Values.Add(5 + rand.Next(90))
			Next i

			Dim primaryY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			primaryY.View = New NRangeAxisView(New NRange1DD(0, 100), True, True)
			Dim linearScale As NLinearScaleConfigurator = TryCast(primaryY.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False

			UpdateScale()

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateScale()
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim primaryY As NAxis = nChartControl1.Charts(0).Axis(StandardAxis.PrimaryY)
			Dim hotZoneRange As NRange1DD = New NRange1DD(CDbl(HotZoneBeginUpDown.Value), 100)
			Dim coldZoneRange As NRange1DD = New NRange1DD(0, CDbl(ColdZoneEndUpDown.Value))

			Dim hotZoneSection As NScaleSectionStyle = New NScaleSectionStyle()
			hotZoneSection.Range = hotZoneRange
			hotZoneSection.LabelTextStyle = New NTextStyle(New NFontStyle(), Color.Red)
			hotZoneSection.MajorTickStrokeStyle = New NStrokeStyle(1, Color.Red)
			hotZoneSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(50, Color.Red))
			hotZoneSection.SetShowAtWall(ChartWallType.Back, True)

			Dim coldZoneSection As NScaleSectionStyle = New NScaleSectionStyle()
			coldZoneSection.Range = coldZoneRange
			coldZoneSection.LabelTextStyle = New NTextStyle(New NFontStyle(), Color.Blue)
			coldZoneSection.MajorTickStrokeStyle = New NStrokeStyle(1, Color.Blue)
			coldZoneSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(50, Color.Blue))
			coldZoneSection.SetShowAtWall(ChartWallType.Back, True)

			Dim configurator As NStandardScaleConfigurator = CType(primaryY.ScaleConfigurator, NStandardScaleConfigurator)

			configurator.Sections.Clear()
			configurator.Sections.Add(hotZoneSection)
			configurator.Sections.Add(coldZoneSection)

			' first use the scale configurator to output some definition
			primaryY.SynchronizeScaleWithConfigurator = True
			primaryY.InvalidateScale()
			primaryY.UpdateScale()
			primaryY.SynchronizeScaleWithConfigurator = False

			' manually program the scale
			Dim scaleLevel As NScaleLevel
			Dim customScaleDecorator As NCustomScaleDecorator
			Dim anchor As NScaleRangeDecorationAnchor
			Dim separator As NScaleLevelSeparator
			Dim label As NValueScaleLabel
			Dim rangeSampler As NNumericDoubleStepRangeSampler
			Dim clampedRangeSampler As NClampedRangeSampler
			Dim tickFactory As NScaleTickFactory
			Dim sampledDecorator As NSampledScaleDecorator

			' create the hot zone

			' add a level separator
			scaleLevel = New NScaleLevel()
			customScaleDecorator = New NCustomScaleDecorator()

			anchor = New NScaleRangeDecorationAnchor(hotZoneRange)
			separator = New NScaleLevelSeparator(0, anchor, ScaleLevelShape.Line, Nothing, New NStrokeStyle(1, Color.Red))
			customScaleDecorator.Decorations.Add(separator)

			' create a value scale label
			label = New NValueScaleLabel()
			label.Text = "Hot Zone"
			label.Anchor = New NRulerValueDecorationAnchor(HorzAlign.Right, New NLength(0))
			label.Style.TextStyle.FillStyle = New NColorFillStyle(Color.Red)
			label.Offset = New NLength(6, NGraphicsUnit.Point)
			label.Style.ContentAlignment = ContentAlignment.TopRight
			label.Style.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90, True)

			customScaleDecorator.Decorations.Add(label)
			scaleLevel.Decorators.Add(customScaleDecorator)

			' add a some ticks
			rangeSampler = New NNumericDoubleStepRangeSampler(New NCustomNumericStepProvider(5))
			rangeSampler.UseCustomOrigin = True
			rangeSampler.CustomOrigin = 0
			clampedRangeSampler = New NClampedRangeSampler(rangeSampler, hotZoneRange)

			tickFactory = New NScaleTickFactory(0, ScaleTickShape.Line, New NLength(0), New NSizeL(New NLength(1), New NLength(5, NGraphicsUnit.Point)), New NConstValueProvider(New NColorFillStyle(Color.Red)), New NConstValueProvider(New NStrokeStyle(1, Color.Red)), HorzAlign.Left)

			sampledDecorator = New NSampledScaleDecorator(clampedRangeSampler, tickFactory)
			scaleLevel.Decorators.Add(sampledDecorator)

			' create the cold zone
			' add a level separator
			customScaleDecorator = New NCustomScaleDecorator()

			anchor = New NScaleRangeDecorationAnchor(coldZoneRange)
			separator = New NScaleLevelSeparator(0, anchor, ScaleLevelShape.Line, Nothing, New NStrokeStyle(1, Color.Blue))
			customScaleDecorator.Decorations.Add(separator)

			' create a value scale label
			label = New NValueScaleLabel()
			label.Text = "Cold Zone"
			label.Anchor = New NRulerValueDecorationAnchor(HorzAlign.Left, New NLength(0))
			label.Style.TextStyle.FillStyle = New NColorFillStyle(Color.Blue)
			label.Style.ContentAlignment = ContentAlignment.TopLeft
			label.Style.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90, True)
			label.Offset = New NLength(6, NGraphicsUnit.Point)

			customScaleDecorator.Decorations.Add(label)
			scaleLevel.Decorators.Add(customScaleDecorator)

			' add a some ticks
			rangeSampler = New NNumericDoubleStepRangeSampler(New NCustomNumericStepProvider(5))
			clampedRangeSampler = New NClampedRangeSampler(rangeSampler, coldZoneRange)
			tickFactory = New NScaleTickFactory(0, ScaleTickShape.Line, New NLength(0), New NSizeL(New NLength(1), New NLength(5, NGraphicsUnit.Point)), New NConstValueProvider(New NColorFillStyle(Color.Red)), New NConstValueProvider(New NStrokeStyle(1, Color.Blue)), HorzAlign.Left)

			sampledDecorator = New NSampledScaleDecorator(clampedRangeSampler, tickFactory)
			scaleLevel.Decorators.Add(sampledDecorator)

			primaryY.Scale.Levels.Add(scaleLevel)

			UpdateData(hotZoneRange, coldZoneRange)

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateData(ByVal hotZoneRange As NRange1DD, ByVal coldZoneRange As NRange1DD)
			Dim point As NPointSeries = TryCast(nChartControl1.Charts(0).Series(0), NPointSeries)

			Dim i As Integer = 0
			Do While i < point.Values.Count
				If hotZoneRange.Contains(CDbl(point.Values(i))) Then
					point.FillStyles(i) = New NColorFillStyle(Color.Red)
				ElseIf coldZoneRange.Contains(CDbl(point.Values(i))) Then
					point.FillStyles(i) = New NColorFillStyle(Color.Blue)
				Else
					point.FillStyles(i) = New NColorFillStyle(Color.SpringGreen)
				End If
				i += 1
			Loop
		End Sub

		Private Sub ColdZoneEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColdZoneEndUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub HotZoneBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HotZoneBeginUpDown.ValueChanged
			UpdateScale()
		End Sub
	End Class
End Namespace
