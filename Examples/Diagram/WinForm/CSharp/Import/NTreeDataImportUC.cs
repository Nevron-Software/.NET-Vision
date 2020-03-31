using System.Drawing;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.DataImport;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NTreeDataImportUC.
	/// </summary>
	public class NTreeDataImportUC : NDiagramExampleUC
	{
		#region Constructor

        public NTreeDataImportUC(NMainForm form)
            : base(form)
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
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
            this.SuspendLayout();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "select * from Pages";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
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
            // oleDbDataAdapter1
            // 
            this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
            this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
            this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
            this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Pages", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ParentId", "ParentId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("URL", "URL")})});
            this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // NTreeDataImportUC
            // 
            this.Name = "NTreeDataImportUC";
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

            // create the tree data source importer
            m_TreeImporter = new NTreeDataSourceImporter();

            // set the document in the active layer of which the shapes will be imported
            m_TreeImporter.Document = document;

            // SET THE DATA SOURCE
            // the tree data source importer supports the following data sources
            //      DataTable
            //      DataView 
            //      OleDbDataAdapter
            //      SqlDataAdapter
            //      OdbcDataAdapter
            //      OleDbCommand
            //      SqlCommand
            //      OdbcCommand
            // in this example we have created an OleDbDataAdapter, 
            // which selects all columns and records from the Pages table of the SiteMap.mdb
            oleDbConnection1.ConnectionString = @"Data Source=""" + Application.StartupPath +
												@"\..\..\Resources\Data\SiteMap.mdb"";Provider=""Microsoft.Jet.OLEDB.4.0"";";

            m_TreeImporter.DataSource = oleDbDataAdapter1;

            // records are uniquely identified by their Id column
            // records link to their parent record by their ParentId column
            m_TreeImporter.IdColumnName = "Id";
            m_TreeImporter.ParentIdColumnName = "ParentId";

            // create vertices as rectangles shapes, with default size (60,30)
            NBasicShapesFactory shapesFactory = new NBasicShapesFactory();
            shapesFactory.DefaultSize = new NSizeF(60, 30);
            m_TreeImporter.VertexShapesFactory = shapesFactory;
            m_TreeImporter.VertexShapesName = BasicShapes.Rectangle.ToString();

            // set stylesheets to be applied to imported vertices and edges
            m_TreeImporter.VertexStyleSheetName = "Vertices";
            m_TreeImporter.EdgeStyleSheetName = "Edges";

            // use layered tree layout
            NLayeredTreeLayout layout = new NLayeredTreeLayout();
            layout.Direction = LayoutDirection.LeftToRight;
            layout.OrthogonalEdgeRouting = true;
            layout.LayerAlignment = RelativeAlignment.Near; 
            m_TreeImporter.Layout = layout;

            // subscribe for the vertex imported event,
            // which is raised when a shape was created for a data source record
            m_TreeImporter.VertexImported += new ShapeImportedDelegate(OnVertexImported);

            // import
            m_TreeImporter.Import();

            // end view init
            view.EndInit();
        }

		#endregion

        #region Event Handlers

        /// <summary>
        /// Called when a vertex shape was created by the NTreeDataSourceImporter for the specified data record
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
        private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;

        #endregion

        #region Fields

        NTreeDataSourceImporter m_TreeImporter;

		#endregion
	}
}