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
	public class NXYZScatterPointUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPointSeries m_Point;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox AxesRoundToTick;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValuesButton;
		private Nevron.UI.WinForm.Controls.NButton ChangeZValues;
		private System.ComponentModel.Container components = null;

		public NXYZScatterPointUC()
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
			this.AxesRoundToTick = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ChangeXValuesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeZValues = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(5, 100);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(170, 21);
			this.InflateMarginsCheck.TabIndex = 3;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// AxesRoundToTick
			// 
			this.AxesRoundToTick.ButtonProperties.BorderOffset = 2;
			this.AxesRoundToTick.Location = new System.Drawing.Point(5, 73);
			this.AxesRoundToTick.Name = "AxesRoundToTick";
			this.AxesRoundToTick.Size = new System.Drawing.Size(170, 20);
			this.AxesRoundToTick.TabIndex = 2;
			this.AxesRoundToTick.Text = "Axes Round To Tick";
			this.AxesRoundToTick.CheckedChanged += new System.EventHandler(this.AxesRoundToTick_CheckedChanged);
			// 
			// ChangeXValuesButton
			// 
			this.ChangeXValuesButton.Location = new System.Drawing.Point(5, 9);
			this.ChangeXValuesButton.Name = "ChangeXValuesButton";
			this.ChangeXValuesButton.Size = new System.Drawing.Size(170, 24);
			this.ChangeXValuesButton.TabIndex = 0;
			this.ChangeXValuesButton.Text = "Change X Values";
			this.ChangeXValuesButton.Click += new System.EventHandler(this.ChangeXValuesButton_Click);
			// 
			// ChangeZValues
			// 
			this.ChangeZValues.Location = new System.Drawing.Point(5, 39);
			this.ChangeZValues.Name = "ChangeZValues";
			this.ChangeZValues.Size = new System.Drawing.Size(170, 23);
			this.ChangeZValues.TabIndex = 1;
			this.ChangeZValues.Text = "Change Z Values";
			this.ChangeZValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			// 
			// NXYZScatterPointUC
			// 
			this.Controls.Add(this.ChangeZValues);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.AxesRoundToTick);
			this.Controls.Add(this.ChangeXValuesButton);
			this.Name = "NXYZScatterPointUC";
			this.Size = new System.Drawing.Size(180, 148);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;

			// Configure all axes to use linear scale
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// setup point series
			m_Point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point.Name = "Point Series";
			m_Point.DataLabelStyle.Visible = false;
			m_Point.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Point.Legend.Format = "<label>";
			m_Point.PointShape = PointShape.Sphere;
			m_Point.BorderStyle.Width = new NLength(0);
			m_Point.UseXValues = true;
			m_Point.UseZValues = true;

			// add xyz values
			m_Point.AddDataPoint(new NDataPoint(10, 15, 34, "Item1"));
			m_Point.AddDataPoint(new NDataPoint(23, 25, -20, "Item2"));
			m_Point.AddDataPoint(new NDataPoint(12, 45, 45, "Item3"));
			m_Point.AddDataPoint(new NDataPoint(24, 35, -12, "Item4"));
			m_Point.AddDataPoint(new NDataPoint(16, 41, 3, "Item5"));
			m_Point.AddDataPoint(new NDataPoint(17, 15, -34, "Item6"));
			m_Point.AddDataPoint(new NDataPoint(13, -25, -20, "Item7"));
			m_Point.AddDataPoint(new NDataPoint(12, 45, 1, "Item8"));
			m_Point.AddDataPoint(new NDataPoint(4, -21, -12, "Item9"));
			m_Point.AddDataPoint(new NDataPoint(16, -24, 47, "Item10"));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			AxesRoundToTick.Checked = true;
			InflateMarginsCheck.Checked = true;
		}

		private void ChangeXValuesButton_Click(object sender, System.EventArgs e)
		{
			m_Point.XValues.FillRandomRange(Random, 10, -50, 50);
			nChartControl1.Refresh();
		}

		private void ChangeYValues_Click(object sender, System.EventArgs e)
		{
			m_Point.ZValues.FillRandomRange(Random, 10, -50, 50);
			nChartControl1.Refresh();
		}

		private void AxesRoundToTick_CheckedChanged(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			linearScale.RoundToTickMin = AxesRoundToTick.Checked;
			linearScale.RoundToTickMax = AxesRoundToTick.Checked;

			linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			linearScale.RoundToTickMin = AxesRoundToTick.Checked;
			linearScale.RoundToTickMax = AxesRoundToTick.Checked;

			linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;

			linearScale.RoundToTickMin = AxesRoundToTick.Checked;
			linearScale.RoundToTickMax = AxesRoundToTick.Checked;

			nChartControl1.Refresh();		
		}

		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Point.InflateMargins = InflateMarginsCheck.Checked;
			nChartControl1.Refresh();
		}
	}
}