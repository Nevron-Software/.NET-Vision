using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLegendDockingUC : NExampleBaseUC
	{
		private NChart m_Chart1;
		private NChart m_Chart2;
		private NLegend m_Legend;
		private bool m_bEnableUpdate;
		private Nevron.UI.WinForm.Controls.NComboBox DockStyleComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox DockPanelComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox LegendExpandModeComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RowCountUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ColCountUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox BoundsModeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox FitAlignmentComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.ComponentModel.Container components = null;

		public NLegendDockingUC()
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
			this.DockStyleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.DockPanelComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.LegendExpandModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.RowCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.ColCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.BoundsModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.FitAlignmentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			((System.ComponentModel.ISupportInitialize)(this.RowCountUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColCountUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Dock Style:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DockStyleComboBox
			// 
			this.DockStyleComboBox.ListProperties.CheckBoxDataMember = "";
			this.DockStyleComboBox.ListProperties.DataSource = null;
			this.DockStyleComboBox.ListProperties.DisplayMember = "";
			this.DockStyleComboBox.Location = new System.Drawing.Point(8, 30);
			this.DockStyleComboBox.Name = "DockStyleComboBox";
			this.DockStyleComboBox.Size = new System.Drawing.Size(168, 21);
			this.DockStyleComboBox.TabIndex = 1;
			this.DockStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.DockStyleComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Dock Panel:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DockPanelComboBox
			// 
			this.DockPanelComboBox.ListProperties.CheckBoxDataMember = "";
			this.DockPanelComboBox.ListProperties.DataSource = null;
			this.DockPanelComboBox.ListProperties.DisplayMember = "";
			this.DockPanelComboBox.Location = new System.Drawing.Point(8, 75);
			this.DockPanelComboBox.Name = "DockPanelComboBox";
			this.DockPanelComboBox.Size = new System.Drawing.Size(168, 21);
			this.DockPanelComboBox.TabIndex = 3;
			this.DockPanelComboBox.SelectedIndexChanged += new System.EventHandler(this.DockPanelComboBox_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 188);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "Legend Expand Mode:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LegendExpandModeComboBox
			// 
			this.LegendExpandModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.LegendExpandModeComboBox.ListProperties.DataSource = null;
			this.LegendExpandModeComboBox.ListProperties.DisplayMember = "";
			this.LegendExpandModeComboBox.Location = new System.Drawing.Point(8, 210);
			this.LegendExpandModeComboBox.Name = "LegendExpandModeComboBox";
			this.LegendExpandModeComboBox.Size = new System.Drawing.Size(168, 21);
			this.LegendExpandModeComboBox.TabIndex = 9;
			this.LegendExpandModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LegendExpandModeComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 233);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(168, 20);
			this.label6.TabIndex = 10;
			this.label6.Text = "Row Count:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RowCountUpDown
			// 
			this.RowCountUpDown.Location = new System.Drawing.Point(8, 255);
			this.RowCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.RowCountUpDown.Name = "RowCountUpDown";
			this.RowCountUpDown.Size = new System.Drawing.Size(168, 20);
			this.RowCountUpDown.TabIndex = 11;
			this.RowCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.RowCountUpDown.ValueChanged += new System.EventHandler(this.RowCountUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 277);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(168, 20);
			this.label5.TabIndex = 12;
			this.label5.Text = "Col Count:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ColCountUpDown
			// 
			this.ColCountUpDown.Location = new System.Drawing.Point(8, 299);
			this.ColCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ColCountUpDown.Name = "ColCountUpDown";
			this.ColCountUpDown.Size = new System.Drawing.Size(168, 20);
			this.ColCountUpDown.TabIndex = 13;
			this.ColCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ColCountUpDown.ValueChanged += new System.EventHandler(this.ColCountUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 143);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(168, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Legend Fit Alignment:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 98);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(168, 20);
			this.label7.TabIndex = 4;
			this.label7.Text = "Bounds Mode:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BoundsModeComboBox
			// 
			this.BoundsModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.BoundsModeComboBox.ListProperties.DataSource = null;
			this.BoundsModeComboBox.ListProperties.DisplayMember = "";
			this.BoundsModeComboBox.Location = new System.Drawing.Point(8, 120);
			this.BoundsModeComboBox.Name = "BoundsModeComboBox";
			this.BoundsModeComboBox.Size = new System.Drawing.Size(168, 21);
			this.BoundsModeComboBox.TabIndex = 5;
			this.BoundsModeComboBox.SelectedIndexChanged += new System.EventHandler(this.BoundsModeComboBox_SelectedIndexChanged);
			// 
			// FitAlignmentComboBox
			// 
			this.FitAlignmentComboBox.ListProperties.CheckBoxDataMember = "";
			this.FitAlignmentComboBox.ListProperties.DataSource = null;
			this.FitAlignmentComboBox.ListProperties.DisplayMember = "";
			this.FitAlignmentComboBox.Location = new System.Drawing.Point(8, 165);
			this.FitAlignmentComboBox.Name = "FitAlignmentComboBox";
			this.FitAlignmentComboBox.Size = new System.Drawing.Size(168, 21);
			this.FitAlignmentComboBox.TabIndex = 14;
			this.FitAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.FitAlignmentComboBox_SelectedIndexChanged);
			// 
			// NLegendDockingUC
			// 
			this.Controls.Add(this.FitAlignmentComboBox);
			this.Controls.Add(this.BoundsModeComboBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.RowCountUpDown);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ColCountUpDown);
			this.Controls.Add(this.LegendExpandModeComboBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.DockPanelComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DockStyleComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NLegendDockingUC";
			this.Size = new System.Drawing.Size(180, 432);
			((System.ComponentModel.ISupportInitialize)(this.RowCountUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColCountUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// clear panels
            nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Legend Docking");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(10, 10, 10, 10);
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Legend = new NLegend();
			m_Legend.ContentAlignment = ContentAlignment.BottomRight;
			m_Legend.Mode = LegendMode.Automatic;
			m_Legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
			m_Legend.ShadowStyle.Type = ShadowType.Solid;
            m_Legend.Margins = new NMarginsL(10, 10, 10, 10);

			m_Chart1 = new NCartesianChart();
			nChartControl1.Panels.Add(m_Chart1);

			// configure charts with explicit positioning
			m_Chart1.BoundsMode = BoundsMode.Stretch;
			m_Chart1.DockMode = PanelDockMode.Top;
			m_Chart1.ContentAlignment = ContentAlignment.MiddleCenter; 
			m_Chart1.Size = new NSizeL(
				new NLength(100, NRelativeUnit.ParentPercentage),
				new NLength(45, NRelativeUnit.ParentPercentage));
            m_Chart1.Margins = new NMarginsL(10, 10, 10, 10);
			ConfigureChart(m_Chart1, Color.YellowGreen);

			m_Chart2 = new NCartesianChart();
            m_Chart2.Margins = new NMarginsL(10, 10, 10, 10);
			nChartControl1.Panels.Add(m_Chart2);

			m_Chart2.BoundsMode = BoundsMode.Stretch;
			m_Chart2.DockMode = PanelDockMode.Top;
			m_Chart2.ContentAlignment = ContentAlignment.MiddleCenter;
			m_Chart2.Size = new NSizeL(
				new NLength(100, NRelativeUnit.ParentPercentage),
				new NLength(45, NRelativeUnit.ParentPercentage));
			ConfigureChart(m_Chart2, Color.Orange);

			// configure combo boxes
			m_bEnableUpdate = false;
			DockStyleComboBox.Items.Add("Left");
			DockStyleComboBox.Items.Add("Top");
			DockStyleComboBox.Items.Add("Right");
			DockStyleComboBox.Items.Add("Bottom");
			DockStyleComboBox.Items.Add("Fill");
			DockStyleComboBox.SelectedIndex = 0;

			DockPanelComboBox.Items.Add("Control");
			DockPanelComboBox.Items.Add("Chart 1");
			DockPanelComboBox.Items.Add("Chart 2");
			DockPanelComboBox.SelectedIndex = 0;

			LegendExpandModeComboBox.Items.Add("Rows only");
			LegendExpandModeComboBox.Items.Add("Cols only");
			LegendExpandModeComboBox.Items.Add("Rows fixed");
			LegendExpandModeComboBox.Items.Add("Cols fixed");
			LegendExpandModeComboBox.SelectedIndex = (int)m_Legend.Data.ExpandMode;

			BoundsModeComboBox.Items.Add("None");
			BoundsModeComboBox.Items.Add("Fit");
			BoundsModeComboBox.Items.Add("Stretch");
			BoundsModeComboBox.SelectedIndex = (int)m_Legend.BoundsMode;

			string[] names = Enum.GetNames(typeof(ContentAlignment));
			for (int i = 0; i < names.Length; i++)
			{
				FitAlignmentComboBox.Items.Add(names[i]);
			}
		
			FitAlignmentComboBox.SelectedItem = m_Legend.ContentAlignment.ToString();

			RowCountUpDown.Value = (decimal)m_Legend.Data.RowCount;
			ColCountUpDown.Value = (decimal)m_Legend.Data.ColCount;

			m_bEnableUpdate = true;

			ConfigureLegend();
		}

		private void ConfigureLegend()
		{
			if (m_bEnableUpdate == false)
				return;

			// first remove the legend
            if (nChartControl1.Panels.Contains(m_Legend))
            {
                nChartControl1.Panels.Remove(m_Legend);
            }

			m_Chart1.DisplayOnLegend = null;
			m_Chart1.ChildPanels.Clear();

			m_Chart2.DisplayOnLegend = null;
			m_Chart2.ChildPanels.Clear();

			// configure the legend dock style
			switch (DockStyleComboBox.SelectedIndex)
			{
				case 0: // Left
					m_Legend.DockMode = PanelDockMode.Left;
					break;
				case 1: // Top
					m_Legend.DockMode = PanelDockMode.Top;
					break;
				case 2: // Right
					m_Legend.DockMode = PanelDockMode.Right;
					break;
				case 3: // Bottom
					m_Legend.DockMode = PanelDockMode.Bottom;
					break;
				case 4: // Fill
					m_Legend.DockMode = PanelDockMode.Fill;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			// pupulate the legend with data according to dock panels
			switch (DockPanelComboBox.SelectedIndex)
			{
				case 0:
					// Control (insert the legend after the label which is first)
					nChartControl1.Panels.Insert(1, m_Legend);
					m_Chart1.DisplayOnLegend = m_Legend;
					m_Chart2.DisplayOnLegend = m_Legend;
					break;
				case 1:
					m_Chart1.ChildPanels.Add(m_Legend);
					m_Chart1.DisplayOnLegend = m_Legend;
					break;
				case 2:
					m_Chart2.ChildPanels.Add(m_Legend);
					m_Chart2.DisplayOnLegend = m_Legend;
					break;
				default:
					Debug.Assert(false);
					break;
			}

			// configure the legend dock style
			m_Legend.Data.ExpandMode = (LegendExpandMode)LegendExpandModeComboBox.SelectedIndex;

			Array values = Enum.GetValues(typeof(ContentAlignment));
			m_Legend.FitAlignment = (ContentAlignment)values.GetValue(FitAlignmentComboBox.SelectedIndex);
			m_Legend.Data.RowCount = (int)RowCountUpDown.Value;
			m_Legend.Data.ColCount = (int)ColCountUpDown.Value;
			m_Legend.BoundsMode = (BoundsMode)BoundsModeComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void ConfigureChart(NChart chart, Color color)
		{
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.Wall(ChartWallType.Back).Width = 0;
			chart.Wall(ChartWallType.Back).FillStyle = new NColorFillStyle(Color.FromArgb(239, 245, 239));
			chart.Wall(ChartWallType.Back).ShadowStyle.Type = ShadowType.Solid;

			// create a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar 1";
			bar.Legend.Mode = SeriesLegendMode.DataPoints;
			bar.DataLabelStyle.Visible = false;
			bar.InflateMargins = true;
			bar.FillStyle = new NColorFillStyle(color);
			bar.Values.ValueFormatter = new NNumericValueFormatter("0.00");

			for(int i = 0; i < 15; i++)
			{
				bar.Values.Add(Random.NextDouble() * 900);
			}
		}


		private void DockStyleComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();		
		}

		private void DockPanelComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void LegendExpandModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();

			switch ((LegendExpandMode)LegendExpandModeComboBox.SelectedIndex)
			{
				case LegendExpandMode.RowsOnly:
					RowCountUpDown.Enabled = false;
					ColCountUpDown.Enabled = false;
					break;
				case LegendExpandMode.ColsOnly:
					RowCountUpDown.Enabled = false;
					ColCountUpDown.Enabled = false;
					break;
				case LegendExpandMode.RowsFixed:
					RowCountUpDown.Enabled = true;
					ColCountUpDown.Enabled = false;
					break;
				case LegendExpandMode.ColsFixed:
					RowCountUpDown.Enabled = false;
					ColCountUpDown.Enabled = true;
					break;
			}
		}

		private void RowCountUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ColCountUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void BoundsModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

        private void FitAlignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigureLegend();
        }
	}
}
