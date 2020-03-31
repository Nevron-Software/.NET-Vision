using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NAbilitiesProtectionAndPermissionsUC.
	/// </summary>
	public class NAbilitiesProtectionAndPermissionsUC : NDiagramExampleUC
	{
		#region Constructor

		public NAbilitiesProtectionAndPermissionsUC(NMainForm form) : base(form)
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
			this.addShapeButton = new Nevron.UI.WinForm.Controls.NButton();
			this.protectionListBox = new Nevron.UI.WinForm.Controls.NListBox();
			this.allButton = new Nevron.UI.WinForm.Controls.NButton();
			this.protectionGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.noneButton = new Nevron.UI.WinForm.Controls.NButton();
			this.protectionGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// addShapeButton
			// 
			this.addShapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.addShapeButton.Location = new System.Drawing.Point(8, 472);
			this.addShapeButton.Name = "addShapeButton";
			this.addShapeButton.Size = new System.Drawing.Size(232, 23);
			this.addShapeButton.TabIndex = 1;
			this.addShapeButton.Text = "Add random shape";
			this.addShapeButton.Click += new System.EventHandler(this.addShapeButton_Click);
			// 
			// protectionListBox
			// 
			this.protectionListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.protectionListBox.CheckBoxes = true;
			this.protectionListBox.CheckOnClick = true;
			this.protectionListBox.ColumnOnLeft = false;
			this.protectionListBox.Location = new System.Drawing.Point(8, 48);
			this.protectionListBox.Name = "protectionListBox";
			this.protectionListBox.Size = new System.Drawing.Size(234, 406);
			this.protectionListBox.TabIndex = 2;
			this.protectionListBox.CheckedChanged += new Nevron.UI.WinForm.Controls.NListBoxItemCheckedEventHandler(this.protectionListBox_CheckedChanged);
			// 
			// allButton
			// 
			this.allButton.Location = new System.Drawing.Point(8, 16);
			this.allButton.Name = "allButton";
			this.allButton.Size = new System.Drawing.Size(104, 23);
			this.allButton.TabIndex = 0;
			this.allButton.Text = "All";
			this.allButton.Click += new System.EventHandler(this.allButton_Click);
			// 
			// protectionGroupBox
			// 
			this.protectionGroupBox.Controls.Add(this.allButton);
			this.protectionGroupBox.Controls.Add(this.protectionListBox);
			this.protectionGroupBox.Controls.Add(this.noneButton);
			this.protectionGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.protectionGroupBox.Enabled = false;
			this.protectionGroupBox.ImageIndex = 0;
			this.protectionGroupBox.Location = new System.Drawing.Point(0, 0);
			this.protectionGroupBox.Name = "protectionGroupBox";
			this.protectionGroupBox.Size = new System.Drawing.Size(250, 464);
			this.protectionGroupBox.TabIndex = 0;
			this.protectionGroupBox.TabStop = false;
			this.protectionGroupBox.Text = "Selected shape protection";
			// 
			// noneButton
			// 
			this.noneButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.noneButton.Location = new System.Drawing.Point(120, 16);
			this.noneButton.Name = "noneButton";
			this.noneButton.Size = new System.Drawing.Size(122, 23);
			this.noneButton.TabIndex = 1;
			this.noneButton.Text = "None";
			this.noneButton.Click += new System.EventHandler(this.noneButton_Click);
			// 
			// NAbilitiesProtectionAndPermissionsUC
			// 
			this.Controls.Add(this.protectionGroupBox);
			this.Controls.Add(this.addShapeButton);
			this.Name = "NAbilitiesProtectionAndPermissionsUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.addShapeButton, 0);
			this.Controls.SetChildIndex(this.protectionGroupBox, 0);
			this.protectionGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init view
			view.Grid.Visible = false;
			view.GlobalVisibility.ShowPorts = false;

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// end view init
			view.EndInit();

			InitFormControls();
		}

		protected override void AttachToEvents()
		{
			view.EventSinkService.NodeSelected += new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected += new NodeEventHandler(EventSinkService_NodeDeselected);

			base.AttachToEvents();
		}

		protected override void DetachFromEvents()
		{
			view.EventSinkService.NodeSelected -= new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected -= new NodeEventHandler(EventSinkService_NodeDeselected);

			base.DetachFromEvents();
		}
 
		
		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			protectionListBox.Items.Clear();

			foreach (object obj in Enum.GetValues(typeof(AbilitiesMask)))
			{
				AbilitiesMask cur = (AbilitiesMask)obj;

				if (!cur.Equals(AbilitiesMask.All) && !cur.Equals(AbilitiesMask.None))
				{
					protectionListBox.Items.Add(cur);
				}
			}

			ResumeEventsHandling();
		}

		private void InitDocument()
		{
			document.Style.TextStyle = new NTextStyle(new Font("Arial Narrow", 8.75f));
			document.Style.FillStyle = new NColorFillStyle(Color.MintCream);

			int row = 0;
			int col = 0;

			Array values = Enum.GetValues(typeof(AbilitiesMask));

			for (int i = 0; i < values.Length; i++)
			{	
				AbilitiesMask cur = (AbilitiesMask)values.GetValue(i);

				if (!cur.Equals(AbilitiesMask.All) && !cur.Equals(AbilitiesMask.None))
				{
					if (col >= 4)
					{
						col = 0;
						row++;
					}

					if (cur.Equals(AbilitiesMask.Ungroup))
					{
						CreateGroup(row, col, cur);
					}
					else if (cur.Equals(AbilitiesMask.Group) || cur.Equals(AbilitiesMask.Compose))
					{
						CreateTwoRectangles(row, col, cur);
					}
					else if (cur.Equals(AbilitiesMask.Decompose))
					{
						CreateCompositeShape(row, col, cur);
					}
					else if (cur.Equals(AbilitiesMask.ChangeStartPoint) || cur.Equals(AbilitiesMask.ChangeEndPoint))
					{
						CreateLine(row, col, cur);
					}
					else
					{
						CreateRectangle(row, col, cur);
					}

					col++;
				}
			}

			document.SizeToContent();
		}
		
		private void CreateGroup(int row, int col, AbilitiesMask protection)
		{
			// create a group
			NGroup group = new NGroup();
			group.Protection = new NAbilities(protection);
			
			// add two rectangle shapes in it
			group.Shapes.AddChild(new NRectangleShape(new NRectangleF(0, 0, 1, 1)));
			group.Shapes.AddChild(new NRectangleShape(new NRectangleF(2, 2, 1, 1)));
			
			// update the group model bounds to fit the shapes
			group.UpdateModelBounds();

			// transform the group to fit in the specified bounds
			group.Bounds = base.GetGridCell(row, col);

			// create the labels shape element
			group.CreateShapeElements(ShapeElementsMask.Labels);
 
			// create the default label
			NRotatedBoundsLabel label = new NRotatedBoundsLabel("", group.UniqueId, new Nevron.Diagram.NMargins(0));
			group.Labels.AddChild(label);
			group.Labels.DefaultLabelUniqueId = label.UniqueId;

			// assign text to the group
			group.Text = "Protected from: " + protection.ToString();

			// add the group to the active layer
			document.ActiveLayer.AddChild(group);
		}

		private void CreateTwoRectangles(int row, int col, AbilitiesMask protection)
		{
			// create the first rectangle shape
			NRectangleF rect = base.GetGridCell(row, col);
			rect = new NRectangleF(rect.X, rect.Y, rect.Width / 2, rect.Height / 2);
			
			NRectangleShape rect1 = new NRectangleShape(rect);
			rect1.Protection = new NAbilities(protection);
			rect1.Text = "Protected from: " + protection.ToString();
			document.ActiveLayer.AddChild(rect1);

			// create the second rectangle shape
			rect = base.GetGridCell(row, col);
			rect = new NRectangleF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2, rect.Width / 2, rect.Height / 2);

			NRectangleShape rect2 = new NRectangleShape(rect);
			rect2.Protection = new NAbilities(protection);
			rect2.Text = "Protected from: " + protection.ToString();
			document.ActiveLayer.AddChild(rect2);
		}

		private void CreateRectangle(int row, int col, AbilitiesMask protection)
		{
			// create a rectangle 
			NRectangleShape rect = new NRectangleShape(base.GetGridCell(row, col));
			
			rect.Protection = new NAbilities(protection);
			rect.Text = "Protected from: " + protection.ToString();
			
			document.ActiveLayer.AddChild(rect);
		}

		private void CreateLine(int row, int col, AbilitiesMask protection)
		{
			// create a line
			NRectangleF rect = base.GetGridCell(row, col);
			NLineShape line = new NLineShape(rect.X, rect.Y, rect.Right, rect.Bottom);
			
			line.Protection = new NAbilities(protection);
			line.Text = "Protected from: " + protection.ToString();
			
			document.ActiveLayer.AddChild(line);
		}
		
		private void CreateCompositeShape(int row, int col, AbilitiesMask protection)
		{
			// create a composite shape 
			NCompositeShape shape = new NCompositeShape();

			shape.Protection = new NAbilities(protection);
			shape.Text = "Protected from: " + protection.ToString();
			
			shape.Primitives.AddChild(new NRectanglePath(new NRectangleF(0, 0, 1, 1)));
			shape.Primitives.AddChild(new NRectanglePath(new NRectangleF(2, 2, 1, 1)));

			shape.UpdateModelBounds();
			shape.Bounds = base.GetGridCell(row, col);

			document.ActiveLayer.AddChild(shape);
		}
		
		private void AddRandomShape()
		{
			Array values = Enum.GetValues(typeof(BasicShapes));
			
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape shape = factory.CreateShape((int)values.GetValue(Random.Next(values.Length)));
			
			NSizeF size = new NSizeF(Random.Next(10) + 30, Random.Next(10) + 30);
			shape.Bounds = new NRectangleF(base.GetRandomPoint(view.Viewport), size);
			shape.Style.FillStyle = new NColorFillStyle(Color.GreenYellow);

			document.ActiveLayer.AddChild(shape);			
		}
		
		private void UpdateProtectionListBox()
		{
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
			{
				protectionGroupBox.Enabled = false;
				return;
			}
			
			protectionGroupBox.Enabled = true;
			
			for (int i = 0; i < protectionListBox.Items.Count; i++)
			{
				NListBoxItem item = protectionListBox.Items[i];
				item.Checked = shape.Protection.Contains((AbilitiesMask)item.Tag);
			}
		}

		
		#endregion

		#region Event Handlers

		private void protectionListBox_CheckedChanged(object sender, Nevron.UI.WinForm.Controls.NListBoxItemCheckEventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			PauseEventsHandling();
			
			for (int i = 0; i < protectionListBox.Items.Count; i++)
			{
				NListBoxItem item = protectionListBox.Items[i];

				NAbilities protection = shape.Protection;
				if (item.Checked)
				{
					protection.Mask = protection.Mask | (AbilitiesMask)item.Tag;
				}
				else
				{
					protection.Mask = protection.Mask & ~(AbilitiesMask)item.Tag;
				}
				shape.Protection = protection;
			}

			document.SmartRefreshAllViews();
			ResumeEventsHandling();
		}

		private void allButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			PauseEventsHandling();
			
			shape.Protection = new NAbilities(AbilitiesMask.All);
			UpdateProtectionListBox();

			document.SmartRefreshAllViews();
			ResumeEventsHandling();
		}

		private void noneButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			PauseEventsHandling();
			
			shape.Protection = new NAbilities(AbilitiesMask.None);
			UpdateProtectionListBox();

			document.SmartRefreshAllViews();
			ResumeEventsHandling();
		}

		private void addShapeButton_Click(object sender, System.EventArgs e)
		{
			AddRandomShape();
			document.SmartRefreshAllViews();
		}
		
		
		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;
			
			PauseEventsHandling();
			UpdateProtectionListBox();
			ResumeEventsHandling();
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;
			
			PauseEventsHandling();
			UpdateProtectionListBox();
			ResumeEventsHandling();
		}

		
		#endregion

		#region Designer Fields

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton addShapeButton;
		private Nevron.UI.WinForm.Controls.NGroupBox protectionGroupBox;
		private Nevron.UI.WinForm.Controls.NButton allButton;
		private Nevron.UI.WinForm.Controls.NButton noneButton;
		private Nevron.UI.WinForm.Controls.NListBox protectionListBox;

		#endregion
	}
}