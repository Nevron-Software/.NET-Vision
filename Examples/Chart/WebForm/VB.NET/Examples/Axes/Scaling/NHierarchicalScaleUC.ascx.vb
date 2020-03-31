Imports Microsoft.VisualBasic
Imports System

Imports System.Drawing

Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NHierarchicalScaleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			If (Not IsPostBack) Then
				' init form controls
				ShowLevelSeparatorsCheckBox.Checked = True
				Show2007DataCheckBox.Checked = True
			End If

			' set a chart title
			Dim header As NLabel = New NLabel("Quarterly Company Sales<br/><font size = '9pt'>Demonstrates how to use hierarchical scale configurators</font>")
			header.DockMode = PanelDockMode.Top
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.FitAlignment = ContentAlignment.MiddleLeft
			header.Margins = New NMarginsL(5, 0, 10, 10)
			nChartControl1.Panels.Add(header)

			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)

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

			Dim rangeSelection As NRangeSelection = New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rangeSelection)

			chart.DisplayOnLegend = legend
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch
			chart.Margins = New NMarginsL(5, 0, 5, 10)
			chart.Axis(StandardAxis.Depth).Visible = False

			' first determine how many months we will show
			Dim monthCount As Integer = 12
			If Show2007DataCheckBox.Checked Then
				monthCount += 12
			End If

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Name = "Coca Cola"
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.DataLabelStyle.Visible = False

			bar1.Values.FillRandomRange(Random, monthCount, 10, 200)

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.Name = "Pepsi"
			bar2.MultiBarMode = MultiBarMode.Clustered
			bar2.DataLabelStyle.Visible = False

			' fill with random data
			bar2.Values.FillRandomRange(Random, monthCount, 10, 300)

			Dim xAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			xAxis.ScrollBar.Visible = True

			' add custom labels to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			UpdateScale()
		End Sub

		Private Sub UpdateScale()
			' add custom labels to the X axis
			Dim hirarchicalScale As NHierarchicalScaleConfigurator = New NHierarchicalScaleConfigurator()
			Dim nodes As NHierarchicalScaleNodeCollection = hirarchicalScale.Nodes


			Dim months As String() = New String() { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
			Dim labelTickMode As RangeLabelTickMode = RangeLabelTickMode.Separators

			For i As Integer = 0 To 1
				If (Not Show2007DataCheckBox.Checked) AndAlso i = 0 Then
					Continue For
				End If

				Dim yearNode As NHierarchicalScaleNode = New NHierarchicalScaleNode(0, (i + 2007).ToString())
				yearNode.LabelStyle.TickMode = labelTickMode
				nodes.AddChild(yearNode)

				For j As Integer = 0 To 3
					Dim quarterNode As NHierarchicalScaleNode = New NHierarchicalScaleNode(3, "Q" & (j + 1).ToString())
					quarterNode.LabelStyle.TickMode = labelTickMode
					yearNode.ChildNodes.AddChild(quarterNode)

					For k As Integer = 0 To 2
						Dim monthNode As NHierarchicalScaleNode = New NHierarchicalScaleNode(1, months(j * 3 + k))
						monthNode.LabelStyle.Angle = New NScaleLabelAngle(90)
						monthNode.LabelStyle.TickMode = labelTickMode
						monthNode.LabelStyle.Offset = New NLength(1)
						quarterNode.ChildNodes.AddChild(monthNode)
					Next k
				Next j
			Next i

			hirarchicalScale.CreateSeparatorForEachLevel = ShowLevelSeparatorsCheckBox.Checked

			nChartControl1.Charts(0).Axis(StandardAxis.PrimaryX).ScaleConfigurator = hirarchicalScale
		End Sub
	End Class
End Namespace
