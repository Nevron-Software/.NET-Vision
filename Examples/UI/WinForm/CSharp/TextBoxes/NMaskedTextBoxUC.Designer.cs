namespace Nevron.Examples.UI.WinForm
{
    partial class NMaskedTextBoxUC
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
            this.nMaskedTextBox1 = new Nevron.UI.WinForm.Controls.NMaskedTextBox();
            this.enableSkinningCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.borderBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.paletteBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // nMaskedTextBox1
            // 
            this.nMaskedTextBox1.Location = new System.Drawing.Point(3, 3);
            this.nMaskedTextBox1.Mask = "00/00/0000";
            this.nMaskedTextBox1.Name = "maskedTextBox1";
            this.nMaskedTextBox1.Size = new System.Drawing.Size(275, 20);
            this.nMaskedTextBox1.TabIndex = 0;
            this.nMaskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // enableSkinningCheck
            // 
            this.enableSkinningCheck.AutoSize = true;
            this.enableSkinningCheck.ButtonProperties.BorderOffset = 2;
            this.enableSkinningCheck.Checked = true;
            this.enableSkinningCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableSkinningCheck.Location = new System.Drawing.Point(3, 58);
            this.enableSkinningCheck.Name = "enableSkinningCheck";
            this.enableSkinningCheck.Size = new System.Drawing.Size(103, 17);
            this.enableSkinningCheck.TabIndex = 1;
            this.enableSkinningCheck.Text = "Enable Skinning";
            this.enableSkinningCheck.CheckedChanged += new System.EventHandler(this.enableSkinningCheck_CheckedChanged);
            // 
            // borderBtn
            // 
            this.borderBtn.Enabled = false;
            this.borderBtn.Location = new System.Drawing.Point(3, 29);
            this.borderBtn.Name = "borderBtn";
            this.borderBtn.Size = new System.Drawing.Size(75, 23);
            this.borderBtn.TabIndex = 2;
            this.borderBtn.Text = "Border...";
            this.borderBtn.Click += new System.EventHandler(this.borderBtn_Click);
            // 
            // paletteBtn
            // 
            this.paletteBtn.Enabled = false;
            this.paletteBtn.Location = new System.Drawing.Point(84, 29);
            this.paletteBtn.Name = "paletteBtn";
            this.paletteBtn.Size = new System.Drawing.Size(75, 23);
            this.paletteBtn.TabIndex = 3;
            this.paletteBtn.Text = "Palette...";
            this.paletteBtn.Click += new System.EventHandler(this.paletteBtn_Click);
            // 
            // NMaskedTextBoxUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paletteBtn);
            this.Controls.Add(this.borderBtn);
            this.Controls.Add(this.enableSkinningCheck);
            this.Controls.Add(this.nMaskedTextBox1);
            this.Name = "NMaskedTextBoxUC";
            this.Size = new System.Drawing.Size(337, 239);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NMaskedTextBox nMaskedTextBox1;
        private Nevron.UI.WinForm.Controls.NCheckBox enableSkinningCheck;
        private Nevron.UI.WinForm.Controls.NButton borderBtn;
        private Nevron.UI.WinForm.Controls.NButton paletteBtn;
    }
}
