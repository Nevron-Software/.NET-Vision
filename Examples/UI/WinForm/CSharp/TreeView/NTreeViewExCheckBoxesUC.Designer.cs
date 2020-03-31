namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeViewExCheckBoxesUC
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
            this.autoCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.checkStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedItemsBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.indeterminateBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTreeViewEx1
            // 
            this.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeViewEx1.Location = new System.Drawing.Point(0, 0);
            this.nTreeViewEx1.Name = "nTreeViewEx1";
            this.nTreeViewEx1.Size = new System.Drawing.Size(650, 360);
            this.nTreeViewEx1.TabIndex = 0;
            this.nTreeViewEx1.Text = "nTreeViewEx1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.indeterminateBtn);
            this.panel1.Controls.Add(this.checkedItemsBtn);
            this.panel1.Controls.Add(this.autoCheck);
            this.panel1.Controls.Add(this.checkStyleCombo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 360);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 68);
            this.panel1.TabIndex = 1;
            // 
            // autoCheck
            // 
            this.autoCheck.AutoSize = true;
            this.autoCheck.ButtonProperties.BorderOffset = 2;
            this.autoCheck.Location = new System.Drawing.Point(105, 31);
            this.autoCheck.Name = "autoCheck";
            this.autoCheck.Size = new System.Drawing.Size(118, 17);
            this.autoCheck.TabIndex = 2;
            this.autoCheck.Text = "Enable Auto-Check";
            this.autoCheck.CheckedChanged += new System.EventHandler(this.autoCheck_CheckedChanged);
            // 
            // checkStyleCombo
            // 
            this.checkStyleCombo.Location = new System.Drawing.Point(105, 3);
            this.checkStyleCombo.Name = "checkStyleCombo";
            this.checkStyleCombo.Size = new System.Drawing.Size(167, 22);
            this.checkStyleCombo.TabIndex = 1;
            this.checkStyleCombo.Text = "nComboBox1";
            this.checkStyleCombo.SelectedIndexChanged += new System.EventHandler(this.checkStyleCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check Style:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkedItemsBtn
            // 
            this.checkedItemsBtn.Location = new System.Drawing.Point(301, 31);
            this.checkedItemsBtn.Name = "checkedItemsBtn";
            this.checkedItemsBtn.Size = new System.Drawing.Size(107, 23);
            this.checkedItemsBtn.TabIndex = 3;
            this.checkedItemsBtn.Text = "Checked Items";
            this.checkedItemsBtn.Click += new System.EventHandler(this.checkedItemsBtn_Click);
            // 
            // indeterminateBtn
            // 
            this.indeterminateBtn.Location = new System.Drawing.Point(414, 31);
            this.indeterminateBtn.Name = "indeterminateBtn";
            this.indeterminateBtn.Size = new System.Drawing.Size(107, 23);
            this.indeterminateBtn.TabIndex = 4;
            this.indeterminateBtn.Text = "Indeterminate Items";
            this.indeterminateBtn.Click += new System.EventHandler(this.indeterminateBtn_Click);
            // 
            // NTreeViewExCheckBoxesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nTreeViewEx1);
            this.Controls.Add(this.panel1);
            this.Name = "NTreeViewExCheckBoxesUC";
            this.Size = new System.Drawing.Size(650, 428);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTreeViewEx nTreeViewEx1;
        private System.Windows.Forms.Panel panel1;
        private Nevron.UI.WinForm.Controls.NComboBox checkStyleCombo;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NCheckBox autoCheck;
        private Nevron.UI.WinForm.Controls.NButton indeterminateBtn;
        private Nevron.UI.WinForm.Controls.NButton checkedItemsBtn;
    }
}
