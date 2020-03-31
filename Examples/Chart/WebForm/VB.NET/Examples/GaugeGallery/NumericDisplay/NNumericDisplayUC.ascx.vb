Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NNumericDisplayUC
		Inherits NExampleUC
		Private m_NumericDisplay1 As NNumericDisplayPanel
		Private m_NumericDisplay2 As NNumericDisplayPanel
		Private m_NumericDisplay3 As NNumericDisplayPanel

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Numeric Display")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			Dim displayContainer As NDockPanel = New NDockPanel()
			displayContainer.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			displayContainer.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(90, NRelativeUnit.ParentPercentage))

			Dim rand As Random = New Random()

			m_NumericDisplay1 = CreateDisplayPanel()
			m_NumericDisplay1.Value = rand.Next(100) - 50
			m_NumericDisplay2 = CreateDisplayPanel()
			m_NumericDisplay2.Value = rand.Next(1000) - 500
			m_NumericDisplay3 = CreateDisplayPanel()
			m_NumericDisplay3.Value = rand.Next(10000) - 5000

			displayContainer.ChildPanels.Add(m_NumericDisplay1)

			displayContainer.ChildPanels.Add(m_NumericDisplay2)
			displayContainer.ChildPanels.Add(m_NumericDisplay3)
			nChartControl1.Panels.Add(displayContainer)

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(DisplayStyleDropDownList, GetType(DisplayStyle))
				DisplayStyleDropDownList.SelectedIndex = CInt(Fix(DisplayStyle.SevenSegmentRounded))

				WebExamplesUtilities.FillComboWithEnumValues(SignModeDropDownList, GetType(DisplaySignMode))
				SignModeDropDownList.SelectedIndex = CInt(Fix(DisplaySignMode.Always))
			End If

			m_NumericDisplay1.DisplayStyle = CType(DisplayStyleDropDownList.SelectedIndex, DisplayStyle)
			m_NumericDisplay2.DisplayStyle = CType(DisplayStyleDropDownList.SelectedIndex, DisplayStyle)
			m_NumericDisplay3.DisplayStyle = CType(DisplayStyleDropDownList.SelectedIndex, DisplayStyle)

			m_NumericDisplay1.SignMode = CType(SignModeDropDownList.SelectedIndex, DisplaySignMode)
			m_NumericDisplay2.SignMode = CType(SignModeDropDownList.SelectedIndex, DisplaySignMode)
			m_NumericDisplay3.SignMode = CType(SignModeDropDownList.SelectedIndex, DisplaySignMode)

			m_NumericDisplay1.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked
			m_NumericDisplay2.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked
			m_NumericDisplay3.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked

			m_NumericDisplay1.AttachSignToNumber = AttachSignToNumberCheckBox.Checked
			m_NumericDisplay2.AttachSignToNumber = AttachSignToNumberCheckBox.Checked
			m_NumericDisplay3.AttachSignToNumber = AttachSignToNumberCheckBox.Checked
		End Sub
		Private Function CreateDisplayPanel() As NNumericDisplayPanel
			Dim numericDisplay As NNumericDisplayPanel = New NNumericDisplayPanel()

			numericDisplay.UseAutomaticSize = True
			numericDisplay.DockMode = PanelDockMode.Top
			numericDisplay.Value = 0
			numericDisplay.CellCountMode = DisplayCellCountMode.Fixed
			numericDisplay.CellCount = 8
			numericDisplay.Margins = New NMarginsL(10, 5, 10, 5)
			numericDisplay.Padding = New NMarginsL(7, 7, 7, 7)

			' apply border, background and paint effect
			numericDisplay.BackgroundFillStyle = New NColorFillStyle(Color.Black)
			Dim border As NEdgeBorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
			border.InnerBevelWidth = New NLength(1)
			border.OuterBevelWidth = New NLength(1)
			border.MiddleBevelWidth = New NLength(1)
			numericDisplay.BorderStyle = border
			numericDisplay.PaintEffect = New NGelEffectStyle()

			' adjust cell fill styles
			numericDisplay.LitFillStyle = New NColorFillStyle(Color.GreenYellow)
			numericDisplay.DimFillStyle.SetTransparencyPercent(50)
			numericDisplay.DecimalLitFillStyle = New NColorFillStyle(Color.Red)
			numericDisplay.DecimalDimFillStyle.SetTransparencyPercent(50)

			' adjust cell sizes
			numericDisplay.CellSize = New NSizeL(New NLength(15), New NLength(30))
			numericDisplay.DecimalCellSize = New NSizeL(New NLength(15), New NLength(30))
			numericDisplay.SegmentGap = New NLength(1, NGraphicsUnit.Point)
			numericDisplay.SegmentWidth = New NLength(2.4f, NGraphicsUnit.Point)

			Return numericDisplay
		End Function
	End Class
End Namespace
