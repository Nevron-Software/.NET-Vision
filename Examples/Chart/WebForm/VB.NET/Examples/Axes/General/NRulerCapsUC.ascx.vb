Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NRulerCapsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Axis Ruler Caps<br/> <font size = '9pt'>Demonstrates how to change the caps of the axis ruler</font>")
			header.DockMode = PanelDockMode.Top
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.FitAlignment = ContentAlignment.MiddleLeft
			header.Margins = New NMarginsL(5, 0, 0, 5)

			nChartControl1.Panels.Add(header)

			Dim chart As NCartesianChart = New NCartesianChart()
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch
			chart.Margins = New NMarginsL(5, 10, 10, 5)
			nChartControl1.Panels.Add(chart)

			Dim random As Random = New Random()

			' feed some random data 
			Dim point As NPointSeries = New NPointSeries()
			point.DataLabelStyle.Visible = False
			point.UseXValues = True
			point.Size = New NLength(5)
			point.BorderStyle.Width = New NLength(0)

			' fill in some random data
			For j As Integer = 0 To 29
				point.Values.Add(5 + random.Next(90))
				point.XValues.Add(5 + random.Next(90))
			Next j

			chart.Series.Add(point)

			' configure scales
			Dim xScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			xScale.RoundToTickMax = True
			xScale.RoundToTickMin = True
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			xScale.ScaleBreaks.Add(New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Orange)), Nothing, New NLength(10)), New NRange1DD(29, 41)))

			' add an interlaced strip to the X axis
			Dim xInterlacedStrip As NScaleStripStyle = New NScaleStripStyle()
			xInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			xInterlacedStrip.Interlaced = True
			xInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			xScale.StripStyles.Add(xInterlacedStrip)

			Dim xAxis As NCartesianAxis = CType(chart.Axis(StandardAxis.PrimaryX), NCartesianAxis)
			xAxis.ScaleConfigurator = xScale
			xAxis.View = New NRangeAxisView(New NRange1DD(0, 100))

			Dim xAxisAnchor As NDockAxisAnchor = New NDockAxisAnchor(AxisDockZone.FrontBottom)
			xAxisAnchor.BeforeSpace = New NLength(10)
			xAxis.Anchor = xAxisAnchor

			Dim yScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			yScale.RoundToTickMax = True
			yScale.RoundToTickMin = True
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScale.ScaleBreaks.Add(New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Orange)), Nothing, New NLength(10)), New NRange1DD(29, 41)))

			' add an interlaced strip to the Y axis
			Dim yInterlacedStrip As NScaleStripStyle = New NScaleStripStyle()
			yInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			yInterlacedStrip.Interlaced = True
			yInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			yScale.StripStyles.Add(yInterlacedStrip)

			Dim yAxis As NCartesianAxis = CType(chart.Axis(StandardAxis.PrimaryY), NCartesianAxis)
			yAxis.ScaleConfigurator = yScale
			yAxis.View = New NRangeAxisView(New NRange1DD(0, 100))

			Dim yAxisAnchor As NDockAxisAnchor = New NDockAxisAnchor(AxisDockZone.FrontLeft)
			yAxisAnchor.BeforeSpace = New NLength(10)
			yAxis.Anchor = yAxisAnchor

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' update form controls
			If (Not IsPostBack) Then
				PaintOnScaleBreaksCheckBox.Checked = False

				WebExamplesUtilities.FillComboWithEnumValues(BeginCapStyleDropDownList, GetType(CapStyle))
				BeginCapStyleDropDownList.SelectedIndex = CInt(Fix(CapStyle.Ellipse))

				WebExamplesUtilities.FillComboWithEnumValues(ScaleBreakCapStyleDropDownList, GetType(CapStyle))
				ScaleBreakCapStyleDropDownList.SelectedIndex = CInt(Fix(CapStyle.LeftCrossLine))

				WebExamplesUtilities.FillComboWithEnumValues(EndCapStyleDropDownList, GetType(CapStyle))
				EndCapStyleDropDownList.SelectedIndex = CInt(Fix(CapStyle.Arrow))
			End If

			UpdateRulerStyleForAxis(xAxis)
			UpdateRulerStyleForAxis(yAxis)
		End Sub

		Private Sub UpdateRulerStyleForAxis(ByVal axis As NAxis)
			' Update the ruler caps for the axis from form controls
			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			' apply style to begin and end caps
			scale.RulerStyle.BeginCapStyle.Style = CType(BeginCapStyleDropDownList.SelectedIndex, CapStyle)
			scale.RulerStyle.EndCapStyle.Style = CType(EndCapStyleDropDownList.SelectedIndex, CapStyle)
			scale.RulerStyle.ScaleBreakCapStyle.Style = CType(ScaleBreakCapStyleDropDownList.SelectedIndex, CapStyle)
			scale.RulerStyle.PaintOnScaleBreaks = PaintOnScaleBreaksCheckBox.Checked
		End Sub

	End Class
End Namespace
