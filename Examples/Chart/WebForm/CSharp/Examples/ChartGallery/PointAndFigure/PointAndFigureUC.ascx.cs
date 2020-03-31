using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class PointAndFigureUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WebExamplesUtilities.FillComboWithColorNames(UpColorDropDownList, KnownColor.Red);
                WebExamplesUtilities.FillComboWithColorNames(DownColorDropDownList, KnownColor.Black);
                ProportionalXCheckBox.Checked = false;
                ProportionalYCheckBox.Checked = false;
                WebExamplesUtilities.FillComboWithFloatValues(BoxSizeDropdownlist, 0.5F, 10, 0.5F);
                BoxSizeDropdownlist.SelectedIndex = 9;
                WebExamplesUtilities.FillComboWithValues(ReversalAmountDropDownList, 1, 5, 1);
                ReversalAmountDropDownList.SelectedIndex = 2;
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Point and Figure");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
            NChart chart = nChartControl1.Charts[0];
            chart.BoundsMode = BoundsMode.Stretch;

            // setup X axis
            NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
            priceConfigurator.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
            priceConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount;
            priceConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
            priceConfigurator.MaxTickCount = 8;

            NNumericRangeSamplerProvider provider = new NNumericRangeSamplerProvider();
            provider.SamplingMode = SamplingMode.CustomStep;
            provider.CustomStep = 1;
            provider.UseOrigin = true;
            provider.Origin = -0.5;
            priceConfigurator.MajorGridStyle.RangeSamplerProvider = provider;
            
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

            // setup Y axis
            NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            scaleY.MajorTickMode = MajorTickMode.CustomStep;
            scaleY.CustomStep = 5;
            scaleY.OuterMajorTickStyle.Width = new NLength(0);
            scaleY.InnerMajorTickStyle.Width = new NLength(0);
            scaleY.AutoMinorTicks = true;
            scaleY.MinorTickCount = 1;
            scaleY.RoundToTickMin = false;
            scaleY.RoundToTickMax = false;
            scaleY.MajorGridStyle.LineStyle.Width = new NLength(0);
            scaleY.MinorGridStyle.LineStyle.Width = new NLength(1);
            scaleY.MinorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };

            float[] highValues = new float[20] { 21.3F, 42.4F, 11.2F, 65.7F, 38.0F, 71.3F, 49.54F, 83.7F, 13.9F, 56.12F, 27.43F, 23.1F, 31.0F, 75.4F, 9.3F, 39.12F, 10.0F, 44.23F, 21.76F, 49.2F };
            float[] lowValues = new float[20] { 12.1F, 14.32F, 8.43F, 36.0F, 13.5F, 47.34F, 24.54F, 68.11F, 6.87F, 23.3F, 12.12F, 14.54F, 25.0F, 37.2F, 3.9F, 23.11F, 1.9F, 14.0F, 8.23F, 34.21F };

            // setup Point & Figure series
            NPointAndFigureSeries pointAndFigure = (NPointAndFigureSeries)chart.Series.Add(SeriesType.PointAndFigure);

            pointAndFigure.UseXValues = true;

            // fill data
            pointAndFigure.HighValues.AddRange(highValues);
            pointAndFigure.LowValues.AddRange(lowValues);

            DateTime dt = new DateTime(2007, 1, 1);

            for (int i = 0; i < 20; i++)
            {
                pointAndFigure.XValues.Add(dt);
                dt = dt.AddDays(1);
            }

            double dBoxSize = Convert.ToDouble(BoxSizeDropdownlist.SelectedValue);

            pointAndFigure.BoxSize = dBoxSize;
            scaleY.CustomStep = dBoxSize;

            pointAndFigure.ProportionalX = ProportionalXCheckBox.Checked;
            pointAndFigure.ProportionalY = ProportionalYCheckBox.Checked;
            pointAndFigure.ReversalAmount = Convert.ToInt32(ReversalAmountDropDownList.SelectedValue);
            pointAndFigure.UpStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(UpColorDropDownList);
            pointAndFigure.DownStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(DownColorDropDownList);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
        }
    }
}