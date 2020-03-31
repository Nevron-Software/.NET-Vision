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
	/// Summary description for NEntryBoxUC.
	/// </summary>
	public class NEntryBoxUC : NExampleUserControl
	{
		#region Constructor

		public NEntryBoxUC(MainForm f) : base(f)
		{
			InitializeComponent();
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
		}



		#endregion

		#region Event Handlers

		private void enabledCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NEntryContainer container;

			foreach(Control c in nGroupBoxEx1.Controls)
			{
				container = c as NEntryContainer;
				if(container == null)
					continue;

				container.Enabled = enabledCheck.Checked;
			}
		}

		private void fillBoundingBoxCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NEntryContainer container;

			foreach(Control c in nGroupBoxEx1.Controls)
			{
				container = c as NEntryContainer;
				if(container == null)
					continue;

				container.FillEntryControlBounds = fillBoundingBoxCheck.Checked;
			}
		}

		private void interactiveCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NEntryContainer container;

			foreach(Control c in nGroupBoxEx1.Controls)
			{
				container = c as NEntryContainer;
				if(container == null)
					continue;

				container.Interactive = interactiveCheck.Checked;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NEntryBoxUC));
			this.nGroupBoxEx1 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
			this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox4 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox3 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox2 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBoxEx2 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
			this.nRadioButton3 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton2 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton1 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.fillBoundingBoxCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.enabledCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.interactiveCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).BeginInit();
			this.nGroupBoxEx1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
			this.nEntryContainer4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
			this.nEntryContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
			this.nEntryContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
			this.nEntryContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
			this.nGrouper1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx2)).BeginInit();
			this.nGroupBoxEx2.SuspendLayout();
			this.SuspendLayout();
			// 
			// nGroupBoxEx1
			// 
			this.nGroupBoxEx1.BackColor = System.Drawing.Color.Transparent;
			this.nGroupBoxEx1.Controls.Add(this.nEntryContainer4);
			this.nGroupBoxEx1.Controls.Add(this.nEntryContainer3);
			this.nGroupBoxEx1.Controls.Add(this.nEntryContainer2);
			this.nGroupBoxEx1.Controls.Add(this.nEntryContainer1);
			this.nGroupBoxEx1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.nGroupBoxEx1.HeaderItem.Image = ((System.Drawing.Image)(resources.GetObject("nGroupBoxEx1.HeaderItem.Image")));
			this.nGroupBoxEx1.HeaderItem.ImageSizeMode = Nevron.UI.ImageSizeMode.Stretch;
			this.nGroupBoxEx1.HeaderItem.ImageTextSpacing = 2;
			this.nGroupBoxEx1.HeaderItem.Padding = new Nevron.UI.NPadding(1, 1, 1, 1);
			this.nGroupBoxEx1.HeaderItem.Text = "Customer";
			this.nGroupBoxEx1.HeaderShadowInfo.Draw = false;
			this.nGroupBoxEx1.HeaderStrokeInfo.Rounding = 5;
			this.nGroupBoxEx1.Location = new System.Drawing.Point(16, 32);
			this.nGroupBoxEx1.Name = "nGroupBoxEx1";
			this.nGroupBoxEx1.ShadowInfo.Draw = false;
			this.nGroupBoxEx1.Size = new System.Drawing.Size(344, 224);
			this.nGroupBoxEx1.StrokeInfo.Rounding = 5;
			this.nGroupBoxEx1.TabIndex = 0;
			// 
			// nEntryContainer4
			// 
			this.nEntryContainer4.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
			this.nEntryContainer4.EntryControl = this.nTextBox4;
			this.nEntryContainer4.Item.ContentAlign = System.Drawing.ContentAlignment.TopLeft;
			this.nEntryContainer4.LabelSize = new System.Drawing.Size(70, 0);
			this.nEntryContainer4.Location = new System.Drawing.Point(24, 136);
			this.nEntryContainer4.Name = "nEntryContainer4";
			this.nEntryContainer4.Size = new System.Drawing.Size(304, 80);
			this.nEntryContainer4.StrokeInfo.Rounding = 5;
			this.nEntryContainer4.TabIndex = 5;
			this.nEntryContainer4.Text = "Notes:";
			// 
			// nTextBox4
			// 
			this.nTextBox4.AutoSize = false;
			this.nTextBox4.Border.Style = Nevron.UI.BorderStyle3D.None;
			this.nTextBox4.Location = new System.Drawing.Point(83, 7);
			this.nTextBox4.Multiline = true;
			this.nTextBox4.Name = "nTextBox4";
			this.nTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.nTextBox4.Size = new System.Drawing.Size(209, 61);
			this.nTextBox4.TabIndex = 3;
			// 
			// nEntryContainer3
			// 
			this.nEntryContainer3.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
			this.nEntryContainer3.EntryControl = this.nTextBox3;
			this.nEntryContainer3.LabelSize = new System.Drawing.Size(70, 0);
			this.nEntryContainer3.Location = new System.Drawing.Point(24, 104);
			this.nEntryContainer3.Name = "nEntryContainer3";
			this.nEntryContainer3.Size = new System.Drawing.Size(304, 32);
			this.nEntryContainer3.StrokeInfo.Rounding = 5;
			this.nEntryContainer3.TabIndex = 4;
			this.nEntryContainer3.Text = "Address:";
			// 
			// nTextBox3
			// 
			this.nTextBox3.AutoSize = false;
			this.nTextBox3.Border.Style = Nevron.UI.BorderStyle3D.None;
			this.nTextBox3.Location = new System.Drawing.Point(83, 7);
			this.nTextBox3.Name = "nTextBox3";
			this.nTextBox3.Size = new System.Drawing.Size(209, 13);
			this.nTextBox3.TabIndex = 3;
			// 
			// nEntryContainer2
			// 
			this.nEntryContainer2.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
			this.nEntryContainer2.EntryControl = this.nTextBox2;
			this.nEntryContainer2.LabelSize = new System.Drawing.Size(70, 0);
			this.nEntryContainer2.Location = new System.Drawing.Point(24, 72);
			this.nEntryContainer2.Name = "nEntryContainer2";
			this.nEntryContainer2.Size = new System.Drawing.Size(304, 32);
			this.nEntryContainer2.StrokeInfo.Rounding = 5;
			this.nEntryContainer2.TabIndex = 3;
			this.nEntryContainer2.Text = "Last Name:";
			// 
			// nTextBox2
			// 
			this.nTextBox2.AutoSize = false;
			this.nTextBox2.Border.Style = Nevron.UI.BorderStyle3D.None;
			this.nTextBox2.Location = new System.Drawing.Point(83, 7);
			this.nTextBox2.Name = "nTextBox2";
			this.nTextBox2.Size = new System.Drawing.Size(209, 13);
			this.nTextBox2.TabIndex = 3;
			// 
			// nEntryContainer1
			// 
			this.nEntryContainer1.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
			this.nEntryContainer1.EntryControl = this.nTextBox1;
			this.nEntryContainer1.LabelSize = new System.Drawing.Size(70, 0);
			this.nEntryContainer1.Location = new System.Drawing.Point(24, 40);
			this.nEntryContainer1.Name = "nEntryContainer1";
			this.nEntryContainer1.Size = new System.Drawing.Size(304, 32);
			this.nEntryContainer1.StrokeInfo.Rounding = 5;
			this.nEntryContainer1.TabIndex = 2;
			this.nEntryContainer1.Text = "First Name:";
			// 
			// nTextBox1
			// 
			this.nTextBox1.AutoSize = false;
			this.nTextBox1.Border.Style = Nevron.UI.BorderStyle3D.None;
			this.nTextBox1.Location = new System.Drawing.Point(83, 7);
			this.nTextBox1.Name = "nTextBox1";
			this.nTextBox1.Size = new System.Drawing.Size(209, 13);
			this.nTextBox1.TabIndex = 3;
			// 
			// nGrouper1
			// 
			this.nGrouper1.Controls.Add(this.nButton1);
			this.nGrouper1.Controls.Add(this.nGroupBoxEx2);
			this.nGrouper1.Controls.Add(this.nGroupBoxEx1);
			this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper1.FooterItem.Text = "Footer";
			this.nGrouper1.FooterItem.Visible = false;
			this.nGrouper1.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
			this.nGrouper1.HeaderItem.Style.FrameStyle = null;
			this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))));
			this.nGrouper1.HeaderItem.Text = "Purchase Order";
			this.nGrouper1.Location = new System.Drawing.Point(8, 8);
			this.nGrouper1.Name = "nGrouper1";
			this.nGrouper1.ShadowInfo.Draw = false;
			this.nGrouper1.Size = new System.Drawing.Size(376, 376);
			this.nGrouper1.TabIndex = 1;
			this.nGrouper1.Text = "nGrouper1";
			// 
			// nButton1
			// 
			this.nButton1.Location = new System.Drawing.Point(264, 344);
			this.nButton1.Name = "nButton1";
			this.nButton1.Size = new System.Drawing.Size(96, 24);
			this.nButton1.TabIndex = 2;
			this.nButton1.Text = "Submit";
			// 
			// nGroupBoxEx2
			// 
			this.nGroupBoxEx2.BackColor = System.Drawing.Color.Transparent;
			this.nGroupBoxEx2.Controls.Add(this.nRadioButton3);
			this.nGroupBoxEx2.Controls.Add(this.nRadioButton2);
			this.nGroupBoxEx2.Controls.Add(this.nRadioButton1);
			this.nGroupBoxEx2.HeaderItem.Image = ((System.Drawing.Image)(resources.GetObject("nGroupBoxEx2.HeaderItem.Image")));
			this.nGroupBoxEx2.HeaderItem.ImageSizeMode = Nevron.UI.ImageSizeMode.Stretch;
			this.nGroupBoxEx2.HeaderItem.ImageTextSpacing = 2;
			this.nGroupBoxEx2.HeaderItem.Padding = new Nevron.UI.NPadding(1, 1, 1, 1);
			this.nGroupBoxEx2.HeaderItem.Text = "Ship Via";
			this.nGroupBoxEx2.HeaderShadowInfo.Draw = false;
			this.nGroupBoxEx2.HeaderStrokeInfo.Rounding = 5;
			this.nGroupBoxEx2.Location = new System.Drawing.Point(16, 264);
			this.nGroupBoxEx2.Name = "nGroupBoxEx2";
			this.nGroupBoxEx2.ShadowInfo.Draw = false;
			this.nGroupBoxEx2.Size = new System.Drawing.Size(344, 64);
			this.nGroupBoxEx2.StrokeInfo.Rounding = 5;
			this.nGroupBoxEx2.TabIndex = 1;
			// 
			// nRadioButton3
			// 
			this.nRadioButton3.Location = new System.Drawing.Point(248, 32);
			this.nRadioButton3.Name = "nRadioButton3";
			this.nRadioButton3.Size = new System.Drawing.Size(72, 24);
			this.nRadioButton3.TabIndex = 4;
			this.nRadioButton3.Text = "Speedy";
			this.nRadioButton3.TransparentBackground = true;
			// 
			// nRadioButton2
			// 
			this.nRadioButton2.Location = new System.Drawing.Point(136, 32);
			this.nRadioButton2.Name = "nRadioButton2";
			this.nRadioButton2.Size = new System.Drawing.Size(80, 24);
			this.nRadioButton2.TabIndex = 3;
			this.nRadioButton2.Text = "Mail";
			this.nRadioButton2.TransparentBackground = true;
			// 
			// nRadioButton1
			// 
			this.nRadioButton1.Location = new System.Drawing.Point(32, 32);
			this.nRadioButton1.Name = "nRadioButton1";
			this.nRadioButton1.Size = new System.Drawing.Size(56, 24);
			this.nRadioButton1.TabIndex = 2;
			this.nRadioButton1.Text = "DHL";
			this.nRadioButton1.TransparentBackground = true;
			// 
			// fillBoundingBoxCheck
			// 
			this.fillBoundingBoxCheck.Checked = true;
			this.fillBoundingBoxCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fillBoundingBoxCheck.Location = new System.Drawing.Point(392, 32);
			this.fillBoundingBoxCheck.Name = "fillBoundingBoxCheck";
			this.fillBoundingBoxCheck.Size = new System.Drawing.Size(128, 24);
			this.fillBoundingBoxCheck.TabIndex = 2;
			this.fillBoundingBoxCheck.Text = "Fill Bounding Box";
			this.fillBoundingBoxCheck.CheckedChanged += new System.EventHandler(this.fillBoundingBoxCheck_CheckedChanged);
			// 
			// enabledCheck
			// 
			this.enabledCheck.Checked = true;
			this.enabledCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.enabledCheck.Location = new System.Drawing.Point(392, 8);
			this.enabledCheck.Name = "enabledCheck";
			this.enabledCheck.Size = new System.Drawing.Size(128, 24);
			this.enabledCheck.TabIndex = 3;
			this.enabledCheck.Text = "Enabled";
			this.enabledCheck.CheckedChanged += new System.EventHandler(this.enabledCheck_CheckedChanged);
			// 
			// interactiveCheck
			// 
			this.interactiveCheck.Checked = true;
			this.interactiveCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.interactiveCheck.Location = new System.Drawing.Point(392, 56);
			this.interactiveCheck.Name = "interactiveCheck";
			this.interactiveCheck.Size = new System.Drawing.Size(128, 24);
			this.interactiveCheck.TabIndex = 4;
			this.interactiveCheck.Text = "Interactive";
			this.interactiveCheck.CheckedChanged += new System.EventHandler(this.interactiveCheck_CheckedChanged);
			// 
			// NEntryBoxUC
			// 
			this.Controls.Add(this.interactiveCheck);
			this.Controls.Add(this.enabledCheck);
			this.Controls.Add(this.fillBoundingBoxCheck);
			this.Controls.Add(this.nGrouper1);
			this.Name = "NEntryBoxUC";
			this.Size = new System.Drawing.Size(520, 392);
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).EndInit();
			this.nGroupBoxEx1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
			this.nEntryContainer4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
			this.nEntryContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
			this.nEntryContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
			this.nEntryContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
			this.nGrouper1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx2)).EndInit();
			this.nGroupBoxEx2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx1;
		private Nevron.UI.WinForm.Controls.NGrouper nGrouper1;
		private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx2;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton1;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton2;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton3;
		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox2;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer3;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox3;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer4;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox4;
		private Nevron.UI.WinForm.Controls.NCheckBox fillBoundingBoxCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox enabledCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox interactiveCheck;

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
