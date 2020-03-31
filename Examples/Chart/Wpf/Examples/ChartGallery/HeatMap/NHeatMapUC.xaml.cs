using System;
using System.Collections.Generic;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NHeatMapUC : NRealTimeExampleBaseUC
	{
		NHeatMapSeries m_HeatMap;
		int m_SizeX = 200;
		int m_SizeY = 200;
		double m_MaxTemperature = 70;
		Random m_Rand = new System.Random();
		List<NHeatZone> m_HeatZones = new List<NHeatZone>();

		public NHeatMapUC()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Heat Map";
			}
		}
		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates the capabilities of the heat map series. The heat map represents a matrix where each cell value is represented by a color, produced by a color palette.";
			}
		}
		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Heat Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			NChart chart = nChartControl1.Charts[0];

			chart.BoundsMode = BoundsMode.Stretch;

			// create the heat map (will be updated on timer tick)
			m_HeatMap = new NHeatMapSeries();
			m_HeatMap.Data.SetGridSize(m_SizeX, m_SizeY);
			m_HeatMap.Data.SetValues(double.NaN);
			m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic; // used to display palette information
			m_HeatMap.Legend.PaletteLegendMode = PaletteLegendMode.GradientAxis;
			m_HeatMap.Legend.PaletteScaleStepMode = PaletteScaleStepMode.SynchronizeWithScaleConfigurator;

			NNumericScaleConfigurator numericScale = m_HeatMap.Legend.PaletteScaleConfigurator as NNumericScaleConfigurator;
			numericScale.MajorTickMode = MajorTickMode.CustomStep;
			numericScale.CustomStep = 10;

			m_HeatMap.Palette.Mode = PaletteMode.AutoMinMaxColor;
			m_HeatMap.Palette.PositiveColor = Color.FromArgb(125, Color.Red);
			m_HeatMap.Palette.ZeroColor = Color.FromArgb(125, Color.Blue);
			m_HeatMap.Palette.SmoothPalette = true;

			chart.Series.Add(m_HeatMap);

			// add background image
			NRangeSeries range = new NRangeSeries();
			range.UseXValues = true;
			range.DataLabelStyle.Visible = false;
			range.Legend.Mode = SeriesLegendMode.None;

			range.Values.Add(0);
			range.Y2Values.Add(m_SizeY);

			range.XValues.Add(0);
			range.X2Values.Add(m_SizeX);

			Bitmap bitmap = NResourceHelper.BitmapFromResource(this.GetType(), "USMap.png", "Nevron.Examples.Chart.Wpf.Resources.Images");
			range.FillStyle = new NImageFillStyle(bitmap);
			chart.Series.Add(range);

			this.StartTimer();

			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);
		}

		protected override void OnTimerTick(object sender, System.EventArgs e)
		{
			for (; m_HeatZones.Count < 50; )
			{
				int x = 0;
				int y = 0;
				switch (m_Rand.Next(4))
				{
					case 0:
						// left
						x = -(int)m_MaxTemperature / 2 + 1;
						y = m_Rand.Next(m_SizeY);
						break;
					case 1:
						// top
						x = m_Rand.Next(m_SizeX);
						y = -(int)m_MaxTemperature / 2 + 1;
						break;
					case 2:
						// right
						x = m_SizeX - (int)m_MaxTemperature / 2 - 1;
						y = m_Rand.Next(m_SizeY);
						break;
					case 3:
						// bottom
						x = m_Rand.Next(m_SizeX);
						y = +(int)m_MaxTemperature / 2 - 1;
						break;
				}

				// if no more heat zones -> create new ones
				NHeatZone heatZone = new NHeatZone(x, y, m_MaxTemperature);

				do
				{
					heatZone.m_DX = m_Rand.Next(4) - 2;
					heatZone.m_DY = m_Rand.Next(4) - 2;
				}
				while (heatZone.m_DX == 0 && heatZone.m_DY == 0);

				m_HeatZones.Add(heatZone);
			}

			// gets the values
			m_HeatMap.Data.SetValues(double.NaN);
			double[] values = m_HeatMap.Data.Values;

			for (int i = m_HeatZones.Count - 1; i >= 0; i--)
			{
				NHeatZone heatZone = m_HeatZones[i];

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
					m_HeatZones.RemoveAt(i);
					continue;
				}

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

								if (curValue > m_MaxTemperature)
								{
									curValue = m_MaxTemperature;
								}

								values[index] = curValue;
							}
						}
					}
				}
			}

			m_HeatMap.Data.OnDataChanged();

			nChartControl1.Refresh();
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

		private void StartStopTimerButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (m_Timer.IsEnabled)
			{
				m_Timer.Stop();
				StartStopTimerButton.Content = "Start Timer";
			}
			else
			{
				m_Timer.Start();
				StartStopTimerButton.Content = "Stop Timer";
			}
		}
	}
}
