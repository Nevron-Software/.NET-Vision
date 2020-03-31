using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NViewRangeUC : NExampleBaseUC
	{
        private UI.WinForm.Controls.NCheckBox UseCustomViewRangeCheckBox;
		private System.ComponentModel.Container components = null;

		public NViewRangeUC()
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
            this.UseCustomViewRangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // UseCustomViewRangeCheckBox
            // 
            this.UseCustomViewRangeCheckBox.AutoSize = true;
            this.UseCustomViewRangeCheckBox.ButtonProperties.BorderOffset = 2;
            this.UseCustomViewRangeCheckBox.Location = new System.Drawing.Point(15, 16);
            this.UseCustomViewRangeCheckBox.Name = "UseCustomViewRangeCheckBox";
            this.UseCustomViewRangeCheckBox.Size = new System.Drawing.Size(122, 17);
            this.UseCustomViewRangeCheckBox.TabIndex = 3;
            this.UseCustomViewRangeCheckBox.Text = "Custom View Range";
            this.UseCustomViewRangeCheckBox.UseVisualStyleBackColor = true;
            this.UseCustomViewRangeCheckBox.CheckedChanged += new System.EventHandler(this.UseCustomViewRangeCheckBox_CheckedChanged);
            // 
            // NViewRangeUC
            // 
            this.Controls.Add(this.UseCustomViewRangeCheckBox);
            this.Name = "NViewRangeUC";
            this.Size = new System.Drawing.Size(202, 182);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis View Range");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.BoundsMode = BoundsMode.Fit;

            // apply predefined lighting and projection
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // setup a bar series
            NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.Name = "Bar Series";
            bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            bar.ShadowStyle.Type = ShadowType.GaussianBlur;
            bar.ShadowStyle.Offset = new NPointL(2, 2);
            bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
            bar.ShadowStyle.FadeLength = new NLength(5);
            bar.HasBottomEdge = false;

            // add some data to the bar series
            bar.AddDataPoint(new NDataPoint(18, "C++"));
            bar.AddDataPoint(new NDataPoint(15, "Ruby"));
            bar.AddDataPoint(new NDataPoint(21, "Python"));
            bar.AddDataPoint(new NDataPoint(23, "Java"));
            bar.AddDataPoint(new NDataPoint(27, "Javascript"));
            bar.AddDataPoint(new NDataPoint(29, "C#"));
			bar.AddDataPoint(new NDataPoint(26, "PHP"));

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document.Charts[0]);

            // apply layout
            ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);
		}

        private void UseCustomViewRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NChart chart = nChartControl1.Charts[0];

            if (UseCustomViewRangeCheckBox.Checked)
            {
                // specify custom view range
                chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(14, 30), true, true);
            }
            else
            {
                chart.Axis(StandardAxis.PrimaryY).View = new NContentAxisView();
            }

            nChartControl1.Refresh();
        }
	}
}
