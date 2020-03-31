using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NHorizontalFloatBarUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroll;
		private System.ComponentModel.Container components = null;

		public NHorizontalFloatBarUC()
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
			this.label2 = new System.Windows.Forms.Label();
			this.WidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Width %:";
			// 
			// WidthScroll
			// 
			this.WidthScroll.LargeChange = 1;
			this.WidthScroll.Location = new System.Drawing.Point(9, 27);
			this.WidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.WidthScroll.Name = "WidthScroll";
			this.WidthScroll.Size = new System.Drawing.Size(160, 18);
			this.WidthScroll.TabIndex = 11;
			this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			// 
			// NHorizontalFloatBarUC
			// 
			this.Controls.Add(this.WidthScroll);
			this.Controls.Add(this.label2);
			this.Name = "NHorizontalFloatBarUC";
			this.Size = new System.Drawing.Size(180, 86);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Gantt");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Projection.ViewerRotation = 270;
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup the value axis
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			dateTimeScale.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back };

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back };
			stripStyle.Interlaced = true;
			dateTimeScale.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = dateTimeScale;
			chart.Axis(StandardAxis.PrimaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true, 0, 100);

			// label the X axis
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Labels.Add("Market Research");
			ordinalScale.Labels.Add("Specifications");
			ordinalScale.Labels.Add("Architecture");
			ordinalScale.Labels.Add("Project Planning");
			ordinalScale.Labels.Add("Detailed Design");
			ordinalScale.Labels.Add("Development");
			ordinalScale.Labels.Add("Test Plan");
			ordinalScale.Labels.Add("Testing and QA");
			ordinalScale.Labels.Add("Documentation");

			// create a floatbar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.BeginValues.ValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			floatBar.EndValues.ValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			floatBar.DataLabelStyle.Visible = false;

			AddDataPoint(floatBar, new DateTime(2009, 2, 2), new DateTime(2009, 2, 16));
			AddDataPoint(floatBar, new DateTime(2009, 2, 16), new DateTime(2009, 3, 2));
			AddDataPoint(floatBar, new DateTime(2009, 3, 2), new DateTime(2009, 3, 16));
			AddDataPoint(floatBar, new DateTime(2009, 3, 9), new DateTime(2009, 3, 23));
			AddDataPoint(floatBar, new DateTime(2009, 3, 16), new DateTime(2009, 3, 30));
			AddDataPoint(floatBar, new DateTime(2009, 3, 23), new DateTime(2009, 4, 27));
			AddDataPoint(floatBar, new DateTime(2009, 4, 13), new DateTime(2009, 4, 27));
			AddDataPoint(floatBar, new DateTime(2009, 4, 20), new DateTime(2009, 5, 4));
			AddDataPoint(floatBar, new DateTime(2009, 4, 27), new DateTime(2009, 5, 4));

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			WidthScroll.Value = (int)floatBar.WidthPercent;
		}

		private void AddDataPoint(NFloatBarSeries floatBar, DateTime dtBegin, DateTime dtEnd)
		{
			floatBar.BeginValues.Add(dtBegin.ToOADate());
			floatBar.EndValues.Add(dtEnd.ToOADate());
		}

		private void WidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.WidthPercent = WidthScroll.Value;
			nChartControl1.Refresh();
		}
	}
}