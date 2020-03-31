Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Globalization
Imports System.Reflection

Imports Nevron.Diagram
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NDrawingDocumentHelper.
	''' </summary>
	Public Class NDrawingDocumentHelper
		#Region "Constructors"

		Public Sub New(ByVal document As NDrawingDocument)
			Me.document = document
		End Sub

		#End Region

		#Region "Properties"

		''' <summary>
		''' Gets/sets the default grid cell size
		''' </summary>
		Public Property DefaultGridCellSize() As NSizeF
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
		Public Property DefaultGridOrigin() As NPointF
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
		Public Property DefaultGridSpacing() As NSizeF
			Get
				Return defaultGridSpacing_Renamed
			End Get
			Set
				defaultGridSpacing_Renamed = Value
			End Set
		End Property

		#End Region

		#Region "Public Methods"

		''' <summary>
		''' Creates a connector between the ports of the specified shapes
		''' </summary>
		''' <param name="fromShape"></param>
		''' <param name="fromPortName"></param>
		''' <param name="toShape"></param>
		''' <param name="toPortName"></param>
		''' <param name="connectorType"></param>
		''' <param name="text"></param>
		''' <returns></returns>
		Public Function CreateConnector(ByVal fromShape As NShape, ByVal fromPortName As String, ByVal toShape As NShape, ByVal toPortName As String, ByVal connectorType As ConnectorType, ByVal text As String) As NShape
			' check input
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

			connector.StartPlug.Connect(fromPort)
			connector.EndPlug.Connect(toPort)

			connector.Style.TextStyle = (TryCast(connector.ComposeTextStyle().Clone(), NTextStyle))
			connector.Style.TextStyle.Offset = New Nevron.GraphicsCore.NPointL(0, -7)

			connector.Text = text
			Return connector
		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="basicShape"></param>
		''' <param name="bounds"></param>
		''' <param name="text"></param>
		''' <param name="fillStyle"></param>
		''' <returns></returns>
		Public Function CreateBasicShape(ByVal basicShape As BasicShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal fillStyle As NFillStyle) As NShape
			Return CreateBasicShape(basicShape, bounds, text, fillStyle, True)
		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="basicShape"></param>
		''' <param name="bounds"></param>
		''' <param name="text"></param>
		''' <param name="fillStyle"></param>
		''' <param name="addToActiveLayer"></param>
		''' <returns></returns>
		Public Function CreateBasicShape(ByVal basicShape As BasicShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal fillStyle As NFillStyle, ByVal addToActiveLayer As Boolean) As NShape
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(basicShape)))

			shape.Bounds = bounds
			shape.Text = text
			shape.Style.FillStyle = CType(fillStyle.Clone(), NFillStyle)

			If addToActiveLayer Then
				document.ActiveLayer.AddChild(shape)
			End If

			Return shape
		End Function
		''' <summary>
		''' Creates a new basic shape and adds it to the document's active layer.
		''' </summary>
		''' <param name="basicShape"></param>
		''' <param name="bounds"></param>
		''' <param name="text"></param>
		''' <param name="styleSheetName"></param>
		''' <returns></returns>
		Public Function CreateBasicShape(ByVal basicShape As BasicShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal styleSheetName As String) As NShape
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(basicShape)))

			shape.Bounds = bounds
			shape.Text = text
			shape.StyleSheetName = styleSheetName
			document.ActiveLayer.AddChild(shape)

			Return shape

		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="flowChartingShape"></param>
		''' <param name="bounds"></param>
		''' <param name="text"></param>
		''' <param name="fillStyle"></param>
		''' <returns></returns>
		Public Function CreateFlowChartingShape(ByVal flowChartingShape As FlowChartingShapes, ByVal bounds As NRectangleF, ByVal text As String, ByVal fillStyle As NFillStyle) As NShape
			Dim factory As NFlowChartingShapesFactory = New NFlowChartingShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(flowChartingShape)))

			shape.Bounds = bounds
			shape.Text = text
			shape.Style.FillStyle = CType(fillStyle.Clone(), NFillStyle)

			document.ActiveLayer.AddChild(shape)

			Return shape
		End Function
		''' <summary>
		''' 
		''' </summary>
		''' <param name="row"></param>
		''' <param name="col"></param>
		''' <returns></returns>
		Public Function GetGridCell(ByVal row As Integer, ByVal col As Integer) As NRectangleF
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
		Public Function GetGridCell(ByVal row As Integer, ByVal col As Integer, ByVal rowSpan As Integer, ByVal colSpan As Integer) As NRectangleF
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
		Public Function GetGridCell(ByVal row As Integer, ByVal col As Integer, ByVal origin As NPointF, ByVal size As NSizeF, ByVal spacing As NSizeF) As NRectangleF
			Return New NRectangleF(origin.X + col * (size.Width + spacing.Width), origin.Y + row * (size.Height + spacing.Height), size.Width, size.Height)
		End Function
		''' <summary>
		''' Parses the given string to float using the proper decimal separator.
		''' </summary>
		''' <param name="value"></param>
		''' <returns></returns>
		Public Function ParseFloat(ByVal value As String) As Single
			If value.Contains(".") Then
				value = value.Replace(".", DecimalSeparator)
			ElseIf value.Contains(",") Then
				value = value.Replace(",", DecimalSeparator)
			End If

			Return Single.Parse(value)
		End Function

		''' <summary>
		''' Configures the layout using the property/value pairs in the specified dictionary.
		''' </summary>
		''' <param name="layout"></param>
		''' <param name="settings"></param>
		Public Sub ConfigureLayout(ByVal layout As NLayout, ByVal settings As Dictionary(Of String, String))
			Dim layoutType As Type = layout.GetType()
			Dim iter As Dictionary(Of String, String).Enumerator = settings.GetEnumerator()

			Do While iter.MoveNext()
				Dim name As String = iter.Current.Key
				Dim value As String = iter.Current.Value

				Dim p As PropertyInfo = layoutType.GetProperty(name)
				If p Is Nothing Then
					Continue Do
				End If

				Try
					Dim propertyValue As Object = Nothing
					If p.PropertyType.Equals(FloatType) Then
						propertyValue = ParseFloat(value)
					Else
						If p.PropertyType.IsEnum Then
							propertyValue = System.Enum.Parse(p.PropertyType, value)
						Else
							propertyValue = Convert.ChangeType(value, p.PropertyType)
						End If
					End If

					p.SetValue(layout, propertyValue, Nothing)
				Catch
					Throw New Exception(String.Format("The value '{0}' is not valid for the '{1}' property", value, name))
				End Try
			Loop
		End Sub
		''' <summary>
		''' Parses the given string of key/value pairs to a dictionary. The string should be in the format:
		''' <para>
		''' name1=value1
		''' </para>
		''' <para>
		''' name2=value2
		''' </para>
		''' <para>
		''' etc.
		''' </para>
		''' </summary>
		''' <param name="settings"></param>
		''' <returns></returns>
		Public Function ParseSettings(ByVal settings As String) As Dictionary(Of String, String)
			Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)()
			Dim lines As String() = settings.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries)
			Dim i As Integer = 0
			Dim lineCount As Integer = lines.Length
			Do While i < lineCount
				Dim lineData As String() = lines(i).Split("="c)
				dict.Add(lineData(0), lineData(1))
				i += 1
			Loop

			Return dict
		End Function

		#End Region

		#Region "Fields"

		' document and view
		Protected document As NDrawingDocument

		' random number generator
		Protected random As Random

		' form controls event handling lock
		'private int suspendEventHandlingLock = 0;

		' grid
		Private defaultGridCellSize_Renamed As NSizeF
		Private defaultGridOrigin_Renamed As NPointF
		Private defaultGridSpacing_Renamed As NSizeF

		#End Region

		#Region "Constants"

		Private ReadOnly DecimalSeparator As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

		Private Shared ReadOnly FloatType As Type = GetType(Single)
		Private Shared ReadOnly LineSeparators As Char() = New Char() { ControlChars.Lf }

		#End Region
	End Class
End Namespace