Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomScaleDecorationsUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(HotZoneBeginDropDownList, 55, 85, 5)
				WebExamplesUtilities.FillComboWithValues(ColdZoneEndDropDownList, 5, 45, 5)

				HotZoneBeginDropDownList.SelectedIndex = 3
				ColdZoneEndDropDownList.SelectedIndex = 4
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Temperature Measurements <br/><font size = '8pt'>Demonstrates how to Custom Program the Scale</font>")
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Disabled
			Dim chart As NChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(95, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))


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
		End Sub

		Private Sub UpdateScale()
			Dim primaryY As NAxis = nChartControl1.Charts(0).Axis(StandardAxis.PrimaryY)
			Dim hotZoneRange As NRange1DD = New NRange1DD(Convert.ToDouble(HotZoneBeginDropDownList.SelectedValue), 100)
			Dim coldZoneRange As NRange1DD = New NRange1DD(0, Convert.ToDouble(ColdZoneEndDropDownList.SelectedValue))

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
			separator = New NScaleLevelSeparator(0, anchor, ScaleLevelShape.Line, Nothing, New NStrokeStyle(1, Color.Red), New NLength(0), New NLength(0), New NLength(0), New NLength(0), Nothing, Nothing, Nothing, False)
			customScaleDecorator.Decorations.Add(separator)

			' create a value scale label
			label = New NValueScaleLabel()
			label.Text = "Hot Zone"
			label.Anchor = New NRulerValueDecorationAnchor(HorzAlign.Right, New NLength(0))
			label.Offset = New NLength(6, NGraphicsUnit.Point)
			label.Style.TextStyle.FillStyle = New NColorFillStyle(Color.Red)
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
			label.Offset = New NLength(6, NGraphicsUnit.Point)
			label.Style.TextStyle.FillStyle = New NColorFillStyle(Color.Blue)
			label.Style.ContentAlignment = ContentAlignment.TopLeft
			label.Style.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90, True)

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

		Protected Sub HotZoneBeginDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateScale()
		End Sub

		Protected Sub ColdZoneEndDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateScale()
		End Sub
	End Class
End Namespace
