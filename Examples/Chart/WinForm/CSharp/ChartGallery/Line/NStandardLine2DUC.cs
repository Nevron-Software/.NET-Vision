using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStandardLine2DUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox LineStyleCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NButton LineFillColorButton;
		private Nevron.UI.WinForm.Controls.NButton LineShadowButton;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton BorderStyleButton;
		private System.ComponentModel.Container components = null;

		public NStandardLine2DUC()
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
			this.LineStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LineFillColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LineShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// LineStyleCombo
			// 
			this.LineStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.LineStyleCombo.ListProperties.DataSource = null;
			this.LineStyleCombo.ListProperties.DisplayMember = "";
			this.LineStyleCombo.Location = new System.Drawing.Point(8, 22);
			this.LineStyleCombo.Name = "LineStyleCombo";
			this.LineStyleCombo.Size = new System.Drawing.Size(164, 21);
			this.LineStyleCombo.TabIndex = 1;
			this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Line Style:";
			// 
			// BorderStyleButton
			// 
			this.BorderStyleButton.Location = new System.Drawing.Point(8, 62);
			this.BorderStyleButton.Name = "BorderStyleButton";
			this.BorderStyleButton.Size = new System.Drawing.Size(164, 24);
			this.BorderStyleButton.TabIndex = 2;
			this.BorderStyleButton.Text = "Border Style ...";
			this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			// 
			// LineFillColorButton
			// 
			this.LineFillColorButton.Location = new System.Drawing.Point(8, 93);
			this.LineFillColorButton.Name = "LineFillColorButton";
			this.LineFillColorButton.Size = new System.Drawing.Size(164, 24);
			this.LineFillColorButton.TabIndex = 3;
			this.LineFillColorButton.Text = "Line Fill Style...";
			this.LineFillColorButton.Click += new System.EventHandler(this.LineFillColorButton_Click);
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(8, 194);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(164, 20);
			this.InflateMarginsCheck.TabIndex = 6;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(8, 222);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(164, 20);
			this.RoundToTickCheck.TabIndex = 7;
			this.RoundToTickCheck.Text = "Left Axis Round to Tick";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			// 
			// LineShadowButton
			// 
			this.LineShadowButton.Location = new System.Drawing.Point(8, 124);
			this.LineShadowButton.Name = "LineShadowButton";
			this.LineShadowButton.Size = new System.Drawing.Size(164, 24);
			this.LineShadowButton.TabIndex = 4;
			this.LineShadowButton.Text = "Line Shadow...";
			this.LineShadowButton.Click += new System.EventHandler(this.LineShadowButton_Click);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(8, 156);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(164, 24);
			this.MarkerStyleButton.TabIndex = 5;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// NStandardLine2DUC
			// 
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.LineShadowButton);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.LineFillColorButton);
			this.Controls.Add(this.BorderStyleButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LineStyleCombo);
			this.Name = "NStandardLine2DUC";
			this.Size = new System.Drawing.Size(180, 266);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.Name = "Line Series";
			line.InflateMargins = true;
			line.DataLabelStyle.Format = "<value>";
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line.ShadowStyle.Type = ShadowType.GaussianBlur;
			line.ShadowStyle.Offset = new NPointL(3, 3);
			line.ShadowStyle.FadeLength = new NLength(5);
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);
			line.Values.FillRandom(Random, 8);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LineStyleCombo.FillFromEnum(typeof(LineSegmentShape));
			LineStyleCombo.SelectedIndex = 0;
			RoundToTickCheck.Checked = true;
			InflateMarginsCheck.Checked = true;
		}

		private void LineStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NLineSeries line = (NLineSeries)nChartControl1.Charts[0].Series[0];
			bool bSimpleLine = (LineStyleCombo.SelectedIndex == 0);

			switch (LineStyleCombo.SelectedIndex)
			{
				case 0: // simple line
					line.LineSegmentShape = LineSegmentShape.Line;
					line.DepthPercent = 0;
					break;

				case 1: // tape
					line.LineSegmentShape = LineSegmentShape.Tape;
					line.DepthPercent = 50;
					break;

				case 2: // tube
					line.LineSegmentShape = LineSegmentShape.Tube;
					line.DepthPercent = 10;
					break;

				case 3: // ellipsoid
					line.LineSegmentShape = LineSegmentShape.Ellipsoid;
					line.DepthPercent = 10;
					break;
			}

			LineFillColorButton.Enabled = !bSimpleLine;

			nChartControl1.Refresh();
		}
		private void BorderPropsButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(series.BorderStyle, out strokeStyleResult))
			{
				series.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LineFillColorButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(series.FillStyle, out fillStyleResult))
			{
				series.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LineShadowButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NShadowStyleTypeEditor.Edit(series.ShadowStyle, out shadowStyleResult))
			{
				series.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.InflateMargins = InflateMarginsCheck.Checked;
			nChartControl1.Refresh();
		}
		private void RoundToTickCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NStandardScaleConfigurator scaleConfigurator = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;

			if (scaleConfigurator != null)
			{
				scaleConfigurator.RoundToTickMin = RoundToTickCheck.Checked;
				scaleConfigurator.RoundToTickMax = RoundToTickCheck.Checked;

				nChartControl1.Refresh();
			}
		}
		private void MarkerBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(series.MarkerStyle.BorderStyle, out strokeStyleResult))
			{
				series.MarkerStyle.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MarkerFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(series.MarkerStyle.FillStyle, out fillStyleResult))
			{
				series.MarkerStyle.FillStyle = fillStyleResult;
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
	}
}