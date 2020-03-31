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
	public class NDateTimeStepLineUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;
		private Nevron.UI.WinForm.Controls.NButton btnChangeYValues;
		private Nevron.UI.WinForm.Controls.NButton btnChangeXValues;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowMarkersCheck;
		private const int nValuesCount = 10;

		public NDateTimeStepLineUC()
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
			this.ShowMarkersCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// btnChangeYValues
			// 
			this.btnChangeYValues.Location = new System.Drawing.Point(5, 8);
			this.btnChangeYValues.Name = "btnChangeYValues";
			this.btnChangeYValues.Size = new System.Drawing.Size(170, 32);
			this.btnChangeYValues.TabIndex = 0;
			this.btnChangeYValues.Text = "Change Y Values";
			this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			// 
			// btnChangeXValues
			// 
			this.btnChangeXValues.Location = new System.Drawing.Point(5, 48);
			this.btnChangeXValues.Name = "btnChangeXValues";
			this.btnChangeXValues.Size = new System.Drawing.Size(170, 32);
			this.btnChangeXValues.TabIndex = 1;
			this.btnChangeXValues.Text = "Change X Values";
			this.btnChangeXValues.Click += new System.EventHandler(this.btnChangeXValues_Click);
			// 
			// ShowMarkersCheck
			// 
			this.ShowMarkersCheck.ButtonProperties.BorderOffset = 2;
			this.ShowMarkersCheck.Location = new System.Drawing.Point(5, 96);
			this.ShowMarkersCheck.Name = "ShowMarkersCheck";
			this.ShowMarkersCheck.Size = new System.Drawing.Size(162, 24);
			this.ShowMarkersCheck.TabIndex = 2;
			this.ShowMarkersCheck.Text = "Show Markers";
			this.ShowMarkersCheck.CheckedChanged += new System.EventHandler(this.ShowMarkersCheck_CheckedChanged);
			// 
			// NDateTimeStepLineUC
			// 
			this.Controls.Add(this.ShowMarkersCheck);
			this.Controls.Add(this.btnChangeXValues);
			this.Controls.Add(this.btnChangeYValues);
			this.Name = "NDateTimeStepLineUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base. Initialize();

			// set a chart title
			NLabel title = new NLabel("DateTime Step Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Width = 90;
			chart.BoundsMode = BoundsMode.Stretch;

            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// switch the X axis in date time scale mode
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2;
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// setup step line series
			NStepLineSeries line = (NStepLineSeries)chart.Series.Add(SeriesType.StepLine);
			line.Name = "Step Line Series";
			line.InflateMargins = true;
			line.UseXValues = true;
			line.UseZValues = false;
			line.DataLabelStyle.Visible = false;
			line.ShadowStyle.Type = ShadowType.Solid;
			line.ShadowStyle.Color = Color.FromArgb(15, 0, 0, 0);
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);

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

		private void ShowMarkersCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NStepLineSeries line = (NStepLineSeries)chart.Series[0];

			line.MarkerStyle.Visible = ShowMarkersCheck.Checked;

			nChartControl1.Refresh();
		}

		private void GenerateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NStepLineSeries line = (NStepLineSeries)chart.Series[0];

			line.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				line.Values.Add(Random.NextDouble() * 20);
			}
		}

		private void GenerateXValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NStepLineSeries line = (NStepLineSeries)chart.Series[0];

			line.XValues.Clear();

			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				line.XValues.Add(dt);
			}
		}
	}
}

