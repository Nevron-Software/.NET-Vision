Imports Microsoft.VisualBasic
Imports System

Imports System.Drawing

Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomRangeLabelsUC
		Inherits NExampleUC
		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				ShowNorthAmericaCheckBox.Checked = True
				ShowEuropeCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Company Sales by Region<br/><font size = '9pt'>Demonstrates how to use custom range labels to denote ranges on a scale</font>")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.DockMode = PanelDockMode.Top
			header.FitAlignment = ContentAlignment.MiddleLeft
			header.Margins = New NMarginsL(5, 0, 10, 10)
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			' configure the legend and add it as child panel of the chart
			Dim legend As NLegend = New NLegend()
			legend.Margins = New NMarginsL(10, 0, 10, 0)
			legend.DockMode = PanelDockMode.Right
			legend.FitAlignment = ContentAlignment.TopCenter
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly
			legend.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))
			legend.HorizontalBorderStyle.Width = New NLength(0)
			legend.VerticalBorderStyle.Width = New NLength(0)
			legend.OuterTopBorderStyle.Width = New NLength(0)
			legend.OuterLeftBorderStyle.Width = New NLength(0)
			legend.OuterBottomBorderStyle.Width = New NLength(0)
			legend.OuterRightBorderStyle.Width = New NLength(0)
			chart.ChildPanels.Add(legend)

			chart.DisplayOnLegend = legend
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch
			chart.Margins = New NMarginsL(2, 0, 2, 2)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add range selection
			Dim rangeSelection As NRangeSelection = New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rangeSelection)

			' add the first bar
			m_Bar1 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Coca Cola"
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.DataLabelStyle.Format = "<value>"

			' add the second bar
			m_Bar2 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Pepsi"
			m_Bar2.MultiBarMode = MultiBarMode.Clustered
			m_Bar2.DataLabelStyle.Format = "<value>"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' add custom labels to the X axis
			Dim xAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			xAxis.ScrollBar.Visible = True
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(xAxis.ScaleConfigurator, NOrdinalScaleConfigurator)

			ordinalScale.AutoLabels = False
			ordinalScale.OuterMajorTickStyle.Visible = False
			ordinalScale.InnerMajorTickStyle.Visible = False

			' add custom labels to the Y axis
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 320))
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = False
			Dim rangeLabel As NCustomRangeLabel = New NCustomRangeLabel(New NRange1DD(240, 320), "Target Volume")
			rangeLabel.Style.TickMode = RangeLabelTickMode.Center
			rangeLabel.Style.WrapText = True
			rangeLabel.Style.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			linearScale.CustomLabels.Add(rangeLabel)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			UpdateRegions()
		End Sub

		Private Sub UpdateRegions()
			m_Bar1.Values.Clear()
			m_Bar2.Values.Clear()

			' add custom labels to the X axis
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.Labels.Clear()
			ordinalScale.CustomLabels.Clear()

			If ShowNorthAmericaCheckBox.Checked Then
				ordinalScale.Labels.Add("USA")
				ordinalScale.Labels.Add("Canada")
				ordinalScale.Labels.Add("Mexico")

				Dim rangeLabel As NCustomRangeLabel = New NCustomRangeLabel()
				rangeLabel.Text = "Sales for North America"
				rangeLabel.Range = New NRange1DD(0, 2)
				ordinalScale.CustomLabels.Add(rangeLabel)

				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))

				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
			End If

			If ShowEuropeCheckBox.Checked Then
				ordinalScale.Labels.Add("Germany")
				ordinalScale.Labels.Add("UK")
				ordinalScale.Labels.Add("France")

				Dim rangeLabel As NCustomRangeLabel = New NCustomRangeLabel()
				rangeLabel.Text = "Sales for Europe"
				rangeLabel.Range = New NRange1DD(m_Bar1.Values.Count, m_Bar1.Values.Count + 2)
				ordinalScale.CustomLabels.Add(rangeLabel)

				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))

				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
			End If
		End Sub
	End Class
End Namespace
