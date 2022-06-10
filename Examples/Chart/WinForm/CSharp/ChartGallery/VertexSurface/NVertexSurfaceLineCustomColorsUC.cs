using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
	public class NVertexSurfaceLineCustomColorsUC : NExampleBaseUC
    {
        private UI.WinForm.Controls.NComboBox DataPointCountPerLineComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private UI.WinForm.Controls.NNumericUpDown NumberOfLinesUpDown;
        private System.ComponentModel.Container components = null;

		public NVertexSurfaceLineCustomColorsUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
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
            this.DataPointCountPerLineComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfLinesUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfLinesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DataPointCountPerLineComboBox
            // 
            this.DataPointCountPerLineComboBox.ListProperties.CheckBoxDataMember = "";
            this.DataPointCountPerLineComboBox.ListProperties.DataSource = null;
            this.DataPointCountPerLineComboBox.ListProperties.DisplayMember = "";
            this.DataPointCountPerLineComboBox.Location = new System.Drawing.Point(8, 27);
            this.DataPointCountPerLineComboBox.Name = "DataPointCountPerLineComboBox";
            this.DataPointCountPerLineComboBox.Size = new System.Drawing.Size(159, 21);
            this.DataPointCountPerLineComboBox.TabIndex = 11;
            this.DataPointCountPerLineComboBox.SelectedIndexChanged += new System.EventHandler(this.DataPointCountPerLineComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Data Points per Line:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Number of Lines:";
            // 
            // NumberOfLinesUpDown
            // 
            this.NumberOfLinesUpDown.Location = new System.Drawing.Point(8, 91);
            this.NumberOfLinesUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumberOfLinesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberOfLinesUpDown.Name = "NumberOfLinesUpDown";
            this.NumberOfLinesUpDown.Size = new System.Drawing.Size(159, 20);
            this.NumberOfLinesUpDown.TabIndex = 13;
            this.NumberOfLinesUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberOfLinesUpDown.ValueChanged += new System.EventHandler(this.NumberOfLinesUpDown_ValueChanged);
            // 
            // NVertexSurfaceLineCustomColorsUC
            // 
            this.Controls.Add(this.NumberOfLinesUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataPointCountPerLineComboBox);
            this.Controls.Add(this.label4);
            this.Name = "NVertexSurfaceLineCustomColorsUC";
            this.Size = new System.Drawing.Size(180, 956);
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfLinesUpDown)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;
			nChartControl1.Settings.JitterMode = JitterMode.Disabled;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Vertex Surface Series<br/><font size='10pt'>Used to draw lines with very large amount of data and custom color per vertex</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 50.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.LightModel.EnableLighting = false;

            // setup axes
            NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleY.MaxTickCount = 5;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;

			DataPointCountPerLineComboBox.Items.Add("10K");
			DataPointCountPerLineComboBox.Items.Add("100K");
			DataPointCountPerLineComboBox.Items.Add("500K");

			DataPointCountPerLineComboBox.SelectedIndex = 1;
            NumberOfLinesUpDown.Value = 7;

            // apply layout
            ConfigureStandardLayout(chart, title, null);

			UpdateData();
		}

		private void UpdateData()
		{
			int dataPointCount = 0;
			switch (DataPointCountPerLineComboBox.SelectedIndex)
			{
				case 0:
					dataPointCount = 10000;
					break;
				case 1:
					dataPointCount = 100000;
					break;
				case 2:
					dataPointCount = 500000;
					break;
			}

			int lineCount = (int)NumberOfLinesUpDown.Value;
			NChart chart = nChartControl1.Charts[0];
			chart.Series.Clear();
			Random random = new Random();

            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

            for (int lineIndex = 0; lineIndex < lineCount; lineIndex++)
			{
				// setup surface series
				NVertexSurfaceSeries surface = new NVertexSurfaceSeries();
				chart.Series.Add(surface);

				surface.Name = "Surface";
				surface.SyncPaletteWithAxisScale = false;
				surface.PaletteSteps = 8;
				surface.ValueFormatter.FormatSpecifier = "0.00";
				surface.FillMode = SurfaceFillMode.CustomColors;
				surface.FrameMode = SurfaceFrameMode.Dots;
				surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
				surface.VertexPrimitive = VertexPrimitive.LineStrip;
				surface.Data.UseColors = true;
				surface.Data.SetCapacity(dataPointCount);

				double x = 0.1;
				double y = 0;
				double z = 0;
				double a = 10.0;
                double b = 18 + lineIndex; // 28.0 - ;
				double c = (lineIndex + 3) / 3.0; //8.0
				double t = lineIndex * (0.01 / lineCount) + 0.01;

                NArgbColorValue color1 = new NArgbColorValue(palette.SeriesColors[lineIndex % palette.SeriesColors.Count]);
				NArgbColorValue color2 = new NArgbColorValue(palette.SeriesColors[(lineIndex + 1) % palette.SeriesColors.Count]);

                unsafe
				{
					fixed (byte* pData = &surface.Data.Data[0])
					{
						float* pVertex = (float*)pData;
						uint* pColor = (uint*)(pData + surface.Data.ColorOffset * 4);

						for (int dataPointIndex = 0; dataPointIndex < dataPointCount; dataPointIndex++)
						{
							float xt = (float)(x + t * a * (y - x));
							float yt = (float)(y + t * (x * (b - z) - y));
							float zt = (float)(z + t * (x * y - c * z));

							pVertex[0] = xt;
							pVertex[1] = yt;
							pVertex[2] = zt;
							*pColor = InterpolateColors(color1, color2, (float)((yt + 40.0) / 80.0)).Value;

							pVertex += 4;
							pColor += 4;

							x = xt;
							y = yt;
							z = zt;
						}
					}
				}

				// notify series that data has changed as we've modified it directly using pointers
				surface.Data.SetCount(dataPointCount);
			}

            nChartControl1.Refresh();
		}
		/// <summary>
		/// Returns a color between begin and end color. The coff parameter must be in the range [0, 1].
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <param name="coeff"></param>
		/// <returns></returns>
		public static NArgbColorValue InterpolateColors(NArgbColorValue begin, NArgbColorValue end, float coeff)
		{
			int a1 = (int)((begin.Value >> 24) & 0xff);
			int r1 = (int)((begin.Value >> 16) & 0xff);
			int g1 = (int)((begin.Value >> 8) & 0xff);
			int b1 = (int)(begin.Value & 0xff);

			int a2 = (int)((end.Value >> 24) & 0xff);
			int r2 = (int)((end.Value >> 16) & 0xff);
			int g2 = (int)((end.Value >> 8) & 0xff);
			int b2 = (int)(end.Value & 0xff);

			int a3 = a1 + (int)((a2 - a1) * coeff);
			int r3 = r1 + (int)((r2 - r1) * coeff);
			int g3 = g1 + (int)((g2 - g1) * coeff);
			int b3 = b1 + (int)((b2 - b1) * coeff);

			return new NArgbColorValue((UInt32)((r3 << 16) | (g3 << 8) | b3 | (a3 << 24)));
		}

		private void DataPointCountPerLineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			UpdateData();
		}

        private void NumberOfLinesUpDown_ValueChanged(object sender, EventArgs e)
        {
			UpdateData();
        }
    }
}