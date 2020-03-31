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
	public partial class NConstLinesUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			// disable frame
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel header = nChartControl1.Labels.AddHeader("Axis Const Lines");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            NChart chart = nChartControl1.Charts[0];

			chart.Enable3D = true;

            // configure the chart margins
            chart.BoundsMode = BoundsMode.Fit;
            chart.Location = new NPointL(
                new NLength(10, NRelativeUnit.ParentPercentage),
                new NLength(15, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(
                new NLength(80, NRelativeUnit.ParentPercentage),
                new NLength(78, NRelativeUnit.ParentPercentage));

            // set projection and lighting
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

            // disable the depth axis
            chart.Axis(StandardAxis.Depth).Visible = false;
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

            // Add a constline for the left axis
            NAxisConstLine cl1 = chart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
            cl1.StrokeStyle.Color = Color.SlateGray;
            cl1.FillStyle = new NColorFillStyle(Color.FromArgb(60, Color.SlateGray));
            cl1.Value = 90;

            // Add a constline for the bottom axis
            NAxisConstLine cl2 = chart.Axis(StandardAxis.PrimaryX).ConstLines.Add();
            cl2.StrokeStyle.Color = Color.LightSkyBlue;
            cl2.FillStyle = new NColorFillStyle(Color.FromArgb(60, Color.LightSkyBlue));
            cl2.Value = 40;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            if (!IsPostBack)
            {
                // init the form controls
                WebExamplesUtilities.FillComboWithValues(LAValueDropDownList, 0, 100, 10);
                LAStyleDropDownList.Items.Add("Line");
                LAStyleDropDownList.Items.Add("Plane");
                LAStyleDropDownList.SelectedIndex = 1;

                WebExamplesUtilities.FillComboWithValues(LABeginValueDropDownList, 0, 100, 10);
                WebExamplesUtilities.FillComboWithValues(LAEndValueDropDownList, 0, 100, 10);

                WebExamplesUtilities.FillComboWithValues(BAValueDropDownList, 0, 100, 10);
                BAStyleDropDownList.Items.Add("Line");
                BAStyleDropDownList.Items.Add("Plane");
                BAStyleDropDownList.SelectedIndex = 1;

                WebExamplesUtilities.FillComboWithValues(BABeginValueDropDownList, 0, 100, 10);
                WebExamplesUtilities.FillComboWithValues(BAEndValueDropDownList, 0, 100, 10);

                LAValueDropDownList.SelectedIndex = (int)(cl1.Value / 10);
                BAValueDropDownList.SelectedIndex = (int)(cl2.Value / 10);

                LABeginValueDropDownList.SelectedIndex = 0;
                LAEndValueDropDownList.SelectedIndex = 10;
                BABeginValueDropDownList.SelectedIndex = 0;
                BAEndValueDropDownList.SelectedIndex = 10;

                LABeginValueDropDownList.Enabled = false;
                LAEndValueDropDownList.Enabled = false;
                BABeginValueDropDownList.Enabled = false;
                BAEndValueDropDownList.Enabled = false;
            }

            NAxisConstLine leftAxisConstLine = chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

            leftAxisConstLine.Value = (LAValueDropDownList.SelectedIndex * 10);

            switch (LAStyleDropDownList.SelectedIndex)
            {
                case 0:
                    leftAxisConstLine.Mode = ConstLineMode.Line;
                    break;

                case 1:
                    leftAxisConstLine.Mode = ConstLineMode.Plane;
                    break;
            }

            NAxisConstLine cl = chart.Axis(StandardAxis.PrimaryY).ConstLines[0];
            if (LAUseBeginEndValueCheckBox.Checked)
            {
                NAxis referenceAxis = chart.Axis(StandardAxis.PrimaryX);
                double refBeginValue = Convert.ToDouble(LABeginValueDropDownList.SelectedIndex) * 10;
                double refEndValue = Convert.ToDouble(LAEndValueDropDownList.SelectedIndex) * 10;
                cl.ReferenceRanges.Add(new NReferenceAxisRange(referenceAxis, refBeginValue, refEndValue));

                LABeginValueDropDownList.Enabled = true;
                LAEndValueDropDownList.Enabled = true;
            }
            else
            {
                cl.ReferenceRanges.Clear();
                LABeginValueDropDownList.Enabled = false;
                LAEndValueDropDownList.Enabled = false;
            }

            // bottom axis
            NAxisConstLine bottomAxisConstline = chart.Axis(StandardAxis.PrimaryX).ConstLines[0];
            bottomAxisConstline.Value = (BAValueDropDownList.SelectedIndex * 10);

            switch (BAStyleDropDownList.SelectedIndex)
            {
                case 0:
                    bottomAxisConstline.Mode = ConstLineMode.Line;
                    break;

                case 1:
                    bottomAxisConstline.Mode = ConstLineMode.Plane;
                    break;
            }

            cl = chart.Axis(StandardAxis.PrimaryX).ConstLines[0];

            if (BAUseBeginEndValueCheckBox.Checked)
            {
                NAxis referenceAxis = chart.Axis(StandardAxis.PrimaryY);
                double refBeginValue = Convert.ToDouble(BABeginValueDropDownList.SelectedIndex) * 10;
                double refEndValue = Convert.ToDouble(BAEndValueDropDownList.SelectedIndex) * 10;
                cl.ReferenceRanges.Add(new NReferenceAxisRange(referenceAxis, refBeginValue, refEndValue));

                BABeginValueDropDownList.Enabled = true;
                BAEndValueDropDownList.Enabled = true;
            }
            else
            {
                cl.ReferenceRanges.Clear();
                BABeginValueDropDownList.Enabled = false;
                BAEndValueDropDownList.Enabled = false;
            }

            
		}
	}
}
