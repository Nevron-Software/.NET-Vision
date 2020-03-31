using System;
using System.Data.OleDb;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.DataImport;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
    /// <summary>
	///	Summary description for NExcelImportUC.
    /// </summary>
	public partial class NExcelImportUC : NDiagramExampleUC
    {
		#region Page Entry Point

		protected void Page_Load(object sender, EventArgs e)
		{
			// create some shape factories
			m_FilesAndFoldersFactory = new NFilesAndFoldersFactory();
			m_FilesAndFoldersFactory.DefaultSize = VertexSize;

			m_BusinessProcessShapesFactory = new NBusinessProcessShapesFactory();
			m_BusinessProcessShapesFactory.DefaultSize = SymbolSize;

			// import the data
			NDrawingView1.Document.BeginInit();
			ImportData();
			NDrawingView1.Document.EndInit();

			// size the view to its content
			NDrawingView1.SizeToContent();
		}

		#endregion

		#region Implementation

		private void ImportData()
		{
			NDrawingDocument document = NDrawingView1.Document;
			document.BackgroundStyle.FrameStyle.Visible = false;

			// create two stylesheets - one for the vertices and one for the edges
			NStyleSheet vertexStyleSheet = new NStyleSheet();
			vertexStyleSheet.Name = "Vertices";
			NStyle.SetFillStyle(vertexStyleSheet, new NColorFillStyle(Color.FromArgb(236, 97, 49)));
			document.StyleSheets.AddChild(vertexStyleSheet);

			NStyleSheet edgeStyleSheet = new NStyleSheet();
			edgeStyleSheet.Name = "Edges";
			NStyle.SetStrokeStyle(edgeStyleSheet, new NStrokeStyle(Color.Blue));
			NStyle.SetEndArrowheadStyle(edgeStyleSheet, new NArrowheadStyle(ArrowheadShape.OpenedArrow, null, new NSizeL(6, 4), null, new NStrokeStyle(Color.Blue)));
			NTextStyle textStyle = (NTextStyle)document.ComposeTextStyle().Clone();
			textStyle.StringFormatStyle.VertAlign = Nevron.VertAlign.Bottom;
			NStyle.SetTextStyle(edgeStyleSheet, textStyle);
			document.StyleSheets.AddChild(edgeStyleSheet);

			// create the graph data source importer
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
			// which selects all columns and records from the Sources and Links tables of the Data.xlsx file
			string databasePath = Server.MapPath(@"..\Examples\Import\Data.xlsx");
			string connectionString = @"Data Source=""" + databasePath + @""";Provider=""Microsoft.ACE.OLEDB.12.0""; Extended Properties=""Excel 12.0 Xml;HDR=YES"";";

			graphImporter.VertexDataSource = new OleDbDataAdapter("SELECT * FROM [Sources$]", connectionString);
			graphImporter.EdgeDataSource = new OleDbDataAdapter("SELECT * FROM [Links$]", connectionString);

			// vertex records are uniquely identified by their Id (in the Sources table)
			// edges link the vertices with the Fro and ToPageId (in the Links table)
			graphImporter.VertexIdColumnName = "Id";
			graphImporter.FromVertexIdColumnName = "From";
			graphImporter.ToVertexIdColumnName = "To";

			// create vertices as group shapes, with default size
			NShapesFactory shapesFactory = new GroupShapesFactory();
			shapesFactory.DefaultSize = VertexSize;
			graphImporter.VertexShapesFactory = shapesFactory;
			graphImporter.VertexShapesName = GroupShapes.Group.ToString();

			// set stylesheets to be applied to imported vertices and edges
			graphImporter.VertexStyleSheetName = "Vertices";
			graphImporter.EdgeStyleSheetName = "Edges";

			// use layered graph layout
			NLayeredGraphLayout layout = new NLayeredGraphLayout();
			layout.LayerSpacing = 70;
			layout.Direction = LayoutDirection.LeftToRight;
			layout.LayerAlignment = RelativeAlignment.Near;
			graphImporter.Layout = layout;

			// subscribe for the vertex and edge imported events,
			// which are raised when a shape was created for a data source record
			graphImporter.VertexImported += new ShapeImportedDelegate(OnVertexImported);
			graphImporter.EdgeImported += new ShapeImportedDelegate(OnEdgeImported);

			// import
			graphImporter.Import();
		}

		#endregion

		#region Event Handlers

		private void OnVertexImported(NDataSourceImporter importer, NShape shape, INDataRecord dataRecord)
		{
			// Create a shape to host in the group based on the value of the "Type" column
			NShape innerShape = null;
			switch (dataRecord.GetColumnValue("Type").ToString())
			{
				case "DB":
					innerShape = m_FilesAndFoldersFactory.CreateShape(FilesAndFoldersShapes.Binder);
					break;
				case "File":
					innerShape = m_FilesAndFoldersFactory.CreateShape(FilesAndFoldersShapes.SimpleFolder);
					break;
				case "Report":
					innerShape = m_FilesAndFoldersFactory.CreateShape(FilesAndFoldersShapes.BlankFile);
					break;
			}

			innerShape.Text = dataRecord.GetColumnValue("Id").ToString();

			// Host the created shape in the group
			NGroup group = (NGroup)shape;
			group.Shapes.AddChild(innerShape);
			group.UpdateModelBounds();
		}
		private void OnEdgeImported(NDataSourceImporter dataSourceImporter, NShape shape, INDataRecord dataRecord)
		{
			// Set the text of the edge
			shape.Text = dataRecord.GetColumnValue("Desc").ToString();

			// Get the symbol name if any
			object symbol = dataRecord.GetColumnValue("Symbol");
			if (symbol == null || Convert.IsDBNull(symbol))
				return;

			// Add a logical line port
			NLogicalLinePort linePort = new NLogicalLinePort(20);
			shape.CreateShapeElements(ShapeElementsMask.Ports);
			shape.Ports.AddChild(linePort);

			// Attach a custom shape based on the symbol name
			NShape customShape = null;
			switch (symbol.ToString())
			{
				case "Stop":
					customShape = m_BusinessProcessShapesFactory.CreateShape(BusinessProcessShapes.StopAccepted);
					break;
				case "Question":
					customShape = m_BusinessProcessShapesFactory.CreateShape(BusinessProcessShapes.Question);
					break;
			}

			((NDrawingDocument)shape.Document).ActiveLayer.AddChild(customShape);

			// Add an outward port to the shape
			NRotatedBoundsPort outwardPort = new NRotatedBoundsPort(new NContentAlignment(ContentAlignment.MiddleCenter));
			outwardPort.Type = PortType.Outward;
			customShape.CreateShapeElements(ShapeElementsMask.Ports);
			customShape.Ports.AddChild(outwardPort);

			outwardPort.Connect(linePort);
		}

		#endregion

		#region Fields

		private NFilesAndFoldersFactory m_FilesAndFoldersFactory;
		private NBusinessProcessShapesFactory m_BusinessProcessShapesFactory;

		#endregion

		#region Constants

		private static readonly NSizeF VertexSize = new NSizeF(60, 60);
		private static readonly NSizeF SymbolSize = new NSizeF(20, 20);

		#endregion

		#region Nested Types

		private class GroupShapesFactory : NShapesFactory
		{
			public GroupShapesFactory()
				: base("Group Shapes")
			{
			}

			public override int ShapesCount
			{
				get
				{
					return Enum.GetValues(typeof(GroupShapes)).Length;
				}
			}

			public override NShape CreateShape(int index)
			{
				NGroup group = new NGroup();
				CreateCenterAndSidesPorts(group);
				return group;
			}

			protected override NShapeInfo CreateShapeInfo(int index)
			{
				GroupShapes shape = (GroupShapes)index;
				string name = NSystem.InsertSpacesBeforeUppers(shape.ToString());
				NShapeInfo info = new NShapeInfo(name);
				return info;
			}
			protected override Type GetEnumType()
			{
				return typeof(GroupShapes);
			}
		}

		private enum GroupShapes
		{
			Group
		}

		#endregion
	}
}
