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
	public class NStandardBubbleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox BubbleShapeCombo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NHScrollBar MinBubbleSizeScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar MaxBubbleSizeScroll;
		private Nevron.UI.WinForm.Controls.NCheckBox DifferentColors;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMargins;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox LegendFormatCombo;
		private Nevron.UI.WinForm.Controls.NButton BubbleFE;
		private Nevron.UI.WinForm.Controls.NCheckBox InvertAxisRuler;
		private Nevron.UI.WinForm.Controls.NButton BubbleBorderButton;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private System.ComponentModel.Container components = null;

		public NStandardBubbleUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.BubbleShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.MinBubbleSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.MaxBubbleSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.DifferentColors = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BubbleFE = new Nevron.UI.WinForm.Controls.NButton();
			this.InflateMargins = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LegendFormatCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.InvertAxisRuler = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BubbleBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bubble Shape:";
			// 
			// BubbleShapeCombo
			// 
			this.BubbleShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.BubbleShapeCombo.ListProperties.DataSource = null;
			this.BubbleShapeCombo.ListProperties.DisplayMember = "";
			this.BubbleShapeCombo.Location = new System.Drawing.Point(9, 28);
			this.BubbleShapeCombo.Name = "BubbleShapeCombo";
			this.BubbleShapeCombo.Size = new System.Drawing.Size(150, 21);
			this.BubbleShapeCombo.TabIndex = 1;
			this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleShapeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Min Bubble Size:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Max Bubble Size:";
			// 
			// MinBubbleSizeScroll
			// 
			this.MinBubbleSizeScroll.Location = new System.Drawing.Point(9, 75);
			this.MinBubbleSizeScroll.Maximum = 60;
			this.MinBubbleSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.MinBubbleSizeScroll.Name = "MinBubbleSizeScroll";
			this.MinBubbleSizeScroll.Size = new System.Drawing.Size(150, 16);
			this.MinBubbleSizeScroll.TabIndex = 4;
			this.MinBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MinBubbleSizeScroll_Scroll);
			// 
			// MaxBubbleSizeScroll
			// 
			this.MaxBubbleSizeScroll.Location = new System.Drawing.Point(9, 120);
			this.MaxBubbleSizeScroll.Maximum = 60;
			this.MaxBubbleSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.MaxBubbleSizeScroll.Name = "MaxBubbleSizeScroll";
			this.MaxBubbleSizeScroll.Size = new System.Drawing.Size(150, 16);
			this.MaxBubbleSizeScroll.TabIndex = 5;
			this.MaxBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MaxBubbleSizeScroll_Scroll);
			// 
			// DifferentColors
			// 
			this.DifferentColors.ButtonProperties.BorderOffset = 2;
			this.DifferentColors.Location = new System.Drawing.Point(9, 16);
			this.DifferentColors.Name = "DifferentColors";
			this.DifferentColors.Size = new System.Drawing.Size(132, 20);
			this.DifferentColors.TabIndex = 6;
			this.DifferentColors.Text = "Different Colors";
			this.DifferentColors.CheckedChanged += new System.EventHandler(this.DifferentColors_CheckedChanged);
			// 
			// BubbleFE
			// 
			this.BubbleFE.Location = new System.Drawing.Point(9, 39);
			this.BubbleFE.Name = "BubbleFE";
			this.BubbleFE.Size = new System.Drawing.Size(132, 23);
			this.BubbleFE.TabIndex = 7;
			this.BubbleFE.Text = "Bubble Fill Style...";
			this.BubbleFE.Click += new System.EventHandler(this.BubbleFE_Click);
			// 
			// InflateMargins
			// 
			this.InflateMargins.ButtonProperties.BorderOffset = 2;
			this.InflateMargins.Location = new System.Drawing.Point(9, 150);
			this.InflateMargins.Name = "InflateMargins";
			this.InflateMargins.Size = new System.Drawing.Size(150, 21);
			this.InflateMargins.TabIndex = 37;
			this.InflateMargins.Text = "Inflate Margins";
			this.InflateMargins.CheckedChanged += new System.EventHandler(this.InflateMargins_CheckedChanged);
			// 
			// LegendFormatCombo
			// 
			this.LegendFormatCombo.ListProperties.CheckBoxDataMember = "";
			this.LegendFormatCombo.ListProperties.DataSource = null;
			this.LegendFormatCombo.ListProperties.DisplayMember = "";
			this.LegendFormatCombo.Location = new System.Drawing.Point(9, 232);
			this.LegendFormatCombo.Name = "LegendFormatCombo";
			this.LegendFormatCombo.Size = new System.Drawing.Size(150, 21);
			this.LegendFormatCombo.TabIndex = 39;
			this.LegendFormatCombo.SelectedIndexChanged += new System.EventHandler(this.LegendFormatCombo_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 211);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(133, 16);
			this.label5.TabIndex = 40;
			this.label5.Text = "Legend Format:";
			// 
			// InvertAxisRuler
			// 
			this.InvertAxisRuler.ButtonProperties.BorderOffset = 2;
			this.InvertAxisRuler.Location = new System.Drawing.Point(9, 173);
			this.InvertAxisRuler.Name = "InvertAxisRuler";
			this.InvertAxisRuler.Size = new System.Drawing.Size(150, 21);
			this.InvertAxisRuler.TabIndex = 39;
			this.InvertAxisRuler.Text = "Invert Y Axis Ruler";
			this.InvertAxisRuler.CheckedChanged += new System.EventHandler(this.InvertAxisRuler_CheckedChanged);
			// 
			// BubbleBorderButton
			// 
			this.BubbleBorderButton.Location = new System.Drawing.Point(9, 68);
			this.BubbleBorderButton.Name = "BubbleBorderButton";
			this.BubbleBorderButton.Size = new System.Drawing.Size(132, 23);
			this.BubbleBorderButton.TabIndex = 40;
			this.BubbleBorderButton.Text = "Bubble Border...";
			this.BubbleBorderButton.Click += new System.EventHandler(this.BubbleBorderButton_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.BubbleFE);
			this.groupBox3.Controls.Add(this.BubbleBorderButton);
			this.groupBox3.Controls.Add(this.DifferentColors);
			this.groupBox3.ImageIndex = 0;
			this.groupBox3.Location = new System.Drawing.Point(9, 271);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(150, 100);
			this.groupBox3.TabIndex = 41;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Appearance";
			// 
			// NStandardBubbleUC
			// 
			this.Controls.Add(this.label5);
			this.Controls.Add(this.LegendFormatCombo);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.InvertAxisRuler);
			this.Controls.Add(this.InflateMargins);
			this.Controls.Add(this.MaxBubbleSizeScroll);
			this.Controls.Add(this.MinBubbleSizeScroll);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BubbleShapeCombo);
			this.Controls.Add(this.label1);
			this.Name = "NStandardBubbleUC";
			this.Size = new System.Drawing.Size(180, 389);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add a bubble series
			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.MinSize = new NLength(7.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.MaxSize = new NLength(16.0f, NRelativeUnit.ParentPercentage);

			m_Bubble.AddDataPoint(new NBubbleDataPoint(10, 10, "Company 1"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(15, 20, "Company 2"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(12, 25, "Company 3"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(8, 15, "Company 4"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(14, 17, "Company 5"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(11, 12, "Company 6"));
			
			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// init form controls
			BubbleShapeCombo.FillFromEnum(typeof(PointShape));
			BubbleShapeCombo.SelectedIndex = 6;

			LegendFormatCombo.Items.Add("Value and Label");
			LegendFormatCombo.Items.Add("Value");
			LegendFormatCombo.Items.Add("Label");
			LegendFormatCombo.Items.Add("Size");
			LegendFormatCombo.SelectedIndex = 2;

			InflateMargins.Checked = true;
            DifferentColors.Checked = true;
		}

		private void BubbleShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Bubble.BubbleShape = (PointShape)BubbleShapeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void MinBubbleSizeScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Bubble.MinSize = new NLength(MinBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}
		private void MaxBubbleSizeScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Bubble.MaxSize = new NLength(MaxBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}
		private void DifferentColors_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			if (DifferentColors.Checked)
			{
				BubbleFE.Enabled = false;
				BubbleBorderButton.Enabled = false;

				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				BubbleFE.Enabled = true;
				BubbleBorderButton.Enabled = true;

                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
                styleSheet.Apply(nChartControl1.Document);
			}

			nChartControl1.Refresh();
		}
		private void BubbleFE_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Bubble.FillStyle, out fillStyleResult))
			{
				m_Bubble.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BubbleBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Bubble.BorderStyle, out strokeStyleResult))
			{
				m_Bubble.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void InflateMargins_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Bubble.InflateMargins = InflateMargins.Checked;
			nChartControl1.Refresh();
		}
		private void LegendFormatCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			string sFormat = "";
			switch (LegendFormatCombo.SelectedIndex)
			{
				case 0:
					sFormat = "<value> <label>";
					break;
				case 1:
					sFormat = "<value>";
					break;
				case 2:
					sFormat = "<label>";
					break;
				case 3:
					sFormat = "<size>";
					break;
			}
			m_Bubble.Legend.Format = sFormat;
			nChartControl1.Refresh();
		}
		private void InvertAxisRuler_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfigurator.Invert = InvertAxisRuler.Checked;

			nChartControl1.Refresh();
		}
		private void LabelStyleButton_Click(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NDataLabelStyle styleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, out styleResult))
			{
				series.DataLabelStyle = styleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
