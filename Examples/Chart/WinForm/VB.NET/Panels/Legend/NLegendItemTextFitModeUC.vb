Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLegendItemTextFitModeUC
		Inherits NExampleBaseUC

		Private label8 As Label
		Private WithEvents MaximumLegendItemWidthUpDown As UI.WinForm.Controls.NNumericUpDown
		Private WithEvents TextFitModeComboBox As NComboBox
		Private label1 As Label
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
			Me.label8 = New System.Windows.Forms.Label()
			Me.MaximumLegendItemWidthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.TextFitModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			DirectCast(Me.MaximumLegendItemWidthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(9, 65)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(156, 20)
			Me.label8.TabIndex = 7
			Me.label8.Text = "Maximum Legend Item Width:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' MaximumLegendItemWidthUpDown
			' 
			Me.MaximumLegendItemWidthUpDown.Location = New System.Drawing.Point(12, 88)
			Me.MaximumLegendItemWidthUpDown.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
			Me.MaximumLegendItemWidthUpDown.Name = "MaximumLegendItemWidthUpDown"
			Me.MaximumLegendItemWidthUpDown.Size = New System.Drawing.Size(153, 20)
			Me.MaximumLegendItemWidthUpDown.TabIndex = 6
			Me.MaximumLegendItemWidthUpDown.Value = New Decimal(New Integer() { 100, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaximumLegendItemWidthUpDown.ValueChanged += new System.EventHandler(this.MaximumLegendItemWidthUpDown_ValueChanged);
			' 
			' TextFitModeComboBox
			' 
			Me.TextFitModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.TextFitModeComboBox.ListProperties.DataSource = Nothing
			Me.TextFitModeComboBox.ListProperties.DisplayMember = ""
			Me.TextFitModeComboBox.Location = New System.Drawing.Point(12, 36)
			Me.TextFitModeComboBox.Name = "TextFitModeComboBox"
			Me.TextFitModeComboBox.Size = New System.Drawing.Size(153, 21)
			Me.TextFitModeComboBox.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextFitModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TextFitModeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(156, 20)
			Me.label1.TabIndex = 9
			Me.label1.Text = "Text Fit Mode:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NLegendItemTextFitModeUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.TextFitModeComboBox)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.MaximumLegendItemWidthUpDown)
			Me.Name = "NLegendItemTextFitModeUC"
			Me.Size = New System.Drawing.Size(180, 680)
			DirectCast(Me.MaximumLegendItemWidthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' confgigure chart
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Legend Item Text Fit Mode")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)
			nChartControl1.Panels.Add(header)

'INSTANT VB NOTE: The variable container was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim container_Renamed As New NDockPanel()
			container_Renamed.DockMode = PanelDockMode.Fill
			container_Renamed.Margins = New NMarginsL(10, 10, 10, 10)
			container_Renamed.PositionChildPanelsInContentBounds = True
			nChartControl1.Panels.Add(container_Renamed)

			' configure the legend
			' configure the legend
			Dim legend As New NLegend()
			legend.Header.Text = "Maximum Legend Item Text Size"
			legend.Mode = LegendMode.Manual
			legend.Data.ExpandMode = LegendExpandMode.HorzWrap
			legend.DockMode = PanelDockMode.Top
			legend.Margins = New NMarginsL(20, 20, 20, 20)
			container_Renamed.ChildPanels.Add(legend)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init controls
			TextFitModeComboBox.FillFromEnum(GetType(LegendTextFitMode))
			TextFitModeComboBox.SelectedIndex = CInt(LegendTextFitMode.None)
			MaximumLegendItemWidthUpDown.Enabled = False
		End Sub
		''' <summary>
		''' 
		''' </summary>
		Private Sub UpdateLegendItems()
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim legend As NLegend = nChartControl1.Legends(0)

			legend.Data.Items.Clear()

			Dim markShapes As Array = System.Enum.GetValues(GetType(LegendMarkShape))
			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)

			For i As Integer = 0 To markShapes.Length - 1
				Dim licd As New NLegendItemCellData()
				Dim markShape As LegendMarkShape = DirectCast(markShapes.GetValue(i), LegendMarkShape)

				licd.Text = "Some very long text about mark shape [" & markShape.ToString() & "]"
				licd.MarkShape = markShape
				licd.MarkFillStyle = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))

				licd.TextFitMode = CType(TextFitModeComboBox.SelectedIndex, LegendTextFitMode)
				licd.MaxTextWidth = New NLength(CSng(MaximumLegendItemWidthUpDown.Value))

				legend.Data.Items.Add(licd)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub MaximumLegendItemWidthUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MaximumLegendItemWidthUpDown.ValueChanged
			UpdateLegendItems()
		End Sub

		Private Sub TextFitModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextFitModeComboBox.SelectedIndexChanged
			MaximumLegendItemWidthUpDown.Enabled = (CType(TextFitModeComboBox.SelectedIndex, LegendTextFitMode)) = LegendTextFitMode.Wrap
			UpdateLegendItems()
		End Sub
	End Class
End Namespace
