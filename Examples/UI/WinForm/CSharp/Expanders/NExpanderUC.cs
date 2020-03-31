using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NExpanderUC.
	/// </summary>
	public class NExpanderUC : NExampleUserControl
	{
		#region Constructor

		public NExpanderUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		public override void Initialize()
		{
			base.Initialize ();
		}



		#endregion

		#region Event Handlers

		private void m_AnimateCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NExpander ex;

			foreach(Control c in this.Controls)
			{
				ex = c as NExpander;
				if(ex == null)
					continue;

				ex.Animate = m_AnimateCheck.Checked;
			}
		}

		private void m_DrawBorderCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NExpander ex;

			foreach(Control c in this.Controls)
			{
				ex = c as NExpander;
				if(ex == null)
					continue;

				ex.DrawBorder = m_DrawBorderCheck.Checked;
			}
		}
		private void m_FocusRectCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NExpander ex;

			foreach(Control c in this.Controls)
			{
				ex = c as NExpander;
				if(ex == null)
					continue;

				ex.FocusRect = m_FocusRectCheck.Checked;
			}
		}
		private void m_CollapseButton_Click(object sender, System.EventArgs e)
		{
			m_PrefferedState = ExpanderState.Collapsed;

			nExpander1.State = m_PrefferedState;
			nExpander2.State = m_PrefferedState;
			nExpander3.State = m_PrefferedState;
		}

		private void m_ExpandButton_Click(object sender, System.EventArgs e)
		{
			m_PrefferedState = ExpanderState.Expanded;

			nExpander1.State = m_PrefferedState;
			nExpander2.State = m_PrefferedState;
			nExpander3.State = m_PrefferedState;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NExpanderUC));
			this.nExpander1 = new Nevron.UI.WinForm.Controls.NExpander();
			this.linkLabel8 = new System.Windows.Forms.LinkLabel();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.nExpander2 = new Nevron.UI.WinForm.Controls.NExpander();
			this.linkLabel7 = new System.Windows.Forms.LinkLabel();
			this.linkLabel4 = new System.Windows.Forms.LinkLabel();
			this.linkLabel5 = new System.Windows.Forms.LinkLabel();
			this.linkLabel6 = new System.Windows.Forms.LinkLabel();
			this.nExpander3 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nhScrollBar1 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nProgressBar1 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nLuminanceBar1 = new Nevron.UI.WinForm.Controls.NLuminanceBar();
			this.nColorButton1 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.m_AnimateCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_CollapseButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ExpandButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_DrawBorderCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_FocusRectCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).BeginInit();
			this.nExpander1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).BeginInit();
			this.nExpander2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander3)).BeginInit();
			this.nExpander3.SuspendLayout();
			this.SuspendLayout();
			// 
			// nExpander1
			// 
			this.nExpander1.BackColor = System.Drawing.Color.Transparent;
			this.nExpander1.Controls.Add(this.linkLabel8);
			this.nExpander1.Controls.Add(this.linkLabel3);
			this.nExpander1.Controls.Add(this.linkLabel2);
			this.nExpander1.Controls.Add(this.linkLabel1);
			this.nExpander1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander1.HeaderImage")));
			this.nExpander1.HeaderImageSize = new System.Drawing.Size(24, 24);
			this.nExpander1.Location = new System.Drawing.Point(8, 8);
			this.nExpander1.Name = "nExpander1";
			this.nExpander1.Size = new System.Drawing.Size(216, 136);
			this.nExpander1.TabIndex = 0;
			this.nExpander1.Text = "nExpander1";
			// 
			// linkLabel8
			// 
			this.linkLabel8.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel8.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel8.Image")));
			this.linkLabel8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel8.Location = new System.Drawing.Point(8, 104);
			this.linkLabel8.Name = "linkLabel8";
			this.linkLabel8.Size = new System.Drawing.Size(88, 24);
			this.linkLabel8.TabIndex = 4;
			this.linkLabel8.TabStop = true;
			this.linkLabel8.Text = "Shortcuts";
			this.linkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel3
			// 
			this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel3.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel3.Image")));
			this.linkLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel3.Location = new System.Drawing.Point(8, 80);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(80, 24);
			this.linkLabel3.TabIndex = 2;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Folders";
			this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel2
			// 
			this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel2.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel2.Image")));
			this.linkLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel2.Location = new System.Drawing.Point(8, 56);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(104, 24);
			this.linkLabel2.TabIndex = 1;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "More Tasks";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel1
			// 
			this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel1.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel1.Image")));
			this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.Location = new System.Drawing.Point(8, 32);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(80, 24);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Tasks";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nExpander2
			// 
			this.nExpander2.BackColor = System.Drawing.Color.Transparent;
			this.nExpander2.Controls.Add(this.linkLabel7);
			this.nExpander2.Controls.Add(this.linkLabel4);
			this.nExpander2.Controls.Add(this.linkLabel5);
			this.nExpander2.Controls.Add(this.linkLabel6);
			this.nExpander2.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander2.HeaderImage")));
			this.nExpander2.HeaderImageSize = new System.Drawing.Size(28, 28);
			this.nExpander2.Location = new System.Drawing.Point(8, 160);
			this.nExpander2.Name = "nExpander2";
			this.nExpander2.Size = new System.Drawing.Size(216, 136);
			this.nExpander2.TabIndex = 1;
			this.nExpander2.Text = "nExpander2";
			// 
			// linkLabel7
			// 
			this.linkLabel7.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel7.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel7.Image")));
			this.linkLabel7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel7.Location = new System.Drawing.Point(8, 104);
			this.linkLabel7.Name = "linkLabel7";
			this.linkLabel7.Size = new System.Drawing.Size(88, 24);
			this.linkLabel7.TabIndex = 3;
			this.linkLabel7.TabStop = true;
			this.linkLabel7.Text = "Shortcuts";
			this.linkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel4
			// 
			this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel4.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel4.Image")));
			this.linkLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel4.Location = new System.Drawing.Point(8, 80);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new System.Drawing.Size(80, 24);
			this.linkLabel4.TabIndex = 2;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Text = "Folders";
			this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel5
			// 
			this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel5.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel5.Image")));
			this.linkLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel5.Location = new System.Drawing.Point(8, 56);
			this.linkLabel5.Name = "linkLabel5";
			this.linkLabel5.Size = new System.Drawing.Size(104, 24);
			this.linkLabel5.TabIndex = 1;
			this.linkLabel5.TabStop = true;
			this.linkLabel5.Text = "More Tasks";
			this.linkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel6
			// 
			this.linkLabel6.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel6.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel6.Image")));
			this.linkLabel6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel6.Location = new System.Drawing.Point(8, 32);
			this.linkLabel6.Name = "linkLabel6";
			this.linkLabel6.Size = new System.Drawing.Size(80, 24);
			this.linkLabel6.TabIndex = 0;
			this.linkLabel6.TabStop = true;
			this.linkLabel6.Text = "Tasks";
			this.linkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nExpander3
			// 
			this.nExpander3.BackColor = System.Drawing.Color.Transparent;
			this.nExpander3.Controls.Add(this.nhScrollBar1);
			this.nExpander3.Controls.Add(this.nProgressBar1);
			this.nExpander3.Controls.Add(this.nLuminanceBar1);
			this.nExpander3.Controls.Add(this.nColorButton1);
			this.nExpander3.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander3.HeaderImage")));
			this.nExpander3.HeaderImageSize = new System.Drawing.Size(28, 28);
			this.nExpander3.Location = new System.Drawing.Point(232, 8);
			this.nExpander3.Name = "nExpander3";
			this.nExpander3.Size = new System.Drawing.Size(216, 288);
			this.nExpander3.TabIndex = 2;
			this.nExpander3.Text = "nExpander3";
			// 
			// nhScrollBar1
			// 
			this.nhScrollBar1.Location = new System.Drawing.Point(8, 232);
			this.nhScrollBar1.Name = "nhScrollBar1";
			this.nhScrollBar1.Size = new System.Drawing.Size(192, 17);
			this.nhScrollBar1.TabIndex = 4;
			this.nhScrollBar1.Text = "nhScrollBar1";
			// 
			// nProgressBar1
			// 
			this.nProgressBar1.Location = new System.Drawing.Point(8, 176);
			this.nProgressBar1.Name = "nProgressBar1";
			this.nProgressBar1.Size = new System.Drawing.Size(192, 16);
			this.nProgressBar1.TabIndex = 3;
			this.nProgressBar1.Text = "nProgressBar1";
			// 
			// nLuminanceBar1
			// 
			this.nLuminanceBar1.Location = new System.Drawing.Point(8, 120);
			this.nLuminanceBar1.Name = "nLuminanceBar1";
			this.nLuminanceBar1.Size = new System.Drawing.Size(184, 24);
			this.nLuminanceBar1.TabIndex = 2;
			this.nLuminanceBar1.Text = "nLuminanceBar1";
			// 
			// nColorButton1
			// 
			this.nColorButton1.ArrowClickOptions = false;
			this.nColorButton1.ArrowWidth = 14;
			this.nColorButton1.Location = new System.Drawing.Point(8, 72);
			this.nColorButton1.Name = "nColorButton1";
			this.nColorButton1.Size = new System.Drawing.Size(88, 23);
			this.nColorButton1.TabIndex = 1;
			// 
			// m_AnimateCheck
			// 
			this.m_AnimateCheck.ButtonProperties.BorderOffset = 2;
			this.m_AnimateCheck.Checked = true;
			this.m_AnimateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_AnimateCheck.Location = new System.Drawing.Point(8, 312);
			this.m_AnimateCheck.Name = "m_AnimateCheck";
			this.m_AnimateCheck.TabIndex = 3;
			this.m_AnimateCheck.Text = "Animate";
			this.m_AnimateCheck.CheckedChanged += new System.EventHandler(this.m_AnimateCheck_CheckedChanged);
			// 
			// m_CollapseButton
			// 
			this.m_CollapseButton.Location = new System.Drawing.Point(8, 344);
			this.m_CollapseButton.Name = "m_CollapseButton";
			this.m_CollapseButton.Size = new System.Drawing.Size(80, 24);
			this.m_CollapseButton.TabIndex = 4;
			this.m_CollapseButton.Text = "Collapse All";
			this.m_CollapseButton.Click += new System.EventHandler(this.m_CollapseButton_Click);
			// 
			// m_ExpandButton
			// 
			this.m_ExpandButton.Location = new System.Drawing.Point(96, 344);
			this.m_ExpandButton.Name = "m_ExpandButton";
			this.m_ExpandButton.Size = new System.Drawing.Size(80, 24);
			this.m_ExpandButton.TabIndex = 5;
			this.m_ExpandButton.Text = "Expand All";
			this.m_ExpandButton.Click += new System.EventHandler(this.m_ExpandButton_Click);
			// 
			// m_DrawBorderCheck
			// 
			this.m_DrawBorderCheck.ButtonProperties.BorderOffset = 2;
			this.m_DrawBorderCheck.Location = new System.Drawing.Point(112, 312);
			this.m_DrawBorderCheck.Name = "m_DrawBorderCheck";
			this.m_DrawBorderCheck.TabIndex = 6;
			this.m_DrawBorderCheck.Text = "Draw Border";
			this.m_DrawBorderCheck.CheckedChanged += new System.EventHandler(this.m_DrawBorderCheck_CheckedChanged);
			// 
			// m_FocusRectCheck
			// 
			this.m_FocusRectCheck.ButtonProperties.BorderOffset = 2;
			this.m_FocusRectCheck.Checked = true;
			this.m_FocusRectCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_FocusRectCheck.Location = new System.Drawing.Point(216, 312);
			this.m_FocusRectCheck.Name = "m_FocusRectCheck";
			this.m_FocusRectCheck.TabIndex = 7;
			this.m_FocusRectCheck.Text = "Focus Rect";
			this.m_FocusRectCheck.CheckedChanged += new System.EventHandler(this.m_FocusRectCheck_CheckedChanged);
			// 
			// NExpanderUC
			// 
			this.Controls.Add(this.m_FocusRectCheck);
			this.Controls.Add(this.m_DrawBorderCheck);
			this.Controls.Add(this.m_ExpandButton);
			this.Controls.Add(this.m_CollapseButton);
			this.Controls.Add(this.m_AnimateCheck);
			this.Controls.Add(this.nExpander3);
			this.Controls.Add(this.nExpander2);
			this.Controls.Add(this.nExpander1);
			this.Name = "NExpanderUC";
			this.Size = new System.Drawing.Size(456, 368);
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).EndInit();
			this.nExpander1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).EndInit();
			this.nExpander2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander3)).EndInit();
			this.nExpander3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal ExpanderState m_PrefferedState;

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private Nevron.UI.WinForm.Controls.NExpander nExpander2;
		private System.Windows.Forms.LinkLabel linkLabel4;
		private System.Windows.Forms.LinkLabel linkLabel5;
		private System.Windows.Forms.LinkLabel linkLabel6;
		private System.Windows.Forms.LinkLabel linkLabel7;
		private System.Windows.Forms.LinkLabel linkLabel8;
		private Nevron.UI.WinForm.Controls.NExpander nExpander3;
		private Nevron.UI.WinForm.Controls.NCheckBox m_AnimateCheck;
		private Nevron.UI.WinForm.Controls.NButton m_CollapseButton;
		private Nevron.UI.WinForm.Controls.NButton m_ExpandButton;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton1;
		private Nevron.UI.WinForm.Controls.NLuminanceBar nLuminanceBar1;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar1;
		private Nevron.UI.WinForm.Controls.NHScrollBar nhScrollBar1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_DrawBorderCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_FocusRectCheck;
		private Nevron.UI.WinForm.Controls.NExpander nExpander1;

		#endregion
	}
}
