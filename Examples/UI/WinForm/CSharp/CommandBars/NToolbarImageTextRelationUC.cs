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
	/// Summary description for NToolbarImageTextRelationUC.
	/// </summary>
	public class NToolbarImageTextRelationUC : NExampleUserControl
	{
		#region Constructor

		public NToolbarImageTextRelationUC()
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

			relationCombo.FillFromEnum(typeof(ImageTextRelation));
			relationCombo.SelectedItem = ImageTextRelation.ImageBeforeText;
		}


		#endregion

		#region Event Handlers

		private void relationCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			nToolbar1.ImageTextRelation = (ImageTextRelation)relationCombo.SelectedItem;
		}
		private void verticalCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nToolbar1.CommandLayout = verticalCheck.Checked ? CommandLayout.VerticalSingleColumn : CommandLayout.HorizontalSingleRow;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NToolbarImageTextRelationUC));
			this.nToolbar1 = new Nevron.UI.WinForm.Controls.NToolbar();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand4 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand5 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand6 = new Nevron.UI.WinForm.Controls.NCommand();
			this.label1 = new System.Windows.Forms.Label();
			this.relationCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.verticalCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCommand9 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand10 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand11 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand12 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand13 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand14 = new Nevron.UI.WinForm.Controls.NCommand();
			this.SuspendLayout();
			// 
			// nToolbar1
			// 
			this.nToolbar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.ControlSpecific;
			this.nToolbar1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand1,
																						   this.nCommand2,
																						   this.nCommand3,
																						   this.nCommand4,
																						   this.nCommand5,
																						   this.nCommand6});
			this.nToolbar1.CommandSize = new System.Drawing.Size(32, 32);
			this.nToolbar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nToolbar1.HasBorder = true;
			this.nToolbar1.HasGripper = false;
			this.nToolbar1.ImageSize = new System.Drawing.Size(24, 24);
			this.nToolbar1.Location = new System.Drawing.Point(8, 8);
			this.nToolbar1.Name = "nToolbar1";
			this.nToolbar1.Size = new System.Drawing.Size(466, 38);
			this.nToolbar1.Text = "nToolbar1";
			// 
			// nCommand1
			// 
			this.nCommand1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand9,
																						   this.nCommand10});
			this.nCommand1.Properties.ImageInfo.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
			this.nCommand1.Properties.Text = "Mail";
			// 
			// nCommand2
			// 
			this.nCommand2.Properties.ImageInfo.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
			this.nCommand2.Properties.Text = "Calendar";
			// 
			// nCommand3
			// 
			this.nCommand3.Properties.ImageInfo.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
			this.nCommand3.Properties.Text = "Contacts";
			// 
			// nCommand4
			// 
			this.nCommand4.Properties.ImageInfo.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
			this.nCommand4.Properties.Text = "Tasks";
			// 
			// nCommand5
			// 
			this.nCommand5.Properties.ImageInfo.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
			this.nCommand5.Properties.Text = "Notes";
			// 
			// nCommand6
			// 
			this.nCommand6.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand11,
																						   this.nCommand12,
																						   this.nCommand13,
																						   this.nCommand14});
			this.nCommand6.Properties.ImageInfo.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
			this.nCommand6.Properties.Text = "Folders";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(120, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Image Text Relation:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// relationCombo
			// 
			this.relationCombo.Location = new System.Drawing.Point(248, 72);
			this.relationCombo.Name = "relationCombo";
			this.relationCombo.Size = new System.Drawing.Size(192, 24);
			this.relationCombo.TabIndex = 2;
			this.relationCombo.Text = "nComboBox1";
			this.relationCombo.SelectedIndexChanged += new System.EventHandler(this.relationCombo_SelectedIndexChanged);
			// 
			// verticalCheck
			// 
			this.verticalCheck.ButtonProperties.BorderOffset = 2;
			this.verticalCheck.Location = new System.Drawing.Point(248, 104);
			this.verticalCheck.Name = "verticalCheck";
			this.verticalCheck.Size = new System.Drawing.Size(192, 24);
			this.verticalCheck.TabIndex = 4;
			this.verticalCheck.Text = "Vertical Layout";
			this.verticalCheck.CheckedChanged += new System.EventHandler(this.verticalCheck_CheckedChanged);
			// 
			// nCommand9
			// 
			this.nCommand9.Properties.Text = "Sub Command 1";
			// 
			// nCommand10
			// 
			this.nCommand10.Properties.Text = "Sub Command 2";
			// 
			// nCommand11
			// 
			this.nCommand11.Properties.Text = "Sub Command 1";
			// 
			// nCommand12
			// 
			this.nCommand12.Properties.Text = "Sub Command 2";
			// 
			// nCommand13
			// 
			this.nCommand13.Properties.Text = "Sub Command 3";
			// 
			// nCommand14
			// 
			this.nCommand14.Properties.Text = "Sub Command 4";
			// 
			// NToolbarImageTextRelationUC
			// 
			this.Controls.Add(this.verticalCheck);
			this.Controls.Add(this.relationCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nToolbar1);
			this.Name = "NToolbarImageTextRelationUC";
			this.Size = new System.Drawing.Size(488, 144);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NToolbar nToolbar1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NCommand nCommand3;
		private Nevron.UI.WinForm.Controls.NCommand nCommand4;
		private Nevron.UI.WinForm.Controls.NCommand nCommand5;
		private Nevron.UI.WinForm.Controls.NCommand nCommand6;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NCheckBox verticalCheck;
		private Nevron.UI.WinForm.Controls.NCommand nCommand9;
		private Nevron.UI.WinForm.Controls.NCommand nCommand10;
		private Nevron.UI.WinForm.Controls.NCommand nCommand11;
		private Nevron.UI.WinForm.Controls.NCommand nCommand12;
		private Nevron.UI.WinForm.Controls.NCommand nCommand13;
		private Nevron.UI.WinForm.Controls.NCommand nCommand14;
		private Nevron.UI.WinForm.Controls.NComboBox relationCombo;

		#endregion
	}
}
