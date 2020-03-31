using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NImageMapPostbackAdvancedUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("HTML Image Map with Postback (Server Events) 2");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(
                new NLength(50, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);
			legend.InteractivityStyle.GeneratePostback = true;
			legend.Header.Text = "Company Score";

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Height = 40;
			chart.Enable3D = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(8, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(84, NRelativeUnit.ParentPercentage),
				new NLength(60, NRelativeUnit.ParentPercentage));

			chart.Axis(StandardAxis.Depth).Visible = false;

			chart.Axis(StandardAxis.Depth).InteractivityStyle.GeneratePostback = true;
			chart.Axis(StandardAxis.PrimaryX).InteractivityStyle.GeneratePostback = true;
			chart.Axis(StandardAxis.PrimaryY).InteractivityStyle.GeneratePostback = true;

			chart.Wall(ChartWallType.Back).InteractivityStyle.GeneratePostback = true;
			chart.Wall(ChartWallType.Left).InteractivityStyle.GeneratePostback = true;
			chart.Wall(ChartWallType.Floor).InteractivityStyle.GeneratePostback = true;

			// add an axis stripe
			NAxisStripe stripe = chart.Axis(StandardAxis.PrimaryY).Stripes.Add(20, 33);
			stripe.FillStyle = new NColorFillStyle(Color.PaleGoldenrod);
			stripe.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Back };
			stripe.InteractivityStyle.GeneratePostback = true;

			// setup X axis
			NOrdinalScaleConfigurator ordinalScale = new NOrdinalScaleConfigurator();
			ordinalScale.AutoLabels = false;
			ordinalScale.Labels.Add("Ford");
			ordinalScale.Labels.Add("VW");
			ordinalScale.Labels.Add("Toyota");
			ordinalScale.Labels.Add("BMW");
			ordinalScale.Labels.Add("Peugeot");
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = ordinalScale;

			// add a bar chart
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Fictive Car sales";
			bar.BarShape = BarShape.SmoothEdgeBar;
			bar.Legend.Mode = SeriesLegendMode.DataPoints;
			bar.DataLabelStyle.Visible = true;
			bar.DataLabelStyle.Format = "<value>";
			bar.InteractivityStyle.Tooltip = new NTooltipAttribute("<value> <label>");
			bar.AddDataPoint(new NDataPoint(22, "Ford", new NColorFillStyle(Color.DarkKhaki)));
			bar.AddDataPoint(new NDataPoint(32, "VW", new NColorFillStyle(Color.OliveDrab)));
			bar.AddDataPoint(new NDataPoint(45, "Toyota", new NColorFillStyle(Color.DarkSeaGreen)));
			bar.AddDataPoint(new NDataPoint(27, "BMW", new NColorFillStyle(Color.CadetBlue)));
			bar.AddDataPoint(new NDataPoint(40, "Peugeot", new NColorFillStyle(Color.LightSlateGray)));

			for (int i = 0; i < bar.Values.Count; i++)
			{
				NInteractivityStyle interactivityStyle = new NInteractivityStyle();
				interactivityStyle.GeneratePostback = true;
				bar.InteractivityStyles[i] = interactivityStyle;
			}

			// configure the control to generate image map with postback
 			NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
			imageMapResponse.GridCellSize = 2;
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

			this.nChartControl1.Click += new EventHandler(this.NChartControl1_Click);
		}

		private void SelectDataItem(int nIndex)
		{
			NBarSeries bar = (NBarSeries)(nChartControl1.Charts[0].Series[0]);
			bar.FillStyles[nIndex] = new NColorFillStyle(Color.Red);
		}

		private void NChartControl1_Click(object sender, EventArgs e)
		{
			NPostbackEventArgs eventArgs = e as NPostbackEventArgs;
			object selectedObject = eventArgs.Id.FindInDocument(nChartControl1.Document);

			if (selectedObject is NDataPoint)
			{
				NDataPoint dataPoint = (NDataPoint)selectedObject;

				dataPoint[DataPointValue.FillStyle] = new NColorFillStyle(Color.Red);

				NSeries series = (NSeries)dataPoint.ParentNode;
				series.StoreDataPoint(dataPoint.IndexInSeries, dataPoint);

				return;
			}

			if (selectedObject is NLabel)
			{
				((NLabel)selectedObject).TextStyle.FillStyle = new NColorFillStyle(Color.Red);
				return;
			}

			if (selectedObject is NLegend)
			{
				((NLegend)selectedObject).FillStyle = new NColorFillStyle(Color.Red);
				return;
			}

			if (selectedObject is NLegendItemCellData)
			{
				NLegendItemCellData licd =  selectedObject as NLegendItemCellData;
				NLegend legend = nChartControl1.Legends[0];
				SelectDataItem(legend.Data.Items.IndexOf(licd));
				return;
			}

			if (selectedObject is NChartWall)
			{
				((NChartWall)selectedObject).FillStyle = new NColorFillStyle(Color.Red);
				return;
			}

			if (selectedObject is NAxisStripe)
			{
				((NAxisStripe)selectedObject).FillStyle = new NColorFillStyle(Color.Red);
				return;
			}

			if (selectedObject is NAxis)
			{
				NAxis axis = selectedObject as NAxis;
				NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)axis.ScaleConfigurator;
				scaleConfigurator.RulerStyle.BorderStyle.Color = Color.Red;
				scaleConfigurator.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.Red);
			}
		}
	}
}
