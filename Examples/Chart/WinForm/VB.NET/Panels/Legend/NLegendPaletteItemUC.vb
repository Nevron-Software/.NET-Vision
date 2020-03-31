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
	<ToolboxItem(False)> _
	Public Class NLegendPaletteItemUC
		Inherits NExampleBaseUC

		Private label1 As Label
		Private WithEvents OrientationComboBox As UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing
		Private label2 As Label
		Private WithEvents ScalePositionComboBox As UI.WinForm.Controls.NComboBox
		Private m_PaletteCellData As NLegendPaletteCellData

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
			Me.OrientationComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.ScalePositionComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 5)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(156, 20)
			Me.label1.TabIndex = 11
			Me.label1.Text = "Orientation:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' OrientationComboBox
			' 
			Me.OrientationComboBox.ListProperties.CheckBoxDataMember = ""
			Me.OrientationComboBox.ListProperties.DataSource = Nothing
			Me.OrientationComboBox.ListProperties.DisplayMember = ""
			Me.OrientationComboBox.Location = New System.Drawing.Point(7, 28)
			Me.OrientationComboBox.Name = "OrientationComboBox"
			Me.OrientationComboBox.Size = New System.Drawing.Size(153, 21)
			Me.OrientationComboBox.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OrientationComboBox.SelectedIndexChanged += new System.EventHandler(this.OrientationComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 54)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(156, 20)
			Me.label2.TabIndex = 13
			Me.label2.Text = "Orientation:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ScalePositionComboBox
			' 
			Me.ScalePositionComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ScalePositionComboBox.ListProperties.DataSource = Nothing
			Me.ScalePositionComboBox.ListProperties.DisplayMember = ""
			Me.ScalePositionComboBox.Location = New System.Drawing.Point(7, 77)
			Me.ScalePositionComboBox.Name = "ScalePositionComboBox"
			Me.ScalePositionComboBox.Size = New System.Drawing.Size(153, 21)
			Me.ScalePositionComboBox.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ScalePositionComboBox.SelectedIndexChanged += new System.EventHandler(this.ScalePositionComboBox_SelectedIndexChanged);
			' 
			' NLegendPaletteItemUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ScalePositionComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.OrientationComboBox)
			Me.Name = "NLegendPaletteItemUC"
			Me.Size = New System.Drawing.Size(180, 680)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' confgigure chart
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Legend Custom Items")
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
			Dim legend As NLegend = CreateLegend(container_Renamed, "Legend Palette Item")

			Dim palette As New NPalette()

			palette.Mode = PaletteMode.AutoFixedEntryCount
			'palette.SmoothPalette = true;

			m_PaletteCellData = New NLegendPaletteCellData(palette, New NRange1DD(0, 100))

			legend.Data.Items.Add(m_PaletteCellData)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			OrientationComboBox.Items.Add("Horizontal")
			OrientationComboBox.Items.Add("Vertical")
			OrientationComboBox.SelectedIndex = 0

			ScalePositionComboBox.Items.Add("Left")
			ScalePositionComboBox.Items.Add("Right")
			ScalePositionComboBox.SelectedIndex = 0
		End Sub

		Private Function CreateLegend(ByVal container As NDockPanel, ByVal title As String) As NLegend
			' configure the legend
			Dim legend As New NLegend()
			legend.Header.Text = title
			legend.Mode = LegendMode.Manual
			legend.Data.ExpandMode = LegendExpandMode.HorzWrap
			legend.DockMode = PanelDockMode.Top
			legend.Margins = New NMarginsL(20, 20, 20, 20)
			container.ChildPanels.Add(legend)

			Return legend
		End Function

		Private Sub OrientationComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OrientationComboBox.SelectedIndexChanged
			m_PaletteCellData.Orientation = CType(OrientationComboBox.SelectedIndex, PaletteOrientation)
			nChartControl1.Refresh()
		End Sub

		Private Sub ScalePositionComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ScalePositionComboBox.SelectedIndexChanged
			m_PaletteCellData.ScalePosition = CType(ScalePositionComboBox.SelectedIndex, PaletteScalePosition)
			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace
