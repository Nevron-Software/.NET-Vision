using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NTreeDataImportUC.
    /// </summary>
    public class NDatabaseSchemaImportUC : NDiagramExampleUC
    {
        #region Constructors

        public NDatabaseSchemaImportUC(NMainForm form)
            : base(form)
        {
        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // begin view init
            view.BeginInit();

            // configure the view
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;

            document.BeginInit();

            document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;
            NDatabaseImporter importer = new NDatabaseImporter(document);
            importer.ImportInActiveLayer = true;
            importer.ImportOleDb(string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\..\..\Resources\Data\Northwind.mdb", Application.StartupPath));
            document.SizeToContent();

            document.EndInit();

            // end view init
            view.EndInit();
        }

        #endregion
    }
}