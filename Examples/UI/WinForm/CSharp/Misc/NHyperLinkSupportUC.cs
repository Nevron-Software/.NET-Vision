using System;
using System.Diagnostics;
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
	/// Summary description for NHyperLinkSupportUC.
	/// </summary>
	public class NHyperLinkSupportUC : NExampleUserControl
	{
		#region Constructor

		public NHyperLinkSupportUC(MainForm f) : base(f)
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

			this.nRichTextLabel1.Item.HyperLinkClick += new Nevron.UI.NHyperLinkEventHandler(OnHyperLinkClick);
		}


		#endregion

		#region Event Handlers

		private void OnHyperLinkClick(object sender, Nevron.UI.NHyperLinkEventArgs e)
		{
			string url = e.Url;
			Process.Start(url);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nRichTextLabel1 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).BeginInit();
			this.SuspendLayout();
			// 
			// nRichTextLabel1
			// 
			this.nRichTextLabel1.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista;
			this.nRichTextLabel1.Item.Padding = new Nevron.UI.NPadding(5, 5, 5, 5);
			this.nRichTextLabel1.Location = new System.Drawing.Point(8, 8);
			this.nRichTextLabel1.Name = "nRichTextLabel1";
			this.nRichTextLabel1.Size = new System.Drawing.Size(352, 64);
			this.nRichTextLabel1.StrokeInfo.PenWidth = 3;
			this.nRichTextLabel1.StrokeInfo.Rounding = 10;
			this.nRichTextLabel1.TabIndex = 0;
			this.nRichTextLabel1.Text = "Since Q4 2006 Nevron Rich Texts support hyper links. For more information visit <" +
				"a href=\'http://www.nevron.com\'>our web site</a>.";
			// 
			// NHyperLinkSupportUC
			// 
			this.Controls.Add(this.nRichTextLabel1);
			this.Name = "NHyperLinkSupportUC";
			this.Size = new System.Drawing.Size(360, 80);
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel1;

		#endregion
	}
}
