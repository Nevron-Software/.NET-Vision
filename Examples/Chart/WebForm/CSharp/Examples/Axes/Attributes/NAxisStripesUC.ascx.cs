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
	public partial class NAxisStripesUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(LABeginValueDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithValues(LAEndValueDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithValues(BABeginValueDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithValues(BAEndValueDropDownList, 0, 100, 10);

                WebExamplesUtilities.FillComboWithColorNames(LAColorDropDownList, KnownColor.LightSteelBlue);
                WebExamplesUtilities.FillComboWithColorNames(BAStripeColorDropDownList, KnownColor.LightSteelBlue);

				// init form controls
				LABeginValueDropDownList.SelectedIndex = 2;
				LAEndValueDropDownList.SelectedIndex = 6;

				BABeginValueDropDownList.SelectedIndex = 2;
				BAEndValueDropDownList.SelectedIndex = 6;

				LAShowAtBackWallCheckBox.Checked = true;
				LAShowAtLeftWallCheckBox.Checked = true;
				BAShowAtBackWallCheckBox.Checked = true;
				BAShowAtFloorCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel header = nChartControl1.Labels.AddHeader("Axis Stripes");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = nChartControl1.Charts[0];

			chart.Enable3D = true;

            // set projection and lighting
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

			// configure the chart margins
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(80, NRelativeUnit.ParentPercentage),
				new NLength(78, NRelativeUnit.ParentPercentage));

			// disable the depth axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

            // Add stripes for the left and the bottom axes
            NAxisStripe stripeY = chart.Axis(StandardAxis.PrimaryY).Stripes.Add(2, 3);
            NAxisStripe stripeX = chart.Axis(StandardAxis.PrimaryX).Stripes.Add(2, 3);

            stripeY.From = LABeginValueDropDownList.SelectedIndex * 10;
            stripeY.To = LAEndValueDropDownList.SelectedIndex * 10;

            stripeY.FillStyle = new NColorFillStyle(Color.FromArgb(125, WebExamplesUtilities.ColorFromDropDownList(LAColorDropDownList)));
            stripeY.SetShowAtWall(ChartWallType.Back, LAShowAtBackWallCheckBox.Checked);
            stripeY.SetShowAtWall(ChartWallType.Left, LAShowAtLeftWallCheckBox.Checked);

            stripeX.From = BABeginValueDropDownList.SelectedIndex * 10;
            stripeX.To = BAEndValueDropDownList.SelectedIndex * 10;
            stripeX.FillStyle = new NColorFillStyle(Color.FromArgb(125, WebExamplesUtilities.ColorFromDropDownList(BAStripeColorDropDownList)));
            stripeX.SetShowAtWall(ChartWallType.Back, BAShowAtBackWallCheckBox.Checked);
            stripeX.SetShowAtWall(ChartWallType.Floor, BAShowAtFloorCheckBox.Checked);

			// Create a point series
			NPointSeries pnt = (NPointSeries)chart.Series.Add(SeriesType.Point);
			pnt.InflateMargins = true;
			pnt.UseXValues = true;
			pnt.Name = "Series 1";
			pnt.DataLabelStyle.Format = "<value>";

			// Add some data
			pnt.Values.Add(31);
			pnt.Values.Add(67);
			pnt.Values.Add(12);
			pnt.Values.Add(84);
			pnt.Values.Add(90);
			pnt.XValues.Add(10);
			pnt.XValues.Add(36);
			pnt.XValues.Add(52);
			pnt.XValues.Add(62);
			pnt.XValues.Add(88);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}
	}
}
