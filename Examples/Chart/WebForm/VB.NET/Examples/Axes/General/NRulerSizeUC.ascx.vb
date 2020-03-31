Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NRulesSizeUC
		Inherits NExampleUC

		Private nChart As NChart
		Private nCustomAxisId As Integer

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithPercents(RedAxisEndPercentDropDownList, 1)
				WebExamplesUtilities.FillComboWithPercents(BlueAxisEndPercentDropDownList, 1)

				RedAxisEndPercentDropDownList.SelectedIndex = 40
				BlueAxisEndPercentDropDownList.SelectedIndex = 60
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Docking and Anchor Percentages<br/> <font size = '9pt'>Demonstrates how to dock axes without creating a new zone level</font>")
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			nChart = nChartControl1.Charts(0)
			nChart.Enable3D = True
			nChart.BoundsMode = BoundsMode.Fit
			nChart.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			nChart.Size = New NSizeL(New NLength(96, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' apply predefined lighting and projection
			nChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			' configure primary Y
			Dim primaryY As NAxis = nChart.Axis(StandardAxis.PrimaryY)
			primaryY.Anchor.BeginPercent = 0
			primaryY.Anchor.EndPercent = 30

			' configure secondary Y
			Dim secondaryY As NAxis = nChart.Axis(StandardAxis.SecondaryY)
			secondaryY.Visible = True
			secondaryY.Anchor.BeginPercent = 30
			secondaryY.Anchor.EndPercent = 70

			' configure a custom axis docked to the front left left chart zone
			Dim customY As NAxis = (CType(nChart.Axes, NCartesianAxisCollection)).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft)
			customY.Visible = True
			customY.Anchor.BeginPercent = 70
			customY.Anchor.EndPercent = 100
			nCustomAxisId = customY.AxisId

			' Setup the line series
			Dim l1 As NLineSeries = CType(nChart.Series.Add(SeriesType.Line), NLineSeries)
			l1.Values.FillRandom(Random, 5)
			l1.LineSegmentShape = LineSegmentShape.Tape
			l1.DataLabelStyle.Format = "<value>"

			Dim l2 As NLineSeries = CType(nChart.Series.Add(SeriesType.Line), NLineSeries)
			l2.Values.FillRandom(Random, 5)
			l2.LineSegmentShape = LineSegmentShape.Tape
			l2.DataLabelStyle.Format = "<value>"
			l2.DisplayOnAxis(StandardAxis.SecondaryY, True)
			l2.DisplayOnAxis(StandardAxis.PrimaryY, False)

			Dim l3 As NLineSeries = CType(nChart.Series.Add(SeriesType.Line), NLineSeries)
			l3.Values.FillRandom(Random, 5)
			l3.LineSegmentShape = LineSegmentShape.Tape
			l3.DataLabelStyle.Format = "<value>"
			l3.DisplayOnAxis(nCustomAxisId, True)
			l3.DisplayOnAxis(StandardAxis.PrimaryY, False)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' set up the appearance of the axes according to the filling/stroke 
			' applied to the line series from the style sheet
			primaryY.ScaleConfigurator = ConfigureScale(l1.FillStyle, l1.BorderStyle.Color)
			secondaryY.ScaleConfigurator = ConfigureScale(l2.FillStyle, l2.BorderStyle.Color)
			customY.ScaleConfigurator = ConfigureScale(l3.FillStyle, l3.BorderStyle.Color)

			RecalcAxes()
		End Sub

		Private Function ConfigureScale(ByVal rulerFillStyle As NFillStyle, ByVal tickColor As Color) As NLinearScaleConfigurator
			Dim scale As NLinearScaleConfigurator = New NLinearScaleConfigurator()

			scale.RulerStyle.FillStyle = CType(rulerFillStyle.Clone(), NFillStyle)
			scale.RulerStyle.Shape = ScaleLevelShape.Bar
			scale.RulerStyle.Height = New NLength(5, NGraphicsUnit.Point)
			scale.RulerStyle.BorderStyle.Color = tickColor
			scale.OuterMajorTickStyle.LineStyle.Color = tickColor
			scale.InnerMajorTickStyle.LineStyle.Color = tickColor
			scale.MajorGridStyle.LineStyle.Color = tickColor

			Dim strip As NScaleStripStyle = New NScaleStripStyle()
			strip.StrokeStyle = Nothing
			strip.FillStyle = CType(rulerFillStyle.Clone(), NFillStyle)
			strip.FillStyle.SetTransparencyPercent(80)
			strip.SetShowAtWall(ChartWallType.Back, True)
			strip.SetShowAtWall(ChartWallType.Left, True)
			scale.StripStyles.Add(strip)

			scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			scale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			Return scale
		End Function

		Private Sub RecalcAxes()
			Dim bottomAxisEnd As Integer = Convert.ToInt32(RedAxisEndPercentDropDownList.SelectedIndex)
			Dim middleAxisBegin As Integer = Convert.ToInt32(RedAxisEndPercentDropDownList.SelectedIndex)
			Dim middleAxisEnd As Integer = Convert.ToInt32(BlueAxisEndPercentDropDownList.SelectedIndex)
			Dim topAxisBegin As Integer = Convert.ToInt32(BlueAxisEndPercentDropDownList.SelectedIndex)

			' red axis
			Dim axis As NAxis = nChart.Axis(StandardAxis.PrimaryY)
			axis.Anchor.EndPercent = middleAxisBegin

			' green axis
			axis = nChart.Axis(StandardAxis.SecondaryY)
			axis.Anchor.BeginPercent = middleAxisBegin
			axis.Anchor.EndPercent = middleAxisEnd

			' blue axis
			axis = nChart.Axis(nCustomAxisId)
			axis.Anchor.BeginPercent = topAxisBegin
		End Sub
	End Class
End Namespace
