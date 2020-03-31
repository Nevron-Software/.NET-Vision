using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSmoothAreaPaletteUC : NExampleBaseUC
	{
        NChart m_Chart;
        NSmoothAreaSeries m_SmoothArea;

        private const int nValuesCount = 6;
        private UI.WinForm.Controls.NCheckBox Enable3DCheckBox;
        private UI.WinForm.Controls.NCheckBox SmoothPaletteCheckBox;
        private UI.WinForm.Controls.NCheckBox InvertAxisCheckBox;
		private System.ComponentModel.IContainer components = null;

		public NSmoothAreaPaletteUC()
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
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Designer generated code
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
            this.Enable3DCheckBox.TabIndex = 13;
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
            this.SmoothPaletteCheckBox.TabIndex = 12;
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
            this.InvertAxisCheckBox.TabIndex = 11;
            this.InvertAxisCheckBox.Text = "Invert Axis";
            this.InvertAxisCheckBox.CheckedChanged += new System.EventHandler(this.InvertAxisCheckBox_CheckedChanged);
            // 
            // NSmoothAreaPaletteUC
            // 
            this.Controls.Add(this.Enable3DCheckBox);
            this.Controls.Add(this.SmoothPaletteCheckBox);
            this.Controls.Add(this.InvertAxisCheckBox);
            this.Name = "NSmoothAreaPaletteUC";
            this.Size = new System.Drawing.Size(180, 320);
            this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Smooth Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legends
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 65;
			m_Chart.Height = 40;
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// setup axes
			NLinearScaleConfigurator linearScaleX = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleX;

			NLinearScaleConfigurator linearScaleY = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleY.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add interlaced stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleY.StripStyles.Add(stripStyle);

			// add the area series
            m_SmoothArea = new NSmoothAreaSeries();
            m_Chart.Series.Add(m_SmoothArea);

			m_SmoothArea.DataLabelStyle.Visible = false;
			m_SmoothArea.MarkerStyle.Visible = false;
			m_SmoothArea.UseXValues = true;

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(5, Color.Yellow);
            palette.Add(10, Color.Red);

            m_SmoothArea.Palette = palette;

			GenerateYValues(nValuesCount);
			GenerateXValues(nValuesCount);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
            SmoothPaletteCheckBox.Checked = true;
            Enable3DCheckBox.Checked = true;
		}

		private void GenerateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			series.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				series.Values.Add(5 + Random.NextDouble() * 10);
			}
		}
		private void GenerateXValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NXYScatterSeries series = (NXYScatterSeries)chart.Series[0];

			series.XValues.Clear();

			double x = 120;

			for(int i = 0; i < nCount; i++)
			{
				x += 10 + Random.NextDouble() * 10;

				series.XValues.Add(x);
			}
		}

        private void InvertAxisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisCheckBox.Checked;
            nChartControl1.Refresh();
        }

        private void SmoothPaletteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_SmoothArea.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;
            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Chart.Enable3D = Enable3DCheckBox.Checked;
            nChartControl1.Refresh();
        }
	}
}

