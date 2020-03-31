using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NHistoryTransactionNameForm.
	/// </summary>
	public class NHistoryTransactionNameForm : System.Windows.Forms.Form
	{
		private Nevron.UI.WinForm.Controls.NButton cancelBtn;
		private Nevron.UI.WinForm.Controls.NButton okButton;
		private Nevron.UI.WinForm.Controls.NTextBox titleTextBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NHistoryTransactionNameForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cancelBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.okButton = new Nevron.UI.WinForm.Controls.NButton();
			this.titleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(198, 40);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.TabIndex = 2;
			this.cancelBtn.Text = "Cancel";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(118, 40);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			// 
			// titleTextBox
			// 
			this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.titleTextBox.ErrorMessage = null;
			this.titleTextBox.Location = new System.Drawing.Point(8, 8);
			this.titleTextBox.Name = "titleTextBox";
			this.titleTextBox.Size = new System.Drawing.Size(262, 20);
			this.titleTextBox.TabIndex = 0;
			this.titleTextBox.Text = "My transaction";
			this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
			// 
			// NHistoryTransactionNameForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(282, 72);
			this.ControlBox = false;
			this.Controls.Add(this.titleTextBox);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NHistoryTransactionNameForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Enter transaction name";
			this.ResumeLayout(false);

		}
		#endregion

		private void titleTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if (titleTextBox.Text.Length == 0)
			{
				okButton.Enabled = false;
				return;
			}

			okButton.Enabled = true;
		}

		public string TransactionTitle
		{
			get {return titleTextBox.Text;}
		}
	}
}
