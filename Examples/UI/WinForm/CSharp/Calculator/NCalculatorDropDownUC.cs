using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NCalculatorDropDownUC.
	/// </summary>
	public class NCalculatorDropDownUC : NPopupDropDownUC
	{
		#region Constructor

		public NCalculatorDropDownUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		internal override NPopupDropDownControl GetDropDownControl()
		{
			return nCalculatorDropDown1;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nCalculatorDropDown1 = new Nevron.UI.WinForm.Controls.NCalculatorDropDown();
			this.popupInstancePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// popupInstancePanel
			// 
			this.popupInstancePanel.Controls.Add(this.nCalculatorDropDown1);
			this.popupInstancePanel.Name = "popupInstancePanel";
			// 
			// nCalculatorDropDown1
			// 
			this.nCalculatorDropDown1.Location = new System.Drawing.Point(8, 8);
			this.nCalculatorDropDown1.Name = "nCalculatorDropDown1";
			this.nCalculatorDropDown1.Size = new System.Drawing.Size(312, 24);
			this.nCalculatorDropDown1.TabIndex = 0;
			this.nCalculatorDropDown1.Text = "nCalculatorDropDown1";
			// 
			// NCalculatorDropDownUC
			// 
			this.Name = "NCalculatorDropDownUC";
			this.Size = new System.Drawing.Size(336, 264);
			this.popupInstancePanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NCalculatorDropDown nCalculatorDropDown1;

		#endregion
	}
}
