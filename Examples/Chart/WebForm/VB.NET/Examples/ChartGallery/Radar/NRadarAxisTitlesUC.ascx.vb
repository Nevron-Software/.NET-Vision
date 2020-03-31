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
	Public Partial Class NRadarAxisTitlesUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' init example controls
				WebExamplesUtilities.FillComboWithValues(TitleOffsetDropDownList, 0, 50, 5)
				TitleOffsetDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithEnumValues(TitleAngleModeDropDownList, GetType(ScaleLabelAngleMode))
				TitleAngleModeDropDownList.SelectedIndex = CInt(Fix(ScaleLabelAngleMode.View))

				WebExamplesUtilities.FillComboWithValues(TitleAngleDropDownList, 0, 360, 10)
				TitleAngleDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithEnumValues(TitlePositionModeDropDownList, GetType(RadarTitlePositionMode))
				TitlePositionModeDropDownList.SelectedIndex = CInt(Fix(RadarTitlePositionMode.Center))

				WebExamplesUtilities.FillComboWithEnumValues(TitleFitModeDropDownList, GetType(RadarTitleFitMode))
				TitleFitModeDropDownList.SelectedIndex = CInt(Fix(RadarTitleFitMode.Wrap))

				WebExamplesUtilities.FillComboWithValues(TitleMaxWidthDropDownList, 30, 200, 10)
				TitleMaxWidthDropDownList.SelectedIndex = 2
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Radar Axis Titles")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10, 10, 10, 10)

			' hide the legend
			nChartControl1.Legends(0).Visible = False

			' configure the chart
			Dim chart As NRadarChart = New NRadarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)
			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(10, 0, 10, 10)
			chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.DisplayOnLegend = nChartControl1.Legends(0)

			AddAxis(chart, "<b>Vitamin A</b><br/><font size='7pt'>etinol or retinal</font>")
			AddAxis(chart, "<b>Vitamin B1</b><br/><font size='7pt'>thiamin or vitamin B1</font>")
			AddAxis(chart, "<b>Vitamin B12</b><br/><font size='7pt'>also called cobalamin</font>")
			AddAxis(chart, "<b>Vitamin C</b><br/><font size='7pt'>L-ascorbic acid or L-ascorbate</font>")
			AddAxis(chart, "<b>Vitamin D</b><br/><font size='7pt'>group of fat-soluble secosteroids</font>")
			AddAxis(chart, "<b>Vitamin E</b><br/><font size='7pt'>group of eight fat-soluble compounds</font>")

			' create the radar series
			Dim m_RadarArea1 As NRadarAreaSeries = New NRadarAreaSeries()
			chart.Series.Add(m_RadarArea1)
			m_RadarArea1.Name = "Series 1"
			m_RadarArea1.Values.FillRandomRange(Random, 8, 50, 90)
			m_RadarArea1.DataLabelStyle.Visible = False
			m_RadarArea1.DataLabelStyle.Format = "<value>"
			m_RadarArea1.MarkerStyle.AutoDepth = True
			m_RadarArea1.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			m_RadarArea1.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)

			Dim m_RadarArea2 As NRadarAreaSeries = New NRadarAreaSeries()
			chart.Series.Add(m_RadarArea2)
			m_RadarArea2.Name = "Series 2"
			m_RadarArea2.Values.FillRandomRange(Random, 8, 0, 100)
			m_RadarArea2.DataLabelStyle.Visible = False
			m_RadarArea2.DataLabelStyle.Format = "<value>"
			m_RadarArea2.MarkerStyle.AutoDepth = True
			m_RadarArea2.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			m_RadarArea2.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Bright)
			styleSheet.Apply(nChartControl1.Charts(0).Series)

			m_RadarArea1.FillStyle.SetTransparencyPercent(50)
			m_RadarArea2.FillStyle.SetTransparencyPercent(60)

			' update title labels
			Dim mode As ScaleLabelAngleMode = CType(TitleAngleModeDropDownList.SelectedIndex, ScaleLabelAngleMode)
			Dim angle As Single = CSng(TitleAngleDropDownList.SelectedIndex) * 10

			Dim i As Integer = 0
			Do While i < chart.Axes.Count
				Dim axis As NRadarAxis = CType(chart.Axes(i), NRadarAxis)

				axis.TitleAngle = New NScaleLabelAngle(mode, angle)
				axis.TitleOffset = New NLength(CSng(TitleOffsetDropDownList.SelectedIndex) * 5)
				axis.TitlePositionMode = CType(TitlePositionModeDropDownList.SelectedIndex, RadarTitlePositionMode)
				axis.TitleFitMode = CType(TitleFitModeDropDownList.SelectedIndex, RadarTitleFitMode)
				axis.TitleMaxWidth = New NLength(CSng(TitleMaxWidthDropDownList.SelectedIndex) * 10 + 30)
				axis.TitleAutomaticAlignment = TitleAutomaticAlignmentCheck.Checked
				i += 1
			Loop

			TitleMaxWidthDropDownList.Enabled = TitleFitModeDropDownList.SelectedIndex = CInt(Fix(RadarTitleFitMode.Wrap))
		End Sub

		Private Sub AddAxis(ByVal chart As NRadarChart, ByVal title As String)
			Dim axis As NRadarAxis = New NRadarAxis()

			' set title
			axis.Title = title
			axis.TitleTextStyle.TextFormat = TextFormat.XML
			axis.TitleTextStyle.FontStyle.EmSize = New NLength(8)

			' setup scale
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RulerStyle.BorderStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)
			linearScale.OuterMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)

			If chart.Axes.Count = 0 Then
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

			chart.Axes.Add(axis)
		End Sub
	End Class
End Namespace