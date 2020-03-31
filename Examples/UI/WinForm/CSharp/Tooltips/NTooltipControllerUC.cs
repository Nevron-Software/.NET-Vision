using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NTooltipControllerUC.
	/// </summary>
	public class NTooltipControllerUC : NExampleUserControl
	{
		#region Constructor

		public NTooltipControllerUC()
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


		#endregion

		#region Event Handlers

		private void nRichTextLabel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			NControl nc = (NControl)sender;
			propertyGrid.SelectedObject = nc.TooltipInfo;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NTooltipControllerUC));
			this.nRichTextLabel1 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.nRichTextLabel2 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel2)).BeginInit();
			this.SuspendLayout();
			// 
			// nRichTextLabel1
			// 
			this.nRichTextLabel1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRichTextLabel1.Location = new System.Drawing.Point(8, 344);
			this.nRichTextLabel1.Name = "nRichTextLabel1";
			this.nRichTextLabel1.Size = new System.Drawing.Size(192, 72);
			this.nRichTextLabel1.StrokeInfo.PenWidth = 3;
			this.nRichTextLabel1.StrokeInfo.Rounding = 5;
			this.nRichTextLabel1.TabIndex = 1;
			this.nRichTextLabel1.Text = "Rich Text Label 1<br/><b>Click to see its TooltipInfo.</b>";
			this.nRichTextLabel1.TooltipInfo.CaptionText = "<b>Rich Text Label 1</b>";
			this.nRichTextLabel1.TooltipInfo.ContentImage = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel1.TooltipInfo.ContentImage")));
			this.nRichTextLabel1.TooltipInfo.ContentImageSize = new Nevron.GraphicsCore.NSize(32, 32);
			this.nRichTextLabel1.TooltipInfo.ContentText = "Sample tooltip over<br/><b>Note</b> the <font face=\'Verdana\' size=\'10\' color=\'Red" +
				"\'>rich</font> text formatting.";
			this.nRichTextLabel1.TooltipInfo.FooterImage = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel1.TooltipInfo.FooterImage")));
			this.nRichTextLabel1.TooltipInfo.FooterText = "Press F1 for more help.";
			this.nRichTextLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nRichTextLabel1_MouseDown);
			// 
			// propertyGrid
			// 
			this.propertyGrid.CommandsVisibleIfAvailable = true;
			this.propertyGrid.LargeButtons = false;
			this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid.Location = new System.Drawing.Point(8, 8);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(384, 328);
			this.propertyGrid.TabIndex = 3;
			this.propertyGrid.Text = "propertyGrid1";
			this.propertyGrid.ToolbarVisible = false;
			this.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// nRichTextLabel2
			// 
			this.nRichTextLabel2.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRichTextLabel2.Location = new System.Drawing.Point(208, 344);
			this.nRichTextLabel2.Name = "nRichTextLabel2";
			this.nRichTextLabel2.Size = new System.Drawing.Size(192, 72);
			this.nRichTextLabel2.StrokeInfo.PenWidth = 3;
			this.nRichTextLabel2.StrokeInfo.Rounding = 5;
			this.nRichTextLabel2.TabIndex = 4;
			this.nRichTextLabel2.Text = "Rich Text Label 2<br/><b>Click to see its TooltipInfo.</b>";
			this.nRichTextLabel2.TooltipInfo.Background = new Nevron.UI.NImageShape(System.Drawing.Drawing2D.SmoothingMode.Default, new Nevron.GraphicsCore.NSize(0, 0), new Nevron.UI.NPadding(0, 0, 0, 0), null, ((System.Drawing.Bitmap)(resources.GetObject("resource"))), null, -1, Nevron.UI.ImageSizeMode.Stretch, true, Nevron.UI.ImageSegment.All, new Nevron.UI.NPadding(4));
			this.nRichTextLabel2.TooltipInfo.CaptionText = "<b>Rich Text Label 2</b>";
			this.nRichTextLabel2.TooltipInfo.ContentImage = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel2.TooltipInfo.ContentImage")));
			this.nRichTextLabel2.TooltipInfo.ContentImageSize = new Nevron.GraphicsCore.NSize(32, 32);
			this.nRichTextLabel2.TooltipInfo.ContentText = "Sample tooltip<br/><b>Note</b> the <font face=\'Verdana\' size=\'10\' color=\'Red\' sha" +
				"dowcolor=\'yellow\' shadowtype=\'solid\'>custom</font> background specified.";
			this.nRichTextLabel2.TooltipInfo.DefaultBorder = false;
			this.nRichTextLabel2.TooltipInfo.EnableSkinning = false;
			this.nRichTextLabel2.TooltipInfo.FooterImage = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel2.TooltipInfo.FooterImage")));
			this.nRichTextLabel2.TooltipInfo.FooterText = "Press F1 for more help.";
			this.nRichTextLabel2.TooltipInfo.Padding = new Nevron.UI.NPadding(5, 5, 4, 4);
			this.nRichTextLabel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nRichTextLabel1_MouseDown);
			// 
			// NTooltipControllerUC
			// 
			this.Controls.Add(this.nRichTextLabel2);
			this.Controls.Add(this.propertyGrid);
			this.Controls.Add(this.nRichTextLabel1);
			this.Name = "NTooltipControllerUC";
			this.Size = new System.Drawing.Size(400, 416);
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel1;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel2;

		#endregion
	}
}
