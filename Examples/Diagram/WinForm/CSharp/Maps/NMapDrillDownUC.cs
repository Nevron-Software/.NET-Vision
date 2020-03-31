using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Maps;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
	public class NMapDrillDownUC : NDiagramExampleUC
	{
        #region Constructors

		public NMapDrillDownUC(NMainForm form)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NMapDrillDownUC));
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.LemonChiffon;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Location = new System.Drawing.Point(12, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(236, 87);
			this.label2.TabIndex = 4;
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BackColor = System.Drawing.Color.AliceBlue;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(13, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(235, 43);
			this.label1.TabIndex = 3;
			this.label1.Text = "Map Drill Down";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NMapDrillDownUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NMapDrillDownUC";
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.ResumeLayout(false);

		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// init form fields
			view.BeginInit();

			view.Grid.Visible = false;
			view.GlobalVisibility.ShowPorts = false;
			view.GlobalVisibility.ShowArrowheads = false;
			view.VerticalRuler.Visible = false;
			view.HorizontalRuler.Visible = false;
			view.ViewLayout = ViewLayout.Fit;

			// disable the selector tool
			view.Controller.Tools.DisableTools(new string[] { Nevron.Diagram.WinForm.NDWFR.ToolSelector });

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();
			document.SizeToContent();

			// end view init
			view.EndInit();
		}
		protected override void AttachToEvents()
		{
			base.AttachToEvents();

			document.EventSinkService.NodeMouseDown += new NodeMouseEventHandler(OnNodeMouseDown);
		}
		protected override void DetachFromEvents()
		{
			base.DetachFromEvents();

			document.EventSinkService.NodeMouseDown -= new NodeMouseEventHandler(OnNodeMouseDown);
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
			// Set up visual formatting
			document.BackgroundStyle.FrameStyle.Visible = false;
			document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);
			document.GraphicsSettings.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

			// Create style sheets
			NStyleSheet clickedCounty = new NStyleSheet("ClickedCounty");
			NStyle.SetFillStyle(clickedCounty, new NColorFillStyle(KnownArgbColorValue.Red));
			NStyle.SetTextStyle(clickedCounty, new NTextStyle(document.ComposeTextStyle().FontStyle,
				new NArgbColor(KnownArgbColorValue.White)));
			document.StyleSheets.AddChild(clickedCounty);

			// Load the map of the USA
			LoadUsaMap();
		}
		private void LoadMap(string fileName, string nameColumn, string textColumn, string toolTipColumn, float mapWidth, float mapHeight)
		{
			document.Layers.RemoveAllChildren();
			document.Width = mapWidth;
			document.Height = mapHeight;

			NEsriMapImporter mapImporter = new NEsriMapImporter();

			// Create the shapefile
			NEsriShapefile shapefile = new NEsriShapefile(Path.Combine(Application.StartupPath, fileName));
			shapefile.NameColumn = nameColumn;
			shapefile.TextColumn = textColumn;
			mapImporter.AddLayer(shapefile);

			// Import the map
			mapImporter.Read();
			if (String.IsNullOrEmpty(toolTipColumn) == false)
			{
				mapImporter.ShapeCreatedListener = new NCustomShapeCreatedListener(toolTipColumn);
			}

			mapImporter.Import(document, document.Bounds);
		}
		private void LoadUsaMap()
		{
			LoadMap(UsaMapFile, "STATE_ABBR", "STATE_ABBR", "STATE_NAME", MapWidth, MapHeight);
		}
		private void LoadStateMap(string abbrStateName)
		{
			string fileName = Path.Combine(StatesFolder, abbrStateName);
			fileName = Path.Combine(fileName, abbrStateName + ".shp");
			LoadMap(fileName, "FIPS", null, "NAME", MapWidth / 2, MapHeight / 2);
		}

		#endregion

		#region Event Handlers

		private void OnNodeMouseDown(NNodeMouseEventArgs args)
		{
			INNode node = args.Node;
			while (node != null && node is NShape == false)
			{
				node = node.ParentNode;
			}

			NShape shape = (NShape)node;
			args.Handled = true;

			if (document.Tag == null)
			{
				if (shape == null)
					return;

				// The user has clicked a state
				document.Tag = shape;
				LoadStateMap(shape.Name);
				document.SizeToContent();
			}
			else
			{
				if (shape == null)
				{
					// Return to the States map
					document.Tag = null;
					LoadUsaMap();
					document.SizeToContent();
				}
				else
				{
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
		
		}

		#endregion

		#region Designer Fields

		private Label label1;
		private Label label2;

		#endregion

		#region Constants

		private const int MapWidth = 1600;
		private const int MapHeight = 1600;

		private const string UsaMapFile = @"..\..\Resources\Maps\usa.shp";
		private const string StatesFolder = @"..\..\Resources\Maps\States";

		#endregion

		#region Nested Types

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