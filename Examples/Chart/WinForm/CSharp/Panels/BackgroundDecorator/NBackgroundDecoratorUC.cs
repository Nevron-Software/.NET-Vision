using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NBackgroundDecoratorUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox DockTitleComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox DockLegendComboBox;
		private NBackgroundDecoratorPanel m_LabelBackgroundPanel;
		private NBackgroundDecoratorPanel m_LegendBackgroundPanel;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NBackgroundDecoratorUC()
		{
			// This call is required by the Windows.Forms Form Designer.
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.DockTitleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.DockLegendComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Dock Title:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Dock Legend:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// DockTitleComboBox
			// 
			this.DockTitleComboBox.ListProperties.CheckBoxDataMember = "";
			this.DockTitleComboBox.ListProperties.DataSource = null;
			this.DockTitleComboBox.ListProperties.DisplayMember = "";
			this.DockTitleComboBox.Location = new System.Drawing.Point(5, 40);
			this.DockTitleComboBox.Name = "DockTitleComboBox";
			this.DockTitleComboBox.Size = new System.Drawing.Size(171, 21);
			this.DockTitleComboBox.TabIndex = 1;
			this.DockTitleComboBox.Text = "comboBox1";
			this.DockTitleComboBox.SelectedIndexChanged += new System.EventHandler(this.DockTitleComboBox_SelectedIndexChanged);
			// 
			// DockLegendComboBox
			// 
			this.DockLegendComboBox.ListProperties.CheckBoxDataMember = "";
			this.DockLegendComboBox.ListProperties.DataSource = null;
			this.DockLegendComboBox.ListProperties.DisplayMember = "";
			this.DockLegendComboBox.Location = new System.Drawing.Point(5, 112);
			this.DockLegendComboBox.Name = "DockLegendComboBox";
			this.DockLegendComboBox.Size = new System.Drawing.Size(171, 21);
			this.DockLegendComboBox.TabIndex = 3;
			this.DockLegendComboBox.Text = "comboBox2";
			this.DockLegendComboBox.SelectedIndexChanged += new System.EventHandler(this.DockLegendComboBox_SelectedIndexChanged);
			// 
			// NBackgroundDecoratorUC
			// 
			this.Controls.Add(this.DockLegendComboBox);
			this.Controls.Add(this.DockTitleComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NBackgroundDecoratorUC";
			this.Size = new System.Drawing.Size(180, 256);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			Nevron.UI.WinForm.Controls.NPalette palette = Nevron.UI.WinForm.Controls.NUIManager.Palette;

			// Clear the chart panels
			nChartControl1.Panels.Clear();
			// Create a background style to assign to the new panels
			NBackgroundStyle backroundStyle = new NBackgroundStyle();
			backroundStyle.FillStyle = new NColorFillStyle(Color.Transparent);
			NImageFrameStyle frameStyle = new NImageFrameStyle();
			frameStyle.BorderStyle.Color = palette.ControlDark;
			frameStyle.BackgroundColor = Color.Transparent;
			frameStyle.Type = ImageFrameType.Raised;
			backroundStyle.FrameStyle = frameStyle;

			// Create the label background panel
			m_LabelBackgroundPanel = new NBackgroundDecoratorPanel();
			m_LabelBackgroundPanel.Size = new NSizeL(new NLength(0, NGraphicsUnit.Pixel), new NLength(10, NRelativeUnit.ParentPercentage));
			m_LabelBackgroundPanel.DockMode = PanelDockMode.Top;
			m_LabelBackgroundPanel.DockMargins = new NMarginsL(new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point));
			m_LabelBackgroundPanel.BackgroundStyle = (NBackgroundStyle)backroundStyle.Clone();
			nChartControl1.Panels.Add(m_LabelBackgroundPanel);

			// Create the legend background panel
			m_LegendBackgroundPanel = new NBackgroundDecoratorPanel();
			m_LegendBackgroundPanel.Size = new NSizeL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(0, NGraphicsUnit.Pixel));
			m_LegendBackgroundPanel.DockMode = PanelDockMode.Right;
			m_LegendBackgroundPanel.BackgroundStyle = (NBackgroundStyle)backroundStyle.Clone();
			m_LegendBackgroundPanel.DockMargins = new NMarginsL(new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point));
			nChartControl1.Panels.Add(m_LegendBackgroundPanel);

			// Create the chart background panel
			NBackgroundDecoratorPanel chartBackgroundPanel = new NBackgroundDecoratorPanel();
			chartBackgroundPanel.BackgroundStyle = (NBackgroundStyle)backroundStyle.Clone();
			chartBackgroundPanel.DockMode = PanelDockMode.Fill;
			chartBackgroundPanel.DockMargins = new NMarginsL(new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point));
			nChartControl1.Panels.Add(chartBackgroundPanel);

			// Create the header label and host it in the label background panel
			NLabel title = new NLabel("Background Decorator Panel");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.SlateGray);
			title.ContentAlignment = ContentAlignment.MiddleCenter;
			title.DockMode = PanelDockMode.Fill;
			title.BoundsMode = BoundsMode.Fit;
			title.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			title.DockMargins = new NMarginsL(frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize);

			m_LabelBackgroundPanel.ChildPanels.Add(title);

			// Create the legend and host it in the legend background panel
			NLegend legend = new NLegend();
			legend.DockMode = PanelDockMode.Fill;
			legend.ContentAlignment = ContentAlignment.MiddleCenter;
			legend.DockMargins = new NMarginsL(frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize);
			m_LegendBackgroundPanel.ChildPanels.Add(legend);

			// Create a cartesian chart and host it in the chart background panel
			NChart chart = new NCartesianChart();
			chartBackgroundPanel.ChildPanels.Add(chart);
			chart.DisplayOnLegend = legend;
			chart.BoundsMode = BoundsMode.Stretch;

			// add bar and change bar color
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.Legend.Mode = SeriesLegendMode.DataPoints;
			bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			bar.ShadowStyle.Offset = new NPointL(3, 3);
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(5);

			// add some data to the bar series
			bar.AddDataPoint(new NDataPoint(18, "C++"));
			bar.AddDataPoint(new NDataPoint(15, "Ruby"));
			bar.AddDataPoint(new NDataPoint(21, "Python"));
			bar.AddDataPoint(new NDataPoint(23, "Java"));
			bar.AddDataPoint(new NDataPoint(27, "Javascript"));
			bar.AddDataPoint(new NDataPoint(29, "C#"));
			bar.AddDataPoint(new NDataPoint(26, "PHP"));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			DockTitleComboBox.Items.Add("Top");
			DockTitleComboBox.Items.Add("Bottom");
			DockTitleComboBox.SelectedIndex = 0;

			DockLegendComboBox.Items.Add("Left");
			DockLegendComboBox.Items.Add("Right");
			DockLegendComboBox.SelectedIndex = 1;
		}

		private void DockTitleComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DockTitleComboBox.SelectedIndex == 0)
			{
				m_LabelBackgroundPanel.DockMode = PanelDockMode.Top;
			}
			else
			{
				m_LabelBackgroundPanel.DockMode = PanelDockMode.Bottom;
			}

			nChartControl1.Refresh();
		}

		private void DockLegendComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DockLegendComboBox.SelectedIndex == 0)
			{
				m_LegendBackgroundPanel.DockMode = PanelDockMode.Left;
			}
			else
			{
				m_LegendBackgroundPanel.DockMode = PanelDockMode.Right;
			}		

			nChartControl1.Refresh();
		}
	}
}
