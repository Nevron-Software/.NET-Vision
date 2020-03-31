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
	/// Summary description for NListBoxImageSizeUC.
	/// </summary>
	public class NListBoxImageSizeUC : NExampleUserControl
	{
		#region Constructor

		public NListBoxImageSizeUC(MainForm f) : base(f)
		{
            ++m_iSuspendUpdate;
			InitializeComponent();

			Dock = DockStyle.Fill;

            --m_iSuspendUpdate;
		}


		#endregion

		#region Overrides

		public override void Initialize()
		{
			base.Initialize ();

			++m_iSuspendUpdate;
			int i;

			NListBoxItem item;

			for(i = 0; i < 10; i++)
			{
				item = new NListBoxItem(-1, "NListBoxItem" + i);
				if(i == 9)
					item.Height = 50;
				nListBox1.Items.Add(item);
			}

			m_ImageSizeWidthNumeric.Value = nListBox1.ImageSize.Width;
			m_ImageSizeHeightNumeric.Value = nListBox1.ImageSize.Height;

			nListBox1.DefaultImageIndex = 0;
			//nListBox1.ScrollAlwaysVisible = true;

			int count = imageList1.Images.Count;

			for(i = 0; i < count; i++)
			{
				item = new NListBoxItem(i, i.ToString(), false);
				comboBox1.Items.Add(item);
			}

			comboBox1.SelectedIndex = 0;

			--m_iSuspendUpdate;
		}

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

		private void m_ImageSizeWidthNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			Size sz = new Size((int)m_ImageSizeWidthNumeric.Value, nListBox1.ImageSize.Height);
			nListBox1.ImageSize = sz;
		}

		private void m_ImageSizeHeightNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			Size sz = new Size(nListBox1.ImageSize.Width, (int)m_ImageSizeHeightNumeric.Value);
			nListBox1.ImageSize = sz;
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			nListBox1.DefaultImageIndex = comboBox1.SelectedIndex;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NListBoxImageSizeUC));
			this.nListBox1 = new Nevron.UI.WinForm.Controls.NListBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_ImageSizeWidthNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.m_ImageSizeHeightNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.comboBox1 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.m_ImageSizeWidthNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_ImageSizeHeightNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// nListBox1
			// 
			this.nListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nListBox1.ImageList = this.imageList1;
			this.nListBox1.ImageSize = new Size(32, 32);
			this.nListBox1.ItemHeight = 50;
			this.nListBox1.Location = new System.Drawing.Point(8, 8);
			this.nListBox1.Name = "nListBox1";
			this.nListBox1.Size = new System.Drawing.Size(288, 254);
			this.nListBox1.TabIndex = 4;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(8, 272);
			this.label1.Name = "label1";
			this.label1.TabIndex = 5;
			this.label1.Text = "Image Size Width:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(8, 296);
			this.label2.Name = "label2";
			this.label2.TabIndex = 6;
			this.label2.Text = "Image Size Height:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_ImageSizeWidthNumeric
			// 
			this.m_ImageSizeWidthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_ImageSizeWidthNumeric.Location = new System.Drawing.Point(112, 272);
			this.m_ImageSizeWidthNumeric.Maximum = new System.Decimal(new int[] {
																					46,
																					0,
																					0,
																					0});
			this.m_ImageSizeWidthNumeric.Minimum = new System.Decimal(new int[] {
																					4,
																					0,
																					0,
																					0});
			this.m_ImageSizeWidthNumeric.Name = "m_ImageSizeWidthNumeric";
			this.m_ImageSizeWidthNumeric.Size = new System.Drawing.Size(96, 20);
			this.m_ImageSizeWidthNumeric.TabIndex = 7;
			this.m_ImageSizeWidthNumeric.Value = new System.Decimal(new int[] {
																				  4,
																				  0,
																				  0,
																				  0});
			this.m_ImageSizeWidthNumeric.ValueChanged += new System.EventHandler(this.m_ImageSizeWidthNumeric_ValueChanged);
			// 
			// m_ImageSizeHeightNumeric
			// 
			this.m_ImageSizeHeightNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_ImageSizeHeightNumeric.Location = new System.Drawing.Point(112, 296);
			this.m_ImageSizeHeightNumeric.Maximum = new System.Decimal(new int[] {
																					 46,
																					 0,
																					 0,
																					 0});
			this.m_ImageSizeHeightNumeric.Minimum = new System.Decimal(new int[] {
																					 4,
																					 0,
																					 0,
																					 0});
			this.m_ImageSizeHeightNumeric.Name = "m_ImageSizeHeightNumeric";
			this.m_ImageSizeHeightNumeric.Size = new System.Drawing.Size(96, 20);
			this.m_ImageSizeHeightNumeric.TabIndex = 8;
			this.m_ImageSizeHeightNumeric.Value = new System.Decimal(new int[] {
																				   4,
																				   0,
																				   0,
																				   0});
			this.m_ImageSizeHeightNumeric.ValueChanged += new System.EventHandler(this.m_ImageSizeHeightNumeric_ValueChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBox1.ImageList = this.imageList1;
			this.comboBox1.Location = new System.Drawing.Point(112, 320);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(96, 21);
			this.comboBox1.TabIndex = 9;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.Location = new System.Drawing.Point(8, 320);
			this.label3.Name = "label3";
			this.label3.TabIndex = 10;
			this.label3.Text = "Image Index:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NListBoxImageSizeUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.m_ImageSizeHeightNumeric);
			this.Controls.Add(this.m_ImageSizeWidthNumeric);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nListBox1);
			this.Name = "NListBoxImageSizeUC";
			this.Size = new System.Drawing.Size(304, 352);
			((System.ComponentModel.ISupportInitialize)(this.m_ImageSizeWidthNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_ImageSizeHeightNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private NNumericUpDown m_ImageSizeWidthNumeric;
		private NNumericUpDown m_ImageSizeHeightNumeric;
		private Nevron.UI.WinForm.Controls.NListBox nListBox1;
		private NComboBox comboBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		#endregion
	}
}
