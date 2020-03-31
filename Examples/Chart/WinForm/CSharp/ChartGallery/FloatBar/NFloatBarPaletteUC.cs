using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NFloatBarPaletteUC : NExampleBaseUC
    {
        NFloatBarSeries m_FloatBar;
        NChart m_Chart;

        private UI.WinForm.Controls.NCheckBox Enable3DCheckBox;
        private UI.WinForm.Controls.NCheckBox SmoothPaletteCheckBox;
        private UI.WinForm.Controls.NCheckBox InvertAxisCheckBox;
		private System.ComponentModel.Container components = null;

		public NFloatBarPaletteUC()
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
            this.Enable3DCheckBox.TabIndex = 7;
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
            this.SmoothPaletteCheckBox.TabIndex = 6;
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
            this.InvertAxisCheckBox.TabIndex = 5;
            this.InvertAxisCheckBox.Text = "Invert Axis";
            this.InvertAxisCheckBox.CheckedChanged += new System.EventHandler(this.InvertAxisCheckBox_CheckedChanged);
            // 
            // NFloatBarPaletteUC
            // 
            this.Controls.Add(this.Enable3DCheckBox);
            this.Controls.Add(this.SmoothPaletteCheckBox);
            this.Controls.Add(this.InvertAxisCheckBox);
            this.Name = "NFloatBarPaletteUC";
            this.Size = new System.Drawing.Size(180, 305);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Float Bar Palette");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

			// add interlaced stripe to the Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// create the float bar series
			m_FloatBar = (NFloatBarSeries)m_Chart.Series.Add(SeriesType.FloatBar);
			m_FloatBar.DataLabelStyle.Visible = false;
			m_FloatBar.DataLabelStyle.VertAlign = VertAlign.Center;
			m_FloatBar.DataLabelStyle.Format = "<begin> - <end>";

			// add bars
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
			m_FloatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(10, Color.Yellow);
            palette.Add(20, Color.Red);

            m_FloatBar.Palette = palette;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

            SmoothPaletteCheckBox.Checked = true;
            Enable3DCheckBox.Checked = true;
		}

        private void Enable3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Chart.Enable3D = Enable3DCheckBox.Checked;

            nChartControl1.Refresh();
        }

        private void SmoothPaletteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_FloatBar.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;
            nChartControl1.Refresh();
        }

        private void InvertAxisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisCheckBox.Checked;

            nChartControl1.Refresh();
        }
	}
}
