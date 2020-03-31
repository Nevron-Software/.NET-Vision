using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAxisMinMaxUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Min Max");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            NLegend legend = nChartControl1.Legends[0];
            legend.Location = new NPointL(
                new NLength(98, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));
            legend.Data.ExpandMode = LegendExpandMode.ColsOnly;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage), 
				new NLength(13, NRelativeUnit.ParentPercentage)); 
			chart.Size = new NSizeL(
				new NLength(96, NRelativeUnit.ParentPercentage), 
				new NLength(85, NRelativeUnit.ParentPercentage));

			chart.PaintCallback = new PaintCallback(this);

			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.RoundToTickMin = false;
			linearScaleConfigurator.RoundToTickMax = false;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash;

			NOrdinalScaleConfigurator ordinalScaleConfigurtor = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScaleConfigurtor.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScaleConfigurtor.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash;

			NewPointSeries(chart, Color.Khaki);
			NewPointSeries(chart, Color.Green);

			GenerateData(6);
		}

		#region Nested Classes

		public class PaintCallback : NPaintCallback
		{
			#region Constructors

			public PaintCallback(NAxisMinMaxUC userControl)
			{
                m_UserControl = userControl;
			}

			#endregion

			#region INPaintCallback Members

			public override void OnBeforePaint(NPanel panel, NPanelPaintEventArgs eventArgs)
			{
				NChart chart = panel as NChart;
				NRange1DD rulerRange = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange;

                NLabel label = new NLabel();
                label.Location = new NPointL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(0, NRelativeUnit.ParentPercentage));
                label.ContentAlignment = ContentAlignment.BottomLeft;
                label.TextStyle.FontStyle.EmSize = new NLength(10);
                label.Text = " Min[" + rulerRange.Begin + "] Max[" + rulerRange.End + "]";

                chart.ChildPanels.Add(label);
				chart.RecalcLayout(eventArgs.Context);
			}

			#endregion

			#region Fields

            NAxisMinMaxUC m_UserControl;

			#endregion
		}

		#endregion

		private NLineSeries NewPointSeries(NChart chart, Color color)
		{
            NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
            line.Name = "Line Series";
            line.BorderStyle = new NStrokeStyle(color);
            line.DataLabelStyle.Visible = false;
            NMarkerStyle marker = new NMarkerStyle();
            marker.PointShape = PointShape.Ellipse;
            marker.Visible = true;
            marker.FillStyle = new NColorFillStyle(color);
            line.MarkerStyle = marker;

            return line;
		}

		private void GenerateData(int itemCount)
		{
			NChart chart = nChartControl1.Charts[0];

			int seriesCount = chart.Series.Count;

			for(int i = 0; i < seriesCount; i++)
			{
				NSeries series = (NSeries)chart.Series[i];
				series.Values.FillRandomRange(Random, itemCount, -100, 100);
			}
		}

		protected void ChangeDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateData(6);
		}
	}
}
