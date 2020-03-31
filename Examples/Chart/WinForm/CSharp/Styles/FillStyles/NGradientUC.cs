using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGradientUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NFloatBarSeries m_Bar;
		private bool m_bSkipUpdate;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog1;
		private Nevron.UI.WinForm.Controls.NButton BeginColorBars;
		private Nevron.UI.WinForm.Controls.NButton EndColorBars;
		private Nevron.UI.WinForm.Controls.NButton EndColorWalls;
		private Nevron.UI.WinForm.Controls.NButton BeginColorWalls;
		private Nevron.UI.WinForm.Controls.NButton EndColorBack;
		private Nevron.UI.WinForm.Controls.NButton BeginColorBack;
		private Nevron.UI.WinForm.Controls.NComboBox StyleComboBars;
		private Nevron.UI.WinForm.Controls.NComboBox VariantComboBars;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private Nevron.UI.WinForm.Controls.NComboBox VariantComboWalls;
		private Nevron.UI.WinForm.Controls.NComboBox StyleComboWalls;
		private Nevron.UI.WinForm.Controls.NComboBox VariantComboBack;
		private Nevron.UI.WinForm.Controls.NComboBox StyleComboBack;
		private System.ComponentModel.IContainer components = null;

		public NGradientUC()
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
			this.VariantComboBars = new Nevron.UI.WinForm.Controls.NComboBox();
			this.StyleComboBars = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.colorDialog1 = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.EndColorWalls = new Nevron.UI.WinForm.Controls.NButton();
			this.BeginColorWalls = new Nevron.UI.WinForm.Controls.NButton();
			this.VariantComboWalls = new Nevron.UI.WinForm.Controls.NComboBox();
			this.StyleComboWalls = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.EndColorBack = new Nevron.UI.WinForm.Controls.NButton();
			this.BeginColorBack = new Nevron.UI.WinForm.Controls.NButton();
			this.VariantComboBack = new Nevron.UI.WinForm.Controls.NComboBox();
			this.StyleComboBack = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.EndColorBars);
			this.groupBox1.Controls.Add(this.BeginColorBars);
			this.groupBox1.Controls.Add(this.VariantComboBars);
			this.groupBox1.Controls.Add(this.StyleComboBars);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(140, 177);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bars";
			// 
			// EndColorBars
			// 
			this.EndColorBars.Location = new System.Drawing.Point(9, 144);
			this.EndColorBars.Name = "EndColorBars";
			this.EndColorBars.Size = new System.Drawing.Size(121, 24);
			this.EndColorBars.TabIndex = 5;
			this.EndColorBars.Text = "End Color...";
			this.EndColorBars.Click += new System.EventHandler(this.EndColorBars_Click);
			// 
			// BeginColorBars
			// 
			this.BeginColorBars.Location = new System.Drawing.Point(9, 114);
			this.BeginColorBars.Name = "BeginColorBars";
			this.BeginColorBars.Size = new System.Drawing.Size(121, 24);
			this.BeginColorBars.TabIndex = 4;
			this.BeginColorBars.Text = "Begin Color...";
			this.BeginColorBars.Click += new System.EventHandler(this.BeginColorBars_Click);
			// 
			// VariantComboBars
			// 
			this.VariantComboBars.Location = new System.Drawing.Point(9, 82);
			this.VariantComboBars.Name = "VariantComboBars";
			this.VariantComboBars.Size = new System.Drawing.Size(121, 21);
			this.VariantComboBars.TabIndex = 3;
			this.VariantComboBars.SelectedIndexChanged += new System.EventHandler(this.VariantComboBars_SelectedIndexChanged);
			// 
			// StyleComboBars
			// 
			this.StyleComboBars.Location = new System.Drawing.Point(9, 36);
			this.StyleComboBars.Name = "StyleComboBars";
			this.StyleComboBars.Size = new System.Drawing.Size(121, 21);
			this.StyleComboBars.TabIndex = 1;
			this.StyleComboBars.SelectedIndexChanged += new System.EventHandler(this.StyleComboBars_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Gradient Style:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "Gradient Variant:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.EndColorWalls);
			this.groupBox2.Controls.Add(this.BeginColorWalls);
			this.groupBox2.Controls.Add(this.VariantComboWalls);
			this.groupBox2.Controls.Add(this.StyleComboWalls);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(7, 190);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(140, 177);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Walls";
			// 
			// EndColorWalls
			// 
			this.EndColorWalls.Location = new System.Drawing.Point(9, 144);
			this.EndColorWalls.Name = "EndColorWalls";
			this.EndColorWalls.Size = new System.Drawing.Size(121, 24);
			this.EndColorWalls.TabIndex = 5;
			this.EndColorWalls.Text = "End Color...";
			this.EndColorWalls.Click += new System.EventHandler(this.EndColorWalls_Click);
			// 
			// BeginColorWalls
			// 
			this.BeginColorWalls.Location = new System.Drawing.Point(9, 114);
			this.BeginColorWalls.Name = "BeginColorWalls";
			this.BeginColorWalls.Size = new System.Drawing.Size(121, 24);
			this.BeginColorWalls.TabIndex = 4;
			this.BeginColorWalls.Text = "Begin Color...";
			this.BeginColorWalls.Click += new System.EventHandler(this.BeginColorWalls_Click);
			// 
			// VariantComboWalls
			// 
			this.VariantComboWalls.Location = new System.Drawing.Point(9, 82);
			this.VariantComboWalls.Name = "VariantComboWalls";
			this.VariantComboWalls.Size = new System.Drawing.Size(121, 21);
			this.VariantComboWalls.TabIndex = 3;
			this.VariantComboWalls.SelectedIndexChanged += new System.EventHandler(this.VariantComboWalls_SelectedIndexChanged);
			// 
			// StyleComboWalls
			// 
			this.StyleComboWalls.Location = new System.Drawing.Point(9, 36);
			this.StyleComboWalls.Name = "StyleComboWalls";
			this.StyleComboWalls.Size = new System.Drawing.Size(121, 21);
			this.StyleComboWalls.TabIndex = 1;
			this.StyleComboWalls.SelectedIndexChanged += new System.EventHandler(this.StyleComboWalls_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 21);
			this.label3.TabIndex = 0;
			this.label3.Text = "Gradient Style:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 21);
			this.label4.TabIndex = 2;
			this.label4.Text = "Gradient Variant:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.EndColorBack);
			this.groupBox3.Controls.Add(this.BeginColorBack);
			this.groupBox3.Controls.Add(this.VariantComboBack);
			this.groupBox3.Controls.Add(this.StyleComboBack);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Location = new System.Drawing.Point(7, 375);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(140, 177);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Background";
			// 
			// EndColorBack
			// 
			this.EndColorBack.Location = new System.Drawing.Point(9, 144);
			this.EndColorBack.Name = "EndColorBack";
			this.EndColorBack.Size = new System.Drawing.Size(121, 24);
			this.EndColorBack.TabIndex = 5;
			this.EndColorBack.Text = "End Color...";
			this.EndColorBack.Click += new System.EventHandler(this.EndColorBack_Click);
			// 
			// BeginColorBack
			// 
			this.BeginColorBack.Location = new System.Drawing.Point(9, 114);
			this.BeginColorBack.Name = "BeginColorBack";
			this.BeginColorBack.Size = new System.Drawing.Size(121, 24);
			this.BeginColorBack.TabIndex = 4;
			this.BeginColorBack.Text = "Begin Color...";
			this.BeginColorBack.Click += new System.EventHandler(this.BeginColorBack_Click);
			// 
			// VariantComboBack
			// 
			this.VariantComboBack.Location = new System.Drawing.Point(9, 82);
			this.VariantComboBack.Name = "VariantComboBack";
			this.VariantComboBack.Size = new System.Drawing.Size(121, 21);
			this.VariantComboBack.TabIndex = 3;
			this.VariantComboBack.SelectedIndexChanged += new System.EventHandler(this.VariantComboBack_SelectedIndexChanged);
			// 
			// StyleComboBack
			// 
			this.StyleComboBack.Location = new System.Drawing.Point(9, 36);
			this.StyleComboBack.Name = "StyleComboBack";
			this.StyleComboBack.Size = new System.Drawing.Size(121, 21);
			this.StyleComboBack.TabIndex = 1;
			this.StyleComboBack.SelectedIndexChanged += new System.EventHandler(this.StyleComboBack_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(121, 21);
			this.label5.TabIndex = 0;
			this.label5.Text = "Gradient Style:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(9, 65);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(121, 21);
			this.label6.TabIndex = 2;
			this.label6.Text = "Gradient Variant:";
			// 
			// NGradientUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Name = "NGradientUC";
			this.Size = new System.Drawing.Size(155, 559);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Set background gradient
			nChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.FromArgb(187,221,255), Color.White);

			// add label
			NLabel title = nChartControl1.Labels.AddHeader("Gradient Fill Style");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.MidnightBlue, Color.PaleVioletRed);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			linearScale.MajorGridStyle.LineStyle.Color = Color.White;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Color = Color.White;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.Projection.Rotation = -14;
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// Setup walls
			Color c = Color.FromArgb(128, 128, 192);
			NGradientFillStyle wallGradientFillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, c, Color.White);
			m_Chart.Wall(ChartWallType.Back).FillStyle = wallGradientFillStyle;
			m_Chart.Wall(ChartWallType.Left).FillStyle = wallGradientFillStyle;
			m_Chart.Wall(ChartWallType.Floor).FillStyle = wallGradientFillStyle;

			// Create a bar series
			m_Bar = (NFloatBarSeries)m_Chart.Series.Add(SeriesType.FloatBar);
			m_Bar.DataLabelStyle.Visible = false;
			m_Bar.BarShape = BarShape.Bar;
			m_Bar.BarEdgePercent = 50;
			m_Bar.WidthPercent = 60;
			m_Bar.DepthPercent = 60;
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bar.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.Green, Color.Yellow);

			m_Bar.AddDataPoint(new NFloatBarDataPoint(2.0, 24.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(21.0, 60.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(22.0, 53.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(34.0, 80.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(11.0, 62.0));

			// init form controls
			FillStyleCombo(StyleComboBars);
			FillStyleCombo(StyleComboWalls);
			FillStyleCombo(StyleComboBack);
			FillVariantCombo(VariantComboBars);
			FillVariantCombo(VariantComboWalls);
			FillVariantCombo(VariantComboBack);

			m_bSkipUpdate = true;

			StyleComboBars.SelectedIndex = (int)((NGradientFillStyle)m_Bar.FillStyle).Style;
			VariantComboBars.SelectedIndex = (int)((NGradientFillStyle)m_Bar.FillStyle).Variant;

			StyleComboWalls.SelectedIndex = (int)((NGradientFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle).Style;
			VariantComboWalls.SelectedIndex = (int)((NGradientFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle).Variant;

			StyleComboBack.SelectedIndex = (int)((NGradientFillStyle)nChartControl1.BackgroundStyle.FillStyle).Style;
			VariantComboBack.SelectedIndex = (int)((NGradientFillStyle)nChartControl1.BackgroundStyle.FillStyle).Variant;

			m_bSkipUpdate = false;
		}

		private void FillStyleCombo(NComboBox combo)
		{
			combo.Items.Clear();
			combo.Items.Add("Horizontal");
			combo.Items.Add("Vertical");
			combo.Items.Add("DiagonalUp");
			combo.Items.Add("DiagonalDown");
			combo.Items.Add("FromCorner");
			combo.Items.Add("FromCenter");
		}

		private void FillVariantCombo(NComboBox combo)
		{
			combo.Items.Clear();
			combo.Items.Add("Variant 1");
			combo.Items.Add("Variant 2");
			combo.Items.Add("Variant 3");
			combo.Items.Add("Variant 4");
		}

		private void StyleComboBars_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)m_Bar.FillStyle;
			gradientFillStyle.Style = (Nevron.GraphicsCore.GradientStyle)StyleComboBars.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void VariantComboBars_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			((NGradientFillStyle)m_Bar.FillStyle).Variant = (GradientVariant)VariantComboBars.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void BeginColorBars_Click(object sender, System.EventArgs e)
		{
			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)(m_Bar.FillStyle);
			colorDialog1.Color = gradientFillStyle.BeginColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				gradientFillStyle.BeginColor = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void EndColorBars_Click(object sender, System.EventArgs e)
		{
			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)nChartControl1.BackgroundStyle.FillStyle;
			colorDialog1.Color = gradientFillStyle.EndColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				gradientFillStyle.EndColor = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void StyleComboWalls_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle;
			gradientFillStyle.Style = (Nevron.GraphicsCore.GradientStyle)StyleComboWalls.SelectedIndex;

			m_Chart.Wall(ChartWallType.Back).FillStyle = gradientFillStyle;
			m_Chart.Wall(ChartWallType.Left).FillStyle = gradientFillStyle;
			m_Chart.Wall(ChartWallType.Floor).FillStyle = gradientFillStyle;

			nChartControl1.Refresh();
		}

		private void VariantComboWalls_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)(m_Chart.Wall(ChartWallType.Back).FillStyle);
			gradientFillStyle.Variant = (GradientVariant)VariantComboWalls.SelectedIndex;

			m_Chart.Wall(ChartWallType.Back).FillStyle = gradientFillStyle;
			m_Chart.Wall(ChartWallType.Left).FillStyle = gradientFillStyle;
			m_Chart.Wall(ChartWallType.Floor).FillStyle = gradientFillStyle;

			nChartControl1.Refresh();
		}

		private void BeginColorWalls_Click(object sender, System.EventArgs e)
		{
			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle;
			colorDialog1.Color = gradientFillStyle.BeginColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				gradientFillStyle.BeginColor = colorDialog1.Color;

				m_Chart.Wall(ChartWallType.Back).FillStyle = gradientFillStyle;
				m_Chart.Wall(ChartWallType.Left).FillStyle = gradientFillStyle;
				m_Chart.Wall(ChartWallType.Floor).FillStyle = gradientFillStyle;

				nChartControl1.Refresh();
			}
		}

		private void EndColorWalls_Click(object sender, System.EventArgs e)
		{
			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)m_Chart.Wall(ChartWallType.Back).FillStyle;

			colorDialog1.Color = gradientFillStyle.EndColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				gradientFillStyle.EndColor = colorDialog1.Color;

				m_Chart.Wall(ChartWallType.Back).FillStyle = gradientFillStyle;
				m_Chart.Wall(ChartWallType.Left).FillStyle = gradientFillStyle;
				m_Chart.Wall(ChartWallType.Floor).FillStyle = gradientFillStyle;
				nChartControl1.Refresh();
			}
		}

		private void StyleComboBack_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)nChartControl1.BackgroundStyle.FillStyle;
			gradientFillStyle.Style = (Nevron.GraphicsCore.GradientStyle)StyleComboBack.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void VariantComboBack_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)nChartControl1.BackgroundStyle.FillStyle;
			gradientFillStyle.Variant = (GradientVariant)VariantComboBack.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void BeginColorBack_Click(object sender, System.EventArgs e)
		{
			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)nChartControl1.BackgroundStyle.FillStyle;
			colorDialog1.Color = gradientFillStyle.BeginColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				gradientFillStyle.BeginColor = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void EndColorBack_Click(object sender, System.EventArgs e)
		{
			NGradientFillStyle gradientFillStyle = (NGradientFillStyle)nChartControl1.BackgroundStyle.FillStyle;
			colorDialog1.Color = gradientFillStyle.EndColor;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				gradientFillStyle.EndColor = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}
	}
}

