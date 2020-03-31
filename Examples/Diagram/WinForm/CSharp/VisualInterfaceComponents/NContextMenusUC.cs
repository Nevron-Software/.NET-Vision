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
	/// Summary description for NContextMenusUC.
	/// </summary>
	public class NContextMenusUC : NDiagramExampleUC
	{
		#region Constructor

		public NContextMenusUC(NMainForm form) : base(form)
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
			// NContextMenusUC
			// 
			this.Name = "NContextMenusUC";
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
					Form.CommandBarsManager.ContextMenuBuilder = originalDiagramContextMenuBuilder;

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
			if (originalDiagramContextMenuBuilder == null)
			{
				originalDiagramContextMenuBuilder = Form.CommandBarsManager.ContextMenuBuilder;
			}

			// create the custom buttom command if not already craated
			if (customDiagramButtonCommand == null)
			{
				customDiagramButtonCommand = new NCustomContextMenuDiagramButtonCommand();
				Form.CommandBarsManager.Commander.Commands.Add(customDiagramButtonCommand);
			}

            NControlHelper.BeginUpdate(Form.CommandBarsManager.ParentControl);
			
			// replace the context menu builder with a custom one
			Form.CommandBarsManager.ContextMenuBuilder = new NCustomDiagramContextMenuBuilder();

			// recreate the command bars. This is needed because custom commands 
			// need to be exported to Nevron UI command contexts also 
			Form.CommandBarsManager.Recreate();

            Form.View.DelegateBuildContextMenu = BuildContextMenu;

			
            NControlHelper.EndUpdate(Form.CommandBarsManager.ParentControl, true);
		}


		#endregion

        NContextMenu BuildContextMenu(object obj)
        {
            NContextMenu contextMenu = new NContextMenu();
            // contextMenu.

            return contextMenu;
        }

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		#endregion

		#region Fields

		public NCustomContextMenuDiagramButtonCommand customDiagramButtonCommand = null;
		public NDiagramContextMenuBuilder originalDiagramContextMenuBuilder = null;

		#endregion
	}

	/// <summary>
	/// Summary description for NCustomDiagramContextMenuBuilder.
	/// </summary>
	public class NCustomDiagramContextMenuBuilder : NDiagramContextMenuBuilder
	{
		#region Constructor

		public NCustomDiagramContextMenuBuilder()
		{
		}


		#endregion

		#region Overrides

		public override NContextMenu BuildContextMenu(object obj)
		{
			NContextMenu menu = base.BuildContextMenu(obj);
			menu.Commands.Add(CreateCommand((int)DiagramCommand.LastCommandId + 1, true));
			return menu;
		}


		#endregion
		
		#region Fields

		private ArrayList customCommandIds = null;

		#endregion
	}

	/// <summary>
	/// Summary description for NCustomContextMenuDiagramButtonCommand.
	/// </summary>
	public class NCustomContextMenuDiagramButtonCommand : NDiagramButtonCommand
	{
		#region Constructors
		
		static NCustomContextMenuDiagramButtonCommand()
		{
			Type thisType = typeof(NCustomDiagramButtonCommand);
			ImageListCustom = new NCustomImageList(NResourceHelper.BitmapFromResource(thisType, "CustomCommandbarImageList.png", "Nevron.Examples.Diagram.WinForm.Resources"), new NSize(16, 16));
		}

		public NCustomContextMenuDiagramButtonCommand()
			: base((int)DiagramCommandRange.Misc, (int)DiagramCommand.LastCommandId + 1, "Custom command", "Custom button command in context menu.")
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