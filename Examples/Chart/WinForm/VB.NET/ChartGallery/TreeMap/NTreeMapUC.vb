Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports System.Xml
Imports System.Reflection
Imports System.IO
Imports Nevron.UI
Imports Nevron.GraphicsCore
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Partial Public Class NTreeMapUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents VerticalFillModeComboBox As UI.WinForm.Controls.NComboBox
		Private WithEvents HorizontalFillModeComboBox As UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private label2 As Label
		Private label3 As Label
		Private WithEvents ColorFillModeComboBox As UI.WinForm.Controls.NComboBox
		Private m_TreeMap As NTreeMapChart

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
			Me.VerticalFillModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.HorizontalFillModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.ColorFillModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' VerticalFillModeComboBox
			' 
			Me.VerticalFillModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.VerticalFillModeComboBox.ListProperties.DataSource = Nothing
			Me.VerticalFillModeComboBox.ListProperties.DisplayMember = ""
			Me.VerticalFillModeComboBox.Location = New System.Drawing.Point(12, 34)
			Me.VerticalFillModeComboBox.Name = "VerticalFillModeComboBox"
			Me.VerticalFillModeComboBox.Size = New System.Drawing.Size(151, 21)
			Me.VerticalFillModeComboBox.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VerticalFillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalFillModeCombo_SelectedIndexChanged);
			' 
			' HorizontalFillModeComboBox
			' 
			Me.HorizontalFillModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.HorizontalFillModeComboBox.ListProperties.DataSource = Nothing
			Me.HorizontalFillModeComboBox.ListProperties.DisplayMember = ""
			Me.HorizontalFillModeComboBox.Location = New System.Drawing.Point(12, 85)
			Me.HorizontalFillModeComboBox.Name = "HorizontalFillModeComboBox"
			Me.HorizontalFillModeComboBox.Size = New System.Drawing.Size(151, 21)
			Me.HorizontalFillModeComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorizontalFillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalFillModeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 15)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(90, 13)
			Me.label1.TabIndex = 8
			Me.label1.Text = "Vertical Fill Mode:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 65)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(102, 13)
			Me.label2.TabIndex = 9
			Me.label2.Text = "Horizontal Fill Mode:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 118)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(79, 13)
			Me.label3.TabIndex = 11
			Me.label3.Text = "Color Fill Mode:"
			' 
			' ColorFillModeComboBox
			' 
			Me.ColorFillModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ColorFillModeComboBox.ListProperties.DataSource = Nothing
			Me.ColorFillModeComboBox.ListProperties.DisplayMember = ""
			Me.ColorFillModeComboBox.Location = New System.Drawing.Point(12, 138)
			Me.ColorFillModeComboBox.Name = "ColorFillModeComboBox"
			Me.ColorFillModeComboBox.Size = New System.Drawing.Size(151, 21)
			Me.ColorFillModeComboBox.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColorFillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorFillModeComboBox_SelectedIndexChanged);
			' 
			' NTreeMapUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.ColorFillModeComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.HorizontalFillModeComboBox)
			Me.Controls.Add(Me.VerticalFillModeComboBox)
			Me.Name = "NTreeMapUC"
			Me.Size = New System.Drawing.Size(178, 350)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()
			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			' set a chart title
			Dim title As New NLabel("Tree Map")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.DockMode = PanelDockMode.Top
			nChartControl1.Panels.Add(title)

			m_TreeMap = New NTreeMapChart()
			nChartControl1.Panels.Add(m_TreeMap)
			m_TreeMap.DockMode = PanelDockMode.Fill

			Dim document As XmlDocument = LoadData()

			For Each industry As XmlElement In document.DocumentElement
				Dim treeMapSeries As New NGroupTreeMapNode()

				treeMapSeries.StrokeStyle = New NStrokeStyle(4, Color.Black)
				treeMapSeries.Padding = New NMarginsL(2.0F)

				m_TreeMap.RootTreeMapNode.ChildNodes.Add(treeMapSeries)

				treeMapSeries.Label = industry.Attributes("Name").Value
				treeMapSeries.InteractivityStyle = New NInteractivityStyle(treeMapSeries.Label)

				For Each company As XmlElement In industry.ChildNodes
					Dim value As Double = Double.Parse(company.Attributes("Size").Value)
					Dim change As Double = Double.Parse(company.Attributes("Change").Value)
					Dim label As String = company.Attributes("Name").Value

					Dim node As New NValueTreeMapNode(value, change, label)
					node.InteractivityStyle = New NInteractivityStyle(label)
					'						node.FillStyle = new NColorFillStyle(Color.Green);
					treeMapSeries.ChildNodes.Add(node)
				Next company
			Next industry

			VerticalFillModeComboBox.FillFromEnum(GetType(TreeMapVerticalFillMode))
			VerticalFillModeComboBox.SelectedIndex = CInt(TreeMapVerticalFillMode.Default)

			HorizontalFillModeComboBox.FillFromEnum(GetType(TreeMapHorizontalFillMode))
			HorizontalFillModeComboBox.SelectedIndex = CInt(TreeMapVerticalFillMode.Default)

			ColorFillModeComboBox.Items.Add("Custom")
			ColorFillModeComboBox.Items.Add("Common Palette")
			ColorFillModeComboBox.Items.Add("Group Palette")
			ColorFillModeComboBox.SelectedIndex = 1
		End Sub
		''' <summary>
		''' Loads the data for the tree map
		''' </summary>
		''' <returns></returns>
		Private Function LoadData() As XmlDocument
			Dim stream As Stream = NResourceHelper.GetResourceStream(Me.GetType().Assembly, "TreeMapData.xml", "Nevron.Examples.Chart.WinForm.Resources")

			If stream Is Nothing Then
				Return Nothing
			End If

			Dim document As New XmlDocument()
			document.Load(stream)

			Return document
		End Function

		Private Sub VerticalFillModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VerticalFillModeComboBox.SelectedIndexChanged
			m_TreeMap.RootTreeMapNode.VerticalFillMode = CType(VerticalFillModeComboBox.SelectedIndex, TreeMapVerticalFillMode)
			nChartControl1.Refresh()
		End Sub

		Private Sub HorizontalFillModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HorizontalFillModeComboBox.SelectedIndexChanged
			m_TreeMap.RootTreeMapNode.HorizontalFillMode = CType(HorizontalFillModeComboBox.SelectedIndex, TreeMapHorizontalFillMode)
			nChartControl1.Refresh()
		End Sub

		Private Sub ColorFillModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ColorFillModeComboBox.SelectedIndexChanged
			Select Case ColorFillModeComboBox.SelectedIndex
				Case 0
						' custom color filling -> assign colors to each group (child nodes will inherit that fill)
						Dim palette As New NChartPalette(ChartPredefinedPalette.Bright)

						Dim industryIndex As Integer = 0
						For Each industryTreeMapNode As NGroupTreeMapNode In m_TreeMap.RootTreeMapNode.ChildNodes
							For Each companyTreeMapNode As NTreeMapNode In industryTreeMapNode.ChildNodes
								companyTreeMapNode.FillStyle = New NColorFillStyle(palette.SeriesColors((industryIndex) Mod palette.SeriesColors.Count))
							Next companyTreeMapNode

							industryIndex += 1
						Next industryTreeMapNode
				Case 1
						' palette filling -> remove all fill styles assigned to nodes
						For Each industryTreeMapNode As NGroupTreeMapNode In m_TreeMap.RootTreeMapNode.ChildNodes
							industryTreeMapNode.Palette = Nothing

							For Each companyTreeMapNode As NTreeMapNode In industryTreeMapNode.ChildNodes
								companyTreeMapNode.FillStyle = Nothing
							Next companyTreeMapNode
						Next industryTreeMapNode
				Case 2
						' palette filling -> remove all fill styles assigned to nodes
						For Each industryTreeMapNode As NGroupTreeMapNode In m_TreeMap.RootTreeMapNode.ChildNodes
							Dim palette As New NPalette()
							palette.Mode = PaletteMode.AutoMinMaxColor
							industryTreeMapNode.Palette = palette

							For Each companyTreeMapNode As NTreeMapNode In industryTreeMapNode.ChildNodes
								companyTreeMapNode.FillStyle = Nothing
							Next companyTreeMapNode
						Next industryTreeMapNode
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
