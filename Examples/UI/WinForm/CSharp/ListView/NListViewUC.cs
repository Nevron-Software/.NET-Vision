using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;

using Nevron.Interop.Win32;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NListViewUC.
	/// </summary>
	public class NListViewUC : NExampleUserControl
	{
		#region Constructor

		public NListViewUC()
		{
			InitializeComponent();

            this.nListView1.HideSelection = false;
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

            this.headerStyleCombo.FillFromEnum(typeof(ColumnHeaderStyle));
            this.headerStyleCombo.SelectedItem = this.nListView1.HeaderStyle;

			headerSizeNumeric.Value = nListView1.HeaderHeight;

			nListView1.BeginUpdate();
			ListViewItem item;

			DateTime dt;
			DateTime dateNow = DateTime.Now;
			string text;
            int randomNum;
            int asciiA = 0x41;
            int asciiZ = 0x5A;

			for(int i = 1; i < 21; i++)
			{
				if(i % 2 == 0)
				{
					text = "sTrinG ItEM";
				}
				else
				{
					text = "String Item";
				}

				item = new ListViewItem(text);

				//case-insensitive column
                randomNum = Random.Next(asciiA, asciiZ);
				item.SubItems.Add(text + " " + randomNum.ToString());

				//numeric column
				item.SubItems.Add((Random.Next(1, 500) * 2).ToString());

				//date-time column
				dt = new DateTime(dateNow.Year, Random.Next(1, 11), Random.Next(1, 28));
				item.SubItems.Add(dt.ToShortDateString());

				nListView1.Items.Add(item);
			}

			nListView1.EndUpdate();
		}

		#endregion

		#region Event Handlers

		private void customScrollCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nListView1.UseCustomScrollBars = customScrollCheck.Checked;
		}
		private void customHeaderCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nListView1.HeaderCustomDraw = customHeaderCheck.Checked;
		}
		private void addBtn_Click(object sender, System.EventArgs e)
		{
			ListViewItem lvi = new ListViewItem("Test Item " + nListView1.Items.Count);
			nListView1.Items.Add(lvi);
		}
        private void headerStyleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nListView1.HeaderStyle = (ColumnHeaderStyle)this.headerStyleCombo.SelectedItem;
        }

		private void headerSizeNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			nListView1.HeaderHeight = (int)headerSizeNumeric.Value;
		}

		private void customItemsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nListView1.ItemCustomDraw = customItemsCheck.Checked;
		}

		private void shadeColorCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!shadeColorCheck.Checked)
			{
				nListView1.SortedColumnBackColor = Color.Empty;
				shadeColorButton.Enabled = false;
			}
			else
			{
				nListView1.SortedColumnBackColor = shadeColorButton.Color;
				shadeColorButton.Enabled = true;
			}
		}

		private void shadeColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if(shadeColorCheck.Checked)
			{
				nListView1.SortedColumnBackColor = shadeColorButton.Color;
			}
		}

		private void alternateRowsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nListView1.AlternateRows = alternateRowsCheck.Checked;
		}

		private void alternateRowColorCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!alternateRowColorCheck.Checked)
			{
				nListView1.AlternateRowColorBackColor = Color.Empty;
				rowColorButton.Enabled = false;
			}
			else
			{
				nListView1.AlternateRowColorBackColor = rowColorButton.Color;
				rowColorButton.Enabled = true;
			}
		}

		private void rowColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if(alternateRowColorCheck.Checked)
			{
				nListView1.AlternateRowColorBackColor = rowColorButton.Color;
			}
		}

		private void columnShadingCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nListView1.SortedColumnShading = columnShadingCheck.Checked;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.nListView1 = new Nevron.UI.WinForm.Controls.NListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.customScrollCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.customHeaderCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.headerSizeNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.customItemsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.shadeColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.columnShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.alternateRowsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.headerStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.alternateRowColorCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.rowColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
            this.shadeColorCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerSizeNumeric)).BeginInit();
            this.nGroupBox1.SuspendLayout();
            this.nGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nListView1
            // 
            this.nListView1.AllowColumnReorder = true;
            this.nListView1.AlternateRowColorBackColor = System.Drawing.Color.Empty;
            this.nListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.nListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.nListView1.ExtendedColumns.AddRange(new Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo[] {
            new Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo(this.columnHeader1, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, Nevron.UI.ImageTextRelation.ImageBeforeText, null, new Nevron.UI.NPadding(4, 2, 2, 4), true, Nevron.UI.WinForm.Controls.SortMode.String, false),
            new Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo(this.columnHeader4, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, Nevron.UI.ImageTextRelation.ImageBeforeText, null, new Nevron.UI.NPadding(4, 2, 2, 4), true, Nevron.UI.WinForm.Controls.SortMode.StringCaseInsensitive, false),
            new Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo(this.columnHeader2, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, Nevron.UI.ImageTextRelation.ImageBeforeText, null, new Nevron.UI.NPadding(4, 2, 2, 4), true, Nevron.UI.WinForm.Controls.SortMode.Numeric, false),
            new Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo(this.columnHeader3, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, Nevron.UI.ImageTextRelation.ImageBeforeText, null, new Nevron.UI.NPadding(4, 2, 2, 4), true, Nevron.UI.WinForm.Controls.SortMode.DateTime, false)});
            this.nListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nListView1.FullRowSelect = true;
            this.nListView1.Location = new System.Drawing.Point(8, 8);
            this.nListView1.Name = "nListView1";
            this.nListView1.Size = new System.Drawing.Size(512, 208);
            this.nListView1.TabIndex = 0;
            this.nListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "String Column";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "String Column Case Insensitive";
            this.columnHeader4.Width = 179;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Numeric Column";
            this.columnHeader2.Width = 107;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DateTime Column";
            this.columnHeader3.Width = 115;
            // 
            // customScrollCheck
            // 
            this.customScrollCheck.ButtonProperties.BorderOffset = 2;
            this.customScrollCheck.Checked = true;
            this.customScrollCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.customScrollCheck.Location = new System.Drawing.Point(16, 24);
            this.customScrollCheck.Name = "customScrollCheck";
            this.customScrollCheck.Size = new System.Drawing.Size(168, 24);
            this.customScrollCheck.TabIndex = 1;
            this.customScrollCheck.Text = "Custom Scrollbars";
            this.customScrollCheck.CheckedChanged += new System.EventHandler(this.customScrollCheck_CheckedChanged);
            // 
            // customHeaderCheck
            // 
            this.customHeaderCheck.ButtonProperties.BorderOffset = 2;
            this.customHeaderCheck.Checked = true;
            this.customHeaderCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.customHeaderCheck.Location = new System.Drawing.Point(16, 48);
            this.customHeaderCheck.Name = "customHeaderCheck";
            this.customHeaderCheck.Size = new System.Drawing.Size(168, 24);
            this.customHeaderCheck.TabIndex = 3;
            this.customHeaderCheck.Text = "Custom Header";
            this.customHeaderCheck.CheckedChanged += new System.EventHandler(this.customHeaderCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(80, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Header Size:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // headerSizeNumeric
            // 
            this.headerSizeNumeric.Location = new System.Drawing.Point(160, 24);
            this.headerSizeNumeric.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.headerSizeNumeric.Minimum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.headerSizeNumeric.Name = "headerSizeNumeric";
            this.headerSizeNumeric.Size = new System.Drawing.Size(88, 20);
            this.headerSizeNumeric.TabIndex = 6;
            this.headerSizeNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.headerSizeNumeric.ValueChanged += new System.EventHandler(this.headerSizeNumeric_ValueChanged);
            // 
            // customItemsCheck
            // 
            this.customItemsCheck.ButtonProperties.BorderOffset = 2;
            this.customItemsCheck.Checked = true;
            this.customItemsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.customItemsCheck.Location = new System.Drawing.Point(16, 72);
            this.customItemsCheck.Name = "customItemsCheck";
            this.customItemsCheck.Size = new System.Drawing.Size(168, 24);
            this.customItemsCheck.TabIndex = 7;
            this.customItemsCheck.Text = "Custom Draw Items";
            this.customItemsCheck.CheckedChanged += new System.EventHandler(this.customItemsCheck_CheckedChanged);
            // 
            // shadeColorButton
            // 
            this.shadeColorButton.ArrowClickOptions = false;
            this.shadeColorButton.ArrowWidth = 14;
            this.shadeColorButton.Color = System.Drawing.Color.LightGray;
            this.shadeColorButton.Enabled = false;
            this.shadeColorButton.Location = new System.Drawing.Point(160, 77);
            this.shadeColorButton.Name = "shadeColorButton";
            this.shadeColorButton.Size = new System.Drawing.Size(88, 24);
            this.shadeColorButton.TabIndex = 8;
            this.shadeColorButton.ColorChanged += new System.EventHandler(this.shadeColorButton_ColorChanged);
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Controls.Add(this.columnShadingCheck);
            this.nGroupBox1.Controls.Add(this.alternateRowsCheck);
            this.nGroupBox1.Controls.Add(this.customScrollCheck);
            this.nGroupBox1.Controls.Add(this.customHeaderCheck);
            this.nGroupBox1.Controls.Add(this.customItemsCheck);
            this.nGroupBox1.ImageIndex = 0;
            this.nGroupBox1.Location = new System.Drawing.Point(8, 224);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(200, 152);
            this.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
            this.nGroupBox1.TabIndex = 9;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "Custom Behavior Flags";
            // 
            // columnShadingCheck
            // 
            this.columnShadingCheck.ButtonProperties.BorderOffset = 2;
            this.columnShadingCheck.Checked = true;
            this.columnShadingCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.columnShadingCheck.Location = new System.Drawing.Point(16, 96);
            this.columnShadingCheck.Name = "columnShadingCheck";
            this.columnShadingCheck.Size = new System.Drawing.Size(168, 24);
            this.columnShadingCheck.TabIndex = 9;
            this.columnShadingCheck.Text = "Sorted Column Shading";
            this.columnShadingCheck.CheckedChanged += new System.EventHandler(this.columnShadingCheck_CheckedChanged);
            // 
            // alternateRowsCheck
            // 
            this.alternateRowsCheck.ButtonProperties.BorderOffset = 2;
            this.alternateRowsCheck.Location = new System.Drawing.Point(16, 120);
            this.alternateRowsCheck.Name = "alternateRowsCheck";
            this.alternateRowsCheck.Size = new System.Drawing.Size(168, 24);
            this.alternateRowsCheck.TabIndex = 8;
            this.alternateRowsCheck.Text = "Alternating Rows";
            this.alternateRowsCheck.CheckedChanged += new System.EventHandler(this.alternateRowsCheck_CheckedChanged);
            // 
            // nGroupBox2
            // 
            this.nGroupBox2.Controls.Add(this.headerStyleCombo);
            this.nGroupBox2.Controls.Add(this.label2);
            this.nGroupBox2.Controls.Add(this.alternateRowColorCheck);
            this.nGroupBox2.Controls.Add(this.rowColorButton);
            this.nGroupBox2.Controls.Add(this.shadeColorCheck);
            this.nGroupBox2.Controls.Add(this.label1);
            this.nGroupBox2.Controls.Add(this.headerSizeNumeric);
            this.nGroupBox2.Controls.Add(this.shadeColorButton);
            this.nGroupBox2.ImageIndex = 0;
            this.nGroupBox2.Location = new System.Drawing.Point(224, 224);
            this.nGroupBox2.Name = "nGroupBox2";
            this.nGroupBox2.Size = new System.Drawing.Size(296, 152);
            this.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
            this.nGroupBox2.TabIndex = 10;
            this.nGroupBox2.TabStop = false;
            this.nGroupBox2.Text = "Additional Settings";
            // 
            // headerStyleCombo
            // 
            this.headerStyleCombo.ListProperties.ColumnOnLeft = false;
            this.headerStyleCombo.Location = new System.Drawing.Point(160, 49);
            this.headerStyleCombo.Name = "headerStyleCombo";
            this.headerStyleCombo.Size = new System.Drawing.Size(130, 22);
            this.headerStyleCombo.TabIndex = 13;
            this.headerStyleCombo.Text = "nComboBox1";
            this.headerStyleCombo.SelectedIndexChanged += new System.EventHandler(this.headerStyleCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Header Style:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // alternateRowColorCheck
            // 
            this.alternateRowColorCheck.ButtonProperties.BorderOffset = 2;
            this.alternateRowColorCheck.Location = new System.Drawing.Point(8, 109);
            this.alternateRowColorCheck.Name = "alternateRowColorCheck";
            this.alternateRowColorCheck.Size = new System.Drawing.Size(144, 24);
            this.alternateRowColorCheck.TabIndex = 11;
            this.alternateRowColorCheck.Text = "Alternate Row Color";
            this.alternateRowColorCheck.CheckedChanged += new System.EventHandler(this.alternateRowColorCheck_CheckedChanged);
            // 
            // rowColorButton
            // 
            this.rowColorButton.ArrowClickOptions = false;
            this.rowColorButton.ArrowWidth = 14;
            this.rowColorButton.Color = System.Drawing.Color.LightGray;
            this.rowColorButton.Enabled = false;
            this.rowColorButton.Location = new System.Drawing.Point(160, 109);
            this.rowColorButton.Name = "rowColorButton";
            this.rowColorButton.Size = new System.Drawing.Size(88, 24);
            this.rowColorButton.TabIndex = 10;
            this.rowColorButton.ColorChanged += new System.EventHandler(this.rowColorButton_ColorChanged);
            // 
            // shadeColorCheck
            // 
            this.shadeColorCheck.ButtonProperties.BorderOffset = 2;
            this.shadeColorCheck.Location = new System.Drawing.Point(64, 77);
            this.shadeColorCheck.Name = "shadeColorCheck";
            this.shadeColorCheck.Size = new System.Drawing.Size(88, 24);
            this.shadeColorCheck.TabIndex = 9;
            this.shadeColorCheck.Text = "Shade Color";
            this.shadeColorCheck.CheckedChanged += new System.EventHandler(this.shadeColorCheck_CheckedChanged);
            // 
            // NListViewUC
            // 
            this.Controls.Add(this.nGroupBox2);
            this.Controls.Add(this.nGroupBox1);
            this.Controls.Add(this.nListView1);
            this.Name = "NListViewUC";
            this.Size = new System.Drawing.Size(536, 436);
            ((System.ComponentModel.ISupportInitialize)(this.headerSizeNumeric)).EndInit();
            this.nGroupBox1.ResumeLayout(false);
            this.nGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private NListView nListView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private Nevron.UI.WinForm.Controls.NCheckBox customScrollCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox customHeaderCheck;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown headerSizeNumeric;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private Nevron.UI.WinForm.Controls.NCheckBox customItemsCheck;
		private Nevron.UI.WinForm.Controls.NColorButton shadeColorButton;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox shadeColorCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox alternateRowsCheck;
		private Nevron.UI.WinForm.Controls.NColorButton rowColorButton;
		private Nevron.UI.WinForm.Controls.NCheckBox alternateRowColorCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox columnShadingCheck;
        private NComboBox headerStyleCombo;
        private Label label2;
		private System.Windows.Forms.ColumnHeader columnHeader3;

		#endregion
	}
}
