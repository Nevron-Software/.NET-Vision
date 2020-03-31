namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeViewExSortingUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.sortDescendingBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.sortAscendingBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.recursiveSortCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sortDescendingBtn);
            this.panel1.Controls.Add(this.sortAscendingBtn);
            this.panel1.Controls.Add(this.recursiveSortCheck);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 57);
            this.panel1.TabIndex = 0;
            // 
            // sortDescendingBtn
            // 
            this.sortDescendingBtn.Location = new System.Drawing.Point(105, 26);
            this.sortDescendingBtn.Name = "sortDescendingBtn";
            this.sortDescendingBtn.Size = new System.Drawing.Size(96, 23);
            this.sortDescendingBtn.TabIndex = 2;
            this.sortDescendingBtn.Text = "Sort Descending";
            this.sortDescendingBtn.Click += new System.EventHandler(this.sortDescendingBtn_Click);
            // 
            // sortAscendingBtn
            // 
            this.sortAscendingBtn.Location = new System.Drawing.Point(3, 26);
            this.sortAscendingBtn.Name = "sortAscendingBtn";
            this.sortAscendingBtn.Size = new System.Drawing.Size(96, 23);
            this.sortAscendingBtn.TabIndex = 1;
            this.sortAscendingBtn.Text = "Sort Ascending";
            this.sortAscendingBtn.Click += new System.EventHandler(this.sortAscendingBtn_Click);
            // 
            // recursiveSortCheck
            // 
            this.recursiveSortCheck.AutoSize = true;
            this.recursiveSortCheck.ButtonProperties.BorderOffset = 2;
            this.recursiveSortCheck.Checked = true;
            this.recursiveSortCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.recursiveSortCheck.Location = new System.Drawing.Point(3, 3);
            this.recursiveSortCheck.Name = "recursiveSortCheck";
            this.recursiveSortCheck.Size = new System.Drawing.Size(96, 17);
            this.recursiveSortCheck.TabIndex = 0;
            this.recursiveSortCheck.Text = "Recursive Sort";
            // 
            // containerPanel
            // 
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(537, 268);
            this.containerPanel.TabIndex = 1;
            // 
            // NTreeViewExSortingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.panel1);
            this.Name = "NTreeViewExSortingUC";
            this.Size = new System.Drawing.Size(537, 325);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Nevron.UI.WinForm.Controls.NCheckBox recursiveSortCheck;
        private Nevron.UI.WinForm.Controls.NButton sortDescendingBtn;
        private Nevron.UI.WinForm.Controls.NButton sortAscendingBtn;
        private System.Windows.Forms.Panel containerPanel;
    }
}
