using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Collections;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLinearScaleUC : NExampleUC
	{

		private NChart m_Chart;
		private NLineSeries m_Line;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Linear Scale");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			m_Chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage), 
				new NLength(12, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage), 
				new NLength(85, NRelativeUnit.ParentPercentage));

			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// configure the y axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// add a strip line style
			NScaleStripStyle stripStyle = new NScaleStripStyle();
			stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Values.FillRandomRange(Random, 7, -100, 100);
			m_Line.Legend.Mode = SeriesLegendMode.None;
			m_Line.InflateMargins = false;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Ellipse;
			m_Line.MarkerStyle.Width = new NLength(5, NGraphicsUnit.Point);
			m_Line.MarkerStyle.Height = new NLength(5, NGraphicsUnit.Point);
			m_Line.MarkerStyle.AutoDepth = true;
			m_Line.DataLabelStyle.Format = "<value>";

			m_Line.Values.FillRandomRange(Random, 10, 0, 100);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			if(!Page.IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(MaxCountDropDownList, 1, 20, 1);
				MaxCountDropDownList.SelectedIndex = 9;
				WebExamplesUtilities.FillComboWithValues(MinDistanceDropDownList, 5, 50, 5);
				MinDistanceDropDownList.SelectedIndex = 2;
				WebExamplesUtilities.FillComboWithValues(CustomStepDropDownList, 1, 20, 1);
				CustomStepDropDownList.SelectedIndex = 4;
				AutoMinDistanceRadioButton.Checked = true;
			}

			UpdateScale();
		}

		private void UpdateScale()
		{
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			if (linearScale == null)
				return;

			linearScale.MaxTickCount = Convert.ToInt32(MaxCountDropDownList.SelectedValue);
			linearScale.MinTickDistance = new NLength((float)Convert.ToInt32(MinDistanceDropDownList.SelectedValue), NGraphicsUnit.Point);
			linearScale.CustomStep = (double)Convert.ToInt32(CustomStepDropDownList.SelectedValue);

			// update the custom ticks to match the values of the line series
			double[] values = new double[m_Line.Values.Count];
			m_Line.Values.CopyTo(values, 0);
			linearScale.CustomMajorTicks = new NDoubleList(values);

			linearScale.CustomSteps.Clear();
			linearScale.CustomSteps.Add(10);
			linearScale.CustomSteps.Add(20);

			if (AutoMaxCountRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.AutoMaxCount;
			}
			else if (AutoMinDistanceRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.AutoMinDistance;
			}
			else if (CustomStepRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.CustomStep;
			}
			else if (CustomStepsRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.CustomSteps;
			}
			else if (CustomTicksRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.CustomTicks;
			}
		}
	}
}
