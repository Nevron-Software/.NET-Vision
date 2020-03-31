Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Imports Nevron.Diagram
Imports Nevron.Diagram.DataImport
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NTreeDataImportUC.
	''' </summary>
	Partial Public Class NTreeDataImportUC
		Inherits NDiagramExampleUC
#Region "Implementation"

		Private Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document
			document.BackgroundStyle.FrameStyle.Visible = False

			' create two stylesheets - one for the vertices and one for the edges
			Dim vertexStyleSheet As NStyleSheet = New NStyleSheet()
			vertexStyleSheet.Name = "Vertices"
			vertexStyleSheet.Style.FillStyle = New NColorFillStyle(Color.FromArgb(236, 97, 49))
			document.StyleSheets.AddChild(vertexStyleSheet)

			Dim edgeStyleSheet As NStyleSheet = New NStyleSheet()
			edgeStyleSheet.Name = "Edges"
			edgeStyleSheet.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(68, 90, 108))
			document.StyleSheets.AddChild(edgeStyleSheet)

			' create the tree data source importer
			Dim treeImporter As NTreeDataSourceImporter = New NTreeDataSourceImporter()

			' set the document in the active layer of which the shapes will be imported
			treeImporter.Document = document

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
			' which selects all columns and records from the Pages table of the SiteMap.mdb
			Dim databasePath As String = HttpContext.Current.Server.MapPath("..\App_Data\SiteMap.xml")
			Dim dataSet As DataSet = New DataSet()
			dataSet.ReadXml(databasePath, XmlReadMode.ReadSchema)

			treeImporter.DataSource = dataSet.Tables("Pages")

			' records are uniquely identified by their Id column
			' records link to their parent record by their ParentId column
			treeImporter.IdColumnName = "Id"
			treeImporter.ParentIdColumnName = "ParentId"

			' create vertices as rectangles shapes, with default size (60,30)
			Dim shapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			shapesFactory.DefaultSize = New NSizeF(60, 30)
			treeImporter.VertexShapesFactory = shapesFactory
			treeImporter.VertexShapesName = BasicShapes.Rectangle.ToString()

			' set stylesheets to be applied to imported vertices and edges
			treeImporter.VertexStyleSheetName = "Vertices"
			treeImporter.EdgeStyleSheetName = "Edges"

			' use layered tree layout
			Dim layout As NLayeredTreeLayout = New NLayeredTreeLayout()
			layout.Direction = LayoutDirection.LeftToRight
			layout.OrthogonalEdgeRouting = True
			layout.LayerAlignment = RelativeAlignment.Near
			treeImporter.Layout = layout

			' subscribe for the vertex imported event,
			' which is raised when a shape was created for a data source record
			AddHandler treeImporter.VertexImported, AddressOf OnVertexImported

			' import
			treeImporter.Import()
		End Sub

#End Region

#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			' view init
			NDrawingView1.ViewLayout = CanvasLayout.Normal

			' init document
			NDrawingView1.Document.BeginInit()
			InitDocument()
			NDrawingView1.Document.EndInit()
		End Sub
		''' <summary>
		''' Called when a vertex shape was created by the NTreeDataSourceImporter for the specified data record
		''' </summary>
		''' <param name="importer"></param>
		''' <param name="shape"></param>
		''' <param name="dataRecord"></param>
		Private Sub OnVertexImported(ByVal importer As NDataSourceImporter, ByVal shape As NShape, ByVal dataRecord As INDataRecord)
			' display the page title in the shape
			Dim text As Object = dataRecord.GetColumnValue("Title")
			If text Is Nothing Then
				shape.Text = "Title not specified"
			Else
				shape.Text = text.ToString()
			End If

			shape.SizeToText(New NMarginsF(10))
		End Sub

#End Region
	End Class
End Namespace