using System;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Visio;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NVisioImportUC.
	/// </summary>
	public class NVisioImportUC : NDiagramExampleUC
	{
		#region Constructor

		public NVisioImportUC(NMainForm form)
			: base(form)
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
			this.btnImport = new Nevron.UI.WinForm.Controls.NButton();
			this.pLibrary = new System.Windows.Forms.Panel();
			this.chkPreserveHierarchy = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.Location = new System.Drawing.Point(8, 475);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(234, 23);
			this.btnImport.TabIndex = 5;
			this.btnImport.Text = "Import Visio Stencil...";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// pLibrary
			// 
			this.pLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pLibrary.Location = new System.Drawing.Point(8, 3);
			this.pLibrary.Name = "pLibrary";
			this.pLibrary.Size = new System.Drawing.Size(234, 424);
			this.pLibrary.TabIndex = 6;
			// 
			// chkPreserveHierarchy
			// 
			this.chkPreserveHierarchy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkPreserveHierarchy.AutoSize = true;
			this.chkPreserveHierarchy.ButtonProperties.BorderOffset = 2;
			this.chkPreserveHierarchy.Location = new System.Drawing.Point(8, 443);
			this.chkPreserveHierarchy.Name = "chkPreserveHierarchy";
			this.chkPreserveHierarchy.Size = new System.Drawing.Size(146, 17);
			this.chkPreserveHierarchy.TabIndex = 7;
			this.chkPreserveHierarchy.Text = "Preserve shape hierarchy";
			this.chkPreserveHierarchy.UseVisualStyleBackColor = true;
			// 
			// dlgOpen
			// 
			this.dlgOpen.Filter = "Visio XML stencil (*.vsx)|*.vsx";
			this.dlgOpen.Title = "Select Visio XML Stencil";
			// 
			// NVisioImportUC
			// 
			this.Controls.Add(this.chkPreserveHierarchy);
			this.Controls.Add(this.pLibrary);
			this.Controls.Add(this.btnImport);
			this.Name = "NVisioImportUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.btnImport, 0);
			this.Controls.SetChildIndex(this.pLibrary, 0);
			this.Controls.SetChildIndex(this.chkPreserveHierarchy, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
			
			// end view init
			view.EndInit();

			InitFormControls();

            // import a sample visio stencil
            NVisioImporter visioImporter = new NVisioImporter(libDocument);
            visioImporter.Import(Path.Combine(Application.StartupPath, @"..\..\Resources\Data\Computers.vsx"));
		}
		private void InitFormControls()
		{
			libDocument = new NLibraryDocument();

			libView = new NLibraryView();
			pLibrary.Controls.Add(libView);
			libView.Dock = DockStyle.Fill;
			libView.Document = libDocument;

			DirectoryInfo directory = new DirectoryInfo(Path.Combine(Application.StartupPath, @"..\..\Resources\Data"));
			dlgOpen.InitialDirectory = directory.FullName;
		}

		#endregion

		#region Event Handlers

		private void btnImport_Click(object sender, EventArgs e)
		{
			if (dlgOpen.ShowDialog() == DialogResult.OK)
			{
				libDocument.RemoveAllChildren();
				NVisioImporter visioImporter = new NVisioImporter(libDocument);
				visioImporter.PreserveShapeHierarchy = chkPreserveHierarchy.Checked;
				visioImporter.Import(dlgOpen.FileName);
			}
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel pLibrary;
		private Nevron.UI.WinForm.Controls.NButton btnImport;
		private Nevron.UI.WinForm.Controls.NCheckBox chkPreserveHierarchy;

		#endregion

		#region Fields

		private NLibraryView libView;
		private OpenFileDialog dlgOpen;
		private NLibraryDocument libDocument;

		#endregion
	}
}