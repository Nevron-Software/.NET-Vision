using System;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Templates;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NTipOverTreeLayoutUC.
	/// </summary>
	public partial class NTipOverTreeLayoutUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized)
				return;

			// Init the diagram control
			NThinDiagramControl1.StateId = "Diagram1";
			NThinDiagramControl1.CustomRequestCallback = new CustomRequestCallback();

			// Init the view
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

			// Init the document
			NDrawingDocument document = NThinDiagramControl1.Document;
			document.BeginInit();
			InitDocument(document);
			document.EndInit();
		}

        #region Implementation

		private void InitDocument(NDrawingDocument document)
		{
            // Remove the standard frame
            document.BackgroundStyle.FrameStyle.Visible = false;

            // Adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            // Set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet styleSheet = new NStyleSheet("orange");
            styleSheet.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
            styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.StyleSheets.AddChild(styleSheet);

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

            // Adjust the text properties
            document.Style.TextStyle.FontStyle = new NFontStyle("arial", 13f);

            // Create the predefined org chart
			DiagramRenderer renderer = new DiagramRenderer();
			renderer.CreatePredefinedOrgChart(document);

			// Apply the layout
			renderer.ApplyLayout(document, null);

			// Resize document to fit all shapes
			document.SizeToContent();
		}

        #endregion

		#region Nested Types

		[Serializable]
		private class CustomRequestCallback : INCustomRequestCallback
		{
			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NDrawingDocument document = diagramControl.Document;

				NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
				Dictionary<string, string> settings = helper.ParseSettings(argument);

				DiagramRenderer renderer = new DiagramRenderer();
				switch (settings["command"])
				{
					case "PredefinedOrgChart":
						renderer.CreatePredefinedOrgChart(document);
						break;
					case "RandomTree5ColShapes":
						renderer.CreateTree(document, 5);
						break;
					case "RandomTree7ColShapes":
						renderer.CreateTree(document, 7);
						break;
				}

				// Layout the diagram
				renderer.ApplyLayout(document, settings);

				// Resize document to fit all shapes
				document.SizeToContent();

				// Update the view
				diagramControl.UpdateView();
			}
		}

		private class DiagramRenderer
		{
			public void CreatePredefinedOrgChart(NDrawingDocument document)
			{
				// Clear the document
				document.ActiveLayer.RemoveAllChildren();

				// We will be using basic shapes with default size of 120, 60
				NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
				basicShapesFactory.DefaultSize = new NSizeF(120, 60);

				// Create the president
				NShape president = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				president.Text = "President";
				document.ActiveLayer.AddChild(president);

				// Create the VPs. 
				// NOTE: The child nodes of the VPs are layed out in cols
				NShape vpMarketing = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				vpMarketing.Text = "VP Marketing";
				document.ActiveLayer.AddChild(vpMarketing);

				NShape vpSales = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				vpSales.Text = "VP Sales";
				document.ActiveLayer.AddChild(vpSales);

				NShape vpProduction = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				vpProduction.Text = "VP Production";
				document.ActiveLayer.AddChild(vpProduction);

				// Connect president with VP
				NRoutableConnector connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = president;
				connector.ToShape = vpMarketing;

				connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = president;
				connector.ToShape = vpSales;

				connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = president;
				connector.ToShape = vpProduction;

				// Create the marketing managers
				NShape marketingManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				marketingManager1.Text = "Manager1";
				document.ActiveLayer.AddChild(marketingManager1);

				NShape marketingManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				marketingManager2.Text = "Manager2";
				document.ActiveLayer.AddChild(marketingManager2);

				// Connect the marketing manager with the marketing VP
				connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = vpMarketing;
				connector.ToShape = marketingManager1;

				connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = vpMarketing;
				connector.ToShape = marketingManager2;

				// Create the sales managers
				NShape salesManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				salesManager1.Text = "Manager1";
				document.ActiveLayer.AddChild(salesManager1);

				NShape salesManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				salesManager2.Text = "Manager2";
				document.ActiveLayer.AddChild(salesManager2);

				// Connect the sales manager with the sales VP
				connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = vpSales;
				connector.ToShape = salesManager1;

				connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = vpSales;
				connector.ToShape = salesManager2;

				// Create the production managers
				NShape productionManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				productionManager1.Text = "Manager1";
				document.ActiveLayer.AddChild(productionManager1);

				NShape productionManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
				productionManager2.Text = "Manager2";
				document.ActiveLayer.AddChild(productionManager2);

				// Connect the production manager with the production VP
				connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = vpProduction;
				connector.ToShape = productionManager1;

				connector = new NRoutableConnector();
				document.ActiveLayer.AddChild(connector);
				connector.FromShape = vpProduction;
				connector.ToShape = productionManager2;
			}
			public void CreateTree(NDrawingDocument document, int maxShapes)
			{
				// clear the document
				document.ActiveLayer.RemoveAllChildren();

				// create a tree
				NGenericTreeTemplate tree = new NGenericTreeTemplate();
				tree.Balanced = false;
				tree.Levels = 6;
				tree.BranchNodes = 3;
				tree.HorizontalSpacing = 10;
				tree.VerticalSpacing = 10;
				tree.VerticesSize = new NSizeF(50, 50);
				tree.VertexSizeDeviation = 0;
				tree.EdgesStyleSheetName = "edges";
				tree.Create(document);

				// make the subtrees of maxShapes random shapes vertically arranged
				NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);
				Random rnd = new Random();
				List<int> usedNumbers = new List<int>();
				int i, index;

				for (i = 0; i < maxShapes; i++)
				{
					do
					{
						index = rnd.Next(shapes.Count);
					}
					while (usedNumbers.Contains(index));

					usedNumbers.Add(index);
					NShape shape = (NShape)shapes[index];
					shape.StyleSheetName = "orange";
					shape.LayoutData.TipOverChildrenPlacement = TipOverChildrenPlacement.ColRight;
				}
			}
			public void ApplyLayout(NDrawingDocument document, Dictionary<string, string> settings)
			{
				// Create the layout
				NTipOverTreeLayout layout = new NTipOverTreeLayout();

				// Configure the layout
				if (settings != null)
				{
					NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
					helper.ConfigureLayout(layout, settings);
				}

				// Get the shapes to layout
				NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

				// Layout the shapes
				layout.Layout(shapes, new NDrawingLayoutContext(document));
			}
		}

		#endregion
	}
}