Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NThinWebGeneral.
	''' </summary>
	Public Partial Class NThinWebGeneralUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(-100, 0)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			If (Not NThinDiagramControl1.Initialized) Then
				' begin view init
				Dim document As NDrawingDocument = NThinDiagramControl1.Document

				NThinDiagramControl1.Controller.Tools.Add(New NTooltipTool())
				NThinDiagramControl1.Controller.Tools.Add(New NCursorTool())
				NThinDiagramControl1.Controller.Tools.Add(New NRectZoomTool())
				Dim panTool As NPanTool = New NPanTool()
				panTool.Enabled = False
				NThinDiagramControl1.Controller.Tools.Add(panTool)

				' configure the toolbar
				NThinDiagramControl1.Toolbar.Visible = True
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveStateAction("DiagramState.ndx", Serialization.PersistencyFormat.XML)))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveImageAction("DiagramPDF", New NPdfImageFormat(), True, New NSize(), 300)))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveImageAction("DiagramPNG", New NPngImageFormat(), True, New NSize(), 96)))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomInAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomOutAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NTogglePanToolAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleRectZoomToolAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleTooltipToolAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleCursorToolAction()))

				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())

				Dim values As Array = System.Enum.GetValues(GetType(CanvasLayout))
				Dim i As Integer = 0
				Do While i < values.Length
					NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleViewLayoutAction(CType(values.GetValue(i), CanvasLayout))))
					i += 1
				Loop


				' init NDrawingView1.Document.
				document.BeginInit()
				InitDocument(document)
				document.SizeToContent()
				document.EndInit()

'                NThinDiagramControl1.View.Layout = CanvasLayout.Fit;
				NThinDiagramControl1.View.ZoomFactor = 2
				NThinDiagramControl1.View.MinZoomFactor = 1
				NThinDiagramControl1.View.MaxZoomFactor = 10
				NThinDiagramControl1.View.ZoomPercent = 50
'				NThinDiagramControl1.View.ViewportOrigin = document.Location;
			End If
		End Sub

		#Region "Implementation"

		Private Function CreateInteractivityStyle(ByVal text As String) As NInteractivityStyle
			Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()
			interactivityStyle.Tooltip.Text = text
			interactivityStyle.Cursor = New NCursorAttribute(CursorType.Hand)

			Return interactivityStyle
		End Function

		Private Sub InitDocument(ByVal document As NDrawingDocument)
			' setup default NDrawingView1.Document. fill style, background style and shadow style
			Dim color1 As Color = Color.FromArgb(225, 232, 232)
			Dim color2 As Color = Color.FromArgb(32, 136, 178)

			Dim lightingFilter As NLightingImageFilter = New NLightingImageFilter()
			lightingFilter.SpecularColor = Color.Black
			lightingFilter.DiffuseColor = Color.White
			lightingFilter.LightSourceType = LightSourceType.Positional
			lightingFilter.Position = New NVector3DF(1, 1, 1)
			lightingFilter.BevelDepth = New NLength(8, NGraphicsUnit.Pixel)

			document.Style.FillStyle = New NColorFillStyle(color1)
			document.Style.FillStyle.ImageFiltersStyle.Filters.Add(lightingFilter)

			document.BackgroundStyle.FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1, Color.LightBlue, color2)

			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			document.Style.ShadowStyle.Offset = New NPointL(5, 5)

			document.ShadowsZOrder = ShadowsZOrder.BehindDocument

			' create title
			Dim title As NTextShape = New NTextShape("Bubble Sort", GetGridCell(0, 1, 2, 1))
			title.Style.TextStyle = New NTextStyle()
			title.Style.TextStyle.FillStyle = (TryCast(document.Style.FillStyle.Clone(), NFillStyle))
			title.Style.TextStyle.ShadowStyle = New NShadowStyle()
			title.Style.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur
			title.Style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 40, FontStyle.Bold))

			title.Style.InteractivityStyle = CreateInteractivityStyle("Bubble Sort")

			document.ActiveLayer.AddChild(title)



			' begin shape
			Dim shapeBegin As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Termination, GetGridCell(0, 0), "BEGIN", "")

			' get array item shape
			Dim shapeGetItem As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Data, GetGridCell(1, 0), "Get array item [1...n]", "")
			Dim rotatedBoundsLabel As NRotatedBoundsLabel = CType(shapeGetItem.Labels.DefaultLabel, NRotatedBoundsLabel)
			rotatedBoundsLabel.Margins = New Nevron.Diagram.NMargins(20, 20, 0, 0)

			' i = 1 shape
			Dim shapeI1 As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(2, 0), "i = 1", "")

			' j = n shape
			Dim shapeJEN As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(3, 0), "j = n", "")

			' less comparison shape
			Dim shapeLess As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(4, 0), "item[i] < item[j - 1]?", "")
			rotatedBoundsLabel = CType(shapeLess.Labels.DefaultLabel, NRotatedBoundsLabel)
			rotatedBoundsLabel.Margins = New Nevron.Diagram.NMargins(15, 15, 0, 0)

			' swap shape
			Dim shapeSwap As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(4, 1), "Swap item[i] and item[j-1]", "")

			' j > i + 1? shape
			Dim shapeJQ As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(5, 0), "j = (i + 1)?", "")

			' dec j shape
			Dim shapeDecJ As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(5, 1), "j = j - 1", "")

			' i > n - 1? shape
			Dim shapeIQ As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(6, 0), "i = (n - 1)?", "")

			' inc i shape
			Dim shapeIncI As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(6, 1), "i = i + 1", "")

			' end shape
			Dim shapeEnd As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Termination, GetGridCell(7, 0), "END", "")

			' connect begin with get array item
			Dim connector1 As NLineShape = New NLineShape()
			connector1.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector1)
			connector1.FromShape = shapeBegin
			connector1.ToShape = shapeGetItem

			' connect get array item with i = 1
			Dim connector2 As NLineShape = New NLineShape()
			connector2.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector2)

			connector2.FromShape = shapeGetItem
			connector2.ToShape = shapeI1

			' connect i = 1 and j = n
			Dim connector3 As NLineShape = New NLineShape()
			connector3.StyleSheetName = NDR.NameConnectorsStyleSheet

			connector3.CreateShapeElements(ShapeElementsMask.Ports)
			connector3.Ports.AddChild(New NLogicalLinePort(connector3.UniqueId, 50))
			connector3.Ports.DefaultInwardPortUniqueId = (TryCast(connector3.Ports.GetChildAt(0), INDiagramElement)).UniqueId
			document.ActiveLayer.AddChild(connector3)

			connector3.FromShape = shapeI1
			connector3.ToShape = shapeJEN

			' connect j = n and item[i] < item[j-1]?
			Dim connector4 As NLineShape = New NLineShape()
			connector4.StyleSheetName = NDR.NameConnectorsStyleSheet

			connector4.CreateShapeElements(ShapeElementsMask.Ports)
			connector4.Ports.AddChild(New NLogicalLinePort(connector4.UniqueId, 50))
			connector4.Ports.DefaultInwardPortUniqueId = (TryCast(connector4.Ports.GetChildAt(0), INDiagramElement)).UniqueId
			document.ActiveLayer.AddChild(connector4)

			connector4.FromShape = shapeJEN
			connector4.ToShape = shapeLess

			' connect item[i] < item[j-1]? and j = (i + 1)? 
			Dim connector5 As NLineShape = New NLineShape()
			connector5.StyleSheetName = NDR.NameConnectorsStyleSheet
			connector5.Text = "No"
			connector5.Style.TextStyle = New NTextStyle()
			connector5.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top

			connector5.CreateShapeElements(ShapeElementsMask.Ports)
			connector5.Ports.AddChild(New NLogicalLinePort(connector5.UniqueId, 50))
			connector5.Ports.DefaultInwardPortUniqueId = (TryCast(connector5.Ports.GetChildAt(0), INDiagramElement)).UniqueId
			document.ActiveLayer.AddChild(connector5)

			connector5.FromShape = shapeLess
			connector5.ToShape = shapeJQ

			' connect j = (i + 1)? and i = (n - 1)?
			Dim connector6 As NLineShape = New NLineShape()
			connector6.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector6)

			connector6.FromShape = shapeJQ
			connector6.ToShape = shapeIQ

			' connect i = (n - 1) and END
			Dim connector7 As NLineShape = New NLineShape()
			connector7.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector7)
			connector7.FromShape = shapeIQ
			connector7.ToShape = shapeEnd

			' connect item[i] < item[j-1]? and Swap
			Dim connector8 As NLineShape = New NLineShape()
			connector8.StyleSheetName = NDR.NameConnectorsStyleSheet
			connector8.Text = "Yes"
			connector8.Style.TextStyle = New NTextStyle()
			connector8.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Bottom
			document.ActiveLayer.AddChild(connector8)

			connector8.FromShape = shapeLess
			connector8.ToShape = shapeSwap

			' connect j = (i + 1)? and j = (j - 1)
			Dim connector9 As NLineShape = New NLineShape()
			connector9.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector9)

			connector9.FromShape = shapeJQ
			connector9.ToShape = shapeDecJ

			' connect i = (n - 1)? and i = (i + 1)
			Dim connector10 As NLineShape = New NLineShape()
			connector10.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector10)

			connector10.FromShape = shapeIQ
			connector10.ToShape = shapeIncI

			' connect Swap to No connector
			Dim connector11 As NStep2Connector = New NStep2Connector(True)
			connector11.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector11)

			connector11.FromShape = shapeSwap
			connector11.ToShape = connector5

			' connect i = i + 1 to connector3
			Dim connector12 As NStep3Connector = New NStep3Connector(False, 50, 60, False)
			connector12.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector12)

			connector12.StartPlug.Connect(TryCast(shapeIncI.Ports.GetChildByName("Right", 0), NPort))
			connector12.EndPlug.Connect(connector3.Ports.DefaultInwardPort)

			' connect j = j - 1 to connector4
			Dim connector13 As NStep3Connector = New NStep3Connector(False, 50, 30, False)
			connector13.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector13)

			connector13.StartPlug.Connect(TryCast(shapeDecJ.Ports.GetChildByName("Right", 0), NPort))
			connector13.EndPlug.Connect(connector4.Ports.DefaultInwardPort)
		End Sub
		''' <summary>
		''' Gets a predefined color
		''' </summary>
		''' <param name="index"></param>
		''' <returns></returns>
		Protected Function GetPredefinedColor(ByVal index As Integer) As Color
			index = index Mod 6

			Select Case index
				Case 0
					Return Color.Magenta
				Case 1
					Return Color.Blue
				Case 2
					Return Color.Green
				Case 3
					Return Color.Chocolate
				Case 4
					Return Color.Coral
				Case 5
					Return Color.Orange
			End Select

			Return Color.Black
		End Function

		''' <summary>
		''' 
		''' </summary>
		''' <param name="row"></param>
		''' <param name="col"></param>
		''' <returns></returns>
		Protected Function GetGridCell(ByVal row As Integer, ByVal col As Integer) As NRectangleF
			Return GetGridCell(row, col, Me.DefaultGridOrigin, DefaultGridCellSize, DefaultGridSpacing)
		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="row"></param>
		''' <param name="col"></param>
		''' <param name="rowSpan"></param>
		''' <param name="colSpan"></param>
		''' <returns></returns>
		Protected Function GetGridCell(ByVal row As Integer, ByVal col As Integer, ByVal rowSpan As Integer, ByVal colSpan As Integer) As NRectangleF
			Dim cell1 As NRectangleF = GetGridCell(row, col, DefaultGridOrigin, DefaultGridCellSize, DefaultGridSpacing)
			Dim cell2 As NRectangleF = GetGridCell(row + rowSpan, col + colSpan, DefaultGridOrigin, DefaultGridCellSize, DefaultGridSpacing)
			Return NRectangleF.Union(cell1, cell2)
		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="row"></param>
		''' <param name="col"></param>
		''' <param name="origin"></param>
		''' <param name="size"></param>
		''' <param name="spacing"></param>
		''' <returns></returns>
		Protected Function GetGridCell(ByVal row As Integer, ByVal col As Integer, ByVal origin As NPointF, ByVal size As NSizeF, ByVal spacing As NSizeF) As NRectangleF
			Return New NRectangleF(origin.X + col * (size.Width + spacing.Width), origin.Y + row * (size.Height + spacing.Height), size.Width, size.Height)
		End Function

		''' <summary>
		''' Gets a random set of points constrained in the specified bounds
		''' </summary>
		''' <param name="bounds"></param>
		''' <param name="pointsCount"></param>
		''' <returns></returns>
		Protected Function GetRandomPoints(ByVal bounds As NRectangleF, ByVal pointsCount As Integer) As NPointF()
			Dim points As NPointF() = New NPointF(pointsCount - 1){}

			Dim i As Integer = 0
			Do While i < points.Length
				points(i) = GetRandomPoint(bounds)
				i += 1
			Loop

			Return points
		End Function
		''' <summary>
		''' Gets a random point constrained in the specified bounds
		''' </summary>
		''' <param name="bounds"></param>
		''' <returns></returns>
		Protected Function GetRandomPoint(ByVal bounds As NRectangleF) As NPointF
			Dim rand As Random = New Random()
			Return New NPointF(bounds.X + (CSng(rand.NextDouble()) * bounds.Width), bounds.Y + (CSng(rand.NextDouble()) * bounds.Height))
		End Function
		''' <summary>
		''' Gets a random size in [minSize, maxSize] range
		''' </summary>
		''' <param name="minSize"></param>
		''' <param name="maxSize"></param>
		''' <returns></returns>
		Protected Function GetRandomSize(ByVal minSize As NSizeF, ByVal maxSize As NSizeF) As NSizeF
			Dim rand As Random = New Random()
			Dim width As Single = CSng(rand.Next(100) * Math.Abs(maxSize.Width - minSize.Width) / 100.0f + Math.Min(maxSize.Width, minSize.Width))
			Dim height As Single = CSng(rand.Next(100) * Math.Abs(maxSize.Height - minSize.Height) / 100.0f + Math.Min(maxSize.Height, minSize.Height))

			Return New NSizeF(width, height)
		End Function

		''' <summary>
		''' Creates a predefined basic shape
		''' </summary>
		''' <param name="basicShape">basic shape</param>
		''' <param name="bounds">bounds</param>
		''' <param name="text">default label text</param>
		''' <param name="styleSheetName">name of the stylesheet from which to inherit styles</param>
		''' <returns>new basic shape</returns>
		Protected Function CreateBasicShape(ByVal document As NDrawingDocument, ByVal basicShape As BasicShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal styleSheetName As String) As NShape
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(basicShape)))

			shape.Bounds = bounds
			shape.Text = text
			shape.StyleSheetName = styleSheetName

			document.ActiveLayer.AddChild(shape)
			Return shape
		End Function
		''' <summary>
		''' Creates a predefined flow charting shape
		''' </summary>
		''' <param name="flowChartShape">flow charting shape</param>
		''' <param name="bounds">bounds</param>
		''' <param name="text">default label text</param>
		''' <param name="styleSheetName">name of the stylesheet from which to inherit styles</param>
		''' <returns>new basic shape</returns>
		Protected Function CreateFlowChartingShape(ByVal document As NDrawingDocument, ByVal flowChartShape As FlowChartingShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal styleSheetName As String) As NShape
			Dim factory As NFlowChartingShapesFactory = New NFlowChartingShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(flowChartShape)))

			shape.Bounds = bounds
			shape.Text = text
			shape.StyleSheetName = styleSheetName
			shape.Style.InteractivityStyle = CreateInteractivityStyle(text)

			document.ActiveLayer.AddChild(shape)
			Return shape
		End Function
		''' <summary>
		''' Creates a new connector, which connects the specified shapes
		''' </summary>
		''' <param name="fromShape"></param>
		''' <param name="fromPortName"></param>
		''' <param name="toShape"></param>
		''' <param name="toPortName"></param>
		''' <param name="connectorType"></param>
		''' <param name="text"></param>
		''' <returns>new 1D shapes</returns>
		Protected Function CreateConnector(ByVal document As NDrawingDocument, ByVal fromShape As NShape, ByVal fromPortName As String, ByVal toShape As NShape, ByVal toPortName As String, ByVal connectorType As ConnectorType, ByVal text As String) As NShape
			' check arguments
			If fromShape Is Nothing Then
				Throw New ArgumentNullException("fromShape")
			End If

			If toShape Is Nothing Then
				Throw New ArgumentNullException("toShape")
			End If

			Dim fromPort As NPort = (TryCast(fromShape.Ports.GetChildByName(fromPortName, 0), NPort))
			If fromPort Is Nothing Then
				Throw New ArgumentException("Was not able to find fromPortName in the ports collection of the fromShape", "fromPortName")
			End If

			Dim toPort As NPort = (TryCast(toShape.Ports.GetChildByName(toPortName, 0), NPort))
			If toPort Is Nothing Then
				Throw New ArgumentException("Was not able to find toPortName in the ports collection of the toShape", "toPortName")
			End If

			' create the connector
			Dim connector As NShape = Nothing
			Select Case connectorType
				Case ConnectorType.Line
					connector = New NLineShape()

				Case ConnectorType.Bezier
					connector = New NBezierCurveShape()

				Case ConnectorType.SingleArrow
					connector = New NArrowShape(ArrowType.SingleArrow)

				Case ConnectorType.DoubleArrow
					connector = New NArrowShape(ArrowType.DoubleArrow)

				Case ConnectorType.SideToTopBottom
					connector = New NStep2Connector(False)

				Case ConnectorType.TopBottomToSide
					connector = New NStep2Connector(True)

				Case ConnectorType.SideToSide
					connector = New NStep3Connector(False, 50, 0, True)

				Case ConnectorType.TopToBottom
					connector = New NStep3Connector(True, 50, 0, True)

				Case ConnectorType.DynamicHV
					connector = New NRoutableConnector(RoutableConnectorType.DynamicHV)

				Case ConnectorType.DynamicPolyline
					connector = New NRoutableConnector(RoutableConnectorType.DynamicPolyline)

				Case ConnectorType.DynamicCurve
					connector = New NRoutableConnector(RoutableConnectorType.DynamicCurve)

				Case Else
					Debug.Assert(False, "New graph connector type?")
			End Select

			' the connector must be added to the document prior to connecting it
			document.ActiveLayer.AddChild(connector)

			' change the default label text
			connector.Text = text

			' connectors by default inherit styles from the connectors stylesheet
			connector.StyleSheetName = NDR.NameConnectorsStyleSheet

			' connect the connector to the specified ports
			connector.StartPlug.Connect(fromPort)
			connector.EndPlug.Connect(toPort)

			' modify the connector text style
			connector.Style.TextStyle = (TryCast(connector.ComposeTextStyle().Clone(), NTextStyle))
			connector.Style.TextStyle.Offset = New NPointL(0, -7)

			Return connector
		End Function

		#End Region
	End Class
End Namespace