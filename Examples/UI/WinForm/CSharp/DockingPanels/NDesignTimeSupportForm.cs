using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NDesignTimeSupportForm.
	/// </summary>
	public class NDesignTimeSupportForm : System.Windows.Forms.Form
	{
		private Nevron.UI.WinForm.Docking.NDockManager nDockManager1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel1;
		private Nevron.UI.WinForm.Controls.NColorPool nColorPool1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel2;
		private System.Windows.Forms.ImageList imageList1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel3;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel4;
		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private Nevron.UI.WinForm.Controls.NColorBar nColorBar1;
		private Nevron.UI.WinForm.Controls.NComboBox nComboBox1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel5;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel6;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel7;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel8;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel9;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton1;
		private Nevron.UI.WinForm.Controls.NWaitingBar nWaitingBar1;
		private Nevron.UI.WinForm.Controls.NProgressBar nProgressBar1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private Nevron.UI.WinForm.Controls.NCommandBarsManager nCommandBarsManager1;
		private Nevron.UI.WinForm.Controls.NMenuBar nMenuBar1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand3;
		private Nevron.UI.WinForm.Controls.NCommand nCommand4;
		private System.ComponentModel.IContainer components;

		public NDesignTimeSupportForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			nDockManager1.RootContainer.BringToFront();

			//add some documents to the framework
			NUIDocument doc;

			for(int i = 1; i < 5; i++)
			{
				doc = new NUIDocument("Nevron Document " + i.ToString(), 0);
				doc.Client = GetTextBox();
				nDockManager1.DocumentManager.AddDocument(doc);
			}

			nDockManager1.Palette.Copy(NUIManager.Palette);
			nCommandBarsManager1.Palette.Copy(NUIManager.Palette);

			nComboBox1.Items.Add("NlistBoxItem1");
			nComboBox1.Items.Add("NlistBoxItem2");
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
				if(nDockManager1 != null)
				{
					nDockManager1.Dispose();
				}

			}
			base.Dispose( disposing );
		}

		TextBox GetTextBox()
		{
			TextBox tb = new TextBox();
			tb.Multiline = true;
			tb.Dock = DockStyle.Fill;

			return tb;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone0 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockZone nDockZone1 = new Nevron.UI.WinForm.Docking.NDockZone();
			Nevron.UI.WinForm.Docking.NDockZone nDockZone2 = new Nevron.UI.WinForm.Docking.NDockZone();
			Nevron.UI.WinForm.Docking.NDockZone nDockZone3 = new Nevron.UI.WinForm.Docking.NDockZone();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone4 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone6 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone7 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone8 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NDesignTimeSupportForm));
			this.nDockManager1 = new Nevron.UI.WinForm.Docking.NDockManager();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.nDockingPanel1 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nColorPool1 = new Nevron.UI.WinForm.Controls.NColorPool();
			this.nDockingPanel2 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nComboBox1 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nDockingPanel3 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nDockingPanel4 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nColorBar1 = new Nevron.UI.WinForm.Controls.NColorBar();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.nDockingPanel5 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nOptionButton1 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nDockingPanel6 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.nDockingPanel7 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nDockingPanel8 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nProgressBar1 = new Nevron.UI.WinForm.Controls.NProgressBar();
			this.nDockingPanel9 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nWaitingBar1 = new Nevron.UI.WinForm.Controls.NWaitingBar();
			this.nRadioButton1 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nCommandBarsManager1 = new Nevron.UI.WinForm.Controls.NCommandBarsManager(this.components);
			this.nMenuBar1 = new Nevron.UI.WinForm.Controls.NMenuBar();
			this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand4 = new Nevron.UI.WinForm.Controls.NCommand();
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).BeginInit();
			this.nDockingPanel1.SuspendLayout();
			this.nDockingPanel2.SuspendLayout();
			this.nDockingPanel4.SuspendLayout();
			this.nDockingPanel5.SuspendLayout();
			this.nDockingPanel6.SuspendLayout();
			this.nDockingPanel8.SuspendLayout();
			this.nDockingPanel9.SuspendLayout();
			// 
			// nDockManager1
			// 
			this.nDockManager1.DocumentStyle.ImageList = this.imageList1;
			this.nDockManager1.Form = this;
			this.nDockManager1.ImageList = this.imageList1;
			this.nDockManager1.RootContainerZIndex = 4;
			//  
			// Root Zone
			//  
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0);
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1);
			this.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Vertical;
			//  
			// nDockZone0
			//  
			nDockZone0.AddChild(this.nDockingPanel7);
			nDockZone0.AddChild(this.nDockingPanel9);
			nDockZone0.AddChild(this.nDockingPanel8);
			nDockZone0.Name = "nDockZone0";
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone0.Index = 0;
			nDockZone0.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 111);
			//  
			// nDockZone1
			//  
			nDockZone1.AddChild(nDockZone2);
			nDockZone1.AddChild(nDockZone8);
			nDockZone1.Name = "nDockZone1";
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone1.Index = 1;
			nDockZone1.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 284);
			//  
			// nDockZone2
			//  
			nDockZone2.AddChild(nDockZone3);
			nDockZone2.AddChild(nDockZone7);
			nDockZone2.Name = "nDockZone2";
			nDockZone2.Orientation = System.Windows.Forms.Orientation.Vertical;
			nDockZone2.Index = 0;
			nDockZone2.SizeInfo.PrefferedSize = new System.Drawing.Size(608, 200);
			//  
			// nDockZone3
			//  
			nDockZone3.AddChild(nDockZone4);
			nDockZone3.AddChild(this.nDockManager1.DocumentManager.DocumentViewHost);
			nDockZone3.AddChild(nDockZone6);
			nDockZone3.Name = "nDockZone3";
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone3.Index = 0;
			nDockZone3.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 298);
			//  
			// nDockZone4
			//  
			nDockZone4.AddChild(this.nDockingPanel6);
			nDockZone4.Name = "nDockZone4";
			nDockZone4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone4.Index = 0;
			nDockZone4.SizeInfo.PrefferedSize = new System.Drawing.Size(250, 200);
			//  
			// nDockZone6
			//  
			nDockZone6.AddChild(this.nDockingPanel1);
			nDockZone6.AddChild(this.nDockingPanel4);
			nDockZone6.Name = "nDockZone6";
			nDockZone6.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone6.Index = 2;
			nDockZone6.SizeInfo.PrefferedSize = new System.Drawing.Size(169, 200);
			//  
			// nDockZone7
			//  
			nDockZone7.AddChild(this.nDockingPanel2);
			nDockZone7.AddChild(this.nDockingPanel3);
			nDockZone7.Name = "nDockZone7";
			nDockZone7.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone7.Index = 1;
			nDockZone7.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 132);
			//  
			// nDockZone8
			//  
			nDockZone8.AddChild(this.nDockingPanel5);
			nDockZone8.Name = "nDockZone8";
			nDockZone8.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone8.Index = 1;
			nDockZone8.SizeInfo.PrefferedSize = new System.Drawing.Size(153, 200);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// nDockingPanel1
			// 
			this.nDockingPanel1.Controls.Add(this.nColorPool1);
			this.nDockingPanel1.Key = "Panel 1";
			this.nDockingPanel1.Name = "nDockingPanel1";
			this.nDockingPanel1.SizeInfo.PrefferedSize = new System.Drawing.Size(169, 200);
			this.nDockingPanel1.TabIndex = 1;
			this.nDockingPanel1.TabInfo.ImageIndex = 4;
			// 
			// nColorPool1
			// 
			this.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nColorPool1.Color = System.Drawing.Color.Empty;
			this.nColorPool1.Hue = 0F;
			this.nColorPool1.Location = new System.Drawing.Point(24, 40);
			this.nColorPool1.Luminance = 0.5F;
			this.nColorPool1.Name = "nColorPool1";
			this.nColorPool1.Saturation = 0F;
			this.nColorPool1.Size = new System.Drawing.Size(136, 104);
			this.nColorPool1.TabIndex = 0;
			// 
			// nDockingPanel2
			// 
			this.nDockingPanel2.Controls.Add(this.nComboBox1);
			this.nDockingPanel2.Key = "Panel 2";
			this.nDockingPanel2.Name = "nDockingPanel2";
			this.nDockingPanel2.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 132);
			this.nDockingPanel2.TabIndex = 1;
			this.nDockingPanel2.TabInfo.ImageIndex = 0;
			// 
			// nComboBox1
			// 
			this.nComboBox1.Location = new System.Drawing.Point(16, 16);
			this.nComboBox1.Name = "nComboBox1";
			this.nComboBox1.Size = new System.Drawing.Size(152, 22);
			this.nComboBox1.TabIndex = 0;
			this.nComboBox1.Text = "nComboBox1";
			// 
			// nDockingPanel3
			// 
			this.nDockingPanel3.Key = "Panel 3";
			this.nDockingPanel3.Name = "nDockingPanel3";
			this.nDockingPanel3.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 132);
			this.nDockingPanel3.TabIndex = 2;
			this.nDockingPanel3.TabInfo.ImageIndex = 1;
			// 
			// nDockingPanel4
			// 
			this.nDockingPanel4.Controls.Add(this.nColorBar1);
			this.nDockingPanel4.Controls.Add(this.nButton1);
			this.nDockingPanel4.Key = "Panel 4";
			this.nDockingPanel4.Name = "nDockingPanel4";
			this.nDockingPanel4.SizeInfo.PrefferedSize = new System.Drawing.Size(169, 200);
			this.nDockingPanel4.TabIndex = 2;
			this.nDockingPanel4.TabInfo.ImageIndex = 2;
			// 
			// nColorBar1
			// 
			this.nColorBar1.Location = new System.Drawing.Point(16, 48);
			this.nColorBar1.Name = "nColorBar1";
			this.nColorBar1.Size = new System.Drawing.Size(128, 25);
			this.nColorBar1.TabIndex = 1;
			this.nColorBar1.Text = "nColorBar1";
			this.nColorBar1.Value = 125;
			// 
			// nButton1
			// 
			this.nButton1.Location = new System.Drawing.Point(16, 16);
			this.nButton1.Name = "nButton1";
			this.nButton1.TabIndex = 0;
			this.nButton1.Text = "nButton1";
			// 
			// nDockingPanel5
			// 
			this.nDockingPanel5.Controls.Add(this.nGroupBox1);
			this.nDockingPanel5.Controls.Add(this.nOptionButton1);
			this.nDockingPanel5.Key = "Panel 5";
			this.nDockingPanel5.Name = "nDockingPanel5";
			this.nDockingPanel5.SizeInfo.PrefferedSize = new System.Drawing.Size(153, 200);
			this.nDockingPanel5.TabIndex = 1;
			this.nDockingPanel5.TabInfo.ImageIndex = 5;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(16, 24);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(112, 80);
			this.nGroupBox1.TabIndex = 0;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "nGroupBox1";
			// 
			// nOptionButton1
			// 
			this.nOptionButton1.ArrowWidth = 14;
			this.nOptionButton1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																								this.nCommand1,
																								this.nCommand2});
			this.nOptionButton1.Location = new System.Drawing.Point(8, 128);
			this.nOptionButton1.Name = "nOptionButton1";
			this.nOptionButton1.Size = new System.Drawing.Size(120, 23);
			this.nOptionButton1.TabIndex = 1;
			this.nOptionButton1.Text = "nOptionButton1";
			// 
			// nDockingPanel6
			// 
			this.nDockingPanel6.Controls.Add(this.propertyGrid1);
			this.nDockingPanel6.Key = "Panel 6";
			this.nDockingPanel6.Name = "nDockingPanel6";
			this.nDockingPanel6.SizeInfo.PrefferedSize = new System.Drawing.Size(250, 200);
			this.nDockingPanel6.TabIndex = 1;
			this.nDockingPanel6.TabInfo.ImageIndex = 3;
			this.nDockingPanel6.Text = "Properties";
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.Control;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.SelectedObject = this.nDockManager1;
			this.propertyGrid1.Size = new System.Drawing.Size(250, 353);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// nDockingPanel7
			// 
			this.nDockingPanel7.Key = "Panel 7";
			this.nDockingPanel7.Name = "nDockingPanel7";
			this.nDockingPanel7.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 111);
			this.nDockingPanel7.TabIndex = 2;
			this.nDockingPanel7.TabInfo.ImageIndex = 0;
			// 
			// nDockingPanel8
			// 
			this.nDockingPanel8.Controls.Add(this.nProgressBar1);
			this.nDockingPanel8.Key = "Panel 8";
			this.nDockingPanel8.Name = "nDockingPanel8";
			this.nDockingPanel8.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 111);
			this.nDockingPanel8.TabIndex = 3;
			this.nDockingPanel8.TabInfo.ImageIndex = 1;
			// 
			// nProgressBar1
			// 
			this.nProgressBar1.Location = new System.Drawing.Point(232, 16);
			this.nProgressBar1.Name = "nProgressBar1";
			this.nProgressBar1.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
			this.nProgressBar1.Properties.Text = "";
			this.nProgressBar1.Properties.Value = 50;
			this.nProgressBar1.Size = new System.Drawing.Size(160, 16);
			this.nProgressBar1.TabIndex = 0;
			this.nProgressBar1.Text = "nProgressBar1";
			// 
			// nDockingPanel9
			// 
			this.nDockingPanel9.Controls.Add(this.nWaitingBar1);
			this.nDockingPanel9.Controls.Add(this.nRadioButton1);
			this.nDockingPanel9.Key = "Panel 9";
			this.nDockingPanel9.Name = "nDockingPanel9";
			this.nDockingPanel9.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 111);
			this.nDockingPanel9.TabIndex = 4;
			this.nDockingPanel9.TabInfo.ImageIndex = 2;
			// 
			// nWaitingBar1
			// 
			this.nWaitingBar1.Location = new System.Drawing.Point(264, 16);
			this.nWaitingBar1.Name = "nWaitingBar1";
			this.nWaitingBar1.Size = new System.Drawing.Size(240, 16);
			this.nWaitingBar1.TabIndex = 1;
			this.nWaitingBar1.Text = "nWaitingBar1";
			// 
			// nRadioButton1
			// 
			this.nRadioButton1.Location = new System.Drawing.Point(32, 16);
			this.nRadioButton1.Name = "nRadioButton1";
			this.nRadioButton1.TabIndex = 0;
			this.nRadioButton1.Text = "nRadioButton1";
			// 
			// nCommandBarsManager1
			// 
			this.nCommandBarsManager1.AllowCustomize = false;
			this.nCommandBarsManager1.ParentControl = this;
			this.nCommandBarsManager1.Toolbars.Add(this.nMenuBar1);
			// 
			// nMenuBar1
			// 
			this.nMenuBar1.AllowDelete = false;
			this.nMenuBar1.AllowHide = false;
			this.nMenuBar1.AllowRename = false;
			this.nMenuBar1.AutoDropDownDelay = false;
			this.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
			this.nMenuBar1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand3});
			this.nMenuBar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.Text;
			this.nMenuBar1.DefaultLocation = new System.Drawing.Point(0, 0);
			this.nMenuBar1.HasGripper = false;
			this.nMenuBar1.HasPendantCommand = false;
			this.nMenuBar1.Name = "nMenuBar1";
			this.nMenuBar1.PrefferedRowIndex = 0;
			this.nMenuBar1.RowIndex = 0;
			this.nMenuBar1.ShowTooltips = false;
			this.nMenuBar1.Text = "Menu Bar";
			// 
			// nCommand3
			// 
			this.nCommand3.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand4});
			this.nCommand3.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
			this.nCommand3.Properties.Text = "&File";
			// 
			// nCommand4
			// 
			this.nCommand4.Properties.Text = "E&xit";
			this.nCommand4.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.nCommand4_Click);
			// 
			// NDesignTimeSupportForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(888, 622);
			this.Name = "NDesignTimeSupportForm";
			this.Text = "Design-Time Generated Layout";
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).EndInit();
			this.nDockingPanel1.ResumeLayout(false);
			this.nDockingPanel2.ResumeLayout(false);
			this.nDockingPanel4.ResumeLayout(false);
			this.nDockingPanel5.ResumeLayout(false);
			this.nDockingPanel6.ResumeLayout(false);
			this.nDockingPanel8.ResumeLayout(false);
			this.nDockingPanel9.ResumeLayout(false);

		}
		#endregion

		private void state_ResolveDocumentClient(object sender, DocumentEventArgs e)
		{
			e.Document.Client = GetTextBox();
		}

		private void Application_Idle(object sender, EventArgs e)
		{
			ArrayList arr = nDockManager1.GetContainers(DockState.Floating);

			Application.Idle -= new EventHandler(Application_Idle);
		}

		private void nCommand4_Click(object sender, Nevron.UI.WinForm.Controls.CommandEventArgs e)
		{
			Close();
		}
	}
}
