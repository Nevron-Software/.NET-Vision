using System;
using System.Diagnostics;
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
	/// Summary description for NNavigationPaneCollapseUC.
	/// </summary>
	public class NNavigationPaneCollapseUC : NExampleUserControl
	{
		#region Constructor

		public NNavigationPaneCollapseUC()
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

			Dock = DockStyle.Fill;
			DockPadding.All = 2;

			NNavigationPaneBand[] bands = this.nNavigationPane1.Bands;
			Debug.WriteLine(bands.Length);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nNavigationPane1 = new Nevron.UI.WinForm.Controls.NNavigationPane();
			this.nNavigationPaneBand1 = new Nevron.UI.WinForm.Controls.NNavigationPaneBand();
			this.nCalculator1 = new Nevron.UI.WinForm.Controls.NCalculator();
			this.nNavigationPaneBand2 = new Nevron.UI.WinForm.Controls.NNavigationPaneBand();
			this.nExplorerBar1 = new Nevron.UI.WinForm.Controls.NExplorerBar();
			this.nExpander1 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nExpander2 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nSplitter1 = new Nevron.UI.WinForm.Controls.NSplitter();
			((System.ComponentModel.ISupportInitialize)(this.nNavigationPane1)).BeginInit();
			this.nNavigationPane1.SuspendLayout();
			this.nNavigationPaneBand1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nCalculator1)).BeginInit();
			this.nNavigationPaneBand2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar1)).BeginInit();
			this.nExplorerBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).BeginInit();
			this.SuspendLayout();
			// 
			// nNavigationPane1
			// 
			this.nNavigationPane1.CaptionItem.Style.TextRenderMode = Nevron.UI.TextRenderMode.Gdi;
			this.nNavigationPane1.CaptionItem.Text = "Band";
			this.nNavigationPane1.Controls.Add(this.nNavigationPaneBand2);
			this.nNavigationPane1.Controls.Add(this.nNavigationPaneBand1);
			this.nNavigationPane1.Dock = System.Windows.Forms.DockStyle.Left;
			this.nNavigationPane1.Location = new System.Drawing.Point(0, 0);
			this.nNavigationPane1.Name = "nNavigationPane1";
			this.nNavigationPane1.SelectedIndex = 1;
			this.nNavigationPane1.Size = new System.Drawing.Size(288, 432);
			this.nNavigationPane1.TabIndex = 0;
			this.nNavigationPane1.Text = "nNavigationPane1";
			// 
			// nNavigationPaneBand1
			// 
			this.nNavigationPaneBand1.Controls.Add(this.nCalculator1);
			this.nNavigationPaneBand1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nNavigationPaneBand1.DockPadding.All = 2;
			this.nNavigationPaneBand1.Location = new System.Drawing.Point(1, 26);
			this.nNavigationPaneBand1.Name = "nNavigationPaneBand1";
			this.nNavigationPaneBand1.Size = new System.Drawing.Size(286, 303);
			this.nNavigationPaneBand1.TabIndex = 2;
			this.nNavigationPaneBand1.Text = "Calculator Band";
			// 
			// nCalculator1
			// 
			this.nCalculator1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nCalculator1.Location = new System.Drawing.Point(16, 40);
			this.nCalculator1.Name = "nCalculator1";
			this.nCalculator1.Size = new System.Drawing.Size(248, 216);
			this.nCalculator1.TabIndex = 0;
			this.nCalculator1.Text = "nCalculator1";
			// 
			// nNavigationPaneBand2
			// 
			this.nNavigationPaneBand2.Controls.Add(this.nExplorerBar1);
			this.nNavigationPaneBand2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nNavigationPaneBand2.DockPadding.All = 2;
			this.nNavigationPaneBand2.Location = new System.Drawing.Point(1, 26);
			this.nNavigationPaneBand2.Name = "nNavigationPaneBand2";
			this.nNavigationPaneBand2.Size = new System.Drawing.Size(286, 303);
			this.nNavigationPaneBand2.TabIndex = 3;
			this.nNavigationPaneBand2.Text = "ExplorerBar Band";
			// 
			// nExplorerBar1
			// 
			this.nExplorerBar1.ClientPadding = new Nevron.UI.NPadding(8);
			this.nExplorerBar1.Controls.Add(this.nExpander1);
			this.nExplorerBar1.Controls.Add(this.nExpander2);
			this.nExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nExplorerBar1.Location = new System.Drawing.Point(2, 2);
			this.nExplorerBar1.Name = "nExplorerBar1";
			this.nExplorerBar1.Size = new System.Drawing.Size(282, 299);
			this.nExplorerBar1.TabIndex = 0;
			this.nExplorerBar1.Text = "nExplorerBar1";
			// 
			// nExpander1
			// 
			this.nExpander1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander1.Location = new System.Drawing.Point(8, 8);
			this.nExpander1.Name = "nExpander1";
			this.nExpander1.Size = new System.Drawing.Size(266, 112);
			this.nExpander1.TabIndex = 1;
			this.nExpander1.Text = "nExpander1";
			// 
			// nExpander2
			// 
			this.nExpander2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander2.Location = new System.Drawing.Point(8, 128);
			this.nExpander2.Name = "nExpander2";
			this.nExpander2.Size = new System.Drawing.Size(266, 112);
			this.nExpander2.TabIndex = 2;
			this.nExpander2.Text = "nExpander2";
			// 
			// nSplitter1
			// 
			this.nSplitter1.Location = new System.Drawing.Point(288, 0);
			this.nSplitter1.Name = "nSplitter1";
			this.nSplitter1.Size = new System.Drawing.Size(5, 432);
			this.nSplitter1.TabIndex = 1;
			this.nSplitter1.TabStop = false;
			// 
			// NNavigationPaneCollapseUC
			// 
			this.Controls.Add(this.nSplitter1);
			this.Controls.Add(this.nNavigationPane1);
			this.Name = "NNavigationPaneCollapseUC";
			this.Size = new System.Drawing.Size(432, 432);
			((System.ComponentModel.ISupportInitialize)(this.nNavigationPane1)).EndInit();
			this.nNavigationPane1.ResumeLayout(false);
			this.nNavigationPaneBand1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nCalculator1)).EndInit();
			this.nNavigationPaneBand2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar1)).EndInit();
			this.nExplorerBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NNavigationPaneBand nNavigationPaneBand1;
		private Nevron.UI.WinForm.Controls.NNavigationPaneBand nNavigationPaneBand2;
		private Nevron.UI.WinForm.Controls.NCalculator nCalculator1;
		private Nevron.UI.WinForm.Controls.NExplorerBar nExplorerBar1;
		private Nevron.UI.WinForm.Controls.NExpander nExpander1;
		private Nevron.UI.WinForm.Controls.NExpander nExpander2;
		private Nevron.UI.WinForm.Controls.NSplitter nSplitter1;
		private Nevron.UI.WinForm.Controls.NNavigationPane nNavigationPane1;

		#endregion
	}
}
