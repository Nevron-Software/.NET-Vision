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
	Public Partial Class NAxisStripeLabelsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(LABeginValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(LAEndValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(BABeginValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(BAEndValueDropDownList, 0, 100, 10)

				' init form controls
				LABeginValueDropDownList.SelectedIndex = 2
				LAEndValueDropDownList.SelectedIndex = 6

				BABeginValueDropDownList.SelectedIndex = 2
				BAEndValueDropDownList.SelectedIndex = 6

				' init the form controls
				WebExamplesUtilities.FillComboWithEnumNames(LAContentAlignmentDropDownList, GetType(ContentAlignment))
				LAContentAlignmentDropDownList.SelectedIndex = 0
				LATextTextBox.Text = "Left Axis Line Text"

				WebExamplesUtilities.FillComboWithEnumNames(BAContentAlignmentDropDownList, GetType(ContentAlignment))
				BAContentAlignmentDropDownList.SelectedIndex = 0
				BATextTextBox.Text = "Bottom Axis Line Text"
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Stripe Labels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			Dim chart As NChart = nChartControl1.Charts(0)

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

			stripeY.FillStyle = New NColorFillStyle(Color.FromArgb(50, Color.Blue))
			stripeY.From = LABeginValueDropDownList.SelectedIndex * 10
			stripeY.To = LAEndValueDropDownList.SelectedIndex * 10
			stripeY.SetShowAtWall(ChartWallType.Back, True)
			stripeY.TextAlignment = CType(System.Enum.Parse(GetType(ContentAlignment), LAContentAlignmentDropDownList.SelectedItem.Text), ContentAlignment)
			stripeY.Text = LATextTextBox.Text

			stripeX.FillStyle = New NColorFillStyle(Color.FromArgb(50, Color.Blue))
			stripeX.From = BABeginValueDropDownList.SelectedIndex * 10
			stripeX.To = BAEndValueDropDownList.SelectedIndex * 10
			stripeX.SetShowAtWall(ChartWallType.Back, True)
			stripeX.TextAlignment = CType(System.Enum.Parse(GetType(ContentAlignment), BAContentAlignmentDropDownList.SelectedItem.Text), ContentAlignment)
			stripeX.Text = BATextTextBox.Text

			' Create a point series
			Dim pnt As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			pnt.InflateMargins = True
			pnt.UseXValues = True
			pnt.Name = "Series 1"
			pnt.DataLabelStyle.Visible = False

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

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
