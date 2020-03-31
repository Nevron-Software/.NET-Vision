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
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NManhattanBarUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private NBarSeries m_Bar3;
		private NBarSeries m_Bar4;
		private const int m_nBarsCount = 7;
		private Nevron.UI.WinForm.Controls.NHScrollBar ChartDepthScroll;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton PositiveNegativeData;
		private Nevron.UI.WinForm.Controls.NButton PositiveData;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox BarsHaveBorders;
		private System.ComponentModel.Container components = null;

		public NManhattanBarUC()
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
			this.ChartDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.PositiveNegativeData = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveData = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.BarsHaveBorders = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ChartDepthScroll
			// 
			this.ChartDepthScroll.LargeChange = 1;
			this.ChartDepthScroll.Location = new System.Drawing.Point(10, 85);
			this.ChartDepthScroll.Maximum = 50;
			this.ChartDepthScroll.Minimum = 1;
			this.ChartDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ChartDepthScroll.Name = "ChartDepthScroll";
			this.ChartDepthScroll.Size = new System.Drawing.Size(152, 16);
			this.ChartDepthScroll.TabIndex = 3;
			this.ChartDepthScroll.Value = 1;
			this.ChartDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ChartDepthScroll_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Chart Depth:";
			// 
			// PositiveNegativeData
			// 
			this.PositiveNegativeData.Location = new System.Drawing.Point(10, 187);
			this.PositiveNegativeData.Name = "PositiveNegativeData";
			this.PositiveNegativeData.Size = new System.Drawing.Size(152, 24);
			this.PositiveNegativeData.TabIndex = 6;
			this.PositiveNegativeData.Text = "Positive and Negative Data";
			this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeData_Click);
			// 
			// PositiveData
			// 
			this.PositiveData.Location = new System.Drawing.Point(10, 155);
			this.PositiveData.Name = "PositiveData";
			this.PositiveData.Size = new System.Drawing.Size(152, 23);
			this.PositiveData.TabIndex = 5;
			this.PositiveData.Text = "Positive Data";
			this.PositiveData.Click += new System.EventHandler(this.PositiveData_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Bar Style:";
			// 
			// StyleCombo
			// 
			this.StyleCombo.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo.ListProperties.DataSource = null;
			this.StyleCombo.ListProperties.DisplayMember = "";
			this.StyleCombo.Location = new System.Drawing.Point(10, 32);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(152, 21);
			this.StyleCombo.TabIndex = 1;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// BarsHaveBorders
			// 
			this.BarsHaveBorders.ButtonProperties.BorderOffset = 2;
			this.BarsHaveBorders.Location = new System.Drawing.Point(10, 121);
			this.BarsHaveBorders.Name = "BarsHaveBorders";
			this.BarsHaveBorders.Size = new System.Drawing.Size(152, 20);
			this.BarsHaveBorders.TabIndex = 4;
			this.BarsHaveBorders.Text = "Bars Have Borders";
			this.BarsHaveBorders.CheckedChanged += new System.EventHandler(this.BarsHaveBorders_CheckedChanged);
			// 
			// NManhattanBarUC
			// 
			this.Controls.Add(this.BarsHaveBorders);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.StyleCombo);
			this.Controls.Add(this.PositiveNegativeData);
			this.Controls.Add(this.PositiveData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ChartDepthScroll);
			this.Name = "NManhattanBarUC";
			this.Size = new System.Drawing.Size(180, 294);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Manhattan Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 60;
			m_Chart.Height = 25;
			m_Chart.Depth = 45;
			m_Chart.BoundsMode = BoundsMode.Fit;
			m_Chart.ContentAlignment = ContentAlignment.BottomRight;
			m_Chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

            // apply predefined projection and lighting
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

			// add axis labels
			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Labels.Add("Miami");
			ordinalScale.Labels.Add("Chicago");
			ordinalScale.Labels.Add("Los Angeles");
			ordinalScale.Labels.Add("New York");
            ordinalScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

			ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add interlace stripe to the Y axis
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add the first bar
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.Name = "Bar1";
			m_Bar1.DataLabelStyle.Visible = false;
			m_Bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255);

			// add the second bar
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.MultiBarMode = MultiBarMode.Series;
			m_Bar2.Name = "Bar2";
			m_Bar2.DataLabelStyle.Visible = false;
			m_Bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210);

			// add the third bar
			m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar3.MultiBarMode = MultiBarMode.Series;
			m_Bar3.Name = "Bar3";
			m_Bar3.DataLabelStyle.Visible = false;
			m_Bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210);

			// add the second bar
			m_Bar4 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar4.MultiBarMode = MultiBarMode.Series;
			m_Bar4.Name = "Bar4";
			m_Bar4.DataLabelStyle.Visible = false;
			m_Bar4.BorderStyle.Color = Color.FromArgb(255, 210, 210);

			// fill with random data
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, 10, 40);
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, 30, 60);
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, 50, 80);
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, 70, 100);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// update form controls
			StyleCombo.FillFromEnum(typeof(BarShape));
			StyleCombo.SelectedIndex = 0;
			BarsHaveBorders.Checked = true;
		}

		private void ChartDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Chart.Depth = (float)ChartDepthScroll.Value;
			nChartControl1.Refresh();
		}

		private void PositiveData_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, 10, 100);
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, 10, 100);
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, 10, 100);
			nChartControl1.Refresh();
		}

		private void PositiveNegativeData_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, -100, 100);
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, -100, 100);
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, -100, 100);
			nChartControl1.Refresh();
		}

		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar1.BarShape = (BarShape)StyleCombo.SelectedIndex;
			m_Bar2.BarShape = (BarShape)StyleCombo.SelectedIndex;
			m_Bar3.BarShape = (BarShape)StyleCombo.SelectedIndex;
			m_Bar4.BarShape = (BarShape)StyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void BarsHaveBorders_CheckedChanged(object sender, System.EventArgs e)
		{
			NLength length;

			if (BarsHaveBorders.Checked)
			{
				length = new NLength(1, NGraphicsUnit.Pixel);
			}
			else
			{
				length = new NLength(0, NGraphicsUnit.Pixel);
			}

			m_Bar1.BorderStyle.Width = length;
			m_Bar2.BorderStyle.Width = length;
			m_Bar3.BorderStyle.Width = length;
			m_Bar4.BorderStyle.Width = length;

			nChartControl1.Refresh();
		}
	}
}
