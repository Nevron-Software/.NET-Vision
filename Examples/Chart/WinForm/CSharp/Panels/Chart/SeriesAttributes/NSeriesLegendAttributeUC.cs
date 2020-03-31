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
	public class NSeriesLegendAttributeUC : NExampleBaseUC
	{
		private NChart m_Chart;

        private NBarSeries m_Bar1;
        private NBarSeries m_Bar2;
        private NBarSeries m_Bar3;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox LegendModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox FormatCombo;
        private Nevron.UI.WinForm.Controls.NComboBox BarStyleCombo;
		private System.ComponentModel.Container components = null;

		public NSeriesLegendAttributeUC()
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
			this.LegendModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.FormatCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.BarStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mode:";
			// 
			// LegendModeCombo
			// 
			this.LegendModeCombo.ListProperties.CheckBoxDataMember = "";
			this.LegendModeCombo.ListProperties.DataSource = null;
			this.LegendModeCombo.ListProperties.DisplayMember = "";
			this.LegendModeCombo.Location = new System.Drawing.Point(6, 27);
			this.LegendModeCombo.Name = "LegendModeCombo";
			this.LegendModeCombo.Size = new System.Drawing.Size(168, 21);
			this.LegendModeCombo.TabIndex = 1;
			this.LegendModeCombo.TextChanged += new System.EventHandler(this.FormatCombo_TextChanged);
			this.LegendModeCombo.SelectedIndexChanged += new System.EventHandler(this.LegendModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Format:";
			// 
			// FormatCombo
			// 
			this.FormatCombo.ListProperties.CheckBoxDataMember = "";
			this.FormatCombo.ListProperties.DataSource = null;
			this.FormatCombo.ListProperties.DisplayMember = "";
			this.FormatCombo.Location = new System.Drawing.Point(6, 81);
			this.FormatCombo.Name = "FormatCombo";
			this.FormatCombo.Size = new System.Drawing.Size(168, 21);
			this.FormatCombo.TabIndex = 3;
			this.FormatCombo.TextChanged += new System.EventHandler(this.FormatCombo_TextChanged);
			this.FormatCombo.SelectedIndexChanged += new System.EventHandler(this.FormatCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 115);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Bar Style:";
			// 
			// BarStyleCombo
			// 
			this.BarStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.BarStyleCombo.ListProperties.DataSource = null;
			this.BarStyleCombo.ListProperties.DisplayMember = "";
			this.BarStyleCombo.Location = new System.Drawing.Point(6, 135);
			this.BarStyleCombo.Name = "BarStyleCombo";
			this.BarStyleCombo.Size = new System.Drawing.Size(168, 21);
			this.BarStyleCombo.TabIndex = 5;
			this.BarStyleCombo.SelectedIndexChanged += new System.EventHandler(this.BarStyleCombo_SelectedIndexChanged);
			// 
			// NSeriesLegendAttributeUC
			// 
			this.Controls.Add(this.BarStyleCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.FormatCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LegendModeCombo);
			this.Controls.Add(this.label1);
			this.Name = "NSeriesLegendAttributeUC";
			this.Size = new System.Drawing.Size(180, 255);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel header = new NLabel("Series Legend Attributes");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.DockMode = PanelDockMode.Top;
            header.Margins = new NMarginsL(0, 10, 0, 10);
            
            nChartControl1.Panels.Add(header);

            NLegend legend = new NLegend();
            legend.DockMode = PanelDockMode.Right;
            legend.Data.ExpandMode = LegendExpandMode.ColsFixed;
            legend.Data.ColCount = 2;
            legend.Mode = LegendMode.Automatic;
            legend.BoundsMode = BoundsMode.Fit;
            legend.Margins = new NMarginsL(0, 0, 10, 0);
            nChartControl1.Panels.Add(legend);

            // create the chart
            m_Chart = new NCartesianChart();
			m_Chart.Enable3D = true;
            nChartControl1.Panels.Add(m_Chart);
            m_Chart.DockMode = PanelDockMode.Fill;
            m_Chart.BoundsMode = BoundsMode.Fit;

			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            m_Chart.Margins = new NMarginsL(40, 10, 20, 30);
            m_Chart.DisplayOnLegend = legend;
            m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add the first bar
            m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
            m_Bar1.Name = "Bar1";
            m_Bar1.MultiBarMode = MultiBarMode.Series;

            // add the second bar
            m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
            m_Bar2.Name = "Bar2";
            m_Bar2.MultiBarMode = MultiBarMode.Stacked;

            // add the third bar
            m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
            m_Bar3.Name = "Bar3";
            m_Bar3.MultiBarMode = MultiBarMode.Stacked;

            // position data labels in the center of the bars
            m_Bar1.DataLabelStyle.Visible = true;
            m_Bar1.DataLabelStyle.VertAlign = VertAlign.Center;
            m_Bar1.DataLabelStyle.Format = "<value>";

            m_Bar2.DataLabelStyle.Visible = true;
            m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center;
            m_Bar2.DataLabelStyle.Format = "<value>";

            m_Bar3.DataLabelStyle.Visible = true;
            m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center;
            m_Bar3.DataLabelStyle.Format = "<value>";

            // fill some random data
            m_Bar1.Values.FillRandomRange(Random, 6, 20, 100);
            m_Bar2.Values.FillRandomRange(Random, 6, 20, 100);
            m_Bar3.Values.FillRandomRange(Random, 6, 20, 100);		

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			FormatCombo.Items.Add("<value> <label>");
			FormatCombo.Items.Add("<index> <cumulative>");
			FormatCombo.Items.Add("<percent> <total>");
			FormatCombo.Text = m_Bar1.Legend.Format;

			LegendModeCombo.FillFromEnum(typeof(SeriesLegendMode));
			LegendModeCombo.SelectedIndex = (int)SeriesLegendMode.DataPoints;

			BarStyleCombo.FillFromEnum(typeof(BarShape));
            BarStyleCombo.SelectedIndex = (int)BarShape.Bar;
		}

		private void LegendModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar1.Legend.Mode = (SeriesLegendMode)LegendModeCombo.SelectedIndex;
            m_Bar2.Legend.Mode = (SeriesLegendMode)LegendModeCombo.SelectedIndex;
            m_Bar3.Legend.Mode = (SeriesLegendMode)LegendModeCombo.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void FormatCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            m_Bar1.Legend.Format = FormatCombo.Text;
            m_Bar2.Legend.Format = FormatCombo.Text;
            m_Bar3.Legend.Format = FormatCombo.Text;

			nChartControl1.Refresh();
		}

		private void FormatCombo_TextChanged(object sender, System.EventArgs e)
		{
			m_Bar1.Legend.Format = FormatCombo.Text;
            m_Bar2.Legend.Format = FormatCombo.Text;
            m_Bar3.Legend.Format = FormatCombo.Text;

			nChartControl1.Refresh();
		}

        private void BarStyleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Bar1.BarShape = (BarShape)BarStyleCombo.SelectedIndex;
            m_Bar2.BarShape = (BarShape)BarStyleCombo.SelectedIndex;
            m_Bar3.BarShape = (BarShape)BarStyleCombo.SelectedIndex;

            nChartControl1.Refresh();
        }
	}
}
