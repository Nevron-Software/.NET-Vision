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
	Public Partial Class NStandardShapeUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(ShapeStyleDropDownList, GetType(BarShape))
				ShapeStyleDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithColorNames(ShapesColorDropDownList, KnownColor.DarkOrange)

				WebExamplesUtilities.FillComboWithPredefinedProjections(ProjectionDropDownList)
				ProjectionDropDownList.SelectedIndex = CInt(Fix(PredefinedProjection.PerspectiveTilted))
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Shape Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Depth = 50
			chart.Projection.SetPredefinedProjection(CType(ProjectionDropDownList.SelectedIndex, PredefinedProjection))
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Floor }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			scaleY.StripStyles.Add(stripStyle)

			' setup Z axis
			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Left, ChartWallType.Floor }
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' setup shape series
			Dim shape As NShapeSeries = CType(chart.Series.Add(SeriesType.Shape), NShapeSeries)
			shape.Name = "Shape Series"
			shape.DataLabelStyle.Visible = False

			' populate with random data
			shape.Values.FillRandomRange(Random, 10, -100, 100)
			shape.XValues.FillRandomRange(Random, 10, -100, 100)
			shape.ZValues.FillRandomRange(Random, 10, -100, 100)
			shape.YSizes.FillRandomRange(Random, 10, 5, 20)
			shape.XSizes.FillRandomRange(Random, 10, 5, 20)
			shape.ZSizes.FillRandomRange(Random, 10, 5, 20)

			shape.Shape = CType(ShapeStyleDropDownList.SelectedIndex, BarShape)
			shape.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(ShapesColorDropDownList))

			shape.UseXValues = UseXValueCheckBox.Checked
			shape.UseZValues = UseZValueCheckBox.Checked

			If DifferentColorsCheckBox.Checked Then
				ShapesColorDropDownList.Enabled = False

				Dim palette As NChartPalette = New NChartPalette()
				palette.SetPredefinedPalette(ChartPredefinedPalette.Nevron)

				Dim i As Integer = 0
				Do While i < shape.Values.Count
					shape.FillStyles(i) = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))
					i += 1
				Loop
			Else
				ShapesColorDropDownList.Enabled = True
				shape.FillStyles.Clear()
				shape.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(ShapesColorDropDownList))
			End If

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace