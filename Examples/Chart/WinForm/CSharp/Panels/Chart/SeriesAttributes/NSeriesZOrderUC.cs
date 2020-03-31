using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using System.Diagnostics;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSeriesZOrderUC : NExampleBaseUC
	{
		private NChart m_Chart;

        private NBarSeries m_Bar1;
        private NBarSeries m_Bar2;
        private NBarSeries m_Bar3;

		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox ZOrderModeCombo;
		private System.ComponentModel.Container components = null;

		public NSeriesZOrderUC()
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
			this.ZOrderModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Z Order:";
			// 
			// ZOrderModeCombo
			// 
			this.ZOrderModeCombo.ListProperties.CheckBoxDataMember = "";
			this.ZOrderModeCombo.ListProperties.DataSource = null;
			this.ZOrderModeCombo.ListProperties.DisplayMember = "";
			this.ZOrderModeCombo.Location = new System.Drawing.Point(6, 27);
			this.ZOrderModeCombo.Name = "ZOrderModeCombo";
			this.ZOrderModeCombo.Size = new System.Drawing.Size(168, 21);
			this.ZOrderModeCombo.TabIndex = 1;
			this.ZOrderModeCombo.SelectedIndexChanged += new System.EventHandler(this.ZOrderModeCombo_SelectedIndexChanged);
			// 
			// NSeriesZOrderUC
			// 
			this.Controls.Add(this.ZOrderModeCombo);
			this.Controls.Add(this.label1);
			this.Name = "NSeriesZOrderUC";
			this.Size = new System.Drawing.Size(180, 255);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Series Z Order");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(0, 10, 0, 10);

			nChartControl1.Panels.Add(header);

			NLegend legend = new NLegend();
			legend.DockMode = PanelDockMode.Right;
			legend.Margins = new NMarginsL(0, 0, 10, 0);
			nChartControl1.Panels.Add(legend);

			// create the chart
			m_Chart = new NCartesianChart();
			nChartControl1.Panels.Add(m_Chart);
			m_Chart.DockMode = PanelDockMode.Fill;
			m_Chart.BoundsMode = BoundsMode.Stretch;

			m_Chart.Margins = new NMarginsL(40, 10, 20, 30);
			m_Chart.DisplayOnLegend = legend;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add the first bar
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.WidthPercent = 80;
			m_Bar1.Name = "Bar1";

			// add the second bar
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.WidthPercent = 60;
			m_Bar2.Name = "Bar2";

			// add the third bar
			m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar3.WidthPercent = 40;
			m_Bar3.Name = "Bar3";

			// position data labels in the center of the bars
			m_Bar1.DataLabelStyle.Visible = false;
			m_Bar2.DataLabelStyle.Visible = false;
			m_Bar3.DataLabelStyle.Visible = false;

			// fill some random data
			m_Bar1.Values.FillRandomRange(Random, 6, 20, 100);
			m_Bar2.Values.FillRandomRange(Random, 6, 20, 100);
			m_Bar3.Values.FillRandomRange(Random, 6, 20, 100);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			ZOrderModeCombo.Items.Add("123");
			ZOrderModeCombo.Items.Add("321");
			ZOrderModeCombo.SelectedIndex = 0;
		}

		private void ZOrderModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (ZOrderModeCombo.SelectedIndex)
			{
				case 0:
					m_Bar1.ZOrder = 1;
					m_Bar2.ZOrder = 2;
					m_Bar3.ZOrder = 3;
					break;
				case 1:
					m_Bar1.ZOrder = 3;
					m_Bar2.ZOrder = 2;
					m_Bar3.ZOrder = 1;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
