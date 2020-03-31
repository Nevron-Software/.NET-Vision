namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeViewExXmlViewerUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.collapseAllBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.expandAllBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.loadFileBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.embeddedFileBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTreeViewEx1
            // 
            this.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeViewEx1.Location = new System.Drawing.Point(0, 0);
            this.nTreeViewEx1.Name = "nTreeViewEx1";
            this.nTreeViewEx1.Size = new System.Drawing.Size(564, 335);
            this.nTreeViewEx1.TabIndex = 0;
            this.nTreeViewEx1.Text = "nTreeViewEx1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.collapseAllBtn);
            this.panel1.Controls.Add(this.expandAllBtn);
            this.panel1.Controls.Add(this.loadFileBtn);
            this.panel1.Controls.Add(this.embeddedFileBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 39);
            this.panel1.TabIndex = 1;
            // 
            // collapseAllBtn
            // 
            this.collapseAllBtn.Location = new System.Drawing.Point(360, 3);
            this.collapseAllBtn.Name = "collapseAllBtn";
            this.collapseAllBtn.Size = new System.Drawing.Size(72, 26);
            this.collapseAllBtn.TabIndex = 3;
            this.collapseAllBtn.Text = "Collapse All";
            this.collapseAllBtn.Click += new System.EventHandler(this.collapseAllBtn_Click);
            // 
            // expandAllBtn
            // 
            this.expandAllBtn.Location = new System.Drawing.Point(282, 3);
            this.expandAllBtn.Name = "expandAllBtn";
            this.expandAllBtn.Size = new System.Drawing.Size(72, 26);
            this.expandAllBtn.TabIndex = 2;
            this.expandAllBtn.Text = "Expand All";
            this.expandAllBtn.Click += new System.EventHandler(this.expandAllBtn_Click);
            // 
            // loadFileBtn
            // 
            this.loadFileBtn.Location = new System.Drawing.Point(126, 3);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(117, 26);
            this.loadFileBtn.TabIndex = 1;
            this.loadFileBtn.Text = "Load File...";
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // embeddedFileBtn
            // 
            this.embeddedFileBtn.Location = new System.Drawing.Point(3, 3);
            this.embeddedFileBtn.Name = "embeddedFileBtn";
            this.embeddedFileBtn.Size = new System.Drawing.Size(117, 26);
            this.embeddedFileBtn.TabIndex = 0;
            this.embeddedFileBtn.Text = "Embedded File";
            this.embeddedFileBtn.Click += new System.EventHandler(this.embeddedFileBtn_Click);
            // 
            // NTreeViewExXmlViewerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nTreeViewEx1);
            this.Controls.Add(this.panel1);
            this.Name = "NTreeViewExXmlViewerUC";
            this.Size = new System.Drawing.Size(564, 374);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTreeViewEx nTreeViewEx1;
        private System.Windows.Forms.Panel panel1;
        private Nevron.UI.WinForm.Controls.NButton loadFileBtn;
        private Nevron.UI.WinForm.Controls.NButton embeddedFileBtn;
        private Nevron.UI.WinForm.Controls.NButton collapseAllBtn;
        private Nevron.UI.WinForm.Controls.NButton expandAllBtn;
    }
}
