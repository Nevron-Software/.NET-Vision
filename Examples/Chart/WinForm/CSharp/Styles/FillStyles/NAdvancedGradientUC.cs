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
	public class NAdvancedGradientUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private int m_nCurrentGradient;
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private Nevron.UI.WinForm.Controls.NButton ChangeGradientButton;
		private System.ComponentModel.IContainer components = null;

		public NAdvancedGradientUC()
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
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeGradientButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(8, 7);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(151, 32);
			this.NewDataButton.TabIndex = 0;
			this.NewDataButton.Text = "New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// ChangeGradientButton
			// 
			this.ChangeGradientButton.Location = new System.Drawing.Point(8, 54);
			this.ChangeGradientButton.Name = "ChangeGradientButton";
			this.ChangeGradientButton.Size = new System.Drawing.Size(151, 32);
			this.ChangeGradientButton.TabIndex = 1;
			this.ChangeGradientButton.Text = "Change Gradient";
			this.ChangeGradientButton.Click += new System.EventHandler(this.ChangeGradientButton_Click);
			// 
			// NAdvancedGradientUC
			// 
			this.Controls.Add(this.ChangeGradientButton);
			this.Controls.Add(this.NewDataButton);
			this.Name = "NAdvancedGradientUC";
			this.Size = new System.Drawing.Size(167, 494);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.FromArgb(230, 230, 244));

			// add label
			NLabel title = nChartControl1.Labels.AddHeader("Advanced Gradient Fill Style");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart and axes
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Color = Color.White;

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Color = Color.White;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// set walls advanced gradient
			NAdvancedGradientFillStyle ag = AzureLight();

			m_Chart.Wall(ChartWallType.Back).FillStyle = ag;
			m_Chart.Wall(ChartWallType.Left).FillStyle = ag;
			m_Chart.Wall(ChartWallType.Floor).FillStyle = ag;

			// create bubble chart
			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.BubbleShape = PointShape.Sphere;
			m_Bubble.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Bubble.UseXValues = true;
			m_Bubble.InflateMargins = true;
			m_Bubble.FillStyle = TheEye();

			GenerateData();
		}

		private void GenerateData()
		{
			m_Bubble.Values.FillRandomRange(Random, 5, -20, 20);
			m_Bubble.XValues.FillRandomRange(Random, 5, -20, 20);
			m_Bubble.Sizes.FillRandomRange(Random, 5, 1, 100);
		}

		private NAdvancedGradientFillStyle TheEye()
		{
			NAdvancedGradientFillStyle ag = new NAdvancedGradientFillStyle();

			ag.BackgroundColor = Color.FromArgb(64, 0, 128);

			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(128, 128, 255), 50, 50, 0, 51, AGPointShape.Circle));
			ag.Points.Add(new NAdvancedGradientPoint(Color.White, 50, 50, 0, 49, AGPointShape.Line));
			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(0, 0, 64), 50, 50, 0, 23, AGPointShape.Circle));
			ag.Points.Add(new NAdvancedGradientPoint(Color.Black, 50, 50, 0, 13, AGPointShape.Circle));

			return ag;
		}

		private NAdvancedGradientFillStyle Medusa()
		{
			NAdvancedGradientFillStyle ag = new NAdvancedGradientFillStyle();

			ag.BackgroundColor = Color.FromArgb(0, 0, 64);

			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(0, 128, 255), 12, 57, 0, 60, AGPointShape.Circle));
			ag.Points.Add(new NAdvancedGradientPoint(Color.White, 29, 29, 0, 35, AGPointShape.Circle));
			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(0, 128, 255), 57, 12, 0, 60, AGPointShape.Circle));
			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(128, 0, 255), 60, 60, 0, 37, AGPointShape.Circle));
			ag.Points.Add(new NAdvancedGradientPoint(Color.White, 84, 84, 0, 50, AGPointShape.Circle));

			return ag;
		}

		private NAdvancedGradientFillStyle Reactor()
		{
			NAdvancedGradientFillStyle ag = new NAdvancedGradientFillStyle();

			ag.BackgroundColor = Color.Black;

			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(255, 128, 255), 50, 78, 0, 35, AGPointShape.Line));
			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(128, 128, 255), 50, 22, 0, 35, AGPointShape.Line));
			ag.Points.Add(new NAdvancedGradientPoint(Color.White, 50, 50, 0, 52, AGPointShape.Circle));

			return ag;
		}

		private NAdvancedGradientFillStyle Flow()
		{
			NAdvancedGradientFillStyle ag = new NAdvancedGradientFillStyle();

			ag.BackgroundColor = Color.FromArgb(64, 0, 128);

			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(255, 255, 128), 38, 17, 50, 48, AGPointShape.Line));
			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(255, 0, 128), 58, 74, 0, 100, AGPointShape.Line));

			return ag;
		}

		private NAdvancedGradientFillStyle AzureLight()
		{
			NAdvancedGradientFillStyle ag = new NAdvancedGradientFillStyle();

			ag.BackgroundColor = Color.White;

			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(235, 168, 255), 87, 29, 0, 92, AGPointShape.Circle));
			ag.Points.Add(new NAdvancedGradientPoint(Color.FromArgb(64, 199, 255), 53, 82, 0, 81, AGPointShape.Circle));
			ag.Points.Add(new NAdvancedGradientPoint(Color.White, 16, 17, 0, 100, AGPointShape.Circle));

			return ag;
		}

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			nChartControl1.Refresh();
		}

		private void ChangeGradientButton_Click(object sender, System.EventArgs e)
		{
			NAdvancedGradientFillStyle ag;

			m_nCurrentGradient++;

			if(m_nCurrentGradient == 4)
				m_nCurrentGradient = 0;

			switch(m_nCurrentGradient)
			{
				case 0:
					ag = TheEye();
					break;
				case 1:
					ag = Medusa();
					break;
				case 2:
					ag = Reactor();
					break;
				case 3:
					ag = Flow();
					break;
				default:
					ag = TheEye();
					break;
			}

			m_Bubble.FillStyle = ag;
			nChartControl1.Refresh();
		}
	}
}