Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.DataImport
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NTreeDataImportUC.
	''' </summary>
	Public Class NTreeDataImportUC
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
			Me.oleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbConnection1 = New System.Data.OleDb.OleDbConnection()
			Me.oleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter()
			Me.SuspendLayout()
			' 
			' oleDbSelectCommand1
			' 
			Me.oleDbSelectCommand1.CommandText = "select * from Pages"
			Me.oleDbSelectCommand1.Connection = Me.oleDbConnection1
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
			' oleDbDataAdapter1
			' 
			Me.oleDbDataAdapter1.DeleteCommand = Me.oleDbDeleteCommand1
			Me.oleDbDataAdapter1.InsertCommand = Me.oleDbInsertCommand1
			Me.oleDbDataAdapter1.SelectCommand = Me.oleDbSelectCommand1
			Me.oleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Pages", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Id", "Id"), New System.Data.Common.DataColumnMapping("ParentId", "ParentId"), New System.Data.Common.DataColumnMapping("Title", "Title"), New System.Data.Common.DataColumnMapping("URL", "URL")})})
			Me.oleDbDataAdapter1.UpdateCommand = Me.oleDbUpdateCommand1
			' 
			' NTreeDataImportUC
			' 
			Me.Name = "NTreeDataImportUC"
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

			' create the tree data source importer
			m_TreeImporter = New NTreeDataSourceImporter()

			' set the document in the active layer of which the shapes will be imported
			m_TreeImporter.Document = document

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
			oleDbConnection1.ConnectionString = "Data Source=""" & Application.StartupPath & "\..\..\Resources\Data\SiteMap.mdb"";Provider=""Microsoft.Jet.OLEDB.4.0"";"

			m_TreeImporter.DataSource = oleDbDataAdapter1

			' records are uniquely identified by their Id column
			' records link to their parent record by their ParentId column
			m_TreeImporter.IdColumnName = "Id"
			m_TreeImporter.ParentIdColumnName = "ParentId"

			' create vertices as rectangles shapes, with default size (60,30)
			Dim shapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			shapesFactory.DefaultSize = New NSizeF(60, 30)
			m_TreeImporter.VertexShapesFactory = shapesFactory
			m_TreeImporter.VertexShapesName = BasicShapes.Rectangle.ToString()

			' set stylesheets to be applied to imported vertices and edges
			m_TreeImporter.VertexStyleSheetName = "Vertices"
			m_TreeImporter.EdgeStyleSheetName = "Edges"

			' use layered tree layout
			Dim layout As NLayeredTreeLayout = New NLayeredTreeLayout()
			layout.Direction = LayoutDirection.LeftToRight
			layout.OrthogonalEdgeRouting = True
			layout.LayerAlignment = RelativeAlignment.Near
			m_TreeImporter.Layout = layout

			' subscribe for the vertex imported event,
			' which is raised when a shape was created for a data source record
			AddHandler m_TreeImporter.VertexImported, AddressOf OnVertexImported

			' import
			m_TreeImporter.Import()

			' end view init
			view.EndInit()
		End Sub

#End Region

#Region "Event Handlers"

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
		Private oleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter

#End Region

#Region "Fields"

		Private m_TreeImporter As NTreeDataSourceImporter

#End Region
	End Class
End Namespace