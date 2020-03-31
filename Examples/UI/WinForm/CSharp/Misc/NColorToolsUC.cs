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
	/// Summary description for NColorToolsUC.
	/// </summary>
	public class NColorToolsUC : NExampleUserControl
	{
		#region Constructor

		public NColorToolsUC(MainForm f) : base(f)
		{
			InitializeComponent();
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

			nColorComboBox1.PopulateKnownColors();
			nColorListBox1.PopulateKnownColors();
		}




		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nColorBar1 = new Nevron.UI.WinForm.Controls.NColorBar();
			this.nColorPool1 = new Nevron.UI.WinForm.Controls.NColorPool();
			this.nLuminanceBar1 = new Nevron.UI.WinForm.Controls.NLuminanceBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.nColorButton1 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label4 = new System.Windows.Forms.Label();
			this.nColorComboBox1 = new Nevron.UI.WinForm.Controls.NColorComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.nColorListBox1 = new Nevron.UI.WinForm.Controls.NColorListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// nColorBar1
			// 
			this.nColorBar1.Location = new System.Drawing.Point(112, 8);
			this.nColorBar1.Name = "nColorBar1";
			this.nColorBar1.Size = new System.Drawing.Size(192, 32);
			this.nColorBar1.TabIndex = 0;
			this.nColorBar1.Text = "nColorBar1";
			this.nColorBar1.Value = 155;
			// 
			// nColorPool1
			// 
			this.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nColorPool1.Color = System.Drawing.Color.Empty;
			this.nColorPool1.Location = new System.Drawing.Point(117, 80);
			this.nColorPool1.Name = "nColorPool1";
			this.nColorPool1.Size = new System.Drawing.Size(184, 102);
			this.nColorPool1.TabIndex = 1;
			// 
			// nLuminanceBar1
			// 
			this.nLuminanceBar1.Color = System.Drawing.Color.Brown;
			this.nLuminanceBar1.Location = new System.Drawing.Point(112, 40);
			this.nLuminanceBar1.Mode = Nevron.UI.WinForm.Controls.ColorBarMode.Custom;
			this.nLuminanceBar1.Name = "nLuminanceBar1";
			this.nLuminanceBar1.Size = new System.Drawing.Size(192, 32);
			this.nLuminanceBar1.TabIndex = 2;
			this.nLuminanceBar1.Text = "nLuminanceBar1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "NColorBar:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "NLuminanceBar:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "NColorPool:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nColorButton1
			// 
			this.nColorButton1.ArrowClickOptions = false;
			this.nColorButton1.Color = System.Drawing.Color.White;
			this.nColorButton1.Location = new System.Drawing.Point(118, 202);
			this.nColorButton1.Name = "nColorButton1";
			this.nColorButton1.Size = new System.Drawing.Size(112, 24);
			this.nColorButton1.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 202);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "NColorButton:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nColorComboBox1
			// 
			this.nColorComboBox1.Location = new System.Drawing.Point(118, 239);
			this.nColorComboBox1.Name = "nColorComboBox1";
			this.nColorComboBox1.Size = new System.Drawing.Size(184, 22);
			this.nColorComboBox1.TabIndex = 8;
			this.nColorComboBox1.Text = "nColorComboBox1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 239);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "NColorComboBox:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nColorListBox1
			// 
			this.nColorListBox1.Location = new System.Drawing.Point(118, 273);
			this.nColorListBox1.Name = "nColorListBox1";
			this.nColorListBox1.Size = new System.Drawing.Size(184, 144);
			this.nColorListBox1.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(0, 273);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "NColorListBox:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NColorToolsUC
			// 
			this.Controls.Add(this.label6);
			this.Controls.Add(this.nColorListBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nColorComboBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.nColorButton1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nLuminanceBar1);
			this.Controls.Add(this.nColorPool1);
			this.Controls.Add(this.nColorBar1);
			this.Name = "NColorToolsUC";
			this.Size = new System.Drawing.Size(333, 424);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NColorBar nColorBar1;
		private Nevron.UI.WinForm.Controls.NColorPool nColorPool1;
		private Nevron.UI.WinForm.Controls.NLuminanceBar nLuminanceBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton1;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NColorComboBox nColorComboBox1;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NColorListBox nColorListBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;

		#endregion
	}
}
