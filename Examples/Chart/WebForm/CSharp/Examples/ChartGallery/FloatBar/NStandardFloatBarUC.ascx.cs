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
	public partial class NStandardFloatBarUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, typeof(BarShape));
				BarShapeDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithPercents(WidthPercentDropDownList, 10);
				WidthPercentDropDownList.SelectedIndex = 6;

				WebExamplesUtilities.FillComboWithPercents(DepthPercentDropDownList, 10);
				DepthPercentDropDownList.SelectedIndex = 3;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

            // add interlace stripe
            NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			// setup floatbar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.DataLabelStyle.Format = "<label>";
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center;

			floatBar.BarShape = (BarShape)BarShapeDropDownList.SelectedIndex;
			floatBar.WidthPercent = WidthPercentDropDownList.SelectedIndex * 10;
			floatBar.DepthPercent = DepthPercentDropDownList.SelectedIndex * 10;

			// add bars
			floatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
			floatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
			floatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
			floatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
			floatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
			floatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
