using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.Templates;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NStepAndArrowConnectorsUC.
	/// </summary>
	public class NStepAndArrowConnectorsUC : NDiagramExampleUC
	{
		#region Constructor

		public NStepAndArrowConnectorsUC(NMainForm form) : base(form)
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
			this.hvConnectorPropertiesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.step3ConnectorPropertiesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.offsetTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.percentTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.offsetRadio = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.percentRadio = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.firstVerticalCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.arrowConnectorPropertiesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.arrowConnectorTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.commonConnectorOperationsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.reflexButton = new Nevron.UI.WinForm.Controls.NButton();
			this.reverseButton = new Nevron.UI.WinForm.Controls.NButton();
			this.hvConnectorPropertiesGroup.SuspendLayout();
			this.step3ConnectorPropertiesGroup.SuspendLayout();
			this.arrowConnectorPropertiesGroup.SuspendLayout();
			this.commonConnectorOperationsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// hvConnectorPropertiesGroup
			// 
			this.hvConnectorPropertiesGroup.Controls.Add(this.step3ConnectorPropertiesGroup);
			this.hvConnectorPropertiesGroup.Controls.Add(this.firstVerticalCheck);
			this.hvConnectorPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.hvConnectorPropertiesGroup.ImageIndex = 0;
			this.hvConnectorPropertiesGroup.Location = new System.Drawing.Point(0, 0);
			this.hvConnectorPropertiesGroup.Name = "hvConnectorPropertiesGroup";
			this.hvConnectorPropertiesGroup.Size = new System.Drawing.Size(248, 136);
			this.hvConnectorPropertiesGroup.TabIndex = 0;
			this.hvConnectorPropertiesGroup.TabStop = false;
			this.hvConnectorPropertiesGroup.Text = "Selected step connector properties";
			// 
			// step3ConnectorPropertiesGroup
			// 
			this.step3ConnectorPropertiesGroup.Controls.Add(this.offsetTextBox);
			this.step3ConnectorPropertiesGroup.Controls.Add(this.percentTextBox);
			this.step3ConnectorPropertiesGroup.Controls.Add(this.offsetRadio);
			this.step3ConnectorPropertiesGroup.Controls.Add(this.percentRadio);
			this.step3ConnectorPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.step3ConnectorPropertiesGroup.ImageIndex = 0;
			this.step3ConnectorPropertiesGroup.Location = new System.Drawing.Point(3, 53);
			this.step3ConnectorPropertiesGroup.Name = "step3ConnectorPropertiesGroup";
			this.step3ConnectorPropertiesGroup.Size = new System.Drawing.Size(242, 80);
			this.step3ConnectorPropertiesGroup.TabIndex = 1;
			this.step3ConnectorPropertiesGroup.TabStop = false;
			this.step3ConnectorPropertiesGroup.Text = "Step 3 connector properties";
			// 
			// offsetTextBox
			// 
			this.offsetTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.offsetTextBox.ErrorMessage = null;
			this.offsetTextBox.Location = new System.Drawing.Point(80, 42);
			this.offsetTextBox.Name = "offsetTextBox";
			this.offsetTextBox.Size = new System.Drawing.Size(152, 20);
			this.offsetTextBox.TabIndex = 3;
			this.offsetTextBox.Text = "textBox2";
			this.offsetTextBox.TextChanged += new System.EventHandler(this.offsetTextBox_TextChanged);
			// 
			// percentTextBox
			// 
			this.percentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.percentTextBox.ErrorMessage = null;
			this.percentTextBox.Location = new System.Drawing.Point(80, 18);
			this.percentTextBox.Name = "percentTextBox";
			this.percentTextBox.Size = new System.Drawing.Size(152, 20);
			this.percentTextBox.TabIndex = 1;
			this.percentTextBox.Text = "textBox1";
			this.percentTextBox.TextChanged += new System.EventHandler(this.percentTextBox_TextChanged);
			// 
			// offsetRadio
			// 
			this.offsetRadio.Location = new System.Drawing.Point(8, 40);
			this.offsetRadio.Name = "offsetRadio";
			this.offsetRadio.Size = new System.Drawing.Size(64, 24);
			this.offsetRadio.TabIndex = 2;
			this.offsetRadio.Text = "Offset";
			this.offsetRadio.CheckedChanged += new System.EventHandler(this.offsetRadio_CheckedChanged);
			// 
			// percentRadio
			// 
			this.percentRadio.Location = new System.Drawing.Point(8, 16);
			this.percentRadio.Name = "percentRadio";
			this.percentRadio.Size = new System.Drawing.Size(64, 24);
			this.percentRadio.TabIndex = 0;
			this.percentRadio.Text = "Percent";
			this.percentRadio.CheckedChanged += new System.EventHandler(this.percentRadio_CheckedChanged);
			// 
			// firstVerticalCheck
			// 
			this.firstVerticalCheck.Location = new System.Drawing.Point(8, 24);
			this.firstVerticalCheck.Name = "firstVerticalCheck";
			this.firstVerticalCheck.Size = new System.Drawing.Size(144, 24);
			this.firstVerticalCheck.TabIndex = 0;
			this.firstVerticalCheck.Text = "First step vertical";
			this.firstVerticalCheck.CheckedChanged += new System.EventHandler(this.firstVerticalCheck_CheckedChanged);
			// 
			// arrowConnectorPropertiesGroup
			// 
			this.arrowConnectorPropertiesGroup.Controls.Add(this.arrowConnectorTypeCombo);
			this.arrowConnectorPropertiesGroup.Controls.Add(this.label1);
			this.arrowConnectorPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.arrowConnectorPropertiesGroup.ImageIndex = 0;
			this.arrowConnectorPropertiesGroup.Location = new System.Drawing.Point(0, 136);
			this.arrowConnectorPropertiesGroup.Name = "arrowConnectorPropertiesGroup";
			this.arrowConnectorPropertiesGroup.Size = new System.Drawing.Size(248, 64);
			this.arrowConnectorPropertiesGroup.TabIndex = 1;
			this.arrowConnectorPropertiesGroup.TabStop = false;
			this.arrowConnectorPropertiesGroup.Text = "Selected Arrow connector properties";
			// 
			// arrowConnectorTypeCombo
			// 
			this.arrowConnectorTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.arrowConnectorTypeCombo.Location = new System.Drawing.Point(80, 24);
			this.arrowConnectorTypeCombo.Name = "arrowConnectorTypeCombo";
			this.arrowConnectorTypeCombo.Size = new System.Drawing.Size(152, 21);
			this.arrowConnectorTypeCombo.TabIndex = 1;
			this.arrowConnectorTypeCombo.Text = "comboBox1";
			this.arrowConnectorTypeCombo.SelectedIndexChanged += new System.EventHandler(this.arrowConnectorTypeCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type:";
			// 
			// commonConnectorOperationsGroup
			// 
			this.commonConnectorOperationsGroup.Controls.Add(this.reflexButton);
			this.commonConnectorOperationsGroup.Controls.Add(this.reverseButton);
			this.commonConnectorOperationsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.commonConnectorOperationsGroup.ImageIndex = 0;
			this.commonConnectorOperationsGroup.Location = new System.Drawing.Point(0, 200);
			this.commonConnectorOperationsGroup.Name = "commonConnectorOperationsGroup";
			this.commonConnectorOperationsGroup.Size = new System.Drawing.Size(248, 96);
			this.commonConnectorOperationsGroup.TabIndex = 2;
			this.commonConnectorOperationsGroup.TabStop = false;
			this.commonConnectorOperationsGroup.Text = "Common 1D shapes operations";
			// 
			// reflexButton
			// 
			this.reflexButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.reflexButton.Location = new System.Drawing.Point(8, 56);
			this.reflexButton.Name = "reflexButton";
			this.reflexButton.Size = new System.Drawing.Size(232, 23);
			this.reflexButton.TabIndex = 1;
			this.reflexButton.Text = "Reflex";
			this.reflexButton.Click += new System.EventHandler(this.reflexButton_Click);
			// 
			// reverseButton
			// 
			this.reverseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.reverseButton.Location = new System.Drawing.Point(8, 24);
			this.reverseButton.Name = "reverseButton";
			this.reverseButton.Size = new System.Drawing.Size(232, 23);
			this.reverseButton.TabIndex = 0;
			this.reverseButton.Text = "Reverse";
			this.reverseButton.Click += new System.EventHandler(this.reverseButton_Click);
			// 
			// NStepAndArrowConnectorsUC
			// 
			this.Controls.Add(this.commonConnectorOperationsGroup);
			this.Controls.Add(this.arrowConnectorPropertiesGroup);
			this.Controls.Add(this.hvConnectorPropertiesGroup);
			this.Name = "NStepAndArrowConnectorsUC";
			this.Size = new System.Drawing.Size(248, 560);
			this.Controls.SetChildIndex(this.hvConnectorPropertiesGroup, 0);
			this.Controls.SetChildIndex(this.arrowConnectorPropertiesGroup, 0);
			this.Controls.SetChildIndex(this.commonConnectorOperationsGroup, 0);
			this.hvConnectorPropertiesGroup.ResumeLayout(false);
			this.step3ConnectorPropertiesGroup.ResumeLayout(false);
			this.arrowConnectorPropertiesGroup.ResumeLayout(false);
			this.commonConnectorOperationsGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			view.Grid.Visible = false;
			view.Selection.Mode = DiagramSelectionMode.Single;
			view.InteractiveAppearance.SelectedStrokeStyle = new NStrokeStyle(2, Color.Blue);
			view.InteractiveAppearance.SelectedFillStyle = new NColorFillStyle(Color.FromArgb(80, Color.Blue));

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();
            
			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}

		protected override void AttachToEvents()
		{
			view.EventSinkService.NodeSelected += new NodeEventHandler(EventSinkService_OnNodeSelected);
			view.EventSinkService.NodeDeselected += new NodeEventHandler(EventSinkService_OnNodeDeselected);

			base.AttachToEvents();
		}
		
		protected override void DetachFromEvents()
		{
			view.EventSinkService.NodeSelected -= new NodeEventHandler(EventSinkService_OnNodeSelected);
			view.EventSinkService.NodeDeselected -= new NodeEventHandler(EventSinkService_OnNodeDeselected);
		
			base.DetachFromEvents();
		}


		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			arrowConnectorTypeCombo.FillFromEnum(typeof(ArrowType));
			offsetTextBox.Text = "";
			percentTextBox.Text = "";

			hvConnectorPropertiesGroup.Enabled = false;
			arrowConnectorPropertiesGroup.Enabled = false;
			commonConnectorOperationsGroup.Enabled = false;
			
			ResumeEventsHandling();
		}
				
		private void InitDocument()
		{
			document.Style.TextStyle = new NTextStyle(new Font("Arial", 9), Color.Black);

			// modify the connectors style sheet
			NStyleSheet styleSheet = (document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1) as NStyleSheet); 

			NTextStyle textStyle = new NTextStyle();
			textStyle.BackplaneStyle.Visible = true;
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = new NLength(0); 
			styleSheet.Style.TextStyle = textStyle;

			styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);

			// create a stylesheet for the 2D Shapes
			styleSheet = new NStyleSheet("SHAPE2D");
			styleSheet.Style.FillStyle = new NColorFillStyle(Color.PapayaWhip);
			document.StyleSheets.AddChild(styleSheet);

			// create a stylesheet for the arrows, which inherits from the connectors stylesheet
			styleSheet = new NStyleSheet("ARROW", NDR.NameConnectorsStyleSheet);

			textStyle = new NTextStyle();
			textStyle.FontStyle.InitFromFont(new Font("Arial", 8));
			styleSheet.Style.TextStyle = textStyle;

			document.StyleSheets.AddChild(styleSheet);
				
			// create shapes
			NShape shape1 = base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(150, 50, 50, 50), "1", "SHAPE2D");
			
			NShape shape2 = base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(150, 150, 50, 50), "2", "SHAPE2D");
			NShape shape3 = base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(325, 150, 50, 50), "3", "SHAPE2D");

			NShape shape4 = base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(50, 250, 50, 50), "4", "SHAPE2D");
			NShape shape5 = base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(250, 250, 50, 50), "5", "SHAPE2D");
			NShape shape6 = base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(400, 250, 50, 50), "6", "SHAPE2D");

			NShape shape7 = base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(250, 350, 50, 50), "7", "SHAPE2D");
			NShape shape8 = base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(400, 350, 50, 50), "8", "SHAPE2D");

			// create connectors
			NLineShape line = new NLineShape();
			line.StyleSheetName = NDR.NameConnectorsStyleSheet;
			line.Text = "Line";
			document.ActiveLayer.AddChild(line);
			line.StartPlug.Connect(shape1.Ports.GetChildByName("Bottom", 0) as NPort);
			line.EndPlug.Connect(shape2.Ports.GetChildByName("Top", 0) as NPort);

			NStep2Connector hv = new NStep2Connector(false);
			hv.StyleSheetName = NDR.NameConnectorsStyleSheet;
			hv.Text = "HV";
			document.ActiveLayer.AddChild(hv);
			hv.StartPlug.Connect(shape1.Ports.GetChildByName("Right", 0) as NPort);
			hv.EndPlug.Connect(shape3.Ports.GetChildByName("Top", 0) as NPort);

			NStep2Connector vh = new NStep2Connector(true);
			vh.StyleSheetName = NDR.NameConnectorsStyleSheet;
			vh.Text = "VH";
			document.ActiveLayer.AddChild(vh);
			vh.StartPlug.Connect(shape4.Ports.GetChildByName("Bottom", 0) as NPort);
			vh.EndPlug.Connect(shape7.Ports.GetChildByName("Left", 0) as NPort);

			NStep3Connector vhv = new NStep3Connector(true, 50, 0, true);
			vhv.StyleSheetName = NDR.NameConnectorsStyleSheet;
			vhv.Text = "VHV";
			document.ActiveLayer.AddChild(vhv);
			vhv.StartPlug.Connect(shape2.Ports.GetChildByName("Bottom", 0) as NPort);
			vhv.EndPlug.Connect(shape4.Ports.GetChildByName("Top", 0) as NPort);

			NStep3Connector hvh = new NStep3Connector(false, 50, 0, true);
			hvh.StyleSheetName = NDR.NameConnectorsStyleSheet;
			hvh.Text = "HVH";
			document.ActiveLayer.AddChild(hvh);
			hvh.StartPlug.Connect(shape2.Ports.GetChildByName("Right", 0) as NPort);
			hvh.EndPlug.Connect(shape5.Ports.GetChildByName("Left", 0) as NPort);

			NArrowShape doubleArrow = new NArrowShape(ArrowType.DoubleArrow, new NPointF(0, 0), new NPointF(1, 1), 10, 45, 30);
			doubleArrow.StyleSheetName = "ARROW";
			doubleArrow.Text = "Double Arrow";
			document.ActiveLayer.AddChild(doubleArrow);
			doubleArrow.StartPlug.Connect(shape5.Ports.GetChildByName("Right", 0) as NPort);
			doubleArrow.EndPlug.Connect(shape6.Ports.GetChildByName("Left", 0) as NPort);

			NArrowShape singleArrow = new NArrowShape(ArrowType.SingleArrow, new NPointF(0, 0), new NPointF(1, 1), 10, 45, 30);
			singleArrow.StyleSheetName = "ARROW";
			singleArrow.Text = "Single Arrow";
			document.ActiveLayer.AddChild(singleArrow);
			singleArrow.StartPlug.Connect(shape7.Ports.GetChildByName("Right", 0) as NPort);
			singleArrow.EndPlug.Connect(shape8.Ports.GetChildByName("Left", 0) as NPort);

			NBezierCurveShape bezier = new NBezierCurveShape();
			bezier.StyleSheetName = NDR.NameConnectorsStyleSheet;
			bezier.Text = "Bezier";
			bezier.StartPlug.Connect(shape6.Ports.GetChildByName("Right", 0) as NPort);
			bezier.EndPlug.Connect(shape6.Ports.GetChildByName("Top", 0) as NPort);
			bezier.Reflex();
		}

		
		#endregion

		#region Event Handlers

		private void EventSinkService_OnNodeSelected(NNodeEventArgs args)
		{
			NShape shape = (view.Selection.AnchorNode as NShape);
			
			if (shape == null)
			{
				commonConnectorOperationsGroup.Enabled = false;
				hvConnectorPropertiesGroup.Enabled = false;
				arrowConnectorPropertiesGroup.Enabled = false; 
				return;
			}

			PauseEventsHandling();

			// common group
			if (shape.ShapeType == ShapeType.Shape1D)
			{
				commonConnectorOperationsGroup.Enabled = true;
				reflexButton.Enabled = (shape is INReflexiveShape);
			}
			else
			{
				commonConnectorOperationsGroup.Enabled = false;
			}
			
			// step connectors group
			if (shape is NStepConnector)
			{
				hvConnectorPropertiesGroup.Enabled = true;
                firstVerticalCheck.Checked = (shape as NStepConnector).FirstVertical;

				if (shape is NStep3Connector)
				{
					NStep3Connector step3Connector = (shape as NStep3Connector);
					step3ConnectorPropertiesGroup.Enabled = true; 

					percentRadio.Checked = step3Connector.UseMiddleControlPointPercent;
					percentTextBox.Text = step3Connector.MiddleControlPointPercent.ToString(); 
					offsetTextBox.Text = step3Connector.MiddleControlPointOffset.ToString();
				}
				else
				{
					step3ConnectorPropertiesGroup.Enabled = false; 
				}
			}
			else
			{
				hvConnectorPropertiesGroup.Enabled = false;
			}

			// arrow group
			if (shape is NArrowShape)
			{
				arrowConnectorPropertiesGroup.Enabled = true; 
				arrowConnectorTypeCombo.SelectedIndex = (int)(shape as NArrowShape).ArrowType;
			}
			else
			{
				arrowConnectorPropertiesGroup.Enabled = false; 
			}

			ResumeEventsHandling();
		}

		private void EventSinkService_OnNodeDeselected(NNodeEventArgs args)
		{
			hvConnectorPropertiesGroup.Enabled = false;
			arrowConnectorPropertiesGroup.Enabled = false;
			commonConnectorOperationsGroup.Enabled = false;
		}


		private void firstVerticalCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NStepConnector connector = (view.Selection.AnchorNode as NStepConnector);
			if (connector == null)
				return;

			connector.FirstVertical = firstVerticalCheck.Checked;
			document.SmartRefreshAllViews(); 
		}

		private void percentRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NStep3Connector connector = (view.Selection.AnchorNode as NStep3Connector);
			if (connector == null)
				return;

			connector.UseMiddleControlPointPercent = percentRadio.Checked;
			document.SmartRefreshAllViews();
		}

		private void percentTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NStep3Connector connector = (view.Selection.AnchorNode as NStep3Connector);
			if (connector == null)
				return;

			float percent = 0;
			try
			{
				percent = Single.Parse(percentTextBox.Text);
			}
			catch
			{
				return;
			}

			connector.MiddleControlPointPercent = percent;
			document.SmartRefreshAllViews();
		}

		private void offsetRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NStep3Connector connector = (view.Selection.AnchorNode as NStep3Connector);
			if (connector == null)
				return;

			connector.UseMiddleControlPointPercent = !offsetRadio.Checked;
			document.SmartRefreshAllViews();
		}

		private void offsetTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NStep3Connector connector = (view.Selection.AnchorNode as NStep3Connector);
			if (connector == null)
				return;

			float offset = 0;
			try
			{
				offset = Single.Parse(offsetTextBox.Text);
			}
			catch
			{
				return;
			}

			connector.MiddleControlPointOffset = offset;
			document.SmartRefreshAllViews();
		}

		private void arrowConnectorTypeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NArrowShape connector = (view.Selection.AnchorNode as NArrowShape);
			if (connector == null)
				return;

			connector.ArrowType = (ArrowType)arrowConnectorTypeCombo.SelectedIndex;
			document.SmartRefreshAllViews();
		}

		private void reverseButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null || shape.ShapeType != ShapeType.Shape1D)
				return;

			shape.Reverse();
			document.SmartRefreshAllViews();
		}

		private void reflexButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			INReflexiveShape reflexiveShape = (view.Selection.AnchorNode as INReflexiveShape);
			if (reflexiveShape == null)
				return;

			reflexiveShape.Reflex();
			document.SmartRefreshAllViews();
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox hvConnectorPropertiesGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox arrowConnectorPropertiesGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox commonConnectorOperationsGroup;
		private Nevron.UI.WinForm.Controls.NButton reverseButton;
		private Nevron.UI.WinForm.Controls.NButton reflexButton;
		private Nevron.UI.WinForm.Controls.NCheckBox firstVerticalCheck;
		private Nevron.UI.WinForm.Controls.NGroupBox step3ConnectorPropertiesGroup;
		private Nevron.UI.WinForm.Controls.NRadioButton percentRadio;
		private Nevron.UI.WinForm.Controls.NRadioButton offsetRadio;
		private Nevron.UI.WinForm.Controls.NTextBox percentTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox offsetTextBox;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox arrowConnectorTypeCombo;

		#endregion
	}
}