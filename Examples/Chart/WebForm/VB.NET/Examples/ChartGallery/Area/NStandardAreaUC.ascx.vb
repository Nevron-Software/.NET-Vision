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
	Public Partial Class NStandardAreaUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithPercents (DepthsPercentDropDownList, 10)
				DepthsPercentDropDownList.SelectedIndex = 4

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1)
				MarkerSizeDropDownList.SelectedIndex = 2

				ShowDataLabelsCheckBox.Checked = False
				UseOriginCheckBox.Checked = True
				ShowMarkersCheckBox.Checked = False
				OriginTextBox.Text = "0"
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.InnerMajorTickStyle.Visible = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			Dim i As Integer = 0
			Do While i < monthLetters.Length
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
				i += 1
			Loop

			' add interlaced stripe for Y axis
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }

			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.StripStyles.Add(stripStyle)

			' setup area series
			Dim area As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area.Name = "Area Series"
			area.DepthPercent = DepthsPercentDropDownList.SelectedIndex * 10
			area.DropLines = DropLinesCheckBox.Checked
			area.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked
			area.DataLabelStyle.Format = "<value>"
			area.MarkerStyle.Visible = ShowMarkersCheckBox.Checked
			area.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			area.MarkerStyle.Height = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			area.MarkerStyle.Width = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)

			area.Values.AddRange(monthValues)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			If UseOriginCheckBox.Checked = True Then
				OriginTextBox.Enabled = True
				area.OriginMode = SeriesOriginMode.CustomOrigin

				Try
					area.Origin = Int32.Parse(OriginTextBox.Text)
				Catch
				End Try
			Else
				OriginTextBox.Enabled = False
				area.OriginMode = SeriesOriginMode.MinValue
			End If

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
