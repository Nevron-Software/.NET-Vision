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
	public partial class NWorldMapUC : NDiagramExampleUC
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
			List<NCityInfo> cities = InitDocument(document);
			document.EndInit();

			// Populate the cities combo box
			PopulateCityComboBox(cities);
		}

		#region Implementation

		private List<NCityInfo> InitDocument(NDrawingDocument document)
		{
			document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
			document.Bounds = new NRectangleF(0, 0, 5000, 5000);
			document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);

			CreateStyleSheets(document);
			CreateStarPointShape(document);

			NEsriMapImporter mapImporter = new NEsriMapImporter();
			mapImporter.MapBounds = NMapBounds.World;

			// Add the countries shape file
			NEsriShapefile countries = new NEsriShapefile(HttpContext.Current.Server.MapPath(CountriesShapefileName));
			countries.NameColumn = "NAME";
			countries.TextColumn = "NAME";
			countries.MaxTextShowZoomFactor = 0.99f;
			mapImporter.AddLayer(countries);

			// Add the cities shape file
			NEsriShapefile cities = new NEsriShapefile(HttpContext.Current.Server.MapPath(CitiesShapefileName));
			cities.NameColumn = "NAME";
			cities.TextColumn = "NAME";
			cities.MinShowZoomFactor = 1.0f;

			cities.PointSizeColumn = "POPULATION";
			cities.MinPointShapeSize = new NSizeF(10, 10);
			cities.MaxPointShapeSize = new NSizeF(40, 40);

			mapImporter.AddLayer(cities);

			// Read the map data
			mapImporter.Read();

			// Set a fill rule for the countries
			countries.FillRule = new NMapFillRuleValue("ISO_NUM", MapColors);

			// Add a shape created listener
			mapImporter.ShapeCreatedListener = new NCustomShapeCreatedListener();

			// Import the map
			mapImporter.Import(document, document.Bounds);

			// Size the document to content
			document.SizeToContent();

			return ((NCustomShapeCreatedListener)mapImporter.ShapeCreatedListener).Cities;
		}
		private void CreateStyleSheets(NDrawingDocument document)
		{
			// Create the zoomed city style sheet
			NStyleSheet zoomedCity = new NStyleSheet();
			zoomedCity.Name = "ZoomedCity";
			NTextStyle textStyle = (NTextStyle)document.ComposeTextStyle().Clone();
			textStyle.FontStyle = new NFontStyle(textStyle.FontStyle.Name, textStyle.FontStyle.EmSize, FontStyle.Bold);
			NStyle.SetTextStyle(zoomedCity, textStyle);
			NStyle.SetFillStyle(zoomedCity, new NColorFillStyle(Color.Red));
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
		private void PopulateCityComboBox(List<NCityInfo> cities)
		{
			cities.Sort();

			StringBuilder sb = new StringBuilder();
			sb.Append("<select id='citiesCombo'>");

			for (int i = 0; i < cities.Count; i++)
			{
				NPointF location = cities[i].Location;
				sb.AppendFormat(CultureInfo.InvariantCulture, "<option value=\"{0},{1}\">{2}</option>",
					location.X, location.Y, cities[i].Name);
			}

			sb.Append("</select>");
			CitiesComboBox.Text = sb.ToString();
		}

		#endregion

		#region Constants

		private const string CountriesShapefileName = @"..\App_Data\Gis_Data\countries.shp";
		private const string CitiesShapefileName = @"..\App_Data\Gis_Data\cities.shp";
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

		#endregion

		#region Nested Types

		private class NCityInfo : IComparable<NCityInfo>
		{
			public NCityInfo(string name, NPointF location)
			{
				Name = name;
				Location = location;
			}

			public int CompareTo(NCityInfo other)
			{
				return this.Name.CompareTo(other.Name);
			}

			public string Name;
			public NPointF Location;
		}

		private class NCustomShapeCreatedListener : NShapeCreatedListener
		{
			#region Constructors

			public NCustomShapeCreatedListener()
			{
				Cities = new List<NCityInfo>();
			}

			#endregion

			#region INShapeCreatedListener

			public override bool OnPointCreated(NMapPointLabel pointLabel, NMapFeature mapFeature)
			{
				string name = mapFeature.GetAttributeValue("NAME").ToString();
				Cities.Add(new NCityInfo(name, pointLabel.PinPoint));

				if (mapFeature.GetAttributeValue("CAPITAL").Equals("Y"))
				{
					pointLabel.ShapeType = PointShape.Custom;
					pointLabel.CustomShapeName = "Star";
				}

				return true;
			}

			#endregion

			#region Fields

			public List<NCityInfo> Cities;

			#endregion

			#region Constants

			private static readonly float[,] cityPopulationScales = new float[,]{
                {1000000, 1.3f},
                {2000000, 1.6f},
                {5000000, 2.0f},
                {10000000, 2.5f},
                {20000000, 3.0f}
            };

			#endregion
		}

		[Serializable]
		private class CustomRequestCallback : INCustomRequestCallback
		{
			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NDrawingDocument document = diagramControl.Document;

				string[] args = argument.Split(',');
				string cityName = args[0];
				float x = Single.Parse(args[1], CultureInfo.InvariantCulture);
				float y = Single.Parse(args[2], CultureInfo.InvariantCulture);

				if (document.Tag is NPointElement)
				{
					((NPointElement)document.Tag).StyleSheetName = String.Empty;
					document.Tag = null;
				}

				NLayer cityLayer = diagramControl.Document.Layers.GetChildByName("cities") as NLayer;
				if (cityLayer != null)
				{
					// Apply the new style to the newly zoomed city
					NMapLabelsShape labelsShape = (NMapLabelsShape)cityLayer.GetChildAt(0);
					NMapPointLabel city = (NMapPointLabel)labelsShape.MapLabels.GetChildByName(cityName);
					city.StyleSheetName = "ZoomedCity";

					// Remember the currently highlighted city in the document's tag
					document.Tag = city;
				}

				diagramControl.View.Layout = CanvasLayout.Normal;
				diagramControl.Zoom(2, new NPointF(x, y));
			}
		}

		#endregion
	}
}