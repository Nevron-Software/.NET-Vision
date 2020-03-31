namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeListUC
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.nSplitter1 = new Nevron.UI.WinForm.Controls.NSplitter();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.nSplitter2 = new Nevron.UI.WinForm.Controls.NSplitter();
            this.mainPanel.SuspendLayout();
            this.propertiesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.containerPanel);
            this.mainPanel.Controls.Add(this.nSplitter2);
            this.mainPanel.Controls.Add(this.actionPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(450, 350);
            this.mainPanel.TabIndex = 0;
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Controls.Add(this.propertyGrid1);
            this.propertiesPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertiesPanel.Location = new System.Drawing.Point(455, 0);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(228, 350);
            this.propertiesPanel.TabIndex = 1;
            // 
            // nSplitter1
            // 
            this.nSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.nSplitter1.Location = new System.Drawing.Point(450, 0);
            this.nSplitter1.MinimumSize = new System.Drawing.Size(5, 34);
            this.nSplitter1.Name = "nSplitter1";
            this.nSplitter1.Size = new System.Drawing.Size(5, 350);
            this.nSplitter1.TabIndex = 2;
            this.nSplitter1.TabStop = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.CommandsVisibleIfAvailable = false;
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(228, 350);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // actionPanel
            // 
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(0, 300);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(450, 50);
            this.actionPanel.TabIndex = 0;
            // 
            // containerPanel
            // 
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(450, 295);
            this.containerPanel.TabIndex = 1;
            // 
            // nSplitter2
            // 
            this.nSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nSplitter2.Location = new System.Drawing.Point(0, 295);
            this.nSplitter2.MinimumSize = new System.Drawing.Size(34, 5);
            this.nSplitter2.Name = "nSplitter2";
            this.nSplitter2.Size = new System.Drawing.Size(450, 5);
            this.nSplitter2.TabIndex = 2;
            this.nSplitter2.TabStop = false;
            // 
            // NTreeListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.nSplitter1);
            this.Controls.Add(this.propertiesPanel);
            this.Name = "NTreeListUC";
            this.Size = new System.Drawing.Size(683, 350);
            this.mainPanel.ResumeLayout(false);
            this.propertiesPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel propertiesPanel;
        private Nevron.UI.WinForm.Controls.NSplitter nSplitter1;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel containerPanel;
        private Nevron.UI.WinForm.Controls.NSplitter nSplitter2;
    }
}
