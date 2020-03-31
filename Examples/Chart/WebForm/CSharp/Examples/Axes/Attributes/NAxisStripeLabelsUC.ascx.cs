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
	public partial class NAxisStripeLabelsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(LABeginValueDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithValues(LAEndValueDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithValues(BABeginValueDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithValues(BAEndValueDropDownList, 0, 100, 10);

				// init form controls
				LABeginValueDropDownList.SelectedIndex = 2;
				LAEndValueDropDownList.SelectedIndex = 6;

				BABeginValueDropDownList.SelectedIndex = 2;
				BAEndValueDropDownList.SelectedIndex = 6;

				// init the form controls
				WebExamplesUtilities.FillComboWithEnumNames(LAContentAlignmentDropDownList, typeof(ContentAlignment));
				LAContentAlignmentDropDownList.SelectedIndex = 0;
				LATextTextBox.Text = "Left Axis Line Text";

				WebExamplesUtilities.FillComboWithEnumNames(BAContentAlignmentDropDownList, typeof(ContentAlignment));
				BAContentAlignmentDropDownList.SelectedIndex = 0;
				BATextTextBox.Text = "Bottom Axis Line Text";	
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Axis Stripe Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			NChart chart = nChartControl1.Charts[0];

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

			stripeY.FillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Blue));
            stripeY.From = LABeginValueDropDownList.SelectedIndex * 10;
            stripeY.To = LAEndValueDropDownList.SelectedIndex * 10;
            stripeY.SetShowAtWall(ChartWallType.Back, true);
			stripeY.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), LAContentAlignmentDropDownList.SelectedItem.Text);
			stripeY.Text = LATextTextBox.Text;

			stripeX.FillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Blue));
            stripeX.From = BABeginValueDropDownList.SelectedIndex * 10;
            stripeX.To = BAEndValueDropDownList.SelectedIndex * 10;
            stripeX.SetShowAtWall(ChartWallType.Back, true);
			stripeX.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), BAContentAlignmentDropDownList.SelectedItem.Text);
			stripeX.Text = BATextTextBox.Text;

			// Create a point series
			NPointSeries pnt = (NPointSeries)chart.Series.Add(SeriesType.Point);
			pnt.InflateMargins = true;
			pnt.UseXValues = true;
			pnt.Name = "Series 1";
			pnt.DataLabelStyle.Visible = false;

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

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
