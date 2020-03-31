using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.UI.WinForm.Controls;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NDrawingBoundsUC.
	/// </summary>
	public class NDrawingBoundsUC : NDiagramExampleUC
	{
		#region Constructor

		public NDrawingBoundsUC(NMainForm form) : base(form)
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.autoBoundsModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.sizeToContentButton = new Nevron.UI.WinForm.Controls.NButton();
			this.inflateToContentButton = new Nevron.UI.WinForm.Controls.NButton();
			this.customBoundsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.boundsHeightTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.boundsWidthTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.boundsYTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.boundsXTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.automaticBoundsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.minWidthTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.minHeightTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.autoBoundsPaddingGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.paddingLeftTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.paddingTopTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.paddingBottomTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.paddingRightTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.panel1.SuspendLayout();
			this.customBoundsGroup.SuspendLayout();
			this.automaticBoundsGroup.SuspendLayout();
			this.autoBoundsPaddingGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.autoBoundsModeComboBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(250, 56);
			this.panel1.TabIndex = 0;
			// 
			// autoBoundsModeComboBox
			// 
			this.autoBoundsModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.autoBoundsModeComboBox.Location = new System.Drawing.Point(8, 24);
			this.autoBoundsModeComboBox.Name = "autoBoundsModeComboBox";
			this.autoBoundsModeComboBox.Size = new System.Drawing.Size(234, 21);
			this.autoBoundsModeComboBox.TabIndex = 1;
			this.autoBoundsModeComboBox.SelectedIndexChanged += new System.EventHandler(this.autoBoundsModeCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Auto bounds mode:";
			// 
			// sizeToContentButton
			// 
			this.sizeToContentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sizeToContentButton.Location = new System.Drawing.Point(8, 88);
			this.sizeToContentButton.Name = "sizeToContentButton";
			this.sizeToContentButton.Size = new System.Drawing.Size(232, 23);
			this.sizeToContentButton.TabIndex = 4;
			this.sizeToContentButton.Text = "Size to content";
			this.sizeToContentButton.Click += new System.EventHandler(this.sizeToContentButton_Click);
			// 
			// inflateToContentButton
			// 
			this.inflateToContentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.inflateToContentButton.Location = new System.Drawing.Point(8, 120);
			this.inflateToContentButton.Name = "inflateToContentButton";
			this.inflateToContentButton.Size = new System.Drawing.Size(232, 23);
			this.inflateToContentButton.TabIndex = 5;
			this.inflateToContentButton.Text = "Inflate to content";
			this.inflateToContentButton.Click += new System.EventHandler(this.inflateToContentButton_Click);
			// 
			// customBoundsGroup
			// 
			this.customBoundsGroup.Controls.Add(this.label5);
			this.customBoundsGroup.Controls.Add(this.label4);
			this.customBoundsGroup.Controls.Add(this.label3);
			this.customBoundsGroup.Controls.Add(this.label2);
			this.customBoundsGroup.Controls.Add(this.boundsHeightTextBox);
			this.customBoundsGroup.Controls.Add(this.boundsWidthTextBox);
			this.customBoundsGroup.Controls.Add(this.boundsYTextBox);
			this.customBoundsGroup.Controls.Add(this.boundsXTextBox);
			this.customBoundsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.customBoundsGroup.ImageIndex = 0;
			this.customBoundsGroup.Location = new System.Drawing.Point(0, 56);
			this.customBoundsGroup.Name = "customBoundsGroup";
			this.customBoundsGroup.Size = new System.Drawing.Size(250, 136);
			this.customBoundsGroup.TabIndex = 1;
			this.customBoundsGroup.TabStop = false;
			this.customBoundsGroup.Text = "Custom bounds";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 111);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 15);
			this.label5.TabIndex = 6;
			this.label5.Text = "Height:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = "Width:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Y:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "X:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// boundsHeightTextBox
			// 
			this.boundsHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.boundsHeightTextBox.ErrorMessage = null;
			this.boundsHeightTextBox.Location = new System.Drawing.Point(80, 108);
			this.boundsHeightTextBox.Name = "boundsHeightTextBox";
			this.boundsHeightTextBox.Size = new System.Drawing.Size(160, 20);
			this.boundsHeightTextBox.TabIndex = 7;
			this.boundsHeightTextBox.TextChanged += new System.EventHandler(this.boundsHeightTextBox_TextChanged);
			// 
			// boundsWidthTextBox
			// 
			this.boundsWidthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.boundsWidthTextBox.ErrorMessage = null;
			this.boundsWidthTextBox.Location = new System.Drawing.Point(80, 80);
			this.boundsWidthTextBox.Name = "boundsWidthTextBox";
			this.boundsWidthTextBox.Size = new System.Drawing.Size(160, 20);
			this.boundsWidthTextBox.TabIndex = 5;
			this.boundsWidthTextBox.TextChanged += new System.EventHandler(this.boundsWidthTextBox_TextChanged);
			// 
			// boundsYTextBox
			// 
			this.boundsYTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.boundsYTextBox.ErrorMessage = null;
			this.boundsYTextBox.Location = new System.Drawing.Point(80, 52);
			this.boundsYTextBox.Name = "boundsYTextBox";
			this.boundsYTextBox.Size = new System.Drawing.Size(160, 20);
			this.boundsYTextBox.TabIndex = 3;
			this.boundsYTextBox.TextChanged += new System.EventHandler(this.boundsYTextBox_TextChanged);
			// 
			// boundsXTextBox
			// 
			this.boundsXTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.boundsXTextBox.ErrorMessage = null;
			this.boundsXTextBox.Location = new System.Drawing.Point(80, 24);
			this.boundsXTextBox.Name = "boundsXTextBox";
			this.boundsXTextBox.Size = new System.Drawing.Size(160, 20);
			this.boundsXTextBox.TabIndex = 1;
			this.boundsXTextBox.TextChanged += new System.EventHandler(this.boundsXTextBox_TextChanged);
			// 
			// automaticBoundsGroup
			// 
			this.automaticBoundsGroup.Controls.Add(this.label7);
			this.automaticBoundsGroup.Controls.Add(this.label6);
			this.automaticBoundsGroup.Controls.Add(this.minWidthTextBox);
			this.automaticBoundsGroup.Controls.Add(this.minHeightTextBox);
			this.automaticBoundsGroup.Controls.Add(this.sizeToContentButton);
			this.automaticBoundsGroup.Controls.Add(this.inflateToContentButton);
			this.automaticBoundsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.automaticBoundsGroup.ImageIndex = 0;
			this.automaticBoundsGroup.Location = new System.Drawing.Point(0, 328);
			this.automaticBoundsGroup.Name = "automaticBoundsGroup";
			this.automaticBoundsGroup.Size = new System.Drawing.Size(250, 152);
			this.automaticBoundsGroup.TabIndex = 3;
			this.automaticBoundsGroup.TabStop = false;
			this.automaticBoundsGroup.Text = "Automatic bounds";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 59);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 15);
			this.label7.TabIndex = 2;
			this.label7.Text = "Min height:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 27);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 15);
			this.label6.TabIndex = 0;
			this.label6.Text = "Min width:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// minWidthTextBox
			// 
			this.minWidthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.minWidthTextBox.ErrorMessage = null;
			this.minWidthTextBox.Location = new System.Drawing.Point(80, 24);
			this.minWidthTextBox.Name = "minWidthTextBox";
			this.minWidthTextBox.Size = new System.Drawing.Size(160, 20);
			this.minWidthTextBox.TabIndex = 1;
			this.minWidthTextBox.TextChanged += new System.EventHandler(this.minWidthTextBox_TextChanged);
			// 
			// minHeightTextBox
			// 
			this.minHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.minHeightTextBox.ErrorMessage = null;
			this.minHeightTextBox.Location = new System.Drawing.Point(80, 56);
			this.minHeightTextBox.Name = "minHeightTextBox";
			this.minHeightTextBox.Size = new System.Drawing.Size(160, 20);
			this.minHeightTextBox.TabIndex = 3;
			this.minHeightTextBox.TextChanged += new System.EventHandler(this.minHeightTextBox_TextChanged);
			// 
			// autoBoundsPaddingGroup
			// 
			this.autoBoundsPaddingGroup.Controls.Add(this.label11);
			this.autoBoundsPaddingGroup.Controls.Add(this.paddingLeftTextBox);
			this.autoBoundsPaddingGroup.Controls.Add(this.label9);
			this.autoBoundsPaddingGroup.Controls.Add(this.label8);
			this.autoBoundsPaddingGroup.Controls.Add(this.label10);
			this.autoBoundsPaddingGroup.Controls.Add(this.paddingTopTextBox);
			this.autoBoundsPaddingGroup.Controls.Add(this.paddingBottomTextBox);
			this.autoBoundsPaddingGroup.Controls.Add(this.paddingRightTextBox);
			this.autoBoundsPaddingGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.autoBoundsPaddingGroup.ImageIndex = 0;
			this.autoBoundsPaddingGroup.Location = new System.Drawing.Point(0, 192);
			this.autoBoundsPaddingGroup.Name = "autoBoundsPaddingGroup";
			this.autoBoundsPaddingGroup.Size = new System.Drawing.Size(250, 136);
			this.autoBoundsPaddingGroup.TabIndex = 2;
			this.autoBoundsPaddingGroup.TabStop = false;
			this.autoBoundsPaddingGroup.Text = "Automatic bounds padding";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 111);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 15);
			this.label11.TabIndex = 6;
			this.label11.Text = "Bottom:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// paddingLeftTextBox
			// 
			this.paddingLeftTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.paddingLeftTextBox.ErrorMessage = null;
			this.paddingLeftTextBox.Location = new System.Drawing.Point(80, 52);
			this.paddingLeftTextBox.Name = "paddingLeftTextBox";
			this.paddingLeftTextBox.Size = new System.Drawing.Size(160, 20);
			this.paddingLeftTextBox.TabIndex = 3;
			this.paddingLeftTextBox.TextChanged += new System.EventHandler(this.paddingLeftTextBox_TextChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 55);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 15);
			this.label9.TabIndex = 2;
			this.label9.Text = "Left:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 27);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 15);
			this.label8.TabIndex = 0;
			this.label8.Text = "Top:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 83);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 15);
			this.label10.TabIndex = 4;
			this.label10.Text = "Right:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// paddingTopTextBox
			// 
			this.paddingTopTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.paddingTopTextBox.ErrorMessage = null;
			this.paddingTopTextBox.Location = new System.Drawing.Point(80, 24);
			this.paddingTopTextBox.Name = "paddingTopTextBox";
			this.paddingTopTextBox.Size = new System.Drawing.Size(160, 20);
			this.paddingTopTextBox.TabIndex = 1;
			this.paddingTopTextBox.TextChanged += new System.EventHandler(this.paddingTopTextBox_TextChanged);
			// 
			// paddingBottomTextBox
			// 
			this.paddingBottomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.paddingBottomTextBox.ErrorMessage = null;
			this.paddingBottomTextBox.Location = new System.Drawing.Point(80, 108);
			this.paddingBottomTextBox.Name = "paddingBottomTextBox";
			this.paddingBottomTextBox.Size = new System.Drawing.Size(160, 20);
			this.paddingBottomTextBox.TabIndex = 7;
			this.paddingBottomTextBox.TextChanged += new System.EventHandler(this.paddingBottomTextBox_TextChanged);
			// 
			// paddingRightTextBox
			// 
			this.paddingRightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.paddingRightTextBox.ErrorMessage = null;
			this.paddingRightTextBox.Location = new System.Drawing.Point(80, 80);
			this.paddingRightTextBox.Name = "paddingRightTextBox";
			this.paddingRightTextBox.Size = new System.Drawing.Size(160, 20);
			this.paddingRightTextBox.TabIndex = 5;
			this.paddingRightTextBox.TextChanged += new System.EventHandler(this.paddingRightTextBox_TextChanged);
			// 
			// NDrawingBoundsUC
			// 
			this.Controls.Add(this.automaticBoundsGroup);
			this.Controls.Add(this.autoBoundsPaddingGroup);
			this.Controls.Add(this.customBoundsGroup);
			this.Controls.Add(this.panel1);
			this.Name = "NDrawingBoundsUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.customBoundsGroup, 0);
			this.Controls.SetChildIndex(this.autoBoundsPaddingGroup, 0);
			this.Controls.SetChildIndex(this.automaticBoundsGroup, 0);
			this.panel1.ResumeLayout(false);
			this.customBoundsGroup.ResumeLayout(false);
			this.automaticBoundsGroup.ResumeLayout(false);
			this.autoBoundsPaddingGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init document
			document.BeginInit();
			InitDocument();
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

			// custom bounds
			boundsXTextBox.Text = document.Bounds.X.ToString();
			boundsYTextBox.Text = document.Bounds.Y.ToString();
			boundsWidthTextBox.Text = document.Bounds.Width.ToString();
			boundsHeightTextBox.Text = document.Bounds.Height.ToString();

			// autobounds
			minWidthTextBox.Text = document.AutoBoundsMinSize.Width.ToString(); 
			minHeightTextBox.Text = document.AutoBoundsMinSize.Height.ToString();

			paddingLeftTextBox.Text = document.AutoBoundsPadding.Left.ToString();
			paddingRightTextBox.Text = document.AutoBoundsPadding.Right.ToString();
			paddingTopTextBox.Text = document.AutoBoundsPadding.Top.ToString();
			paddingBottomTextBox.Text = document.AutoBoundsPadding.Bottom.ToString();

			autoBoundsModeComboBox.FillFromEnum(typeof(AutoBoundsMode));
			autoBoundsModeComboBox.SelectedItem = (AutoBoundsMode) document.AutoBoundsMode;

			ResumeEventsHandling();
		}

		private void InitDocument()
		{
			NRectangleShape rect1 = new NRectangleShape(new NRectangleF(10, 10, 200, 200));
			rect1.Text = "Change the Auto Bounds Mode and move Me";
			document.ActiveLayer.AddChild(rect1);

			NRectangleShape rect2 = new NRectangleShape(new NRectangleF(310, 310, 200, 200));
			rect2.Text = "Change the Auto Bounds Mode and move Me";
			document.ActiveLayer.AddChild(rect2);
		}

		
		private void ChangePadding()
		{
			Nevron.Diagram.NMargins margins = new Nevron.Diagram.NMargins(0);

			try
			{
				margins.Left = Single.Parse(paddingLeftTextBox.Text);
				margins.Right = Single.Parse(paddingRightTextBox.Text);
				margins.Top = Single.Parse(paddingTopTextBox.Text);
				margins.Bottom = Single.Parse(paddingBottomTextBox.Text);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Change padding failed with exception: " + ex.Message);
				return;
			}

			document.AutoBoundsPadding = margins; 
		}
		
		private void ChangeBounds()
		{
			float x = 0, y = 0, width = 0, height = 0;

			try
			{
				x = Single.Parse(boundsXTextBox.Text); 
				y = Single.Parse(boundsYTextBox.Text);
				width = Single.Parse(boundsWidthTextBox.Text); 
				height = Single.Parse(boundsHeightTextBox.Text);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Change bounds failed with exception: " + ex.Message);
				return;
			}

			document.Bounds = new NRectangleF(x, y, width, height); 
		}

		private void ChangeMinSize()
		{
			float minWidth = 0, minHeight = 0;

			try
			{
				minWidth = Single.Parse(minWidthTextBox.Text);
				minHeight = Single.Parse(minHeightTextBox.Text);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Change min size failed with exception: " + ex.Message);
				return;
			}
            
			document.AutoBoundsMinSize = new NSizeF(minWidth, minHeight);
		}


		#endregion

		#region Event Handlers

		private void autoBoundsModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			document.AutoBoundsMode = (AutoBoundsMode)autoBoundsModeComboBox.SelectedIndex;

			switch (document.AutoBoundsMode)
			{
				case AutoBoundsMode.CustomConstrained: 
				case AutoBoundsMode.CustomNonConstrained:
					customBoundsGroup.Enabled = true;
					minWidthTextBox.Enabled = false;
					minHeightTextBox.Enabled = false;
					sizeToContentButton.Enabled = true;
					inflateToContentButton.Enabled = true;
					break;
				case AutoBoundsMode.AutoInflateToContent:
					customBoundsGroup.Enabled = false;
					minWidthTextBox.Enabled = true;
					minHeightTextBox.Enabled = true;
					inflateToContentButton.Enabled = false;
					sizeToContentButton.Enabled = true;
					break;
				case AutoBoundsMode.AutoSizeToContent: 
					customBoundsGroup.Enabled = false;
					minWidthTextBox.Enabled = true;
					minHeightTextBox.Enabled = true;
					sizeToContentButton.Enabled = false;
					inflateToContentButton.Enabled = false;
					break;
			}
		}

		private void sizeToContentButton_Click(object sender, System.EventArgs e)
		{
			document.SizeToContent();
		}

		private void inflateToContentButton_Click(object sender, System.EventArgs e)
		{
			document.InflateToContent(); 
		}
        
		private void minWidthTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangeMinSize();
		}

		private void minHeightTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangeMinSize();
		}


		private void paddingTopTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangePadding();
		}

		private void paddingLeftTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangePadding();
		}

		private void paddingRightTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangePadding();
		}

		private void paddingBottomTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangePadding();
		}

		
		private void boundsXTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangeBounds();
		}

		private void boundsYTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangeBounds();
		}

		private void boundsWidthTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangeBounds();
		}

		private void boundsHeightTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ChangeBounds();
		}

		#endregion

		#region Designer Fields

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private Nevron.UI.WinForm.Controls.NComboBox autoBoundsModeComboBox;
		private Nevron.UI.WinForm.Controls.NTextBox boundsXTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox boundsWidthTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox boundsHeightTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox minWidthTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox minHeightTextBox;
		private Nevron.UI.WinForm.Controls.NButton inflateToContentButton;
		private Nevron.UI.WinForm.Controls.NButton sizeToContentButton;
		private Nevron.UI.WinForm.Controls.NTextBox paddingTopTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox paddingLeftTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox paddingRightTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox paddingBottomTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox boundsYTextBox;
		private Nevron.UI.WinForm.Controls.NGroupBox customBoundsGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox automaticBoundsGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox autoBoundsPaddingGroup;
		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
	}
}
