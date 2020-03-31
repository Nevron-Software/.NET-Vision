Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web

Imports Nevron.Diagram
Imports Nevron.Diagram.Maps
Imports Nevron.Diagram.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	Public Partial Class NWorldPopulationUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized Then
				Return
			End If

			' Init the diagram control
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

			' Create the default data grouping
			Dim dataGrouping As NDataGrouping = New NDataGroupingOptimal()
			dataGrouping.RoundedRanges = True

			' Init the document
			Dim document As NDrawingDocument = NThinDiagramControl1.Document
			document.BeginInit()
			Dim mapRenderer As MapRenderer = New MapRenderer()
			mapRenderer.InitDocument(document, dataGrouping)
			document.EndInit()
		End Sub

		#Region "Constants"

		Private Const CountriesShapefileName As String = "..\App_Data\Gis_Data\countries.shp"
		Private Const WhiteTextStyleSheetName As String = "WhiteText"

		#End Region

		#Region "Nested Types"

		<Serializable> _
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
				' Configure the drawing document
				document.Layers.RemoveAllChildren()
				document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
				document.RoutingManager.Enabled = False
				document.BridgeManager.Enabled = False
				document.Bounds = New NRectangleF(0, 0, 5000, 5000)
				document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)

				' Add a style sheet
				Dim styleSheet As NStyleSheet = New NStyleSheet(WhiteTextStyleSheetName)
				Dim textStyle As NTextStyle = CType(document.ComposeTextStyle().Clone(), NTextStyle)
				textStyle.FillStyle = New NColorFillStyle(KnownArgbColorValue.White)
				NStyle.SetTextStyle(styleSheet, textStyle)
				document.StyleSheets.AddChild(styleSheet)

				' Create a map importer
				Dim mapImporter As NEsriMapImporter = New NEsriMapImporter()
				mapImporter.MapBounds = NMapBounds.World

				' Add a shapefile
				Dim countries As NEsriShapefile = New NEsriShapefile(HttpContext.Current.Server.MapPath(CountriesShapefileName))
				countries.NameColumn = "NAME"
				countries.TextColumn = "NAME"
				mapImporter.AddLayer(countries)

				' Read the map data
				mapImporter.Read()

				' Create a fill rule
				Dim fillRule As NMapFillRuleRange = New NMapFillRuleRange("POP_1994", Color.White, Color.Black, 12)
				fillRule.DataGrouping = dataGrouping
				countries.FillRule = fillRule

				' Associate a shape created listener and import the map data
				mapImporter.ShapeCreatedListener = New NCustomShapeCreatedListener()
				mapImporter.Import(document, document.Bounds)

				' Generate a legend
				Dim mapLegend As NMapLegendRange = CType(mapImporter.GetLegend(fillRule), NMapLegendRange)
				mapLegend.Title = "Population (thousands people)"
				mapLegend.RangeFormatString = "{0:#,###,##0,} - {1:#,###,##0,}"
				mapLegend.LastFormatString = "more than {0:#,###,##0,}"
				NMapLegendRenderPage.MapLegend = mapLegend

				document.SizeToContent()
			End Sub
		End Class

		Private Class NCustomShapeCreatedListener
			Inherits NShapeCreatedListener
			Public Overrides Function OnPolygonLabelCreated(ByVal polygonLabel As NMapPolygonLabel, ByVal mapFeature As NMapFeature) As Boolean
				Dim master As NStyleableElement = CType(polygonLabel.MasterElement, NStyleableElement)
				Dim color As Color = master.ComposeFillStyle().GetPrimaryColor().ToColor()

				If color.R < 128 Then
					' Make the text of dark shape labels white
					polygonLabel.StyleSheetName = WhiteTextStyleSheetName
				End If

				Return True
			End Function
		End Class

		#End Region
	End Class
End Namespace