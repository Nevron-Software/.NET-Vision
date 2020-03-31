using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	public class NTabControlUC : NExampleUserControl
	{
		#region Constructor

		public NTabControlUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
		}


		#endregion

		#region Implementation

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
				m_DefRenderer.Dispose();
				m_CustomRenderer.Dispose();
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize ();

			m_XPBackgroundCheck.Checked = nTabControl1.DrawThemeBackground;

			m_TabStyleCombo.FillFromEnum(typeof(TabStyle), false);
			m_TabStyleCombo.SelectedItem = TabStyle.Standard;

			m_TabAlignCombo.FillFromEnum(typeof(TabAlign), false);
			m_TabAlignCombo.SelectedItem = TabAlign.Top;

			m_TextOrientationCombo.FillFromEnum(typeof(TextOrientation), false);
			m_TextOrientationCombo.SelectedItem = TextOrientation.Automatic;

			m_DefRenderer = new NTabControlRenderer(nTabControl1);
			m_CustomRenderer = new NCustomTabControlRenderer(nTabControl1);

			NListBoxItem item;

			item = new NListBoxItem(m_DefRenderer);
			item.Text = "Default Renderer";
			m_RenderersCombo.Items.Add(item);

			item = new NListBoxItem(m_CustomRenderer);
			item.Text = "Custom Renderer";
			m_RenderersCombo.Items.Add(item);
			m_RenderersCombo.SelectedIndex = 0;

			//nTabPage1.Text = "Long text tab page";
			nTabControl1.HasClose = true;
		}
		

		#endregion

		#region Event Handlers

		private void nComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.nTabControl1.TabAlign = (TabAlign)this.m_TabAlignCombo.SelectedIndex;
		}

		private void m_CurveWidth_ValueChanged(object sender, System.EventArgs e)
		{
			this.nTabControl1.TabCurveWidth = (int)m_CurveWidth.Value;
		}
		private void m_HotTrack_CheckedChanged(object sender, System.EventArgs e)
		{
			nTabControl1.HotTrack = m_HotTrack.Checked;
		}
		private void m_TabStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			nTabControl1.TabStyle = (TabStyle)this.m_TabStyleCombo.SelectedIndex;
		}
		private void nComboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			nTabControl1.TextOrientation = (TextOrientation)m_TextOrientationCombo.SelectedIndex;
		}

		private void m_RenderersCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_RenderersCombo.Items.Count == 0)
				return;
			try
			{
				NTabControlRenderer r = m_RenderersCombo.SelectedItem as NTabControlRenderer;
				if(r != null && r != nTabControl1.Renderer)
					nTabControl1.Renderer = r;
			}
			catch
			{
			}
		}

		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			nTabControl1.HasArrows = nCheckBox2.Checked;
		}
		private void nCheckBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			nTabControl1.HasClose = m_HasCloseCheck.Checked;
            m_ShowCloseOnEachTabCheck.Enabled = nTabControl1.HasClose;
		}

		private void nCheckBox4_CheckedChanged(object sender, System.EventArgs e)
		{
			nTabControl1.AllowTabReorder = m_AllowTabReorderCheck.Checked;
		}

		private void m_SelectableCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nTabControl1.Selectable = m_SelectableCheck.Checked;
		}

		private void m_ShowFocusRectCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nTabControl1.ShowFocusRect = m_ShowFocusRectCheck.Checked;
		}

		private void m_AddPageButton_Click(object sender, System.EventArgs e)
		{
			NTabPage page = new NTabPage();

			int index = nTabControl1.Controls.Count;
			//page.Text = "Tab Page " + nTabControl1.Controls.Count + "!!!!!";
			page.Text = "Tab &Page " + "1" + "!!!!!";

			int maxIndex = imageList1.Images.Count - 1;
			if(index > maxIndex)
				index = 0;

			page.ImageIndex = index;

			nTabControl1.TabPages.Add(page);
		}

		private void m_XPBackgroundCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nTabControl1.DrawThemeBackground = m_XPBackgroundCheck.Checked;
		}

		private void m_FontButton_Click(object sender, System.EventArgs e)
		{
			FontDialog dlg = new FontDialog();
			dlg.Font = this.nTabControl1.Font;
			if(dlg.ShowDialog() == DialogResult.OK)
				this.nTabControl1.Font = dlg.Font;
		}
        private void removePageButton_Click(object sender, EventArgs e)
        {
            this.nTabControl1.TabPages.RemoveAt(this.nTabControl1.SelectedIndex);
        }

        private void m_ShowCloseOnEachTabCheck_CheckStateChanged(object sender, System.EventArgs e)
        {
            this.nTabControl1.ShowCloseOnEachTab = m_ShowCloseOnEachTabCheck.Checked;
        }

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTabControlUC));
            this.nTabControl1 = new Nevron.UI.WinForm.Controls.NTabControl();
            this.nTabPage1 = new Nevron.UI.WinForm.Controls.NTabPage();
            this.nTabPage2 = new Nevron.UI.WinForm.Controls.NTabPage();
            this.nTabPage3 = new Nevron.UI.WinForm.Controls.NTabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
            this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.nColorBar1 = new Nevron.UI.WinForm.Controls.NColorBar();
            this.nColorButton1 = new Nevron.UI.WinForm.Controls.NColorButton();
            this.nColorPool1 = new Nevron.UI.WinForm.Controls.NColorPool();
            this.m_TabAlignCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_CurveWidth = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.m_HotTrack = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_TabStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.m_TextOrientationCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_RenderersCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.m_HasCloseCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.m_AllowTabReorderCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.m_SelectableCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.m_ShowFocusRectCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.m_AddPageButton = new Nevron.UI.WinForm.Controls.NButton();
            this.m_XPBackgroundCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.m_ShowCloseOnEachTabCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.m_FontButton = new Nevron.UI.WinForm.Controls.NButton();
            this.removePageButton = new Nevron.UI.WinForm.Controls.NButton();
            this.nTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_CurveWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // nTabControl1
            // 
            this.nTabControl1.Controls.Add(this.nTabPage1);
            this.nTabControl1.Controls.Add(this.nTabPage2);
            this.nTabControl1.Controls.Add(this.nTabPage3);
            this.nTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.nTabControl1.HasClose = true;
            this.nTabControl1.ImageList = this.imageList1;
            this.nTabControl1.Location = new System.Drawing.Point(10, 10);
            this.nTabControl1.Name = "nTabControl1";
            this.nTabControl1.Selectable = true;
            this.nTabControl1.SelectedIndex = 0;
            this.nTabControl1.Size = new System.Drawing.Size(708, 342);
            this.nTabControl1.TabIndex = 0;
            // 
            // nTabPage1
            // 
            this.nTabPage1.ImageIndex = 0;
            this.nTabPage1.Location = new System.Drawing.Point(4, 29);
            this.nTabPage1.Name = "nTabPage1";
            this.nTabPage1.Size = new System.Drawing.Size(700, 309);
            this.nTabPage1.TabIndex = 1;
            this.nTabPage1.Text = "nTabPage1";
            // 
            // nTabPage2
            // 
            this.nTabPage2.ImageIndex = 1;
            this.nTabPage2.Location = new System.Drawing.Point(4, 29);
            this.nTabPage2.Name = "nTabPage2";
            this.nTabPage2.Size = new System.Drawing.Size(700, 309);
            this.nTabPage2.TabIndex = 2;
            this.nTabPage2.Text = "nTabPage2";
            // 
            // nTabPage3
            // 
            this.nTabPage3.ImageIndex = 9;
            this.nTabPage3.Location = new System.Drawing.Point(4, 29);
            this.nTabPage3.Name = "nTabPage3";
            this.nTabPage3.Size = new System.Drawing.Size(700, 309);
            this.nTabPage3.TabIndex = 3;
            this.nTabPage3.Text = "nTabPage3";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // nButton1
            // 
            this.nButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nButton1.Location = new System.Drawing.Point(216, 136);
            this.nButton1.Name = "nButton1";
            this.nButton1.Size = new System.Drawing.Size(75, 23);
            this.nButton1.TabIndex = 4;
            this.nButton1.Text = "nButton1";
            // 
            // nCheckBox1
            // 
            this.nCheckBox1.ButtonProperties.BorderOffset = 2;
            this.nCheckBox1.Location = new System.Drawing.Point(112, 136);
            this.nCheckBox1.Name = "nCheckBox1";
            this.nCheckBox1.Size = new System.Drawing.Size(104, 24);
            this.nCheckBox1.TabIndex = 3;
            this.nCheckBox1.Text = "nCheckBox1";
            // 
            // nColorBar1
            // 
            this.nColorBar1.Location = new System.Drawing.Point(208, 8);
            this.nColorBar1.Name = "nColorBar1";
            this.nColorBar1.Size = new System.Drawing.Size(50, 112);
            this.nColorBar1.TabIndex = 2;
            this.nColorBar1.Text = "nColorBar1";
            // 
            // nColorButton1
            // 
            this.nColorButton1.ArrowClickOptions = false;
            this.nColorButton1.ArrowWidth = 14;
            this.nColorButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nColorButton1.Location = new System.Drawing.Point(8, 128);
            this.nColorButton1.Name = "nColorButton1";
            this.nColorButton1.Size = new System.Drawing.Size(75, 23);
            this.nColorButton1.TabIndex = 1;
            // 
            // nColorPool1
            // 
            this.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nColorPool1.Color = System.Drawing.Color.Empty;
            this.nColorPool1.Hue = 0F;
            this.nColorPool1.Location = new System.Drawing.Point(8, 8);
            this.nColorPool1.Luminance = 0.5F;
            this.nColorPool1.Name = "nColorPool1";
            this.nColorPool1.Saturation = 0F;
            this.nColorPool1.Size = new System.Drawing.Size(192, 112);
            this.nColorPool1.TabIndex = 0;
            // 
            // m_TabAlignCombo
            // 
            this.m_TabAlignCombo.Location = new System.Drawing.Point(112, 360);
            this.m_TabAlignCombo.Name = "m_TabAlignCombo";
            this.m_TabAlignCombo.Size = new System.Drawing.Size(152, 22);
            this.m_TabAlignCombo.TabIndex = 1;
            this.m_TabAlignCombo.Text = "nComboBox1";
            this.m_TabAlignCombo.SelectedIndexChanged += new System.EventHandler(this.nComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tab Align:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_CurveWidth
            // 
            this.m_CurveWidth.Location = new System.Drawing.Point(376, 360);
            this.m_CurveWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_CurveWidth.Name = "m_CurveWidth";
            this.m_CurveWidth.Size = new System.Drawing.Size(88, 20);
            this.m_CurveWidth.TabIndex = 3;
            this.m_CurveWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_CurveWidth.ValueChanged += new System.EventHandler(this.m_CurveWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(272, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tab Curve Width:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_HotTrack
            // 
            this.m_HotTrack.ButtonProperties.BorderOffset = 2;
            this.m_HotTrack.Checked = true;
            this.m_HotTrack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_HotTrack.Location = new System.Drawing.Point(112, 456);
            this.m_HotTrack.Name = "m_HotTrack";
            this.m_HotTrack.Size = new System.Drawing.Size(88, 24);
            this.m_HotTrack.TabIndex = 5;
            this.m_HotTrack.Text = "Hot &Track";
            this.m_HotTrack.CheckedChanged += new System.EventHandler(this.m_HotTrack_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tab Style:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_TabStyleCombo
            // 
            this.m_TabStyleCombo.Location = new System.Drawing.Point(112, 392);
            this.m_TabStyleCombo.Name = "m_TabStyleCombo";
            this.m_TabStyleCombo.Size = new System.Drawing.Size(152, 22);
            this.m_TabStyleCombo.TabIndex = 7;
            this.m_TabStyleCombo.Text = "nComboBox2";
            this.m_TabStyleCombo.SelectedIndexChanged += new System.EventHandler(this.m_TabStyleCombo_SelectedIndexChanged);
            // 
            // m_TextOrientationCombo
            // 
            this.m_TextOrientationCombo.Location = new System.Drawing.Point(112, 424);
            this.m_TextOrientationCombo.Name = "m_TextOrientationCombo";
            this.m_TextOrientationCombo.Size = new System.Drawing.Size(152, 22);
            this.m_TextOrientationCombo.TabIndex = 8;
            this.m_TextOrientationCombo.Text = "nComboBox2";
            this.m_TextOrientationCombo.SelectedIndexChanged += new System.EventHandler(this.nComboBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Text Orientation:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_RenderersCombo
            // 
            this.m_RenderersCombo.Location = new System.Drawing.Point(376, 384);
            this.m_RenderersCombo.Name = "m_RenderersCombo";
            this.m_RenderersCombo.Size = new System.Drawing.Size(184, 22);
            this.m_RenderersCombo.TabIndex = 12;
            this.m_RenderersCombo.Text = "nComboBox3";
            this.m_RenderersCombo.SelectedIndexChanged += new System.EventHandler(this.m_RenderersCombo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(272, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Select Renderer:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nCheckBox2
            // 
            this.nCheckBox2.ButtonProperties.BorderOffset = 2;
            this.nCheckBox2.Checked = true;
            this.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nCheckBox2.Location = new System.Drawing.Point(208, 456);
            this.nCheckBox2.Name = "nCheckBox2";
            this.nCheckBox2.Size = new System.Drawing.Size(88, 24);
            this.nCheckBox2.TabIndex = 14;
            this.nCheckBox2.Text = "Has &Arrows";
            this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
            // 
            // m_HasCloseCheck
            // 
            this.m_HasCloseCheck.ButtonProperties.BorderOffset = 2;
            this.m_HasCloseCheck.Checked = true;
            this.m_HasCloseCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_HasCloseCheck.Location = new System.Drawing.Point(336, 456);
            this.m_HasCloseCheck.Name = "m_HasCloseCheck";
            this.m_HasCloseCheck.Size = new System.Drawing.Size(88, 24);
            this.m_HasCloseCheck.TabIndex = 15;
            this.m_HasCloseCheck.Text = "Has &Close";
            this.m_HasCloseCheck.CheckedChanged += new System.EventHandler(this.nCheckBox3_CheckedChanged);
            // 
            // m_AllowTabReorderCheck
            // 
            this.m_AllowTabReorderCheck.ButtonProperties.BorderOffset = 2;
            this.m_AllowTabReorderCheck.Location = new System.Drawing.Point(208, 480);
            this.m_AllowTabReorderCheck.Name = "m_AllowTabReorderCheck";
            this.m_AllowTabReorderCheck.Size = new System.Drawing.Size(120, 24);
            this.m_AllowTabReorderCheck.TabIndex = 16;
            this.m_AllowTabReorderCheck.Text = "Allow Tab &Reorder";
            this.m_AllowTabReorderCheck.CheckedChanged += new System.EventHandler(this.nCheckBox4_CheckedChanged);
            // 
            // m_SelectableCheck
            // 
            this.m_SelectableCheck.ButtonProperties.BorderOffset = 2;
            this.m_SelectableCheck.Checked = true;
            this.m_SelectableCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_SelectableCheck.Location = new System.Drawing.Point(112, 480);
            this.m_SelectableCheck.Name = "m_SelectableCheck";
            this.m_SelectableCheck.Size = new System.Drawing.Size(80, 24);
            this.m_SelectableCheck.TabIndex = 17;
            this.m_SelectableCheck.Text = "Selectable";
            this.m_SelectableCheck.CheckedChanged += new System.EventHandler(this.m_SelectableCheck_CheckedChanged);
            // 
            // m_ShowFocusRectCheck
            // 
            this.m_ShowFocusRectCheck.ButtonProperties.BorderOffset = 2;
            this.m_ShowFocusRectCheck.Checked = true;
            this.m_ShowFocusRectCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ShowFocusRectCheck.Location = new System.Drawing.Point(336, 480);
            this.m_ShowFocusRectCheck.Name = "m_ShowFocusRectCheck";
            this.m_ShowFocusRectCheck.Size = new System.Drawing.Size(120, 24);
            this.m_ShowFocusRectCheck.TabIndex = 18;
            this.m_ShowFocusRectCheck.Text = "Show Focus Rect";
            this.m_ShowFocusRectCheck.CheckedChanged += new System.EventHandler(this.m_ShowFocusRectCheck_CheckedChanged);
            //
            // m_ShowCloseOnEachTabCheck
            //
            this.m_ShowCloseOnEachTabCheck.ButtonProperties.BorderOffset = 2;
            this.m_ShowCloseOnEachTabCheck.Checked = false;
            this.m_ShowCloseOnEachTabCheck.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.m_ShowCloseOnEachTabCheck.Location = new System.Drawing.Point(462, 480);
            this.m_ShowCloseOnEachTabCheck.Name = "m_ShowCloseOnEachTabCheck";
            this.m_ShowCloseOnEachTabCheck.Size = new System.Drawing.Size(180, 24);
            this.m_ShowCloseOnEachTabCheck.TabIndex = 19;
            this.m_ShowCloseOnEachTabCheck.Text = "Show Close Button on Each Tab";
            this.m_ShowCloseOnEachTabCheck.CheckStateChanged += new EventHandler(this.m_ShowCloseOnEachTabCheck_CheckStateChanged);
            // 
            // m_AddPageButton
            // 
            this.m_AddPageButton.Location = new System.Drawing.Point(112, 512);
            this.m_AddPageButton.Name = "m_AddPageButton";
            this.m_AddPageButton.Size = new System.Drawing.Size(91, 23);
            this.m_AddPageButton.TabIndex = 20;
            this.m_AddPageButton.Text = "Add Page";
            this.m_AddPageButton.Click += new System.EventHandler(this.m_AddPageButton_Click);
            // 
            // m_XPBackgroundCheck
            // 
            this.m_XPBackgroundCheck.ButtonProperties.BorderOffset = 2;
            this.m_XPBackgroundCheck.Location = new System.Drawing.Point(462, 456);
            this.m_XPBackgroundCheck.Name = "m_XPBackgroundCheck";
            this.m_XPBackgroundCheck.Size = new System.Drawing.Size(176, 24);
            this.m_XPBackgroundCheck.TabIndex = 21;
            this.m_XPBackgroundCheck.Text = "Render XP Background";
            this.m_XPBackgroundCheck.CheckedChanged += new System.EventHandler(this.m_XPBackgroundCheck_CheckedChanged);
            // 
            // m_FontButton
            // 
            this.m_FontButton.Location = new System.Drawing.Point(306, 512);
            this.m_FontButton.Name = "m_FontButton";
            this.m_FontButton.Size = new System.Drawing.Size(75, 23);
            this.m_FontButton.TabIndex = 22;
            this.m_FontButton.Text = "Font...";
            this.m_FontButton.Click += new System.EventHandler(this.m_FontButton_Click);
            // 
            // removePageButton
            // 
            this.removePageButton.Location = new System.Drawing.Point(209, 512);
            this.removePageButton.Name = "removePageButton";
            this.removePageButton.Size = new System.Drawing.Size(91, 23);
            this.removePageButton.TabIndex = 23;
            this.removePageButton.Text = "Remove Page";
            this.removePageButton.Click += new System.EventHandler(this.removePageButton_Click);
            // 
            // NTabControlUC
            // 
            this.Controls.Add(this.removePageButton);
            this.Controls.Add(this.m_FontButton);
            this.Controls.Add(this.m_XPBackgroundCheck);
            this.Controls.Add(this.m_AddPageButton);
            this.Controls.Add(this.m_ShowFocusRectCheck);
            this.Controls.Add(this.m_SelectableCheck);
            this.Controls.Add(this.m_AllowTabReorderCheck);
            this.Controls.Add(this.m_HasCloseCheck);
            this.Controls.Add(this.nCheckBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_RenderersCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_TextOrientationCombo);
            this.Controls.Add(this.m_TabStyleCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_HotTrack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_CurveWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_TabAlignCombo);
            this.Controls.Add(this.nTabControl1);
            this.Controls.Add(this.m_ShowCloseOnEachTabCheck);
            this.Name = "NTabControlUC";
            this.DockPadding.All = 10;
            this.Size = new System.Drawing.Size(728, 552);
            this.nTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_CurveWidth)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NTabControl nTabControl1;
		private System.Windows.Forms.ImageList imageList1;
		private Nevron.UI.WinForm.Controls.NColorPool nColorPool1;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton1;
		private Nevron.UI.WinForm.Controls.NColorBar nColorBar1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_CurveWidth;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NCheckBox m_HotTrack;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox m_TabStyleCombo;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox m_RenderersCombo;
		private System.Windows.Forms.Label label6;
		private System.ComponentModel.IContainer components;

		internal NTabControlRenderer m_DefRenderer;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox m_SelectableCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowFocusRectCheck;
		private Nevron.UI.WinForm.Controls.NComboBox m_TabAlignCombo;
		private Nevron.UI.WinForm.Controls.NComboBox m_TextOrientationCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox m_HasCloseCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_AllowTabReorderCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox m_ShowCloseOnEachTabCheck;
		private Nevron.UI.WinForm.Controls.NTabPage nTabPage1;
		private Nevron.UI.WinForm.Controls.NTabPage nTabPage2;
		private Nevron.UI.WinForm.Controls.NTabPage nTabPage3;
		private Nevron.UI.WinForm.Controls.NButton m_AddPageButton;
		private Nevron.UI.WinForm.Controls.NCheckBox m_XPBackgroundCheck;
		private Nevron.UI.WinForm.Controls.NButton m_FontButton;
        private NButton removePageButton;
		internal NCustomTabControlRenderer m_CustomRenderer;


		#endregion
	}

	public class NCustomTabControlRenderer : NTabControlRenderer
	{
		public NCustomTabControlRenderer(NTabControl tab) : base(tab)
		{
		}

		#region Overrides

		protected override void DrawTabBackground(Graphics g)
		{
			Brush.Color = m_Tab.Selected ? Color.Chocolate : Color.Silver;
			if(m_Tab.Hovered)
				Brush.Color = Color.BlanchedAlmond;
			g.FillRectangle(Brush, m_TabBounds);
		}
		protected override void DrawTabWinDefBackground(Graphics g)
		{
			Brush.Color = m_Tab.Selected ? Color.Chocolate : Color.Silver;
			if(m_Tab.Hovered)
				Brush.Color = Color.BlanchedAlmond;
			g.FillRectangle(Brush, m_TabBounds);
		}

		protected override void DrawTabBorder(Graphics g)
		{
			Pen.Color = Color.Black;
			g.DrawRectangle(Pen, m_TabBounds);
		}


		#endregion
	}
}
