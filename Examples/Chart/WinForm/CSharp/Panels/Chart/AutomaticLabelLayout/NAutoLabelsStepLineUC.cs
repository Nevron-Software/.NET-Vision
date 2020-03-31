using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAutoLabelsStepLineUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox EnableLabelAdjustmentCheck;
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableInitialPositioningCheck;
		private Label label6;
		private Nevron.UI.WinForm.Controls.NComboBox LocationsCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox InvertForDownwardDPCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox InvertIfOutOfBoundsCheck;
		private System.ComponentModel.Container components = null;

		public NAutoLabelsStepLineUC()
		{
			InitializeComponent();

			LocationsCombo.Items.Add("Top");
			LocationsCombo.Items.Add("Top - Bottom");
			LocationsCombo.Items.Add("Top - Bottom - Left - Right");
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
			this.EnableLabelAdjustmentCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.EnableInitialPositioningCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.LocationsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.InvertForDownwardDPCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InvertIfOutOfBoundsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// EnableLabelAdjustmentCheck
			// 
			this.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2;
			this.EnableLabelAdjustmentCheck.Location = new System.Drawing.Point(7, 78);
			this.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck";
			this.EnableLabelAdjustmentCheck.Size = new System.Drawing.Size(159, 21);
			this.EnableLabelAdjustmentCheck.TabIndex = 6;
			this.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment";
			this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(4, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(172, 24);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// EnableInitialPositioningCheck
			// 
			this.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2;
			this.EnableInitialPositioningCheck.Location = new System.Drawing.Point(7, 46);
			this.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck";
			this.EnableInitialPositioningCheck.Size = new System.Drawing.Size(159, 21);
			this.EnableInitialPositioningCheck.TabIndex = 8;
			this.EnableInitialPositioningCheck.Text = "Enable Initial Positioning";
			this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(4, 135);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(138, 15);
			this.label6.TabIndex = 48;
			this.label6.Text = "Proposals for Label Location:";
			// 
			// LocationsCombo
			// 
			this.LocationsCombo.ListProperties.CheckBoxDataMember = "";
			this.LocationsCombo.ListProperties.DataSource = null;
			this.LocationsCombo.ListProperties.DisplayMember = "";
			this.LocationsCombo.Location = new System.Drawing.Point(4, 153);
			this.LocationsCombo.Name = "LocationsCombo";
			this.LocationsCombo.Size = new System.Drawing.Size(172, 21);
			this.LocationsCombo.TabIndex = 47;
			this.LocationsCombo.SelectedIndexChanged += new System.EventHandler(this.LocationsCombo_SelectedIndexChanged);
			// 
			// InvertForDownwardDPCheck
			// 
			this.InvertForDownwardDPCheck.ButtonProperties.BorderOffset = 2;
			this.InvertForDownwardDPCheck.ButtonProperties.WrapText = true;
			this.InvertForDownwardDPCheck.Location = new System.Drawing.Point(4, 189);
			this.InvertForDownwardDPCheck.Name = "InvertForDownwardDPCheck";
			this.InvertForDownwardDPCheck.Size = new System.Drawing.Size(172, 34);
			this.InvertForDownwardDPCheck.TabIndex = 49;
			this.InvertForDownwardDPCheck.Text = "Invert Locations for Downward Data Points";
			this.InvertForDownwardDPCheck.CheckedChanged += new System.EventHandler(this.InvertForDownwardDPCheck_CheckedChanged);
			// 
			// InvertIfOutOfBoundsCheck
			// 
			this.InvertIfOutOfBoundsCheck.ButtonProperties.BorderOffset = 2;
			this.InvertIfOutOfBoundsCheck.ButtonProperties.WrapText = true;
			this.InvertIfOutOfBoundsCheck.Location = new System.Drawing.Point(4, 233);
			this.InvertIfOutOfBoundsCheck.Name = "InvertIfOutOfBoundsCheck";
			this.InvertIfOutOfBoundsCheck.Size = new System.Drawing.Size(172, 35);
			this.InvertIfOutOfBoundsCheck.TabIndex = 50;
			this.InvertIfOutOfBoundsCheck.Text = "Invert Locations If All Are Out of Bounds";
			this.InvertIfOutOfBoundsCheck.CheckedChanged += new System.EventHandler(this.InvertIfOutOfBoundsCheck_CheckedChanged);
			// 
			// NAutoLabelsStepLineUC
			// 
			this.Controls.Add(this.InvertIfOutOfBoundsCheck);
			this.Controls.Add(this.InvertForDownwardDPCheck);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.LocationsCombo);
			this.Controls.Add(this.EnableInitialPositioningCheck);
			this.Controls.Add(this.EnableLabelAdjustmentCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Name = "NAutoLabelsStepLineUC";
			this.Size = new System.Drawing.Size(180, 292);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Step Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

			// configure Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			// step line series
			NStepLineSeries series1 = (NStepLineSeries)chart.Series.Add(SeriesType.StepLine);
			series1.InflateMargins = true;
			series1.BorderStyle = new NStrokeStyle(new NLength(1.2f, NGraphicsUnit.Point), GreyBlue);

			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowLength = new NLength(12);
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;

			// label layout settings
			chart.LabelLayout.EnableInitialPositioning = true;
			chart.LabelLayout.EnableLabelAdjustment = true;

			series1.LabelLayout.UseLabelLocations = true;
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));

			// fill with random data 
			GenerateData(series1);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			EnableInitialPositioningCheck.Checked = true;
			EnableLabelAdjustmentCheck.Checked = true;
			LocationsCombo.SelectedIndex = 1;
			InvertForDownwardDPCheck.Checked = true;
			InvertIfOutOfBoundsCheck.Checked = true;
		}

		void GenerateData(NSeries series)
		{
			series.Values.Clear();

			for (int i = 0; i < 30; i++)
			{
				double value = Math.Sin(i * 0.2) * 10 + Random.NextDouble() * 2;
				series.Values.Add(value);
			}
		}

		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			GenerateData(series);

			nChartControl1.Refresh();
		}


		private void EnableInitialPositioningCheck_CheckedChanged(object sender, EventArgs e)
		{
			bool enableInitialPositioningSettings = EnableInitialPositioningCheck.Checked;
			LocationsCombo.Enabled = enableInitialPositioningSettings;
			InvertForDownwardDPCheck.Enabled = enableInitialPositioningSettings;
			InvertIfOutOfBoundsCheck.Enabled = enableInitialPositioningSettings;

			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked;

			nChartControl1.Refresh();
		}
		private void EnableLabelAdjustmentCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked;

			nChartControl1.Refresh();
		}
		private void LocationsCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			LabelLocation[] locations = null;

			switch (LocationsCombo.SelectedIndex)
			{
				case 0:
					locations = new LabelLocation[] { LabelLocation.Top };
					break;

				case 1:
					locations = new LabelLocation[] { LabelLocation.Top, LabelLocation.Bottom };
					break;

				case 2:
					locations = new LabelLocation[] { LabelLocation.Top, LabelLocation.Bottom, LabelLocation.Left, LabelLocation.Right };
					break;
			}

			NChart chart = nChartControl1.Charts[0];
			chart.Series[0].LabelLayout.LabelLocations = locations;

			nChartControl1.Refresh();
		}

		private void InvertForDownwardDPCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Series[0].LabelLayout.InvertLocationsForInvertedDataPoints = InvertForDownwardDPCheck.Checked;

			nChartControl1.Refresh();
		}

		private void InvertIfOutOfBoundsCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Series[0].LabelLayout.InvertLocationsIfIgnored = InvertIfOutOfBoundsCheck.Checked;

			nChartControl1.Refresh();
		}

	}
}