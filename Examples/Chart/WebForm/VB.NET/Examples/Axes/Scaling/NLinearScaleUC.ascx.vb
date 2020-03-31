Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Collections

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NLinearScaleUC
		Inherits NExampleUC

		Private m_Chart As NChart
		Private m_Line As NLineSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Linear Scale")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))

			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' configure the y axis
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' add a strip line style
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Values.FillRandomRange(Random, 7, -100, 100)
			m_Line.Legend.Mode = SeriesLegendMode.None
			m_Line.InflateMargins = False
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.PointShape = PointShape.Ellipse
			m_Line.MarkerStyle.Width = New NLength(5, NGraphicsUnit.Point)
			m_Line.MarkerStyle.Height = New NLength(5, NGraphicsUnit.Point)
			m_Line.MarkerStyle.AutoDepth = True
			m_Line.DataLabelStyle.Format = "<value>"

			m_Line.Values.FillRandomRange(Random, 10, 0, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(MaxCountDropDownList, 1, 20, 1)
				MaxCountDropDownList.SelectedIndex = 9
				WebExamplesUtilities.FillComboWithValues(MinDistanceDropDownList, 5, 50, 5)
				MinDistanceDropDownList.SelectedIndex = 2
				WebExamplesUtilities.FillComboWithValues(CustomStepDropDownList, 1, 20, 1)
				CustomStepDropDownList.SelectedIndex = 4
				AutoMinDistanceRadioButton.Checked = True
			End If

			UpdateScale()
		End Sub

		Private Sub UpdateScale()
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			If linearScale Is Nothing Then
				Return
			End If

			linearScale.MaxTickCount = Convert.ToInt32(MaxCountDropDownList.SelectedValue)
			linearScale.MinTickDistance = New NLength(CSng(Convert.ToInt32(MinDistanceDropDownList.SelectedValue)), NGraphicsUnit.Point)
			linearScale.CustomStep = CDbl(Convert.ToInt32(CustomStepDropDownList.SelectedValue))

			' update the custom ticks to match the values of the line series
			Dim values As Double() = New Double(m_Line.Values.Count - 1){}
			m_Line.Values.CopyTo(values, 0)
			linearScale.CustomMajorTicks = New NDoubleList(values)

			linearScale.CustomSteps.Clear()
			linearScale.CustomSteps.Add(10)
			linearScale.CustomSteps.Add(20)

			If AutoMaxCountRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.AutoMaxCount
			ElseIf AutoMinDistanceRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.AutoMinDistance
			ElseIf CustomStepRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.CustomStep
			ElseIf CustomStepsRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.CustomSteps
			ElseIf CustomTicksRadioButton.Checked Then
				linearScale.MajorTickMode = MajorTickMode.CustomTicks
			End If
		End Sub
	End Class
End Namespace
