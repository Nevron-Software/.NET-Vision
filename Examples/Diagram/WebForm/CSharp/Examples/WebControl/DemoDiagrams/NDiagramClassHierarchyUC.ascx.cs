using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;

using Nevron.Dom;
using Nevron.Diagram.Filters;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.Diagram.Extensions;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NDiagramClassHierarchyUC.
	/// </summary>
	public partial class NDiagramClassHierarchyUC : NDiagramExampleUC
	{
		#region Implementation

		protected void InitFormControls()
		{
            RootTypesDropDownList.DataSource = TYPES;
            RootTypesDropDownList.DataMember = "Name";
            RootTypesDropDownList.DataTextField = "Name";
            RootTypesDropDownList.DataBind();
			RootTypesDropDownList.SelectedIndex = 2;
		}
		private void RebuildDocument()
		{
			if (RootTypesDropDownList.SelectedItem == null)
				return;

			NDrawingView1.Document.BeginInit();
			RecreateDocument(TYPES[RootTypesDropDownList.SelectedIndex]);
			NDrawingView1.Document.EndInit();	
		}
		protected void RecreateDocument(Type type)
		{
			// set up visual formatting
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren();
			NDrawingView1.Document.BeginInit();

            NClassImporter importer = new NClassImporter(NDrawingView1.Document);
            importer.ImportInActiveLayer = true;
            importer.Import(type);

			NDrawingView1.Document.EndInit();
			NDrawingView1.Document.SizeToContent();
			NDrawingView1.Width = new Unit(NDrawingView1.Document.Bounds.Width, System.Web.UI.WebControls.UnitType.Pixel);
			NDrawingView1.Height = new Unit(NDrawingView1.Document.Bounds.Height, System.Web.UI.WebControls.UnitType.Pixel);
		}
		
		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				InitFormControls();
			}

			// begin view init
			NDrawingView1.ViewLayout = CanvasLayout.Fit; 

			if (!IsPostBack)
			{
				RebuildDocument();
			}

			NHtmlImageMapResponse response = new NHtmlImageMapResponse();
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = response;
			NDrawingView1.ServerSettings.ControlStateSettings.PersistControlState = true;
			NDrawingView1.EnableViewState  = true;
		}
		protected void RootTypesDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			RebuildDocument();
		}

		#endregion

        #region Static

        private static readonly Type[] TYPES = new Type[]{
            typeof(NLayout),
            typeof(NPrimitiveShape),
            typeof(NShapePoint)
        };

        #endregion
    }
}