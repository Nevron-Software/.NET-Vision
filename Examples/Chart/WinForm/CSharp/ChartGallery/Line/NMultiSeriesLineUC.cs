using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
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
	public class NMultiSeriesLineUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NLineSeries m_Line1;
		private NLineSeries m_Line2;
		private NLineSeries m_Line3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NHScrollBar ChartDepthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar LineDepthScroll;
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private System.ComponentModel.Container components = null;

		public NMultiSeriesLineUC()
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
			this.ChartDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.LineDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Chart Depth:";
			// 
			// ChartDepthScroll
			// 
			this.ChartDepthScroll.LargeChange = 5;
			this.ChartDepthScroll.Location = new System.Drawing.Point(7, 31);
			this.ChartDepthScroll.Maximum = 50;
			this.ChartDepthScroll.Minimum = 1;
			this.ChartDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ChartDepthScroll.Name = "ChartDepthScroll";
			this.ChartDepthScroll.Size = new System.Drawing.Size(167, 16);
			this.ChartDepthScroll.TabIndex = 1;
			this.ChartDepthScroll.Value = 1;
			this.ChartDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ChartDepthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(167, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Line Depth %:";
			// 
			// LineDepthScroll
			// 
			this.LineDepthScroll.Location = new System.Drawing.Point(7, 87);
			this.LineDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LineDepthScroll.Name = "LineDepthScroll";
			this.LineDepthScroll.Size = new System.Drawing.Size(167, 16);
			this.LineDepthScroll.TabIndex = 3;
			this.LineDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineDepthScroll_Scroll);
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(7, 133);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(167, 22);
			this.NewDataButton.TabIndex = 4;
			this.NewDataButton.Text = "New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// NMultiSeriesLineUC
			// 
			this.Controls.Add(this.NewDataButton);
			this.Controls.Add(this.LineDepthScroll);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ChartDepthScroll);
			this.Name = "NMultiSeriesLineUC";
			this.Size = new System.Drawing.Size(180, 171);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Multi Series Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 60;
			m_Chart.Height = 25;
			m_Chart.Depth = 45;
			m_Chart.Projection.Type = ProjectionType.Perspective;
			m_Chart.Projection.Elevation = 28;
			m_Chart.Projection.Rotation = -17;
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// show the X axis gridlines
			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);

			// add the first line
			m_Line1 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line1.MultiLineMode = MultiLineMode.Series;
			m_Line1.LineSegmentShape = LineSegmentShape.Tape;
			m_Line1.DataLabelStyle.Visible = false;
			m_Line1.DepthPercent = 50;
			m_Line1.Name = "Line 1";

			// add the second line
			m_Line2 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line2.MultiLineMode = MultiLineMode.Series;
			m_Line2.LineSegmentShape = LineSegmentShape.Tape;
			m_Line2.DataLabelStyle.Visible = false;
			m_Line2.DepthPercent = 50;
			m_Line2.Name = "Line 2";

			// add the third line
			m_Line3 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line3.MultiLineMode = MultiLineMode.Series;
			m_Line3.LineSegmentShape = LineSegmentShape.Tape;
			m_Line3.DataLabelStyle.Visible = false;
			m_Line3.DepthPercent = 50;
			m_Line3.Name = "Line 3";

			GenerateData();

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}


		private void GenerateData()
		{
			m_Line1.Values.FillRandom(Random, 7);
			m_Line2.Values.FillRandom(Random, 7);
			m_Line3.Values.FillRandom(Random, 7);
		}

		private void ChartDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Chart.Depth = (float)ChartDepthScroll.Value;
			nChartControl1.Refresh();		
		}

		private void LineDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Line1.DepthPercent = LineDepthScroll.Value;
			m_Line2.DepthPercent = LineDepthScroll.Value;		
			m_Line3.DepthPercent = LineDepthScroll.Value;

			nChartControl1.Refresh();
		}

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateData();

			nChartControl1.Refresh();
		}
	}
}
