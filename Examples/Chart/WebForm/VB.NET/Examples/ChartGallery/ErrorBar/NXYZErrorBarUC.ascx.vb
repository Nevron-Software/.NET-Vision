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
	Public Partial Class NXYZErrorBarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Error Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Depth = 55.0f
			chart.Width = 55.0f
			chart.Height = 55.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.RoundToTickMin = RoundToTickCheck.Checked
			linearScaleConfigurator.RoundToTickMax = RoundToTickCheck.Checked
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.RoundToTickMin = RoundToTickCheck.Checked
			linearScaleConfigurator.RoundToTickMax = RoundToTickCheck.Checked
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.RoundToTickMin = RoundToTickCheck.Checked
			linearScaleConfigurator.RoundToTickMax = RoundToTickCheck.Checked
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			' add an error bar series
			Dim series As NErrorBarSeries = CType(chart.Series.Add(SeriesType.ErrorBar), NErrorBarSeries)
			series.DataLabelStyle.Visible = False
			series.BorderStyle = New NStrokeStyle(GreyBlue)
			series.MarkerStyle.Visible = True
			series.MarkerStyle.AutoDepth = False
			series.MarkerStyle.FillStyle = New NColorFillStyle(DarkOrange)
			series.MarkerStyle.BorderStyle = New NStrokeStyle(GreyBlue)
			series.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			series.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			series.MarkerStyle.Depth = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			series.UseXValues = True
			series.UseZValues = True

			GenerateData(series)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			If (Not IsPostBack) Then
				ShowUpperXErrorCheck.Checked = series.ShowUpperErrorX
				ShowLowerXErrorCheck.Checked = series.ShowLowerErrorX
				ShowUpperYErrorCheck.Checked = series.ShowUpperErrorY
				ShowLowerYErrorCheck.Checked = series.ShowLowerErrorY
				ShowUpperZErrorCheck.Checked = series.ShowUpperErrorZ
				ShowLowerZErrorCheck.Checked = series.ShowLowerErrorZ
				InflateMarginsCheck.Checked = series.InflateMargins
			Else
				series.ShowUpperErrorX = ShowUpperXErrorCheck.Checked
				series.ShowLowerErrorX = ShowLowerXErrorCheck.Checked
				series.ShowUpperErrorY = ShowUpperYErrorCheck.Checked
				series.ShowLowerErrorY = ShowLowerYErrorCheck.Checked
				series.ShowUpperErrorZ = ShowUpperZErrorCheck.Checked
				series.ShowLowerErrorZ = ShowLowerZErrorCheck.Checked
				series.InflateMargins = InflateMarginsCheck.Checked
			End If
		End Sub

		Private Sub GenerateData(ByVal series As NErrorBarSeries)
			series.ClearDataPoints()

			Dim v As NVector3DF = New NVector3DF()
			Dim randrom As Random = New Random()

			For i As Integer = 0 To 9
				v.X = CSng(0.5 - randrom.NextDouble())
				v.Y = CSng(0.5 - randrom.NextDouble())
				v.Z = CSng(0.5 - randrom.NextDouble())

				v.Normalize(40.0f)

				series.Values.Add(v.X)
				series.XValues.Add(v.Y)
				series.ZValues.Add(v.Z)

				series.LowerErrorsX.Add(3 + 5 * randrom.NextDouble())
				series.UpperErrorsX.Add(3 + 5 * randrom.NextDouble())
				series.LowerErrorsY.Add(3 + 5 * randrom.NextDouble())
				series.UpperErrorsY.Add(3 + 5 * randrom.NextDouble())
				series.LowerErrorsZ.Add(3 + 5 * randrom.NextDouble())
				series.UpperErrorsZ.Add(3 + 5 * randrom.NextDouble())
			Next i
		End Sub
	End Class
End Namespace
