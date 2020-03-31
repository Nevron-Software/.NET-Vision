Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAdvancedFunnel2DUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Funnel Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed
			legend.Data.RowCount = 2

			Dim chart As NFunnelChart = New NFunnelChart()
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(68, NRelativeUnit.ParentPercentage))

			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			Dim funnel As NFunnelSeries = CType(chart.Series.Add(SeriesType.Funnel), NFunnelSeries)
			funnel.BorderStyle.Color = Color.LemonChiffon
			funnel.Legend.DisplayOnLegend = legend
			funnel.Legend.Format = "<percent>"
			funnel.Legend.Mode = SeriesLegendMode.DataPoints
			funnel.DataLabelStyle.Format = "<value> [<xsize>]"
			funnel.UseXSizes = True
			funnel.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			funnel.XSizes.ValueFormatter = New NNumericValueFormatter("0.00")

			GenerateData(funnel)

			If (Not IsPostBack) Then
				' init form controls
				WebExamplesUtilities.FillComboWithEnumValues(FunnelLabelModeDropDownList, GetType(FunnelLabelMode))
				FunnelLabelModeDropDownList.SelectedIndex = CInt(Fix(FunnelLabelMode.RightAligned))

				WebExamplesUtilities.FillComboWithValues(FunnelPointGapDropDownList, 0, 15, 1)
				FunnelPointGapDropDownList.SelectedIndex = 6

				WebExamplesUtilities.FillComboWithValues(FunnelRadiusDropDownList, 0, 100, 10)
				FunnelRadiusDropDownList.SelectedIndex = CInt(Fix(chart.Width / 10.0f))

				WebExamplesUtilities.FillComboWithValues(FunnelArrowLengthDropDownList, 0, 10, 1)
				FunnelArrowLengthDropDownList.SelectedIndex = 1
			End If

			' init funnel label mode
			funnel.LabelMode = CType(FunnelLabelModeDropDownList.SelectedIndex, FunnelLabelMode)

			Dim ha As HorzAlign = HorzAlign.Center

			Select Case funnel.LabelMode
				Case FunnelLabelMode.Left, FunnelLabelMode.LeftAligned
					ha = HorzAlign.Right

				Case FunnelLabelMode.Right, FunnelLabelMode.RightAligned
					ha = HorzAlign.Left
			End Select

			funnel.DataLabelStyle.TextStyle.StringFormatStyle.HorzAlign = ha

			' arrow length
			funnel.DataLabelStyle.ArrowLength = New NLength(CSng(FunnelArrowLengthDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)

			' funnel radius
			chart.Width = FunnelRadiusDropDownList.SelectedIndex * 10

			funnel.FunnelPointGap = FunnelPointGapDropDownList.SelectedIndex / 10.0f
		End Sub

		Private Sub GenerateData(ByVal funnel As NFunnelSeries)
			funnel.ClearDataPoints()

			Dim dSizeX As Double = 100
			Dim i As Integer = 0

			For i = 0 To 9
				funnel.Values.Add(Random.NextDouble() + 1)
				funnel.XSizes.Add(dSizeX)

				dSizeX -= Random.NextDouble() * 9
			Next i

			funnel.Values.Add(0.0)
			funnel.XSizes.Add(dSizeX)

			i = 0
			Do While i < arrCustomColors1.Length
				funnel.FillStyles(i) = arrCustomColors1(i)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
