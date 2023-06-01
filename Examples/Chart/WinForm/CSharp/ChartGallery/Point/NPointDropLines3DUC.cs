using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPointDropLines3DUC : NExampleBaseUC
	{
		private NPointSeries m_Point;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowVerticalDropLinesCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowHorizontalDropLinesCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowDepthDropLinesCheckBox;
		private System.ComponentModel.Container components = null;

		public NPointDropLines3DUC()
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
			this.ShowVerticalDropLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowHorizontalDropLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowDepthDropLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ShowVerticalDropLinesCheckBox
			// 
			this.ShowVerticalDropLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowVerticalDropLinesCheckBox.Location = new System.Drawing.Point(0, 29);
			this.ShowVerticalDropLinesCheckBox.Name = "ShowVerticalDropLinesCheckBox";
			this.ShowVerticalDropLinesCheckBox.Size = new System.Drawing.Size(172, 21);
			this.ShowVerticalDropLinesCheckBox.TabIndex = 1;
			this.ShowVerticalDropLinesCheckBox.Text = "Show Vertical Drop Lines";
			this.ShowVerticalDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowVerticalDropLinesCheckBox_CheckedChanged);
			// 
			// ShowHorizontalDropLinesCheckBox
			// 
			this.ShowHorizontalDropLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowHorizontalDropLinesCheckBox.Location = new System.Drawing.Point(0, 2);
			this.ShowHorizontalDropLinesCheckBox.Name = "ShowHorizontalDropLinesCheckBox";
			this.ShowHorizontalDropLinesCheckBox.Size = new System.Drawing.Size(172, 21);
			this.ShowHorizontalDropLinesCheckBox.TabIndex = 0;
			this.ShowHorizontalDropLinesCheckBox.Text = "Show Horizontal Drop Lines";
			this.ShowHorizontalDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowHorizontalDropLinesCheckBox_CheckedChanged);
			// 
			// ShowDepthDropLinesCheckBox
			// 
			this.ShowDepthDropLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowDepthDropLinesCheckBox.Location = new System.Drawing.Point(0, 56);
			this.ShowDepthDropLinesCheckBox.Name = "ShowDepthDropLinesCheckBox";
			this.ShowDepthDropLinesCheckBox.Size = new System.Drawing.Size(172, 21);
			this.ShowDepthDropLinesCheckBox.TabIndex = 2;
			this.ShowDepthDropLinesCheckBox.Text = "Show Depth Drop Lines";
			this.ShowDepthDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowDepthDropLinesCheckBox_CheckedChanged);
			// 
			// NPointDropLines3DUC
			// 
			this.Controls.Add(this.ShowDepthDropLinesCheckBox);
			this.Controls.Add(this.ShowHorizontalDropLinesCheckBox);
			this.Controls.Add(this.ShowVerticalDropLinesCheckBox);
			this.Name = "NPointDropLines3DUC";
			this.Size = new System.Drawing.Size(180, 320);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Point Chart Droplines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = chart.Height = chart.Depth = 50;
			chart.Axis(StandardAxis.Depth).Visible = true;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = new NLinearScaleConfigurator();

			// add interlace stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// setup point series
			m_Point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			m_Point.Name = "Point Series";
			m_Point.InflateMargins = true;
			m_Point.UseXValues = true;
			m_Point.UseZValues = true;
			m_Point.Size = new NLength(10, NGraphicsUnit.Point);
			m_Point.DataLabelStyle.Visible = false;

			Random random = new Random();

			for (int i = 0; i < 100; i += 5)
			{
				m_Point.Values.Add(random.Next(200) - 100);
				m_Point.XValues.Add(random.Next(200) - 100);
				m_Point.ZValues.Add(random.Next(200) - 100);
			}

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// apply interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// init form controls
			ShowVerticalDropLinesCheckBox.Checked = true;
			ShowHorizontalDropLinesCheckBox.Checked = true;
			ShowDepthDropLinesCheckBox.Checked = true;
		}

		private void ShowVerticalDropLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Point.ShowVerticalDropLines = ShowVerticalDropLinesCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ShowHorizontalDropLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Point.ShowHorizontalDropLines = ShowHorizontalDropLinesCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ShowDepthDropLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Point.ShowDepthDropLines = ShowDepthDropLinesCheckBox.Checked;
			nChartControl1.Refresh();
		}
	}
}