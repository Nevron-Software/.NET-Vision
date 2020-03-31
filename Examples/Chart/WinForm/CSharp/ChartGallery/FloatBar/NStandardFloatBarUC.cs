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
	public class NStandardFloatBarUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox BarShapeCombo;
		private Nevron.UI.WinForm.Controls.NHScrollBar DepthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroll;
		private Nevron.UI.WinForm.Controls.NButton BarFEButton;
		private Nevron.UI.WinForm.Controls.NButton BarBorderButton;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDataLabelsCheck;
		private System.ComponentModel.Container components = null;

		public NStandardFloatBarUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.BarShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.BarFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.DepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.WidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.BarBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowDataLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(159, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bar Shape:";
			// 
			// BarShapeCombo
			// 
			this.BarShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.BarShapeCombo.ListProperties.DataSource = null;
			this.BarShapeCombo.ListProperties.DisplayMember = "";
			this.BarShapeCombo.Location = new System.Drawing.Point(10, 27);
			this.BarShapeCombo.Name = "BarShapeCombo";
			this.BarShapeCombo.Size = new System.Drawing.Size(159, 21);
			this.BarShapeCombo.TabIndex = 2;
			this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarStyleCombo_SelectedIndexChanged);
			// 
			// BarFEButton
			// 
			this.BarFEButton.Location = new System.Drawing.Point(10, 162);
			this.BarFEButton.Name = "BarFEButton";
			this.BarFEButton.Size = new System.Drawing.Size(159, 24);
			this.BarFEButton.TabIndex = 4;
			this.BarFEButton.Text = "Bar Fill Style...";
			this.BarFEButton.Click += new System.EventHandler(this.BarFEButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 108);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(159, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Depth %:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(159, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Width %:";
			// 
			// DepthScroll
			// 
			this.DepthScroll.Location = new System.Drawing.Point(10, 126);
			this.DepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.DepthScroll.Name = "DepthScroll";
			this.DepthScroll.Size = new System.Drawing.Size(159, 16);
			this.DepthScroll.TabIndex = 8;
			this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			// 
			// WidthScroll
			// 
			this.WidthScroll.Location = new System.Drawing.Point(10, 80);
			this.WidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.WidthScroll.Name = "WidthScroll";
			this.WidthScroll.Size = new System.Drawing.Size(159, 16);
			this.WidthScroll.TabIndex = 7;
			this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			// 
			// BarBorderButton
			// 
			this.BarBorderButton.Location = new System.Drawing.Point(10, 193);
			this.BarBorderButton.Name = "BarBorderButton";
			this.BarBorderButton.Size = new System.Drawing.Size(159, 24);
			this.BarBorderButton.TabIndex = 18;
			this.BarBorderButton.Text = "Bar Border...";
			this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			// 
			// ShowDataLabelsCheck
			// 
			this.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.ShowDataLabelsCheck.Location = new System.Drawing.Point(10, 235);
			this.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck";
			this.ShowDataLabelsCheck.Size = new System.Drawing.Size(159, 21);
			this.ShowDataLabelsCheck.TabIndex = 27;
			this.ShowDataLabelsCheck.Text = "Show Data Labels";
			this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			// 
			// NStandardFloatBarUC
			// 
			this.Controls.Add(this.ShowDataLabelsCheck);
			this.Controls.Add(this.BarBorderButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DepthScroll);
			this.Controls.Add(this.WidthScroll);
			this.Controls.Add(this.BarFEButton);
			this.Controls.Add(this.BarShapeCombo);
			this.Controls.Add(this.label1);
			this.Name = "NStandardFloatBarUC";
			this.Size = new System.Drawing.Size(180, 304);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Floating Bars");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

            // add interlaced stripe to the Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			// create the float bar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.DataLabelStyle.Visible = false;
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center;
			floatBar.DataLabelStyle.Format = "<begin> - <end>";

			// add bars
			floatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
			floatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
			floatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
			floatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
			floatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
			floatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			BarShapeCombo.FillFromEnum(typeof(BarShape));
			BarShapeCombo.SelectedIndex = 0;
		}

		private void BarFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(series.FillStyle, out fillStyleResult))
			{
				series.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BarBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(series.BorderStyle, out strokeStyleResult))
			{
				series.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BarStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.BarShape = (BarShape)BarShapeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void WidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.WidthPercent = WidthScroll.Value;
			nChartControl1.Refresh();
		}
		private void DepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.DepthPercent = DepthScroll.Value;
			nChartControl1.Refresh();
		}
		private void ShowDataLabelsCheck_CheckedChanged(object sender, EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			nChartControl1.Refresh();
		}
	}
}
