using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NLibraryBrowserUC.
	/// </summary>
	public class NLibraryBrowserUC : NDiagramExampleUC
	{
		#region Constructor

		public NLibraryBrowserUC(NMainForm form) : base(form)
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
			this.libraryBrowser = new Nevron.Diagram.WinForm.NLibraryBrowser();
			this.openButton = new Nevron.UI.WinForm.Controls.NButton();
			this.saveButton = new Nevron.UI.WinForm.Controls.NButton();
			this.newButton = new Nevron.UI.WinForm.Controls.NButton();
			this.closeButton = new Nevron.UI.WinForm.Controls.NButton();
			this.viewStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// libraryBrowser
			// 
			this.libraryBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.libraryBrowser.ContextMenuGroup = null;
			this.libraryBrowser.Location = new System.Drawing.Point(8, 160);
			this.libraryBrowser.Name = "libraryBrowser";
			this.libraryBrowser.Size = new System.Drawing.Size(234, 352);
			this.libraryBrowser.TabIndex = 29;
			this.libraryBrowser.ViewStyle = Nevron.Diagram.WinForm.LibraryViewStyle.IconsAndDetails;
			// 
			// openButton
			// 
			this.openButton.Location = new System.Drawing.Point(8, 56);
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(112, 23);
			this.openButton.TabIndex = 30;
			this.openButton.Text = "Open...";
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(128, 24);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(112, 23);
			this.saveButton.TabIndex = 31;
			this.saveButton.Text = "Save...";
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// newButton
			// 
			this.newButton.Location = new System.Drawing.Point(8, 24);
			this.newButton.Name = "newButton";
			this.newButton.Size = new System.Drawing.Size(112, 23);
			this.newButton.TabIndex = 32;
			this.newButton.Text = "New";
			this.newButton.Click += new System.EventHandler(this.newButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(128, 56);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(112, 23);
			this.closeButton.TabIndex = 33;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// viewStyleCombo
			// 
			this.viewStyleCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.viewStyleCombo.Location = new System.Drawing.Point(80, 24);
			this.viewStyleCombo.Name = "viewStyleCombo";
			this.viewStyleCombo.Size = new System.Drawing.Size(160, 21);
			this.viewStyleCombo.TabIndex = 34;
			this.viewStyleCombo.Text = "comboBox1";
			this.viewStyleCombo.SelectedIndexChanged += new System.EventHandler(this.viewStyleCombo_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.newButton);
			this.groupBox1.Controls.Add(this.saveButton);
			this.groupBox1.Controls.Add(this.closeButton);
			this.groupBox1.Controls.Add(this.openButton);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(250, 96);
			this.groupBox1.TabIndex = 35;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Library browser operations";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.viewStyleCombo);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(250, 56);
			this.groupBox2.TabIndex = 36;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Library browser appearance";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 35;
			this.label1.Text = "View style:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NLibraryBrowserUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.libraryBrowser);
			this.Name = "NLibraryBrowserUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.libraryBrowser, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.groupBox2, 0);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// attach the library browser to the command bars manager, 
			// in order so that it can display context menus
			Form.CommandBarsManager.LibraryBrowser = libraryBrowser;

			// clear all bands (library groups)
			libraryBrowser.ClearBands();

			// create a new library
			NLibraryDocument library = new NLibraryDocument();
			library.Info.Title = "My first library";

			NBasicShapesFactory factory = new NBasicShapesFactory(document);

			// add several masters in the library
			NShape shape = factory.CreateShape((int)BasicShapes.Pentagram);
			shape.Width = 130;
			shape.Height = 130;
			library.AddChild(new NMaster(shape, NGraphicsUnit.Pixel, "Star", "My star"));

			shape = factory.CreateShape((int)BasicShapes.Octagram);
			shape.Width = 130;
			shape.Height = 130;
			library.AddChild(new NMaster(shape, NGraphicsUnit.Pixel, "Octagon", "My octagon"));

			// create a new library group hosting the library
			libraryBrowser.OpenLibraryGroup(library);
			
			// start view init
			view.BeginInit();

			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;
			view.AllowDrop = true;

			// init document
			document.BeginInit();
			CreateCustomOpenFigureShape();
			CreateCustomClosedFigureShape();
			document.EndInit();

			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// detach the library browser from the command bars manager
				Form.CommandBarsManager.LibraryBrowser = null;				
			}

			base.Dispose(disposing);
		}

		
		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			viewStyleCombo.FillFromEnum(typeof(LibraryViewStyle));
			viewStyleCombo.SelectedIndex = (int)libraryBrowser.ViewStyle;

			ResumeEventsHandling();
		}

		private void CreateCustomClosedFigureShape()
		{
			// create the coffee cup shape
			GraphicsPath graphicsPath = new GraphicsPath();
			
			AddFilledCup(graphicsPath);
			AddFilledCupHandle(graphicsPath);
			AddFilledSteam(graphicsPath);
			
			graphicsPath.CloseAllFigures();
			
			NCompositeShape shape = new NCompositeShape();
			shape.Primitives.AddChild(new NCustomPath(graphicsPath, PathType.ClosedFigure));
			shape.UpdateModelBounds();

			shape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0, 0, 0x88));
			shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(0, 0, 0x88));

			document.ActiveLayer.AddChild(shape);

			// describe the shape
			NTextShape text = new NTextShape("Custom Shape 1", 35, 340, 120, 50);
			text.Style.FillStyle = new NColorFillStyle(Color.Black);
			text.Style.TextStyle = new NTextStyle();
			text.Style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 9));
			document.ActiveLayer.AddChild(text);
		}

		private void CreateCustomOpenFigureShape()
		{
			// create the coffee cup shape
			GraphicsPath graphicsPath = new GraphicsPath();
			
			AddStrokeCup(graphicsPath);
			AddStrokeCupHandle(graphicsPath);
			AddStrokeSteam(graphicsPath);
		
			NCompositeShape shape = new NCompositeShape();
			shape.Primitives.AddChild(new NCustomPath(graphicsPath, PathType.OpenFigure));
			shape.UpdateModelBounds();

			shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(0, 0, 0xaa));
			document.ActiveLayer.AddChild(shape); 

			// describe the shape
			NTextShape text = new NTextShape("Custom Shape 2", 195, 340, 120, 50);
			text.Style.FillStyle = new NColorFillStyle(Color.Black);
			text.Style.TextStyle = new NTextStyle();
			text.Style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 9));
			document.ActiveLayer.AddChild(text);
		}


		private void AddFilledCup(GraphicsPath graphicsPath)
		{
			PointF[] points = new PointF[]
			{
				new PointF(45, 268),
				new PointF(63, 331),
				new PointF(121, 331),
				new PointF(140, 268),
			};

			graphicsPath.AddPolygon(points);
		}

		private void AddFilledCupHandle(GraphicsPath graphicsPath)
		{
			PointF[] points = new PointF[]
			{
				new PointF(175, 295),
				new PointF(171, 278),
				new PointF(140, 283),
				new PointF(170, 290),
				new PointF(128, 323),
			};

			graphicsPath.AddClosedCurve(points, 1);
		}

		private void AddFilledSteam(GraphicsPath graphicsPath)
		{
			PointF[] points = new PointF[]
			{
				new PointF(92, 258),
				new PointF(53, 163),
				new PointF(145, 160),
				new PointF(86, 50),
				new PointF(138, 194),
				new PointF(45, 145),
				new PointF(92, 258),
			};

			graphicsPath.AddBeziers(points);
		}

		private void AddStrokeCup(GraphicsPath graphicsPath)
		{
			graphicsPath.StartFigure();
			PointF[] points = new PointF[]
			{
				new PointF(205, 268),
				new PointF(223, 331),
				new PointF(281, 331),
				new PointF(300, 268),
			};

			graphicsPath.AddLines(points);
		}

		private void AddStrokeCupHandle(GraphicsPath graphicsPath)
		{
			graphicsPath.StartFigure();
			PointF[] points = new PointF[]
			{
				new PointF(300, 283),
				new PointF(330, 290),
				new PointF(288, 323),
			};

			graphicsPath.AddCurve(points, 1);
		}

		private void AddStrokeSteam(GraphicsPath graphicsPath)
		{
			graphicsPath.StartFigure();
			PointF[] points = new PointF[]
			{
				new PointF(252, 258),
				new PointF(213, 163),
				new PointF(305, 160),
				new PointF(246, 50),
			};

			graphicsPath.AddBeziers(points);
		}


		#endregion

		#region Event Handlers

		private void saveButton_Click(object sender, System.EventArgs e)
		{
			if (libraryBrowser.ExpandedGroup != null)
				libraryBrowser.ExpandedGroup.SaveLibrary();
		}

		private void openButton_Click(object sender, System.EventArgs e)
		{
			libraryBrowser.OpenLibraryGroup();
		}

		private void newButton_Click(object sender, System.EventArgs e)
		{
			libraryBrowser.NewEmptyLibraryGroup("New library");
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			if (libraryBrowser.ExpandedGroup != null)
				libraryBrowser.CloseLibraryGroup(libraryBrowser.ExpandedGroup);
		}

		private void viewStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			libraryBrowser.ViewStyle = (LibraryViewStyle)viewStyleCombo.SelectedIndex;
		}

		
		#endregion
		
		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton saveButton;
		
		private Nevron.UI.WinForm.Controls.NButton openButton;
		private Nevron.UI.WinForm.Controls.NButton newButton;
		private Nevron.UI.WinForm.Controls.NButton closeButton;
		private Nevron.UI.WinForm.Controls.NComboBox viewStyleCombo;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.Windows.Forms.Label label1;

		#endregion
		
		#region Fields

		private NLibraryGroup libraryGroup = null;
		private NLibraryBrowser libraryBrowser;

		#endregion
	}
}