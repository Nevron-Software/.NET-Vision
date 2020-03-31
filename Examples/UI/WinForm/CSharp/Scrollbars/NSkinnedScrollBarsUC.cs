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
	/// Summary description for NSkinnedScrollBarsUC.
	/// </summary>
	public class NSkinnedScrollBarsUC : NExampleUserControl
	{
		#region Constructor

		public NSkinnedScrollBarsUC(MainForm f) : base(f)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

			nTreeView1.ExpandAll();
		}


		#endregion

		#region Event Handlers

		private void m_UseCustomScrollsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			bool bChecked = m_UseCustomScrollsCheck.Checked;

			nListBox1.UseCustomScrollBars = bChecked;
			nTextBox1.UseCustomScrollBars = bChecked;
			nTreeView1.UseCustomScrollBars = bChecked;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node21");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node20", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node19", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node18", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node17", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node16", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node9", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node8", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node7", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node6", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node5", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Node10");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Node11");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Node12");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Node13");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Node14");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Node15");
            this.nListBox1 = new Nevron.UI.WinForm.Controls.NListBox();
            this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
            this.nTreeView1 = new Nevron.UI.WinForm.Controls.NTreeView();
            this.m_UseCustomScrollsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // nListBox1
            // 
            this.nListBox1.HorizontalExtent = 500;
            this.nListBox1.HorizontalScrollbar = true;
            this.nListBox1.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0))});
            this.nListBox1.Location = new System.Drawing.Point(8, 8);
            this.nListBox1.Name = "nListBox1";
            this.nListBox1.Size = new System.Drawing.Size(184, 141);
            this.nListBox1.TabIndex = 0;
            // 
            // nTextBox1
            // 
            this.nTextBox1.Location = new System.Drawing.Point(8, 152);
            this.nTextBox1.Multiline = true;
            this.nTextBox1.Name = "nTextBox1";
            this.nTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nTextBox1.Size = new System.Drawing.Size(184, 144);
            this.nTextBox1.TabIndex = 1;
            this.nTextBox1.Text = "Line\r\nLine\r\nLine\r\nLineLine\r\nLineLine\r\nLineLine\r\nLineLine\r\nLineLine\r\nLineLine\r\nLin" +
                "eLine\r\nLineLine\r\nLong LineLong LineLong LineLong LineLong LineLong LineLong Line" +
                "Long LineLong LineLong Line";
            this.nTextBox1.WordWrap = false;
            // 
            // nTreeView1
            // 
            this.nTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nTreeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.nTreeView1.Location = new System.Drawing.Point(200, 8);
            this.nTreeView1.Name = "nTreeView1";
            treeNode1.Name = "";
            treeNode1.Text = "Node21";
            treeNode2.Name = "";
            treeNode2.Text = "Node20";
            treeNode3.Name = "";
            treeNode3.Text = "Node19";
            treeNode4.Name = "";
            treeNode4.Text = "Node18";
            treeNode5.Name = "";
            treeNode5.Text = "Node17";
            treeNode6.Name = "";
            treeNode6.Text = "Node16";
            treeNode7.Name = "";
            treeNode7.Text = "Node9";
            treeNode8.Name = "";
            treeNode8.Text = "Node8";
            treeNode9.Name = "";
            treeNode9.Text = "Node7";
            treeNode10.Name = "";
            treeNode10.Text = "Node6";
            treeNode11.Name = "";
            treeNode11.Text = "Node5";
            treeNode12.Name = "";
            treeNode12.Text = "Node4";
            treeNode13.Name = "";
            treeNode13.Text = "Node0";
            treeNode14.Name = "";
            treeNode14.Text = "Node1";
            treeNode15.Name = "";
            treeNode15.Text = "Node2";
            treeNode16.Name = "";
            treeNode16.Text = "Node3";
            treeNode17.Name = "";
            treeNode17.Text = "Node10";
            treeNode18.Name = "";
            treeNode18.Text = "Node11";
            treeNode19.Name = "";
            treeNode19.Text = "Node12";
            treeNode20.Name = "";
            treeNode20.Text = "Node13";
            treeNode21.Name = "";
            treeNode21.Text = "Node14";
            treeNode22.Name = "";
            treeNode22.Text = "Node15";
            this.nTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            this.nTreeView1.Size = new System.Drawing.Size(232, 288);
            this.nTreeView1.TabIndex = 2;
            // 
            // m_UseCustomScrollsCheck
            // 
            this.m_UseCustomScrollsCheck.ButtonProperties.BorderOffset = 2;
            this.m_UseCustomScrollsCheck.Checked = true;
            this.m_UseCustomScrollsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_UseCustomScrollsCheck.Location = new System.Drawing.Point(8, 304);
            this.m_UseCustomScrollsCheck.Name = "m_UseCustomScrollsCheck";
            this.m_UseCustomScrollsCheck.Size = new System.Drawing.Size(184, 24);
            this.m_UseCustomScrollsCheck.TabIndex = 3;
            this.m_UseCustomScrollsCheck.Text = "Use Custom ScrollBars";
            this.m_UseCustomScrollsCheck.CheckedChanged += new System.EventHandler(this.m_UseCustomScrollsCheck_CheckedChanged);
            // 
            // NSkinnedScrollBarsUC
            // 
            this.Controls.Add(this.m_UseCustomScrollsCheck);
            this.Controls.Add(this.nTreeView1);
            this.Controls.Add(this.nTextBox1);
            this.Controls.Add(this.nListBox1);
            this.Name = "NSkinnedScrollBarsUC";
            this.Size = new System.Drawing.Size(440, 328);
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NListBox nListBox1;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;
		private Nevron.UI.WinForm.Controls.NTreeView nTreeView1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_UseCustomScrollsCheck;

		#endregion
	}
}
