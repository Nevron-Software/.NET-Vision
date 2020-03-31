Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Partial Public Class NTreeMapLegendUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing
		Private m_TreeMap As NTreeMapChart
		Private label1 As Label
		Private label2 As Label
		Private WithEvents PaletteLegendModeComboBox As UI.WinForm.Controls.NComboBox
		Private WithEvents LegendModeComboBox As UI.WinForm.Controls.NComboBox

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
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
			Me.LegendModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.PaletteLegendModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 11)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(76, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Legend Mode:"
			' 
			' LegendModeComboBox
			' 
			Me.LegendModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.LegendModeComboBox.ListProperties.DataSource = Nothing
			Me.LegendModeComboBox.ListProperties.DisplayMember = ""
			Me.LegendModeComboBox.Location = New System.Drawing.Point(13, 28)
			Me.LegendModeComboBox.Name = "LegendModeComboBox"
			Me.LegendModeComboBox.Size = New System.Drawing.Size(151, 21)
			Me.LegendModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LegendModeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(13, 64)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(73, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Palette Mode:"
			' 
			' PaletteLegendModeComboBox
			' 
			Me.PaletteLegendModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PaletteLegendModeComboBox.ListProperties.DataSource = Nothing
			Me.PaletteLegendModeComboBox.ListProperties.DisplayMember = ""
			Me.PaletteLegendModeComboBox.Location = New System.Drawing.Point(13, 81)
			Me.PaletteLegendModeComboBox.Name = "PaletteLegendModeComboBox"
			Me.PaletteLegendModeComboBox.Size = New System.Drawing.Size(151, 21)
			Me.PaletteLegendModeComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PaletteLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaletteLegendModeComboBox_SelectedIndexChanged);
			' 
			' NTreeMapLegendUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.PaletteLegendModeComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LegendModeComboBox)
			Me.Name = "NTreeMapLegendUC"
			Me.Size = New System.Drawing.Size(178, 350)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()
			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			nChartControl1.Document.RootPanel.Margins = New NMarginsL(10)

			' set a chart title
			Dim title As New NLabel("Tree Map - Legend Options")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.DockMode = PanelDockMode.Top
			nChartControl1.Panels.Add(title)

			Dim legend As New NLegend()
			legend.DockMode = PanelDockMode.Right
			nChartControl1.Panels.Add(legend)

			m_TreeMap = New NTreeMapChart()
			nChartControl1.Panels.Add(m_TreeMap)
			m_TreeMap.DockMode = PanelDockMode.Fill

			m_TreeMap.RootTreeMapNode.Legend.DisplayOnLegend = legend

			Dim document As XmlDocument = LoadData()

			m_TreeMap.RootTreeMapNode.Label = "Tree Map by Industry Sector"
			m_TreeMap.RootTreeMapNode.Format = ""
			m_TreeMap.RootTreeMapNode.LegendFormat = "<label>"

			For Each industry As XmlElement In document.DocumentElement
				Dim groupNode As New NGroupTreeMapNode()

				groupNode.Padding = New NMarginsL(2.0F)

				m_TreeMap.RootTreeMapNode.ChildNodes.Add(groupNode)

				groupNode.Label = industry.Attributes("Name").Value

				groupNode.LabelTextStyle = New NTextStyle()
				groupNode.LabelTextStyle.FillStyle = New NColorFillStyle(Color.White)
				groupNode.FillStyle = New NColorFillStyle(Color.Black)

				groupNode.StrokeStyle = New NStrokeStyle(1, Color.Black)

				groupNode.InteractivityStyle = New NInteractivityStyle(groupNode.Label)

				For Each sector As XmlElement In industry.ChildNodes
					Dim value As Double = Double.Parse(sector.Attributes("Size").Value)
					Dim change As Double = Double.Parse(sector.Attributes("Change").Value)
					Dim label As String = sector.Attributes("Name").Value

					Dim valueNode As New NValueTreeMapNode(value, change, label)

					valueNode.InteractivityStyle = New NInteractivityStyle(label)
					valueNode.StrokeStyle = New NStrokeStyle(1, Color.Black)
					valueNode.LabelTextStyle = New NTextStyle()
					valueNode.LabelTextStyle.FillStyle = New NColorFillStyle(Color.Black)

					groupNode.ChildNodes.Add(valueNode)
				Next sector
			Next industry

			LegendModeComboBox.FillFromEnum(GetType(TreeMapNodeLegendMode))
			LegendModeComboBox.SelectedIndex = CInt(TreeMapNodeLegendMode.GroupAndChildNodes)

			PaletteLegendModeComboBox.FillFromEnum(GetType(PaletteLegendMode))
			PaletteLegendModeComboBox.Enabled = False
			PaletteLegendModeComboBox.SelectedIndex = CInt(PaletteLegendMode.GradientAxis)
		End Sub
		''' <summary>
		''' Loads the data for the tree map
		''' </summary>
		''' <returns></returns>
		Private Function LoadData() As XmlDocument
			Dim stream As Stream = NResourceHelper.GetResourceStream(Me.GetType().Assembly, "TreeMapDataSmall.xml", "Nevron.Examples.Chart.WinForm.Resources")

			If stream Is Nothing Then
				Return Nothing
			End If

			Dim document As New XmlDocument()
			document.Load(stream)

			Return document
		End Function

		Private Sub LegendModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LegendModeComboBox.SelectedIndexChanged
			PaletteLegendModeComboBox.Enabled = (CType(LegendModeComboBox.SelectedIndex, TreeMapNodeLegendMode) = TreeMapNodeLegendMode.Palette)
			m_TreeMap.RootTreeMapNode.Legend.Mode = CType(LegendModeComboBox.SelectedIndex, TreeMapNodeLegendMode)

			For Each node As NGroupTreeMapNode In m_TreeMap.RootTreeMapNode.ChildNodes
				node.Legend.Mode = CType(LegendModeComboBox.SelectedIndex, TreeMapNodeLegendMode)
			Next node

			nChartControl1.Refresh()
		End Sub

		Private Sub PaletteLegendModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PaletteLegendModeComboBox.SelectedIndexChanged
			m_TreeMap.RootTreeMapNode.Legend.PaletteLegendMode = CType(PaletteLegendModeComboBox.SelectedIndex, PaletteLegendMode)

			For Each node As NGroupTreeMapNode In m_TreeMap.RootTreeMapNode.ChildNodes
				node.Legend.PaletteLegendMode = CType(PaletteLegendModeComboBox.SelectedIndex, PaletteLegendMode)
			Next node

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
