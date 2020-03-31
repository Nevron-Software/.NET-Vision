using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Interop.Win32;
using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for DateTimePickerUC.
	/// </summary>
	public class NDateTimePickerUC : NExampleUserControl
	{
		#region Constructor

		public NDateTimePickerUC(MainForm f) : base(f)
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

		private void borderBtn_Click(object sender, System.EventArgs e)
		{
			this.dateTimePicker1.Border.ShowEditor();
		}
        private void nCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.ShowUpDown = nCheckBox1.Checked;
        }
        private void nCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.EnableSkinning = nCheckBox2.Checked;
            this.borderBtn.Enabled = (nCheckBox2.Checked == false);
        }

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.dateTimePicker1 = new Nevron.UI.WinForm.Controls.NDateTimePicker();
            this.borderBtn = new Nevron.UI.WinForm.Controls.NButton();
            this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dateTimePicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // borderBtn
            // 
            this.borderBtn.Enabled = false;
            this.borderBtn.Location = new System.Drawing.Point(8, 81);
            this.borderBtn.Name = "borderBtn";
            this.borderBtn.Size = new System.Drawing.Size(80, 24);
            this.borderBtn.TabIndex = 1;
            this.borderBtn.Text = "Border...";
            this.borderBtn.Click += new System.EventHandler(this.borderBtn_Click);
            // 
            // nCheckBox1
            // 
#if VS2005
            this.nCheckBox1.AutoSize = true;
#endif
            this.nCheckBox1.ButtonProperties.BorderOffset = 2;
            this.nCheckBox1.Location = new System.Drawing.Point(8, 35);
            this.nCheckBox1.Name = "nCheckBox1";
            this.nCheckBox1.Size = new System.Drawing.Size(98, 17);
            this.nCheckBox1.TabIndex = 2;
            this.nCheckBox1.Text = "Show UpDown";
            this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
            // 
            // nCheckBox2
            // 
#if VS2005
            this.nCheckBox1.AutoSize = true;
#endif
            this.nCheckBox2.ButtonProperties.BorderOffset = 2;
            this.nCheckBox2.Checked = true;
            this.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nCheckBox2.Location = new System.Drawing.Point(8, 58);
            this.nCheckBox2.Name = "nCheckBox2";
            this.nCheckBox2.Size = new System.Drawing.Size(103, 17);
            this.nCheckBox2.TabIndex = 3;
            this.nCheckBox2.Text = "Enable Skinning";
            this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
            // 
            // NDateTimePickerUC
            // 
            this.Controls.Add(this.nCheckBox2);
            this.Controls.Add(this.nCheckBox1);
            this.Controls.Add(this.borderBtn);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "NDateTimePickerUC";
            this.Size = new System.Drawing.Size(336, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton borderBtn;
        private NCheckBox nCheckBox1;
        private NCheckBox nCheckBox2;

		private NDateTimePicker dateTimePicker1;

		#endregion
	}
}
