Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRangeSelectionMoveResizeToolUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing

		Private m_Chart1 As NCartesianChart
		Private m_Chart2 As NCartesianChart

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
			Me.SuspendLayout()
			' 
			' NRangeSelectionMoveResizeToolUC
			' 
			Me.Name = "NRangeSelectionMoveResizeToolUC"
			Me.Size = New System.Drawing.Size(180, 664)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Range Selection Resize and Panning")
			title.DockMode = PanelDockMode.Top
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(title)

			' configure chart
			Dim dockPanel As New NDockPanel()
			dockPanel.Margins = New NMarginsL(10)
			dockPanel.DockMode = PanelDockMode.Fill
			nChartControl1.Panels.Add(dockPanel)

			m_Chart1 = New NCartesianChart()
			m_Chart1.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NValueTimelineScaleConfigurator()
			m_Chart1.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True
			m_Chart1.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = False
			m_Chart1.Size = New NSizeL(New NLength(0), New NLength(50, NRelativeUnit.ParentPercentage))
			m_Chart1.DockMode = PanelDockMode.Top
			m_Chart1.BoundsMode = BoundsMode.Stretch
			dockPanel.ChildPanels.Add(m_Chart1)
			Dim area1 As New NAreaSeries()
			area1.UseXValues = True
			area1.DataLabelStyle.Visible = False
			m_Chart1.Series.Add(area1)

			m_Chart2 = New NCartesianChart()
			m_Chart2.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NValueTimelineScaleConfigurator()
			m_Chart2.Size = New NSizeL(New NLength(0), New NLength(50, NRelativeUnit.ParentPercentage))
			m_Chart2.DockMode = PanelDockMode.Top
			m_Chart2.BoundsMode = BoundsMode.Stretch
			dockPanel.ChildPanels.Add(m_Chart2)
			Dim area2 As New NAreaSeries()
			area2.UseXValues = True
			area2.DataLabelStyle.Visible = False
			m_Chart2.Series.Add(area2)

			Dim rangeSelection As New NRangeSelection()
			rangeSelection.Visible = True
			rangeSelection.PaintInverted = True
			rangeSelection.ShowGrippers = True
			rangeSelection.AllowVerticalResize = False
			rangeSelection.AllowHorizontalResize = True
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			rangeSelection.GripperSize = New NSizeL(5, 20)
			m_Chart2.RangeSelections.Add(rangeSelection)

			GenerateOHLCData(area1, 100, 1000)
			area2.Values = DirectCast(area1.Values.Clone(), NDataSeriesDouble)
			area2.XValues = DirectCast(area1.XValues.Clone(), NDataSeriesDouble)

			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NRangeSelectionMoveResizeTool())

			nChartControl1.RecalcLayout()

			' link the x axes of the charts
			AddHandler m_Chart1.Axis(StandardAxis.PrimaryX).Scale.RulerRangeChanged, AddressOf Scale_RulerRangeChanged
			AddHandler rangeSelection.HorizontalAxisRangeChanged, AddressOf rangeSelection_HorizontalAxisRangeChanged
			rangeSelection.HorizontalAxisRange = New NRange1DD(DirectCast(area2.XValues(0), Double), DirectCast(area2.XValues(100), Double))
		End Sub

		Private Sub Scale_RulerRangeChanged(ByVal sender As Object, ByVal e As EventArgs)
			DirectCast(m_Chart2.RangeSelections(0), NRangeSelection).HorizontalAxisRange = m_Chart1.Axis(StandardAxis.PrimaryX).Scale.RulerRange
		End Sub

		Private Sub rangeSelection_HorizontalAxisRangeChanged(ByVal sender As Object, ByVal e As EventArgs)
			m_Chart1.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(DirectCast(m_Chart2.RangeSelections(0), NRangeSelection).HorizontalAxisRange, 0.1)
		End Sub

		Friend Overloads Sub GenerateOHLCData(ByVal areaSeries As NAreaSeries, ByVal prevValue As Double, ByVal nCount As Integer)
			Dim value, open As Double
			Dim dt As Date = Date.Now
			Dim range As New NRange1DD(10, 1000)

			For nIndex As Integer = 0 To nCount - 1
				open = prevValue
				Dim upward As Boolean = False

				If range.Begin > prevValue Then
					upward = True
				ElseIf range.End < prevValue Then
					upward = False
				Else
					upward = Random.NextDouble() > 0.5
				End If

				If upward Then
					' upward price change
					value = open + (2 + (Random.NextDouble() * 20))
				Else
					' downward price change
					value = open - (2 + (Random.NextDouble() * 20))
				End If

				If value < 1 Then
					value = 1
				End If

				prevValue = value

				areaSeries.Values.Add(value)

				Do While dt.DayOfWeek = DayOfWeek.Saturday OrElse dt.DayOfWeek = DayOfWeek.Sunday
					dt = dt.AddDays(1)
				Loop

				areaSeries.XValues.Add(nIndex)
'                areaSeries.XValues.Add(dt.ToOADate());
				dt = dt.AddDays(1)
			Next nIndex
		End Sub
	End Class
End Namespace
