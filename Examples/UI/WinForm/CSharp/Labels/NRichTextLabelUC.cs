using System;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NRichTextLabelUC.
	/// </summary>
	public class NRichTextLabelUC : NExampleUserControl
	{
		#region Constructor

		public NRichTextLabelUC(MainForm f) : base(f)
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


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NRichTextLabelUC));
			this.nRichTextLabel1 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.nRichTextLabel2 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.nRichTextLabel3 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel3)).BeginInit();
			this.SuspendLayout();
			// 
			// nRichTextLabel1
			// 
			this.nRichTextLabel1.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(90)), ((System.Byte)(125)), ((System.Byte)(222)));
			this.nRichTextLabel1.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(155)), ((System.Byte)(186)), ((System.Byte)(247)));
			this.nRichTextLabel1.FillInfo.GradientAngle = 15F;
			this.nRichTextLabel1.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nRichTextLabel1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRichTextLabel1.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel1.Item.Image")));
			this.nRichTextLabel1.Item.ImageSize = new Nevron.GraphicsCore.NSize(28, 28);
			this.nRichTextLabel1.Item.Padding = new Nevron.UI.NPadding(5, 5, 5, 5);
			this.nRichTextLabel1.Location = new System.Drawing.Point(8, 8);
			this.nRichTextLabel1.Name = "nRichTextLabel1";
			this.nRichTextLabel1.Size = new System.Drawing.Size(296, 72);
			this.nRichTextLabel1.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(45)), ((System.Byte)(150)));
			this.nRichTextLabel1.StrokeInfo.PenWidth = 2;
			this.nRichTextLabel1.StrokeInfo.Rounding = 10;
			this.nRichTextLabel1.TabIndex = 0;
			this.nRichTextLabel1.Text = "<font face=\'Tahoma\' color=\'white\'>The Nevron <b><u><font color=\'whitesmoke\'>NRich" +
				"TextLabel</font></u></b> is a <i><b>revolutionary</b></i> component which allows" +
				" you to display <font color=\'red\'><b>HTML</b></font> formatted texts with ease.<" +
				"/font>";
			// 
			// nRichTextLabel2
			// 
			this.nRichTextLabel2.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
			this.nRichTextLabel2.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(102)), ((System.Byte)(0)));
			this.nRichTextLabel2.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nRichTextLabel2.FillInfo.GradientAngle = 15F;
			this.nRichTextLabel2.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nRichTextLabel2.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRichTextLabel2.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel2.Item.Image")));
			this.nRichTextLabel2.Item.ImageSize = new Nevron.GraphicsCore.NSize(28, 28);
			this.nRichTextLabel2.Item.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText;
			this.nRichTextLabel2.Item.Padding = new Nevron.UI.NPadding(5, 5, 5, 5);
			this.nRichTextLabel2.Item.Text = "";
			this.nRichTextLabel2.Item.TextOrientation = Nevron.UI.TextOrientation.Vertical90;
			this.nRichTextLabel2.Location = new System.Drawing.Point(8, 88);
			this.nRichTextLabel2.Name = "nRichTextLabel2";
			this.nRichTextLabel2.Size = new System.Drawing.Size(88, 240);
			this.nRichTextLabel2.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(204)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nRichTextLabel2.StrokeInfo.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
			this.nRichTextLabel2.StrokeInfo.PenWidth = 2;
			this.nRichTextLabel2.StrokeInfo.Rounding = 10;
			this.nRichTextLabel2.TabIndex = 1;
			this.nRichTextLabel2.Text = "<font face=\'Tahoma\'>The Nevron <b><u><font color=\'whitesmoke\'>NRichTextLabel</fon" +
				"t></u></b> is a <i><b>revolutionary</b></i> component which allows you to displa" +
				"y <font color=\'red\'><b>HTML</b></font> formatted texts with ease.</font>";
			// 
			// nRichTextLabel3
			// 
			this.nRichTextLabel3.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
			this.nRichTextLabel3.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(225)), ((System.Byte)(212)), ((System.Byte)(192)));
			this.nRichTextLabel3.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nRichTextLabel3.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nRichTextLabel3.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRichTextLabel3.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel3.Item.Image")));
			this.nRichTextLabel3.Item.ImageSize = new Nevron.GraphicsCore.NSize(28, 28);
			this.nRichTextLabel3.Item.ImageTextRelation = Nevron.UI.ImageTextRelation.TextAboveImage;
			this.nRichTextLabel3.Item.Padding = new Nevron.UI.NPadding(5, 5, 5, 5);
			this.nRichTextLabel3.Item.Text = "";
			this.nRichTextLabel3.Item.TextOrientation = Nevron.UI.TextOrientation.Vertical270;
			this.nRichTextLabel3.Location = new System.Drawing.Point(112, 88);
			this.nRichTextLabel3.Name = "nRichTextLabel3";
			this.nRichTextLabel3.ShadowInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(28)), ((System.Byte)(28)), ((System.Byte)(28)));
			this.nRichTextLabel3.Size = new System.Drawing.Size(88, 240);
			this.nRichTextLabel3.StrokeInfo.Color = System.Drawing.Color.Brown;
			this.nRichTextLabel3.StrokeInfo.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
			this.nRichTextLabel3.StrokeInfo.PenWidth = 2;
			this.nRichTextLabel3.StrokeInfo.Rounding = 10;
			this.nRichTextLabel3.TabIndex = 2;
			this.nRichTextLabel3.Text = "<font face=\'Tahoma\' color=\'brown\'>The Nevron <b><u><font color=\'black\'>NRichTextL" +
				"abel</font></u></b> is a <i><b>revolutionary</b></i> component which allows you " +
				"to display <font color=\'red\'><b>HTML</b></font> formatted texts with ease.</font" +
				">";
			// 
			// NRichTextLabelUC
			// 
			this.Controls.Add(this.nRichTextLabel3);
			this.Controls.Add(this.nRichTextLabel2);
			this.Controls.Add(this.nRichTextLabel1);
			this.Name = "NRichTextLabelUC";
			this.Size = new System.Drawing.Size(312, 336);
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel2;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel3;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel1;

		#endregion
	}
}
