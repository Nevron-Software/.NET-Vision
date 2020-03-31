Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web

Imports Nevron.Diagram
Imports Nevron.Diagram.Maps
Imports Nevron.Diagram.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	Public Partial Class NMapDataBindingUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized Then
				Return
			End If

			' Init the diagram control
			Dim serializationCallback As CustomSerializationCallback = New CustomSerializationCallback()
			NThinDiagramControl1.DocumentSerializationCallback = serializationCallback
			NThinDiagramControl1.CustomRequestCallback = New CustomRequestCallback()

			' Set manual ID so that it can be referenced in JavaScript
			NThinDiagramControl1.StateId = "Diagram1"

			' Init the view
			NThinDiagramControl1.View.MinZoomFactor = 0.1f
			NThinDiagramControl1.View.MaxZoomFactor = 50
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit

			' Configure the controller
			NThinDiagramControl1.Controller.Tools.Add(New NTooltipTool())
			NThinDiagramControl1.Controller.Tools.Add(New NCursorTool())
			NThinDiagramControl1.Controller.Tools.Add(New NRectZoomTool())
			Dim panTool As NPanTool = New NPanTool()
			panTool.Enabled = False
			NThinDiagramControl1.Controller.Tools.Add(panTool)

			' Configure the toolbar
			NThinDiagramControl1.Toolbar.Visible = True
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomInAction()))
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomOutAction()))
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())

			Dim values As Array = System.Enum.GetValues(GetType(CanvasLayout))
			Dim i As Integer = 0
			Do While i < values.Length
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleViewLayoutAction(CType(values.GetValue(i), CanvasLayout))))
				i += 1
			Loop

			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NTogglePanToolAction()))
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleRectZoomToolAction()))

			' Render the map
			serializationCallback.Deserialize(NThinDiagramControl1)
		End Sub

		#Region "Constants"

		Private Const CountriesShapefileName As String = "..\App_Data\Gis_Data\countries.shp"
		Private Const SalesXmlFileName As String = "..\App_Data\sales.xml"

		#End Region

		#Region "Nested Types"

		<Serializable> _
		Private Class CustomSerializationCallback
			Implements INDrawingDocumentSerializationCallback
#Region "INDrawingDocumentSerializationCallback Members"

			Public Function Deserialize(ByVal control As NThinDiagramControl) As NDrawingDocument Implements INDrawingDocumentSerializationCallback.Deserialize
				If m_Document Is Nothing Then
					' Create the default data grouping
					Dim dataGrouping As NDataGrouping = New NDataGroupingOptimal()
					dataGrouping.RoundedRanges = True

					' Init the document
					m_Document = New NDrawingDocument()
					m_Document.BeginInit()
					Dim mapRenderer As MapRenderer = New MapRenderer()
					mapRenderer.InitDocument(m_Document, dataGrouping)
					m_Document.EndInit()
				End If

				Return m_Document
			End Function
			Public Sub Serialize(ByVal control As NThinDiagramControl, ByVal document As NDrawingDocument) Implements INDrawingDocumentSerializationCallback.Serialize
			End Sub

#End Region

#Region "Fields"

			<NonSerialized()> _
			Private m_Document As NDrawingDocument

#End Region
		End Class

		<Serializable()> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim args As String() = argument.Split(","c)
				Dim dataGrouping As NDataGrouping = Nothing

				Select Case args(0)
					Case "EqualDistribution"
						dataGrouping = New NDataGroupingEqualDistribution()
					Case "EqualInterval"
						dataGrouping = New NDataGroupingEqualInterval()
					Case "Optimal"
						dataGrouping = New NDataGroupingOptimal()
					Case Else
						Throw New Exception("New data grouping type?")
				End Select

				dataGrouping.RoundedRanges = Boolean.Parse(args(1))

				Dim mapRenderer As MapRenderer = New MapRenderer()
				mapRenderer.InitDocument(diagramControl.Document, dataGrouping)

				diagramControl.UpdateView()
				diagramControl.AddCustomClientCommand("UpdateLegend")
			End Sub
		End Class

		Private Class MapRenderer
			Public Sub InitDocument(ByVal document As NDrawingDocument, ByVal dataGrouping As NDataGrouping)
				document.Layers.RemoveAllChildren()
				document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
				document.RoutingManager.Enabled = False
				document.BridgeManager.Enabled = False
				document.Bounds = New NRectangleF(0, 0, 5000, 5000)
				document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)

				Dim mapImporter As NEsriMapImporter = New NEsriMapImporter()
				mapImporter.MapBounds = NMapBounds.World

				Dim countries As NEsriShapefile = New NEsriShapefile(HttpContext.Current.Server.MapPath(CountriesShapefileName))
				countries.NameColumn = "NAME"
				countries.TextColumn = "NAME"
				mapImporter.AddLayer(countries)

				mapImporter.Read()

				' Load the data
				Dim dataSet As DataSet = New DataSet()
				dataSet.ReadXml(HttpContext.Current.Server.MapPath(SalesXmlFileName), XmlReadMode.ReadSchema)

				' Create a data binding source
				Dim source As NMapDataTableBindingSource = New NMapDataTableBindingSource(dataSet.Tables("Sales"))

				' Create a data binding context
				Dim context As NMapDataBindingContext = New NMapDataBindingContext()
				context.AddColumnMatching("NAME", "Country")
				context.ColumnsToImport.Add("Sales")

				' Perform the data binding
				countries.DataBind(source, context)

				' Add a fill rule
				Dim fillRule As NMapFillRuleRange = New NMapFillRuleRange("Sales", Color.White, Color.DarkGreen, 8)
				fillRule.DataGrouping = dataGrouping
				countries.FillRule = fillRule

				mapImporter.Import(document, document.Bounds)

				' Generate the legend
				Dim mapLegend As NMapLegendRange = CType(mapImporter.GetLegend(fillRule), NMapLegendRange)
				mapLegend.Title = "Sales"
				mapLegend.RangeFormatString = "{0:N0} - {1:N0} million dollars"
				mapLegend.LastFormatString = "{0:N0} million dollars and more"
				NMapLegendRenderPage.MapLegend = mapLegend

				document.SizeToContent()
			End Sub
		End Class

		#End Region
	End Class
End Namespace