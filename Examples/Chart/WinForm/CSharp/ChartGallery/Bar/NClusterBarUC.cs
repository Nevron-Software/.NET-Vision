using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Dom;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NClusterBarUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private Nevron.UI.WinForm.Controls.NHScrollBar GapPercentScrollBar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton PositiveData;
		private Nevron.UI.WinForm.Controls.NButton PositiveNegativeData;
		private Nevron.UI.WinForm.Controls.NButton Bar1FillStyle;
		private Nevron.UI.WinForm.Controls.NButton Bar2FillStyle;
		private Nevron.UI.WinForm.Controls.NCheckBox ScaleSecondCluster;
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroller;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.Container components = null;

		public NClusterBarUC()
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
			this.GapPercentScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.PositiveData = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveNegativeData = new Nevron.UI.WinForm.Controls.NButton();
			this.ScaleSecondCluster = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.WidthScroller = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.Bar1FillStyle = new Nevron.UI.WinForm.Controls.NButton();
			this.Bar2FillStyle = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// GapPercentScrollBar
			// 
			this.GapPercentScrollBar.Location = new System.Drawing.Point(12, 91);
			this.GapPercentScrollBar.Maximum = 110;
			this.GapPercentScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.GapPercentScrollBar.Name = "GapPercentScrollBar";
			this.GapPercentScrollBar.Size = new System.Drawing.Size(152, 16);
			this.GapPercentScrollBar.TabIndex = 3;
			this.GapPercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.GapPercentScrollBar_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Gap Percent:";
			// 
			// PositiveData
			// 
			this.PositiveData.Location = new System.Drawing.Point(12, 221);
			this.PositiveData.Name = "PositiveData";
			this.PositiveData.Size = new System.Drawing.Size(152, 23);
			this.PositiveData.TabIndex = 7;
			this.PositiveData.Text = "Positive Data";
			this.PositiveData.Click += new System.EventHandler(this.PositiveData_Click);
			// 
			// PositiveNegativeData
			// 
			this.PositiveNegativeData.Location = new System.Drawing.Point(12, 248);
			this.PositiveNegativeData.Name = "PositiveNegativeData";
			this.PositiveNegativeData.Size = new System.Drawing.Size(152, 24);
			this.PositiveNegativeData.TabIndex = 8;
			this.PositiveNegativeData.Text = "Positive and Negative Data";
			this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeData_Click);
			// 
			// ScaleSecondCluster
			// 
			this.ScaleSecondCluster.ButtonProperties.BorderOffset = 2;
			this.ScaleSecondCluster.ButtonProperties.ShowFocusRect = false;
			this.ScaleSecondCluster.ButtonProperties.WrapText = true;
			this.ScaleSecondCluster.Location = new System.Drawing.Point(14, 172);
			this.ScaleSecondCluster.Name = "ScaleSecondCluster";
			this.ScaleSecondCluster.Size = new System.Drawing.Size(150, 47);
			this.ScaleSecondCluster.TabIndex = 6;
			this.ScaleSecondCluster.Text = "Scale the second cluster on the secondary Y axis";
			this.ScaleSecondCluster.CheckedChanged += new System.EventHandler(this.ScaleSecondCluster_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 130);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Width Percent:";
			// 
			// WidthScroller
			// 
			this.WidthScroller.Location = new System.Drawing.Point(12, 148);
			this.WidthScroller.Maximum = 110;
			this.WidthScroller.MinimumSize = new System.Drawing.Size(32, 16);
			this.WidthScroller.Name = "WidthScroller";
			this.WidthScroller.Size = new System.Drawing.Size(152, 16);
			this.WidthScroller.TabIndex = 5;
			this.WidthScroller.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroller_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Bar Style:";
			// 
			// StyleCombo
			// 
			this.StyleCombo.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo.ListProperties.DataSource = null;
			this.StyleCombo.ListProperties.DisplayMember = "";
			this.StyleCombo.Location = new System.Drawing.Point(12, 30);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(152, 21);
			this.StyleCombo.TabIndex = 1;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// Bar1FillStyle
			// 
			this.Bar1FillStyle.Location = new System.Drawing.Point(12, 292);
			this.Bar1FillStyle.Name = "Bar1FillStyle";
			this.Bar1FillStyle.Size = new System.Drawing.Size(152, 23);
			this.Bar1FillStyle.TabIndex = 9;
			this.Bar1FillStyle.Text = "Bar1 Fill Style...";
			this.Bar1FillStyle.Click += new System.EventHandler(this.Bar1FillStyle_Click);
			// 
			// Bar2FillStyle
			// 
			this.Bar2FillStyle.Location = new System.Drawing.Point(12, 320);
			this.Bar2FillStyle.Name = "Bar2FillStyle";
			this.Bar2FillStyle.Size = new System.Drawing.Size(152, 23);
			this.Bar2FillStyle.TabIndex = 10;
			this.Bar2FillStyle.Text = "Bar2 Fill Style...";
			this.Bar2FillStyle.Click += new System.EventHandler(this.Bar2FillStyle_Click);
			// 
			// NClusterBarUC
			// 
			this.Controls.Add(this.Bar2FillStyle);
			this.Controls.Add(this.Bar1FillStyle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.StyleCombo);
			this.Controls.Add(this.WidthScroller);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ScaleSecondCluster);
			this.Controls.Add(this.PositiveNegativeData);
			this.Controls.Add(this.PositiveData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GapPercentScrollBar);
			this.Name = "NClusterBarUC";
			this.Size = new System.Drawing.Size(180, 358);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Cluster Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add a bar series
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Format = "<value>";
			m_Bar1.Values.ValueFormatter = new NNumericValueFormatter("0.###");

			// add another bar series
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.MultiBarMode = MultiBarMode.Clustered;
			m_Bar2.DataLabelStyle.Format = "<value>";
			m_Bar2.Values.ValueFormatter = new NNumericValueFormatter("0.###");

			// fill with random data
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			StyleCombo.FillFromEnum(typeof(BarShape));
			StyleCombo.SelectedIndex = 0;
		}

		private void GapPercentScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Bar1.GapPercent = GapPercentScrollBar.Value;
			m_Bar2.GapPercent = GapPercentScrollBar.Value;
			nChartControl1.Refresh();
		}
		private void PositiveData_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500);
			nChartControl1.Refresh();
		}
		private void PositiveNegativeData_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, 5, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, -100, 100);
			nChartControl1.Refresh();
		}
		private void ScaleSecondCluster_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ScaleSecondCluster.Checked == true)
			{
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, false);
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, true);

				m_Chart.Axis(StandardAxis.SecondaryY).Visible = true;
			}
			else
			{
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, true);
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, false);

				m_Chart.Axis(StandardAxis.SecondaryY).Visible = false;
			}

			nChartControl1.Refresh();
		}
		private void WidthScroller_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Bar1.WidthPercent = WidthScroller.Value;
			m_Bar2.WidthPercent = WidthScroller.Value;
			nChartControl1.Refresh();		
		}
		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar1.BarShape = (BarShape)StyleCombo.SelectedIndex;
			m_Bar2.BarShape = (BarShape)StyleCombo.SelectedIndex;

			nChartControl1.Refresh();
		}
		private void Bar1FillStyle_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Bar1.FillStyle, out fillStyleResult))
			{
				m_Bar1.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void Bar2FillStyle_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Bar2.FillStyle, out fillStyleResult))
			{
				m_Bar2.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
