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
	/// <summary>
	/// Summary description for NCommandAppearanceUC.
	/// </summary>
	public class NCommandAppearanceUC : NExampleUserControl
	{
		#region Constructor

		public NCommandAppearanceUC(MainForm f) : base(f)
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
			base.Initialize ();

			m_BackgroundTypeCombo.FillFromEnum(typeof(BackgroundType));
			m_BackgroundTypeCombo.SelectedItem = BackgroundType.SolidColor;

			m_ShowTooltipsCheck.Checked = true;
			m_HasGripperCheck.Checked = false;
			m_HasBorderCheck.Checked = false;
		}




		#endregion

		#region Event Handlers

		private void m_BackgroundTypeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BackgroundType type = (BackgroundType)m_BackgroundTypeCombo.SelectedIndex;

			nToolbar1.BackgroundType = type;
            nToolbar2.BackgroundType = type;
			nToolbar3.BackgroundType = type;
		}

		private void m_HasBorderCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			bool hasBorder = m_HasBorderCheck.Checked;
			nToolbar1.HasBorder = hasBorder;
			nToolbar2.HasBorder = hasBorder;
			nToolbar3.HasBorder = hasBorder;
		}

		private void m_HasGripperCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			bool hasGripper = m_HasGripperCheck.Checked;
			nToolbar1.HasGripper = hasGripper;
			nToolbar2.HasGripper = hasGripper;
			nToolbar3.HasGripper = hasGripper;
		}

		private void m_ShowTooltipsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			int count = Controls.Count;
			NCommandParent parent;

			for(int i = 0; i < count; i++)
			{
				parent = Controls[i] as NCommandParent;
                if (parent != null)
                {
                    parent.ShowTooltips = m_ShowTooltipsCheck.Checked;
                }
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NCommandAppearanceUC));
			this.nCommand22 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand20 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand23 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand26 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand24 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand7 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand8 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand17 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand18 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand19 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand21 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand6 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand27 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand36 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand35 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand37 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand39 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand38 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand30 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand31 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand32 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand33 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand34 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand28 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand5 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand11 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand10 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nToolbar1 = new Nevron.UI.WinForm.Controls.NToolbar();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand9 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand12 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand13 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand15 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand16 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand14 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand4 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand25 = new Nevron.UI.WinForm.Controls.NCommand();
			this.m_ImageList = new System.Windows.Forms.ImageList(this.components);
			this.nCommand29 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nToolbar3 = new Nevron.UI.WinForm.Controls.NToolbar();
			this.nToolbar2 = new Nevron.UI.WinForm.Controls.NToolbar();
			this.m_HasGripperCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_ShowTooltipsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_HasBorderCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_BackgroundTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// nCommand22
			// 
			this.nCommand22.Properties.BeginGroup = true;
			this.nCommand22.Properties.ImageIndex = 5;
			this.nCommand22.Properties.Text = "Nested Command 2";
			// 
			// nCommand20
			// 
			this.nCommand20.Properties.ImageIndex = 13;
			this.nCommand20.Properties.Text = "Deeper Nested Command 4";
			// 
			// nCommand23
			// 
			this.nCommand23.Properties.ImageIndex = 16;
			this.nCommand23.Properties.Text = "Nested Command 3";
			// 
			// nCommand26
			// 
			this.nCommand26.Properties.ImageIndex = 5;
			this.nCommand26.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nCommand26.Properties.Text = "Open...";
			// 
			// nCommand24
			// 
			this.nCommand24.Properties.BeginGroup = true;
			this.nCommand24.Properties.ImageIndex = 4;
			this.nCommand24.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nCommand24.Properties.Text = "Save...";
			// 
			// nCommand7
			// 
			this.nCommand7.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand8,
																						   this.nCommand22,
																						   this.nCommand23});
			this.nCommand7.Properties.ImageIndex = 1;
			this.nCommand7.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
			// 
			// nCommand8
			// 
			this.nCommand8.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand17,
																						   this.nCommand18,
																						   this.nCommand19,
																						   this.nCommand20,
																						   this.nCommand21});
			this.nCommand8.Properties.ImageIndex = 3;
			this.nCommand8.Properties.Text = "Nested Command 1";
			// 
			// nCommand17
			// 
			this.nCommand17.Properties.ImageIndex = 7;
			this.nCommand17.Properties.Text = "Deeper Nested Command 1";
			// 
			// nCommand18
			// 
			this.nCommand18.Properties.ImageIndex = 9;
			this.nCommand18.Properties.Text = "Deeper Nested Command 2";
			// 
			// nCommand19
			// 
			this.nCommand19.Properties.ImageIndex = 12;
			this.nCommand19.Properties.Text = "Deeper Nested Command 3";
			// 
			// nCommand21
			// 
			this.nCommand21.Properties.ImageIndex = 14;
			this.nCommand21.Properties.Text = "Deeper Nested Command 5";
			// 
			// nCommand6
			// 
			this.nCommand6.Properties.FadeImage = true;
			this.nCommand6.Properties.ImageIndex = 0;
			this.nCommand6.Properties.ImageShadow = true;
			this.nCommand6.Properties.SelectedImageIndex = 21;
			// 
			// nCommand27
			// 
			this.nCommand27.Properties.ImageIndex = 2;
			// 
			// nCommand36
			// 
			this.nCommand36.Properties.BeginGroup = true;
			this.nCommand36.Properties.ImageIndex = 5;
			this.nCommand36.Properties.Text = "Nested Command 2";
			// 
			// nCommand35
			// 
			this.nCommand35.Properties.ImageIndex = 14;
			this.nCommand35.Properties.Text = "Deeper Nested Command 5";
			// 
			// nCommand37
			// 
			this.nCommand37.Properties.ImageIndex = 16;
			this.nCommand37.Properties.Text = "Nested Command 3";
			// 
			// nCommand39
			// 
			this.nCommand39.Properties.ImageIndex = 5;
			this.nCommand39.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nCommand39.Properties.Text = "Open...";
			// 
			// nCommand38
			// 
			this.nCommand38.Properties.BeginGroup = true;
			this.nCommand38.Properties.ImageIndex = 4;
			this.nCommand38.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nCommand38.Properties.Text = "Save...";
			// 
			// nCommand30
			// 
			this.nCommand30.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																							this.nCommand31,
																							this.nCommand32,
																							this.nCommand33,
																							this.nCommand34,
																							this.nCommand35});
			this.nCommand30.Properties.ImageIndex = 3;
			this.nCommand30.Properties.Text = "Nested Command 1";
			// 
			// nCommand31
			// 
			this.nCommand31.Properties.ImageIndex = 7;
			this.nCommand31.Properties.Text = "Deeper Nested Command 1";
			// 
			// nCommand32
			// 
			this.nCommand32.Properties.ImageIndex = 9;
			this.nCommand32.Properties.Text = "Deeper Nested Command 2";
			// 
			// nCommand33
			// 
			this.nCommand33.Properties.ImageIndex = 12;
			this.nCommand33.Properties.Text = "Deeper Nested Command 3";
			// 
			// nCommand34
			// 
			this.nCommand34.Properties.ImageIndex = 13;
			this.nCommand34.Properties.Text = "Deeper Nested Command 4";
			// 
			// nCommand28
			// 
			this.nCommand28.Properties.ImageIndex = 0;
			// 
			// nCommand5
			// 
			this.nCommand5.Properties.FadeImage = true;
			this.nCommand5.Properties.ImageIndex = 2;
			this.nCommand5.Properties.ImageShadow = true;
			this.nCommand5.Properties.SelectedImageIndex = 8;
			// 
			// nCommand11
			// 
			this.nCommand11.Properties.ImageIndex = 7;
			this.nCommand11.Properties.Text = "Deeper Nested Command 1";
			// 
			// nCommand10
			// 
			this.nCommand10.Properties.BeginGroup = true;
			this.nCommand10.Properties.ImageIndex = 5;
			this.nCommand10.Properties.Text = "Nested Command 2";
			// 
			// nToolbar1
			// 
			this.nToolbar1.AutoSize = false;
			this.nToolbar1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand1,
																						   this.nCommand2,
																						   this.nCommand3,
																						   this.nCommand4,
																						   this.nCommand25});
			this.nToolbar1.CommandSize = new System.Drawing.Size(32, 32);
			this.nToolbar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nToolbar1.HasGripper = false;
			this.nToolbar1.ImageList = this.m_ImageList;
			this.nToolbar1.ImageSize = new System.Drawing.Size(24, 24);
			this.nToolbar1.Location = new System.Drawing.Point(0, 0);
			this.nToolbar1.Name = "nToolbar1";
			this.nToolbar1.Size = new System.Drawing.Size(352, 40);
			this.nToolbar1.Text = "nToolbar1";
			// 
			// nCommand1
			// 
			this.nCommand1.Properties.FadeImage = true;
			this.nCommand1.Properties.ImageIndex = 2;
			this.nCommand1.Properties.ImageShadow = true;
			// 
			// nCommand2
			// 
			this.nCommand2.Properties.ImageIndex = 0;
			// 
			// nCommand3
			// 
			this.nCommand3.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand9,
																						   this.nCommand10,
																						   this.nCommand14});
			this.nCommand3.Properties.ImageIndex = 1;
			// 
			// nCommand9
			// 
			this.nCommand9.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand11,
																						   this.nCommand12,
																						   this.nCommand13,
																						   this.nCommand15,
																						   this.nCommand16});
			this.nCommand9.Properties.ImageIndex = 3;
			this.nCommand9.Properties.Text = "Nested Command 1";
			// 
			// nCommand12
			// 
			this.nCommand12.Properties.ImageIndex = 9;
			this.nCommand12.Properties.Text = "Deeper Nested Command 2";
			// 
			// nCommand13
			// 
			this.nCommand13.Properties.ImageIndex = 12;
			this.nCommand13.Properties.Text = "Deeper Nested Command 3";
			// 
			// nCommand15
			// 
			this.nCommand15.Properties.ImageIndex = 13;
			this.nCommand15.Properties.Text = "Deeper Nested Command 4";
			// 
			// nCommand16
			// 
			this.nCommand16.Properties.ImageIndex = 14;
			this.nCommand16.Properties.Text = "Deeper Nested Command 5";
			// 
			// nCommand14
			// 
			this.nCommand14.Properties.ImageIndex = 16;
			this.nCommand14.Properties.Text = "Nested Command 3";
			// 
			// nCommand4
			// 
			this.nCommand4.Properties.BeginGroup = true;
			this.nCommand4.Properties.ImageIndex = 4;
			this.nCommand4.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nCommand4.Properties.Text = "Save...";
			// 
			// nCommand25
			// 
			this.nCommand25.Properties.ImageIndex = 5;
			this.nCommand25.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nCommand25.Properties.Text = "Open...";
			// 
			// m_ImageList
			// 
			this.m_ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImageList.ImageStream")));
			this.m_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// nCommand29
			// 
			this.nCommand29.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																							this.nCommand30,
																							this.nCommand36,
																							this.nCommand37});
			this.nCommand29.Properties.DropDownBehavior = Nevron.UI.WinForm.Controls.DropDownBehavior.AlwaysDropDown;
			this.nCommand29.Properties.ImageIndex = 1;
			this.nCommand29.Properties.Text = "Drop-Down";
			// 
			// nToolbar3
			// 
			this.nToolbar3.CommandLayout = Nevron.UI.WinForm.Controls.CommandLayout.VerticalMaxWidth;
			this.nToolbar3.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand27,
																						   this.nCommand28,
																						   this.nCommand29,
																						   this.nCommand38,
																						   this.nCommand39});
			this.nToolbar3.CommandSize = new System.Drawing.Size(32, 32);
			this.nToolbar3.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nToolbar3.HasGripper = false;
			this.nToolbar3.ImageList = this.m_ImageList;
			this.nToolbar3.ImageSize = new System.Drawing.Size(24, 24);
			this.nToolbar3.Location = new System.Drawing.Point(56, 48);
			this.nToolbar3.Name = "nToolbar3";
			this.nToolbar3.Size = new System.Drawing.Size(109, 182);
			this.nToolbar3.Text = "nToolbar3";
			// 
			// nToolbar2
			// 
			this.nToolbar2.AutoSize = false;
			this.nToolbar2.CommandLayout = Nevron.UI.WinForm.Controls.CommandLayout.VerticalSingleColumn;
			this.nToolbar2.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand5,
																						   this.nCommand6,
																						   this.nCommand7,
																						   this.nCommand24,
																						   this.nCommand26});
			this.nToolbar2.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText;
			this.nToolbar2.Dock = System.Windows.Forms.DockStyle.Left;
			this.nToolbar2.HasGripper = false;
			this.nToolbar2.ImageList = this.m_ImageList;
			this.nToolbar2.Location = new System.Drawing.Point(0, 40);
			this.nToolbar2.Name = "nToolbar2";
			this.nToolbar2.Size = new System.Drawing.Size(28, 328);
			this.nToolbar2.Text = "nToolbar2";
			// 
			// m_HasGripperCheck
			// 
			this.m_HasGripperCheck.Location = new System.Drawing.Point(56, 296);
			this.m_HasGripperCheck.Name = "m_HasGripperCheck";
			this.m_HasGripperCheck.Size = new System.Drawing.Size(88, 24);
			this.m_HasGripperCheck.TabIndex = 4;
			this.m_HasGripperCheck.Text = "Has Gripper";
			this.m_HasGripperCheck.TransparentBackground = true;
			this.m_HasGripperCheck.CheckedChanged += new System.EventHandler(this.m_HasGripperCheck_CheckedChanged);
			// 
			// m_ShowTooltipsCheck
			// 
			this.m_ShowTooltipsCheck.Location = new System.Drawing.Point(56, 344);
			this.m_ShowTooltipsCheck.Name = "m_ShowTooltipsCheck";
			this.m_ShowTooltipsCheck.Size = new System.Drawing.Size(96, 24);
			this.m_ShowTooltipsCheck.TabIndex = 5;
			this.m_ShowTooltipsCheck.Text = "Show Tooltips";
			this.m_ShowTooltipsCheck.TransparentBackground = true;
			this.m_ShowTooltipsCheck.CheckedChanged += new System.EventHandler(this.m_ShowTooltipsCheck_CheckedChanged);
			// 
			// m_HasBorderCheck
			// 
			this.m_HasBorderCheck.Location = new System.Drawing.Point(56, 320);
			this.m_HasBorderCheck.Name = "m_HasBorderCheck";
			this.m_HasBorderCheck.Size = new System.Drawing.Size(88, 24);
			this.m_HasBorderCheck.TabIndex = 9;
			this.m_HasBorderCheck.Text = "Has Border";
			this.m_HasBorderCheck.TransparentBackground = true;
			this.m_HasBorderCheck.CheckedChanged += new System.EventHandler(this.m_HasBorderCheck_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 240);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 10;
			this.label1.Text = "Background Type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_BackgroundTypeCombo
			// 
			this.m_BackgroundTypeCombo.Location = new System.Drawing.Point(56, 264);
			this.m_BackgroundTypeCombo.Name = "m_BackgroundTypeCombo";
			this.m_BackgroundTypeCombo.Size = new System.Drawing.Size(176, 24);
			this.m_BackgroundTypeCombo.TabIndex = 11;
			this.m_BackgroundTypeCombo.Text = "nComboBox1";
			this.m_BackgroundTypeCombo.SelectedIndexChanged += new System.EventHandler(this.m_BackgroundTypeCombo_SelectedIndexChanged);
			// 
			// NCommandAppearanceUC
			// 
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.Controls.Add(this.m_BackgroundTypeCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_HasBorderCheck);
			this.Controls.Add(this.m_ShowTooltipsCheck);
			this.Controls.Add(this.m_HasGripperCheck);
			this.Controls.Add(this.nToolbar3);
			this.Controls.Add(this.nToolbar2);
			this.Controls.Add(this.nToolbar1);
			this.Name = "NCommandAppearanceUC";
			this.Size = new System.Drawing.Size(352, 368);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.IContainer components;

		private Nevron.UI.WinForm.Controls.NCommand nCommand22;
		private Nevron.UI.WinForm.Controls.NCommand nCommand20;
		private Nevron.UI.WinForm.Controls.NCommand nCommand23;
		private Nevron.UI.WinForm.Controls.NCommand nCommand26;
		private Nevron.UI.WinForm.Controls.NCommand nCommand24;
		private Nevron.UI.WinForm.Controls.NCommand nCommand7;
		private Nevron.UI.WinForm.Controls.NCommand nCommand8;
		private Nevron.UI.WinForm.Controls.NCommand nCommand17;
		private Nevron.UI.WinForm.Controls.NCommand nCommand18;
		private Nevron.UI.WinForm.Controls.NCommand nCommand19;
		private Nevron.UI.WinForm.Controls.NCommand nCommand21;
		private Nevron.UI.WinForm.Controls.NCommand nCommand6;
		private Nevron.UI.WinForm.Controls.NCommand nCommand27;
		private Nevron.UI.WinForm.Controls.NCommand nCommand36;
		private Nevron.UI.WinForm.Controls.NCommand nCommand35;
		private Nevron.UI.WinForm.Controls.NCommand nCommand37;
		private Nevron.UI.WinForm.Controls.NCommand nCommand39;
		private Nevron.UI.WinForm.Controls.NCommand nCommand38;
		private Nevron.UI.WinForm.Controls.NCommand nCommand30;
		private Nevron.UI.WinForm.Controls.NCommand nCommand31;
		private Nevron.UI.WinForm.Controls.NCommand nCommand32;
		private Nevron.UI.WinForm.Controls.NCommand nCommand33;
		private Nevron.UI.WinForm.Controls.NCommand nCommand34;
		private Nevron.UI.WinForm.Controls.NCommand nCommand28;
		private Nevron.UI.WinForm.Controls.NCommand nCommand5;
		private Nevron.UI.WinForm.Controls.NCommand nCommand11;
		private Nevron.UI.WinForm.Controls.NCommand nCommand10;
		private Nevron.UI.WinForm.Controls.NToolbar nToolbar1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NCommand nCommand3;
		private Nevron.UI.WinForm.Controls.NCommand nCommand9;
		private Nevron.UI.WinForm.Controls.NCommand nCommand12;
		private Nevron.UI.WinForm.Controls.NCommand nCommand13;
		private Nevron.UI.WinForm.Controls.NCommand nCommand15;
		private Nevron.UI.WinForm.Controls.NCommand nCommand16;
		private Nevron.UI.WinForm.Controls.NCommand nCommand14;
		private Nevron.UI.WinForm.Controls.NCommand nCommand4;
		private Nevron.UI.WinForm.Controls.NCommand nCommand25;
		private System.Windows.Forms.ImageList m_ImageList;
		private Nevron.UI.WinForm.Controls.NCommand nCommand29;
		private Nevron.UI.WinForm.Controls.NToolbar nToolbar3;
		private Nevron.UI.WinForm.Controls.NToolbar nToolbar2;
		private Nevron.UI.WinForm.Controls.NCheckBox m_HasGripperCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_HasBorderCheck;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox m_BackgroundTypeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowTooltipsCheck;

		#endregion
	}
}
