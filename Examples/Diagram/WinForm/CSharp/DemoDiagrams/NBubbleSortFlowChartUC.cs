using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NBubbleSortFlowChartUC.
	/// </summary>
	public class NBubbleSortFlowChartUC : NDiagramExampleUC
	{
		#region Constructor

		public NBubbleSortFlowChartUC(NMainForm form) : base(form)
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
			this.SuspendLayout();
			// 
			// commonControlsPanel
			// 
			this.commonControlsPanel.Location = new System.Drawing.Point(0, 304);
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(248, 80);
			// 
			// NBubbleSortFlowChartUC
			// 
			this.Name = "NBubbleSortFlowChartUC";
			this.Size = new System.Drawing.Size(248, 384);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

			// begin view init
			view.BeginInit();
			view.GlobalVisibility.ShowPorts = false;
			view.Grid.Visible = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;

			// init document
            document.BeginInit();
			InitDocument();
			document.EndInit();

			// end view init
			view.EndInit();
		}


		#endregion

		#region Implementation

		private void InitDocument()
		{
			// setup default document fill style and shadow style
			NLightingImageFilter lightingFilter = new NLightingImageFilter();
			lightingFilter.SpecularColor = Color.Black;
			lightingFilter.DiffuseColor = Color.White;
			lightingFilter.LightSourceType = LightSourceType.Positional;
			lightingFilter.Position = new NVector3DF(1, 1, 1);
			lightingFilter.BevelDepth = new NLength(8, NGraphicsUnit.Pixel);

			document.Style.FillStyle = new NColorFillStyle(Color.FromArgb(251, 203, 156));
			document.Style.FillStyle.ImageFiltersStyle.Filters.Add(lightingFilter);
			
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur;  
			document.Style.ShadowStyle.Offset = new NPointL(5, 5); 

			document.ShadowsZOrder = ShadowsZOrder.BehindDocument;

			// create title
			NTextShape title = new NTextShape("Bubble Sort", base.GetGridCell(0, 1, 2, 1));
			title.Style.TextStyle = new NTextStyle();
            title.Style.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(68, 90, 108));
			title.Style.TextStyle.ShadowStyle = new NShadowStyle();
			title.Style.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur;
			title.Style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 40, FontStyle.Bold));
			document.ActiveLayer.AddChild(title);

			// begin shape
			NShape shapeBegin = base.CreateFlowChartingShape(FlowChartingShapes.Termination, base.GetGridCell(0, 0), "BEGIN", "");
			
			// get array item shape
			NShape shapeGetItem = base.CreateFlowChartingShape(FlowChartingShapes.Data, base.GetGridCell(1, 0), "Get array item [1...n]", "");
			((NRotatedBoundsLabel)shapeGetItem.Labels.DefaultLabel).Margins = new Nevron.Diagram.NMargins(20, 20, 0, 0);

			// i = 1 shape
			NShape shapeI1 = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(2, 0), "i = 1", "");
			
			// j = n shape
			NShape shapeJEN = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(3, 0), "j = n", "");
			
			// less comparison shape
			NShape shapeLess = base.CreateFlowChartingShape(FlowChartingShapes.Decision, base.GetGridCell(4, 0), "item[i] < item[j - 1]?", "");
			((NRotatedBoundsLabel)shapeLess.Labels.DefaultLabel).Margins = new Nevron.Diagram.NMargins(15, 15, 0, 0);

			// swap shape
			NShape shapeSwap = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(4, 1), "Swap item[i] and item[j-1]", "");

			// j > i + 1? shape
			NShape shapeJQ = base.CreateFlowChartingShape(FlowChartingShapes.Decision, base.GetGridCell(5, 0), "j = (i + 1)?", "");

			// dec j shape
			NShape shapeDecJ = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(5, 1), "j = j - 1", "");
			
			// i > n - 1? shape
			NShape shapeIQ = base.CreateFlowChartingShape(FlowChartingShapes.Decision, base.GetGridCell(6, 0), "i = (n - 1)?", "");

			// inc i shape
			NShape shapeIncI = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(6, 1), "i = i + 1", "");

			// end shape
			NShape shapeEnd = base.CreateFlowChartingShape(FlowChartingShapes.Termination, base.GetGridCell(7, 0), "END", "");

			// connect begin with get array item
			NLineShape connector1 = new NLineShape();
			connector1.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector1);
			connector1.FromShape = shapeBegin;
			connector1.ToShape = shapeGetItem;

			// connect get array item with i = 1
			NLineShape connector2 = new NLineShape();
			connector2.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector2);
			
			connector2.FromShape = shapeGetItem;
			connector2.ToShape = shapeI1;

			// connect i = 1 and j = n
			NLineShape connector3 = new NLineShape();
			connector3.StyleSheetName = NDR.NameConnectorsStyleSheet;
			
			connector3.CreateShapeElements(ShapeElementsMask.Ports);
			connector3.Ports.AddChild(new NLogicalLinePort(connector3.UniqueId, 50)); 
			connector3.Ports.DefaultInwardPortUniqueId = (connector3.Ports.GetChildAt(0) as INDiagramElement).UniqueId; 
			document.ActiveLayer.AddChild(connector3);

			connector3.FromShape = shapeI1;
			connector3.ToShape = shapeJEN;

			// connect j = n and item[i] < item[j-1]?
			NLineShape connector4 = new NLineShape();
			connector4.StyleSheetName = NDR.NameConnectorsStyleSheet;
			
			connector4.CreateShapeElements(ShapeElementsMask.Ports);
			connector4.Ports.AddChild(new NLogicalLinePort(connector4.UniqueId, 50)); 
			connector4.Ports.DefaultInwardPortUniqueId = (connector4.Ports.GetChildAt(0) as INDiagramElement).UniqueId; 
			document.ActiveLayer.AddChild(connector4);

			connector4.FromShape = shapeJEN;
			connector4.ToShape = shapeLess;

			// connect item[i] < item[j-1]? and j = (i + 1)? 
			NLineShape connector5 = new NLineShape();
			connector5.StyleSheetName = NDR.NameConnectorsStyleSheet;
			connector5.Text = "No";
			connector5.Style.TextStyle = new NTextStyle();
			connector5.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top;

			connector5.CreateShapeElements(ShapeElementsMask.Ports);
			connector5.Ports.AddChild(new NLogicalLinePort(connector5.UniqueId, 50)); 
			connector5.Ports.DefaultInwardPortUniqueId = (connector5.Ports.GetChildAt(0) as INDiagramElement).UniqueId;
			document.ActiveLayer.AddChild(connector5);

			connector5.FromShape = shapeLess;
			connector5.ToShape = shapeJQ;

			// connect j = (i + 1)? and i = (n - 1)?
			NLineShape connector6 = new NLineShape();
			connector6.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector6);

			connector6.FromShape = shapeJQ;
			connector6.ToShape = shapeIQ;

			// connect i = (n - 1) and END
			NLineShape connector7 = new NLineShape();
			connector7.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector7);
			connector7.FromShape = shapeIQ;
			connector7.ToShape = shapeEnd;

			// connect item[i] < item[j-1]? and Swap
			NLineShape connector8 = new NLineShape();
			connector8.StyleSheetName = NDR.NameConnectorsStyleSheet;
			connector8.Text = "Yes";
			connector8.Style.TextStyle = new NTextStyle();
			connector8.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Bottom;
			document.ActiveLayer.AddChild(connector8);

			connector8.FromShape = shapeLess;
			connector8.ToShape = shapeSwap;
			
			// connect j = (i + 1)? and j = (j - 1)
			NLineShape connector9 = new NLineShape();
			connector9.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector9);

			connector9.FromShape = shapeJQ;
			connector9.ToShape = shapeDecJ;

			// connect i = (n - 1)? and i = (i + 1)
			NLineShape connector10 = new NLineShape();
			connector10.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector10);

			connector10.FromShape = shapeIQ;
			connector10.ToShape = shapeIncI;

			// connect Swap to No connector
			NStep2Connector connector11 = new NStep2Connector(true);
			connector11.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector11);

			connector11.FromShape = shapeSwap;
			connector11.ToShape = connector5;

			// connect i = i + 1 to connector3
			NStep3Connector connector12 = new NStep3Connector(false, 50, 60, false);
			connector12.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector12);

			connector12.StartPlug.Connect(shapeIncI.Ports.GetChildByName("Right", 0) as NPort);
			connector12.EndPlug.Connect(connector3.Ports.DefaultInwardPort);

			// connect j = j - 1 to connector4
			NStep3Connector connector13 = new NStep3Connector(false, 50, 30, false);
			connector13.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector13);

			connector13.StartPlug.Connect(shapeDecJ.Ports.GetChildByName("Right", 0) as NPort);
			connector13.EndPlug.Connect(connector4.Ports.DefaultInwardPort);
		}

		#endregion

		#region Designer Fields
		
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
