using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NImageUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private Nevron.UI.WinForm.Controls.NButton ChooseImageBars;
		private Nevron.UI.WinForm.Controls.NButton ChooseImageWalls;
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.IContainer components = null;

		public NImageUC()
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
			this.ChooseImageBars = new Nevron.UI.WinForm.Controls.NButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.ChooseImageWalls = new Nevron.UI.WinForm.Controls.NButton();
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// ChooseImageBars
			// 
			this.ChooseImageBars.Location = new System.Drawing.Point(8, 59);
			this.ChooseImageBars.Name = "ChooseImageBars";
			this.ChooseImageBars.Size = new System.Drawing.Size(173, 23);
			this.ChooseImageBars.TabIndex = 0;
			this.ChooseImageBars.Text = "Choose Bubbles Texture...";
			this.ChooseImageBars.Click += new System.EventHandler(this.ChooseImageBars_Click);
			// 
			// ChooseImageWalls
			// 
			this.ChooseImageWalls.Location = new System.Drawing.Point(8, 88);
			this.ChooseImageWalls.Name = "ChooseImageWalls";
			this.ChooseImageWalls.Size = new System.Drawing.Size(173, 23);
			this.ChooseImageWalls.TabIndex = 1;
			this.ChooseImageWalls.Text = "Choose Walls Texture...";
			this.ChooseImageWalls.Click += new System.EventHandler(this.ChooseImageWalls_Click);
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(8, 8);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(173, 23);
			this.NewDataButton.TabIndex = 2;
			this.NewDataButton.Text = "New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// NImageUC
			// 
			this.Controls.Add(this.NewDataButton);
			this.Controls.Add(this.ChooseImageWalls);
			this.Controls.Add(this.ChooseImageBars);
			this.Name = "NImageUC";
			this.Size = new System.Drawing.Size(188, 460);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// load textures from resources
			Bitmap bmp0 = NResourceHelper.BitmapFromResource(this.GetType(), "Back.png", "Nevron.Examples.Chart.WinForm.Resources");
			Bitmap bmp1 = NResourceHelper.BitmapFromResource(this.GetType(), "Leafs.png", "Nevron.Examples.Chart.WinForm.Resources");
			Bitmap bmp2 = NResourceHelper.BitmapFromResource(this.GetType(), "Banner.png", "Nevron.Examples.Chart.WinForm.Resources");

			NImageFillStyle imageFillStyle = new NImageFillStyle(bmp0);
			imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled;

			nChartControl1.BackgroundStyle.FillStyle = imageFillStyle;

			// add label
			NLabel title = nChartControl1.Labels.AddHeader("Image Fill Style");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            

			// setup chart and axes
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Color = Color.White;

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Color = Color.White;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// Setup walls
			Color c = Color.FromArgb(128, 128, 192);
			imageFillStyle = new NImageFillStyle(bmp1);
			imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled;

			m_Chart.Wall(ChartWallType.Back).FillStyle = imageFillStyle;
			m_Chart.Wall(ChartWallType.Left).FillStyle = imageFillStyle;
			m_Chart.Wall(ChartWallType.Floor).FillStyle = imageFillStyle;

			// create bubble chart
			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.BubbleShape = PointShape.Ellipse;
			m_Bubble.UseXValues = true;
			m_Bubble.InflateMargins = true;
			m_Bubble.BorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
			m_Bubble.FillStyle = new NImageFillStyle(bmp2);

			GenerateData();
		}

		private void GenerateData()
		{
			m_Bubble.Values.FillRandomRange(Random, 5, -20, 20);
			m_Bubble.XValues.FillRandomRange(Random, 5, -20, 20);
			m_Bubble.Sizes.FillRandomRange(Random, 5, 1, 100);
		}

		private void ChooseImageBars_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Bubble.FillStyle = new NImageFillStyle(openFileDialog1.FileName);
				nChartControl1.Refresh();
			}
		}

		private void ChooseImageWalls_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				NImageFillStyle imageFillStyle = new NImageFillStyle(openFileDialog1.FileName);

				m_Chart.Wall(ChartWallType.Back).FillStyle = imageFillStyle;
				m_Chart.Wall(ChartWallType.Left).FillStyle = imageFillStyle;
				m_Chart.Wall(ChartWallType.Floor).FillStyle = imageFillStyle;

				nChartControl1.Refresh();
			}
		}

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			nChartControl1.Refresh();
		}
	}
}