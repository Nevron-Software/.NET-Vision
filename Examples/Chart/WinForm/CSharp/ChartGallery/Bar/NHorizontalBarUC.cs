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
	public class NHorizontalBarUC : NExampleBaseUC
	{
		private const int categoriesCount = 6;
		private Nevron.UI.WinForm.Controls.NButton PositiveData;
		private Nevron.UI.WinForm.Controls.NButton PositiveNegativeData;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private System.ComponentModel.Container components = null;

		public NHorizontalBarUC()
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
			this.PositiveData = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveNegativeData = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// PositiveData
			// 
			this.PositiveData.Location = new System.Drawing.Point(8, 58);
			this.PositiveData.Name = "PositiveData";
			this.PositiveData.Size = new System.Drawing.Size(156, 23);
			this.PositiveData.TabIndex = 2;
			this.PositiveData.Text = "Positive Data";
			this.PositiveData.Click += new System.EventHandler(this.PositiveData_Click);
			// 
			// PositiveNegativeData
			// 
			this.PositiveNegativeData.Location = new System.Drawing.Point(8, 90);
			this.PositiveNegativeData.Name = "PositiveNegativeData";
			this.PositiveNegativeData.Size = new System.Drawing.Size(156, 23);
			this.PositiveNegativeData.TabIndex = 3;
			this.PositiveNegativeData.Text = "Positive And Negative Data";
			this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeData_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bar Style:";
			// 
			// StyleCombo
			// 
			this.StyleCombo.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo.ListProperties.DataSource = null;
			this.StyleCombo.ListProperties.DisplayMember = "";
			this.StyleCombo.Location = new System.Drawing.Point(8, 25);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(158, 21);
			this.StyleCombo.TabIndex = 1;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// NHorizontalBarUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.StyleCombo);
			this.Controls.Add(this.PositiveNegativeData);
			this.Controls.Add(this.PositiveData);
			this.Name = "NHorizontalBarUC";
			this.Size = new System.Drawing.Size(180, 196);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Horizontal Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterRight);
			chart.Width = 40;
			chart.Height = 65;

			chart.Axis(StandardAxis.PrimaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true, 0, 100);
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe to the Y axis
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add a bar series
			NBarSeries b1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			b1.MultiBarMode = MultiBarMode.Series;
			b1.Name = "Bar 1";
			b1.DataLabelStyle.Format = "<value>";
            b1.Legend.Mode = SeriesLegendMode.DataPoints;
			b1.Values.AddRange(new double[]{ 10, 27, 43, 71, 89, 93 });

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			StyleCombo.FillFromEnum(typeof(BarShape));
			StyleCombo.SelectedIndex = 0;
		}

		private void PositiveData_Click(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			nChartControl1.Refresh();
		}

		private void PositiveNegativeData_Click(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			nChartControl1.Refresh();
		}

		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.BarShape = (BarShape)StyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
	}
}
