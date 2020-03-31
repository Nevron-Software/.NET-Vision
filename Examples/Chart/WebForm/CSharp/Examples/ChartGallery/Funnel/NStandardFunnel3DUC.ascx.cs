using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardFunnel3DUC : NExampleUC
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Funnel Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			NFunnelChart chart = new NFunnelChart();
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(new NLength(85, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));            
			chart.Enable3D = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
			chart.Projection.Elevation = 18;

			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NFunnelSeries funnel = (NFunnelSeries)chart.Series.Add(SeriesType.Funnel);
			funnel.BorderStyle.Color = Color.LemonChiffon;
			funnel.Legend.DisplayOnLegend = legend;
			funnel.Legend.Mode = SeriesLegendMode.DataPoints;
			funnel.DataLabelStyle.Format = "<percent>";

			funnel.Values.Add(20.0);
			funnel.Values.Add(10.0);
			funnel.Values.Add(15.0);
			funnel.Values.Add(7.0);
			funnel.Values.Add(28.0);

			funnel.Labels.Add("Awareness");
			funnel.Labels.Add("First Hear");
			funnel.Labels.Add("Further Learn");
			funnel.Labels.Add("Liking");
			funnel.Labels.Add("Decision");

            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Bright);

            for (int i = 0; i < funnel.Values.Count; i++)
            {
                funnel.FillStyles[i] = palette.SeriesColors[i % palette.SeriesColors.Count];
            }

			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithEnumValues(FunnelLabelModeDropDownList, typeof(FunnelLabelMode));
				FunnelLabelModeDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(FunnelRadiusDropDownList, 0, 100, 10);
				FunnelRadiusDropDownList.SelectedIndex = (int)(chart.Width / 10);

				WebExamplesUtilities.FillComboWithValues(FunnelPointGapDropDownList, 0, 100, 10);
				FunnelPointGapDropDownList.SelectedIndex = (int)(funnel.FunnelPointGap / 10);

				WebExamplesUtilities.FillComboWithValues(NeckWidthDropDownList, 0, 100, 10);
				NeckWidthDropDownList.SelectedIndex = (int)(funnel.NeckWidthPercent / 10);

				WebExamplesUtilities.FillComboWithValues(NeckHeightDropDownList, 0, 100, 10);
				NeckHeightDropDownList.SelectedIndex = (int)(funnel.NeckHeightPercent / 10);

                WebExamplesUtilities.FillComboWithValues(LabelArrowLengthDropDownList, 0, 10, 1);
				LabelArrowLengthDropDownList.SelectedIndex = (int)(funnel.DataLabelStyle.ArrowLength.Value);
			}

			SetLabelMode(funnel);

			// set funnel arrow length
			funnel.DataLabelStyle.ArrowLength = new NLength((float)(LabelArrowLengthDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage);

			// set funnel radius
			nChartControl1.Charts[0].Width = FunnelRadiusDropDownList.SelectedIndex * 10.0f;

			// set funnel gap
			funnel.FunnelPointGap = FunnelPointGapDropDownList.SelectedIndex;

			// set neck width
			funnel.NeckWidthPercent = NeckWidthDropDownList.SelectedIndex * 10.0f;

			// set neck height
			funnel.NeckHeightPercent = NeckHeightDropDownList.SelectedIndex * 10.0f;
		}


		private void SetLabelMode(NFunnelSeries funnel)
		{
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
		}
	}
}
