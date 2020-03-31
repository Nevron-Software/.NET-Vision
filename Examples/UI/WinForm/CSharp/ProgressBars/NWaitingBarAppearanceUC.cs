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
	/// Summary description for NWaitingBarAppearanceUC.
	/// </summary>
	public class NWaitingBarAppearanceUC : NExampleUserControl
	{
		#region Constructor

		public NWaitingBarAppearanceUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				Wait(false);

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

			Wait(true);
		}
		internal void Wait(bool begin)
		{
			int count = Controls.Count;
			NWaitingBar bar;

			for(int i = 0; i < count; i++)
			{
				bar = Controls[i] as NWaitingBar;
				if(bar == null)
					continue;

				if(begin)
					bar.BeginWait();
				else
					bar.EndWait();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NWaitingBarAppearanceUC));
			this.nWaitingBar1 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.nWaitingBar2 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.nWaitingBar3 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.nWaitingBar4 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.nWaitingBar5 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.nWaitingBar6 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.nWaitingBar7 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.SuspendLayout();
			// 
			// nWaitingBar1
			// 
			this.nWaitingBar1.Border.Style = Nevron.UI.BorderStyle3D.Raised;
			this.nWaitingBar1.Location = new System.Drawing.Point(112, 8);
			this.nWaitingBar1.Name = "nWaitingBar1";
			this.nWaitingBar1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Energy;
			this.nWaitingBar1.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nWaitingBar1.Properties.Position = 40;
			this.nWaitingBar1.Properties.Step = 3;
			this.nWaitingBar1.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nWaitingBar1.Properties.WaitSize = 200;
			this.nWaitingBar1.Size = new System.Drawing.Size(336, 24);
			this.nWaitingBar1.TabIndex = 0;
			this.nWaitingBar1.Text = "nWaitingBar1";
			// 
			// nWaitingBar2
			// 
			this.nWaitingBar2.Location = new System.Drawing.Point(8, 8);
			this.nWaitingBar2.Name = "nWaitingBar2";
			this.nWaitingBar2.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nWaitingBar2.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.nWaitingBar2.Properties.Position = 20;
			this.nWaitingBar2.Size = new System.Drawing.Size(24, 336);
			this.nWaitingBar2.TabIndex = 1;
			this.nWaitingBar2.Text = "nWaitingBar2";
			// 
			// nWaitingBar3
			// 
			this.nWaitingBar3.Border.BaseColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nWaitingBar3.Border.Style = Nevron.UI.BorderStyle3D.RaisedFrame;
			this.nWaitingBar3.Location = new System.Drawing.Point(112, 40);
			this.nWaitingBar3.Name = "nWaitingBar3";
			this.nWaitingBar3.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Lilac;
			this.nWaitingBar3.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nWaitingBar3.Properties.Position = 20;
			this.nWaitingBar3.Properties.Step = 2;
			this.nWaitingBar3.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nWaitingBar3.Properties.WaitSize = 100;
			this.nWaitingBar3.Size = new System.Drawing.Size(336, 32);
			this.nWaitingBar3.TabIndex = 2;
			this.nWaitingBar3.Text = "nWaitingBar3";
			// 
			// nWaitingBar4
			// 
			this.nWaitingBar4.Location = new System.Drawing.Point(112, 80);
			this.nWaitingBar4.Name = "nWaitingBar4";
			this.nWaitingBar4.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nWaitingBar4.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nWaitingBar4.Properties.Position = 50;
			this.nWaitingBar4.Properties.Step = 2;
			this.nWaitingBar4.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nWaitingBar4.Properties.WaitSize = 50;
			this.nWaitingBar4.Size = new System.Drawing.Size(336, 24);
			this.nWaitingBar4.TabIndex = 3;
			this.nWaitingBar4.Text = "nWaitingBar4";
			// 
			// nWaitingBar5
			// 
			this.nWaitingBar5.Location = new System.Drawing.Point(112, 112);
			this.nWaitingBar5.Name = "nWaitingBar5";
			this.nWaitingBar5.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nWaitingBar5.Properties.Position = 2;
			this.nWaitingBar5.Properties.Step = 2;
			this.nWaitingBar5.Properties.WaitSize = 60;
			this.nWaitingBar5.Size = new System.Drawing.Size(336, 24);
			this.nWaitingBar5.TabIndex = 4;
			this.nWaitingBar5.Text = "nWaitingBar5";
			// 
			// nWaitingBar6
			// 
			this.nWaitingBar6.Border.BaseColor = System.Drawing.Color.FromArgb(((System.Byte)(204)), ((System.Byte)(51)), ((System.Byte)(0)));
			this.nWaitingBar6.Border.Style = Nevron.UI.BorderStyle3D.Bump;
			this.nWaitingBar6.Location = new System.Drawing.Point(40, 8);
			this.nWaitingBar6.Name = "nWaitingBar6";
			this.nWaitingBar6.Palette.Border = System.Drawing.Color.FromArgb(((System.Byte)(147)), ((System.Byte)(0)), ((System.Byte)(23)));
			this.nWaitingBar6.Palette.Caption = System.Drawing.Color.FromArgb(((System.Byte)(245)), ((System.Byte)(0)), ((System.Byte)(38)));
			this.nWaitingBar6.Palette.CaptionText = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nWaitingBar6.Palette.CheckedDark = System.Drawing.Color.FromArgb(((System.Byte)(153)), ((System.Byte)(77)), ((System.Byte)(0)));
			this.nWaitingBar6.Palette.CheckedLight = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(179)), ((System.Byte)(102)));
			this.nWaitingBar6.Palette.Control = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			this.nWaitingBar6.Palette.ControlBorder = System.Drawing.Color.FromArgb(((System.Byte)(147)), ((System.Byte)(0)), ((System.Byte)(23)));
			this.nWaitingBar6.Palette.ControlDark = System.Drawing.Color.FromArgb(((System.Byte)(179)), ((System.Byte)(90)), ((System.Byte)(0)));
			this.nWaitingBar6.Palette.ControlLight = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(223)), ((System.Byte)(191)));
			this.nWaitingBar6.Palette.ControlText = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nWaitingBar6.Palette.Highlight = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(161)), ((System.Byte)(67)));
			this.nWaitingBar6.Palette.HighlightDark = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(235)), ((System.Byte)(128)));
			this.nWaitingBar6.Palette.HighlightLight = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(245)), ((System.Byte)(191)));
			this.nWaitingBar6.Palette.HighlightText = System.Drawing.Color.FromArgb(((System.Byte)(8)), ((System.Byte)(8)), ((System.Byte)(8)));
			this.nWaitingBar6.Palette.Menu = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(179)), ((System.Byte)(102)));
			this.nWaitingBar6.Palette.MenuText = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nWaitingBar6.Palette.PressedDark = System.Drawing.Color.FromArgb(((System.Byte)(245)), ((System.Byte)(0)), ((System.Byte)(38)));
			this.nWaitingBar6.Palette.PressedLight = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(102)), ((System.Byte)(126)));
			this.nWaitingBar6.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Custom;
			this.nWaitingBar6.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((System.Byte)(147)), ((System.Byte)(0)), ((System.Byte)(23)));
			this.nWaitingBar6.Palette.Window = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(245)), ((System.Byte)(191)));
			this.nWaitingBar6.Palette.WindowText = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nWaitingBar6.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nWaitingBar6.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.nWaitingBar6.Properties.Position = 30;
			this.nWaitingBar6.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nWaitingBar6.Properties.WaitSize = 200;
			this.nWaitingBar6.Size = new System.Drawing.Size(24, 336);
			this.nWaitingBar6.TabIndex = 5;
			this.nWaitingBar6.Text = "nWaitingBar6";
			// 
			// nWaitingBar7
			// 
			this.nWaitingBar7.Border.Style = Nevron.UI.BorderStyle3D.Sunken;
			this.nWaitingBar7.Location = new System.Drawing.Point(72, 8);
			this.nWaitingBar7.Name = "nWaitingBar7";
			this.nWaitingBar7.Palette.Border = System.Drawing.SystemColors.ControlDarkDark;
			this.nWaitingBar7.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
			this.nWaitingBar7.Palette.CaptionText = System.Drawing.Color.White;
			this.nWaitingBar7.Palette.CheckedDark = System.Drawing.Color.FromArgb(((System.Byte)(204)), ((System.Byte)(210)), ((System.Byte)(187)));
			this.nWaitingBar7.Palette.CheckedLight = System.Drawing.Color.FromArgb(((System.Byte)(204)), ((System.Byte)(210)), ((System.Byte)(187)));
			this.nWaitingBar7.Palette.Control = System.Drawing.SystemColors.Control;
			this.nWaitingBar7.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark;
			this.nWaitingBar7.Palette.ControlDark = System.Drawing.SystemColors.Control;
			this.nWaitingBar7.Palette.ControlLight = System.Drawing.SystemColors.Control;
			this.nWaitingBar7.Palette.ControlText = System.Drawing.SystemColors.ControlText;
			this.nWaitingBar7.Palette.Highlight = System.Drawing.SystemColors.Highlight;
			this.nWaitingBar7.Palette.HighlightDark = System.Drawing.Color.FromArgb(((System.Byte)(212)), ((System.Byte)(217)), ((System.Byte)(198)));
			this.nWaitingBar7.Palette.HighlightLight = System.Drawing.Color.FromArgb(((System.Byte)(212)), ((System.Byte)(217)), ((System.Byte)(198)));
			this.nWaitingBar7.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
			this.nWaitingBar7.Palette.Menu = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nWaitingBar7.Palette.MenuText = System.Drawing.SystemColors.MenuText;
			this.nWaitingBar7.Palette.PressedDark = System.Drawing.SystemColors.Highlight;
			this.nWaitingBar7.Palette.PressedLight = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(195)), ((System.Byte)(165)));
			this.nWaitingBar7.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Custom;
			this.nWaitingBar7.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((System.Byte)(50)), ((System.Byte)(55)), ((System.Byte)(36)));
			this.nWaitingBar7.Palette.UseThemes = false;
			this.nWaitingBar7.Palette.Window = System.Drawing.SystemColors.Window;
			this.nWaitingBar7.Palette.WindowText = System.Drawing.SystemColors.WindowText;
			this.nWaitingBar7.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nWaitingBar7.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.nWaitingBar7.Properties.Position = 50;
			this.nWaitingBar7.Properties.Step = 2;
			this.nWaitingBar7.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nWaitingBar7.Properties.WaitSize = 50;
			this.nWaitingBar7.Size = new System.Drawing.Size(24, 336);
			this.nWaitingBar7.TabIndex = 6;
			this.nWaitingBar7.Text = "nWaitingBar7";
			// 
			// NWaitingBarAppearanceUC
			// 
			this.Controls.Add(this.nWaitingBar7);
			this.Controls.Add(this.nWaitingBar6);
			this.Controls.Add(this.nWaitingBar5);
			this.Controls.Add(this.nWaitingBar4);
			this.Controls.Add(this.nWaitingBar3);
			this.Controls.Add(this.nWaitingBar2);
			this.Controls.Add(this.nWaitingBar1);
			this.Name = "NWaitingBarAppearanceUC";
			this.Size = new System.Drawing.Size(456, 352);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar1;
		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar2;
		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar3;
		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar4;
		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar6;
		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar7;
		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar5;

		#endregion
	}
}
