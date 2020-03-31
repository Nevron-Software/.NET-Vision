using System;
using System.Resources;
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
	public class NOrdinalScaleUC : NExampleBaseUC
	{
		private NCartesianChart m_Chart;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox HorzDataPointsBetweenTicksCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox HorzAutoLabelsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox DepthAutoLabelsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox DepthDataPointsBetweenTicksCheck;
		private System.ComponentModel.Container components = null;
		private bool m_Updating;

		public NOrdinalScaleUC()
		{
			m_Updating = true;

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
			this.HorzDataPointsBetweenTicksCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.HorzAutoLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.DepthAutoLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.DepthDataPointsBetweenTicksCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// HorzDataPointsBetweenTicksCheck
			// 
			this.HorzDataPointsBetweenTicksCheck.Location = new System.Drawing.Point(6, 20);
			this.HorzDataPointsBetweenTicksCheck.Name = "HorzDataPointsBetweenTicksCheck";
			this.HorzDataPointsBetweenTicksCheck.Size = new System.Drawing.Size(192, 22);
			this.HorzDataPointsBetweenTicksCheck.TabIndex = 0;
			this.HorzDataPointsBetweenTicksCheck.Text = "Display Data Points Between Ticks";
			this.HorzDataPointsBetweenTicksCheck.CheckedChanged += new System.EventHandler(this.HorzDataPointsBetweenTicksCheck_CheckedChanged);
			// 
			// HorzAutoLabelsCheck
			// 
			this.HorzAutoLabelsCheck.Location = new System.Drawing.Point(7, 43);
			this.HorzAutoLabelsCheck.Name = "HorzAutoLabelsCheck";
			this.HorzAutoLabelsCheck.Size = new System.Drawing.Size(161, 19);
			this.HorzAutoLabelsCheck.TabIndex = 1;
			this.HorzAutoLabelsCheck.Text = "Auto Labels";
			this.HorzAutoLabelsCheck.CheckedChanged += new System.EventHandler(this.HorzAutoLabelsCheck_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.HorzAutoLabelsCheck);
			this.groupBox1.Controls.Add(this.HorzDataPointsBetweenTicksCheck);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(235, 72);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Horizontal Axis";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.DepthAutoLabelsCheck);
			this.groupBox2.Controls.Add(this.DepthDataPointsBetweenTicksCheck);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(235, 72);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Depth Axis";
			// 
			// DepthAutoLabelsCheck
			// 
			this.DepthAutoLabelsCheck.Location = new System.Drawing.Point(7, 43);
			this.DepthAutoLabelsCheck.Name = "DepthAutoLabelsCheck";
			this.DepthAutoLabelsCheck.Size = new System.Drawing.Size(161, 19);
			this.DepthAutoLabelsCheck.TabIndex = 1;
			this.DepthAutoLabelsCheck.Text = "Auto Labels";
			this.DepthAutoLabelsCheck.CheckedChanged += new System.EventHandler(this.DepthAutoLabelsCheck_CheckedChanged);
			// 
			// DepthDataPointsBetweenTicksCheck
			// 
			this.DepthDataPointsBetweenTicksCheck.Location = new System.Drawing.Point(6, 20);
			this.DepthDataPointsBetweenTicksCheck.Name = "DepthDataPointsBetweenTicksCheck";
			this.DepthDataPointsBetweenTicksCheck.Size = new System.Drawing.Size(192, 22);
			this.DepthDataPointsBetweenTicksCheck.TabIndex = 0;
			this.DepthDataPointsBetweenTicksCheck.Text = "Display Data Points Between Ticks";
			this.DepthDataPointsBetweenTicksCheck.CheckedChanged += new System.EventHandler(this.DepthDataPointsBetweenTicksCheck_CheckedChanged);
			// 
			// NOrdinalScaleUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NOrdinalScaleUC";
			this.Size = new System.Drawing.Size(235, 364);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Ordinal Scale");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the chart
			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Depth = 50;
			m_Chart.BoundsMode = BoundsMode.Fit;

			m_Chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));

            // add interlaced stripe to the Y axis
            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            NScaleStripStyle stripStyle = new NScaleStripStyle();
            stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

			// add some series
			int dataItemsCount = 6;
			for (int i = 0; i < 3; i++)
			{
				NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);

				bar.Name = "Series " + i.ToString();
				bar.Values.FillRandomRange(Random, dataItemsCount, 10, 30);
				bar.InflateMargins = true;
				bar.DataLabelStyle.Visible = false;
			}

			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			for (int j = 0; j < dataItemsCount; j++)
			{
				ordinalScale.Labels.Add("Category " + j.ToString());
			}

			ordinalScale = m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.Labels.Add("Series 1");
			ordinalScale.Labels.Add("Series 2");
			ordinalScale.Labels.Add("Series 3");
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			HorzDataPointsBetweenTicksCheck.Checked = true;
			DepthDataPointsBetweenTicksCheck.Checked = true;
			HorzAutoLabelsCheck.Checked = true;
			DepthAutoLabelsCheck.Checked = true;
			m_Updating = false;

			nChartControl1.Refresh();
		}

		private void UpdateScales()
		{
			if (m_Updating)
				return;

			NOrdinalScaleConfigurator ordinalScale;

			// configure the primary x axis
			ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			ordinalScale.DisplayDataPointsBetweenTicks = HorzDataPointsBetweenTicksCheck.Checked;
			ordinalScale.AutoLabels = HorzAutoLabelsCheck.Checked;

			// configure the depth axis
			ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;

			ordinalScale.DisplayDataPointsBetweenTicks = DepthDataPointsBetweenTicksCheck.Checked;
			ordinalScale.AutoLabels = DepthAutoLabelsCheck.Checked;

			nChartControl1.Refresh();
		}

		private void HorzDataPointsBetweenTicksCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScales();
		}

		private void HorzAutoLabelsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScales();
		}

		private void DepthDataPointsBetweenTicksCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScales();
		}

		private void DepthAutoLabelsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScales();		
		}
	}
}
