using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDateTimeFloatBarUC : NExampleUC
	{
/*		protected Label Label1;
		protected Label Label2;
		protected Label Label3;
		protected DropDownList BarStyleDropDownList;
		protected DropDownList WidthPercentDropDownList;
		protected DropDownList DepthPercentDropDownList;*/

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("DateTime Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			// setup X axis
			NDateTimeScaleConfigurator scaleX = new NDateTimeScaleConfigurator();
			scaleX.LabelStyle.Angle = new NScaleLabelAngle(90);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// create the float bar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.UseXValues = true;
			floatBar.UseZValues = false;
			floatBar.InflateMargins = true;
			floatBar.DataLabelStyle.Visible = false;
			floatBar.ShadowStyle.Type = ShadowType.Solid;
			floatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0);
			floatBar.Values.ValueFormatter = new NNumericValueFormatter("0.0");
			floatBar.EndValues.ValueFormatter = new NNumericValueFormatter("0.0");

			// show the begin end values in the legend
			floatBar.Legend.Format = "<begin> - <end>";
			floatBar.Legend.Mode = SeriesLegendMode.DataPoints;

			GenerateData(floatBar);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		void GenerateData(NFloatBarSeries floatBar)
		{
			const int nCount = 6;

			floatBar.Values.Clear();
			floatBar.EndValues.Clear();
			floatBar.XValues.Clear();

			// generate Y values
			for(int i = 0; i < nCount; i++)
			{
				double dBeginValue = Random.NextDouble() * 5;
				double dEndValue = dBeginValue + 2 + Random.NextDouble();
				floatBar.Values.Add(dBeginValue);
				floatBar.EndValues.Add(dEndValue);
			}

			// generate X values
			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				floatBar.XValues.Add(dt);
			}
		}
	}
}
