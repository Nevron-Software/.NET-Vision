using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NChartAspect2DUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

            // set a chart title
            NLabel title = new NLabel("Chart Aspect 2D");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.DockMode = PanelDockMode.Top;
            title.Margins = new NMarginsL(10, 10, 10, 0);
            nChartControl1.Panels.Add(title);

            NCartesianChart chart = new NCartesianChart();
            nChartControl1.Panels.Add(chart);

            chart.DockMode = PanelDockMode.Fill;
            chart.Margins = new NMarginsL(30, 10, 10, 30);
            chart.Padding = new NMarginsL(0);
            chart.BoundsMode = BoundsMode.Stretch;
            chart.UsePlotAspect = true;
            chart.Width = chart.Height = 50;
            
            // switch all axes to linear mode
            NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
            xScale.Title.Text = "X Scale Title";
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            xScale.LabelStyle.KeepInsideRuler = true;
            xScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90, false);
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;

            NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();
            yScale.Title.Text = "Y Scale Title";
            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            yScale.LabelStyle.KeepInsideRuler = true;
            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;

            chart.Axis(StandardAxis.SecondaryX).ScaleConfigurator = new NLinearScaleConfigurator();
            chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator = new NLinearScaleConfigurator();

            // cross secondary X and Y axes
            chart.Axis(StandardAxis.SecondaryX).Anchor = new NCrossAxisAnchor(AxisOrientation.Horizontal, new NValueAxisCrossing(chart.Axis(StandardAxis.PrimaryY), 0));
            chart.Axis(StandardAxis.SecondaryY).Anchor = new NCrossAxisAnchor(AxisOrientation.Vertical, new NValueAxisCrossing(chart.Axis(StandardAxis.PrimaryX), 0));

            // show secondary axes
            chart.Axis(StandardAxis.SecondaryX).Visible = true;
            chart.Axis(StandardAxis.SecondaryY).Visible = true;

            // turn off labels for cross axes
			NLinearScaleConfigurator secondaryScaleX = chart.Axis(StandardAxis.SecondaryX).ScaleConfigurator as NLinearScaleConfigurator;
			secondaryScaleX.AutoLabels = false;

			NLinearScaleConfigurator secondaryScaleY = chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator as NLinearScaleConfigurator;
            secondaryScaleY.AutoLabels = false;

            // add some dummy data
            NPointSeries point = new NPointSeries();
            chart.Series.Add(point);
            point.DataLabelStyle.Visible = false;
            point.UseXValues = true;

            point.DisplayOnAxis((int)StandardAxis.SecondaryX, true);
            point.DisplayOnAxis((int)StandardAxis.SecondaryY, true);
            point.Size = new NLength(1);
            point.BorderStyle.Width = new NLength(0);
            point.ClusterMode = ClusterMode.Enabled;

            // add some random data in the range [-100, 100]
            Random rand = new Random();

            for (int i = 0; i < 3000; i++)
            {
                point.Values.Add(rand.Next(200) - 100);
                point.XValues.Add(rand.Next(200) - 100);
            }


			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithValues(XProportionDropDownList, 1, 5, 1);
				XProportionDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(YProportionDropDownList, 1, 5, 1);
				YProportionDropDownList.SelectedIndex = 0;

				FitAxisContentCheckBox.Checked = true;
				UsePlotAspectCheckBox.Checked = true;
				ShowContentAreaCheckBox.Checked = false;
			}

			chart.Width = (XProportionDropDownList.SelectedIndex + 1) * 10;
			chart.Height = (YProportionDropDownList.SelectedIndex + 1) * 10;
			chart.UsePlotAspect = UsePlotAspectCheckBox.Checked;
			chart.Fit2DAxisContent = FitAxisContentCheckBox.Checked;

			UsePlotAspectCheckBox.Enabled = FitAxisContentCheckBox.Checked;
			bool enableProportion = UsePlotAspectCheckBox.Checked && !FitAxisContentCheckBox.Checked;
			XProportionDropDownList.Enabled = enableProportion;
			YProportionDropDownList.Enabled = enableProportion;

			if (ShowContentAreaCheckBox.Checked)
			{
				chart.BorderStyle = new NStrokeBorderStyle();
			}
			else
			{
				chart.BorderStyle = null;
			}
		}
	}
}
