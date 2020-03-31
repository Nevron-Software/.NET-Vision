using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Interop.Win32;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NShadowDecorator.
	/// </summary>
	public class NDecoratorsUC : NExampleUserControl
	{
		#region Constructor

		public NDecoratorsUC(MainForm f) : base(f)
		{
			InitializeComponent();

			//Dock = DockStyle.Fill;
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
			base.Initialize();
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc (ref m);

			if(m.Msg != NWMConstants.WM_MOUSEACTIVATE)
				return;

			Control c = NControlHelper.ControlFromPoint(Control.MousePosition);
			if(c is NDecoratorBase)
				m_Properties.SelectedObject = c;

			Control decorator = NControlHelper.GetParentOfType(c, typeof(NDecoratorBase));
			if(decorator != null)
				m_Properties.SelectedObject = decorator;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NDecoratorsUC));
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.m_Properties = new System.Windows.Forms.PropertyGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nDecorator2 = new Nevron.UI.WinForm.Controls.NDecorator();
			this.nDecorator3 = new Nevron.UI.WinForm.Controls.NDecorator();
			this.label3 = new System.Windows.Forms.Label();
			this.nShadowDecorator5 = new Nevron.UI.WinForm.Controls.NShadowDecorator();
			this.nShadowDecorator4 = new Nevron.UI.WinForm.Controls.NShadowDecorator();
			this.nShadowDecorator3 = new Nevron.UI.WinForm.Controls.NShadowDecorator();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.nShadowDecorator2 = new Nevron.UI.WinForm.Controls.NShadowDecorator();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nShadowDecorator1 = new Nevron.UI.WinForm.Controls.NShadowDecorator();
			this.label2 = new System.Windows.Forms.Label();
			this.nDecorator1 = new Nevron.UI.WinForm.Controls.NDecorator();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.nGroupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nDecorator2)).BeginInit();
			this.nDecorator2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nDecorator3)).BeginInit();
			this.nDecorator3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator3)).BeginInit();
			this.nShadowDecorator3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator2)).BeginInit();
			this.nShadowDecorator2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator1)).BeginInit();
			this.nShadowDecorator1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nDecorator1)).BeginInit();
			this.nDecorator1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.m_Properties);
			this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(5, 0);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(275, 414);
			this.nGroupBox1.TabIndex = 0;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Properties";
			// 
			// m_Properties
			// 
			this.m_Properties.CommandsVisibleIfAvailable = true;
			this.m_Properties.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.m_Properties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_Properties.LargeButtons = false;
			this.m_Properties.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.m_Properties.Location = new System.Drawing.Point(3, 16);
			this.m_Properties.Name = "m_Properties";
			this.m_Properties.Size = new System.Drawing.Size(269, 395);
			this.m_Properties.TabIndex = 0;
			this.m_Properties.Text = "PropertyGrid";
			this.m_Properties.ToolbarVisible = false;
			this.m_Properties.ViewBackColor = System.Drawing.SystemColors.Window;
			this.m_Properties.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(5, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(342, 414);
			this.panel1.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.nGroupBox3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 120);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(342, 294);
			this.panel4.TabIndex = 1;
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.BackColor = System.Drawing.Color.Transparent;
			this.nGroupBox3.Controls.Add(this.nDecorator2);
			this.nGroupBox3.Controls.Add(this.nShadowDecorator5);
			this.nGroupBox3.Controls.Add(this.nShadowDecorator4);
			this.nGroupBox3.Controls.Add(this.nShadowDecorator3);
			this.nGroupBox3.Controls.Add(this.nShadowDecorator2);
			this.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(0, 0);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(342, 294);
			this.nGroupBox3.TabIndex = 1;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Custom Settings";
			// 
			// nDecorator2
			// 
			this.nDecorator2.Controls.Add(this.nDecorator3);
			this.nDecorator2.FillInfo.Gradient1 = System.Drawing.SystemColors.ControlText;
			this.nDecorator2.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText;
			this.nDecorator2.FillInfo.GradientAngle = 240F;
			this.nDecorator2.Location = new System.Drawing.Point(232, 136);
			this.nDecorator2.Name = "nDecorator2";
			this.nDecorator2.Size = new System.Drawing.Size(88, 88);
			this.nDecorator2.StrokeInfo.Color = System.Drawing.SystemColors.ControlText;
			this.nDecorator2.StrokeInfo.Draw = false;
			this.nDecorator2.StrokeInfo.PenWidth = 2;
			this.nDecorator2.StrokeInfo.Rounding = 50;
			this.nDecorator2.TabIndex = 4;
			this.nDecorator2.Text = "nDecorator2";
			// 
			// nDecorator3
			// 
			this.nDecorator3.Controls.Add(this.label3);
			this.nDecorator3.FillInfo.Gradient1 = System.Drawing.SystemColors.ControlText;
			this.nDecorator3.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText;
			this.nDecorator3.FillInfo.GradientAngle = 60F;
			this.nDecorator3.Location = new System.Drawing.Point(16, 16);
			this.nDecorator3.Name = "nDecorator3";
			this.nDecorator3.Size = new System.Drawing.Size(56, 56);
			this.nDecorator3.StrokeInfo.Color = System.Drawing.SystemColors.ControlText;
			this.nDecorator3.StrokeInfo.Draw = false;
			this.nDecorator3.StrokeInfo.Rounding = 50;
			this.nDecorator3.TabIndex = 5;
			this.nDecorator3.Text = "nDecorator3";
			// 
			// label3
			// 
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 48);
			this.label3.TabIndex = 0;
			// 
			// nShadowDecorator5
			// 
			this.nShadowDecorator5.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass;
			this.nShadowDecorator5.FillInfo.Gradient1 = System.Drawing.Color.Blue;
			this.nShadowDecorator5.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText;
			this.nShadowDecorator5.Location = new System.Drawing.Point(160, 136);
			this.nShadowDecorator5.Name = "nShadowDecorator5";
			this.nShadowDecorator5.ShadowInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(51)), ((System.Byte)(153)));
			this.nShadowDecorator5.ShadowInfo.OffsetX = 10;
			this.nShadowDecorator5.ShadowInfo.OffsetY = 10;
			this.nShadowDecorator5.Size = new System.Drawing.Size(56, 56);
			this.nShadowDecorator5.StrokeInfo.Color = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(204)));
			this.nShadowDecorator5.StrokeInfo.Gradient1 = System.Drawing.Color.Blue;
			this.nShadowDecorator5.StrokeInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText;
			this.nShadowDecorator5.StrokeInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nShadowDecorator5.StrokeInfo.Rounding = 50;
			this.nShadowDecorator5.TabIndex = 3;
			// 
			// nShadowDecorator4
			// 
			this.nShadowDecorator4.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Gel;
			this.nShadowDecorator4.FillInfo.Gradient1 = System.Drawing.Color.Red;
			this.nShadowDecorator4.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText;
			this.nShadowDecorator4.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista;
			this.nShadowDecorator4.Location = new System.Drawing.Point(16, 136);
			this.nShadowDecorator4.Name = "nShadowDecorator4";
			this.nShadowDecorator4.ShadowInfo.OffsetX = 10;
			this.nShadowDecorator4.ShadowInfo.OffsetY = 10;
			this.nShadowDecorator4.Size = new System.Drawing.Size(136, 56);
			this.nShadowDecorator4.StrokeInfo.Color = System.Drawing.SystemColors.ActiveCaptionText;
			this.nShadowDecorator4.StrokeInfo.Gradient1 = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(51)), ((System.Byte)(0)));
			this.nShadowDecorator4.StrokeInfo.Gradient2 = System.Drawing.SystemColors.ControlText;
			this.nShadowDecorator4.StrokeInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nShadowDecorator4.StrokeInfo.PenStyle = Nevron.UI.WinForm.Controls.PenStyle.UseBrush;
			this.nShadowDecorator4.StrokeInfo.PenWidth = 5;
			this.nShadowDecorator4.StrokeInfo.Rounding = 20;
			this.nShadowDecorator4.StrokeInfo.RoundingEdges = ((Nevron.UI.RoundingEdges)((Nevron.UI.RoundingEdges.TopRight | Nevron.UI.RoundingEdges.BottomLeft)));
			this.nShadowDecorator4.TabIndex = 2;
			// 
			// nShadowDecorator3
			// 
			this.nShadowDecorator3.Controls.Add(this.radioButton1);
			this.nShadowDecorator3.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.SegmentedImage;
			this.nShadowDecorator3.FillInfo.SegmentedImage.Image = ((System.Drawing.Image)(resources.GetObject("nShadowDecorator3.FillInfo.SegmentedImage.Image")));
			this.nShadowDecorator3.FillInfo.SegmentedImage.Margins = new Nevron.UI.NPadding(4, 4, 4, 4);
			this.nShadowDecorator3.Location = new System.Drawing.Point(160, 32);
			this.nShadowDecorator3.Name = "nShadowDecorator3";
			this.nShadowDecorator3.ShadowInfo.OffsetX = 10;
			this.nShadowDecorator3.ShadowInfo.OffsetY = 10;
			this.nShadowDecorator3.Size = new System.Drawing.Size(160, 88);
			this.nShadowDecorator3.StrokeInfo.Draw = false;
			this.nShadowDecorator3.TabIndex = 1;
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(24, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "radioButton1";
			// 
			// nShadowDecorator2
			// 
			this.nShadowDecorator2.Controls.Add(this.checkBox1);
			this.nShadowDecorator2.FillInfo.Gradient1 = System.Drawing.Color.WhiteSmoke;
			this.nShadowDecorator2.FillInfo.Gradient2 = System.Drawing.Color.DimGray;
			this.nShadowDecorator2.Location = new System.Drawing.Point(16, 32);
			this.nShadowDecorator2.Name = "nShadowDecorator2";
			this.nShadowDecorator2.Size = new System.Drawing.Size(136, 96);
			this.nShadowDecorator2.StrokeInfo.Gradient1 = System.Drawing.Color.DimGray;
			this.nShadowDecorator2.StrokeInfo.Gradient2 = System.Drawing.Color.WhiteSmoke;
			this.nShadowDecorator2.StrokeInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
			this.nShadowDecorator2.StrokeInfo.PenStyle = Nevron.UI.WinForm.Controls.PenStyle.UseBrush;
			this.nShadowDecorator2.StrokeInfo.PenWidth = 5;
			this.nShadowDecorator2.StrokeInfo.Rounding = 10;
			this.nShadowDecorator2.TabIndex = 0;
			// 
			// checkBox1
			// 
			this.checkBox1.BackColor = System.Drawing.Color.Transparent;
			this.checkBox1.Location = new System.Drawing.Point(24, 24);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(88, 24);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "checkBox1";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.nGroupBox2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(342, 120);
			this.panel2.TabIndex = 0;
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.BackColor = System.Drawing.Color.Transparent;
			this.nGroupBox2.Controls.Add(this.nShadowDecorator1);
			this.nGroupBox2.Controls.Add(this.nDecorator1);
			this.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(0, 0);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(342, 120);
			this.nGroupBox2.TabIndex = 0;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Default Settings";
			// 
			// nShadowDecorator1
			// 
			this.nShadowDecorator1.Controls.Add(this.label2);
			this.nShadowDecorator1.Location = new System.Drawing.Point(160, 24);
			this.nShadowDecorator1.Name = "nShadowDecorator1";
			this.nShadowDecorator1.Size = new System.Drawing.Size(168, 80);
			this.nShadowDecorator1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(161, 73);
			this.label2.TabIndex = 1;
			this.label2.Text = "This is label nested in a NShadowDecorator instance.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nDecorator1
			// 
			this.nDecorator1.Controls.Add(this.label1);
			this.nDecorator1.Location = new System.Drawing.Point(16, 24);
			this.nDecorator1.Name = "nDecorator1";
			this.nDecorator1.Size = new System.Drawing.Size(136, 80);
			this.nDecorator1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 78);
			this.label1.TabIndex = 0;
			this.label1.Text = "This is label nested in a NDecorator instance.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.nGroupBox1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.DockPadding.Left = 5;
			this.panel3.Location = new System.Drawing.Point(347, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(280, 414);
			this.panel3.TabIndex = 2;
			// 
			// NDecoratorsUC
			// 
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.DockPadding.All = 5;
			this.Name = "NDecoratorsUC";
			this.Size = new System.Drawing.Size(632, 424);
			this.nGroupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nDecorator2)).EndInit();
			this.nDecorator2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nDecorator3)).EndInit();
			this.nDecorator3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator3)).EndInit();
			this.nShadowDecorator3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator2)).EndInit();
			this.nShadowDecorator2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nShadowDecorator1)).EndInit();
			this.nShadowDecorator1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nDecorator1)).EndInit();
			this.nDecorator1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private System.Windows.Forms.PropertyGrid m_Properties;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private System.Windows.Forms.Panel panel3;
		private Nevron.UI.WinForm.Controls.NDecorator nDecorator1;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NShadowDecorator nShadowDecorator1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel4;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Nevron.UI.WinForm.Controls.NShadowDecorator nShadowDecorator2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.CheckBox checkBox1;
		private Nevron.UI.WinForm.Controls.NShadowDecorator nShadowDecorator4;
		private Nevron.UI.WinForm.Controls.NShadowDecorator nShadowDecorator5;
		private Nevron.UI.WinForm.Controls.NDecorator nDecorator2;
		private Nevron.UI.WinForm.Controls.NDecorator nDecorator3;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NShadowDecorator nShadowDecorator3;

		#endregion
	}
}