using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NVisualEditorsUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton WizardButton;
		private Nevron.UI.WinForm.Controls.NButton ShowEditor;
		private System.ComponentModel.Container components = null;

		public NVisualEditorsUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
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


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.WizardButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowEditor = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// WizardButton
			// 
			this.WizardButton.Location = new System.Drawing.Point(8, 8);
			this.WizardButton.Name = "WizardButton";
			this.WizardButton.Size = new System.Drawing.Size(102, 25);
			this.WizardButton.TabIndex = 10;
			this.WizardButton.Text = "Chart Wizard";
			this.WizardButton.Click += new System.EventHandler(this.WizardButton_Click);
			// 
			// ShowEditor
			// 
			this.ShowEditor.Location = new System.Drawing.Point(8, 37);
			this.ShowEditor.Name = "ShowEditor";
			this.ShowEditor.Size = new System.Drawing.Size(102, 25);
			this.ShowEditor.TabIndex = 11;
			this.ShowEditor.Text = "Chart Editor";
			this.ShowEditor.Click += new System.EventHandler(this.ShowEditor_Click);
			// 
			// NVisualEditorsUC
			// 
			this.Controls.Add(this.ShowEditor);
			this.Controls.Add(this.WizardButton);
			this.Name = "NVisualEditorsUC";
			this.Size = new System.Drawing.Size(120, 492);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			NLabel title = nChartControl1.Labels.AddHeader("Visual Editors");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			
		}

		private void WizardButton_Click(object sender, System.EventArgs e)
		{
			nChartControl1.Wizard.ShowDialog();
		}

		private void ShowEditor_Click(object sender, System.EventArgs e)
		{
			nChartControl1.ShowEditor();
		}
	}
}
