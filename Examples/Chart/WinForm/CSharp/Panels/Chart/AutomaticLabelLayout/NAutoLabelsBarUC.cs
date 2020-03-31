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
	public class NAutoLabelsBarUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableInitialPositioningCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableLabelAdjustmentCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RemoveOverlappedLabelsCheck;
		private Label label6;
		private Nevron.UI.WinForm.Controls.NComboBox LocationsCombo;
		private System.ComponentModel.Container components = null;

		public NAutoLabelsBarUC()
		{
			InitializeComponent();

			LocationsCombo.Items.Add("Top");
			LocationsCombo.Items.Add("Top - Bottom");
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
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.EnableInitialPositioningCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableLabelAdjustmentCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RemoveOverlappedLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.LocationsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(5, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(171, 24);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// EnableInitialPositioningCheck
			// 
			this.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2;
			this.EnableInitialPositioningCheck.Location = new System.Drawing.Point(5, 47);
			this.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck";
			this.EnableInitialPositioningCheck.Size = new System.Drawing.Size(170, 21);
			this.EnableInitialPositioningCheck.TabIndex = 10;
			this.EnableInitialPositioningCheck.Text = "Enable Initial Positioning";
			this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			// 
			// EnableLabelAdjustmentCheck
			// 
			this.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2;
			this.EnableLabelAdjustmentCheck.Location = new System.Drawing.Point(5, 118);
			this.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck";
			this.EnableLabelAdjustmentCheck.Size = new System.Drawing.Size(170, 21);
			this.EnableLabelAdjustmentCheck.TabIndex = 9;
			this.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment";
			this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			// 
			// RemoveOverlappedLabelsCheck
			// 
			this.RemoveOverlappedLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.RemoveOverlappedLabelsCheck.ButtonProperties.WrapText = true;
			this.RemoveOverlappedLabelsCheck.Location = new System.Drawing.Point(5, 74);
			this.RemoveOverlappedLabelsCheck.Name = "RemoveOverlappedLabelsCheck";
			this.RemoveOverlappedLabelsCheck.Size = new System.Drawing.Size(170, 38);
			this.RemoveOverlappedLabelsCheck.TabIndex = 11;
			this.RemoveOverlappedLabelsCheck.Text = "Remove Overlapped Labels After Initial Positioning";
			this.RemoveOverlappedLabelsCheck.CheckedChanged += new System.EventHandler(this.RemoveOverlappedLabelsCheck_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 153);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(153, 15);
			this.label6.TabIndex = 50;
			this.label6.Text = "Proposals for Label Location:";
			// 
			// LocationsCombo
			// 
			this.LocationsCombo.ListProperties.CheckBoxDataMember = "";
			this.LocationsCombo.ListProperties.DataSource = null;
			this.LocationsCombo.ListProperties.DisplayMember = "";
			this.LocationsCombo.Location = new System.Drawing.Point(3, 171);
			this.LocationsCombo.Name = "LocationsCombo";
			this.LocationsCombo.Size = new System.Drawing.Size(174, 21);
			this.LocationsCombo.TabIndex = 49;
			this.LocationsCombo.SelectedIndexChanged += new System.EventHandler(this.LocationsCombo_SelectedIndexChanged);
			// 
			// NAutoLabelsBarUC
			// 
			this.Controls.Add(this.label6);
			this.Controls.Add(this.LocationsCombo);
			this.Controls.Add(this.RemoveOverlappedLabelsCheck);
			this.Controls.Add(this.EnableInitialPositioningCheck);
			this.Controls.Add(this.EnableLabelAdjustmentCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Name = "NAutoLabelsBarUC";
			this.Size = new System.Drawing.Size(180, 277);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bar Chart");
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

			// bar series
			NBarSeries series1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowLength = new NLength(10);

			// enable initial labels positioning
			chart.LabelLayout.EnableInitialPositioning = true;

			// enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = true;

			// use only "top" location for the labels
			series1.LabelLayout.UseLabelLocations = true;
			series1.LabelLayout.LabelLocations = new LabelLocation[] { LabelLocation.Top };
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsIfIgnored = true;

			// protect data points from being overlapped
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
			RemoveOverlappedLabelsCheck.Checked = false;
			EnableLabelAdjustmentCheck.Checked = true;
			LocationsCombo.SelectedIndex = 0;
		}

		private void GenerateData(NSeries series)
		{
			series.Values.Clear();

			for (int i = 0; i < 30; i++)
			{
				double value = Math.Sin(i * 0.2) * 10 + Random.NextDouble() * 4;
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
			RemoveOverlappedLabelsCheck.Enabled = EnableInitialPositioningCheck.Checked;
			LocationsCombo.Enabled = EnableInitialPositioningCheck.Checked;

			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked;

			nChartControl1.Refresh();
		}

		private void RemoveOverlappedLabelsCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheck.Checked;

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
			}

			NChart chart = nChartControl1.Charts[0];
			chart.Series[0].LabelLayout.LabelLocations = locations;

			nChartControl1.Refresh();
		}
	}
}