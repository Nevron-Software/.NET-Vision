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
	Public Partial Class NStandardPieUC
		Inherits NExampleUC
		Protected Label5 As Label

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' init form controls
				WebExamplesUtilities.FillComboWithEnumValues(PieStyleDropDownList, GetType(PieStyle))
				PieStyleDropDownList.SelectedIndex = CInt(Fix(PieStyle.Ring))

				PieLabelModeDropDownList.Items.Add("Center")
				PieLabelModeDropDownList.Items.Add("Rim")
				PieLabelModeDropDownList.Items.Add("Spider")
				PieLabelModeDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithValues(ArrowLengthDropDownList, 0, 10, 1)
				ArrowLengthDropDownList.SelectedIndex = 4

				WebExamplesUtilities.FillComboWithValues(ArrowPointerLengthDropDownList, 0, 10, 1)
				ArrowPointerLengthDropDownList.SelectedIndex = 4

				WebExamplesUtilities.FillComboWithValues(DepthDropDownList, 0, 100, 10)
				DepthDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 10)
				BeginAngleDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(TotalAngleDropDownList, 0, 360, 10)
				TotalAngleDropDownList.SelectedIndex = 36

				LightsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Pie Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.FillStyle = New NColorFillStyle(Color.FromArgb(124, 255, 255, 255))
			legend.HorizontalBorderStyle.Width = New NLength(0)
			legend.VerticalBorderStyle.Width = New NLength(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed
			legend.Data.RowCount = 2
			legend.Data.CellMargins = New NMarginsL(New NLength(6, NGraphicsUnit.Pixel), New NLength(3, NGraphicsUnit.Pixel), New NLength(6, NGraphicsUnit.Pixel), New NLength(3, NGraphicsUnit.Pixel))
			legend.Data.MarkSize = New NSizeL(New NLength(7, NGraphicsUnit.Pixel), New NLength(7, NGraphicsUnit.Pixel))


			' by default the control contains a Cartesian chart -> remove it and create a Pie chart
			Dim pieChart As NPieChart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(pieChart)

			pieChart.Enable3D = True
			pieChart.DisplayOnLegend = nChartControl1.Legends(0)
			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
			pieChart.Depth = DepthDropDownList.SelectedIndex * 10
			pieChart.BoundsMode = BoundsMode.Fit
			pieChart.Location = New NPointL(New NLength(12, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			pieChart.Size = New NSizeL(New NLength(76, NRelativeUnit.ParentPercentage), New NLength(68, NRelativeUnit.ParentPercentage))
			pieChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 10
			pieChart.TotalAngle = TotalAngleDropDownList.SelectedIndex * 10
			pieChart.InnerRadius = New NLength(40)

			' setup pie series
			Dim pieSeries As NPieSeries = CType(pieChart.Series.Add(SeriesType.Pie), NPieSeries)
			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints
			pieSeries.Legend.Format = "<label> <percent>"
			pieSeries.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			pieSeries.PieStyle = CType(PieStyleDropDownList.SelectedIndex, PieStyle)
			pieSeries.LabelMode = CType(PieLabelModeDropDownList.SelectedIndex, PieLabelMode)
			pieSeries.DataLabelStyle.ArrowLength = New NLength(CSng(ArrowLengthDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			pieSeries.DataLabelStyle.ArrowPointerLength = New NLength(CSng(ArrowPointerLengthDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)

			pieSeries.AddDataPoint(New NDataPoint(12, "Bikes"))
			pieSeries.AddDataPoint(New NDataPoint(22, "Trains"))
			pieSeries.AddDataPoint(New NDataPoint(19, "Cars"))
			pieSeries.AddDataPoint(New NDataPoint(51, "Planes"))
			pieSeries.AddDataPoint(New NDataPoint(23, "Buses", New NColorFillStyle(Color.Red)))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			Select Case pieSeries.LabelMode
				Case PieLabelMode.Center
					ArrowPointerLengthDropDownList.Enabled = False
					ArrowLengthDropDownList.Enabled = False

				Case PieLabelMode.Rim
					ArrowPointerLengthDropDownList.Enabled = True
					ArrowLengthDropDownList.Enabled = True

				Case PieLabelMode.Spider
					ArrowPointerLengthDropDownList.Enabled = True
					ArrowLengthDropDownList.Enabled = True
			End Select

			If LightsCheckBox.Checked Then
				pieChart.LightModel.EnableLighting = True
				pieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)
			Else
				pieChart.LightModel.EnableLighting = False
			End If
		End Sub
	End Class
End Namespace
