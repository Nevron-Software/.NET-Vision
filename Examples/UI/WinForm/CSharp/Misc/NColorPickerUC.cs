using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NColorPickerUC.
	/// </summary>
	public class NColorPickerUC : NExampleUserControl
	{
		#region Constructor

		public NColorPickerUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Implementation

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


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nColorPicker1 = new Nevron.UI.WinForm.Controls.NColorPicker();
			this.SuspendLayout();
			// 
			// nColorPicker1
			// 
			this.nColorPicker1.Location = new System.Drawing.Point(0, 0);
			this.nColorPicker1.Name = "nColorPicker1";
			this.nColorPicker1.Size = new System.Drawing.Size(280, 336);
			this.nColorPicker1.TabIndex = 0;
			// 
			// NColorPickerUC
			// 
			this.Controls.Add(this.nColorPicker1);
			this.Name = "NColorPickerUC";
			this.Size = new System.Drawing.Size(280, 336);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NColorPicker nColorPicker1;

		#endregion
	}
}
