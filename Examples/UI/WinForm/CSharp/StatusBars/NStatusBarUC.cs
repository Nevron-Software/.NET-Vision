using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	public class NStatusBarUC : NExampleUserControl
	{
		#region Constructor

		public NStatusBarUC(MainForm f) : base(f)
		{
			m_StatusBar = new NStatusBar();
			m_StatusBar.ImageList = MainForm.TestImages;

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

			Dock = DockStyle.Fill;

			m_SeparatorsCheck.Checked = m_StatusBar.Separators;

			Controls.Add(m_StatusBar);

			m_ControlCombo.Items.Add("(none)");
			m_ControlCombo.Items.Add("TextBox");
			m_ControlCombo.Items.Add("ComboBox");
			m_ControlCombo.Items.Add("Button");
			m_ControlCombo.Items.Add("NumericUpDown");
			m_ControlCombo.Items.Add("CheckBox");
			m_ControlCombo.Items.Add("RadioButton");
			m_ControlCombo.Items.Add("ProgressBar");

			m_BackColorButton.Color = m_StatusBar.BackColor;
			m_ForeColorButton.Color = m_StatusBar.Palette.ControlText;

			//populate autosize combobox
			m_AutoSizeCombo.FillFromEnum(typeof(StatusBarPanelAutoSize), false);
			m_AutoSizeCombo.SelectedIndex = 0;

			//populate alignment combobox
			m_AlignmentCombo.FillFromEnum(typeof(HorizontalAlignment), false);
			m_AlignmentCombo.SelectedIndex = 0;

			//populate borderstyle combobox
			m_BorderStyleCombo.FillFromEnum(typeof(BorderStyle3D), false);
			m_BorderStyleCombo.SelectedItem = BorderStyle3D.Flat;

			//populate gripperstyle combobox
			m_GripperStyleCombo.FillFromEnum(typeof(GripperStyle), false);
			m_GripperStyleCombo.SelectedItem = m_StatusBar.GripperStyle;

			//populate imageindex combobox
			NListBoxItem item;

			item = new NListBoxItem(-1, "(none)", false);
			m_ImageIndexCombo.Items.Add(item);
			m_ImageIndexCombo.ImageList = MainForm.TestImages;

			for(int i = 0; i < MainForm.TestImages.Images.Count; i++)
			{
				item = new NListBoxItem(i, i.ToString(), false);
				m_ImageIndexCombo.Items.Add(item);
			}
		}

		internal Control GetControl()
		{
			switch(m_ControlCombo.SelectedIndex)
			{
				case 0:
					return null;
				case 1:
					NTextBox tb = new NTextBox();
					tb.Text = "NTextBox";
					return tb;
				case 2:
					NComboBox cb = new NComboBox();
					cb.ImageList = MainForm.TestImages;
					for(int i = 0; i < 20; i++)
						cb.Items.Add(new NListBoxItem(i, "Item "+(i+1), false));
					return cb;
				case 3:
					NButton b = new NButton();
					b.Text = "Test Button";
					return b;
				case 4:
					NNumericUpDown ud = new NNumericUpDown();
					return ud;
				case 5:
					NCheckBox chb = new NCheckBox();
					chb.Text = "NCheckBox";
					chb.TransparentBackground = true;
					return chb;
				case 6:
					NRadioButton rb = new NRadioButton();
					rb.Text = "NRadioButton";
					rb.TransparentBackground = true;
					return rb;
				case 7:
					NProgressBar bar = new NProgressBar();
					bar.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
					bar.Properties.Value = 60;
					return bar;
			}

			return null;
		}


		#endregion

		#region Event Handlers

		private void m_AddButton_Click(object sender, System.EventArgs e)
		{
			NStatusBarPanel panel = new NStatusBarPanel(m_PanelTextEdit.Text, m_ImageIndexCombo.SelectedIndex - 1);

			panel.AutoSize = (StatusBarPanelAutoSize)m_AutoSizeCombo.SelectedItem;
			panel.Alignment = (HorizontalAlignment)m_AlignmentCombo.SelectedItem;
			panel.BorderStyle = (BorderStyle3D)m_BorderStyleCombo.SelectedItem;

			if(m_BackColorButton.Enabled)
				panel.BackColor = m_BackColorButton.Color;
			if(m_ForeColorButton.Enabled)
				panel.ForeColor = m_ForeColorButton.Color;

			Control c = GetControl();
			if(c is NProgressBar)
				panel.Padding = new NPadding(2);

			panel.Control = c;

			m_StatusBar.Panels.Add(panel);
		}
		private void m_RemoveButton_Click(object sender, System.EventArgs e)
		{
			m_StatusBar.Panels.Clear();
		}
		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_StatusBar.SizingGrip = nCheckBox1.Checked;
		}

		private void m_UseDefBackColor_CheckedChanged(object sender, System.EventArgs e)
		{
			m_BackColorButton.Enabled = !m_UseDefBackColor.Checked;
		}
		private void m_UseDefForeColor_CheckedChanged(object sender, System.EventArgs e)
		{
			m_ForeColorButton.Enabled = !m_UseDefForeColor.Checked;
		}

		private void m_SeparatorsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_StatusBar.Separators = m_SeparatorsCheck.Checked;
		}

		private void m_GripperStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_StatusBar.GripperStyle = (GripperStyle)m_GripperStyleCombo.SelectedItem;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_AddButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_PanelTextEdit = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_AutoSizeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_AlignmentCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_BorderStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_ImageIndexCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_RemoveButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ControlCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_BackColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.m_ForeColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.m_UseDefBackColor = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_UseDefForeColor = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_SeparatorsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_GripperStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_AddButton
			// 
			this.m_AddButton.Location = new System.Drawing.Point(216, 320);
			this.m_AddButton.Name = "m_AddButton";
			this.m_AddButton.Size = new System.Drawing.Size(72, 23);
			this.m_AddButton.TabIndex = 0;
			this.m_AddButton.Text = "Add &Panel";
			this.m_AddButton.Click += new System.EventHandler(this.m_AddButton_Click);
			// 
			// m_PanelTextEdit
			// 
			this.m_PanelTextEdit.Location = new System.Drawing.Point(104, 8);
			this.m_PanelTextEdit.Name = "m_PanelTextEdit";
			this.m_PanelTextEdit.Size = new System.Drawing.Size(176, 18);
			this.m_PanelTextEdit.TabIndex = 1;
			this.m_PanelTextEdit.Text = "Example";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Panel Text:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "AutoSize:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_AutoSizeCombo
			// 
			this.m_AutoSizeCombo.Location = new System.Drawing.Point(104, 40);
			this.m_AutoSizeCombo.Name = "m_AutoSizeCombo";
			this.m_AutoSizeCombo.Size = new System.Drawing.Size(152, 22);
			this.m_AutoSizeCombo.TabIndex = 4;
			this.m_AutoSizeCombo.Text = "nComboBox1";
			// 
			// m_AlignmentCombo
			// 
			this.m_AlignmentCombo.Location = new System.Drawing.Point(104, 72);
			this.m_AlignmentCombo.Name = "m_AlignmentCombo";
			this.m_AlignmentCombo.Size = new System.Drawing.Size(152, 22);
			this.m_AlignmentCombo.TabIndex = 6;
			this.m_AlignmentCombo.Text = "nComboBox1";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Alignment:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_BorderStyleCombo
			// 
			this.m_BorderStyleCombo.Location = new System.Drawing.Point(104, 104);
			this.m_BorderStyleCombo.Name = "m_BorderStyleCombo";
			this.m_BorderStyleCombo.Size = new System.Drawing.Size(152, 22);
			this.m_BorderStyleCombo.TabIndex = 8;
			this.m_BorderStyleCombo.Text = "nComboBox1";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Border Style:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_ImageIndexCombo
			// 
			this.m_ImageIndexCombo.Location = new System.Drawing.Point(104, 136);
			this.m_ImageIndexCombo.Name = "m_ImageIndexCombo";
			this.m_ImageIndexCombo.Size = new System.Drawing.Size(152, 22);
			this.m_ImageIndexCombo.TabIndex = 10;
			this.m_ImageIndexCombo.Text = "nComboBox1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "Image Index:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_RemoveButton
			// 
			this.m_RemoveButton.Location = new System.Drawing.Point(296, 320);
			this.m_RemoveButton.Name = "m_RemoveButton";
			this.m_RemoveButton.Size = new System.Drawing.Size(72, 23);
			this.m_RemoveButton.TabIndex = 11;
			this.m_RemoveButton.Text = "Remove &All";
			this.m_RemoveButton.Click += new System.EventHandler(this.m_RemoveButton_Click);
			// 
			// m_ControlCombo
			// 
			this.m_ControlCombo.Location = new System.Drawing.Point(104, 168);
			this.m_ControlCombo.Name = "m_ControlCombo";
			this.m_ControlCombo.Size = new System.Drawing.Size(152, 22);
			this.m_ControlCombo.TabIndex = 13;
			this.m_ControlCombo.Text = "nComboBox1";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 12;
			this.label6.Text = "Control:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(104, 296);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.TabIndex = 14;
			this.nCheckBox1.Text = "Sizing Grip";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// m_BackColorButton
			// 
			this.m_BackColorButton.ArrowClickOptions = false;
			this.m_BackColorButton.Enabled = false;
			this.m_BackColorButton.Location = new System.Drawing.Point(104, 200);
			this.m_BackColorButton.Name = "m_BackColorButton";
			this.m_BackColorButton.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 200);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 23);
			this.label7.TabIndex = 16;
			this.label7.Text = "BackColor:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 232);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 23);
			this.label8.TabIndex = 18;
			this.label8.Text = "ForeColor:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_ForeColorButton
			// 
			this.m_ForeColorButton.ArrowClickOptions = false;
			this.m_ForeColorButton.Enabled = false;
			this.m_ForeColorButton.Location = new System.Drawing.Point(104, 232);
			this.m_ForeColorButton.Name = "m_ForeColorButton";
			this.m_ForeColorButton.TabIndex = 17;
			// 
			// m_UseDefBackColor
			// 
			this.m_UseDefBackColor.Checked = true;
			this.m_UseDefBackColor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_UseDefBackColor.Location = new System.Drawing.Point(184, 200);
			this.m_UseDefBackColor.Name = "m_UseDefBackColor";
			this.m_UseDefBackColor.TabIndex = 19;
			this.m_UseDefBackColor.Text = "Use Default";
			this.m_UseDefBackColor.CheckedChanged += new System.EventHandler(this.m_UseDefBackColor_CheckedChanged);
			// 
			// m_UseDefForeColor
			// 
			this.m_UseDefForeColor.Checked = true;
			this.m_UseDefForeColor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_UseDefForeColor.Location = new System.Drawing.Point(184, 232);
			this.m_UseDefForeColor.Name = "m_UseDefForeColor";
			this.m_UseDefForeColor.TabIndex = 20;
			this.m_UseDefForeColor.Text = "Use Default";
			this.m_UseDefForeColor.CheckedChanged += new System.EventHandler(this.m_UseDefForeColor_CheckedChanged);
			// 
			// m_SeparatorsCheck
			// 
			this.m_SeparatorsCheck.Checked = true;
			this.m_SeparatorsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_SeparatorsCheck.Location = new System.Drawing.Point(104, 320);
			this.m_SeparatorsCheck.Name = "m_SeparatorsCheck";
			this.m_SeparatorsCheck.TabIndex = 21;
			this.m_SeparatorsCheck.Text = "Separators";
			this.m_SeparatorsCheck.CheckedChanged += new System.EventHandler(this.m_SeparatorsCheck_CheckedChanged);
			// 
			// m_GripperStyleCombo
			// 
			this.m_GripperStyleCombo.Location = new System.Drawing.Point(104, 264);
			this.m_GripperStyleCombo.Name = "m_GripperStyleCombo";
			this.m_GripperStyleCombo.Size = new System.Drawing.Size(152, 22);
			this.m_GripperStyleCombo.TabIndex = 25;
			this.m_GripperStyleCombo.Text = "nComboBox1";
			this.m_GripperStyleCombo.SelectedIndexChanged += new System.EventHandler(this.m_GripperStyleCombo_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 264);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 23);
			this.label9.TabIndex = 24;
			this.label9.Text = "Gripper Style:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NStatusBarUC
			// 
			this.Controls.Add(this.m_GripperStyleCombo);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.m_SeparatorsCheck);
			this.Controls.Add(this.m_UseDefForeColor);
			this.Controls.Add(this.m_UseDefBackColor);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.m_ForeColorButton);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.m_BackColorButton);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.m_ControlCombo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.m_RemoveButton);
			this.Controls.Add(this.m_ImageIndexCombo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_BorderStyleCombo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_AlignmentCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_AutoSizeCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_PanelTextEdit);
			this.Controls.Add(this.m_AddButton);
			this.Name = "NStatusBarUC";
			this.Size = new System.Drawing.Size(384, 352);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		internal NStatusBar m_StatusBar;

		private Nevron.UI.WinForm.Controls.NButton m_AddButton;
		private Nevron.UI.WinForm.Controls.NTextBox m_PanelTextEdit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox m_AutoSizeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox m_AlignmentCombo;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox m_BorderStyleCombo;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox m_ImageIndexCombo;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox m_ControlCombo;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NColorButton m_BackColorButton;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private Nevron.UI.WinForm.Controls.NColorButton m_ForeColorButton;
		private Nevron.UI.WinForm.Controls.NCheckBox m_UseDefBackColor;
		private Nevron.UI.WinForm.Controls.NCheckBox m_UseDefForeColor;
		private Nevron.UI.WinForm.Controls.NCheckBox m_SeparatorsCheck;
		private Nevron.UI.WinForm.Controls.NComboBox m_GripperStyleCombo;
		private System.Windows.Forms.Label label9;
		private Nevron.UI.WinForm.Controls.NButton m_RemoveButton;

		#endregion
	}
}
