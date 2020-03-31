Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Collections

Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisLabelsUC
		Inherits NExampleUC

		Private m_Chart As NChart

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(YLabelGenerationModeDropDownList, GetType(LabelGenerationMode))
				WebExamplesUtilities.FillComboWithEnumValues(XLabelGenerationModeDropDownList, GetType(LabelGenerationMode))
				WebExamplesUtilities.FillComboWithValues(XTicksPerLabelDropDownList, 1, 10, 1)
				WebExamplesUtilities.FillComboWithValues(YTicksPerLabelDropDownList, 1, 10, 1)
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Labels")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' remove all legends
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(4, NRelativeUnit.ParentPercentage), New NLength(13, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(82, NRelativeUnit.ParentPercentage))

			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorY.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleConfiguratorY.MaxTickCount = 50

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			scaleConfiguratorY.StripStyles.Add(stripStyle)

			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleConfiguratorX.AutoLabels = False
			scaleConfiguratorX.Labels.Add("France")
			scaleConfiguratorX.Labels.Add("Italy")
			scaleConfiguratorX.Labels.Add("Germany")
			scaleConfiguratorX.Labels.Add("Norway")
			scaleConfiguratorX.Labels.Add("Spain")
			scaleConfiguratorX.Labels.Add("Belgium")
			scaleConfiguratorX.Labels.Add("Greece")
			scaleConfiguratorX.Labels.Add("Austria")
			scaleConfiguratorX.Labels.Add("Sweden")
			scaleConfiguratorX.Labels.Add("Finland")
			scaleConfiguratorX.Labels.Add("Poland")
			scaleConfiguratorX.Labels.Add("Denmark")

			Dim series1 As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			series1.Name = "Product A"
			series1.DataLabelStyle.Visible = False
			GenerateData(series1.Values, 12)

			Dim series2 As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			series2.MultiBarMode = MultiBarMode.Clustered
			series2.Name = "Product B"
			series2.DataLabelStyle.Visible = False

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			GenerateData(series2.Values, 12)
			UpdateScale()
		End Sub

		Private Sub GenerateData(ByVal dataSeries As NDataSeriesDouble, ByVal count As Integer)
			Dim i As Integer = 0
			Do While i < count
				dataSeries.Add(Random.NextDouble() * 59 + 1)
				i += 1
			Loop
		End Sub

		Private Function GetLabelFitModesFromListBox(ByVal listBox As CheckBoxList) As LabelFitMode()
			Dim arrFitModes As ArrayList = New ArrayList()

			Dim i As Integer = 0
			Do While i < listBox.Items.Count
				Dim item As ListItem = listBox.Items(i)

				If item.Selected Then
					arrFitModes.Add(CType(i, LabelFitMode))
				End If
				i += 1
			Loop

			Return CType(arrFitModes.ToArray(GetType(LabelFitMode)), LabelFitMode())
		End Function


		Private Sub UpdateScale()
			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorY.LabelGenerationMode = CType(YLabelGenerationModeDropDownList.SelectedIndex, LabelGenerationMode)
			scaleConfiguratorY.NumberOfTicksPerLabel = Convert.ToInt32(YTicksPerLabelDropDownList.SelectedValue)
			scaleConfiguratorY.LabelFitModes = GetLabelFitModesFromListBox(YLabelFitModesList)

			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorX.LabelGenerationMode = CType(XLabelGenerationModeDropDownList.SelectedIndex, LabelGenerationMode)
			scaleConfiguratorX.NumberOfTicksPerLabel = Convert.ToInt32(XTicksPerLabelDropDownList.SelectedValue)
			scaleConfiguratorX.LabelFitModes = GetLabelFitModesFromListBox(XLabelFitModesList)
		End Sub
	End Class
End Namespace
