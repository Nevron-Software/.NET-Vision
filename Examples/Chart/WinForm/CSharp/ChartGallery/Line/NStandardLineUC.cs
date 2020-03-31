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
	public class NStandardLineUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox LineStyleCombo;
		private Nevron.UI.WinForm.Controls.NHScrollBar LineDepthScroll;
		private Nevron.UI.WinForm.Controls.NButton LineFillColorButton;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton BorderStyleButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar LineSizeScroll;
		private System.ComponentModel.Container components = null;

		public NStandardLineUC()
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
			this.LineDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.BorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LineFillColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.LineSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.SuspendLayout();
			// 
			// LineStyleCombo
			// 
			this.LineStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.LineStyleCombo.ListProperties.DataSource = null;
			this.LineStyleCombo.ListProperties.DisplayMember = "";
			this.LineStyleCombo.Location = new System.Drawing.Point(6, 24);
			this.LineStyleCombo.Name = "LineStyleCombo";
			this.LineStyleCombo.Size = new System.Drawing.Size(168, 21);
			this.LineStyleCombo.TabIndex = 1;
			this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Line Style:";
			// 
			// LineDepthScroll
			// 
			this.LineDepthScroll.Location = new System.Drawing.Point(6, 74);
			this.LineDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LineDepthScroll.Name = "LineDepthScroll";
			this.LineDepthScroll.Size = new System.Drawing.Size(168, 16);
			this.LineDepthScroll.TabIndex = 3;
			this.LineDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineDepthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Line Depth Percent:";
			// 
			// BorderStyleButton
			// 
			this.BorderStyleButton.Location = new System.Drawing.Point(6, 149);
			this.BorderStyleButton.Name = "BorderStyleButton";
			this.BorderStyleButton.Size = new System.Drawing.Size(168, 24);
			this.BorderStyleButton.TabIndex = 6;
			this.BorderStyleButton.Text = "Border Style ...";
			this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			// 
			// LineFillColorButton
			// 
			this.LineFillColorButton.Location = new System.Drawing.Point(6, 180);
			this.LineFillColorButton.Name = "LineFillColorButton";
			this.LineFillColorButton.Size = new System.Drawing.Size(168, 24);
			this.LineFillColorButton.TabIndex = 7;
			this.LineFillColorButton.Text = "Line Fill Style...";
			this.LineFillColorButton.Click += new System.EventHandler(this.LineFillColorButton_Click);
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(6, 247);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(168, 20);
			this.InflateMarginsCheck.TabIndex = 9;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(6, 274);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(168, 19);
			this.RoundToTickCheck.TabIndex = 10;
			this.RoundToTickCheck.Text = "Left Axis Round to Tick";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(6, 211);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(168, 24);
			this.MarkerStyleButton.TabIndex = 8;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Line Size:";
			// 
			// LineSizeScroll
			// 
			this.LineSizeScroll.Location = new System.Drawing.Point(6, 115);
			this.LineSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LineSizeScroll.Name = "LineSizeScroll";
			this.LineSizeScroll.Size = new System.Drawing.Size(168, 16);
			this.LineSizeScroll.TabIndex = 5;
			this.LineSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineSizeScroll_ValueChanged);
			// 
			// NStandardLineUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LineSizeScroll);
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.LineFillColorButton);
			this.Controls.Add(this.BorderStyleButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LineDepthScroll);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LineStyleCombo);
			this.Name = "NStandardLineUC";
			this.Size = new System.Drawing.Size(180, 322);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective2);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// add a line series
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.Name = "Line Series";
			line.InflateMargins = true;
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
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

			switch (LineStyleCombo.SelectedIndex)
			{
				case 0: // simple line
					line.LineSegmentShape = LineSegmentShape.Line; 
					LineDepthScroll.Enabled = false;
					LineSizeScroll.Enabled = false;
					LineFillColorButton.Enabled = false;
					break;

				case 1: // tape
					line.LineSegmentShape = LineSegmentShape.Tape;
					LineDepthScroll.Enabled = true;
					LineSizeScroll.Enabled = false;
					LineFillColorButton.Enabled = true;
					break;

				case 2: // tube
					line.LineSegmentShape = LineSegmentShape.Tube;
					LineDepthScroll.Enabled = false;
					LineSizeScroll.Enabled = true;
					LineFillColorButton.Enabled = true;
					break;

				case 3: // ellipsoid
					line.LineSegmentShape = LineSegmentShape.Ellipsoid;
					LineDepthScroll.Enabled = false;
					LineSizeScroll.Enabled = true;
					LineFillColorButton.Enabled = true;
					break;
			}

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
		private void LineDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NLineSeries line = (NLineSeries)nChartControl1.Charts[0].Series[0];
			line.DepthPercent = LineDepthScroll.Value;
			nChartControl1.Refresh();
		}
		private void LineSizeScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NLineSeries line = (NLineSeries)nChartControl1.Charts[0].Series[0];
			line.LineSize = new NLength(LineSizeScroll.Value / 40.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
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
