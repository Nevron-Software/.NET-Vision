Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NSampledLine3DUC
		Inherits NExampleBaseUC

		Private m_Line As NLineSeries
		Private WithEvents SampleDistanceScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label2 As Label
		Private DataPointCountTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label1 As Label
		Private WithEvents ClearDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Add40KDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Add20KDataButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.SampleDistanceScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.DataPointCountTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ClearDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Add40KDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Add20KDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' SampleDistanceScroll
			' 
			Me.SampleDistanceScroll.LargeChange = 1
			Me.SampleDistanceScroll.Location = New System.Drawing.Point(6, 30)
			Me.SampleDistanceScroll.Maximum = 12
			Me.SampleDistanceScroll.Minimum = 1
			Me.SampleDistanceScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.SampleDistanceScroll.Name = "SampleDistanceScroll"
			Me.SampleDistanceScroll.Size = New System.Drawing.Size(168, 18)
			Me.SampleDistanceScroll.TabIndex = 16
			Me.SampleDistanceScroll.Value = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SampleDistanceScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SampleDistanceScroll_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 14)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(168, 21)
			Me.label2.TabIndex = 17
			Me.label2.Text = "Sample Distance:"
			' 
			' DataPointCountTextBox
			' 
			Me.DataPointCountTextBox.Location = New System.Drawing.Point(6, 174)
			Me.DataPointCountTextBox.Name = "DataPointCountTextBox"
			Me.DataPointCountTextBox.ReadOnly = True
			Me.DataPointCountTextBox.Size = New System.Drawing.Size(168, 18)
			Me.DataPointCountTextBox.TabIndex = 21
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 150)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 21)
			Me.label1.TabIndex = 20
			Me.label1.Text = "Data Point Count:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' ClearDataButton
			' 
			Me.ClearDataButton.Location = New System.Drawing.Point(6, 248)
			Me.ClearDataButton.Name = "ClearDataButton"
			Me.ClearDataButton.Size = New System.Drawing.Size(168, 23)
			Me.ClearDataButton.TabIndex = 22
			Me.ClearDataButton.Text = "Clear Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			' 
			' Add40KDataButton
			' 
			Me.Add40KDataButton.Location = New System.Drawing.Point(6, 124)
			Me.Add40KDataButton.Name = "Add40KDataButton"
			Me.Add40KDataButton.Size = New System.Drawing.Size(168, 23)
			Me.Add40KDataButton.TabIndex = 19
			Me.Add40KDataButton.Text = "Add 40,000 Data Points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Add40KDataButton.Click += new System.EventHandler(this.Add40KDataButton_Click);
			' 
			' Add20KDataButton
			' 
			Me.Add20KDataButton.Location = New System.Drawing.Point(6, 95)
			Me.Add20KDataButton.Name = "Add20KDataButton"
			Me.Add20KDataButton.Size = New System.Drawing.Size(168, 23)
			Me.Add20KDataButton.TabIndex = 18
			Me.Add20KDataButton.Text = "Add 20,000 Data Points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Add20KDataButton.Click += new System.EventHandler(this.Add20KDataButton_Click);
			' 
			' NSampledLine3DUC
			' 
			Me.Controls.Add(Me.DataPointCountTextBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ClearDataButton)
			Me.Controls.Add(Me.Add40KDataButton)
			Me.Controls.Add(Me.Add20KDataButton)
			Me.Controls.Add(Me.SampleDistanceScroll)
			Me.Controls.Add(Me.label2)
			Me.Name = "NSampledLine3DUC"
			Me.Size = New System.Drawing.Size(180, 322)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Sampled Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 70
			chart.Height = 70
			chart.Depth = 70
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = New NLinearScaleConfigurator()

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			' add a line series
			m_Line = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Name = "Line Series"
			m_Line.InflateMargins = True
			m_Line.DataLabelStyle.Visible = False
			m_Line.MarkerStyle.Visible = False
			m_Line.UseXValues = True
			m_Line.UseZValues = True
			m_Line.SamplingMode = SeriesSamplingMode.Enabled


			SampleDistanceScroll.Value = CInt(Math.Truncate(m_Line.SampleDistance.Value))

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			Add20KDataButton_Click(Nothing, Nothing)
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


		Private Sub AddNewData(ByVal count As Integer)
			Dim rand As New Random()
			Dim prevYVal As Double = 0
			Dim prevXVal As Double = 0
			Dim prevZVal As Double = 0

			Dim angle As Double = 0
			Dim phase As Double = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001
			Dim magnitude As Double = rand.NextDouble() * 5

			Dim xValues(count - 1) As Double
			Dim yValues(count - 1) As Double
			Dim zValues(count - 1) As Double

			Dim valueCount As Integer = m_Line.Values.Count
			If valueCount > 0 Then
				prevYVal = DirectCast(m_Line.Values(valueCount - 1), Double)
				prevXVal = DirectCast(m_Line.XValues(valueCount - 1), Double)
				prevZVal = DirectCast(m_Line.ZValues(valueCount - 1), Double)
			End If

			For i As Integer = 0 To count - 1
				Dim yStep As Double = Math.Cos(angle) + Math.Sin(angle) * magnitude
				Dim xStep As Double = Math.Cos(angle) * magnitude
				Dim zStep As Double = Math.Sin(angle) * magnitude

				If xStep < 0 Then
					xStep = 0
				End If

				angle += phase

				yValues(i) = prevYVal + yStep
				xValues(i) = prevXVal + xStep
				zValues(i) = prevZVal + zStep

				prevXVal = xValues(i)
				prevYVal = yValues(i)
				prevZVal = zValues(i)
			Next i

			m_Line.Values.AddRange(yValues)
			m_Line.XValues.AddRange(xValues)
			m_Line.ZValues.AddRange(zValues)

			UpdateCounter()

			nChartControl1.Refresh()
		End Sub

		Private Sub SampleDistanceScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles SampleDistanceScroll.ValueChanged
			m_Line.SampleDistance = New NLength(CSng(SampleDistanceScroll.Value))
			nChartControl1.Refresh()
		End Sub

		Private Sub Add20KDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Add20KDataButton.Click
			AddNewData(20000)
		End Sub

		Private Sub Add40KDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Add40KDataButton.Click
			AddNewData(20000)
		End Sub

		Private Sub ClearDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ClearDataButton.Click
			m_Line.Values.Clear()
			m_Line.XValues.Clear()
			m_Line.ZValues.Clear()

			UpdateCounter()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
