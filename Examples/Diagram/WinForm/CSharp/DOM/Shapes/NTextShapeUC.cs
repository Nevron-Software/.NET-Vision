using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NTextShapeUC.
	/// </summary>
	public class NTextShapeUC : NDiagramExampleUC
	{
		#region Constructor

		public NTextShapeUC(NMainForm form) : base(form)
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
            this.textEditBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.selectedTextGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.textModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.allowDownwardCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.selectedTextGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditBox
            // 
            this.textEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditBox.Location = new System.Drawing.Point(74, 56);
            this.textEditBox.Multiline = true;
            this.textEditBox.Name = "textEditBox";
            this.textEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textEditBox.Size = new System.Drawing.Size(166, 112);
            this.textEditBox.TabIndex = 3;
            this.textEditBox.TextChanged += new System.EventHandler(this.textEdit_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Text:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textStyleButton
            // 
            this.textStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textStyleButton.Location = new System.Drawing.Point(10, 204);
            this.textStyleButton.Name = "textStyleButton";
            this.textStyleButton.Size = new System.Drawing.Size(232, 23);
            this.textStyleButton.TabIndex = 4;
            this.textStyleButton.Text = "Text Style...";
            this.textStyleButton.Click += new System.EventHandler(this.textStyleButton_Click);
            // 
            // selectedTextGroupBox
            // 
            this.selectedTextGroupBox.Controls.Add(this.allowDownwardCheck);
            this.selectedTextGroupBox.Controls.Add(this.textModeCombo);
            this.selectedTextGroupBox.Controls.Add(this.label2);
            this.selectedTextGroupBox.Controls.Add(this.textStyleButton);
            this.selectedTextGroupBox.Controls.Add(this.textEditBox);
            this.selectedTextGroupBox.Controls.Add(this.label1);
            this.selectedTextGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedTextGroupBox.Enabled = false;
            this.selectedTextGroupBox.ImageIndex = 0;
            this.selectedTextGroupBox.Location = new System.Drawing.Point(0, 0);
            this.selectedTextGroupBox.Name = "selectedTextGroupBox";
            this.selectedTextGroupBox.Size = new System.Drawing.Size(250, 241);
            this.selectedTextGroupBox.TabIndex = 0;
            this.selectedTextGroupBox.TabStop = false;
            this.selectedTextGroupBox.Text = "Selected Text Properties";
            // 
            // textModeCombo
            // 
            this.textModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textModeCombo.ListProperties.CheckBoxDataMember = "";
            this.textModeCombo.ListProperties.DataSource = null;
            this.textModeCombo.ListProperties.DisplayMember = "";
            this.textModeCombo.Location = new System.Drawing.Point(74, 24);
            this.textModeCombo.Name = "textModeCombo";
            this.textModeCombo.Size = new System.Drawing.Size(166, 22);
            this.textModeCombo.TabIndex = 1;
            this.textModeCombo.Text = "nComboBox1";
            this.textModeCombo.SelectedIndexChanged += new System.EventHandler(this.textModeCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mode:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // allowDownwardCheck
            // 
            this.allowDownwardCheck.ButtonProperties.BorderOffset = 2;
            this.allowDownwardCheck.Location = new System.Drawing.Point(11, 174);
            this.allowDownwardCheck.Name = "allowDownwardCheck";
            this.allowDownwardCheck.Size = new System.Drawing.Size(229, 24);
            this.allowDownwardCheck.TabIndex = 5;
            this.allowDownwardCheck.Text = "Allow downward orientation";
            this.allowDownwardCheck.CheckedChanged += new System.EventHandler(this.allowDownwardCheck_CheckedChanged);
            // 
            // NTextShapeUC
            // 
            this.Controls.Add(this.selectedTextGroupBox);
            this.Name = "NTextShapeUC";
            this.Size = new System.Drawing.Size(250, 600);
            this.Controls.SetChildIndex(this.selectedTextGroupBox, 0);
            this.selectedTextGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Overrides

		protected override void LoadExample()
		{
			this.DefaultGridCellSize = new NSizeF(200, 100);

			// begin view init
			view.BeginInit();

			// init view
			view.Selection.Mode = DiagramSelectionMode.Single;
			view.Grid.Visible = false;

			// start document initialization
			document.BeginInit();

			CreateWrappedText();
			CreateStretchedText();
			CreateWrappedTextWithBackplane();
			CreateStretchedTextWithBackplane();
			CreateXMLFormattedText();

			// end document initialization
			document.EndInit();

			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}

		#endregion
																		
		#region Implementation

		private void CreateWrappedText()
		{
			// create text
			NTextShape text = new NTextShape("Wrapped text with font: Tahoma and size: 8", base.GetGridCell(0, 0)); 

			text.Style.TextStyle = new NTextStyle(new Font("Tahoma", 8), base.GetPredefinedColor(0));
			text.Mode = BoxTextMode.Wrap;

			// add to active layer
			document.ActiveLayer.AddChild(text);
			document.SmartRefreshAllViews(); 
		}
		private void CreateStretchedText()
		{
			// create text
			NTextShape text = new NTextShape("Stretched text", base.GetGridCell(0, 1)); 

			text.Style.TextStyle = new NTextStyle(new Font("Tahoma", 8), base.GetPredefinedColor(1));
			text.Mode = BoxTextMode.Stretch;

			// add to active layer
			document.ActiveLayer.AddChild(text);
			document.SmartRefreshAllViews(); 
		}
		private void CreateWrappedTextWithBackplane()
		{
			// create text
			NTextShape text = new NTextShape("Wrapped text with backplane", base.GetGridCell(1, 0)); 

			text.Style.TextStyle = new NTextStyle(new Font("Arial", 10), base.GetPredefinedColor(2));
			text.Style.TextStyle.BackplaneStyle.Visible = true;
			text.Style.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			text.Mode = BoxTextMode.Wrap;

			// add to active layer
			document.ActiveLayer.AddChild(text);
			document.SmartRefreshAllViews(); 
		}
		private void CreateStretchedTextWithBackplane()
		{
			// create text
			NTextShape text = new NTextShape("Stretched text with backplane", base.GetGridCell(1, 1)); 

			text.Style.TextStyle = new NTextStyle(new Font("Arial", 10), base.GetPredefinedColor(3));
			text.Style.TextStyle.BackplaneStyle.Visible = true;
			text.Style.TextStyle.BackplaneStyle.Shape = BackplaneShape.SmoothEdgeRectangle;
			text.Mode = BoxTextMode.Stretch;

			// add to active layer
			document.ActiveLayer.AddChild(text);
			document.SmartRefreshAllViews(); 
		}
		private void CreateXMLFormattedText()
		{
			NRectangleF cell = base.GetGridCell(2, 0, 1, 1);

			// create text
            NTextShape text = new NTextShape(
                "<b>XML</b> Formatted Text allows you to <br></br>" + 
                "<font face = 'Tahoma' size = '19'>mix</font>   <font face = 'Impact' size = '22'>fonts</font> <br></br>" + 
                "<font gradient = '0, 0, white, red'>display text with gradiens</font> <br></br>" +
                "<font size = '22' border = '1' bordercolor = 'gray'>display text with borders</font> <br></br>" + 
                "<font shadowoffset = '2, 2' shadowfadelength = '3' shadowtype = 'gaussianblur'>display text with shadows</font> <br></br>" + 
                "display text with <b>bold</b>, <i>italic</i>, <u>underline</u> and <strike>strikeout</strike>",
                cell); 

			text.Style.TextStyle = new NTextStyle(new Font("Arial", 12), base.GetPredefinedColor(4));
			text.Style.TextStyle.TextFormat = TextFormat.XML;

			// add to active layer
			document.ActiveLayer.AddChild(text);
			document.SmartRefreshAllViews(); 
		}
		
		private void InitFormControls()
		{
			PauseEventsHandling();

			selectedTextGroupBox.Enabled = false;
			textEditBox.Text = "";
			textModeCombo.FillFromEnum(typeof(BoxTextMode));
			textModeCombo.SelectedItem = BoxTextMode.Wrap;

			ResumeEventsHandling();
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

		#region Event Handlers

		private void textEdit_TextChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected text shape
			NTextShape text = (view.Selection.AnchorNode as NTextShape);
			if (text == null)
				return;

			// change its text
			text.Text = textEditBox.Text;
			document.SmartRefreshAllViews();
		}
		private void textStyleButton_Click(object sender, System.EventArgs e)
		{
			// get the selected text shape
			NTextShape text = (view.Selection.AnchorNode as NTextShape);
			if (text == null)
				return;

			// show it text style editor
			base.ShowTextStyleEditor(text); 
		}
		private void textModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			if (textModeCombo.SelectedIndex == -1)
				return;
			
			// get the selected text shape
			NTextShape text = (view.Selection.AnchorNode as NTextShape);
			if (text == null)
				return;

			// change its display mode
			text.Mode = (BoxTextMode)textModeCombo.SelectedItem;
			document.SmartRefreshAllViews();
		}
        private void allowDownwardCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            if (textModeCombo.SelectedIndex == -1)
                return;

            // get the selected text shape
            NTextShape text = (view.Selection.AnchorNode as NTextShape);
            if (text == null)
                return;

            // change its allow downward orientation property
            text.AllowDownwardOrientation = allowDownwardCheck.Checked;
            document.SmartRefreshAllViews();
        }

		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			// get the selected text shape
			NTextShape text = (view.Selection.AnchorNode as NTextShape);
			if (text == null)
				return;

			// update the form controls from the shape
			PauseEventsHandling();

			selectedTextGroupBox.Enabled = true;
			textEditBox.Text = text.Text;
			textModeCombo.SelectedItem = text.Mode;
            allowDownwardCheck.Checked = text.AllowDownwardOrientation;

			ResumeEventsHandling();
		}
		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			selectedTextGroupBox.Enabled = false;
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton textStyleButton;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedTextGroupBox;
		private Nevron.UI.WinForm.Controls.NTextBox textEditBox;
		private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NCheckBox allowDownwardCheck;
		private Nevron.UI.WinForm.Controls.NComboBox textModeCombo;

		#endregion
	}
}
