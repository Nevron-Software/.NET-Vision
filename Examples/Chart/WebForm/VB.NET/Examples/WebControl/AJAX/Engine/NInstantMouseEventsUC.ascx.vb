Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NInstantMouseEventsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.HttpHandlerCallback = New CustomHttpHandlerCallback()

			If nChartControl1.RequiresInitialization Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False

				' set a chart title
				Dim header As NLabel = nChartControl1.Labels.AddHeader("Mouse Events")
				header.TextStyle.FontStyle = New NFontStyle("Palatino Linotype", 14, FontStyle.Italic)
				header.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.ContentAlignment = ContentAlignment.BottomRight
				header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

				' clear the legends
				nChartControl1.Legends.Clear()

				' configure stack bar chart
				Dim chart1 As NChart = nChartControl1.Charts(0)
				chart1.Tag = "BarChart"
				chart1.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
				chart1.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
				chart1.BoundsMode = BoundsMode.Fit
				chart1.Axis(StandardAxis.Depth).Visible = False

				' add the first bar
				Dim bar1 As NBarSeries = CType(chart1.Series.Add(SeriesType.Bar), NBarSeries)
				bar1.Name = "Cars"
				bar1.MultiBarMode = MultiBarMode.Series
				bar1.DataLabelStyle.Visible = False

				' add the second bar
				Dim bar2 As NBarSeries = CType(chart1.Series.Add(SeriesType.Bar), NBarSeries)
				bar2.Name = "Airplanes"
				bar2.MultiBarMode = MultiBarMode.Stacked
				bar2.DataLabelStyle.Visible = False

				' add the third bar
				Dim bar3 As NBarSeries = CType(chart1.Series.Add(SeriesType.Bar), NBarSeries)
				bar3.Name = "Trains"
				bar3.MultiBarMode = MultiBarMode.Stacked
				bar3.DataLabelStyle.Visible = False

				' add the fourth bar
				Dim bar4 As NBarSeries = CType(chart1.Series.Add(SeriesType.Bar), NBarSeries)
				bar4.Name = "Buses"
				bar4.MultiBarMode = MultiBarMode.Stacked
				bar4.DataLabelStyle.Visible = False

				' change the color of the second and third bars
				bar1.Values.FillRandomRange(Random, 5, 20, 100)
				bar2.Values.FillRandomRange(Random, 5, 20, 100)
				bar3.Values.FillRandomRange(Random, 5, 20, 100)
				bar4.Values.FillRandomRange(Random, 5, 20, 100)

				' add a pie chart
				Dim chart2 As NChart = New NPieChart()
				nChartControl1.Charts.Add(chart2)

				chart2.Tag = "PieChart"
				chart2.Location = New NPointL(New NLength(55, NRelativeUnit.ParentPercentage), New NLength(8, NRelativeUnit.ParentPercentage))
				chart2.Size = New NSizeL(New NLength(45, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
				chart2.BoundsMode = BoundsMode.Fit
				chart2.Projection.Zoom = 80

				Dim pie As NPieSeries = CType(chart2.Series.Add(SeriesType.Pie), NPieSeries)
				pie.DataLabelStyle.Visible = False

				pie.AddDataPoint(New NDataPoint(12))
				pie.AddDataPoint(New NDataPoint(42))
				pie.AddDataPoint(New NDataPoint(56))
				pie.AddDataPoint(New NDataPoint(23))

				' apply style sheet
				Dim styleSheet1 As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet1.Apply(chart1)

				Dim styleSheet2 As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet2.Apply(chart2)
			End If
		End Sub

		Protected Sub nChartControl1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			nChartControl1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(False))
			nChartControl1.AjaxTools.Add(New NAjaxMouseDoubleClickCallbackTool(False))
			nChartControl1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
			nChartControl1.AjaxTools.Add(New NAjaxMouseDownCallbackTool(False))
			nChartControl1.AjaxTools.Add(New NAjaxMouseUpCallbackTool(False))
		End Sub

		Protected Sub simulatePostbackButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			'	select the default enabled state of the mouse tools
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseClickCallbackTool)).DefaultEnabled = (Not Request("mouseClickCheckbox") Is Nothing)
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseDoubleClickCallbackTool)).DefaultEnabled = (Not Request("mouseDoubleClickCheckbox") Is Nothing)
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Not Request("mouseMoveCheckbox") Is Nothing)
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseDownCallbackTool)).DefaultEnabled = (Not Request("mouseDownCheckbox") Is Nothing)
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseUpCallbackTool)).DefaultEnabled = (Not Request("mouseUpCheckbox") Is Nothing)

			'	select the default enabled state of client side services
			nChartControl1.AsyncRequestWaitCursorEnabled = (Not Request("waitCursorCheckbox") Is Nothing)

			simulatePostbackLabel.Text = "Postback simulated!"
		End Sub

		#Region "Nested Classes"

		<Serializable> _
		Public Class CustomHttpHandlerCallback
			Inherits NHttpHandlerCallback
			#Region "INHttpHandlerCallback Members"

			Public Overrides Sub OnAsyncClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
				ProcessMouseEvent(state, args, palette.GaugeBackgroundForeColor)
			End Sub

			Public Overrides Sub OnAsyncDoubleClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
				ProcessMouseEvent(state, args, palette.GaugeBackgroundForeColor)
			End Sub

			Public Overrides Sub OnAsyncMouseDown(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
				ProcessMouseEvent(state, args, palette.GaugeBackgroundForeColor)
			End Sub

			Public Overrides Sub OnAsyncMouseMove(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
				ProcessMouseEvent(state, args, palette.GaugeBackgroundForeColor)
			End Sub

			Public Overrides Sub OnAsyncMouseUp(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
				ProcessMouseEvent(state, args, palette.GaugeBackgroundForeColor)
			End Sub

			#End Region

			#Region "Implementation"

			Private Sub ProcessMouseEvent(ByVal state As NStateObject, ByVal e As EventArgs, ByVal c As Color)
				Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
				Dim chartState As NChartSessionStateObject = TryCast(state, NChartSessionStateObject)
				Dim result As NHitTestResult = chartState.HitTest(args)
				Dim rootPanel As NRootPanel = chartState.Document.RootPanel

				If result.ChartElement = ChartElement.DataPoint Then
					Select Case result.Chart.Tag.ToString()
						Case "BarChart"
							Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
							Dim highlightColor As Color = palette.SeriesColors(5)

							Dim barSeries As NBarSeries = TryCast(result.Series, NBarSeries)
							For Each series As NBarSeries In rootPanel.Charts(0).Series
								series.FillStyles.Clear()
								series.BorderStyles.Clear()
							Next series
							barSeries.FillStyles(result.DataPointIndex) = New NColorFillStyle(c)
							barSeries.BorderStyles(result.DataPointIndex) = New NStrokeStyle(1, c)

							Dim nCount As Integer = rootPanel.ChildPanels.Count
							Dim i As Integer = 0
							Do While i < nCount
								If TypeOf rootPanel.ChildPanels(i) Is NRoundedRectangularCallout Then
									rootPanel.ChildPanels.RemoveAt(i)
								End If
								i += 1
							Loop

							Dim m_RoundedRectangularCallout As NRoundedRectangularCallout = New NRoundedRectangularCallout()
							m_RoundedRectangularCallout.ArrowLength = New NLength(10, NRelativeUnit.ParentPercentage)
							m_RoundedRectangularCallout.FillStyle = New NGradientFillStyle(Color.FromArgb(255, Color.White), Color.FromArgb(125, highlightColor))
							m_RoundedRectangularCallout.UseAutomaticSize = True
							m_RoundedRectangularCallout.Orientation = 45
							m_RoundedRectangularCallout.Anchor = New NDataPointAnchor(barSeries, result.DataPointIndex, ContentAlignment.TopRight, StringAlignment.Center)
							m_RoundedRectangularCallout.Text = (CType(result.Object, NDataPoint))(DataPointValue.Y).ToString()
							rootPanel.ChildPanels.Add(m_RoundedRectangularCallout)


						Case "PieChart"
							Dim pieSeries As NPieSeries = TryCast(result.Series, NPieSeries)
							pieSeries.Detachments.Clear()
							Dim i As Integer = 0
							Do While i < pieSeries.Values.Count
								If i = result.DataPointIndex Then
									pieSeries.Detachments.Add(15)
								Else
									pieSeries.Detachments.Add(0)
								End If
								i += 1
							Loop
					End Select
				End If
			End Sub

			#End Region
		End Class

		#End Region
	End Class
End Namespace
