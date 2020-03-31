Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.DataImport

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NGraphDataImportUC.
	''' </summary>
	Public Class NGraphDataImportUC
		Inherits NDiagramExampleUC
#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

#End Region

#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NGraphDataImportUC))
			Me.oleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbConnection1 = New System.Data.OleDb.OleDbConnection()
			Me.oleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.PagesDataAdapter = New System.Data.OleDb.OleDbDataAdapter()
			Me.oleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbInsertCommand2 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbUpdateCommand2 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbDeleteCommand2 = New System.Data.OleDb.OleDbCommand()
			Me.LinksDataAdapter = New System.Data.OleDb.OleDbDataAdapter()
			Me.oleDbConnection2 = New System.Data.OleDb.OleDbConnection()
			Me.SuspendLayout()
			' 
			' oleDbSelectCommand1
			' 
			Me.oleDbSelectCommand1.CommandText = "select * from Pages"
			Me.oleDbSelectCommand1.Connection = Me.oleDbConnection1
			' 
			' oleDbConnection1
			' 
			Me.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DataBinding\SiteMap." & "mdb;Persist Security Info=True"
			' 
			' oleDbInsertCommand1
			' 
			Me.oleDbInsertCommand1.CommandText = "INSERT INTO `Pages` (`ParentId`, `Title`, `URL`) VALUES (?, ?, ?)"
			Me.oleDbInsertCommand1.Connection = Me.oleDbConnection1
			Me.oleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ParentId", System.Data.OleDb.OleDbType.Integer, 0, "ParentId"), New System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 0, "Title"), New System.Data.OleDb.OleDbParameter("URL", System.Data.OleDb.OleDbType.LongVarWChar, 0, "URL")})
			' 
			' oleDbUpdateCommand1
			' 
			Me.oleDbUpdateCommand1.CommandText = "UPDATE `Pages` SET `ParentId` = ?, `Title` = ?, `URL` = ? WHERE ((`Id` = ?) AND (" & "(? = 1 AND `ParentId` IS NULL) OR (`ParentId` = ?)) AND ((? = 1 AND `Title` IS N" & "ULL) OR (`Title` = ?)))"
			Me.oleDbUpdateCommand1.Connection = Me.oleDbConnection1
			Me.oleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ParentId", System.Data.OleDb.OleDbType.Integer, 0, "ParentId"), New System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 0, "Title"), New System.Data.OleDb.OleDbParameter("URL", System.Data.OleDb.OleDbType.LongVarWChar, 0, "URL"), New System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "Id", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ParentId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ParentId", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ParentId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "ParentId", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Title", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Title", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "Title", System.Data.DataRowVersion.Original, Nothing)})
			' 
			' oleDbDeleteCommand1
			' 
			Me.oleDbDeleteCommand1.CommandText = "DELETE FROM `Pages` WHERE ((`Id` = ?) AND ((? = 1 AND `ParentId` IS NULL) OR (`Pa" & "rentId` = ?)) AND ((? = 1 AND `Title` IS NULL) OR (`Title` = ?)))"
			Me.oleDbDeleteCommand1.Connection = Me.oleDbConnection1
			Me.oleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "Id", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ParentId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ParentId", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ParentId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "ParentId", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Title", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Title", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "Title", System.Data.DataRowVersion.Original, Nothing)})
			' 
			' PagesDataAdapter
			' 
			Me.PagesDataAdapter.DeleteCommand = Me.oleDbDeleteCommand1
			Me.PagesDataAdapter.InsertCommand = Me.oleDbInsertCommand1
			Me.PagesDataAdapter.SelectCommand = Me.oleDbSelectCommand1
			Me.PagesDataAdapter.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Pages", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Id", "Id"), New System.Data.Common.DataColumnMapping("ParentId", "ParentId"), New System.Data.Common.DataColumnMapping("Title", "Title"), New System.Data.Common.DataColumnMapping("URL", "URL")})})
			Me.PagesDataAdapter.UpdateCommand = Me.oleDbUpdateCommand1
			' 
			' oleDbSelectCommand2
			' 
			Me.oleDbSelectCommand2.CommandText = "select * from Links"
			Me.oleDbSelectCommand2.Connection = Me.oleDbConnection2
			' 
			' oleDbInsertCommand2
			' 
			Me.oleDbInsertCommand2.CommandText = "INSERT INTO `Links` (`FromPageId`, `ToPageId`, `Title`) VALUES (?, ?, ?)"
			Me.oleDbInsertCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("FromPageId", System.Data.OleDb.OleDbType.Integer, 0, "FromPageId"), New System.Data.OleDb.OleDbParameter("ToPageId", System.Data.OleDb.OleDbType.Integer, 0, "ToPageId"), New System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 0, "Title")})
			' 
			' oleDbUpdateCommand2
			' 
			Me.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText")
			Me.oleDbUpdateCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("FromPageId", System.Data.OleDb.OleDbType.Integer, 0, "FromPageId"), New System.Data.OleDb.OleDbParameter("ToPageId", System.Data.OleDb.OleDbType.Integer, 0, "ToPageId"), New System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 0, "Title"), New System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "id", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_FromPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "FromPageId", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_FromPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "FromPageId", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ToPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ToPageId", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ToPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "ToPageId", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Title", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Title", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "Title", System.Data.DataRowVersion.Original, Nothing)})
			' 
			' oleDbDeleteCommand2
			' 
			Me.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText")
			Me.oleDbDeleteCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "id", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_FromPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "FromPageId", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_FromPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "FromPageId", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ToPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ToPageId", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ToPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "ToPageId", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Title", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Title", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "Title", System.Data.DataRowVersion.Original, Nothing)})
			' 
			' LinksDataAdapter
			' 
			Me.LinksDataAdapter.DeleteCommand = Me.oleDbDeleteCommand2
			Me.LinksDataAdapter.InsertCommand = Me.oleDbInsertCommand2
			Me.LinksDataAdapter.SelectCommand = Me.oleDbSelectCommand2
			Me.LinksDataAdapter.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Links", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("id", "id"), New System.Data.Common.DataColumnMapping("FromPageId", "FromPageId"), New System.Data.Common.DataColumnMapping("ToPageId", "ToPageId"), New System.Data.Common.DataColumnMapping("Title", "Title")})})
			Me.LinksDataAdapter.UpdateCommand = Me.oleDbUpdateCommand2
			' 
			' NGraphDataImportUC
			' 
			Me.Name = "NGraphDataImportUC"
			Me.Size = New System.Drawing.Size(248, 560)
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' configure the view
			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single
			view.GlobalVisibility.ShowPorts = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False

			' create two stylesheets - one for the vertices and one for the edges
			Dim vertexStyleSheet As NStyleSheet = New NStyleSheet()
			vertexStyleSheet.Name = "Vertices"
			vertexStyleSheet.Style.FillStyle = New NColorFillStyle(Color.FromArgb(236, 97, 49))
			document.StyleSheets.AddChild(vertexStyleSheet)

			Dim edgeStyleSheet As NStyleSheet = New NStyleSheet()
			edgeStyleSheet.Name = "Edges"
			edgeStyleSheet.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(68, 90, 108))
			document.StyleSheets.AddChild(edgeStyleSheet)

			' configure the graph data source importer
			m_GraphImporter = New NGraphDataSourceImporter()

			' set the document in the active layer of which the shapes will be imported
			m_GraphImporter.Document = document

			' set the data sources
			' the graph data source importer supports the following data sources
			'      DataTable
			'      DataView 
			'      OleDbDataAdapter
			'      SqlDataAdapter
			'      OdbcDataAdapter
			'      OleDbCommand
			'      SqlCommand
			'      OdbcCommand
			' in this example we have created two OleDbDataAdapters: 
			' the PagesDataAdapter selects all records and columns from the Pages table of the SiteMap.mdb
			' the LinksDataAdapter selects all records and columns from the Links table of the SiteMap.mdb
			oleDbConnection1.ConnectionString = "Data Source=""" & Application.StartupPath & "\..\..\Resources\Data\SiteMap.mdb"";Provider=""Microsoft.Jet.OLEDB.4.0"";"
			oleDbConnection2.ConnectionString = "Data Source=""" & Application.StartupPath & "\..\..\Resources\Data\SiteMap.mdb"";Provider=""Microsoft.Jet.OLEDB.4.0"";"

			m_GraphImporter.VertexDataSource = PagesDataAdapter
			m_GraphImporter.EdgeDataSource = LinksDataAdapter

			' vertex records are uniquely identified by their Id (in the Pages table)
			' edges link the vertices with the FromPageId and ToPageId (in the Links table)
			m_GraphImporter.VertexIdColumnName = "Id"
			m_GraphImporter.FromVertexIdColumnName = "FromPageId"
			m_GraphImporter.ToVertexIdColumnName = "ToPageId"

			' create vertices as rectangles shapes, with default size (60, 30)
			Dim shapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			shapesFactory.DefaultSize = New NSizeF(60, 30)
			m_GraphImporter.VertexShapesFactory = shapesFactory
			m_GraphImporter.VertexShapesName = BasicShapes.Rectangle.ToString()

			' set stylesheets to be applied to imported vertices and edges
			m_GraphImporter.VertexStyleSheetName = "Vertices"
			m_GraphImporter.EdgeStyleSheetName = "Edges"

			' use layered graph layout
			Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()
			layout.Direction = LayoutDirection.LeftToRight
			layout.LayerAlignment = RelativeAlignment.Near
			m_GraphImporter.Layout = layout

			' subscribe for the vertex imported event,
			' which is raised when a shape was created for a data source record
			AddHandler m_GraphImporter.VertexImported, AddressOf OnVertexImported

			' import
			m_GraphImporter.Import()

			' end view init
			view.EndInit()
		End Sub

#End Region

#Region "Event Handlers"

		''' <summary>
		''' Called when a vertex shape was created by the NGraphDataSourceImporter for the specified data record
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

			' make the URL a tooltip of the shape
			Dim url As Object = dataRecord.GetColumnValue("URL")
			If url Is Nothing OrElse url.ToString().Length = 0 Then
				shape.Style.InteractivityStyle = New NInteractivityStyle("URL not specified")
			Else
				shape.Style.InteractivityStyle = New NInteractivityStyle(url.ToString())
			End If
		End Sub

#End Region

#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private oleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
		Private oleDbConnection1 As System.Data.OleDb.OleDbConnection
		Private oleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
		Private oleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
		Private oleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
		Private PagesDataAdapter As System.Data.OleDb.OleDbDataAdapter
		Private oleDbSelectCommand2 As System.Data.OleDb.OleDbCommand
		Private oleDbInsertCommand2 As System.Data.OleDb.OleDbCommand
		Private oleDbUpdateCommand2 As System.Data.OleDb.OleDbCommand
		Private oleDbDeleteCommand2 As System.Data.OleDb.OleDbCommand
		Private LinksDataAdapter As System.Data.OleDb.OleDbDataAdapter
		Private oleDbConnection2 As System.Data.OleDb.OleDbConnection

#End Region

#Region "Fields"

		Private m_GraphImporter As NGraphDataSourceImporter

#End Region
	End Class
End Namespace