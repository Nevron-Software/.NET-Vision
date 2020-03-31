using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NDateTimeFloatBarUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton btnChangeData;
		private System.ComponentModel.IContainer components = null;

		public NDateTimeFloatBarUC()
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
			this.btnChangeData = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// btnChangeData
			// 
			this.btnChangeData.Location = new System.Drawing.Point(7, 8);
			this.btnChangeData.Name = "btnChangeData";
			this.btnChangeData.Size = new System.Drawing.Size(164, 32);
			this.btnChangeData.TabIndex = 1;
			this.btnChangeData.Text = "Change Data";
			this.btnChangeData.Click += new System.EventHandler(this.btnChangeData_Click);
			// 
			// NDateTimeFloatBarUC
			// 
			this.Controls.Add(this.btnChangeData);
			this.Name = "NDateTimeFloatBarUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("DateTime Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

			// setup x axis
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			// create the float bar series
			NFloatBarSeries floatBar = new NFloatBarSeries();
			chart.Series.Add(floatBar);
			floatBar.UseXValues = true;
			floatBar.UseZValues = false;
			floatBar.InflateMargins = true;
			floatBar.DataLabelStyle.Visible = false;

			// bar appearance
			floatBar.BorderStyle.Color = Color.Bisque;
			floatBar.ShadowStyle.Type = ShadowType.Solid;
			floatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0);

			floatBar.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			floatBar.EndValues.ValueFormatter = new NNumericValueFormatter("0.00");

			// show the begin end values in the legend
			floatBar.Legend.Format = "<begin> - <end>";
			floatBar.Legend.Mode = SeriesLegendMode.DataPoints;

            GenerateData(floatBar);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void GenerateData(NFloatBarSeries floatBar)
		{
			const int nCount = 6;

			floatBar.Values.Clear();
			floatBar.EndValues.Clear();
			floatBar.XValues.Clear();

			// generate Y values
			for(int i = 0; i < nCount; i++)
			{
				double dBeginValue = Random.NextDouble() * 5;
				double dEndValue = dBeginValue + 2 + Random.NextDouble();
				floatBar.Values.Add(dBeginValue);
				floatBar.EndValues.Add(dEndValue);
			}

			// generate X values
			DateTime dt = new DateTime(2007, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				floatBar.XValues.Add(dt);
			}
		}

		private void btnChangeData_Click(object sender, System.EventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];

			GenerateData(floatBar);

			nChartControl1.Refresh();
		}
	}
}

