Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Editors
Imports Nevron.Diagram.WinForm
Imports Nevron.Examples.Framework.WinForm
Imports Nevron.Diagram.Layout
Imports Nevron.Dom
Imports Nevron.Diagram.Filters

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' The NDiagramExampleUC class serves as base user control for all diagram examples
	''' </summary>
	Public Class NDiagramExampleUC
		Inherits NExampleUserControl
		#Region "Constructors"

		''' <summary>
		''' Default constructor
		''' </summary>
		Public Sub New()
			InitializeComponent()

			view = Nothing
			document = Nothing

			eventHandlingPauseCounter = 0

			defaultGridOrigin_Renamed = New NPointF(15, 15)
			defaultGridCellSize_Renamed = New NSizeF(100, 100)
			defaultGridSpacing_Renamed = New NSizeF(20, 20)
		End Sub

		''' <summary>
		''' Initializer constructor
		''' </summary>
		''' <param name="form">main application form</param>
'INSTANT VB NOTE: The parameter form was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
		Public Sub New(ByVal form_Renamed As NMainForm)
			MyBase.New(form_Renamed)
			InitializeComponent()

			view = form_Renamed.View
			document = form_Renamed.Document
			eventHandlingPauseCounter = 0

			defaultGridOrigin_Renamed = New NPointF(15, 15)
			defaultGridCellSize_Renamed = New NSizeF(100, 100)
			defaultGridSpacing_Renamed = New NSizeF(20, 20)
		End Sub

		#End Region

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.GraphicsSettingsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ResetExampleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.commonControlsPanel = New System.Windows.Forms.Panel()
			Me.commonControlsPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' GraphicsSettingsButton
			' 
			Me.GraphicsSettingsButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.GraphicsSettingsButton.Location = New System.Drawing.Point(8, 12)
			Me.GraphicsSettingsButton.Name = "GraphicsSettingsButton"
			Me.GraphicsSettingsButton.Size = New System.Drawing.Size(244, 24)
			Me.GraphicsSettingsButton.TabIndex = 0
			Me.GraphicsSettingsButton.Text = "Graphics settings..."
'			Me.GraphicsSettingsButton.Click += New System.EventHandler(Me.GraphicsSettingsButton_Click);
			' 
			' ResetExampleButton
			' 
			Me.ResetExampleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ResetExampleButton.Location = New System.Drawing.Point(8, 44)
			Me.ResetExampleButton.Name = "ResetExampleButton"
			Me.ResetExampleButton.Size = New System.Drawing.Size(244, 24)
			Me.ResetExampleButton.TabIndex = 1
			Me.ResetExampleButton.Text = "Reset example"
'			Me.ResetExampleButton.Click += New System.EventHandler(Me.ResetExampleButton_Click);
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Controls.Add(Me.GraphicsSettingsButton)
			Me.commonControlsPanel.Controls.Add(Me.ResetExampleButton)
			Me.commonControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.commonControlsPanel.Location = New System.Drawing.Point(0, 520)
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(260, 80)
			Me.commonControlsPanel.TabIndex = 0
			' 
			' NDiagramExampleUC
			' 
			Me.AutoScroll = True
			Me.Controls.Add(Me.commonControlsPanel)
			Me.Name = "NDiagramExampleUC"
			Me.Size = New System.Drawing.Size(260, 600)
			Me.commonControlsPanel.ResumeLayout(False)
			Me.ResumeLayout(False)
		End Sub

		#End Region

		#Region "Component Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				DetachFromEvents()
			End If

			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Overrides"

		''' <summary>
		''' 
		''' </summary>
		Public Overrides Sub Initialize()
			' synchonize the view and form document
			If Not view Is Nothing AndAlso (Not Object.ReferenceEquals(document, view.Document)) Then
				document = view.Document
				If Not Form Is Nothing Then
					Form.Document = view.Document
				End If
			End If

			' load the example 
			LoadExample()

			' attach to the view and document events 
			AttachToEvents()

			' dock to fill the docking panel
			Dock = System.Windows.Forms.DockStyle.Fill
		End Sub

		#End Region

		#Region "Protected Overridable"

		''' <summary>
		''' Called when the example is loaded
		''' </summary>
		Protected Overridable Sub LoadExample()
		End Sub
		''' <summary>
		''' Attaches the example to the document and view events
		''' </summary>
		Protected Overridable Sub AttachToEvents()
		End Sub
		''' <summary>
		''' Detaches the example to the document and view events
		''' </summary>
		Protected Overridable Sub DetachFromEvents()
		End Sub
		''' <summary>
		''' Resets the example to its initial state
		''' </summary>
		Protected Overridable Sub ResetExample()
			' update document references in case the document was reloaded
			If (Not Object.ReferenceEquals(document, view.Document)) Then
				document = view.Document

				If Not Form Is Nothing Then
					Form.Document = document
				End If
			End If

			DetachFromEvents()

			' reset the document
			document.Reset()
			view.Reset()

			LoadExample()
			AttachToEvents()
		End Sub
		''' <summary>
		''' Creates a default flow diagram
		''' </summary>
		Protected Overridable Sub CreateDefaultFlowDiagram()
			Dim bounds As NRectangleF

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

			bounds = New NRectangleF(col2, row1, shapeWidth, shapeHeight)
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
			step3Connector.MiddleControlPointOffset = - (vSpacing / 2)

			CreateConnector(haveSerialNumber, "Right", getSerialNumber, "Left", ConnectorType.Line, "No")
			CreateConnector(haveSerialNumber, "Bottom", enterSerialNumber, "Top", ConnectorType.TopToBottom, "Yes")
			CreateConnector(enterSerialNumber, "Right", haveDiskSpace, "Left", ConnectorType.Line, "")

			step3Connector = CType(CreateConnector(freeUpSpace, "Top", haveDiskSpace, "Top", ConnectorType.TopToBottom, ""), NStep3Connector)
			step3Connector.UseMiddleControlPointPercent = False
			step3Connector.MiddleControlPointOffset = - (vSpacing / 3)

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

		#End Region

		#Region "Protected"

		''' <summary>
		''' Gets a predefined color from a list of 6 predefined colors.
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
		''' Shows the start arrowhead style editor for the specified styleable node
		''' </summary>
		''' <param name="styleable"></param>
		Protected Sub ShowStartArrowheadStyleEditor(ByVal styleable As INStyleable)
			If styleable Is Nothing Then
				Return
			End If

			Dim arrowheadStyle As NArrowheadStyle = styleable.ComposeStartArrowheadStyle()
			Dim newArrowheadStyle As NArrowheadStyle = Nothing

			If NArrowheadStyleTypeEditor.Edit(arrowheadStyle, newArrowheadStyle, True, Not arrowheadStyle Is NStyle.GetStartArrowheadStyle(styleable)) Then
				NStyle.SetStartArrowheadStyle(styleable, newArrowheadStyle)
				document.RefreshAllViews()
			End If
		End Sub
		''' <summary>
		''' Shows the end arrowhead style editor for the specified styleable node
		''' </summary>
		''' <param name="styleable"></param>
		Protected Sub ShowEndArrowheadStyleEditor(ByVal styleable As INStyleable)
			If styleable Is Nothing Then
				Return
			End If

			Dim arrowheadStyle As NArrowheadStyle = styleable.ComposeEndArrowheadStyle()
			Dim newArrowheadStyle As NArrowheadStyle = Nothing

			If NArrowheadStyleTypeEditor.Edit(arrowheadStyle, newArrowheadStyle, False, Not arrowheadStyle Is NStyle.GetEndArrowheadStyle(styleable)) Then
				NStyle.SetEndArrowheadStyle(styleable, newArrowheadStyle)
				document.RefreshAllViews()
			End If
		End Sub
		''' <summary>
		''' Shows the stroke style editor for the specified styleable node
		''' </summary>
		''' <param name="styleable"></param>
		Protected Sub ShowStrokeStyleEditor(ByVal styleable As INStyleable)
			If styleable Is Nothing Then
				Return
			End If

			Dim strokeStyle As NStrokeStyle = styleable.ComposeStrokeStyle()
			Dim newStrokeStyle As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(strokeStyle, newStrokeStyle) Then
				NStyle.SetStrokeStyle(styleable, newStrokeStyle)
				document.RefreshAllViews()
			End If
		End Sub
		''' <summary>
		''' Shows the shadow style editor for the specified styleable node
		''' </summary>
		''' <param name="styleable"></param>
		Protected Sub ShowShadowStyleEditor(ByVal styleable As INStyleable)
			If styleable Is Nothing Then
				Return
			End If

			Dim shadowStyle As NShadowStyle = styleable.ComposeShadowStyle()
			Dim newShadowStyle As NShadowStyle = Nothing

			If NShadowStyleTypeEditor.Edit(shadowStyle, newShadowStyle) Then
				NStyle.SetShadowStyle(styleable, newShadowStyle)
				document.RefreshAllViews()
			End If
		End Sub
		''' <summary>
		''' Shows the fill style editor for the specified styleable node
		''' </summary>
		''' <param name="styleable"></param>
		Protected Sub ShowFillStyleEditor(ByVal styleable As INStyleable)
			If styleable Is Nothing Then
				Return
			End If

			Dim fillStyle As NFillStyle = styleable.ComposeFillStyle()
			Dim newFillStyle As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(fillStyle, newFillStyle) Then
				NStyle.SetFillStyle(styleable, newFillStyle)
				document.RefreshAllViews()
			End If
		End Sub
		''' <summary>
		''' Shows the bridge style edtior for the specified styleable node
		''' </summary>
		''' <param name="styleable"></param>
		Protected Sub ShowBridgeStyleEditor(ByVal styleable As INStyleable)
			If styleable Is Nothing Then
				Return
			End If

			Dim bridgeStyle As NBridgeStyle = styleable.ComposeBridgeStyle()
			Dim newBridgeStyle As NBridgeStyle = Nothing

			If NBridgeStyleTypeEditor.Edit(bridgeStyle, newBridgeStyle, Not bridgeStyle Is NStyle.GetBridgeStyle(styleable)) Then
				NStyle.SetBridgeStyle(styleable, newBridgeStyle)
				document.RefreshAllViews()
			End If
		End Sub
		''' <summary>
		''' Shows the text style edtior for the specified styleable node
		''' </summary>
		''' <param name="styleable"></param>
		Protected Sub ShowTextStyleEditor(ByVal styleable As INStyleable)
			If styleable Is Nothing Then
				Return
			End If

			Dim textStyle As NTextStyle = styleable.ComposeTextStyle()
			Dim newTextStyle As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(textStyle, Not textStyle Is NStyle.GetTextStyle(styleable), newTextStyle) Then
				NStyle.SetTextStyle(styleable, newTextStyle)
				document.SmartRefreshAllViews()
			End If
		End Sub

		''' <summary>
		''' Pauses event handling for form controls. 
		''' </summary>
		Protected Sub PauseEventsHandling()
			eventHandlingPauseCounter += 1
		End Sub
		''' <summary>
		''' Resumes event handling for form controls
		''' </summary>
		Protected Sub ResumeEventsHandling()
			If eventHandlingPauseCounter <= 0 Then
				Throw New InvalidOperationException("The event handling pause counter cannot drop below zero. PauseEventsHandling - ResumeEventsHandling calls must match")
			End If

			eventHandlingPauseCounter -= 1
		End Sub

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
		Protected Function CreateBasicShape(ByVal basicShape As BasicShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal styleSheetName As String) As NShape
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			factory.DefaultSize = bounds.Size
			Dim shape As NShape = factory.CreateShape(CInt(Fix(basicShape)))

			shape.Location = bounds.Location
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
		Protected Function CreateFlowChartingShape(ByVal flowChartShape As FlowChartingShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal styleSheetName As String) As NShape
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
		Protected Function CreateConnector(ByVal fromShape As NShape, ByVal fromPortName As String, ByVal toShape As NShape, ByVal toPortName As String, ByVal connectorType As ConnectorType, ByVal text As String) As NShape
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

		#Region "Event Handlers"

		''' <summary>
		''' Invoked when the Reset Example button is clicked. 
		''' The Reset Example button is present in all examples
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub ResetExampleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetExampleButton.Click
			ResetExample()
		End Sub
		''' <summary>
		''' Invoked when the Graphics Settings button is clicked
		''' The Graphics Settings button is present in all examples.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub GraphicsSettingsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GraphicsSettingsButton.Click
			Try
				Dim hash As Hashtable = New Hashtable()
				Dim newDoc As NDrawingDocument = CType(document.Clone(), NDrawingDocument)
				Me.view.Document = newDoc
				Return
			Catch ex As Exception
				Trace.Write(ex.Message)
			End Try

			Dim result As NGraphicsSettings = Nothing
			If NGraphicsSettingsTypeEditor.Edit(document.GraphicsSettings, result) = False Then
				Return
			End If

			document.GraphicsSettings = result
			view.Refresh()
		End Sub

		#End Region

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

		''' <summary>
		''' Obtains a reference to the main form
		''' </summary>
		Protected ReadOnly Property Form() As NMainForm
			Get
				Return TryCast(MyBase.m_MainForm, NMainForm)
			End Get
		End Property

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents GraphicsSettingsButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ResetExampleButton As Nevron.UI.WinForm.Controls.NButton
		Friend commonControlsPanel As System.Windows.Forms.Panel

		#End Region

		#Region "Fields"

		Protected document As NDrawingDocument
		Protected view As NDrawingView

		Private eventHandlingPauseCounter As Integer = 0
		Private defaultGridCellSize_Renamed As NSizeF
		Private defaultGridOrigin_Renamed As NPointF
		Private defaultGridSpacing_Renamed As NSizeF

		#End Region
	End Class
End Namespace