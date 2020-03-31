Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAppearanceUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				FillModeDropDownList.Items.Add("Uniform")
				FillModeDropDownList.Items.Add("Individual")
				FillModeDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithColorNames(BarColorDropDownList, KnownColor.DarkOrange)

				WebExamplesUtilities.FillComboWithValues(CycleCountDropDownList, 2, 6, 1)
				CycleCountDropDownList.SelectedIndex = 4

				WebExamplesUtilities.FillComboWithValues(BarCountDropDownList, 3, 20, 1)
				BarCountDropDownList.SelectedIndex = 3
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Series Appearance")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.DataLabelStyle.Visible = False
			bar.Values.FillRandom(Random, BarCountDropDownList.SelectedIndex + 3)

			Select Case FillModeDropDownList.SelectedIndex
				Case 0 ' Uniform
					BarColorDropDownList.Enabled = True
					CycleCountDropDownList.Enabled = False

					bar.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(BarColorDropDownList))

				Case 1 ' Individual
					BarColorDropDownList.Enabled = False
					CycleCountDropDownList.Enabled = True

					bar.FillStyles.Clear()

					Dim palette As NChartPalette = New NChartPalette()
					palette.SetPredefinedPalette(ChartPredefinedPalette.Nevron)

					Dim cycleCount As Integer = CycleCountDropDownList.SelectedIndex + 1
					Dim currentColor As Integer = 0

					Dim i As Integer = 0
					Do While i < bar.Values.Count
						bar.FillStyles(i) = New NColorFillStyle(palette.SeriesColors(currentColor))
						currentColor += 1

						If currentColor > cycleCount Then
							currentColor = 0
						End If
						i += 1
					Loop
			End Select

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
