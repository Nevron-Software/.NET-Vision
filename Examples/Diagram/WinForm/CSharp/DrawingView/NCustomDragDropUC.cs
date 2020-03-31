using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.Reflection;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Diagram.Filters;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NCustomDragDropUC.
	/// </summary>
	public class NCustomDragDropUC : NDiagramExampleUC
	{
		#region Constructor

		public NCustomDragDropUC(NMainForm form) : base(form)
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
			this.treeView = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// treeView
			// 
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.ImageIndex = -1;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = -1;
			this.treeView.Size = new System.Drawing.Size(240, 496);
			this.treeView.TabIndex = 1;
			this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
			// 
			// NCustomDragDropUC
			// 
			this.Controls.Add(this.treeView);
			this.Name = "NCustomDragDropUC";
			this.Size = new System.Drawing.Size(240, 576);
			this.Controls.SetChildIndex(this.treeView, 0);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			view.DocumentPadding = new Nevron.Diagram.NMargins(20);
			view.Grid.Visible = false;

			// replace the default drag drop target tool with your own one
			// to extend the drop capabilities of the view
			NTool tool = view.Controller.Tools.GetToolByName(NDWFR.ToolDragDropTarget);
			int index = view.Controller.Tools.IndexOf(tool);
			view.Controller.Tools.Remove(tool);

			tool = new NMyDragDropTargetTool();
			tool.Enabled = true;
			view.Controller.Tools.Insert(index, tool);

			// init document
			document.BeginInit();

			// create and add your own data object adaptor
			// to extend the default set of supported data object formats
			document.DataObjectAdaptors.Add(new NMyDataObjectAdaptor()); 

			// create a simple group for demonstration
			NGroup group = new NGroup();

			group.Shapes.AddChild(new NRectangleShape(100, 100, 200, 200));
			group.CreateShapeElements(ShapeElementsMask.Labels);

			NRotatedBoundsLabel label = new NRotatedBoundsLabel("Drop items from the tree view in me", group.UniqueId, new Nevron.Diagram.NMargins(0));
			group.Labels.AddChild(label);
			group.Labels.DefaultLabelUniqueId = label.UniqueId;

			group.Text = "Drop items from the tree view in me";
			group.UpdateModelBounds();
			
			document.ActiveLayer.AddChild(group);
			
			document.EndInit();

			// init form controls
			InitFormControls();

			// end view init
			view.EndInit(); 
		}

		protected override void ResetExample()
		{
			view.Reset();
			base.ResetExample();
		}


		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			// string items
			TreeNode stringItems = new TreeNode("String items");

			TreeNode string1 = new TreeNode("Nevron Diagram for .NET");
			string1.Tag = "Dragged and dropped text";
			stringItems.Nodes.Add(string1);

			TreeNode string2 = new TreeNode("Text2");
			string1.Tag = "Nevron Diagram for .NET";
			stringItems.Nodes.Add(string1);

			treeView.Nodes.Add(stringItems);

			// image items
			TreeNode imageItems = new TreeNode("Image items");

			TreeNode image1 = new TreeNode("Man");
			image1.Tag = NResourceHelper.BitmapFromResource(GetType(), "man7.jpg", "Nevron.Examples.Diagram.WinForm.Resources");
			imageItems.Nodes.Add(image1);

			TreeNode image2 = new TreeNode("Woman");
			image2.Tag = NResourceHelper.BitmapFromResource(GetType(), "woman1.jpg", "Nevron.Examples.Diagram.WinForm.Resources");
			imageItems.Nodes.Add(image2);

			treeView.Nodes.Add(imageItems);

            // shape items
			TreeNode shapeItems = new TreeNode("Shape items");

			TreeNode shape1 = new TreeNode("Rectangle");
			shape1.Tag = new NMyDataObject("Rectangle", new NSizeF(20, 30));
			shapeItems.Nodes.Add(shape1);

			TreeNode shape2 = new TreeNode("Ellipse");
			shape2.Tag = new NMyDataObject("Ellipse", new NSizeF(30, 20));
			shapeItems.Nodes.Add(shape2);

			treeView.Nodes.Add(shapeItems);

			ResumeEventsHandling();
		}

		#endregion

		#region Event Handlers

		private void treeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			TreeNode node = (TreeNode)e.Item;
			if (node == null || node.Tag == null)
				return;

			// create a data object
			DataObject data;
			if (node.Tag is String)
			{
				data = new DataObject(DataFormats.Text, node.Tag);
			}
			else if (node.Tag is Bitmap)
			{
				data = new DataObject(DataFormats.Bitmap, node.Tag);
			}
			else if (node.Tag is NMyDataObject)
			{
				data = new DataObject("My Custom Format", node.Tag);
			}
			else
			{
				return;
			}

			treeView.DoDragDrop(data, DragDropEffects.Copy);
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TreeView treeView;

		#endregion

		#region Nested Types

		/// <summary>
		/// The NMyDataObject class represents custom data object which is transferred by drag and drop
		/// </summary>
		[Serializable]
		public class NMyDataObject
		{
			public NMyDataObject(string shapeType, NSizeF shapeSize)
			{
				this.shapeType = shapeType;
				this.shapeSize = shapeSize;
			}
			public string shapeType;
			public NSizeF shapeSize;
		}
		/// <summary>
		/// The NMyDataObjectAdaptor is used to adapt the bitmap and custom data objects formats
		/// </summary>
		[Serializable]
		public class NMyDataObjectAdaptor : NDataObjectAdaptor
		{
			public NMyDataObjectAdaptor()
			{
			}

			public NDrawingDocument Document
			{
				get
				{
					return this.m_Document;
				}
			}

			public override void UpdateReferences(INReferenceProvider provider)
			{
				if (provider != null)
				{
					m_Document = (provider.ProvideReference(typeof(NDrawingDocument)) as NDrawingDocument); 
				}
				else
				{
					m_Document = null;
				}

				base.UpdateReferences(provider);
			}
			public override bool CanAdapt(IDataObject dataObject)
			{
				if (dataObject == null)
					throw new ArgumentNullException("dataObject"); 

				if (dataObject.GetDataPresent(DataFormats.Bitmap))
					return true;

				if (dataObject.GetDataPresent("My Custom Format"))
					return true;

				return false;
			}
			public override object Adapt(IDataObject dataObject)
			{
				if (CanAdapt(dataObject) == false)
					return null;

				// adapt bitmap
				if (dataObject.GetDataPresent(DataFormats.Bitmap))
				{
					Bitmap bmp = (dataObject.GetData(DataFormats.Bitmap) as Bitmap);
					if (bmp == null)
						return null;

					return AdaptBitmap(bmp);
				}

				// adapt my custom format
				if (dataObject.GetDataPresent("My Custom Format"))
				{
					NMyDataObject myDataObject = (dataObject.GetData("My Custom Format") as NMyDataObject);
					if (myDataObject == null)
						return null;

					return AdaptMyCustomFormat(myDataObject); 
				}

				return null;
			}

			protected virtual NDrawingDataObject AdaptBitmap(Bitmap bmp)
			{
				if (bmp == null)
					throw new ArgumentNullException("bmp"); 

				// create a rectangle shape with the proper dimensions
				// and fill it with the bitmap
				NRectangleShape shape = new NRectangleShape(0, 0, bmp.Width, bmp.Height);
				shape.Style.FillStyle = new NImageFillStyle(bmp);

				// create a drawing data object, which encapsulates the shape
				NDrawingDataObject ddo = new NDrawingDataObject(null, new INDiagramElement[]{shape});
				return ddo;
			}
			protected virtual NDrawingDataObject AdaptMyCustomFormat(NMyDataObject myDataObject)
			{
				if (myDataObject == null)
					throw new ArgumentNullException("myDataObject"); 

				// create the respective shape with the specified size
				NShape shape;
				if (myDataObject.shapeType == "Rectangle")
				{
					shape = new NRectangleShape(new NPointF(0, 0), myDataObject.shapeSize);
				}
				else if (myDataObject.shapeType == "Ellipse")
				{
					shape = new NEllipseShape(new NPointF(0, 0), myDataObject.shapeSize);
				}
				else 
				{
					return null;
				}
                
				// create a drawing data object, which encapsulates the shape
				NDrawingDataObject ddo = new NDrawingDataObject(null, new INDiagramElement[]{shape});
				return ddo;
			}

			[NonSerialized][NReferenceField] 
			internal NDrawingDocument m_Document;
		}
		/// <summary>
		/// The NMyDragDropTargetTool class represents a tool, which drops shapes in the group below the mouse pointer.
		/// Otherwise it uses the default implementation which drops the shape in the active layer.
		/// </summary>
		[Serializable]
		public class NMyDragDropTargetTool : NDragDropTargetTool
		{
			#region Constructors

			/// <summary>
			/// Default constructor
			/// </summary>
			public NMyDragDropTargetTool()
			{
			}


			#endregion

			#region Interface implementations

			#region INDragDropEventProcessor

			/// <summary>
			/// Processes the drag drop event 
			/// </summary>
			/// <remarks>
			/// Overriden to the drag drop data object in the document active layer
			/// </remarks>
			/// <param name="e"></param>
			/// <returns>true if the event was processed, otherwise false</returns> 
			public override bool ProcessDragDrop(DragEventArgs e)
			{
                // check whether a group is hit, and if not use base implementation
                // which adds shapes to the active layer
				NPointF mouseInDevice = View.GetMousePositionInDevice();
				NGroup group = View.LastActiveDocumentContentHit(mouseInDevice, -1, NFilters.TypeNGroup) as NGroup;

				if (group == null)
					return base.ProcessDragDrop(e);

                // a group was hit - check desired effect
				if (e.Effect != DragDropEffects.Copy &&	e.Effect != DragDropEffects.Move)
					return false;

                // need to manually instruct that the move has ended
                EndMove(false);

                // make a custom transaction, which simply modifies the group text
                // this code can be extended to perform group specific tasks
				Document.StartTransaction("Drop elements in group");

				try
				{
					group.Text += "\n data in: " + e.Data.GetFormats()[0] + " format dropped";
					View.Focus();
				}
				catch (Exception ex)
				{
					Trace.WriteLine("Failed to drop. Exception was: " + ex.Message);
					Document.Rollback();
					return false;
				}

				Document.Commit();
				Document.SmartRefreshAllViews();

				return true;
			}

			#endregion

			#endregion
		}

		#endregion
	}
}