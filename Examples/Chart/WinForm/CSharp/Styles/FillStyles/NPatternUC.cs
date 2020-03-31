using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPatternUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NFloatBarSeries m_Bar;
		private bool m_bSkipUpdate;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton EndColorBars;
		private Nevron.UI.WinForm.Controls.NButton BeginColorBars;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NComboBox HatchComboBars;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NButton EndColorWalls;
		private Nevron.UI.WinForm.Controls.NButton BeginColorWalls;
		private Nevron.UI.WinForm.Controls.NComboBox HatchComboWalls;
		private Nevron.UI.WinForm.Controls.NButton EndColorBack;
		private Nevron.UI.WinForm.Controls.NButton BeginColorBack;
		private Nevron.UI.WinForm.Controls.NComboBox HatchComboBack;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog1;
		private System.ComponentModel.IContainer components = null;

		public NPatternUC()
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
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.EndColorBars = new Nevron.UI.WinForm.Controls.NButton();
			this.BeginColorBars = new Nevron.UI.WinForm.Controls.NButton();
			this.HatchComboBars = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.EndColorWalls = new Nevron.UI.WinForm.Controls.NButton();
			this.BeginColorWalls = new Nevron.UI.WinForm.Controls.NButton();
			this.HatchComboWalls = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.EndColorBack = new Nevron.UI.WinForm.Controls.NButton();
			this.BeginColorBack = new Nevron.UI.WinForm.Controls.NButton();
			this.HatchComboBack = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.colorDialog1 = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.EndColorBars);
			this.groupBox1.Controls.Add(this.BeginColorBars);
			this.groupBox1.Controls.Add(this.HatchComboBars);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(189, 132);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bars";
			// 
			// EndColorBars
			// 
			this.EndColorBars.Location = new System.Drawing.Point(9, 98);
			this.EndColorBars.Name = "EndColorBars";
			this.EndColorBars.Size = new System.Drawing.Size(171, 24);
			this.EndColorBars.TabIndex = 5;
			this.EndColorBars.Text = "End Color...";
			this.EndColorBars.Click += new System.EventHandler(this.EndColorBars_Click);
			// 
			// BeginColorBars
			// 
			this.BeginColorBars.Location = new System.Drawing.Point(9, 68);
			this.BeginColorBars.Name = "BeginColorBars";
			this.BeginColorBars.Size = new System.Drawing.Size(171, 24);
			this.BeginColorBars.TabIndex = 4;
			this.BeginColorBars.Text = "Begin Color...";
			this.BeginColorBars.Click += new System.EventHandler(this.BeginColorBars_Click);
			// 
			// HatchComboBars
			// 
			this.HatchComboBars.DropDownWidth = 121;
			this.HatchComboBars.Location = new System.Drawing.Point(9, 36);
			this.HatchComboBars.Name = "HatchComboBars";
			this.HatchComboBars.Size = new System.Drawing.Size(171, 21);
			this.HatchComboBars.TabIndex = 1;
			this.HatchComboBars.SelectedIndexChanged += new System.EventHandler(this.HatchComboBars_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Pattern Style:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.EndColorWalls);
			this.groupBox2.Controls.Add(this.BeginColorWalls);
			this.groupBox2.Controls.Add(this.HatchComboWalls);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(7, 150);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(189, 132);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Walls";
			// 
			// EndColorWalls
			// 
			this.EndColorWalls.Location = new System.Drawing.Point(9, 98);
			this.EndColorWalls.Name = "EndColorWalls";
			this.EndColorWalls.Size = new System.Drawing.Size(171, 24);
			this.EndColorWalls.TabIndex = 5;
			this.EndColorWalls.Text = "End Color...";
			this.EndColorWalls.Click += new System.EventHandler(this.EndColorWalls_Click);
			// 
			// BeginColorWalls
			// 
			this.BeginColorWalls.Location = new System.Drawing.Point(9, 68);
			this.BeginColorWalls.Name = "BeginColorWalls";
			this.BeginColorWalls.Size = new System.Drawing.Size(171, 24);
			this.BeginColorWalls.TabIndex = 4;
			this.BeginColorWalls.Text = "Begin Color...";
			this.BeginColorWalls.Click += new System.EventHandler(this.BeginColorWalls_Click);
			// 
			// HatchComboWalls
			// 
			this.HatchComboWalls.DropDownWidth = 121;
			this.HatchComboWalls.Location = new System.Drawing.Point(9, 36);
			this.HatchComboWalls.Name = "HatchComboWalls";
			this.HatchComboWalls.Size = new System.Drawing.Size(171, 21);
			this.HatchComboWalls.TabIndex = 1;
			this.HatchComboWalls.SelectedIndexChanged += new System.EventHandler(this.HatchComboWalls_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Pattern Style:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.EndColorBack);
			this.groupBox3.Controls.Add(this.BeginColorBack);
			this.groupBox3.Controls.Add(this.HatchComboBack);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(7, 296);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(189, 132);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Background";
			// 
			// EndColorBack
			// 
			this.EndColorBack.Location = new System.Drawing.Point(9, 98);
			this.EndColorBack.Name = "EndColorBack";
			this.EndColorBack.Size = new System.Drawing.Size(171, 24);
			this.EndColorBack.TabIndex = 5;
			this.EndColorBack.Text = "End Color...";
			this.EndColorBack.Click += new System.EventHandler(this.EndColorBack_Click);
			// 
			// BeginColorBack
			// 
			this.BeginColorBack.Location = new System.Drawing.Point(9, 68);
			this.BeginColorBack.Name = "BeginColorBack";
			this.BeginColorBack.Size = new System.Drawing.Size(171, 24);
			this.BeginColorBack.TabIndex = 4;
			this.BeginColorBack.Text = "Begin Color...";
			this.BeginColorBack.Click += new System.EventHandler(this.BeginColorBack_Click);
			// 
			// HatchComboBack
			// 
			this.HatchComboBack.DropDownWidth = 121;
			this.HatchComboBack.Location = new System.Drawing.Point(9, 36);
			this.HatchComboBack.Name = "HatchComboBack";
			this.HatchComboBack.Size = new System.Drawing.Size(171, 21);
			this.HatchComboBack.TabIndex = 1;
			this.HatchComboBack.SelectedIndexChanged += new System.EventHandler(this.HatchComboBack_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Pattern Style:";
			// 
			// NPatternUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Name = "NPatternUC";
			this.Size = new System.Drawing.Size(203, 489);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Set background pattern
			nChartControl1.BackgroundStyle.FillStyle = new NHatchFillStyle(HatchStyle.ZigZag, Color.FromArgb(187,221,255), Color.White);

			// add label
			NLabel title = nChartControl1.Labels.AddHeader("Hatch Fill Style");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// hide y axis grid lines
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, false);
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);

			// hide x axis grid lines
			scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, false);
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);

			// set the projection to tilted
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			m_Chart.Projection.Rotation = -14;
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// Setup walls
			Color c = Color.FromArgb(128, 128, 192);
			NHatchFillStyle hatchFillstyle = new NHatchFillStyle(HatchStyle.Weave, Color.White, c);

			m_Chart.Wall(ChartWallType.Back).FillStyle = hatchFillstyle;
			m_Chart.Wall(ChartWallType.Left).FillStyle = hatchFillstyle;
			m_Chart.Wall(ChartWallType.Floor).FillStyle = hatchFillstyle;

			// Create a bar series
			m_Bar = (NFloatBarSeries)m_Chart.Series.Add(SeriesType.FloatBar);
			m_Bar.DataLabelStyle.Visible = false;
			m_Bar.BarShape = BarShape.Bar;
			m_Bar.BarEdgePercent = 50;
			m_Bar.WidthPercent = 60;
			m_Bar.DepthPercent = 60;
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bar.FillStyle = new NHatchFillStyle(HatchStyle.LargeConfetti, Color.Green, Color.Yellow);

			m_Bar.AddDataPoint(new NFloatBarDataPoint(2.0, 24.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(21.0, 60.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(22.0, 53.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(34.0, 80.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(11.0, 62.0));

			// init form controls
			string[] arrHatchNames = Enum.GetNames(typeof(HatchStyle));

			HatchComboBars.Items.AddRange(arrHatchNames);
			HatchComboWalls.Items.AddRange(arrHatchNames);
			HatchComboBack.Items.AddRange(arrHatchNames);

			m_bSkipUpdate = true;

			SetHatchStyleFromCombo(HatchComboBars, ((NHatchFillStyle)m_Bar.FillStyle).Style);
			SetHatchStyleFromCombo(HatchComboWalls, ((NHatchFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle).Style);
			SetHatchStyleFromCombo(HatchComboBack, ((NHatchFillStyle)nChartControl1.BackgroundStyle.FillStyle).Style);

			m_bSkipUpdate = false;
		}

		private HatchStyle GetHatchStyleFromCombo(NComboBox combo)
		{
			string sHatchName = (string)combo.SelectedItem;
			return (HatchStyle)Enum.Parse(typeof(HatchStyle), sHatchName);
		}

		private void SetHatchStyleFromCombo(NComboBox combo, HatchStyle style)
		{
			combo.SelectedItem = Enum.GetName(typeof(HatchStyle), style);
		}

		private void HatchComboBars_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			((NHatchFillStyle)m_Bar.FillStyle).Style = GetHatchStyleFromCombo(HatchComboBars);
			nChartControl1.Refresh();
		}

		private void BeginColorBars_Click(object sender, System.EventArgs e)
		{
			NHatchFillStyle hatchFillStyle = (NHatchFillStyle)m_Bar.FillStyle;
			colorDialog1.Color = hatchFillStyle.ForegroundColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				hatchFillStyle.ForegroundColor = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void EndColorBars_Click(object sender, System.EventArgs e)
		{
			NHatchFillStyle hatchFillStyle = (NHatchFillStyle)m_Bar.FillStyle;
			colorDialog1.Color = hatchFillStyle.BackgroundColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				hatchFillStyle.BackgroundColor = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void HatchComboWalls_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			HatchStyle style = GetHatchStyleFromCombo(HatchComboWalls);

			((NHatchFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle).Style = style;
			((NHatchFillStyle)m_Chart.Wall(ChartWallType.Left).FillStyle).Style = style;
			((NHatchFillStyle)m_Chart.Wall(ChartWallType.Floor).FillStyle).Style = style;

			nChartControl1.Refresh();
		}

		private void BeginColorWalls_Click(object sender, System.EventArgs e)
		{
			NHatchFillStyle hatchFillStyle = (NHatchFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle;
			colorDialog1.Color = hatchFillStyle.ForegroundColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				hatchFillStyle.ForegroundColor = colorDialog1.Color;

				m_Chart.Wall(ChartWallType.Back).FillStyle = hatchFillStyle;
				m_Chart.Wall(ChartWallType.Left).FillStyle = hatchFillStyle;
				m_Chart.Wall(ChartWallType.Floor).FillStyle = hatchFillStyle;

				nChartControl1.Refresh();
			}
		}

		private void EndColorWalls_Click(object sender, System.EventArgs e)
		{
			NHatchFillStyle hatchFillStyle = (NHatchFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle;
			colorDialog1.Color = hatchFillStyle.ForegroundColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				hatchFillStyle.ForegroundColor = colorDialog1.Color;

				m_Chart.Wall(ChartWallType.Back).FillStyle = hatchFillStyle;
				m_Chart.Wall(ChartWallType.Left).FillStyle = hatchFillStyle;
				m_Chart.Wall(ChartWallType.Floor).FillStyle = hatchFillStyle;

				nChartControl1.Refresh();
			}
		}

		private void HatchComboBack_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			NHatchFillStyle hatchFillStyle = (NHatchFillStyle)nChartControl1.BackgroundStyle.FillStyle;
			hatchFillStyle.Style = GetHatchStyleFromCombo(HatchComboBack);
			nChartControl1.Refresh();
		}

		private void BeginColorBack_Click(object sender, System.EventArgs e)
		{
			NHatchFillStyle hatchFillStyle = (NHatchFillStyle)nChartControl1.BackgroundStyle.FillStyle;
			colorDialog1.Color = hatchFillStyle.ForegroundColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				hatchFillStyle.ForegroundColor = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void EndColorBack_Click(object sender, System.EventArgs e)
		{
			NHatchFillStyle hatchFillStyle = (NHatchFillStyle)nChartControl1.BackgroundStyle.FillStyle;
			colorDialog1.Color = hatchFillStyle.ForegroundColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				hatchFillStyle.ForegroundColor = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}
	}
}