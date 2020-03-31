Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Serialization
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NSerializingTheChartStateUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private WithEvents SerializationFormatComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SaveToFileButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LoadFromFileButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private SerializationContentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ResetChartButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ModifyDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ModifyAppearanceButton As Nevron.UI.WinForm.Controls.NButton

		Private m_Chart As NChart
		Private m_HighLow As NHighLowSeries
		Private m_LineSMA As NLineSeries
		Private m_Stock As NStockSeries
		Private Const nNumberOfWeeks As Integer = 20
		Private Const nWorkDaysInWeek As Integer = 5
		Private Const nDaysInWeek As Integer = 7
		Private Const nTotalWorkDays As Integer = nNumberOfWeeks * nWorkDaysInWeek
		Private Const nTotalDays As Integer = nNumberOfWeeks * nDaysInWeek
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.SaveToFileButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SerializationFormatComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.LoadFromFileButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SerializationContentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ResetChartButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ModifyDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ModifyAppearanceButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(136, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Serialization format:"
			' 
			' SaveToFileButton
			' 
			Me.SaveToFileButton.Location = New System.Drawing.Point(8, 112)
			Me.SaveToFileButton.Name = "SaveToFileButton"
			Me.SaveToFileButton.Size = New System.Drawing.Size(136, 23)
			Me.SaveToFileButton.TabIndex = 1
			Me.SaveToFileButton.Text = "Save to File"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SaveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
			' 
			' SerializationFormatComboBox
			' 
			Me.SerializationFormatComboBox.Location = New System.Drawing.Point(8, 24)
			Me.SerializationFormatComboBox.Name = "SerializationFormatComboBox"
			Me.SerializationFormatComboBox.Size = New System.Drawing.Size(136, 21)
			Me.SerializationFormatComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SerializationFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.SerializationFormatComboBox_SelectedIndexChanged);
			' 
			' LoadFromFileButton
			' 
			Me.LoadFromFileButton.Location = New System.Drawing.Point(8, 144)
			Me.LoadFromFileButton.Name = "LoadFromFileButton"
			Me.LoadFromFileButton.Size = New System.Drawing.Size(136, 23)
			Me.LoadFromFileButton.TabIndex = 3
			Me.LoadFromFileButton.Text = "LoadFromFile"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LoadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(136, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Serialization content:"
			' 
			' SerializationContentComboBox
			' 
			Me.SerializationContentComboBox.Location = New System.Drawing.Point(8, 80)
			Me.SerializationContentComboBox.Name = "SerializationContentComboBox"
			Me.SerializationContentComboBox.Size = New System.Drawing.Size(136, 21)
			Me.SerializationContentComboBox.TabIndex = 5
			' 
			' ResetChartButton
			' 
			Me.ResetChartButton.Location = New System.Drawing.Point(8, 224)
			Me.ResetChartButton.Name = "ResetChartButton"
			Me.ResetChartButton.Size = New System.Drawing.Size(136, 23)
			Me.ResetChartButton.TabIndex = 6
			Me.ResetChartButton.Text = "Reset chart"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ResetChartButton.Click += new System.EventHandler(this.ResetChartButton_Click);
			' 
			' ModifyDataButton
			' 
			Me.ModifyDataButton.Location = New System.Drawing.Point(8, 256)
			Me.ModifyDataButton.Name = "ModifyDataButton"
			Me.ModifyDataButton.Size = New System.Drawing.Size(136, 23)
			Me.ModifyDataButton.TabIndex = 7
			Me.ModifyDataButton.Text = "Modify data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ModifyDataButton.Click += new System.EventHandler(this.ModifyDataButton_Click);
			' 
			' ModifyAppearanceButton
			' 
			Me.ModifyAppearanceButton.Location = New System.Drawing.Point(8, 288)
			Me.ModifyAppearanceButton.Name = "ModifyAppearanceButton"
			Me.ModifyAppearanceButton.Size = New System.Drawing.Size(136, 23)
			Me.ModifyAppearanceButton.TabIndex = 8
			Me.ModifyAppearanceButton.Text = "Modify appearance"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ModifyAppearanceButton.Click += new System.EventHandler(this.ModifyAppearanceButton_Click);
			' 
			' NSerializingTheChartState
			' 
			Me.Controls.Add(Me.ModifyAppearanceButton)
			Me.Controls.Add(Me.ModifyDataButton)
			Me.Controls.Add(Me.ResetChartButton)
			Me.Controls.Add(Me.SerializationContentComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.LoadFromFileButton)
			Me.Controls.Add(Me.SerializationFormatComboBox)
			Me.Controls.Add(Me.SaveToFileButton)
			Me.Controls.Add(Me.label1)
			Me.Name = "NSerializingTheChartState"
			Me.Size = New System.Drawing.Size(150, 440)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Init form controls
			Dim arrPersistencyFormats() As String = System.Enum.GetNames(GetType(PersistencyFormat))
			For i As Integer = 0 To arrPersistencyFormats.Length - 1
				SerializationFormatComboBox.Items.Add(arrPersistencyFormats(i))
			Next i

			SerializationContentComboBox.Items.Add("All")
			SerializationContentComboBox.Items.Add("Data")
			SerializationContentComboBox.Items.Add("Appearance")
			SerializationContentComboBox.SelectedIndex = 0

			ResetChartButton_Click(Nothing, Nothing)
		End Sub

		Private Sub GenerateData(ByVal nCount As Integer)
			Dim now As Date = Date.Now
			GenerateOHLCData(m_Stock, 300, nCount)
			Dim day As New TimeSpan(1, 0, 0, 0, 0)

			For i As Integer = 0 To nCount - 1
				m_Stock.XValues.Add(now)
				m_HighLow.XValues.Add(now)
				m_LineSMA.XValues.Add(now)

				now = now.Add(day)
			Next i

			' create a function calculator
			Dim fc As New NFunctionCalculator()
			m_Stock.CloseValues.Name = "close"
			fc.Arguments.Add(m_Stock.CloseValues)

			' calculate the bollinger bands
			fc.Expression = "BOLLINGER(close; 20; 2)"
			m_HighLow.HighValues = fc.Calculate()

			fc.Expression = "BOLLINGER(close; 20; -2)"
			m_HighLow.LowValues = fc.Calculate()

			' calculate the simple moving average
			fc.Expression = "SMA(close; 20)"
			m_LineSMA.Values = fc.Calculate()

			' remove data that won't be charted
			m_Stock.HighValues.RemoveRange(0, 20)
			m_Stock.LowValues.RemoveRange(0, 20)
			m_Stock.OpenValues.RemoveRange(0, 20)
			m_Stock.CloseValues.RemoveRange(0, 20)
			m_HighLow.HighValues.RemoveRange(0, 20)
			m_HighLow.LowValues.RemoveRange(0, 20)
			m_LineSMA.Values.RemoveRange(0, 20)
		End Sub

		Private Function GetSeriazliationFilter() As NSerializationFilter
			Dim format As PersistencyFormat = CType(SerializationFormatComboBox.SelectedIndex, PersistencyFormat)

			If format.Equals(PersistencyFormat.Binary) OrElse format.Equals(PersistencyFormat.XML) OrElse format.Equals(PersistencyFormat.SOAP) Then
				Return Nothing
			End If

			Dim filter As NSerializationFilter = Nothing

			Select Case SerializationContentComboBox.SelectedIndex
				Case 0 ' All
					filter = Nothing
				Case 1 ' Data
					filter = New NDataSerializationFilter()
				Case 2 ' Appearance
					filter = New NAppearanceSerializationFilter()
			End Select

			Return filter
		End Function

		Private Sub SaveToFileButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToFileButton.Click
			Dim dlg As New SaveFileDialog()
			dlg.Filter = "Binary(*.bin)|*.bin|XML(*.xml)|*.xml|All files (*.*)|*.*"

			If dlg.ShowDialog() <> DialogResult.OK Then
				Return
			End If

			Try
				Dim filter As NSerializationFilter = GetSeriazliationFilter()
				nChartControl1.Serializer.SaveControlStateToFile(dlg.FileName, CType(SerializationFormatComboBox.SelectedIndex, PersistencyFormat), filter)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub LoadFromFileButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoadFromFileButton.Click
			Dim dlg As New OpenFileDialog()
			dlg.Filter = "Binary(*.bin)|*.bin|XML(*.xml)|*.xml|All files (*.*)|*.*"

			If dlg.ShowDialog() <> DialogResult.OK Then
				Return
			End If

			Try
				Dim filter As NSerializationFilter = GetSeriazliationFilter()
				nChartControl1.Serializer.LoadControlStateFromFile(dlg.FileName, CType(SerializationFormatComboBox.SelectedIndex, PersistencyFormat), filter)

				' update form members
				If nChartControl1.Charts.Count > 0 Then
					m_Chart = nChartControl1.Charts(0)

					For Each series As NSeriesBase In m_Chart.Series
						If TypeOf series Is NHighLowSeries Then
							m_HighLow = CType(series, NHighLowSeries)
						ElseIf TypeOf series Is NLineSeries Then
							m_LineSMA = CType(series, NLineSeries)
						ElseIf TypeOf series Is NStockSeries Then
							m_Stock = CType(series, NStockSeries)
						End If
					Next series
				End If

				nChartControl1.Refresh()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub ResetChartButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetChartButton.Click
			nChartControl1.Clear()

			Const nNumberOfWeeks As Integer = 20
			Const nWorkDaysInWeek As Integer = 5
			Const nDaysInWeek As Integer = 7
			Const nTotalWorkDays As Integer = nNumberOfWeeks * nWorkDaysInWeek
			Const nTotalDays As Integer = nNumberOfWeeks * nDaysInWeek

			Dim title As NLabel = nChartControl1.Labels.AddHeader("Financial Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.Location = New NPointL(New NLength(7, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(86, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			m_Chart.Height = 30
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.Wall(ChartWallType.Floor).Visible = False
			m_Chart.Wall(ChartWallType.Left).Visible = False
			m_Chart.Wall(ChartWallType.Back).Width = 0
			m_Chart.Wall(ChartWallType.Back).FillStyle = New NColorFillStyle(Color.FromArgb(239, 245, 239))
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' setup y axis
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Color = Color.Gray
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)

			' setup x axis
			Dim axisX1 As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)

			linearScale = New NLinearScaleConfigurator()
			axisX1.ScaleConfigurator = linearScale

			linearScale.AutoLabels = False

			linearScale.MinorTickCount = 4
			linearScale.MajorTickMode = MajorTickMode.CustomStep
			linearScale.CustomStep = 5
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			linearScale.OuterMajorTickStyle.Length = New NLength(4, NGraphicsUnit.Point)
			linearScale.InnerMajorTickStyle.Visible = False
			linearScale.InnerMinorTickStyle.Visible = False
			linearScale.OuterMinorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)
			linearScale.OuterMinorTickStyle.LineStyle.Color = Color.Brown
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, False)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.LabelStyle.ValueScale = 0.2

			' create a line series for the simple moving average
			m_LineSMA = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_LineSMA.Name = "SMA(20)"
			m_LineSMA.DataLabelStyle.Visible = False
			m_LineSMA.BorderStyle.Color = Color.DarkOrange

			' create the stock series
			m_Stock = CType(m_Chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.Name = "Stock Data"
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Bar
			m_Stock.CandleWidth = New NLength(5, NGraphicsUnit.Point)
			m_Stock.InflateMargins = False
			m_Stock.DownFillStyle = New NColorFillStyle(Color.Maroon)
			m_Stock.UpFillStyle = New NColorFillStyle(Color.CornflowerBlue)
			m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, True)
			m_Stock.UpStrokeStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
			m_Stock.DownStrokeStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
			m_Stock.UpStrokeStyle.Color = Color.Navy
			m_Stock.DownStrokeStyle.Color = Color.Maroon
			m_Stock.InflateMargins = True

			' add the bollinger bands as high low area
			m_HighLow = CType(m_Chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			m_HighLow.Name = "BB(20, 2)"
			m_HighLow.DataLabelStyle.Visible = False
			m_HighLow.HighFillStyle = New NColorFillStyle(Color.FromArgb(80, 130, 134, 168))
			m_HighLow.HighBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_HighLow.DisplayOnAxis(StandardAxis.SecondaryX, True)

			' generate some stock data
			GenerateData(nTotalWorkDays + 20)

			' create a function calculator
			Dim fc As New NFunctionCalculator()
			m_Stock.CloseValues.Name = "close"
			fc.Arguments.Add(m_Stock.CloseValues)

			' calculate the bollinger bands
			fc.Expression = "BOLLINGER(close; 20; 2)"
			m_HighLow.HighValues = fc.Calculate()

			fc.Expression = "BOLLINGER(close; 20; -2)"
			m_HighLow.LowValues = fc.Calculate()

			' calculate the simple moving average
			fc.Expression = "SMA(close; 20)"
			m_LineSMA.Values = fc.Calculate()

			' remove data that won't be charted
			m_Stock.HighValues.RemoveRange(0, 20)
			m_Stock.LowValues.RemoveRange(0, 20)
			m_Stock.OpenValues.RemoveRange(0, 20)
			m_Stock.CloseValues.RemoveRange(0, 20)
			m_HighLow.HighValues.RemoveRange(0, 20)
			m_HighLow.LowValues.RemoveRange(0, 20)
			m_LineSMA.Values.RemoveRange(0, 20)

			GenerateDateLabels(nTotalDays)

			nChartControl1.Refresh()
		End Sub

		Private Sub GenerateDateLabels(ByVal nTotalDays As Integer)
			' the chart starts with the first monday of june 2003
			Dim dt As New Date(2003, 6, 2)
			Dim daySpan As New TimeSpan(1, 0, 0, 0)
			Dim labelFont As New NFontStyle("Arial", 9, FontStyle.Bold)
			Dim axisX1 As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim linearScale As NLinearScaleConfigurator = TryCast(axisX1.ScaleConfigurator, NLinearScaleConfigurator)
			Dim nCurCategory As Integer = 0
			m_Chart.ChildPanels.Clear()

			For i As Integer = 0 To nTotalDays - 1
				' add a custom label for the first work day of the month
				If (dt.Day = 1) OrElse ((dt.DayOfWeek = DayOfWeek.Monday) AndAlso (dt.Day = 2 OrElse dt.Day = 3)) Then
					Dim callout As New NRectangularCallout()
					callout.Anchor = New NAxisValueAnchor(axisX1, AxisValueAnchorMode.Clamp, nCurCategory)
					callout.Orientation = 270

					callout.TextStyle.FontStyle = labelFont
					callout.Text = dt.ToString("MMM yyyy")
					callout.StrokeStyle.Color = Color.DarkSeaGreen
					callout.StrokeStyle.Pattern = LinePattern.Dot
					callout.ArrowBasePercent = 0
					callout.UseAutomaticSize = True

					m_Chart.ChildPanels.Add(callout)

					Dim cl As NAxisConstLine = axisX1.ConstLines.Add()
					cl.Value = nCurCategory
					cl.StrokeStyle.Color = Color.DarkSeaGreen


				End If

				If dt.DayOfWeek = DayOfWeek.Monday Then
					If (dt.Day = 1) OrElse (dt.Day = 2) OrElse (dt.Day = 3) Then
						linearScale.Labels.Add("")
						nCurCategory += 1
					Else
						linearScale.Labels.Add(dt.Day.ToString())
						nCurCategory += 1
					End If
				ElseIf dt.DayOfWeek = DayOfWeek.Saturday Then
				ElseIf dt.DayOfWeek = DayOfWeek.Sunday Then
				Else
					nCurCategory += 1
				End If

				dt = dt.Add(daySpan)
			Next i
		End Sub

		Private Sub ModifyDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModifyDataButton.Click
			GenerateData(nTotalWorkDays + 20)
			nChartControl1.Refresh()
		End Sub

		Private Sub ModifyAppearanceButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModifyAppearanceButton.Click
			m_Chart.Wall(ChartWallType.Back).FillStyle = New NColorFillStyle(RandomColor())
			' create a line series for the simple moving average
			m_LineSMA.BorderStyle.Color = RandomColor()

			m_Stock.DownFillStyle = New NColorFillStyle(RandomColor())
			m_Stock.UpFillStyle = New NColorFillStyle(RandomColor())
			m_Stock.UpStrokeStyle.Color = RandomColor()
			m_Stock.DownStrokeStyle.Color = RandomColor()

			' add the bollinger bands as high low area
			m_HighLow.HighFillStyle = New NColorFillStyle(RandomColor())

			nChartControl1.Refresh()
		End Sub

		Private Sub SerializationFormatComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SerializationFormatComboBox.SelectedIndexChanged
			Dim format As PersistencyFormat = CType(SerializationFormatComboBox.SelectedIndex, PersistencyFormat)

			If format.Equals(PersistencyFormat.Binary) OrElse format.Equals(PersistencyFormat.XML) OrElse format.Equals(PersistencyFormat.SOAP) Then
				SerializationContentComboBox.Enabled = False
			Else
				SerializationContentComboBox.Enabled = True
			End If
		End Sub
	End Class
End Namespace
