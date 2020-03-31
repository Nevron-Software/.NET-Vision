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
	/// Summary description for NTaskDialogMessageBoxUC.
	/// </summary>
	public class NTaskDialogMessageBoxUC : NExampleUserControl
	{
		#region Constructor

		public NTaskDialogMessageBoxUC(MainForm f) : base(f)
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

			m_CallBack = new NTaskDialogCallBack(OnCallBack);
		}


		#endregion

		#region Implementation

		internal NTaskDialog CreateDefaultDialog()
		{
			NTaskDialog dlg = new NTaskDialog();
			dlg.Title = "Nevron User Interface Q4 2006";
			dlg.Content.Text = "Download of Nevron .NET Vision Q4 2006 is complete!";
			dlg.Content.Image = NSystemImages.Information;
			dlg.Content.ImageSize = new NSize(32, 32);

			return dlg;
		}


		#endregion

		#region Event Handlers

		private void standardMessageBoxBtn_Click(object sender, System.EventArgs e)
		{
			NTaskDialog dlg = CreateDefaultDialog();
			//dlg.PredefinedButtons = TaskDialogButtons.Ok;
			dlg.PreferredWidth = 360;

			dlg.Show();
		}

		private void customizedMessageBoxBtn_Click(object sender, System.EventArgs e)
		{
			NTaskDialog dlg = new NTaskDialog();
			dlg.PreferredWidth = 400;
			dlg.ProgressType = TaskDialogProgressType.Marguee;
			dlg.MarqueeProgress.Start();

			dlg.Title = "Nevron User Interface Q4 2006";
			dlg.Content.Style.TextStrokeStyle = new NStrokeStyle(1, Color.Brown);
			dlg.Content.Style.TextFillStyle = new NColorFillStyle(Color.Wheat);
			dlg.Content.Style.TextSmoothingMode = SmoothingMode.AntiAlias;
			dlg.Content.Style.FontInfo = new NThemeFontInfo("Trebuchet MS", 22f, FontStyleEx.Bold | FontStyleEx.Italic);
			dlg.Content.Text = "Downloading Nevron .NET Vision Q4 2006...";

			NPushButtonElement[] customButtons = new NPushButtonElement[2];
			NPushButtonElement btn;
            
			btn = new NPushButtonElement();
			btn.Text = "<b>Cancel Download</b>";
			btn.Image = NSystemImages.Error;
			btn.ImageTextRelation = ImageTextRelation.ImageAboveText;
			btn.ImageSize = new NSize(32, 32);
			btn.Id = 0;
			customButtons[0] = btn;

			btn = new NPushButtonElement();
			btn.Text = "<b>Pause Download</b>";
			btn.Image = NSystemImages.Exclamation;
			btn.ImageTextRelation = ImageTextRelation.ImageAboveText;
			btn.ImageSize = new NSize(32, 32);
			btn.Id = 1;
			customButtons[1] = btn;

			dlg.UserButtons = customButtons;
			dlg.DefaultButtonId = 2;

			dlg.Show();
		}

		private void vistaLikeNotification_Click(object sender, System.EventArgs e)
		{
			NTaskDialog dlg = new NTaskDialog();
			dlg.Title = "Copy File";
			dlg.PreferredWidth = 480;
			dlg.PredefinedButtons = TaskDialogButtons.Cancel;

			NThemeFontInfo fi = new NThemeFontInfo("Tahoma", 9, FontStyleEx.Regular);

			NLabelElement label = dlg.Content;
			label.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			label.Text = "<font color='navy' size='11' face='Tahoma'>There is already a file with the same name in this location.</font><br/><br/>What would you like to do:";

			NPushButtonElement[] largeButtons = new NPushButtonElement[3];
			NPushButtonElement button;
			string text;

			button = new NPushButtonElement();
			button.Id = 100;
			button.TreatAsOneEntity = false;
			button.ImageAlign = ContentAlignment.TopLeft;
			button.TextAlign = ContentAlignment.TopLeft;
			button.Image = NSystemImages.Question;
			button.ImageSize = new NSize(32, 32);
			button.ContentAlign = ContentAlignment.MiddleLeft;
			button.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			button.Style.FontInfo = fi;
			text = "<font color='navy' size='12'>Copy and replace</font><br/><font color='navy'>Replace the file in the destination folder with the file you are copying:</font><br/>";
			text += "<b>NTaskDialog.cs</b><br/>";
			text += @"<font color='navy'>NTaskDialog (C:\Projects\UI\WinForm\Controls\Forms\TaskDialog)</font>";
			text += "<br/>Size: 14 KB<br/>";
			text += "Date Modified: 03/03/2007 10:00 AM (Newer)";
			button.Text = text;
			largeButtons[0] = button;

			button = new NPushButtonElement();
			button.Id = 101;
			button.TreatAsOneEntity = false;
			button.ImageAlign = ContentAlignment.TopLeft;
			button.TextAlign = ContentAlignment.TopLeft;
			button.Image = NSystemImages.Question;
			button.ImageSize = new NSize(32, 32);
			button.ContentAlign = ContentAlignment.MiddleLeft;
			button.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			button.Style.FontInfo = fi;
			text = "<font color='navy' size='12'>Don't Copy</font><br/><font color='navy'>No files will be changed. Leave this file in the destination folder:</font><br/>";
			text += "<b>NTaskDialog.cs</b><br/>";
			text += @"<font color='navy'>NTaskDialog (C:\OldProjects\UI\WinForm\Controls\Forms\TaskDialog)</font>";
			text += "<br/>Size: 12 KB (Smaller)<br/>";
			text += "Date Modified: 03/03/2007 09:00 AM";
			button.Text = text;
			largeButtons[1] = button;

			button = new NPushButtonElement();
			button.Id = 102;
			button.TreatAsOneEntity = false;
			button.ImageAlign = ContentAlignment.TopLeft;
			button.TextAlign = ContentAlignment.TopLeft;
			button.Image = NSystemImages.Question;
			button.ImageSize = new NSize(32, 32);
			button.ContentAlign = ContentAlignment.MiddleLeft;
			button.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			button.Style.FontInfo = fi;
			text = "<font color='navy' size='12'>Copy, but keep both files</font><br/><font color='navy'>The file you are copying will be renamed \"NTaskDialog (2).cs\"</font>";
			button.Text = text;
			largeButtons[2] = button;

			dlg.DefaultButtonId = 100;
			dlg.LargeUserButtons = largeButtons;
			dlg.Show();
		}

		private void progressDialogBtn_Click(object sender, System.EventArgs e)
		{
			NTaskDialog dlg = new NTaskDialog();
			dlg.PreferredWidth = 400;
			dlg.ProgressType = TaskDialogProgressType.Standard;

			dlg.Title = "Nevron User Interface Q4 2006";
			dlg.Content.Style.FontInfo = new NThemeFontInfo("Tahoma", 10f, FontStyleEx.Regular);
			dlg.Content.Text = "Downloading Nevron .NET Vision Q4 2006...";
			dlg.Content.Image = NSystemImages.Information;
			dlg.Content.ImageSize = new NSize(32, 32);
			dlg.ProgressType = TaskDialogProgressType.Standard;
			dlg.EnableTimer = true;
			dlg.Verification.Text = "Close this dialog when download is complete";
			dlg.Notify += m_CallBack;

			//inint buttons
			NPushButtonElement cancelBtn = new NPushButtonElement();
			cancelBtn.Text = "Cancel";
			cancelBtn.Id = 100;

			NPushButtonElement pauseBtn = new NPushButtonElement();
			pauseBtn.Text = "Pause";
			pauseBtn.Id = 101;

			NPushButtonElement resumeBtn = new NPushButtonElement();
			resumeBtn.Text = "Resume";
			resumeBtn.Id = 102;

			dlg.UserButtons = new NPushButtonElement[] {cancelBtn, pauseBtn, resumeBtn};
			//the defaulted button is "Pause"
			dlg.DefaultButtonId = 101;
			dlg.Show();
		}

		private void OnCallBack(object sender, NTaskDialogEventArgs e)
		{
			switch(e.Notification)
			{
				case TaskDialogNotification.ButtonClick:
					int id = ((NPushButtonElement)sender).Id;
					if(id == 100)//cancel button; leave default implementation
						break;

				switch(id)
				{
					case 101://pause button
						m_bPaused = true;
						break;
					case 102://resume button
						m_bPaused = false;
						break;
				}
					//prevent the default implementation of the click which will close the dialog
					e.Cancel = true;

					break;
				case TaskDialogNotification.TimerTick:
					if(m_bPaused)
						break;

					NTaskDialog dlg = e.Dialog;
					NProgressBarElement progress = dlg.ProgressBar;

					progress.Value++;
					if(progress.Value == progress.Maximum)
					{
						if(dlg.Verification.CheckState == CheckState.Checked)
							e.Form.Close();
					}
					break;
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
			this.standardMessageBoxBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.customizedMessageBoxBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.vistaLikeNotification = new Nevron.UI.WinForm.Controls.NButton();
			this.progressDialogBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// standardMessageBoxBtn
			// 
			this.standardMessageBoxBtn.Location = new System.Drawing.Point(8, 8);
			this.standardMessageBoxBtn.Name = "standardMessageBoxBtn";
			this.standardMessageBoxBtn.Size = new System.Drawing.Size(160, 24);
			this.standardMessageBoxBtn.TabIndex = 0;
			this.standardMessageBoxBtn.Text = "Standard Message Box...";
			this.standardMessageBoxBtn.Click += new System.EventHandler(this.standardMessageBoxBtn_Click);
			// 
			// customizedMessageBoxBtn
			// 
			this.customizedMessageBoxBtn.Location = new System.Drawing.Point(8, 72);
			this.customizedMessageBoxBtn.Name = "customizedMessageBoxBtn";
			this.customizedMessageBoxBtn.Size = new System.Drawing.Size(160, 24);
			this.customizedMessageBoxBtn.TabIndex = 1;
			this.customizedMessageBoxBtn.Text = "Marquee Progress Dialog...";
			this.customizedMessageBoxBtn.Click += new System.EventHandler(this.customizedMessageBoxBtn_Click);
			// 
			// vistaLikeNotification
			// 
			this.vistaLikeNotification.Location = new System.Drawing.Point(8, 104);
			this.vistaLikeNotification.Name = "vistaLikeNotification";
			this.vistaLikeNotification.Size = new System.Drawing.Size(160, 24);
			this.vistaLikeNotification.TabIndex = 2;
			this.vistaLikeNotification.Text = "Vista-like Copy Notification...";
			this.vistaLikeNotification.Click += new System.EventHandler(this.vistaLikeNotification_Click);
			// 
			// progressDialogBtn
			// 
			this.progressDialogBtn.Location = new System.Drawing.Point(8, 40);
			this.progressDialogBtn.Name = "progressDialogBtn";
			this.progressDialogBtn.Size = new System.Drawing.Size(160, 24);
			this.progressDialogBtn.TabIndex = 3;
			this.progressDialogBtn.Text = "Progress Dialog...";
			this.progressDialogBtn.Click += new System.EventHandler(this.progressDialogBtn_Click);
			// 
			// NTaskDialogMessageBoxUC
			// 
			this.Controls.Add(this.progressDialogBtn);
			this.Controls.Add(this.vistaLikeNotification);
			this.Controls.Add(this.customizedMessageBoxBtn);
			this.Controls.Add(this.standardMessageBoxBtn);
			this.Name = "NTaskDialogMessageBoxUC";
			this.Size = new System.Drawing.Size(176, 136);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NTaskDialogCallBack m_CallBack;
		internal bool m_bPaused;
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton standardMessageBoxBtn;
		private Nevron.UI.WinForm.Controls.NButton vistaLikeNotification;
		private Nevron.UI.WinForm.Controls.NButton progressDialogBtn;
		private Nevron.UI.WinForm.Controls.NButton customizedMessageBoxBtn;

		#endregion
	}
}
