using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NDoughnutPieUC : NExampleBaseUC
	{
		private NPieChart m_PieChart;
		private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;
		private System.ComponentModel.Container components = null;

		public NDoughnutPieUC()
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
			this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// ChangeDataButton
			// 
			this.ChangeDataButton.Location = new System.Drawing.Point(6, 8);
			this.ChangeDataButton.Name = "ChangeDataButton";
			this.ChangeDataButton.Size = new System.Drawing.Size(169, 24);
			this.ChangeDataButton.TabIndex = 0;
			this.ChangeDataButton.Text = "Change Data";
			this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			// 
			// NDoughnutPieUC
			// 
			this.Controls.Add(this.ChangeDataButton);
			this.Name = "NDoughnutPieUC";
			this.Size = new System.Drawing.Size(180, 213);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Doughnut Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_PieChart = new NPieChart();
			m_PieChart.Enable3D = true;
			nChartControl1.Charts.Clear();
			nChartControl1.Panels.Add(m_PieChart);

			m_PieChart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			m_PieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);

			m_PieChart.DisplayOnLegend = nChartControl1.Legends[0];
			m_PieChart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_PieChart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
			m_PieChart.InnerRadius = new NLength(10, NRelativeUnit.ParentPercentage);

			Random random = new Random();
			string[] labels = new string[] { "Ships", "Trains", "Automobiles", "Airplanes" };

			for (int i = 0; i < 4; i++)
			{
				NPieSeries pieSeries = new NPieSeries();

				// create a small detachment between pie rings
				pieSeries.BeginRadiusPercent = 10;
				pieSeries.PieStyle = PieStyle.Ring;

				m_PieChart.Series.Add(pieSeries);

				pieSeries.DataLabelStyle.ArrowLength = new NLength(0);
				pieSeries.DataLabelStyle.ArrowPointerLength = new NLength(0);
				pieSeries.DataLabelStyle.Format = "<percent>";

				if (i == 0)
				{
					pieSeries.Legend.Mode = SeriesLegendMode.DataPoints;
					pieSeries.Legend.Format = "<label>";
				}
				else
				{
					pieSeries.Legend.Mode = SeriesLegendMode.None;
				}

				pieSeries.LabelMode = PieLabelMode.Center;

				for (int j = 0; j < labels.Length; j++)
				{
					pieSeries.Values.Add(20 + random.Next(100));
					pieSeries.Labels.Add(labels[j]);
				}
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);
		}


		private void ChangeDataButton_Click(object sender, System.EventArgs e)
		{
			foreach (NPieSeries pie in m_PieChart.Series)
			{
				pie.Values.FillRandomRange(Random, 4, 1, 60);
			}

			nChartControl1.Refresh();
		}
	}
}