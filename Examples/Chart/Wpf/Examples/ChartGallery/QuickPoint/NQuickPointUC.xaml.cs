using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Diagnostics;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NQuickPointUC : NExampleBaseUC
	{
        private NQuickPointSeries m_QuickPoint;

        public NQuickPointUC()
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
				return "Point";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard point chart.\r\n" + 
						"Use the controls on the right to modify some commonly used properties.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Quick Point Chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

            // setup chart
            NChart m_Chart = nChartControl1.Charts[0];
            m_Chart.Axis(StandardAxis.Depth).Visible = false;

            m_Chart.Width = m_Chart.Height = m_Chart.Depth = 50;
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

            // add interlace stripe
            NLinearScaleConfigurator s = new NLinearScaleConfigurator();
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = CreateScale(new ChartWallType[] { ChartWallType.Back, ChartWallType.Left });
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = CreateScale(new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor });
            m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = CreateScale(new ChartWallType[] { ChartWallType.Left, ChartWallType.Floor });
            m_Chart.Axis(StandardAxis.Depth).Visible = true;

            // setup point series
            m_QuickPoint = new NQuickPointSeries();
            m_Chart.Series.Add(m_QuickPoint);
            m_QuickPoint.Name = "Point Series";
            m_QuickPoint.InflateMargins = true;
            m_QuickPoint.UseXValues = true;
            m_QuickPoint.UseZValues = true;
            m_QuickPoint.Size = new NLength(1);

            // apply layout
            ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// init form controls
            MaxPointCountComboBox.Items.Add("10K");
            MaxPointCountComboBox.Items.Add("100K");
            MaxPointCountComboBox.Items.Add("500K");
            MaxPointCountComboBox.SelectedIndex = 1;

            //UseHardwareAccelerationCheckBox.IsChecked = true;
            //Enable3DCheckBox.IsChecked = true;
		}

        private NLinearScaleConfigurator CreateScale(ChartWallType[] stripeWalls)
        {
            // add interlace stripe
            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;

            for (int i = 0; i < stripeWalls.Length; i++)
            {
                stripStyle.SetShowAtWall(stripeWalls[i], true);
            }

            linearScale.StripStyles.Add(stripStyle);

            return linearScale;
        }

        private int GetPointCount()
        {
            switch (MaxPointCountComboBox.SelectedIndex)
            {
                case 0:
                    return 10000;
                case 1:
                    return 100000;
                case 2:
                    return 500000;
                default:
                    Debug.Assert(false);
                    return 1000;
            }
        }

        private void MaxPointCountComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ChangeDataButton_Click(null, null);
        }

        private void ChangeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Random rand = new Random();

            int pointCount = GetPointCount();

            m_QuickPoint.Values.Clear();
            m_QuickPoint.XValues.Clear();
            m_QuickPoint.ZValues.Clear();
            m_QuickPoint.Colors.Clear();

            int lastIndex = m_QuickPoint.Values.Count;

            int groupCount = 20;
            int groupPointCount = pointCount / groupCount;

            for (int group = 0; group < groupCount; group++)
            {
                double centerX = rand.Next(1000000) / 1000;
                double centerY = rand.Next(1000000) / 1000;
                double centerZ = rand.Next(1000000) / 1000;

                int radius = rand.Next(1000000) / 1000 + 200;
                Color color = Color.FromArgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));

                for (int i = 0; i < groupPointCount; i++)
                {
                    double pitch = rand.Next(100000) / 100000.0 * Math.PI * 2;
                    double latitude = rand.Next(100000) / 100000.0 * Math.PI * 2;
                    double res = radius * Math.Sin(pitch);


                    m_QuickPoint.XValues.Add(centerY + radius * Math.Cos(pitch));
                    m_QuickPoint.Values.Add(centerX + res * Math.Cos(latitude));
                    m_QuickPoint.ZValues.Add(centerZ + res * Math.Sin(latitude));

                    m_QuickPoint.Colors[lastIndex++] = color;
                }
            }

            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_QuickPoint.Chart.Enable3D = (bool)Enable3DCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void UseHardwareAccelerationCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            nChartControl1.Settings.RenderSurface = (bool)UseHardwareAccelerationCheckBox.IsChecked ? RenderSurface.Window : RenderSurface.Bitmap;
        }
	}
}
