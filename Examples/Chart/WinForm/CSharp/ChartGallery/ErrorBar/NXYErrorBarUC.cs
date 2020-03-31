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
	public class NXYErrorBarUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar YErrorSizeScroll;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowUpperErrorCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowLowerErrorCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowLowerErrorXCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowUpperErrorXCheck;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NHScrollBar XErrorSizeScroll;
		private Nevron.UI.WinForm.Controls.NButton BorderStyleButton;
		private System.ComponentModel.Container components = null;

		public NXYErrorBarUC()
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
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.YErrorSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowUpperErrorCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowLowerErrorCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowLowerErrorXCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowUpperErrorXCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.XErrorSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.SuspendLayout();
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(10, 327);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(154, 20);
			this.InflateMarginsCheck.TabIndex = 10;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(10, 354);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(154, 19);
			this.RoundToTickCheck.TabIndex = 11;
			this.RoundToTickCheck.Text = "Left Axis Round to Tick";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			// 
			// BorderStyleButton
			// 
			this.BorderStyleButton.Location = new System.Drawing.Point(10, 262);
			this.BorderStyleButton.Name = "BorderStyleButton";
			this.BorderStyleButton.Size = new System.Drawing.Size(154, 24);
			this.BorderStyleButton.TabIndex = 8;
			this.BorderStyleButton.Text = "Border Style ...";
			this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(10, 294);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(154, 24);
			this.MarkerStyleButton.TabIndex = 9;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// YErrorSizeScroll
			// 
			this.YErrorSizeScroll.Location = new System.Drawing.Point(10, 24);
			this.YErrorSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.YErrorSizeScroll.Name = "YErrorSizeScroll";
			this.YErrorSizeScroll.Size = new System.Drawing.Size(154, 16);
			this.YErrorSizeScroll.TabIndex = 1;
			this.YErrorSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.YErrorSizeScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(154, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Y Error Whiskers Size:";
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(10, 397);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(154, 24);
			this.GenerateDataButton.TabIndex = 12;
			this.GenerateDataButton.Text = "Generate Data ...";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// ShowUpperErrorCheck
			// 
			this.ShowUpperErrorCheck.ButtonProperties.BorderOffset = 2;
			this.ShowUpperErrorCheck.Location = new System.Drawing.Point(10, 45);
			this.ShowUpperErrorCheck.Name = "ShowUpperErrorCheck";
			this.ShowUpperErrorCheck.Size = new System.Drawing.Size(147, 24);
			this.ShowUpperErrorCheck.TabIndex = 2;
			this.ShowUpperErrorCheck.Text = "Show Upper Y Error";
			this.ShowUpperErrorCheck.CheckedChanged += new System.EventHandler(this.ShowUpperErrorCheck_CheckedChanged);
			// 
			// ShowLowerErrorCheck
			// 
			this.ShowLowerErrorCheck.ButtonProperties.BorderOffset = 2;
			this.ShowLowerErrorCheck.Location = new System.Drawing.Point(10, 70);
			this.ShowLowerErrorCheck.Name = "ShowLowerErrorCheck";
			this.ShowLowerErrorCheck.Size = new System.Drawing.Size(148, 24);
			this.ShowLowerErrorCheck.TabIndex = 3;
			this.ShowLowerErrorCheck.Text = "Show Lower Y Error";
			this.ShowLowerErrorCheck.CheckedChanged += new System.EventHandler(this.ShowLowerErrorCheck_CheckedChanged);
			// 
			// ShowLowerErrorXCheck
			// 
			this.ShowLowerErrorXCheck.ButtonProperties.BorderOffset = 2;
			this.ShowLowerErrorXCheck.Location = new System.Drawing.Point(11, 185);
			this.ShowLowerErrorXCheck.Name = "ShowLowerErrorXCheck";
			this.ShowLowerErrorXCheck.Size = new System.Drawing.Size(148, 24);
			this.ShowLowerErrorXCheck.TabIndex = 7;
			this.ShowLowerErrorXCheck.Text = "Show Lower X Error";
			this.ShowLowerErrorXCheck.CheckedChanged += new System.EventHandler(this.ShowLowerErrorXCheck_CheckedChanged);
			// 
			// ShowUpperErrorXCheck
			// 
			this.ShowUpperErrorXCheck.ButtonProperties.BorderOffset = 2;
			this.ShowUpperErrorXCheck.Location = new System.Drawing.Point(11, 160);
			this.ShowUpperErrorXCheck.Name = "ShowUpperErrorXCheck";
			this.ShowUpperErrorXCheck.Size = new System.Drawing.Size(147, 24);
			this.ShowUpperErrorXCheck.TabIndex = 6;
			this.ShowUpperErrorXCheck.Text = "Show Upper X Error";
			this.ShowUpperErrorXCheck.CheckedChanged += new System.EventHandler(this.ShowUpperErrorXCheck_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 123);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "X Error Whiskers Size:";
			// 
			// XErrorSizeScroll
			// 
			this.XErrorSizeScroll.Location = new System.Drawing.Point(11, 139);
			this.XErrorSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.XErrorSizeScroll.Name = "XErrorSizeScroll";
			this.XErrorSizeScroll.Size = new System.Drawing.Size(154, 16);
			this.XErrorSizeScroll.TabIndex = 5;
			this.XErrorSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.XErrorSizeScroll_ValueChanged);
			// 
			// NXYErrorBarUC
			// 
			this.Controls.Add(this.ShowLowerErrorXCheck);
			this.Controls.Add(this.ShowUpperErrorXCheck);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.XErrorSizeScroll);
			this.Controls.Add(this.ShowLowerErrorCheck);
			this.Controls.Add(this.ShowUpperErrorCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.BorderStyleButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.YErrorSizeScroll);
			this.Name = "NXYErrorBarUC";
			this.Size = new System.Drawing.Size(180, 443);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Error Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove the legend
			nChartControl1.Legends.Clear();

			m_Chart = nChartControl1.Charts[0];

			// setup axes
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor };
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add an error bar series
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series.Add(SeriesType.ErrorBar);
			series.DataLabelStyle.Visible = false;
			series.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Visible = true;
			series.MarkerStyle.PointShape = PointShape.Ellipse;
			series.MarkerStyle.AutoDepth = false;
			series.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			series.MarkerStyle.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Depth =  new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.UseXValues = true;

			GenerateData(series);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// form controls
			YErrorSizeScroll.Value = 20;
			ShowLowerErrorCheck.Checked = true;
			ShowUpperErrorCheck.Checked = true;

			XErrorSizeScroll.Value = 20;
			ShowLowerErrorXCheck.Checked = true;
			ShowUpperErrorXCheck.Checked = true;

			RoundToTickCheck.Checked = true;
			InflateMarginsCheck.Checked = true;
		}

		void GenerateData(NErrorBarSeries series)
		{
			series.ClearDataPoints();

			double y;
			double x = 50.0;

			for(int i = 0; i < 15; i++)
			{
				y = 20 + Random.NextDouble() * 30;
				x += 2.0 + Random.NextDouble() * 2;

				series.Values.Add(y);
				series.LowerErrorsY.Add(1 + Random.NextDouble());
				series.UpperErrorsY.Add(1 + Random.NextDouble());

				series.XValues.Add(x);
				series.LowerErrorsX.Add(1 + Random.NextDouble());
				series.UpperErrorsX.Add(1 + Random.NextDouble());
			}
		}

		private void YErrorSizeScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];

			series.SizeY = new NLength(YErrorSizeScroll.Value / 20.0f, NRelativeUnit.ParentPercentage);

			nChartControl1.Refresh();
		}
		private void ShowUpperErrorCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowUpperErrorY = ShowUpperErrorCheck.Checked;
			nChartControl1.Refresh();
		}
		private void ShowLowerErrorCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowLowerErrorY = ShowLowerErrorCheck.Checked;
			nChartControl1.Refresh();
		}
		private void XErrorSizeScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];

			series.SizeX = new NLength(XErrorSizeScroll.Value / 20.0f, NRelativeUnit.ParentPercentage);

			nChartControl1.Refresh();
		}
		private void ShowUpperErrorXCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowUpperErrorX = ShowUpperErrorXCheck.Checked;
			nChartControl1.Refresh();		
		}
		private void ShowLowerErrorXCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowLowerErrorX = ShowLowerErrorXCheck.Checked;
			nChartControl1.Refresh();
		}
		private void BorderPropsButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NSeries series = (NSeries)m_Chart.Series[0];

			if (NStrokeStyleTypeEditor.Edit(series.BorderStyle, out strokeStyleResult))
			{
				series.BorderStyle = strokeStyleResult;
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
		private void DataLabelStyleButton_Click(object sender, System.EventArgs e)
		{
			NDataLabelStyle dataLabelStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, out dataLabelStyleResult))
			{
				series.DataLabelStyle = dataLabelStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)m_Chart.Series[0];
			series.InflateMargins = InflateMarginsCheck.Checked;
			nChartControl1.Refresh();
		}
		private void RoundToTickCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			linearScale.RoundToTickMin = RoundToTickCheck.Checked;
			linearScale.RoundToTickMax = RoundToTickCheck.Checked;

			nChartControl1.Refresh();
		}
		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			GenerateData(series);
			nChartControl1.Refresh();
		}
	}
}
