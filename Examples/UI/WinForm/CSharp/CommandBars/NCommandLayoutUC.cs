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
	public class NCommandLayoutUC : NExampleUserControl
	{
		#region Constructor

		public NCommandLayoutUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
		}


		#endregion

		#region Implementation

		public override void Initialize()
		{
			base.Initialize();

			m_LayoutCombo.FillFromEnum(typeof(CommandLayout), true);
			m_LayoutCombo.SelectedItem = CommandLayout.HorizontalSingleRow;

			m_BackgroundTypeCombo.FillFromEnum(typeof(BackgroundType), true);
			m_BackgroundTypeCombo.SelectedItem = nToolbar3.BackgroundType;

			m_ShowGripperCheck.Checked = true;
			m_HasBorderCheck.Checked = nToolbar3.HasBorder;
		}

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

		private void m_ShowGripperCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nToolbar3.HasGripper = m_ShowGripperCheck.Checked;
		}

		private void m_LayoutCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			object o = this.m_LayoutCombo.SelectedItem;
			if(!(o is CommandLayout))
				return;

			nToolbar3.CommandLayout = (CommandLayout)o;
		}

		private void m_BackgroundTypeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			object o = m_BackgroundTypeCombo.SelectedItem;
			if(!(o is BackgroundType))
				return;

			nToolbar3.BackgroundType = (BackgroundType)o;
		}
		private void m_HasBorderCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nToolbar3.HasBorder = m_HasBorderCheck.Checked;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NCommandLayoutUC));
			this.m_ImageList = new System.Windows.Forms.ImageList(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.nToolbar3 = new Nevron.UI.WinForm.Controls.NToolbar();
			this.nCommand17 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand18 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand19 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand20 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand21 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand24 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand25 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand6 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand7 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand8 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand4 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand5 = new Nevron.UI.WinForm.Controls.NCommand();
			this.m_LayoutCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_ShowGripperCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_BackgroundTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_HasBorderCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// m_ImageList
			// 
			this.m_ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImageList.ImageStream")));
			this.m_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 280);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Layout Mode:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nToolbar3
			// 
			this.nToolbar3.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand17,
																						   this.nCommand18,
																						   this.nCommand24,
																						   this.nCommand25,
																						   this.nCommand1,
																						   this.nCommand2,
																						   this.nCommand3,
																						   this.nCommand4,
																						   this.nCommand5});
			this.nToolbar3.ImageList = this.m_ImageList;
			this.nToolbar3.Location = new System.Drawing.Point(8, 8);
			this.nToolbar3.Name = "nToolbar3";
			this.nToolbar3.Size = new System.Drawing.Size(288, 28);
			this.nToolbar3.Text = "nToolbar3";
			// 
			// nCommand17
			// 
			this.nCommand17.Properties.ImageIndex = 3;
			this.nCommand17.Properties.Text = "Command 1";
			// 
			// nCommand18
			// 
			this.nCommand18.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																							this.nCommand19,
																							this.nCommand20,
																							this.nCommand21});
			this.nCommand18.Properties.DropDownBehavior = Nevron.UI.WinForm.Controls.DropDownBehavior.AlwaysDropDown;
			this.nCommand18.Properties.ImageIndex = 5;
			// 
			// nCommand19
			// 
			this.nCommand19.Properties.ImageIndex = 6;
			this.nCommand19.Properties.Text = "Nested Command 1";
			// 
			// nCommand20
			// 
			this.nCommand20.Properties.ImageIndex = 1;
			this.nCommand20.Properties.Text = "Nested Command 2";
			// 
			// nCommand21
			// 
			this.nCommand21.Properties.ImageIndex = 2;
			this.nCommand21.Properties.Text = "Nested Command 3";
			// 
			// nCommand24
			// 
			this.nCommand24.Properties.ImageIndex = 4;
			this.nCommand24.Properties.PressedImageIndex = 0;
			this.nCommand24.Properties.SelectedImageIndex = 7;
			// 
			// nCommand25
			// 
			this.nCommand25.Properties.BeginGroup = true;
			this.nCommand25.Properties.ImageIndex = 12;
			// 
			// nCommand1
			// 
			this.nCommand1.Properties.ImageIndex = 8;
			// 
			// nCommand2
			// 
			this.nCommand2.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand6,
																						   this.nCommand7,
																						   this.nCommand8});
			this.nCommand2.Properties.BeginGroup = true;
			this.nCommand2.Properties.ImageIndex = 15;
			this.nCommand2.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nCommand2.Properties.Text = "New...";
			// 
			// nCommand6
			// 
			this.nCommand6.Properties.Text = "Project...";
			// 
			// nCommand7
			// 
			this.nCommand7.Properties.Text = "Blank Solution";
			// 
			// nCommand8
			// 
			this.nCommand8.Properties.Text = "File...";
			// 
			// nCommand3
			// 
			this.nCommand3.Properties.ImageIndex = 16;
			// 
			// nCommand4
			// 
			this.nCommand4.Properties.ImageIndex = 18;
			// 
			// nCommand5
			// 
			this.nCommand5.Properties.ImageIndex = 7;
			// 
			// m_LayoutCombo
			// 
			this.m_LayoutCombo.Location = new System.Drawing.Point(120, 280);
			this.m_LayoutCombo.Name = "m_LayoutCombo";
			this.m_LayoutCombo.Size = new System.Drawing.Size(184, 22);
			this.m_LayoutCombo.TabIndex = 14;
			this.m_LayoutCombo.Text = "nComboBox1";
			this.m_LayoutCombo.SelectedIndexChanged += new System.EventHandler(this.m_LayoutCombo_SelectedIndexChanged);
			// 
			// m_ShowGripperCheck
			// 
			this.m_ShowGripperCheck.Location = new System.Drawing.Point(120, 344);
			this.m_ShowGripperCheck.Name = "m_ShowGripperCheck";
			this.m_ShowGripperCheck.TabIndex = 16;
			this.m_ShowGripperCheck.Text = "Has Gripper";
			this.m_ShowGripperCheck.TransparentBackground = true;
			this.m_ShowGripperCheck.CheckedChanged += new System.EventHandler(this.m_ShowGripperCheck_CheckedChanged);
			// 
			// m_BackgroundTypeCombo
			// 
			this.m_BackgroundTypeCombo.Location = new System.Drawing.Point(120, 312);
			this.m_BackgroundTypeCombo.Name = "m_BackgroundTypeCombo";
			this.m_BackgroundTypeCombo.Size = new System.Drawing.Size(184, 22);
			this.m_BackgroundTypeCombo.TabIndex = 19;
			this.m_BackgroundTypeCombo.Text = "nComboBox1";
			this.m_BackgroundTypeCombo.SelectedIndexChanged += new System.EventHandler(this.m_BackgroundTypeCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 312);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 23);
			this.label1.TabIndex = 18;
			this.label1.Text = "Background Type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_HasBorderCheck
			// 
			this.m_HasBorderCheck.Location = new System.Drawing.Point(120, 368);
			this.m_HasBorderCheck.Name = "m_HasBorderCheck";
			this.m_HasBorderCheck.TabIndex = 21;
			this.m_HasBorderCheck.Text = "Has Border";
			this.m_HasBorderCheck.TransparentBackground = true;
			this.m_HasBorderCheck.CheckedChanged += new System.EventHandler(this.m_HasBorderCheck_CheckedChanged);
			// 
			// NCommandLayoutUC
			// 
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.Controls.Add(this.m_HasBorderCheck);
			this.Controls.Add(this.m_BackgroundTypeCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_ShowGripperCheck);
			this.Controls.Add(this.m_LayoutCombo);
			this.Controls.Add(this.nToolbar3);
			this.Controls.Add(this.label3);
			this.DockPadding.All = 2;
			this.Name = "NCommandLayoutUC";
			this.Size = new System.Drawing.Size(312, 408);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.IContainer components;
		internal System.Windows.Forms.ImageList m_ImageList;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NToolbar nToolbar3;
		private Nevron.UI.WinForm.Controls.NCommand nCommand17;
		private Nevron.UI.WinForm.Controls.NCommand nCommand18;
		private Nevron.UI.WinForm.Controls.NCommand nCommand19;
		private Nevron.UI.WinForm.Controls.NCommand nCommand20;
		private Nevron.UI.WinForm.Controls.NCommand nCommand21;
		private Nevron.UI.WinForm.Controls.NCommand nCommand24;
		private Nevron.UI.WinForm.Controls.NComboBox m_LayoutCombo;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowGripperCheck;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NCommand nCommand3;
		private Nevron.UI.WinForm.Controls.NCommand nCommand4;
		private Nevron.UI.WinForm.Controls.NCommand nCommand5;
		private Nevron.UI.WinForm.Controls.NCommand nCommand6;
		private Nevron.UI.WinForm.Controls.NCommand nCommand7;
		private Nevron.UI.WinForm.Controls.NCommand nCommand8;
		private Nevron.UI.WinForm.Controls.NComboBox m_BackgroundTypeCombo;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_HasBorderCheck;
		private Nevron.UI.WinForm.Controls.NCommand nCommand25;

		#endregion
	}
}
