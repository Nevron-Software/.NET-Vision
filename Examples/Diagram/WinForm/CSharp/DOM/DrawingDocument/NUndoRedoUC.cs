using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.UI.WinForm.Controls;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NUndoRedoUC.
	/// </summary>
	public class NUndoRedoUC : NDiagramExampleUC
	{
		#region Constructor

		public NUndoRedoUC(NMainForm form) : base(form)
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
			this.transactionGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.historyTransactionTitleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.commitHistoryTransactionButton = new Nevron.UI.WinForm.Controls.NButton();
			this.rollbackHistoryTransactionButton = new Nevron.UI.WinForm.Controls.NButton();
			this.startTransactionButton = new Nevron.UI.WinForm.Controls.NButton();
			this.recordHistoryCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.addShapeButton = new Nevron.UI.WinForm.Controls.NButton();
			this.undoButton = new Nevron.UI.WinForm.Controls.NButton();
			this.redoButton = new Nevron.UI.WinForm.Controls.NButton();
			this.undoListBox = new Nevron.UI.WinForm.Controls.NListBox();
			this.historyGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.redoListBox = new Nevron.UI.WinForm.Controls.NListBox();
			this.transactionGroup.SuspendLayout();
			this.historyGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// transactionGroup
			// 
			this.transactionGroup.Controls.Add(this.historyTransactionTitleTextBox);
			this.transactionGroup.Controls.Add(this.commitHistoryTransactionButton);
			this.transactionGroup.Controls.Add(this.rollbackHistoryTransactionButton);
			this.transactionGroup.Controls.Add(this.startTransactionButton);
			this.transactionGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.transactionGroup.ImageIndex = 0;
			this.transactionGroup.Location = new System.Drawing.Point(0, 304);
			this.transactionGroup.Name = "transactionGroup";
			this.transactionGroup.Size = new System.Drawing.Size(250, 160);
			this.transactionGroup.TabIndex = 1;
			this.transactionGroup.TabStop = false;
			this.transactionGroup.Text = "History Transactions";
			// 
			// historyTransactionTitleTextBox
			// 
			this.historyTransactionTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.historyTransactionTitleTextBox.ErrorMessage = null;
			this.historyTransactionTitleTextBox.Location = new System.Drawing.Point(8, 56);
			this.historyTransactionTitleTextBox.Name = "historyTransactionTitleTextBox";
			this.historyTransactionTitleTextBox.ReadOnly = true;
			this.historyTransactionTitleTextBox.Size = new System.Drawing.Size(232, 20);
			this.historyTransactionTitleTextBox.TabIndex = 1;
			this.historyTransactionTitleTextBox.Text = "";
			// 
			// commitHistoryTransactionButton
			// 
			this.commitHistoryTransactionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.commitHistoryTransactionButton.Location = new System.Drawing.Point(8, 88);
			this.commitHistoryTransactionButton.Name = "commitHistoryTransactionButton";
			this.commitHistoryTransactionButton.Size = new System.Drawing.Size(232, 23);
			this.commitHistoryTransactionButton.TabIndex = 2;
			this.commitHistoryTransactionButton.Text = "Commit";
			this.commitHistoryTransactionButton.Click += new System.EventHandler(this.commitHistoryTransactionButton_Click);
			// 
			// rollbackHistoryTransactionButton
			// 
			this.rollbackHistoryTransactionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.rollbackHistoryTransactionButton.Location = new System.Drawing.Point(8, 120);
			this.rollbackHistoryTransactionButton.Name = "rollbackHistoryTransactionButton";
			this.rollbackHistoryTransactionButton.Size = new System.Drawing.Size(232, 23);
			this.rollbackHistoryTransactionButton.TabIndex = 3;
			this.rollbackHistoryTransactionButton.Text = "Rollback";
			this.rollbackHistoryTransactionButton.Click += new System.EventHandler(this.rollbackHistoryTransactionButton_Click);
			// 
			// startTransactionButton
			// 
			this.startTransactionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.startTransactionButton.Location = new System.Drawing.Point(8, 24);
			this.startTransactionButton.Name = "startTransactionButton";
			this.startTransactionButton.Size = new System.Drawing.Size(232, 23);
			this.startTransactionButton.TabIndex = 0;
			this.startTransactionButton.Text = "Start history transaction";
			this.startTransactionButton.Click += new System.EventHandler(this.startTransactionButton_Click);
			// 
			// recordHistoryCheckBox
			// 
			this.recordHistoryCheckBox.Checked = true;
			this.recordHistoryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.recordHistoryCheckBox.Location = new System.Drawing.Point(8, 472);
			this.recordHistoryCheckBox.Name = "recordHistoryCheckBox";
			this.recordHistoryCheckBox.Size = new System.Drawing.Size(112, 24);
			this.recordHistoryCheckBox.TabIndex = 2;
			this.recordHistoryCheckBox.Text = "Record history";
			this.recordHistoryCheckBox.CheckedChanged += new System.EventHandler(this.recordHistoryCheckBox_CheckedChanged);
			// 
			// addShapeButton
			// 
			this.addShapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.addShapeButton.Location = new System.Drawing.Point(120, 472);
			this.addShapeButton.Name = "addShapeButton";
			this.addShapeButton.Size = new System.Drawing.Size(122, 23);
			this.addShapeButton.TabIndex = 3;
			this.addShapeButton.Text = "Add random shape";
			this.addShapeButton.Click += new System.EventHandler(this.addShapeButton_Click);
			// 
			// undoButton
			// 
			this.undoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.undoButton.Location = new System.Drawing.Point(8, 120);
			this.undoButton.Name = "undoButton";
			this.undoButton.Size = new System.Drawing.Size(232, 23);
			this.undoButton.TabIndex = 2;
			this.undoButton.Text = "Undo";
			this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
			// 
			// redoButton
			// 
			this.redoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.redoButton.Location = new System.Drawing.Point(8, 256);
			this.redoButton.Name = "redoButton";
			this.redoButton.Size = new System.Drawing.Size(232, 23);
			this.redoButton.TabIndex = 5;
			this.redoButton.Text = "Redo";
			this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
			// 
			// undoListBox
			// 
			this.undoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.undoListBox.Location = new System.Drawing.Point(8, 48);
			this.undoListBox.Name = "undoListBox";
			this.undoListBox.Size = new System.Drawing.Size(232, 66);
			this.undoListBox.TabIndex = 1;
			// 
			// historyGroup
			// 
			this.historyGroup.Controls.Add(this.label2);
			this.historyGroup.Controls.Add(this.label1);
			this.historyGroup.Controls.Add(this.undoListBox);
			this.historyGroup.Controls.Add(this.undoButton);
			this.historyGroup.Controls.Add(this.redoButton);
			this.historyGroup.Controls.Add(this.redoListBox);
			this.historyGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.historyGroup.Enabled = false;
			this.historyGroup.ImageIndex = 0;
			this.historyGroup.Location = new System.Drawing.Point(0, 0);
			this.historyGroup.Name = "historyGroup";
			this.historyGroup.Size = new System.Drawing.Size(250, 304);
			this.historyGroup.TabIndex = 0;
			this.historyGroup.TabStop = false;
			this.historyGroup.Text = "History State";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 160);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Redo list:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Undo list:";
			// 
			// redoListBox
			// 
			this.redoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.redoListBox.Location = new System.Drawing.Point(8, 184);
			this.redoListBox.Name = "redoListBox";
			this.redoListBox.Size = new System.Drawing.Size(232, 66);
			this.redoListBox.TabIndex = 4;
			// 
			// NUndoRedoUC
			// 
			this.Controls.Add(this.addShapeButton);
			this.Controls.Add(this.transactionGroup);
			this.Controls.Add(this.historyGroup);
			this.Controls.Add(this.recordHistoryCheckBox);
			this.Name = "NUndoRedoUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.recordHistoryCheckBox, 0);
			this.Controls.SetChildIndex(this.historyGroup, 0);
			this.Controls.SetChildIndex(this.transactionGroup, 0);
			this.Controls.SetChildIndex(this.addShapeButton, 0);
			this.transactionGroup.ResumeLayout(false);
			this.historyGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init document
			InitDocument();

            // update form controls
			UpdateFormControls();

			// end view init
			view.EndInit();
		}

		protected override void ResetExample()
		{
			base.ResetExample();
			historyTransactionTitleTextBox.Text = string.Empty;
			UpdateFormControls();
		}

		protected override void AttachToEvents()
		{
			document.HistoryService.OperationRecorded += new EventHandler(HistoryService_Changed);
			document.HistoryService.RedoExecuted += new EventHandler(HistoryService_Changed);
			document.HistoryService.UndoExecuted += new EventHandler(HistoryService_Changed);

			base.AttachToEvents();
		}

		protected override void DetachFromEvents()
		{
			document.HistoryService.OperationRecorded -= new EventHandler(HistoryService_Changed);
			document.HistoryService.RedoExecuted -= new EventHandler(HistoryService_Changed);
			document.HistoryService.UndoExecuted -= new EventHandler(HistoryService_Changed);

			base.DetachFromEvents();
		}
 

		#endregion

		#region Implementation

		private void InitDocument()
		{
			CreateGroup(0, 0, Color.Red);
			CreateGroup(0, 2, Color.Blue);
			CreateGroup(1, 1, Color.Green);
		}

		
		private void CreateGroup(int row, int col, Color color)
		{
			string transactionName = color.ToString().Replace("Color [", string.Empty).Replace("]", string.Empty) + " group";
			
			// start transaction
			document.StartTransaction(transactionName);

			// create the shapes in the group
			NPolygonShape polygon = new NPolygonShape(base.GetRandomPoints(base.GetGridCell(row, col), 6));
			NClosedCurveShape curve = new NClosedCurveShape(base.GetRandomPoints(base.GetGridCell(row, col + 1), 6), 1);
			NTextShape text = new NTextShape(transactionName, base.GetGridCell(row, col, 0, 1));

			// create the group
			NGroup group = new NGroup();
			group.Shapes.AddChild(polygon);
			group.Shapes.AddChild(curve);
			group.Shapes.AddChild(text);
			group.UpdateModelBounds();
		
			// apply styles to it
			group.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, color));
			group.Style.StrokeStyle = new NStrokeStyle(1, color);
			group.Style.TextStyle = new NTextStyle(new Font("Arial", 10), color);
			group.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Bottom;

			// add the group to the active layer
			document.ActiveLayer.AddChild(group);

			// commit the transaction
			document.HistoryService.Commit();
		}

		private void AddRandomShape()
		{
			Array values = Enum.GetValues(typeof(BasicShapes));

			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape shape = factory.CreateShape((int)values.GetValue(Random.Next(values.Length)));

			shape.Bounds = new NRectangleF(	base.GetRandomPoint(view.Viewport), 
												base.GetRandomSize(new NSizeF(10, 10), new NSizeF(100, 100)));

			document.ActiveLayer.AddChild(shape);
		}
		

		private void UpdateFormControls()
		{
			PauseEventsHandling();

			if (historyTransactionTitleTextBox.Text == string.Empty)
			{
				commitHistoryTransactionButton.Enabled = false;
				rollbackHistoryTransactionButton.Enabled = false;
				startTransactionButton.Enabled = true;
			}
			else
			{
				commitHistoryTransactionButton.Enabled = true;
				rollbackHistoryTransactionButton.Enabled = true;
				startTransactionButton.Enabled = false;
			}

			undoButton.Enabled = document.HistoryService.CanUndo();
			redoButton.Enabled = document.HistoryService.CanRedo();

			DumpHistoryToListBoxes(undoListBox, redoListBox);
			undoListBox.SelectedIndex = undoListBox.Items.Count - 1;
			redoListBox.SelectedIndex = redoListBox.Items.Count - 1;

			historyGroup.Enabled = document.HistoryService.CanRecord();

			ResumeEventsHandling();
		}

		private void DumpHistoryToListBoxes(NListBox undoList, NListBox redoList)
		{
			undoList.Items.Clear();
			redoList.Items.Clear();

			foreach (NOperation undo in document.HistoryService.UndoStack)
			{
				undoList.Items.Add(undo.Description);
			}

			foreach (NOperation redo in document.HistoryService.RedoStack)
			{
				redoList.Items.Add(redo.Description);
			}
		}


		#endregion

		#region Event Handlers

		private void addShapeButton_Click(object sender, System.EventArgs e)
		{
			AddRandomShape();
			document.RefreshAllViews();
		}

		private void recordHistoryCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (recordHistoryCheckBox.Checked)
			{
				document.HistoryService.Resume();
			}
			else
			{
				document.HistoryService.Pause();
			}

			UpdateFormControls();
		}

		
		private void startTransactionButton_Click(object sender, System.EventArgs e)
		{
			NHistoryTransactionNameForm form = new NHistoryTransactionNameForm();
			if (form.ShowDialog() == DialogResult.Cancel)
				return;

			historyTransactionTitleTextBox.Text = form.TransactionTitle;
			document.HistoryService.StartTransaction(form.TransactionTitle);
			UpdateFormControls();
		}

		private void commitHistoryTransactionButton_Click(object sender, System.EventArgs e)
		{
			document.HistoryService.Commit();
			historyTransactionTitleTextBox.Text = string.Empty;
			UpdateFormControls();
		}

		private void rollbackHistoryTransactionButton_Click(object sender, System.EventArgs e)
		{
			document.HistoryService.Rollback();
			historyTransactionTitleTextBox.Text = string.Empty;
			UpdateFormControls();
			document.RefreshAllViews();
		}

		
		private void undoButton_Click(object sender, System.EventArgs e)
		{
			document.HistoryService.Undo();
		}

		private void redoButton_Click(object sender, System.EventArgs e)
		{
			document.HistoryService.Redo();
		}

		
		private void HistoryService_Changed(object sender, EventArgs e)
		{
			UpdateFormControls();
		}

		
		#endregion

		#region Designer Fields

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NCheckBox recordHistoryCheckBox;
		private Nevron.UI.WinForm.Controls.NTextBox historyTransactionTitleTextBox;
		private Nevron.UI.WinForm.Controls.NButton commitHistoryTransactionButton;
		private Nevron.UI.WinForm.Controls.NButton rollbackHistoryTransactionButton;
		private Nevron.UI.WinForm.Controls.NButton addShapeButton;
		private Nevron.UI.WinForm.Controls.NButton undoButton;
		private Nevron.UI.WinForm.Controls.NButton redoButton;
		private Nevron.UI.WinForm.Controls.NListBox undoListBox;
		private Nevron.UI.WinForm.Controls.NListBox redoListBox;
		private Nevron.UI.WinForm.Controls.NGroupBox historyGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox transactionGroup;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton startTransactionButton;
		#endregion
	}
}
