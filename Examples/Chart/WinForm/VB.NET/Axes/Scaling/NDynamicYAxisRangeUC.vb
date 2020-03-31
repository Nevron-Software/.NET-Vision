Imports System
Imports System.Resources
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Collections
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDynamicYAxisRangeUC
		Inherits NExampleBaseUC

		Private label2 As Label
		Private WithEvents ChartTypeComboBox As UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label2 = New System.Windows.Forms.Label()
			Me.ChartTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(13, 11)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(62, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Chart Type:"
			' 
			' ChartTypeComboBox
			' 
			Me.ChartTypeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ChartTypeComboBox.ListProperties.DataSource = Nothing
			Me.ChartTypeComboBox.ListProperties.DisplayMember = ""
			Me.ChartTypeComboBox.Location = New System.Drawing.Point(13, 30)
			Me.ChartTypeComboBox.Name = "ChartTypeComboBox"
			Me.ChartTypeComboBox.Size = New System.Drawing.Size(153, 21)
			Me.ChartTypeComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChartTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartTypeComboBox_SelectedIndexChanged);
			' 
			' NDynamicYAxisRangeUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ChartTypeComboBox)
			Me.Name = "NDynamicYAxisRangeUC"
			Me.Size = New System.Drawing.Size(205, 304)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Dynamic Y Axis Range")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)

			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True

			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rangeSelection)

			ChartTypeComboBox.Items.Add("Area")
			ChartTypeComboBox.Items.Add("Bar")
			ChartTypeComboBox.Items.Add("Box And Whiskers")
			ChartTypeComboBox.Items.Add("Error Bar")
			ChartTypeComboBox.Items.Add("Float Bar")
			ChartTypeComboBox.Items.Add("Line")
			ChartTypeComboBox.Items.Add("Point")
			ChartTypeComboBox.Items.Add("Stock")

			ChartTypeComboBox.SelectedIndex = 0

			' enable interactivity
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())
		End Sub

		Private Sub ChartTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChartTypeComboBox.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series.Clear()
			Const numDataPoints As Integer = 50

			Select Case ChartTypeComboBox.SelectedIndex
				Case 0 ' Area
						Dim area As New NAreaSeries()
						area.DataLabelStyle.Visible = False
						area.VerticalAxisRangeMode = AxisRangeMode.ViewRange

						GenerateData(area, 100.0, numDataPoints, New NRange1DD(60, 140))
						chart.Series.Add(area)
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NValueTimelineScaleConfigurator()
				Case 1 ' Bar
						Dim bar As New NBarSeries()
						bar.DataLabelStyle.Visible = False
						bar.VerticalAxisRangeMode = AxisRangeMode.ViewRange

						GenerateData(bar, 100.0, numDataPoints, New NRange1DD(60, 140))
						chart.Series.Add(bar)
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NValueTimelineScaleConfigurator()
				Case 2 ' Box And Whiskers
						Dim boxAndWhiskers As New NBoxAndWhiskersSeries()
						boxAndWhiskers.VerticalAxisRangeMode = AxisRangeMode.ViewRange

						For i As Integer = 0 To 39
							Dim boxLower As Double = 1000 + Random.NextDouble() * 200
							Dim boxUpper As Double = boxLower + 200 + Random.NextDouble() * 200
							Dim whiskersLower As Double = boxLower - (20 + Random.NextDouble() * 300)
							Dim whiskersUpper As Double = boxUpper + (20 + Random.NextDouble() * 300)

							Dim IQR As Double = (boxUpper - boxLower)
							Dim median As Double = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5
							Dim average As Double = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5

							boxAndWhiskers.UpperBoxValues.Add(boxUpper)
							boxAndWhiskers.LowerBoxValues.Add(boxLower)
							boxAndWhiskers.UpperWhiskerValues.Add(whiskersUpper)
							boxAndWhiskers.LowerWhiskerValues.Add(whiskersLower)
							boxAndWhiskers.MedianValues.Add(median)
							boxAndWhiskers.AverageValues.Add(average)

							Dim outliersCount As Integer = Random.Next(5)

							Dim outliers As New NDoubleList()

							For k As Integer = 0 To outliersCount - 1
								Dim dOutlier As Double = 0

								If Random.NextDouble() > 0.5 Then
									dOutlier = boxUpper + IQR * 1.5 + Random.NextDouble() * 100
								Else
									dOutlier = boxLower - IQR * 1.5 - Random.NextDouble() * 100
								End If

								outliers.Add(dOutlier)
							Next k

							boxAndWhiskers.OutlierValues.Add(outliers)
						Next i

						chart.Series.Add(boxAndWhiskers)
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
				Case 3 ' Error Bar
						Dim errorBar As New NErrorBarSeries()
						errorBar.VerticalAxisRangeMode = AxisRangeMode.ViewRange

						Dim y As Double
						Dim x As Double = 50.0

						For i As Integer = 0 To 49
							y = 20 + Random.NextDouble() * 30
							x += 2.0 + Random.NextDouble() * 2

							errorBar.Values.Add(y)
							errorBar.LowerErrorsY.Add(1 + Random.NextDouble())
							errorBar.UpperErrorsY.Add(1 + Random.NextDouble())

							errorBar.XValues.Add(x)
							errorBar.LowerErrorsX.Add(1 + Random.NextDouble())
							errorBar.UpperErrorsX.Add(1 + Random.NextDouble())
						Next i

						chart.Series.Add(errorBar)
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
				Case 4 ' "Float Bar");
						Dim floatBar As New NFloatBarSeries()

						floatBar.VerticalAxisRangeMode = AxisRangeMode.ViewRange

						' generate Y values
						For i As Integer = 0 To 99
							Dim dBeginValue As Double = Random.NextDouble() * 5
							Dim dEndValue As Double = dBeginValue + 2 + Random.NextDouble()
							floatBar.Values.Add(dBeginValue)
							floatBar.EndValues.Add(dEndValue)
						Next i

						' generate X values
						Dim dt As New Date(2007, 5, 24, 11, 0, 0)

						For i As Integer = 0 To 99
							dt = dt.AddHours(12 + Random.NextDouble() * 60)

							floatBar.XValues.Add(dt)
						Next i

						chart.Series.Add(floatBar)
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NValueTimelineScaleConfigurator()
				Case 5 ' Line
						Dim line As New NLineSeries()
						line.DataLabelStyle.Visible = False
						line.VerticalAxisRangeMode = AxisRangeMode.ViewRange

						GenerateData(line, 100.0, numDataPoints, New NRange1DD(60, 140))
						chart.Series.Add(line)
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NValueTimelineScaleConfigurator()
				Case 6 ' Point
						Dim point As New NPointSeries()
						point.DataLabelStyle.Visible = False
						point.VerticalAxisRangeMode = AxisRangeMode.ViewRange
						point.Size = New NLength(5)

						GenerateData(point, 100.0, numDataPoints, New NRange1DD(60, 140))
						chart.Series.Add(point)
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
				Case 7 ' Stock
						' setup stock series
						Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
						stock.DataLabelStyle.Visible = False
						stock.UpFillStyle = New NColorFillStyle(Color.White)
						stock.UpStrokeStyle.Color = Color.Black
						stock.DownFillStyle = New NColorFillStyle(Color.Crimson)
						stock.DownStrokeStyle.Color = Color.Crimson
						stock.HighLowStrokeStyle.Color = Color.Black
						stock.CandleWidth = New NLength(1.2F, NRelativeUnit.ParentPercentage)
						stock.UseXValues = True
						stock.InflateMargins = True
						stock.VerticalAxisRangeMode = AxisRangeMode.ViewRange

						' add some stock items
						GenerateOHLCData(stock, 100.0, numDataPoints, New NRange1DD(60, 140))
						FillStockDates(stock, numDataPoints)
						chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NValueTimelineScaleConfigurator()
			End Select

			nChartControl1.Refresh()
		End Sub
		Friend Sub GenerateData(ByVal xyScatterSeries As NXYScatterSeries, ByVal value As Double, ByVal nCount As Integer, ByVal range As NRange1DD)
			xyScatterSeries.ClearDataPoints()
			Dim dt As New Date(2009, 1, 5)

			For nIndex As Integer = 0 To nCount - 1
				Dim upward As Boolean = False

				If range.Begin > value Then
					upward = True
				ElseIf range.End < value Then
					upward = False
				Else
					upward = Random.NextDouble() > 0.5
				End If

				xyScatterSeries.Values.Add(value)

				If upward Then
					value += (2 + (Random.NextDouble() * 20))
				Else
					value -= (2 + (Random.NextDouble() * 20))
				End If

				Do
					dt = dt.AddDays(1)

					If dt.DayOfWeek <> DayOfWeek.Saturday AndAlso dt.DayOfWeek <> DayOfWeek.Sunday Then
						xyScatterSeries.XValues.Add(dt.ToOADate())
						Exit Do
					End If
				Loop
			Next nIndex
		End Sub
		Friend Sub FillDates(ByVal xyScatterSeries As NXYScatterSeries, ByVal count As Integer, ByVal startDate As Date)
			xyScatterSeries.XValues.Clear()

			Dim dt As Date = startDate

			Dim i As Integer = 0
			Do While i < count
				If dt.DayOfWeek <> DayOfWeek.Saturday AndAlso dt.DayOfWeek <> DayOfWeek.Sunday Then
					xyScatterSeries.XValues.Add(dt.ToOADate())
					i += 1
				End If

				dt = dt.AddDays(1)
			Loop
		End Sub
	End Class
End Namespace
