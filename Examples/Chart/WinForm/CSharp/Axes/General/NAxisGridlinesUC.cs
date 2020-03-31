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
	public class NAxisGridlinesUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox4;
		private Nevron.UI.WinForm.Controls.NComboBox LeftMajorCombo;
		private Nevron.UI.WinForm.Controls.NComboBox BottomMajorCombo;
		private Nevron.UI.WinForm.Controls.NComboBox DepthMajorCombo;
		private Nevron.UI.WinForm.Controls.NComboBox LeftMinorCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftMajor2Check;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftMajor1Check;
		private Nevron.UI.WinForm.Controls.NCheckBox Bottom2Check;
		private Nevron.UI.WinForm.Controls.NCheckBox Bottom1Check;
		private Nevron.UI.WinForm.Controls.NCheckBox Depth2Check;
		private Nevron.UI.WinForm.Controls.NCheckBox Depth1Check;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftMinor2Check;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftMinor1Check;
		private Nevron.UI.WinForm.Controls.NButton BottomColor;
		private Nevron.UI.WinForm.Controls.NButton LeftMajorColor;
		private Nevron.UI.WinForm.Controls.NButton DepthColor;
		private Nevron.UI.WinForm.Controls.NButton LeftMinorColor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog1;
		private System.ComponentModel.Container components = null;

		public NAxisGridlinesUC()
		{
			InitializeComponent();

			LeftMajorCombo.FillFromEnum(typeof(LinePattern));
			BottomMajorCombo.FillFromEnum(typeof(LinePattern));
			DepthMajorCombo.FillFromEnum(typeof(LinePattern));
			LeftMinorCombo.FillFromEnum(typeof(LinePattern));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NAxisGridlinesUC));
            this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.LeftMajorCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.LeftMajorColor = new Nevron.UI.WinForm.Controls.NButton();
            this.LeftMajor2Check = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.LeftMajor1Check = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.BottomMajorCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.BottomColor = new Nevron.UI.WinForm.Controls.NButton();
            this.Bottom2Check = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.Bottom1Check = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.DepthColor = new Nevron.UI.WinForm.Controls.NButton();
            this.label3 = new System.Windows.Forms.Label();
            this.DepthMajorCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.Depth2Check = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.Depth1Check = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.groupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LeftMinorCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.LeftMinorColor = new Nevron.UI.WinForm.Controls.NButton();
            this.LeftMinor2Check = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.LeftMinor1Check = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.colorDialog1 = new Nevron.UI.WinForm.Controls.NColorDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LeftMajorCombo);
            this.groupBox1.Controls.Add(this.LeftMajorColor);
            this.groupBox1.Controls.Add(this.LeftMajor2Check);
            this.groupBox1.Controls.Add(this.LeftMajor1Check);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ImageIndex = 0;
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Left axis major gridlines";
            // 
            // LeftMajorCombo
            // 
            this.LeftMajorCombo.Location = new System.Drawing.Point(43, 84);
            this.LeftMajorCombo.Name = "LeftMajorCombo";
            this.LeftMajorCombo.Size = new System.Drawing.Size(132, 21);
            this.LeftMajorCombo.TabIndex = 4;
            this.LeftMajorCombo.SelectedIndexChanged += new System.EventHandler(this.LeftMajorCombo_SelectedIndexChanged);
            // 
            // LeftMajorColor
            // 
            this.LeftMajorColor.Location = new System.Drawing.Point(7, 58);
            this.LeftMajorColor.Name = "LeftMajorColor";
            this.LeftMajorColor.Size = new System.Drawing.Size(168, 22);
            this.LeftMajorColor.TabIndex = 2;
            this.LeftMajorColor.Text = "Color";
            this.LeftMajorColor.Click += new System.EventHandler(this.LeftMajorColor_Click);
            // 
            // LeftMajor2Check
            // 
            this.LeftMajor2Check.ButtonProperties.BorderOffset = 2;
            this.LeftMajor2Check.Location = new System.Drawing.Point(7, 35);
            this.LeftMajor2Check.Name = "LeftMajor2Check";
            this.LeftMajor2Check.Size = new System.Drawing.Size(137, 19);
            this.LeftMajor2Check.TabIndex = 1;
            this.LeftMajor2Check.Text = "Show at back wall";
            this.LeftMajor2Check.CheckedChanged += new System.EventHandler(this.LeftMajor2Check_CheckedChanged);
            // 
            // LeftMajor1Check
            // 
            this.LeftMajor1Check.ButtonProperties.BorderOffset = 2;
            this.LeftMajor1Check.Location = new System.Drawing.Point(7, 16);
            this.LeftMajor1Check.Name = "LeftMajor1Check";
            this.LeftMajor1Check.Size = new System.Drawing.Size(137, 19);
            this.LeftMajor1Check.TabIndex = 0;
            this.LeftMajor1Check.Text = "Show at left wall";
            this.LeftMajor1Check.CheckedChanged += new System.EventHandler(this.LeftMajor1Check_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Style:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BottomMajorCombo);
            this.groupBox2.Controls.Add(this.BottomColor);
            this.groupBox2.Controls.Add(this.Bottom2Check);
            this.groupBox2.Controls.Add(this.Bottom1Check);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ImageIndex = 0;
            this.groupBox2.Location = new System.Drawing.Point(7, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bottom axis major lines";
            // 
            // BottomMajorCombo
            // 
            this.BottomMajorCombo.Location = new System.Drawing.Point(43, 84);
            this.BottomMajorCombo.Name = "BottomMajorCombo";
            this.BottomMajorCombo.Size = new System.Drawing.Size(132, 21);
            this.BottomMajorCombo.TabIndex = 5;
            this.BottomMajorCombo.SelectedIndexChanged += new System.EventHandler(this.BottomMajorCombo_SelectedIndexChanged);
            // 
            // BottomColor
            // 
            this.BottomColor.Location = new System.Drawing.Point(7, 58);
            this.BottomColor.Name = "BottomColor";
            this.BottomColor.Size = new System.Drawing.Size(168, 22);
            this.BottomColor.TabIndex = 2;
            this.BottomColor.Text = "Color";
            this.BottomColor.Click += new System.EventHandler(this.BottomColor_Click);
            // 
            // Bottom2Check
            // 
            this.Bottom2Check.ButtonProperties.BorderOffset = 2;
            this.Bottom2Check.Location = new System.Drawing.Point(7, 34);
            this.Bottom2Check.Name = "Bottom2Check";
            this.Bottom2Check.Size = new System.Drawing.Size(137, 21);
            this.Bottom2Check.TabIndex = 1;
            this.Bottom2Check.Text = "Show at back wall";
            this.Bottom2Check.CheckedChanged += new System.EventHandler(this.Bottom2Check_CheckedChanged);
            // 
            // Bottom1Check
            // 
            this.Bottom1Check.ButtonProperties.BorderOffset = 2;
            this.Bottom1Check.Location = new System.Drawing.Point(7, 15);
            this.Bottom1Check.Name = "Bottom1Check";
            this.Bottom1Check.Size = new System.Drawing.Size(137, 19);
            this.Bottom1Check.TabIndex = 0;
            this.Bottom1Check.Text = "Show at floor";
            this.Bottom1Check.CheckedChanged += new System.EventHandler(this.Bottom1Check_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Style:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DepthColor);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.DepthMajorCombo);
            this.groupBox3.Controls.Add(this.Depth2Check);
            this.groupBox3.Controls.Add(this.Depth1Check);
            this.groupBox3.ImageIndex = 0;
            this.groupBox3.Location = new System.Drawing.Point(7, 248);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 115);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Depth axis major lines";
            // 
            // DepthColor
            // 
            this.DepthColor.Location = new System.Drawing.Point(7, 58);
            this.DepthColor.Name = "DepthColor";
            this.DepthColor.Size = new System.Drawing.Size(168, 22);
            this.DepthColor.TabIndex = 7;
            this.DepthColor.Text = "Color";
            this.DepthColor.Click += new System.EventHandler(this.DepthColor_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Style:";
            // 
            // DepthMajorCombo
            // 
            this.DepthMajorCombo.Location = new System.Drawing.Point(43, 82);
            this.DepthMajorCombo.Name = "DepthMajorCombo";
            this.DepthMajorCombo.Size = new System.Drawing.Size(132, 21);
            this.DepthMajorCombo.TabIndex = 5;
            this.DepthMajorCombo.SelectedIndexChanged += new System.EventHandler(this.DepthMajorCombo_SelectedIndexChanged);
            // 
            // Depth2Check
            // 
            this.Depth2Check.ButtonProperties.BorderOffset = 2;
            this.Depth2Check.Location = new System.Drawing.Point(7, 35);
            this.Depth2Check.Name = "Depth2Check";
            this.Depth2Check.Size = new System.Drawing.Size(137, 17);
            this.Depth2Check.TabIndex = 1;
            this.Depth2Check.Text = "Show at left wall";
            this.Depth2Check.CheckedChanged += new System.EventHandler(this.Depth2Check_CheckedChanged);
            // 
            // Depth1Check
            // 
            this.Depth1Check.ButtonProperties.BorderOffset = 2;
            this.Depth1Check.Location = new System.Drawing.Point(7, 14);
            this.Depth1Check.Name = "Depth1Check";
            this.Depth1Check.Size = new System.Drawing.Size(137, 20);
            this.Depth1Check.TabIndex = 0;
            this.Depth1Check.Text = "Show at floor";
            this.Depth1Check.CheckedChanged += new System.EventHandler(this.Depth1Check_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.LeftMinorCombo);
            this.groupBox4.Controls.Add(this.LeftMinorColor);
            this.groupBox4.Controls.Add(this.LeftMinor2Check);
            this.groupBox4.Controls.Add(this.LeftMinor1Check);
            this.groupBox4.ImageIndex = 0;
            this.groupBox4.Location = new System.Drawing.Point(8, 370);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(185, 115);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Left axis minor gridlines";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Style:";
            // 
            // LeftMinorCombo
            // 
            this.LeftMinorCombo.Location = new System.Drawing.Point(43, 84);
            this.LeftMinorCombo.Name = "LeftMinorCombo";
            this.LeftMinorCombo.Size = new System.Drawing.Size(132, 21);
            this.LeftMinorCombo.TabIndex = 9;
            this.LeftMinorCombo.SelectedIndexChanged += new System.EventHandler(this.LeftMinorCombo_SelectedIndexChanged);
            // 
            // LeftMinorColor
            // 
            this.LeftMinorColor.Location = new System.Drawing.Point(7, 58);
            this.LeftMinorColor.Name = "LeftMinorColor";
            this.LeftMinorColor.Size = new System.Drawing.Size(168, 22);
            this.LeftMinorColor.TabIndex = 8;
            this.LeftMinorColor.Text = "Color";
            this.LeftMinorColor.Click += new System.EventHandler(this.LeftMinorColor_Click);
            // 
            // LeftMinor2Check
            // 
            this.LeftMinor2Check.ButtonProperties.BorderOffset = 2;
            this.LeftMinor2Check.Location = new System.Drawing.Point(7, 37);
            this.LeftMinor2Check.Name = "LeftMinor2Check";
            this.LeftMinor2Check.Size = new System.Drawing.Size(137, 17);
            this.LeftMinor2Check.TabIndex = 2;
            this.LeftMinor2Check.Text = "Show at back wall";
            this.LeftMinor2Check.CheckedChanged += new System.EventHandler(this.LeftMinor2Check_CheckedChanged);
            // 
            // LeftMinor1Check
            // 
            this.LeftMinor1Check.ButtonProperties.BorderOffset = 2;
            this.LeftMinor1Check.Location = new System.Drawing.Point(7, 18);
            this.LeftMinor1Check.Name = "LeftMinor1Check";
            this.LeftMinor1Check.Size = new System.Drawing.Size(137, 17);
            this.LeftMinor1Check.TabIndex = 1;
            this.LeftMinor1Check.Text = "Show at left wall";
            this.LeftMinor1Check.CheckedChanged += new System.EventHandler(this.LeftMinor1Check_CheckedChanged);
            // 
            // colorDialog1
            // 
            this.colorDialog1.ClientSize = new System.Drawing.Size(402, 351);
            this.colorDialog1.Color = System.Drawing.Color.Empty;
            this.colorDialog1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.colorDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("colorDialog1.Icon")));
            this.colorDialog1.Location = new System.Drawing.Point(20, 21);
            this.colorDialog1.MaximizeBox = false;
            this.colorDialog1.MinimizeBox = false;
            this.colorDialog1.Name = "colorDialog1";
            this.colorDialog1.ShowCaptionImage = false;
            this.colorDialog1.ShowInTaskbar = false;
            this.colorDialog1.Sizable = false;
            this.colorDialog1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.colorDialog1.Text = "Edit Color";
            this.colorDialog1.Visible = false;
            // 
            // NAxisGridlinesUC
            // 
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NAxisGridlinesUC";
            this.Size = new System.Drawing.Size(201, 495);
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

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Gridlines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;

			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Height = 28;
			m_Chart.Depth = 40;
			m_Chart.BoundsMode = BoundsMode.Fit;
			m_Chart.Projection.Rotation = -19;
			m_Chart.Projection.Elevation = 20;
			m_Chart.Projection.Type = ProjectionType.Perspective;

			NStandardScaleConfigurator scaleConfigurator = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;
			scaleConfigurator.AutoMinorTicks = false;
			scaleConfigurator.MinorTickCount = 3;

			NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandomRange(Random, 5, 1, 20);
			bar.WidthPercent = 20;
			bar.DepthPercent = 20;
			bar.Name = "Series 1";

			bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandomRange(Random, 5, 1, 20);
			bar.WidthPercent = 20;
			bar.DepthPercent = 20;
			bar.Name = "Series 2";

			bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandomRange(Random, 5, 1, 20);
			bar.WidthPercent = 20;
			bar.DepthPercent = 20;
			bar.Name = "Series 3";

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LeftMajorCombo.SelectedIndex = 0;
			LeftMinorCombo.SelectedIndex = 0;
			BottomMajorCombo.SelectedIndex = 0;
			DepthMajorCombo.SelectedIndex = 0;

			NStandardScaleConfigurator leftScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;
			leftScale.AutoMinorTicks = true;

			NStandardScaleConfigurator bottomScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NStandardScaleConfigurator;
			NStandardScaleConfigurator depthScale = m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator as NStandardScaleConfigurator;

			LeftMajor1Check.Checked = leftScale.MajorGridStyle.GetShowAtWall(ChartWallType.Left);
			LeftMajor2Check.Checked = leftScale.MajorGridStyle.GetShowAtWall(ChartWallType.Back);

			LeftMinor1Check.Checked = leftScale.MinorGridStyle.GetShowAtWall(ChartWallType.Left);
			LeftMinor2Check.Checked = leftScale.MinorGridStyle.GetShowAtWall(ChartWallType.Back);

			Bottom1Check.Checked = bottomScale.MajorGridStyle.GetShowAtWall(ChartWallType.Floor);
			Bottom2Check.Checked = bottomScale.MinorGridStyle.GetShowAtWall(ChartWallType.Back);

			Depth1Check.Checked = depthScale.MajorGridStyle.GetShowAtWall(ChartWallType.Floor);
			Depth2Check.Checked = depthScale.MinorGridStyle.GetShowAtWall(ChartWallType.Left);
		}

		private void LeftMajor1Check_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, LeftMajor1Check.Checked);

			nChartControl1.Refresh();
		}

		private void LeftMajor2Check_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, LeftMajor2Check.Checked);

			nChartControl1.Refresh();
		}

		private void Bottom1Check_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, Bottom1Check.Checked);

			nChartControl1.Refresh();
		}

		private void Bottom2Check_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, Bottom2Check.Checked);

			nChartControl1.Refresh();
		}

		private void Depth1Check_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, Depth1Check.Checked);

			nChartControl1.Refresh();
		}

		private void Depth2Check_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, Depth2Check.Checked);

			nChartControl1.Refresh();
		}

		private void LeftMinor1Check_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfigurator.MinorGridStyle.SetShowAtWall(ChartWallType.Left, LeftMinor1Check.Checked);

			nChartControl1.Refresh();
		}

		private void LeftMinor2Check_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfigurator.MinorGridStyle.SetShowAtWall(ChartWallType.Back, LeftMinor2Check.Checked);

			nChartControl1.Refresh();
		}

		private void LeftMajorColor_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			colorDialog1.Color = scaleConfigurator.MajorGridStyle.LineStyle.Color;
			colorDialog1.ShowDialog();

			scaleConfigurator.MajorGridStyle.LineStyle.Color = colorDialog1.Color;
			nChartControl1.Refresh();
		}

		private void BottomColor_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			colorDialog1.Color = scaleConfigurator.MajorGridStyle.LineStyle.Color;
			colorDialog1.ShowDialog();

			scaleConfigurator.MajorGridStyle.LineStyle.Color = colorDialog1.Color;
			nChartControl1.Refresh();
		}

		private void DepthColor_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;

			colorDialog1.Color = scaleConfigurator.MajorGridStyle.LineStyle.Color;
			colorDialog1.ShowDialog();

			scaleConfigurator.MajorGridStyle.LineStyle.Color = colorDialog1.Color;
			nChartControl1.Refresh();
		}

		private void LeftMinorColor_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			colorDialog1.Color = scaleConfigurator.MinorGridStyle.LineStyle.Color;
			colorDialog1.ShowDialog();

			scaleConfigurator.MinorGridStyle.LineStyle.Color = colorDialog1.Color;
			nChartControl1.Refresh();
		}

		private void LeftMajorCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			LinePattern pattern = GetPatternFromIndex(LeftMajorCombo.SelectedIndex);
			scaleConfigurator.MajorGridStyle.LineStyle.Pattern = pattern;

			nChartControl1.Refresh();
		}

		private void BottomMajorCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			LinePattern pattern = GetPatternFromIndex(BottomMajorCombo.SelectedIndex);
			scaleConfigurator.MajorGridStyle.LineStyle.Pattern = pattern;
		
			nChartControl1.Refresh();
		}

		private void DepthMajorCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			LinePattern pattern = GetPatternFromIndex(DepthMajorCombo.SelectedIndex);

			scaleConfigurator.MajorGridStyle.LineStyle.Pattern = pattern;
		
			nChartControl1.Refresh();
		}

		private void LeftMinorCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			LinePattern pattern = GetPatternFromIndex(LeftMinorCombo.SelectedIndex);

			scaleConfigurator.MinorGridStyle.LineStyle.Pattern = pattern;
		
			nChartControl1.Refresh();
		}

		private LinePattern GetPatternFromIndex(int index)
		{
			switch(index)
			{
				case 0: return LinePattern.Dot;
				case 1: return LinePattern.Dash;
				case 2: return LinePattern.DashDot;
				case 3: return LinePattern.DashDotDot;
				case 4: return LinePattern.Solid;
				default: return LinePattern.Solid;
			}
		}
	}
}