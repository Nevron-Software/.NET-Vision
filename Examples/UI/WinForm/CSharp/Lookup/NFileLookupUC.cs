using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Globalization;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NFileLookupUC.
	/// </summary>
	public class NFileLookupUC : NExampleUserControl
	{
		#region Constructor

		public NFileLookupUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
			fileFilterEdit.Text = NFileDialogFilters.XmlFileFilter;
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


		#endregion

		#region Event Handlers

		private void editableCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(nFileLookup1 == null)
				return;

			if(editableCheck.Checked)
			{
				nFileLookup1.EditorVisibility = EditorVisibility.Show;
			}
			else
			{
				nFileLookup1.EditorVisibility = EditorVisibility.Hide;
			}
		}
		private void indexNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(nFileLookup1 == null)
				return;

			nFileLookup1.DisplayIndex = (int)indexNumeric.Value;
		}

		private void fileFilterEdit_TextChanged(object sender, System.EventArgs e)
		{
			nFileLookup1.FileFilter = fileFilterEdit.Text;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nFileLookup1 = new Nevron.UI.WinForm.Controls.NFileLookup();
			this.editableCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.fileFilterEdit = new System.Windows.Forms.TextBox();
			this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.indexNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
			this.nEntryContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
			this.nEntryContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.indexNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// nFileLookup1
			// 
			this.nFileLookup1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nFileLookup1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nFileLookup1.Location = new System.Drawing.Point(8, 8);
			this.nFileLookup1.Name = "nFileLookup1";
			this.nFileLookup1.Size = new System.Drawing.Size(280, 24);
			this.nFileLookup1.TabIndex = 0;
			// 
			// editableCheck
			// 
			this.editableCheck.ButtonProperties.BorderOffset = 2;
			this.editableCheck.Checked = true;
			this.editableCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.editableCheck.Location = new System.Drawing.Point(8, 120);
			this.editableCheck.Name = "editableCheck";
			this.editableCheck.TabIndex = 3;
			this.editableCheck.Text = "Editable";
			this.editableCheck.CheckedChanged += new System.EventHandler(this.editableCheck_CheckedChanged);
			// 
			// nEntryContainer1
			// 
			this.nEntryContainer1.ClientPadding = new Nevron.UI.NPadding(0);
			this.nEntryContainer1.EntryControl = this.fileFilterEdit;
			this.nEntryContainer1.Item.Style.TextRenderMode = Nevron.UI.TextRenderMode.Gdi;
			this.nEntryContainer1.LabelSize = new System.Drawing.Size(80, 0);
			this.nEntryContainer1.Location = new System.Drawing.Point(8, 40);
			this.nEntryContainer1.Name = "nEntryContainer1";
			this.nEntryContainer1.Size = new System.Drawing.Size(280, 32);
			this.nEntryContainer1.StrokeInfo.Rounding = 5;
			this.nEntryContainer1.TabIndex = 1;
			this.nEntryContainer1.Text = "File Filter:";
			// 
			// fileFilterEdit
			// 
			this.fileFilterEdit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(245)), ((System.Byte)(245)), ((System.Byte)(245)));
			this.fileFilterEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fileFilterEdit.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.fileFilterEdit.Location = new System.Drawing.Point(92, 7);
			this.fileFilterEdit.Name = "fileFilterEdit";
			this.fileFilterEdit.Size = new System.Drawing.Size(177, 13);
			this.fileFilterEdit.TabIndex = 0;
			this.fileFilterEdit.Text = "";
			this.fileFilterEdit.TextChanged += new System.EventHandler(this.fileFilterEdit_TextChanged);
			// 
			// nEntryContainer2
			// 
			this.nEntryContainer2.ClientPadding = new Nevron.UI.NPadding(0);
			this.nEntryContainer2.EntryControl = this.indexNumeric;
			this.nEntryContainer2.Item.Style.TextRenderMode = Nevron.UI.TextRenderMode.Gdi;
			this.nEntryContainer2.LabelSize = new System.Drawing.Size(80, 0);
			this.nEntryContainer2.Location = new System.Drawing.Point(8, 80);
			this.nEntryContainer2.Name = "nEntryContainer2";
			this.nEntryContainer2.Size = new System.Drawing.Size(208, 32);
			this.nEntryContainer2.StrokeInfo.Rounding = 5;
			this.nEntryContainer2.TabIndex = 2;
			this.nEntryContainer2.TabStop = false;
			this.nEntryContainer2.Text = "Display Index:";
			// 
			// indexNumeric
			// 
			this.indexNumeric.Border.Style = Nevron.UI.BorderStyle3D.None;
			this.indexNumeric.Location = new System.Drawing.Point(92, 6);
			this.indexNumeric.Name = "indexNumeric";
			this.indexNumeric.Size = new System.Drawing.Size(105, 14);
			this.indexNumeric.TabIndex = 0;
			this.indexNumeric.ValueChanged += new System.EventHandler(this.indexNumeric_ValueChanged);
			// 
			// NFileLookupUC
			// 
			this.Controls.Add(this.nEntryContainer2);
			this.Controls.Add(this.nEntryContainer1);
			this.Controls.Add(this.editableCheck);
			this.Controls.Add(this.nFileLookup1);
			this.Name = "NFileLookupUC";
			this.Size = new System.Drawing.Size(344, 216);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
			this.nEntryContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
			this.nEntryContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.indexNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NFileLookup nFileLookup1;
		private Nevron.UI.WinForm.Controls.NCheckBox editableCheck;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
		private System.Windows.Forms.TextBox fileFilterEdit;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown indexNumeric;

		#endregion
	}
}
