using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStackedAreaUC : NExampleBaseUC
	{
		private const int categoriesCount = 10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox StackModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox FirstAreaDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox ThirdAreaDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox SecondAreaDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDataLabelsCheck;
		private System.ComponentModel.Container components = null;

		public NStackedAreaUC()
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
			this.StackModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ThirdAreaDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SecondAreaDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.FirstAreaDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ShowDataLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// StackModeCombo
			// 
			this.StackModeCombo.ListProperties.CheckBoxDataMember = "";
			this.StackModeCombo.ListProperties.DataSource = null;
			this.StackModeCombo.ListProperties.DisplayMember = "";
			this.StackModeCombo.Location = new System.Drawing.Point(9, 27);
			this.StackModeCombo.Name = "StackModeCombo";
			this.StackModeCombo.Size = new System.Drawing.Size(159, 21);
			this.StackModeCombo.TabIndex = 1;
			this.StackModeCombo.SelectedIndexChanged += new System.EventHandler(this.StackModeCombo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(159, 21);
			this.label4.TabIndex = 0;
			this.label4.Text = "Stack Mode:";
			// 
			// ThirdAreaDataLabelsCombo
			// 
			this.ThirdAreaDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.ThirdAreaDataLabelsCombo.ListProperties.DataSource = null;
			this.ThirdAreaDataLabelsCombo.ListProperties.DisplayMember = "";
			this.ThirdAreaDataLabelsCombo.Location = new System.Drawing.Point(9, 228);
			this.ThirdAreaDataLabelsCombo.Name = "ThirdAreaDataLabelsCombo";
			this.ThirdAreaDataLabelsCombo.Size = new System.Drawing.Size(159, 21);
			this.ThirdAreaDataLabelsCombo.TabIndex = 8;
			this.ThirdAreaDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.ThirdAreaDataLabelsCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(159, 21);
			this.label3.TabIndex = 7;
			this.label3.Text = "Third Area Data Labels:";
			// 
			// SecondAreaDataLabelsCombo
			// 
			this.SecondAreaDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.SecondAreaDataLabelsCombo.ListProperties.DataSource = null;
			this.SecondAreaDataLabelsCombo.ListProperties.DisplayMember = "";
			this.SecondAreaDataLabelsCombo.Location = new System.Drawing.Point(9, 180);
			this.SecondAreaDataLabelsCombo.Name = "SecondAreaDataLabelsCombo";
			this.SecondAreaDataLabelsCombo.Size = new System.Drawing.Size(159, 21);
			this.SecondAreaDataLabelsCombo.TabIndex = 6;
			this.SecondAreaDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.SecondAreaDataLabelsCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 164);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(159, 21);
			this.label2.TabIndex = 5;
			this.label2.Text = "Second Area Data Labels:";
			// 
			// FirstAreaDataLabelsCombo
			// 
			this.FirstAreaDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.FirstAreaDataLabelsCombo.ListProperties.DataSource = null;
			this.FirstAreaDataLabelsCombo.ListProperties.DisplayMember = "";
			this.FirstAreaDataLabelsCombo.Location = new System.Drawing.Point(9, 132);
			this.FirstAreaDataLabelsCombo.Name = "FirstAreaDataLabelsCombo";
			this.FirstAreaDataLabelsCombo.Size = new System.Drawing.Size(159, 21);
			this.FirstAreaDataLabelsCombo.TabIndex = 4;
			this.FirstAreaDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.FirstAreaDataLabelsCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 116);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(159, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "First Area Data Labels:";
			// 
			// ShowDataLabelsCheck
			// 
			this.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.ShowDataLabelsCheck.Location = new System.Drawing.Point(9, 79);
			this.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck";
			this.ShowDataLabelsCheck.Size = new System.Drawing.Size(159, 21);
			this.ShowDataLabelsCheck.TabIndex = 2;
			this.ShowDataLabelsCheck.Text = "Show Data Labels";
			this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			// 
			// NStackedAreaUC
			// 
			this.Controls.Add(this.ShowDataLabelsCheck);
			this.Controls.Add(this.StackModeCombo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ThirdAreaDataLabelsCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SecondAreaDataLabelsCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FirstAreaDataLabelsCombo);
			this.Controls.Add(this.label1);
			this.Name = "NStackedAreaUC";
			this.Size = new System.Drawing.Size(180, 334);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective2);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < categoriesCount; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, (2000 + i).ToString()));
			}

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };

			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.StripStyles.Add(stripStyle);

			// hide Z axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add the first area
			NAreaSeries area0 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area0.MultiAreaMode = MultiAreaMode.Series;
			area0.Name = "Product A";
			SetupDataLabels(area0);

			// add the second Area
			NAreaSeries area1 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area1.MultiAreaMode = MultiAreaMode.Stacked;
			area1.Name = "Product B";
			SetupDataLabels(area1);

			// add the third Area
			NAreaSeries area2 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area2.MultiAreaMode = MultiAreaMode.Stacked;
			area2.Name = "Product C";
			SetupDataLabels(area2);

			// fill with random data
			area0.Values.FillRandomRange(Random, categoriesCount, 20, 50);
			area1.Values.FillRandomRange(Random, categoriesCount, 20, 50);
			area2.Values.FillRandomRange(Random, categoriesCount, 20, 50);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			InitLabelsCombo(FirstAreaDataLabelsCombo);
			InitLabelsCombo(SecondAreaDataLabelsCombo);
			InitLabelsCombo(ThirdAreaDataLabelsCombo);

			StackModeCombo.Items.Add("Stack");
			StackModeCombo.Items.Add("Stack 100%");
			StackModeCombo.SelectedIndex = 0;

			ShowDataLabelsCheck_CheckedChanged(null, null);
		}

		private void SetupDataLabels(NAreaSeries area)
		{
			NDataLabelStyle dataLabel = area.DataLabelStyle;
			dataLabel.ArrowLength = new NLength(0);
			dataLabel.VertAlign = VertAlign.Center;
			dataLabel.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			dataLabel.TextStyle.BackplaneStyle.Inflate = new NSizeL(5, 5);
			dataLabel.TextStyle.FontStyle = new NFontStyle("Arial", new NLength(8, NGraphicsUnit.Point), FontStyle.Bold);
		}
		private string GetFormatStringFromIndex(int index)
		{
			switch (index)
			{
				case 0:
					return "<value>";

				case 1:
					return "<total>";

				case 2:
					return "<cumulative>";

				case 3:
					return "<percent>";

				default:
					return "";
			}
		}
		private void InitLabelsCombo(Nevron.UI.WinForm.Controls.NComboBox comboBox)
		{
			comboBox.Items.Add("Value");
			comboBox.Items.Add("Total");
			comboBox.Items.Add("Cumulative");
			comboBox.Items.Add("Percent");
			comboBox.SelectedIndex = 0;
		}

		private void StackModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area1 = (NAreaSeries)chart.Series[1];
			NAreaSeries area2 = (NAreaSeries)chart.Series[2];
			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			switch (StackModeCombo.SelectedIndex)
			{
				case 0:
					area1.MultiAreaMode = MultiAreaMode.Stacked;
					area2.MultiAreaMode = MultiAreaMode.Stacked;
                    scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					area1.MultiAreaMode = MultiAreaMode.StackedPercent;
					area2.MultiAreaMode = MultiAreaMode.StackedPercent;
                    scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			nChartControl1.Refresh();
		}
		private void ShowDataLabelsCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area0 = (NAreaSeries)chart.Series[0];
			NAreaSeries area1 = (NAreaSeries)chart.Series[1];
			NAreaSeries area2 = (NAreaSeries)chart.Series[2];

			area0.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			area1.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			area2.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;

			FirstAreaDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;
			SecondAreaDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;
			ThirdAreaDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;

			nChartControl1.Refresh();
		}
		private void FirstAreaDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area0 = (NAreaSeries)chart.Series[0];

			area0.DataLabelStyle.Format = GetFormatStringFromIndex(FirstAreaDataLabelsCombo.SelectedIndex);

			nChartControl1.Refresh();
		}
		private void SecondAreaDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area1 = (NAreaSeries)chart.Series[1];

			area1.DataLabelStyle.Format = GetFormatStringFromIndex(SecondAreaDataLabelsCombo.SelectedIndex);

			nChartControl1.Refresh();
		}
		private void ThirdAreaDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area2 = (NAreaSeries)chart.Series[2];

			area2.DataLabelStyle.Format = GetFormatStringFromIndex(ThirdAreaDataLabelsCombo.SelectedIndex);

			nChartControl1.Refresh();
		}
	}
}
