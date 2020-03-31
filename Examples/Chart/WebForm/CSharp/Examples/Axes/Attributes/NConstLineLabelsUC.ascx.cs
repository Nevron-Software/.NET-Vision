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
	public partial class NConstLineLabelsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// disable frame
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Axis Const Line Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            NChart chart = nChartControl1.Charts[0];

            // disable the depth axis
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // switch the X axis to linear as well
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

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

            // Add a constline for the left axis
            NAxisConstLine cl1 = chart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
            cl1.Value = 90;

            // Add a constline for the bottom axis
            NAxisConstLine cl2 = chart.Axis(StandardAxis.PrimaryX).ConstLines.Add();
            cl2.Value = 40;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

            if (!IsPostBack)
            {
                // init the form controls
                WebExamplesUtilities.FillComboWithValues(LAValueDropDownList, 0, 100, 10);
                LAValueDropDownList.SelectedIndex = (int)(cl1.Value / 10);
				WebExamplesUtilities.FillComboWithEnumNames(LAContentAlignmentDropDownList, typeof(ContentAlignment));
                LAContentAlignmentDropDownList.SelectedIndex = 0;
				LATextTextBox.Text = "Left Axis Line Text";

				WebExamplesUtilities.FillComboWithValues(BAValueDropDownList, 0, 100, 10);
				WebExamplesUtilities.FillComboWithEnumNames(BAContentAlignmentDropDownList, typeof(ContentAlignment));
                BAValueDropDownList.SelectedIndex = (int)(cl2.Value / 10);
				BAContentAlignmentDropDownList.SelectedIndex = 0;
				BATextTextBox.Text = "Bottom Axis Line Text";
            }

            NAxisConstLine leftAxisConstLine = chart.Axis(StandardAxis.PrimaryY).ConstLines[0];
            leftAxisConstLine.Value = (LAValueDropDownList.SelectedIndex * 10);
            leftAxisConstLine.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), LAContentAlignmentDropDownList.SelectedItem.Text);
            leftAxisConstLine.Text = LATextTextBox.Text;

            // bottom axis
            NAxisConstLine bottomAxisConstline = chart.Axis(StandardAxis.PrimaryX).ConstLines[0];
            bottomAxisConstline.Value = (BAValueDropDownList.SelectedIndex * 10);
            bottomAxisConstline.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), BAContentAlignmentDropDownList.SelectedItem.Text);
            bottomAxisConstline.Text = BATextTextBox.Text;
		}
	}
}
