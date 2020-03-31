using System;
using System.Diagnostics;
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
	/// Summary description for NExplorerBarUC.
	/// </summary>
	public class NExplorerBarUC : NExampleUserControl
	{
		#region Constructor

		public NExplorerBarUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
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


		#endregion

		#region Event Handlers

		private void m_ScrollableCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			bool scrollable = m_ScrollableCheck.Checked;

			nExplorerBar1.Scrollable = scrollable;
			nExplorerBar2.Scrollable = scrollable;
		}

		private void linkLabel19_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.glyfz.com/");
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NExplorerBarUC));
			this.nExplorerBar1 = new Nevron.UI.WinForm.Controls.NExplorerBar();
			this.nExpander3 = new Nevron.UI.WinForm.Controls.NExpander();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.nExpander2 = new Nevron.UI.WinForm.Controls.NExpander();
			this.linkLabel4 = new System.Windows.Forms.LinkLabel();
			this.linkLabel5 = new System.Windows.Forms.LinkLabel();
			this.linkLabel6 = new System.Windows.Forms.LinkLabel();
			this.nExpander1 = new Nevron.UI.WinForm.Controls.NExpander();
			this.linkLabel7 = new System.Windows.Forms.LinkLabel();
			this.linkLabel8 = new System.Windows.Forms.LinkLabel();
			this.linkLabel9 = new System.Windows.Forms.LinkLabel();
			this.nExplorerBar2 = new Nevron.UI.WinForm.Controls.NExplorerBar();
			this.nExpander4 = new Nevron.UI.WinForm.Controls.NExpander();
			this.linkLabel10 = new System.Windows.Forms.LinkLabel();
			this.linkLabel11 = new System.Windows.Forms.LinkLabel();
			this.linkLabel12 = new System.Windows.Forms.LinkLabel();
			this.nExpander5 = new Nevron.UI.WinForm.Controls.NExpander();
			this.linkLabel13 = new System.Windows.Forms.LinkLabel();
			this.linkLabel14 = new System.Windows.Forms.LinkLabel();
			this.linkLabel15 = new System.Windows.Forms.LinkLabel();
			this.nExpander6 = new Nevron.UI.WinForm.Controls.NExpander();
			this.linkLabel16 = new System.Windows.Forms.LinkLabel();
			this.linkLabel17 = new System.Windows.Forms.LinkLabel();
			this.linkLabel18 = new System.Windows.Forms.LinkLabel();
			this.m_ScrollableCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.linkLabel19 = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar1)).BeginInit();
			this.nExplorerBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander3)).BeginInit();
			this.nExpander3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).BeginInit();
			this.nExpander2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).BeginInit();
			this.nExpander1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar2)).BeginInit();
			this.nExplorerBar2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander4)).BeginInit();
			this.nExpander4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander5)).BeginInit();
			this.nExpander5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander6)).BeginInit();
			this.nExpander6.SuspendLayout();
			this.SuspendLayout();
			// 
			// nExplorerBar1
			// 
			this.nExplorerBar1.ClientPadding = new Nevron.UI.NPadding(8);
			this.nExplorerBar1.Controls.Add(this.nExpander3);
			this.nExplorerBar1.Controls.Add(this.nExpander2);
			this.nExplorerBar1.Controls.Add(this.nExpander1);
			this.nExplorerBar1.Location = new System.Drawing.Point(8, 8);
			this.nExplorerBar1.Name = "nExplorerBar1";
			this.nExplorerBar1.Size = new System.Drawing.Size(232, 424);
			this.nExplorerBar1.TabIndex = 0;
			this.nExplorerBar1.Text = "nExplorerBar1";
			// 
			// nExpander3
			// 
			this.nExpander3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander3.Controls.Add(this.linkLabel3);
			this.nExpander3.Controls.Add(this.linkLabel2);
			this.nExpander3.Controls.Add(this.linkLabel1);
			this.nExpander3.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander3.HeaderImage")));
			this.nExpander3.HeaderImageSize = new System.Drawing.Size(28, 28);
			this.nExpander3.Location = new System.Drawing.Point(8, 8);
			this.nExpander3.Name = "nExpander3";
			this.nExpander3.Size = new System.Drawing.Size(216, 112);
			this.nExpander3.TabIndex = 3;
			this.nExpander3.Text = "System Tasks";
			// 
			// linkLabel3
			// 
			this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel3.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel3.Image")));
			this.linkLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel3.Location = new System.Drawing.Point(8, 80);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(128, 23);
			this.linkLabel3.TabIndex = 2;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Change a setting";
			this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel2
			// 
			this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel2.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel2.Image")));
			this.linkLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel2.Location = new System.Drawing.Point(8, 56);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(160, 23);
			this.linkLabel2.TabIndex = 1;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Add or remove programs";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel1
			// 
			this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel1.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel1.Image")));
			this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.Location = new System.Drawing.Point(8, 32);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(160, 23);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "View system information";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nExpander2
			// 
			this.nExpander2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander2.Controls.Add(this.linkLabel4);
			this.nExpander2.Controls.Add(this.linkLabel5);
			this.nExpander2.Controls.Add(this.linkLabel6);
			this.nExpander2.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander2.HeaderImage")));
			this.nExpander2.HeaderImageSize = new System.Drawing.Size(28, 28);
			this.nExpander2.Location = new System.Drawing.Point(8, 128);
			this.nExpander2.Name = "nExpander2";
			this.nExpander2.Size = new System.Drawing.Size(216, 112);
			this.nExpander2.TabIndex = 2;
			this.nExpander2.Text = "Other Places";
			// 
			// linkLabel4
			// 
			this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel4.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel4.Image")));
			this.linkLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel4.Location = new System.Drawing.Point(8, 80);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new System.Drawing.Size(128, 23);
			this.linkLabel4.TabIndex = 5;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Text = "Change a setting";
			this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel5
			// 
			this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel5.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel5.Image")));
			this.linkLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel5.Location = new System.Drawing.Point(8, 56);
			this.linkLabel5.Name = "linkLabel5";
			this.linkLabel5.Size = new System.Drawing.Size(160, 23);
			this.linkLabel5.TabIndex = 4;
			this.linkLabel5.TabStop = true;
			this.linkLabel5.Text = "Add or remove programs";
			this.linkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel6
			// 
			this.linkLabel6.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel6.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel6.Image")));
			this.linkLabel6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel6.Location = new System.Drawing.Point(8, 32);
			this.linkLabel6.Name = "linkLabel6";
			this.linkLabel6.Size = new System.Drawing.Size(160, 23);
			this.linkLabel6.TabIndex = 3;
			this.linkLabel6.TabStop = true;
			this.linkLabel6.Text = "View system information";
			this.linkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nExpander1
			// 
			this.nExpander1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander1.Controls.Add(this.linkLabel7);
			this.nExpander1.Controls.Add(this.linkLabel8);
			this.nExpander1.Controls.Add(this.linkLabel9);
			this.nExpander1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander1.HeaderImage")));
			this.nExpander1.Location = new System.Drawing.Point(8, 248);
			this.nExpander1.Name = "nExpander1";
			this.nExpander1.Size = new System.Drawing.Size(216, 112);
			this.nExpander1.TabIndex = 1;
			this.nExpander1.Text = "Details";
			// 
			// linkLabel7
			// 
			this.linkLabel7.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel7.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel7.Image")));
			this.linkLabel7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel7.Location = new System.Drawing.Point(8, 77);
			this.linkLabel7.Name = "linkLabel7";
			this.linkLabel7.Size = new System.Drawing.Size(128, 23);
			this.linkLabel7.TabIndex = 5;
			this.linkLabel7.TabStop = true;
			this.linkLabel7.Text = "Change a setting";
			this.linkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel8
			// 
			this.linkLabel8.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel8.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel8.Image")));
			this.linkLabel8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel8.Location = new System.Drawing.Point(8, 53);
			this.linkLabel8.Name = "linkLabel8";
			this.linkLabel8.Size = new System.Drawing.Size(160, 23);
			this.linkLabel8.TabIndex = 4;
			this.linkLabel8.TabStop = true;
			this.linkLabel8.Text = "Add or remove programs";
			this.linkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel9
			// 
			this.linkLabel9.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel9.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel9.Image")));
			this.linkLabel9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel9.Location = new System.Drawing.Point(8, 29);
			this.linkLabel9.Name = "linkLabel9";
			this.linkLabel9.Size = new System.Drawing.Size(160, 23);
			this.linkLabel9.TabIndex = 3;
			this.linkLabel9.TabStop = true;
			this.linkLabel9.Text = "View system information";
			this.linkLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nExplorerBar2
			// 
			this.nExplorerBar2.ClientPadding = new Nevron.UI.NPadding(8);
			this.nExplorerBar2.Controls.Add(this.nExpander4);
			this.nExplorerBar2.Controls.Add(this.nExpander5);
			this.nExplorerBar2.Controls.Add(this.nExpander6);
			this.nExplorerBar2.Location = new System.Drawing.Point(248, 8);
			this.nExplorerBar2.Name = "nExplorerBar2";
			this.nExplorerBar2.Size = new System.Drawing.Size(224, 424);
			this.nExplorerBar2.TabIndex = 1;
			this.nExplorerBar2.Text = "nExplorerBar2";
			// 
			// nExpander4
			// 
			this.nExpander4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander4.Controls.Add(this.linkLabel10);
			this.nExpander4.Controls.Add(this.linkLabel11);
			this.nExpander4.Controls.Add(this.linkLabel12);
			this.nExpander4.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander4.HeaderImage")));
			this.nExpander4.HeaderImageSize = new System.Drawing.Size(28, 28);
			this.nExpander4.Location = new System.Drawing.Point(8, 8);
			this.nExpander4.Name = "nExpander4";
			this.nExpander4.Size = new System.Drawing.Size(208, 112);
			this.nExpander4.TabIndex = 3;
			this.nExpander4.Text = "System Tasks";
			// 
			// linkLabel10
			// 
			this.linkLabel10.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel10.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel10.Image")));
			this.linkLabel10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel10.Location = new System.Drawing.Point(8, 80);
			this.linkLabel10.Name = "linkLabel10";
			this.linkLabel10.Size = new System.Drawing.Size(128, 23);
			this.linkLabel10.TabIndex = 2;
			this.linkLabel10.TabStop = true;
			this.linkLabel10.Text = "Change a setting";
			this.linkLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel11
			// 
			this.linkLabel11.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel11.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel11.Image")));
			this.linkLabel11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel11.Location = new System.Drawing.Point(8, 56);
			this.linkLabel11.Name = "linkLabel11";
			this.linkLabel11.Size = new System.Drawing.Size(160, 23);
			this.linkLabel11.TabIndex = 1;
			this.linkLabel11.TabStop = true;
			this.linkLabel11.Text = "Add or remove programs";
			this.linkLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel12
			// 
			this.linkLabel12.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel12.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel12.Image")));
			this.linkLabel12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel12.Location = new System.Drawing.Point(8, 32);
			this.linkLabel12.Name = "linkLabel12";
			this.linkLabel12.Size = new System.Drawing.Size(160, 23);
			this.linkLabel12.TabIndex = 0;
			this.linkLabel12.TabStop = true;
			this.linkLabel12.Text = "View system information";
			this.linkLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nExpander5
			// 
			this.nExpander5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander5.Controls.Add(this.linkLabel13);
			this.nExpander5.Controls.Add(this.linkLabel14);
			this.nExpander5.Controls.Add(this.linkLabel15);
			this.nExpander5.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander5.HeaderImage")));
			this.nExpander5.HeaderImageSize = new System.Drawing.Size(28, 28);
			this.nExpander5.Location = new System.Drawing.Point(8, 128);
			this.nExpander5.Name = "nExpander5";
			this.nExpander5.Size = new System.Drawing.Size(208, 112);
			this.nExpander5.TabIndex = 2;
			this.nExpander5.Text = "Other Places";
			// 
			// linkLabel13
			// 
			this.linkLabel13.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel13.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel13.Image")));
			this.linkLabel13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel13.Location = new System.Drawing.Point(8, 80);
			this.linkLabel13.Name = "linkLabel13";
			this.linkLabel13.Size = new System.Drawing.Size(128, 23);
			this.linkLabel13.TabIndex = 5;
			this.linkLabel13.TabStop = true;
			this.linkLabel13.Text = "Change a setting";
			this.linkLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel14
			// 
			this.linkLabel14.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel14.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel14.Image")));
			this.linkLabel14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel14.Location = new System.Drawing.Point(8, 56);
			this.linkLabel14.Name = "linkLabel14";
			this.linkLabel14.Size = new System.Drawing.Size(160, 23);
			this.linkLabel14.TabIndex = 4;
			this.linkLabel14.TabStop = true;
			this.linkLabel14.Text = "Add or remove programs";
			this.linkLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel15
			// 
			this.linkLabel15.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel15.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel15.Image")));
			this.linkLabel15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel15.Location = new System.Drawing.Point(8, 32);
			this.linkLabel15.Name = "linkLabel15";
			this.linkLabel15.Size = new System.Drawing.Size(160, 23);
			this.linkLabel15.TabIndex = 3;
			this.linkLabel15.TabStop = true;
			this.linkLabel15.Text = "View system information";
			this.linkLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nExpander6
			// 
			this.nExpander6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander6.Controls.Add(this.linkLabel16);
			this.nExpander6.Controls.Add(this.linkLabel17);
			this.nExpander6.Controls.Add(this.linkLabel18);
			this.nExpander6.HeaderImage = ((System.Drawing.Image)(resources.GetObject("nExpander6.HeaderImage")));
			this.nExpander6.Location = new System.Drawing.Point(8, 248);
			this.nExpander6.Name = "nExpander6";
			this.nExpander6.Size = new System.Drawing.Size(208, 112);
			this.nExpander6.TabIndex = 1;
			this.nExpander6.Text = "Details";
			// 
			// linkLabel16
			// 
			this.linkLabel16.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel16.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel16.Image")));
			this.linkLabel16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel16.Location = new System.Drawing.Point(8, 77);
			this.linkLabel16.Name = "linkLabel16";
			this.linkLabel16.Size = new System.Drawing.Size(128, 23);
			this.linkLabel16.TabIndex = 5;
			this.linkLabel16.TabStop = true;
			this.linkLabel16.Text = "Change a setting";
			this.linkLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel17
			// 
			this.linkLabel17.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel17.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel17.Image")));
			this.linkLabel17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel17.Location = new System.Drawing.Point(8, 53);
			this.linkLabel17.Name = "linkLabel17";
			this.linkLabel17.Size = new System.Drawing.Size(160, 23);
			this.linkLabel17.TabIndex = 4;
			this.linkLabel17.TabStop = true;
			this.linkLabel17.Text = "Add or remove programs";
			this.linkLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel18
			// 
			this.linkLabel18.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel18.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel18.Image")));
			this.linkLabel18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel18.Location = new System.Drawing.Point(8, 29);
			this.linkLabel18.Name = "linkLabel18";
			this.linkLabel18.Size = new System.Drawing.Size(160, 23);
			this.linkLabel18.TabIndex = 3;
			this.linkLabel18.TabStop = true;
			this.linkLabel18.Text = "View system information";
			this.linkLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_ScrollableCheck
			// 
			this.m_ScrollableCheck.ButtonProperties.BorderOffset = 2;
			this.m_ScrollableCheck.Checked = true;
			this.m_ScrollableCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ScrollableCheck.Location = new System.Drawing.Point(488, 8);
			this.m_ScrollableCheck.Name = "m_ScrollableCheck";
			this.m_ScrollableCheck.TabIndex = 2;
			this.m_ScrollableCheck.Text = "Scrollable";
			this.m_ScrollableCheck.CheckedChanged += new System.EventHandler(this.m_ScrollableCheck_CheckedChanged);
			// 
			// linkLabel19
			// 
			this.linkLabel19.Location = new System.Drawing.Point(488, 64);
			this.linkLabel19.Name = "linkLabel19";
			this.linkLabel19.Size = new System.Drawing.Size(120, 23);
			this.linkLabel19.TabIndex = 7;
			this.linkLabel19.TabStop = true;
			this.linkLabel19.Text = "http://www.glyfz.com/";
			this.linkLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel19.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel19_LinkClicked);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(488, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 24);
			this.label1.TabIndex = 6;
			this.label1.Text = "Sample images used from:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NExplorerBarUC
			// 
			this.Controls.Add(this.linkLabel19);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_ScrollableCheck);
			this.Controls.Add(this.nExplorerBar2);
			this.Controls.Add(this.nExplorerBar1);
			this.Name = "NExplorerBarUC";
			this.Size = new System.Drawing.Size(640, 440);
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar1)).EndInit();
			this.nExplorerBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander3)).EndInit();
			this.nExpander3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).EndInit();
			this.nExpander2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).EndInit();
			this.nExpander1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar2)).EndInit();
			this.nExplorerBar2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander4)).EndInit();
			this.nExpander4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander5)).EndInit();
			this.nExpander5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander6)).EndInit();
			this.nExpander6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NExplorerBar nExplorerBar1;
		private Nevron.UI.WinForm.Controls.NExpander nExpander1;
		private Nevron.UI.WinForm.Controls.NExpander nExpander2;
		private Nevron.UI.WinForm.Controls.NExpander nExpander3;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.LinkLabel linkLabel4;
		private System.Windows.Forms.LinkLabel linkLabel5;
		private System.Windows.Forms.LinkLabel linkLabel6;
		private System.Windows.Forms.LinkLabel linkLabel7;
		private System.Windows.Forms.LinkLabel linkLabel8;
		private Nevron.UI.WinForm.Controls.NExplorerBar nExplorerBar2;
		private Nevron.UI.WinForm.Controls.NExpander nExpander4;
		private System.Windows.Forms.LinkLabel linkLabel10;
		private System.Windows.Forms.LinkLabel linkLabel11;
		private System.Windows.Forms.LinkLabel linkLabel12;
		private Nevron.UI.WinForm.Controls.NExpander nExpander5;
		private System.Windows.Forms.LinkLabel linkLabel13;
		private System.Windows.Forms.LinkLabel linkLabel14;
		private System.Windows.Forms.LinkLabel linkLabel15;
		private Nevron.UI.WinForm.Controls.NExpander nExpander6;
		private System.Windows.Forms.LinkLabel linkLabel16;
		private System.Windows.Forms.LinkLabel linkLabel17;
		private System.Windows.Forms.LinkLabel linkLabel18;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ScrollableCheck;
		private System.Windows.Forms.LinkLabel linkLabel19;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel9;

		#endregion
	}
}
