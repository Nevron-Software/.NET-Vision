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


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NClusterStackCombinationUC : NExampleBaseUC
	{
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private NBarSeries m_Bar3;
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroller;
		private Nevron.UI.WinForm.Controls.NHScrollBar GapPercentScrollBar;
		private Nevron.UI.WinForm.Controls.NCheckBox ScaleSecondCluster;
		private Nevron.UI.WinForm.Controls.NButton PositiveNegativeData;
		private Nevron.UI.WinForm.Controls.NButton PositiveData;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo1;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo2;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDataLabelsCheck;
		private System.ComponentModel.Container components = null;

		public NClusterStackCombinationUC()
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
			this.WidthScroller = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.GapPercentScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.ScaleSecondCluster = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.PositiveNegativeData = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveData = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.StyleCombo1 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.StyleCombo2 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.StyleCombo3 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ShowDataLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// WidthScroller
			// 
			this.WidthScroller.LargeChange = 1;
			this.WidthScroller.Location = new System.Drawing.Point(7, 70);
			this.WidthScroller.MinimumSize = new System.Drawing.Size(32, 16);
			this.WidthScroller.Name = "WidthScroller";
			this.WidthScroller.Size = new System.Drawing.Size(160, 16);
			this.WidthScroller.TabIndex = 3;
			this.WidthScroller.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroller_Scroll);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(7, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "Width Percent:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Gap Percent:";
			// 
			// GapPercentScrollBar
			// 
			this.GapPercentScrollBar.LargeChange = 1;
			this.GapPercentScrollBar.Location = new System.Drawing.Point(7, 26);
			this.GapPercentScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.GapPercentScrollBar.Name = "GapPercentScrollBar";
			this.GapPercentScrollBar.Size = new System.Drawing.Size(160, 16);
			this.GapPercentScrollBar.TabIndex = 1;
			this.GapPercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.GapPercentScrollBar_Scroll);
			// 
			// ScaleSecondCluster
			// 
			this.ScaleSecondCluster.ButtonProperties.BorderOffset = 2;
			this.ScaleSecondCluster.ButtonProperties.WrapText = true;
			this.ScaleSecondCluster.Location = new System.Drawing.Point(9, 103);
			this.ScaleSecondCluster.Name = "ScaleSecondCluster";
			this.ScaleSecondCluster.Size = new System.Drawing.Size(160, 33);
			this.ScaleSecondCluster.TabIndex = 4;
			this.ScaleSecondCluster.Text = "Scale the second cluster on the secondary Y axis";
			this.ScaleSecondCluster.CheckedChanged += new System.EventHandler(this.ScaleSecondCluster_CheckedChanged);
			// 
			// PositiveNegativeData
			// 
			this.PositiveNegativeData.Location = new System.Drawing.Point(7, 212);
			this.PositiveNegativeData.Name = "PositiveNegativeData";
			this.PositiveNegativeData.Size = new System.Drawing.Size(160, 24);
			this.PositiveNegativeData.TabIndex = 6;
			this.PositiveNegativeData.Text = "Positive and Negative Data";
			this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeData_Click);
			// 
			// PositiveData
			// 
			this.PositiveData.Location = new System.Drawing.Point(7, 182);
			this.PositiveData.Name = "PositiveData";
			this.PositiveData.Size = new System.Drawing.Size(160, 23);
			this.PositiveData.TabIndex = 5;
			this.PositiveData.Text = "Positive Data";
			this.PositiveData.Click += new System.EventHandler(this.PositiveData_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 265);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Bar1 Style:";
			// 
			// StyleCombo1
			// 
			this.StyleCombo1.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo1.ListProperties.DataSource = null;
			this.StyleCombo1.ListProperties.DisplayMember = "";
			this.StyleCombo1.Location = new System.Drawing.Point(7, 281);
			this.StyleCombo1.Name = "StyleCombo1";
			this.StyleCombo1.Size = new System.Drawing.Size(160, 21);
			this.StyleCombo1.TabIndex = 8;
			this.StyleCombo1.SelectedIndexChanged += new System.EventHandler(this.StyleCombo1_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 321);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Bar2 Style:";
			// 
			// StyleCombo2
			// 
			this.StyleCombo2.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo2.ListProperties.DataSource = null;
			this.StyleCombo2.ListProperties.DisplayMember = "";
			this.StyleCombo2.Location = new System.Drawing.Point(7, 337);
			this.StyleCombo2.Name = "StyleCombo2";
			this.StyleCombo2.Size = new System.Drawing.Size(160, 21);
			this.StyleCombo2.TabIndex = 10;
			this.StyleCombo2.SelectedIndexChanged += new System.EventHandler(this.StyleCombo2_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 378);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "Bar3 Style:";
			// 
			// StyleCombo3
			// 
			this.StyleCombo3.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo3.ListProperties.DataSource = null;
			this.StyleCombo3.ListProperties.DisplayMember = "";
			this.StyleCombo3.Location = new System.Drawing.Point(7, 394);
			this.StyleCombo3.Name = "StyleCombo3";
			this.StyleCombo3.Size = new System.Drawing.Size(160, 21);
			this.StyleCombo3.TabIndex = 12;
			this.StyleCombo3.SelectedIndexChanged += new System.EventHandler(this.StyleCombo3_SelectedIndexChanged);
			// 
			// ShowDataLabelsCheck
			// 
			this.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.ShowDataLabelsCheck.ButtonProperties.WrapText = true;
			this.ShowDataLabelsCheck.Location = new System.Drawing.Point(9, 146);
			this.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck";
			this.ShowDataLabelsCheck.Size = new System.Drawing.Size(160, 19);
			this.ShowDataLabelsCheck.TabIndex = 13;
			this.ShowDataLabelsCheck.Text = "Show Data Labels";
			this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			// 
			// NClusterStackCombinationUC
			// 
			this.Controls.Add(this.ShowDataLabelsCheck);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.StyleCombo3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.StyleCombo2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.StyleCombo1);
			this.Controls.Add(this.ScaleSecondCluster);
			this.Controls.Add(this.PositiveNegativeData);
			this.Controls.Add(this.PositiveData);
			this.Controls.Add(this.WidthScroller);
			this.Controls.Add(this.GapPercentScrollBar);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label1);
			this.Name = "NClusterStackCombinationUC";
			this.Size = new System.Drawing.Size(180, 438);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Cluster Stack Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup the chart
			NChart m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 65;
			m_Chart.Height = 40;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft); 
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlaced stripe to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// add the first bar
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Format = "<value>";
			m_Bar1.DataLabelStyle.Visible = false;

			// add the second bar
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.MultiBarMode = MultiBarMode.Clustered;
			m_Bar2.DataLabelStyle.Format = "<value>";
			m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bar2.DataLabelStyle.Visible = false;

			// add the third bar
			m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar3.Name = "Bar2";
			m_Bar3.MultiBarMode = MultiBarMode.Stacked;
			m_Bar3.DataLabelStyle.Format = "<value>";
			m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bar3.DataLabelStyle.Visible = false;

			// fill with random data
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500);
			m_Bar3.Values.FillRandomRange(Random, 5, 10, 500);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			StyleCombo1.FillFromEnum(typeof(BarShape));
			StyleCombo2.FillFromEnum(typeof(BarShape));
			StyleCombo3.FillFromEnum(typeof(BarShape));

            StyleCombo1.SelectedIndex = (int)BarShape.Cylinder;
            StyleCombo2.SelectedIndex = (int)BarShape.Pyramid;
            StyleCombo3.SelectedIndex = (int)BarShape.Pyramid;

            GapPercentScrollBar.Value = 5;
            WidthScroller.Value = 70;
		}

		private void GapPercentScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Bar1.GapPercent = GapPercentScrollBar.Value;
			m_Bar2.GapPercent = GapPercentScrollBar.Value;
			m_Bar3.GapPercent = GapPercentScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void WidthScroller_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Bar1.WidthPercent = WidthScroller.Value;
			m_Bar2.WidthPercent = WidthScroller.Value;
			m_Bar3.WidthPercent = WidthScroller.Value;

			nChartControl1.Refresh();
		}

		private void ScaleSecondCluster_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			if (ScaleSecondCluster.Checked == true)
			{
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, false);
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, true);

				m_Bar3.DisplayOnAxis(StandardAxis.PrimaryY, false);
				m_Bar3.DisplayOnAxis(StandardAxis.SecondaryY, true);

				chart.Axis(StandardAxis.SecondaryY).Visible = true;
			}
			else
			{
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, true);
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, false);

				m_Bar3.DisplayOnAxis(StandardAxis.PrimaryY, true);
				m_Bar3.DisplayOnAxis(StandardAxis.SecondaryY, false);

				chart.Axis(StandardAxis.SecondaryY).Visible = false;
			}

			nChartControl1.Refresh();
		}

		private void PositiveData_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500);
			m_Bar3.Values.FillRandomRange(Random, 5, 10, 500);

			nChartControl1.Refresh();
		}

		private void PositiveNegativeData_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, 5, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, -100, 100);		
			m_Bar3.Values.FillRandomRange(Random, 5, -100, 100);

			nChartControl1.Refresh();
		}

		private void StyleCombo1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar1.BarShape = (BarShape)StyleCombo1.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void StyleCombo2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar2.BarShape = (BarShape)StyleCombo2.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void StyleCombo3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar3.BarShape = (BarShape)StyleCombo3.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void ShowDataLabelsCheck_CheckedChanged(object sender, EventArgs e)
		{
			m_Bar1.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			m_Bar2.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			m_Bar3.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			nChartControl1.Refresh();
		}
	}
}
