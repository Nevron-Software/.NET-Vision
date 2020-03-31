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
	public partial class NLabelsGeneralUC : NExampleUC
	{
		protected DropDownList HorizontalAlignDropDownList;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LabelTextBox.Text = "Chart Title";

				WebExamplesUtilities.FillComboWithPercents(HorizontalMarginDropDownList, 10);
				HorizontalMarginDropDownList.SelectedIndex = 5;

				WebExamplesUtilities.FillComboWithPercents(VerticalMarginDropDownList, 10);
				VerticalMarginDropDownList.SelectedIndex = 1;

				ContentAlignmentDropDownList.Items.Add("BottomCenter");
				ContentAlignmentDropDownList.Items.Add("BottomLeft");
				ContentAlignmentDropDownList.Items.Add("BottomRight");
				ContentAlignmentDropDownList.Items.Add("MiddleCenter");
				ContentAlignmentDropDownList.Items.Add("MiddleLeft");
				ContentAlignmentDropDownList.Items.Add("MiddleRight");
				ContentAlignmentDropDownList.Items.Add("TopCenter");
				ContentAlignmentDropDownList.Items.Add("TopLeft");
				ContentAlignmentDropDownList.Items.Add("TopRight");
				ContentAlignmentDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithFontNames(FontDropDownList, "Arial");
				WebExamplesUtilities.FillComboWithValues(FontSizeDropDownList, 8, 52, 1);
				FontSizeDropDownList.SelectedIndex = 2;

				WebExamplesUtilities.FillComboWithColorNames(FontColorDropDownList, KnownColor.Black);
				WebExamplesUtilities.FillComboWithValues(FontOrientationDropDownList, 0, 360, 10);

				HasBackplaneCheckBox.Checked = true;

				BackplaneStyleDropDownList.Items.Add("Rectangle");
				BackplaneStyleDropDownList.Items.Add("Ellipse");
				BackplaneStyleDropDownList.Items.Add("Circle");
				BackplaneStyleDropDownList.Items.Add("Cut Edge Rectangle");
				BackplaneStyleDropDownList.Items.Add("Smooth Edge Rectangle");
				BackplaneStyleDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// setup the label
            NLabel label = new NLabel();
			nChartControl1.Panels.Add(label);
			label.Text = LabelTextBox.Text;
			label.TextStyle.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(FontColorDropDownList));
			label.TextStyle.Orientation = FontOrientationDropDownList.SelectedIndex * 10;
			label.TextStyle.BackplaneStyle.Visible = HasBackplaneCheckBox.Checked;
			label.ContentAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), ContentAlignmentDropDownList.SelectedItem.Text);
			label.Location = new NPointL(
				new NLength(HorizontalMarginDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage),
                new NLength(VerticalMarginDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage));

            try
            {
                label.TextStyle.FontStyle = new NFontStyle(FontDropDownList.SelectedItem.Text, FontSizeDropDownList.SelectedIndex + 8); ;
            }
            catch
            {
            }

            BackplaneStyleDropDownList.Enabled = HasBackplaneCheckBox.Checked;

            if (HasBackplaneCheckBox.Checked)
            {
                label.TextStyle.BackplaneStyle.Shape = (BackplaneShape)BackplaneStyleDropDownList.SelectedIndex;
            }

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Fit;
			chart.Axis(StandardAxis.PrimaryX).Visible = false;
			chart.Axis(StandardAxis.PrimaryY).Visible = false;
			chart.Location = new NPointL(
				new NLength(15, NRelativeUnit.ParentPercentage),
				new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(60, NRelativeUnit.ParentPercentage));

			NBarSeries series = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series.DataLabelStyle.Visible = false;
			series.Values.AddRange(new double[]{ 16, 42, 56, 23, 47, 38 });

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(series);
		}
	}
}
