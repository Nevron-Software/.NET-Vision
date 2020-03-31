Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Xml
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NThreeMapUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumNames(VerticalFillModeDropDownList, GetType(TreeMapVerticalFillMode))
				VerticalFillModeDropDownList.SelectedIndex = CInt(Fix(TreeMapVerticalFillMode.Default))

				WebExamplesUtilities.FillComboWithEnumNames(HorizontalFillModeDropDownList, GetType(TreeMapHorizontalFillMode))
				HorizontalFillModeDropDownList.SelectedIndex = CInt(Fix(TreeMapVerticalFillMode.Default))

				ColorModeDropDownList.Items.Add("Custom")
				ColorModeDropDownList.Items.Add("Common Palette")
				ColorModeDropDownList.Items.Add("Group Palette")
				ColorModeDropDownList.SelectedIndex = 1
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False


			' set a chart title
			Dim title As NLabel = New NLabel("Tree Map")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.DockMode = PanelDockMode.Top
			nChartControl1.Panels.Add(title)

			Dim treeMap As NTreeMapChart = New NTreeMapChart()
			nChartControl1.Panels.Add(treeMap)
			treeMap.DockMode = PanelDockMode.Fill

			Dim document As XmlDocument = LoadData()

			For Each industry As XmlElement In document.DocumentElement
				Dim treeMapSeries As NGroupTreeMapNode = New NGroupTreeMapNode()

				treeMapSeries.StrokeStyle = New NStrokeStyle(4, Color.Black)
				treeMapSeries.Padding = New NMarginsL(2.0f)

				treeMap.RootTreeMapNode.ChildNodes.Add(treeMapSeries)

				treeMapSeries.Label = industry.Attributes("Name").Value
				treeMapSeries.InteractivityStyle = New NInteractivityStyle(treeMapSeries.Label)

				For Each company As XmlElement In industry.ChildNodes
					Dim value As Double = Double.Parse(company.Attributes("Size").Value)
					Dim change As Double = Double.Parse(company.Attributes("Change").Value)
					Dim label As String = company.Attributes("Name").Value

					Dim node As NValueTreeMapNode = New NValueTreeMapNode(value, change, label)
					node.InteractivityStyle = New NInteractivityStyle(label)
					'						node.FillStyle = new NColorFillStyle(Color.Green);
					treeMapSeries.ChildNodes.Add(node)
				Next company
			Next industry

			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, treeMap, title, Nothing)

			' update from from controls
			treeMap.RootTreeMapNode.HorizontalFillMode = CType(HorizontalFillModeDropDownList.SelectedIndex, TreeMapHorizontalFillMode)
			treeMap.RootTreeMapNode.VerticalFillMode = CType(VerticalFillModeDropDownList.SelectedIndex, TreeMapVerticalFillMode)

			Select Case ColorModeDropDownList.SelectedIndex
				Case 0
						' custom color filling -> assign colors to each group (child nodes will inherit that fill)
						Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Bright)

						Dim industryIndex As Integer = 0
						For Each industryTreeMapNode As NGroupTreeMapNode In treeMap.RootTreeMapNode.ChildNodes
							For Each companyTreeMapNode As NTreeMapNode In industryTreeMapNode.ChildNodes
								companyTreeMapNode.FillStyle = New NColorFillStyle(palette.SeriesColors((industryIndex) Mod palette.SeriesColors.Count))
							Next companyTreeMapNode

							industryIndex += 1
						Next industryTreeMapNode
				Case 1
						' palette filling -> remove all fill styles assigned to nodes
						For Each industryTreeMapNode As NGroupTreeMapNode In treeMap.RootTreeMapNode.ChildNodes
							industryTreeMapNode.Palette = Nothing

							For Each companyTreeMapNode As NTreeMapNode In industryTreeMapNode.ChildNodes
								companyTreeMapNode.FillStyle = Nothing
							Next companyTreeMapNode
						Next industryTreeMapNode
				Case 2
						' palette filling -> remove all fill styles assigned to nodes
						For Each industryTreeMapNode As NGroupTreeMapNode In treeMap.RootTreeMapNode.ChildNodes
							Dim palette As NPalette = New NPalette()
							palette.Mode = PaletteMode.AutoMinMaxColor
							industryTreeMapNode.Palette = palette

							For Each companyTreeMapNode As NTreeMapNode In industryTreeMapNode.ChildNodes
								companyTreeMapNode.FillStyle = Nothing
							Next companyTreeMapNode
						Next industryTreeMapNode
			End Select
		End Sub

		''' <summary>
		''' Loads the data for the tree map
		''' </summary>
		''' <returns></returns>
		Private Function LoadData() As XmlDocument
			Dim document As XmlDocument = New XmlDocument()

			document.Load(Me.MapPathSecure(Me.TemplateSourceDirectory & "\TreeMapDataSmall.xml"))

			Return document
		End Function

		Private Sub GenerateData(ByVal threeLineBreak As NThreeLineBreakSeries)
			Dim dataGenerator As NStockDataGenerator = New NStockDataGenerator(New NRange1DD(50, 350), 0.002, 2)
			dataGenerator.Reset()

			Dim dt As DateTime = New DateTime(2007, 1, 1)

			For i As Integer = 0 To 99
				threeLineBreak.Values.Add(dataGenerator.GetNextValue())
				threeLineBreak.XValues.Add(dt)

				dt = dt.AddDays(1)
			Next i
		End Sub
	End Class
End Namespace