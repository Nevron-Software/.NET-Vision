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
	Public Partial Class NConstLineLabelsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' disable frame
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Const Line Labels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			Dim chart As NChart = nChartControl1.Charts(0)

			' disable the depth axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' switch the X axis to linear as well
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

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

			' Add a constline for the left axis
			Dim cl1 As NAxisConstLine = chart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
			cl1.Value = 90

			' Add a constline for the bottom axis
			Dim cl2 As NAxisConstLine = chart.Axis(StandardAxis.PrimaryX).ConstLines.Add()
			cl2.Value = 40

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			If (Not IsPostBack) Then
				' init the form controls
				WebExamplesUtilities.FillComboWithValues(LAValueDropDownList, 0, 100, 10)
				LAValueDropDownList.SelectedIndex = CInt(Fix(cl1.Value / 10))
				WebExamplesUtilities.FillComboWithEnumNames(LAContentAlignmentDropDownList, GetType(ContentAlignment))
				LAContentAlignmentDropDownList.SelectedIndex = 0
				LATextTextBox.Text = "Left Axis Line Text"

				WebExamplesUtilities.FillComboWithValues(BAValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithEnumNames(BAContentAlignmentDropDownList, GetType(ContentAlignment))
				BAValueDropDownList.SelectedIndex = CInt(Fix(cl2.Value / 10))
				BAContentAlignmentDropDownList.SelectedIndex = 0
				BATextTextBox.Text = "Bottom Axis Line Text"
			End If

			Dim leftAxisConstLine As NAxisConstLine = chart.Axis(StandardAxis.PrimaryY).ConstLines(0)
			leftAxisConstLine.Value = (LAValueDropDownList.SelectedIndex * 10)
			leftAxisConstLine.TextAlignment = CType(System.Enum.Parse(GetType(ContentAlignment), LAContentAlignmentDropDownList.SelectedItem.Text), ContentAlignment)
			leftAxisConstLine.Text = LATextTextBox.Text

			' bottom axis
			Dim bottomAxisConstline As NAxisConstLine = chart.Axis(StandardAxis.PrimaryX).ConstLines(0)
			bottomAxisConstline.Value = (BAValueDropDownList.SelectedIndex * 10)
			bottomAxisConstline.TextAlignment = CType(System.Enum.Parse(GetType(ContentAlignment), BAContentAlignmentDropDownList.SelectedItem.Text), ContentAlignment)
			bottomAxisConstline.Text = BATextTextBox.Text
		End Sub
	End Class
End Namespace
