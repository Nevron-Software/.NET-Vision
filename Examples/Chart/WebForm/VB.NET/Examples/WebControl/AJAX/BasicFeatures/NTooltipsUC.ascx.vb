Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTooltipsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1.RequiresInitialization Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Settings.JitterMode = JitterMode.Enabled

				' configure legend
				Dim legend As NLegend = nChartControl1.Legends(0)
				legend.ShadowStyle.Type = ShadowType.GaussianBlur
				legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Left)
				legend.DockMode = PanelDockMode.Bottom
				legend.Margins = New NMarginsL(0, 0, 0, 10)
				legend.Data.ExpandMode = LegendExpandMode.ColsFixed
				legend.Data.ColCount = 2

				' set a chart title
				Dim header As NLabel = nChartControl1.Labels.AddHeader("Product Analysis")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.ContentAlignment = ContentAlignment.BottomRight
				header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

				' by default the chart contains a cartesian chart which cannot display pie series
				Dim chart As NPieChart = New NPieChart()
				chart.Enable3D = True

				nChartControl1.Charts.Clear()
				nChartControl1.Charts.Add(chart)
				chart.DisplayOnLegend = nChartControl1.Legends(0)

				Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)

				pie.AddDataPoint(New NDataPoint(23, ".NET Vision"))
				pie.AddDataPoint(New NDataPoint(56, "Chart"))
				pie.AddDataPoint(New NDataPoint(42, "Diagram"))
				pie.AddDataPoint(New NDataPoint(12, "User Interface"))

				pie.Legend.Mode = SeriesLegendMode.DataPoints
				pie.Legend.Format = "<label> <percent>"

				pie.PieStyle = PieStyle.SmoothEdgePie
				pie.LabelMode = PieLabelMode.Spider

				pie.LabelMode = PieLabelMode.Center
				pie.DataLabelStyle.ArrowLength = New NLength(0f, NRelativeUnit.ParentPercentage)
				pie.DataLabelStyle.ArrowPointerLength = New NLength(0f, NRelativeUnit.ParentPercentage)

				chart.LightModel.EnableLighting = True
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
				chart.BoundsMode = BoundsMode.Fit
				chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

				'	set up client side tooltips
				pie.InteractivityStyles.Add(0, New NInteractivityStyle(True, Nothing, ".NET Vision"))
				pie.InteractivityStyles.Add(1, New NInteractivityStyle(True, Nothing, "Chart"))
				pie.InteractivityStyles.Add(2, New NInteractivityStyle(True, Nothing, "Diagram"))
				pie.InteractivityStyles.Add(3, New NInteractivityStyle(True, Nothing, "User Interface"))

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			End If
		End Sub

		Protected Sub nChartControl1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.AjaxTools.Add(New NAjaxTooltipTool(True))
		End Sub
	End Class
End Namespace
