using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;

using Nevron.Diagram;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
	public class NDiagramExamplesCommandBarsManager : NCommandBarsManager
	{
		#region Constructors

		public NDiagramExamplesCommandBarsManager(NMainForm form) : base(form)
		{
			this.form = form;
			AllowCustomize = false;

			CreateColorSchemeContext();
			CreateMenuBar();
		}

		#endregion

		#region Implementation

		private void CreateColorSchemeContext()
		{
			//create the parent context for all color schemes
			NCommandContext parent = NCommandContext.CreateContext("Color &Scheme", (int)NDiagramExamplesCommandIDs.ColorScheme, null, -1, -1, null, false);
			Contexts.Add(parent);

			//create a context for each color scheme
			NCommandContext scheme;

			scheme = NCommandContext.CreateContext("&Automatic", (int)NDiagramExamplesCommandIDs.ColorScheme_Automatic, null, -1, -1, null, false);
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("&Standard", (int)NDiagramExamplesCommandIDs.ColorScheme_Standard, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.Standard;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("&Widows Default", (int)NDiagramExamplesCommandIDs.ColorScheme_WindowsDefault, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.WindowsDefault;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("Luna &Blue", (int)NDiagramExamplesCommandIDs.ColorScheme_LunaBlue, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.LunaBlue;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("Luna &Olive", (int)NDiagramExamplesCommandIDs.ColorScheme_LunaOlive, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.LunaOlive;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("Luna Sil&ver", (int)NDiagramExamplesCommandIDs.ColorScheme_LunaSilver, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.LunaSilver;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("&Longhorn", (int)NDiagramExamplesCommandIDs.ColorScheme_Longhorn, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.Longhorn;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("&Energy", (int)NDiagramExamplesCommandIDs.ColorScheme_Energy, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.Energy;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("Lila&c", (int)NDiagramExamplesCommandIDs.ColorScheme_Lilac, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.Lilac;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("Bl&ue", (int)NDiagramExamplesCommandIDs.ColorScheme_Blue, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.Blue;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("&Gold", (int)NDiagramExamplesCommandIDs.ColorScheme_Gold, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.Gold;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);

			scheme = NCommandContext.CreateContext("Custo&m", (int)NDiagramExamplesCommandIDs.ColorScheme_Custom, null, -1, -1, null, false);
			scheme.Properties.Tag = ColorScheme.Custom;
			parent.Contexts.Add(scheme);
			Contexts.Add(scheme);
		}
		
		private void CreateMenuBar()
		{
			NMenuBar menu = new NMenuBar();
			menu.Text = "Examples Main Menu";
			//forbide toolbar permisiions
			menu.AllowReset = false;
			menu.AllowRename = false;
			menu.AllowHide = false;

			NCommand comm, comm1;

			//create the "File" command
			comm = new NCommand();
			comm.Properties.Text = "&File";
			menu.Commands.Add(comm);

			//create the "Exit" command
			comm1 = new NCommand();
			comm1.Properties.ID = (int)NDiagramExamplesCommandIDs.Exit;
			comm1.Properties.Text = "E&xit";
			comm.Commands.Add(comm1);

			//create the "View" command
			comm = new NCommand();
			comm.Properties.Text = "&View";
			//add the "View Navigation" command
			comm1 = new NCommand();
			comm1.Properties.Text = "Navigation Tree";
			comm1.Properties.ID = (int)NDiagramExamplesCommandIDs.View_NavigationTree;
			comm.Commands.Add(comm1);
			//add the "View Example TabControl" command
			comm1 = new NCommand();
			comm1.Properties.Text = "Example TabControl";
			comm1.Properties.ID = (int)NDiagramExamplesCommandIDs.View_ExampleTabControl;
			comm.Commands.Add(comm1);
			//add the "View Example CommandBars" command
			comm1 = new NCommand();
			comm1.Properties.Text = "Example Command Bars";
			comm1.Properties.ID = (int)NDiagramExamplesCommandIDs.View_ExampleCommandBars;
			comm.Commands.Add(comm1);
			menu.Commands.Add(comm);


			//create the "Palette" command
			comm = new NCommand();
			comm.Properties.Text = "&Palette";
			//add the color scheme context
			comm.Commands.Add(NCommand.FromContext(Contexts.ContextFromID((int)NDiagramExamplesCommandIDs.ColorScheme)));
			//add the style3d context
			comm.Commands.Add(NCommand.FromContext(Contexts.ContextFromID((int)NDiagramExamplesCommandIDs.Style3D)));
			//add the "Edit Palette" command
			comm1 = new NCommand();
			comm1.Properties.BeginGroup = true;
			comm1.Properties.Text = "&Edit";
			comm1.Properties.ID = (int)NDiagramExamplesCommandIDs.Palette_Edit;
			comm.Commands.Add(comm1);
			menu.Commands.Add(comm);

			//create the "File" command
			comm = new NCommand();
			comm.Properties.Text = "&Help";
			comm1 = new NCommand();
			comm1.Properties.Text = "&About...";
			comm.Commands.Add(comm1);
			menu.Commands.Add(comm);

			//add the menu to the toolbars collection
			base.Toolbars.Add(menu);
		}


		#endregion

		#region Fields

		public NMainForm form = null;

		#endregion
	}
}
