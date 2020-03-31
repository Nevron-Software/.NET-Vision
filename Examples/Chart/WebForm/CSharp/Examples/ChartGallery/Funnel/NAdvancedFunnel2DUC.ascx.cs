using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAdvancedFunnel2DUC : NExampleUC
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Funnel Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
			legend.Data.RowCount = 2;

			NFunnelChart chart = new NFunnelChart();
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(12, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(80, NRelativeUnit.ParentPercentage),
				new NLength(68, NRelativeUnit.ParentPercentage));

			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NFunnelSeries funnel = (NFunnelSeries)chart.Series.Add(SeriesType.Funnel);
			funnel.BorderStyle.Color = Color.LemonChiffon;
			funnel.Legend.DisplayOnLegend = legend;
			funnel.Legend.Format = "<percent>";
			funnel.Legend.Mode = SeriesLegendMode.DataPoints;
			funnel.DataLabelStyle.Format = "<value> [<xsize>]";
			funnel.UseXSizes = true;
			funnel.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			funnel.XSizes.ValueFormatter = new NNumericValueFormatter("0.00");

			GenerateData(funnel);

			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithEnumValues(FunnelLabelModeDropDownList, typeof(FunnelLabelMode));
				FunnelLabelModeDropDownList.SelectedIndex = (int)FunnelLabelMode.RightAligned;

				WebExamplesUtilities.FillComboWithValues(FunnelPointGapDropDownList, 0, 15, 1);
				FunnelPointGapDropDownList.SelectedIndex = 6;

				WebExamplesUtilities.FillComboWithValues(FunnelRadiusDropDownList, 0, 100, 10);
				FunnelRadiusDropDownList.SelectedIndex = (int)(chart.Width / 10.0f);

				WebExamplesUtilities.FillComboWithValues(FunnelArrowLengthDropDownList, 0, 10, 1);
				FunnelArrowLengthDropDownList.SelectedIndex = 1;
			}

			// init funnel label mode
			funnel.LabelMode = (FunnelLabelMode)FunnelLabelModeDropDownList.SelectedIndex;

			HorzAlign ha = HorzAlign.Center;

			switch(funnel.LabelMode)
			{
				case FunnelLabelMode.Left:
				case FunnelLabelMode.LeftAligned:
					ha = HorzAlign.Right;
					break;

				case FunnelLabelMode.Right:
				case FunnelLabelMode.RightAligned:
					ha = HorzAlign.Left;
					break;
			}

			funnel.DataLabelStyle.TextStyle.StringFormatStyle.HorzAlign = ha;

			// arrow length
			funnel.DataLabelStyle.ArrowLength = new NLength((float)FunnelArrowLengthDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);

			// funnel radius
			chart.Width = FunnelRadiusDropDownList.SelectedIndex * 10;

			funnel.FunnelPointGap = FunnelPointGapDropDownList.SelectedIndex / 10.0f;
		}

		private void GenerateData(NFunnelSeries funnel)
		{
			funnel.ClearDataPoints();

			double dSizeX = 100;
			int i = 0;

			for(i = 0; i < 10; i++)
			{
				funnel.Values.Add(Random.NextDouble() + 1);
				funnel.XSizes.Add(dSizeX);

				dSizeX -= Random.NextDouble() * 9;
			}

			funnel.Values.Add(0.0);
			funnel.XSizes.Add(dSizeX);

			for (i = 0; i < arrCustomColors1.Length; i++)
			{
				funnel.FillStyles[i] = arrCustomColors1[i];
			}
		}
	}
}
