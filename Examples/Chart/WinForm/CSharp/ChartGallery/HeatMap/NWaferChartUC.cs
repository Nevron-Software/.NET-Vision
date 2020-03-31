using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public partial class NWaferChartUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

        NHeatMapSeries m_HeatMap;
        private UI.WinForm.Controls.NCheckBox InterpolateImageCheckBox;

        public NWaferChartUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		private void InitializeComponent()
		{
            this.InterpolateImageCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // InterpolateImageCheckBox
            // 
            this.InterpolateImageCheckBox.ButtonProperties.BorderOffset = 2;
            this.InterpolateImageCheckBox.Location = new System.Drawing.Point(12, 13);
            this.InterpolateImageCheckBox.Name = "InterpolateImageCheckBox";
            this.InterpolateImageCheckBox.Size = new System.Drawing.Size(150, 24);
            this.InterpolateImageCheckBox.TabIndex = 15;
            this.InterpolateImageCheckBox.Text = "Interpolate Image";
            this.InterpolateImageCheckBox.CheckedChanged += new System.EventHandler(this.InterpolateImageCheckBox_CheckedChanged);
            // 
            // NWaferChartUC
            // 
            this.Controls.Add(this.InterpolateImageCheckBox);
            this.Name = "NWaferChartUC";
            this.Size = new System.Drawing.Size(186, 321);
            this.ResumeLayout(false);

		}

		#endregion
		
		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Wafer Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

            // configure chart
            NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];

            m_HeatMap = new NHeatMapSeries();
            chart.Series.Add(m_HeatMap);

            NHeatMapData data = m_HeatMap.Data;

            m_HeatMap.Palette.Mode = PaletteMode.AutoFixedEntryCount;
            m_HeatMap.Palette.AutoPaletteColors = new NArgbColorValue[] { new NArgbColorValue(Color.Green), new NArgbColorValue(Color.Red) };
            m_HeatMap.Palette.SmoothPalette = true;

            int gridSizeX = 100;
            int gridSizeY = 100;
            data.SetGridSize(gridSizeX, gridSizeY);

            int centerX = gridSizeX / 2;
            int centerY = gridSizeY / 2;

            int radius = gridSizeX / 2;
            Random rand = new Random();

            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    int dx = x - centerX;
                    int dy = y - centerY;

                    double pointDistance = Math.Sqrt(dx * dx + dy * dy);

                    if (pointDistance < radius)
                    {
                        // assign value
                        data.SetValue(x, y, pointDistance + rand.Next(20));
                    }
                    else
                    {
                        data.SetValue(x, y, double.NaN);
                    }
                }
            }
		}

        private void InterpolateImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_HeatMap.InterpolateImage = InterpolateImageCheckBox.Checked;
            nChartControl1.Refresh();
        }
	}
}
