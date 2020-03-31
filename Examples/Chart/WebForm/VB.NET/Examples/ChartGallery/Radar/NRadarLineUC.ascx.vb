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
	Public Partial Class NRadarLineUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithColorNames(RadarAreaColor1DropDownList, KnownColor.Brown)
				WebExamplesUtilities.FillComboWithColorNames(RadarAreaColor2DropDownList, KnownColor.DarkOrange)

				ShowMarkersCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Radar Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create and configure a radar chart
			Dim radarChart As NRadarChart = New NRadarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(radarChart)
			radarChart.BoundsMode = BoundsMode.Fit
			radarChart.Location = New NPointL(New NLength(0, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
			radarChart.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			radarChart.Padding = New NMarginsL(7, 7, 7, 7)
			radarChart.InnerRadius = New NLength(15)

			' set some axis labels
			AddAxis(radarChart, "Vitamin A")
			AddAxis(radarChart, "Vitamin B1")
			AddAxis(radarChart, "Vitamin B2")
			AddAxis(radarChart, "Vitamin B6")
			AddAxis(radarChart, "Vitamin B12")
			AddAxis(radarChart, "Vitamin C")
			AddAxis(radarChart, "Vitamin D")
			AddAxis(radarChart, "Vitamin E")

			Dim color1 As Color = WebExamplesUtilities.ColorFromDropDownList(RadarAreaColor1DropDownList)
			Dim color2 As Color = WebExamplesUtilities.ColorFromDropDownList(RadarAreaColor2DropDownList)

			' create the radar series
			Dim radarLine1 As NRadarLineSeries = CType(radarChart.Series.Add(SeriesType.RadarLine), NRadarLineSeries)
			radarLine1.Name = "Series 1"
			radarLine1.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked
			radarLine1.DataLabelStyle.Format = "<value>"
			radarLine1.BorderStyle.Color = color1
			radarLine1.MarkerStyle.Visible = ShowMarkersCheckBox.Checked
			radarLine1.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			radarLine1.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarLine1.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarLine1.MarkerStyle.FillStyle = New NColorFillStyle(color1)
			radarLine1.MarkerStyle.BorderStyle.Color = color1
			radarLine1.Values.FillRandomRange(Random, 8, 0, 100)

			Dim radarLine2 As NRadarLineSeries = CType(radarChart.Series.Add(SeriesType.RadarLine), NRadarLineSeries)
			radarLine2.Name = "Series 2"
			radarLine2.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked
			radarLine2.DataLabelStyle.Format = "<value>"
			radarLine2.BorderStyle.Color = color2
			radarLine2.MarkerStyle.Visible = ShowMarkersCheckBox.Checked
			radarLine2.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			radarLine2.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarLine2.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarLine2.MarkerStyle.FillStyle = New NColorFillStyle(color2)
			radarLine2.MarkerStyle.BorderStyle.Color = color2
			radarLine2.Values.FillRandomRange(Random, 8, 0, 100)
		End Sub

		Private Sub AddAxis(ByVal radarChart As NRadarChart, ByVal title As String)
			Dim axis As NRadarAxis = New NRadarAxis()

			' set title
			axis.Title = title
			axis.TitleAngle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 0)

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

			Else
				' hide labels
				linearScale.AutoLabels = False
			End If

			radarChart.Axes.Add(axis)
		End Sub

	End Class
End Namespace
