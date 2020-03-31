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
	/// Summary description for NProgressBarAppearanceUC.
	/// </summary>
	public class NProgressBarAppearanceUC : NExampleUserControl
	{
		#region Constructor

		public NProgressBarAppearanceUC(MainForm f) : base(f)
		{
			InitializeComponent();

			m_Timer = new Timer();
			m_Timer.Interval = 40;
			m_Timer.Tick += new EventHandler(OnTimer_Tick);
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				m_Timer.Stop();
				m_Timer.Dispose();
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

			m_Timer.Start();
		}



		#endregion

		#region Event Handlers

		private void OnTimer_Tick(object sender, EventArgs e)
		{
			NProgressBar bar;
			int count = Controls.Count;
			int value;

			for(int i = 0; i < count; i++)
			{
				bar = Controls[i] as NProgressBar;
				if(bar == null)
					continue;

				value = bar.Properties.Value;
				if(value > 99)
					value = 0;
				value++;
				bar.Properties.Value = value;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NProgressBarAppearanceUC));
			this.nProgressBar1 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nProgressBar2 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nProgressBar3 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nProgressBar4 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nProgressBar5 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nProgressBar6 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nProgressBar7 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nProgressBar8 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.SuspendLayout();
			// 
			// nProgressBar1
			// 
			this.nProgressBar1.Location = new System.Drawing.Point(96, 8);
			this.nProgressBar1.Name = "nProgressBar1";
			this.nProgressBar1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nProgressBar1.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nProgressBar1.Properties.Text = "";
			this.nProgressBar1.Properties.Value = 30;
			this.nProgressBar1.Size = new System.Drawing.Size(304, 24);
			this.nProgressBar1.TabIndex = 4;
			this.nProgressBar1.Text = "nProgressBar1";
			// 
			// nProgressBar2
			// 
			this.nProgressBar2.Border.Style = Nevron.UI.BorderStyle3D.Raised;
			this.nProgressBar2.Location = new System.Drawing.Point(96, 72);
			this.nProgressBar2.Name = "nProgressBar2";
			this.nProgressBar2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Energy;
			this.nProgressBar2.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nProgressBar2.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nProgressBar2.Properties.Text = "";
			this.nProgressBar2.Properties.Value = 50;
			this.nProgressBar2.Size = new System.Drawing.Size(304, 24);
			this.nProgressBar2.TabIndex = 5;
			this.nProgressBar2.Text = "nProgressBar2";
			// 
			// nProgressBar3
			// 
			this.nProgressBar3.Border.Style = Nevron.UI.BorderStyle3D.Sunken;
			this.nProgressBar3.Location = new System.Drawing.Point(96, 40);
			this.nProgressBar3.Name = "nProgressBar3";
			this.nProgressBar3.Palette.Border = System.Drawing.SystemColors.ControlDarkDark;
			this.nProgressBar3.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
			this.nProgressBar3.Palette.CaptionText = System.Drawing.Color.White;
			this.nProgressBar3.Palette.CheckedDark = System.Drawing.Color.FromArgb(((System.Byte)(204)), ((System.Byte)(210)), ((System.Byte)(187)));
			this.nProgressBar3.Palette.CheckedLight = System.Drawing.Color.FromArgb(((System.Byte)(204)), ((System.Byte)(210)), ((System.Byte)(187)));
			this.nProgressBar3.Palette.Control = System.Drawing.SystemColors.Control;
			this.nProgressBar3.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark;
			this.nProgressBar3.Palette.ControlDark = System.Drawing.SystemColors.Control;
			this.nProgressBar3.Palette.ControlLight = System.Drawing.Color.FromArgb(((System.Byte)(246)), ((System.Byte)(244)), ((System.Byte)(236)));
			this.nProgressBar3.Palette.ControlText = System.Drawing.SystemColors.ControlText;
			this.nProgressBar3.Palette.Highlight = System.Drawing.SystemColors.Highlight;
			this.nProgressBar3.Palette.HighlightDark = System.Drawing.Color.FromArgb(((System.Byte)(212)), ((System.Byte)(217)), ((System.Byte)(198)));
			this.nProgressBar3.Palette.HighlightLight = System.Drawing.Color.FromArgb(((System.Byte)(212)), ((System.Byte)(217)), ((System.Byte)(198)));
			this.nProgressBar3.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
			this.nProgressBar3.Palette.Menu = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nProgressBar3.Palette.MenuText = System.Drawing.SystemColors.MenuText;
			this.nProgressBar3.Palette.PressedDark = System.Drawing.SystemColors.Highlight;
			this.nProgressBar3.Palette.PressedLight = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(195)), ((System.Byte)(165)));
			this.nProgressBar3.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Custom;
			this.nProgressBar3.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((System.Byte)(50)), ((System.Byte)(55)), ((System.Byte)(36)));
			this.nProgressBar3.Palette.UseThemes = false;
			this.nProgressBar3.Palette.Window = System.Drawing.SystemColors.Window;
			this.nProgressBar3.Palette.WindowText = System.Drawing.SystemColors.WindowText;
			this.nProgressBar3.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nProgressBar3.Properties.Segments = true;
			this.nProgressBar3.Properties.ShowText = true;
			this.nProgressBar3.Properties.Text = "Custom Text";
			this.nProgressBar3.Properties.Value = 70;
			this.nProgressBar3.Size = new System.Drawing.Size(304, 24);
			this.nProgressBar3.TabIndex = 6;
			this.nProgressBar3.Text = "nProgressBar3";
			// 
			// nProgressBar4
			// 
			this.nProgressBar4.Border.Style = Nevron.UI.BorderStyle3D.Sunken;
			this.nProgressBar4.Location = new System.Drawing.Point(96, 104);
			this.nProgressBar4.Name = "nProgressBar4";
			this.nProgressBar4.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaSilver;
			this.nProgressBar4.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nProgressBar4.Properties.ShowText = true;
			this.nProgressBar4.Properties.Text = "";
			this.nProgressBar4.Properties.Value = 65;
			this.nProgressBar4.Size = new System.Drawing.Size(304, 24);
			this.nProgressBar4.TabIndex = 7;
			this.nProgressBar4.Text = "nProgressBar4";
			// 
			// nProgressBar5
			// 
			this.nProgressBar5.Border.Style = Nevron.UI.BorderStyle3D.RaisedFrame;
			this.nProgressBar5.Location = new System.Drawing.Point(8, 8);
			this.nProgressBar5.Name = "nProgressBar5";
			this.nProgressBar5.Palette.Border = System.Drawing.Color.Black;
			this.nProgressBar5.Palette.Caption = System.Drawing.Color.FromArgb(((System.Byte)(8)), ((System.Byte)(8)), ((System.Byte)(8)));
			this.nProgressBar5.Palette.CaptionText = System.Drawing.Color.White;
			this.nProgressBar5.Palette.CheckedDark = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.nProgressBar5.Palette.CheckedLight = System.Drawing.Color.FromArgb(((System.Byte)(60)), ((System.Byte)(60)), ((System.Byte)(60)));
			this.nProgressBar5.Palette.Control = System.Drawing.Color.FromArgb(((System.Byte)(90)), ((System.Byte)(90)), ((System.Byte)(90)));
			this.nProgressBar5.Palette.ControlBorder = System.Drawing.Color.Black;
			this.nProgressBar5.Palette.ControlDark = System.Drawing.Color.FromArgb(((System.Byte)(26)), ((System.Byte)(26)), ((System.Byte)(26)));
			this.nProgressBar5.Palette.ControlLight = System.Drawing.Color.FromArgb(((System.Byte)(110)), ((System.Byte)(110)), ((System.Byte)(110)));
			this.nProgressBar5.Palette.ControlText = System.Drawing.Color.White;
			this.nProgressBar5.Palette.Highlight = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.nProgressBar5.Palette.HighlightDark = System.Drawing.Color.FromArgb(((System.Byte)(60)), ((System.Byte)(60)), ((System.Byte)(60)));
			this.nProgressBar5.Palette.HighlightLight = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(80)));
			this.nProgressBar5.Palette.HighlightText = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(223)), ((System.Byte)(127)));
			this.nProgressBar5.Palette.Menu = System.Drawing.Color.FromArgb(((System.Byte)(91)), ((System.Byte)(91)), ((System.Byte)(91)));
			this.nProgressBar5.Palette.MenuText = System.Drawing.Color.White;
			this.nProgressBar5.Palette.PressedDark = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(102)), ((System.Byte)(0)));
			this.nProgressBar5.Palette.PressedLight = System.Drawing.Color.FromArgb(((System.Byte)(123)), ((System.Byte)(123)), ((System.Byte)(123)));
			this.nProgressBar5.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Custom;
			this.nProgressBar5.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(223)), ((System.Byte)(127)));
			this.nProgressBar5.Palette.Window = System.Drawing.Color.FromArgb(((System.Byte)(131)), ((System.Byte)(131)), ((System.Byte)(131)));
			this.nProgressBar5.Palette.WindowText = System.Drawing.Color.White;
			this.nProgressBar5.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nProgressBar5.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.nProgressBar5.Properties.ShowText = true;
			this.nProgressBar5.Properties.Text = "";
			this.nProgressBar5.Properties.Value = 20;
			this.nProgressBar5.Size = new System.Drawing.Size(32, 304);
			this.nProgressBar5.TabIndex = 8;
			this.nProgressBar5.Text = "nProgressBar5";
			// 
			// nProgressBar6
			// 
			this.nProgressBar6.Border.Style = Nevron.UI.BorderStyle3D.Bump;
			this.nProgressBar6.Location = new System.Drawing.Point(96, 136);
			this.nProgressBar6.Name = "nProgressBar6";
			this.nProgressBar6.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaSilver;
			this.nProgressBar6.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nProgressBar6.Properties.ShowText = true;
			this.nProgressBar6.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nProgressBar6.Properties.Text = "";
			this.nProgressBar6.Properties.Value = 70;
			this.nProgressBar6.Size = new System.Drawing.Size(304, 24);
			this.nProgressBar6.TabIndex = 9;
			this.nProgressBar6.Text = "nProgressBar6";
			// 
			// nProgressBar7
			// 
			this.nProgressBar7.Location = new System.Drawing.Point(48, 8);
			this.nProgressBar7.Name = "nProgressBar7";
			this.nProgressBar7.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nProgressBar7.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None;
			this.nProgressBar7.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.nProgressBar7.Properties.ShowText = true;
			this.nProgressBar7.Properties.Text = "Installing... Please, wait!";
			this.nProgressBar7.Properties.Value = 30;
			this.nProgressBar7.Size = new System.Drawing.Size(32, 304);
			this.nProgressBar7.TabIndex = 10;
			this.nProgressBar7.Text = "nProgressBar7";
			// 
			// nProgressBar8
			// 
			this.nProgressBar8.Location = new System.Drawing.Point(96, 168);
			this.nProgressBar8.Name = "nProgressBar8";
			this.nProgressBar8.Properties.ShowText = true;
			this.nProgressBar8.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nProgressBar8.Properties.Text = "";
			this.nProgressBar8.Properties.Value = 80;
			this.nProgressBar8.Size = new System.Drawing.Size(304, 24);
			this.nProgressBar8.TabIndex = 11;
			this.nProgressBar8.Text = "nProgressBar8";
			// 
			// NProgressBarAppearanceUC
			// 
			this.Controls.Add(this.nProgressBar8);
			this.Controls.Add(this.nProgressBar7);
			this.Controls.Add(this.nProgressBar6);
			this.Controls.Add(this.nProgressBar5);
			this.Controls.Add(this.nProgressBar4);
			this.Controls.Add(this.nProgressBar3);
			this.Controls.Add(this.nProgressBar2);
			this.Controls.Add(this.nProgressBar1);
			this.Name = "NProgressBarAppearanceUC";
			this.Size = new System.Drawing.Size(480, 344);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar1;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar3;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar4;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar5;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar6;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar7;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar2;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar8;

		internal Timer m_Timer;

		#endregion
	}
}
