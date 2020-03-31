using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Web;

using Nevron.Diagram;
using Nevron.Diagram.Maps;
using Nevron.Diagram.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	public partial class NMapProjectionsUC : NDiagramExampleUC
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

			// Init the document
			NDrawingDocument document = NThinDiagramControl1.Document;
			document.BeginInit();
			CreateStyleSheets(document);
			CreateStarPointShape(document);
			MapRenderer mapRenderer = new MapRenderer();
			mapRenderer.InitDocument(document, MapProjections[16]);
			document.EndInit();

			// Populate the cities combo box
			PopulateProjectionsComboBox(16);
		}

		#region Implementation

		private void CreateStyleSheets(NDrawingDocument document)
		{
			// Create the zoomed city style sheet
			NStyleSheet zoomedCity = new NStyleSheet();
			zoomedCity.Name = "Zoomed City";
			zoomedCity.Style.FillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.DarkRed, Color.Red);
			document.StyleSheets.AddChild(zoomedCity);
		}
		private void CreateStarPointShape(NDrawingDocument document)
		{
			// create the graphics path representing the point shape
			NRectangleF modelBounds = new NRectangleF(-1, -1, 2, 2);
			GraphicsPath path = new GraphicsPath();
			CreateNGramPath(path, modelBounds, 5, - NMath.PIHalf, 0.5f);

			// wrap it in amodel and name it
			NCustomPath customPath = new NCustomPath(path, PathType.ClosedFigure);
			customPath.Name = "Star";

			// add it to the stencil
			document.PointShapeStencil.AddChild(customPath);
		}
		private void CreateNGramPath(GraphicsPath path, NRectangleF rect, int edgeCount, float startAngle, float innerRadius)
		{
			int i;
			float angle;
			float halfWidth = rect.Width / 2.0f;
			float halfHeight = rect.Height / 2.0f;
			float centerX = rect.X + halfWidth;
			float centerY = rect.Y + halfHeight;
			float incAngle = (float)(2 * Math.PI / edgeCount);
			float innerOffsetAngle = (float)(Math.PI / edgeCount);

			PointF[] outer = new PointF[edgeCount];
			PointF[] inner = new PointF[edgeCount];

			for (i = 0; i < edgeCount; i++)
			{
				angle = startAngle + i * incAngle;
				outer[i].X = (float)Math.Round(centerX + Math.Cos(angle) * halfWidth, 1);
				outer[i].Y = (float)Math.Round(centerY + Math.Sin(angle) * halfHeight, 1);

				angle += innerOffsetAngle;
				inner[i].X = (float)Math.Round(centerX + Math.Cos(angle) * innerRadius, 1);
				inner[i].Y = (float)Math.Round(centerY + Math.Sin(angle) * innerRadius, 1);
			}

			for (i = 0; i < (edgeCount - 1); i++)
			{
				path.AddLine(outer[i], inner[i]);
				path.AddLine(inner[i], outer[i + 1]);
			}

			path.AddLine(outer[i], inner[i]);
			path.CloseAllFigures();
		}
		private void PopulateProjectionsComboBox(int checkedIndex)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0, count = MapProjections.Length; i < count; i++)
			{
				sb.Append("<input type=\"radio\" name=\"ProjectionRadioButton\" value=\"");
				sb.Append(i);
				sb.Append("\" ");
				sb.Append("onclick=\"ChangeProjection(this.value)\"");
				sb.Append(i == checkedIndex ? " checked=\"checked\">" : ">");
				sb.Append(MapProjections[i].ToString());
				sb.AppendLine("<br />");
			}

			ProjectionsRadioGroup.Text = sb.ToString();
		}

		#endregion

		#region Constants

		private const string CountriesShapefileName = @"..\App_Data\Gis_Data\countries.shp";
		private static readonly Color[] MapColors = new Color[]
		{
            Color.OldLace,
            Color.PaleGreen,
            Color.Gold,
            Color.Gray,
            Color.Tan,
            Color.Khaki,
            Color.IndianRed,
            Color.Orange,
			Color.Tomato,
			Color.PaleGoldenrod,
			Color.Wheat,
        };

		private static readonly NMapProjection[] MapProjections = new NMapProjection[]{
				new NAitoffProjection(),
				new NBonneProjection(),

				new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Lambert),
				new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Behrmann),
				new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.TristanEdwards),
				new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Peters),
				new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Gall),
				new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Balthasart),

				new NEckertIVProjection(),
				new NEckertVIProjection(),
				new NEquirectangularProjection(),
				new NHammerProjection(),
				new NKavrayskiyVIIProjection(),
				new NMercatorProjection(),
				new NMillerCylindricalProjection(),
				new NMollweideProjection(),
				new NOrthographicProjection(),
				new NRobinsonProjection(),
				new NStereographicProjection(),
				new NVanDerGrintenProjection(),
				new NWagnerVIProjection(),
				new NWinkelTripelProjection()
			};

		#endregion

		#region Nested Types

		[Serializable]
		private class CustomRequestCallback : INCustomRequestCallback
		{
			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NDrawingDocument document = diagramControl.Document;
				int index = Int32.Parse(argument);
				MapRenderer mapRenderer = new MapRenderer();
				mapRenderer.InitDocument(document, MapProjections[index]);
				diagramControl.UpdateView();
			}
		}

		private class MapRenderer
		{
			public void InitDocument(NDrawingDocument document, NMapProjection mapProjection)
			{
				document.Layers.RemoveAllChildren();
				document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
				document.Bounds = new NRectangleF(0, 0, 5000, 5000);
				document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);

				NEsriMapImporter mapImporter = new NEsriMapImporter();
				mapImporter.MapBounds = NMapBounds.World;

				// Add the countries shape file
				NEsriShapefile countries = new NEsriShapefile(HttpContext.Current.Server.MapPath(CountriesShapefileName));
				countries.NameColumn = "NAME";
				mapImporter.AddLayer(countries);

				// Read the map data
				mapImporter.Read();

				mapImporter.Projection = mapProjection;
				mapImporter.Parallels.ArcRenderMode = ArcRenderMode.Fine;
				mapImporter.Meridians.ArcRenderMode = ArcRenderMode.Fine;

				// Add a fill rule
				countries.FillRule = new NMapFillRuleValue("ISO_NUM", MapColors);

				// Import the map
				mapImporter.Import(document, document.Bounds);

				// Size the document to content
				document.SizeToContent();
			}
		}

		#endregion
	}
}