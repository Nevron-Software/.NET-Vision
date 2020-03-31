Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NExampleUC.
	''' </summary>
	Public Partial Class NDiagramExampleUC
		Inherits System.Web.UI.UserControl
		#Region "Properties"

		''' <summary>
		''' Determines whether event handling is paused
		''' </summary>
		Protected ReadOnly Property EventsHandlingPaused() As Boolean
			Get
				Return (eventHandlingPauseCounter <> 0)
			End Get
		End Property
		''' <summary>
		''' Gets/sets the default grid cell size
		''' </summary>
		Protected Property DefaultGridCellSize() As NSizeF
			Get
				Return defaultGridCellSize_Renamed
			End Get
			Set
				defaultGridCellSize_Renamed = Value
			End Set
		End Property
		''' <summary>
		''' Gets/sets the default grid origin
		''' </summary>
		Protected Property DefaultGridOrigin() As NPointF
			Get
				Return defaultGridOrigin_Renamed
			End Get
			Set
				defaultGridOrigin_Renamed = Value
			End Set
		End Property
		''' <summary>
		''' Gets/sets the default grid spacing
		''' </summary>
		Protected Property DefaultGridSpacing() As NSizeF
			Get
				Return defaultGridSpacing_Renamed
			End Get
			Set
				defaultGridSpacing_Renamed = Value
			End Set
		End Property

		#End Region

		#Region "Protected Methods"

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
			Return GetGridCell(row, col, defaultGridOrigin_Renamed, defaultGridCellSize_Renamed, defaultGridSpacing_Renamed)
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
			Dim cell1 As NRectangleF = GetGridCell(row, col, defaultGridOrigin_Renamed, defaultGridCellSize_Renamed, defaultGridSpacing_Renamed)
			Dim cell2 As NRectangleF = GetGridCell(row + rowSpan, col + colSpan, defaultGridOrigin_Renamed, defaultGridCellSize_Renamed, defaultGridSpacing_Renamed)
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
			Return New NPointF(bounds.X + (CSng(Random.NextDouble()) * bounds.Width), bounds.Y + (CSng(Random.NextDouble()) * bounds.Height))
		End Function
		''' <summary>
		''' Gets a random size in [minSize, maxSize] range
		''' </summary>
		''' <param name="minSize"></param>
		''' <param name="maxSize"></param>
		''' <returns></returns>
		Protected Function GetRandomSize(ByVal minSize As NSizeF, ByVal maxSize As NSizeF) As NSizeF
			Dim width As Single = CSng(Random.Next(100) * Math.Abs(maxSize.Width - minSize.Width) / 100.0f + Math.Min(maxSize.Width, minSize.Width))
			Dim height As Single = CSng(Random.Next(100) * Math.Abs(maxSize.Height - minSize.Height) / 100.0f + Math.Min(maxSize.Height, minSize.Height))

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

		#Region "Fields"

		Protected Shared Random As Random = New Random()

		Private eventHandlingPauseCounter As Integer = 0
		Private defaultGridCellSize_Renamed As NSizeF
		Private defaultGridOrigin_Renamed As NPointF
		Private defaultGridSpacing_Renamed As NSizeF

		#End Region
	End Class
End Namespace