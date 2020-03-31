using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Filters;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Layout;
using Nevron.Diagram.DataImport;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NGraphDataImportUC.
	/// </summary>
	public class NGraphDataImportUC : NDiagramExampleUC
	{
		#region Constructor

		public NGraphDataImportUC(NMainForm form) : base(form)
		{
            InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		
        /// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NGraphDataImportUC));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.PagesDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.LinksDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
            this.SuspendLayout();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "select * from Pages";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DataBinding\\SiteMap." +
                "mdb;Persist Security Info=True";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO `Pages` (`ParentId`, `Title`, `URL`) VALUES (?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ParentId", System.Data.OleDb.OleDbType.Integer, 0, "ParentId"),
            new System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 0, "Title"),
            new System.Data.OleDb.OleDbParameter("URL", System.Data.OleDb.OleDbType.LongVarWChar, 0, "URL")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE `Pages` SET `ParentId` = ?, `Title` = ?, `URL` = ? WHERE ((`Id` = ?) AND (" +
                "(? = 1 AND `ParentId` IS NULL) OR (`ParentId` = ?)) AND ((? = 1 AND `Title` IS N" +
                "ULL) OR (`Title` = ?)))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ParentId", System.Data.OleDb.OleDbType.Integer, 0, "ParentId"),
            new System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 0, "Title"),
            new System.Data.OleDb.OleDbParameter("URL", System.Data.OleDb.OleDbType.LongVarWChar, 0, "URL"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ParentId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ParentId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ParentId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ParentId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Title", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM `Pages` WHERE ((`Id` = ?) AND ((? = 1 AND `ParentId` IS NULL) OR (`Pa" +
                "rentId` = ?)) AND ((? = 1 AND `Title` IS NULL) OR (`Title` = ?)))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ParentId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ParentId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ParentId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ParentId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Title", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, null)});
            // 
            // PagesDataAdapter
            // 
            this.PagesDataAdapter.DeleteCommand = this.oleDbDeleteCommand1;
            this.PagesDataAdapter.InsertCommand = this.oleDbInsertCommand1;
            this.PagesDataAdapter.SelectCommand = this.oleDbSelectCommand1;
            this.PagesDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Pages", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ParentId", "ParentId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("URL", "URL")})});
            this.PagesDataAdapter.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "select * from Links";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection2;
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO `Links` (`FromPageId`, `ToPageId`, `Title`) VALUES (?, ?, ?)";
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("FromPageId", System.Data.OleDb.OleDbType.Integer, 0, "FromPageId"),
            new System.Data.OleDb.OleDbParameter("ToPageId", System.Data.OleDb.OleDbType.Integer, 0, "ToPageId"),
            new System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 0, "Title")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("FromPageId", System.Data.OleDb.OleDbType.Integer, 0, "FromPageId"),
            new System.Data.OleDb.OleDbParameter("ToPageId", System.Data.OleDb.OleDbType.Integer, 0, "ToPageId"),
            new System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 0, "Title"),
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FromPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FromPageId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FromPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FromPageId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ToPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ToPageId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ToPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ToPageId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Title", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText");
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FromPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FromPageId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FromPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FromPageId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ToPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ToPageId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ToPageId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ToPageId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Title", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, null)});
            // 
            // LinksDataAdapter
            // 
            this.LinksDataAdapter.DeleteCommand = this.oleDbDeleteCommand2;
            this.LinksDataAdapter.InsertCommand = this.oleDbInsertCommand2;
            this.LinksDataAdapter.SelectCommand = this.oleDbSelectCommand2;
            this.LinksDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Links", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("FromPageId", "FromPageId"),
                        new System.Data.Common.DataColumnMapping("ToPageId", "ToPageId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title")})});
            this.LinksDataAdapter.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // NGraphDataImportUC
            // 
            this.Name = "NGraphDataImportUC";
            this.Size = new System.Drawing.Size(248, 560);
            this.ResumeLayout(false);

		}

		#endregion

		#region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // begin view init
            view.BeginInit();

            // configure the view
            view.Grid.Visible = false;
            view.Selection.Mode = DiagramSelectionMode.Single;
            view.GlobalVisibility.ShowPorts = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;

            // create two stylesheets - one for the vertices and one for the edges
            NStyleSheet vertexStyleSheet = new NStyleSheet();
            vertexStyleSheet.Name = "Vertices";
            vertexStyleSheet.Style.FillStyle = new NColorFillStyle(Color.FromArgb(236, 97, 49));
            document.StyleSheets.AddChild(vertexStyleSheet);

            NStyleSheet edgeStyleSheet = new NStyleSheet();
            edgeStyleSheet.Name = "Edges";
            edgeStyleSheet.Style.StrokeStyle = new NStrokeStyle(Color.FromArgb(68, 90, 108));
            document.StyleSheets.AddChild(edgeStyleSheet);

            // configure the graph data source importer
            m_GraphImporter = new NGraphDataSourceImporter();

            // set the document in the active layer of which the shapes will be imported
            m_GraphImporter.Document = document;

            // set the data sources
            // the graph data source importer supports the following data sources
            //      DataTable
            //      DataView 
            //      OleDbDataAdapter
            //      SqlDataAdapter
            //      OdbcDataAdapter
            //      OleDbCommand
            //      SqlCommand
            //      OdbcCommand
            // in this example we have created two OleDbDataAdapters: 
            // the PagesDataAdapter selects all records and columns from the Pages table of the SiteMap.mdb
            // the LinksDataAdapter selects all records and columns from the Links table of the SiteMap.mdb
            oleDbConnection1.ConnectionString = @"Data Source=""" + Application.StartupPath +
                                                @"\..\..\Resources\Data\SiteMap.mdb"";Provider=""Microsoft.Jet.OLEDB.4.0"";";
            oleDbConnection2.ConnectionString = @"Data Source=""" + Application.StartupPath +
												@"\..\..\Resources\Data\SiteMap.mdb"";Provider=""Microsoft.Jet.OLEDB.4.0"";";

            m_GraphImporter.VertexDataSource = PagesDataAdapter;
            m_GraphImporter.EdgeDataSource = LinksDataAdapter;

            // vertex records are uniquely identified by their Id (in the Pages table)
            // edges link the vertices with the FromPageId and ToPageId (in the Links table)
            m_GraphImporter.VertexIdColumnName = "Id";
            m_GraphImporter.FromVertexIdColumnName = "FromPageId";
            m_GraphImporter.ToVertexIdColumnName = "ToPageId";

            // create vertices as rectangles shapes, with default size (60, 30)
            NBasicShapesFactory shapesFactory = new NBasicShapesFactory();
            shapesFactory.DefaultSize = new NSizeF(60, 30);
            m_GraphImporter.VertexShapesFactory = shapesFactory;
            m_GraphImporter.VertexShapesName = BasicShapes.Rectangle.ToString();

            // set stylesheets to be applied to imported vertices and edges
            m_GraphImporter.VertexStyleSheetName = "Vertices";
            m_GraphImporter.EdgeStyleSheetName = "Edges";

            // use layered graph layout
            NLayeredGraphLayout layout = new NLayeredGraphLayout();
            layout.Direction = LayoutDirection.LeftToRight;
            layout.LayerAlignment = RelativeAlignment.Near;
            m_GraphImporter.Layout = layout;

            // subscribe for the vertex imported event,
            // which is raised when a shape was created for a data source record
            m_GraphImporter.VertexImported += new ShapeImportedDelegate(OnVertexImported);

            // import
            m_GraphImporter.Import();

            // end view init
            view.EndInit();
        }

		#endregion

        #region Event Handlers

        /// <summary>
        /// Called when a vertex shape was created by the NGraphDataSourceImporter for the specified data record
        /// </summary>
        /// <param name="importer"></param>
        /// <param name="shape"></param>
        /// <param name="dataRecord"></param>
        private void OnVertexImported(NDataSourceImporter importer, NShape shape, INDataRecord dataRecord)
        {
            // display the page title in the shape
            object text = dataRecord.GetColumnValue("Title");
            if (text == null)
            {
                shape.Text = "Title not specified";
            }
            else
            {
                shape.Text = text.ToString();
            }
            
            shape.SizeToText(new NMarginsF(10));

            // make the URL a tooltip of the shape
            object url =  dataRecord.GetColumnValue("URL");
            if (url == null || url.ToString().Length == 0)
            {
                shape.Style.InteractivityStyle = new NInteractivityStyle("URL not specified");
            }
            else
            {
                shape.Style.InteractivityStyle = new NInteractivityStyle(url.ToString());
            }
        }

        #endregion

        #region Designer Fields

        private System.ComponentModel.Container components = null;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter PagesDataAdapter;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private System.Data.OleDb.OleDbDataAdapter LinksDataAdapter;
        private System.Data.OleDb.OleDbConnection oleDbConnection2;

        #endregion
        
        #region Fields

        NGraphDataSourceImporter m_GraphImporter;

		#endregion
	}
}