using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NGalleryPanelThumbnailPreviewUC.
	/// </summary>
	public class NGalleryPanelThumbnailPreviewUC : NExampleUserControl
	{
		#region Constructor

		public NGalleryPanelThumbnailPreviewUC()
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

			this.nGalleryPanel1.ItemSelectionChanged += new NGalleryItemSelectionChangedEventHandler(nGalleryPanel1_ItemSelectionChanged);

			foreach(NGalleryItem item in nGalleryPanel1.Items)
			{
				item.Label.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				item.Label.Style.TextShadowStyle = new NShadowStyle(ShadowType.LinearBlur, Color.Gray, 1, 1, 1F, 1);
			}

			nGalleryItem1.Selected = true;
			previewBox.Image = nGalleryItem1.Label.Image;
		}



		#endregion

		#region Event Handlers

		private void nGalleryPanel1_ItemSelectionChanged(object sender, NGalleryItemSelectionChangedEventArgs e)
		{
			if(e.Change == GalleryItemSelectionChange.Selected)
			{
				previewBox.Image = e.Item.Label.Image;
			}
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NGalleryPanelThumbnailPreviewUC));
			this.previewBox = new System.Windows.Forms.PictureBox();
			this.nGalleryPanel1 = new Nevron.UI.WinForm.Controls.NGalleryPanel();
			this.nGalleryItem1 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem2 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem3 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem4 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem5 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem6 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem7 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem8 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem9 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			this.nGalleryItem10 = new Nevron.UI.WinForm.Controls.NGalleryItem();
			((System.ComponentModel.ISupportInitialize)(this.nGalleryPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// previewBox
			// 
			this.previewBox.Location = new System.Drawing.Point(136, 8);
			this.previewBox.Name = "previewBox";
			this.previewBox.Size = new System.Drawing.Size(256, 256);
			this.previewBox.TabIndex = 0;
			this.previewBox.TabStop = false;
			// 
			// nGalleryPanel1
			// 
			this.nGalleryPanel1.ItemLayout = Nevron.UI.WinForm.Controls.GalleryPanelLayout.HorizontalStack;
			this.nGalleryPanel1.Items.AddRange(new Nevron.UI.WinForm.Controls.NGalleryItem[] {
																								 this.nGalleryItem1,
																								 this.nGalleryItem2,
																								 this.nGalleryItem3,
																								 this.nGalleryItem4,
																								 this.nGalleryItem5,
																								 this.nGalleryItem6,
																								 this.nGalleryItem7,
																								 this.nGalleryItem8,
																								 this.nGalleryItem9,
																								 this.nGalleryItem10});
			this.nGalleryPanel1.ItemSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryPanel1.Location = new System.Drawing.Point(8, 272);
			this.nGalleryPanel1.Name = "nGalleryPanel1";
			this.nGalleryPanel1.Size = new System.Drawing.Size(520, 182);
			this.nGalleryPanel1.TabIndex = 1;
			this.nGalleryPanel1.Text = "nGalleryPanel1";
			// 
			// nGalleryItem1
			// 
			this.nGalleryItem1.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem1.Label.Image")));
			this.nGalleryItem1.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem1.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem1.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem1.Label.Text = "Gallery Item 1";
			// 
			// nGalleryItem2
			// 
			this.nGalleryItem2.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem2.Label.Image")));
			this.nGalleryItem2.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem2.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem2.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem2.Label.Text = "Gallery Item 2";
			// 
			// nGalleryItem3
			// 
			this.nGalleryItem3.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem3.Label.Image")));
			this.nGalleryItem3.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem3.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem3.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem3.Label.Text = "Gallery Item 3";
			// 
			// nGalleryItem4
			// 
			this.nGalleryItem4.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem4.Label.Image")));
			this.nGalleryItem4.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem4.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem4.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem4.Label.Text = "Gallery Item 4";
			// 
			// nGalleryItem5
			// 
			this.nGalleryItem5.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem5.Label.Image")));
			this.nGalleryItem5.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem5.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem5.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem5.Label.Text = "Gallery Item 5";
			// 
			// nGalleryItem6
			// 
			this.nGalleryItem6.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem6.Label.Image")));
			this.nGalleryItem6.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem6.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem6.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem6.Label.Text = "Gallery Item 6";
			// 
			// nGalleryItem7
			// 
			this.nGalleryItem7.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem7.Label.Image")));
			this.nGalleryItem7.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem7.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem7.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem7.Label.Text = "Gallery Item 7";
			// 
			// nGalleryItem8
			// 
			this.nGalleryItem8.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem8.Label.Image")));
			this.nGalleryItem8.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem8.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem8.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem8.Label.Text = "Gallery Item 8";
			// 
			// nGalleryItem9
			// 
			this.nGalleryItem9.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem9.Label.Image")));
			this.nGalleryItem9.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem9.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem9.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem9.Label.Text = "Gallery Item 9";
			// 
			// nGalleryItem10
			// 
			this.nGalleryItem10.Label.Image = ((System.Drawing.Image)(resources.GetObject("nGalleryItem10.Label.Image")));
			this.nGalleryItem10.Label.ImageSize = new Nevron.GraphicsCore.NSize(128, 128);
			this.nGalleryItem10.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nGalleryItem10.Label.Padding = new Nevron.UI.NPadding(4);
			this.nGalleryItem10.Label.Text = "Gallery Item 10";
			// 
			// NGalleryPanelThumbnailPreviewUC
			// 
			this.Controls.Add(this.nGalleryPanel1);
			this.Controls.Add(this.previewBox);
			this.Name = "NGalleryPanelThumbnailPreviewUC";
			this.Size = new System.Drawing.Size(560, 472);
			((System.ComponentModel.ISupportInitialize)(this.nGalleryPanel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PictureBox previewBox;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem1;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem2;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem3;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem4;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem5;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem6;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem7;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem8;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem9;
		private Nevron.UI.WinForm.Controls.NGalleryItem nGalleryItem10;
		private Nevron.UI.WinForm.Controls.NGalleryPanel nGalleryPanel1;

		#endregion
	}
}
