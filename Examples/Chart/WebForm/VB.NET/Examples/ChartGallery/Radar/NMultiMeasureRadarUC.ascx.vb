Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NMultiMeasureRadarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Montana County Comparison<br/><font size = '9pt'>Demonstrates how to create a multi measure radar chart</font>")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.TextStyle.TextFormat = TextFormat.XML
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(0, 5, 0, 5)
			nChartControl1.Panels.Add(title)

			Dim legend As NLegend = New NLegend()
			legend.Header.Text = "County"
			legend.DockMode = PanelDockMode.Right
			legend.Margins = New NMarginsL(5, 0, 5, 0)
			nChartControl1.Panels.Add(legend)

			' setup chart
			Dim radarChart As NRadarChart = New NRadarChart()
			radarChart.Margins = New NMarginsL(5, 0, 0, 5)
			nChartControl1.Panels.Add(radarChart)
			radarChart.DisplayOnLegend = legend
			radarChart.DockMode = PanelDockMode.Fill
			radarChart.RadarMode = RadarMode.MultiMeasure
			radarChart.InnerRadius = New NLength(10, NRelativeUnit.ParentPercentage)

			' set some axis labels
			AddAxis(radarChart, "Population", True)
			AddAxis(radarChart, "Housing Units", True)
			AddAxis(radarChart, "Water", False)
			AddAxis(radarChart, "Land", True)
			AddAxis(radarChart, "Population" & Constants.vbCrLf & "Density", False)
			AddAxis(radarChart, "Housing" & Constants.vbCrLf & "Density", False)

			' sample data
			Dim data As Object() = New Object(){ "Cascade", 80357, 35225, 13.75, 2697.90, 29.8, 13.1, "Custer", 11696, 5360, 10.09, 3783.13, 3.1, 1.4, "Dawson", 9059, 4168, 9.99, 2373.14, 3.8, 1.8, "Jefferson", 10049, 4199, 2.19, 1656.64, 6.1, 2.5, "Missoula", 95802, 41319, 20.37, 2597.97, 36.9, 15.9, "Powell", 7180, 2930, 6.74, 2325.94, 3.1, 1.3 }

			For i As Integer = 0 To 5
				Dim radarLine As NRadarLineSeries = New NRadarLineSeries()
				radarChart.Series.Add(radarLine)

				Dim baseIndex As Integer = i * 7
				radarLine.Name = data(baseIndex).ToString()
				baseIndex = baseIndex + 1

				For j As Integer = 0 To 5
					radarLine.Values.Add(System.Convert.ToDouble(data(baseIndex)))
					baseIndex = baseIndex + 1
				Next j

				radarLine.DataLabelStyle.Visible = False
				radarLine.MarkerStyle.Width = New NLength(4)
				radarLine.MarkerStyle.Height = New NLength(4)
				radarLine.MarkerStyle.Visible = True
				radarLine.BorderStyle.Width = New NLength(2)
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Bright)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub AddAxis(ByVal radar As NRadarChart, ByVal title As String, ByVal applyKFormatting As Boolean)
			Dim axis As NRadarAxis = New NRadarAxis()

			' set title
			axis.Title = title
			radar.Axes.Add(axis)

			If applyKFormatting Then
				Dim linearScale As NLinearScaleConfigurator = TryCast(axis.ScaleConfigurator, NLinearScaleConfigurator)
				linearScale.LabelValueFormatter = New NNumericValueFormatter("0,K")
			End If
		End Sub
	End Class
End Namespace
