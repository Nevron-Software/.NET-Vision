using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NHighLowPaletteUC : NExampleBaseUC
	{
		private NChart m_Chart;
        private NHighLowSeries m_HighLow;
        private UI.WinForm.Controls.NCheckBox Enable3DCheckBox;
        private UI.WinForm.Controls.NCheckBox SmoothPaletteCheckBox;
        private UI.WinForm.Controls.NCheckBox InvertAxisCheckBox;
		private System.ComponentModel.Container components = null;

		public NHighLowPaletteUC()
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
            this.Enable3DCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SmoothPaletteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.InvertAxisCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // Enable3DCheckBox
            // 
            this.Enable3DCheckBox.ButtonProperties.BorderOffset = 2;
            this.Enable3DCheckBox.ButtonProperties.ShowFocusRect = false;
            this.Enable3DCheckBox.ButtonProperties.WrapText = true;
            this.Enable3DCheckBox.Location = new System.Drawing.Point(9, 56);
            this.Enable3DCheckBox.Name = "Enable3DCheckBox";
            this.Enable3DCheckBox.Size = new System.Drawing.Size(139, 18);
            this.Enable3DCheckBox.TabIndex = 10;
            this.Enable3DCheckBox.Text = "Enable 3D";
            this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
            // 
            // SmoothPaletteCheckBox
            // 
            this.SmoothPaletteCheckBox.ButtonProperties.BorderOffset = 2;
            this.SmoothPaletteCheckBox.ButtonProperties.ShowFocusRect = false;
            this.SmoothPaletteCheckBox.ButtonProperties.WrapText = true;
            this.SmoothPaletteCheckBox.Location = new System.Drawing.Point(9, 34);
            this.SmoothPaletteCheckBox.Name = "SmoothPaletteCheckBox";
            this.SmoothPaletteCheckBox.Size = new System.Drawing.Size(139, 18);
            this.SmoothPaletteCheckBox.TabIndex = 9;
            this.SmoothPaletteCheckBox.Text = "Smooth Palette";
            this.SmoothPaletteCheckBox.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheckBox_CheckedChanged);
            // 
            // InvertAxisCheckBox
            // 
            this.InvertAxisCheckBox.ButtonProperties.BorderOffset = 2;
            this.InvertAxisCheckBox.ButtonProperties.ShowFocusRect = false;
            this.InvertAxisCheckBox.ButtonProperties.WrapText = true;
            this.InvertAxisCheckBox.Location = new System.Drawing.Point(9, 12);
            this.InvertAxisCheckBox.Name = "InvertAxisCheckBox";
            this.InvertAxisCheckBox.Size = new System.Drawing.Size(139, 18);
            this.InvertAxisCheckBox.TabIndex = 8;
            this.InvertAxisCheckBox.Text = "Invert Axis";
            this.InvertAxisCheckBox.CheckedChanged += new System.EventHandler(this.InvertAxisCheckBox_CheckedChanged);
            // 
            // NHighLowPaletteUC
            // 
            this.Controls.Add(this.Enable3DCheckBox);
            this.Controls.Add(this.SmoothPaletteCheckBox);
            this.Controls.Add(this.InvertAxisCheckBox);
            this.Name = "NHighLowPaletteUC";
            this.Size = new System.Drawing.Size(180, 270);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("High Low Palette");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add a High-Low series
			m_HighLow = (NHighLowSeries)m_Chart.Series.Add(SeriesType.HighLow);
			m_HighLow.Legend.Mode = SeriesLegendMode.None;
			m_HighLow.DataLabelStyle.Visible = false;

			GenerateData();

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(1.5, Color.Yellow);
            palette.Add(3, Color.Red);

            m_HighLow.Palette = palette;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            SmoothPaletteCheckBox.Checked = true;
            Enable3DCheckBox.Checked = true;
		}

		private void GenerateData()
		{
			m_HighLow.ClearDataPoints();

			for(int i = 0; i < 20; i++)
			{
				double d1 = Math.Log(i + 1) + 0.1 * Random.NextDouble();
				double d2 = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble();

				m_HighLow.HighValues.Add(d1);
				m_HighLow.LowValues.Add(d2);
			}
		}

        private void InvertAxisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisCheckBox.Checked;
            nChartControl1.Refresh();
        }

        private void SmoothPaletteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_HighLow.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;
            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Chart.Enable3D = Enable3DCheckBox.Checked;
            nChartControl1.Refresh();
        }
	}
}