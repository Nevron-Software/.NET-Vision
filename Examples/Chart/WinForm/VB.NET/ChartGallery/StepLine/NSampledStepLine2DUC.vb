Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NSampledStepLine2DUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Line As NStepLineSeries
		Private label3 As Label
		Private GeneratorModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private DataPointCountTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents UseXValuesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As Label
		Private WithEvents ClearDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SampleDistanceScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label2 As Label
		Private WithEvents Add40KDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Add20KDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LineSegmentRouteComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As Label
		Private WithEvents EditMarkerButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.label3 = New System.Windows.Forms.Label()
			Me.GeneratorModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.DataPointCountTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.UseXValuesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ClearDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SampleDistanceScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.Add40KDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Add20KDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LineSegmentRouteComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.EditMarkerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(4, 138)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(171, 17)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Generator Mode:"
			' 
			' GeneratorModeCombo
			' 
			Me.GeneratorModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.GeneratorModeCombo.ListProperties.DataSource = Nothing
			Me.GeneratorModeCombo.ListProperties.DisplayMember = ""
			Me.GeneratorModeCombo.Location = New System.Drawing.Point(4, 158)
			Me.GeneratorModeCombo.Name = "GeneratorModeCombo"
			Me.GeneratorModeCombo.Size = New System.Drawing.Size(171, 22)
			Me.GeneratorModeCombo.TabIndex = 6
			' 
			' DataPointCountTextBox
			' 
			Me.DataPointCountTextBox.Location = New System.Drawing.Point(4, 297)
			Me.DataPointCountTextBox.Name = "DataPointCountTextBox"
			Me.DataPointCountTextBox.ReadOnly = True
			Me.DataPointCountTextBox.Size = New System.Drawing.Size(171, 18)
			Me.DataPointCountTextBox.TabIndex = 10
			' 
			' UseXValuesCheckBox
			' 
			Me.UseXValuesCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseXValuesCheckBox.Location = New System.Drawing.Point(4, 52)
			Me.UseXValuesCheckBox.Name = "UseXValuesCheckBox"
			Me.UseXValuesCheckBox.Size = New System.Drawing.Size(171, 48)
			Me.UseXValuesCheckBox.TabIndex = 2
			Me.UseXValuesCheckBox.Text = "Use X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseXValuesCheckBox.CheckedChanged += new System.EventHandler(this.UseXValuesCheckBox_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 273)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(171, 21)
			Me.label1.TabIndex = 9
			Me.label1.Text = "Data Point Count:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' ClearDataButton
			' 
			Me.ClearDataButton.Location = New System.Drawing.Point(4, 371)
			Me.ClearDataButton.Name = "ClearDataButton"
			Me.ClearDataButton.Size = New System.Drawing.Size(171, 23)
			Me.ClearDataButton.TabIndex = 11
			Me.ClearDataButton.Text = "Clear Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			' 
			' SampleDistanceScroll
			' 
			Me.SampleDistanceScroll.LargeChange = 1
			Me.SampleDistanceScroll.Location = New System.Drawing.Point(4, 28)
			Me.SampleDistanceScroll.Maximum = 30
			Me.SampleDistanceScroll.Minimum = 5
			Me.SampleDistanceScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.SampleDistanceScroll.Name = "SampleDistanceScroll"
			Me.SampleDistanceScroll.Size = New System.Drawing.Size(171, 18)
			Me.SampleDistanceScroll.TabIndex = 1
			Me.SampleDistanceScroll.Value = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SampleDistanceScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SampleDistanceScroll_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 12)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(171, 45)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Sample Distance:"
			' 
			' Add40KDataButton
			' 
			Me.Add40KDataButton.Location = New System.Drawing.Point(4, 247)
			Me.Add40KDataButton.Name = "Add40KDataButton"
			Me.Add40KDataButton.Size = New System.Drawing.Size(171, 23)
			Me.Add40KDataButton.TabIndex = 8
			Me.Add40KDataButton.Text = "Add 40,000 Data Points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Add40KDataButton.Click += new System.EventHandler(this.Add40KDataButton_Click);
			' 
			' Add20KDataButton
			' 
			Me.Add20KDataButton.Location = New System.Drawing.Point(4, 218)
			Me.Add20KDataButton.Name = "Add20KDataButton"
			Me.Add20KDataButton.Size = New System.Drawing.Size(171, 23)
			Me.Add20KDataButton.TabIndex = 7
			Me.Add20KDataButton.Text = "Add 20,000 Data Points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Add20KDataButton.Click += new System.EventHandler(this.Add20KDataButton_Click);
			' 
			' LineSegmentRouteComboBox
			' 
			Me.LineSegmentRouteComboBox.ListProperties.CheckBoxDataMember = ""
			Me.LineSegmentRouteComboBox.ListProperties.DataSource = Nothing
			Me.LineSegmentRouteComboBox.ListProperties.DisplayMember = ""
			Me.LineSegmentRouteComboBox.Location = New System.Drawing.Point(4, 112)
			Me.LineSegmentRouteComboBox.Name = "LineSegmentRouteComboBox"
			Me.LineSegmentRouteComboBox.Size = New System.Drawing.Size(171, 22)
			Me.LineSegmentRouteComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineSegmentRouteComboBox.SelectedIndexChanged += new System.EventHandler(this.LineSegmentRouteComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(4, 92)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(171, 17)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Line Segment Route:"
			' 
			' EditMarkerButton
			' 
			Me.EditMarkerButton.Location = New System.Drawing.Point(4, 414)
			Me.EditMarkerButton.Name = "EditMarkerButton"
			Me.EditMarkerButton.Size = New System.Drawing.Size(171, 23)
			Me.EditMarkerButton.TabIndex = 12
			Me.EditMarkerButton.Text = "Edit Marker Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EditMarkerButton.Click += new System.EventHandler(this.EditMarkerButton_Click);
			' 
			' NSampledStepLine2DUC
			' 
			Me.Controls.Add(Me.EditMarkerButton)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.LineSegmentRouteComboBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.GeneratorModeCombo)
			Me.Controls.Add(Me.DataPointCountTextBox)
			Me.Controls.Add(Me.UseXValuesCheckBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ClearDataButton)
			Me.Controls.Add(Me.SampleDistanceScroll)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.Add40KDataButton)
			Me.Controls.Add(Me.Add20KDataButton)
			Me.Name = "NSampledStepLine2DUC"
			Me.Size = New System.Drawing.Size(180, 492)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Sampled Step Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			m_Chart = nChartControl1.Charts(0)

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			' add a line series
			m_Line = CType(m_Chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			m_Line.Name = "Line Series"
			m_Line.InflateMargins = True
			m_Line.DataLabelStyle.Visible = False
			m_Line.MarkerStyle.Visible = False
			m_Line.SamplingMode = SeriesSamplingMode.Enabled
			m_Line.FilterType = SeriesFilterType.Distance

			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_Line.UseXValues = True

			SampleDistanceScroll.Value = CInt(Math.Truncate(m_Line.SampleDistance.Value))

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			GeneratorModeCombo.Items.Add("Generator 1 (Continous Y)")
			GeneratorModeCombo.Items.Add("Generator 2 (Random Y)")
			GeneratorModeCombo.SelectedIndex = 0

			LineSegmentRouteComboBox.FillFromEnum(GetType(LineSegmentRoute))
			LineSegmentRouteComboBox.SelectedIndex = CInt(LineSegmentRoute.AlwaysHV)

			UseXValuesCheckBox.Checked = True
			SampleDistanceScroll.Value = 10

			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.RangeSelections.Add(New NRangeSelection())
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True
			chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = True

			nChartControl1.Controller.Selection.Add(chart)
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			Add40KDataButton_Click(Nothing, Nothing)
		End Sub

		Private Sub AddNewData(ByVal count As Integer)
			Dim rand As New Random()

			Dim prevYVal As Double = 0
			Dim prevXVal As Double = 0

			Dim valueCount As Integer = m_Line.Values.Count

			If valueCount > 0 Then
				prevYVal = DirectCast(m_Line.Values(valueCount - 1), Double)
				prevXVal = DirectCast(m_Line.XValues(valueCount - 1), Double)
			End If

			Dim xValues(count - 1) As Double
			Dim yValues(count - 1) As Double

			Dim magnitude As Double = 0.01 + rand.NextDouble() * 5

			If GeneratorModeCombo.SelectedIndex = 0 Then
				' continuous
				Dim angle As Double = 0
				Dim phase As Double = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001

				For i As Integer = 0 To count - 1
					Dim yStep As Double = Math.Sin(angle) * magnitude
					Dim xStep As Double = 0.01 + rand.NextDouble() * magnitude

					If xStep < 0 Then
						xStep = 0
					End If

					angle += phase
					prevXVal += xStep

					yValues(i) = prevYVal + yStep
					xValues(i) = prevXVal
				Next i

				m_Line.Values.AddRange(yValues)
				m_Line.XValues.AddRange(xValues)
			Else
				' monotone X, random
				For i As Integer = 0 To count - 1
					yValues(i) = rand.NextDouble() * magnitude
					xValues(i) = prevXVal
					prevXVal += 1
				Next i

				m_Line.Values.AddRange(yValues)
				m_Line.XValues.AddRange(xValues)
			End If

			UpdateCounter()

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateCounter()
			Dim count As Integer = m_Line.Values.Count
			DataPointCountTextBox.Text = (count \ 1000).ToString() & "K"

			If count > 1000000 Then
				Add20KDataButton.Enabled = False
				Add40KDataButton.Enabled = False
			Else
				Add20KDataButton.Enabled = True
				Add40KDataButton.Enabled = True
			End If
		End Sub

		Private Sub SampleDistanceScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles SampleDistanceScroll.ValueChanged
			m_Line.SampleDistance = New NLength(CSng(SampleDistanceScroll.Value))
			nChartControl1.Refresh()
		End Sub

		Private Sub UseXValuesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UseXValuesCheckBox.CheckedChanged
			m_Line.UseXValues = UseXValuesCheckBox.Checked

			If UseXValuesCheckBox.Checked Then
				m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			Else
				m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NOrdinalScaleConfigurator()
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub Add20KDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Add20KDataButton.Click
			AddNewData(20000)
			UpdateCounter()

		End Sub

		Private Sub Add40KDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Add40KDataButton.Click
			AddNewData(40000)
			UpdateCounter()
		End Sub

		Private Sub ClearDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ClearDataButton.Click
			m_Line.Values.Clear()
			m_Line.XValues.Clear()
			UpdateCounter()

			nChartControl1.Refresh()
		End Sub

		Private Sub LineSegmentRouteComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LineSegmentRouteComboBox.SelectedIndexChanged
			m_Line.LineSegmentRoute = CType(LineSegmentRouteComboBox.SelectedIndex, LineSegmentRoute)
			nChartControl1.Refresh()
		End Sub

		Private Sub EditMarkerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EditMarkerButton.Click
			Dim series As NStepLineSeries = CType(nChartControl1.Charts(0).Series(0), NStepLineSeries)
			Dim markerStyleResult As NMarkerStyle = Nothing

			If NMarkerStyleTypeEditor.Edit(series.MarkerStyle, markerStyleResult) Then
				series.MarkerStyle = markerStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
