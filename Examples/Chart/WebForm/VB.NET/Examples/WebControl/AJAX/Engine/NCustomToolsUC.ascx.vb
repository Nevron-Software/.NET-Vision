Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomToolsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.AjaxToolsFactoryType = "NCustomToolFactory"

			If nChartControl1.RequiresInitialization Then
				Dim data As NCustomToolsData.NData = NCustomToolsData.Read()

				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Charts.Clear()

				'	display the female population chart
				Dim fChart As NCartesianChart = New NCartesianChart()

				fChart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalRight)
				fChart.Margins = New NMarginsL(9, 0, 0, 0)
				fChart.Location = New NPointL(New NLength(0, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
				fChart.Size = New NSizeL(New NLength(54.21f, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
				nChartControl1.Charts.Add(fChart)

				InitializeChartData(fChart, data.TotalFemaleData, True, Color.Pink)

				Dim axisX As NAxis = fChart.Axis(StandardAxis.PrimaryX)
				Dim scaleX As NLinearScaleConfigurator = TryCast(axisX.ScaleConfigurator, NLinearScaleConfigurator)
				scaleX.CustomLabelsLevelOffset = New NLength(4)

				Dim nRowCount As Integer = data.TotalMaleData.Rows.Count
				Dim i As Integer = 0
				Do While i < nRowCount
					Dim en As NCustomToolsData.NPopulationDataEntry = data.TotalMaleData.Rows(i)
					Dim begin As Double = en.AgeRange.Start
					Dim [end] As Double = en.AgeRange.End + 1
					scaleX.CustomLabels.Add(New NCustomValueLabel((begin + [end]) / 2, en.AgeRange.Title))
					i += 1
				Loop

				'	display the male population chart
				Dim mChart As NCartesianChart = New NCartesianChart()

				mChart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft)
				mChart.Margins = New NMarginsL(0, 0, 9, 0)
				mChart.Location = New NPointL(New NLength(55.5f, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
				mChart.Size = New NSizeL(New NLength(44.8f, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
				nChartControl1.Charts.Add(mChart)

				InitializeChartData(mChart, data.TotalMaleData, False, Color.SkyBlue)
			End If
		End Sub

		Protected Sub nChartControl1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			nChartControl1.AjaxTools.Add(New NAjaxDynamicCursorTool(True))
			nChartControl1.AjaxTools.Add(New NAjaxCustomTool(True))
		End Sub

		#Region "Implementation"

		Private Sub InitializeChartData(ByVal chart As NCartesianChart, ByVal data As NCustomToolsData.NPopulationData, ByVal invert As Boolean, ByVal color As Color)
			chart.BoundsMode = BoundsMode.Stretch

			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			scaleX.Invert = invert
			scaleX.AutoLabels = False
			scaleX.CustomLabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }
			scaleX.MajorTickMode = MajorTickMode.CustomTicks

			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.LabelValueFormatter = New NNumericValueFormatter("0,,M")

			' add the shape chart
			Dim shape1 As NShapeSeries = New NShapeSeries()
			chart.Series.Add(shape1)

			shape1.FillStyle = New NColorFillStyle(color)
			shape1.DataLabelStyle.Visible = False
			shape1.UseXValues = True
			shape1.XSizesUnits = MeasurementUnits.Scale
			shape1.YSizesUnits = MeasurementUnits.Scale

			Dim nRowCount As Integer = data.Rows.Count
			Dim i As Integer = 0
			Do While i < nRowCount
				Dim en As NCustomToolsData.NPopulationDataEntry = data.Rows(i)

				Dim value As Double = en.Value
				Dim begin As Double = en.AgeRange.Start
				Dim [end] As Double = en.AgeRange.End + 1

				shape1.XValues.Add((begin + [end]) / 2)
				shape1.XSizes.Add(Math.Abs(begin - [end]))

				shape1.Values.Add(value / 2)
				shape1.YSizes.Add(value)

				shape1.ZSizes.Add(0)
				shape1.InteractivityStyles.Add(i, New NInteractivityStyle(True, String.Format("{0}:{1}", data.Id, i), Nothing, CursorType.Hand))
				i += 1
			Loop
		End Sub

		#End Region
	End Class

	''' <summary>
	''' Provides configuration for the client side NAjaxCustomTool tool.
	''' </summary>
	<Serializable> _
	Public Class NAjaxCustomTool
		Inherits NAjaxToolDefinition
		#Region "Constructors"

		''' <summary>
		''' Initializes a new instance of NAjaxCustomTool with a given default enabled value.
		''' </summary>
		''' <param name="defaultEnabled">
		''' Selects the initial enabled state of the tool.
		''' </param>
		Public Sub New(ByVal defaultEnabled As Boolean)
			MyBase.New("NCustomTool", defaultEnabled)
		End Sub

		#End Region

		#Region "Overrides"

		''' <summary>
		''' Generates JavaScript that will create a new tool configuration object at the client.
		''' </summary>
		''' <returns>Returns a JavaScript that will create a new tool configuration object at the client.</returns>
		Protected Overrides Function GetConfigurationObjectJavaScript() As String
			Return "new NCustomToolConfig()"
		End Function

		#End Region
	End Class
End Namespace
