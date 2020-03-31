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
	public class NPanelBarUC : NExampleUserControl
	{
		#region Constructor

		public NPanelBarUC(MainForm f) : base(f)
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

		public override void Initialize()
		{
			base.Initialize ();

			m_TextAlignCombo.FillFromEnum(typeof(HorizontalAlignment), false);
			m_TextAlignCombo.SelectedItem = HorizontalAlignment.Left;
		}




		#endregion

		#region Event Handlers

		private void m_TextAlignCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			foreach(NBand band in nPanelBar1.Controls)
			{
				band.TextAlign = (HorizontalAlignment)m_TextAlignCombo.SelectedIndex;
			}
		}
		private void m_BorderButton_Click(object sender, System.EventArgs e)
		{
			nPanelBar1.Border.ShowEditor();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NPanelBarUC));
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
																													 "Client1",
																													 "00 0000 000000",
																													 "Client Address"}, -1);
			this.nPanelBar1 = new Nevron.UI.WinForm.Controls.NPanelBar();
			this.m_ImageList = new System.Windows.Forms.ImageList(this.components);
			this.m_TextAlignCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nBand1 = new Nevron.UI.WinForm.Controls.NBand();
			this.nBand2 = new Nevron.UI.WinForm.Controls.NBand();
			this.nBand3 = new Nevron.UI.WinForm.Controls.NBand();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.nPanelBar1.SuspendLayout();
			this.nBand3.SuspendLayout();
			this.SuspendLayout();
			// 
			// nPanelBar1
			// 
			this.nPanelBar1.Controls.Add(this.nBand1);
			this.nPanelBar1.Controls.Add(this.nBand3);
			this.nPanelBar1.Controls.Add(this.nBand2);
			this.nPanelBar1.Dock = System.Windows.Forms.DockStyle.Left;
			this.nPanelBar1.ImageList = this.m_ImageList;
			this.nPanelBar1.Location = new System.Drawing.Point(0, 0);
			this.nPanelBar1.Name = "nPanelBar1";
			this.nPanelBar1.Size = new System.Drawing.Size(280, 368);
			this.nPanelBar1.TabIndex = 0;
			// 
			// m_ImageList
			// 
			this.m_ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImageList.ImageStream")));
			this.m_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_TextAlignCombo
			// 
			this.m_TextAlignCombo.Location = new System.Drawing.Point(288, 32);
			this.m_TextAlignCombo.Name = "m_TextAlignCombo";
			this.m_TextAlignCombo.Size = new System.Drawing.Size(184, 22);
			this.m_TextAlignCombo.TabIndex = 1;
			this.m_TextAlignCombo.Text = "nComboBox2";
			this.m_TextAlignCombo.SelectedIndexChanged += new System.EventHandler(this.m_TextAlignCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(288, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "TextAlign:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_BorderButton
			// 
			this.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_BorderButton.Location = new System.Drawing.Point(288, 64);
			this.m_BorderButton.Name = "m_BorderButton";
			this.m_BorderButton.Size = new System.Drawing.Size(104, 24);
			this.m_BorderButton.TabIndex = 15;
			this.m_BorderButton.Text = "Border...";
			this.m_BorderButton.Click += new System.EventHandler(this.m_BorderButton_Click);
			// 
			// nBand1
			// 
			this.nBand1.Caption = "Mail";
			this.nBand1.ImageIndex = 1;
			this.nBand1.Name = "nBand1";
			this.nBand1.State = Nevron.UI.WinForm.Controls.BandState.Expanded;
			this.nBand1.TabIndex = 0;
			// 
			// nBand2
			// 
			this.nBand2.Caption = "Shortcuts";
			this.nBand2.ImageIndex = 2;
			this.nBand2.Name = "nBand2";
			this.nBand2.TabIndex = 1;
			// 
			// nBand3
			// 
			this.nBand3.Caption = "Contacts";
			this.nBand3.Controls.Add(this.listView1);
			this.nBand3.ImageIndex = 3;
			this.nBand3.Name = "nBand3";
			this.nBand3.TabIndex = 2;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					  listViewItem1});
			this.listView1.Location = new System.Drawing.Point(0, 22);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(278, 0);
			this.listView1.TabIndex = 1;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Phone";
			this.columnHeader2.Width = 91;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Address";
			this.columnHeader3.Width = 119;
			// 
			// NPanelBarUC
			// 
			this.Controls.Add(this.nPanelBar1);
			this.Controls.Add(this.m_BorderButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_TextAlignCombo);
			this.Name = "NPanelBarUC";
			this.Size = new System.Drawing.Size(480, 368);
			this.nPanelBar1.ResumeLayout(false);
			this.nBand3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.IContainer components;


		private Nevron.UI.WinForm.Controls.NPanelBar nPanelBar1;
		private System.Windows.Forms.ImageList m_ImageList;
		private Nevron.UI.WinForm.Controls.NButton m_BorderButton;
		private Nevron.UI.WinForm.Controls.NComboBox m_TextAlignCombo;
		private Nevron.UI.WinForm.Controls.NBand nBand1;
		private Nevron.UI.WinForm.Controls.NBand nBand2;
		private Nevron.UI.WinForm.Controls.NBand nBand3;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label1;

		#endregion
	}
}
