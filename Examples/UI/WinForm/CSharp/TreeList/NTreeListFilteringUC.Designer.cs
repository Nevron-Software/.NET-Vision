namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeListFilteringUC
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

                m_Helper.Dispose();
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
            this.containerPanel = new System.Windows.Forms.Panel();
            this.nSplitter1 = new Nevron.UI.WinForm.Controls.NSplitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.amountFilterNum2 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.amountFilterNum1 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.removeNumericFilterBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.applyNumericFilterBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.numericOptionsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.disableFromFilterBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.enableFromFilterBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.stringOptionsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fromColumnFilterText1 = new Nevron.UI.WinForm.Controls.NTextBox();
            this.panel2.SuspendLayout();
            this.nGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountFilterNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountFilterNum1)).BeginInit();
            this.nGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(328, 275);
            this.containerPanel.TabIndex = 0;
            // 
            // nSplitter1
            // 
            this.nSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.nSplitter1.Location = new System.Drawing.Point(328, 0);
            this.nSplitter1.MinimumSize = new System.Drawing.Size(5, 34);
            this.nSplitter1.Name = "nSplitter1";
            this.nSplitter1.Size = new System.Drawing.Size(5, 275);
            this.nSplitter1.TabIndex = 1;
            this.nSplitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nGroupBox2);
            this.panel2.Controls.Add(this.nGroupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(333, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 275);
            this.panel2.TabIndex = 2;
            // 
            // nGroupBox2
            // 
            this.nGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nGroupBox2.Controls.Add(this.amountFilterNum2);
            this.nGroupBox2.Controls.Add(this.amountFilterNum1);
            this.nGroupBox2.Controls.Add(this.label4);
            this.nGroupBox2.Controls.Add(this.removeNumericFilterBtn);
            this.nGroupBox2.Controls.Add(this.applyNumericFilterBtn);
            this.nGroupBox2.Controls.Add(this.numericOptionsCombo);
            this.nGroupBox2.Controls.Add(this.label5);
            this.nGroupBox2.Controls.Add(this.label6);
            this.nGroupBox2.Location = new System.Drawing.Point(3, 113);
            this.nGroupBox2.Name = "nGroupBox2";
            this.nGroupBox2.Size = new System.Drawing.Size(230, 130);
            this.nGroupBox2.TabIndex = 1;
            this.nGroupBox2.TabStop = false;
            this.nGroupBox2.Text = "\'PurchaseAmount\' Column Filter";
            // 
            // amountFilterNum2
            // 
            this.amountFilterNum2.Location = new System.Drawing.Point(84, 45);
            this.amountFilterNum2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.amountFilterNum2.Name = "amountFilterNum2";
            this.amountFilterNum2.Size = new System.Drawing.Size(90, 20);
            this.amountFilterNum2.TabIndex = 9;
            // 
            // amountFilterNum1
            // 
            this.amountFilterNum1.Location = new System.Drawing.Point(84, 19);
            this.amountFilterNum1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.amountFilterNum1.Name = "amountFilterNum1";
            this.amountFilterNum1.Size = new System.Drawing.Size(90, 20);
            this.amountFilterNum1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number 2:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // removeNumericFilterBtn
            // 
            this.removeNumericFilterBtn.Location = new System.Drawing.Point(156, 99);
            this.removeNumericFilterBtn.Name = "removeNumericFilterBtn";
            this.removeNumericFilterBtn.Size = new System.Drawing.Size(68, 23);
            this.removeNumericFilterBtn.TabIndex = 5;
            this.removeNumericFilterBtn.Text = "Remove";
            this.removeNumericFilterBtn.Click += new System.EventHandler(this.removeNumericFilterBtn_Click);
            // 
            // applyNumericFilterBtn
            // 
            this.applyNumericFilterBtn.Location = new System.Drawing.Point(84, 99);
            this.applyNumericFilterBtn.Name = "applyNumericFilterBtn";
            this.applyNumericFilterBtn.Size = new System.Drawing.Size(69, 23);
            this.applyNumericFilterBtn.TabIndex = 4;
            this.applyNumericFilterBtn.Text = "Apply";
            this.applyNumericFilterBtn.Click += new System.EventHandler(this.applyNumericFilterBtn_Click);
            // 
            // numericOptionsCombo
            // 
            this.numericOptionsCombo.Location = new System.Drawing.Point(84, 71);
            this.numericOptionsCombo.Name = "numericOptionsCombo";
            this.numericOptionsCombo.Size = new System.Drawing.Size(140, 22);
            this.numericOptionsCombo.TabIndex = 3;
            this.numericOptionsCombo.SelectedIndexChanged += new System.EventHandler(this.numericOptionsCombo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(22, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Options:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Number 1:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nGroupBox1.Controls.Add(this.disableFromFilterBtn);
            this.nGroupBox1.Controls.Add(this.enableFromFilterBtn);
            this.nGroupBox1.Controls.Add(this.stringOptionsCombo);
            this.nGroupBox1.Controls.Add(this.label2);
            this.nGroupBox1.Controls.Add(this.label1);
            this.nGroupBox1.Controls.Add(this.fromColumnFilterText1);
            this.nGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(230, 104);
            this.nGroupBox1.TabIndex = 0;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "\'From\' Column Filter";
            // 
            // disableFromFilterBtn
            // 
            this.disableFromFilterBtn.Location = new System.Drawing.Point(156, 71);
            this.disableFromFilterBtn.Name = "disableFromFilterBtn";
            this.disableFromFilterBtn.Size = new System.Drawing.Size(68, 23);
            this.disableFromFilterBtn.TabIndex = 5;
            this.disableFromFilterBtn.Text = "Remove";
            this.disableFromFilterBtn.Click += new System.EventHandler(this.disableFromFilterBtn_Click);
            // 
            // enableFromFilterBtn
            // 
            this.enableFromFilterBtn.Location = new System.Drawing.Point(84, 71);
            this.enableFromFilterBtn.Name = "enableFromFilterBtn";
            this.enableFromFilterBtn.Size = new System.Drawing.Size(69, 23);
            this.enableFromFilterBtn.TabIndex = 4;
            this.enableFromFilterBtn.Text = "Apply";
            this.enableFromFilterBtn.Click += new System.EventHandler(this.enableFromFilterBtn_Click);
            // 
            // stringOptionsCombo
            // 
            this.stringOptionsCombo.Location = new System.Drawing.Point(84, 43);
            this.stringOptionsCombo.Name = "stringOptionsCombo";
            this.stringOptionsCombo.Size = new System.Drawing.Size(140, 22);
            this.stringOptionsCombo.TabIndex = 3;
            this.stringOptionsCombo.SelectedIndexChanged += new System.EventHandler(this.stringOptionsCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Options:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter Text:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fromColumnFilterText1
            // 
            this.fromColumnFilterText1.Location = new System.Drawing.Point(84, 19);
            this.fromColumnFilterText1.Name = "fromColumnFilterText1";
            this.fromColumnFilterText1.Size = new System.Drawing.Size(140, 18);
            this.fromColumnFilterText1.TabIndex = 0;
            // 
            // NTreeListFilteringUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.nSplitter1);
            this.Controls.Add(this.panel2);
            this.Name = "NTreeListFilteringUC";
            this.Size = new System.Drawing.Size(569, 275);
            this.panel2.ResumeLayout(false);
            this.nGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.amountFilterNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountFilterNum1)).EndInit();
            this.nGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel containerPanel;
        private Nevron.UI.WinForm.Controls.NSplitter nSplitter1;
        private System.Windows.Forms.Panel panel2;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
        private Nevron.UI.WinForm.Controls.NButton disableFromFilterBtn;
        private Nevron.UI.WinForm.Controls.NButton enableFromFilterBtn;
        private Nevron.UI.WinForm.Controls.NComboBox stringOptionsCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NTextBox fromColumnFilterText1;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
        private Nevron.UI.WinForm.Controls.NNumericUpDown amountFilterNum1;
        private System.Windows.Forms.Label label4;
        private Nevron.UI.WinForm.Controls.NButton removeNumericFilterBtn;
        private Nevron.UI.WinForm.Controls.NButton applyNumericFilterBtn;
        private Nevron.UI.WinForm.Controls.NComboBox numericOptionsCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Nevron.UI.WinForm.Controls.NNumericUpDown amountFilterNum2;
    }
}
