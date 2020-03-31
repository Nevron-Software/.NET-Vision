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
	Public Partial Class NAxisGridlinesUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Gridlines")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' disable the depth axis
			chart.Axis(StandardAxis.Depth).Visible = False

			Dim leftAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(leftAxis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MinorTickCount = 3

			Dim pnt As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			pnt.InflateMargins = True
			pnt.DataLabelStyle.Visible = False
			pnt.Values.FillRandom(Random, 5)
			pnt.Legend.Mode = SeriesLegendMode.None

			If (Not IsPostBack) Then
				MajorGridLineStyleDropDown.Items.Add("Solid")
				MajorGridLineStyleDropDown.Items.Add("Dot")
				MajorGridLineStyleDropDown.Items.Add("Dash")
				MajorGridLineStyleDropDown.Items.Add("Dash-Dot")
				MajorGridLineStyleDropDown.Items.Add("Dash-Dot-Dot")
				MajorGridLineStyleDropDown.SelectedIndex = 0

				MinorGridLineStyleDropDown.Items.Add("Solid")
				MinorGridLineStyleDropDown.Items.Add("Dot")
				MinorGridLineStyleDropDown.Items.Add("Dash")
				MinorGridLineStyleDropDown.Items.Add("Dash-Dot")
				MinorGridLineStyleDropDown.Items.Add("Dash-Dot-Dot")
				MinorGridLineStyleDropDown.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithColorNames(MajorGridLineColorDropDown, KnownColor.Black)
				WebExamplesUtilities.FillComboWithColorNames(MinorGridLineColorDropDown, KnownColor.Blue)

				MajorGridLineAtLeftWallCheckBox.Checked = linearScaleConfigurator.MajorGridStyle.GetShowAtWall(ChartWallType.Left)
				MajorGridLineAtBackWallCheckBox.Checked = linearScaleConfigurator.MajorGridStyle.GetShowAtWall(ChartWallType.Back)
				MinorGridLineAtLeftWallCheckBox.Checked = linearScaleConfigurator.MinorGridStyle.GetShowAtWall(ChartWallType.Left)
				MinorGridLineAtLeftWallCheckBox.Checked = linearScaleConfigurator.MinorGridStyle.GetShowAtWall(ChartWallType.Back)

				MajorGridLineAtLeftWallCheckBox.Checked = True
				MajorGridLineAtBackWallCheckBox.Checked = True
				MinorGridLineAtLeftWallCheckBox.Checked = True
				MinorGridLineAtBackwallCheckBox.Checked = True
			End If

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' configure Y chart axis 
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			linearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)

			linearScaleConfigurator.MajorGridStyle.LineStyle.Color = WebExamplesUtilities.ColorFromDropDownList(MajorGridLineColorDropDown)
			linearScaleConfigurator.MinorGridStyle.LineStyle.Color = WebExamplesUtilities.ColorFromDropDownList(MinorGridLineColorDropDown)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = GetPatternFromIndex(MajorGridLineStyleDropDown.SelectedIndex)
			linearScaleConfigurator.MinorGridStyle.LineStyle.Pattern = GetPatternFromIndex(MinorGridLineStyleDropDown.SelectedIndex)

			' set gridlines
			linearScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, MajorGridLineAtLeftWallCheckBox.Checked)
			linearScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, MajorGridLineAtBackWallCheckBox.Checked)
			linearScaleConfigurator.MinorGridStyle.SetShowAtWall(ChartWallType.Left, MinorGridLineAtLeftWallCheckBox.Checked)
			linearScaleConfigurator.MinorGridStyle.SetShowAtWall(ChartWallType.Back, MinorGridLineAtBackwallCheckBox.Checked)
		End Sub

		Private Function GetPatternFromIndex(ByVal index As Integer) As LinePattern
			Select Case index
				Case 0
					Return LinePattern.Solid
				Case 1
					Return LinePattern.Dot
				Case 2
					Return LinePattern.Dash
				Case 3
					Return LinePattern.DashDot
				Case 4
					Return LinePattern.DashDotDot
				Case Else
					Return LinePattern.Solid
			End Select
		End Function
	End Class
End Namespace
