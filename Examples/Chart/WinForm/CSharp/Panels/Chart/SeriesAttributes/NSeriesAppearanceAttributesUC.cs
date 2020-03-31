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
	public class NSeriesAppearanceAttributesUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private Nevron.UI.WinForm.Controls.NButton btnDefaultFillStyle;
		private Nevron.UI.WinForm.Controls.NButton btnDefaultBorder;
		private Nevron.UI.WinForm.Controls.NButton btnBar3FillStyle;
		private Nevron.UI.WinForm.Controls.NButton btnBar3Border;
		private System.ComponentModel.Container components = null;

		public NSeriesAppearanceAttributesUC()
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
			this.btnDefaultFillStyle = new Nevron.UI.WinForm.Controls.NButton();
			this.btnDefaultBorder = new Nevron.UI.WinForm.Controls.NButton();
			this.btnBar3FillStyle = new Nevron.UI.WinForm.Controls.NButton();
			this.btnBar3Border = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// btnDefaultFillStyle
			// 
			this.btnDefaultFillStyle.Location = new System.Drawing.Point(5, 7);
			this.btnDefaultFillStyle.Name = "btnDefaultFillStyle";
			this.btnDefaultFillStyle.Size = new System.Drawing.Size(170, 23);
			this.btnDefaultFillStyle.TabIndex = 0;
			this.btnDefaultFillStyle.Text = "Default Bar Fill Style...";
			this.btnDefaultFillStyle.Click += new System.EventHandler(this.DefaultFillStyle_Click);
			// 
			// btnDefaultBorder
			// 
			this.btnDefaultBorder.Location = new System.Drawing.Point(5, 39);
			this.btnDefaultBorder.Name = "btnDefaultBorder";
			this.btnDefaultBorder.Size = new System.Drawing.Size(170, 23);
			this.btnDefaultBorder.TabIndex = 1;
			this.btnDefaultBorder.Text = "Default Bar Border...";
			this.btnDefaultBorder.Click += new System.EventHandler(this.DefaultBorder_Click);
			// 
			// btnBar3FillStyle
			// 
			this.btnBar3FillStyle.Location = new System.Drawing.Point(5, 98);
			this.btnBar3FillStyle.Name = "btnBar3FillStyle";
			this.btnBar3FillStyle.Size = new System.Drawing.Size(170, 23);
			this.btnBar3FillStyle.TabIndex = 2;
			this.btnBar3FillStyle.Text = "Bar #3 Fill Style...";
			this.btnBar3FillStyle.Click += new System.EventHandler(this.Bar3FillStyle_Click);
			// 
			// btnBar3Border
			// 
			this.btnBar3Border.Location = new System.Drawing.Point(5, 130);
			this.btnBar3Border.Name = "btnBar3Border";
			this.btnBar3Border.Size = new System.Drawing.Size(170, 23);
			this.btnBar3Border.TabIndex = 3;
			this.btnBar3Border.Text = "Bar #3 Border...";
			this.btnBar3Border.Click += new System.EventHandler(this.Bar3Border_Click);
			// 
			// NSeriesAttribsAppearanceUC
			// 
			this.Controls.Add(this.btnBar3FillStyle);
			this.Controls.Add(this.btnBar3Border);
			this.Controls.Add(this.btnDefaultFillStyle);
			this.Controls.Add(this.btnDefaultBorder);
			this.Name = "NSeriesAttribsAppearanceUC";
			this.Size = new System.Drawing.Size(180, 190);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Series Appearance Attributes");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage)); 
            
			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // apply lighting and projectection
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// setup bar series
			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.DataLabelStyle.Visible = false;
			m_Bar.FillStyle = new NColorFillStyle(LightGreen);
			m_Bar.Name = "Bar";

			// fill data
			m_Bar.AddDataPoint(new NDataPoint(10));
			m_Bar.AddDataPoint(new NDataPoint(20));
			m_Bar.AddDataPoint(new NDataPoint(30));

			// set an individual Fill Style and Stroke Style for data point #3
			NDataPoint dp = new NDataPoint(25);
			dp[DataPointValue.FillStyle] = new NGradientFillStyle(LightOrange, DarkOrange);
			dp[DataPointValue.StrokeStyle] = new NStrokeStyle(1, DarkOrange, LinePattern.Dot, 0, 1);
			m_Bar.AddDataPoint(dp);

			m_Bar.AddDataPoint(new NDataPoint(29));
			m_Bar.AddDataPoint(new NDataPoint(27));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);
		}

		private void DefaultFillStyle_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if(NFillStyleTypeEditor.Edit(m_Bar.FillStyle, out fillStyleResult))
			{
				m_Bar.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void DefaultBorder_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if(NStrokeStyleTypeEditor.Edit(m_Bar.BorderStyle, out strokeStyleResult))
			{
				m_Bar.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void Bar3FillStyle_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NFillStyle inFillStyle = (NFillStyle)m_Bar.FillStyles[3];

			if(NFillStyleTypeEditor.Edit(inFillStyle, false, out fillStyleResult))
			{
				m_Bar.FillStyles[3] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void Bar3Border_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NStrokeStyle inStrokeStyle = (NStrokeStyle)m_Bar.BorderStyles[3];

			if(NStrokeStyleTypeEditor.Edit(inStrokeStyle, false, out strokeStyleResult))
			{
				m_Bar.BorderStyles[3] = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}