namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeViewExUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nTreeViewEx1 = new Nevron.UI.WinForm.Controls.NTreeViewEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.addChildBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.addSiblingBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.removeNodeBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.expandAllBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.collapseAllBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.addTestNodesBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTreeViewEx1
            // 
            this.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeViewEx1.IndicatorLength = 20;
            this.nTreeViewEx1.Location = new System.Drawing.Point(0, 0);
            this.nTreeViewEx1.Name = "nTreeViewEx1";
            this.nTreeViewEx1.Size = new System.Drawing.Size(433, 406);
            this.nTreeViewEx1.TabIndex = 0;
            this.nTreeViewEx1.Text = "nTreeViewEx1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(686, 474);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.nTreeViewEx1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.addTestNodesBtn);
            this.splitContainer2.Panel2.Controls.Add(this.collapseAllBtn);
            this.splitContainer2.Panel2.Controls.Add(this.expandAllBtn);
            this.splitContainer2.Panel2.Controls.Add(this.removeNodeBtn);
            this.splitContainer2.Panel2.Controls.Add(this.addSiblingBtn);
            this.splitContainer2.Panel2.Controls.Add(this.addChildBtn);
            this.splitContainer2.Size = new System.Drawing.Size(433, 474);
            this.splitContainer2.SplitterDistance = 406;
            this.splitContainer2.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(249, 474);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // addChildBtn
            // 
            this.addChildBtn.Location = new System.Drawing.Point(3, 3);
            this.addChildBtn.Name = "addChildBtn";
            this.addChildBtn.Size = new System.Drawing.Size(75, 24);
            this.addChildBtn.TabIndex = 0;
            this.addChildBtn.Text = "Add Child";
            this.addChildBtn.Click += new System.EventHandler(this.addChildBtn_Click);
            // 
            // addSiblingBtn
            // 
            this.addSiblingBtn.Location = new System.Drawing.Point(84, 3);
            this.addSiblingBtn.Name = "addSiblingBtn";
            this.addSiblingBtn.Size = new System.Drawing.Size(75, 24);
            this.addSiblingBtn.TabIndex = 1;
            this.addSiblingBtn.Text = "Add Sibling";
            this.addSiblingBtn.Click += new System.EventHandler(this.addSiblingBtn_Click);
            // 
            // removeNodeBtn
            // 
            this.removeNodeBtn.Location = new System.Drawing.Point(263, 3);
            this.removeNodeBtn.Name = "removeNodeBtn";
            this.removeNodeBtn.Size = new System.Drawing.Size(92, 24);
            this.removeNodeBtn.TabIndex = 2;
            this.removeNodeBtn.Text = "Remove Node(s)";
            this.removeNodeBtn.Click += new System.EventHandler(this.removeNodeBtn_Click);
            // 
            // expandAllBtn
            // 
            this.expandAllBtn.Location = new System.Drawing.Point(3, 33);
            this.expandAllBtn.Name = "expandAllBtn";
            this.expandAllBtn.Size = new System.Drawing.Size(75, 24);
            this.expandAllBtn.TabIndex = 3;
            this.expandAllBtn.Text = "Expand All";
            this.expandAllBtn.Click += new System.EventHandler(this.expandAllBtn_Click);
            // 
            // collapseAllBtn
            // 
            this.collapseAllBtn.Location = new System.Drawing.Point(84, 33);
            this.collapseAllBtn.Name = "collapseAllBtn";
            this.collapseAllBtn.Size = new System.Drawing.Size(75, 24);
            this.collapseAllBtn.TabIndex = 4;
            this.collapseAllBtn.Text = "Collapse All";
            this.collapseAllBtn.Click += new System.EventHandler(this.collapseAllBtn_Click);
            // 
            // addTestNodesBtn
            // 
            this.addTestNodesBtn.Location = new System.Drawing.Point(165, 3);
            this.addTestNodesBtn.Name = "addTestNodesBtn";
            this.addTestNodesBtn.Size = new System.Drawing.Size(92, 24);
            this.addTestNodesBtn.TabIndex = 5;
            this.addTestNodesBtn.Text = "Add Test Nodes";
            this.addTestNodesBtn.Click += new System.EventHandler(this.addTestNodesBtn_Click);
            // 
            // NTreeViewExUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "NTreeViewExUC";
            this.Size = new System.Drawing.Size(686, 474);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTreeViewEx nTreeViewEx1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Nevron.UI.WinForm.Controls.NButton removeNodeBtn;
        private Nevron.UI.WinForm.Controls.NButton addSiblingBtn;
        private Nevron.UI.WinForm.Controls.NButton addChildBtn;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.UI.WinForm.Controls.NButton addTestNodesBtn;
        private Nevron.UI.WinForm.Controls.NButton collapseAllBtn;
        private Nevron.UI.WinForm.Controls.NButton expandAllBtn;

    }
}
