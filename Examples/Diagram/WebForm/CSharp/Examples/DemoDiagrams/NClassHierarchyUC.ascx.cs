using System;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.Layout;
using Nevron.Diagram.ThinWeb;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NClassHierarchyUC.
	/// </summary>
	public partial class NClassHierarchyUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized == false)
			{
				// Init the thin diagram control
				NThinDiagramControl1.CustomRequestCallback = new CustomRequestCallback();
				NThinDiagramControl1.Controller.Tools.Add(new NRectZoomTool());
				NPanTool panTool = new NPanTool();
				panTool.Enabled = false;
				NThinDiagramControl1.Controller.Tools.Add(panTool);

				// Set manual ID so that it can be referenced in JavaScript
				NThinDiagramControl1.StateId = "Diagram1";

				// Init the view
				NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

				// Init the toolbar
				NThinDiagramControl1.Toolbar.Visible = true;
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NZoomInAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NZoomOutAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarSeparator());

				Array values = Enum.GetValues(typeof(CanvasLayout));
				for (int i = 0; i < values.Length; i++)
				{
					NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleViewLayoutAction((CanvasLayout)values.GetValue(i))));
				}

				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarSeparator());
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NTogglePanToolAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleRectZoomToolAction()));

				// Init the document
				InitDocument(NThinDiagramControl1.Document, typeof(NLayout));
			}
		}

		#region Implementation

		private static void InitDocument(NDrawingDocument document, Type type)
		{
			// set up visual formatting
			document.BackgroundStyle.FrameStyle.Visible = false;
			document.ActiveLayer.RemoveAllChildren();
			document.BeginInit();

			NClassImporter importer = new NClassImporter(document);
            importer.ImportInActiveLayer = true;
            importer.Import(type);

			document.EndInit();
			document.SizeToContent();
		}
		
		#endregion

		#region Nested Types

		[Serializable]
		class CustomRequestCallback : INCustomRequestCallback
		{
			#region INCustomRequestCallback Members

			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				InitDocument(diagramControl.Document, Type.GetType(argument));
				control.UpdateView();
			}

			#endregion
		}

		#endregion
	}
}