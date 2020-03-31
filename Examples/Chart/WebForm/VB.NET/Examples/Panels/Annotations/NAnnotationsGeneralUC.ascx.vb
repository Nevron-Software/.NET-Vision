Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAnnotationsGeneralUC
		Inherits NExampleUC
		Private nChart As NChart
		Private nLegend As NLegend
		Private nBar As NBarSeries
		Private nLine As NLineSeries
		Private nRectangularCallout As NRectangularCallout
		Private nRoundedRectangularCallout As NRoundedRectangularCallout
		Private nCutEdgeRectangularCallout As NCutEdgeRectangularCallout
		Private nOvalCallout As NOvalCallout
		Private nArrowAnnotation As NArrowAnnotation

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			ConfigureChart()
			ConfigureAnnotations()
		End Sub

		Private Sub ConfigureChart()
			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Annotations")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomCenter
			header.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nLegend = nChartControl1.Legends(0)

			' setup the chart
			nChart = nChartControl1.Charts(0)
			nChart.Enable3D = True
			nChart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			nChart.Axis(StandardAxis.Depth).Visible = False

			Dim scaleX As NOrdinalScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount

			' add the line series
			nLine = CType(nChart.Series.Add(SeriesType.Line), NLineSeries)
			nLine.Name = "Cumulative"
			nLine.DataLabelStyle.Visible = False
			nLine.BorderStyle = New NStrokeStyle(GreyBlue)
			nLine.MarkerStyle.Visible = True
			nLine.MarkerStyle.PointShape = PointShape.Cylinder
			nLine.MarkerStyle.FillStyle = New NColorFillStyle(Green)
			nLine.MarkerStyle.BorderStyle = New NStrokeStyle(GreyBlue)
			nLine.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			nLine.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			nLine.ShadowStyle.Type = ShadowType.GaussianBlur
			nLine.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			nLine.ShadowStyle.Offset = New NPointL(2, 2)
			nLine.ShadowStyle.FadeLength = New NLength(4)

			' add the bar series
			nBar = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar.Name = "Bar Series"
			nBar.DataLabelStyle.Visible = False
			nBar.BorderStyle = New NStrokeStyle(DarkOrange)
			nBar.FillStyle = New NColorFillStyle(DarkOrange)
			nBar.ShadowStyle.Type = ShadowType.GaussianBlur
			nBar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			nBar.ShadowStyle.Offset = New NPointL(3, 3)
			nBar.ShadowStyle.FadeLength = New NLength(4)

			' fill with random data and sort in descending order
			nBar.Values.FillRandom(Random, 10)
			nBar.Values.Sort(DataSeriesSortOrder.Descending)

			' generate a data series cumulative sum of the bar values
			Dim fc As NFunctionCalculator = New NFunctionCalculator()
			fc.Expression = "CUMSUM(Value)"
			fc.Arguments.Add(nBar.Values)
			nLine.Values = fc.Calculate()
		End Sub

		Private Sub ConfigureAnnotations()
			If rectPanelCheck.Checked Then
				nRectangularCallout = New NRectangularCallout()
				nRectangularCallout.ArrowLength = New NLength(15, NRelativeUnit.ParentPercentage)
				nRectangularCallout.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.CadetBlue))
				nRectangularCallout.UseAutomaticSize = True
				nRectangularCallout.Orientation = 225
				nRectangularCallout.Anchor = New NDataPointAnchor(nBar, 2, ContentAlignment.MiddleCenter, StringAlignment.Center)
				nRectangularCallout.Text = GetTextForAnnotation(nRectangularCallout)
				nRectangularCallout.TextStyle.FontStyle.EmSize = New NLength(8)
				nChartControl1.Panels.Add(nRectangularCallout)
			End If

			If roundRectCalloutCheck.Checked Then
				nRoundedRectangularCallout = New NRoundedRectangularCallout()
				nRoundedRectangularCallout.ArrowLength = New NLength(15, NRelativeUnit.ParentPercentage)
				nRoundedRectangularCallout.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightGreen))
				nRoundedRectangularCallout.UseAutomaticSize = True
				nRoundedRectangularCallout.Orientation = 135
				nRoundedRectangularCallout.Anchor = New NModelPointAnchor(nChart, New NVector3DF(0, 0, 0))
				nRoundedRectangularCallout.Text = GetTextForAnnotation(nRoundedRectangularCallout)
				nRoundedRectangularCallout.TextStyle.FontStyle.EmSize = New NLength(8)
				nChartControl1.Panels.Add(nRoundedRectangularCallout)
			End If

			If cutedgeRectPanelCheck.Checked Then
				nCutEdgeRectangularCallout = New NCutEdgeRectangularCallout()
				nCutEdgeRectangularCallout.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightBlue))
				nCutEdgeRectangularCallout.ArrowLength = New NLength(40, NRelativeUnit.ParentPercentage)
				nCutEdgeRectangularCallout.UseAutomaticSize = True
				nCutEdgeRectangularCallout.Orientation = 190
				nCutEdgeRectangularCallout.Anchor = New NLegendDataItemAnchor(nLegend, 1)
				nCutEdgeRectangularCallout.Text = GetTextForAnnotation(nCutEdgeRectangularCallout)
				nCutEdgeRectangularCallout.TextStyle.FontStyle.EmSize = New NLength(8)
				nChartControl1.Panels.Add(nCutEdgeRectangularCallout)
			End If

			If ovalPanelCheck.Checked Then
				nOvalCallout = New NOvalCallout()
				nOvalCallout.FillStyle = New NColorFillStyle(Color.FromArgb(200, Color.AliceBlue))
				nOvalCallout.ArrowLength = New NLength(15, NRelativeUnit.ParentPercentage)
				nOvalCallout.UseAutomaticSize = True
				nOvalCallout.Orientation = 315
				nOvalCallout.Anchor = New NScalePointAnchor(nChart, CInt(Fix(StandardAxis.PrimaryX)), CInt(Fix(StandardAxis.PrimaryY)), CInt(Fix(StandardAxis.Depth)), AxisValueAnchorMode.Clip, New NVector3DD(7, 100, 0))
				nOvalCallout.Text = GetTextForAnnotation(nOvalCallout)
				nOvalCallout.TextStyle.FontStyle.EmSize = New NLength(8)
				nChartControl1.Panels.Add(nOvalCallout)
			End If

			If arrowCheck.Checked Then
				nArrowAnnotation = New NArrowAnnotation()
				nArrowAnnotation.UseAutomaticSize = True
				nArrowAnnotation.ArrowHeadWidthPercent = 30
				nArrowAnnotation.TextStyle.FontStyle.EmSize = New NLength(11, NGraphicsUnit.Point)
				nArrowAnnotation.TextStyle.FontStyle.Style = nArrowAnnotation.TextStyle.FontStyle.Style Or FontStyle.Bold
				nArrowAnnotation.Orientation = 45
				nArrowAnnotation.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.Orange))
				nArrowAnnotation.Anchor = New NDataPointAnchor(nBar, 4, ContentAlignment.MiddleCenter, StringAlignment.Center)
				nArrowAnnotation.Text = GetTextForAnnotation(nArrowAnnotation)
				nArrowAnnotation.TextStyle.FontStyle.EmSize = New NLength(8)
				nChartControl1.Panels.Add(nArrowAnnotation)
			End If
		End Sub

		Private Function GetTextForAnnotation(ByVal annotation As NAnchorPanel) As String
			Dim sText As String = ""

			If TypeOf annotation Is NRectangularCallout Then
				sText = "This is a rectangular callout panel " & Constants.vbCrLf
			ElseIf TypeOf annotation Is NRoundedRectangularCallout Then
				sText = "This is a rounded rectangular callout panel " & Constants.vbCrLf
			ElseIf TypeOf annotation Is NCutEdgeRectangularCallout Then
				sText = "This is a cut edge rectangular callout panel " & Constants.vbCrLf
			ElseIf TypeOf annotation Is NOvalCallout Then
				sText = "This is an oval callout panel " & Constants.vbCrLf
			ElseIf TypeOf annotation Is NArrowAnnotation Then
				sText = "This is an arrow annotation " & Constants.vbCrLf
			Else
				Debug.Assert(False)
			End If

			Return sText & GetTextForAnchor(annotation.Anchor)
		End Function

		Private Function GetTextForAnchor(ByVal anchor As NAnchor) As String
			Dim sText As String = "attached to "

			If TypeOf anchor Is NAxisValueAnchor Then
				sText &= "an axis value."
			ElseIf TypeOf anchor Is NDataPointAnchor Then
				sText &= "a chart data point."
			ElseIf TypeOf anchor Is NLegendDataItemAnchor Then
				sText &= "a legend data point."
			ElseIf TypeOf anchor Is NModelPointAnchor Then
				sText &= "a model point."
			ElseIf TypeOf anchor Is NScalePointAnchor Then
				sText &= "a scale point."
			Else
				Debug.Assert(False)
			End If

			Return sText
		End Function
	End Class
End Namespace
