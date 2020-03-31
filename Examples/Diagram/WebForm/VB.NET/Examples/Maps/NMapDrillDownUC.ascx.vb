Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Web

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Maps
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	Public Partial Class NMapDrillDownUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized Then
				Return
			End If

			' Init the diagram control
			Dim mapRenderer As MapRenderer = New MapRenderer()

			' Configure the controller
			Dim serverMouseEventTool As NServerMouseEventTool = New NServerMouseEventTool()
			NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool)
			serverMouseEventTool.MouseDown = New NMouseDownEventCallback(mapRenderer)

			' Init the view
			NThinDiagramControl1.View.MinZoomFactor = 0.1f
			NThinDiagramControl1.View.MaxZoomFactor = 50
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit

			' Configure the controller
			NThinDiagramControl1.Controller.Tools.Add(New NTooltipTool())
			NThinDiagramControl1.Controller.Tools.Add(New NCursorTool())

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
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleTooltipToolAction()))

			' Init the document
			Dim document As NDrawingDocument = NThinDiagramControl1.Document
			document.BeginInit()
			Dim dataGrouping As NDataGrouping = New NDataGroupingOptimal()
			dataGrouping.RoundedRanges = True
			mapRenderer.InitDocument(document)
			document.EndInit()
		End Sub

		#Region "Constants"

		Private Const MapWidth As Integer = 1000
		Private Const MapHeight As Integer = 1000

		Private Const UsaShapefileName As String = "..\App_Data\Gis_Data\usa.shp"
		Private Const StatesFolder As String = "..\App_Data\Gis_Data\States"

		#End Region

		#Region "Nested Types"

		<Serializable> _
		Private Class NMouseDownEventCallback
			Implements INMouseEventCallback
			Public Sub New(ByVal mapRenderer As MapRenderer)
				m_MapRenderer = mapRenderer
			End Sub

			#Region "INMouseEventCallback Members"

			Private Sub OnMouseEvent(ByVal control As NAspNetThinWebControl, ByVal e As NBrowserMouseEventArgs) Implements INMouseEventCallback.OnMouseEvent
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim nodes As NNodeList = diagramControl.HitTest(New NPointF(e.X, e.Y))
				Dim shapes As NNodeList = nodes.Filter(NFilters.Shape2D)
				Dim document As NDrawingDocument = diagramControl.Document

				If String.IsNullOrEmpty(m_MapRenderer.CurrentState) Then
					If shapes.Count = 0 Then
						Return
					End If

					' The user has clicked a state
					Dim shape As NShape = CType(shapes(0), NShape)
					m_MapRenderer.LoadStateMap(document, shape.Name)
				Else
					If shapes.Count = 0 Then
						' Return to the States map
						m_MapRenderer.LoadUsaMap(document)
					Else
						' The user has clicked a county
						Dim shape As NShape = CType(shapes(0), NShape)
						If shape.StyleSheetName = "ClickedCounty" Then
							' The user has clicked a selected county - unselect it
							shape.StyleSheetName = String.Empty
							shape.Text = String.Empty
						Else
							' The user has clicked a non selected county - select it (make it red)
							shape.StyleSheetName = "ClickedCounty"
							shape.Text = shape.Name
						End If
					End If
				End If

				diagramControl.UpdateView()
			End Sub

			#End Region

			#Region "Fields"

			Private m_MapRenderer As MapRenderer

			#End Region
		End Class

		<Serializable> _
		Private Class MapRenderer
			Public Sub New()
				m_sCurrentState = Nothing
			End Sub

			Public ReadOnly Property CurrentState() As String
				Get
					Return m_sCurrentState
				End Get
			End Property

			Public Sub InitDocument(ByVal document As NDrawingDocument)
				' Set up visual formatting
				document.BackgroundStyle.FrameStyle.Visible = False
				document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)
				document.GraphicsSettings.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

				' Create style sheets
				Dim clickedCounty As NStyleSheet = New NStyleSheet("ClickedCounty")
				NStyle.SetFillStyle(clickedCounty, New NColorFillStyle(KnownArgbColorValue.Red))
				NStyle.SetTextStyle(clickedCounty, New NTextStyle(document.ComposeTextStyle().FontStyle, Color.White))
				document.StyleSheets.AddChild(clickedCounty)

				' Load the map of the USA
				LoadUsaMap(document)
			End Sub
			Public Sub LoadUsaMap(ByVal document As NDrawingDocument)
				m_sCurrentState = Nothing
				LoadMap(document, UsaShapefileName, "STATE_ABBR", "STATE_ABBR", "STATE_NAME", MapWidth, MapHeight)
			End Sub
			Public Sub LoadStateMap(ByVal document As NDrawingDocument, ByVal abbrStateName As String)
				m_sCurrentState = abbrStateName
				Dim fileName As String = Path.Combine(StatesFolder, abbrStateName)
				fileName = Path.Combine(fileName, abbrStateName & ".shp")
				LoadMap(document, fileName, "FIPS", Nothing, "NAME", MapWidth * 0.6f, MapHeight * 0.6f)
			End Sub

			Private Sub LoadMap(ByVal document As NDrawingDocument, ByVal fileName As String, ByVal nameColumn As String, ByVal textColumn As String, ByVal toolTipColumn As String, ByVal width As Single, ByVal height As Single)
				document.Layers.RemoveAllChildren()
				document.Width = width
				document.Height = height

				Dim mapImporter As NEsriMapImporter = New NEsriMapImporter()

				' Create the STATES shape file
				Dim countries As NEsriShapefile = New NEsriShapefile(HttpContext.Current.Server.MapPath(fileName))
				countries.NameColumn = nameColumn
				countries.TextColumn = textColumn
				mapImporter.AddLayer(countries)

				' Import the map
				mapImporter.Read()
				If String.IsNullOrEmpty(toolTipColumn) = False Then
					mapImporter.ShapeCreatedListener = New NCustomShapeCreatedListener(toolTipColumn)
				End If

				mapImporter.Import(document, document.Bounds)
				document.SizeToContent()
			End Sub

			Private m_sCurrentState As String
		End Class

		Private Class NCustomShapeCreatedListener
			Inherits NShapeCreatedListener
			Public Sub New(ByVal tooltipColumnName As String)
				m_sTooltipColumnName = tooltipColumnName
			End Sub

			Public Overrides Function OnPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Dim shape As NShape = TryCast(element, NShape)
				If Not shape Is Nothing Then
					Dim iStyle As NInteractivityStyle = New NInteractivityStyle(True, Nothing, mapFeature.GetAttributeValue(m_sTooltipColumnName).ToString())
					NStyle.SetInteractivityStyle(shape, iStyle)
				End If

				Return MyBase.OnPolygonCreated(element, mapFeature)
			End Function
			Public Overrides Function OnMultiPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Return OnPolygonCreated(element, mapFeature)
			End Function

			Private m_sTooltipColumnName As String
		End Class

		#End Region
	End Class
End Namespace