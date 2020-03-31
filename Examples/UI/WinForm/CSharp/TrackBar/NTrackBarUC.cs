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
	/// Summary description for NTrackBarUC.
	/// </summary>
	public class NTrackBarUC : NExampleUserControl
	{
		#region Constructor

		public NTrackBarUC()
		{
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

			m_PropertyGrid.SelectedObject = nTrackBar1;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nTrackBar1 = new Nevron.UI.WinForm.Controls.NTrackBar();
			this.m_PropertyGrid = new System.Windows.Forms.PropertyGrid();
			((System.ComponentModel.ISupportInitialize)(this.nTrackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// nTrackBar1
			// 
			this.nTrackBar1.Location = new System.Drawing.Point(8, 8);
			this.nTrackBar1.Name = "nTrackBar1";
			this.nTrackBar1.Size = new System.Drawing.Size(282, 39);
			this.nTrackBar1.TabIndex = 0;
			this.nTrackBar1.Text = "nTrackBar1";
			// 
			// m_PropertyGrid
			// 
			this.m_PropertyGrid.CommandsVisibleIfAvailable = true;
			this.m_PropertyGrid.LargeButtons = false;
			this.m_PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.m_PropertyGrid.Location = new System.Drawing.Point(312, 0);
			this.m_PropertyGrid.Name = "m_PropertyGrid";
			this.m_PropertyGrid.Size = new System.Drawing.Size(248, 312);
			this.m_PropertyGrid.TabIndex = 1;
			this.m_PropertyGrid.Text = "propertyGrid1";
			this.m_PropertyGrid.ToolbarVisible = false;
			this.m_PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.m_PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// NTrackBarUC
			// 
			this.Controls.Add(this.m_PropertyGrid);
			this.Controls.Add(this.nTrackBar1);
			this.Name = "NTrackBarUC";
			this.Size = new System.Drawing.Size(560, 312);
			((System.ComponentModel.ISupportInitialize)(this.nTrackBar1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PropertyGrid m_PropertyGrid;

		private Nevron.UI.WinForm.Controls.NTrackBar nTrackBar1;

		#endregion
	}
}
