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
	public partial class NOrdinalScaleUC : NExampleUC
	{
		private NChart m_Chart;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			// init form controls
			if (!IsPostBack)
			{
				PrimaryXAxisAutoLabelsCheckBox.Checked = true;
				PrimaryXAxisInvertCheckBox.Checked = true;

				DepthAxisAutoLabelsCheckBox.Checked = true;
				DepthAxisInvertAxisCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Ordinal Scale");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;

            // set projection and lighting
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

            // set sizes
			m_Chart.Depth = 50;
			m_Chart.BoundsMode = BoundsMode.Fit;

			m_Chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage), 
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage), 
				new NLength(80, NRelativeUnit.ParentPercentage));

            // add interlace stripe
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add series
			Color[] seriesColors = new Color[] { Color.Crimson, Color.Orange, Color.OliveDrab };
			int dataItemsCount = 6;
			for (int i = 0; i < seriesColors.Length; i++)
			{
				NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);

				bar.FillStyle = new NColorFillStyle(seriesColors[i]);
				bar.Name = "Series " + i.ToString();
				bar.Values.FillRandomRange(Random, dataItemsCount, 10, 30);
				bar.InflateMargins = true;
				bar.DataLabelStyle.Visible = false;
			}

			NOrdinalScaleConfigurator oridnalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			oridnalScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };

			for (int i = 0; i < dataItemsCount; i++)
			{
				oridnalScale.Labels.Add("Category " + i.ToString());
			}

			oridnalScale = m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;
			oridnalScale.Labels.Add("Series 1");
			oridnalScale.Labels.Add("Series 2");
			oridnalScale.Labels.Add("Series 3");
			oridnalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			oridnalScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void UpdateScales()
		{
			NOrdinalScaleConfigurator ordinalScale;

			// configure the primary x axis
			ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			ordinalScale.DisplayDataPointsBetweenTicks = PrimaryXAxisInvertCheckBox.Checked;
			ordinalScale.AutoLabels = PrimaryXAxisAutoLabelsCheckBox.Checked;

			// configure the depth axis
			ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;

			ordinalScale.DisplayDataPointsBetweenTicks = DepthAxisInvertAxisCheckBox.Checked;
			ordinalScale.AutoLabels = DepthAxisAutoLabelsCheckBox.Checked;
		}

		protected void PrimaryXAxisInvertCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScales();
		}

		protected void PrimaryXAxisAutoLabelsCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScales();
		}

		protected void DepthAxisInvertAxisCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScales();
		}

		protected void DepthAxisAutoLabelsCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScales();
		}
	}
}
