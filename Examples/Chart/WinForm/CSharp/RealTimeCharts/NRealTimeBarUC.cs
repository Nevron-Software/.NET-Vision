using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using System.Collections.Generic;
using System.Diagnostics;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRealTimeBarUC : NRealTimeExampleBaseUC
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
					if (x >= 0 && x < countX)
					{
						for (int y = minY; y <= maxY; y++)
						{
							if (y >= 0 && y < countY)
							{
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
				}
			}

			#endregion

			#region Fields

			public int m_X;
			public int m_Y;
			public int m_Radius;

			#endregion
		}

		private Nevron.UI.WinForm.Controls.NCheckBox UseHardwareAccelerationCheckBox;
		private Nevron.UI.WinForm.Controls.NButton StopStartTimerButton;
		private Nevron.UI.WinForm.Controls.NButton ResetButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private UI.WinForm.Controls.NComboBox GridSizeXComboBox;
		private UI.WinForm.Controls.NComboBox GridSizeYComboBox;
		private Label label6;
		private System.ComponentModel.IContainer components;

		double[][] m_Matrix;
		internal static readonly double m_MaxValue = 255.0;
		List<NSphereInfo> m_SphereList;
		int m_SphereCreationCounter;
		Color[] m_ColorTable;

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
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.UseHardwareAccelerationCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.StopStartTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.ResetButton = new Nevron.UI.WinForm.Controls.NButton();
			this.GridSizeXComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.GridSizeYComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Bottom:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Right:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Top:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Left:";
			// 
			// UseHardwareAccelerationCheckBox
			// 
			this.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseHardwareAccelerationCheckBox.Location = new System.Drawing.Point(7, 12);
			this.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox";
			this.UseHardwareAccelerationCheckBox.Size = new System.Drawing.Size(153, 24);
			this.UseHardwareAccelerationCheckBox.TabIndex = 0;
			this.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration";
			this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			// 
			// StopStartTimerButton
			// 
			this.StopStartTimerButton.Location = new System.Drawing.Point(7, 42);
			this.StopStartTimerButton.Name = "StopStartTimerButton";
			this.StopStartTimerButton.Size = new System.Drawing.Size(153, 23);
			this.StopStartTimerButton.TabIndex = 1;
			this.StopStartTimerButton.Text = "Stop Timer";
			this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Grid Size X:";
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(7, 71);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(153, 23);
			this.ResetButton.TabIndex = 2;
			this.ResetButton.Text = "Reset";
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// GridSizeXComboBox
			// 
			this.GridSizeXComboBox.ListProperties.CheckBoxDataMember = "";
			this.GridSizeXComboBox.ListProperties.DataSource = null;
			this.GridSizeXComboBox.ListProperties.DisplayMember = "";
			this.GridSizeXComboBox.Location = new System.Drawing.Point(7, 122);
			this.GridSizeXComboBox.Name = "GridSizeXComboBox";
			this.GridSizeXComboBox.Size = new System.Drawing.Size(153, 21);
			this.GridSizeXComboBox.TabIndex = 19;
			this.GridSizeXComboBox.Text = "comboBox2";
			this.GridSizeXComboBox.SelectedIndexChanged += new System.EventHandler(this.GridSizeXComboBox_SelectedIndexChanged);
			// 
			// GridSizeYComboBox
			// 
			this.GridSizeYComboBox.ListProperties.CheckBoxDataMember = "";
			this.GridSizeYComboBox.ListProperties.DataSource = null;
			this.GridSizeYComboBox.ListProperties.DisplayMember = "";
			this.GridSizeYComboBox.Location = new System.Drawing.Point(7, 175);
			this.GridSizeYComboBox.Name = "GridSizeYComboBox";
			this.GridSizeYComboBox.Size = new System.Drawing.Size(153, 21);
			this.GridSizeYComboBox.TabIndex = 20;
			this.GridSizeYComboBox.Text = "comboBox2";
			this.GridSizeYComboBox.SelectedIndexChanged += new System.EventHandler(this.GridSizeYComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(7, 156);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(83, 16);
			this.label6.TabIndex = 21;
			this.label6.Text = "Grid Size Y:";
			// 
			// NRealTimeBarUC
			// 
			this.Controls.Add(this.label6);
			this.Controls.Add(this.GridSizeYComboBox);
			this.Controls.Add(this.GridSizeXComboBox);
			this.Controls.Add(this.UseHardwareAccelerationCheckBox);
			this.Controls.Add(this.StopStartTimerButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ResetButton);
			this.Name = "NRealTimeBarUC";
			this.Size = new System.Drawing.Size(180, 442);
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Real Time Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
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

			GridSizeXComboBox.Items.Add("10");
			GridSizeXComboBox.Items.Add("50");
			GridSizeXComboBox.Items.Add("100");

			GridSizeYComboBox.Items.Add("10");
			GridSizeYComboBox.Items.Add("50");
			GridSizeYComboBox.Items.Add("100");

			GridSizeXComboBox.SelectedIndex = 2;
			GridSizeYComboBox.SelectedIndex = 2;

			UseHardwareAccelerationCheckBox.Checked = true;
			StartTimer();
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

		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Bar";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		private void ResetButton_Click(object sender, System.EventArgs e)
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

		private void NumberOfDataPointsUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			ResetButton_Click(null, null);
		}

		protected override void  OnTimerTick(object sender, EventArgs e)
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
				}
				else
				{
					bar.Values.SetRange(0, barValues);
				}

				int fillStyleCount = bar.FillStyles.Count;

				for (int j = 0; j < barValueCount; j++)
				{
					if (j >= fillStyleCount)
					{
						bar.FillStyles[j] = new NColorFillStyle(m_ColorTable[(int)barValues[j]]);
					}
					else
					{
						((NColorFillStyle)bar.FillStyles[j]).Color = m_ColorTable[(int)barValues[j]];
					} 
				}
			}
			

			if (m_SphereCreationCounter == 0)
			{
				m_SphereCreationCounter = 5;

				int radius = (int)Math.Max(1, Random.NextDouble() * 50);
				int y = (int)(Random.NextDouble() * GetGridSizeY());
				int x = GetGridSizeX() + radius;

				NSphereInfo sphere = new NSphereInfo(x, y, radius);
				m_SphereList.Add(sphere);
			}

			m_SphereCreationCounter--;

			nChartControl1.Refresh();
		}

		public static Color InterpolateColors(Color color1, Color color2, float factor)
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

		private void UseHardwareAccelerationCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(UseHardwareAccelerationCheckBox.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}

		private void StopStartTimerButton_Click(object sender, EventArgs e)
		{
			ToggleTimer();

			if (IsTimerRunning())
			{
				StopStartTimerButton.Text = "Stop Timer";
			}
			else
			{
				StopStartTimerButton.Text = "Start Timer";
			}
		}

		private void GridSizeXComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ResetButton_Click(null, null);
		}

		private void GridSizeYComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ResetButton_Click(null, null);
		}
	}
}
