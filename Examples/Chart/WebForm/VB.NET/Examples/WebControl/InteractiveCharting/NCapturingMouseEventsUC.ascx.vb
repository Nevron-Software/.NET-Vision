Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCapturingMouseEventsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				CaptureMouseEventDropDownList.Items.Add("OnClick")
				CaptureMouseEventDropDownList.Items.Add("OnDblClick")
				CaptureMouseEventDropDownList.Items.Add("OnMouseOut")
				CaptureMouseEventDropDownList.Items.Add("OnMouseOver")
				CaptureMouseEventDropDownList.Items.Add("OnMouseWheel")
				CaptureMouseEventDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Capturing Mouse Events")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Right)
			legend.FillStyle.SetTransparencyPercent(50)
			legend.Location = New NPointL(New NLength(98, NRelativeUnit.ParentPercentage), legend.Location.Y)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' create a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "My Bar Series"
			bar.DataLabelStyle.Format = "<value>"

			bar.AddDataPoint(New NDataPoint(10, "Ford", New NColorFillStyle(WebExamplesUtilities.RandomColor())))
			bar.AddDataPoint(New NDataPoint(20, "Toyota", New NColorFillStyle(WebExamplesUtilities.RandomColor())))
			bar.AddDataPoint(New NDataPoint(30, "VW", New NColorFillStyle(WebExamplesUtilities.RandomColor())))
			bar.AddDataPoint(New NDataPoint(25, "Mitsubishi", New NColorFillStyle(WebExamplesUtilities.RandomColor())))
			bar.AddDataPoint(New NDataPoint(29, "Jaguar", New NColorFillStyle(WebExamplesUtilities.RandomColor())))

			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.BarShape = BarShape.SmoothEdgeBar
			bar.DataLabelStyle.Visible = False

			Dim i As Integer = 0
			Do While i < bar.Values.Count
				Dim customAttribute As String = CaptureMouseEventDropDownList.SelectedItem.Text & " = ""javascript:alert(' Mouse event [" & CaptureMouseEventDropDownList.SelectedItem.Text & "] intercepted for bar [" & i.ToString() & "] ')"" "
				Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()

				interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = customAttribute

				bar.InteractivityStyles(i) = interactivityStyle
				i += 1
			Loop

			' change the response type to image map
			Dim imageMapResponse As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse
		End Sub

		Protected Sub ApplyImageMapAttributesToSerie(ByVal bar As NBarSeries)
		End Sub
	End Class
End Namespace
