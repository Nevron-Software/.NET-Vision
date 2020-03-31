namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeViewExDragDropUC
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
            this.expandNodeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.autoScrollCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.showHintsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.enableDragCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.expandAllBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.collapseAllBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTreeViewEx1
            // 
            this.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeViewEx1.Location = new System.Drawing.Point(0, 0);
            this.nTreeViewEx1.Name = "nTreeViewEx1";
            this.nTreeViewEx1.Size = new System.Drawing.Size(631, 269);
            this.nTreeViewEx1.TabIndex = 0;
            this.nTreeViewEx1.Text = "nTreeViewEx1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.collapseAllBtn);
            this.panel1.Controls.Add(this.expandAllBtn);
            this.panel1.Controls.Add(this.expandNodeCheck);
            this.panel1.Controls.Add(this.autoScrollCheck);
            this.panel1.Controls.Add(this.showHintsCheck);
            this.panel1.Controls.Add(this.enableDragCheck);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 53);
            this.panel1.TabIndex = 1;
            // 
            // expandNodeCheck
            // 
            this.expandNodeCheck.AutoSize = true;
            this.expandNodeCheck.ButtonProperties.BorderOffset = 2;
            this.expandNodeCheck.Location = new System.Drawing.Point(210, 26);
            this.expandNodeCheck.Name = "expandNodeCheck";
            this.expandNodeCheck.Size = new System.Drawing.Size(156, 17);
            this.expandNodeCheck.TabIndex = 3;
            this.expandNodeCheck.Text = "Expand Node on Drag-over";
            this.expandNodeCheck.CheckedChanged += new System.EventHandler(this.expandNodeCheck_CheckedChanged);
            // 
            // autoScrollCheck
            // 
            this.autoScrollCheck.AutoSize = true;
            this.autoScrollCheck.ButtonProperties.BorderOffset = 2;
            this.autoScrollCheck.Location = new System.Drawing.Point(210, 3);
            this.autoScrollCheck.Name = "autoScrollCheck";
            this.autoScrollCheck.Size = new System.Drawing.Size(182, 17);
            this.autoScrollCheck.TabIndex = 2;
            this.autoScrollCheck.Text = "Enable Drag-and-drop Auto-scroll";
            this.autoScrollCheck.CheckedChanged += new System.EventHandler(this.autoScrollCheck_CheckedChanged);
            // 
            // showHintsCheck
            // 
            this.showHintsCheck.AutoSize = true;
            this.showHintsCheck.ButtonProperties.BorderOffset = 2;
            this.showHintsCheck.Location = new System.Drawing.Point(3, 26);
            this.showHintsCheck.Name = "showHintsCheck";
            this.showHintsCheck.Size = new System.Drawing.Size(151, 17);
            this.showHintsCheck.TabIndex = 1;
            this.showHintsCheck.Text = "Show Drag-and-drop Hints";
            this.showHintsCheck.CheckedChanged += new System.EventHandler(this.showHintsCheck_CheckedChanged);
            // 
            // enableDragCheck
            // 
            this.enableDragCheck.AutoSize = true;
            this.enableDragCheck.ButtonProperties.BorderOffset = 2;
            this.enableDragCheck.Location = new System.Drawing.Point(3, 3);
            this.enableDragCheck.Name = "enableDragCheck";
            this.enableDragCheck.Size = new System.Drawing.Size(130, 17);
            this.enableDragCheck.TabIndex = 0;
            this.enableDragCheck.Text = "Enable Drag-and-drop";
            this.enableDragCheck.CheckedChanged += new System.EventHandler(this.enableDragCheck_CheckedChanged);
            // 
            // expandAllBtn
            // 
            this.expandAllBtn.Location = new System.Drawing.Point(422, 3);
            this.expandAllBtn.Name = "expandAllBtn";
            this.expandAllBtn.Size = new System.Drawing.Size(75, 23);
            this.expandAllBtn.TabIndex = 4;
            this.expandAllBtn.Text = "Expand All";
            this.expandAllBtn.Click += new System.EventHandler(this.expandAllBtn_Click);
            // 
            // collapseAllBtn
            // 
            this.collapseAllBtn.Location = new System.Drawing.Point(503, 3);
            this.collapseAllBtn.Name = "collapseAllBtn";
            this.collapseAllBtn.Size = new System.Drawing.Size(75, 23);
            this.collapseAllBtn.TabIndex = 5;
            this.collapseAllBtn.Text = "Collapse All";
            this.collapseAllBtn.Click += new System.EventHandler(this.collapseAllBtn_Click);
            // 
            // NTreeViewExDragDropUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nTreeViewEx1);
            this.Controls.Add(this.panel1);
            this.Name = "NTreeViewExDragDropUC";
            this.Size = new System.Drawing.Size(631, 322);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTreeViewEx nTreeViewEx1;
        private System.Windows.Forms.Panel panel1;
        private Nevron.UI.WinForm.Controls.NCheckBox showHintsCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox enableDragCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox autoScrollCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox expandNodeCheck;
        private Nevron.UI.WinForm.Controls.NButton collapseAllBtn;
        private Nevron.UI.WinForm.Controls.NButton expandAllBtn;
    }
}
