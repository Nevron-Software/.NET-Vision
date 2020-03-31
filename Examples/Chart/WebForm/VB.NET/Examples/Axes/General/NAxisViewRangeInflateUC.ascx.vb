Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisViewRangeInflateUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(ViewRangeInflateModeDropDownList, GetType(ScaleViewRangeInflateMode))
				ViewRangeInflateModeDropDownList.SelectedIndex = CInt(Fix(ScaleViewRangeInflateMode.MajorTick))

				InflateMinCheckBox.Checked = True
				InflateMaxCheckBox.Checked = True

				WebExamplesUtilities.FillComboWithValues(LogicalInflateMinMaxDropDownList, 0, 200, 10)
				WebExamplesUtilities.FillComboWithValues(AbsoluteInflateMinMaxDropDownList, 0, 20, 2)
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Volume Change vs. Last Year<br/> <font size = '9pt'>Demonstrates different view range modes</font>")
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.DockMode = PanelDockMode.Top
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			header.Margins = New NMarginsL(10, 2, 10, 10)
			nChartControl1.Panels.Add(header)

			' add some data to the control
			Dim chart As NCartesianChart = New NCartesianChart()
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch

			Dim bar As NBarSeries = New NBarSeries()
			bar.DataLabelStyle.Visible = False

			Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)

			bar.Values.Add(100)
			bar.FillStyles(0) = New NColorFillStyle(palette.SeriesColors(0))

			bar.Values.Add(200)
			bar.FillStyles(1) = New NColorFillStyle(palette.SeriesColors(0))

			bar.Values.Add(-180)
			bar.FillStyles(3) = New NColorFillStyle(palette.SeriesColors(1))

			bar.Values.Add(200)
			bar.FillStyles(4) = New NColorFillStyle(palette.SeriesColors(1))

			bar.Values.Add(400)
			bar.FillStyles(5) = New NColorFillStyle(palette.SeriesColors(1))

			chart.Series.Add(bar)

			chart.Margins = New NMarginsL(10, 0, 10, 10)

			' configure y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' configure the x axis
			Dim hierarchicalScale As NHierarchicalScaleConfigurator = New NHierarchicalScaleConfigurator()
			hierarchicalScale.CreateSeparatorForEachLevel = False

			' create utilization group
			Dim utilization As NHierarchicalScaleNode = New NHierarchicalScaleNode(0, "Cash Utilisation")

			utilization.LabelStyle.TickMode = RangeLabelTickMode.Separators
			utilization.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(11)
			utilization.LabelStyle.TextStyle.FontStyle.Style = FontStyle.Bold

			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at ATM", True, False))
			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at desk", True, False))
			hierarchicalScale.Nodes.Add(utilization)

			' create payments group
			Dim payments As NHierarchicalScaleNode = New NHierarchicalScaleNode(0, "Payments")

			payments.LabelStyle.TickMode = RangeLabelTickMode.Separators
			payments.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(11)
			payments.LabelStyle.TextStyle.FontStyle.Style = FontStyle.Bold

			payments.ChildNodes.Add(CreateSubScaleNode("Cheque", True, False))
			payments.ChildNodes.Add(CreateSubScaleNode("Direct debit", True, False))
			payments.ChildNodes.Add(CreateSubScaleNode("Wire transfer", True, True))
			hierarchicalScale.Nodes.Add(payments)

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = hierarchicalScale
			nChartControl1.Panels.Add(chart)

			' update form controls			
			Dim yAxis As NAxis = nChartControl1.Charts(0).Axis(StandardAxis.PrimaryY)
			Dim scale As NNumericScaleConfigurator = CType(yAxis.ScaleConfigurator, NNumericScaleConfigurator)
			scale.Title.Text = "Volume in Thousands USD"

			scale.ViewRangeInflateMode = CType(ViewRangeInflateModeDropDownList.SelectedIndex, ScaleViewRangeInflateMode)
			scale.InflateViewRangeBegin = InflateMinCheckBox.Checked
			scale.InflateViewRangeEnd = InflateMaxCheckBox.Checked

			Select Case scale.ViewRangeInflateMode
				Case ScaleViewRangeInflateMode.MajorTick
				Case ScaleViewRangeInflateMode.Logical
					Dim logicalInflate As Double = LogicalInflateMinMaxDropDownList.SelectedIndex * 10
					scale.LogicalInflate = New NRange1DD(logicalInflate, logicalInflate)
				Case ScaleViewRangeInflateMode.Absolute
					Dim absoluteInflate As Single = AbsoluteInflateMinMaxDropDownList.SelectedIndex * 2
					scale.AbsoluteInflate = New NRange1DL(New NLength(absoluteInflate, NGraphicsUnit.Point), New NLength(absoluteInflate, NGraphicsUnit.Point))
			End Select

			' assign scale configurator to y axis
			yAxis.ScaleConfigurator = scale

			' update controls state
			LogicalInflateMinMaxDropDownList.Enabled = scale.ViewRangeInflateMode = ScaleViewRangeInflateMode.Logical
			AbsoluteInflateMinMaxDropDownList.Enabled = scale.ViewRangeInflateMode = ScaleViewRangeInflateMode.Absolute
		End Sub

		Private Function CreateSubScaleNode(ByVal text As String, ByVal beginSeparator As Boolean, ByVal endSeparator As Boolean) As NHierarchicalScaleNode
			Dim node As NHierarchicalScaleNode = New NHierarchicalScaleNode(1, text)

			If beginSeparator AndAlso endSeparator Then
				node.LabelStyle.TickMode = RangeLabelTickMode.Separators
			ElseIf beginSeparator Then
				node.LabelStyle.TickMode = RangeLabelTickMode.BeginSeparator
			ElseIf endSeparator Then
				node.LabelStyle.TickMode = RangeLabelTickMode.EndSeparator
			End If

			Return node
		End Function
	End Class
End Namespace
