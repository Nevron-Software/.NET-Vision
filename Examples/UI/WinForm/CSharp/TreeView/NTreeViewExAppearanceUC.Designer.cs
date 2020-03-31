namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeViewExAppearanceUC
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
            this.settings1Btn = new Nevron.UI.WinForm.Controls.NButton();
            this.settings2Btn = new Nevron.UI.WinForm.Controls.NButton();
            this.expandAllBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.collapseAllBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.expandToRightCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.multiSelectCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.imageHighlightCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTreeViewEx1
            // 
            this.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeViewEx1.Location = new System.Drawing.Point(0, 0);
            this.nTreeViewEx1.Name = "nTreeViewEx1";
            this.nTreeViewEx1.Size = new System.Drawing.Size(510, 401);
            this.nTreeViewEx1.TabIndex = 0;
            this.nTreeViewEx1.Text = "nTreeViewEx1";
            // 
            // settings1Btn
            // 
            this.settings1Btn.Location = new System.Drawing.Point(3, 3);
            this.settings1Btn.Name = "settings1Btn";
            this.settings1Btn.Size = new System.Drawing.Size(75, 23);
            this.settings1Btn.TabIndex = 1;
            this.settings1Btn.Text = "Settings 1";
            this.settings1Btn.Click += new System.EventHandler(this.settings1Btn_Click);
            // 
            // settings2Btn
            // 
            this.settings2Btn.Location = new System.Drawing.Point(84, 3);
            this.settings2Btn.Name = "settings2Btn";
            this.settings2Btn.Size = new System.Drawing.Size(75, 23);
            this.settings2Btn.TabIndex = 2;
            this.settings2Btn.Text = "Settings 2";
            this.settings2Btn.Click += new System.EventHandler(this.settings2Btn_Click);
            // 
            // expandAllBtn
            // 
            this.expandAllBtn.Location = new System.Drawing.Point(180, 3);
            this.expandAllBtn.Name = "expandAllBtn";
            this.expandAllBtn.Size = new System.Drawing.Size(75, 23);
            this.expandAllBtn.TabIndex = 3;
            this.expandAllBtn.Text = "Expand All";
            this.expandAllBtn.Click += new System.EventHandler(this.expandAllBtn_Click);
            // 
            // collapseAllBtn
            // 
            this.collapseAllBtn.Location = new System.Drawing.Point(261, 3);
            this.collapseAllBtn.Name = "collapseAllBtn";
            this.collapseAllBtn.Size = new System.Drawing.Size(75, 23);
            this.collapseAllBtn.TabIndex = 4;
            this.collapseAllBtn.Text = "Collapse All";
            this.collapseAllBtn.Click += new System.EventHandler(this.collapseAllBtn_Click);
            // 
            // expandToRightCheck
            // 
            this.expandToRightCheck.AutoSize = true;
            this.expandToRightCheck.ButtonProperties.BorderOffset = 2;
            this.expandToRightCheck.Location = new System.Drawing.Point(3, 32);
            this.expandToRightCheck.Name = "expandToRightCheck";
            this.expandToRightCheck.Size = new System.Drawing.Size(97, 17);
            this.expandToRightCheck.TabIndex = 5;
            this.expandToRightCheck.Text = "Expand to right";
            this.expandToRightCheck.CheckedChanged += new System.EventHandler(this.expandToRightCheck_CheckedChanged);
            // 
            // multiSelectCheck
            // 
            this.multiSelectCheck.AutoSize = true;
            this.multiSelectCheck.ButtonProperties.BorderOffset = 2;
            this.multiSelectCheck.Location = new System.Drawing.Point(106, 32);
            this.multiSelectCheck.Name = "multiSelectCheck";
            this.multiSelectCheck.Size = new System.Drawing.Size(76, 17);
            this.multiSelectCheck.TabIndex = 6;
            this.multiSelectCheck.Text = "Multiselect";
            this.multiSelectCheck.CheckedChanged += new System.EventHandler(this.multiSelectCheck_CheckedChanged);
            // 
            // imageHighlightCheck
            // 
            this.imageHighlightCheck.AutoSize = true;
            this.imageHighlightCheck.ButtonProperties.BorderOffset = 2;
            this.imageHighlightCheck.Location = new System.Drawing.Point(188, 32);
            this.imageHighlightCheck.Name = "imageHighlightCheck";
            this.imageHighlightCheck.Size = new System.Drawing.Size(97, 17);
            this.imageHighlightCheck.TabIndex = 7;
            this.imageHighlightCheck.Text = "Image highlight";
            this.imageHighlightCheck.CheckedChanged += new System.EventHandler(this.imageHighlightCheck_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.settings1Btn);
            this.panel1.Controls.Add(this.imageHighlightCheck);
            this.panel1.Controls.Add(this.settings2Btn);
            this.panel1.Controls.Add(this.multiSelectCheck);
            this.panel1.Controls.Add(this.expandAllBtn);
            this.panel1.Controls.Add(this.expandToRightCheck);
            this.panel1.Controls.Add(this.collapseAllBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 60);
            this.panel1.TabIndex = 8;
            // 
            // NTreeViewExAppearanceUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nTreeViewEx1);
            this.Controls.Add(this.panel1);
            this.Name = "NTreeViewExAppearanceUC";
            this.Size = new System.Drawing.Size(510, 461);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Nevron.UI.WinForm.Controls.NTreeViewEx nTreeViewEx1;
        private Nevron.UI.WinForm.Controls.NButton settings1Btn;
        private Nevron.UI.WinForm.Controls.NButton settings2Btn;
        private Nevron.UI.WinForm.Controls.NButton expandAllBtn;
        private Nevron.UI.WinForm.Controls.NButton collapseAllBtn;
        private Nevron.UI.WinForm.Controls.NCheckBox expandToRightCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox multiSelectCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox imageHighlightCheck;
        private System.Windows.Forms.Panel panel1;
    }
}
