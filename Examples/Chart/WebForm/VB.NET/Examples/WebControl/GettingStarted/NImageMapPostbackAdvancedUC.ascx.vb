Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NImageMapPostbackAdvancedUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("HTML Image Map with Postback (Server Events) 2")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)
			legend.InteractivityStyle.GeneratePostback = True
			legend.Header.Text = "Company Score"

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Height = 40
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(8, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(84, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			chart.Axis(StandardAxis.Depth).Visible = False

			chart.Axis(StandardAxis.Depth).InteractivityStyle.GeneratePostback = True
			chart.Axis(StandardAxis.PrimaryX).InteractivityStyle.GeneratePostback = True
			chart.Axis(StandardAxis.PrimaryY).InteractivityStyle.GeneratePostback = True

			chart.Wall(ChartWallType.Back).InteractivityStyle.GeneratePostback = True
			chart.Wall(ChartWallType.Left).InteractivityStyle.GeneratePostback = True
			chart.Wall(ChartWallType.Floor).InteractivityStyle.GeneratePostback = True

			' add an axis stripe
			Dim stripe As NAxisStripe = chart.Axis(StandardAxis.PrimaryY).Stripes.Add(20, 33)
			stripe.FillStyle = New NColorFillStyle(Color.PaleGoldenrod)
			stripe.ShowAtWalls = New ChartWallType() { ChartWallType.Left, ChartWallType.Back }
			stripe.InteractivityStyle.GeneratePostback = True

			' setup X axis
			Dim ordinalScale As NOrdinalScaleConfigurator = New NOrdinalScaleConfigurator()
			ordinalScale.AutoLabels = False
			ordinalScale.Labels.Add("Ford")
			ordinalScale.Labels.Add("VW")
			ordinalScale.Labels.Add("Toyota")
			ordinalScale.Labels.Add("BMW")
			ordinalScale.Labels.Add("Peugeot")
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = ordinalScale

			' add a bar chart
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Fictive Car sales"
			bar.BarShape = BarShape.SmoothEdgeBar
			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.DataLabelStyle.Visible = True
			bar.DataLabelStyle.Format = "<value>"
			bar.InteractivityStyle.Tooltip = New NTooltipAttribute("<value> <label>")
			bar.AddDataPoint(New NDataPoint(22, "Ford", New NColorFillStyle(Color.DarkKhaki)))
			bar.AddDataPoint(New NDataPoint(32, "VW", New NColorFillStyle(Color.OliveDrab)))
			bar.AddDataPoint(New NDataPoint(45, "Toyota", New NColorFillStyle(Color.DarkSeaGreen)))
			bar.AddDataPoint(New NDataPoint(27, "BMW", New NColorFillStyle(Color.CadetBlue)))
			bar.AddDataPoint(New NDataPoint(40, "Peugeot", New NColorFillStyle(Color.LightSlateGray)))

			Dim i As Integer = 0
			Do While i < bar.Values.Count
				Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()
				interactivityStyle.GeneratePostback = True
				bar.InteractivityStyles(i) = interactivityStyle
				i += 1
			Loop

			' configure the control to generate image map with postback
			 Dim imageMapResponse As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			imageMapResponse.GridCellSize = 2
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse

			AddHandler nChartControl1.Click, AddressOf NChartControl1_Click
		End Sub

		Private Sub SelectDataItem(ByVal nIndex As Integer)
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.FillStyles(nIndex) = New NColorFillStyle(Color.Red)
		End Sub

		Private Sub NChartControl1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim eventArgs As NPostbackEventArgs = TryCast(e, NPostbackEventArgs)
			Dim selectedObject As Object = eventArgs.Id.FindInDocument(nChartControl1.Document)

			If TypeOf selectedObject Is NDataPoint Then
				Dim dataPoint As NDataPoint = CType(selectedObject, NDataPoint)

				dataPoint(DataPointValue.FillStyle) = New NColorFillStyle(Color.Red)

				Dim series As NSeries = CType(dataPoint.ParentNode, NSeries)
				series.StoreDataPoint(dataPoint.IndexInSeries, dataPoint)

				Return
			End If

			If TypeOf selectedObject Is NLabel Then
				CType(selectedObject, NLabel).TextStyle.FillStyle = New NColorFillStyle(Color.Red)
				Return
			End If

			If TypeOf selectedObject Is NLegend Then
				CType(selectedObject, NLegend).FillStyle = New NColorFillStyle(Color.Red)
				Return
			End If

			If TypeOf selectedObject Is NLegendItemCellData Then
				Dim licd As NLegendItemCellData = TryCast(selectedObject, NLegendItemCellData)
				Dim legend As NLegend = nChartControl1.Legends(0)
				SelectDataItem(legend.Data.Items.IndexOf(licd))
				Return
			End If

			If TypeOf selectedObject Is NChartWall Then
				CType(selectedObject, NChartWall).FillStyle = New NColorFillStyle(Color.Red)
				Return
			End If

			If TypeOf selectedObject Is NAxisStripe Then
				CType(selectedObject, NAxisStripe).FillStyle = New NColorFillStyle(Color.Red)
				Return
			End If

			If TypeOf selectedObject Is NAxis Then
				Dim axis As NAxis = TryCast(selectedObject, NAxis)
				Dim scaleConfigurator As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
				scaleConfigurator.RulerStyle.BorderStyle.Color = Color.Red
				scaleConfigurator.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.Red)
			End If
		End Sub
	End Class
End Namespace
