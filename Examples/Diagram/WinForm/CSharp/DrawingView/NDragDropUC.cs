using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Shapes; 
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NDragDropUC.
	/// </summary>
	public class NDragDropUC : NDiagramExampleUC
	{
		#region Constructor

		public NDragDropUC(NMainForm form) : base(form)
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
			this.sourceMoveModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.targetMoveModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.sourceViewPanel = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sourceMoveModeCombo
			// 
			this.sourceMoveModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sourceMoveModeCombo.Location = new System.Drawing.Point(80, 96);
			this.sourceMoveModeCombo.Name = "sourceMoveModeCombo";
			this.sourceMoveModeCombo.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue;
			this.sourceMoveModeCombo.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.sourceMoveModeCombo.Size = new System.Drawing.Size(160, 21);
			this.sourceMoveModeCombo.TabIndex = 3;
			this.sourceMoveModeCombo.SelectedIndexChanged += new System.EventHandler(this.sourceMoveModeCombo_SelectedIndexChanged);
			// 
			// targetMoveModeCombo
			// 
			this.targetMoveModeCombo.Location = new System.Drawing.Point(8, 32);
			this.targetMoveModeCombo.Name = "targetMoveModeCombo";
			this.targetMoveModeCombo.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaOlive;
			this.targetMoveModeCombo.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.targetMoveModeCombo.Size = new System.Drawing.Size(152, 21);
			this.targetMoveModeCombo.TabIndex = 2;
			this.targetMoveModeCombo.SelectedIndexChanged += new System.EventHandler(this.targetMoveModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Green view move mode:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(80, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Blue view move mode:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.targetMoveModeCombo);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.sourceMoveModeCombo);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(248, 128);
			this.panel1.TabIndex = 4;
			// 
			// sourceViewPanel
			// 
			this.sourceViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sourceViewPanel.Location = new System.Drawing.Point(0, 128);
			this.sourceViewPanel.Name = "sourceViewPanel";
			this.sourceViewPanel.Size = new System.Drawing.Size(248, 280);
			this.sourceViewPanel.TabIndex = 5;
			// 
			// NDragDropUC
			// 
			this.Controls.Add(this.sourceViewPanel);
			this.Controls.Add(this.panel1);
			this.Name = "NDragDropUC";
			this.Size = new System.Drawing.Size(248, 408);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.sourceViewPanel, 0);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			commonControlsPanel.SendToBack();

			// create the source view (blue view)
			CreateSourceView();
			
			// begin view init
			view.BeginInit();
            
			view.AllowDrop = true;
			view.GlobalVisibility.ShowPorts = false;

            // init document
			document.BeginInit();
			document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.FromArgb(90, Color.YellowGreen));
			document.EndInit();

			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}

		#endregion

		#region Implementation
		
		private void InitFormControls()
		{
			PauseEventsHandling();

			sourceMoveModeCombo.ListProperties.ColumnOnLeft = false;
			targetMoveModeCombo.ListProperties.ColumnOnLeft = false;

			sourceMoveModeCombo.FillFromEnum(typeof(MoveToolMode));
			targetMoveModeCombo.FillFromEnum(typeof(MoveToolMode));
			
			sourceMoveModeCombo.SelectedIndex = 1;
			targetMoveModeCombo.SelectedIndex = 0;

			ResumeEventsHandling();
		}

		private void CreateSourceView()
		{
			if (sourceView == null)
			{
				// begin view init
				sourceView = new NDrawingView();
				sourceView.BeginInit();

				sourceView.Dock = DockStyle.Fill;
				sourceView.Parent = sourceViewPanel;

				// begin document init
				sourceDocument = new NDrawingDocument();
				sourceDocument.BeginInit();
				sourceDocument.BackgroundStyle.FillStyle = new NColorFillStyle(Color.FromArgb(70, Color.RoyalBlue));

				// attach document to view
				sourceView.Document = sourceDocument;
			}
			else
			{
				// begin view init
				sourceView.BeginInit();

				// begin document init
				sourceDocument.BeginInit();
				sourceDocument.ActiveLayer.RemoveAllChildren();
			}

			sourceView.AllowDrop = true;
			sourceView.HorizontalRuler.Visible = false;
			sourceView.VerticalRuler.Visible = false;
			sourceView.GlobalVisibility.ShowPorts = false;

			string[] toolNames = new string[]{	NDWFR.ToolCreateGuideline, 
												NDWFR.ToolHandle, 
												NDWFR.ToolMove, 
												NDWFR.ToolSelector, 
												NDWFR.ToolContextMenu, 
												NDWFR.ToolKeyboard, 
												NDWFR.ToolInplaceEdit}; 

			sourceView.Controller.Tools.SingleEnableTools(toolNames);

			CreateSourceScene();

			// end document init
			sourceDocument.EndInit();

			// end view init
			sourceView.EndInit();
		}

		private void CreateSourceScene()
		{
			sourceDocument.AutoBoundsMode = AutoBoundsMode.CustomNonConstrained;
			
			NRectangleF cell;
			int row = 0, col = 0;
			int width = (sourceView.Width - 40) / 3;

			NShape shape = null;
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			factory.DefaultSize = new NSizeF(50, 50);

			foreach (BasicShapes basicShape in Enum.GetValues(typeof(BasicShapes)))
			{
				shape = factory.CreateShape((int)basicShape);
				shape.Bounds = GetGridCell(row, col, new NPointF(0, 0), new NSizeF(50, 50), new NSizeF(10, 10));

				sourceDocument.ActiveLayer.AddChild(shape);
				col++;
				
				if (col > 2)
				{
					row++;
					col = 0;
				}
			}

			// Add some content to the table shape
			NTableShape table = (NTableShape)shape;
			table.InitTable(2, 2);
			table.BeginUpdate();
			table.CellMargins = new Nevron.Diagram.NMargins(8);
			table[0, 0].Text = "1";
			table[1, 0].Text = "2";
			table[0, 1].Text = "3";
			table[1, 1].Text = "4";
			table.PortDistributionMode = TablePortDistributionMode.CellBased;
			table.EndUpdate();

			sourceDocument.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;
			sourceDocument.RefreshAllViews();
		}		

		#endregion

		#region Event Handlers

		private void sourceMoveModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NMoveTool moveTool = sourceView.Controller.Tools.GetToolByName(NDWFR.ToolMove) as NMoveTool;
			if (moveTool == null)
				return;

			moveTool.Mode = (MoveToolMode)sourceMoveModeCombo.SelectedItem;
		}

		private void targetMoveModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NMoveTool moveTool = view.Controller.Tools.GetToolByName(NDWFR.ToolMove) as NMoveTool;
			if (moveTool == null)
				return;

			moveTool.Mode = (MoveToolMode)targetMoveModeCombo.SelectedItem;
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private Nevron.UI.WinForm.Controls.NComboBox sourceMoveModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox targetMoveModeCombo;
		private System.Windows.Forms.Panel sourceViewPanel;
		private System.Windows.Forms.Label label2;

		#endregion

		#region Fields

		private NDrawingView sourceView;
		private NDrawingDocument sourceDocument;

		#endregion
	}
}