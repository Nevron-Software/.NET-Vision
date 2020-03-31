using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NMdiChildrenCustomFramesUC.
	/// </summary>
	public class NMdiChildrenCustomFramesUC : NDockingPanelsBasicFeaturesUC
	{
		#region Constructor

		public NMdiChildrenCustomFramesUC(MainForm f) : base(f)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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

		public override void Initialize()
		{
			base.Initialize ();

			m_ExampleFormType = typeof(NMdiChildrenCustomFramesForm);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
