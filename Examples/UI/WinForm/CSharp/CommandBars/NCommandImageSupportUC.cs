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
	/// Summary description for NCommandImageSupportUC.
	/// </summary>
	public class NCommandImageSupportUC : NExampleUserControl
	{
		#region Constructor

		public NCommandImageSupportUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
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
			base.Initialize();

			this.nCommandBarsManager1.Palette.Copy(NUIManager.Palette);

			Type t = GetType();

			nDockingToolbar1.ImageSize = new Size(48, 48);

			string path = "Nevron.Examples.UI.WinForm.Resources.Images";
			
			Bitmap bmp = NResourceHelper.BitmapFromResource(t, "Clock.png", path);
			nCommand1.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Envelope.png", path);
			nCommand2.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Flash.png", path);
			nCommand3.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Book.png", path);
			nCommand4.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Pencil.png", path);
			nCommand5.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Light.png", path);
			nCommand6.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Globe.png", path);
			nCommand7.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Mobile.png", path);
			nCommand8.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Flask.png", path);
			nCommand9.Properties.ImageInfo.Image = bmp;

			bmp = NResourceHelper.BitmapFromResource(t, "Darts.png", path);
			nCommand10.Properties.ImageInfo.Image = bmp;
		}


		#endregion

		#region Event Handlers

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.icongalore.com");
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NCommandImageSupportUC));
			this.nCommandBarsManager1 = new Nevron.UI.WinForm.Controls.NCommandBarsManager(this.components);
			this.nDockingToolbar1 = new Nevron.UI.WinForm.Controls.NDockingToolbar();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand4 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand5 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand6 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand7 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand8 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand9 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand10 = new Nevron.UI.WinForm.Controls.NCommand();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// nCommandBarsManager1
			// 
			this.nCommandBarsManager1.ParentControl = this;
			this.nCommandBarsManager1.Toolbars.Add(this.nDockingToolbar1);
			// 
			// nDockingToolbar1
			// 
			this.nDockingToolbar1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																								  this.nCommand1,
																								  this.nCommand2,
																								  this.nCommand3,
																								  this.nCommand4,
																								  this.nCommand5,
																								  this.nCommand6,
																								  this.nCommand7,
																								  this.nCommand8,
																								  this.nCommand9,
																								  this.nCommand10});
			this.nDockingToolbar1.DefaultLocation = new System.Drawing.Point(0, 0);
			this.nDockingToolbar1.Name = "nDockingToolbar1";
			this.nDockingToolbar1.PrefferedRowIndex = 0;
			this.nDockingToolbar1.RowIndex = 0;
			this.nDockingToolbar1.Text = "Custom 1";
			// 
			// nCommand1
			// 
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "Sample images used from:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(208, 104);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(144, 23);
			this.linkLabel1.TabIndex = 5;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://www.icongalore.com";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// NCommandImageSupportUC
			// 
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label1);
			this.Name = "NCommandImageSupportUC";
			this.Size = new System.Drawing.Size(528, 400);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NCommandBarsManager nCommandBarsManager1;
		private Nevron.UI.WinForm.Controls.NDockingToolbar nDockingToolbar1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NCommand nCommand3;
		private Nevron.UI.WinForm.Controls.NCommand nCommand4;
		private Nevron.UI.WinForm.Controls.NCommand nCommand5;
		private Nevron.UI.WinForm.Controls.NCommand nCommand6;
		private Nevron.UI.WinForm.Controls.NCommand nCommand7;
		private Nevron.UI.WinForm.Controls.NCommand nCommand8;
		private Nevron.UI.WinForm.Controls.NCommand nCommand9;
		private Nevron.UI.WinForm.Controls.NCommand nCommand10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.ComponentModel.IContainer components;

		#endregion
	}
}
