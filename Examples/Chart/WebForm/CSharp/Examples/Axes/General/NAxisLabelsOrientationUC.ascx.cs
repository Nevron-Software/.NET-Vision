using System;
using System.Drawing;

using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm 
{
	public partial class NAxisLabelsOrientationUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// init form controls
			if (!IsPostBack)
			{
				AngleModeDropDownList.Items.Add("View");
				AngleModeDropDownList.Items.Add("Scale");
				AngleModeDropDownList.SelectedIndex = 1;

				AllowFlipCheckBox.Checked = false;
				FitAxisContentInBox.Checked = true;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Axis Labels Orientation");
			nChartControl1.Panels.Add(header);
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.Margins = new NMarginsL(10, 10, 10, 4);
			header.DockMode = PanelDockMode.Top;
			
			// setup the chart
			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);
			chart.Enable3D = true;
			chart.Fit3DAxisContent = FitAxisContentInBox.Checked;
			chart.DockMode = PanelDockMode.Fill;
			chart.BorderStyle = new NStrokeBorderStyle(BorderShape.RoundedRect);
			chart.BackgroundFillStyle = new NGradientFillStyle(Color.White, Color.LightGray);
			chart.Margins = new NMarginsL(10, 0, 10, 10);
			chart.Padding = new NMarginsL(2, 2, 2, 2);

			// set predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

			chart.Depth = 50;
			chart.Width = 50;
			chart.Height = 50;
			chart.BoundsMode = BoundsMode.Fit;

			chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

			// add interlaced stripe
			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle();
			stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			scaleConfiguratorY.StripStyles.Add(stripStyle);

			// add series
			Color[] seriesColors = new Color[] { Color.Crimson, Color.Orange, Color.OliveDrab };
			int dataItemsCount = 6;
			for (int i = 0; i < seriesColors.Length; i++)
			{
				NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);

				bar.BarShape = BarShape.SmoothEdgeBar;
				bar.FillStyle = new NColorFillStyle(seriesColors[i]);
				bar.Name = "Series " + i.ToString();
				bar.Values.FillRandomRange(Random, dataItemsCount, 10, 30);
				bar.InflateMargins = true;
				bar.DataLabelStyle.Visible = false;
			}

			// configure the x axis labels (categories)
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Title.Text = "Categories Title";
			ordinalScale.MajorTickMode = MajorTickMode.CustomStep;
			ordinalScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.Stagger2, LabelFitMode.AutoScale };

			for (int i = 0; i < dataItemsCount; i++)
			{
				ordinalScale.Labels.Add("S" + i.ToString());
			}

			// configure the depth axis labels (series)
			ordinalScale = chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Title.Text = "Series Title";
			ordinalScale.MajorTickMode = MajorTickMode.CustomStep;
			ordinalScale.Labels.Add("S1");
			ordinalScale.Labels.Add("S2");
			ordinalScale.Labels.Add("S3");
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.Stagger2, LabelFitMode.AutoScale };

			// set title to Y axis
			NNumericScaleConfigurator numericScale = chart.Axis((int)StandardAxis.PrimaryY).ScaleConfigurator as NNumericScaleConfigurator;
			numericScale.Title.Text = "Values";

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// read the form control values
			float customAngle;
			if (!float.TryParse(CustomAngleTextBox.Text, out customAngle) || customAngle < 0 || customAngle > 360)
			{
				customAngle = 0f;
				CustomAngleTextBox.Text = customAngle.ToString();
			}

			// update scale labels angle
			int count =chart.Axes.Count;

			NScaleLabelAngle angle = new NScaleLabelAngle((ScaleLabelAngleMode)Enum.Parse(typeof(ScaleLabelAngleMode), AngleModeDropDownList.SelectedItem.Value),
														   customAngle,
														   AllowFlipCheckBox.Checked);

			// update the x axis
			NAxis axis = (NAxis)chart.Axes[(int)StandardAxis.PrimaryX];
			NStandardScaleConfigurator scale = axis.ScaleConfigurator as NStandardScaleConfigurator;
			scale.LabelStyle.Angle = angle;

			// update the depth axis
			axis = (NAxis)chart.Axes[(int)StandardAxis.Depth];
			scale = axis.ScaleConfigurator as NStandardScaleConfigurator;
			scale.LabelStyle.Angle = angle;
		}
	}
}
