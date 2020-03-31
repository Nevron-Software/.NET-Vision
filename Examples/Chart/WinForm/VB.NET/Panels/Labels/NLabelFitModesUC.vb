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
	<ToolboxItem(False)> _
	Public Class NLabelFitModesUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private label8 As Label
		Private WithEvents PanelWidthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents LabelFitModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label

		Private m_ContainerPanel As NDockPanel

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
			Me.PanelWidthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.LabelFitModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			DirectCast(Me.PanelWidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(14, 24)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(155, 20)
			Me.label8.TabIndex = 2
			Me.label8.Text = "Panel Width (in percents):"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' PanelWidthNumericUpDown
			' 
			Me.PanelWidthNumericUpDown.Location = New System.Drawing.Point(14, 47)
			Me.PanelWidthNumericUpDown.Name = "PanelWidthNumericUpDown"
			Me.PanelWidthNumericUpDown.Size = New System.Drawing.Size(155, 20)
			Me.PanelWidthNumericUpDown.TabIndex = 3
			Me.PanelWidthNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PanelWidthNumericUpDown.ValueChanged += new System.EventHandler(this.PanelWidthNumericUpDown_ValueChanged);
			' 
			' LabelFitModeComboBox
			' 
			Me.LabelFitModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.LabelFitModeComboBox.ListProperties.DataSource = Nothing
			Me.LabelFitModeComboBox.ListProperties.DisplayMember = ""
			Me.LabelFitModeComboBox.Location = New System.Drawing.Point(14, 105)
			Me.LabelFitModeComboBox.Name = "LabelFitModeComboBox"
			Me.LabelFitModeComboBox.Size = New System.Drawing.Size(155, 21)
			Me.LabelFitModeComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelFitModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelFitModeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(14, 78)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(80, 23)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Label Fit Mode:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NLabelFitModesUC
			' 
			Me.Controls.Add(Me.LabelFitModeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.PanelWidthNumericUpDown)
			Me.Name = "NLabelFitModesUC"
			Me.Size = New System.Drawing.Size(180, 542)
			DirectCast(Me.PanelWidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NTrackballTool())
			nChartControl1.Panels.Clear()

			m_ContainerPanel = New NDockPanel()
			m_ContainerPanel.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			m_ContainerPanel.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			Dim label As New NLabel("The control supports labels that can automatically scale, wrap or clip when the available space is not sufficient to accommodate them.")
			label.DockMode = PanelDockMode.Top
			label.ContentAlignment = ContentAlignment.MiddleCenter
			label.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			label.TextStyle.FillStyle = New NGradientFillStyle(Color.LightBlue, Color.DarkBlue)
			label.Padding = New NMarginsL(10, 10, 10, 10)
			label.Margins = New NMarginsL(0, 0, 0, 10)

			' apply border to the label
			Dim labelBorder As New NEdgeBorderStyle()
			labelBorder.OuterBevelWidth = New NLength(0)
			labelBorder.InnerBevelWidth = New NLength(0)
			labelBorder.MiddleBevelFillStyle = New NColorFillStyle(Color.Black)
			label.BorderStyle = labelBorder
			m_ContainerPanel.ChildPanels.Add(label)

			Dim chart As New NCartesianChart()
			m_ContainerPanel.ChildPanels.Add(chart)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Padding = New NMarginsL(10, 10, 10, 10)
			chart.DockMode = PanelDockMode.Fill

			' apply border to the chart
			Dim chartBorder As New NEdgeBorderStyle()
			chartBorder.OuterBevelWidth = New NLength(0)
			chartBorder.InnerBevelWidth = New NLength(0)
			chartBorder.MiddleBevelFillStyle = New NColorFillStyle(Color.Black)
			chart.BorderStyle = chartBorder

			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red)
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.DataLabelStyle.Visible = False
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(3, 3)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.Values.AddRange(monthValues)

			nChartControl1.Panels.Add(m_ContainerPanel)

			LabelFitModeComboBox.FillFromEnum(GetType(TitleFitMode))
			LabelFitModeComboBox.SelectedIndex = CInt(TitleFitMode.Wrap)

			PanelWidthNumericUpDown.Value = 80

			nChartControl1.Refresh()
		End Sub

		Private Sub PanelWidthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PanelWidthNumericUpDown.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_ContainerPanel.Size = New NSizeL(New NLength(CSng(PanelWidthNumericUpDown.Value), NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			nChartControl1.Refresh()
		End Sub

		Private Sub LabelFitModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelFitModeComboBox.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			nChartControl1.Labels(0).FitMode = CType(LabelFitModeComboBox.SelectedIndex, TitleFitMode)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
