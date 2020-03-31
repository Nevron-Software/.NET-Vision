using System;
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
	public class NLabelFitModesUC : NExampleBaseUC
    {
		private System.ComponentModel.Container components = null;
        private Label label8;
        private Nevron.UI.WinForm.Controls.NNumericUpDown PanelWidthNumericUpDown;
        private Nevron.UI.WinForm.Controls.NComboBox LabelFitModeComboBox;
        private Label label1;

        NDockPanel m_ContainerPanel;
		
		public NLabelFitModesUC()
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
			this.label8 = new System.Windows.Forms.Label();
			this.PanelWidthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.LabelFitModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PanelWidthNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(14, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(155, 20);
			this.label8.TabIndex = 2;
			this.label8.Text = "Panel Width (in percents):";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PanelWidthNumericUpDown
			// 
			this.PanelWidthNumericUpDown.Location = new System.Drawing.Point(14, 47);
			this.PanelWidthNumericUpDown.Name = "PanelWidthNumericUpDown";
			this.PanelWidthNumericUpDown.Size = new System.Drawing.Size(155, 20);
			this.PanelWidthNumericUpDown.TabIndex = 3;
			this.PanelWidthNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.PanelWidthNumericUpDown.ValueChanged += new System.EventHandler(this.PanelWidthNumericUpDown_ValueChanged);
			// 
			// LabelFitModeComboBox
			// 
			this.LabelFitModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.LabelFitModeComboBox.ListProperties.DataSource = null;
			this.LabelFitModeComboBox.ListProperties.DisplayMember = "";
			this.LabelFitModeComboBox.Location = new System.Drawing.Point(14, 105);
			this.LabelFitModeComboBox.Name = "LabelFitModeComboBox";
			this.LabelFitModeComboBox.Size = new System.Drawing.Size(155, 21);
			this.LabelFitModeComboBox.TabIndex = 5;
			this.LabelFitModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelFitModeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Label Fit Mode:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NLabelFitModesUC
			// 
			this.Controls.Add(this.LabelFitModeComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.PanelWidthNumericUpDown);
			this.Name = "NLabelFitModesUC";
			this.Size = new System.Drawing.Size(180, 542);
			((System.ComponentModel.ISupportInitialize)(this.PanelWidthNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NTrackballTool());
			nChartControl1.Panels.Clear();

            m_ContainerPanel = new NDockPanel();
            m_ContainerPanel.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
            m_ContainerPanel.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

			NLabel label = new NLabel("The control supports labels that can automatically scale, wrap or clip when the available space is not sufficient to accommodate them.");
			label.DockMode = PanelDockMode.Top;
			label.ContentAlignment = ContentAlignment.MiddleCenter;
            label.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			label.TextStyle.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
            label.Padding = new NMarginsL(10, 10, 10, 10);
            label.Margins = new NMarginsL(0, 0, 0, 10);

            // apply border to the label
            NEdgeBorderStyle labelBorder = new NEdgeBorderStyle();
            labelBorder.OuterBevelWidth = new NLength(0);
            labelBorder.InnerBevelWidth = new NLength(0);
            labelBorder.MiddleBevelFillStyle = new NColorFillStyle(Color.Black);
            label.BorderStyle = labelBorder;
            m_ContainerPanel.ChildPanels.Add(label);

			NCartesianChart chart = new NCartesianChart();
            m_ContainerPanel.ChildPanels.Add(chart);
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
            chart.Padding = new NMarginsL(10, 10, 10, 10);
            chart.DockMode = PanelDockMode.Fill;

            // apply border to the chart
            NEdgeBorderStyle chartBorder = new NEdgeBorderStyle();
            chartBorder.OuterBevelWidth = new NLength(0);
            chartBorder.InnerBevelWidth = new NLength(0);
            chartBorder.MiddleBevelFillStyle = new NColorFillStyle(Color.Black);
            chart.BorderStyle = chartBorder;

			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red);
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.DataLabelStyle.Visible = false;
			bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			bar.ShadowStyle.Offset = new NPointL(3, 3);
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(5);
			bar.Values.AddRange(monthValues);

            nChartControl1.Panels.Add(m_ContainerPanel);

            LabelFitModeComboBox.FillFromEnum(typeof(TitleFitMode));
            LabelFitModeComboBox.SelectedIndex = (int)TitleFitMode.Wrap;

            PanelWidthNumericUpDown.Value = 80;

			nChartControl1.Refresh();
		}

        private void PanelWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
			if (nChartControl1 == null)
				return;

            m_ContainerPanel.Size = new NSizeL(new NLength((float)PanelWidthNumericUpDown.Value, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            nChartControl1.Refresh();
        }

        private void LabelFitModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (nChartControl1 == null)
				return;

            nChartControl1.Labels[0].FitMode = (TitleFitMode)LabelFitModeComboBox.SelectedIndex;
            nChartControl1.Refresh();
        }
	}
}
