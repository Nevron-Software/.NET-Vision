using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAutoWallsAndAxesVisibilityUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Chart Walls<br/><font size = '9pt'>Demonstrates how to enable automatic wall visibility and automatic axis anchors</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			nChartControl1.Panels.Add(title);

			NChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);
			chart.Enable3D = true;
			chart.Width = 55;
			chart.Height = 25;
			chart.Depth = 40;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			// add interlaced stripe to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[]{
				ChartWallType.Back,
				ChartWallType.Left,
				ChartWallType.Right,
				ChartWallType.Front };

			NStandardScaleConfigurator scaleY = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.StripStyles.Add(stripStyle);

			// create several series
			for (int i = 0; i < 4; i++)
			{
				NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
				bar.Values.FillRandom(Random, 6);
				bar.DataLabelStyle.Visible = false;
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// update form controls
			if (!IsPostBack)
			{
				RotationTextBox.Text = chart.Projection.Rotation.ToString();
				ElevationTextBox.Text = chart.Projection.Elevation.ToString();
				LightsInCameraSpaceCheckBox.Checked = true;
				AutoWallsVisibilityCheckBox.Checked = true;

                AxisAnchorsModeDropDownList.Items.Add("Best Visibility");
                AxisAnchorsModeDropDownList.Items.Add("Auto Side");
                AxisAnchorsModeDropDownList.Items.Add("Manual");
                AxisAnchorsModeDropDownList.SelectedIndex = 0;
			}

			// configure lights
			NPointLightSource lightSource = new NPointLightSource();
			lightSource.Position = new NVector3DF(2, 2, 50);
			lightSource.Ambient = Color.FromArgb(64, 64, 64);
			lightSource.Diffuse = Color.FromArgb(255, 255, 255);
			lightSource.Specular = Color.FromArgb(100, 100, 100);

			chart.LightModel.LightSources.Clear();
			chart.LightModel.LightSources.Add(lightSource);
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(0, 0, 0);

			if (LightsInCameraSpaceCheckBox.Checked)
			{
				lightSource.CoordinateMode = LightSourceCoordinateMode.Camera;
				lightSource.Position = new NVector3DF(0, 0, 50);
			}
			else
			{
				lightSource.CoordinateMode = LightSourceCoordinateMode.Model;
				lightSource.Position = new NVector3DF(100, 95, 110);
			}

			chart.Projection.Rotation = (float)Convert.ToDouble(RotationTextBox.Text);
			chart.Projection.Elevation = (float)Convert.ToDouble(ElevationTextBox.Text);


			// update walls visiblity
			if (AutoWallsVisibilityCheckBox.Checked)
			{
				foreach (NChartWall wall in chart.Walls)
				{
					wall.VisibilityMode = WallVisibilityMode.Auto;
				}
			}
			else
			{
				chart.Wall(ChartWallType.Left).VisibilityMode = WallVisibilityMode.Visible;
				chart.Wall(ChartWallType.Back).VisibilityMode = WallVisibilityMode.Visible;
				chart.Wall(ChartWallType.Floor).VisibilityMode = WallVisibilityMode.Visible;
				chart.Wall(ChartWallType.Front).VisibilityMode = WallVisibilityMode.Hidden;
				chart.Wall(ChartWallType.Top).VisibilityMode = WallVisibilityMode.Hidden;
				chart.Wall(ChartWallType.Right).VisibilityMode = WallVisibilityMode.Hidden;
			}

			// update axis anchors
			NAxisAnchor anchorY = null;
			NAxisAnchor anchorX = null;
			NAxisAnchor anchorZ = null;

            switch (AxisAnchorsModeDropDownList.SelectedIndex)
            {
                case 0:
                    anchorY = new NBestVisibilityAxisAnchor(AxisOrientation.Vertical);
                    anchorX = new NBestVisibilityAxisAnchor(AxisOrientation.Horizontal);
                    anchorZ = new NBestVisibilityAxisAnchor(AxisOrientation.Depth);
                    break;

                case 1:
                    anchorY = new NAutoSideAxisAnchor(AxisOrientation.Vertical);
                    anchorX = new NAutoSideAxisAnchor(AxisOrientation.Horizontal);
                    anchorZ = new NAutoSideAxisAnchor(AxisOrientation.Depth);
                    break;

                case 2:
                    anchorY = new NDockAxisAnchor(AxisDockZone.FrontLeft);
                    anchorX = new NDockAxisAnchor(AxisDockZone.FrontBottom);
                    anchorZ = new NDockAxisAnchor(AxisDockZone.BottomRight);
                    break;
            }

			chart.Axis(StandardAxis.PrimaryY).Anchor = anchorY;
			chart.Axis(StandardAxis.PrimaryX).Anchor = anchorX;
			chart.Axis(StandardAxis.Depth).Anchor = anchorZ;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
