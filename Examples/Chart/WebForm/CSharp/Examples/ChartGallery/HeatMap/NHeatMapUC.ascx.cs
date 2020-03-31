using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NHeatMapUC : NExampleUC
    {
		const int m_SizeX = 200;
		const int m_SizeY = 200;

        protected void Page_Load(object sender, EventArgs e)
        {
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Heat Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(0, 5, 0, 0);
			nChartControl1.Panels.Add(title);

			NLegend legend = new NLegend();
			legend.DockMode = PanelDockMode.Right;
			legend.Margins = new NMarginsL(0, 5, 5, 0);
			legend.FitAlignment = ContentAlignment.TopCenter;
			nChartControl1.Panels.Add(legend);

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			chart.DisplayOnLegend = legend;
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(5);

			// create the heat map (will be updated on timer tick)
			NHeatMapSeries heatMap = new NHeatMapSeries();
			heatMap.Data.SetGridSize(m_SizeX, m_SizeY);
			heatMap.Data.SetValues(double.NaN);
			heatMap.Legend.Mode = SeriesLegendMode.SeriesLogic; // used to display palette information
			heatMap.Legend.PaletteLegendMode = PaletteLegendMode.GradientAxis;
			heatMap.Legend.PaletteScaleStepMode = PaletteScaleStepMode.SynchronizeWithScaleConfigurator;
			heatMap.Legend.PaletteLength = new NLength(170);

			NNumericScaleConfigurator numericScale = heatMap.Legend.PaletteScaleConfigurator as NNumericScaleConfigurator;
			numericScale.MajorTickMode = MajorTickMode.CustomStep;
			numericScale.CustomStep = 10;

			heatMap.Palette.Mode = PaletteMode.AutoMinMaxColor;
			heatMap.Palette.PositiveColor = Color.FromArgb(125, Color.Red);
			heatMap.Palette.ZeroColor = Color.FromArgb(125, Color.Blue);
			heatMap.Palette.SmoothPalette = true;

			chart.Series.Add(heatMap);

			// add background image
			NRangeSeries range = new NRangeSeries();
			range.UseXValues = true;
			range.DataLabelStyle.Visible = false;
			range.Legend.Mode = SeriesLegendMode.None;

			range.Values.Add(0);
			range.Y2Values.Add(m_SizeY);

			range.XValues.Add(0);
			range.X2Values.Add(m_SizeX);

			Bitmap bitmap = new Bitmap(this.MapPathSecure(this.TemplateSourceDirectory + "/USMap.png"));
			range.FillStyle = new NImageFillStyle(bitmap);
			chart.Series.Add(range);

			// then create some dummy data
			CreateDymmyData(heatMap);
		}

		private void CreateDymmyData(NHeatMapSeries heatMap)
		{
			Random rand = new Random();
			List<NHeatZone> heatZones = new List<NHeatZone>();
			double maxTemperature = 70;

			while (heatZones.Count < 50)
			{
				int x = 0;
				int y = 0;
				switch (rand.Next(4))
				{
					case 0:
						// left
						x = - (int)maxTemperature / 2 + 1;
						y = rand.Next(m_SizeY);
						break;
					case 1:
						// top
						x = rand.Next(m_SizeX);
						y = -(int)maxTemperature / 2 + 1;
						break;
					case 2:
						// right
						x = m_SizeX - (int)maxTemperature / 2 - 1;
						y = rand.Next(m_SizeY);
						break;
					case 3:
						// bottom
						x = rand.Next(m_SizeX);
						y = +(int)maxTemperature / 2 - 1;
						break;
				}

				// if no more heat zones -> create new ones
				NHeatZone heatZone = new NHeatZone(x, y, maxTemperature);

				do
				{
					heatZone.m_DX = rand.Next(4) - 2;
					heatZone.m_DY = rand.Next(4) - 2;
				}
				while (heatZone.m_DX == 0 && heatZone.m_DY == 0);

				heatZones.Add(heatZone);
			}

			// gets the values
			heatMap.Data.SetValues(double.NaN);
			double[] values = heatMap.Data.Values;

			for (int i = heatZones.Count - 1; i >= 0; i--)
			{
				NHeatZone heatZone = heatZones[i];

				int radius = heatZone.m_Radius;

				// move the heat zone
				heatZone.m_X += heatZone.m_DX;
				heatZone.m_Y += heatZone.m_DY;

				bool removeZone = false;

				if (heatZone.m_X < -radius)
				{
					removeZone = true;
				}
				else if (heatZone.m_X >= m_SizeX + radius)
				{
					removeZone = true;
				}

				if (heatZone.m_Y < -radius)
				{
					removeZone = true;
				}
				else if (heatZone.m_Y >= m_SizeX + radius)
				{
					removeZone = true;
				}

				if (removeZone)
				{
					heatZones.RemoveAt(i);
				}
				else
				{
					int centerX = heatZone.m_X;
					int centerY = heatZone.m_Y;

					int startX = Math.Max(0, centerX - radius);
					int startY = Math.Max(0, centerY - radius);

					int endX = Math.Min(m_SizeX - 1, centerX + radius);
					int endY = Math.Min(m_SizeY - 1, centerY + radius);

					for (int x = startX; x <= endX; x++)
					{
						for (int y = startY; y <= endY; y++)
						{
							double value = heatZone.m_Temperature - 2 * Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));

							if (value >= 0)
							{
								int index = y * m_SizeX + x;
								double curValue = values[index];

								if (double.IsNaN(curValue))
								{
									values[index] = value;
								}
								else
								{
									curValue += value;

									if (curValue > maxTemperature)
									{
										curValue = maxTemperature;
									}

									values[index] = curValue;
								}
							}
						}
					}
				}
			}

			heatMap.Data.OnDataChanged();
		}

		class NHeatZone
		{
			#region Constructors

			/// <summary>
			/// Initializer constructor
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <param name="temperature"></param>
			public NHeatZone(int x, int y, double temperature)
			{
				m_X = x;
				m_Y = y;
				m_Temperature = temperature;
				m_Radius = (int)Math.Max(1, m_Temperature / 2);
			}

			#endregion

			#region Fields

			public double m_Temperature;
			public int m_Radius;
			public int m_X;
			public int m_Y;

			public int m_DX;
			public int m_DY;

			#endregion
		};
    }
}