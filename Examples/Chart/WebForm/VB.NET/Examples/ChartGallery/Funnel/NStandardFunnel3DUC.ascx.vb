Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandardFunnel3DUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Funnel Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight)

			Dim chart As NFunnelChart = New NFunnelChart()
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(85, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)
			chart.Projection.Elevation = 18

			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			Dim funnel As NFunnelSeries = CType(chart.Series.Add(SeriesType.Funnel), NFunnelSeries)
			funnel.BorderStyle.Color = Color.LemonChiffon
			funnel.Legend.DisplayOnLegend = legend
			funnel.Legend.Mode = SeriesLegendMode.DataPoints
			funnel.DataLabelStyle.Format = "<percent>"

			funnel.Values.Add(20.0)
			funnel.Values.Add(10.0)
			funnel.Values.Add(15.0)
			funnel.Values.Add(7.0)
			funnel.Values.Add(28.0)

			funnel.Labels.Add("Awareness")
			funnel.Labels.Add("First Hear")
			funnel.Labels.Add("Further Learn")
			funnel.Labels.Add("Liking")
			funnel.Labels.Add("Decision")

			Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Bright)

			Dim i As Integer = 0
			Do While i < funnel.Values.Count
				funnel.FillStyles(i) = palette.SeriesColors(i Mod palette.SeriesColors.Count)
				i += 1
			Loop

			If (Not IsPostBack) Then
				' init form controls
				WebExamplesUtilities.FillComboWithEnumValues(FunnelLabelModeDropDownList, GetType(FunnelLabelMode))
				FunnelLabelModeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(FunnelRadiusDropDownList, 0, 100, 10)
				FunnelRadiusDropDownList.SelectedIndex = CInt(Fix(chart.Width / 10))

				WebExamplesUtilities.FillComboWithValues(FunnelPointGapDropDownList, 0, 100, 10)
				FunnelPointGapDropDownList.SelectedIndex = CInt(Fix(funnel.FunnelPointGap / 10))

				WebExamplesUtilities.FillComboWithValues(NeckWidthDropDownList, 0, 100, 10)
				NeckWidthDropDownList.SelectedIndex = CInt(Fix(funnel.NeckWidthPercent / 10))

				WebExamplesUtilities.FillComboWithValues(NeckHeightDropDownList, 0, 100, 10)
				NeckHeightDropDownList.SelectedIndex = CInt(Fix(funnel.NeckHeightPercent / 10))

				WebExamplesUtilities.FillComboWithValues(LabelArrowLengthDropDownList, 0, 10, 1)
				LabelArrowLengthDropDownList.SelectedIndex = CInt(Fix(funnel.DataLabelStyle.ArrowLength.Value))
			End If

			SetLabelMode(funnel)

			' set funnel arrow length
			funnel.DataLabelStyle.ArrowLength = New NLength(CSng(LabelArrowLengthDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)

			' set funnel radius
			nChartControl1.Charts(0).Width = FunnelRadiusDropDownList.SelectedIndex * 10.0f

			' set funnel gap
			funnel.FunnelPointGap = FunnelPointGapDropDownList.SelectedIndex

			' set neck width
			funnel.NeckWidthPercent = NeckWidthDropDownList.SelectedIndex * 10.0f

			' set neck height
			funnel.NeckHeightPercent = NeckHeightDropDownList.SelectedIndex * 10.0f
		End Sub


		Private Sub SetLabelMode(ByVal funnel As NFunnelSeries)
			funnel.LabelMode = CType(FunnelLabelModeDropDownList.SelectedIndex, FunnelLabelMode)

			Dim ha As HorzAlign = HorzAlign.Center

			Select Case funnel.LabelMode
				Case FunnelLabelMode.Left, FunnelLabelMode.LeftAligned
					ha = HorzAlign.Right

				Case FunnelLabelMode.Right, FunnelLabelMode.RightAligned
					ha = HorzAlign.Left
			End Select

			funnel.DataLabelStyle.TextStyle.StringFormatStyle.HorzAlign = ha
		End Sub
	End Class
End Namespace
