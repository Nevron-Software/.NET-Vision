using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NWallsGeneralUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox4;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftVisibleCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox BackVisibleCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RightVisibleCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox FloorVisibleCheck;
		private Nevron.UI.WinForm.Controls.NButton LeftBorderButton;
		private Nevron.UI.WinForm.Controls.NButton BackBorderButton;
		private Nevron.UI.WinForm.Controls.NButton RightBorderButton;
		private Nevron.UI.WinForm.Controls.NButton FloorBorderButton;
		private Nevron.UI.WinForm.Controls.NButton LeftFillButton;
		private Nevron.UI.WinForm.Controls.NButton BackFillButton;
		private Nevron.UI.WinForm.Controls.NButton RightFillButton;
		private Nevron.UI.WinForm.Controls.NButton FloorFillButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftWidthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar BackWidthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar RightWidthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar FloorWidthScroll;
		private System.ComponentModel.Container components = null;

		public NWallsGeneralUC()
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
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LeftBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LeftFillButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LeftWidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.LeftVisibleCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BackBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BackFillButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BackWidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.BackVisibleCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.RightBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.RightFillButton = new Nevron.UI.WinForm.Controls.NButton();
			this.RightWidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.RightVisibleCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.FloorBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.FloorFillButton = new Nevron.UI.WinForm.Controls.NButton();
			this.FloorWidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label4 = new System.Windows.Forms.Label();
			this.FloorVisibleCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LeftBorderButton);
			this.groupBox1.Controls.Add(this.LeftFillButton);
			this.groupBox1.Controls.Add(this.LeftWidthScroll);
			this.groupBox1.Controls.Add(this.LeftVisibleCheck);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(171, 135);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Left Wall";
			// 
			// LeftBorderButton
			// 
			this.LeftBorderButton.Location = new System.Drawing.Point(8, 106);
			this.LeftBorderButton.Name = "LeftBorderButton";
			this.LeftBorderButton.Size = new System.Drawing.Size(153, 21);
			this.LeftBorderButton.TabIndex = 4;
			this.LeftBorderButton.Text = "Border...";
			this.LeftBorderButton.Click += new System.EventHandler(this.LeftBorderButton_Click);
			// 
			// LeftFillButton
			// 
			this.LeftFillButton.Location = new System.Drawing.Point(8, 80);
			this.LeftFillButton.Name = "LeftFillButton";
			this.LeftFillButton.Size = new System.Drawing.Size(153, 21);
			this.LeftFillButton.TabIndex = 3;
			this.LeftFillButton.Text = "Fill Style...";
			this.LeftFillButton.Click += new System.EventHandler(this.LeftFillButton_Click);
			// 
			// LeftWidthScroll
			// 
			this.LeftWidthScroll.Location = new System.Drawing.Point(8, 59);
			this.LeftWidthScroll.Maximum = 110;
			this.LeftWidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LeftWidthScroll.Name = "LeftWidthScroll";
			this.LeftWidthScroll.Size = new System.Drawing.Size(153, 16);
			this.LeftWidthScroll.TabIndex = 2;
			this.LeftWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftWidthScroll_Scroll);
			// 
			// LeftVisibleCheck
			// 
			this.LeftVisibleCheck.ButtonProperties.BorderOffset = 2;
			this.LeftVisibleCheck.Location = new System.Drawing.Point(8, 17);
			this.LeftVisibleCheck.Name = "LeftVisibleCheck";
			this.LeftVisibleCheck.Size = new System.Drawing.Size(153, 21);
			this.LeftVisibleCheck.TabIndex = 0;
			this.LeftVisibleCheck.Text = "Visible";
			this.LeftVisibleCheck.CheckedChanged += new System.EventHandler(this.LeftVisibleCheck_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "Width:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.BackBorderButton);
			this.groupBox2.Controls.Add(this.BackFillButton);
			this.groupBox2.Controls.Add(this.BackWidthScroll);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.BackVisibleCheck);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(6, 147);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(171, 135);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Back Wall";
			// 
			// BackBorderButton
			// 
			this.BackBorderButton.Location = new System.Drawing.Point(8, 106);
			this.BackBorderButton.Name = "BackBorderButton";
			this.BackBorderButton.Size = new System.Drawing.Size(153, 21);
			this.BackBorderButton.TabIndex = 4;
			this.BackBorderButton.Text = "Border...";
			this.BackBorderButton.Click += new System.EventHandler(this.BackBorderButton_Click);
			// 
			// BackFillButton
			// 
			this.BackFillButton.Location = new System.Drawing.Point(8, 80);
			this.BackFillButton.Name = "BackFillButton";
			this.BackFillButton.Size = new System.Drawing.Size(153, 21);
			this.BackFillButton.TabIndex = 3;
			this.BackFillButton.Text = "Fill Style...";
			this.BackFillButton.Click += new System.EventHandler(this.BackFillButton_Click);
			// 
			// BackWidthScroll
			// 
			this.BackWidthScroll.Location = new System.Drawing.Point(8, 59);
			this.BackWidthScroll.Maximum = 110;
			this.BackWidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BackWidthScroll.Name = "BackWidthScroll";
			this.BackWidthScroll.Size = new System.Drawing.Size(153, 16);
			this.BackWidthScroll.TabIndex = 2;
			this.BackWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BackWidthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 14);
			this.label2.TabIndex = 1;
			this.label2.Text = "Width:";
			// 
			// BackVisibleCheck
			// 
			this.BackVisibleCheck.ButtonProperties.BorderOffset = 2;
			this.BackVisibleCheck.Location = new System.Drawing.Point(8, 17);
			this.BackVisibleCheck.Name = "BackVisibleCheck";
			this.BackVisibleCheck.Size = new System.Drawing.Size(116, 21);
			this.BackVisibleCheck.TabIndex = 0;
			this.BackVisibleCheck.Text = "Visible";
			this.BackVisibleCheck.CheckedChanged += new System.EventHandler(this.BackVisibleCheck_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.RightBorderButton);
			this.groupBox3.Controls.Add(this.RightFillButton);
			this.groupBox3.Controls.Add(this.RightWidthScroll);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.RightVisibleCheck);
			this.groupBox3.ImageIndex = 0;
			this.groupBox3.Location = new System.Drawing.Point(6, 288);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(171, 135);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Right Wall";
			// 
			// RightBorderButton
			// 
			this.RightBorderButton.Location = new System.Drawing.Point(8, 106);
			this.RightBorderButton.Name = "RightBorderButton";
			this.RightBorderButton.Size = new System.Drawing.Size(153, 21);
			this.RightBorderButton.TabIndex = 4;
			this.RightBorderButton.Text = "Border...";
			this.RightBorderButton.Click += new System.EventHandler(this.RightBorderButton_Click);
			// 
			// RightFillButton
			// 
			this.RightFillButton.Location = new System.Drawing.Point(8, 80);
			this.RightFillButton.Name = "RightFillButton";
			this.RightFillButton.Size = new System.Drawing.Size(153, 21);
			this.RightFillButton.TabIndex = 3;
			this.RightFillButton.Text = "Fill Style...";
			this.RightFillButton.Click += new System.EventHandler(this.RightFillButton_Click);
			// 
			// RightWidthScroll
			// 
			this.RightWidthScroll.Location = new System.Drawing.Point(8, 59);
			this.RightWidthScroll.Maximum = 110;
			this.RightWidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.RightWidthScroll.Name = "RightWidthScroll";
			this.RightWidthScroll.Size = new System.Drawing.Size(153, 16);
			this.RightWidthScroll.TabIndex = 2;
			this.RightWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RightWidthScroll_Scroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 14);
			this.label3.TabIndex = 1;
			this.label3.Text = "Width:";
			// 
			// RightVisibleCheck
			// 
			this.RightVisibleCheck.ButtonProperties.BorderOffset = 2;
			this.RightVisibleCheck.Location = new System.Drawing.Point(8, 17);
			this.RightVisibleCheck.Name = "RightVisibleCheck";
			this.RightVisibleCheck.Size = new System.Drawing.Size(116, 21);
			this.RightVisibleCheck.TabIndex = 0;
			this.RightVisibleCheck.Text = "Visible";
			this.RightVisibleCheck.CheckedChanged += new System.EventHandler(this.RightVisibleCheck_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.FloorBorderButton);
			this.groupBox4.Controls.Add(this.FloorFillButton);
			this.groupBox4.Controls.Add(this.FloorWidthScroll);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.FloorVisibleCheck);
			this.groupBox4.ImageIndex = 0;
			this.groupBox4.Location = new System.Drawing.Point(6, 429);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(171, 135);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Floor Wall";
			// 
			// FloorBorderButton
			// 
			this.FloorBorderButton.Location = new System.Drawing.Point(8, 106);
			this.FloorBorderButton.Name = "FloorBorderButton";
			this.FloorBorderButton.Size = new System.Drawing.Size(153, 21);
			this.FloorBorderButton.TabIndex = 4;
			this.FloorBorderButton.Text = "Border...";
			this.FloorBorderButton.Click += new System.EventHandler(this.FloorBorderButton_Click);
			// 
			// FloorFillButton
			// 
			this.FloorFillButton.Location = new System.Drawing.Point(8, 80);
			this.FloorFillButton.Name = "FloorFillButton";
			this.FloorFillButton.Size = new System.Drawing.Size(153, 21);
			this.FloorFillButton.TabIndex = 3;
			this.FloorFillButton.Text = "Fill Style...";
			this.FloorFillButton.Click += new System.EventHandler(this.FloorFillButton_Click);
			// 
			// FloorWidthScroll
			// 
			this.FloorWidthScroll.Location = new System.Drawing.Point(8, 59);
			this.FloorWidthScroll.Maximum = 110;
			this.FloorWidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.FloorWidthScroll.Name = "FloorWidthScroll";
			this.FloorWidthScroll.Size = new System.Drawing.Size(153, 16);
			this.FloorWidthScroll.TabIndex = 2;
			this.FloorWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FloorWidthScroll_Scroll);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 14);
			this.label4.TabIndex = 1;
			this.label4.Text = "Width:";
			// 
			// FloorVisibleCheck
			// 
			this.FloorVisibleCheck.ButtonProperties.BorderOffset = 2;
			this.FloorVisibleCheck.Location = new System.Drawing.Point(8, 17);
			this.FloorVisibleCheck.Name = "FloorVisibleCheck";
			this.FloorVisibleCheck.Size = new System.Drawing.Size(116, 21);
			this.FloorVisibleCheck.TabIndex = 0;
			this.FloorVisibleCheck.Text = "Visible";
			this.FloorVisibleCheck.CheckedChanged += new System.EventHandler(this.FloorVisibleCheck_CheckedChanged);
			// 
			// NWallsGeneralUC
			// 
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NWallsGeneralUC";
			this.Size = new System.Drawing.Size(180, 572);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			nChartControl1.Legends.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Chart Walls");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(3, NRelativeUnit.ParentPercentage));

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;

            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.Values.FillRandom(Random, 6);
			bar.Name = "Bars";
			bar.DataLabelStyle.Visible = false;

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LeftVisibleCheck.Checked = m_Chart.Wall(ChartWallType.Left).Visible;
			BackVisibleCheck.Checked = m_Chart.Wall(ChartWallType.Back).Visible;
			RightVisibleCheck.Checked = m_Chart.Wall(ChartWallType.Right).Visible;
			FloorVisibleCheck.Checked = m_Chart.Wall(ChartWallType.Floor).Visible;

			LeftWidthScroll.Value = 20;
			BackWidthScroll.Value = 20;
			RightWidthScroll.Value = 20;
			FloorWidthScroll.Value = 20;
		}

		private void LeftVisibleCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Chart.Wall(ChartWallType.Left).Visible = LeftVisibleCheck.Checked;
			nChartControl1.Refresh();
		}

		private void BackVisibleCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Chart.Wall(ChartWallType.Back).Visible = BackVisibleCheck.Checked;
			nChartControl1.Refresh();
		}

		private void RightVisibleCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Chart.Wall(ChartWallType.Right).Visible = RightVisibleCheck.Checked;
			nChartControl1.Refresh();
		}

		private void FloorVisibleCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Chart.Wall(ChartWallType.Floor).Visible = FloorVisibleCheck.Checked;
			nChartControl1.Refresh();
		}

		private void LeftWidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Chart.Wall(ChartWallType.Left).Width = (float)LeftWidthScroll.Value / 10.0f;
			nChartControl1.Refresh();
		}

		private void BackWidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Chart.Wall(ChartWallType.Back).Width = (float)BackWidthScroll.Value / 10.0f;
			nChartControl1.Refresh();
		}

		private void RightWidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Chart.Wall(ChartWallType.Right).Width = (float)RightWidthScroll.Value / 10.0f;
			nChartControl1.Refresh();
		}

		private void FloorWidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Chart.Wall(ChartWallType.Floor).Width = (float)FloorWidthScroll.Value / 10.0f;
			nChartControl1.Refresh();
		}

		private void LeftFillButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Left).FillStyle, out fillStyleResult))
			{
				m_Chart.Wall(ChartWallType.Left).FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BackFillButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Back).FillStyle, out fillStyleResult))
			{
				m_Chart.Wall(ChartWallType.Back).FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void RightFillButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Right).FillStyle, out fillStyleResult))
			{
				m_Chart.Wall(ChartWallType.Right).FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void FloorFillButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Floor).FillStyle, out fillStyleResult))
			{
				m_Chart.Wall(ChartWallType.Floor).FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LeftBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Left).BorderStyle, out strokeStyleResult))
			{
				m_Chart.Wall(ChartWallType.Left).BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BackBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Back).BorderStyle, out strokeStyleResult))
			{
				m_Chart.Wall(ChartWallType.Back).BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void RightBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Right).BorderStyle, out strokeStyleResult))
			{
				m_Chart.Wall(ChartWallType.Right).BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void FloorBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Chart.Wall(ChartWallType.Floor).BorderStyle, out strokeStyleResult))
			{
				m_Chart.Wall(ChartWallType.Floor).BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
