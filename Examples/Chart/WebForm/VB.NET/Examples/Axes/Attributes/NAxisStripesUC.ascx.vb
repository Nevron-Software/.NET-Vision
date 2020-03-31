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
	Public Partial Class NAxisStripesUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(LABeginValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(LAEndValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(BABeginValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(BAEndValueDropDownList, 0, 100, 10)

				WebExamplesUtilities.FillComboWithColorNames(LAColorDropDownList, KnownColor.LightSteelBlue)
				WebExamplesUtilities.FillComboWithColorNames(BAStripeColorDropDownList, KnownColor.LightSteelBlue)

				' init form controls
				LABeginValueDropDownList.SelectedIndex = 2
				LAEndValueDropDownList.SelectedIndex = 6

				BABeginValueDropDownList.SelectedIndex = 2
				BAEndValueDropDownList.SelectedIndex = 6

				LAShowAtBackWallCheckBox.Checked = True
				LAShowAtLeftWallCheckBox.Checked = True
				BAShowAtBackWallCheckBox.Checked = True
				BAShowAtFloorCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Stripes")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Enable3D = True

			' set projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			' configure the chart margins
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(78, NRelativeUnit.ParentPercentage))

			' disable the depth axis
			chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			' Add stripes for the left and the bottom axes
			Dim stripeY As NAxisStripe = chart.Axis(StandardAxis.PrimaryY).Stripes.Add(2, 3)
			Dim stripeX As NAxisStripe = chart.Axis(StandardAxis.PrimaryX).Stripes.Add(2, 3)

			stripeY.From = LABeginValueDropDownList.SelectedIndex * 10
			stripeY.To = LAEndValueDropDownList.SelectedIndex * 10

			stripeY.FillStyle = New NColorFillStyle(Color.FromArgb(125, WebExamplesUtilities.ColorFromDropDownList(LAColorDropDownList)))
			stripeY.SetShowAtWall(ChartWallType.Back, LAShowAtBackWallCheckBox.Checked)
			stripeY.SetShowAtWall(ChartWallType.Left, LAShowAtLeftWallCheckBox.Checked)

			stripeX.From = BABeginValueDropDownList.SelectedIndex * 10
			stripeX.To = BAEndValueDropDownList.SelectedIndex * 10
			stripeX.FillStyle = New NColorFillStyle(Color.FromArgb(125, WebExamplesUtilities.ColorFromDropDownList(BAStripeColorDropDownList)))
			stripeX.SetShowAtWall(ChartWallType.Back, BAShowAtBackWallCheckBox.Checked)
			stripeX.SetShowAtWall(ChartWallType.Floor, BAShowAtFloorCheckBox.Checked)

			' Create a point series
			Dim pnt As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			pnt.InflateMargins = True
			pnt.UseXValues = True
			pnt.Name = "Series 1"
			pnt.DataLabelStyle.Format = "<value>"

			' Add some data
			pnt.Values.Add(31)
			pnt.Values.Add(67)
			pnt.Values.Add(12)
			pnt.Values.Add(84)
			pnt.Values.Add(90)
			pnt.XValues.Add(10)
			pnt.XValues.Add(36)
			pnt.XValues.Add(52)
			pnt.XValues.Add(62)
			pnt.XValues.Add(88)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub
	End Class
End Namespace
