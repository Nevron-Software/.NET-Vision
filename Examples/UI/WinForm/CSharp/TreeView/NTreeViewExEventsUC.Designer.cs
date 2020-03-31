namespace Nevron.Examples.UI.WinForm
{
    partial class NTreeViewExEventsUC
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
            this.trackNotificationsList = new Nevron.UI.WinForm.Controls.NListBox();
            this.clearLogBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelNotificationList = new Nevron.UI.WinForm.Controls.NListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.batchUpdatesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nSplitter1 = new Nevron.UI.WinForm.Controls.NSplitter();
            this.nSplitter2 = new Nevron.UI.WinForm.Controls.NSplitter();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTreeViewEx1
            // 
            this.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeViewEx1.Location = new System.Drawing.Point(0, 0);
            this.nTreeViewEx1.Name = "nTreeViewEx1";
            this.nTreeViewEx1.Size = new System.Drawing.Size(492, 254);
            this.nTreeViewEx1.TabIndex = 0;
            this.nTreeViewEx1.Text = "nTreeViewEx1";
            // 
            // trackNotificationsList
            // 
            this.trackNotificationsList.ColumnOnLeft = false;
            this.trackNotificationsList.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackNotificationsList.Location = new System.Drawing.Point(0, 23);
            this.trackNotificationsList.Name = "trackNotificationsList";
            this.trackNotificationsList.Size = new System.Drawing.Size(246, 164);
            this.trackNotificationsList.TabIndex = 1;
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.Location = new System.Drawing.Point(6, 26);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(75, 23);
            this.clearLogBtn.TabIndex = 0;
            this.clearLogBtn.Text = "Clear Log";
            this.clearLogBtn.Click += new System.EventHandler(this.clearLogBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelNotificationList);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.trackNotificationsList);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(497, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 445);
            this.panel1.TabIndex = 4;
            // 
            // cancelNotificationList
            // 
            this.cancelNotificationList.ColumnOnLeft = false;
            this.cancelNotificationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelNotificationList.Location = new System.Drawing.Point(0, 210);
            this.cancelNotificationList.Name = "cancelNotificationList";
            this.cancelNotificationList.Size = new System.Drawing.Size(246, 183);
            this.cancelNotificationList.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 187);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(246, 23);
            this.panel6.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cancel Notifications:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(246, 23);
            this.panel5.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Track Notifications:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.batchUpdatesCheck);
            this.panel2.Controls.Add(this.clearLogBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 393);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 52);
            this.panel2.TabIndex = 2;
            // 
            // batchUpdatesCheck
            // 
            this.batchUpdatesCheck.AutoSize = true;
            this.batchUpdatesCheck.ButtonProperties.BorderOffset = 2;
            this.batchUpdatesCheck.Location = new System.Drawing.Point(6, 3);
            this.batchUpdatesCheck.Name = "batchUpdatesCheck";
            this.batchUpdatesCheck.Size = new System.Drawing.Size(133, 17);
            this.batchUpdatesCheck.TabIndex = 1;
            this.batchUpdatesCheck.Text = "Enable Batch Updates";
            this.batchUpdatesCheck.CheckedChanged += new System.EventHandler(this.batchUpdatesCheck_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nTextBox1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 259);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(497, 186);
            this.panel3.TabIndex = 5;
            // 
            // nTextBox1
            // 
            this.nTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTextBox1.Location = new System.Drawing.Point(0, 25);
            this.nTextBox1.Multiline = true;
            this.nTextBox1.Name = "nTextBox1";
            this.nTextBox1.Size = new System.Drawing.Size(497, 161);
            this.nTextBox1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(497, 25);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event Log List:";
            // 
            // nSplitter1
            // 
            this.nSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.nSplitter1.Location = new System.Drawing.Point(492, 0);
            this.nSplitter1.Name = "nSplitter1";
            this.nSplitter1.Size = new System.Drawing.Size(5, 259);
            this.nSplitter1.TabIndex = 6;
            this.nSplitter1.TabStop = false;
            // 
            // nSplitter2
            // 
            this.nSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nSplitter2.Location = new System.Drawing.Point(0, 254);
            this.nSplitter2.Name = "nSplitter2";
            this.nSplitter2.Size = new System.Drawing.Size(492, 5);
            this.nSplitter2.TabIndex = 7;
            this.nSplitter2.TabStop = false;
            // 
            // NTreeViewExEventsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nTreeViewEx1);
            this.Controls.Add(this.nSplitter2);
            this.Controls.Add(this.nSplitter1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "NTreeViewExEventsUC";
            this.Size = new System.Drawing.Size(743, 445);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTreeViewEx nTreeViewEx1;
        private Nevron.UI.WinForm.Controls.NListBox trackNotificationsList;
        private Nevron.UI.WinForm.Controls.NButton clearLogBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NSplitter nSplitter1;
        private Nevron.UI.WinForm.Controls.NSplitter nSplitter2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NCheckBox batchUpdatesCheck;
        private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;
        private Nevron.UI.WinForm.Controls.NListBox cancelNotificationList;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
    }
}
