Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Web

Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NPdfExportRenderPage.
	''' </summary>
	Public Partial Class NPdfExportRenderPage
		Inherits NDrawingViewHostPage
		#Region "Constructors"

		''' <summary>
		''' Default constructor.
		''' </summary>
		Public Sub New()
			DrawingView = New NDrawingView()
			DrawingView.ViewLayout = CanvasLayout.Normal

			Dim format As String = HttpContext.Current.Request.QueryString("format")
			If format = "pdf" Then
				' Create a pdf image format
				Dim imageFormat As NPdfImageFormat = New NPdfImageFormat()
				imageFormat.PageSize = New NSizeF(GetSizeInPoints("PageWidth"), GetSizeInPoints("PageHeight"))
				imageFormat.PageMargins = New NMarginsF(GetSizeInPoints("MarginsLeft"), GetSizeInPoints("MarginsTop"), GetSizeInPoints("MarginsRight"), GetSizeInPoints("MarginsBottom"))
				imageFormat.ZoomPercent = GetFloat("ZoomPercent")
				If GetBoolean("FitToPage") Then
					imageFormat.Layout = PagedLayout.FitToPages
				End If

				' Override the default response
				Dim imageResponse As NImageResponse = New NImageResponse()
				imageResponse.ImageFormat = imageFormat
				imageResponse.StreamImageToBrowser = True
				DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse
			End If

			' init document
			Dim document As NDrawingDocument = Me.DrawingView.Document
			document.BeginInit()
			CreateScene(document)
			document.EndInit()

			Me.DrawingView.SizeToContent()
		End Sub

		#End Region

		#Region "Private Methods"

		''' <summary>
		''' Creates the diagram.
		''' </summary>
		''' <param name="document"></param>
		Private Sub CreateScene(ByVal document As NDrawingDocument)
			' create a style sheet for the start and end shapes
			Dim styleSheet As NStyleSheet = New NStyleSheet("STARTEND")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(247, 150, 56), Color.FromArgb(251, 203, 156))
			document.StyleSheets.AddChild(styleSheet)

			' create a style sheet for the question shapes
			styleSheet = New NStyleSheet("QUESTION")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(129, 133, 133), Color.FromArgb(192, 194, 194))
			document.StyleSheets.AddChild(styleSheet)

			' create a style sheet for the action shapes
			styleSheet = New NStyleSheet("ACTION")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(68, 90, 108), Color.FromArgb(162, 173, 182))
			document.StyleSheets.AddChild(styleSheet)

			Dim vSpacing As Integer = 35
			Dim hSpacing As Integer = 45
			Dim topMargin As Integer = 10
			Dim leftMargin As Integer = 10

			Dim shapeWidth As Integer = 90
			Dim shapeHeight As Integer = 55

			Dim col1 As Integer = leftMargin
			Dim col2 As Integer = col1 + shapeWidth + hSpacing
			Dim col3 As Integer = col2 + shapeWidth + hSpacing
			Dim col4 As Integer = col3 + shapeWidth + hSpacing

			Dim row1 As Integer = topMargin
			Dim row2 As Integer = row1 + shapeHeight + vSpacing
			Dim row3 As Integer = row2 + shapeHeight + vSpacing
			Dim row4 As Integer = row3 + shapeHeight + vSpacing
			Dim row5 As Integer = row4 + shapeHeight + vSpacing
			Dim row6 As Integer = row5 + shapeHeight + vSpacing

			Dim bounds As NRectangleF = New NRectangleF(col2, row1, shapeWidth, shapeHeight)
			Dim start As NShape = CreateFlowChartingShape(FlowChartingShapes.Termination, bounds, "START", "STARTEND")

			' row 2
			bounds = New NRectangleF(col2, row2, shapeWidth, shapeHeight)
			Dim haveSerialNumber As NShape = CreateFlowChartingShape(FlowChartingShapes.Decision, bounds, "Have a serial number?", "QUESTION")

			bounds = New NRectangleF(col3, row2, shapeWidth, shapeHeight)
			Dim getSerialNumber As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Get serial number", "ACTION")

			' row 3
			bounds = New NRectangleF(col1, row3, shapeWidth, shapeHeight)
			Dim enterSerialNumber As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Enter serial number", "ACTION")

			bounds = New NRectangleF(col2, row3, shapeWidth, shapeHeight)
			Dim haveDiskSpace As NShape = CreateFlowChartingShape(FlowChartingShapes.Decision, bounds, "Have disk space?", "QUESTION")

			bounds = New NRectangleF(col3, row3, shapeWidth, shapeHeight)
			Dim freeUpSpace As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Free up space", "ACTION")

			' row 4
			bounds = New NRectangleF(col1, row4, shapeWidth, shapeHeight)
			Dim runInstallRect As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Run install file", "ACTION")

			bounds = New NRectangleF(col2, row4, shapeWidth, shapeHeight)
			Dim registerNow As NShape = CreateFlowChartingShape(FlowChartingShapes.Decision, bounds, "Register now?", "QUESTION")

			bounds = New NRectangleF(col3, row4, shapeWidth, shapeHeight)
			Dim fillForm As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Fill out form", "ACTION")

			bounds = New NRectangleF(col4, row4, shapeWidth, shapeHeight)
			Dim submitForm As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Submit form", "ACTION")

			' row 5
			bounds = New NRectangleF(col1, row5, shapeWidth, shapeHeight)
			Dim finishInstall As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Finish installation", "ACTION")

			bounds = New NRectangleF(col2, row5, shapeWidth, shapeHeight)
			Dim restartNeeded As NShape = CreateFlowChartingShape(FlowChartingShapes.Decision, bounds, "Restart needed?", "QUESTION")

			bounds = New NRectangleF(col3, row5, shapeWidth, shapeHeight)
			Dim restart As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Restart", "ACTION")

			' row 6
			bounds = New NRectangleF(col2, row6, shapeWidth, shapeHeight)
			Dim run As NShape = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "RUN", "STARTEND")

			' create connectors
			CreateConnector(start, "Bottom", haveSerialNumber, "Top", ConnectorType.Line, "")

			Dim step3Connector As NStep3Connector = CType(CreateConnector(getSerialNumber, "Top", haveSerialNumber, "Top", ConnectorType.TopToBottom, ""), NStep3Connector)
			step3Connector.UseMiddleControlPointPercent = False
			step3Connector.MiddleControlPointOffset = -(vSpacing / 2)

			CreateConnector(haveSerialNumber, "Right", getSerialNumber, "Left", ConnectorType.Line, "No")
			CreateConnector(haveSerialNumber, "Bottom", enterSerialNumber, "Top", ConnectorType.TopToBottom, "Yes")
			CreateConnector(enterSerialNumber, "Right", haveDiskSpace, "Left", ConnectorType.Line, "")

			step3Connector = CType(CreateConnector(freeUpSpace, "Top", haveDiskSpace, "Top", ConnectorType.TopToBottom, ""), NStep3Connector)
			step3Connector.UseMiddleControlPointPercent = False
			step3Connector.MiddleControlPointOffset = -(vSpacing / 3)

			CreateConnector(haveDiskSpace, "Right", freeUpSpace, "Left", ConnectorType.Line, "No")
			CreateConnector(haveDiskSpace, "Bottom", runInstallRect, "Top", ConnectorType.TopToBottom, "Yes")
			CreateConnector(registerNow, "Right", fillForm, "Left", ConnectorType.Line, "Yes")
			CreateConnector(registerNow, "Bottom", finishInstall, "Top", ConnectorType.TopToBottom, "No")
			CreateConnector(fillForm, "Right", submitForm, "Left", ConnectorType.Line, "")
			CreateConnector(submitForm, "Bottom", finishInstall, "Top", ConnectorType.TopToBottom, "")
			CreateConnector(finishInstall, "Right", restartNeeded, "Left", ConnectorType.Line, "")
			CreateConnector(restart, "Bottom", run, "Top", ConnectorType.TopToBottom, "")
			CreateConnector(restartNeeded, "Right", restart, "Left", ConnectorType.Line, "Yes")
			CreateConnector(restartNeeded, "Bottom", run, "Top", ConnectorType.Line, "No")
		End Sub
		''' <summary>
		''' Creates a predefined flow charting shape
		''' </summary>
		''' <param name="flowChartShape">flow charting shape</param>
		''' <param name="bounds">bounds</param>
		''' <param name="text">default label text</param>
		''' <param name="styleSheetName">name of the stylesheet from which to inherit styles</param>
		''' <returns>new basic shape</returns>
		Private Function CreateFlowChartingShape(ByVal flowChartShape As FlowChartingShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal styleSheetName As String) As NShape
			Dim factory As NFlowChartingShapesFactory = New NFlowChartingShapesFactory(DrawingView.Document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(flowChartShape)))

			shape.Bounds = bounds
			shape.Text = text
			shape.StyleSheetName = styleSheetName

			DrawingView.Document.ActiveLayer.AddChild(shape)
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
		Private Function CreateConnector(ByVal fromShape As NShape, ByVal fromPortName As String, ByVal toShape As NShape, ByVal toPortName As String, ByVal connectorType As ConnectorType, ByVal text As String) As NShape
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
			DrawingView.Document.ActiveLayer.AddChild(connector)

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

		#Region "Static"

		''' <summary>
		''' Reads the parameter with the specified name as boolean.
		''' </summary>
		''' <param name="name"></param>
		''' <returns></returns>
		Private Shared Function GetBoolean(ByVal name As String) As Boolean
			Dim str As String = HttpContext.Current.Request(name)
			Dim result As Boolean
			If Boolean.TryParse(str, result) = False Then
				result = False
			End If

			Return result
		End Function
		''' <summary>
		''' Reads the parameter with the specified name as float.
		''' </summary>
		''' <param name="name"></param>
		''' <returns></returns>
		Private Shared Function GetFloat(ByVal name As String) As Single
			Dim str As String = HttpContext.Current.Request(name)
			Dim result As Single
			If Single.TryParse(str, result) = False Then
				If name.StartsWith("Page") Then
					result = 10
				ElseIf name.StartsWith("Zoom") Then
					result = 1
				Else
					result = 0
				End If
			End If

			Return result
		End Function
		''' <summary>
		''' Reads the parameter with the specified name as float and then
		''' converts it from mm to points.
		''' </summary>
		''' <param name="name"></param>
		''' <returns></returns>
		Private Shared Function GetSizeInPoints(ByVal name As String) As Single
			Dim result As Single = GetFloat(name)
			Return NMath.Round(result * MmToPoints)
		End Function

		#End Region

		#Region "Constants"

		Private Const MmToPoints As Single = 2.83464567f

		#End Region
	End Class
End Namespace