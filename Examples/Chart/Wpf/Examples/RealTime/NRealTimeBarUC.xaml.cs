using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;
using System;
using Nevron.Dom;
using System.Collections.Generic;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRealTimeBarUC : NRealTimeExampleBaseUC
	{
		/// <summary>
		/// Helper class that represents a random sphere
		/// </summary>
		class NSphereInfo
		{
			#region Constructors

			/// <summary>
			/// Initializer constructor
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <param name="radius"></param>
			public NSphereInfo(int x, int y, int radius)
			{
				m_X = x;
				m_Y = y;
				m_Radius = radius;
			}

			#endregion

			#region Methods

			/// <summary>
			/// Applies the sphere to the grid
			/// </summary>
			/// <param name="grid"></param>
			public void ApplyToGrid(double[][] grid)
			{
				int minX = m_X - m_Radius;
				int maxX = m_X + m_Radius;

				int minY = m_Y - m_Radius;
				int maxY = m_Y + m_Radius;

				int countY = grid.Length;
				int countX = grid[0].Length;

				double radiusSquare = m_Radius * m_Radius;

				for (int x = minX; x <= maxX; x++)
				{
					if (x < 0 || x >= countX)
						continue;

					for (int y = minY; y <= maxY; y++)
					{
						if (y < 0 || y >= countY)
							continue;

						int dx = x - m_X;
						int dy = y - m_Y;

						double temp = Math.Sqrt(dx * dx + dy * dy);
						temp = radiusSquare - temp * temp;

						if (temp > 0)
						{
							double curValue = grid[y][x];
							double sphereValue = Math.Sqrt(temp);

							grid[y][x] = Math.Min(NRealTimeBarUC.m_MaxValue, curValue + sphereValue);
						}
					}
				}
			}

			#endregion

			#region Fields

			public int m_X;
			public int m_Y;
			public int m_Radius;

			#endregion
		}

		public NRealTimeBarUC()
		{
			InitializeComponent();

			m_SphereList = new List<NSphereInfo>();
			m_ColorTable = new Color[256];

			for (int i = 0; i <= 255; i++)
			{
				m_ColorTable[i] = InterpolateColors(Color.Blue, Color.Red, i / 255.0f);
			}
		}


		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Real Time Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to create realtime bar charts with hardware acceleration. It also shows how to take advantage of the DataPointOriginIndex which allows you to create cyclic data storage and avoid data shifts.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader(this.Title);
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// do not update automatic legends
			nChartControl1.ServiceManager.LegendUpdateService.UpdateAutoLegends();
			nChartControl1.ServiceManager.LegendUpdateService.Stop();

			// configure the chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Enable3D = true;
			chart.Fit3DAxisContent = false;

			// make the aspect 6:1:2
			chart.Width = 60;
			chart.Height = 20;
			chart.Depth = 20;

			// configure the y axis
			NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
			yAxis.View = new NRangeAxisView(new NRange1DD(0, m_MaxValue));

			NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			linearScale.MajorGridStyle.LineStyle.Color = Color.LightSteelBlue;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.InnerMajorTickStyle.Visible = false;
			linearScale.LabelFitModes = new LabelFitMode[0];

			// configure the x axis
			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			linearScale = new NLinearScaleConfigurator();
			linearScale.LabelFitModes = new LabelFitMode[0];
			xAxis.ScaleConfigurator = linearScale;
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.InnerMajorTickStyle.Visible = false;
			
			chart.Axis(StandardAxis.Depth).Visible = false;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			GridSizeXComboBox.Items.Add("10");
			GridSizeXComboBox.Items.Add("50");
			GridSizeXComboBox.Items.Add("100");

			GridSizeYComboBox.Items.Add("10");
			GridSizeYComboBox.Items.Add("50");
			GridSizeYComboBox.Items.Add("100");

			GridSizeXComboBox.SelectedIndex = 2;
			GridSizeYComboBox.SelectedIndex = 2;

			UseHardwareAccelerationCheckBox.IsChecked = true;
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			StartTimer();

			ConfigureStandardLayout(chart, title, null);
		}

		private int GetGridSizeX()
		{
			switch (GridSizeXComboBox.SelectedIndex)
			{
				case 0:
					return 10;
				case 1:
					return 50;
				case 2:
					return 100;
				default:
					return 10;
			}
		}

		private int GetGridSizeY()
		{
			switch (GridSizeYComboBox.SelectedIndex)
			{
				case 0:
					return 10;
				case 1:
					return 50;
				case 2:
					return 100;
				default:
					return 10;
			}
		}

		private static Color InterpolateColors(Color color1, Color color2, float factor)
		{
			int num1 = ((int)color1.R);
			int num2 = ((int)color1.G);
			int num3 = ((int)color1.B);

			int num4 = ((int)color2.R);
			int num5 = ((int)color2.G);
			int num6 = ((int)color2.B);

			byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * factor)));
			byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * factor)));
			byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * factor)));

			return Color.FromArgb(num7, num8, num9);
		}

		private void UseHardwareAccelerationCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			nChartControl1.Settings.RenderSurface = (bool)UseHardwareAccelerationCheckBox.IsChecked ? RenderSurface.Window : RenderSurface.Bitmap;
		}

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
		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Area";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
			base.OnTimerTick(sender, e);

			// clear the list
			for (int i = 0; i < m_Matrix.Length; i++)
			{
				double[] arr = m_Matrix[i];
				Array.Clear(arr, 0, arr.Length);
			}

			for (int i = m_SphereList.Count - 1; i >= 0; i--)
			{
				NSphereInfo sphere = m_SphereList[i];

				sphere.ApplyToGrid(m_Matrix);

				sphere.m_X--;

				if (sphere.m_X + sphere.m_Radius < 0)
				{
					m_SphereList.RemoveAt(i);
				}
			}

			// fill grid to bars
			NChart chart = nChartControl1.Charts[0];
			for (int i = 0; i < m_Matrix.Length; i++)
			{
				NBarSeries bar = chart.Series[i] as NBarSeries;
				double[] barValues = m_Matrix[i];
				int barValueCount = barValues.Length;

				if (bar.Values.Count == 0)
				{
					bar.Values.AddRange(barValues);
					for (int j = 0; j < barValueCount; j++)
					{
						bar.FillStyles[j] = new NColorFillStyle(m_ColorTable[(int)barValues[j]]);
					}
				}
				else
				{
					bar.Values.SetRange(0, barValues);
					for (int j = 0; j < barValueCount; j++)
					{
						((NColorFillStyle)bar.FillStyles[j]).Color = m_ColorTable[(int)barValues[j]];
					}
				}
			}


			if (m_SphereCreationCounter == 0)
			{
				m_SphereCreationCounter = 5;

				int radius = (int)Math.Max(1, m_Random.NextDouble() * 50);
				int y = (int)(m_Random.NextDouble() * GetGridSizeY());
				int x = GetGridSizeX() + radius;

				NSphereInfo sphere = new NSphereInfo(x, y, radius);
				m_SphereList.Add(sphere);
			}

			m_SphereCreationCounter--;

			nChartControl1.Refresh();
		}

		private void ResetButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			int gridSizeX = GetGridSizeX();
			int gridSizeY = GetGridSizeY();

			NChart chart = nChartControl1.Charts[0];

			chart.Width = gridSizeX;
			chart.Depth = gridSizeY;

			chart.Series.Clear();

			m_Matrix = new double[gridSizeY][];

			for (int i = 0; i < gridSizeY; i++)
			{
				m_Matrix[i] = new double[gridSizeX];
			}

			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

			for (int i = 0; i < gridSizeY; i++)
			{
				// add the first line
				NBarSeries bar = new NBarSeries();
				chart.Series.Add(bar);

				bar.WidthPercent = 100.0f;
				bar.DepthPercent = 100.0f;

				bar.EnableDepthSort = false;
				bar.DataLabelStyle.Visible = false;

				bar.Values.ValueFormatter = new NNumericValueFormatter("0.0");
				bar.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Skip;

				bar.Values.Clear();
				bar.FillStyles.StorageType = IndexedStorageType.Array;
				bar.DataPointOriginIndex = 0;

				// turn off bar border to improve performance
				bar.BorderStyle.Width = new NLength(0);
			}

			nChartControl1.Refresh();

		}

		private void NewDataPointsPerTickComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}

		private void NumberOfDataPointsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
		ResetButton_Click(null, null);
		}

		private void NumberOfDataPointsComboBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}

		private void NewDataPointsPerTickComboBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}

		private void GridSizeXComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}

		private void GridSizeYComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}

		private Color[] m_ColorTable;
		private double[][] m_Matrix;
		private Random m_Random = new Random();
		private List<NSphereInfo> m_SphereList;
		private int m_SphereCreationCounter;
		internal static readonly double m_MaxValue = 255.0;
	}
}
