using System.Data;
using System.Drawing;
using System.Web;

using Nevron.Diagram;
using Nevron.Diagram.DataImport;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
    /// Summary description for NGraphDataImportUC.
	/// </summary>
	public partial class NGraphDataImportUC : NDiagramExampleUC
	{
		#region Implementation

		private void InitDocument()
		{
			NDrawingDocument document = NDrawingView1.Document;
            document.BackgroundStyle.FrameStyle.Visible = false;

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
            NGraphDataSourceImporter graphImporter = new NGraphDataSourceImporter();

            // set the document in the active layer of which the shapes will be imported
            graphImporter.Document = document;

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
            string databasePath = HttpContext.Current.Server.MapPath(@"..\App_Data\SiteMap.xml");
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(databasePath, XmlReadMode.ReadSchema);

			graphImporter.VertexDataSource = dataSet.Tables["Pages"];
			graphImporter.EdgeDataSource = dataSet.Tables["Links"];

            // vertex records are uniquely identified by their Id (in the Pages table)
            // edges link the vertices with the FromPageId and ToPageId (in the Links table)
            graphImporter.VertexIdColumnName = "Id";
            graphImporter.FromVertexIdColumnName = "FromPageId";
            graphImporter.ToVertexIdColumnName = "ToPageId";

            // create vertices as rectangles shapes, with default size (60,30)
            NBasicShapesFactory shapesFactory = new NBasicShapesFactory();
            shapesFactory.DefaultSize = new NSizeF(60, 30);
            graphImporter.VertexShapesFactory = shapesFactory;
            graphImporter.VertexShapesName = BasicShapes.Rectangle.ToString();

            // set stylesheets to be applied to imported vertices and edges
            graphImporter.VertexStyleSheetName = "Vertices";
            graphImporter.EdgeStyleSheetName = "Edges";

            // use layered graph layout
            NLayeredGraphLayout layout = new NLayeredGraphLayout();
            layout.Direction = LayoutDirection.LeftToRight;
            layout.LayerAlignment = RelativeAlignment.Near;
            graphImporter.Layout = layout;

            // subscribe for the vertex imported event,
            // which is raised when a shape was created for a data source record
            graphImporter.VertexImported += new ShapeImportedDelegate(OnVertexImported);

            // import
            graphImporter.Import();
        }

		#endregion

        #region Event Handlers

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// begin view init
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

			// view init
			NDrawingView1.ViewLayout = CanvasLayout.Normal;

			// init document
			NDrawingView1.Document.BeginInit();
			InitDocument();
			NDrawingView1.Document.EndInit();
		}
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
        }

        #endregion
    }
}