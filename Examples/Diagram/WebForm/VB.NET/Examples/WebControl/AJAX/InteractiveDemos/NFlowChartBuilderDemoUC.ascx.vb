Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.WebForm
Imports Nevron.Diagram.DataStructures

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NFlowChartBuilderDemoUC.
	''' </summary>
	Public Partial Class NFlowChartBuilderDemoUC
		Inherits NDiagramExampleUC
		Private Shared ReadOnly documentBackgroundColor As Color = Color.FromArgb(&Hf4, &Hf2, &Hf4)
		Private Shared ReadOnly documentSelectedShapeBorderColor As Color = Color.LimeGreen
		Private Shared ReadOnly libraryFillColor As Color = Color.White
		Private Shared ReadOnly libraryBorderColor As Color = Color.FromArgb(&H44, &H5a, &H6c)
		Private Shared ReadOnly libraryHighlightFillColor As Color = Color.FromArgb(&Hfb, &Hcb, &H9c)
		Private Shared ReadOnly libraryHighlightBorderColor As Color = Color.FromArgb(&H44, &H5a, &H6c)

		Private Shared toolbarButtons As ToolbarButton() = New ToolbarButton() { New ToolbarButton("Create Shape", "createShape", "NewShapeIcon.BMP", New NSize(14, 16), False), New ToolbarButton("Move/Select Shape", "moveSelect", "MoveShapeIcon.BMP", New NSize(12, 12), False), New ToolbarButton("Connect Two Shapes", "connect", "ConnectShapesIcon.BMP", New NSize(13, 16), False), New ToolbarButton("Delete Shape", "delete", "DeleteShapeIcon.BMP", New NSize(12, 12), False), New ToolbarButton(), New ToolbarButton("Change Shape Text", "text", "EditTextIcon.BMP", New NSize(12, 12), True), New ToolbarButton("Undo", "undo", "UndoIcon.BMP", New NSize(15, 16), True), New ToolbarButton("Redo", "redo", "RedoIcon.BMP", New NSize(15, 16), True), New ToolbarButton(), New ToolbarButton(), New ToolbarButton(), New ToolbarButton(), New ToolbarButton("Apply Fill Style", "fill:98fb98", Color.PaleGreen), New ToolbarButton("Apply Fill Style", "fill:b0e0b6", Color.PowderBlue), New ToolbarButton("Apply Fill Style", "fill:ffd700", Color.Gold), New ToolbarButton("Apply Fill Style", "fill:fa8072", Color.Salmon), New ToolbarButton("Apply Fill Style", "fill:ffb6c1", Color.LightPink), New ToolbarButton("Apply Fill Style", "fill:ffffff", Color.White), New ToolbarButton("Apply Fill Style", "fill:fbcb9c", Color.FromArgb(&Hfb, &Hcb, &H9c)) }

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			InitToolbar()
			InitLibrary()
			InitDocument()
		End Sub

		#Region "Library"

		<Serializable> _
		Public Class LibraryHttpHandlerCallback
			Inherits NHttpHandlerCallback
			Public Overrides Sub OnAsyncClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				Dim clickedNodes As NNodeList = diagramState.HitTest(args)
				Dim clickedShapes As NNodeList = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)

				Dim shapes As NNodeList = diagramState.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)
				Dim length As Integer = shapes.Count
				Dim i As Integer = 0
				Do While i < length
					Dim s As NShape = TryCast(shapes(i), NShape)
					s.Style.FillStyle = Nothing
					s.Style.StrokeStyle = Nothing
					s.Style.ShadowStyle = Nothing
					s.Tag = Nothing
					i += 1
				Loop

				If clickedShapes.Count = 0 Then
					Return
				End If

				Dim clickedShape As NShape = TryCast(clickedShapes(0), NShape)
				clickedShape.Style.FillStyle = New NColorFillStyle(libraryHighlightFillColor)
				clickedShape.Style.StrokeStyle = New NStrokeStyle(libraryHighlightBorderColor)
				clickedShape.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(90, Color.Black), New NPointL(2, 1))
				clickedShape.Tag = "selected"
			End Sub
		End Class

		Private Sub InitLibrary()
			nDrawingViewLibrary.HttpHandlerCallback = New LibraryHttpHandlerCallback()

			If nDrawingViewLibrary.RequiresInitialization Then
				' begin view init
				nDrawingViewLibrary.ViewLayout = CanvasLayout.Normal
				nDrawingViewLibrary.DocumentPadding = New Nevron.Diagram.NMargins(10)

				' init document
				nDrawingViewLibrary.Document.BeginInit()

				nDrawingViewLibrary.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
				nDrawingViewLibrary.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
				nDrawingViewLibrary.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality

				' set up visual formatting
				nDrawingViewLibrary.Document.BackgroundStyle.FillStyle = New NColorFillStyle(documentBackgroundColor)
				nDrawingViewLibrary.Document.Style.FillStyle = New NColorFillStyle(libraryFillColor)
				nDrawingViewLibrary.Document.Style.StrokeStyle = New NStrokeStyle(libraryBorderColor)
				nDrawingViewLibrary.Document.Style.TextStyle.FontStyle.InitFromFont(New Font("Arial Narrow", 8))

				nDrawingViewLibrary.Document.BackgroundStyle.FrameStyle.Visible = False

				Dim factory As NFlowChartingShapesFactory = New NFlowChartingShapesFactory(nDrawingViewLibrary.Document)
				factory.DefaultSize = New NSizeF(76, 51)
				Dim count As Integer = factory.ShapesCount
				Dim i As Integer = 0
				Do While i < count
					' create a basic shape
					Dim shape As NShape = factory.CreateShape(i)

					' enable interactivity
					shape.Style.InteractivityStyle = New NInteractivityStyle(True, i.ToString(), shape.Name, CursorType.Hand)

					' add it to the active layer
					nDrawingViewLibrary.Document.ActiveLayer.AddChild(shape)

					' select the first shape
					If i = 0 Then
						shape.Style.FillStyle = New NColorFillStyle(libraryHighlightFillColor)
						shape.Style.StrokeStyle = New NStrokeStyle(libraryHighlightBorderColor)
						shape.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(90, Color.Black), New NPointL(2, 1))
						shape.Tag = "selected"
					End If
					i += 1
				Loop

				' layout the shapes in the active layer using a table layout
				Dim layout As NTableLayout = New NTableLayout()

				' setup the table layout
				layout.Direction = LayoutDirection.LeftToRight
				layout.ConstrainMode = CellConstrainMode.Ordinal
				layout.MaxOrdinal = 1
				layout.VerticalSpacing = 20

				' create a layout context
				Dim layoutContext As NLayoutContext = New NLayoutContext()
				layoutContext.GraphAdapter = New NShapeGraphAdapter()
				layoutContext.BodyAdapter = New NShapeBodyAdapter(nDrawingViewLibrary.Document)
				layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(nDrawingViewLibrary.Document)

				' layout the shapes
				layout.Layout(nDrawingViewLibrary.Document.ActiveLayer.Children(Nothing), layoutContext)

				' resize document to fit all shapes
				nDrawingViewLibrary.SizeToContent()

				nDrawingViewLibrary.Document.EndInit()
			End If
		End Sub

		Protected Sub nDrawingViewLibrary_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			nDrawingViewLibrary.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True, True))
			nDrawingViewLibrary.AjaxTools.Add(New NAjaxDynamicCursorTool(True))
			nDrawingViewLibrary.AjaxTools.Add(New NAjaxTooltipTool(True))
		End Sub

		#End Region

		#Region "Document"

		Private Sub InitDocument()
			If nDrawingViewDocument.RequiresInitialization Then
				nDrawingViewDocument.Document.HistoryService.Stop()
				Try
					SelectedShapeId = Guid.Empty

					'	configure the view
					nDrawingViewDocument.ViewLayout = CanvasLayout.Normal
					nDrawingViewDocument.DocumentPadding = New Nevron.Diagram.NMargins(10)

					'	remove the frame border
					nDrawingViewDocument.Document.BackgroundStyle.FrameStyle.Visible = False

					'	configure the document
					nDrawingViewDocument.Document.BackgroundStyle.FillStyle = New NColorFillStyle(documentBackgroundColor)
					nDrawingViewDocument.Width = New Unit(nDrawingViewDocument.Width.Value * 2)
					nDrawingViewDocument.Height = New Unit(nDrawingViewDocument.Height.Value * 2)
					nDrawingViewDocument.Document.Width = CSng(nDrawingViewDocument.Dimensions.Width)
					nDrawingViewDocument.Document.Height = CSng(nDrawingViewDocument.Dimensions.Height)

					'	configure interactivity
					nDrawingViewDocument.AsyncClickEventQueueLength = 10
				Finally
					nDrawingViewDocument.Document.HistoryService.Start()
				End Try
			End If
		End Sub

		Protected Sub nDrawingViewDocument_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			nDrawingViewDocument.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True, False))
			nDrawingViewDocument.AjaxTools.Add(New NAjaxDynamicCursorTool(True))
		End Sub

		Protected Sub nDrawingViewDocument_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
			Dim command As String = ActiveCommand
			Dim button As ToolbarButton = GetButtonByCommand(command)
			If command.StartsWith("fill:") Then
				command = "fill"
			End If

			Select Case command
				Case "createShape"
					CreateShape(args)
				Case "moveSelect"
					MoveOrSelect(args)
				Case "connect"
					Connect(args)
				Case "delete"
					Delete(args)
				Case "fill"
					Fill(args, button.Color)
			End Select
		End Sub

		Protected Sub nDrawingViewDocument_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Select Case args.Command.Name
				Case "undo"
					Try
						nDrawingViewDocument.Document.HistoryService.Undo()
						nDrawingViewDocument.Document.UpdateAllViews()
					Catch ex As Exception
						System.Diagnostics.Debug.WriteLine("nDrawingViewDocument_AsyncCustomCommand, undo: " & ex.Message)
					End Try
				Case "redo"
					Try
						nDrawingViewDocument.Document.HistoryService.Redo()
						nDrawingViewDocument.Document.UpdateAllViews()
					Catch ex As Exception
						System.Diagnostics.Debug.WriteLine("nDrawingViewDocument_AsyncCustomCommand, redo: " & ex.Message)
					End Try
				Case "text"
					Try
						Dim selectedShape As NShape = TryCast(nDrawingViewDocument.Document.ActiveLayer.GetChildFromUniqueId(SelectedShapeId), NShape)
						If selectedShape Is Nothing Then
							Exit Try
						End If
						Dim text As String = TryCast(args.Command.Arguments("text"), String)
						If text Is Nothing Then
							Exit Try
						End If
						selectedShape.Text = text
					Catch ex As Exception
						System.Diagnostics.Debug.WriteLine("nDrawingViewDocument_AsyncCustomCommand, redo: " & ex.Message)
					End Try
			End Select
		End Sub

		Protected Sub nDrawingViewDocument_AsyncQueryCommandResult(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackQueryCommandResultArgs = TryCast(e, NCallbackQueryCommandResultArgs)
			Dim resultBuilder As NAjaxXmlTransportBuilder = args.ResultBuilder

			Select Case args.Command.Name
				Case "undo", "redo", "text"
					'	add a built-in data section that will enforce full image refresh at the client
					If (Not resultBuilder.ContainsRedrawDataSection()) Then
						resultBuilder.AddRedrawDataSection(nDrawingViewDocument)
					End If
			End Select
		End Sub

		Private Sub CreateShape(ByVal args As NCallbackMouseEventArgs)
			nDrawingViewDocument.Document.HistoryService.StartTransaction("CreateShape")
			Try
				'	create the new shape
				Dim shapes As NNodeList = nDrawingViewLibrary.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)
				Dim length As Integer = shapes.Count
				Dim newShape As NShape = Nothing
				Dim i As Integer = 0
				Do While i < length
					Dim s As NShape = TryCast(shapes(i), NShape)
					If Not s.Tag Is Nothing AndAlso s.Tag.ToString() = "selected" Then
						newShape = TryCast(s.CloneWithNewUniqueId(New Hashtable()), NShape)
						newShape.Center = New NPointF(args.Point.X, args.Point.Y)
						nDrawingViewDocument.Document.ActiveLayer.AddChild(newShape)
						Exit Do
					End If
					i += 1
				Loop

				If newShape Is Nothing Then
					Return
				End If

				'	select the new shape
				Dim docShapes As NNodeList = nDrawingViewDocument.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)
				length = docShapes.Count
				i = 0
				Do While i < length
					Dim s As NShape = TryCast(docShapes(i), NShape)
					If s.UniqueId = newShape.UniqueId Then
						s.Style.StrokeStyle = New NStrokeStyle(2, documentSelectedShapeBorderColor)
					Else
						s.Style.StrokeStyle = Nothing
					End If
					i += 1
				Loop
				SelectedShapeId = newShape.UniqueId
			Finally
				nDrawingViewDocument.Document.HistoryService.Commit()
			End Try
		End Sub

		Private Sub MoveOrSelect(ByVal args As NCallbackMouseEventArgs)
			Dim clickedNodes As NNodeList = nDrawingViewDocument.HitTest(args)
			Dim clickedShapes As NNodeList = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
			If clickedShapes.Count = 0 Then
				'	move the shape, if one is selected
				nDrawingViewDocument.Document.HistoryService.StartTransaction("Move")
				Try
					If SelectedShapeId = Guid.Empty Then
						Return
					End If

					Dim selectedShape As NShape = TryCast(nDrawingViewDocument.Document.ActiveLayer.GetChildFromUniqueId(SelectedShapeId), NShape)
					selectedShape.Center = New NPointF(args.Point.X, args.Point.Y)
				Finally
					nDrawingViewDocument.Document.HistoryService.Commit()
				End Try
			Else
				'	select a shape
				nDrawingViewDocument.Document.HistoryService.Pause()
				Try
					Dim clickedShape As NShape = TryCast(clickedShapes(clickedShapes.Count - 1), NShape)
					Dim selectedShape As NShape = TryCast(nDrawingViewDocument.Document.ActiveLayer.GetChildFromUniqueId(SelectedShapeId), NShape)
					If clickedShape Is selectedShape Then
						selectedShape.Style.StrokeStyle = Nothing
						SelectedShapeId = Guid.Empty
						Return
					End If

					Dim shapes As NNodeList = nDrawingViewDocument.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)
					Dim length As Integer = shapes.Count
					Dim i As Integer = 0
					Do While i < length
						Dim s As NShape = TryCast(shapes(i), NShape)
						If s.UniqueId = clickedShape.UniqueId Then
							s.Style.StrokeStyle = New NStrokeStyle(2, documentSelectedShapeBorderColor)
						Else
							s.Style.StrokeStyle = Nothing
						End If
						i += 1
					Loop
					SelectedShapeId = clickedShape.UniqueId
				Finally
					nDrawingViewDocument.Document.HistoryService.Resume()
				End Try
			End If
		End Sub

		Private Sub Connect(ByVal args As NCallbackMouseEventArgs)
			Dim clickedNodes As NNodeList = nDrawingViewDocument.HitTest(args)
			Dim clickedShapes As NNodeList = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
			If clickedShapes.Count = 0 Then
				Return
			End If
			Dim clickedShape As NShape
			If SelectedShapeId = Guid.Empty Then
				'	select a shape
				nDrawingViewDocument.Document.HistoryService.Pause()
				Try
					clickedShape = TryCast(clickedShapes(clickedShapes.Count - 1), NShape)
					Dim shapes As NNodeList = nDrawingViewDocument.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)
					Dim length As Integer = shapes.Count
					Dim i As Integer = 0
					Do While i < length
						Dim s As NShape = TryCast(shapes(i), NShape)
						If s.UniqueId = clickedShape.UniqueId Then
							s.Style.StrokeStyle = New NStrokeStyle(2, documentSelectedShapeBorderColor)
						Else
							s.Style.StrokeStyle = Nothing
						End If
						i += 1
					Loop
					SelectedShapeId = clickedShape.UniqueId
					Return
				Finally
					nDrawingViewDocument.Document.HistoryService.Resume()
				End Try
			End If

			Dim selectedShape As NShape = TryCast(nDrawingViewDocument.Document.ActiveLayer.GetChildFromUniqueId(SelectedShapeId), NShape)

			nDrawingViewDocument.Document.HistoryService.StartTransaction("Connect")
			Try
				'	connect shapes
				clickedShape = TryCast(clickedShapes(clickedShapes.Count - 1), NShape)

				Dim connector As NRoutableConnector = New NRoutableConnector(RoutableConnectorType.DynamicHV)
				nDrawingViewDocument.Document.ActiveLayer.AddChild(connector)
				connector.StyleSheetName = "Connectors"
				connector.FromShape = selectedShape
				connector.ToShape = clickedShape
				connector.RerouteAutomatically = RerouteAutomatically.Always

				If connector.IsReflexive Then
					connector.Reflex()
				Else
					connector.Reroute()
				End If
			Finally
				nDrawingViewDocument.Document.HistoryService.Commit()
			End Try

			'	deselect the shape
			nDrawingViewDocument.Document.HistoryService.Pause()
			Try
				selectedShape.Style.StrokeStyle = Nothing
				SelectedShapeId = Guid.Empty
			Finally
				nDrawingViewDocument.Document.HistoryService.Resume()
			End Try
		End Sub

		Private Sub Delete(ByVal args As NCallbackMouseEventArgs)
			nDrawingViewDocument.Document.HistoryService.StartTransaction("Delete")
			Try
				Dim clickedNodes As NNodeList = nDrawingViewDocument.HitTest(args)
				Dim clickedShapes As NNodeList = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
				If clickedShapes.Count <> 0 Then
					Dim clickedShape As NShape = TryCast(clickedShapes(clickedShapes.Count - 1), NShape)
					nDrawingViewDocument.Document.ActiveLayer.RemoveChild(clickedShape)
				Else
					Dim clickedConnectors As NNodeList = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape1D)
					If clickedConnectors.Count <> 0 Then
						Dim clickedConnector As NShape = TryCast(clickedConnectors(clickedConnectors.Count - 1), NShape)
						nDrawingViewDocument.Document.ActiveLayer.RemoveChild(clickedConnector)
					End If
				End If
			Finally
				nDrawingViewDocument.Document.HistoryService.Commit()
			End Try
		End Sub

		Private Sub Fill(ByVal args As NCallbackMouseEventArgs, ByVal c As Color)
			nDrawingViewDocument.Document.HistoryService.StartTransaction("Fill")
			Try
				Dim clickedNodes As NNodeList = nDrawingViewDocument.HitTest(args)
				Dim clickedShapes As NNodeList = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
				If clickedShapes.Count = 0 Then
					Return
				End If
				Dim clickedShape As NShape = TryCast(clickedShapes(clickedShapes.Count - 1), NShape)
				clickedShape.Style.FillStyle = New NColorFillStyle(c)
			Finally
				nDrawingViewDocument.Document.HistoryService.Commit()
			End Try
		End Sub

		#End Region

		#Region "Toolbar"

		<Serializable> _
		Public Class ToolbarButton
'INSTANT VB NOTE: The parameter title was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter commandName was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter iconFile was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter iconSize was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter isClientSide was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal title_Renamed As String, ByVal commandName_Renamed As String, ByVal iconFile_Renamed As String, ByVal iconSize_Renamed As NSize, ByVal isClientSide_Renamed As Boolean)
				Me.Title = title_Renamed
				Me.CommandName = commandName_Renamed
				Me.IconFile = iconFile_Renamed
				Me.IconSize = iconSize_Renamed
				Me.IsColorSelector = False
				Me.IsClientSide = isClientSide_Renamed
			End Sub

'INSTANT VB NOTE: The parameter title was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter commandName was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter color was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal title_Renamed As String, ByVal commandName_Renamed As String, ByVal color_Renamed As Color)
				Me.Title = title_Renamed
				Me.CommandName = commandName_Renamed
				Me.Color = color_Renamed
				Me.IsColorSelector = True
				Me.IsClientSide = False

				Me.IconFile = "FillBucketIcon.png"
				Me.IconSize = New NSize(18, 18)
			End Sub

			Public Sub New()
				Me.IsSeparator = True
			End Sub

			Public Title As String
			Public CommandName As String
			Public IconFile As String
			Public IconSize As NSize
			Public Color As Color
			Public IsColorSelector As Boolean
			Public IsClientSide As Boolean
			Public IsSeparator As Boolean
		End Class

		Private Sub InitToolbar()
			If nDrawingViewToolbar.RequiresInitialization Then
				ActiveCommand = toolbarButtons(0).CommandName

				' begin view init
				nDrawingViewToolbar.ViewLayout = CanvasLayout.Normal
				nDrawingViewToolbar.DocumentPadding = New Nevron.Diagram.NMargins(0)

				' init document
				nDrawingViewToolbar.Document.BeginInit()

				nDrawingViewToolbar.Document.AutoBoundsPadding = New Nevron.Diagram.NMargins(4)

				nDrawingViewToolbar.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
				nDrawingViewToolbar.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
				nDrawingViewToolbar.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality

				' set up visual formatting
				nDrawingViewToolbar.Document.Style.FillStyle = New NColorFillStyle(Color.White)
				nDrawingViewToolbar.Document.Style.TextStyle.FontStyle.InitFromFont(New Font("Arial Narrow", 8))

				nDrawingViewToolbar.Document.BackgroundStyle.FrameStyle.Visible = False

				'	set up the shape factories
				Dim buttonFactory As NBasicShapesFactory = New NBasicShapesFactory(nDrawingViewToolbar.Document)
				buttonFactory.DefaultSize = New NSizeF(24, 24)

				Dim iconFactory As NBrainstormingShapesFactory = New NBrainstormingShapesFactory(nDrawingViewToolbar.Document)
				iconFactory.DefaultSize = New NSizeF(16, 16)

				'	create a batch layout, which will align shapes
				Dim batchLayout As NBatchLayout = New NBatchLayout(nDrawingViewToolbar.Document)

				'	create buttons
				Dim count As Integer = toolbarButtons.Length
				Dim i As Integer = 0
				Do While i < count
					Dim btn As ToolbarButton = toolbarButtons(i)
					Dim isActive As Boolean = (Me.ActiveCommand = btn.CommandName)
					Dim buttonShape As NShape = buttonFactory.CreateShape(BasicShapes.RoundedRectangle)

					'	create the button shape group
					Dim g As NGroup = New NGroup()
					Dim bgroup As NBatchGroup = New NBatchGroup(nDrawingViewToolbar.Document)
					Dim shapes As NNodeList = New NNodeList()
					If btn.IsSeparator Then
						buttonShape.Width /= 2
						buttonShape.Style.StrokeStyle = New NStrokeStyle(Color.White)
						shapes.Add(buttonShape)
					ElseIf (Not btn.IsColorSelector) Then
						shapes.Add(buttonShape)
					Else
						buttonShape.Style.FillStyle = New NColorFillStyle(btn.Color)
						shapes.Add(buttonShape)
					End If

					Dim imagePath As NRectanglePath = New NRectanglePath(0f, 0f, btn.IconSize.Width, btn.IconSize.Height)
					Dim fs1 As NImageFillStyle = New NImageFillStyle(Me.MapPathSecure("..\..\..\Images\FlowChartBuilder\" & btn.IconFile))
					NStyle.SetFillStyle(imagePath, fs1)
					NStyle.SetStrokeStyle(imagePath, New NStrokeStyle(0, Color.White))
					Dim imageShape As NCompositeShape = New NCompositeShape()
					imageShape.Primitives.AddChild(imagePath)
					imageShape.UpdateModelBounds()
					shapes.Add(imageShape)

					Dim coverShape As NShape = buttonFactory.CreateShape(BasicShapes.RoundedRectangle)
					coverShape.Width = buttonShape.Width
					coverShape.Name = "coverShape"
					shapes.Add(coverShape)

					If (Not isActive) AndAlso (Not btn.IsClientSide) AndAlso (Not btn.IsSeparator) Then
						If btn.IsColorSelector Then
							coverShape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(180, Color.White))
						Else
							coverShape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(160, Color.White))
						End If
						coverShape.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(160, Color.White))
					Else
						coverShape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))
						coverShape.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(0, Color.White))
						If (Not btn.IsSeparator) Then
							coverShape.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(70, Color.Black), New NPointL(1, 0))
						End If
					End If

					' perform layout
					batchLayout.Build(shapes)
					batchLayout.AlignVertically(buttonShape, VertAlign.Center, False)
					batchLayout.AlignHorizontally(buttonShape, HorzAlign.Center, False)

					' group shapes
					bgroup.Build(shapes)
					bgroup.Group(Nothing, False, g)

					' enable interactivity
					If (Not btn.IsSeparator) Then
						g.Style.InteractivityStyle = New NInteractivityStyle(True, btn.CommandName, btn.Title, CursorType.Hand)
					End If

					' set the command of the button
					g.Tag = btn.CommandName

					nDrawingViewToolbar.Document.ActiveLayer.AddChild(g)
					i += 1
				Loop

				' layout the shapes in the active layer using a table layout
				Dim layout As NTableLayout = New NTableLayout()

				' setup the table layout
				layout.Direction = LayoutDirection.LeftToRight
				layout.ConstrainMode = CellConstrainMode.Ordinal
				layout.MaxOrdinal = toolbarButtons.Length
				layout.HorizontalSpacing = 7

				' create a layout context
				Dim layoutContext As NLayoutContext = New NLayoutContext()
				layoutContext.GraphAdapter = New NShapeGraphAdapter()
				layoutContext.BodyAdapter = New NShapeBodyAdapter(nDrawingViewToolbar.Document)
				layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(nDrawingViewToolbar.Document)

				' layout the shapes
				layout.Layout(nDrawingViewToolbar.Document.ActiveLayer.Children(Nothing), layoutContext)

				nDrawingViewToolbar.Document.EndInit()
			End If
		End Sub

		Private Function GetButtonByCommand(ByVal name As String) As ToolbarButton
			Dim length As Integer = toolbarButtons.Length
			Dim i As Integer = 0
			Do While i < length
				If toolbarButtons(i).CommandName = name Then
					Return toolbarButtons(i)
				End If
				i += 1
			Loop
			Return Nothing
		End Function

		Protected Sub nDrawingViewToolbar_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			nDrawingViewToolbar.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True, True))
			nDrawingViewToolbar.AjaxTools.Add(New NAjaxDynamicCursorTool(True))
			nDrawingViewToolbar.AjaxTools.Add(New NAjaxTooltipTool(True))
		End Sub

		Protected Sub nDrawingViewToolbar_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			'	get the selected command
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
			Dim clickedNodes As NNodeList = nDrawingViewToolbar.HitTest(args)
			Dim clickedGroups As NNodeList = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.TypeNGroup)
			If clickedGroups.Count = 0 Then
				Return
			End If
			Dim clickedGroup As NGroup = TryCast(clickedGroups(0), NGroup)
			Dim command As String = TryCast(clickedGroup.Tag, String)
			If command Is Nothing Then
				Return
			End If

			'	get the selected button
			Dim selectedBtn As ToolbarButton = GetButtonByCommand(command)
			If (Not selectedBtn.IsClientSide) Then
				Me.ActiveCommand = command
			Else
				Return
			End If

			'	highlight the clicked button
			Dim selectedCoverShape As NShape = TryCast(clickedGroup.Shapes.GetChildByName("coverShape", 0), NShape)
			If selectedCoverShape Is Nothing Then
				Return
			End If
			Dim groups As NNodeList = nDrawingViewToolbar.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.TypeNGroup)
			Dim length As Integer = groups.Count
			Dim i As Integer = 0
			Do While i < length
				Dim group As NGroup = TryCast(groups(i), NGroup)
				Dim btn As ToolbarButton = GetButtonByCommand(TryCast(group.Tag, String))
				If btn Is Nothing Then
					Continue Do
				End If
				Dim coverShape As NShape = TryCast(group.Shapes.GetChildByName("coverShape", 0), NShape)
				If (Not btn.IsSeparator) Then
					If (Not Object.ReferenceEquals(selectedCoverShape, coverShape)) AndAlso (Not btn.IsClientSide) Then
						If btn.IsColorSelector Then
							coverShape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(80, Color.White))
						Else
							coverShape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(160, Color.White))
						End If
						coverShape.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(160, Color.White))
						coverShape.Style.ShadowStyle = Nothing
					Else
						coverShape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))
						coverShape.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(0, Color.White))
						coverShape.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(70, Color.Black), New NPointL(1, 0))
					End If
				End If
				i += 1
			Loop
		End Sub

		#End Region

		Private Property ActiveCommand() As String
			Get
				Return TryCast(Me.Session("ActiveCommand"), String)
			End Get
			Set
				Me.Session("ActiveCommand") = Value
			End Set
		End Property

		Private Property SelectedShapeId() As Guid
			Get
				If Me.Session("SelectedShapeId") Is Nothing Then
					Return Guid.Empty
				End If
				Return CType(Me.Session("SelectedShapeId"), Guid)
			End Get
			Set
				Me.Session("SelectedShapeId") = Value
			End Set
		End Property
	End Class
End Namespace
