using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NMultiSeriesAreaUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NAreaSeries m_Area1;
		private NAreaSeries m_Area2;
		private NAreaSeries m_Area3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NHScrollBar ChartDepthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar AreaDepthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar AreaTransparencyScroll;
		private System.ComponentModel.Container components = null;

		public NMultiSeriesAreaUC()
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
			this.AreaDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ChartDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.AreaTransparencyScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.SuspendLayout();
			// 
			// AreaDepthScroll
			// 
			this.AreaDepthScroll.Location = new System.Drawing.Point(6, 67);
			this.AreaDepthScroll.Maximum = 110;
			this.AreaDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.AreaDepthScroll.Name = "AreaDepthScroll";
			this.AreaDepthScroll.Size = new System.Drawing.Size(168, 16);
			this.AreaDepthScroll.TabIndex = 12;
			this.AreaDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.AreaDepthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Area Depth %:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Chart Depth:";
			// 
			// ChartDepthScroll
			// 
			this.ChartDepthScroll.Location = new System.Drawing.Point(6, 22);
			this.ChartDepthScroll.Maximum = 60;
			this.ChartDepthScroll.Minimum = 1;
			this.ChartDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ChartDepthScroll.Name = "ChartDepthScroll";
			this.ChartDepthScroll.Size = new System.Drawing.Size(168, 16);
			this.ChartDepthScroll.TabIndex = 8;
			this.ChartDepthScroll.Value = 1;
			this.ChartDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ChartDepthScroll_Scroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 14);
			this.label3.TabIndex = 13;
			this.label3.Text = "Area Transparency";
			// 
			// AreaTransparencyScroll
			// 
			this.AreaTransparencyScroll.Location = new System.Drawing.Point(6, 112);
			this.AreaTransparencyScroll.Maximum = 110;
			this.AreaTransparencyScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.AreaTransparencyScroll.Name = "AreaTransparencyScroll";
			this.AreaTransparencyScroll.Size = new System.Drawing.Size(168, 16);
			this.AreaTransparencyScroll.TabIndex = 14;
			this.AreaTransparencyScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.AreaTransparencyScroll_Scroll);
			// 
			// NMultiSeriesAreaUC
			// 
			this.Controls.Add(this.AreaTransparencyScroll);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.AreaDepthScroll);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ChartDepthScroll);
			this.Name = "NMultiSeriesAreaUC";
			this.Size = new System.Drawing.Size(180, 181);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Multi Series Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

            // apply predefined projection and lighting
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Width = 65.0f;
			m_Chart.Height = 40.0f;
			m_Chart.Depth = 40.0f;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add the first area
			m_Area1 = (NAreaSeries)m_Chart.Series.Add(SeriesType.Area);
			m_Area1.MultiAreaMode = MultiAreaMode.Series;
			m_Area1.DataLabelStyle.Visible = false;
			m_Area1.Name = "Area 1";
			m_Area1.Values.FillRandomRange(Random, 15, 10, 40);

			// add the second area
			m_Area2 = (NAreaSeries)m_Chart.Series.Add(SeriesType.Area);
			m_Area2.MultiAreaMode = MultiAreaMode.Series;
			m_Area2.DataLabelStyle.Visible = false;
			m_Area2.Name = "Area 2";
			m_Area2.Values.FillRandomRange(Random, 15, 30, 60);

			// add the third area
			m_Area3 = (NAreaSeries)m_Chart.Series.Add(SeriesType.Area);
			m_Area3.MultiAreaMode = MultiAreaMode.Series;
			m_Area3.DataLabelStyle.Visible = false;
			m_Area3.Name = "Area 3";
			m_Area3.Values.FillRandomRange(Random, 15, 50, 80);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void ChartDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Chart.Depth = (float)ChartDepthScroll.Value;
			nChartControl1.Refresh();				
		}

		private void AreaDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Area1.DepthPercent = AreaDepthScroll.Value;
			m_Area2.DepthPercent = AreaDepthScroll.Value;
			m_Area3.DepthPercent = AreaDepthScroll.Value;

			nChartControl1.Refresh();		
		}

		private void AreaTransparencyScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Area1.FillStyle.SetTransparencyPercent(AreaTransparencyScroll.Value);
			m_Area2.FillStyle.SetTransparencyPercent(AreaTransparencyScroll.Value);
			m_Area3.FillStyle.SetTransparencyPercent(AreaTransparencyScroll.Value);

			nChartControl1.Refresh();
		}
	}
}