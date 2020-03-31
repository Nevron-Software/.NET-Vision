Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports System.Text
Imports System.Diagnostics
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLineStudiesUC
		Inherits NExampleBaseUC

		Private m_nMinIndex1 As Integer
		Private m_nMaxIndex1 As Integer
		Private m_nMinIndex2 As Integer
		Private m_nMaxIndex2 As Integer
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents m_NewDataBtn As Nevron.UI.WinForm.Controls.NButton
		Private label3 As System.Windows.Forms.Label
		Private WithEvents FinancialMarkerCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ShowTextsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents TextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents IncludeInMinMaxCalculationCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents TrendlineModeCombo As Nevron.UI.WinForm.Controls.NComboBox

		Public Sub New()
			InitializeComponent()

			TrendlineModeCombo.FillFromEnum(GetType(TrendLineMode))

			FinancialMarkerCombo.Items.Add("Fibonacci Arcs")
			FinancialMarkerCombo.Items.Add("Fibonacci Fans")
			FinancialMarkerCombo.Items.Add("Fibonacci Retracements")
			FinancialMarkerCombo.Items.Add("Speed Resistance Lines")
			FinancialMarkerCombo.Items.Add("Quadrant Lines")
			FinancialMarkerCombo.Items.Add("Trend Line")
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
			Me.label3 = New System.Windows.Forms.Label()
			Me.FinancialMarkerCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_NewDataBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowTextsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.TextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.TrendlineModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.IncludeInMinMaxCalculationCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 8)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(169, 17)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Line Study:"
			' 
			' FinancialMarkerCombo
			' 
			Me.FinancialMarkerCombo.ListProperties.CheckBoxDataMember = ""
			Me.FinancialMarkerCombo.ListProperties.DataSource = Nothing
			Me.FinancialMarkerCombo.ListProperties.DisplayMember = ""
			Me.FinancialMarkerCombo.Location = New System.Drawing.Point(6, 29)
			Me.FinancialMarkerCombo.Name = "FinancialMarkerCombo"
			Me.FinancialMarkerCombo.Size = New System.Drawing.Size(169, 22)
			Me.FinancialMarkerCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FinancialMarkerCombo.SelectedIndexChanged += new System.EventHandler(this.FinancialMarkerCombo_SelectedIndexChanged);
			' 
			' m_NewDataBtn
			' 
			Me.m_NewDataBtn.Location = New System.Drawing.Point(6, 244)
			Me.m_NewDataBtn.Name = "m_NewDataBtn"
			Me.m_NewDataBtn.Size = New System.Drawing.Size(169, 22)
			Me.m_NewDataBtn.TabIndex = 7
			Me.m_NewDataBtn.Text = "Generate New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_NewDataBtn.Click += new System.EventHandler(this.GenerateDataBtn_Click);
			' 
			' ShowTextsCheck
			' 
			Me.ShowTextsCheck.ButtonProperties.BorderOffset = 2
			Me.ShowTextsCheck.Location = New System.Drawing.Point(6, 145)
			Me.ShowTextsCheck.Name = "ShowTextsCheck"
			Me.ShowTextsCheck.Size = New System.Drawing.Size(169, 20)
			Me.ShowTextsCheck.TabIndex = 5
			Me.ShowTextsCheck.Text = "Show Texts"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowTextsCheck.CheckedChanged += new System.EventHandler(this.ShowTextsCheck_CheckedChanged);
			' 
			' TextStyleButton
			' 
			Me.TextStyleButton.Location = New System.Drawing.Point(6, 172)
			Me.TextStyleButton.Name = "TextStyleButton"
			Me.TextStyleButton.Size = New System.Drawing.Size(169, 22)
			Me.TextStyleButton.TabIndex = 6
			Me.TextStyleButton.Text = "Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextStyleButton.Click += new System.EventHandler(this.TextStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 81)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(169, 17)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Trendline Mode:"
			' 
			' TrendlineModeCombo
			' 
			Me.TrendlineModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.TrendlineModeCombo.ListProperties.DataSource = Nothing
			Me.TrendlineModeCombo.ListProperties.DisplayMember = ""
			Me.TrendlineModeCombo.Location = New System.Drawing.Point(6, 102)
			Me.TrendlineModeCombo.Name = "TrendlineModeCombo"
			Me.TrendlineModeCombo.Size = New System.Drawing.Size(169, 22)
			Me.TrendlineModeCombo.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TrendlineModeCombo.SelectedIndexChanged += new System.EventHandler(this.TrendlineModeCombo_SelectedIndexChanged);
			' 
			' IncludeInMinMaxCalculationCheckBox
			' 
			Me.IncludeInMinMaxCalculationCheckBox.ButtonProperties.BorderOffset = 2
			Me.IncludeInMinMaxCalculationCheckBox.Location = New System.Drawing.Point(6, 54)
			Me.IncludeInMinMaxCalculationCheckBox.Name = "IncludeInMinMaxCalculationCheckBox"
			Me.IncludeInMinMaxCalculationCheckBox.Size = New System.Drawing.Size(181, 20)
			Me.IncludeInMinMaxCalculationCheckBox.TabIndex = 2
			Me.IncludeInMinMaxCalculationCheckBox.Text = "Include in Min Max Calculation"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.IncludeInMinMaxCalculationCheckBox.CheckedChanged += new System.EventHandler(this.IncludeInMinMaxCalculationCheckBox_CheckedChanged);
			' 
			' NLineStudiesUC
			' 
			Me.Controls.Add(Me.IncludeInMinMaxCalculationCheckBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.TrendlineModeCombo)
			Me.Controls.Add(Me.TextStyleButton)
			Me.Controls.Add(Me.ShowTextsCheck)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.FinancialMarkerCombo)
			Me.Controls.Add(Me.m_NewDataBtn)
			Me.Name = "NLineStudiesUC"
			Me.Size = New System.Drawing.Size(187, 303)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Line Studies")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.LightModel.EnableLighting = False
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Height = 40
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' setup X axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			axis.ScaleConfigurator = dateTimeScale

			dateTimeScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, False)
			dateTimeScale.InnerMajorTickStyle.Length = New NLength(0)
			dateTimeScale.RoundToTickMin = True
			dateTimeScale.RoundToTickMax = True
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2
			dateTimeScale.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }

			' setup primary Y axis
			axis = chart.Axis(StandardAxis.PrimaryY)
			Dim standardScale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			standardScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)

			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			standardScale.StripStyles.Add(stripStyle)
			standardScale.InnerMajorTickStyle.Length = New NLength(0)

			Dim customColor As Color = Color.FromArgb(150, 150, 200)

			' setup the stock series
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Bar
			stock.CandleWidth = New NLength(0.5F, NRelativeUnit.ParentPercentage)
			stock.HighLowStrokeStyle.Color = customColor
			stock.UpStrokeStyle.Width = New NLength(0)
			stock.DownStrokeStyle.Width = New NLength(0)
			stock.UpFillStyle = New NColorFillStyle(Color.LightGreen)
			stock.DownFillStyle = New NColorFillStyle(customColor)
			stock.Legend.Mode = SeriesLegendMode.SeriesLogic
			stock.UseXValues = True
			stock.InflateMargins = True

			GenerateData()

			' form controls
			ShowTextsCheck.Checked = True
			FinancialMarkerCombo.SelectedIndex = 2
			TrendlineModeCombo.SelectedIndex = 2
		End Sub

		Private Sub InsertFinancialMarker(ByVal chart As NChart, ByVal ls As NLineStudy)
			If chart.Series.Count > 1 Then
				chart.Series.RemoveAt(0)
			End If

			chart.Series.Insert(0, ls)
		End Sub

		Private Sub GenerateData()
			Const dataCount As Integer = 240

			Dim chart As NChart = nChartControl1.Charts(0)
			Dim stock As NStockSeries = CType(chart.Series(chart.Series.Count - 1), NStockSeries)

			GenerateStockData(stock, dataCount, 1000)

			' find the points where line studies should be attached
			m_nMinIndex1 = FindLocalMin(stock, 20)
			m_nMaxIndex1 = FindLocalMax(stock, 100)
			m_nMinIndex2 = FindLocalMin(stock, 120)
			m_nMaxIndex2 = FindLocalMax(stock, 200)

			Dim lineStudy As NLineStudy = TryCast(chart.Series(0), NLineStudy)
			If lineStudy IsNot Nothing Then
				UpdateLineStudyAnchor(stock, lineStudy)
			End If
		End Sub

		Private Function FindLocalMin(ByVal stock As NStockSeries, ByVal index As Integer) As Integer
			Dim minValue As Double = DirectCast(stock.LowValues(index), Double)
			Dim minIndex As Integer = index

			Dim from As Integer = Math.Max(0, index - 10)
			Dim [to] As Integer = Math.Min(index + 10, stock.LowValues.Count - 1)

			For i As Integer = From To [to]
				Dim value As Double = DirectCast(stock.LowValues(i), Double)
				If value < minValue Then
					minValue = value
					minIndex = i
				End If
			Next i

			Return minIndex
		End Function

		Private Function FindLocalMax(ByVal stock As NStockSeries, ByVal index As Integer) As Integer
			Dim maxValue As Double = DirectCast(stock.HighValues(index), Double)
			Dim maxIndex As Integer = index

			Dim from As Integer = Math.Max(0, index - 10)
			Dim [to] As Integer = Math.Min(index + 10, stock.LowValues.Count - 1)

			For i As Integer = From To [to]
				Dim value As Double = DirectCast(stock.HighValues(i), Double)
				If value > maxValue Then
					maxValue = value
					maxIndex = i
				End If
			Next i

			Return maxIndex
		End Function

		Private Function GetHighPointFromStock(ByVal stock As NStockSeries, ByVal dataPointIndex As Integer) As NPointD
			Dim result As NPointD

			result.X = DirectCast(stock.XValues(dataPointIndex), Double)
			result.Y = DirectCast(stock.HighValues(dataPointIndex), Double)

			Return result
		End Function

		Private Function GetLowPointFromStock(ByVal stock As NStockSeries, ByVal dataPointIndex As Integer) As NPointD
			Dim result As NPointD

			result.X = DirectCast(stock.XValues(dataPointIndex), Double)
			result.Y = DirectCast(stock.LowValues(dataPointIndex), Double)

			Return result
		End Function

		Private Sub UpdateLineStudyAnchor(ByVal stock As NStockSeries, ByVal lineStudy As NLineStudy)
			Select Case FinancialMarkerCombo.SelectedIndex
				Case 0, 1, 2, 3, 4 ' Fibonacci Arcs
					lineStudy.BeginPoint = GetLowPointFromStock(stock, m_nMinIndex1)
					lineStudy.EndPoint = GetHighPointFromStock(stock, m_nMaxIndex2)

				Case 5 ' Trend Line
					lineStudy.BeginPoint = GetLowPointFromStock(stock, m_nMinIndex1)
					lineStudy.EndPoint = GetLowPointFromStock(stock, m_nMaxIndex2)
			End Select
		End Sub

		Private Sub SetTextVisibility()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim lineStudy As NLineStudy = TryCast(chart.Series(0), NLineStudy)

			If lineStudy IsNot Nothing Then
				lineStudy.ShowTexts = ShowTextsCheck.Checked
			End If
		End Sub

		Private Sub SetTrendlineMode()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim trend As NLineStudy = TryCast(chart.Series(0), NLineStudy)

			If trend IsNot Nothing Then
				trend.TrendLineMode = CType(TrendlineModeCombo.SelectedIndex, TrendLineMode)
			End If
		End Sub

		Private Sub GenerateStockData(ByVal stock As NStockSeries, ByVal count As Integer, ByVal dPrevClose As Double)
			Dim dt As New Date(2006, 5, 15)
			Dim dGrowProbability As Double = 0.0
			Dim open, high, low, close As Double

			stock.ClearDataPoints()

			For nIndex As Integer = 0 To count - 1
				open = dPrevClose

				If (nIndex Mod 100) <= 20 Then
					' downtrend
					dGrowProbability = 0.20
				Else
					' uptrend
					dGrowProbability = 0.75
				End If

				If Random.NextDouble() < dGrowProbability Then
					' upward price change
					close = open + 2 + (Random.NextDouble() * 20)
					high = close + (Random.NextDouble() * 10)
					low = open - (Random.NextDouble() * 10)
				Else
					' downward price change
					close = open - (2 + (Random.NextDouble() * 20))
					high = open + (Random.NextDouble() * 10)
					low = close - (Random.NextDouble() * 10)
				End If

				If low < 1 Then
					low = 1
				End If

				dPrevClose = close

				stock.OpenValues.Add(open)
				stock.HighValues.Add(high)
				stock.LowValues.Add(low)
				stock.CloseValues.Add(close)
				stock.XValues.Add(dt.ToOADate())

				dt = dt.Add(New TimeSpan(1, 0, 0, 0))
			Next nIndex
		End Sub

		Private Sub FinancialMarkerCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FinancialMarkerCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim stock As NStockSeries = CType(chart.Series(chart.Series.Count - 1), NStockSeries)
			Dim lineStudy As NLineStudy = Nothing
			Dim lineColor As Color = Color.Crimson

			Select Case FinancialMarkerCombo.SelectedIndex
				Case 0
					lineStudy = New NFibonacciArcs()
					TrendlineModeCombo.Enabled = False

				Case 1
					lineStudy = New NFibonacciFans()
					TrendlineModeCombo.Enabled = True

				Case 2
					lineStudy = New NFibonacciRetracements()
					CType(lineStudy, NFibonacciRetracements).RetracementsStrokeStyle.Color = lineColor
					TrendlineModeCombo.Enabled = True

				Case 3
					lineStudy = New NSpeedResistanceLines()
					TrendlineModeCombo.Enabled = True

				Case 4
					lineStudy = New NQuadrantLines()
					CType(lineStudy, NQuadrantLines).CentralLineStrokeStyle.Color = lineColor
					TrendlineModeCombo.Enabled = False

				Case 5
					lineStudy = New NTrendLine()
					TrendlineModeCombo.Enabled = True

				Case Else
					Return
			End Select

			UpdateLineStudyAnchor(stock, lineStudy)

			' set the primary line color
			lineStudy.StrokeStyle.Color = lineColor

			InsertFinancialMarker(chart, lineStudy)
			SetTextVisibility()
			lineStudy.TrendLineMode = CType(TrendlineModeCombo.SelectedIndex, TrendLineMode)

			nChartControl1.Refresh()
		End Sub

		Private Sub TrendlineModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrendlineModeCombo.SelectedIndexChanged
			SetTrendlineMode()
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowTextsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowTextsCheck.CheckedChanged
			SetTextVisibility()
			nChartControl1.Refresh()
		End Sub

		Private Sub GenerateDataBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_NewDataBtn.Click
			GenerateData()

			nChartControl1.Refresh()
		End Sub

		Private Sub TextStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextStyleButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim lineStudy As NLineStudy = TryCast(chart.Series(0), NLineStudy)

			If lineStudy Is Nothing Then
				Return
			End If

			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(lineStudy.TextStyle, textStyleResult) Then
				lineStudy.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub IncludeInMinMaxCalculationCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles IncludeInMinMaxCalculationCheckBox.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim lineStudy As NLineStudy = TryCast(chart.Series(0), NLineStudy)

			If lineStudy IsNot Nothing Then
				lineStudy.IncludeInMinMaxCalculation = IncludeInMinMaxCalculationCheckBox.Checked
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace