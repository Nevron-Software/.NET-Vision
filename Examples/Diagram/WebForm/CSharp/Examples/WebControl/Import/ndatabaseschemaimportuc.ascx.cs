using System.Web;
using System.Web.UI.WebControls;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
    /// Summary description for NDatabaseSchemaImportUC.
	/// </summary>
	public partial class NDatabaseSchemaImportUC : NDiagramExampleUC
	{
		#region Implementation

		private void InitDocument()
		{
            NDrawingDocument document = NDrawingView1.Document;
            document.BackgroundStyle.FrameStyle.Visible = false;

            string databasePath = HttpContext.Current.Server.MapPath(@"..\App_Data\Northwind.xml");

            NDatabaseImporter importer = new NDatabaseImporter(document);
            importer.ImportInActiveLayer = true;
			importer.Import(databasePath);

            NDrawingView1.Document.SizeToContent();
            NDrawingView1.Width = new Unit(NDrawingView1.Document.Bounds.Width, System.Web.UI.WebControls.UnitType.Pixel);
            NDrawingView1.Height = new Unit(NDrawingView1.Document.Bounds.Height, System.Web.UI.WebControls.UnitType.Pixel);
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

        #endregion
    }
}