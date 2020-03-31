using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Editors;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NShapeLabelsUC.
	/// </summary>
	public class NShapeLabelsUC : NDiagramExampleUC
	{
		#region Constructor

		public NShapeLabelsUC(NMainForm form) : base(form)
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
            this.labelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.selectedShapeLabelsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boundsLabelsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxTextModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.marginsButton = new Nevron.UI.WinForm.Controls.NButton();
            this.lineLabelsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.percentPositionNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.allowDownwardCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.useLineOrientationCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.labelPropertiesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.labelTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.textStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.visibleCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.allowDownwardCheck2 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.selectedShapeLabelsGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.boundsLabelsGroup.SuspendLayout();
            this.lineLabelsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentPositionNumeric)).BeginInit();
            this.labelPropertiesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelsCombo
            // 
            this.labelsCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelsCombo.ListProperties.CheckBoxDataMember = "";
            this.labelsCombo.ListProperties.DataSource = null;
            this.labelsCombo.ListProperties.DisplayMember = "";
            this.labelsCombo.Location = new System.Drawing.Point(3, 16);
            this.labelsCombo.Name = "labelsCombo";
            this.labelsCombo.Size = new System.Drawing.Size(244, 22);
            this.labelsCombo.TabIndex = 0;
            this.labelsCombo.Text = "nComboBox1";
            this.labelsCombo.SelectedIndexChanged += new System.EventHandler(this.labelsCombo_SelectedIndexChanged);
            // 
            // selectedShapeLabelsGroup
            // 
            this.selectedShapeLabelsGroup.Controls.Add(this.panel1);
            this.selectedShapeLabelsGroup.Controls.Add(this.labelsCombo);
            this.selectedShapeLabelsGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedShapeLabelsGroup.ImageIndex = 0;
            this.selectedShapeLabelsGroup.Location = new System.Drawing.Point(0, 0);
            this.selectedShapeLabelsGroup.Name = "selectedShapeLabelsGroup";
            this.selectedShapeLabelsGroup.Size = new System.Drawing.Size(250, 464);
            this.selectedShapeLabelsGroup.TabIndex = 1;
            this.selectedShapeLabelsGroup.TabStop = false;
            this.selectedShapeLabelsGroup.Text = "Selected shape labels";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.boundsLabelsGroup);
            this.panel1.Controls.Add(this.lineLabelsGroup);
            this.panel1.Controls.Add(this.labelPropertiesGroup);
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 400);
            this.panel1.TabIndex = 1;
            // 
            // boundsLabelsGroup
            // 
            this.boundsLabelsGroup.Controls.Add(this.allowDownwardCheck2);
            this.boundsLabelsGroup.Controls.Add(this.label3);
            this.boundsLabelsGroup.Controls.Add(this.boxTextModeCombo);
            this.boundsLabelsGroup.Controls.Add(this.marginsButton);
            this.boundsLabelsGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.boundsLabelsGroup.ImageIndex = 0;
            this.boundsLabelsGroup.Location = new System.Drawing.Point(0, 296);
            this.boundsLabelsGroup.Name = "boundsLabelsGroup";
            this.boundsLabelsGroup.Size = new System.Drawing.Size(244, 123);
            this.boundsLabelsGroup.TabIndex = 9;
            this.boundsLabelsGroup.TabStop = false;
            this.boundsLabelsGroup.Text = "Bounds/rotated bounds labels properties";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mode:";
            // 
            // boxTextModeCombo
            // 
            this.boxTextModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.boxTextModeCombo.ListProperties.CheckBoxDataMember = "";
            this.boxTextModeCombo.ListProperties.DataSource = null;
            this.boxTextModeCombo.ListProperties.DisplayMember = "";
            this.boxTextModeCombo.Location = new System.Drawing.Point(72, 56);
            this.boxTextModeCombo.Name = "boxTextModeCombo";
            this.boxTextModeCombo.Size = new System.Drawing.Size(160, 21);
            this.boxTextModeCombo.TabIndex = 2;
            this.boxTextModeCombo.SelectedIndexChanged += new System.EventHandler(this.boxTextModeCombo_SelectedIndexChanged);
            // 
            // marginsButton
            // 
            this.marginsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.marginsButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.marginsButton.Location = new System.Drawing.Point(8, 16);
            this.marginsButton.Name = "marginsButton";
            this.marginsButton.Size = new System.Drawing.Size(224, 23);
            this.marginsButton.TabIndex = 1;
            this.marginsButton.Text = "Margins";
            this.marginsButton.Click += new System.EventHandler(this.marginsButton_Click);
            // 
            // lineLabelsGroup
            // 
            this.lineLabelsGroup.Controls.Add(this.percentPositionNumeric);
            this.lineLabelsGroup.Controls.Add(this.label2);
            this.lineLabelsGroup.Controls.Add(this.allowDownwardCheck);
            this.lineLabelsGroup.Controls.Add(this.useLineOrientationCheck);
            this.lineLabelsGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineLabelsGroup.ImageIndex = 0;
            this.lineLabelsGroup.Location = new System.Drawing.Point(0, 176);
            this.lineLabelsGroup.Name = "lineLabelsGroup";
            this.lineLabelsGroup.Size = new System.Drawing.Size(244, 120);
            this.lineLabelsGroup.TabIndex = 10;
            this.lineLabelsGroup.TabStop = false;
            this.lineLabelsGroup.Text = "Logical line label properties";
            // 
            // percentPositionNumeric
            // 
            this.percentPositionNumeric.Location = new System.Drawing.Point(168, 24);
            this.percentPositionNumeric.Name = "percentPositionNumeric";
            this.percentPositionNumeric.Size = new System.Drawing.Size(64, 20);
            this.percentPositionNumeric.TabIndex = 1;
            this.percentPositionNumeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.percentPositionNumeric.ValueChanged += new System.EventHandler(this.percentPositionNumeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Percent position:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // allowDownwardCheck
            // 
            this.allowDownwardCheck.ButtonProperties.BorderOffset = 2;
            this.allowDownwardCheck.Location = new System.Drawing.Point(8, 80);
            this.allowDownwardCheck.Name = "allowDownwardCheck";
            this.allowDownwardCheck.Size = new System.Drawing.Size(168, 24);
            this.allowDownwardCheck.TabIndex = 3;
            this.allowDownwardCheck.Text = "Allow downward orientation";
            this.allowDownwardCheck.CheckedChanged += new System.EventHandler(this.allowDownwardCheck_CheckedChanged);
            // 
            // useLineOrientationCheck
            // 
            this.useLineOrientationCheck.ButtonProperties.BorderOffset = 2;
            this.useLineOrientationCheck.Location = new System.Drawing.Point(8, 56);
            this.useLineOrientationCheck.Name = "useLineOrientationCheck";
            this.useLineOrientationCheck.Size = new System.Drawing.Size(168, 24);
            this.useLineOrientationCheck.TabIndex = 2;
            this.useLineOrientationCheck.Text = "Use line percent orientation";
            this.useLineOrientationCheck.CheckedChanged += new System.EventHandler(this.useLineOrientationCheck_CheckedChanged);
            // 
            // labelPropertiesGroup
            // 
            this.labelPropertiesGroup.Controls.Add(this.labelTextBox);
            this.labelPropertiesGroup.Controls.Add(this.textStyleButton);
            this.labelPropertiesGroup.Controls.Add(this.visibleCheck);
            this.labelPropertiesGroup.Controls.Add(this.label1);
            this.labelPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPropertiesGroup.ImageIndex = 0;
            this.labelPropertiesGroup.Location = new System.Drawing.Point(0, 0);
            this.labelPropertiesGroup.Name = "labelPropertiesGroup";
            this.labelPropertiesGroup.Size = new System.Drawing.Size(244, 176);
            this.labelPropertiesGroup.TabIndex = 8;
            this.labelPropertiesGroup.TabStop = false;
            this.labelPropertiesGroup.Text = "General label properties";
            // 
            // labelTextBox
            // 
            this.labelTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextBox.Location = new System.Drawing.Point(48, 40);
            this.labelTextBox.Multiline = true;
            this.labelTextBox.Name = "labelTextBox";
            this.labelTextBox.Size = new System.Drawing.Size(184, 88);
            this.labelTextBox.TabIndex = 5;
            this.labelTextBox.Text = "textBox1";
            this.labelTextBox.TextChanged += new System.EventHandler(this.labelTextBox_TextChanged);
            // 
            // textStyleButton
            // 
            this.textStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textStyleButton.Location = new System.Drawing.Point(8, 136);
            this.textStyleButton.Name = "textStyleButton";
            this.textStyleButton.Size = new System.Drawing.Size(224, 23);
            this.textStyleButton.TabIndex = 4;
            this.textStyleButton.Text = "Text style...";
            this.textStyleButton.Click += new System.EventHandler(this.textStyleButton_Click);
            // 
            // visibleCheck
            // 
            this.visibleCheck.ButtonProperties.BorderOffset = 2;
            this.visibleCheck.Location = new System.Drawing.Point(8, 16);
            this.visibleCheck.Name = "visibleCheck";
            this.visibleCheck.Size = new System.Drawing.Size(96, 24);
            this.visibleCheck.TabIndex = 3;
            this.visibleCheck.Text = "Visible";
            this.visibleCheck.CheckedChanged += new System.EventHandler(this.visibleCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // allowDownwardCheck2
            // 
            this.allowDownwardCheck2.ButtonProperties.BorderOffset = 2;
            this.allowDownwardCheck2.Location = new System.Drawing.Point(19, 83);
            this.allowDownwardCheck2.Name = "allowDownwardCheck2";
            this.allowDownwardCheck2.Size = new System.Drawing.Size(168, 24);
            this.allowDownwardCheck2.TabIndex = 4;
            this.allowDownwardCheck2.Text = "Allow downward orientation";
            this.allowDownwardCheck2.CheckedChanged += new System.EventHandler(this.allowDownwardCheck2_CheckedChanged);
            // 
            // NShapeLabelsUC
            // 
            this.Controls.Add(this.selectedShapeLabelsGroup);
            this.Name = "NShapeLabelsUC";
            this.Size = new System.Drawing.Size(250, 600);
            this.Controls.SetChildIndex(this.selectedShapeLabelsGroup, 0);
            this.selectedShapeLabelsGroup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.boundsLabelsGroup.ResumeLayout(false);
            this.lineLabelsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.percentPositionNumeric)).EndInit();
            this.labelPropertiesGroup.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			base.DefaultGridCellSize = new NSizeF(200, 100);
			base.DefaultGridOrigin = new NPointF(40, 40);

			// begin view init
			view.BeginInit();

			view.Grid.Visible = false;
			view.GlobalVisibility.ShowPorts = false;

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();
		
			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();

			UpdateControlsState();
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

			boxTextModeCombo.Items.Clear();
			boxTextModeCombo.FillFromEnum(typeof(BoxTextMode));

			ResumeEventsHandling();
		}
		private void InitDocument()
		{
			// create a rectangle shape with a 2 bounds label
			NShape shape = new NRectangleShape(base.GetGridCell(0, 0));
			shape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0xcc, 0, 0));

			shape.Labels.RemoveAllChildren();
			
			NBoundsLabel boundsLabel = new NBoundsLabel("Label 1, Wrapped", shape.UniqueId, new Nevron.Diagram.NMargins(0, 0, 0, 50));
			shape.Labels.AddChild(boundsLabel);
			shape.Labels.DefaultLabelUniqueId = boundsLabel.UniqueId;

			boundsLabel = new NBoundsLabel("Label 2, Stretched", shape.UniqueId, new Nevron.Diagram.NMargins(0, 0, 50, 0));
			boundsLabel.Mode = BoxTextMode.Stretch;
			shape.Labels.AddChild(boundsLabel);

			document.ActiveLayer.AddChild(shape);

			// create a rectangle shape with a 2 rotated bounds labels
			shape = new NRectangleShape(base.GetGridCell(0, 1));
			shape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0, 0, 0xcc));

			shape.Labels.RemoveAllChildren();
			
			NRotatedBoundsLabel rotatedLabel = new NRotatedBoundsLabel("Rotated Label 1, Wrapped", shape.UniqueId, new Nevron.Diagram.NMargins(0, 0, 0, 50));
			shape.Labels.AddChild(rotatedLabel);
			shape.Labels.DefaultLabelUniqueId = rotatedLabel.UniqueId;

			rotatedLabel = new NRotatedBoundsLabel("Rotated Label 2, Stretched", shape.UniqueId, new Nevron.Diagram.NMargins(0, 0, 50, 0));
			rotatedLabel.Mode = BoxTextMode.Stretch;
			shape.Labels.AddChild(rotatedLabel);

			document.ActiveLayer.AddChild(shape);

			// create a polyline shape with two logical line labels
			NRectangleF cell = base.GetGridCell(1, 0, 0, 1); 
			shape = new NPolylineShape(new NPointF[]{cell.Location, cell.RightBottom});

			shape.Labels.RemoveAllChildren();
			
			NLogicalLineLabel lineLabel = new NLogicalLineLabel("Line label - start", shape.UniqueId, 0, true, true);
			shape.Labels.AddChild(lineLabel);
			shape.Labels.DefaultLabelUniqueId = lineLabel.UniqueId;

			// alter the start label text style
			NTextStyle textStyle = document.Style.TextStyle.Clone() as NTextStyle;
			textStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			textStyle.Offset = new NPointL(0, -7);
			NStyle.SetTextStyle(lineLabel, textStyle);
			
			// add the end label
			lineLabel = new NLogicalLineLabel("Line label - end", shape.UniqueId, 100, true, true);
			shape.Labels.AddChild(lineLabel);

			// alter the end label text style
			textStyle = document.Style.TextStyle.Clone() as NTextStyle;
			textStyle.StringFormatStyle.HorzAlign = HorzAlign.Right;
			textStyle.Offset = new NPointL(0, -7);
			NStyle.SetTextStyle(lineLabel, textStyle);

			document.ActiveLayer.AddChild(shape);
		}
		
		private void UpdateControlsState()
		{
			// only single selection is processed
			if (view.Selection.Nodes.Count != 1)
			{
				selectedShapeLabelsGroup.Enabled = false;
				HideLabelControls();
				return;
			}

			// check to see if the selected node is a shape and it has lables
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null || shape.Labels == null)
			{
				selectedShapeLabelsGroup.Enabled = false;
				HideLabelControls();
				return;
			}

			selectedShapeLabelsGroup.Enabled = true;

			// get the default label
			NLabel defaultLabel = shape.Labels.DefaultLabel;

			// fill the labels combo and select the default label
			labelsCombo.Items.Clear();
			foreach (NLabel label in shape.Labels.Children(null))
			{
				labelsCombo.Items.Add(label);
				if (label == defaultLabel)
				{
					labelsCombo.SelectedItem = label;
				}
			}

			// update the label controls from the default label
			if (defaultLabel == null)
			{
				HideLabelControls();
				return;
			}
			
			UpdateLabelControls(defaultLabel);
		}
		private void UpdateLabelControls(NLabel label)
		{
			// update general properties
			labelPropertiesGroup.Visible = true;
			visibleCheck.Checked = label.Visible;
			labelTextBox.Text = label.Text;

			// bounds labels specific
			if (label is NBoundsLabel)
			{
				boundsLabelsGroup.Visible = true;
				boxTextModeCombo.SelectedIndex = (int)(label as NBoundsLabel).Mode;

                if (label is NRotatedBoundsLabel)
                {
                    allowDownwardCheck2.Visible = true;
                    allowDownwardCheck2.Checked = (label as NRotatedBoundsLabel).AllowDownwardOrientation;
                }
                else
                {
                    allowDownwardCheck2.Visible = false;
                }
			}
			else
			{
				boundsLabelsGroup.Visible = false;
			}

			// logical line specific
			if (label is NLogicalLineLabel)
			{
				lineLabelsGroup.Visible = true;
				allowDownwardCheck.Checked = (label as NLogicalLineLabel).AllowDownwardOrientation;
				useLineOrientationCheck.Checked  = (label as NLogicalLineLabel).UseLineOrientation; 
				percentPositionNumeric.Value = (decimal)(label as NLogicalLineLabel).PercentPosition;
			}
			else
			{
				lineLabelsGroup.Visible = false;
			}
		}
		private void HideLabelControls()
		{
			labelPropertiesGroup.Visible = false;
			boundsLabelsGroup.Visible = false;
			lineLabelsGroup.Visible = false;	
		}
		
		#endregion

		#region Event Handlers

		private void labelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// get the selected label
			NLabel label = labelsCombo.SelectedItem as NLabel;
			if (label == null)
			{
				HideLabelControls();
				return;
			}

			// update the label controls
			PauseEventsHandling();
			UpdateLabelControls(label);
			ResumeEventsHandling();
		}
		private void labelTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected label
			NLabel label = labelsCombo.SelectedItem as NLabel;
			if (label == null)
				return;

			// update the label text
			label.Text = labelTextBox.Text;
			document.SmartRefreshAllViews();
		}
		private void visibleCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected label
			NLabel label = labelsCombo.SelectedItem as NLabel;
			if (label == null)
				return;

			// update the label visibility
			label.Visible = visibleCheck.Checked;
			document.SmartRefreshAllViews();
		}
		private void textStyleButton_Click(object sender, System.EventArgs e)
		{
			// get the selected label
			NLabel label = labelsCombo.SelectedItem as NLabel;
			if (label == null)
				return;

			// edit the label text style
			base.ShowTextStyleEditor(label);
		}
		private void percentPositionNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected label
			NLogicalLineLabel label = labelsCombo.SelectedItem as NLogicalLineLabel;
			if (label == null)
				return;

			// change the logical line label percent position
			label.PercentPosition = (float)percentPositionNumeric.Value; 
			document.SmartRefreshAllViews();
		}
		private void useLineOrientationCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected label
			NLogicalLineLabel label = labelsCombo.SelectedItem as NLogicalLineLabel;
			if (label == null)
				return;

			// specify whether the logical line label should follow the line orientation
			label.UseLineOrientation = useLineOrientationCheck.Checked; 
			document.SmartRefreshAllViews();
		}
		private void allowDownwardCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected label
			NLogicalLineLabel label = labelsCombo.SelectedItem as NLogicalLineLabel;
			if (label == null)
				return;

			// specify whether the logical line can have downward orientation
			label.AllowDownwardOrientation = allowDownwardCheck.Checked; 
			document.SmartRefreshAllViews();
		}
        private void allowDownwardCheck2_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            // get the selected label
            NRotatedBoundsLabel label = labelsCombo.SelectedItem as NRotatedBoundsLabel;
            if (label == null)
                return;

            // specify whether the rotated bounds label can have downward orientation
            label.AllowDownwardOrientation = allowDownwardCheck2.Checked;
            document.SmartRefreshAllViews();
        }
		private void marginsButton_Click(object sender, System.EventArgs e)
		{
			// get the selected label
			NBoundsLabel label = labelsCombo.SelectedItem as NBoundsLabel;
			if (label == null)
				return;

			// change the bounds label margins
			Nevron.Diagram.NMargins margins = new Nevron.Diagram.NMargins();
			if (Nevron.Diagram.Editors.NMarginsTypeEditor.Edit(label.Margins, ref margins) == false)
				return;
			
			label.Margins = margins;
			document.SmartRefreshAllViews();
		}
		private void boxTextModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected label
			NBoundsLabel label = labelsCombo.SelectedItem as NBoundsLabel;
			if (label == null)
				return;

			// change the bounds label display mode
			label.Mode = (BoxTextMode)boxTextModeCombo.SelectedIndex; 
			document.SmartRefreshAllViews();
		}

        private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			UpdateControlsState();
			ResumeEventsHandling();
		}
		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			UpdateControlsState();
			ResumeEventsHandling();
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NComboBox labelsCombo;
		private System.Windows.Forms.Panel panel1;
		private Nevron.UI.WinForm.Controls.NGroupBox labelPropertiesGroup;
		private Nevron.UI.WinForm.Controls.NButton textStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox visibleCheck;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NGroupBox boundsLabelsGroup;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox boxTextModeCombo;
		private Nevron.UI.WinForm.Controls.NButton marginsButton;
		private Nevron.UI.WinForm.Controls.NGroupBox lineLabelsGroup;
		private Nevron.UI.WinForm.Controls.NNumericUpDown percentPositionNumeric;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NCheckBox allowDownwardCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox useLineOrientationCheck;
		private Nevron.UI.WinForm.Controls.NTextBox labelTextBox;
        private Nevron.UI.WinForm.Controls.NCheckBox allowDownwardCheck2;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedShapeLabelsGroup;

		#endregion


	}
}