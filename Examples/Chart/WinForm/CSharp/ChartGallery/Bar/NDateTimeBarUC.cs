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
	public class NDateTimeBarUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;
		private Nevron.UI.WinForm.Controls.NButton btnChangeYValues;
		private Nevron.UI.WinForm.Controls.NButton btnChangeXValues;
		private const int nValuesCount = 10;

		public NDateTimeBarUC()
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
			this.btnChangeYValues = new Nevron.UI.WinForm.Controls.NButton();
			this.btnChangeXValues = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// btnChangeYValues
			// 
			this.btnChangeYValues.Location = new System.Drawing.Point(8, 8);
			this.btnChangeYValues.Name = "btnChangeYValues";
			this.btnChangeYValues.Size = new System.Drawing.Size(161, 32);
			this.btnChangeYValues.TabIndex = 0;
			this.btnChangeYValues.Text = "Change Y Values";
			this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			// 
			// btnChangeXValues
			// 
			this.btnChangeXValues.Location = new System.Drawing.Point(8, 48);
			this.btnChangeXValues.Name = "btnChangeXValues";
			this.btnChangeXValues.Size = new System.Drawing.Size(161, 32);
			this.btnChangeXValues.TabIndex = 1;
			this.btnChangeXValues.Text = "Change X Values";
			this.btnChangeXValues.Click += new System.EventHandler(this.btnChangeXValues_Click);
			// 
			// NDateTimeBarUC
			// 
			this.Controls.Add(this.btnChangeXValues);
			this.Controls.Add(this.btnChangeYValues);
			this.Name = "NDateTimeBarUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("DateTime Bars");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripes to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 2, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2;
 			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			// setup bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.InflateMargins = true;
			bar.UseXValues = true;
			bar.UseZValues = false;
			bar.DataLabelStyle.Visible = false;
			bar.ShadowStyle.Type = ShadowType.Solid;
			bar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0);

			GenerateYValues(nValuesCount);
			GenerateXValues(nValuesCount);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void btnChangeYValues_Click(object sender, System.EventArgs e)
		{
			GenerateYValues(nValuesCount);
			nChartControl1.Refresh();
		}

		private void btnChangeXValues_Click(object sender, System.EventArgs e)
		{
			GenerateXValues(nValuesCount);
			nChartControl1.Refresh();
		}

		private void GenerateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NBarSeries bar = (NBarSeries)chart.Series[0];

			bar.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				bar.Values.Add(Random.NextDouble() * 20);
			}
		}

		private void GenerateXValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NBarSeries bar = (NBarSeries)chart.Series[0];

			bar.XValues.Clear();

			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				bar.XValues.Add(dt);
			}
		}
	}
}

