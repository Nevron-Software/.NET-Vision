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
	Public Partial Class NStackedRadarAreaUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				StackModeDropDownList.Items.Clear()
				StackModeDropDownList.Items.Add("Stacked")
				StackModeDropDownList.Items.Add("Stacked %")
				StackModeDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stacked Radar Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)

			' configure the chart
			Dim radarChart As NRadarChart = New NRadarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(radarChart)
			radarChart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White
			radarChart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			radarChart.DisplayOnLegend = nChartControl1.Legends(0)

			AddAxis(radarChart, "Category A")
			AddAxis(radarChart, "Category B")
			AddAxis(radarChart, "Category C")
			AddAxis(radarChart, "Category D")
			AddAxis(radarChart, "Category E")

			' create the radar series
			Dim radarArea0 As NRadarAreaSeries = New NRadarAreaSeries()
			radarChart.Series.Add(radarArea0)
			radarArea0.Name = "Series 1"
			radarArea0.Values.FillRandomRange(Random, 5, 50, 90)
			radarArea0.DataLabelStyle.Visible = False
			radarArea0.DataLabelStyle.Format = "<value>"
			radarArea0.MarkerStyle.AutoDepth = True
			radarArea0.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarArea0.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)

			Dim radarArea1 As NRadarAreaSeries = New NRadarAreaSeries()
			radarChart.Series.Add(radarArea1)
			radarArea1.Name = "Series 2"
			radarArea1.Values.FillRandomRange(Random, 5, 0, 100)
			radarArea1.DataLabelStyle.Visible = False
			radarArea1.DataLabelStyle.Format = "<value>"
			radarArea1.MarkerStyle.AutoDepth = True
			radarArea1.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarArea1.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)

			Dim radarArea2 As NRadarAreaSeries = New NRadarAreaSeries()
			radarChart.Series.Add(radarArea2)
			radarArea2.Name = "Series 3"
			radarArea2.Values.FillRandomRange(Random, 5, 0, 100)
			radarArea2.DataLabelStyle.Visible = False
			radarArea2.DataLabelStyle.Format = "<value>"
			radarArea2.MarkerStyle.AutoDepth = True
			radarArea2.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarArea2.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)

			' set the stack mode
			If StackModeDropDownList.SelectedIndex = 0 Then
				radarArea1.MultiAreaMode = MultiAreaMode.Stacked
				radarArea2.MultiAreaMode = MultiAreaMode.Stacked
			Else
				radarArea1.MultiAreaMode = MultiAreaMode.StackedPercent
				radarArea2.MultiAreaMode = MultiAreaMode.StackedPercent
			End If

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Bright)
			styleSheet.Apply(nChartControl1.Charts(0).Series)

			radarArea0.FillStyle.SetTransparencyPercent(20)
			radarArea1.FillStyle.SetTransparencyPercent(20)
			radarArea2.FillStyle.SetTransparencyPercent(20)

			' apply layout template
			ApplyLayoutTemplate(0, nChartControl1, radarChart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub AddAxis(ByVal radarChart As NRadarChart, ByVal title As String)
			Dim axis As NRadarAxis = New NRadarAxis()

			' set title
			axis.Title = title

			' setup scale
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RulerStyle.BorderStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)
			linearScale.OuterMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)

			If radarChart.Axes.Count = 0 Then
				' if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, True)

				' add interlaced stripe
				Dim strip As NScaleStripStyle = New NScaleStripStyle()
				strip.FillStyle = New NColorFillStyle(Color.FromArgb(64, 200, 200, 200))
				strip.Interlaced = True
				strip.SetShowAtWall(ChartWallType.Radar, True)
				linearScale.StripStyles.Add(strip)
			Else
				' hide labels
				linearScale.AutoLabels = False
			End If

			radarChart.Axes.Add(axis)
		End Sub
	End Class
End Namespace