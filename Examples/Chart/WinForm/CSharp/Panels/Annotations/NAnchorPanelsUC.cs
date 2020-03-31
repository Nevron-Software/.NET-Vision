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
	public class NAnchorPanelsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPointSeries m_PointSeries;
		private bool m_bLockUpdate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox PointStyleComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox MiniChartTypeComboBox;
		private System.ComponentModel.Container components = null;

		public NAnchorPanelsUC()
		{
			InitializeComponent();

			m_bLockUpdate = true;
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
			this.MiniChartTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.PointStyleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mini chart type:";
			// 
			// MiniChartTypeComboBox
			// 
			this.MiniChartTypeComboBox.ListProperties.CheckBoxDataMember = "";
			this.MiniChartTypeComboBox.ListProperties.DataSource = null;
			this.MiniChartTypeComboBox.ListProperties.DisplayMember = "";
			this.MiniChartTypeComboBox.Location = new System.Drawing.Point(8, 24);
			this.MiniChartTypeComboBox.Name = "MiniChartTypeComboBox";
			this.MiniChartTypeComboBox.Size = new System.Drawing.Size(128, 21);
			this.MiniChartTypeComboBox.TabIndex = 1;
			this.MiniChartTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.MiniChartTypeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Shapes style:";
			// 
			// PointStyleComboBox
			// 
			this.PointStyleComboBox.ListProperties.CheckBoxDataMember = "";
			this.PointStyleComboBox.ListProperties.DataSource = null;
			this.PointStyleComboBox.ListProperties.DisplayMember = "";
			this.PointStyleComboBox.Location = new System.Drawing.Point(8, 88);
			this.PointStyleComboBox.Name = "PointStyleComboBox";
			this.PointStyleComboBox.Size = new System.Drawing.Size(128, 21);
			this.PointStyleComboBox.TabIndex = 3;
			this.PointStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.PointStyleComboBox_SelectedIndexChanged);
			// 
			// NAnchorPanelsUC
			// 
			this.Controls.Add(this.PointStyleComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.MiniChartTypeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NAnchorPanelsUC";
			this.Size = new System.Drawing.Size(150, 232);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			m_bLockUpdate = true;

			// set a chart title
			NLabel title = new NLabel("Anchor panels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// form controls
			MiniChartTypeComboBox.Items.Add("Pie");
			MiniChartTypeComboBox.Items.Add("Doughnut");
			MiniChartTypeComboBox.Items.Add("Bar");
			MiniChartTypeComboBox.Items.Add("Area");
			MiniChartTypeComboBox.SelectedIndex = 0;

			PointStyleComboBox.FillFromEnum(typeof(BarShape));
			PointStyleComboBox.SelectedIndex = 0;

			m_bLockUpdate = false;

			UpdateMiniCharts();

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);
		}

		private void UpdateMiniCharts()
		{
			if (m_bLockUpdate == true)
				return;

			m_Chart.RemoveDescendantsOfType(typeof(NAnchorPanel));
			m_Chart.Series.Clear();

			// add bar and change bar color
			m_PointSeries = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);

			// use custom X positions
			m_PointSeries.UseXValues = true;

			m_PointSeries.Size = new NLength(12, NRelativeUnit.ParentPercentage);
		
			// this will require to set the InflateMargins flag to true since in this mode
			// scale is determined only by the X positions of the shape and will not take 
			// into account the size of the bubbles.
			m_PointSeries.InflateMargins = true;

			m_PointSeries.PointShape = (PointShape)PointStyleComboBox.SelectedIndex;
			m_PointSeries.DataLabelStyle.Visible = false;

			// populate the shape series of the master chart
			int i = 0;

			for (i = 0; i < 5; i++)
			{
				float fShapeSize = 40 + Random.Next(5);

				m_PointSeries.XValues.Add(Random.Next(10));
				m_PointSeries.Values.Add(Random.Next(10));
				m_PointSeries.FillStyles[i] = new NColorFillStyle(RandomColor());
			}

			// create anchor panels attached to the shape series data points
			for (i = 0; i < m_PointSeries.Values.Count; i++)
			{
				NAnchorPanel anchorPanel = new NAnchorPanel();
				m_Chart.ChildPanels.Add(anchorPanel);

				anchorPanel.Size = new NSizeL(
					new NLength(10, NRelativeUnit.ParentPercentage),
					new NLength(10, NRelativeUnit.ParentPercentage));

				anchorPanel.Anchor = new NDataPointAnchor(m_PointSeries, i, ContentAlignment.MiddleCenter, StringAlignment.Near);
				anchorPanel.ContentAlignment = ContentAlignment.MiddleCenter;
				anchorPanel.ChildPanels.Add(CreateAnchorPanelChart());
			}

			nChartControl1.Refresh();
		}

		private NChart CreateAnchorPanelChart()
		{
			NChart chart = null;
			NSeries series = null;

			switch (MiniChartTypeComboBox.SelectedIndex)
			{
				case 0: // Pie
					chart = new NPieChart();
					series = (NSeries)chart.Series.Add(SeriesType.Pie);
					break;

				case 1: // Doughnut
				{
					chart = new NPieChart();
					NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
					pie.PieStyle = PieStyle.Torus;
					series = pie;
					break;
				}

				case 2: // Bar
					chart = new NCartesianChart();
					chart.Wall(ChartWallType.Back).Visible = false;
					chart.Axis(StandardAxis.PrimaryX).Visible = false;
					chart.Axis(StandardAxis.PrimaryY).Visible = false;
					chart.Axis(StandardAxis.Depth).Visible = false;
					series = (NSeries)chart.Series.Add(SeriesType.Bar);
					break;

				case 3: // Area
					chart = new NCartesianChart();
					chart.Wall(ChartWallType.Back).Visible = false;
					chart.Axis(StandardAxis.PrimaryX).Visible = false;
					chart.Axis(StandardAxis.PrimaryY).Visible = false;
					chart.Axis(StandardAxis.Depth).Visible = false;
					series = (NSeries)chart.Series.Add(SeriesType.Area);
					break;
			}

			chart.BoundsMode = BoundsMode.Fit;
			chart.DockMode = PanelDockMode.Fill;
			series.DataLabelStyle.Visible = false;

			NDataPoint dp = new NDataPoint();

			for(int i = 0; i < 5; i++)
			{
				dp[DataPointValue.Value] = 5 + Random.Next(10);
				dp[DataPointValue.FillStyle] = new NColorFillStyle(RandomColor());
				series.AddDataPoint(dp);
			}

			return chart;
		}

		private void MiniChartTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateMiniCharts();
		}

		private void PointStyleComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateMiniCharts();
		}
	}
}
