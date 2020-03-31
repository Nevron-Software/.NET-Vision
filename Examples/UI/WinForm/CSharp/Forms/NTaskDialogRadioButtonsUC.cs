using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NQ1TaskDialogFeaturesUC.
	/// </summary>
	public class NTaskDialogRadioButtonsUC : NExampleUserControl
	{
		#region Constructor

		public NTaskDialogRadioButtonsUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

				foreach(NRadioBoxElement element in m_arrButtons)
				{
					element.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize ();

			m_arrButtons = new ArrayList();

			//add 5 buttons by default
			for(int i = 0; i < 5; i++)
			{
				addBtn_Click(null, null);
			}
		}


		#endregion

		#region Event Handlers

		private void addBtn_Click(object sender, System.EventArgs e)
		{
			NRadioBoxElement box = new NRadioBoxElement();
			m_arrButtons.Add(box);

			box.Text = "Test <b>Radio</b> Button " + m_arrButtons.Count;

			NListBoxItem item = new NListBoxItem();
			item.Tag = box;
			item.Text = "Button " + m_arrButtons.Count;

			buttonsList.Items.Add(item);

			buttonProperties.SelectedObject = box;
		}
		private void removeBtn_Click(object sender, System.EventArgs e)
		{
			NRadioBoxElement box = buttonsList.SelectedItemTag as NRadioBoxElement;
			if(box == null)
			{
				return;
			}

			m_arrButtons.Remove(box);
			buttonsList.Items.RemoveAt(buttonsList.SelectedIndex);
			buttonProperties.SelectedObject = null;
		}
		private void buttonsList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NRadioBoxElement box = buttonsList.SelectedItemTag as NRadioBoxElement;
			buttonProperties.SelectedObject = box;
		}
		private void showBtn_Click(object sender, System.EventArgs e)
		{
			NTaskDialog dlg = new NTaskDialog();
			dlg.Title = "Q2 2007 Radio Buttons Support";
			dlg.Content.Text = "<font size='12' face='Trebuchet MS'>Task Dialog <b>Radio Buttons</b> example</font>";
			dlg.Content.Image = NSystemImages.Information;
			dlg.Content.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			dlg.Content.ImageSize = new NSize(32, 32);
			dlg.PreferredWidth = 300;

			if(m_arrButtons.Count > 0)
			{
				NRadioBoxElement[] buttons = new NRadioBoxElement[m_arrButtons.Count];
				m_arrButtons.CopyTo(buttons);
				dlg.RadioButtons = buttons;
			}

			dlg.Show();

			NRadioBoxElement box = dlg.CheckedRadioButton;
			if(box != null)
			{
				checkedButtonLabel.Text = box.Text;
			}
			else
			{
				checkedButtonLabel.Text = "None";
			}

			dlg.RadioButtons = null;
			dlg.Dispose();
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonProperties = new System.Windows.Forms.PropertyGrid();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.addBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.buttonsList = new Nevron.UI.WinForm.Controls.NListBox();
			this.removeBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.showBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.checkedButtonLabel = new System.Windows.Forms.Label();
			this.nGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonProperties
			// 
			this.buttonProperties.HelpVisible = false;
			this.buttonProperties.LargeButtons = false;
			this.buttonProperties.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.buttonProperties.Location = new System.Drawing.Point(256, 24);
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(232, 248);
			this.buttonProperties.TabIndex = 0;
			this.buttonProperties.Text = "propertyGrid1";
			this.buttonProperties.ToolbarVisible = false;
			this.buttonProperties.ViewBackColor = System.Drawing.SystemColors.Window;
			this.buttonProperties.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.removeBtn);
			this.nGroupBox1.Controls.Add(this.buttonsList);
			this.nGroupBox1.Controls.Add(this.addBtn);
			this.nGroupBox1.Controls.Add(this.buttonProperties);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(504, 288);
			this.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox1.TabIndex = 1;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Radio Buttons";
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(8, 24);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(112, 24);
			this.addBtn.TabIndex = 1;
			this.addBtn.Text = "Add Button";
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// buttonsList
			// 
			this.buttonsList.IntegralHeight = false;
			this.buttonsList.Location = new System.Drawing.Point(8, 56);
			this.buttonsList.Name = "buttonsList";
			this.buttonsList.Size = new System.Drawing.Size(232, 216);
			this.buttonsList.TabIndex = 2;
			this.buttonsList.SelectedIndexChanged += new System.EventHandler(this.buttonsList_SelectedIndexChanged);
			// 
			// removeBtn
			// 
			this.removeBtn.Location = new System.Drawing.Point(128, 24);
			this.removeBtn.Name = "removeBtn";
			this.removeBtn.Size = new System.Drawing.Size(112, 24);
			this.removeBtn.TabIndex = 3;
			this.removeBtn.Text = "Remove Button";
			this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
			// 
			// showBtn
			// 
			this.showBtn.Location = new System.Drawing.Point(8, 304);
			this.showBtn.Name = "showBtn";
			this.showBtn.Size = new System.Drawing.Size(144, 24);
			this.showBtn.TabIndex = 2;
			this.showBtn.Text = "Show Dialog..";
			this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 336);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Checked Radio Button:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkedButtonLabel
			// 
			this.checkedButtonLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.checkedButtonLabel.Location = new System.Drawing.Point(8, 360);
			this.checkedButtonLabel.Name = "checkedButtonLabel";
			this.checkedButtonLabel.Size = new System.Drawing.Size(504, 23);
			this.checkedButtonLabel.TabIndex = 4;
			// 
			// NQ1TaskDialogFeaturesUC
			// 
			this.Controls.Add(this.checkedButtonLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.showBtn);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NQ1TaskDialogFeaturesUC";
			this.Size = new System.Drawing.Size(520, 392);
			this.nGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal ArrayList m_arrButtons;

		private System.Windows.Forms.PropertyGrid buttonProperties;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NButton addBtn;
		private Nevron.UI.WinForm.Controls.NListBox buttonsList;
		private Nevron.UI.WinForm.Controls.NButton removeBtn;
		private Nevron.UI.WinForm.Controls.NButton showBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label checkedButtonLabel;
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
