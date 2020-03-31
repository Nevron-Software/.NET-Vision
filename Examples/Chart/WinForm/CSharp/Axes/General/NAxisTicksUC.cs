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
	public class NAxisTicksUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NButton OuterMajorTickColorButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar OuterMajorTickLengthScrollBar;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowOuterMajorTicksCheckBox;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowInnerMajorTicksCheckBox;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton InnerMajorTickColorButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar InnerMajorTickLengthScrollBar;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox4;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowOuterMinorTicksCheckBox;
		private Nevron.UI.WinForm.Controls.NHScrollBar OuterMinorTickLengthScrollBar;
		private Nevron.UI.WinForm.Controls.NButton OuterMinorTickColorButton;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowInnerMinorTicksCheckBox;
		private Nevron.UI.WinForm.Controls.NHScrollBar InnerMinorTickLengthScrollBar;
		private Nevron.UI.WinForm.Controls.NButton InnerMinorTickColorButton;
		private System.ComponentModel.Container components = null;

		public NAxisTicksUC()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NAxisTicksUC));
			this.colorDialog1 = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ShowOuterMajorTicksCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.OuterMajorTickColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.OuterMajorTickLengthScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ShowInnerMajorTicksCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.InnerMajorTickColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.InnerMajorTickLengthScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ShowOuterMinorTicksCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.OuterMinorTickColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.OuterMinorTickLengthScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nGroupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ShowInnerMinorTicksCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.InnerMinorTickColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.InnerMinorTickLengthScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			this.nGroupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// colorDialog1
			// 
			this.colorDialog1.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.colorDialog1.ClientSize = new System.Drawing.Size(396, 324);
			this.colorDialog1.Color = System.Drawing.Color.Empty;
			this.colorDialog1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.colorDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("colorDialog1.Icon")));
			this.colorDialog1.Location = new System.Drawing.Point(88, 88);
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
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.ShowOuterMajorTicksCheckBox);
			this.nGroupBox1.Controls.Add(this.label6);
			this.nGroupBox1.Controls.Add(this.OuterMajorTickColorButton);
			this.nGroupBox1.Controls.Add(this.OuterMajorTickLengthScrollBar);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(5, 6);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(149, 133);
			this.nGroupBox1.TabIndex = 16;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Major Outer Ticks";
			// 
			// ShowOuterMajorTicksCheckBox
			// 
			this.ShowOuterMajorTicksCheckBox.Location = new System.Drawing.Point(10, 22);
			this.ShowOuterMajorTicksCheckBox.Name = "ShowOuterMajorTicksCheckBox";
			this.ShowOuterMajorTicksCheckBox.Size = new System.Drawing.Size(116, 22);
			this.ShowOuterMajorTicksCheckBox.TabIndex = 0;
			this.ShowOuterMajorTicksCheckBox.Text = "Show Ticks";
			this.ShowOuterMajorTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowOuterMajorTicksCheckBox_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 19);
			this.label6.TabIndex = 1;
			this.label6.Text = "Tick Length:";
			// 
			// OuterMajorTickColorButton
			// 
			this.OuterMajorTickColorButton.Location = new System.Drawing.Point(8, 96);
			this.OuterMajorTickColorButton.Name = "OuterMajorTickColorButton";
			this.OuterMajorTickColorButton.Size = new System.Drawing.Size(125, 22);
			this.OuterMajorTickColorButton.TabIndex = 3;
			this.OuterMajorTickColorButton.Text = "Tick Color";
			this.OuterMajorTickColorButton.Click += new System.EventHandler(this.OuterMajorTickColorButton_Click);
			// 
			// OuterMajorTickLengthScrollBar
			// 
			this.OuterMajorTickLengthScrollBar.LargeChange = 2;
			this.OuterMajorTickLengthScrollBar.Location = new System.Drawing.Point(8, 72);
			this.OuterMajorTickLengthScrollBar.Maximum = 20;
			this.OuterMajorTickLengthScrollBar.Name = "OuterMajorTickLengthScrollBar";
			this.OuterMajorTickLengthScrollBar.Size = new System.Drawing.Size(116, 16);
			this.OuterMajorTickLengthScrollBar.TabIndex = 2;
			this.OuterMajorTickLengthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.OuterMajorTickLengthScrollBar_ValueChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.ShowInnerMajorTicksCheckBox);
			this.nGroupBox2.Controls.Add(this.label1);
			this.nGroupBox2.Controls.Add(this.InnerMajorTickColorButton);
			this.nGroupBox2.Controls.Add(this.InnerMajorTickLengthScrollBar);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(5, 150);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(149, 133);
			this.nGroupBox2.TabIndex = 17;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Major Inner Ticks";
			// 
			// ShowInnerMajorTicksCheckBox
			// 
			this.ShowInnerMajorTicksCheckBox.Location = new System.Drawing.Point(10, 22);
			this.ShowInnerMajorTicksCheckBox.Name = "ShowInnerMajorTicksCheckBox";
			this.ShowInnerMajorTicksCheckBox.Size = new System.Drawing.Size(116, 22);
			this.ShowInnerMajorTicksCheckBox.TabIndex = 0;
			this.ShowInnerMajorTicksCheckBox.Text = "Show Ticks";
			this.ShowInnerMajorTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowInnerMajorTicksCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Tick Length:";
			// 
			// InnerMajorTickColorButton
			// 
			this.InnerMajorTickColorButton.Location = new System.Drawing.Point(8, 96);
			this.InnerMajorTickColorButton.Name = "InnerMajorTickColorButton";
			this.InnerMajorTickColorButton.Size = new System.Drawing.Size(125, 22);
			this.InnerMajorTickColorButton.TabIndex = 3;
			this.InnerMajorTickColorButton.Text = "Tick Color";
			this.InnerMajorTickColorButton.Click += new System.EventHandler(this.InnerMajorTickColorButton_Click);
			// 
			// InnerMajorTickLengthScrollBar
			// 
			this.InnerMajorTickLengthScrollBar.LargeChange = 2;
			this.InnerMajorTickLengthScrollBar.Location = new System.Drawing.Point(8, 72);
			this.InnerMajorTickLengthScrollBar.Maximum = 20;
			this.InnerMajorTickLengthScrollBar.Name = "InnerMajorTickLengthScrollBar";
			this.InnerMajorTickLengthScrollBar.Size = new System.Drawing.Size(116, 16);
			this.InnerMajorTickLengthScrollBar.TabIndex = 2;
			this.InnerMajorTickLengthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.InnerMajorTickLengthScrollBar_ValueChanged);
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.ShowOuterMinorTicksCheckBox);
			this.nGroupBox3.Controls.Add(this.label2);
			this.nGroupBox3.Controls.Add(this.OuterMinorTickColorButton);
			this.nGroupBox3.Controls.Add(this.OuterMinorTickLengthScrollBar);
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(5, 294);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(149, 133);
			this.nGroupBox3.TabIndex = 18;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Minor Outer Ticks";
			// 
			// ShowOuterMinorTicksCheckBox
			// 
			this.ShowOuterMinorTicksCheckBox.Location = new System.Drawing.Point(10, 22);
			this.ShowOuterMinorTicksCheckBox.Name = "ShowOuterMinorTicksCheckBox";
			this.ShowOuterMinorTicksCheckBox.Size = new System.Drawing.Size(116, 22);
			this.ShowOuterMinorTicksCheckBox.TabIndex = 0;
			this.ShowOuterMinorTicksCheckBox.Text = "Show Ticks";
			this.ShowOuterMinorTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowOuterMinorTicksCheckBox_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tick Length:";
			// 
			// OuterMinorTickColorButton
			// 
			this.OuterMinorTickColorButton.Location = new System.Drawing.Point(8, 96);
			this.OuterMinorTickColorButton.Name = "OuterMinorTickColorButton";
			this.OuterMinorTickColorButton.Size = new System.Drawing.Size(125, 22);
			this.OuterMinorTickColorButton.TabIndex = 3;
			this.OuterMinorTickColorButton.Text = "Tick Color";
			this.OuterMinorTickColorButton.Click += new System.EventHandler(this.OuterMinorTickColorButton_Click);
			// 
			// OuterMinorTickLengthScrollBar
			// 
			this.OuterMinorTickLengthScrollBar.LargeChange = 2;
			this.OuterMinorTickLengthScrollBar.Location = new System.Drawing.Point(8, 72);
			this.OuterMinorTickLengthScrollBar.Maximum = 20;
			this.OuterMinorTickLengthScrollBar.Name = "OuterMinorTickLengthScrollBar";
			this.OuterMinorTickLengthScrollBar.Size = new System.Drawing.Size(116, 16);
			this.OuterMinorTickLengthScrollBar.TabIndex = 2;
			this.OuterMinorTickLengthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.OuterMinorTickLengthScrollBar_ValueChanged);
			// 
			// nGroupBox4
			// 
			this.nGroupBox4.Controls.Add(this.ShowInnerMinorTicksCheckBox);
			this.nGroupBox4.Controls.Add(this.label3);
			this.nGroupBox4.Controls.Add(this.InnerMinorTickColorButton);
			this.nGroupBox4.Controls.Add(this.InnerMinorTickLengthScrollBar);
			this.nGroupBox4.ImageIndex = 0;
			this.nGroupBox4.Location = new System.Drawing.Point(5, 438);
			this.nGroupBox4.Name = "nGroupBox4";
			this.nGroupBox4.Size = new System.Drawing.Size(149, 133);
			this.nGroupBox4.TabIndex = 19;
			this.nGroupBox4.TabStop = false;
			this.nGroupBox4.Text = "Minor Inner Ticks";
			// 
			// ShowInnerMinorTicksCheckBox
			// 
			this.ShowInnerMinorTicksCheckBox.Location = new System.Drawing.Point(10, 22);
			this.ShowInnerMinorTicksCheckBox.Name = "ShowInnerMinorTicksCheckBox";
			this.ShowInnerMinorTicksCheckBox.Size = new System.Drawing.Size(116, 22);
			this.ShowInnerMinorTicksCheckBox.TabIndex = 0;
			this.ShowInnerMinorTicksCheckBox.Text = "Show Ticks";
			this.ShowInnerMinorTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowInnerMinorTicksCheckBox_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "Tick Length:";
			// 
			// InnerMinorTickColorButton
			// 
			this.InnerMinorTickColorButton.Location = new System.Drawing.Point(8, 96);
			this.InnerMinorTickColorButton.Name = "InnerMinorTickColorButton";
			this.InnerMinorTickColorButton.Size = new System.Drawing.Size(125, 22);
			this.InnerMinorTickColorButton.TabIndex = 3;
			this.InnerMinorTickColorButton.Text = "Tick Color";
			this.InnerMinorTickColorButton.Click += new System.EventHandler(this.InnerMinorTickColorButton_Click);
			// 
			// InnerMinorTickLengthScrollBar
			// 
			this.InnerMinorTickLengthScrollBar.LargeChange = 2;
			this.InnerMinorTickLengthScrollBar.Location = new System.Drawing.Point(8, 72);
			this.InnerMinorTickLengthScrollBar.Maximum = 20;
			this.InnerMinorTickLengthScrollBar.Name = "InnerMinorTickLengthScrollBar";
			this.InnerMinorTickLengthScrollBar.Size = new System.Drawing.Size(116, 16);
			this.InnerMinorTickLengthScrollBar.TabIndex = 2;
			this.InnerMinorTickLengthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.InnerMinorTickLengthScrollBar_ValueChanged);
			// 
			// NAxisTicksUC
			// 
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox4);
			this.Controls.Add(this.nGroupBox3);
			this.Name = "NAxisTicksUC";
			this.Size = new System.Drawing.Size(159, 587);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			this.nGroupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Ticks");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MinorTickCount = 3;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.Values.FillRandom(Random, 5);
			bar.FillStyle = new NColorFillStyle(Color.DarkOrchid);
			bar.DataLabelStyle.Format = "<value>";
			bar.Name = "Bars";

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			OuterMajorTickLengthScrollBar.Value = (int)(linearScale.OuterMajorTickStyle.Length.Value);
			InnerMajorTickLengthScrollBar.Value = (int)(linearScale.InnerMajorTickStyle.Length.Value);
			OuterMinorTickLengthScrollBar.Value = (int)(linearScale.OuterMinorTickStyle.Length.Value);
			InnerMinorTickLengthScrollBar.Value = (int)(linearScale.InnerMinorTickStyle.Length.Value);

			ShowOuterMajorTicksCheckBox.Checked = true;
			ShowInnerMajorTicksCheckBox.Checked = true;
			ShowOuterMinorTicksCheckBox.Checked = true;
			ShowInnerMinorTicksCheckBox.Checked = true;
		}

		private void ShowOuterMajorTicksCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			int width = ShowOuterMajorTicksCheckBox.Checked ? OuterMajorTickLengthScrollBar.Value : 0;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.OuterMajorTickStyle.Length = new NLength(width, linearScale.OuterMajorTickStyle.Length.MeasurementUnit);

			nChartControl1.Refresh();
	
		}

		private void OuterMajorTickLengthScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.OuterMajorTickStyle.Length = new NLength(OuterMajorTickLengthScrollBar.Value, linearScale.OuterMajorTickStyle.Length.MeasurementUnit);

			nChartControl1.Refresh();
		}

		private void OuterMajorTickColorButton_Click(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			colorDialog1.Color = linearScale.OuterMajorTickStyle.LineStyle.Color;

			colorDialog1.ShowDialog();

			linearScale.OuterMajorTickStyle.LineStyle.Color = colorDialog1.Color;

			nChartControl1.Refresh();
		}

		private void ShowInnerMajorTicksCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			int width = ShowInnerMajorTicksCheckBox.Checked ? InnerMajorTickLengthScrollBar.Value : 0;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.InnerMajorTickStyle.Length = new NLength(width, linearScale.InnerMajorTickStyle.Length.MeasurementUnit);
		
			nChartControl1.Refresh();
		}

		private void InnerMajorTickLengthScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.InnerMajorTickStyle.Length = new NLength(InnerMajorTickLengthScrollBar.Value, linearScale.InnerMajorTickStyle.Length.MeasurementUnit);

			nChartControl1.Refresh();
		}

		private void InnerMajorTickColorButton_Click(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			colorDialog1.Color = linearScale.InnerMajorTickStyle.LineStyle.Color;

			colorDialog1.ShowDialog();
			linearScale.InnerMajorTickStyle.LineStyle.Color = colorDialog1.Color;

			nChartControl1.Refresh();
		}

		private void ShowOuterMinorTicksCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			int width = ShowOuterMinorTicksCheckBox.Checked ? OuterMinorTickLengthScrollBar.Value : 0;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.OuterMinorTickStyle.Length = new NLength(width, linearScale.OuterMinorTickStyle.Length.MeasurementUnit);
		
			nChartControl1.Refresh();
		}

		private void OuterMinorTickLengthScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.OuterMinorTickStyle.Length = new NLength(OuterMinorTickLengthScrollBar.Value, linearScale.OuterMinorTickStyle.Length.MeasurementUnit);

			nChartControl1.Refresh();
		}

		private void OuterMinorTickColorButton_Click(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			colorDialog1.Color = linearScale.OuterMinorTickStyle.LineStyle.Color;

			colorDialog1.ShowDialog();

			linearScale.OuterMinorTickStyle.LineStyle.Color = colorDialog1.Color;

			nChartControl1.Refresh();
		}

		private void ShowInnerMinorTicksCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			int width = ShowInnerMinorTicksCheckBox.Checked ? InnerMinorTickLengthScrollBar.Value : 0;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.InnerMinorTickStyle.Length = new NLength(width, linearScale.InnerMinorTickStyle.Length.MeasurementUnit);
		
			nChartControl1.Refresh();
		}

		private void InnerMinorTickLengthScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.InnerMinorTickStyle.Length = new NLength(InnerMinorTickLengthScrollBar.Value, linearScale.InnerMinorTickStyle.Length.MeasurementUnit);

			nChartControl1.Refresh();
		}

		private void InnerMinorTickColorButton_Click(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			colorDialog1.Color = linearScale.InnerMinorTickStyle.LineStyle.Color;

			colorDialog1.ShowDialog();

			linearScale.InnerMinorTickStyle.LineStyle.Color = colorDialog1.Color;

			nChartControl1.Refresh();
		}


	}
}
