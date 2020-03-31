using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NTooltipUC.
	/// </summary>
	public class NTooltipUC : NExampleUserControl
	{
		#region Constructor

		public NTooltipUC(MainForm f) : base(f)
		{
			InitializeComponent();

			m_Properties.SelectedObject = nTooltip1;
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
				if(nTooltip1 != null)
					nTooltip1.Dispose();

			}
			base.Dispose( disposing );
		}


		#endregion

		#region Event Handlers

		private void nRichTextLabel1_MouseEnter(object sender, System.EventArgs e)
		{
			nTooltip1.SetTooltip(nRichTextLabel1);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NTooltipUC));
			this.nRichTextLabel1 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.m_Properties = new System.Windows.Forms.PropertyGrid();
			this.nTooltip1 = new Nevron.UI.WinForm.Controls.NTooltip();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).BeginInit();
			this.SuspendLayout();
			// 
			// nRichTextLabel1
			// 
			this.nRichTextLabel1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRichTextLabel1.Item.Padding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nRichTextLabel1.Item.Style.RichTextFormat = new Nevron.UI.NRichTextFormat(Nevron.GraphicsCore.LineTrimStyle.Word, Nevron.GraphicsCore.ParagraphAlignment.Center, 0, 0, 0, 0, 0, 0, 0);
			this.nRichTextLabel1.Location = new System.Drawing.Point(8, 8);
			this.nRichTextLabel1.Name = "nRichTextLabel1";
			this.nRichTextLabel1.Size = new System.Drawing.Size(208, 72);
			this.nRichTextLabel1.TabIndex = 0;
			this.nRichTextLabel1.Text = "Hover this label to display the tooltip. Change tooltip\'s content properties from" +
				" the property grid.";
			this.nRichTextLabel1.MouseEnter += new System.EventHandler(this.nRichTextLabel1_MouseEnter);
			// 
			// m_Properties
			// 
			this.m_Properties.CommandsVisibleIfAvailable = true;
			this.m_Properties.LargeButtons = false;
			this.m_Properties.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.m_Properties.Location = new System.Drawing.Point(224, 8);
			this.m_Properties.Name = "m_Properties";
			this.m_Properties.Size = new System.Drawing.Size(256, 272);
			this.m_Properties.TabIndex = 1;
			this.m_Properties.Text = "propertyGrid1";
			this.m_Properties.ToolbarVisible = false;
			this.m_Properties.ViewBackColor = System.Drawing.SystemColors.Window;
			this.m_Properties.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// nTooltip1
			// 
			this.nTooltip1.Content.AutoSizeMask = Nevron.UI.AutoSizeMask.Both;
			this.nTooltip1.Content.Image = ((System.Drawing.Image)(resources.GetObject("nTooltip1.Content.Image")));
			this.nTooltip1.Content.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.nTooltip1.Content.ImageSize = new Nevron.GraphicsCore.NSize(32, 32);
			this.nTooltip1.Content.Padding = new Nevron.UI.NPadding(0, 2, 0, 0);
			this.nTooltip1.Content.Text = "The Nevron NTooltip component allows you<br/>to display <b>Office 2007</b> style " +
				"super tooltips<br/>with support for <u>rich</u> text and images.";
			this.nTooltip1.Content.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.nTooltip1.Content.TreatAsOneEntity = false;
			this.nTooltip1.Heading.AutoSizeMask = Nevron.UI.AutoSizeMask.Both;
			this.nTooltip1.Heading.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.nTooltip1.Heading.Text = "<b>Nevron NTooltip</b>";
			this.nTooltip1.Heading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.nTooltip1.Heading.TreatAsOneEntity = false;
			this.nTooltip1.HideDelay = 100;
			this.nTooltip1.ShowDelay = 700;
			// 
			// NTooltipUC
			// 
			this.Controls.Add(this.m_Properties);
			this.Controls.Add(this.nRichTextLabel1);
			this.Name = "NTooltipUC";
			this.Size = new System.Drawing.Size(488, 288);
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel1;
		private System.Windows.Forms.PropertyGrid m_Properties;
		private Nevron.UI.WinForm.Controls.NTooltip nTooltip1;
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
