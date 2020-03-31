Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NClientSideEventsToolUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				CaptureMouseEventDropDownList.Items.Add("OnClick")
				CaptureMouseEventDropDownList.Items.Add("OnDblClick")
				CaptureMouseEventDropDownList.Items.Add("OnMouseEnter")
				CaptureMouseEventDropDownList.Items.Add("OnMouseLeave")
				CaptureMouseEventDropDownList.Items.Add("Postback")
				CaptureMouseEventDropDownList.SelectedIndex = 0
			End If

			Dim bar As NBarSeries

			If (Not NThinChartControl1.Initialized) Then
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False

				' set a chart title
				Dim header As NLabel = NThinChartControl1.Labels.AddHeader("Client Side Events Tool")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.ContentAlignment = ContentAlignment.BottomRight
				header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

				' configure the legend
				Dim legend As NLegend = NThinChartControl1.Legends(0)
				legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Right)
				legend.FillStyle.SetTransparencyPercent(50)
				legend.Location = New NPointL(New NLength(98, NRelativeUnit.ParentPercentage), legend.Location.Y)

				' configure the chart
				Dim chart As NChart = NThinChartControl1.Charts(0)
				chart.Axis(StandardAxis.Depth).Visible = False
				chart.BoundsMode = BoundsMode.Fit
				chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

				' create a bar series
				bar = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
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

				NThinChartControl1.Controller.Tools.Add(New NClientMouseEventTool())
			Else
				bar = CType(NThinChartControl1.Charts(0).Series(0), NBarSeries)
			End If

			bar.InteractivityStyles.Clear()
			Dim i As Integer = 0
			Do While i < bar.Values.Count
				Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()

				Dim script As String = "alert(""Mouse Event [" & CaptureMouseEventDropDownList.SelectedValue.ToString() & "]. Captured for bar [" & i.ToString() & "])"");"

				Select Case CaptureMouseEventDropDownList.SelectedIndex
					Case 0 ' OnClick
						interactivityStyle.ClientMouseEventAttribute.Click = script
					Case 1 ' OnDblClick
						interactivityStyle.ClientMouseEventAttribute.DoubleClick = script
					Case 2 ' OnMouseEnter
						interactivityStyle.ClientMouseEventAttribute.MouseEnter = script
					Case 3 ' OnMouseLeave
						interactivityStyle.ClientMouseEventAttribute.MouseLeave = script
					Case 4
						interactivityStyle.ClientMouseEventAttribute.Click = "_doPostback()"
				End Select

				bar.InteractivityStyles(i) = interactivityStyle
				i += 1
			Loop
		End Sub
	End Class
End Namespace
