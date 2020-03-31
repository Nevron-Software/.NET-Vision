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
	public class NAxisValueCrossingUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftAxisScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomAxisScroll;
		private System.Windows.Forms.Label LeftAxisLabel;
		private System.Windows.Forms.Label BottomAxisLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftUsePositionCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox BottomUsePositionCheck;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.ComponentModel.Container components = null;

		public NAxisValueCrossingUC()
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
			this.LeftAxisScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.LeftAxisLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.LeftUsePositionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BottomUsePositionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BottomAxisLabel = new System.Windows.Forms.Label();
			this.BottomAxisScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// LeftAxisScroll
			// 
			this.LeftAxisScroll.LargeChange = 1;
			this.LeftAxisScroll.Location = new System.Drawing.Point(8, 71);
			this.LeftAxisScroll.Maximum = 20;
			this.LeftAxisScroll.Minimum = -20;
			this.LeftAxisScroll.Name = "LeftAxisScroll";
			this.LeftAxisScroll.Size = new System.Drawing.Size(118, 16);
			this.LeftAxisScroll.TabIndex = 0;
			this.LeftAxisScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftAxisScroll_Scroll);
			// 
			// LeftAxisLabel
			// 
			this.LeftAxisLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.LeftAxisLabel.Location = new System.Drawing.Point(133, 71);
			this.LeftAxisLabel.Name = "LeftAxisLabel";
			this.LeftAxisLabel.Size = new System.Drawing.Size(32, 17);
			this.LeftAxisLabel.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(147, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Position Value:";
			// 
			// LeftUsePositionCheck
			// 
			this.LeftUsePositionCheck.Location = new System.Drawing.Point(8, 19);
			this.LeftUsePositionCheck.Name = "LeftUsePositionCheck";
			this.LeftUsePositionCheck.Size = new System.Drawing.Size(112, 20);
			this.LeftUsePositionCheck.TabIndex = 6;
			this.LeftUsePositionCheck.Text = "Use Position";
			this.LeftUsePositionCheck.CheckedChanged += new System.EventHandler(this.LeftUsePositionCheck_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LeftAxisScroll);
			this.groupBox1.Controls.Add(this.LeftAxisLabel);
			this.groupBox1.Controls.Add(this.LeftUsePositionCheck);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 112);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Left Axis";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.BottomUsePositionCheck);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.BottomAxisLabel);
			this.groupBox2.Controls.Add(this.BottomAxisScroll);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(7, 128);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(176, 112);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bottom Axis";
			// 
			// BottomUsePositionCheck
			// 
			this.BottomUsePositionCheck.Location = new System.Drawing.Point(8, 19);
			this.BottomUsePositionCheck.Name = "BottomUsePositionCheck";
			this.BottomUsePositionCheck.Size = new System.Drawing.Size(91, 21);
			this.BottomUsePositionCheck.TabIndex = 11;
			this.BottomUsePositionCheck.Text = "Use Position";
			this.BottomUsePositionCheck.CheckedChanged += new System.EventHandler(this.BottomUsePositionCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(153, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Position Value:";
			// 
			// BottomAxisLabel
			// 
			this.BottomAxisLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.BottomAxisLabel.Location = new System.Drawing.Point(133, 71);
			this.BottomAxisLabel.Name = "BottomAxisLabel";
			this.BottomAxisLabel.Size = new System.Drawing.Size(32, 17);
			this.BottomAxisLabel.TabIndex = 9;
			// 
			// BottomAxisScroll
			// 
			this.BottomAxisScroll.LargeChange = 1;
			this.BottomAxisScroll.Location = new System.Drawing.Point(8, 71);
			this.BottomAxisScroll.Maximum = 20;
			this.BottomAxisScroll.Minimum = -20;
			this.BottomAxisScroll.Name = "BottomAxisScroll";
			this.BottomAxisScroll.Size = new System.Drawing.Size(118, 16);
			this.BottomAxisScroll.TabIndex = 8;
			this.BottomAxisScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomAxisScroll_Scroll);
			// 
			// NAxisValueCrossingUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NAxisValueCrossingUC";
			this.Size = new System.Drawing.Size(191, 250);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Value Crossing <br/> <font size = '9pt'>Demonstrates how to use of the value cross anchor</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);

			// configure scales
			NLinearScaleConfigurator yScaleConfigurator = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle yStripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            yStripStyle.SetShowAtWall(ChartWallType.Back, true);
            yStripStyle.Interlaced = true;
            yScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            yScaleConfigurator.StripStyles.Add(yStripStyle);

			NLinearScaleConfigurator xScaleConfigurator = new NLinearScaleConfigurator();
            NScaleStripStyle xStripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            xStripStyle.SetShowAtWall(ChartWallType.Back, true);
            xStripStyle.Interlaced = true;
            xScaleConfigurator.StripStyles.Add(xStripStyle);
            xScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScaleConfigurator;

			// cross X and Y axes
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor = new NCrossAxisAnchor(AxisOrientation.Horizontal, new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), 0));
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor.RulerOrientation = RulerOrientation.Right;
			m_Chart.Axis(StandardAxis.PrimaryY).Anchor = new NCrossAxisAnchor(AxisOrientation.Vertical, new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), 0));

			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;

			// setup bubble series
			NBubbleSeries bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			bubble.Name = "Bubble Series";
			bubble.InflateMargins = true;
			bubble.DataLabelStyle.Visible = false;
			bubble.UseXValues = true;
			bubble.BubbleShape = PointShape.Sphere;

			// fill with random data
			bubble.Values.FillRandomRange(Random, 10, -20, 20);
			bubble.XValues.FillRandomRange(Random, 10, -20, 20);
			bubble.Sizes.FillRandomRange(Random, 10, 1, 6);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LeftAxisScroll.Minimum = -30;
			LeftAxisScroll.Maximum = 30;
			LeftAxisScroll.Value = 0;

			BottomAxisScroll.Minimum = -30;
			BottomAxisScroll.Maximum = 30;
			BottomAxisScroll.Value = 0;

			LeftAxisLabel.Text = LeftAxisScroll.Value.ToString();
			BottomAxisLabel.Text = BottomAxisScroll.Value.ToString();

			LeftUsePositionCheck.Checked = true;
			BottomUsePositionCheck.Checked = true;
		}

		private void LeftAxisScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			LeftAxisLabel.Text = LeftAxisScroll.Value.ToString();

			double posValue = (double) LeftAxisScroll.Value;

			NCrossAxisAnchor crossAnchor = m_Chart.Axis(StandardAxis.PrimaryY).Anchor as NCrossAxisAnchor;

			if (crossAnchor != null)
			{
				((NValueAxisCrossing)crossAnchor.Crossings[0]).Value = posValue;
				nChartControl1.Refresh();
			}
		}

		private void BottomAxisScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			BottomAxisLabel.Text = BottomAxisScroll.Value.ToString();

			double posValue = (double) BottomAxisScroll.Value;

			NCrossAxisAnchor crossAnchor = m_Chart.Axis(StandardAxis.PrimaryX).Anchor as NCrossAxisAnchor;

			if (crossAnchor != null)
			{
				((NValueAxisCrossing)crossAnchor.Crossings[0]).Value = posValue;
				nChartControl1.Refresh();
			}
		}

		private void LeftUsePositionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			LeftAxisScroll.Enabled = LeftUsePositionCheck.Checked;

			if(LeftUsePositionCheck.Checked)
			{
				double posValue = (double) LeftAxisScroll.Value;
				m_Chart.Axis(StandardAxis.PrimaryY).Anchor = new NCrossAxisAnchor(AxisOrientation.Vertical, new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), posValue));
			}
			else
			{
				m_Chart.Axis(StandardAxis.PrimaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, true);
			}

			nChartControl1.Refresh();
		}

		private void BottomUsePositionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			BottomAxisScroll.Enabled = BottomUsePositionCheck.Checked;

			if(BottomUsePositionCheck.Checked)
			{
				double posValue = (double) BottomAxisScroll.Value;
				m_Chart.Axis(StandardAxis.PrimaryX).Anchor = new NCrossAxisAnchor(AxisOrientation.Horizontal, new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), posValue));
				m_Chart.Axis(StandardAxis.PrimaryX).Anchor.RulerOrientation = RulerOrientation.Right;
			}
			else
			{
				m_Chart.Axis(StandardAxis.PrimaryX).Anchor = new NDockAxisAnchor(AxisDockZone.FrontBottom, true);
			}

			nChartControl1.Refresh();
		}
	}
}