using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardAreaUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(PointShape));
				MarkerShapeDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithPercents (DepthsPercentDropDownList, 10);
				DepthsPercentDropDownList.SelectedIndex = 4;

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1);
				MarkerSizeDropDownList.SelectedIndex = 2;

				ShowDataLabelsCheckBox.Checked = false;
				UseOriginCheckBox.Checked = true;
				ShowMarkersCheckBox.Checked = false;
				OriginTextBox.Text = "0";
			}

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.InnerMajorTickStyle.Visible = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };

			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.StripStyles.Add(stripStyle);
            
			// setup area series
			NAreaSeries area = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area.Name = "Area Series";
			area.DepthPercent = DepthsPercentDropDownList.SelectedIndex * 10;
			area.DropLines = DropLinesCheckBox.Checked;
			area.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked;
			area.DataLabelStyle.Format = "<value>";
			area.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;
			area.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			area.MarkerStyle.Height = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Width = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);

			area.Values.AddRange(monthValues);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			if (UseOriginCheckBox.Checked == true)
			{
				OriginTextBox.Enabled = true;
				area.OriginMode = SeriesOriginMode.CustomOrigin;

				try
				{
					area.Origin = Int32.Parse(OriginTextBox.Text);
				}
				catch
				{
				}		
			}
			else
			{
				OriginTextBox.Enabled = false;
				area.OriginMode = SeriesOriginMode.MinValue;
			}

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked;
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
