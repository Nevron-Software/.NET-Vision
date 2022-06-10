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
	Partial Public Class NTreeMapDrillDownUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents GoBackToTopLevelButton As Nevron.UI.WinForm.Controls.NButton
		Private m_TreeMap As NTreeMapChart
		Private m_OrgRootNode As NGroupTreeMapNode

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
			Me.GoBackToTopLevelButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' GoBackToTopLevelButton
			' 
			Me.GoBackToTopLevelButton.Location = New System.Drawing.Point(12, 17)
			Me.GoBackToTopLevelButton.Name = "GoBackToTopLevelButton"
			Me.GoBackToTopLevelButton.Size = New System.Drawing.Size(152, 23)
			Me.GoBackToTopLevelButton.TabIndex = 0
			Me.GoBackToTopLevelButton.Text = "Go Back To Top Level"
			Me.GoBackToTopLevelButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GoBackToTopLevelButton.Click += new System.EventHandler(this.GoBackToTopLevelButton_Click);
			' 
			' NTreeMapDrillDownUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.GoBackToTopLevelButton)
			Me.Name = "NTreeMapDrillDownUC"
			Me.Size = New System.Drawing.Size(178, 350)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()
			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			' set a chart title
			Dim title As New NLabel("Tree Map - Drill Down")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.DockMode = PanelDockMode.Top
			nChartControl1.Panels.Add(title)

			m_TreeMap = New NTreeMapChart()
			nChartControl1.Panels.Add(m_TreeMap)
			m_TreeMap.DockMode = PanelDockMode.Fill

			m_OrgRootNode = m_TreeMap.RootTreeMapNode

			Dim document As XmlDocument = LoadData()

			For Each industry As XmlElement In document.DocumentElement
				Dim groupNode As New NGroupTreeMapNode()
				groupNode.StrokeStyle = New NStrokeStyle(1.0F, Color.Green)
				groupNode.Padding = New NMarginsL(2.0F)

				m_TreeMap.RootTreeMapNode.ChildNodes.Add(groupNode)

				groupNode.Label = industry.Attributes("Name").Value
				groupNode.InteractivityStyle = New NInteractivityStyle(groupNode.Label)

				For Each company As XmlElement In industry.ChildNodes
					Dim value As Double = Double.Parse(company.Attributes("Size").Value)
					Dim change As Double = Double.Parse(company.Attributes("Change").Value)
					Dim label As String = company.Attributes("Name").Value

					Dim valueNode As New NValueTreeMapNode(value, change, label)
					valueNode.InteractivityStyle = New NInteractivityStyle(label)
					groupNode.ChildNodes.Add(valueNode)
				Next company
			Next industry

			AddHandler nChartControl1.MouseClick, AddressOf nChartControl1_MouseClick
		End Sub

		Private Sub nChartControl1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If result.ChartElement = ChartElement.TreeMapNode Then
				Dim groupNode As NGroupTreeMapNode = result.GroupTreeMapNode

				If groupNode IsNot Nothing AndAlso groupNode.ParentNode IsNot Nothing Then
					m_TreeMap.RootTreeMapNode = DirectCast(groupNode.Clone(), NGroupTreeMapNode)

					' assign palette to this node
					Dim palette As New NPalette()

					palette.Mode = PaletteMode.AutoMinMaxColor
					palette.SmoothPalette = True
					m_TreeMap.RootTreeMapNode.Palette = palette

					nChartControl1.Refresh()
				End If
			End If
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub GoBackToTopLevelButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GoBackToTopLevelButton.Click
			m_TreeMap.RootTreeMapNode = m_OrgRootNode
			nChartControl1.Refresh()
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
	End Class
End Namespace
