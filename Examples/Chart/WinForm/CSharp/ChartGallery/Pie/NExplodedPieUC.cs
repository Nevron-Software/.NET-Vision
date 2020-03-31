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
	public class NExplodedPieUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPieSeries m_Pie;
		private Nevron.UI.WinForm.Controls.NButton ExplodeSmallestButton;
		private Nevron.UI.WinForm.Controls.NButton ExpodeBiggestButton;
		private Nevron.UI.WinForm.Controls.NButton RemoveExplosionsButton;
		private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;
		private System.ComponentModel.Container components = null;

		public NExplodedPieUC()
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
			this.ExplodeSmallestButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExpodeBiggestButton = new Nevron.UI.WinForm.Controls.NButton();
			this.RemoveExplosionsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// ExplodeSmallestButton
			// 
			this.ExplodeSmallestButton.Location = new System.Drawing.Point(6, 73);
			this.ExplodeSmallestButton.Name = "ExplodeSmallestButton";
			this.ExplodeSmallestButton.Size = new System.Drawing.Size(169, 24);
			this.ExplodeSmallestButton.TabIndex = 2;
			this.ExplodeSmallestButton.Text = "Explode Smallest";
			this.ExplodeSmallestButton.Click += new System.EventHandler(this.ExplodeSmallestButton_Click);
			// 
			// ExpodeBiggestButton
			// 
			this.ExpodeBiggestButton.Location = new System.Drawing.Point(6, 105);
			this.ExpodeBiggestButton.Name = "ExpodeBiggestButton";
			this.ExpodeBiggestButton.Size = new System.Drawing.Size(169, 24);
			this.ExpodeBiggestButton.TabIndex = 3;
			this.ExpodeBiggestButton.Text = "Expode Biggest";
			this.ExpodeBiggestButton.Click += new System.EventHandler(this.ExpodeBiggestButton_Click);
			// 
			// RemoveExplosionsButton
			// 
			this.RemoveExplosionsButton.Location = new System.Drawing.Point(6, 40);
			this.RemoveExplosionsButton.Name = "RemoveExplosionsButton";
			this.RemoveExplosionsButton.Size = new System.Drawing.Size(169, 24);
			this.RemoveExplosionsButton.TabIndex = 1;
			this.RemoveExplosionsButton.Text = "Remove Explosions";
			this.RemoveExplosionsButton.Click += new System.EventHandler(this.RemoveExplosionsButton_Click);
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
			// NExplodedPieUC
			// 
			this.Controls.Add(this.ChangeDataButton);
			this.Controls.Add(this.RemoveExplosionsButton);
			this.Controls.Add(this.ExpodeBiggestButton);
			this.Controls.Add(this.ExplodeSmallestButton);
			this.Name = "NExplodedPieUC";
			this.Size = new System.Drawing.Size(180, 213);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Exploded Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = new NPieChart();
			m_Chart.Enable3D = true;
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);

			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);

			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];
			m_Chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));

			m_Pie = (NPieSeries)m_Chart.Series.Add(SeriesType.Pie);
			m_Pie.PieEdgePercent = 30;
			m_Pie.PieStyle = PieStyle.SmoothEdgePie;
			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Pie.Legend.Format = "<label> <percent>";

			m_Pie.AddDataPoint(new NDataPoint(12, "Ships"));
			m_Pie.AddDataPoint(new NDataPoint(42, "Trains"));
			m_Pie.AddDataPoint(new NDataPoint(56, "Cars"));
			m_Pie.AddDataPoint(new NDataPoint(23, "Buses"));
			m_Pie.AddDataPoint(new NDataPoint(18, "Airplanes"));

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			FillDetachments();
		}

		void FillDetachments()
		{
			m_Pie.Detachments.Clear();

			for(int i = 0; i < m_Pie.Values.Count; i++)
			{
				m_Pie.Detachments.Add(0.0);
			}
		}

		private void RemoveExplosionsButton_Click(object sender, System.EventArgs e)
		{
			// set all pie detachments to 0
			for (int i = 0; i < m_Pie.Detachments.Count; i++)
			{
				m_Pie.Detachments[i] = 0.0;
			}

			nChartControl1.Refresh();
		}

		private void ExplodeSmallestButton_Click(object sender, System.EventArgs e)
		{
			int nIndex = m_Pie.Values.FindMinValue();
			m_Pie.Detachments[nIndex] =  5.0f;
			nChartControl1.Refresh();
		}

		private void ExpodeBiggestButton_Click(object sender, System.EventArgs e)
		{
			int nIndex = m_Pie.Values.FindMaxValue();
			m_Pie.Detachments[nIndex] = 5.0f;
			nChartControl1.Refresh();
		}

		private void ChangeDataButton_Click(object sender, System.EventArgs e)
		{
			m_Pie.Values.FillRandomRange(Random, 5, 1, 60);
			FillDetachments();

			nChartControl1.Refresh();
		}
	}
}