using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardStepLineUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(LineStyleDropDownList, typeof(LineSegmentShape));
				LineStyleDropDownList.SelectedIndex = 0;
				RoundToTickCheck.Checked = true;
				InflateMarginsCheck.Checked = true;
			}

			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Step Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);

			// setup the X axis
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;

			// setup the Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.RoundToTickMin = RoundToTickCheck.Checked;
			scaleY.RoundToTickMax = RoundToTickCheck.Checked;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			scaleY.StripStyles.Add(stripStyle);

			// hide the Z axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup step line series
			NStepLineSeries stepLine = (NStepLineSeries)chart.Series.Add(SeriesType.StepLine);
			stepLine.Name = "Series 1";
			stepLine.DepthPercent = 50;
			stepLine.LineSize = 2;
			stepLine.Legend.Mode = SeriesLegendMode.None;
			stepLine.FillStyle = new NColorFillStyle(Color.OliveDrab);
			stepLine.DataLabelStyle.Visible = false;
			stepLine.DataLabelStyle.Format = "<value>";
			stepLine.MarkerStyle.Visible = true;
			stepLine.InflateMargins = InflateMarginsCheck.Checked;

			Random random = new Random();
			stepLine.Values.FillRandom(random, 8);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			switch (LineStyleDropDownList.SelectedIndex)
			{
				case 0: // simple line
					stepLine.LineSegmentShape = LineSegmentShape.Line; 
					SetupTapeMarkers(stepLine.MarkerStyle);
					break;

				case 1: // tape
					stepLine.LineSegmentShape = LineSegmentShape.Tape; 
					SetupTapeMarkers(stepLine.MarkerStyle);
					break;

				case 2: // tube
					stepLine.LineSegmentShape = LineSegmentShape.Tube; 
					SetupTubeMarkers(stepLine.MarkerStyle);
					break;

				case 3: // elipsoid
					stepLine.LineSegmentShape = LineSegmentShape.Ellipsoid; 
					SetupTubeMarkers(stepLine.MarkerStyle);
					break;
			}
		}

		private void SetupTapeMarkers(NMarkerStyle marker)
		{
			marker.PointShape = PointShape.Cylinder;
			marker.AutoDepth = true;
			marker.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			marker.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
		}

		private void SetupTubeMarkers(NMarkerStyle marker)
		{
			marker.PointShape = PointShape.Sphere;
			marker.AutoDepth = false;
			marker.Width = new NLength(3.5f, NRelativeUnit.ParentPercentage);
			marker.Height = new NLength(3.5f, NRelativeUnit.ParentPercentage);
			marker.Depth = new NLength(3.5f, NRelativeUnit.ParentPercentage);
		}
	}
}
