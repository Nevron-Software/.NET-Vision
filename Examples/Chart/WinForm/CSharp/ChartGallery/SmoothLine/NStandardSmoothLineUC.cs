using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStandardSmoothLineUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;
		private Nevron.UI.WinForm.Controls.NButton ChangeYValuesButton;
		private Nevron.UI.WinForm.Controls.NButton LineShadowButton;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton BorderStyleButton;
		private const int nValuesCount = 8;

		public NStandardSmoothLineUC()
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
			this.ChangeYValuesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LineShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// ChangeYValuesButton
			// 
			this.ChangeYValuesButton.Location = new System.Drawing.Point(6, 7);
			this.ChangeYValuesButton.Name = "ChangeYValuesButton";
			this.ChangeYValuesButton.Size = new System.Drawing.Size(169, 24);
			this.ChangeYValuesButton.TabIndex = 0;
			this.ChangeYValuesButton.Text = "Change Y Values";
			this.ChangeYValuesButton.Click += new System.EventHandler(this.btnChangeYValues_Click);
			// 
			// LineShadowButton
			// 
			this.LineShadowButton.Location = new System.Drawing.Point(6, 71);
			this.LineShadowButton.Name = "LineShadowButton";
			this.LineShadowButton.Size = new System.Drawing.Size(169, 24);
			this.LineShadowButton.TabIndex = 2;
			this.LineShadowButton.Text = "Line Shadow...";
			this.LineShadowButton.Click += new System.EventHandler(this.LineShadowButton_Click);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(6, 172);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(169, 24);
			this.RoundToTickCheck.TabIndex = 5;
			this.RoundToTickCheck.Text = "Left Axis Round to Tick";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(6, 144);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(169, 24);
			this.InflateMarginsCheck.TabIndex = 4;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// BorderStyleButton
			// 
			this.BorderStyleButton.Location = new System.Drawing.Point(6, 39);
			this.BorderStyleButton.Name = "BorderStyleButton";
			this.BorderStyleButton.Size = new System.Drawing.Size(169, 24);
			this.BorderStyleButton.TabIndex = 1;
			this.BorderStyleButton.Text = "Border Style ...";
			this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(6, 104);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(169, 24);
			this.MarkerStyleButton.TabIndex = 3;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// NStandardSmoothLineUC
			// 
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.LineShadowButton);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.BorderStyleButton);
			this.Controls.Add(this.ChangeYValuesButton);
			this.Name = "NStandardSmoothLineUC";
			this.Size = new System.Drawing.Size(180, 212);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Smooth Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

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
			line.Legend.Mode = SeriesLegendMode.Series;
			line.UseXValues = false;
			line.UseZValues = false;
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.AutoDepth = false;
			line.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Depth = new NLength(1.4f, NRelativeUnit.ParentPercentage);

			GenerateYValues(nValuesCount);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			InflateMarginsCheck.Checked = true;
			RoundToTickCheck.Checked = true;
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

		private void btnChangeYValues_Click(object sender, System.EventArgs e)
		{
			GenerateYValues(nValuesCount);
			nChartControl1.Refresh();
		}

		private void BorderPropsButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NChart chart = nChartControl1.Charts[0];
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series[0];

			if(NStrokeStyleTypeEditor.Edit(line.BorderStyle, out strokeStyleResult))
			{
				line.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LineShadowButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NShadowStyleTypeEditor.Edit(series.ShadowStyle, out shadowStyleResult))
			{
				series.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MarkerStyleButton_Click(object sender, System.EventArgs e)
		{
			NMarkerStyle markerStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NMarkerStyleTypeEditor.Edit(series.MarkerStyle, out markerStyleResult))
			{
				series.MarkerStyle = markerStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series[0];

			line.InflateMargins = InflateMarginsCheck.Checked;
			nChartControl1.Refresh();
		}

		private void RoundToTickCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.RoundToTickMin = RoundToTickCheck.Checked;
			standardScale.RoundToTickMax = RoundToTickCheck.Checked;

			nChartControl1.Refresh();
		}
	}
}
