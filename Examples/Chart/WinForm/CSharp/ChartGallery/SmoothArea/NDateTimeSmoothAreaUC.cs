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
	public class NDateTimeSmoothAreaUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;
		private const int nValuesCount = 5;
		private Nevron.UI.WinForm.Controls.NButton btnChangeXValues;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowMarkersCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDropLinesCheck;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox AreaOriginModeCombo;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NTextBox OriginValueTextBox;
		private Nevron.UI.WinForm.Controls.NButton btnChangeYValues;

		public NDateTimeSmoothAreaUC()
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
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowMarkersCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowDropLinesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.OriginValueTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.AreaOriginModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
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
			// btnChangeYValues
			// 
			this.btnChangeYValues.Location = new System.Drawing.Point(5, 8);
			this.btnChangeYValues.Name = "btnChangeYValues";
			this.btnChangeYValues.Size = new System.Drawing.Size(170, 32);
			this.btnChangeYValues.TabIndex = 0;
			this.btnChangeYValues.Text = "Change Y Values";
			this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(4, 269);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(170, 24);
			this.RoundToTickCheck.TabIndex = 8;
			this.RoundToTickCheck.Text = "Axis Round To Tick ";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.checkRoundToTick_CheckedChanged);
			// 
			// ShowMarkersCheck
			// 
			this.ShowMarkersCheck.ButtonProperties.BorderOffset = 2;
			this.ShowMarkersCheck.Location = new System.Drawing.Point(4, 96);
			this.ShowMarkersCheck.Name = "ShowMarkersCheck";
			this.ShowMarkersCheck.Size = new System.Drawing.Size(170, 24);
			this.ShowMarkersCheck.TabIndex = 2;
			this.ShowMarkersCheck.Text = "Show Markers";
			this.ShowMarkersCheck.CheckedChanged += new System.EventHandler(this.checkShowMarkers_CheckedChanged);
			// 
			// ShowDropLinesCheck
			// 
			this.ShowDropLinesCheck.ButtonProperties.BorderOffset = 2;
			this.ShowDropLinesCheck.Location = new System.Drawing.Point(4, 120);
			this.ShowDropLinesCheck.Name = "ShowDropLinesCheck";
			this.ShowDropLinesCheck.Size = new System.Drawing.Size(170, 24);
			this.ShowDropLinesCheck.TabIndex = 3;
			this.ShowDropLinesCheck.Text = "Show Drop Lines";
			this.ShowDropLinesCheck.CheckedChanged += new System.EventHandler(this.ShowDropLinesCheck_CheckedChanged);
			// 
			// OriginValueTextBox
			// 
			this.OriginValueTextBox.Location = new System.Drawing.Point(5, 231);
			this.OriginValueTextBox.Name = "OriginValueTextBox";
			this.OriginValueTextBox.Size = new System.Drawing.Size(169, 18);
			this.OriginValueTextBox.TabIndex = 7;
			this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 208);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Origin Value:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AreaOriginModeCombo
			// 
			this.AreaOriginModeCombo.ListProperties.CheckBoxDataMember = "";
			this.AreaOriginModeCombo.ListProperties.DataSource = null;
			this.AreaOriginModeCombo.ListProperties.DisplayMember = "";
			this.AreaOriginModeCombo.Location = new System.Drawing.Point(5, 176);
			this.AreaOriginModeCombo.Name = "AreaOriginModeCombo";
			this.AreaOriginModeCombo.Size = new System.Drawing.Size(170, 21);
			this.AreaOriginModeCombo.TabIndex = 5;
			this.AreaOriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.AreaOriginModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 160);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Area Origin Mode:";
			// 
			// NDateTimeSmoothAreaUC
			// 
			this.Controls.Add(this.AreaOriginModeCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.OriginValueTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ShowDropLinesCheck);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.ShowMarkersCheck);
			this.Controls.Add(this.btnChangeXValues);
			this.Controls.Add(this.btnChangeYValues);
			this.Name = "NDateTimeSmoothAreaUC";
			this.Size = new System.Drawing.Size(180, 305);
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Date/Time Smooth Area");
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

			// add the area series
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series.Add(SeriesType.SmoothArea);
			area.DataLabelStyle.Visible = false;
			area.MarkerStyle.Visible = true;
			area.MarkerStyle.PointShape = PointShape.Cylinder;
			area.MarkerStyle.AutoDepth = false;
			area.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Depth = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.UseXValues = true;

			ShowMarkersCheck.Checked = true;
			RoundToTickCheck.Checked = true;
			ShowDropLinesCheck.Checked = false;
			AreaOriginModeCombo.FillFromEnum(typeof(SeriesOriginMode));
			AreaOriginModeCombo.SelectedIndex = 0;
			OriginValueTextBox.Text = "0";

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
				series.Values.Add(5 + Random.NextDouble() * 10);
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
			NSeries series = (NSeries)chart.Series[0];

			series.MarkerStyle.Visible = ShowMarkersCheck.Checked;

			nChartControl1.Refresh();
		}

		private void checkRoundToTick_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			bool bRoundToTick = RoundToTickCheck.Checked;

			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			standardScale.RoundToTickMin = bRoundToTick;
			standardScale.RoundToTickMax = bRoundToTick;

			standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			standardScale.RoundToTickMin = bRoundToTick;
			standardScale.RoundToTickMax = bRoundToTick;

			nChartControl1.Refresh();
		}

		private void ShowDropLinesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series[0];

			area.DropLines = ShowDropLinesCheck.Checked;

			nChartControl1.Refresh();
		}

		private void AreaOriginModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series[0];

			area.OriginMode = (SeriesOriginMode)AreaOriginModeCombo.SelectedIndex;

			nChartControl1.Refresh();

			OriginValueTextBox.Enabled = (area.OriginMode == SeriesOriginMode.CustomOrigin);
		}

		private void OriginValueTextBox_TextChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series[0];

			try
			{
				area.Origin = Double.Parse(OriginValueTextBox.Text);
				nChartControl1.Refresh();
			}
			catch
			{
			}
		}
	}
}

