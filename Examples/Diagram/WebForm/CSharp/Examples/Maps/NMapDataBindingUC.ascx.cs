using System;
using System.Data;
using System.Drawing;
using System.Web;

using Nevron.Diagram;
using Nevron.Diagram.Maps;
using Nevron.Diagram.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	public partial class NMapDataBindingUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized)
				return;

			// Init the diagram control
			CustomSerializationCallback serializationCallback = new CustomSerializationCallback();
			NThinDiagramControl1.DocumentSerializationCallback = serializationCallback;
			NThinDiagramControl1.CustomRequestCallback = new CustomRequestCallback();

			// Set manual ID so that it can be referenced in JavaScript
			NThinDiagramControl1.StateId = "Diagram1";

			// Init the view
			NThinDiagramControl1.View.MinZoomFactor = 0.1f;
			NThinDiagramControl1.View.MaxZoomFactor = 50;
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

			// Configure the controller
			NThinDiagramControl1.Controller.Tools.Add(new NTooltipTool());
			NThinDiagramControl1.Controller.Tools.Add(new NCursorTool());
			NThinDiagramControl1.Controller.Tools.Add(new NRectZoomTool());
			NPanTool panTool = new NPanTool();
			panTool.Enabled = false;
			NThinDiagramControl1.Controller.Tools.Add(panTool);

			// Configure the toolbar
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

			// Render the map
			serializationCallback.Deserialize(NThinDiagramControl1);
		}

		#region Constants

		private const string CountriesShapefileName = @"..\App_Data\Gis_Data\countries.shp";
		private const string SalesXmlFileName = @"..\App_Data\sales.xml";

		#endregion

		#region Nested Types

		[Serializable]
		private class CustomSerializationCallback : INDrawingDocumentSerializationCallback
		{
			#region INDrawingDocumentSerializationCallback Members

			public NDrawingDocument Deserialize(NThinDiagramControl control)
			{
				if (m_Document == null)
				{
					// Create the default data grouping
					NDataGrouping dataGrouping = new NDataGroupingOptimal();
					dataGrouping.RoundedRanges = true;

					// Init the document
					m_Document = new NDrawingDocument();
					m_Document.BeginInit();
					MapRenderer mapRenderer = new MapRenderer();
					mapRenderer.InitDocument(m_Document, dataGrouping);
					m_Document.EndInit();
				}

				return m_Document;
			}
			public void Serialize(NThinDiagramControl control, NDrawingDocument document)
			{				
			}

			#endregion

			#region Fields

			[NonSerialized]
			NDrawingDocument m_Document;

			#endregion
		}

		[Serializable]
		private class CustomRequestCallback : INCustomRequestCallback
		{
			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				string[] args = argument.Split(',');
				NDataGrouping dataGrouping = null;

				switch (args[0])
				{
					case "EqualDistribution":
						dataGrouping = new NDataGroupingEqualDistribution();
						break;
					case "EqualInterval":
						dataGrouping = new NDataGroupingEqualInterval();
						break;
					case "Optimal":
						dataGrouping = new NDataGroupingOptimal();
						break;
					default:
						throw new Exception("New data grouping type?");
				}

				dataGrouping.RoundedRanges = Boolean.Parse(args[1]);

				MapRenderer mapRenderer = new MapRenderer();
				mapRenderer.InitDocument(diagramControl.Document, dataGrouping);

				diagramControl.UpdateView();
				diagramControl.AddCustomClientCommand("UpdateLegend");
			}
		}

		private class MapRenderer
		{
			public void InitDocument(NDrawingDocument document, NDataGrouping dataGrouping)
			{
				document.Layers.RemoveAllChildren();
				document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
				document.RoutingManager.Enabled = false;
				document.BridgeManager.Enabled = false;
				document.Bounds = new NRectangleF(0, 0, 5000, 5000);
				document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);

				NEsriMapImporter mapImporter = new NEsriMapImporter();
				mapImporter.MapBounds = NMapBounds.World;

				NEsriShapefile countries = new NEsriShapefile(HttpContext.Current.Server.MapPath(CountriesShapefileName));
				countries.NameColumn = "NAME";
				countries.TextColumn = "NAME";
				mapImporter.AddLayer(countries);

				mapImporter.Read();

				// Load the data
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(HttpContext.Current.Server.MapPath(SalesXmlFileName), XmlReadMode.ReadSchema);

				// Create a data binding source
				NMapDataTableBindingSource source = new NMapDataTableBindingSource(dataSet.Tables["Sales"]);

				// Create a data binding context
				NMapDataBindingContext context = new NMapDataBindingContext();
				context.AddColumnMatching("NAME", "Country");
				context.ColumnsToImport.Add("Sales");

				// Perform the data binding
				countries.DataBind(source, context);

				// Add a fill rule
				NMapFillRuleRange fillRule = new NMapFillRuleRange("Sales", Color.White, Color.DarkGreen, 8);
				fillRule.DataGrouping = dataGrouping;
				countries.FillRule = fillRule;

				mapImporter.Import(document, document.Bounds);

				// Generate the legend
				NMapLegendRange mapLegend = (NMapLegendRange)mapImporter.GetLegend(fillRule);
				mapLegend.Title = "Sales";
				mapLegend.RangeFormatString = "{0:N0} - {1:N0} million dollars";
				mapLegend.LastFormatString = "{0:N0} million dollars and more";
				NMapLegendRenderPage.MapLegend = mapLegend;

				document.SizeToContent();
			}
		}

		#endregion
	}
}