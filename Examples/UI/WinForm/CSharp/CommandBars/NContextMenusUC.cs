using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	public class NContextMenusUC : NExampleUserControl
	{
		#region Constructor

		public NContextMenusUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
		}


		#endregion

		#region Implementation

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
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);
			if(e.Button == System.Windows.Forms.MouseButtons.Right)
				nContextMenu1.Show(Control.MousePosition);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NContextMenusUC));
            this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nComboBoxCommand1 = new Nevron.UI.WinForm.Controls.NComboBoxCommand();
            this.nComboBoxCommand2 = new Nevron.UI.WinForm.Controls.NComboBoxCommand();
            this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nContextMenu1 = new Nevron.UI.WinForm.Controls.NContextMenu();
            this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nComboBoxCommand3 = new Nevron.UI.WinForm.Controls.NComboBoxCommand();
            this.nComboBoxCommand4 = new Nevron.UI.WinForm.Controls.NComboBoxCommand();
            this.nCommand4 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nCommand5 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nCommand6 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nCommand7 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nCommand8 = new Nevron.UI.WinForm.Controls.NCommand();
            this.m_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.nCommand9 = new Nevron.UI.WinForm.Controls.NCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nComboBoxCommand1
            // 
            this.nComboBoxCommand1.ControlText = "";
            this.nComboBoxCommand1.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            // 
            // nComboBoxCommand2
            // 
            this.nComboBoxCommand2.ControlText = "";
            this.nComboBoxCommand2.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            // 
            // nContextMenu1
            // 
            this.nContextMenu1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.nCommand3,
            this.nComboBoxCommand4,
            this.nCommand4});
            this.nContextMenu1.ImageList = this.m_ImageList;
            // 
            // nCommand3
            // 
            this.nCommand3.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.nComboBoxCommand3});
            this.nCommand3.Properties.ImageIndex = 0;
            this.nCommand3.Properties.Text = "ComboBox Command";
            // 
            // nComboBoxCommand3
            // 
            this.nComboBoxCommand3.ControlText = "";
            this.nComboBoxCommand3.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0))});
            this.nComboBoxCommand3.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            // 
            // nComboBoxCommand4
            // 
            this.nComboBoxCommand4.ControlText = "NlistBoxItem";
            this.nComboBoxCommand4.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem(null, -1, false, 0, new System.Drawing.Size(0, 0))});
            this.nComboBoxCommand4.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            // 
            // nCommand4
            // 
            this.nCommand4.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.nCommand5,
            this.nCommand6,
            this.nCommand7,
            this.nCommand8});
            this.nCommand4.Properties.BeginGroup = true;
            this.nCommand4.Properties.ImageIndex = 0;
            this.nCommand4.Properties.Text = "Add/Remove Commands";
            // 
            // nCommand5
            // 
            this.nCommand5.Checked = true;
            this.nCommand5.Properties.ImageIndex = 2;
            this.nCommand5.Properties.Text = "&File";
            // 
            // nCommand6
            // 
            this.nCommand6.Checked = true;
            this.nCommand6.Properties.BeginGroup = true;
            this.nCommand6.Properties.ImageIndex = 3;
            this.nCommand6.Properties.Text = "&New";
            // 
            // nCommand7
            // 
            this.nCommand7.Checked = true;
            this.nCommand7.Properties.BeginGroup = true;
            this.nCommand7.Properties.ImageIndex = 5;
            this.nCommand7.Properties.Text = "Save";
            // 
            // nCommand8
            // 
            this.nCommand8.Checked = true;
            this.nCommand8.Properties.ImageIndex = 16;
            this.nCommand8.Properties.Text = "Save &As...";
            // 
            // m_ImageList
            // 
            this.m_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImageList.ImageStream")));
            this.m_ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_ImageList.Images.SetKeyName(0, "");
            this.m_ImageList.Images.SetKeyName(1, "");
            this.m_ImageList.Images.SetKeyName(2, "");
            this.m_ImageList.Images.SetKeyName(3, "");
            this.m_ImageList.Images.SetKeyName(4, "");
            this.m_ImageList.Images.SetKeyName(5, "");
            this.m_ImageList.Images.SetKeyName(6, "");
            this.m_ImageList.Images.SetKeyName(7, "");
            this.m_ImageList.Images.SetKeyName(8, "");
            this.m_ImageList.Images.SetKeyName(9, "");
            this.m_ImageList.Images.SetKeyName(10, "");
            this.m_ImageList.Images.SetKeyName(11, "");
            this.m_ImageList.Images.SetKeyName(12, "");
            this.m_ImageList.Images.SetKeyName(13, "");
            this.m_ImageList.Images.SetKeyName(14, "");
            this.m_ImageList.Images.SetKeyName(15, "");
            this.m_ImageList.Images.SetKeyName(16, "");
            this.m_ImageList.Images.SetKeyName(17, "");
            this.m_ImageList.Images.SetKeyName(18, "");
            this.m_ImageList.Images.SetKeyName(19, "");
            this.m_ImageList.Images.SetKeyName(20, "");
            this.m_ImageList.Images.SetKeyName(21, "");
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Right-click on the example to show the context menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NContextMenusUC
            // 
            this.Controls.Add(this.label1);
            this.Name = "NContextMenusUC";
            this.Size = new System.Drawing.Size(296, 232);
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.IContainer components;


		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NComboBoxCommand nComboBoxCommand1;
		private Nevron.UI.WinForm.Controls.NComboBoxCommand nComboBoxCommand2;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NContextMenu nContextMenu1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand3;
		private Nevron.UI.WinForm.Controls.NComboBoxCommand nComboBoxCommand3;
		private Nevron.UI.WinForm.Controls.NComboBoxCommand nComboBoxCommand4;
		private Nevron.UI.WinForm.Controls.NCommand nCommand5;
		private Nevron.UI.WinForm.Controls.NCommand nCommand6;
		private Nevron.UI.WinForm.Controls.NCommand nCommand7;
		private Nevron.UI.WinForm.Controls.NCommand nCommand8;
		private Nevron.UI.WinForm.Controls.NCommand nCommand9;
		internal System.Windows.Forms.ImageList m_ImageList;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand4;

		#endregion
	}
}
