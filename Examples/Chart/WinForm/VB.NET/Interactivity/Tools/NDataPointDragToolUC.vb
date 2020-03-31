Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDataPointDragToolUC
		Inherits NExampleBaseUC
		Private label1 As System.Windows.Forms.Label
		Private WithEvents ChartTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing
		Private m_Chart As NChart
		Private WithEvents AllowHorizontalDraggingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AllowVerticalDraggingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents Drag2D3DCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AllowDraggingOutsideAxisRangeCheckBox As UI.WinForm.Controls.NCheckBox
		Private m_DataPointDragTool As NDataPointDragTool

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
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
			Me.ChartTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.AllowHorizontalDraggingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AllowVerticalDraggingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.Drag2D3DCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AllowDraggingOutsideAxisRangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(111, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Chart type:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ChartTypeComboBox
			' 
			Me.ChartTypeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ChartTypeComboBox.ListProperties.DataSource = Nothing
			Me.ChartTypeComboBox.ListProperties.DisplayMember = ""
			Me.ChartTypeComboBox.Location = New System.Drawing.Point(11, 27)
			Me.ChartTypeComboBox.Name = "ChartTypeComboBox"
			Me.ChartTypeComboBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark
			Me.ChartTypeComboBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark
			Me.ChartTypeComboBox.Palette.CheckedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.ChartTypeComboBox.Palette.CheckedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.ChartTypeComboBox.Palette.Control = System.Drawing.SystemColors.Control
			Me.ChartTypeComboBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark
			Me.ChartTypeComboBox.Palette.ControlDark = System.Drawing.SystemColors.Control
			Me.ChartTypeComboBox.Palette.ControlLight = System.Drawing.SystemColors.Control
			Me.ChartTypeComboBox.Palette.Highlight = System.Drawing.SystemColors.Highlight
			Me.ChartTypeComboBox.Palette.HighlightDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.ChartTypeComboBox.Palette.HighlightLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.ChartTypeComboBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText
			Me.ChartTypeComboBox.Palette.Menu = System.Drawing.Color.FromArgb((CInt(Fix((CByte(234))))), (CInt(Fix((CByte(232))))), (CInt(Fix((CByte(228))))))
			Me.ChartTypeComboBox.Palette.PressedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.ChartTypeComboBox.Palette.PressedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.ChartTypeComboBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CInt(Fix((CByte(3))))), (CInt(Fix((CByte(12))))), (CInt(Fix((CByte(35))))))
			Me.ChartTypeComboBox.Palette.Window = System.Drawing.SystemColors.Window
			Me.ChartTypeComboBox.Size = New System.Drawing.Size(156, 21)
			Me.ChartTypeComboBox.TabIndex = 1
'			Me.ChartTypeComboBox.SelectedIndexChanged += New System.EventHandler(Me.ChartTypeComboBox_SelectedIndexChanged);
			' 
			' AllowHorizontalDraggingCheckBox
			' 
			Me.AllowHorizontalDraggingCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowHorizontalDraggingCheckBox.Location = New System.Drawing.Point(11, 49)
			Me.AllowHorizontalDraggingCheckBox.Name = "AllowHorizontalDraggingCheckBox"
			Me.AllowHorizontalDraggingCheckBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowHorizontalDraggingCheckBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowHorizontalDraggingCheckBox.Palette.CheckedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.AllowHorizontalDraggingCheckBox.Palette.CheckedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.AllowHorizontalDraggingCheckBox.Palette.Control = System.Drawing.SystemColors.Control
			Me.AllowHorizontalDraggingCheckBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowHorizontalDraggingCheckBox.Palette.ControlDark = System.Drawing.SystemColors.Control
			Me.AllowHorizontalDraggingCheckBox.Palette.ControlLight = System.Drawing.SystemColors.Control
			Me.AllowHorizontalDraggingCheckBox.Palette.Highlight = System.Drawing.SystemColors.Highlight
			Me.AllowHorizontalDraggingCheckBox.Palette.HighlightDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.AllowHorizontalDraggingCheckBox.Palette.HighlightLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.AllowHorizontalDraggingCheckBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText
			Me.AllowHorizontalDraggingCheckBox.Palette.Menu = System.Drawing.Color.FromArgb((CInt(Fix((CByte(234))))), (CInt(Fix((CByte(232))))), (CInt(Fix((CByte(228))))))
			Me.AllowHorizontalDraggingCheckBox.Palette.PressedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.AllowHorizontalDraggingCheckBox.Palette.PressedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.AllowHorizontalDraggingCheckBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CInt(Fix((CByte(3))))), (CInt(Fix((CByte(12))))), (CInt(Fix((CByte(35))))))
			Me.AllowHorizontalDraggingCheckBox.Palette.Window = System.Drawing.SystemColors.Window
			Me.AllowHorizontalDraggingCheckBox.Size = New System.Drawing.Size(156, 24)
			Me.AllowHorizontalDraggingCheckBox.TabIndex = 2
			Me.AllowHorizontalDraggingCheckBox.Text = "Allow horizontal dragging"
'			Me.AllowHorizontalDraggingCheckBox.CheckedChanged += New System.EventHandler(Me.AllowHorizontalDraggingCheckBox_CheckedChanged);
			' 
			' AllowVerticalDraggingCheckBox
			' 
			Me.AllowVerticalDraggingCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowVerticalDraggingCheckBox.Location = New System.Drawing.Point(11, 74)
			Me.AllowVerticalDraggingCheckBox.Name = "AllowVerticalDraggingCheckBox"
			Me.AllowVerticalDraggingCheckBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowVerticalDraggingCheckBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowVerticalDraggingCheckBox.Palette.CheckedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.AllowVerticalDraggingCheckBox.Palette.CheckedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.AllowVerticalDraggingCheckBox.Palette.Control = System.Drawing.SystemColors.Control
			Me.AllowVerticalDraggingCheckBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowVerticalDraggingCheckBox.Palette.ControlDark = System.Drawing.SystemColors.Control
			Me.AllowVerticalDraggingCheckBox.Palette.ControlLight = System.Drawing.SystemColors.Control
			Me.AllowVerticalDraggingCheckBox.Palette.Highlight = System.Drawing.SystemColors.Highlight
			Me.AllowVerticalDraggingCheckBox.Palette.HighlightDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.AllowVerticalDraggingCheckBox.Palette.HighlightLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.AllowVerticalDraggingCheckBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText
			Me.AllowVerticalDraggingCheckBox.Palette.Menu = System.Drawing.Color.FromArgb((CInt(Fix((CByte(234))))), (CInt(Fix((CByte(232))))), (CInt(Fix((CByte(228))))))
			Me.AllowVerticalDraggingCheckBox.Palette.PressedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.AllowVerticalDraggingCheckBox.Palette.PressedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.AllowVerticalDraggingCheckBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CInt(Fix((CByte(3))))), (CInt(Fix((CByte(12))))), (CInt(Fix((CByte(35))))))
			Me.AllowVerticalDraggingCheckBox.Palette.Window = System.Drawing.SystemColors.Window
			Me.AllowVerticalDraggingCheckBox.Size = New System.Drawing.Size(156, 24)
			Me.AllowVerticalDraggingCheckBox.TabIndex = 3
			Me.AllowVerticalDraggingCheckBox.Text = "Allow vertical dragging"
'			Me.AllowVerticalDraggingCheckBox.CheckedChanged += New System.EventHandler(Me.AllowVerticalDraggingCheckBox_CheckedChanged);
			' 
			' Drag2D3DCheckBox
			' 
			Me.Drag2D3DCheckBox.ButtonProperties.BorderOffset = 2
			Me.Drag2D3DCheckBox.Location = New System.Drawing.Point(11, 124)
			Me.Drag2D3DCheckBox.Name = "Drag2D3DCheckBox"
			Me.Drag2D3DCheckBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark
			Me.Drag2D3DCheckBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark
			Me.Drag2D3DCheckBox.Palette.CheckedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.Drag2D3DCheckBox.Palette.CheckedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.Drag2D3DCheckBox.Palette.Control = System.Drawing.SystemColors.Control
			Me.Drag2D3DCheckBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark
			Me.Drag2D3DCheckBox.Palette.ControlDark = System.Drawing.SystemColors.Control
			Me.Drag2D3DCheckBox.Palette.ControlLight = System.Drawing.SystemColors.Control
			Me.Drag2D3DCheckBox.Palette.Highlight = System.Drawing.SystemColors.Highlight
			Me.Drag2D3DCheckBox.Palette.HighlightDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.Drag2D3DCheckBox.Palette.HighlightLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.Drag2D3DCheckBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText
			Me.Drag2D3DCheckBox.Palette.Menu = System.Drawing.Color.FromArgb((CInt(Fix((CByte(234))))), (CInt(Fix((CByte(232))))), (CInt(Fix((CByte(228))))))
			Me.Drag2D3DCheckBox.Palette.PressedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.Drag2D3DCheckBox.Palette.PressedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.Drag2D3DCheckBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CInt(Fix((CByte(3))))), (CInt(Fix((CByte(12))))), (CInt(Fix((CByte(35))))))
			Me.Drag2D3DCheckBox.Palette.Window = System.Drawing.SystemColors.Window
			Me.Drag2D3DCheckBox.Size = New System.Drawing.Size(156, 24)
			Me.Drag2D3DCheckBox.TabIndex = 5
			Me.Drag2D3DCheckBox.Text = "3D data point dragging"
'			Me.Drag2D3DCheckBox.CheckedChanged += New System.EventHandler(Me.Drag2D3DCheckBox_CheckedChanged);
			' 
			' AllowDraggingOutsideAxisRangeCheckBox
			' 
			Me.AllowDraggingOutsideAxisRangeCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowDraggingOutsideAxisRangeCheckBox.Location = New System.Drawing.Point(11, 99)
			Me.AllowDraggingOutsideAxisRangeCheckBox.Name = "AllowDraggingOutsideAxisRangeCheckBox"
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.CheckedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.CheckedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(139))))), (CInt(Fix((CByte(151))))), (CInt(Fix((CByte(184))))))
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.Control = System.Drawing.SystemColors.Control
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.ControlDark = System.Drawing.SystemColors.Control
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.ControlLight = System.Drawing.SystemColors.Control
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.Highlight = System.Drawing.SystemColors.Highlight
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.HighlightDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.HighlightLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(158))))), (CInt(Fix((CByte(169))))), (CInt(Fix((CByte(196))))))
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.Menu = System.Drawing.Color.FromArgb((CInt(Fix((CByte(234))))), (CInt(Fix((CByte(232))))), (CInt(Fix((CByte(228))))))
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.PressedDark = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.PressedLight = System.Drawing.Color.FromArgb((CInt(Fix((CByte(101))))), (CInt(Fix((CByte(117))))), (CInt(Fix((CByte(161))))))
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CInt(Fix((CByte(3))))), (CInt(Fix((CByte(12))))), (CInt(Fix((CByte(35))))))
			Me.AllowDraggingOutsideAxisRangeCheckBox.Palette.Window = System.Drawing.SystemColors.Window
			Me.AllowDraggingOutsideAxisRangeCheckBox.Size = New System.Drawing.Size(199, 24)
			Me.AllowDraggingOutsideAxisRangeCheckBox.TabIndex = 4
			Me.AllowDraggingOutsideAxisRangeCheckBox.Text = "Allow dragging outside axis range"
'			Me.AllowDraggingOutsideAxisRangeCheckBox.CheckedChanged += New System.EventHandler(Me.AllowDraggingOutsideAxisRangeCheckBox_CheckedChanged);
			' 
			' NDataPointDragToolUC
			' 
			Me.Controls.Add(Me.AllowDraggingOutsideAxisRangeCheckBox)
			Me.Controls.Add(Me.Drag2D3DCheckBox)
			Me.Controls.Add(Me.AllowVerticalDraggingCheckBox)
			Me.Controls.Add(Me.AllowHorizontalDraggingCheckBox)
			Me.Controls.Add(Me.ChartTypeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NDataPointDragToolUC"
			Me.Size = New System.Drawing.Size(218, 182)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Configure device and background
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Data Point Drag Tool")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = CType(nChartControl1.Charts(0), NChart)

			nChartControl1.Controller.Tools.Add(New NSelectorTool())

			m_DataPointDragTool = New NDataPointDragTool()
			m_DataPointDragTool.DepthAxisValue = 0
			nChartControl1.Controller.Tools.Add(m_DataPointDragTool)

			nChartControl1.Controller.Selection.Add(m_Chart)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			ChartTypeComboBox.Items.Add("Point")
			ChartTypeComboBox.Items.Add("Line")
			ChartTypeComboBox.Items.Add("Smooth Line")
			ChartTypeComboBox.Items.Add("Bar")
			ChartTypeComboBox.SelectedIndex = 0

			AllowHorizontalDraggingCheckBox.Checked = True
			AllowVerticalDraggingCheckBox.Checked = True
			AllowDraggingOutsideAxisRangeCheckBox.Checked = True
			Drag2D3DCheckBox.Checked = False
		End Sub

		Private Sub ChartTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChartTypeComboBox.SelectedIndexChanged
			m_Chart.Series.Clear()

			Dim series As NXYScatterSeries = Nothing

			Select Case ChartTypeComboBox.SelectedIndex
				Case 0 ' point
					series = CType(m_Chart.Series.Add(SeriesType.Point), NXYScatterSeries)
					series.Name = "Point series"

				Case 1 ' line
					series = CType(m_Chart.Series.Add(SeriesType.Line), NXYScatterSeries)
					series.Name = "Line series"
					series.MarkerStyle.Visible = True

				Case 2 ' smooth line
					series = CType(m_Chart.Series.Add(SeriesType.SmoothLine), NXYScatterSeries)
					series.Name = "Smooth line series"
					series.MarkerStyle.Visible = True
					CType(series, NSmoothLineSeries).Use1DInterpolationForXYScatter = False

				Case 3 ' bar
					series = CType(m_Chart.Series.Add(SeriesType.Bar), NXYScatterSeries)
					series.Name = "Bar series"
					series.MarkerStyle.Visible = False

				Case Else
					Debug.Assert(False)
			End Select

			series.DataLabelStyle.Visible = False
			Dim dp As NDataPoint = New NDataPoint()

			series.UseXValues = True

			For i As Integer = 0 To 9
				dp(DataPointValue.Y) = Random.Next(100)
				dp(DataPointValue.X) = Random.Next(100)
				dp(DataPointValue.Label) = "Item" & i.ToString()
				series.AddDataPoint(dp)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub AllowHorizontalDraggingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AllowHorizontalDraggingCheckBox.CheckedChanged
			m_DataPointDragTool.AllowHorizontalDragging = AllowHorizontalDraggingCheckBox.Checked
		End Sub

		Private Sub AllowVerticalDraggingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AllowVerticalDraggingCheckBox.CheckedChanged
			m_DataPointDragTool.AllowVerticalDragging = AllowVerticalDraggingCheckBox.Checked
		End Sub

		Private Sub Drag2D3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Drag2D3DCheckBox.CheckedChanged
			Dim chart As NChart = CType(nChartControl1.Charts(0), NChart)
			If Drag2D3DCheckBox.Checked Then
				chart.Enable3D = True
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			Else
				chart.Enable3D = False
			End If
		End Sub

		Private Sub AllowDraggingOutsideAxisRangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowDraggingOutsideAxisRangeCheckBox.CheckedChanged
			If AllowDraggingOutsideAxisRangeCheckBox.Checked Then
				m_DataPointDragTool.DragOutsideAxisRangeMode = DragOutsideAxisRangeMode.Enabled
			Else
				m_DataPointDragTool.DragOutsideAxisRangeMode = DragOutsideAxisRangeMode.Disabled
			End If
		End Sub
	End Class
End Namespace
