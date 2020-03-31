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
	public class NStripesUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftBeginScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftEndScroll;
		private Nevron.UI.WinForm.Controls.NButton LeftFillStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftShowAtBackCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftShowAtLeftCheck;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NCheckBox BottomShowAtFloorCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox BottomShowAtBackCheck;
		private Nevron.UI.WinForm.Controls.NButton BottomFillStyleButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomEndScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomBeginScroll;
		private UI.WinForm.Controls.NCheckBox LeftIncludeInAxisRangeCheckBox;
		private UI.WinForm.Controls.NCheckBox BottomIncludeInAxisRangeCheckBox;
		private System.ComponentModel.Container components = null;

		public NStripesUC()
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
			this.LeftBeginScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.LeftShowAtLeftCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LeftShowAtBackCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LeftFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LeftEndScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.BottomShowAtFloorCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BottomShowAtBackCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BottomFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BottomEndScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.BottomBeginScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.LeftIncludeInAxisRangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BottomIncludeInAxisRangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// LeftBeginScroll
			// 
			this.LeftBeginScroll.Location = new System.Drawing.Point(9, 45);
			this.LeftBeginScroll.Maximum = 130;
			this.LeftBeginScroll.Minimum = -20;
			this.LeftBeginScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LeftBeginScroll.Name = "LeftBeginScroll";
			this.LeftBeginScroll.Size = new System.Drawing.Size(128, 16);
			this.LeftBeginScroll.TabIndex = 0;
			this.LeftBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftBeginScroll_Scroll);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LeftIncludeInAxisRangeCheckBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.LeftShowAtLeftCheck);
			this.groupBox1.Controls.Add(this.LeftShowAtBackCheck);
			this.groupBox1.Controls.Add(this.LeftFillStyleButton);
			this.groupBox1.Controls.Add(this.LeftEndScroll);
			this.groupBox1.Controls.Add(this.LeftBeginScroll);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(8, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(151, 220);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Left Axis Stripe";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "End Value:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "Begin Value:";
			// 
			// LeftShowAtLeftCheck
			// 
			this.LeftShowAtLeftCheck.ButtonProperties.BorderOffset = 2;
			this.LeftShowAtLeftCheck.Location = new System.Drawing.Point(9, 185);
			this.LeftShowAtLeftCheck.Name = "LeftShowAtLeftCheck";
			this.LeftShowAtLeftCheck.Size = new System.Drawing.Size(128, 18);
			this.LeftShowAtLeftCheck.TabIndex = 4;
			this.LeftShowAtLeftCheck.Text = "Show At Left Wall";
			this.LeftShowAtLeftCheck.CheckedChanged += new System.EventHandler(this.LeftShowAtLeftCheck_CheckedChanged);
			// 
			// LeftShowAtBackCheck
			// 
			this.LeftShowAtBackCheck.ButtonProperties.BorderOffset = 2;
			this.LeftShowAtBackCheck.Location = new System.Drawing.Point(9, 160);
			this.LeftShowAtBackCheck.Name = "LeftShowAtBackCheck";
			this.LeftShowAtBackCheck.Size = new System.Drawing.Size(128, 20);
			this.LeftShowAtBackCheck.TabIndex = 3;
			this.LeftShowAtBackCheck.Text = "Show At Back Wall";
			this.LeftShowAtBackCheck.CheckedChanged += new System.EventHandler(this.LeftShowAtBackCheck_CheckedChanged);
			// 
			// LeftFillStyleButton
			// 
			this.LeftFillStyleButton.Location = new System.Drawing.Point(9, 133);
			this.LeftFillStyleButton.Name = "LeftFillStyleButton";
			this.LeftFillStyleButton.Size = new System.Drawing.Size(128, 22);
			this.LeftFillStyleButton.TabIndex = 2;
			this.LeftFillStyleButton.Text = "Stripe Fill Style...";
			this.LeftFillStyleButton.Click += new System.EventHandler(this.LeftFillStyleButton_Click);
			// 
			// LeftEndScroll
			// 
			this.LeftEndScroll.Location = new System.Drawing.Point(9, 87);
			this.LeftEndScroll.Maximum = 130;
			this.LeftEndScroll.Minimum = -20;
			this.LeftEndScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LeftEndScroll.Name = "LeftEndScroll";
			this.LeftEndScroll.Size = new System.Drawing.Size(128, 16);
			this.LeftEndScroll.TabIndex = 1;
			this.LeftEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftEndScroll_Scroll);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.BottomIncludeInAxisRangeCheckBox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.BottomShowAtFloorCheck);
			this.groupBox2.Controls.Add(this.BottomShowAtBackCheck);
			this.groupBox2.Controls.Add(this.BottomFillStyleButton);
			this.groupBox2.Controls.Add(this.BottomEndScroll);
			this.groupBox2.Controls.Add(this.BottomBeginScroll);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(8, 235);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(151, 220);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bottom Axis Stripe";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "End Value:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 17);
			this.label4.TabIndex = 12;
			this.label4.Text = "Begin Value:";
			// 
			// BottomShowAtFloorCheck
			// 
			this.BottomShowAtFloorCheck.ButtonProperties.BorderOffset = 2;
			this.BottomShowAtFloorCheck.Location = new System.Drawing.Point(9, 187);
			this.BottomShowAtFloorCheck.Name = "BottomShowAtFloorCheck";
			this.BottomShowAtFloorCheck.Size = new System.Drawing.Size(129, 19);
			this.BottomShowAtFloorCheck.TabIndex = 11;
			this.BottomShowAtFloorCheck.Text = "Show At Floor";
			this.BottomShowAtFloorCheck.CheckedChanged += new System.EventHandler(this.BottomShowAtFloorCheck_CheckedChanged);
			// 
			// BottomShowAtBackCheck
			// 
			this.BottomShowAtBackCheck.ButtonProperties.BorderOffset = 2;
			this.BottomShowAtBackCheck.Location = new System.Drawing.Point(9, 159);
			this.BottomShowAtBackCheck.Name = "BottomShowAtBackCheck";
			this.BottomShowAtBackCheck.Size = new System.Drawing.Size(128, 19);
			this.BottomShowAtBackCheck.TabIndex = 10;
			this.BottomShowAtBackCheck.Text = "Show At Back Wall";
			this.BottomShowAtBackCheck.CheckedChanged += new System.EventHandler(this.BottomShowAtBackCheck_CheckedChanged);
			// 
			// BottomFillStyleButton
			// 
			this.BottomFillStyleButton.Location = new System.Drawing.Point(9, 128);
			this.BottomFillStyleButton.Name = "BottomFillStyleButton";
			this.BottomFillStyleButton.Size = new System.Drawing.Size(128, 22);
			this.BottomFillStyleButton.TabIndex = 9;
			this.BottomFillStyleButton.Text = "Stripe Fill Style...";
			this.BottomFillStyleButton.Click += new System.EventHandler(this.BottomFillStyleButton_Click);
			// 
			// BottomEndScroll
			// 
			this.BottomEndScroll.Location = new System.Drawing.Point(9, 103);
			this.BottomEndScroll.Maximum = 130;
			this.BottomEndScroll.Minimum = -20;
			this.BottomEndScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BottomEndScroll.Name = "BottomEndScroll";
			this.BottomEndScroll.Size = new System.Drawing.Size(128, 16);
			this.BottomEndScroll.TabIndex = 8;
			this.BottomEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomEndScroll_Scroll);
			// 
			// BottomBeginScroll
			// 
			this.BottomBeginScroll.Location = new System.Drawing.Point(9, 49);
			this.BottomBeginScroll.Maximum = 130;
			this.BottomBeginScroll.Minimum = -20;
			this.BottomBeginScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BottomBeginScroll.Name = "BottomBeginScroll";
			this.BottomBeginScroll.Size = new System.Drawing.Size(128, 16);
			this.BottomBeginScroll.TabIndex = 7;
			this.BottomBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomBeginScroll_Scroll);
			// 
			// LeftIncludeInAxisRangeCheckBox
			// 
			this.LeftIncludeInAxisRangeCheckBox.ButtonProperties.BorderOffset = 2;
			this.LeftIncludeInAxisRangeCheckBox.Location = new System.Drawing.Point(9, 108);
			this.LeftIncludeInAxisRangeCheckBox.Name = "LeftIncludeInAxisRangeCheckBox";
			this.LeftIncludeInAxisRangeCheckBox.Size = new System.Drawing.Size(128, 20);
			this.LeftIncludeInAxisRangeCheckBox.TabIndex = 7;
			this.LeftIncludeInAxisRangeCheckBox.Text = "Include in axis range";
			this.LeftIncludeInAxisRangeCheckBox.CheckedChanged += new System.EventHandler(this.LeftIncludeInAxisRangeCheckBox_CheckedChanged);
			// 
			// BottomIncludeInAxisRangeCheckBox
			// 
			this.BottomIncludeInAxisRangeCheckBox.ButtonProperties.BorderOffset = 2;
			this.BottomIncludeInAxisRangeCheckBox.Location = new System.Drawing.Point(9, 74);
			this.BottomIncludeInAxisRangeCheckBox.Name = "BottomIncludeInAxisRangeCheckBox";
			this.BottomIncludeInAxisRangeCheckBox.Size = new System.Drawing.Size(128, 20);
			this.BottomIncludeInAxisRangeCheckBox.TabIndex = 8;
			this.BottomIncludeInAxisRangeCheckBox.Text = "Include in axis range";
			this.BottomIncludeInAxisRangeCheckBox.CheckedChanged += new System.EventHandler(this.BottomIncludeInAxisRange_CheckedChanged);
			// 
			// NStripesUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NStripesUC";
			this.Size = new System.Drawing.Size(169, 463);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Stripes");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;

            // apply predefined lighting and projection
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = new NLinearScaleConfigurator();

            // configure the x and y scales
            NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            yScale.StripStyles.Add(stripStyle);

            // display major grid lines at back and left walls
            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;

            NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;

			// Create a point series
			NPointSeries pnt = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			pnt.InflateMargins = true;
			pnt.UseXValues = true;
			pnt.Name = "Series 1";
			pnt.DataLabelStyle.Format = "<value>";

			// Add some data
			pnt.Values.Add(3.1);
			pnt.Values.Add(6.7);
			pnt.Values.Add(1.2);
			pnt.Values.Add(8.4);
			pnt.Values.Add(9.0);
			pnt.XValues.Add(0.5);
			pnt.XValues.Add(1.8);
			pnt.XValues.Add(2.6);
			pnt.XValues.Add(3.1);
			pnt.XValues.Add(4.4);

			// Add stripes for the left and the bottom axes
			NAxisStripe s1 = m_Chart.Axis(StandardAxis.PrimaryY).Stripes.Add(2, 3);
            s1.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.SteelBlue));
			NAxisStripe s2 = m_Chart.Axis(StandardAxis.PrimaryX).Stripes.Add(2, 3);
            s2.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.SteelBlue));

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LeftBeginScroll.Value = (int)(s1.From * 10);
			LeftEndScroll.Value = (int)(s1.To * 10);
			BottomBeginScroll.Value = (int)(s2.From * 20);
			BottomEndScroll.Value = (int)(s2.To * 20);

			LeftShowAtBackCheck.Checked = true;
			LeftShowAtLeftCheck.Checked = true;
			BottomShowAtBackCheck.Checked = true;
			BottomShowAtFloorCheck.Checked = true;

			nChartControl1.Refresh();
		}

		private void LeftBeginScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];

			stripe.From = LeftBeginScroll.Value / 10.0;

			nChartControl1.Refresh();
		}

		private void LeftEndScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];

			stripe.To = LeftEndScroll.Value / 10.0;

			nChartControl1.Refresh();
		}

		private void BottomBeginScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];

			stripe.From = BottomBeginScroll.Value / 20.0;

			nChartControl1.Refresh();
		}

		private void BottomEndScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];

			stripe.To = BottomEndScroll.Value / 20.0;

			nChartControl1.Refresh();
		}

		private void LeftFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(stripe.FillStyle, out fillStyleResult))
			{
				stripe.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BottomFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(stripe.FillStyle, out fillStyleResult))
			{
				stripe.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LeftShowAtBackCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];

			stripe.SetShowAtWall(ChartWallType.Back, LeftShowAtBackCheck.Checked);

			nChartControl1.Refresh();
		}

		private void LeftShowAtLeftCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];

			stripe.SetShowAtWall(ChartWallType.Left, LeftShowAtLeftCheck.Checked);

			nChartControl1.Refresh();
		}

		private void BottomShowAtBackCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];

			stripe.SetShowAtWall(ChartWallType.Back, BottomShowAtBackCheck.Checked);

			nChartControl1.Refresh();
		}

		private void BottomShowAtFloorCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];

			stripe.SetShowAtWall(ChartWallType.Floor, BottomShowAtFloorCheck.Checked);

			nChartControl1.Refresh();
		}

		private void BottomIncludeInAxisRange_CheckedChanged(object sender, EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];

			stripe.IncludeFromValueInAxisRange = BottomIncludeInAxisRangeCheckBox.Checked;
			stripe.IncludeToValueInAxisRange = BottomIncludeInAxisRangeCheckBox.Checked;

			nChartControl1.Refresh();
		}

		private void LeftIncludeInAxisRangeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];			

			stripe.IncludeFromValueInAxisRange = LeftIncludeInAxisRangeCheckBox.Checked;
			stripe.IncludeToValueInAxisRange = LeftIncludeInAxisRangeCheckBox.Checked;

			nChartControl1.Refresh();
		}
	}
}