using System;
using System.Collections;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.DataImport;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;
using Nevron.Dom;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Diagram.Shapes;
using System.Collections.Generic;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NCompanyOrgChartUC.
	/// </summary>
	public class NCompanyOrgChartUC : NDiagramExampleUC
	{
		#region Constructors

        public NCompanyOrgChartUC(NMainForm form)
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
            this.pEmployee = new System.Windows.Forms.Panel();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblBiography = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.pEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pEmployee
            // 
            this.pEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pEmployee.Controls.Add(this.lblSalary);
            this.pEmployee.Controls.Add(this.lblBirthDate);
            this.pEmployee.Controls.Add(this.lblBiography);
            this.pEmployee.Controls.Add(this.lblPosition);
            this.pEmployee.Controls.Add(this.lblName);
            this.pEmployee.Controls.Add(this.pbPhoto);
            this.pEmployee.Location = new System.Drawing.Point(3, 3);
            this.pEmployee.Name = "pEmployee";
            this.pEmployee.Size = new System.Drawing.Size(242, 200);
            this.pEmployee.TabIndex = 1;
            this.pEmployee.Visible = false;
            // 
            // lblSalary
            // 
            this.lblSalary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSalary.Location = new System.Drawing.Point(90, 83);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(146, 19);
            this.lblSalary.TabIndex = 5;
            this.lblSalary.Text = "Salary";
            this.lblSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBirthDate.Location = new System.Drawing.Point(90, 57);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(146, 19);
            this.lblBirthDate.TabIndex = 4;
            this.lblBirthDate.Text = "Birth Date";
            this.lblBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBiography
            // 
            this.lblBiography.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBiography.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBiography.Location = new System.Drawing.Point(3, 113);
            this.lblBiography.Name = "lblBiography";
            this.lblBiography.Size = new System.Drawing.Size(233, 75);
            this.lblBiography.TabIndex = 3;
            this.lblBiography.Text = "Bigraphy";
            this.lblBiography.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPosition.Location = new System.Drawing.Point(90, 31);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(146, 19);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(90, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(146, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(4, 3);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(80, 100);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // NCompanyOrgChartUC
            // 
            this.Controls.Add(this.pEmployee);
            this.Name = "NCompanyOrgChartUC";
            this.Size = new System.Drawing.Size(248, 384);
            this.Controls.SetChildIndex(this.pEmployee, 0);
            this.pEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

        protected override void AttachToEvents()
        {
            base.AttachToEvents();
            document.EventSinkService.NodeMouseDown += new NodeMouseEventHandler(EventSinkService_NodeMouseDown);
        }
		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init view
			view.ViewLayout = ViewLayout.Fit;
			view.DocumentPadding = new Nevron.Diagram.NMargins(10);
			view.Grid.Visible = false;
			view.GlobalVisibility.ShowPorts = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;

			// init document
			document.BeginInit();
            CreateStyleSheets();
			InitDocument();
			document.EndInit();

			// end view init
			view.EndInit();
		}
        protected override void DetachFromEvents()
        {
            document.EventSinkService.NodeMouseDown -= new NodeMouseEventHandler(EventSinkService_NodeMouseDown);
            base.DetachFromEvents();
        }

		#endregion

		#region Implementation

        private void CreateStyleSheets()
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
		private void InitDocument()
		{
			m_Dict = new Dictionary<NTableShape, NEmployee>();

			// change default document styles
			document.Style.TextStyle.TextFormat = TextFormat.XML;
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;

			// configure shadow (inherited by all objects)
			document.Style.ShadowStyle = new NShadowStyle(
				ShadowType.GaussianBlur,
				Color.FromArgb(150, Color.Black),
				new NPointL(3, 3),
				1,
				new NLength(4));

			document.ShadowsZOrder = ShadowsZOrder.BehindDocument;			

			// create the data importer
			string databasePath = Path.Combine(Application.StartupPath, @"..\..\Resources\Data\OrgData.mdb");
            NTreeDataSourceImporter treeImporter = new NTreeDataSourceImporter();
            treeImporter.Document = document;
            treeImporter.DataSource = new OleDbDataAdapter(
                "SELECT * FROM Employees",
                string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", databasePath)
            );

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
			m_Dict.Add(shape, employee);

            string stylesheetName = employee.Position.ToUpper();
            if (stylesheetName.StartsWith("VP"))
            {
                stylesheetName = "VP";
            }

            shape.InitTable(2, 2);
            shape.BeginUpdate();
            shape.ShowGrid = false;
            shape.CellMargins = new Nevron.Diagram.NMargins(2);

            NTableColumn column = (NTableColumn)shape.Columns.GetChildAt(1);
            column.SizeMode = TableColumnSizeMode.Fixed;
            column.Width = 108;

            shape[0, 0].Margins = new Nevron.Diagram.NMargins(5);
            shape[0, 0].RowSpan = 2;
			shape[0, 0].Bitmap = employee.Photo;
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

        private void treeImporter_VertexImported(NDataSourceImporter dataSourceImporter, NShape shape, INDataRecord record)
        {
            InitTableShape((NTableShape)shape, new NEmployee(record));
        }
        private void EventSinkService_NodeMouseDown(NNodeMouseEventArgs args)
        {
            if (args.Button != MouseButtons.Left || !(args.Node is NTableShape || args.Node is NGroupSampleUC))
            {
                pEmployee.Visible = false;
                return;
            }

            INNode node = args.Node;
            while (!(node is NTableShape))
            {
                node = node.ParentNode;
            }

            NEmployee employee = m_Dict[(NTableShape)node];
            pbPhoto.Image = employee.Photo;
            lblName.Text = employee.Name;
            lblPosition.Text = employee.Position;
            lblBirthDate.Text = string.Format(CULTURE, "Birth Date: {0:MMMM dd, yyyy}", employee.BirthDate);
            lblSalary.Text = "Salary: " + employee.Salary.ToString("C", CULTURE);
            lblBiography.Text = employee.Biography;

            pEmployee.Visible = true;
            args.Handled = !(args.Node is NGroupSampleUC);
        }

        #endregion

		#region Designer Fields
		
		private System.ComponentModel.Container components = null;
        private Panel pEmployee;
        private PictureBox pbPhoto;
        private Label lblName;
        private Label lblPosition;
        private Label lblBiography;
        private Label lblBirthDate;
        private Label lblSalary;

		#endregion

		#region Fields

		private Dictionary<NTableShape, NEmployee> m_Dict;

		#endregion

		#region Static

		private static readonly CultureInfo CULTURE = new CultureInfo("en-US");

		#endregion

        #region Nested Types

        private class NEmployee
		{
            public NEmployee(INDataRecord data)
            {
                Name = data.GetColumnValue("Name").ToString();
                Position = data.GetColumnValue("Position").ToString();
                BirthDate = (DateTime)data.GetColumnValue("BirthDate");
                Salary = (decimal)data.GetColumnValue("Salary");
                Biography = data.GetColumnValue("Biography").ToString();

                byte[] imageData = data.GetColumnValue("Photo") as byte[];
                if (imageData != null)
                {
                    // Signature bytes of an OLE container header.
                    const byte OLEbyte0 = 21;
                    const byte OLEbyte1 = 28;

                    // Number of bytes in an OLE container header.
                    const int OLEheaderLength = 78;

                    // Test for an OLE container header
                    if ((imageData[0] == OLEbyte0) && (imageData[1] == OLEbyte1))
                    {
                        // Use a second array to strip off the header. Make it big enough to hold
                        // the bytes after the header.
                        byte[] strippedData = new byte[imageData.Length - OLEheaderLength];

                        // Strip off the header by copying the bytes after the header.
                        Array.Copy(imageData, OLEheaderLength, strippedData, 0, imageData.Length - OLEheaderLength);
                        imageData = strippedData;
                    }

                    Photo = new Bitmap(new MemoryStream(imageData));
                }
                else
                {
                    Photo = new Bitmap(80, 100);
                }
            }

            public string Name;
            public string Position;
            public DateTime BirthDate;
            public decimal Salary;
            public string Biography;
            public Bitmap Photo;
        }

        #endregion
    }
}