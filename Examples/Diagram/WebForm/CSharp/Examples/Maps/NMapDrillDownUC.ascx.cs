using System;
using System.Drawing;
using System.IO;
using System.Web;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Maps;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	public partial class NMapDrillDownUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized)
				return;

			// Init the diagram control
			MapRenderer mapRenderer = new MapRenderer();

			// Configure the controller
			NServerMouseEventTool serverMouseEventTool = new NServerMouseEventTool();
			NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool);
			serverMouseEventTool.MouseDown = new NMouseDownEventCallback(mapRenderer);

			// Init the view
			NThinDiagramControl1.View.MinZoomFactor = 0.1f;
			NThinDiagramControl1.View.MaxZoomFactor = 50;
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

			// Configure the controller
			NThinDiagramControl1.Controller.Tools.Add(new NTooltipTool());
			NThinDiagramControl1.Controller.Tools.Add(new NCursorTool());

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
			NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleTooltipToolAction()));

			// Init the document
			NDrawingDocument document = NThinDiagramControl1.Document;
			document.BeginInit();
			NDataGrouping dataGrouping = new NDataGroupingOptimal();
			dataGrouping.RoundedRanges = true;
			mapRenderer.InitDocument(document);
			document.EndInit();
		}

		#region Constants

		private const int MapWidth = 1000;
		private const int MapHeight = 1000;

		private const string UsaShapefileName = @"..\App_Data\Gis_Data\usa.shp";
		private const string StatesFolder = @"..\App_Data\Gis_Data\States";

		#endregion

		#region Nested Types

		[Serializable]
		class NMouseDownEventCallback : INMouseEventCallback
		{
			public NMouseDownEventCallback(MapRenderer mapRenderer)
			{
				m_MapRenderer = mapRenderer;
			}

			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NNodeList nodes = diagramControl.HitTest(new NPointF(e.X, e.Y));
				NNodeList shapes = nodes.Filter(NFilters.Shape2D);
				NDrawingDocument document = diagramControl.Document;

				if (String.IsNullOrEmpty(m_MapRenderer.CurrentState))
				{
					if (shapes.Count == 0)
						return;

					// The user has clicked a state
					NShape shape = (NShape)shapes[0];
					m_MapRenderer.LoadStateMap(document, shape.Name);
				}
				else
				{
					if (shapes.Count == 0)
					{
						// Return to the States map
						m_MapRenderer.LoadUsaMap(document);
					}
					else
					{
						// The user has clicked a county
						NShape shape = (NShape)shapes[0];
						if (shape.StyleSheetName == "ClickedCounty")
						{
							// The user has clicked a selected county - unselect it
							shape.StyleSheetName = String.Empty;
							shape.Text = String.Empty;
						}
						else
						{
							// The user has clicked a non selected county - select it (make it red)
							shape.StyleSheetName = "ClickedCounty";
							shape.Text = shape.Name;
						}
					}
				}

				diagramControl.UpdateView();
			}

			#endregion

			#region Fields

			private MapRenderer m_MapRenderer;

			#endregion
		}

		[Serializable]
		private class MapRenderer
		{
			public MapRenderer()
			{
				m_sCurrentState = null;
			}

			public string CurrentState
			{
				get
				{
					return m_sCurrentState;
				}
			}

			public void InitDocument(NDrawingDocument document)
			{
				// Set up visual formatting
				document.BackgroundStyle.FrameStyle.Visible = false;
				document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);
				document.GraphicsSettings.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

				// Create style sheets
				NStyleSheet clickedCounty = new NStyleSheet("ClickedCounty");
				NStyle.SetFillStyle(clickedCounty, new NColorFillStyle(KnownArgbColorValue.Red));
				NStyle.SetTextStyle(clickedCounty, new NTextStyle(document.ComposeTextStyle().FontStyle, Color.White));
				document.StyleSheets.AddChild(clickedCounty);

				// Load the map of the USA
				LoadUsaMap(document);
			}
			public void LoadUsaMap(NDrawingDocument document)
			{
				m_sCurrentState = null;
				LoadMap(document, UsaShapefileName, "STATE_ABBR", "STATE_ABBR", "STATE_NAME", MapWidth, MapHeight);
			}
			public void LoadStateMap(NDrawingDocument document, string abbrStateName)
			{
				m_sCurrentState = abbrStateName;
				string fileName = Path.Combine(StatesFolder, abbrStateName);
				fileName = Path.Combine(fileName, abbrStateName + ".shp");
				LoadMap(document, fileName, "FIPS", null, "NAME", MapWidth * 0.6f, MapHeight * 0.6f);
			}

			private void LoadMap(NDrawingDocument document, string fileName, string nameColumn, string textColumn,
				string toolTipColumn, float width, float height)
			{
				document.Layers.RemoveAllChildren();
				document.Width = width;
				document.Height = height;

				NEsriMapImporter mapImporter = new NEsriMapImporter();

				// Create the STATES shape file
				NEsriShapefile countries = new NEsriShapefile(HttpContext.Current.Server.MapPath(fileName));
				countries.NameColumn = nameColumn;
				countries.TextColumn = textColumn;
				mapImporter.AddLayer(countries);

				// Import the map
				mapImporter.Read();
				if (String.IsNullOrEmpty(toolTipColumn) == false)
				{
					mapImporter.ShapeCreatedListener = new NCustomShapeCreatedListener(toolTipColumn);
				}

				mapImporter.Import(document, document.Bounds);
				document.SizeToContent();
			}

			private string m_sCurrentState;
		}

		private class NCustomShapeCreatedListener : NShapeCreatedListener
		{
			public NCustomShapeCreatedListener(string tooltipColumnName)
			{
				m_sTooltipColumnName = tooltipColumnName;
			}

			public override bool OnPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
			{
				NShape shape = element as NShape;
				if (shape != null)
				{
					NInteractivityStyle iStyle = new NInteractivityStyle(true, null, mapFeature.GetAttributeValue(m_sTooltipColumnName).ToString());
					NStyle.SetInteractivityStyle(shape, iStyle);
				}

				return base.OnPolygonCreated(element, mapFeature);
			}
			public override bool OnMultiPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
			{
				return OnPolygonCreated(element, mapFeature);
			}

			private string m_sTooltipColumnName;
		}

		#endregion
	}
}