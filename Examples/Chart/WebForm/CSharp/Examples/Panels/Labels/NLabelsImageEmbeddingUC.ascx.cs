using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using System.IO;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLabelsImageEmbeddingUC : NExampleUC
	{
		protected HtmlForm LabelsGeneral;
		protected Dictionary<string, string> m_CountryToBase64EncodedImage;

        protected void Page_Load(object sender, EventArgs e)
        {
			nChartControl1.Panels.Clear();
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
		
			// create a map for country name equals base64 encoded data (must start with "data:"
			string[] countlyFlagResourceName = new string[] { "Austria.png", "Finland.png", "France.png", "Germany.png", "Greece.png"};
			m_CountryToBase64EncodedImage = new Dictionary<string, string>();

			for (int i = 0; i < countlyFlagResourceName.Length; i++)
			{
				string countryFlagFile = countlyFlagResourceName[i];
				string alias = countlyFlagResourceName[i].Split('.')[0];

				byte[] countryFlagBytes = File.ReadAllBytes(this.MapPathSecure("~\\Images\\" + countryFlagFile));

				m_CountryToBase64EncodedImage[alias] = "data:" + System.Convert.ToBase64String(countryFlagBytes);
			}

			// create chart title
			NLabel label = new NLabel();
			nChartControl1.Panels.Add(label);
			
			label.Text = "Verified CO<sub>2</sub> Emissions for 2005<br/>Proposed and Allowed Emissions Caps for 2008-2012";
			label.TextStyle.FontStyle = new NFontStyle("Sylfaen", 10);
			label.TextStyle.TextFormat = TextFormat.XML;
			label.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur;
			label.TextStyle.ShadowStyle.FadeLength = new NLength(4);
			label.TextStyle.ShadowStyle.Offset = new NPointL(
				new NLength(1, NGraphicsUnit.Pixel),
				new NLength(1, NGraphicsUnit.Pixel));
			label.DockMode = PanelDockMode.Top;
			label.Margins = new NMarginsL(2, 2, 2, 0);

			// create a chart
			NChart chart = new NCartesianChart();
			nChartControl1.Charts.Add(chart);

			// create a legend
			NLegend legend = new NLegend();
			chart.ChildPanels.Add(legend);

			legend.ContentAlignment = ContentAlignment.BottomRight;
			legend.Margins = new NMarginsL(4, 4, 4, 2);
			legend.Location = new NPointL(
				new NLength(0, NRelativeUnit.ParentPercentage),
				new NLength(0, NRelativeUnit.ParentPercentage));
			legend.Data.MarkSize = new NSizeL(
				new NLength(4, NGraphicsUnit.Point),
				new NLength(4, NGraphicsUnit.Point));
			legend.FillStyle = new NColorFillStyle(Color.FromArgb(100, Color.White));
			legend.OuterBottomBorderStyle.Width = new NLength(0);
			legend.OuterTopBorderStyle.Width = new NLength(0);
			legend.OuterLeftBorderStyle.Width = new NLength(0);
			legend.OuterRightBorderStyle.Width = new NLength(0);
			legend.VerticalBorderStyle.Width = new NLength(0);

			// configure chart
			chart.DisplayOnLegend = legend;

			chart.BoundsMode = BoundsMode.Stretch;
			chart.DockMode = PanelDockMode.Fill;
			chart.Margins = new NMarginsL(4, 4, 4, 4);
			chart.PositionChildPanelsInContentBounds = true;

			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.InnerMajorTickStyle.Visible = false;

			// setup title
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.Title.Text = "MMTCO<sub>2</sub> Eq.";
			scaleY.Title.TextStyle.TextFormat = TextFormat.XML;
			scaleY.Title.Angle = new NScaleLabelAngle(90);

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };
			scaleY.StripStyles.Add(stripStyle);
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			DataTable table = CreateDataTable();

			NOrdinalScaleConfigurator scaleX = new NOrdinalScaleConfigurator();
			scaleX.AutoLabels = false;
			scaleX.LabelStyle.TextStyle.TextFormat = TextFormat.XML;

			// add labels from data table
			for (int i = 0; i < table.Rows.Count; i++)
			{
				DataRow row = table.Rows[i];
				scaleX.Labels.Add(row[0]);
			}

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			CreateClusterBars(chart, table);
        }

		private void CreateClusterBars(NChart chart, DataTable table)
		{
			NBarSeries electricEmissions = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			electricEmissions.Name = "2005 Emissions - Electric Power";
			electricEmissions.FillStyle = new NColorFillStyle(Color.FromArgb(195, 193, 27));
			electricEmissions.MultiBarMode = MultiBarMode.Series;
			electricEmissions.DataLabelStyle.Visible = false;
			electricEmissions.BorderStyle.Width = new NLength(0);

			NBarSeries transportationEmissions = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			transportationEmissions.Name = "2005 Emissions - Transportation";
			transportationEmissions.FillStyle = new NColorFillStyle(Color.FromArgb(182, 98, 17));
			transportationEmissions.MultiBarMode = MultiBarMode.Stacked;
			transportationEmissions.DataLabelStyle.Visible = false;
			transportationEmissions.BorderStyle.Width = new NLength(0);

			NBarSeries industrialEmissions = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			industrialEmissions.Name = "2005 Emissions - Industrial & Other";
			industrialEmissions.FillStyle = new NColorFillStyle(Color.FromArgb(144, 47, 79));
			industrialEmissions.MultiBarMode = MultiBarMode.Stacked;
			industrialEmissions.DataLabelStyle.Visible = false;
			industrialEmissions.BorderStyle.Width = new NLength(0);

			NBarSeries proposed = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			proposed.Name = "Proposed Cap 2008-2012";
			proposed.FillStyle = new NColorFillStyle(Color.FromArgb(94, 129, 179));
			proposed.MultiBarMode = MultiBarMode.Clustered;
			proposed.DataLabelStyle.Visible = false;
			proposed.BorderStyle.Width = new NLength(0);

			NBarSeries allowed = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			allowed.Name = "Allowed Cap 2008-2012";
			allowed.FillStyle = new NColorFillStyle(Color.FromArgb(141, 77, 232));
			allowed.MultiBarMode = MultiBarMode.Clustered;
			allowed.DataLabelStyle.Visible = false;
			allowed.BorderStyle.Width = new NLength(0);

			// fill the data
			for (int i = 0; i < table.Rows.Count; i++)
			{
				DataRow row = table.Rows[i];

				proposed.Labels.Add(row[0]);

				electricEmissions.Values.Add(row[3]);
				transportationEmissions.Values.Add(row[4]);
				industrialEmissions.Values.Add(row[5]);
				proposed.Values.Add(row[6]);
				allowed.Values.Add(row[7]);
			}
		}

		private DataTable CreateDataTable()
		{
			DataTable table = new DataTable();

			DataColumnCollection cols = table.Columns;
			DataRowCollection rows = table.Rows;

			cols.Add("Country", typeof(string));
			cols.Add("Longitude", typeof(double));
			cols.Add("Latitude", typeof(double));
			cols.Add("2005 Electric", typeof(double));
			cols.Add("2005 Transport", typeof(double));
			cols.Add("2005 Industrial", typeof(double));
			cols.Add("ProposedCap", typeof(double));
			cols.Add("AllowedCap", typeof(double));

			rows.Add("Austria <br/> <img size = '40, 20' src ='" + m_CountryToBase64EncodedImage["Austria"] + "' />", 14.3, 47.3, 18.5, 10.1, 4.8, 25.2, 22.8);
			rows.Add("Finland <br/> <img size = '40, 20' src ='" + m_CountryToBase64EncodedImage["Finland"] + "' />", 20.0, 63.0, 16.9, 9.5, 6.7, 39.6, 37.6);
			rows.Add("France <br/> <img size = '40, 20' src ='" + m_CountryToBase64EncodedImage["France"] + "' />", 4.0, 46.0, 55.8, 38.1, 37.4, 132.8, 132.8);
			rows.Add("Germany <br/> <img size = '40, 20' src ='" + m_CountryToBase64EncodedImage["Germany"] + "' />", 10.5, 50.5, 212.4, 140.4, 121.2, 482, 453.1);
			rows.Add("Greece <br/> <img size = '40, 20' src ='" + m_CountryToBase64EncodedImage["Greece"] + "' />", 22.5, 39.9, 30.7, 23, 17.6, 75.5, 69.1);

			return table;
		}
	}
}
