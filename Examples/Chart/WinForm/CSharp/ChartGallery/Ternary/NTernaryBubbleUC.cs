using Nevron.Chart;
using Nevron.Editors;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTernaryBubbleUC : NExampleBaseUC
	{
		private NTernaryBubbleSeries m_BubbleSeries;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox BubbleShapeCombo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NHScrollBar MinBubbleSizeScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar MaxBubbleSizeScroll;
		private Nevron.UI.WinForm.Controls.NCheckBox DifferentColors;
		private Nevron.UI.WinForm.Controls.NButton BubbleFE;
		private Nevron.UI.WinForm.Controls.NButton BubbleBorderButton;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private System.ComponentModel.Container components = null;

		public NTernaryBubbleUC()
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
			this.label3.TabIndex = 4;
			this.label3.Text = "Max Bubble Size:";
			// 
			// MinBubbleSizeScroll
			// 
			this.MinBubbleSizeScroll.Location = new System.Drawing.Point(9, 75);
			this.MinBubbleSizeScroll.Maximum = 60;
			this.MinBubbleSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.MinBubbleSizeScroll.Name = "MinBubbleSizeScroll";
			this.MinBubbleSizeScroll.Size = new System.Drawing.Size(150, 16);
			this.MinBubbleSizeScroll.TabIndex = 3;
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
			this.DifferentColors.TabIndex = 0;
			this.DifferentColors.Text = "Different Colors";
			this.DifferentColors.CheckedChanged += new System.EventHandler(this.DifferentColors_CheckedChanged);
			// 
			// BubbleFE
			// 
			this.BubbleFE.Location = new System.Drawing.Point(9, 39);
			this.BubbleFE.Name = "BubbleFE";
			this.BubbleFE.Size = new System.Drawing.Size(132, 23);
			this.BubbleFE.TabIndex = 1;
			this.BubbleFE.Text = "Bubble Fill Style...";
			this.BubbleFE.Click += new System.EventHandler(this.BubbleFE_Click);
			// 
			// BubbleBorderButton
			// 
			this.BubbleBorderButton.Location = new System.Drawing.Point(9, 68);
			this.BubbleBorderButton.Name = "BubbleBorderButton";
			this.BubbleBorderButton.Size = new System.Drawing.Size(132, 23);
			this.BubbleBorderButton.TabIndex = 2;
			this.BubbleBorderButton.Text = "Bubble Border...";
			this.BubbleBorderButton.Click += new System.EventHandler(this.BubbleBorderButton_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.BubbleFE);
			this.groupBox3.Controls.Add(this.BubbleBorderButton);
			this.groupBox3.Controls.Add(this.DifferentColors);
			this.groupBox3.ImageIndex = 0;
			this.groupBox3.Location = new System.Drawing.Point(9, 151);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(150, 100);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Appearance";
			// 
			// NTernaryBubbleUC
			// 
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.MaxBubbleSizeScroll);
			this.Controls.Add(this.MinBubbleSizeScroll);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BubbleShapeCombo);
			this.Controls.Add(this.label1);
			this.Name = "NTernaryBubbleUC";
			this.Size = new System.Drawing.Size(180, 389);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Ternary Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			NLegend legend = new NLegend();
			nChartControl1.Panels.Add(legend);

			// setup chart
			NTernaryChart ternaryChart = new NTernaryChart();
			nChartControl1.Panels.Add(ternaryChart);
			ternaryChart.DisplayOnLegend = legend;

			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryA));
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryB));
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryC));

			// add a bubble series
			m_BubbleSeries = new NTernaryBubbleSeries();
			ternaryChart.Series.Add(m_BubbleSeries);
			m_BubbleSeries.DataLabelStyle.VertAlign = VertAlign.Center;
			m_BubbleSeries.DataLabelStyle.Visible = false;
			m_BubbleSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			m_BubbleSeries.MinSize = new NLength(2.0f, NGraphicsUnit.Point);
			m_BubbleSeries.MaxSize = new NLength(20, NGraphicsUnit.Point);
			m_BubbleSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			m_BubbleSeries.Legend.Format = "<size>";

			Random rand = new Random();
			for (int i = 0; i < 20; i++)
			{
				// will be automatically normalized so that the sum of a, b, c value is 100
				double aValue = rand.Next(100);
				double bValue = rand.Next(100);
				double cValue = rand.Next(100);

				m_BubbleSeries.AValues.Add(aValue);
				m_BubbleSeries.BValues.Add(bValue);
				m_BubbleSeries.CValues.Add(cValue);
				m_BubbleSeries.Sizes.Add(10 + rand.Next(90));
			}

			// apply layout
			ConfigureStandardLayout(ternaryChart, title, nChartControl1.Legends[0]);

			// init form controls
			BubbleShapeCombo.FillFromEnum(typeof(PointShape));
			BubbleShapeCombo.SelectedIndex = 6;

            DifferentColors.Checked = true;
		}

		private void ConfigureAxis(NAxis axis)
		{
			NLinearScaleConfigurator linearScale = axis.ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(25, Color.Beige)), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Ternary, true);
			linearScale.StripStyles.Add(stripStyle);

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Ternary, true);
		}

		private void BubbleShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_BubbleSeries.Shape = (PointShape)BubbleShapeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void MinBubbleSizeScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_BubbleSeries.MinSize = new NLength(MinBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}
		private void MaxBubbleSizeScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_BubbleSeries.MaxSize = new NLength(MaxBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage);
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

			if (NFillStyleTypeEditor.Edit(m_BubbleSeries.FillStyle, out fillStyleResult))
			{
				m_BubbleSeries.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BubbleBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_BubbleSeries.BorderStyle, out strokeStyleResult))
			{
				m_BubbleSeries.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
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
