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
	public class NDateTimeSmoothLineUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;
		private const int nValuesCount = 8;
		private Nevron.UI.WinForm.Controls.NButton btnChangeXValues;
		private Nevron.UI.WinForm.Controls.NButton btnChangeYValues;
		private Nevron.UI.WinForm.Controls.NCheckBox checkRoundToTick;
		private Nevron.UI.WinForm.Controls.NCheckBox checkShowMarkers;

		public NDateTimeSmoothLineUC()
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
			this.btnChangeXValues = new Nevron.UI.WinForm.Controls.NButton();
			this.btnChangeYValues = new Nevron.UI.WinForm.Controls.NButton();
			this.checkRoundToTick = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.checkShowMarkers = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// btnChangeXValues
			// 
			this.btnChangeXValues.Location = new System.Drawing.Point(6, 47);
			this.btnChangeXValues.Name = "btnChangeXValues";
			this.btnChangeXValues.Size = new System.Drawing.Size(169, 32);
			this.btnChangeXValues.TabIndex = 1;
			this.btnChangeXValues.Text = "Change X Values";
			this.btnChangeXValues.Click += new System.EventHandler(this.btnChangeXValues_Click);
			// 
			// btnChangeYValues
			// 
			this.btnChangeYValues.Location = new System.Drawing.Point(6, 7);
			this.btnChangeYValues.Name = "btnChangeYValues";
			this.btnChangeYValues.Size = new System.Drawing.Size(169, 32);
			this.btnChangeYValues.TabIndex = 0;
			this.btnChangeYValues.Text = "Change Y Values";
			this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			// 
			// checkRoundToTick
			// 
			this.checkRoundToTick.ButtonProperties.BorderOffset = 2;
			this.checkRoundToTick.Location = new System.Drawing.Point(5, 135);
			this.checkRoundToTick.Name = "checkRoundToTick";
			this.checkRoundToTick.Size = new System.Drawing.Size(169, 24);
			this.checkRoundToTick.TabIndex = 3;
			this.checkRoundToTick.Text = "Axis Round To Tick ";
			this.checkRoundToTick.CheckedChanged += new System.EventHandler(this.checkRoundToTick_CheckedChanged);
			// 
			// checkShowMarkers
			// 
			this.checkShowMarkers.ButtonProperties.BorderOffset = 2;
			this.checkShowMarkers.Location = new System.Drawing.Point(5, 95);
			this.checkShowMarkers.Name = "checkShowMarkers";
			this.checkShowMarkers.Size = new System.Drawing.Size(169, 24);
			this.checkShowMarkers.TabIndex = 2;
			this.checkShowMarkers.Text = "Show Markers";
			this.checkShowMarkers.CheckedChanged += new System.EventHandler(this.checkShowMarkers_CheckedChanged);
			// 
			// NDateTimeSmoothLineUC
			// 
			this.Controls.Add(this.checkRoundToTick);
			this.Controls.Add(this.checkShowMarkers);
			this.Controls.Add(this.btnChangeXValues);
			this.Controls.Add(this.btnChangeYValues);
			this.Name = "NDateTimeSmoothLineUC";
			this.Size = new System.Drawing.Size(180, 176);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("DateTime Smooth Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add the line
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series.Add(SeriesType.SmoothLine);
			line.Name = "Smooth Line";
			line.InflateMargins = true;
			line.Legend.Mode = SeriesLegendMode.Series;
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.AutoDepth = false;
			line.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Depth = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.UseXValues = true;
			line.UseZValues = false;
			line.Use1DInterpolationForXYScatter = true;

			checkShowMarkers.Checked = true;
			checkRoundToTick.Checked = true;

			GenerateYValues(nValuesCount);
			GenerateXValues(nValuesCount);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void GenerateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			series.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				series.Values.Add(Random.NextDouble() * 20);
			}
		}

		private void GenerateXValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NXYScatterSeries series = (NXYScatterSeries)chart.Series[0];

			series.XValues.Clear();

			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				series.XValues.Add(dt);
			}
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

		private void checkShowMarkers_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series[0];

			line.MarkerStyle.Visible = checkShowMarkers.Checked;

			nChartControl1.Refresh();
		}

		private void checkRoundToTick_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			bool bRoundToTick = checkRoundToTick.Checked;

			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			standardScale.RoundToTickMin = bRoundToTick;
			standardScale.RoundToTickMax = bRoundToTick;

			standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			standardScale.RoundToTickMin = bRoundToTick;
			standardScale.RoundToTickMax = bRoundToTick;

			nChartControl1.Refresh();		
		}
	}
}

