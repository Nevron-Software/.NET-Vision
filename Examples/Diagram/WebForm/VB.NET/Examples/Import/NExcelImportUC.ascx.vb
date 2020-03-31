Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.DataImport
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NExcelImportUC.
	''' </summary>
	Partial Public Class NExcelImportUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' create some shape factories
			m_FilesAndFoldersFactory = New NFilesAndFoldersFactory()
			m_FilesAndFoldersFactory.DefaultSize = VertexSize

			m_BusinessProcessShapesFactory = New NBusinessProcessShapesFactory()
			m_BusinessProcessShapesFactory.DefaultSize = SymbolSize

			' import the data
			NDrawingView1.Document.BeginInit()
			ImportData()
			NDrawingView1.Document.EndInit()

			' size the view to its content
			NDrawingView1.SizeToContent()
		End Sub

#Region "Implementation"

		Private Sub ImportData()
			Dim document As NDrawingDocument = NDrawingView1.Document
			document.BackgroundStyle.FrameStyle.Visible = False

			' create two stylesheets - one for the vertices and one for the edges
			Dim vertexStyleSheet As NStyleSheet = New NStyleSheet()
			vertexStyleSheet.Name = "Vertices"
			NStyle.SetFillStyle(vertexStyleSheet, New NColorFillStyle(Color.FromArgb(236, 97, 49)))
			document.StyleSheets.AddChild(vertexStyleSheet)

			Dim edgeStyleSheet As NStyleSheet = New NStyleSheet()
			edgeStyleSheet.Name = "Edges"
			NStyle.SetStrokeStyle(edgeStyleSheet, New NStrokeStyle(Color.Blue))
			NStyle.SetEndArrowheadStyle(edgeStyleSheet, New NArrowheadStyle(ArrowheadShape.OpenedArrow, Nothing, New NSizeL(6, 4), Nothing, New NStrokeStyle(Color.Blue)))
			Dim textStyle As NTextStyle = CType(document.ComposeTextStyle().Clone(), NTextStyle)
			textStyle.StringFormatStyle.VertAlign = Nevron.VertAlign.Bottom
			NStyle.SetTextStyle(edgeStyleSheet, textStyle)
			document.StyleSheets.AddChild(edgeStyleSheet)

			' create the graph data source importer
			Dim graphImporter As NGraphDataSourceImporter = New NGraphDataSourceImporter()

			' set the document in the active layer of which the shapes will be imported
			graphImporter.Document = document

			' SET THE DATA SOURCE
			' the tree data source importer supports the following data sources
			'      DataTable
			'      DataView 
			'      OleDbDataAdapter
			'      SqlDataAdapter
			'      OdbcDataAdapter
			'      OleDbCommand
			'      SqlCommand
			'      OdbcCommand
			' in this example we have created an OleDbDataAdapter, 
			' which selects all columns and records from the Sources and Links tables of the Data.xlsx file
			Dim databasePath As String = Server.MapPath("..\Examples\Import\Data.xlsx")
			Dim connectionString As String = "Data Source=""" & databasePath & """;Provider=""Microsoft.ACE.OLEDB.12.0""; Extended Properties=""Excel 12.0 Xml;HDR=YES"";"

			graphImporter.VertexDataSource = New OleDbDataAdapter("SELECT * FROM [Sources$]", connectionString)
			graphImporter.EdgeDataSource = New OleDbDataAdapter("SELECT * FROM [Links$]", connectionString)

			' vertex records are uniquely identified by their Id (in the Sources table)
			' edges link the vertices with the Fro and ToPageId (in the Links table)
			graphImporter.VertexIdColumnName = "Id"
			graphImporter.FromVertexIdColumnName = "From"
			graphImporter.ToVertexIdColumnName = "To"

			' create vertices as group shapes, with default size
			Dim shapesFactory As NShapesFactory = New GroupShapesFactory()
			shapesFactory.DefaultSize = VertexSize
			graphImporter.VertexShapesFactory = shapesFactory
			graphImporter.VertexShapesName = GroupShapes.Group.ToString()

			' set stylesheets to be applied to imported vertices and edges
			graphImporter.VertexStyleSheetName = "Vertices"
			graphImporter.EdgeStyleSheetName = "Edges"

			' use layered graph layout
			Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()
			layout.LayerSpacing = 70
			layout.Direction = LayoutDirection.LeftToRight
			layout.LayerAlignment = RelativeAlignment.Near
			graphImporter.Layout = layout

			' subscribe for the vertex and edge imported events,
			' which are raised when a shape was created for a data source record
			AddHandler graphImporter.VertexImported, AddressOf OnVertexImported
			AddHandler graphImporter.EdgeImported, AddressOf OnEdgeImported

			' import
			graphImporter.Import()
		End Sub

#End Region

#Region "Event Handlers"

		Private Sub OnVertexImported(ByVal importer As NDataSourceImporter, ByVal shape As NShape, ByVal dataRecord As INDataRecord)
			' Create a shape to host in the group based on the value of the "Type" column
			Dim innerShape As NShape = Nothing
			Select Case dataRecord.GetColumnValue("Type").ToString()
				Case "DB"
					innerShape = m_FilesAndFoldersFactory.CreateShape(FilesAndFoldersShapes.Binder)
				Case "File"
					innerShape = m_FilesAndFoldersFactory.CreateShape(FilesAndFoldersShapes.SimpleFolder)
				Case "Report"
					innerShape = m_FilesAndFoldersFactory.CreateShape(FilesAndFoldersShapes.BlankFile)
			End Select

			innerShape.Text = dataRecord.GetColumnValue("Id").ToString()

			' Host the created shape in the group
			Dim group As NGroup = CType(shape, NGroup)
			group.Shapes.AddChild(innerShape)
			group.UpdateModelBounds()
		End Sub
		Private Sub OnEdgeImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal dataRecord As INDataRecord)
			' Set the text of the edge
			shape.Text = dataRecord.GetColumnValue("Desc").ToString()

			' Get the symbol name if any
			Dim symbol As Object = dataRecord.GetColumnValue("Symbol")
			If symbol Is Nothing OrElse Convert.IsDBNull(symbol) Then
				Return
			End If

			' Add a logical line port
			Dim linePort As NLogicalLinePort = New NLogicalLinePort(20)
			shape.CreateShapeElements(ShapeElementsMask.Ports)
			shape.Ports.AddChild(linePort)

			' Attach a custom shape based on the symbol name
			Dim customShape As NShape = Nothing
			Select Case symbol.ToString()
				Case "Stop"
					customShape = m_BusinessProcessShapesFactory.CreateShape(BusinessProcessShapes.StopAccepted)
				Case "Question"
					customShape = m_BusinessProcessShapesFactory.CreateShape(BusinessProcessShapes.Question)
			End Select

			CType(shape.Document, NDrawingDocument).ActiveLayer.AddChild(customShape)

			' Add an outward port to the shape
			Dim outwardPort As NRotatedBoundsPort = New NRotatedBoundsPort(New NContentAlignment(ContentAlignment.MiddleCenter))
			outwardPort.Type = PortType.Outward
			customShape.CreateShapeElements(ShapeElementsMask.Ports)
			customShape.Ports.AddChild(outwardPort)

			outwardPort.Connect(linePort)
		End Sub

#End Region

#Region "Fields"

		Private m_FilesAndFoldersFactory As NFilesAndFoldersFactory
		Private m_BusinessProcessShapesFactory As NBusinessProcessShapesFactory

#End Region

#Region "Constants"

		Private Shared ReadOnly VertexSize As NSizeF = New NSizeF(60, 60)
		Private Shared ReadOnly SymbolSize As NSizeF = New NSizeF(20, 20)

#End Region

#Region "Nested Types"

		Private Class GroupShapesFactory
			Inherits NShapesFactory
			Public Sub New()
				MyBase.New("Group Shapes")
			End Sub

			Public Overrides ReadOnly Property ShapesCount() As Integer
				Get
					Return System.Enum.GetValues(GetType(GroupShapes)).Length
				End Get
			End Property

			Public Overrides Function CreateShape(ByVal index As Integer) As NShape
				Dim group As NGroup = New NGroup()
				CreateCenterAndSidesPorts(group)
				Return group
			End Function

			Protected Overrides Function CreateShapeInfo(ByVal index As Integer) As NShapeInfo
				Dim shape As GroupShapes = CType(index, GroupShapes)
				Dim name As String = NSystem.InsertSpacesBeforeUppers(shape.ToString())
				Dim info As NShapeInfo = New NShapeInfo(name)
				Return info
			End Function
			Protected Overrides Function GetEnumType() As Type
				Return GetType(GroupShapes)
			End Function
		End Class

		Private Enum GroupShapes
			Group
		End Enum

#End Region
	End Class
End Namespace