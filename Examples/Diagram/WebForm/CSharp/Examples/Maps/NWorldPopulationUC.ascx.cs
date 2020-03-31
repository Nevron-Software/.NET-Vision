using System;
using System.Drawing;
using System.Web;

using Nevron.Diagram;
using Nevron.Diagram.Maps;
using Nevron.Diagram.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	public partial class NWorldPopulationUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized)
				return;

			// Init the diagram control
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

			// Create the default data grouping
			NDataGrouping dataGrouping = new NDataGroupingOptimal();
			dataGrouping.RoundedRanges = true;

			// Init the document
			NDrawingDocument document = NThinDiagramControl1.Document;
			document.BeginInit();
			MapRenderer mapRenderer = new MapRenderer();
			mapRenderer.InitDocument(document, dataGrouping);
			document.EndInit();
		}

		#region Constants

		private const string CountriesShapefileName = @"..\App_Data\Gis_Data\countries.shp";
		private const string WhiteTextStyleSheetName = "WhiteText";

		#endregion

		#region Nested Types

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
				// Configure the drawing document
				document.Layers.RemoveAllChildren();
				document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
				document.RoutingManager.Enabled = false;
				document.BridgeManager.Enabled = false;
				document.Bounds = new NRectangleF(0, 0, 5000, 5000);
				document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);

				// Add a style sheet
				NStyleSheet styleSheet = new NStyleSheet(WhiteTextStyleSheetName);
				NTextStyle textStyle = (NTextStyle)document.ComposeTextStyle().Clone();
				textStyle.FillStyle = new NColorFillStyle(KnownArgbColorValue.White);
				NStyle.SetTextStyle(styleSheet, textStyle);
				document.StyleSheets.AddChild(styleSheet);

				// Create a map importer
				NEsriMapImporter mapImporter = new NEsriMapImporter();
				mapImporter.MapBounds = NMapBounds.World;

				// Add a shapefile
				NEsriShapefile countries = new NEsriShapefile(HttpContext.Current.Server.MapPath(CountriesShapefileName));
				countries.NameColumn = "NAME";
				countries.TextColumn = "NAME";
				mapImporter.AddLayer(countries);

				// Read the map data
				mapImporter.Read();

				// Create a fill rule
				NMapFillRuleRange fillRule = new NMapFillRuleRange("POP_1994", Color.White, Color.Black, 12);
				fillRule.DataGrouping = dataGrouping;
				countries.FillRule = fillRule;

				// Associate a shape created listener and import the map data
				mapImporter.ShapeCreatedListener = new NCustomShapeCreatedListener();
				mapImporter.Import(document, document.Bounds);

				// Generate a legend
				NMapLegendRange mapLegend = (NMapLegendRange)mapImporter.GetLegend(fillRule);
				mapLegend.Title = "Population (thousands people)";
				mapLegend.RangeFormatString = "{0:#,###,##0,} - {1:#,###,##0,}";
				mapLegend.LastFormatString = "more than {0:#,###,##0,}";
				NMapLegendRenderPage.MapLegend = mapLegend;

				document.SizeToContent();
			}
		}

		private class NCustomShapeCreatedListener : NShapeCreatedListener
		{
			public override bool OnPolygonLabelCreated(NMapPolygonLabel polygonLabel, NMapFeature mapFeature)
			{
				NStyleableElement master = (NStyleableElement)polygonLabel.MasterElement;
				Color color = master.ComposeFillStyle().GetPrimaryColor().ToColor();

				if (color.R < 128)
				{
					// Make the text of dark shape labels white
					polygonLabel.StyleSheetName = WhiteTextStyleSheetName;
				}

				return true;
			}
		}

		#endregion
	}
}