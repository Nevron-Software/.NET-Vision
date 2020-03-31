using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Editors;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NBasicViewFeaturesUC.
	/// </summary>
	public class NBasicViewFeaturesUC : NDiagramExampleUC
	{
		#region Constructor

		public NBasicViewFeaturesUC(NMainForm form) : base(form)
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
			this.label1 = new System.Windows.Forms.Label();
			this.viewStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.scalingGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.scaleYPercentLabel = new System.Windows.Forms.Label();
			this.scaleXPercentLabel = new System.Windows.Forms.Label();
			this.zoomPercentLabel = new System.Windows.Forms.Label();
			this.scaleYScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.scaleXScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.zoomScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.scrollbarsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.autoScrollTimeNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.autoScrollDelayNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.smallScrollChangeNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.nonScrollSceneAlignmentCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.scrollBarsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.nNumericUpDown1 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.generalGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.viewportOriginXNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.viewportOriginYNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.globalVisibilityButton = new Nevron.UI.WinForm.Controls.NButton();
			this.documentShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.documentPaddingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.scalingGroup.SuspendLayout();
			this.scrollbarsGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.autoScrollTimeNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.autoScrollDelayNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.smallScrollChangeNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).BeginInit();
			this.generalGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewportOriginXNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.viewportOriginYNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "View style:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// viewStyleCombo
			// 
			this.viewStyleCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.viewStyleCombo.Location = new System.Drawing.Point(80, 22);
			this.viewStyleCombo.Name = "viewStyleCombo";
			this.viewStyleCombo.Size = new System.Drawing.Size(152, 21);
			this.viewStyleCombo.TabIndex = 1;
			this.viewStyleCombo.SelectedIndexChanged += new System.EventHandler(this.viewStyleCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "Zoom:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 14);
			this.label3.TabIndex = 5;
			this.label3.Text = "Scale X:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "Scale Y:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// scalingGroup
			// 
			this.scalingGroup.Controls.Add(this.scaleYPercentLabel);
			this.scalingGroup.Controls.Add(this.scaleXPercentLabel);
			this.scalingGroup.Controls.Add(this.zoomPercentLabel);
			this.scalingGroup.Controls.Add(this.scaleYScroll);
			this.scalingGroup.Controls.Add(this.scaleXScroll);
			this.scalingGroup.Controls.Add(this.zoomScroll);
			this.scalingGroup.Controls.Add(this.label4);
			this.scalingGroup.Controls.Add(this.label1);
			this.scalingGroup.Controls.Add(this.viewStyleCombo);
			this.scalingGroup.Controls.Add(this.label2);
			this.scalingGroup.Controls.Add(this.label3);
			this.scalingGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.scalingGroup.ImageIndex = 0;
			this.scalingGroup.Location = new System.Drawing.Point(0, 176);
			this.scalingGroup.Name = "scalingGroup";
			this.scalingGroup.Size = new System.Drawing.Size(240, 128);
			this.scalingGroup.TabIndex = 2;
			this.scalingGroup.TabStop = false;
			this.scalingGroup.Text = "Scaling";
			// 
			// scaleYPercentLabel
			// 
			this.scaleYPercentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.scaleYPercentLabel.Location = new System.Drawing.Point(192, 96);
			this.scaleYPercentLabel.Name = "scaleYPercentLabel";
			this.scaleYPercentLabel.Size = new System.Drawing.Size(40, 16);
			this.scaleYPercentLabel.TabIndex = 10;
			this.scaleYPercentLabel.Text = "100%";
			this.scaleYPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// scaleXPercentLabel
			// 
			this.scaleXPercentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.scaleXPercentLabel.Location = new System.Drawing.Point(192, 72);
			this.scaleXPercentLabel.Name = "scaleXPercentLabel";
			this.scaleXPercentLabel.Size = new System.Drawing.Size(40, 16);
			this.scaleXPercentLabel.TabIndex = 7;
			this.scaleXPercentLabel.Text = "100%";
			this.scaleXPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// zoomPercentLabel
			// 
			this.zoomPercentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.zoomPercentLabel.Location = new System.Drawing.Point(192, 48);
			this.zoomPercentLabel.Name = "zoomPercentLabel";
			this.zoomPercentLabel.Size = new System.Drawing.Size(40, 16);
			this.zoomPercentLabel.TabIndex = 4;
			this.zoomPercentLabel.Text = "100%";
			this.zoomPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// scaleYScroll
			// 
			this.scaleYScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.scaleYScroll.Location = new System.Drawing.Point(80, 96);
			this.scaleYScroll.Minimum = 1;
			this.scaleYScroll.Name = "scaleYScroll";
			this.scaleYScroll.Size = new System.Drawing.Size(104, 17);
			this.scaleYScroll.TabIndex = 9;
			this.scaleYScroll.Value = 1;
			this.scaleYScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.scaleYScroll_ValueChanged);
			// 
			// scaleXScroll
			// 
			this.scaleXScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.scaleXScroll.Location = new System.Drawing.Point(80, 72);
			this.scaleXScroll.Minimum = 1;
			this.scaleXScroll.Name = "scaleXScroll";
			this.scaleXScroll.Size = new System.Drawing.Size(104, 17);
			this.scaleXScroll.TabIndex = 6;
			this.scaleXScroll.Value = 1;
			this.scaleXScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.scaleXScroll_ValueChanged);
			// 
			// zoomScroll
			// 
			this.zoomScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.zoomScroll.Location = new System.Drawing.Point(80, 48);
			this.zoomScroll.Minimum = 1;
			this.zoomScroll.Name = "zoomScroll";
			this.zoomScroll.Size = new System.Drawing.Size(104, 17);
			this.zoomScroll.TabIndex = 3;
			this.zoomScroll.Value = 1;
			this.zoomScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.zoomScroll_ValueChanged);
			// 
			// scrollbarsGroup
			// 
			this.scrollbarsGroup.Controls.Add(this.autoScrollTimeNumeric);
			this.scrollbarsGroup.Controls.Add(this.label11);
			this.scrollbarsGroup.Controls.Add(this.autoScrollDelayNumeric);
			this.scrollbarsGroup.Controls.Add(this.label10);
			this.scrollbarsGroup.Controls.Add(this.smallScrollChangeNumeric);
			this.scrollbarsGroup.Controls.Add(this.nonScrollSceneAlignmentCombo);
			this.scrollbarsGroup.Controls.Add(this.label7);
			this.scrollbarsGroup.Controls.Add(this.label9);
			this.scrollbarsGroup.Controls.Add(this.scrollBarsCombo);
			this.scrollbarsGroup.Controls.Add(this.label5);
			this.scrollbarsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.scrollbarsGroup.ImageIndex = 0;
			this.scrollbarsGroup.Location = new System.Drawing.Point(0, 304);
			this.scrollbarsGroup.Name = "scrollbarsGroup";
			this.scrollbarsGroup.Size = new System.Drawing.Size(240, 176);
			this.scrollbarsGroup.TabIndex = 3;
			this.scrollbarsGroup.TabStop = false;
			this.scrollbarsGroup.Text = "Scrolling";
			// 
			// autoScrollTimeNumeric
			// 
			this.autoScrollTimeNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.autoScrollTimeNumeric.Location = new System.Drawing.Point(128, 136);
			this.autoScrollTimeNumeric.Maximum = new System.Decimal(new int[] {
																				  10000,
																				  0,
																				  0,
																				  0});
			this.autoScrollTimeNumeric.Name = "autoScrollTimeNumeric";
			this.autoScrollTimeNumeric.Size = new System.Drawing.Size(100, 22);
			this.autoScrollTimeNumeric.TabIndex = 9;
			this.autoScrollTimeNumeric.Value = new System.Decimal(new int[] {
																				1,
																				0,
																				0,
																				0});
			this.autoScrollTimeNumeric.ValueChanged += new System.EventHandler(this.autoScrollTimeNumeric_ValueChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 136);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(112, 16);
			this.label11.TabIndex = 8;
			this.label11.Text = "Auto scroll  time:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// autoScrollDelayNumeric
			// 
			this.autoScrollDelayNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.autoScrollDelayNumeric.Location = new System.Drawing.Point(128, 112);
			this.autoScrollDelayNumeric.Maximum = new System.Decimal(new int[] {
																				   10000,
																				   0,
																				   0,
																				   0});
			this.autoScrollDelayNumeric.Name = "autoScrollDelayNumeric";
			this.autoScrollDelayNumeric.Size = new System.Drawing.Size(100, 22);
			this.autoScrollDelayNumeric.TabIndex = 7;
			this.autoScrollDelayNumeric.Value = new System.Decimal(new int[] {
																				 1,
																				 0,
																				 0,
																				 0});
			this.autoScrollDelayNumeric.ValueChanged += new System.EventHandler(this.autoScrollDelayNumeric_ValueChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 112);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 16);
			this.label10.TabIndex = 6;
			this.label10.Text = "Auto scroll  delay:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// smallScrollChangeNumeric
			// 
			this.smallScrollChangeNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.smallScrollChangeNumeric.Location = new System.Drawing.Point(128, 88);
			this.smallScrollChangeNumeric.Maximum = new System.Decimal(new int[] {
																					 10000,
																					 0,
																					 0,
																					 0});
			this.smallScrollChangeNumeric.Name = "smallScrollChangeNumeric";
			this.smallScrollChangeNumeric.Size = new System.Drawing.Size(100, 22);
			this.smallScrollChangeNumeric.TabIndex = 5;
			this.smallScrollChangeNumeric.ValueChanged += new System.EventHandler(this.smallScrollChangeNumeric_ValueChanged);
			// 
			// nonScrollSceneAlignmentCombo
			// 
			this.nonScrollSceneAlignmentCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nonScrollSceneAlignmentCombo.Location = new System.Drawing.Point(80, 56);
			this.nonScrollSceneAlignmentCombo.Name = "nonScrollSceneAlignmentCombo";
			this.nonScrollSceneAlignmentCombo.Size = new System.Drawing.Size(152, 21);
			this.nonScrollSceneAlignmentCombo.TabIndex = 3;
			this.nonScrollSceneAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.nonScrollSceneAlignmentCombo_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 32);
			this.label7.TabIndex = 2;
			this.label7.Text = "Non scroll alignment:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 32);
			this.label9.TabIndex = 0;
			this.label9.Text = "Scroll bars:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// scrollBarsCombo
			// 
			this.scrollBarsCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.scrollBarsCombo.Location = new System.Drawing.Point(80, 22);
			this.scrollBarsCombo.Name = "scrollBarsCombo";
			this.scrollBarsCombo.Size = new System.Drawing.Size(152, 21);
			this.scrollBarsCombo.TabIndex = 1;
			this.scrollBarsCombo.SelectedIndexChanged += new System.EventHandler(this.scrollBarsCombo_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Small scroll change:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nNumericUpDown1
			// 
			this.nNumericUpDown1.Location = new System.Drawing.Point(0, 0);
			this.nNumericUpDown1.Name = "nNumericUpDown1";
			this.nNumericUpDown1.Size = new System.Drawing.Size(120, 22);
			this.nNumericUpDown1.TabIndex = 0;
			// 
			// generalGroup
			// 
			this.generalGroup.Controls.Add(this.viewportOriginXNumeric);
			this.generalGroup.Controls.Add(this.viewportOriginYNumeric);
			this.generalGroup.Controls.Add(this.globalVisibilityButton);
			this.generalGroup.Controls.Add(this.documentShadowButton);
			this.generalGroup.Controls.Add(this.label8);
			this.generalGroup.Controls.Add(this.label6);
			this.generalGroup.Controls.Add(this.documentPaddingButton);
			this.generalGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.generalGroup.ImageIndex = 0;
			this.generalGroup.Location = new System.Drawing.Point(0, 0);
			this.generalGroup.Name = "generalGroup";
			this.generalGroup.Size = new System.Drawing.Size(240, 176);
			this.generalGroup.TabIndex = 1;
			this.generalGroup.TabStop = false;
			this.generalGroup.Text = "General";
			// 
			// viewportOriginXNumeric
			// 
			this.viewportOriginXNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.viewportOriginXNumeric.Location = new System.Drawing.Point(128, 25);
			this.viewportOriginXNumeric.Maximum = new System.Decimal(new int[] {
																				   100000,
																				   0,
																				   0,
																				   0});
			this.viewportOriginXNumeric.Minimum = new System.Decimal(new int[] {
																				   100000,
																				   0,
																				   0,
																				   -2147483648});
			this.viewportOriginXNumeric.Name = "viewportOriginXNumeric";
			this.viewportOriginXNumeric.Size = new System.Drawing.Size(100, 22);
			this.viewportOriginXNumeric.TabIndex = 1;
			this.viewportOriginXNumeric.ValueChanged += new System.EventHandler(this.viewportOriginXNumeric_ValueChanged);
			// 
			// viewportOriginYNumeric
			// 
			this.viewportOriginYNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.viewportOriginYNumeric.Location = new System.Drawing.Point(128, 49);
			this.viewportOriginYNumeric.Maximum = new System.Decimal(new int[] {
																				   100000,
																				   0,
																				   0,
																				   0});
			this.viewportOriginYNumeric.Minimum = new System.Decimal(new int[] {
																				   100000,
																				   0,
																				   0,
																				   -2147483648});
			this.viewportOriginYNumeric.Name = "viewportOriginYNumeric";
			this.viewportOriginYNumeric.Size = new System.Drawing.Size(100, 22);
			this.viewportOriginYNumeric.TabIndex = 3;
			this.viewportOriginYNumeric.ValueChanged += new System.EventHandler(this.viewportOriginYNumeric_ValueChanged);
			// 
			// globalVisibilityButton
			// 
			this.globalVisibilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.globalVisibilityButton.Location = new System.Drawing.Point(8, 80);
			this.globalVisibilityButton.Name = "globalVisibilityButton";
			this.globalVisibilityButton.Size = new System.Drawing.Size(224, 23);
			this.globalVisibilityButton.TabIndex = 4;
			this.globalVisibilityButton.Text = "Global visibility...";
			this.globalVisibilityButton.Click += new System.EventHandler(this.globalVisibilityButton_Click);
			// 
			// documentShadowButton
			// 
			this.documentShadowButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.documentShadowButton.Location = new System.Drawing.Point(8, 144);
			this.documentShadowButton.Name = "documentShadowButton";
			this.documentShadowButton.Size = new System.Drawing.Size(224, 23);
			this.documentShadowButton.TabIndex = 6;
			this.documentShadowButton.Text = "Document shadow...";
			this.documentShadowButton.Click += new System.EventHandler(this.documentShadowButton_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 23);
			this.label8.TabIndex = 2;
			this.label8.Text = "Viewport origin Y:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Viewport origin X:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentPaddingButton
			// 
			this.documentPaddingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.documentPaddingButton.Location = new System.Drawing.Point(8, 112);
			this.documentPaddingButton.Name = "documentPaddingButton";
			this.documentPaddingButton.Size = new System.Drawing.Size(224, 23);
			this.documentPaddingButton.TabIndex = 5;
			this.documentPaddingButton.Text = "Document padding...";
			this.documentPaddingButton.Click += new System.EventHandler(this.documentPaddingButton_Click);
			// 
			// NBasicViewFeaturesUC
			// 
			this.Controls.Add(this.scrollbarsGroup);
			this.Controls.Add(this.scalingGroup);
			this.Controls.Add(this.generalGroup);
			this.Name = "NBasicViewFeaturesUC";
			this.Size = new System.Drawing.Size(240, 576);
			this.Controls.SetChildIndex(this.generalGroup, 0);
			this.Controls.SetChildIndex(this.scalingGroup, 0);
			this.Controls.SetChildIndex(this.scrollbarsGroup, 0);
			this.scalingGroup.ResumeLayout(false);
			this.scrollbarsGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.autoScrollTimeNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.autoScrollDelayNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.smallScrollChangeNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).EndInit();
			this.generalGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.viewportOriginXNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.viewportOriginYNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			view.DocumentPadding = new Nevron.Diagram.NMargins(20);
			view.ViewportOrigin = new NPointF(-12, -12);
			view.Grid.Visible = false;

			// init document
			document.BeginInit();
			CreateDefaultFlowDiagram();
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

			viewportOriginXNumeric.Value = (int)view.ViewportOrigin.X;
			viewportOriginYNumeric.Value = (int)view.ViewportOrigin.Y;

			viewStyleCombo.FillFromEnum(typeof(ViewLayout));
			viewStyleCombo.SelectedItem = view.ViewLayout;

			int scaleX = (int)Math.Round(view.ScaleX * 10);
			scaleXScroll.Value = scaleX;
			zoomScroll.Value = scaleX;

			int scaleY = (int)Math.Round(view.ScaleY * 10);
			scaleYScroll.Value = scaleY;

			scrollBarsCombo.FillFromEnum(typeof(ScrollBars));
			scrollBarsCombo.SelectedItem = view.ScrollBars;

			nonScrollSceneAlignmentCombo.FillFromEnum(typeof(ContentAlignment));
			nonScrollSceneAlignmentCombo.SelectedItem = view.NonScrollableSceneAlignment;

			smallScrollChangeNumeric.Value = view.SmallScrollChange.Height;
			autoScrollDelayNumeric.Value = view.AutoScroller.Delay;
			autoScrollTimeNumeric.Value = view.AutoScroller.Time;

			ResumeEventsHandling();
		}

		#endregion

		#region Event Handlers

		private void viewportOriginXNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float x = (float)viewportOriginXNumeric.Value;
			float y = view.ViewportOrigin.Y;
			view.ViewportOrigin = new NPointF(x, y);

			view.Refresh();
		}

		private void viewportOriginYNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float x = view.ViewportOrigin.X;
			float y = (float)viewportOriginYNumeric.Value;
			view.ViewportOrigin = new NPointF(x, y);

			view.Refresh();
		}


		private void globalVisibilityButton_Click(object sender, System.EventArgs e)
		{		
			if (EventsHandlingPaused)
				return;

			NGlobalVisibility visibility;
			if (NGlobalVisibilityTypeEditor.Edit(view.GlobalVisibility, out visibility))
			{
				view.GlobalVisibility = visibility;
			}
		}

		private void documentShadowButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NShadowStyle shadow;
			if (NShadowStyleTypeEditor.Edit(view.DocumentShadow, out shadow))
			{
				view.DocumentShadow = shadow;
			}
		}
		
		private void documentPaddingButton_Click(object sender, System.EventArgs e)
		{
			Nevron.Diagram.NMargins result = new Nevron.Diagram.NMargins();
			if (Nevron.Diagram.Editors.NMarginsTypeEditor.Edit(view.DocumentPadding, ref result) == false)
				return;

			view.DocumentPadding = result;
			view.Refresh();
		}


		private void viewStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			view.ViewLayout = (ViewLayout)viewStyleCombo.SelectedItem;

			bool enable = (view.ViewLayout == ViewLayout.Normal);
			zoomScroll.Enabled = enable;
			scaleXScroll.Enabled = enable;
			scaleYScroll.Enabled = enable;

			view.Refresh();
		}

		private void zoomScroll_ValueChanged(object sender, ScrollBarEventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float value = (float)zoomScroll.Value;
			view.Zoom((float) value / 10);
			zoomPercentLabel.Text = Convert.ToString(value * 10) + "%";

			scaleXScroll.Value = (int)value;
			scaleYScroll.Value = (int)value;

			view.Refresh();
		}

		private void scaleXScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float value = (float)scaleXScroll.Value;
			view.ScaleX = ((float) value / 10);
			scaleXPercentLabel.Text = Convert.ToString(value * 10) + "%";

			view.Refresh();
		}

		private void scaleYScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float value = (float)scaleYScroll.Value;
			view.ScaleY = ((float) value / 10);
			scaleYPercentLabel.Text = Convert.ToString(value * 10) + "%";

			view.Refresh();
		}

		
		private void scrollBarsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			view.ScrollBars = (ScrollBars)scrollBarsCombo.SelectedItem;
		}

		private void nonScrollSceneAlignmentCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			view.NonScrollableSceneAlignment = (ContentAlignment)nonScrollSceneAlignmentCombo.SelectedItem;
		}

		private void smallScrollChangeNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			int change = (int)smallScrollChangeNumeric.Value;
			view.SmallScrollChange = new NSize(change, change);
		}

		private void autoScrollDelayNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			int delay = (int)autoScrollDelayNumeric.Value;
			view.AutoScroller.Delay = delay;
		}

		private void autoScrollTimeNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			int time = (int)autoScrollTimeNumeric.Value;
			view.AutoScroller.Time = time;
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton documentPaddingButton;
		private Nevron.UI.WinForm.Controls.NComboBox viewStyleCombo;
		private Nevron.UI.WinForm.Controls.NHScrollBar scaleYScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar scaleXScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar zoomScroll;
		private Nevron.UI.WinForm.Controls.NComboBox scrollBarsCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private Nevron.UI.WinForm.Controls.NGroupBox scalingGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox scrollbarsGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox generalGroup;
		private Nevron.UI.WinForm.Controls.NButton documentShadowButton;
		private Nevron.UI.WinForm.Controls.NButton globalVisibilityButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown smallScrollChangeNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown viewportOriginYNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown viewportOriginXNumeric;
		private Nevron.UI.WinForm.Controls.NComboBox nonScrollSceneAlignmentCombo;
		private Nevron.UI.WinForm.Controls.NNumericUpDown autoScrollDelayNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown autoScrollTimeNumeric;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label zoomPercentLabel;
		private System.Windows.Forms.Label scaleXPercentLabel;
		private System.Windows.Forms.Label scaleYPercentLabel;

		#endregion
	}
}