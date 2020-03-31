using System;
using System.Drawing;
using System.Web.UI;
using Nevron.Examples.Framework.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Image = System.Web.UI.WebControls.Image;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NCustomClientSideScriptAndPostbackUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            NLegend legend = nChartControl1.Legends[0];
            legend.ShadowStyle.Type = ShadowType.GaussianBlur;
            legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Left);
            legend.Location = new NPointL(legend.Location.X, new NLength(50, NRelativeUnit.ParentPercentage));
            legend.ContentAlignment = ContentAlignment.BottomRight;

            // set a chart title
            NLabel header = nChartControl1.Labels.AddHeader("Transport Sales Analysis");
            header.Location = new NPointL(new NLength(97, NRelativeUnit.ParentPercentage), new NLength(3, NRelativeUnit.ParentPercentage));
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomLeft;

			// by default the chart contains a cartesian chart which cannot display pie series
            nChartControl1.Charts.Clear();
            
			NPieChart chart = new NPieChart();
			chart.Enable3D = true;
            nChartControl1.Charts.Add(chart);
			chart.DisplayOnLegend = nChartControl1.Legends[0];

			NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);

			pie.AddDataPoint(new NDataPoint(12, "Cars", new NColorFillStyle(Color.Red)));
			pie.AddDataPoint(new NDataPoint(42, "Trains", new NColorFillStyle(Color.Gold)));
			pie.AddDataPoint(new NDataPoint(56, "Ships", new NColorFillStyle(Color.Chocolate)));
			pie.AddDataPoint(new NDataPoint(23, "Buses", new NColorFillStyle(Color.Cyan)));

			
			pie.InteractivityStyles.Add(0, new NInteractivityStyle("Cars", CursorType.Hand));
			pie.InteractivityStyles.Add(1, new NInteractivityStyle("Trains", CursorType.Hand));
			pie.InteractivityStyles.Add(2, new NInteractivityStyle("Ships", CursorType.Hand));
			pie.InteractivityStyles.Add(3, new NInteractivityStyle("Buses", CursorType.Hand));

			pie.Legend.Mode = SeriesLegendMode.DataPoints;
			pie.Legend.Format = "<label> <percent>";

			pie.PieStyle = PieStyle.SmoothEdgePie;
			pie.LabelMode = PieLabelMode.Spider;

			pie.LabelMode = PieLabelMode.Center;
			pie.DataLabelStyle.ArrowLength = new NLength(0f, NRelativeUnit.ParentPercentage);
			pie.DataLabelStyle.ArrowPointerLength = new NLength(0f, NRelativeUnit.ParentPercentage);

			chart.LightModel.EnableLighting = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(35, NRelativeUnit.ParentPercentage),
				new NLength(30, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(60, NRelativeUnit.ParentPercentage),
				new NLength(60, NRelativeUnit.ParentPercentage));

			
 			NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.Settings.JitteringSteps = 4;

			// select the car sales by default
			if (!IsPostBack)
			{
				for (int i = 0; i < pie.Values.Count; i++)
				{
					pie.Detachments.Add(0);
				}

				SalesOverTimeImg.ImageUrl = "NInteractiveCarSalesPage.aspx";
			}

			ApplyImageMapAttributesToSerie(pie);

			this.nChartControl1.Click += new EventHandler(this.NChartControl1_Click);
		}

		protected void ApplyImageMapAttributesToSerie(NPieSeries pie)
		{
			String sCustomAttribute, sFader;

			NInteractivityStyle interactivityStyle;

			for (int i = 0; i < pie.Values.Count; i++)
			{
				sFader = "bus";

				switch (i)
				{
					case 0:
						sFader = "car";
						break;
					case 1:
						sFader = "train";
						break;
					case 2:
						sFader = "ship";
						break;
					case 3:
						sFader = "bus";
						break;
				}

				sCustomAttribute = "#default_mouse_click #default_mouse_move #default_title	onMouseOver=\"JSFX.fadeIn('" + sFader + "')\" onMouseOut=\"JSFX.fadeOut('" + sFader + "')\"";

				interactivityStyle = new NInteractivityStyle();
				interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = sCustomAttribute;
				interactivityStyle.GeneratePostback = true;

				pie.InteractivityStyles[i] = interactivityStyle;
			}
		}

		private void NChartControl1_Click(object sender, EventArgs e)
		{
			NPostbackEventArgs eventArgs = e as NPostbackEventArgs;
			object selectedNode =  eventArgs.Id.FindInDocument(nChartControl1.Document);

			if (selectedNode is NDataPoint)
			{
				NDataPoint dataPoint = (NDataPoint)selectedNode;

				dataPoint[DataPointValue.PieDetachment] = 10;

				NSeries series = (NSeries)dataPoint.ParentNode;
				series.StoreDataPoint(dataPoint.IndexInSeries, dataPoint);

				switch (dataPoint.IndexInSeries)
				{
					case 0:
						SalesOverTimeImg.ImageUrl = "NInteractiveCarSalesPage.aspx";
						break;
					case 1:
						SalesOverTimeImg.ImageUrl = "NInteractiveTrainSalesPage.aspx";
						break;
					case 2:
						SalesOverTimeImg.ImageUrl = "NInteractiveShipSalesPage.aspx";
						break;
					case 3:
						SalesOverTimeImg.ImageUrl = "NInteractiveBusSalesPage.aspx";
						break;
				}
			}
		}
	}
}
