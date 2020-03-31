using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
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
	/// Summary description for NTaskDialogUC.
	/// </summary>
	public class NTaskDialogExtendedUC : NExampleUserControl
	{
		#region Constructor

		public NTaskDialogExtendedUC(MainForm f) : base(f)
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

			NImageAndTextItem item;
			string text;

			Type t = GetType();
			string path = "Nevron.Examples.UI.WinForm.Resources.Images.TaskDialog";

			m_TaskDialog = new NTaskDialog();
			m_TaskDialog.PreferredWidth = 350;
			m_TaskDialog.PredefinedButtons = TaskDialogButtons.Yes | TaskDialogButtons.No | TaskDialogButtons.Cancel;
			m_TaskDialog.Title = "Nevron User Interface for .NET";

			//customize header
			item = m_TaskDialog.Content;
			item.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			item.TreatAsOneEntity = false;
			item.ImageAlign = ContentAlignment.BottomRight;
			item.TextAlign = ContentAlignment.TopLeft;
			item.ImageTextRelation = ImageTextRelation.None;
			item.ImageAlpha = 0.5f;
			item.Image = NResourceHelper.BitmapFromResource(t, "computer_48_hot.png", path);
			item.ImageSize = new NSize(48, 48);
			item.Style.TextFillStyle = new NAdvancedGradientFillStyle(AdvancedGradientScheme.Red, 8);
			item.Style.TextShadowStyle = new NShadowStyle(ShadowType.LinearBlur, Color.Gray, 1, 1, 1F, 1);

			text = "<b><font size='10' face='Verdana' color='navy'>Nevron User Interface for .NET Q4 2006 is available!</font></b>";
			text += "<br/><br/>Following are the new features:";
			text += "<br/><br/><u>Chart for .NET:</u><br/><br/>";
			text += "<ul liststyletype='decimal'>";
			text += "<li>Brand new axis model.</li>";
			text += "<li>Greatly improved date-time support.</li>";
			text += "<li>Date-time scrolling.</li>";
			text += "</ul>";

			text += "<br/><u>User Interface for .NET:</u><br/><br/>";
			text += "<ul liststyletype='decimal'>";
			text += "<li>Extended DateTimePicker.</li>";
			text += "<li>Vista-like TaskDialog.</li>";
			text += "<li>Hyper-links per element basis.</li>";
			text += "</ul>";
			text += "<br/><font size='10' color='black'>Download the new version now?</font>";
			item.Text = text;

			item = m_TaskDialog.Footer;
			item.HyperLinkClick += new NHyperLinkEventHandler(OnFooterHyperLinkClick);
			Icon icon = SystemIcons.Information;
			NSize imageSize = new NSize(icon.Width, icon.Height);
			item.Image = NSystemImages.Information;
			item.ImageSize = imageSize;

			text = "For more information visit <a href='http://www.nevron.com/News.aspx?content=News'>www.nevron.com</a>";
			item.Text = text;

			item = m_TaskDialog.Verification;
			item.Text = "In future download new versions automatically";

			propertyGrid.SelectedObject = m_TaskDialog;
		}


		#endregion

		#region Event Handlers

		private void showDialogButton_Click(object sender, System.EventArgs e)
		{
			int result = m_TaskDialog.Show();
			this.dialogResultLabel.Text = result.ToString();
		}

		private void OnFooterHyperLinkClick(object sender, NHyperLinkEventArgs e)
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
			this.showDialogButton = new Nevron.UI.WinForm.Controls.NButton();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dialogResultLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// showDialogButton
			// 
			this.showDialogButton.Location = new System.Drawing.Point(160, 336);
			this.showDialogButton.Name = "showDialogButton";
			this.showDialogButton.Size = new System.Drawing.Size(104, 24);
			this.showDialogButton.TabIndex = 0;
			this.showDialogButton.Text = "Show Dialog...";
			this.showDialogButton.Click += new System.EventHandler(this.showDialogButton_Click);
			// 
			// propertyGrid
			// 
			this.propertyGrid.CommandsVisibleIfAvailable = true;
			this.propertyGrid.LargeButtons = false;
			this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid.Location = new System.Drawing.Point(0, 24);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(264, 304);
			this.propertyGrid.TabIndex = 4;
			this.propertyGrid.Text = "propertyGrid1";
			this.propertyGrid.ToolbarVisible = false;
			this.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Task Dialog Properties:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 336);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 24);
			this.label2.TabIndex = 6;
			this.label2.Text = "Dialog Result:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dialogResultLabel
			// 
			this.dialogResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dialogResultLabel.Location = new System.Drawing.Point(0, 360);
			this.dialogResultLabel.Name = "dialogResultLabel";
			this.dialogResultLabel.Size = new System.Drawing.Size(104, 24);
			this.dialogResultLabel.TabIndex = 7;
			this.dialogResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NTaskDialogUC
			// 
			this.Controls.Add(this.dialogResultLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.propertyGrid);
			this.Controls.Add(this.showDialogButton);
			this.Name = "NTaskDialogUC";
			this.Size = new System.Drawing.Size(264, 384);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NTaskDialog m_TaskDialog;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label dialogResultLabel;
		private Nevron.UI.WinForm.Controls.NButton showDialogButton;

		#endregion
	}
}
