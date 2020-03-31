using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardArea2DUC : NExampleUC
	{
		protected System.Web.UI.HtmlControls.HtmlForm StandardArea;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(PointShape));
				MarkerShapeDropDownList.SelectedIndex = 7;

				WebExamplesUtilities.FillComboWithColorNames(AreaColorDropDownList, KnownColor.DarkOrange);

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1);
				MarkerSizeDropDownList.SelectedIndex = 2;

				ShowDataLabelsCheckBox.Checked = false;
				UseOriginCheckBox.Checked = true;
				ShowMarkersCheckBox.Checked = false;
				OriginTextBox.Text = "0";
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
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
			area.Legend.Mode = SeriesLegendMode.DataPoints;
			area.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			area.DropLines = DropLinesCheckBox.Checked;
			area.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromString(AreaColorDropDownList.SelectedItem.Text));
			area.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;
			area.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			area.MarkerStyle.Height = new NLength((float)MarkerSizeDropDownList.SelectedIndex,NRelativeUnit.ParentPercentage) ;
			area.MarkerStyle.Width = new NLength((float)MarkerSizeDropDownList.SelectedIndex,NRelativeUnit.ParentPercentage);
			area.ShadowStyle.Type = ShadowType.GaussianBlur;
			area.ShadowStyle.Offset = new NPointL(3, 0);
			area.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);

			area.Values.AddRange(monthValues);

			area.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked;
			area.DataLabelStyle.Format = "<value>";

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
