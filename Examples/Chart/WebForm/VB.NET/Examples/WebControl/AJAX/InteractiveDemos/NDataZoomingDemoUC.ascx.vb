Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web
Imports Nevron.Chart
Imports Nevron.Chart.View
Imports Nevron.Chart.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDataZoomingDemoUC
		Inherits NExampleUC
		'	sample data, imitating the results of a query
		Private Shared waveDataLenth As Integer = 5000
		Private Shared waveDataWave1Factor As Double = 100
		Private Shared waveDataWave1Length As Double = 10

		Private Shared waveDataWave2Factor As Double = 0.9
		Private Shared waveDataWave2Length As Double = 77
		Private Shared waveDataWave2Phase As Double = 10

		Private Shared waveDataWave3Factor As Double = 1.1
		Private Shared waveDataWave3Length As Double = 178
		Private Shared waveDataWave3Phase As Double = 50

		Private Shared waveData As Double()

		'	configuration
		Private Shared defaultDataWindowWidth As Double = 750

		'	initialize the sample data
		Shared Sub New()
			waveData = New Double(waveDataLenth - 1){}
			Dim i As Integer = 0
			Do While i < waveDataLenth
				waveData(i) = Math.Sin(i / waveDataWave1Length) * waveDataWave1Factor
				waveData(i) *= Math.Sin((i - waveDataWave2Phase) / waveDataWave2Length) * waveDataWave2Factor
				waveData(i) *= Math.Sin((i - waveDataWave3Phase) / waveDataWave3Length) * waveDataWave3Factor
				i += 1
			Loop
		End Sub

		'	stores the index of the currently selected bar series data point
		Private Property SelectedDataPointIndex() As Integer
			Get
				If Session("SelectedDataPointIndex") Is Nothing Then
					Return -1
				End If
				Return CInt(Fix(Session("SelectedDataPointIndex")))
			End Get
			Set
				Session("SelectedDataPointIndex") = Value
			End Set
		End Property

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			'	create the full data preview
			CreatePreviewChart()
			'	create the data zoom chart
			CreateZoomChart()
		End Sub

		#Region "Preview Chart"

		Private Class PreviewHttpHandlerCallback
			Inherits NHttpHandlerCallback
			Public Overrides Sub OnAsyncClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				Dim ptViewPoint As NPointF = New NPointF(CSng(args.Point.X), 0)
				UpdateDataWindow(webControlId, context, state, ptViewPoint)
			End Sub

			Public Overrides Sub OnAsyncCustomCommand(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackCustomCommandArgs)
				Select Case args.Command.Name
					Case "setDataWindowWidth"
						Dim ptViewPoint As NPointF = New NPointF(Single.Parse(TryCast(args.Command.Arguments("x"), String)), 0f)
						DataWindowWidth = Double.Parse(TryCast(args.Command.Arguments("width"), String))
						UpdateDataWindow(webControlId, context, state, ptViewPoint)
				End Select
			End Sub

			Private Sub UpdateDataWindow(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal ptViewPoint As NPointF)
				Dim chartState As NChartSessionStateObject = TryCast(state, NChartSessionStateObject)
				Dim rootPanel As NRootPanel = chartState.Document.RootPanel
				Dim chart As NCartesianChart = TryCast(rootPanel.Charts(0), NCartesianChart)
				Dim vecScalePoint As NVector2DD = New NVector2DD()
				Dim xAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
				Dim yAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)

				Using view As NChartRasterView = New NChartRasterView(chartState.Document, chartState.Size, NResolution.ScreenResolution)
					view.RecalcLayout()

					Dim viewToScale As NViewToScale2DTransformation = New NViewToScale2DTransformation(view.Context, chart, CInt(Fix(StandardAxis.PrimaryX)), CInt(Fix(StandardAxis.PrimaryY)))

					If viewToScale.Transform(ptViewPoint, vecScalePoint) Then
						Dim rangeMin As Double = vecScalePoint.X - DataWindowWidth / 2
						rangeMin = xAxis.Scale.ViewRange.GetValueInRange(rangeMin)

						Dim rangeMax As Double = rangeMin + DataWindowWidth
						rangeMax = xAxis.Scale.ViewRange.GetValueInRange(rangeMax)

						rangeMin = rangeMax - DataWindowWidth

						Dim selection As NRangeSelection = TryCast(chart.RangeSelections(0), NRangeSelection)
						selection.HorizontalAxisRange = New NRange1DD(rangeMin, rangeMax)
						selection.VerticalAxisRange = New NRange1DD(-waveDataWave1Factor, waveDataWave1Factor)
					End If
				End Using
			End Sub

			Private Property DataWindowWidth() As Double
				Get
					If HttpContext.Current.Session("DataWindowWidth") Is Nothing Then
						Return defaultDataWindowWidth
					End If
					Return CDbl(HttpContext.Current.Session("DataWindowWidth"))
				End Get
				Set
					HttpContext.Current.Session("DataWindowWidth") = Value
				End Set
			End Property
		End Class

		Private Sub CreatePreviewChart()
			nChartControl1.HttpHandlerCallback = New PreviewHttpHandlerCallback()

			If nChartControl1.RequiresInitialization Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Legends.Clear()

				' set a chart title
				Dim header As NLabel = nChartControl1.Labels.AddHeader("Wave Preview")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.ContentAlignment = ContentAlignment.BottomRight
				header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

				' setup a Smooth Line chart
				Dim chart As NCartesianChart = TryCast(nChartControl1.Charts(0), NCartesianChart)
				chart.BoundsMode = BoundsMode.Stretch
				chart.Location = New NPointL(New NLength(4, NRelativeUnit.ParentPercentage), New NLength(25, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(88, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

				' setup X axis
				Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

				' setup Y axis
				Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				scaleY.InnerMajorTickStyle.Visible = False

				' add interlace stripe to the Y axis
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(&Hfe, &Hed, &He2)), Nothing, True, 0, 0, 1, 1)
				stripStyle.Interlaced = True
				stripStyle.SetShowAtWall(ChartWallType.Back, True)
				stripStyle.SetShowAtWall(ChartWallType.Left, True)
				scaleY.StripStyles.Add(stripStyle)

				' add the line
				Dim line As NSmoothLineSeries = CType(chart.Series.Add(SeriesType.SmoothLine), NSmoothLineSeries)
				line.Name = "Wave"
				line.Legend.Mode = SeriesLegendMode.None
				line.UseXValues = False
				line.UseZValues = False
				line.InflateMargins = True
				line.DataLabelStyle.Visible = False
				line.MarkerStyle.Visible = False
				line.BorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)

				' initialize data points
				Dim i As Integer = 0
				Do While i < waveDataLenth
					line.Values.Add(waveData(i))
					i += 1
				Loop

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)

				' select a default window
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
				Dim selectionBorderColor As Color = palette.SeriesColors(2)
				Dim selectionFillColor As Color = Color.FromArgb(64, palette.SeriesColors(1))

				Dim selection As NRangeSelection = New NRangeSelection(CInt(Fix(StandardAxis.PrimaryX)), CInt(Fix(StandardAxis.PrimaryY)))
				selection.BorderStyle = New NStrokeStyle(1, selectionBorderColor)
				selection.FillStyle = New NColorFillStyle(selectionFillColor)
				selection.HorizontalAxisRange = New NRange1DD(0, defaultDataWindowWidth)
				selection.VerticalAxisRange = New NRange1DD(-waveDataWave1Factor, waveDataWave1Factor)
				selection.Visible = True
				chart.RangeSelections.Add(selection)
			End If
		End Sub

		Protected Sub nChartControl1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
		End Sub

		#End Region

		#Region "Zoom Chart"

		Private Sub CreateZoomChart()
			If nChartControl2.RequiresInitialization Then
				'	reset the data window width
				HttpContext.Current.Session("DataWindowWidth") = defaultDataWindowWidth

				' set up the chart control
				nChartControl2.BackgroundStyle.FrameStyle.Visible = False
				nChartControl2.Legends.Clear()

				' set a chart title
				Dim header As NLabel = nChartControl2.Labels.AddHeader("Wave Details")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.ContentAlignment = ContentAlignment.BottomRight
				header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

				' setup a Smooth Line chart
				Dim chart As NCartesianChart = TryCast(nChartControl2.Charts(0), NCartesianChart)
				chart.BoundsMode = BoundsMode.Stretch
				chart.Location = New NPointL(New NLength(4, NRelativeUnit.ParentPercentage), New NLength(25, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(88, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

				' setup X axis
				Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
				scaleX.RoundToTickMin = False
				scaleX.RoundToTickMax = False

				' setup Y axis
				Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				scaleY.InnerMajorTickStyle.Visible = False

				' add interlace stripe to the Y axis
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(&Hfe, &Hed, &He2)), Nothing, True, 0, 0, 1, 1)
				stripStyle.Interlaced = True
				stripStyle.SetShowAtWall(ChartWallType.Back, True)
				stripStyle.SetShowAtWall(ChartWallType.Left, True)
				scaleY.StripStyles.Add(stripStyle)

				' add the line
				Dim line As NSmoothLineSeries = CType(chart.Series.Add(SeriesType.SmoothLine), NSmoothLineSeries)
				line.Name = "Wave"
				line.Legend.Mode = SeriesLegendMode.None
				line.UseXValues = True
				line.InflateMargins = True
				line.DataLabelStyle.Visible = False
				line.MarkerStyle.Visible = False
				line.BorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)

				' initialize data points
				Dim i As Integer = 0
				Do While i < defaultDataWindowWidth
					line.XValues.Add(i)
					line.Values.Add(waveData(i))
					i += 1
				Loop

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl2.Document)
			End If
		End Sub

		Protected Sub nChartControl2_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Select Case args.Command.Name
				Case "displayDataWindow"
					Dim dataWindowWidth As Double = Double.Parse(TryCast(args.Command.Arguments("width"), String))

					Dim zoomChart As NCartesianChart = TryCast(nChartControl2.Charts(0), NCartesianChart)
					Dim zoomLine As NSmoothLineSeries = TryCast(zoomChart.Series(0), NSmoothLineSeries)

					Dim previewChart As NCartesianChart = TryCast(nChartControl1.Charts(0), NCartesianChart)
					Dim previewXAxis As NAxis = previewChart.Axis(StandardAxis.PrimaryX)

					Dim ptViewPoint As NPointF = New NPointF(Single.Parse(TryCast(args.Command.Arguments("x"), String)), 0)
					Dim vecScalePoint As NVector2DD = New NVector2DD()

					Using view As NChartRasterView = New NChartRasterView(nChartControl1.Document, nChartControl1.Dimensions, NResolution.ScreenResolution)
						view.RecalcLayout()

						Dim viewToScale As NViewToScale2DTransformation = New NViewToScale2DTransformation(view.Context, previewChart, CInt(Fix(StandardAxis.PrimaryX)), CInt(Fix(StandardAxis.PrimaryY)))

						If viewToScale.Transform(ptViewPoint, vecScalePoint) Then
							Dim rangeMin As Double = vecScalePoint.X - dataWindowWidth / 2
							rangeMin = previewXAxis.Scale.ViewRange.GetValueInRange(rangeMin)

							Dim rangeMax As Double = rangeMin + dataWindowWidth
							rangeMax = previewXAxis.Scale.ViewRange.GetValueInRange(rangeMax)

							rangeMin = rangeMax - dataWindowWidth

							' reinitialize data points
							zoomLine.XValues.Clear()
							zoomLine.Values.Clear()
							Dim i As Integer = CInt(Fix(rangeMin))
							Do While i <= CInt(Fix(rangeMax))
								zoomLine.XValues.Add(i)
								zoomLine.Values.Add(waveData(i))
								i += 1
							Loop
						End If
					End Using
			End Select
		End Sub

		Protected Sub nChartControl2_AsyncQueryCommandResult(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackQueryCommandResultArgs = TryCast(e, NCallbackQueryCommandResultArgs)
			Select Case args.Command.Name
				Case "displayDataWindow"
					If (Not args.ResultBuilder.ContainsRedrawDataSection()) Then
						args.ResultBuilder.AddRedrawDataSection(nChartControl2)
					End If
			End Select
		End Sub

		#End Region
	End Class
End Namespace
