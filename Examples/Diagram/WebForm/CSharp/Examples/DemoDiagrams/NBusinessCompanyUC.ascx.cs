using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Web;

using Nevron.Diagram;
using Nevron.Diagram.DataImport;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	/// Summary description for NBusinessCompanyUC.
	/// </summary>
	public partial class NBusinessCompanyUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized == false)
			{
				// Init the diagram control
				NThinDiagramControl1.StateId = "Diagram1";

				// Init the drawing view
				NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

				// Configure the controller
				NServerMouseEventTool serverMouseEventTool = new NServerMouseEventTool();
				NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool);
				serverMouseEventTool.MouseDown = new NMouseDownEventCallback();

				// Init the drawing document
				NDrawingDocument document = NThinDiagramControl1.Document;
				document.BeginInit();
				CreateStyleSheets(document);
				InitDocument(document);
				document.EndInit();
			}
		}

        #region Implementation

        private void CreateStyleSheets(NDrawingDocument document)
        {
            // create a stylesheet for the president
            NStyleSheet styleSheet = new NStyleSheet("PRESIDENT");
            styleSheet.Style.FillStyle = new NColorFillStyle(Color.FromArgb(129, 133, 133));
            styleSheet.Style.FillStyle.ImageFiltersStyle.Filters.Add(new NLightingImageFilter());
            document.StyleSheets.AddChild(styleSheet);

            // create a stylesheet for the VPs
            styleSheet = new NStyleSheet("VP");
            styleSheet.Style.FillStyle = new NColorFillStyle(Color.FromArgb(162, 173, 182));
            styleSheet.Style.FillStyle.ImageFiltersStyle.Filters.Add(new NLightingImageFilter());
            document.StyleSheets.AddChild(styleSheet);

            // create a stylesheet for the managers
            styleSheet = new NStyleSheet("MANAGER");
            styleSheet.Style.FillStyle = new NColorFillStyle(Color.FromArgb(251, 203, 156));
            styleSheet.Style.FillStyle.ImageFiltersStyle.Filters.Add(new NLightingImageFilter());
            document.StyleSheets.AddChild(styleSheet);

            // create a stylesheet for the person name labels
            styleSheet = new NStyleSheet("NAME");

            NTextStyle textStyle = document.Style.TextStyle.Clone() as NTextStyle;
            textStyle.FontStyle.InitFromFont(new Font("Arial", 10, FontStyle.Bold));
            textStyle.StringFormatStyle.HorzAlign = HorzAlign.Right;
            textStyle.StringFormatStyle.VertAlign = VertAlign.Bottom;

            styleSheet.Style.TextStyle = textStyle;
            document.StyleSheets.AddChild(styleSheet);

            // create a stylesheet for the person position labels
            styleSheet = new NStyleSheet("POSITION");

            textStyle = document.Style.TextStyle.Clone() as NTextStyle;
            textStyle.FontStyle.InitFromFont(new Font("Arial", 10, FontStyle.Bold));
            textStyle.StringFormatStyle.HorzAlign = HorzAlign.Right;
            textStyle.StringFormatStyle.VertAlign = VertAlign.Center;

            styleSheet.Style.TextStyle = textStyle;
            document.StyleSheets.AddChild(styleSheet);
        }
        private void InitDocument(NDrawingDocument document)
        {
            // change default document styles
            document.Style.TextStyle.TextFormat = TextFormat.XML;
            document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
            document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;
            document.BackgroundStyle.FrameStyle.Visible = false;

            // configure shadow (inherited by all objects)
            document.Style.ShadowStyle = new NShadowStyle(
                ShadowType.GaussianBlur,
                Color.FromArgb(150, Color.Black),
                new NPointL(3, 3),
                1,
                new NLength(4));

            document.ShadowsZOrder = ShadowsZOrder.BehindDocument;

            // create the data importer
            string databasePath = HttpContext.Current.Server.MapPath(@"..\App_Data\OrgData.xml");
            NTreeDataSourceImporter treeImporter = new NTreeDataSourceImporter();
            treeImporter.Document = document;

			DataSet dataSet = new DataSet();
			dataSet.ReadXml(databasePath, XmlReadMode.ReadSchema);
			treeImporter.DataSource = dataSet.Tables["Employees"];

            // records are uniquely identified by their Id column
            // records link to their parent record by their ParentId column
            treeImporter.IdColumnName = "Id";
            treeImporter.ParentIdColumnName = "ParentId";
            treeImporter.CollapsibleSubtrees = true;
            treeImporter.VertexShapesFactory = new NBasicShapesFactory();
            treeImporter.VertexShapesName = BasicShapes.Table.ToString();

            // use tip over tree layout
            NTipOverTreeLayout tipOverLayout = new NTipOverTreeLayout();
            tipOverLayout.ColRightParentPlacement.Offset = 70;
            tipOverLayout.HorizontalSpacing = 30;
            tipOverLayout.LeafsPlacement = TipOverChildrenPlacement.ColRight;
            treeImporter.Layout = tipOverLayout;

            // import the shapes
            treeImporter.VertexImported += new ShapeImportedDelegate(OnTreeImporterVertexImported);
            bool ok = treeImporter.Import();

            // resize document to fit all shapes
            document.SizeToContent();
        }
        private void InitTableShape(NTableShape shape, NEmployee employee)
        {
            string stylesheetName = employee.Position.ToUpper();
            if (stylesheetName.StartsWith("VP"))
            {
                stylesheetName = "VP";
            }

            shape.Name = employee.Name;
            shape.Tag = employee;
            shape.InitTable(2, 2);
            shape.BeginUpdate();
            shape.ShowGrid = false;
            shape.CellMargins = new Nevron.Diagram.NMargins(2);

            NTableColumn column = (NTableColumn)shape.Columns.GetChildAt(1);
            column.SizeMode = TableColumnSizeMode.Fixed;
            column.Width = 108;

            shape[0, 0].Margins = new Nevron.Diagram.NMargins(5);
            shape[0, 0].RowSpan = 2;
            shape[0, 0].Bitmap = new Bitmap(this.MapPathSecure(employee.PhotoFileName));
            shape[0, 0].Borders = TableCellBorder.All;
            shape[1, 0].Text = employee.Position;
            shape[1, 1].Text = employee.Name;
            shape[1, 0].StyleSheetName = "POSITION";
            shape[1, 1].StyleSheetName = "NAME";
            shape.StyleSheetName = stylesheetName;
            shape.EndUpdate();

            shape.Ports.DefaultInwardPortUniqueId = ((NPort)shape.Ports.GetChildByName("Bottom")).UniqueId;
        }

        #endregion

        #region Event Handlers

        protected void OnTreeImporterVertexImported(NDataSourceImporter dataSourceImporter, NShape shape, INDataRecord record)
        {
            InitTableShape((NTableShape)shape, new NEmployee(record));
        }

        #endregion

        #region Static

        private static readonly CultureInfo UsCulture = new CultureInfo("en-US");
        private static readonly NFilter TableShapeFilter = new NInstanceOfTypeFilter(typeof(NTableShape));
        private static readonly NFilter DecoratorFilter = new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator));

        #endregion

        #region Nested Types

		[Serializable]
		class NMouseDownEventCallback : INMouseEventCallback
		{
			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NNodeList nodes = diagramControl.HitTest(new NPointF(e.X, e.Y));
				NNodeList shapes = nodes.Filter(TableShapeFilter);

				if (shapes.Count == 0)
				{
					diagramControl.Document.Tag = null;
					return;
				}

				NNodeList decorators = nodes.Filter(DecoratorFilter);
				if (decorators.Count > 0)
				{
					// Toggle the clicked show/hide subtree decorator and update the view
					((NShowHideSubtreeDecorator)decorators[0]).ToggleState();
					diagramControl.UpdateView();
				}

				// Send a custom command
				NTableShape table = (NTableShape)shapes[0];
				NEmployee employee = (NEmployee)table.Tag;
				diagramControl.AddCustomClientCommand(employee.GetData());
			}

			#endregion
		}

		[Serializable]
        class NEmployee
        {
            public NEmployee(INDataRecord data)
            {
                Name = data.GetColumnValue("Name").ToString();
                Position = data.GetColumnValue("Position").ToString();
                BirthDate = (DateTime)data.GetColumnValue("BirthDate");
                Salary = (decimal)data.GetColumnValue("Salary");
                Biography = data.GetColumnValue("Biography").ToString();

				string photoImage = data.GetColumnValue("Photo").ToString();
				PhotoFileName = "~\\Images\\" + photoImage;
            }
            public NEmployee(NEmployee other)
            {
                Name = other.Name;
                Position = other.Position;
                BirthDate = other.BirthDate;
                Salary = other.Salary;
                Biography = other.Biography;
				PhotoFileName = other.PhotoFileName;
            }

            public string GetData()
            {
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("Name=" + Name);
				sb.AppendLine("Position=" + Position);
				sb.AppendLine("BirthDate=" + BirthDate.ToString("MMMM dd, yyyy", UsCulture));
				sb.AppendLine("Salary=" + Salary.ToString("C", UsCulture));
				sb.AppendLine("Biography=" + Biography);
				sb.AppendLine("Photo=" + PhotoFileName.Replace("~", ".."));

				return sb.ToString();
            }

            public string Name;
            public string Position;
            public DateTime BirthDate;
            public decimal Salary;
            public string Biography;
            public string PhotoFileName;
        }

        #endregion
    }
}