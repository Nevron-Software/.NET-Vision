Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	Public Class NPipelineEditorUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' Init view and document
			view.BeginInit()
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False
			view.EndInit()

			' Init controls
			Dim libView As NLibraryView = CreateLibrary()
			libView.SetBounds(0, 0, Me.Width, Me.commonControlsPanel.Top)
			libView.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top Or AnchorStyles.Bottom
			Me.Controls.Add(libView)
		End Sub
		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()

			AddHandler document.EventSinkService.Connecting, AddressOf OnNodesConnecting
		End Sub
		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()

			RemoveHandler document.EventSinkService.Connecting, AddressOf OnNodesConnecting
		End Sub

		#End Region

		#Region "Implementation - Masters"

		Private Sub SetProtections(ByVal shape As NShape)
			Dim protection As NAbilities = shape.Protection
			protection.ResizeX = True
			protection.ResizeY = True
			protection.Rotate = True
			protection.InplaceEdit = True
			protection.TrackersEdit = True
			shape.Protection = protection
		End Sub
		Private Function CreateHorizontalPipe() As NCompositeShape
			Dim port As NDynamicPort
			Dim shape As NCompositeShape = New NCompositeShape()
			Dim rect As NRectanglePath = New NRectanglePath(0, SIZE, 3 * SIZE, SIZE)
			NStyle.SetStrokeStyle(rect, New NStrokeStyle(0, Color.White))

			shape.Primitives.AddChild(rect)
			shape.Primitives.AddChild(New NLinePath(0, SIZE, 3 * SIZE, SIZE))
			shape.Primitives.AddChild(New NLinePath(0, 2 * SIZE, 3 * SIZE, 2 * SIZE))
			shape.UpdateModelBounds()

			If shape.Ports Is Nothing Then
				shape.CreateShapeElements(ShapeElementsMask.Ports)
			End If

			port = New NDynamicPort(shape.UniqueId, LEFT, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			port = New NDynamicPort(shape.UniqueId, RIGHT, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			SetProtections(shape)
			Return shape
		End Function
		Private Function CreateVerticalPipe() As NCompositeShape
			Dim port As NDynamicPort
			Dim shape As NCompositeShape = New NCompositeShape()
			Dim rect As NRectanglePath = New NRectanglePath(SIZE, 0, SIZE, 3 * SIZE)
			NStyle.SetStrokeStyle(rect, New NStrokeStyle(0, Color.White))

			shape.Primitives.AddChild(rect)
			shape.Primitives.AddChild(New NLinePath(SIZE, 0, SIZE, 3 * SIZE))
			shape.Primitives.AddChild(New NLinePath(2 * SIZE, 0, 2 * SIZE, 3 * SIZE))
			shape.UpdateModelBounds()

			If shape.Ports Is Nothing Then
				shape.CreateShapeElements(ShapeElementsMask.Ports)
			End If

			port = New NDynamicPort(shape.UniqueId, TOP, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			port = New NDynamicPort(shape.UniqueId, BOTTOM, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			SetProtections(shape)
			Return shape
		End Function
		Private Function CreateCrossPipe() As NCompositeShape
			Dim port As NDynamicPort
			Dim shape As NCompositeShape = New NCompositeShape()
			Dim polygon As NPolygonPath = New NPolygonPath(New NPointF(){ New NPointF(0, SIZE), New NPointF(SIZE, SIZE), New NPointF(SIZE, 0), New NPointF(2 * SIZE, 0), New NPointF(2 * SIZE, SIZE), New NPointF(3 * SIZE, SIZE), New NPointF(3 * SIZE, 2 * SIZE), New NPointF(2 * SIZE, 2 * SIZE), New NPointF(2 * SIZE, 3 * SIZE), New NPointF(SIZE, 3 * SIZE), New NPointF(SIZE, 2 * SIZE), New NPointF(0, 2 * SIZE) })

			NStyle.SetStrokeStyle(polygon, New NStrokeStyle(0, Color.White))
			shape.Primitives.AddChild(polygon)
			shape.Primitives.AddChild(New NLinePath(0, SIZE, SIZE, SIZE))
			shape.Primitives.AddChild(New NLinePath(SIZE, SIZE, SIZE, 0))
			shape.Primitives.AddChild(New NLinePath(2 * SIZE, 0, 2 * SIZE, SIZE))
			shape.Primitives.AddChild(New NLinePath(2 * SIZE, SIZE, 3 * SIZE, SIZE))
			shape.Primitives.AddChild(New NLinePath(3 * SIZE, 2 * SIZE, 2 * SIZE, 2 * SIZE))
			shape.Primitives.AddChild(New NLinePath(2 * SIZE, 2 * SIZE, 2 * SIZE, 3 * SIZE))
			shape.Primitives.AddChild(New NLinePath(SIZE, 3 * SIZE, SIZE, 2 * SIZE))
			shape.Primitives.AddChild(New NLinePath(SIZE, 2 * SIZE, 0, 2 * SIZE))
			shape.UpdateModelBounds()

			If shape.Ports Is Nothing Then
				shape.CreateShapeElements(ShapeElementsMask.Ports)
			End If

			port = New NDynamicPort(shape.UniqueId, LEFT, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			port = New NDynamicPort(shape.UniqueId, TOP, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			port = New NDynamicPort(shape.UniqueId, RIGHT, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			port = New NDynamicPort(shape.UniqueId, BOTTOM, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			SetProtections(shape)
			Return shape
		End Function
		Private Function CreateElbowPipe(ByVal type As String) As NCompositeShape
			Dim port As NDynamicPort
			Dim shape As NCompositeShape = New NCompositeShape()
			Dim polygon As NPolygonPath
			Dim ca1, ca2 As NContentAlignment

			Select Case type
				Case "NW"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(0, SIZE), New NPointF(SIZE, SIZE), New NPointF(SIZE, 0), New NPointF(2 * SIZE, 0), New NPointF(2 * SIZE, 2 * SIZE), New NPointF(0, 2 * SIZE) })

					ca1 = TOP
					ca2 = LEFT

				Case "NE"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(3 * SIZE, SIZE), New NPointF(2 * SIZE, SIZE), New NPointF(2 * SIZE, 0), New NPointF(SIZE, 0), New NPointF(SIZE, 2 * SIZE), New NPointF(3 * SIZE, 2 * SIZE) })

					ca1 = TOP
					ca2 = RIGHT

				Case "SW"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(0, 2 * SIZE), New NPointF(SIZE, 2 * SIZE), New NPointF(SIZE, 3 * SIZE), New NPointF(2 * SIZE, 3 * SIZE), New NPointF(2 * SIZE, SIZE), New NPointF(0, SIZE) })

					ca1 = BOTTOM
					ca2 = LEFT

				Case "SE"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(3 * SIZE, 2 * SIZE), New NPointF(2 * SIZE, 2 * SIZE), New NPointF(2 * SIZE, 3 * SIZE), New NPointF(SIZE, 3 * SIZE), New NPointF(SIZE, SIZE), New NPointF(3 * SIZE, SIZE) })

					ca1 = BOTTOM
					ca2 = RIGHT

				Case Else
					Throw New ArgumentException("Unsupported elbow pipe type")
			End Select

			NStyle.SetStrokeStyle(polygon, New NStrokeStyle(0, Color.White))
			shape.Primitives.AddChild(polygon)
			shape.Primitives.AddChild(New NLinePath(polygon.Points(0), polygon.Points(1)))
			shape.Primitives.AddChild(New NLinePath(polygon.Points(1), polygon.Points(2)))
			shape.Primitives.AddChild(New NLinePath(polygon.Points(3), polygon.Points(4)))
			shape.Primitives.AddChild(New NLinePath(polygon.Points(4), polygon.Points(5)))
			shape.UpdateModelBounds(New NRectangleF(0, 0, 3 * SIZE, 3 * SIZE))

			If shape.Ports Is Nothing Then
				shape.CreateShapeElements(ShapeElementsMask.Ports)
			End If

			port = New NDynamicPort(shape.UniqueId, ca1, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			port = New NDynamicPort(shape.UniqueId, ca2, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			SetProtections(shape)
			Return shape
		End Function
		Private Function CreateTPipe(ByVal type As String) As NCompositeShape
			Dim port As NDynamicPort
			Dim shape As NCompositeShape = New NCompositeShape()
			Dim polygon As NPolygonPath
			Dim ca1, ca2, ca3 As NContentAlignment

			Select Case type
				Case "NEW"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(0, SIZE), New NPointF(SIZE, SIZE), New NPointF(SIZE, 0), New NPointF(2 * SIZE, 0), New NPointF(2 * SIZE, SIZE), New NPointF(3 * SIZE, SIZE), New NPointF(3 * SIZE, 2 * SIZE), New NPointF(0, 2 * SIZE) })

					ca1 = TOP
					ca2 = LEFT
					ca3 = RIGHT

				Case "NES"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(3 * SIZE, SIZE), New NPointF(2 * SIZE, SIZE), New NPointF(2 * SIZE, 0), New NPointF(SIZE, 0), New NPointF(SIZE, 3 * SIZE), New NPointF(2 * SIZE, 3 * SIZE), New NPointF(2 * SIZE, 2 * SIZE), New NPointF(3 * SIZE, 2 * SIZE) })

					ca1 = TOP
					ca2 = RIGHT
					ca3 = BOTTOM

				Case "NWS"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(0, SIZE), New NPointF(SIZE, SIZE), New NPointF(SIZE, 0), New NPointF(2 * SIZE, 0), New NPointF(2 * SIZE, 3 * SIZE), New NPointF(SIZE, 3 * SIZE), New NPointF(SIZE, 2 * SIZE), New NPointF(0, 2 * SIZE) })

					ca1 = TOP
					ca2 = LEFT
					ca3 = BOTTOM

				Case "SEW"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(3 * SIZE, 2 * SIZE), New NPointF(2 * SIZE, 2 * SIZE), New NPointF(2 * SIZE, 3 * SIZE), New NPointF(SIZE, 3 * SIZE), New NPointF(SIZE, 2 * SIZE), New NPointF(0, 2 * SIZE), New NPointF(0, SIZE), New NPointF(3 * SIZE, SIZE) })

					ca1 = BOTTOM
					ca2 = RIGHT
					ca3 = LEFT

				Case Else
					Throw New ArgumentException("Unsupported elbow pipe type")
			End Select

			NStyle.SetStrokeStyle(polygon, New NStrokeStyle(0, Color.White))
			shape.Primitives.AddChild(polygon)
			shape.Primitives.AddChild(New NLinePath(polygon.Points(0), polygon.Points(1)))
			shape.Primitives.AddChild(New NLinePath(polygon.Points(1), polygon.Points(2)))
			shape.Primitives.AddChild(New NLinePath(polygon.Points(3), polygon.Points(4)))
			If type.Contains("S") AndAlso type.Contains("N") Then
				shape.Primitives.AddChild(New NLinePath(polygon.Points(5), polygon.Points(6)))
			Else
				shape.Primitives.AddChild(New NLinePath(polygon.Points(4), polygon.Points(5)))
			End If

			shape.Primitives.AddChild(New NLinePath(polygon.Points(6), polygon.Points(7)))
			shape.UpdateModelBounds(New NRectangleF(0, 0, 3 * SIZE, 3 * SIZE))

			If shape.Ports Is Nothing Then
				shape.CreateShapeElements(ShapeElementsMask.Ports)
			End If

			port = New NDynamicPort(shape.UniqueId, ca1, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			port = New NDynamicPort(shape.UniqueId, ca2, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			port = New NDynamicPort(shape.UniqueId, ca3, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			SetProtections(shape)
			Return shape
		End Function
		Private Function CreateEndPipe(ByVal type As String) As NCompositeShape
			Dim port As NDynamicPort
			Dim shape As NCompositeShape = New NCompositeShape()
			Dim polygon As NPolygonPath
			Dim ca As NContentAlignment

			Select Case type
				Case "W"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(3 * SIZE, SIZE), New NPointF(2 * SIZE, 1.5f * SIZE), New NPointF(3 * SIZE, 2 * SIZE) })

					ca = RIGHT

				Case "N"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(SIZE, 3 * SIZE), New NPointF(1.5f * SIZE, 2 * SIZE), New NPointF(2 * SIZE, 3 * SIZE) })

					ca = BOTTOM

				Case "E"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(0, SIZE), New NPointF(SIZE, 1.5f * SIZE), New NPointF(0, 2 * SIZE) })

					ca = LEFT

				Case "S"
					polygon = New NPolygonPath(New NPointF(){ New NPointF(SIZE, 0), New NPointF(1.5f * SIZE, SIZE), New NPointF(2 * SIZE, 0) })

					ca = TOP

				Case Else
					Throw New ArgumentException("Unsupported elbow pipe type")
			End Select

			NStyle.SetStrokeStyle(polygon, New NStrokeStyle(0, Color.White))
			shape.Primitives.AddChild(polygon)
			shape.Primitives.AddChild(New NLinePath(polygon.Points(0), polygon.Points(1)))
			shape.Primitives.AddChild(New NLinePath(polygon.Points(1), polygon.Points(2)))
			shape.UpdateModelBounds(New NRectangleF(0, 0, 3 * SIZE, 3 * SIZE))

			If shape.Ports Is Nothing Then
				shape.CreateShapeElements(ShapeElementsMask.Ports)
			End If

			port = New NDynamicPort(shape.UniqueId, ca, DynamicPortGlueMode.GlueToContour)
			port.Type = PortType.InwardAndOutward
			shape.Ports.AddChild(port)

			SetProtections(shape)
			Return shape
		End Function

		#End Region

		#Region "Implemenetation - Library"

		Private Function GetSideIndex(ByVal port As NDynamicPort) As Integer
			If port.Alignment = LEFT Then
				Return 0
			ElseIf port.Alignment = TOP Then
				Return 1
			ElseIf port.Alignment = RIGHT Then
				Return 2
			ElseIf port.Alignment = BOTTOM Then
				Return 3
			Else
				Throw New Exception("Invalid port side")
			End If
		End Function
		Private Function CreateLibrary() As NLibraryView
			Dim libView As NLibraryView = New NLibraryView()
			libView.ScrollBars = ScrollBars.Vertical
			libView.Selection.Mode = DiagramSelectionMode.Single

			Dim libDoc As NLibraryDocument = New NLibraryDocument()
			libView.Document = libDoc
			libDoc.BackgroundStyle = New NBackgroundStyle()
			libDoc.BackgroundStyle.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Vertical, GradientVariant.Variant1, Color.RoyalBlue, Color.LightSkyBlue)

			' Horizontal Pipe
			Dim shape As NCompositeShape = CreateHorizontalPipe()
			Dim master As NMaster = New NMaster(shape, NGraphicsUnit.Pixel, "Horizontal Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' Vertical Pipe
			shape = CreateVerticalPipe()
			master = New NMaster(shape, NGraphicsUnit.Pixel, "Vertical Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' Cross Pipe
			shape = CreateCrossPipe()
			master = New NMaster(shape, NGraphicsUnit.Pixel, "Cross Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' North-West Pipe
			shape = CreateElbowPipe("NW")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "North-West Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' North-East Pipe
			shape = CreateElbowPipe("NE")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "North-East Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' South-West Pipe
			shape = CreateElbowPipe("SW")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "South-West Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' South-East Pipe
			shape = CreateElbowPipe("SE")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "South-East Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' North-East-West Pipe
			shape = CreateTPipe("NEW")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "North-East-West Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' North-East-South Pipe
			shape = CreateTPipe("NES")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "North-East-South Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' North-West-South Pipe
			shape = CreateTPipe("NWS")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "North-West-South Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' South-East-West Pipe
			shape = CreateTPipe("SEW")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "South-East-West Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' West-End Pipe
			shape = CreateEndPipe("W")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "West-End Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' North-End Pipe
			shape = CreateEndPipe("N")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "North-End Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' East-End Pipe
			shape = CreateEndPipe("E")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "East-End Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			' South-End Pipe
			shape = CreateEndPipe("S")
			master = New NMaster(shape, NGraphicsUnit.Pixel, "South-End Pipe", "Drag me on the drawing")
			libDoc.AddChild(master)

			Return libView
		End Function

		#End Region

		#Region "Event Handlers"

		Private Sub OnNodesConnecting(ByVal args As NConnectionCancelEventArgs)
			Dim port1 As NDynamicPort = CType(document.GetElementFromUniqueId(args.UniqueId1), NDynamicPort)
			Dim port2 As NDynamicPort = CType(document.GetElementFromUniqueId(args.UniqueId2), NDynamicPort)

			Dim side1 As Integer = GetSideIndex(port1)
			Dim side2 As Integer = GetSideIndex(port2)

			Dim sidesFail As Boolean = side1 Mod 2 <> side2 Mod 2
			Dim alreadyConnected As Boolean = Not port1.ConnectedPoints Is Nothing OrElse Not port2.ConnectedPoints Is Nothing

			If sidesFail OrElse alreadyConnected Then
				' The ports cannot be connected, so cancel the connection and apply a bounce back force
				Dim offset As NPoint = New NPoint(0, 0)
				Dim even As Boolean = side1 Mod 2 = 0
				If sidesFail Then
					If even Then
						offset.X = (1 - side1) * SIZE
					Else
						offset.Y = (2 - side1) * SIZE
					End If
				Else
					If (Not even) Then
						offset.X = (2 - side1) * SIZE
					Else
						offset.Y = (1 - side1) * SIZE
					End If
				End If

				port1.Shape.Location = New NPointF(port1.Shape.Location.X + offset.X, port1.Shape.Location.Y + offset.Y)
				args.Cancel = True
			End If
		End Sub

		#End Region

		#Region "Constants"

		Private Const SIZE As Integer = 25
		Private Shared ReadOnly LEFT As NContentAlignment = New NContentAlignment(ContentAlignment.MiddleLeft)
		Private Shared ReadOnly RIGHT As NContentAlignment = New NContentAlignment(ContentAlignment.MiddleRight)
		Private Shared ReadOnly TOP As NContentAlignment = New NContentAlignment(ContentAlignment.TopCenter)
		Private Shared ReadOnly BOTTOM As NContentAlignment = New NContentAlignment(ContentAlignment.BottomCenter)

		#End Region

		#Region "Nested Types"

		Private Enum Side
			None = -1
			Left
			Top
			Right
			Bottom
		End Enum

		#End Region
	End Class
End Namespace