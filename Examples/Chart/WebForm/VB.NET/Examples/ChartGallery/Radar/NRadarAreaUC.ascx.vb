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
	Public Partial Class NRadarAreaUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithColorNames(RadarColor1DropDownList, KnownColor.SlateBlue)
				WebExamplesUtilities.FillComboWithColorNames(RadarColor2DropDownList, KnownColor.Crimson)

				ShowMarkersCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Radar Area")
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

			' set some axis labels
			AddAxis(radarChart, "Vitamin A")
			AddAxis(radarChart, "Vitamin B1")
			AddAxis(radarChart, "Vitamin B2")
			AddAxis(radarChart, "Vitamin B6")
			AddAxis(radarChart, "Vitamin B12")
			AddAxis(radarChart, "Vitamin C")
			AddAxis(radarChart, "Vitamin D")
			AddAxis(radarChart, "Vitamin E")

			Dim color1 As Color = WebExamplesUtilities.ColorFromDropDownList(RadarColor1DropDownList)
			Dim color2 As Color = WebExamplesUtilities.ColorFromDropDownList(RadarColor2DropDownList)

			' setup radar series 1
			Dim radarArea1 As NRadarAreaSeries = CType(radarChart.Series.Add(SeriesType.RadarArea), NRadarAreaSeries)
			radarArea1.Name = "Series 1"
			radarArea1.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked
			radarArea1.DataLabelStyle.Format = "<value>"
			radarArea1.BorderStyle.Color = color1
			radarArea1.FillStyle = New NColorFillStyle(Color.FromArgb(125, color1))
			radarArea1.MarkerStyle.Visible = ShowMarkersCheckBox.Checked
			radarArea1.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			radarArea1.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarArea1.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarArea1.MarkerStyle.FillStyle = New NColorFillStyle(color1)
			radarArea1.MarkerStyle.BorderStyle.Color = color1
			radarArea1.Values.FillRandomRange(Random, 8, 0, 100)

			' setup radar series 2
			Dim radarArea2 As NRadarAreaSeries = CType(radarChart.Series.Add(SeriesType.RadarArea), NRadarAreaSeries)
			radarArea2.Name = "Series 2"
			radarArea2.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked
			radarArea2.DataLabelStyle.Format = "<value>"
			radarArea2.BorderStyle.Color = color2
			radarArea2.FillStyle = New NColorFillStyle(Color.FromArgb(125, color2))
			radarArea2.MarkerStyle.Visible = ShowMarkersCheckBox.Checked
			radarArea2.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			radarArea2.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarArea2.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			radarArea2.MarkerStyle.FillStyle = New NColorFillStyle(color2)
			radarArea2.MarkerStyle.BorderStyle.Color = color2
			radarArea2.Values.FillRandomRange(Random, 8, 0, 100)
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