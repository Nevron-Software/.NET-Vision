namespace Nevron.Examples.UI.WinForm
{
    partial class NSystemImagesUC
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
            this.smallImages = new Nevron.UI.WinForm.Controls.NGalleryPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.largeImages = new Nevron.UI.WinForm.Controls.NGalleryPanel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.smallImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeImages)).BeginInit();
            this.SuspendLayout();
            // 
            // smallImages
            // 
            this.smallImages.Location = new System.Drawing.Point(3, 26);
            this.smallImages.Name = "smallImages";
            this.smallImages.Size = new System.Drawing.Size(300, 300);
            this.smallImages.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Small Images:";
            // 
            // largeImages
            // 
            this.largeImages.Location = new System.Drawing.Point(309, 26);
            this.largeImages.Name = "largeImages";
            this.largeImages.Size = new System.Drawing.Size(300, 300);
            this.largeImages.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Large Images:";
            // 
            // NSystemImagesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.largeImages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.smallImages);
            this.Name = "NSystemImagesUC";
            this.Size = new System.Drawing.Size(628, 343);
            ((System.ComponentModel.ISupportInitialize)(this.smallImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NGalleryPanel smallImages;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NGalleryPanel largeImages;
        private System.Windows.Forms.Label label2;
    }
}
