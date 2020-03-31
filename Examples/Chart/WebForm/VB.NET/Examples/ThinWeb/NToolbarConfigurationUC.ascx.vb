Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NToolbarConfigurationUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			NThinChartControl1.StateId = "Chart1"

			If (Not NThinChartControl1.Initialized) Then
				' enable jittering (full scene antialiasing)
				NThinChartControl1.Settings.JitterMode = JitterMode.Enabled
				NThinChartControl1.ServerSettings.EnableTiledZoom = True
				NThinChartControl1.Panels.Clear()

				' apply background image border
				Dim frame As NImageFrameStyle = New NImageFrameStyle()
				frame.Type = ImageFrameType.Raised
				frame.BackgroundColor = Color.White
				frame.BorderStyle.Color = Color.Gainsboro
				NThinChartControl1.BackgroundStyle.FrameStyle = frame
				NThinChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(Color.White, Color.GhostWhite)

				' set a chart title
				Dim title As NLabel = New NLabel("Toolbar Configuration")
				NThinChartControl1.Panels.Add(title)
				title.DockMode = PanelDockMode.Top
				title.Padding = New NMarginsL(4, 6, 4, 6)
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				' configure the legend
				Dim legend As NLegend = New NLegend()
				NThinChartControl1.Panels.Add(legend)
				legend.DockMode = PanelDockMode.Right
				legend.Padding = New NMarginsL(1, 1, 3, 3)
				legend.FillStyle.SetTransparencyPercent(50)
				legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

				' configure the chart
				Dim chart As NCartesianChart = New NCartesianChart()
				NThinChartControl1.Panels.Add(chart)
				chart.Enable3D = True
				chart.Fit3DAxisContent = True
				chart.DisplayOnLegend = legend
				chart.BoundsMode = BoundsMode.Fit
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
				chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
				chart.DockMode = PanelDockMode.Fill
				chart.Padding = New NMarginsL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))
				chart.Wall(ChartWallType.Back).FillStyle = New NGradientFillStyle(Color.White, Color.Gray)

				' setup the X axis
				Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
				axisX.ScrollBar.Visible = True
				Dim scaleX As NOrdinalScaleConfigurator = CType(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
				scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
				scaleX.AutoLabels = False

				' add interlaced stripe for the Y axis
				Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
				axisY.ScrollBar.Visible = True
				Dim scaleY As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
				stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
				scaleY.StripStyles.Add(stripStyle)

				' hide the depth axis
				chart.Axis(StandardAxis.Depth).Visible = False

				' add a bar series and fill it with data
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.Name = "Simple Bar Chart"
				bar.BarShape = BarShape.SmoothEdgeBar
				bar.Legend.Mode = SeriesLegendMode.DataPoints
				bar.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
				bar.DataLabelStyle.Visible = False

				AddDataPoint(scaleX, bar, 16, "Spain", "http://en.wikipedia.org/wiki/Spain")
				AddDataPoint(scaleX, bar, 42, "France", "http://en.wikipedia.org/wiki/France")
				AddDataPoint(scaleX, bar, 56, "Germany", "http://en.wikipedia.org/wiki/Germany")
				AddDataPoint(scaleX, bar, 23, "Italy", "http://en.wikipedia.org/wiki/Italy")
				AddDataPoint(scaleX, bar, 47, "UK", "http://en.wikipedia.org/wiki/UK")
				AddDataPoint(scaleX, bar, 38, "Sweden", "http://en.wikipedia.org/wiki/Sweden")

				' add the index of the bar to highlight
				NThinChartControl1.CustomData = 0

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(bar)

				' configure toolbar
				NThinChartControl1.Toolbar.Visible = True
				NThinChartControl1.Controller.SetActivePanel(chart)

				NThinChartControl1.AutoUpdateCallback = New NAutoUpdateCallback()

				'NThinChartControl1.Controller.EnableAutoUpdate = true;
				Dim tbt As NTrackballTool = New NTrackballTool()
				tbt.Exclusive = True
				tbt.Enabled = True
				NThinChartControl1.Controller.Tools.Add(tbt)

				' add a data zoom tool
				Dim dataZoomTool As NDataZoomTool = New NDataZoomTool()
				dataZoomTool.Exclusive = True
				dataZoomTool.Enabled = False
				NThinChartControl1.Controller.Tools.Add(dataZoomTool)

				' add a data pan tool
				Dim dataPanTool As NDataPanTool = New NDataPanTool()
				dataPanTool.Exclusive = True
				dataPanTool.Enabled = False
				NThinChartControl1.Controller.Tools.Add(dataPanTool)

				' add a tooltip tool
				NThinChartControl1.Controller.Tools.Add(New NTooltipTool())
				' add a cursor change tool
				NThinChartControl1.Controller.Tools.Add(New NCursorTool())
				' add a browser redirect tool
				NThinChartControl1.Controller.Tools.Add(New NBrowserRedirectTool())

				NThinChartControl1.Toolbar.Visible = True
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveStateAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveImageAction("Save as PDF", New NPdfImageFormat(), True, New NSize(), 300)))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveImageAction("Save as SVG", New NSvgImageFormat(), True, New NSize(), 96)))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveImageAction("Save as XAML", New NXamlImageFormat(), True, New NSize(), 96)))

				Dim sia As NSaveImageAction = New NSaveImageAction("Bitmap.bmp", New NBitmapImageFormat(), True, New NSize(), 96)
				sia.Tooltip = "Print or Save as Bitmap"
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(sia))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarSeparator())

				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NTogglePanelSelectorToolAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleDataZoomToolAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleDataPanToolAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleTrackballToolAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarSeparator())

				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleAutoUpdateAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleChart3DAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleChartLightingAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarSeparator())

				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleTooltipToolAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleBrowserRedirectToolAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleCursorToolAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarSeparator())

				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New ShowDataLabelsAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New HideDataLabelsAction()))

				NThinChartControl1.CustomRequestCallback = New CustomRequestCallback()
			End If
		End Sub
		''' <summary>
		''' A simple class showing how to show / hide data labels
		''' </summary>
		<Serializable> _
		Private Class ShowDataLabelsAction
			Inherits NAction
			Public Sub New()
				MyBase.New("Show Data Labels (Custom)")
			End Sub

			Public Overrides Function GetImage() As Bitmap
				Dim path As String = HttpContext.Current.Server.MapPath("~\Images\ShowDataLabelsButton.png")
				Return CType(Bitmap.FromFile(path), Bitmap)
			End Function

			Public Overrides Function GetScript() As String
				Dim control As NThinChartControl = CType(Me.m_Control, NThinChartControl)
				Return "NClientNode.GetFromId('" & control.StateId & "').ExecuteCustomRequest(""ShowDataLabels"");"
			End Function

			Public Overrides Function IsEnabled() As Boolean
				Dim control As NThinChartControl = CType(Me.m_Control, NThinChartControl)
				Dim bar As NBarSeries = TryCast(control.Charts(0).Series(0), NBarSeries)
				Return Not bar.DataLabelStyle.Visible
			End Function
		End Class
		''' <summary>
		''' A simple class showing how to show / hide data labels
		''' </summary>
		<Serializable> _
		Private Class HideDataLabelsAction
			Inherits NAction
			Public Sub New()
				MyBase.New("Hide Data Labels (Custom)")
			End Sub

			Public Overrides Function GetImage() As Bitmap
				Dim path As String = HttpContext.Current.Server.MapPath("~\Images\HideDataLabelsButton.png")
				Return CType(Bitmap.FromFile(path), Bitmap)
			End Function

			Public Overrides Function GetScript() As String
				Dim control As NThinChartControl = CType(Me.m_Control, NThinChartControl)
				Return "NClientNode.GetFromId('" & control.StateId & "').ExecuteCustomRequest(""HideDataLabels"");"
			End Function

			Public Overrides Function IsEnabled() As Boolean
				Dim control As NThinChartControl = CType(Me.m_Control, NThinChartControl)
				Dim bar As NBarSeries = TryCast(control.Charts(0).Series(0), NBarSeries)
				Return bar.DataLabelStyle.Visible
			End Function
		End Class

		<Serializable> _
		Public Class CustomRequestCallback
            Implements INCustomRequestCallback
			#Region "INCustomRequestCallback Members"

			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim chartControl As NThinChartControl = CType(control, NThinChartControl)

				Dim chart As NChart = chartControl.Charts(0)
				Dim bar As NBarSeries = CType(chart.Series(0), NBarSeries)
				bar.DataLabelStyles.Clear()

				Select Case argument
					Case "ShowDataLabels"
							bar.DataLabelStyle.Visible = True
					Case "HideDataLabels"
							bar.DataLabelStyle.Visible = False
				End Select

				' update the control and toolbar
				chartControl.Update()
			End Sub

			#End Region
		End Class

		<Serializable> _
		Public Class NAutoUpdateCallback
            Implements INAutoUpdateCallback
			#Region "INAutoUpdateCallback Members"

			Private Sub OnAutoUpdate(ByVal control As NAspNetThinWebControl) Implements INAutoUpdateCallback.OnAutoUpdate
				Dim chartControl As NThinChartControl = CType(control, NThinChartControl)
				Dim bar As NBarSeries = CType(chartControl.Charts(0).Series(0), NBarSeries)

				Dim index As Integer = CInt(Fix(chartControl.CustomData))

				Dim i As Integer = 0
				Do While i < bar.FillStyles.Count
					Dim colorFill As NColorFillStyle = TryCast(bar.FillStyles(i), NColorFillStyle)
					If i <> index Then
						colorFill.Color = Color.FromArgb(60, colorFill.Color)
					Else
						colorFill.Color = Color.FromArgb(255, colorFill.Color)
					End If
					i += 1
				Loop

				index += 1

				If index >= bar.FillStyles.Count Then
					index = 0
				End If

				chartControl.CustomData = index

				chartControl.UpdateView()
			End Sub

			Private Sub OnAutoUpdateStateChanged(ByVal control As NAspNetThinWebControl) Implements INAutoUpdateCallback.OnAutoUpdateStateChanged
				' reset colors
				Dim chartControl As NThinChartControl = CType(control, NThinChartControl)
				Dim bar As NBarSeries = CType(chartControl.Charts(0).Series(0), NBarSeries)

				Dim index As Integer = CInt(Fix(chartControl.CustomData))

				Dim i As Integer = 0
				Do While i < bar.FillStyles.Count
					Dim colorFill As NColorFillStyle = TryCast(bar.FillStyles(i), NColorFillStyle)
					colorFill.Color = Color.FromArgb(255, colorFill.Color)
					i += 1
				Loop

				chartControl.CustomData = 0
				chartControl.UpdateView()
			End Sub

			#End Region
		End Class

		Private Sub AddDataPoint(ByVal scale As NOrdinalScaleConfigurator, ByVal bar As NBarSeries, ByVal value As Double, ByVal countryName As String, ByVal url As String)
			scale.Labels.Add(countryName)

			bar.Values.Add(value)
			bar.Labels.Add(countryName)

			Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()

			interactivityStyle.Tooltip = New NTooltipAttribute("Click here to jump to [" & countryName & "]")
			interactivityStyle.Cursor = New NCursorAttribute(CursorType.Hand)
			interactivityStyle.UrlLink = New NUrlLinkAttribute(url, True)

			bar.InteractivityStyles.Add(bar.Values.Count - 1, interactivityStyle)
		End Sub
	End Class
End Namespace
