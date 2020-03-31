Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisLabelsOrientationUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' init form controls
			If (Not IsPostBack) Then
				AngleModeDropDownList.Items.Add("View")
				AngleModeDropDownList.Items.Add("Scale")
				AngleModeDropDownList.SelectedIndex = 1

				AllowFlipCheckBox.Checked = False
				FitAxisContentInBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Axis Labels Orientation")
			nChartControl1.Panels.Add(header)
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.Margins = New NMarginsL(10, 10, 10, 4)
			header.DockMode = PanelDockMode.Top

			' setup the chart
			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)
			chart.Enable3D = True
			chart.Fit3DAxisContent = FitAxisContentInBox.Checked
			chart.DockMode = PanelDockMode.Fill
			chart.BorderStyle = New NStrokeBorderStyle(BorderShape.RoundedRect)
			chart.BackgroundFillStyle = New NGradientFillStyle(Color.White, Color.LightGray)
			chart.Margins = New NMarginsL(10, 0, 10, 10)
			chart.Padding = New NMarginsL(2, 2, 2, 2)

			' set predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			chart.Depth = 50
			chart.Width = 50
			chart.Height = 50
			chart.BoundsMode = BoundsMode.Fit

			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' add interlaced stripe
			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			scaleConfiguratorY.StripStyles.Add(stripStyle)

			' add series
			Dim seriesColors As Color() = New Color() { Color.Crimson, Color.Orange, Color.OliveDrab }
			Dim dataItemsCount As Integer = 6
			Dim i As Integer = 0
			Do While i < seriesColors.Length
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)

				bar.BarShape = BarShape.SmoothEdgeBar
				bar.FillStyle = New NColorFillStyle(seriesColors(i))
				bar.Name = "Series " & i.ToString()
				bar.Values.FillRandomRange(Random, dataItemsCount, 10, 30)
				bar.InflateMargins = True
				bar.DataLabelStyle.Visible = False
				i += 1
			Loop

			' configure the x axis labels (categories)
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.Title.Text = "Categories Title"
			ordinalScale.MajorTickMode = MajorTickMode.CustomStep
			ordinalScale.LabelFitModes = New LabelFitMode() { LabelFitMode.Stagger2, LabelFitMode.AutoScale }

			i = 0
			Do While i < dataItemsCount
				ordinalScale.Labels.Add("S" & i.ToString())
				i += 1
			Loop

			' configure the depth axis labels (series)
			ordinalScale = TryCast(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.Title.Text = "Series Title"
			ordinalScale.MajorTickMode = MajorTickMode.CustomStep
			ordinalScale.Labels.Add("S1")
			ordinalScale.Labels.Add("S2")
			ordinalScale.Labels.Add("S3")
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.LabelFitModes = New LabelFitMode() { LabelFitMode.Stagger2, LabelFitMode.AutoScale }

			' set title to Y axis
			Dim numericScale As NNumericScaleConfigurator = TryCast(chart.Axis(CInt(Fix(StandardAxis.PrimaryY))).ScaleConfigurator, NNumericScaleConfigurator)
			numericScale.Title.Text = "Values"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' read the form control values
			Dim customAngle As Single
			If (Not Single.TryParse(CustomAngleTextBox.Text, customAngle)) OrElse customAngle < 0 OrElse customAngle > 360 Then
				customAngle = 0f
				CustomAngleTextBox.Text = customAngle.ToString()
			End If

			' update scale labels angle
			Dim count As Integer =chart.Axes.Count

			Dim angle As NScaleLabelAngle = New NScaleLabelAngle(CType(System.Enum.Parse(GetType(ScaleLabelAngleMode), AngleModeDropDownList.SelectedItem.Value), ScaleLabelAngleMode), customAngle, AllowFlipCheckBox.Checked)

			' update the x axis
			Dim axis As NAxis = CType(chart.Axes(CInt(Fix(StandardAxis.PrimaryX))), NAxis)
			Dim scale As NStandardScaleConfigurator = TryCast(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale.LabelStyle.Angle = angle

			' update the depth axis
			axis = CType(chart.Axes(CInt(Fix(StandardAxis.Depth))), NAxis)
			scale = TryCast(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale.LabelStyle.Angle = angle
		End Sub
	End Class
End Namespace
