using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Dom;

using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Batches;
using Nevron.Diagram.WebForm;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.DataStructures;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NCustomToolsUC.
	/// </summary>
	public partial class NCustomToolsUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			NDrawingView1.AjaxToolsFactoryType = "NCustomToolFactory";

			if (NDrawingView1.RequiresInitialization)
			{
				// init document
				NDrawingView1.Document.BeginInit();
				InitDocument();
				NDrawingView1.Document.EndInit();
			}
		}

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxDynamicCursorTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxCustomTool(true));
		}

		#region Implementation

		void InitDocument()
		{
			// set up visual formatting
			NDrawingView1.Document.Style.FillStyle = new NColorFillStyle(Color.White);
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;

			NCustomToolsData.NBookEntry[] books = NCustomToolsData.CreateBooks();

			//	set up the shape factories
			NBasicShapesFactory bookItemsFactory = new NBasicShapesFactory(NDrawingView1.Document);
			bookItemsFactory.DefaultSize = new NSizeF(150, 100);

			//	create a table layout, which will align te thumbnail and the text within a group
			NTableLayout bookThumbLayout = new NTableLayout();
			bookThumbLayout.Direction = LayoutDirection.LeftToRight;
			bookThumbLayout.ConstrainMode = CellConstrainMode.Ordinal;
			bookThumbLayout.MaxOrdinal = 1;

			//	create a table layout, which will align all books in a grid
			NTableLayout tableLayout = new NTableLayout();
			tableLayout.Direction = LayoutDirection.LeftToRight;
			tableLayout.ConstrainMode = CellConstrainMode.Ordinal;
			tableLayout.MaxOrdinal = 4;
			tableLayout.HorizontalSpacing = 7;
			tableLayout.VerticalSpacing = 7;

			NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(NDrawingView1.Document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(NDrawingView1.Document);

			int length = books.Length;
			for (int i = 0; i < length; i++)
			{
				NCustomToolsData.NBookEntry book = books[i];

				NShape bookThumbnailShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle);
				NImageFillStyle fs1 = new NImageFillStyle(this.MapPathSecure(@"..\..\..\..\Images\CustomTools\" + book.ThumbnailFile));
				fs1.TextureMappingStyle.MapLayout = MapLayout.Centered;
				NStyle.SetFillStyle(bookThumbnailShape, fs1);
				NStyle.SetStrokeStyle(bookThumbnailShape, new NStrokeStyle(0, Color.White));

				NShape bookTextShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle);
				NStyle.SetStrokeStyle(bookTextShape, new NStrokeStyle(0, Color.White));
				bookTextShape.Text = book.Title;
				bookTextShape.Height = 50f;

				bookThumbnailShape.Style.InteractivityStyle = new NInteractivityStyle(true, book.Id.ToString(), null, CursorType.Hand);
				bookTextShape.Style.InteractivityStyle = new NInteractivityStyle(true, book.Id.ToString(), null, CursorType.Hand);

				//	create the book tumbnail group
				NGroup g = new NGroup();
				NBatchGroup bgroup = new NBatchGroup(NDrawingView1.Document);
				NNodeList shapes = new NNodeList();

				shapes.Add(bookThumbnailShape);
				shapes.Add(bookTextShape);

				// perform layout
				bookThumbLayout.Layout(shapes, layoutContext);

				// group shapes
				bgroup.Build(shapes);
				bgroup.Group(null, false, out g);

				NDrawingView1.Document.ActiveLayer.AddChild(g);
			}

			// layout the books
			tableLayout.Layout(NDrawingView1.Document.ActiveLayer.Children(null), layoutContext);
		}

		#endregion
	}

	/// <summary>
	/// Provides configuration for the client side NAjaxCustomTool tool.
	/// </summary>
	[Serializable]
	public class NAjaxCustomTool : NAjaxToolDefinition
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of NAjaxCustomTool with a given default enabled value.
		/// </summary>
		/// <param name="defaultEnabled">
		/// Selects the initial enabled state of the tool.
		/// </param>
		public NAjaxCustomTool(bool defaultEnabled)
			: base(@"NCustomTool", defaultEnabled)
		{
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Generates JavaScript that will create a new tool configuration object at the client.
		/// </summary>
		/// <returns>Returns a JavaScript that will create a new tool configuration object at the client.</returns>
		protected override string GetConfigurationObjectJavaScript()
		{
			return "new NCustomToolConfig()";
		}

		#endregion
	}
}
