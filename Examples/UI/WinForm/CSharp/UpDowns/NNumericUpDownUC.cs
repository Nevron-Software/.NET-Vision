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
	public class NNumericUpDownUC : NExampleUserControl
	{
		#region Constructor

		public NNumericUpDownUC(MainForm f) : base(f)
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


		#endregion

		#region Event Handlers

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(c is NNumericUpDown)
					c.Enabled = nCheckBox1.Checked;
			}
		}
		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
		}

		private void m_CustomTextEdit_TextChanged(object sender, System.EventArgs e)
		{
			nNumericUpDown1.CustomText = m_CustomTextEdit.Text;

			foreach(Control c in Controls)
			{
				if(!(c is NNumericUpDown))
					continue;
				((NNumericUpDown)c).CustomText = m_CustomTextEdit.Text;
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
            this.nNumericUpDown1 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown2 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown3 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown4 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown5 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown6 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown7 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown8 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown9 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown10 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown13 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown11 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown12 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown14 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nNumericUpDown15 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.m_CustomTextEdit = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown15)).BeginInit();
            this.SuspendLayout();
            // 
            // nNumericUpDown1
            // 
            this.nNumericUpDown1.DecimalPlaces = 2;
            this.nNumericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nNumericUpDown1.Location = new System.Drawing.Point(8, 8);
            this.nNumericUpDown1.Name = "nNumericUpDown1";
            this.nNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.nNumericUpDown1.TabIndex = 0;
            // 
            // nNumericUpDown2
            // 
            this.nNumericUpDown2.Location = new System.Drawing.Point(8, 32);
            this.nNumericUpDown2.Name = "nNumericUpDown2";
            this.nNumericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.nNumericUpDown2.TabIndex = 1;
            // 
            // nNumericUpDown3
            // 
            this.nNumericUpDown3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown3.Location = new System.Drawing.Point(8, 56);
            this.nNumericUpDown3.Name = "nNumericUpDown3";
            this.nNumericUpDown3.Size = new System.Drawing.Size(120, 26);
            this.nNumericUpDown3.TabIndex = 2;
            // 
            // nNumericUpDown4
            // 
            this.nNumericUpDown4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown4.Location = new System.Drawing.Point(8, 88);
            this.nNumericUpDown4.Name = "nNumericUpDown4";
            this.nNumericUpDown4.Size = new System.Drawing.Size(120, 30);
            this.nNumericUpDown4.TabIndex = 3;
            // 
            // nNumericUpDown5
            // 
            this.nNumericUpDown5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown5.Location = new System.Drawing.Point(8, 128);
            this.nNumericUpDown5.Name = "nNumericUpDown5";
            this.nNumericUpDown5.Size = new System.Drawing.Size(120, 44);
            this.nNumericUpDown5.TabIndex = 4;
            // 
            // nNumericUpDown6
            // 
            this.nNumericUpDown6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown6.Location = new System.Drawing.Point(136, 128);
            this.nNumericUpDown6.Name = "nNumericUpDown6";
            this.nNumericUpDown6.Size = new System.Drawing.Size(120, 44);
            this.nNumericUpDown6.TabIndex = 9;
            this.nNumericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nNumericUpDown6.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown7
            // 
            this.nNumericUpDown7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown7.Location = new System.Drawing.Point(136, 88);
            this.nNumericUpDown7.Name = "nNumericUpDown7";
            this.nNumericUpDown7.Size = new System.Drawing.Size(120, 30);
            this.nNumericUpDown7.TabIndex = 8;
            this.nNumericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nNumericUpDown7.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown8
            // 
            this.nNumericUpDown8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown8.Location = new System.Drawing.Point(136, 56);
            this.nNumericUpDown8.Name = "nNumericUpDown8";
            this.nNumericUpDown8.Size = new System.Drawing.Size(120, 26);
            this.nNumericUpDown8.TabIndex = 7;
            this.nNumericUpDown8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nNumericUpDown8.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown9
            // 
            this.nNumericUpDown9.Location = new System.Drawing.Point(136, 32);
            this.nNumericUpDown9.Name = "nNumericUpDown9";
            this.nNumericUpDown9.Size = new System.Drawing.Size(120, 20);
            this.nNumericUpDown9.TabIndex = 6;
            this.nNumericUpDown9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nNumericUpDown9.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown10
            // 
            this.nNumericUpDown10.Location = new System.Drawing.Point(136, 8);
            this.nNumericUpDown10.Name = "nNumericUpDown10";
            this.nNumericUpDown10.Size = new System.Drawing.Size(120, 20);
            this.nNumericUpDown10.TabIndex = 5;
            this.nNumericUpDown10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nNumericUpDown10.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown13
            // 
            this.nNumericUpDown13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown13.Location = new System.Drawing.Point(264, 56);
            this.nNumericUpDown13.Name = "nNumericUpDown13";
            this.nNumericUpDown13.Size = new System.Drawing.Size(120, 26);
            this.nNumericUpDown13.TabIndex = 12;
            this.nNumericUpDown13.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown11
            // 
            this.nNumericUpDown11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown11.Location = new System.Drawing.Point(264, 88);
            this.nNumericUpDown11.Name = "nNumericUpDown11";
            this.nNumericUpDown11.Size = new System.Drawing.Size(120, 30);
            this.nNumericUpDown11.TabIndex = 13;
            this.nNumericUpDown11.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown12
            // 
            this.nNumericUpDown12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nNumericUpDown12.Location = new System.Drawing.Point(264, 128);
            this.nNumericUpDown12.Name = "nNumericUpDown12";
            this.nNumericUpDown12.Size = new System.Drawing.Size(120, 44);
            this.nNumericUpDown12.TabIndex = 14;
            this.nNumericUpDown12.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown14
            // 
            this.nNumericUpDown14.Location = new System.Drawing.Point(264, 32);
            this.nNumericUpDown14.Name = "nNumericUpDown14";
            this.nNumericUpDown14.Size = new System.Drawing.Size(120, 20);
            this.nNumericUpDown14.TabIndex = 18;
            this.nNumericUpDown14.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nNumericUpDown15
            // 
            this.nNumericUpDown15.Location = new System.Drawing.Point(264, 8);
            this.nNumericUpDown15.Name = "nNumericUpDown15";
            this.nNumericUpDown15.Size = new System.Drawing.Size(120, 20);
            this.nNumericUpDown15.TabIndex = 17;
            this.nNumericUpDown15.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nCheckBox1
            // 
            this.nCheckBox1.ButtonProperties.BorderOffset = 2;
            this.nCheckBox1.Checked = true;
            this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nCheckBox1.Location = new System.Drawing.Point(8, 184);
            this.nCheckBox1.Name = "nCheckBox1";
            this.nCheckBox1.Size = new System.Drawing.Size(80, 24);
            this.nCheckBox1.TabIndex = 19;
            this.nCheckBox1.Text = "&Enable";
            this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
            // 
            // m_CustomTextEdit
            // 
            this.m_CustomTextEdit.Location = new System.Drawing.Point(96, 216);
            this.m_CustomTextEdit.Name = "m_CustomTextEdit";
            this.m_CustomTextEdit.Size = new System.Drawing.Size(168, 18);
            this.m_CustomTextEdit.TabIndex = 21;
            this.m_CustomTextEdit.TextChanged += new System.EventHandler(this.m_CustomTextEdit_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Custom Text:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NNumericUpDownUC
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_CustomTextEdit);
            this.Controls.Add(this.nCheckBox1);
            this.Controls.Add(this.nNumericUpDown15);
            this.Controls.Add(this.nNumericUpDown14);
            this.Controls.Add(this.nNumericUpDown12);
            this.Controls.Add(this.nNumericUpDown11);
            this.Controls.Add(this.nNumericUpDown13);
            this.Controls.Add(this.nNumericUpDown6);
            this.Controls.Add(this.nNumericUpDown7);
            this.Controls.Add(this.nNumericUpDown8);
            this.Controls.Add(this.nNumericUpDown9);
            this.Controls.Add(this.nNumericUpDown10);
            this.Controls.Add(this.nNumericUpDown5);
            this.Controls.Add(this.nNumericUpDown4);
            this.Controls.Add(this.nNumericUpDown3);
            this.Controls.Add(this.nNumericUpDown2);
            this.Controls.Add(this.nNumericUpDown1);
            this.Name = "NNumericUpDownUC";
            this.Size = new System.Drawing.Size(392, 296);
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown15)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown6;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown7;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown8;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown9;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown10;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown13;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown11;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown12;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown14;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown15;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NTextBox m_CustomTextEdit;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown5;

		#endregion
	}
}
