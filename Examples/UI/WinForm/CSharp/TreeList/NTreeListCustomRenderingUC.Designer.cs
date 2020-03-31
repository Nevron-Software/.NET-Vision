namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeListCustomRenderingUC
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
            this.autoSizeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.subItemRendererCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.headerRendererCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.autoSizeCheck);
            this.panel1.Controls.Add(this.subItemRendererCheck);
            this.panel1.Controls.Add(this.headerRendererCheck);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 319);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 47);
            this.panel1.TabIndex = 0;
            // 
            // autoSizeCheck
            // 
            this.autoSizeCheck.AutoSize = true;
            this.autoSizeCheck.ButtonProperties.BorderOffset = 2;
            this.autoSizeCheck.Location = new System.Drawing.Point(313, 6);
            this.autoSizeCheck.Name = "autoSizeCheck";
            this.autoSizeCheck.Size = new System.Drawing.Size(112, 17);
            this.autoSizeCheck.TabIndex = 2;
            this.autoSizeCheck.Text = "Auto-size Columns";
            this.autoSizeCheck.CheckedChanged += new System.EventHandler(this.autoSizeCheck_CheckedChanged);
            // 
            // subItemRendererCheck
            // 
            this.subItemRendererCheck.AutoSize = true;
            this.subItemRendererCheck.ButtonProperties.BorderOffset = 2;
            this.subItemRendererCheck.Checked = true;
            this.subItemRendererCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.subItemRendererCheck.Location = new System.Drawing.Point(155, 6);
            this.subItemRendererCheck.Name = "subItemRendererCheck";
            this.subItemRendererCheck.Size = new System.Drawing.Size(152, 17);
            this.subItemRendererCheck.TabIndex = 1;
            this.subItemRendererCheck.Text = "Custom Sub-item Renderer";
            this.subItemRendererCheck.CheckedChanged += new System.EventHandler(this.subItemRendererCheck_CheckedChanged);
            // 
            // headerRendererCheck
            // 
            this.headerRendererCheck.AutoSize = true;
            this.headerRendererCheck.ButtonProperties.BorderOffset = 2;
            this.headerRendererCheck.Checked = true;
            this.headerRendererCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.headerRendererCheck.Location = new System.Drawing.Point(3, 6);
            this.headerRendererCheck.Name = "headerRendererCheck";
            this.headerRendererCheck.Size = new System.Drawing.Size(146, 17);
            this.headerRendererCheck.TabIndex = 0;
            this.headerRendererCheck.Text = "Custom Header Renderer";
            this.headerRendererCheck.CheckedChanged += new System.EventHandler(this.headerRendererCheck_CheckedChanged);
            // 
            // containerPanel
            // 
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(609, 319);
            this.containerPanel.TabIndex = 1;
            // 
            // NTreeListCustomRenderingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.panel1);
            this.Name = "NTreeListCustomRenderingUC";
            this.Size = new System.Drawing.Size(609, 366);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Nevron.UI.WinForm.Controls.NCheckBox headerRendererCheck;
        private System.Windows.Forms.Panel containerPanel;
        private Nevron.UI.WinForm.Controls.NCheckBox subItemRendererCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox autoSizeCheck;
    }
}
