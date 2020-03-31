Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandardStepLineUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(LineStyleDropDownList, GetType(LineSegmentShape))
				LineStyleDropDownList.SelectedIndex = 0
				RoundToTickCheck.Checked = True
				InflateMarginsCheck.Checked = True
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Step Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)

			' setup the X axis
			Dim scaleX As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount

			' setup the Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.RoundToTickMin = RoundToTickCheck.Checked
			scaleY.RoundToTickMax = RoundToTickCheck.Checked

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			scaleY.StripStyles.Add(stripStyle)

			' hide the Z axis
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup step line series
			Dim stepLine As NStepLineSeries = CType(chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			stepLine.Name = "Series 1"
			stepLine.DepthPercent = 50
			stepLine.LineSize = 2
			stepLine.Legend.Mode = SeriesLegendMode.None
			stepLine.FillStyle = New NColorFillStyle(Color.OliveDrab)
			stepLine.DataLabelStyle.Visible = False
			stepLine.DataLabelStyle.Format = "<value>"
			stepLine.MarkerStyle.Visible = True
			stepLine.InflateMargins = InflateMarginsCheck.Checked

			Dim random As Random = New Random()
			stepLine.Values.FillRandom(random, 8)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			Select Case LineStyleDropDownList.SelectedIndex
				Case 0 ' simple line
					stepLine.LineSegmentShape = LineSegmentShape.Line
					SetupTapeMarkers(stepLine.MarkerStyle)

				Case 1 ' tape
					stepLine.LineSegmentShape = LineSegmentShape.Tape
					SetupTapeMarkers(stepLine.MarkerStyle)

				Case 2 ' tube
					stepLine.LineSegmentShape = LineSegmentShape.Tube
					SetupTubeMarkers(stepLine.MarkerStyle)

				Case 3 ' elipsoid
					stepLine.LineSegmentShape = LineSegmentShape.Ellipsoid
					SetupTubeMarkers(stepLine.MarkerStyle)
			End Select
		End Sub

		Private Sub SetupTapeMarkers(ByVal marker As NMarkerStyle)
			marker.PointShape = PointShape.Cylinder
			marker.AutoDepth = True
			marker.Width = New NLength(1.2f, NRelativeUnit.ParentPercentage)
			marker.Height = New NLength(1.2f, NRelativeUnit.ParentPercentage)
		End Sub

		Private Sub SetupTubeMarkers(ByVal marker As NMarkerStyle)
			marker.PointShape = PointShape.Sphere
			marker.AutoDepth = False
			marker.Width = New NLength(3.5f, NRelativeUnit.ParentPercentage)
			marker.Height = New NLength(3.5f, NRelativeUnit.ParentPercentage)
			marker.Depth = New NLength(3.5f, NRelativeUnit.ParentPercentage)
		End Sub
	End Class
End Namespace
