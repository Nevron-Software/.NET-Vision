using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Diagram;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NCommandBarsUC.
	/// </summary>
	public class NCommandBarsUC : NDiagramExampleUC
	{
		#region Constructor

		public NCommandBarsUC(NMainForm form) : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// commonControlsPanel
			// 
			this.commonControlsPanel.Location = new System.Drawing.Point(0, 424);
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(248, 80);
			// 
			// NCommandBarsUC
			// 
			this.Name = "NCommandBarsUC";
			this.Size = new System.Drawing.Size(248, 504);
			this.ResumeLayout(false);

		}
		#endregion

		#region Component Overrides

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				try
				{
					NControlHelper.BeginUpdate(Form.CommandBarsManager.ParentControl);
		
					Form.CommandBarsManager.Commander.Commands.Remove(customDiagramButtonCommand);
					Form.CommandBarsManager.ToolbarsBuilder = originalDiagramToolbarsBuilder;
					Form.CommandBarsManager.Recreate();
					NControlHelper.EndUpdate(Form.CommandBarsManager.ParentControl, true);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}

				if (components != null) 
				{
					components.Dispose();
				}
			}

			base.Dispose(disposing);
		}


		#endregion
		
		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// store a reference to the original toolbar builder
			if (originalDiagramToolbarsBuilder == null)
			{
				originalDiagramToolbarsBuilder = Form.CommandBarsManager.ToolbarsBuilder;
			}

			// create the custom buttom command if not already craated
			if (customDiagramButtonCommand == null)
			{
				customDiagramButtonCommand = new NCustomDiagramButtonCommand();
				Form.CommandBarsManager.Commander.Commands.Add(customDiagramButtonCommand);
			}

            NControlHelper.BeginUpdate(Form.CommandBarsManager.ParentControl);
			
			// replace the toolbar builder with a custom one
			Form.CommandBarsManager.ToolbarsBuilder = new NCustomDiagramToolbarsBuilder();

			// recreate the command bars. Since we have replaced the toolbars builder,  
			// this will add the new command in the toolbars
			Form.CommandBarsManager.Recreate();

            NControlHelper.EndUpdate(Form.CommandBarsManager.ParentControl, true);
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		#endregion

		#region Fields

		public NCustomDiagramButtonCommand customDiagramButtonCommand = null;
		public NDiagramToolbarsBuilder originalDiagramToolbarsBuilder = null;

		#endregion
	}

	/// <summary>
	/// Summary description for NCustomDiagramToolbarsBuilder.
	/// </summary>
	public class NCustomDiagramToolbarsBuilder : NDiagramToolbarsBuilder
	{
		#region Constructor

		public NCustomDiagramToolbarsBuilder()
		{
		}


		#endregion

		#region Overrides

		public override NDockingToolbar[] BuildToolbars()
		{
			ArrayList toolbars = new ArrayList(base.BuildToolbars());
			string[] toolbarsNames = new string[] {"Custom Toolbar"};
			ArrayList[] commandArrays = new ArrayList[] {this.customCommandIds};

			ArrayList commands;
			Nevron.UI.WinForm.Controls.NCommand command;
			ArrayList beginGroupCommandIds = new ArrayList(this.BeginGroupCommandIds);

			for (int i = 0; i < commandArrays.Length; i++)
			{
				NDockingToolbar toolbar = new NDockingToolbar();
				toolbar.Text = toolbarsNames[i];
				toolbars.Add(toolbar);

				commands = commandArrays[i];
				for (int j = 0; j < commands.Count; j++)
				{
					int commandId = (int)commands[j];
					command = CreateCommand(commandId, beginGroupCommandIds.Contains(commandId));

					if (command != null)
					{
						toolbar.Commands.Add(command);
					}
				}
			}

			return (NDockingToolbar[])toolbars.ToArray(typeof(NDockingToolbar));
		}

		public override void Reset()
		{
			base.Reset();

			customCommandIds = new ArrayList();
			customCommandIds.Add((int)DiagramCommand.LastCommandId + 1);
		}

		#endregion
		
		#region Fields

		private ArrayList customCommandIds;

		#endregion
	}
	/// <summary>
	/// Summary description for NCustomDiagramButtonCommand.
	/// </summary>
	public class NCustomDiagramButtonCommand : NDiagramButtonCommand
	{
		#region Constructors
		
		static NCustomDiagramButtonCommand()
		{
			Type thisType = typeof(NCustomDiagramButtonCommand);
			ImageListCustom = new NCustomImageList(NResourceHelper.BitmapFromResource(thisType, "CustomCommandbarImageList.png", "Nevron.Examples.Diagram.WinForm.Resources"), new NSize(16, 16));
		}

		public NCustomDiagramButtonCommand()
			: base((int)DiagramCommandRange.Misc, (int)DiagramCommand.LastCommandId + 1, "Custom command", "Custom button command in a custom toolbar.")
		{
		}


		#endregion
		
		#region Overrides

		public override void Execute()
		{
			MessageBox.Show("NCustomDiagramButtonCommand was executed.");
		}

		public override bool GetImageInfo(out NCustomImageList imageList, out int imageIndex)
		{
			imageList = ImageListCustom;
			imageIndex = 0;
			return true;
		}
	

		#endregion

		#region Static Fields

		static public NCustomImageList ImageListCustom = null;

		#endregion
	}
}
