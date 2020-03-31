using System;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Web;

using Nevron.Diagram;
using Nevron.Diagram.DataImport;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;
using System.Data;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	/// Summary description for NDiagramClassHierarchyUC.
	/// </summary>
	public partial class NOrgChartUC : NDiagramExampleUC
	{
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (NDrawingView1.RequiresInitialization)
            {
                // begin view init
                NDrawingView1.ViewLayout = CanvasLayout.Fit;

                // init document
                NDrawingView1.Document.HistoryService.Stop();
                NDrawingView1.Document.BeginInit();
                CreateStyleSheets();
                InitDocument();
                NDrawingView1.Document.EndInit();
            }
        }

        #region Implementation

        private void CreateStyleSheets()
        {
            NDrawingDocument document = NDrawingView1.Document;

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
        private void InitDocument()
        {
            NDrawingDocument document = NDrawingView1.Document;

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
            treeImporter.VertexImported += new ShapeImportedDelegate(treeImporter_VertexImported);
            bool ok = treeImporter.Import();

            // resize document to fit all shapes
            document.SizeToContent();
        }
        private void InitTableShape(NTableShape shape, NEmployee employee)
        {
		//	employee.Photo = this.MapPathSecure(employee.Photo);

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
            shape[0, 0].Bitmap = new Bitmap(this.MapPathSecure(employee.PhotoPath));
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

        protected void treeImporter_VertexImported(NDataSourceImporter dataSourceImporter, NShape shape, INDataRecord record)
        {
            InitTableShape((NTableShape)shape, new NEmployee(record));
        }
        protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
        {
            //	configure the client side tools
            NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
        }
        protected void NDrawingView1_AsyncClick(object sender, EventArgs e)
        {
            NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;

            NNodeList nodes = NDrawingView1.HitTest(args);
            NNodeList shapes = nodes.Filter(TABLE_SHAPE_FILTER);

            if (shapes.Count == 0)
            {
                NDrawingView1.Document.Tag = null;
                return;
            }

            NNodeList decorators = nodes.Filter(DECORATOR_FILTER);
            if (decorators.Count > 0)
            {
                ((NShowHideSubtreeDecorator)decorators[0]).ToggleState();
            }

            NTableShape table = (NTableShape)shapes[0];
            NEmployee employee = (NEmployee)table.Tag;
            NDrawingView1.Document.Tag = employee;
            NDrawingView1.Document.SmartRefreshAllViews();
        }
        protected void NDrawingView1_AsyncQueryCommandResult(object sender, EventArgs e)
        {
            NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
            NCallbackCommand command = args.Command;
            NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;

            switch (command.Name)
            {
                case "mouseClick":
                    //	build a custom response data section
                        NEmployee employee = NDrawingView1.Document.Tag as NEmployee;
                        if (employee == null)
                            return;

                        employee.SetAjaxData(resultBuilder);
                    break;
            }
        }

        #endregion

        #region Static

        private static readonly CultureInfo CULTURE = new CultureInfo("en-US");
        private static readonly NFilter TABLE_SHAPE_FILTER = new NInstanceOfTypeFilter(typeof(NTableShape));
        private static readonly NFilter DECORATOR_FILTER = new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator));

        #endregion

        #region Nested Types

        private class NEmployee : ICloneable
        {
            public string Name;
            public string Position;
            public DateTime BirthDate;
            public decimal Salary;
            public string Biography;
            public string PhotoPath;
			public string Photo;

            public NEmployee(INDataRecord data)
            {
                Name = data.GetColumnValue("Name").ToString();
                Position = data.GetColumnValue("Position").ToString();
                BirthDate = (DateTime)data.GetColumnValue("BirthDate");
                Salary = (decimal)data.GetColumnValue("Salary");
                Biography = data.GetColumnValue("Biography").ToString();

				string photoImage = data.GetColumnValue("Photo").ToString();
				PhotoPath = "~\\Images\\" + photoImage;
				Photo = "..\\Images\\" + photoImage;
            }
            public NEmployee(NEmployee other)
            {
                Name = other.Name;
                Position = other.Position;
                BirthDate = other.BirthDate;
                Salary = other.Salary;
                Biography = other.Biography;
                Photo = other.Photo;
				Photo = other.Photo;
            }

            #region ICloneable Members

            public object Clone()
            {
                return new NEmployee(this);
            }

            #endregion

            public void SetAjaxData(NAjaxXmlTransportBuilder resultBuilder)
            {
                FieldInfo[] fields = this.GetType().GetFields();
                int i, count = fields.Length;
                string format;

                for (i = 0; i < count; i++)
                {
                    NAjaxXmlDataSection dataSection = new NAjaxXmlDataSection(fields[i].Name.ToLower());
                    switch(fields[i].FieldType.Name)
                    {
                        case "DateTime":
                            dataSection.Data = string.Format(CULTURE, "{0:MMMM dd, yyyy}", fields[i].GetValue(this));
                            break;

                        default:
                            format = dataSection.Name == "salary" ? ":C" : string.Empty;
                            dataSection.Data = string.Format(CULTURE, "{0" + format + "}", fields[i].GetValue(this));
                            break;
                    }

                    switch (dataSection.Name)
                    {
                        case "salary":
                            dataSection.Data = "Salary: " + dataSection.Data;
                            break;

                        case "birthdate":
                            dataSection.Data = "Birth Date: " + dataSection.Data;
                            break;
                    }

                    resultBuilder.AddDataSection(dataSection);
                }
            }
        }

        #endregion
    }
}