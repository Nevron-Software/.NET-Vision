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
	public class NSmoothArea3DUC : NExampleBaseUC
	{
		private const int nValuesCount = 6;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowMarkersCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDropLinesCheck;
		private Nevron.UI.WinForm.Controls.NComboBox AreaOriginModeCombo;
		private Nevron.UI.WinForm.Controls.NTextBox OriginValueTextBox;
		private Nevron.UI.WinForm.Controls.NButton btnChangeYValues;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components = null;

		public NSmoothArea3DUC()
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
			this.ShowMarkersCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowDropLinesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.OriginValueTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.AreaOriginModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnChangeYValues
			// 
			this.btnChangeYValues.Location = new System.Drawing.Point(6, 8);
			this.btnChangeYValues.Name = "btnChangeYValues";
			this.btnChangeYValues.Size = new System.Drawing.Size(170, 32);
			this.btnChangeYValues.TabIndex = 0;
			this.btnChangeYValues.Text = "Change Y Values";
			this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			// 
			// ShowMarkersCheck
			// 
			this.ShowMarkersCheck.ButtonProperties.BorderOffset = 2;
			this.ShowMarkersCheck.Location = new System.Drawing.Point(5, 48);
			this.ShowMarkersCheck.Name = "ShowMarkersCheck";
			this.ShowMarkersCheck.Size = new System.Drawing.Size(170, 24);
			this.ShowMarkersCheck.TabIndex = 1;
			this.ShowMarkersCheck.Text = "Show Markers";
			this.ShowMarkersCheck.CheckedChanged += new System.EventHandler(this.checkShowMarkers_CheckedChanged);
			// 
			// ShowDropLinesCheck
			// 
			this.ShowDropLinesCheck.ButtonProperties.BorderOffset = 2;
			this.ShowDropLinesCheck.Location = new System.Drawing.Point(5, 72);
			this.ShowDropLinesCheck.Name = "ShowDropLinesCheck";
			this.ShowDropLinesCheck.Size = new System.Drawing.Size(170, 24);
			this.ShowDropLinesCheck.TabIndex = 2;
			this.ShowDropLinesCheck.Text = "Show Drop Lines";
			this.ShowDropLinesCheck.CheckedChanged += new System.EventHandler(this.ShowDropLinesCheck_CheckedChanged);
			// 
			// OriginValueTextBox
			// 
			this.OriginValueTextBox.Location = new System.Drawing.Point(6, 180);
			this.OriginValueTextBox.Name = "OriginValueTextBox";
			this.OriginValueTextBox.Size = new System.Drawing.Size(170, 18);
			this.OriginValueTextBox.TabIndex = 6;
			this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 159);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Origin Value:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AreaOriginModeCombo
			// 
			this.AreaOriginModeCombo.ListProperties.CheckBoxDataMember = "";
			this.AreaOriginModeCombo.ListProperties.DataSource = null;
			this.AreaOriginModeCombo.ListProperties.DisplayMember = "";
			this.AreaOriginModeCombo.Location = new System.Drawing.Point(6, 128);
			this.AreaOriginModeCombo.Name = "AreaOriginModeCombo";
			this.AreaOriginModeCombo.Size = new System.Drawing.Size(170, 21);
			this.AreaOriginModeCombo.TabIndex = 4;
			this.AreaOriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.AreaOriginModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(162, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Area Origin Mode:";
			// 
			// NSmoothArea3DUC
			// 
			this.Controls.Add(this.AreaOriginModeCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.OriginValueTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ShowDropLinesCheck);
			this.Controls.Add(this.ShowMarkersCheck);
			this.Controls.Add(this.btnChangeYValues);
			this.Name = "NSmoothArea3DUC";
			this.Size = new System.Drawing.Size(180, 212);
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Smooth Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legends
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add the area series
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series.Add(SeriesType.SmoothArea);
			area.DataLabelStyle.Visible = false;
			area.MarkerStyle.Visible = false;
			area.MarkerStyle.PointShape = PointShape.Cylinder;
			area.MarkerStyle.AutoDepth = true;
			area.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);

			GenerateYValues(nValuesCount);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form conrols
			ShowMarkersCheck.Checked = false;
			ShowDropLinesCheck.Checked = false;
			AreaOriginModeCombo.FillFromEnum(typeof(SeriesOriginMode));
			AreaOriginModeCombo.SelectedIndex = 0;
			OriginValueTextBox.Text = "0";
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

