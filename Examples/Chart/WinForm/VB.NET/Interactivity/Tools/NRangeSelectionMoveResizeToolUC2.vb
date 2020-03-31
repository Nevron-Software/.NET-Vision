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
	Public Class NRangeSelectionMoveResizeToolUC2
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents AllowPanCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents AllowVerticalResizeCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents AllowHorizontalResizeCheckBox As UI.WinForm.Controls.NCheckBox
		Private label2 As Label
		Private HorizontalRangeTextBox As UI.WinForm.Controls.NTextBox
		Private label1 As Label
		Private VerticalRangeTextBox As UI.WinForm.Controls.NTextBox
		Private WithEvents PaintInvertedCheckBox As UI.WinForm.Controls.NCheckBox

		Private m_RangeSelection As NRangeSelection

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
			Me.AllowPanCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AllowVerticalResizeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AllowHorizontalResizeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.HorizontalRangeTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.VerticalRangeTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.PaintInvertedCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' AllowPanCheckBox
			' 
			Me.AllowPanCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowPanCheckBox.Location = New System.Drawing.Point(6, 48)
			Me.AllowPanCheckBox.Name = "AllowPanCheckBox"
			Me.AllowPanCheckBox.Size = New System.Drawing.Size(120, 24)
			Me.AllowPanCheckBox.TabIndex = 2
			Me.AllowPanCheckBox.Text = "Allow Pan"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowPanCheckBox.CheckedChanged += new System.EventHandler(this.AllowPanCheckBox_CheckedChanged);
			' 
			' AllowVerticalResizeCheckBox
			' 
			Me.AllowVerticalResizeCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowVerticalResizeCheckBox.Location = New System.Drawing.Point(6, 27)
			Me.AllowVerticalResizeCheckBox.Name = "AllowVerticalResizeCheckBox"
			Me.AllowVerticalResizeCheckBox.Size = New System.Drawing.Size(143, 24)
			Me.AllowVerticalResizeCheckBox.TabIndex = 1
			Me.AllowVerticalResizeCheckBox.Text = "Allow Vertical Resize"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowVerticalResizeCheckBox.CheckedChanged += new System.EventHandler(this.AllowVerticalResizeCheckBox_CheckedChanged);
			' 
			' AllowHorizontalResizeCheckBox
			' 
			Me.AllowHorizontalResizeCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowHorizontalResizeCheckBox.Location = New System.Drawing.Point(6, 6)
			Me.AllowHorizontalResizeCheckBox.Name = "AllowHorizontalResizeCheckBox"
			Me.AllowHorizontalResizeCheckBox.Size = New System.Drawing.Size(158, 24)
			Me.AllowHorizontalResizeCheckBox.TabIndex = 0
			Me.AllowHorizontalResizeCheckBox.Text = "Allow Horizontal Resize"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowHorizontalResizeCheckBox.CheckedChanged += new System.EventHandler(this.AllowHorizontalResizeCheckBox_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 96)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(157, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Horizontal Range:"
			' 
			' HorizontalRangeTextBox
			' 
			Me.HorizontalRangeTextBox.Location = New System.Drawing.Point(6, 116)
			Me.HorizontalRangeTextBox.Name = "HorizontalRangeTextBox"
			Me.HorizontalRangeTextBox.ReadOnly = True
			Me.HorizontalRangeTextBox.Size = New System.Drawing.Size(157, 18)
			Me.HorizontalRangeTextBox.TabIndex = 5
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 137)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(157, 16)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Vertical Range:"
			' 
			' VerticalRangeTextBox
			' 
			Me.VerticalRangeTextBox.Location = New System.Drawing.Point(6, 157)
			Me.VerticalRangeTextBox.Name = "VerticalRangeTextBox"
			Me.VerticalRangeTextBox.ReadOnly = True
			Me.VerticalRangeTextBox.Size = New System.Drawing.Size(157, 18)
			Me.VerticalRangeTextBox.TabIndex = 7
			' 
			' PaintInvertedCheckBox
			' 
			Me.PaintInvertedCheckBox.ButtonProperties.BorderOffset = 2
			Me.PaintInvertedCheckBox.Location = New System.Drawing.Point(6, 69)
			Me.PaintInvertedCheckBox.Name = "PaintInvertedCheckBox"
			Me.PaintInvertedCheckBox.Size = New System.Drawing.Size(120, 24)
			Me.PaintInvertedCheckBox.TabIndex = 3
			Me.PaintInvertedCheckBox.Text = "Paint Inverted"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PaintInvertedCheckBox.CheckedChanged += new System.EventHandler(this.PaintInvertedCheckBox_CheckedChanged);
			' 
			' NRangeSelectionMoveResizeToolUC2
			' 
			Me.Controls.Add(Me.PaintInvertedCheckBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.VerticalRangeTextBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.HorizontalRangeTextBox)
			Me.Controls.Add(Me.AllowHorizontalResizeCheckBox)
			Me.Controls.Add(Me.AllowVerticalResizeCheckBox)
			Me.Controls.Add(Me.AllowPanCheckBox)
			Me.Name = "NRangeSelectionMoveResizeToolUC2"
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
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)

			' switch the x to linear scale
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			' create the range selection
			m_RangeSelection = New NRangeSelection()

			m_RangeSelection.AllowHorizontalResize = True
			m_RangeSelection.AllowVerticalResize = True
			m_RangeSelection.AllowPan = True

			m_RangeSelection.PaintInverted = True
			m_RangeSelection.HorizontalAxisRange = New Nevron.GraphicsCore.NRange1DD(20, 40)
			m_RangeSelection.VerticalAxisRange = New Nevron.GraphicsCore.NRange1DD(20, 40)
			m_RangeSelection.Visible = True
			m_RangeSelection.ShowGrippers = True

			chart.RangeSelections.Add(m_RangeSelection)

			AddHandler m_RangeSelection.HorizontalAxisRangeChanged, AddressOf OnRangeSelectionHorizontalAxisRangeChanged
			AddHandler m_RangeSelection.VerticalAxisRangeChanged, AddressOf OnRangeSelectionVerticalAxisRangeChanged

			Dim point As New NPointSeries()
			point.UseXValues = True
			point.InflateMargins = True
			point.Size = New NLength(5)
			point.DataLabelStyle.Visible = False

'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()

			For i As Integer = 0 To 99
				point.Values.Add(random_Renamed.Next(100))
				point.XValues.Add(random_Renamed.Next(100))
			Next i

			chart.Series.Add(point)

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NRangeSelectionMoveResizeTool())

			AllowHorizontalResizeCheckBox.Checked = m_RangeSelection.AllowHorizontalResize
			AllowVerticalResizeCheckBox.Checked = m_RangeSelection.AllowVerticalResize
			AllowPanCheckBox.Checked = m_RangeSelection.AllowPan
			PaintInvertedCheckBox.Checked = m_RangeSelection.PaintInverted
		End Sub

		Private Sub OnRangeSelectionVerticalAxisRangeChanged(ByVal sender As Object, ByVal e As EventArgs)
			VerticalRangeTextBox.Text = "Begin:" & m_RangeSelection.VerticalAxisRange.Begin.ToString() & ", End:" & m_RangeSelection.VerticalAxisRange.End.ToString()
		End Sub

		Private Sub OnRangeSelectionHorizontalAxisRangeChanged(ByVal sender As Object, ByVal e As EventArgs)
			HorizontalRangeTextBox.Text = "Begin:" & m_RangeSelection.HorizontalAxisRange.Begin.ToString() & ", End:" & m_RangeSelection.HorizontalAxisRange.End.ToString()
		End Sub

		Private Sub AllowHorizontalResizeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowHorizontalResizeCheckBox.CheckedChanged
			m_RangeSelection.AllowHorizontalResize = AllowHorizontalResizeCheckBox.Checked
			nChartControl1.RefreshOverlay()
		End Sub

		Private Sub AllowVerticalResizeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowVerticalResizeCheckBox.CheckedChanged
			m_RangeSelection.AllowVerticalResize = AllowVerticalResizeCheckBox.Checked
			nChartControl1.RefreshOverlay()
		End Sub

		Private Sub AllowPanCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowPanCheckBox.CheckedChanged
			m_RangeSelection.AllowPan = AllowPanCheckBox.Checked
			nChartControl1.RefreshOverlay()
		End Sub

		Private Sub PaintInvertedCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PaintInvertedCheckBox.CheckedChanged
			m_RangeSelection.PaintInverted = PaintInvertedCheckBox.Checked
			nChartControl1.RefreshOverlay()
		End Sub
	End Class
End Namespace
