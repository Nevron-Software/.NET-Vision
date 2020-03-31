using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NMultiplePiesUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox Rotate;
		private System.Windows.Forms.Timer m_Timer;
		private System.ComponentModel.IContainer components;
		private Color[] colors;

		public NMultiplePiesUC()
		{
			InitializeComponent();

			colors = new Color[] { DarkOrange, LightOrange, LightGreen, Turqoise };
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
			this.components = new System.ComponentModel.Container();
			this.Rotate = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_Timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// Rotate
			// 
			this.Rotate.ButtonProperties.BorderOffset = 2;
			this.Rotate.Location = new System.Drawing.Point(9, 9);
			this.Rotate.Name = "Rotate";
			this.Rotate.Size = new System.Drawing.Size(122, 24);
			this.Rotate.TabIndex = 1;
			this.Rotate.Text = "Rotate";
			this.Rotate.CheckedChanged += new System.EventHandler(this.Rotate_CheckedChanged);
			// 
			// Timer1
			// 
			this.m_Timer.Interval = 50;
			this.m_Timer.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// NMultiplePiesUC
			// 
			this.Controls.Add(this.Rotate);
			this.Name = "NMultiplePiesUC";
			this.Size = new System.Drawing.Size(180, 41);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			ConfigureHeaderLabel();
			ConfigureLegend();
			ConfigurePieCharts();

			// apply style sheet
//			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
//			styleSheet.Apply(nChartControl1.Document);
		}

		private void ConfigureHeaderLabel()
		{
			NLabel label = new NLabel("Product Revenue Percents 2002 - 2005");
			label.TextStyle.BackplaneStyle.Visible = false;
			label.TextStyle.FontStyle.EmSize = new NLength(17, NGraphicsUnit.Point);
			label.ContentAlignment = ContentAlignment.MiddleCenter;
			label.DockMode = PanelDockMode.Fill;
			label.BoundsMode = BoundsMode.Fit;
			label.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center;

			NDockPanel labelHostPanel = new NDockPanel();
			labelHostPanel.DockMode = PanelDockMode.Top;
			labelHostPanel.Size = new NSizeL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			labelHostPanel.ChildPanels.Add(label);

			nChartControl1.Panels.Add(labelHostPanel);
		}
		private void ConfigureLegend()
		{
			NLegend legend = new NLegend();
			legend.Mode = LegendMode.Manual;
			legend.DockMode = PanelDockMode.Fill;
			legend.BoundsMode = BoundsMode.Fit;
			legend.ContentAlignment = ContentAlignment.MiddleCenter;
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly;

			// add custom legend items
			legend.Data.Items.Add(CreateLegendItem("Charting", colors[0]));
			legend.Data.Items.Add(CreateLegendItem("Diagramming", colors[1]));
			legend.Data.Items.Add(CreateLegendItem("User Interface", colors[2]));
			legend.Data.Items.Add(CreateLegendItem("Help Authoring", colors[3]));

			NDockPanel legendHostPanel = new NDockPanel();
			legendHostPanel.DockMode = PanelDockMode.Bottom;
			legendHostPanel.Size = new NSizeL(
				new NLength(100, NRelativeUnit.ParentPercentage),
				new NLength(5, NRelativeUnit.ParentPercentage));
			legendHostPanel.ChildPanels.Add(legend);

			nChartControl1.Panels.Add(legendHostPanel);
		}
		private void ConfigurePieCharts()
		{
			NDockPanel contentPanel = new NDockPanel();
			contentPanel.DockMode = PanelDockMode.Fill;
			nChartControl1.Panels.Add(contentPanel);

			// configure four pie 1
			NDockPanel dockPanelLeftTop = new NDockPanel();
			dockPanelLeftTop.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			dockPanelLeftTop.Location = new NPointL(new NLength(0, NRelativeUnit.ParentPercentage), new NLength(0, NRelativeUnit.ParentPercentage));
			dockPanelLeftTop.ChildPanels.Add(ConfigureLabel("2002", 90, new NLength(12, NGraphicsUnit.Point), ContentAlignment.TopLeft, PanelDockMode.Left));
			dockPanelLeftTop.ChildPanels.Add(ConfigurePieChart());
			contentPanel.ChildPanels.Add(dockPanelLeftTop);

			// configure four pie 2
			NDockPanel dockPanelRightTop = new NDockPanel();
			dockPanelRightTop.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			dockPanelRightTop.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(0, NRelativeUnit.ParentPercentage));
			dockPanelRightTop.ChildPanels.Add(ConfigureLabel("2003", 90, new NLength(12, NGraphicsUnit.Point), ContentAlignment.TopLeft, PanelDockMode.Left));
			dockPanelRightTop.ChildPanels.Add(ConfigurePieChart());
			contentPanel.ChildPanels.Add(dockPanelRightTop);

			// configure four pie 3
			NDockPanel dockPanelLeftBottom = new NDockPanel();
			dockPanelLeftBottom.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			dockPanelLeftBottom.Location = new NPointL(new NLength(0, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			dockPanelLeftBottom.ChildPanels.Add(ConfigureLabel("2004", 90, new NLength(12, NGraphicsUnit.Point), ContentAlignment.TopLeft, PanelDockMode.Left));
			dockPanelLeftBottom.ChildPanels.Add(ConfigurePieChart());
			contentPanel.ChildPanels.Add(dockPanelLeftBottom);

			// configure four pie 4
			NDockPanel dockPanelRightBottom = new NDockPanel();
			dockPanelRightBottom.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			dockPanelRightBottom.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			dockPanelRightBottom.ChildPanels.Add(ConfigureLabel("2005", 90, new NLength(12, NGraphicsUnit.Point), ContentAlignment.TopLeft, PanelDockMode.Left));
			dockPanelRightBottom.ChildPanels.Add(ConfigurePieChart());
			contentPanel.ChildPanels.Add(dockPanelRightBottom);
		}

		private NPanel ConfigureLabel(string text, float orientation, NLength fontSize, ContentAlignment contentAlignment, PanelDockMode dockMode)
		{
			NLabel label = new NLabel(text);
			label.TextStyle.BackplaneStyle.Visible = false;
			label.TextStyle.Orientation = orientation;
			label.TextStyle.FontStyle.EmSize = fontSize;
			label.ContentAlignment = contentAlignment;
			label.DockMode = PanelDockMode.Fill;
			label.BoundsMode = BoundsMode.Fit;
			label.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center;

			NWatermark labelHostPanel = new NWatermark();
			labelHostPanel.DockMode = dockMode;
			labelHostPanel.UseAutomaticSize = false;
			labelHostPanel.Size = new NSizeL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			labelHostPanel.ChildPanels.Add(label);

			return labelHostPanel;
		}
		private NPanel ConfigurePieChart()
		{
			// configure the chart bounds, contentalign, docking, light model and projection.
			NChart chart = new NPieChart();
			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Fit;
			chart.ContentAlignment = ContentAlignment.MiddleCenter;
			chart.DockMode = PanelDockMode.Fill;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);

			// create the pie series
			NPieSeries pie = new NPieSeries();
			chart.Series.Add(pie);
			pie.PieStyle = PieStyle.SmoothEdgePie;
			pie.DataLabelStyle.Format = "<percent>";
			pie.LabelMode = PieLabelMode.Center;
			pie.DataLabelStyle.TextStyle.BackplaneStyle.Visible = false;
			pie.DataLabelStyle.TextStyle.FontStyle.Style |= FontStyle.Bold;
			pie.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(12, NGraphicsUnit.Point);

			for (int i = 0; i < colors.Length; i++)
			{
				pie.AddDataPoint(new NDataPoint(Random.Next(10) + 5, new NColorFillStyle(colors[i])));
			}

			// create a watermark and nest the chart inside
			NWatermark chartHostPanel = new NWatermark();
			chartHostPanel.DockMode = PanelDockMode.Fill;
			chartHostPanel.ChildPanels.Add(chart);

			return chartHostPanel;
		}
		private NLegendItemCellData CreateLegendItem(string text, Color color)
		{
			NLegendItemCellData ldi = new NLegendItemCellData();
			ldi.Text = text;
			ldi.MarkFillStyle = new NColorFillStyle(color);
			ldi.MarkLineStyle.Width = new NLength(0);
			return ldi;
		}

		private void Rotate_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Timer.Enabled = Rotate.Checked;
		}
		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			NChartCollection charts = nChartControl1.Charts;

			for (int i = 0; i < charts.Count; i++)
			{
				NPieChart pieChart = (NPieChart)charts[i];
				float newBeginAngle = pieChart.BeginAngle + 5;

				if (newBeginAngle > 360)
				{
					newBeginAngle -= 360;
				}

				pieChart.BeginAngle = newBeginAngle;
			}

			nChartControl1.Refresh();
		}
	}
}
