Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDateTimeSmoothAreaUC
		Inherits NExampleUC
		Private Const nValuesCount As Integer = 5

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Date/Time Smooth Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			Dim dateTimeScale As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2

			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.StripStyles.Add(stripStyle)

			' add the area series
			Dim area As NSmoothAreaSeries = CType(chart.Series.Add(SeriesType.SmoothArea), NSmoothAreaSeries)
			area.FillStyle = New NColorFillStyle(Color.LightSteelBlue)
			area.BorderStyle.Color = Color.MidnightBlue
			area.DataLabelStyle.Visible = False
			area.MarkerStyle.Visible = True
			area.MarkerStyle.PointShape = PointShape.Cylinder
			area.MarkerStyle.BorderStyle.Color = Color.MidnightBlue
			area.MarkerStyle.AutoDepth = False
			area.MarkerStyle.Width = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			area.MarkerStyle.Height = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			area.MarkerStyle.Depth = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			area.UseXValues = True

			GenreateYValues(nValuesCount)
			GenreateXValues(nValuesCount)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			If (Not Page.IsPostBack) Then
				ShowMarkersCheck.Checked = True
				RoundToTickCheck.Checked = True
				ShowDropLinesCheck.Checked = False

				WebExamplesUtilities.FillComboWithEnumValues(AreaOriginModeCombo, GetType(SeriesOriginMode))
				AreaOriginModeCombo.SelectedIndex = 0
				OriginValueTextBox.Text = "0"
			End If

			area.MarkerStyle.Visible = ShowMarkersCheck.Checked
			area.DropLines = ShowDropLinesCheck.Checked

			area.OriginMode = CType(AreaOriginModeCombo.SelectedIndex, SeriesOriginMode)

			Try
				area.Origin = Double.Parse(OriginValueTextBox.Text)
			Catch
			End Try

			dateTimeScale.RoundToTickMin = RoundToTickCheck.Checked
			dateTimeScale.RoundToTickMax = RoundToTickCheck.Checked

			linearScale.RoundToTickMin = RoundToTickCheck.Checked
			linearScale.RoundToTickMax = RoundToTickCheck.Checked
		End Sub

		Private Sub GenreateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.Values.Clear()

			Dim i As Integer = 0
			Do While i < nCount
				series.Values.Add(5 + Random.NextDouble() * 10)
				i += 1
			Loop
		End Sub

		Private Sub GenreateXValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NXYScatterSeries = CType(chart.Series(0), NXYScatterSeries)

			series.XValues.Clear()

			Dim dt As DateTime = New DateTime(2005, 5, 24, 11, 0, 0)

			Dim i As Integer = 0
			Do While i < nCount
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				series.XValues.Add(dt)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
