namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeViewExFilteringUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.filterCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTreeViewEx1
            // 
            this.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeViewEx1.Location = new System.Drawing.Point(0, 0);
            this.nTreeViewEx1.Name = "nTreeViewEx1";
            this.nTreeViewEx1.Size = new System.Drawing.Size(608, 228);
            this.nTreeViewEx1.TabIndex = 0;
            this.nTreeViewEx1.Text = "nTreeViewEx1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.descriptionLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.filterCombo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 117);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Filter:";
            // 
            // filterCombo
            // 
            this.filterCombo.Location = new System.Drawing.Point(97, 3);
            this.filterCombo.Name = "filterCombo";
            this.filterCombo.Size = new System.Drawing.Size(212, 22);
            this.filterCombo.TabIndex = 1;
            this.filterCombo.Text = "nComboBox1";
            this.filterCombo.SelectedIndexChanged += new System.EventHandler(this.filterCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter Description:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(97, 37);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(212, 80);
            this.descriptionLabel.TabIndex = 3;
            // 
            // NTreeViewExFilteringUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nTreeViewEx1);
            this.Controls.Add(this.panel1);
            this.Name = "NTreeViewExFilteringUC";
            this.Size = new System.Drawing.Size(608, 345);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTreeViewEx nTreeViewEx1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NComboBox filterCombo;
        private System.Windows.Forms.Label label1;
    }
}
