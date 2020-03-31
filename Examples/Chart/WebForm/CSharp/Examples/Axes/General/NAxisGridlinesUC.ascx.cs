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
	public partial class NAxisGridlinesUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Gridlines");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(80, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

			// disable the depth axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			NAxis leftAxis = chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)leftAxis.ScaleConfigurator;
			linearScaleConfigurator.MinorTickCount = 3;
			
			NPointSeries pnt = (NPointSeries)chart.Series.Add(SeriesType.Point);
			pnt.InflateMargins = true;
			pnt.DataLabelStyle.Visible = false;
			pnt.Values.FillRandom(Random, 5);
			pnt.Legend.Mode = SeriesLegendMode.None;

			if (!IsPostBack)
			{
				MajorGridLineStyleDropDown.Items.Add("Solid");
				MajorGridLineStyleDropDown.Items.Add("Dot");
				MajorGridLineStyleDropDown.Items.Add("Dash");
				MajorGridLineStyleDropDown.Items.Add("Dash-Dot");
				MajorGridLineStyleDropDown.Items.Add("Dash-Dot-Dot");
				MajorGridLineStyleDropDown.SelectedIndex = 0;

				MinorGridLineStyleDropDown.Items.Add("Solid");
				MinorGridLineStyleDropDown.Items.Add("Dot");
				MinorGridLineStyleDropDown.Items.Add("Dash");
				MinorGridLineStyleDropDown.Items.Add("Dash-Dot");
				MinorGridLineStyleDropDown.Items.Add("Dash-Dot-Dot");
				MinorGridLineStyleDropDown.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithColorNames(MajorGridLineColorDropDown, KnownColor.Black);
				WebExamplesUtilities.FillComboWithColorNames(MinorGridLineColorDropDown, KnownColor.Blue);

				MajorGridLineAtLeftWallCheckBox.Checked = linearScaleConfigurator.MajorGridStyle.GetShowAtWall(ChartWallType.Left);
				MajorGridLineAtBackWallCheckBox.Checked = linearScaleConfigurator.MajorGridStyle.GetShowAtWall(ChartWallType.Back);
				MinorGridLineAtLeftWallCheckBox.Checked = linearScaleConfigurator.MinorGridStyle.GetShowAtWall(ChartWallType.Left);
				MinorGridLineAtLeftWallCheckBox.Checked = linearScaleConfigurator.MinorGridStyle.GetShowAtWall(ChartWallType.Back);

				MajorGridLineAtLeftWallCheckBox.Checked = true;
				MajorGridLineAtBackWallCheckBox.Checked = true;
				MinorGridLineAtLeftWallCheckBox.Checked = true;
				MinorGridLineAtBackwallCheckBox.Checked = true;
			}

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// configure Y chart axis 
			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			linearScaleConfigurator = (NLinearScaleConfigurator)axisY.ScaleConfigurator;

			linearScaleConfigurator.MajorGridStyle.LineStyle.Color = WebExamplesUtilities.ColorFromDropDownList(MajorGridLineColorDropDown);
			linearScaleConfigurator.MinorGridStyle.LineStyle.Color = WebExamplesUtilities.ColorFromDropDownList(MinorGridLineColorDropDown);
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = GetPatternFromIndex(MajorGridLineStyleDropDown.SelectedIndex);
			linearScaleConfigurator.MinorGridStyle.LineStyle.Pattern = GetPatternFromIndex(MinorGridLineStyleDropDown.SelectedIndex);

			// set gridlines
			linearScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, MajorGridLineAtLeftWallCheckBox.Checked);
			linearScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, MajorGridLineAtBackWallCheckBox.Checked);
			linearScaleConfigurator.MinorGridStyle.SetShowAtWall(ChartWallType.Left, MinorGridLineAtLeftWallCheckBox.Checked);
			linearScaleConfigurator.MinorGridStyle.SetShowAtWall(ChartWallType.Back, MinorGridLineAtBackwallCheckBox.Checked);
		}

		private LinePattern GetPatternFromIndex(int index)
		{
			switch(index)
			{
				case 0: return LinePattern.Solid;
				case 1: return LinePattern.Dot;
				case 2: return LinePattern.Dash;
				case 3: return LinePattern.DashDot;
				case 4: return LinePattern.DashDotDot;
				default: return LinePattern.Solid;
			}
		}
	}
}
