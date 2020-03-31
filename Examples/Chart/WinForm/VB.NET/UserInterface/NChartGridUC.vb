Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NChartGridUC
		Inherits NExampleBaseUC

		Private m_Chart1 As NChart
		Private m_Chart2 As NChart
		Private nChartGridControl1 As NChartGridControl
		Private label1 As System.Windows.Forms.Label
		Private WithEvents ChartInteractivityComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			ChartInteractivityComboBox.Items.Add("Tooltips")
			ChartInteractivityComboBox.Items.Add("Mouse Cursor Change")
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
			Me.nChartGridControl1 = New Nevron.Chart.WinForm.NChartGridControl()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ChartInteractivityComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' nChartGridControl1
			' 
			Me.nChartGridControl1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nChartGridControl1.BindToChart = False
			Me.nChartGridControl1.ChartControl = Nothing
			Me.nChartGridControl1.ChartGridButtonsMask = Nevron.Chart.WinForm.ChartGridButtonsMask.All
			Me.nChartGridControl1.Location = New System.Drawing.Point(7, 7)
			Me.nChartGridControl1.Name = "nChartGridControl1"
			Me.nChartGridControl1.Size = New System.Drawing.Size(554, 171)
			Me.nChartGridControl1.TabIndex = 0
			Me.nChartGridControl1.ToolbarVisible = True
			' 
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label1.Location = New System.Drawing.Point(7, 189)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(96, 18)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Chart Interactivity:"
			' 
			' ChartInteractivityComboBox
			' 
			Me.ChartInteractivityComboBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.ChartInteractivityComboBox.Location = New System.Drawing.Point(103, 186)
			Me.ChartInteractivityComboBox.Name = "ChartInteractivityComboBox"
			Me.ChartInteractivityComboBox.Size = New System.Drawing.Size(198, 21)
			Me.ChartInteractivityComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChartInteractivityComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartInteractivityComboBox_SelectedIndexChanged);
			' 
			' NChartGridUC
			' 
			Me.Controls.Add(Me.nChartGridControl1)
			Me.Controls.Add(Me.ChartInteractivityComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NChartGridUC"
			Me.Size = New System.Drawing.Size(568, 217)
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.NChartGridUC_Load);
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

		End Sub


		Private Sub NChartGridUC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			' set some background
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Built-in Grid Component")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))


			' hide the legend
			CType(nChartControl1.Legends(0), NLegend).Mode = LegendMode.Disabled

			' create two charts
			m_Chart1 = nChartControl1.Charts(0)
			m_Chart1.Name = "Bar & Area Chart"

			m_Chart2 = New NCartesianChart()
			nChartControl1.Charts.Add(m_Chart2)
			m_Chart2.Name = "Line & Point Chart"

			' position the charts using fit margin mode
			m_Chart1.BoundsMode = BoundsMode.Fit
			m_Chart1.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			m_Chart1.Size = New NSizeL(New NLength(40, NRelativeUnit.ParentPercentage), New NLength(95, NRelativeUnit.ParentPercentage))


			m_Chart2.BoundsMode = BoundsMode.Fit
			m_Chart2.Location = New NPointL(New NLength(55, NRelativeUnit.ParentPercentage), New NLength(4, NRelativeUnit.ParentPercentage))
			m_Chart2.Size = New NSizeL(New NLength(40, NRelativeUnit.ParentPercentage), New NLength(95, NRelativeUnit.ParentPercentage))

			' second one is date time
			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			m_Chart2.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale

			' add series to first chart
			Dim bar As NBarSeries = CType(m_Chart1.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar"
			bar.DataLabelStyle.Visible = False
			bar.Values.FillRandom(Random, 5)

			Dim area As NAreaSeries = CType(m_Chart1.Series.Add(SeriesType.Area), NAreaSeries)
			area.DataLabelStyle.Visible = False
			area.FillStyle = New NColorFillStyle(Color.SkyBlue)
			area.Name = "Area"
			area.Values.FillRandom(Random, 5)

			' add series to second chart
			Dim line As NLineSeries = CType(m_Chart2.Series.Add(SeriesType.Line), NLineSeries)
			line.DataLabelStyle.Visible = False
			line.FillStyle = New NColorFillStyle(Color.DarkOrange)
			line.LineSegmentShape = LineSegmentShape.Tape
			line.Name = "Line"
			line.UseXValues = True
			line.Values.FillRandom(Random, 3)
			line.XValues.Add(6)
			line.XValues.ValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)

			For i As Integer = 1 To 2
				line.XValues.Add(DirectCast(line.XValues(i - 1), Double) + Random.Next(5,100))
			Next i

			Dim point As NPointSeries = CType(m_Chart2.Series.Add(SeriesType.Point), NPointSeries)
			point.DataLabelStyle.Visible = False
			point.PointShape = PointShape.Sphere
			point.Name = "Point"
			point.UseXValues = True
			point.Values.FillRandom(Random, 3)
			point.XValues.Add(20)
			point.XValues.ValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)

			For i As Integer = 1 To 2
				point.XValues.Add(DirectCast(point.XValues(i - 1), Double) + Random.Next(5, 100))
			Next i

			' bind the grid to the chart
			nChartGridControl1.ChartControl = nChartControl1

			nChartControl1.InteractivityStyle.Tooltip.Text = "The background of the control"
			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			ChartInteractivityComboBox.SelectedIndex = 0
		End Sub

		Private Sub ChartInteractivityComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChartInteractivityComboBox.SelectedIndexChanged
			nChartControl1.Controller.Tools.Clear()

			Select Case ChartInteractivityComboBox.SelectedIndex
				Case 0
					nChartControl1.Controller.Tools.Add(New NTooltipTool())

				Case 1
					nChartControl1.Controller.Tools.Add(New NCursorTool())
			End Select
		End Sub
	End Class
End Namespace