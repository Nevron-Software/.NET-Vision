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
	/// <summary>
	/// Summary description for NEntryControlExtendedUC.
	/// </summary>
	public class NEntryControlsExtendedUC : NExampleUserControl
	{
		#region Constructor

		public NEntryControlsExtendedUC(MainForm f) : base(f)
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

			this.nGrouper1.FooterItem.HyperLinkClick += new Nevron.UI.NHyperLinkEventHandler(OnFooterItemHyperLinkClick);

			this.nComboBox1.ListProperties.ColumnOnLeft = false;
			this.nComboBox1.Items.Add(".NET Vision");
			this.nComboBox1.Items.Add("Chart for .NET");
			this.nComboBox1.Items.Add("Diagram for .NET");
			this.nComboBox1.Items.Add("User Interface for .NET");
		}



		#endregion

		#region Event Handlers

		private void OnFooterItemHyperLinkClick(object sender, Nevron.UI.NHyperLinkEventArgs e)
		{
			Process.Start(e.Url);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NEntryControlsExtendedUC));
			this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
			this.nGroupBoxEx2 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
			this.nEntryContainer8 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nDateTimePicker1 = new Nevron.UI.WinForm.Controls.NDateTimePicker();
			this.nEntryContainer7 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox6 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nEntryContainer5 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox5 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox4 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nComboBox1 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBoxEx1 = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
			this.nEntryContainer6 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox3 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.nTextBox2 = new Nevron.UI.WinForm.Controls.NTextBox();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
			this.nEntryContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
			this.nGrouper1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx2)).BeginInit();
			this.nGroupBoxEx2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer8)).BeginInit();
			this.nEntryContainer8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer7)).BeginInit();
			this.nEntryContainer7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer5)).BeginInit();
			this.nEntryContainer5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
			this.nEntryContainer4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
			this.nEntryContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).BeginInit();
			this.nGroupBoxEx1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer6)).BeginInit();
			this.nEntryContainer6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
			this.nEntryContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// nEntryContainer1
			// 
			this.nEntryContainer1.BackColor = System.Drawing.Color.Transparent;
			this.nEntryContainer1.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer1.EntryControl = this.nTextBox1;
			this.nEntryContainer1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nEntryContainer1.LabelSize = new System.Drawing.Size(60, 0);
			this.nEntryContainer1.Location = new System.Drawing.Point(16, 32);
			this.nEntryContainer1.Name = "nEntryContainer1";
			this.nEntryContainer1.ShadowInfo.Draw = false;
			this.nEntryContainer1.Size = new System.Drawing.Size(392, 24);
			this.nEntryContainer1.StrokeInfo.Draw = false;
			this.nEntryContainer1.TabIndex = 0;
			this.nEntryContainer1.Text = "Name<font color=\'red\'><b>*</b></font>:";
			// 
			// nTextBox1
			// 
			this.nTextBox1.Location = new System.Drawing.Point(68, 2);
			this.nTextBox1.Name = "nTextBox1";
			this.nTextBox1.Size = new System.Drawing.Size(322, 19);
			this.nTextBox1.TabIndex = 1;
			// 
			// nGrouper1
			// 
			this.nGrouper1.Controls.Add(this.nGroupBoxEx2);
			this.nGrouper1.Controls.Add(this.nGroupBoxEx1);
			this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper1.FooterItem.Image = ((System.Drawing.Image)(resources.GetObject("nGrouper1.FooterItem.Image")));
			this.nGrouper1.FooterItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.nGrouper1.FooterItem.ImageSizeMode = Nevron.UI.ImageSizeMode.Stretch;
			this.nGrouper1.FooterItem.ImageTextRelation = Nevron.UI.ImageTextRelation.None;
			this.nGrouper1.FooterItem.Text = "For more information visit <a href=\'www.nevron.com\'>www.nevron.com</a>";
			this.nGrouper1.FooterItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper1.HeaderItem.Image = ((System.Drawing.Image)(resources.GetObject("nGrouper1.HeaderItem.Image")));
			this.nGrouper1.HeaderItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper1.HeaderItem.ImageSize = new Nevron.GraphicsCore.NSize(32, 32);
			this.nGrouper1.HeaderItem.ImageTextRelation = Nevron.UI.ImageTextRelation.None;
			this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))));
			this.nGrouper1.HeaderItem.Style.TextOffset = new Nevron.GraphicsCore.NPoint(0, 0);
			this.nGrouper1.HeaderItem.Text = "<font shadowtype=\'linearblur\' shadowcolor=\'black\' size=\'15\' face=\'Trebuchet MS\'><" +
				"b>Purchase Form</b></font><br/><font size=\'9\'>Detailed List</font>";
			this.nGrouper1.HeaderItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nGrouper1.HeaderStrokeInfo.Draw = false;
			this.nGrouper1.Location = new System.Drawing.Point(8, 8);
			this.nGrouper1.Name = "nGrouper1";
			this.nGrouper1.Size = new System.Drawing.Size(448, 408);
			this.nGrouper1.TabIndex = 2;
			this.nGrouper1.Text = "nGrouper1";
			// 
			// nGroupBoxEx2
			// 
			this.nGroupBoxEx2.BackColor = System.Drawing.Color.Transparent;
			this.nGroupBoxEx2.Controls.Add(this.nEntryContainer8);
			this.nGroupBoxEx2.Controls.Add(this.nEntryContainer7);
			this.nGroupBoxEx2.Controls.Add(this.nEntryContainer5);
			this.nGroupBoxEx2.Controls.Add(this.nEntryContainer4);
			this.nGroupBoxEx2.Controls.Add(this.nEntryContainer3);
			this.nGroupBoxEx2.FillInfo.Draw = false;
			this.nGroupBoxEx2.HeaderItem.Text = "Product Information";
			this.nGroupBoxEx2.HeaderShadowInfo.Draw = false;
			this.nGroupBoxEx2.HeaderStrokeInfo.Rounding = 2;
			this.nGroupBoxEx2.Location = new System.Drawing.Point(8, 224);
			this.nGroupBoxEx2.Name = "nGroupBoxEx2";
			this.nGroupBoxEx2.ShadowInfo.Draw = false;
			this.nGroupBoxEx2.Size = new System.Drawing.Size(424, 144);
			this.nGroupBoxEx2.StrokeInfo.Rounding = 5;
			this.nGroupBoxEx2.TabIndex = 6;
			this.nGroupBoxEx2.Text = "nGroupBoxEx2";
			// 
			// nEntryContainer8
			// 
			this.nEntryContainer8.BackColor = System.Drawing.Color.Transparent;
			this.nEntryContainer8.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer8.EntryControl = this.nDateTimePicker1;
			this.nEntryContainer8.Item.Padding = new Nevron.UI.NPadding(1, 0, 0, 0);
			this.nEntryContainer8.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl;
			this.nEntryContainer8.LabelSize = new System.Drawing.Size(60, 0);
			this.nEntryContainer8.Location = new System.Drawing.Point(216, 88);
			this.nEntryContainer8.Name = "nEntryContainer8";
			this.nEntryContainer8.ShadowInfo.Draw = false;
			this.nEntryContainer8.Size = new System.Drawing.Size(192, 48);
			this.nEntryContainer8.StrokeInfo.Draw = false;
			this.nEntryContainer8.TabIndex = 6;
			this.nEntryContainer8.Text = "Purchase Date<font color=\'red\'><b>*</b></font>:";
			// 
			// nDateTimePicker1
			// 
			this.nDateTimePicker1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nDateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nDateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((System.Byte)(235)), ((System.Byte)(235)), ((System.Byte)(235)));
			this.nDateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((System.Byte)(76)), ((System.Byte)(76)), ((System.Byte)(76)));
			this.nDateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((System.Byte)(242)), ((System.Byte)(242)), ((System.Byte)(242)));
			this.nDateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((System.Byte)(127)), ((System.Byte)(127)), ((System.Byte)(127)));
			this.nDateTimePicker1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.nDateTimePicker1.Location = new System.Drawing.Point(2, 21);
			this.nDateTimePicker1.Name = "nDateTimePicker1";
			this.nDateTimePicker1.Size = new System.Drawing.Size(188, 21);
			this.nDateTimePicker1.TabIndex = 7;
			// 
			// nEntryContainer7
			// 
			this.nEntryContainer7.BackColor = System.Drawing.Color.Transparent;
			this.nEntryContainer7.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer7.EntryControl = this.nTextBox6;
			this.nEntryContainer7.Item.Padding = new Nevron.UI.NPadding(1, 0, 0, 0);
			this.nEntryContainer7.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl;
			this.nEntryContainer7.LabelSize = new System.Drawing.Size(60, 0);
			this.nEntryContainer7.Location = new System.Drawing.Point(16, 88);
			this.nEntryContainer7.Name = "nEntryContainer7";
			this.nEntryContainer7.ShadowInfo.Draw = false;
			this.nEntryContainer7.Size = new System.Drawing.Size(192, 48);
			this.nEntryContainer7.StrokeInfo.Draw = false;
			this.nEntryContainer7.TabIndex = 5;
			this.nEntryContainer7.Text = "Discount Coupon:";
			// 
			// nTextBox6
			// 
			this.nTextBox6.Location = new System.Drawing.Point(2, 21);
			this.nTextBox6.Name = "nTextBox6";
			this.nTextBox6.Size = new System.Drawing.Size(188, 19);
			this.nTextBox6.TabIndex = 1;
			// 
			// nEntryContainer5
			// 
			this.nEntryContainer5.BackColor = System.Drawing.Color.Transparent;
			this.nEntryContainer5.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer5.EntryControl = this.nTextBox5;
			this.nEntryContainer5.Item.Padding = new Nevron.UI.NPadding(1, 0, 0, 0);
			this.nEntryContainer5.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl;
			this.nEntryContainer5.LabelSize = new System.Drawing.Size(60, 0);
			this.nEntryContainer5.Location = new System.Drawing.Point(312, 32);
			this.nEntryContainer5.Name = "nEntryContainer5";
			this.nEntryContainer5.ShadowInfo.Draw = false;
			this.nEntryContainer5.Size = new System.Drawing.Size(96, 48);
			this.nEntryContainer5.StrokeInfo.Draw = false;
			this.nEntryContainer5.TabIndex = 4;
			this.nEntryContainer5.Text = "Copies<font color=\'red\'><b>*</b></font>:";
			// 
			// nTextBox5
			// 
			this.nTextBox5.Location = new System.Drawing.Point(2, 21);
			this.nTextBox5.Name = "nTextBox5";
			this.nTextBox5.Size = new System.Drawing.Size(92, 19);
			this.nTextBox5.TabIndex = 1;
			// 
			// nEntryContainer4
			// 
			this.nEntryContainer4.BackColor = System.Drawing.Color.Transparent;
			this.nEntryContainer4.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer4.EntryControl = this.nTextBox4;
			this.nEntryContainer4.Item.Padding = new Nevron.UI.NPadding(1, 0, 0, 0);
			this.nEntryContainer4.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl;
			this.nEntryContainer4.LabelSize = new System.Drawing.Size(60, 0);
			this.nEntryContainer4.Location = new System.Drawing.Point(216, 32);
			this.nEntryContainer4.Name = "nEntryContainer4";
			this.nEntryContainer4.ShadowInfo.Draw = false;
			this.nEntryContainer4.Size = new System.Drawing.Size(88, 48);
			this.nEntryContainer4.StrokeInfo.Draw = false;
			this.nEntryContainer4.TabIndex = 3;
			this.nEntryContainer4.Text = "Price(USD)<font color=\'red\'><b>*</b></font>:";
			// 
			// nTextBox4
			// 
			this.nTextBox4.Location = new System.Drawing.Point(2, 21);
			this.nTextBox4.Name = "nTextBox4";
			this.nTextBox4.Size = new System.Drawing.Size(84, 19);
			this.nTextBox4.TabIndex = 1;
			// 
			// nEntryContainer3
			// 
			this.nEntryContainer3.BackColor = System.Drawing.Color.Transparent;
			this.nEntryContainer3.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer3.EntryControl = this.nComboBox1;
			this.nEntryContainer3.Item.ContentAlign = System.Drawing.ContentAlignment.TopLeft;
			this.nEntryContainer3.Item.Padding = new Nevron.UI.NPadding(1, 0, 0, 0);
			this.nEntryContainer3.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl;
			this.nEntryContainer3.LabelSize = new System.Drawing.Size(60, 0);
			this.nEntryContainer3.Location = new System.Drawing.Point(16, 32);
			this.nEntryContainer3.Name = "nEntryContainer3";
			this.nEntryContainer3.ShadowInfo.Draw = false;
			this.nEntryContainer3.Size = new System.Drawing.Size(192, 48);
			this.nEntryContainer3.StrokeInfo.Draw = false;
			this.nEntryContainer3.TabIndex = 2;
			this.nEntryContainer3.Text = "Product<font color=\'red\'><b>*</b></font>:";
			// 
			// nComboBox1
			// 
			this.nComboBox1.Location = new System.Drawing.Point(2, 21);
			this.nComboBox1.Name = "nComboBox1";
			this.nComboBox1.Size = new System.Drawing.Size(188, 25);
			this.nComboBox1.TabIndex = 5;
			this.nComboBox1.Text = "nComboBox1";
			// 
			// nGroupBoxEx1
			// 
			this.nGroupBoxEx1.BackColor = System.Drawing.Color.Transparent;
			this.nGroupBoxEx1.Controls.Add(this.nEntryContainer6);
			this.nGroupBoxEx1.Controls.Add(this.nEntryContainer1);
			this.nGroupBoxEx1.Controls.Add(this.nEntryContainer2);
			this.nGroupBoxEx1.FillInfo.Draw = false;
			this.nGroupBoxEx1.HeaderItem.Text = "Customer Information";
			this.nGroupBoxEx1.HeaderShadowInfo.Draw = false;
			this.nGroupBoxEx1.HeaderStrokeInfo.Rounding = 2;
			this.nGroupBoxEx1.Location = new System.Drawing.Point(8, 48);
			this.nGroupBoxEx1.Name = "nGroupBoxEx1";
			this.nGroupBoxEx1.ShadowInfo.Draw = false;
			this.nGroupBoxEx1.Size = new System.Drawing.Size(424, 168);
			this.nGroupBoxEx1.StrokeInfo.Rounding = 5;
			this.nGroupBoxEx1.TabIndex = 5;
			this.nGroupBoxEx1.Text = "nGroupBoxEx1";
			// 
			// nEntryContainer6
			// 
			this.nEntryContainer6.BackColor = System.Drawing.Color.Transparent;
			this.nEntryContainer6.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer6.EntryControl = this.nTextBox3;
			this.nEntryContainer6.Item.ContentAlign = System.Drawing.ContentAlignment.TopRight;
			this.nEntryContainer6.LabelSize = new System.Drawing.Size(60, 0);
			this.nEntryContainer6.Location = new System.Drawing.Point(16, 80);
			this.nEntryContainer6.Name = "nEntryContainer6";
			this.nEntryContainer6.ShadowInfo.Draw = false;
			this.nEntryContainer6.Size = new System.Drawing.Size(392, 80);
			this.nEntryContainer6.StrokeInfo.Draw = false;
			this.nEntryContainer6.TabIndex = 2;
			this.nEntryContainer6.Text = "Details:";
			// 
			// nTextBox3
			// 
			this.nTextBox3.Location = new System.Drawing.Point(68, 2);
			this.nTextBox3.Multiline = true;
			this.nTextBox3.Name = "nTextBox3";
			this.nTextBox3.Size = new System.Drawing.Size(322, 76);
			this.nTextBox3.TabIndex = 1;
			// 
			// nEntryContainer2
			// 
			this.nEntryContainer2.BackColor = System.Drawing.Color.Transparent;
			this.nEntryContainer2.ClientPadding = new Nevron.UI.NPadding(2, 2, 2, 2);
			this.nEntryContainer2.EntryControl = this.nTextBox2;
			this.nEntryContainer2.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nEntryContainer2.LabelSize = new System.Drawing.Size(60, 0);
			this.nEntryContainer2.Location = new System.Drawing.Point(16, 56);
			this.nEntryContainer2.Name = "nEntryContainer2";
			this.nEntryContainer2.ShadowInfo.Draw = false;
			this.nEntryContainer2.Size = new System.Drawing.Size(392, 24);
			this.nEntryContainer2.StrokeInfo.Draw = false;
			this.nEntryContainer2.TabIndex = 1;
			this.nEntryContainer2.Text = "Address<font color=\'red\'><b>*</b></font>:";
			// 
			// nTextBox2
			// 
			this.nTextBox2.Location = new System.Drawing.Point(68, 2);
			this.nTextBox2.Name = "nTextBox2";
			this.nTextBox2.Size = new System.Drawing.Size(322, 19);
			this.nTextBox2.TabIndex = 1;
			// 
			// NEntryControlsExtendedUC
			// 
			this.Controls.Add(this.nGrouper1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.Name = "NEntryControlsExtendedUC";
			this.Size = new System.Drawing.Size(456, 416);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
			this.nEntryContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
			this.nGrouper1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx2)).EndInit();
			this.nGroupBoxEx2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer8)).EndInit();
			this.nEntryContainer8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer7)).EndInit();
			this.nEntryContainer7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer5)).EndInit();
			this.nEntryContainer5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
			this.nEntryContainer4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
			this.nEntryContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nGroupBoxEx1)).EndInit();
			this.nGroupBoxEx1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer6)).EndInit();
			this.nEntryContainer6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
			this.nEntryContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
		private Nevron.UI.WinForm.Controls.NGrouper nGrouper1;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox2;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer3;
		private Nevron.UI.WinForm.Controls.NComboBox nComboBox1;
		private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx1;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer6;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox3;
		private Nevron.UI.WinForm.Controls.NGroupBoxEx nGroupBoxEx2;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer4;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox4;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer5;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox5;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer7;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox6;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer8;
		private Nevron.UI.WinForm.Controls.NDateTimePicker nDateTimePicker1;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;

		#endregion
	}
}

