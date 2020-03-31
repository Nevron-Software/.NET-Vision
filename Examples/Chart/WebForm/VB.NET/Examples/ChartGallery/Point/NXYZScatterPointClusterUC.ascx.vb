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
	Public Partial Class NXYZScatterPointClusterUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' init form controls
				WebExamplesUtilities.FillComboWithEnumValues(ClusterModeDropDownList, GetType(ClusterMode))
				ClusterModeDropDownList.SelectedIndex = CInt(Fix(ClusterMode.Enabled))

				For i As Integer = 0 To 8
					ClusterDistanceFactorDropDownList.Items.Add("0.0" & (i + 1).ToString())
				Next i

				WebExamplesUtilities.FillComboWithValues(NumberOfPointGroupsDropDownList, 1, 10, 1)
				NumberOfPointGroupsDropDownList.SelectedIndex = 2

				WebExamplesUtilities.FillComboWithValues(NumberOfPointsInGroupDropDownList, 5000, 15000, 5000)
				NumberOfPointsInGroupDropDownList.SelectedIndex = 0
			End If

			' switch to OpenGL rendering
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Scatter Point Cluster Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 50
			chart.Depth = 50
			chart.Height = 50
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			' setup point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point1"
			point.DataLabelStyle.Visible = False
			point.MarkerStyle.Visible = False
			point.Legend.Mode = SeriesLegendMode.None
			point.PointShape = PointShape.Bar
			point.BorderStyle.Width = New NLength(0)
			point.Size = New NLength(1)
			point.UseXValues = True
			point.UseZValues = True

			' update cluster settings
			point.ClusterMode = CType(ClusterModeDropDownList.SelectedIndex, ClusterMode)
			point.ClusterDistanceFactor = (ClusterDistanceFactorDropDownList.SelectedIndex + 1) * 0.01

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init the chart with some random values
			GenerateXYZData(point)

			NumberOfDataPointsLabel.Text = "Number of Data Points:" & (point.Values.Count / 1000).ToString() & "K"

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub


		Private Sub GenerateXYZData(ByVal point As NPointSeries)
			point.ClearDataPoints()

			Dim numberOfGroups As Integer = NumberOfPointGroupsDropDownList.SelectedIndex + 1
			Dim numberOfPointsInGroup As Integer = (NumberOfPointsInGroupDropDownList.SelectedIndex + 1) * 5000

			Dim i As Integer = 0
			Do While i < numberOfGroups
				AddPointGroup(point, numberOfPointsInGroup)
				i += 1
			Loop

		End Sub

		Private Sub AddPointGroup(ByVal point As NPointSeries, ByVal count As Integer)
			Dim rand As Random = New Random()

			Dim xValues As Double() = New Double(count - 1){}
			Dim yValues As Double() = New Double(count - 1){}
			Dim zValues As Double() = New Double(count - 1){}

			Dim centerX As Double = rand.Next(20)
			Dim centerY As Double = rand.Next(20)
			Dim centerZ As Double = rand.Next(20)

			Dim i As Integer = 0
			Do While i < count
				Dim u1 As Double = rand.NextDouble()
				Dim u2 As Double = rand.NextDouble()
				Dim u3 As Double = rand.NextDouble()

				If u1 = 0 Then
					u1 += 0.0001
				End If

				If u2 = 0 Then
					u2 += 0.0001
				End If

				If u3 = 0 Then
					u3 += 0.0001
				End If

				Dim z0 As Double = centerX + Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2)
				Dim z1 As Double = centerY + Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2)
				Dim z2 As Double = centerZ + Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u3)

				xValues(i) = z0
				yValues(i) = z1
				zValues(i) = z2
				i += 1
			Loop

			point.XValues.AddRange(xValues)
			point.Values.AddRange(yValues)
			point.ZValues.AddRange(zValues)
		End Sub
	End Class
End Namespace
