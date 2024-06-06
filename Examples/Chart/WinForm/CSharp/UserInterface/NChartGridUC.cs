using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Chart.WinForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
	public class NChartGridUC : NExampleBaseUC
	{
		private NChart m_Chart1;
		private NChart m_Chart2;
		private NChartGridControl nChartGridControl1;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox ChartInteractivityComboBox;
		private System.ComponentModel.Container components = null;

		public NChartGridUC()
		{
			InitializeComponent();

			ChartInteractivityComboBox.Items.Add("Tooltips");
			ChartInteractivityComboBox.Items.Add("Mouse Cursor Change");
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
			this.nChartGridControl1 = new Nevron.Chart.WinForm.NChartGridControl();
			this.label1 = new System.Windows.Forms.Label();
			this.ChartInteractivityComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// nChartGridControl1
			// 
			this.nChartGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nChartGridControl1.BindToChart = false;
			this.nChartGridControl1.ChartControl = null;
			this.nChartGridControl1.ChartGridButtonsMask = Nevron.Chart.WinForm.ChartGridButtonsMask.All;
			this.nChartGridControl1.Location = new System.Drawing.Point(7, 7);
			this.nChartGridControl1.Name = "nChartGridControl1";
			this.nChartGridControl1.Size = new System.Drawing.Size(554, 171);
			this.nChartGridControl1.TabIndex = 0;
			this.nChartGridControl1.ToolbarVisible = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(7, 189);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Chart Interactivity:";
			// 
			// ChartInteractivityComboBox
			// 
			this.ChartInteractivityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ChartInteractivityComboBox.Location = new System.Drawing.Point(103, 186);
			this.ChartInteractivityComboBox.Name = "ChartInteractivityComboBox";
			this.ChartInteractivityComboBox.Size = new System.Drawing.Size(198, 21);
			this.ChartInteractivityComboBox.TabIndex = 2;
			this.ChartInteractivityComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartInteractivityComboBox_SelectedIndexChanged);
			// 
			// NChartGridUC
			// 
			this.Controls.Add(this.nChartGridControl1);
			this.Controls.Add(this.ChartInteractivityComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NChartGridUC";
			this.Size = new System.Drawing.Size(568, 217);
			this.Load += new System.EventHandler(this.NChartGridUC_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

		}


		private void NChartGridUC_Load(object sender, System.EventArgs e)
		{
			// set some background
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Built-in Grid Component");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			

			// hide the legend
			((NLegend)nChartControl1.Legends[0]).Mode = LegendMode.Disabled;

			// create two charts
			m_Chart1 = nChartControl1.Charts[0];
			m_Chart1.Name = "Bar & Area Chart";

			m_Chart2 = new NCartesianChart();
			nChartControl1.Charts.Add(m_Chart2);
			m_Chart2.Name = "Line & Point Chart";

			// position the charts using fit margin mode
			m_Chart1.BoundsMode = BoundsMode.Fit;
			m_Chart1.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(5, NRelativeUnit.ParentPercentage));
			m_Chart1.Size = new NSizeL(new NLength(40, NRelativeUnit.ParentPercentage), new NLength(95, NRelativeUnit.ParentPercentage));

			
			m_Chart2.BoundsMode = BoundsMode.Fit;
			m_Chart2.Location = new NPointL(new NLength(55, NRelativeUnit.ParentPercentage), new NLength(4, NRelativeUnit.ParentPercentage));
			m_Chart2.Size = new NSizeL(new NLength(40, NRelativeUnit.ParentPercentage), new NLength(95, NRelativeUnit.ParentPercentage));

			// second one is date time
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			m_Chart2.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			// add series to first chart
			NBarSeries bar = (NBarSeries)m_Chart1.Series.Add(SeriesType.Bar);
			bar.Name = "Bar";
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandom(Random, 5);

			NAreaSeries area = (NAreaSeries)m_Chart1.Series.Add(SeriesType.Area);
			area.DataLabelStyle.Visible = false;
			area.FillStyle = new NColorFillStyle(Color.SkyBlue);
			area.Name = "Area";
			area.Values.FillRandom(Random, 5);

			// add series to second chart
			NLineSeries line = (NLineSeries)m_Chart2.Series.Add(SeriesType.Line);
			line.DataLabelStyle.Visible = false;
			line.FillStyle = new NColorFillStyle(Color.DarkOrange);
			line.LineSegmentShape = LineSegmentShape.Tape;
			line.Name = "Line";
			line.UseXValues = true;
			line.Values.FillRandom(Random, 3);
			line.XValues.Add(6);
			line.XValues.ValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);

			for (int i = 1; i < 3; i++)
			{
				line.XValues.Add((double)line.XValues[i - 1] + Random.Next(5,100));
			}

			NPointSeries point = (NPointSeries)m_Chart2.Series.Add(SeriesType.Point);
			point.DataLabelStyle.Visible = false;
			point.PointShape = PointShape.Sphere;
			point.Name = "Point";
			point.UseXValues = true;
			point.Values.FillRandom(Random, 3);
			point.XValues.Add(20);
			point.XValues.ValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);

			for (int i = 1; i < 3; i++)
			{
				point.XValues.Add((double)point.XValues[i - 1] + Random.Next(5, 100));
			}

			// bind the grid to the chart
			nChartGridControl1.ChartControl = nChartControl1;

			nChartControl1.InteractivityStyle.Tooltip.Text = "The background of the control";
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			ChartInteractivityComboBox.SelectedIndex = 0;
		}

		private void ChartInteractivityComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Controller.Tools.Clear();

			switch (ChartInteractivityComboBox.SelectedIndex)
			{
				case 0:
					nChartControl1.Controller.Tools.Add(new NTooltipTool());
					break;

				case 1:
					nChartControl1.Controller.Tools.Add(new NCursorTool());
					break;
			}
		}
	}
}