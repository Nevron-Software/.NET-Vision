using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NStickyFloatingFramesForm.
	/// </summary>
	public class NStickyFloatingFramesForm : System.Windows.Forms.Form
	{
		#region Constructor

		public NStickyFloatingFramesForm()
		{
			InitializeComponent();

			m_StickyAreaNumeric.Value = nDockManager1.StickyOptions.StickyInflate;
			nDockManager1.DocumentStyle.DocumentViewEnabled = false;
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

				if(nDockManager1 != null)
				{
					nDockManager1.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Event Handlers

		private void m_LeftEdgeCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_LeftEdgeCheck.Checked)
				nDockManager1.StickyOptions.StickyEdges |= Edges.Left;
			else
				nDockManager1.StickyOptions.StickyEdges &= ~Edges.Left;
		}

		private void m_TopEdgeCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_TopEdgeCheck.Checked)
				nDockManager1.StickyOptions.StickyEdges |= Edges.Top;
			else
				nDockManager1.StickyOptions.StickyEdges &= ~Edges.Top;
		}

		private void m_RightEdgeCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_RightEdgeCheck.Checked)
				nDockManager1.StickyOptions.StickyEdges |= Edges.Right;
			else
				nDockManager1.StickyOptions.StickyEdges &= ~Edges.Right;
		}

		private void m_BottomEdgeCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_BottomEdgeCheck.Checked)
				nDockManager1.StickyOptions.StickyEdges |= Edges.Bottom;
			else
				nDockManager1.StickyOptions.StickyEdges &= ~Edges.Bottom;
		}

		private void m_StickyAreaNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			nDockManager1.StickyOptions.StickyInflate = (int)m_StickyAreaNumeric.Value;
		}

		private void m_StickyFramesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nDockManager1.StickyFloatingFrames = m_StickyFramesCheck.Checked;
		}

		private void m_StickToMainFormCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nDockManager1.StickToMainForm = m_StickToMainFormCheck.Checked;
		}

		private void m_StickToWorkAreaCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nDockManager1.StickToWorkingArea = m_StickToWorkAreaCheck.Checked;
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone0 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockZone nDockZone1 = new Nevron.UI.WinForm.Docking.NDockZone();
			Nevron.UI.WinForm.Docking.NDockZone nDockZone2 = new Nevron.UI.WinForm.Docking.NDockZone();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone4 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockZone nDockZone5 = new Nevron.UI.WinForm.Docking.NDockZone();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone6 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone7 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			this.nDockManager1 = new Nevron.UI.WinForm.Docking.NDockManager();
			this.nDockingPanel1 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nDockingPanel2 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.m_StickyFramesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_StickToWorkAreaCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_StickToMainFormCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.m_BottomEdgeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_TopEdgeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_RightEdgeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_LeftEdgeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_StickyAreaNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.nDockingPanel3 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nDockingPanel4 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nDockingPanel5 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).BeginInit();
			this.nDockingPanel2.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_StickyAreaNumeric)).BeginInit();
			// 
			// nDockManager1
			// 
			this.nDockManager1.Form = this;
			this.nDockManager1.RootContainerZIndex = 0;
			this.nDockManager1.StickyOptions.StickyInflate = 21;
			//  
			// Root Zone
			//  
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0);
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1);
			this.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//  
			// nDockZone0
			//  
			nDockZone0.AddChild(this.nDockingPanel2);
			nDockZone0.Name = "nDockZone0";
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone0.Index = 0;
			nDockZone0.SizeInfo.SizeLogic = Nevron.UI.WinForm.Docking.SizeLogic.Absolute;
			nDockZone0.SizeInfo.PrefferedSize = new System.Drawing.Size(220, 200);
			nDockZone0.SizeInfo.AbsoluteSize = new System.Drawing.Size(220, 0);
			//  
			// nDockZone1
			//  
			nDockZone1.AddChild(nDockZone2);
			nDockZone1.AddChild(nDockZone5);
			nDockZone1.Name = "nDockZone1";
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Vertical;
			nDockZone1.Index = 1;
			nDockZone1.SizeInfo.SizeLogic = Nevron.UI.WinForm.Docking.SizeLogic.FillInterior;
			nDockZone1.SizeInfo.PrefferedSize = new System.Drawing.Size(599, 200);
			//  
			// nDockZone2
			//  
			nDockZone2.AddChild(this.nDockManager1.DocumentManager.DocumentViewHost);
			nDockZone2.AddChild(nDockZone4);
			nDockZone2.Name = "nDockZone2";
			nDockZone2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone2.Index = 0;
			nDockZone2.SizeInfo.SizeLogic = Nevron.UI.WinForm.Docking.SizeLogic.FillInterior;
			nDockZone2.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 118);
			//  
			// nDockZone4
			//  
			nDockZone4.AddChild(this.nDockingPanel3);
			nDockZone4.AddChild(this.nDockingPanel4);
			nDockZone4.Name = "nDockZone4";
			nDockZone4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone4.Index = 1;
			nDockZone4.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 179);
			//  
			// nDockZone5
			//  
			nDockZone5.AddChild(nDockZone6);
			nDockZone5.AddChild(nDockZone7);
			nDockZone5.Name = "nDockZone5";
			nDockZone5.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone5.Index = 1;
			nDockZone5.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 141);
			//  
			// nDockZone6
			//  
			nDockZone6.AddChild(this.nDockingPanel5);
			nDockZone6.Name = "nDockZone6";
			nDockZone6.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone6.Index = 0;
			nDockZone6.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 141);
			//  
			// nDockZone7
			//  
			nDockZone7.AddChild(this.nDockingPanel1);
			nDockZone7.Name = "nDockZone7";
			nDockZone7.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone7.Index = 1;
			nDockZone7.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 179);
			// 
			// nDockingPanel1
			// 
			this.nDockingPanel1.Name = "nDockingPanel1";
			this.nDockingPanel1.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 179);
			this.nDockingPanel1.TabIndex = 1;
			// 
			// nDockingPanel2
			// 
			this.nDockingPanel2.Controls.Add(this.m_StickyFramesCheck);
			this.nDockingPanel2.Controls.Add(this.m_StickToWorkAreaCheck);
			this.nDockingPanel2.Controls.Add(this.m_StickToMainFormCheck);
			this.nDockingPanel2.Controls.Add(this.nGroupBox1);
			this.nDockingPanel2.Controls.Add(this.label1);
			this.nDockingPanel2.Controls.Add(this.m_StickyAreaNumeric);
			this.nDockingPanel2.Name = "nDockingPanel2";
			this.nDockingPanel2.SizeInfo.AbsoluteSize = new System.Drawing.Size(220, 0);
			this.nDockingPanel2.SizeInfo.PrefferedSize = new System.Drawing.Size(220, 200);
			this.nDockingPanel2.SizeInfo.SizeLogic = Nevron.UI.WinForm.Docking.SizeLogic.Absolute;
			this.nDockingPanel2.TabIndex = 1;
			this.nDockingPanel2.Text = "Sticky Options";
			// 
			// m_StickyFramesCheck
			// 
			this.m_StickyFramesCheck.Checked = true;
			this.m_StickyFramesCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_StickyFramesCheck.Location = new System.Drawing.Point(88, 144);
			this.m_StickyFramesCheck.Name = "m_StickyFramesCheck";
			this.m_StickyFramesCheck.Size = new System.Drawing.Size(128, 24);
			this.m_StickyFramesCheck.TabIndex = 6;
			this.m_StickyFramesCheck.Text = "Sticky Frames";
			this.m_StickyFramesCheck.CheckedChanged += new System.EventHandler(this.m_StickyFramesCheck_CheckedChanged);
			// 
			// m_StickToWorkAreaCheck
			// 
			this.m_StickToWorkAreaCheck.Checked = true;
			this.m_StickToWorkAreaCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_StickToWorkAreaCheck.Location = new System.Drawing.Point(88, 192);
			this.m_StickToWorkAreaCheck.Name = "m_StickToWorkAreaCheck";
			this.m_StickToWorkAreaCheck.Size = new System.Drawing.Size(128, 24);
			this.m_StickToWorkAreaCheck.TabIndex = 5;
			this.m_StickToWorkAreaCheck.Text = "Stick To Work Area";
			this.m_StickToWorkAreaCheck.CheckedChanged += new System.EventHandler(this.m_StickToWorkAreaCheck_CheckedChanged);
			// 
			// m_StickToMainFormCheck
			// 
			this.m_StickToMainFormCheck.Checked = true;
			this.m_StickToMainFormCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_StickToMainFormCheck.Location = new System.Drawing.Point(88, 168);
			this.m_StickToMainFormCheck.Name = "m_StickToMainFormCheck";
			this.m_StickToMainFormCheck.Size = new System.Drawing.Size(128, 24);
			this.m_StickToMainFormCheck.TabIndex = 4;
			this.m_StickToMainFormCheck.Text = "Stick To Main Form";
			this.m_StickToMainFormCheck.CheckedChanged += new System.EventHandler(this.m_StickToMainFormCheck_CheckedChanged);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.m_BottomEdgeCheck);
			this.nGroupBox1.Controls.Add(this.m_TopEdgeCheck);
			this.nGroupBox1.Controls.Add(this.m_RightEdgeCheck);
			this.nGroupBox1.Controls.Add(this.m_LeftEdgeCheck);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(200, 96);
			this.nGroupBox1.TabIndex = 2;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Sticky Edges";
			// 
			// m_BottomEdgeCheck
			// 
			this.m_BottomEdgeCheck.Checked = true;
			this.m_BottomEdgeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_BottomEdgeCheck.Location = new System.Drawing.Point(80, 64);
			this.m_BottomEdgeCheck.Name = "m_BottomEdgeCheck";
			this.m_BottomEdgeCheck.Size = new System.Drawing.Size(72, 24);
			this.m_BottomEdgeCheck.TabIndex = 3;
			this.m_BottomEdgeCheck.Text = "Bottom";
			this.m_BottomEdgeCheck.CheckedChanged += new System.EventHandler(this.m_BottomEdgeCheck_CheckedChanged);
			// 
			// m_TopEdgeCheck
			// 
			this.m_TopEdgeCheck.Checked = true;
			this.m_TopEdgeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_TopEdgeCheck.Location = new System.Drawing.Point(80, 16);
			this.m_TopEdgeCheck.Name = "m_TopEdgeCheck";
			this.m_TopEdgeCheck.Size = new System.Drawing.Size(72, 24);
			this.m_TopEdgeCheck.TabIndex = 2;
			this.m_TopEdgeCheck.Text = "Top";
			this.m_TopEdgeCheck.CheckedChanged += new System.EventHandler(this.m_TopEdgeCheck_CheckedChanged);
			// 
			// m_RightEdgeCheck
			// 
			this.m_RightEdgeCheck.Checked = true;
			this.m_RightEdgeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_RightEdgeCheck.Location = new System.Drawing.Point(128, 40);
			this.m_RightEdgeCheck.Name = "m_RightEdgeCheck";
			this.m_RightEdgeCheck.Size = new System.Drawing.Size(64, 24);
			this.m_RightEdgeCheck.TabIndex = 1;
			this.m_RightEdgeCheck.Text = "Right";
			this.m_RightEdgeCheck.CheckedChanged += new System.EventHandler(this.m_RightEdgeCheck_CheckedChanged);
			// 
			// m_LeftEdgeCheck
			// 
			this.m_LeftEdgeCheck.Checked = true;
			this.m_LeftEdgeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_LeftEdgeCheck.Location = new System.Drawing.Point(24, 40);
			this.m_LeftEdgeCheck.Name = "m_LeftEdgeCheck";
			this.m_LeftEdgeCheck.Size = new System.Drawing.Size(72, 24);
			this.m_LeftEdgeCheck.TabIndex = 0;
			this.m_LeftEdgeCheck.Text = "Left";
			this.m_LeftEdgeCheck.CheckedChanged += new System.EventHandler(this.m_LeftEdgeCheck_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Sticky Area:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_StickyAreaNumeric
			// 
			this.m_StickyAreaNumeric.Location = new System.Drawing.Point(88, 112);
			this.m_StickyAreaNumeric.Maximum = new System.Decimal(new int[] {
																				30,
																				0,
																				0,
																				0});
			this.m_StickyAreaNumeric.Name = "m_StickyAreaNumeric";
			this.m_StickyAreaNumeric.Size = new System.Drawing.Size(120, 20);
			this.m_StickyAreaNumeric.TabIndex = 0;
			this.m_StickyAreaNumeric.ValueChanged += new System.EventHandler(this.m_StickyAreaNumeric_ValueChanged);
			// 
			// nDockingPanel3
			// 
			this.nDockingPanel3.Name = "nDockingPanel3";
			this.nDockingPanel3.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 179);
			this.nDockingPanel3.TabIndex = 2;
			// 
			// nDockingPanel4
			// 
			this.nDockingPanel4.Name = "nDockingPanel4";
			this.nDockingPanel4.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 179);
			this.nDockingPanel4.TabIndex = 3;
			// 
			// nDockingPanel5
			// 
			this.nDockingPanel5.Name = "nDockingPanel5";
			this.nDockingPanel5.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 141);
			this.nDockingPanel5.TabIndex = 1;
			// 
			// NStickyFloatingFramesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(832, 526);
			this.Name = "NStickyFloatingFramesForm";
			this.Text = "Sticky Floating Frames Example";
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).EndInit();
			this.nDockingPanel2.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_StickyAreaNumeric)).EndInit();

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Docking.NDockManager nDockManager1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_StickyAreaNumeric;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_LeftEdgeCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_RightEdgeCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_TopEdgeCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_BottomEdgeCheck;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel3;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel4;
		private Nevron.UI.WinForm.Controls.NCheckBox m_StickyFramesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_StickToWorkAreaCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_StickToMainFormCheck;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel5;

		#endregion
	}
}
