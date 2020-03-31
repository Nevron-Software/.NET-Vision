Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NBackgroundDecoratorUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' Clear the chart panels
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			Dim controlFrameStyle As NStandardFrameStyle = New NStandardFrameStyle()
			controlFrameStyle.OuterBorderWidth = New NLength(0)
			controlFrameStyle.InnerBorderWidth = New NLength(0)
			nChartControl1.BackgroundStyle.FrameStyle = controlFrameStyle
			nChartControl1.Panels.Clear()

			' Create a background style to assign to the new panels
			Dim backroundStyle As NBackgroundStyle = New NBackgroundStyle()
			backroundStyle.FillStyle = New NColorFillStyle(Color.Transparent)
			Dim frameStyle As NImageFrameStyle = New NImageFrameStyle()
			frameStyle.BorderStyle = New NStrokeStyle(0, Color.White)
			'frameStyle.BorderStyle.Color = Color.Gray;
			frameStyle.BackgroundColor = Color.Transparent
			frameStyle.Type = ImageFrameType.Raised
			backroundStyle.FrameStyle = frameStyle

			'Create a shadow style to assign to some items
			Dim shadowStyle As NShadowStyle = New NShadowStyle()
			shadowStyle.Type = ShadowType.LinearBlur
			shadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			shadowStyle.FadeLength = New NLength(1)
			shadowStyle.Offset = New NPointL(2, 2)

			' Create the label background panel
			Dim labelBackgroundPanel As NBackgroundDecoratorPanel = New NBackgroundDecoratorPanel()
			labelBackgroundPanel.Size = New NSizeL(New NLength(0, NGraphicsUnit.Pixel), New NLength(15, NRelativeUnit.ParentPercentage))
			labelBackgroundPanel.DockMode = PanelDockMode.Top
			labelBackgroundPanel.DockMargins = New NMarginsL(New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point))
			labelBackgroundPanel.BackgroundStyle = CType(backroundStyle.Clone(), NBackgroundStyle)
			nChartControl1.Panels.Add(labelBackgroundPanel)

			' Create the legend background panel
			Dim legendBackgroundPanel As NBackgroundDecoratorPanel = New NBackgroundDecoratorPanel()
			legendBackgroundPanel.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(0, NGraphicsUnit.Pixel))
			legendBackgroundPanel.DockMode = PanelDockMode.Right
			legendBackgroundPanel.BackgroundStyle = CType(backroundStyle.Clone(), NBackgroundStyle)
			legendBackgroundPanel.DockMargins = New NMarginsL(New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point))
			nChartControl1.Panels.Add(legendBackgroundPanel)

			' Create the chart background panel
			Dim chartBackgroundPanel As NBackgroundDecoratorPanel = New NBackgroundDecoratorPanel()
			chartBackgroundPanel.BackgroundStyle = CType(backroundStyle.Clone(), NBackgroundStyle)
			chartBackgroundPanel.DockMode = PanelDockMode.Fill
			chartBackgroundPanel.DockMargins = New NMarginsL(New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point), New NLength(3, NGraphicsUnit.Point))
			nChartControl1.Panels.Add(chartBackgroundPanel)

			' Create the header label and host it in the label background panel
			Dim header As NLabel = New NLabel("Background Decorator Panel")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle = CType(shadowStyle.Clone(), NShadowStyle)
			header.TextStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightBlue, Color.DarkSlateBlue)
			header.ContentAlignment = ContentAlignment.MiddleCenter
			header.DockMode = PanelDockMode.Fill
			header.BoundsMode = BoundsMode.Fit
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			header.DockMargins = New NMarginsL(frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize)
			labelBackgroundPanel.ChildPanels.Add(header)

			' Create the legend and host it in the legend background panel
			Dim legend As NLegend = New NLegend()
			legend.DockMode = PanelDockMode.Fill
			legend.ContentAlignment = ContentAlignment.MiddleCenter
			legend.DockMargins = New NMarginsL(frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize)
			legend.FillStyle = New NColorFillStyle(New NArgbColor(0, Color.White))
			Dim borderStyle As NStrokeStyle = New NStrokeStyle(0, Color.White)
			legend.HorizontalBorderStyle = borderStyle
			legend.VerticalBorderStyle = borderStyle
			legend.OuterBottomBorderStyle = borderStyle
			legend.OuterLeftBorderStyle = borderStyle
			legend.OuterRightBorderStyle = borderStyle
			legend.OuterTopBorderStyle = borderStyle
			legendBackgroundPanel.ChildPanels.Add(legend)

			' Create a cartesian chart and host it in the chart background panel
			Dim chart As NChart = New NCartesianChart()
			chartBackgroundPanel.ChildPanels.Add(chart)

			chart.Axis(StandardAxis.Depth).Visible = False
			chart.DisplayOnLegend = legend
			chart.BoundsMode = BoundsMode.Stretch
			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(2, 10, 2, 2)

			' add bar and change bar color
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red)
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.ShadowStyle = CType(shadowStyle.Clone(), NShadowStyle)
			bar.DataLabelStyle.Visible = False

			bar.AddDataPoint(New NDataPoint(10, "Electronics", New NColorFillStyle(Color.Tomato)))
			bar.AddDataPoint(New NDataPoint(20, "Medical", New NColorFillStyle(Color.Orange)))
			bar.AddDataPoint(New NDataPoint(30, "Clothing", New NColorFillStyle(Color.Yellow)))
			bar.AddDataPoint(New NDataPoint(25, "Energy", New NColorFillStyle(Color.YellowGreen)))
			bar.AddDataPoint(New NDataPoint(29, "Financial", New NColorFillStyle(Color.ForestGreen)))
			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.Legend.TextStyle.ShadowStyle = CType(shadowStyle.Clone(), NShadowStyle)

			' init form controls
			If (Not IsPostBack) Then
				DockTitleDropDownList.Items.Add("Top")
				DockTitleDropDownList.Items.Add("Bottom")
				DockTitleDropDownList.SelectedIndex = 0

				DockLegendDropDownList.Items.Add("Left")
				DockLegendDropDownList.Items.Add("Right")
				DockLegendDropDownList.SelectedIndex = 1
			Else
				If DockTitleDropDownList.SelectedIndex = 0 Then
					labelBackgroundPanel.DockMode = PanelDockMode.Top
				Else
					labelBackgroundPanel.DockMode = PanelDockMode.Bottom
				End If

				If DockLegendDropDownList.SelectedIndex = 0 Then
					legendBackgroundPanel.DockMode = PanelDockMode.Left
				Else
					legendBackgroundPanel.DockMode = PanelDockMode.Right
				End If
			End If
		End Sub
	End Class
End Namespace
