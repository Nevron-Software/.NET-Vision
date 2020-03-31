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
	public class NSolidColorUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NFloatBarSeries m_Bar;
		private bool m_bSkipUpdate;
		private Nevron.UI.WinForm.Controls.NButton EditLightsButton;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NButton BarsDiffuseButton;
		private Nevron.UI.WinForm.Controls.NButton BarsAmbientButton;
		private Nevron.UI.WinForm.Controls.NButton BarsSpecularButton;
		private Nevron.UI.WinForm.Controls.NButton BarsEmissiveButton;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NButton WallsEmissiveButton;
		private Nevron.UI.WinForm.Controls.NButton WallsDiffuseButton;
		private Nevron.UI.WinForm.Controls.NButton WallsSpecularButton;
		private Nevron.UI.WinForm.Controls.NButton WallsAmbientButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BarsShininessSpin;
		private Nevron.UI.WinForm.Controls.NNumericUpDown WallsShininessSpin;
		private Nevron.UI.WinForm.Controls.NButton BackColorButton;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components = null;

		public NSolidColorUC()
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
			this.EditLightsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BarsDiffuseButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BarsAmbientButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BarsSpecularButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BarsEmissiveButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BarsShininessSpin = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.colorDialog1 = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.WallsShininessSpin = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.WallsEmissiveButton = new Nevron.UI.WinForm.Controls.NButton();
			this.WallsDiffuseButton = new Nevron.UI.WinForm.Controls.NButton();
			this.WallsSpecularButton = new Nevron.UI.WinForm.Controls.NButton();
			this.WallsAmbientButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BackColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarsShininessSpin)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.WallsShininessSpin)).BeginInit();
			this.SuspendLayout();
			// 
			// EditLightsButton
			// 
			this.EditLightsButton.Location = new System.Drawing.Point(7, 7);
			this.EditLightsButton.Name = "EditLightsButton";
			this.EditLightsButton.Size = new System.Drawing.Size(141, 23);
			this.EditLightsButton.TabIndex = 0;
			this.EditLightsButton.Text = "Edit Ligths...";
			this.EditLightsButton.Click += new System.EventHandler(this.EditLightsButton_Click);
			// 
			// BarsDiffuseButton
			// 
			this.BarsDiffuseButton.Location = new System.Drawing.Point(8, 21);
			this.BarsDiffuseButton.Name = "BarsDiffuseButton";
			this.BarsDiffuseButton.Size = new System.Drawing.Size(122, 22);
			this.BarsDiffuseButton.TabIndex = 1;
			this.BarsDiffuseButton.Text = "Diffuse Color...";
			this.BarsDiffuseButton.Click += new System.EventHandler(this.BarsDiffuseButton_Click);
			// 
			// BarsAmbientButton
			// 
			this.BarsAmbientButton.Location = new System.Drawing.Point(8, 48);
			this.BarsAmbientButton.Name = "BarsAmbientButton";
			this.BarsAmbientButton.Size = new System.Drawing.Size(122, 22);
			this.BarsAmbientButton.TabIndex = 2;
			this.BarsAmbientButton.Text = "Ambient Color...";
			this.BarsAmbientButton.Click += new System.EventHandler(this.BarsAmbientButton_Click);
			// 
			// BarsSpecularButton
			// 
			this.BarsSpecularButton.Location = new System.Drawing.Point(8, 76);
			this.BarsSpecularButton.Name = "BarsSpecularButton";
			this.BarsSpecularButton.Size = new System.Drawing.Size(122, 22);
			this.BarsSpecularButton.TabIndex = 3;
			this.BarsSpecularButton.Text = "Specular Color...";
			this.BarsSpecularButton.Click += new System.EventHandler(this.BarsSpecularButton_Click);
			// 
			// BarsEmissiveButton
			// 
			this.BarsEmissiveButton.Location = new System.Drawing.Point(8, 104);
			this.BarsEmissiveButton.Name = "BarsEmissiveButton";
			this.BarsEmissiveButton.Size = new System.Drawing.Size(122, 22);
			this.BarsEmissiveButton.TabIndex = 4;
			this.BarsEmissiveButton.Text = "Emissive Color...";
			this.BarsEmissiveButton.Click += new System.EventHandler(this.BarsEmissiveButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BarsShininessSpin);
			this.groupBox1.Controls.Add(this.BarsEmissiveButton);
			this.groupBox1.Controls.Add(this.BarsDiffuseButton);
			this.groupBox1.Controls.Add(this.BarsSpecularButton);
			this.groupBox1.Controls.Add(this.BarsAmbientButton);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(7, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(141, 179);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bars";
			// 
			// BarsShininessSpin
			// 
			this.BarsShininessSpin.Location = new System.Drawing.Point(8, 149);
			this.BarsShininessSpin.Maximum = new System.Decimal(new int[] {
																			  128,
																			  0,
																			  0,
																			  0});
			this.BarsShininessSpin.Name = "BarsShininessSpin";
			this.BarsShininessSpin.Size = new System.Drawing.Size(81, 20);
			this.BarsShininessSpin.TabIndex = 5;
			this.BarsShininessSpin.ValueChanged += new System.EventHandler(this.BarsShininessSpin_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 133);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Shininess:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.WallsShininessSpin);
			this.groupBox2.Controls.Add(this.WallsEmissiveButton);
			this.groupBox2.Controls.Add(this.WallsDiffuseButton);
			this.groupBox2.Controls.Add(this.WallsSpecularButton);
			this.groupBox2.Controls.Add(this.WallsAmbientButton);
			this.groupBox2.Location = new System.Drawing.Point(7, 244);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(141, 179);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Walls";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 133);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "Shininess:";
			// 
			// WallsShininessSpin
			// 
			this.WallsShininessSpin.Location = new System.Drawing.Point(11, 149);
			this.WallsShininessSpin.Maximum = new System.Decimal(new int[] {
																			   128,
																			   0,
																			   0,
																			   0});
			this.WallsShininessSpin.Name = "WallsShininessSpin";
			this.WallsShininessSpin.Size = new System.Drawing.Size(81, 20);
			this.WallsShininessSpin.TabIndex = 6;
			this.WallsShininessSpin.ValueChanged += new System.EventHandler(this.WallsShininessSpin_ValueChanged);
			// 
			// WallsEmissiveButton
			// 
			this.WallsEmissiveButton.Location = new System.Drawing.Point(8, 104);
			this.WallsEmissiveButton.Name = "WallsEmissiveButton";
			this.WallsEmissiveButton.Size = new System.Drawing.Size(122, 22);
			this.WallsEmissiveButton.TabIndex = 4;
			this.WallsEmissiveButton.Text = "Emissive Color...";
			this.WallsEmissiveButton.Click += new System.EventHandler(this.WallsEmissiveButton_Click);
			// 
			// WallsDiffuseButton
			// 
			this.WallsDiffuseButton.Location = new System.Drawing.Point(8, 21);
			this.WallsDiffuseButton.Name = "WallsDiffuseButton";
			this.WallsDiffuseButton.Size = new System.Drawing.Size(122, 22);
			this.WallsDiffuseButton.TabIndex = 1;
			this.WallsDiffuseButton.Text = "Diffuse Color...";
			this.WallsDiffuseButton.Click += new System.EventHandler(this.WallsDiffuseButton_Click);
			// 
			// WallsSpecularButton
			// 
			this.WallsSpecularButton.Location = new System.Drawing.Point(8, 76);
			this.WallsSpecularButton.Name = "WallsSpecularButton";
			this.WallsSpecularButton.Size = new System.Drawing.Size(122, 22);
			this.WallsSpecularButton.TabIndex = 3;
			this.WallsSpecularButton.Text = "Specular Color...";
			this.WallsSpecularButton.Click += new System.EventHandler(this.WallsSpecularButton_Click);
			// 
			// WallsAmbientButton
			// 
			this.WallsAmbientButton.Location = new System.Drawing.Point(8, 48);
			this.WallsAmbientButton.Name = "WallsAmbientButton";
			this.WallsAmbientButton.Size = new System.Drawing.Size(122, 22);
			this.WallsAmbientButton.TabIndex = 2;
			this.WallsAmbientButton.Text = "Ambient Color...";
			this.WallsAmbientButton.Click += new System.EventHandler(this.WallsAmbientButton_Click);
			// 
			// BackColorButton
			// 
			this.BackColorButton.Location = new System.Drawing.Point(7, 443);
			this.BackColorButton.Name = "BackColorButton";
			this.BackColorButton.Size = new System.Drawing.Size(141, 23);
			this.BackColorButton.TabIndex = 7;
			this.BackColorButton.Text = "Background Color...";
			this.BackColorButton.Click += new System.EventHandler(this.BackColorButton_Click);
			// 
			// NSolidColorUC
			// 
			this.Controls.Add(this.BackColorButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.EditLightsButton);
			this.Controls.Add(this.groupBox2);
			this.Name = "NSolidColorUC";
			this.Size = new System.Drawing.Size(156, 482);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.BarsShininessSpin)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.WallsShininessSpin)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.BackgroundStyle.FillStyle = new NColorFillStyle(Color.FromArgb(230, 230, 255));

			// add label
			NLabel title = nChartControl1.Labels.AddHeader("Colors And Materials");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);

			// Setup the light model
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
			m_Chart.LightModel.GlobalAmbientLight = Color.FromArgb(64, 64, 64);
			m_Chart.LightModel.LightSources[0].Diffuse = Color.FromArgb(160, 160, 160);
			m_Chart.LightModel.LightSources[1].Diffuse = Color.FromArgb(160, 160, 160);
			m_Chart.LightModel.LightSources[2].Diffuse = Color.FromArgb(160, 160, 160);

			// Setup axes
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			standardScale.MajorGridStyle.LineStyle.Color = Color.White;
			standardScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			standardScale.MajorGridStyle.LineStyle.Color = Color.White;
			standardScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			standardScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// Setup walls
			Color diffuse = Color.FromArgb(128, 128, 192);
			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Diffuse = diffuse;
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Diffuse = diffuse;
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Diffuse = diffuse;

			Color ambient = Color.FromArgb(128, 0, 255);
			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Ambient = ambient;
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Ambient = ambient;
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Ambient = ambient;

			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Specular = Color.White;
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Specular = Color.White;
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Specular = Color.White;

			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Shininess = 110;
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Shininess = 110;
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Shininess = 110;

			// Create a bar series
			m_Bar = (NFloatBarSeries)m_Chart.Series.Add(SeriesType.FloatBar);
			m_Bar.DataLabelStyle.Visible = false;
			m_Bar.BarShape = BarShape.SmoothEdgeBar;
			m_Bar.BarEdgePercent = 50;
			m_Bar.WidthPercent = 60;
			m_Bar.DepthPercent = 60;
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bar.FillStyle.MaterialStyle.Diffuse = Color.FromArgb(0, 0, 64);
			m_Bar.FillStyle.MaterialStyle.Ambient = Color.White;
			m_Bar.FillStyle.MaterialStyle.Specular = Color.White;
			m_Bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);;

			m_Bar.AddDataPoint(new NFloatBarDataPoint(2.0, 24.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(21.0, 60.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(22.0, 53.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(34.0, 80.0));
			m_Bar.AddDataPoint(new NFloatBarDataPoint(11.0, 62.0));

			// init form controls
			m_bSkipUpdate = true;
			BarsShininessSpin.Value = (decimal)m_Bar.FillStyle.MaterialStyle.Shininess;
			WallsShininessSpin.Value = (decimal)m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Shininess;
			m_bSkipUpdate = false;
		}

		private void EditLightsButton_Click(object sender, System.EventArgs e)
		{
			NLightModel result;

			if(NLightModelTypeEditor.Edit(m_Chart.LightModel, out result))
			{
				m_Chart.LightModel = result;
				nChartControl1.Refresh();
			}
		}

		private void BarsDiffuseButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = m_Bar.FillStyle.MaterialStyle.Diffuse;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Bar.FillStyle.MaterialStyle.Diffuse = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void BarsAmbientButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = m_Bar.FillStyle.MaterialStyle.Ambient;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Bar.FillStyle.MaterialStyle.Ambient = colorDialog1.Color;
				nChartControl1.Refresh();
			}		
		}

		private void BarsSpecularButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = m_Bar.FillStyle.MaterialStyle.Specular;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Bar.FillStyle.MaterialStyle.Specular = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void BarsEmissiveButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = m_Bar.FillStyle.MaterialStyle.Emissive;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Bar.FillStyle.MaterialStyle.Emissive = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void WallsDiffuseButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Diffuse;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Diffuse = colorDialog1.Color;
				m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Diffuse = colorDialog1.Color;
				m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Diffuse = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void WallsAmbientButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Ambient;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Ambient = colorDialog1.Color;
				m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Ambient = colorDialog1.Color;
				m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Ambient = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void WallsSpecularButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Specular;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Specular = colorDialog1.Color;
				m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Specular = colorDialog1.Color;
				m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Specular = colorDialog1.Color;
				nChartControl1.Refresh();
			}
		}

		private void WallsEmissiveButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Emissive;

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Emissive = colorDialog1.Color;
				m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Emissive = colorDialog1.Color;
				m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Emissive = colorDialog1.Color;
				nChartControl1.Refresh();
			}		
		}

		private void BarsShininessSpin_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			m_Bar.FillStyle.MaterialStyle.Shininess = (float)BarsShininessSpin.Value;
			nChartControl1.Refresh();
		}

		private void WallsShininessSpin_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			float shininess = (float)WallsShininessSpin.Value;

			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Shininess = shininess;
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Shininess = shininess;
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Shininess = shininess;
			nChartControl1.Refresh();
		}

		private void BackColorButton_Click(object sender, System.EventArgs e)
		{
			colorDialog1.Color = nChartControl1.BackgroundStyle.FillStyle.GetPrimaryColor().ToColor();

			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				nChartControl1.BackgroundStyle.FillStyle = new NColorFillStyle(colorDialog1.Color);
				nChartControl1.Refresh();
			}
		}
	}
}
