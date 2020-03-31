using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NViewMessagesUC.
	/// </summary>
	public class NViewMessagesUC : NDiagramExampleUC
	{
		#region Constructor

		public NViewMessagesUC(NMainForm form) : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.customDesignerMessageButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// customDesignerMessageButton
			// 
			this.customDesignerMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.customDesignerMessageButton.Location = new System.Drawing.Point(8, 8);
			this.customDesignerMessageButton.Name = "customDesignerMessageButton";
			this.customDesignerMessageButton.Size = new System.Drawing.Size(232, 23);
			this.customDesignerMessageButton.TabIndex = 30;
			this.customDesignerMessageButton.Text = "Show custom view message";
			this.customDesignerMessageButton.Click += new System.EventHandler(this.customDesignerMessageButton_Click);
			// 
			// NViewMessagesUC
			// 
			this.Controls.Add(this.customDesignerMessageButton);
			this.Name = "NViewMessagesUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.customDesignerMessageButton, 0);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// end view init
			view.EndInit();
		}

		protected override void ResetExample()
		{
			base.ResetExample();
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
			NRectangleShape rect1 = new NRectangleShape(new NRectangleF(10, 10, 100, 100));
			document.ActiveLayer.AddChild(rect1);
			rect1.Style.FillStyle = new NColorFillStyle(Color.Red);
			rect1.Protection = new NAbilities(rect1.Protection.Mask &~ AbilitiesMask.ChangeStyle);

			NRectangleShape rect2 = new NRectangleShape (new NRectangleF(160, 160, 100, 100));
			document.ActiveLayer.AddChild(rect2);
			rect2.Style.FillStyle = new NColorFillStyle(Color.Green);

			view.Selection.SingleSelect(document.ActiveLayer.Children(NFilters.PermissionSelect));
		}

		#endregion

		#region Event Handlers

		private void customDesignerMessageButton_Click(object sender, System.EventArgs e)
		{
			view.ShowMessage("Custom view message. Click to hide this message.");
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton customDesignerMessageButton;

		#endregion

		#region Fields
		private Hashtable toolsMap = new Hashtable();
		#endregion
	}
}