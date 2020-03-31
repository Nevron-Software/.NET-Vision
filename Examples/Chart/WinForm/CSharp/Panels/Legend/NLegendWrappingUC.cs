using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLegendWrappingUC : NExampleBaseUC
	{
        NChart m_Chart;
        NLegend m_Legend;

        NBarSeries m_Bar1;
        NBarSeries m_Bar2;
        NBarSeries m_Bar3;

        private Label label8;
        private Nevron.UI.WinForm.Controls.NNumericUpDown LegendWidthNumericUpDown;
        private Nevron.UI.WinForm.Controls.NComboBox FitAlignmentComboBox;
        private Label label1;
        private Nevron.UI.WinForm.Controls.NRadioButton VertWrapRadioButton;
        private Nevron.UI.WinForm.Controls.NRadioButton HorzWrapRadioButton;
        private Label label2;
        private Nevron.UI.WinForm.Controls.NNumericUpDown DataPointsPerSeriesNumericUpDown;
		private System.ComponentModel.Container components = null;

		public NLegendWrappingUC()
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
			this.LegendWidthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.FitAlignmentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.VertWrapRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.HorzWrapRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.DataPointsPerSeriesNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.LegendWidthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DataPointsPerSeriesNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(171, 20);
			this.label8.TabIndex = 0;
			this.label8.Text = "Legend Width (in percents):";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LegendWidthNumericUpDown
			// 
			this.LegendWidthNumericUpDown.Location = new System.Drawing.Point(6, 38);
			this.LegendWidthNumericUpDown.Name = "LegendWidthNumericUpDown";
			this.LegendWidthNumericUpDown.Size = new System.Drawing.Size(171, 20);
			this.LegendWidthNumericUpDown.TabIndex = 1;
			this.LegendWidthNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.LegendWidthNumericUpDown.ValueChanged += new System.EventHandler(this.LegendWidthNumericUpDown_ValueChanged);
			// 
			// FitAlignmentComboBox
			// 
			this.FitAlignmentComboBox.ListProperties.CheckBoxDataMember = "";
			this.FitAlignmentComboBox.ListProperties.DataSource = null;
			this.FitAlignmentComboBox.ListProperties.DisplayMember = "";
			this.FitAlignmentComboBox.Location = new System.Drawing.Point(3, 202);
			this.FitAlignmentComboBox.Name = "FitAlignmentComboBox";
			this.FitAlignmentComboBox.Size = new System.Drawing.Size(171, 21);
			this.FitAlignmentComboBox.TabIndex = 5;
			this.FitAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.FitAlignmentComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 180);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(175, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Fit Alignement:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VertWrapRadioButton
			// 
			this.VertWrapRadioButton.ButtonProperties.BorderOffset = 2;
			this.VertWrapRadioButton.Location = new System.Drawing.Point(3, 144);
			this.VertWrapRadioButton.Name = "VertWrapRadioButton";
			this.VertWrapRadioButton.Size = new System.Drawing.Size(175, 24);
			this.VertWrapRadioButton.TabIndex = 3;
			this.VertWrapRadioButton.Text = "Vertical Wrap";
			this.VertWrapRadioButton.CheckedChanged += new System.EventHandler(this.VertWrapRadioButton_CheckedChanged);
			// 
			// HorzWrapRadioButton
			// 
			this.HorzWrapRadioButton.ButtonProperties.BorderOffset = 2;
			this.HorzWrapRadioButton.Location = new System.Drawing.Point(3, 124);
			this.HorzWrapRadioButton.Name = "HorzWrapRadioButton";
			this.HorzWrapRadioButton.Size = new System.Drawing.Size(175, 24);
			this.HorzWrapRadioButton.TabIndex = 2;
			this.HorzWrapRadioButton.Text = "Horizontal Wrap";
			this.HorzWrapRadioButton.CheckedChanged += new System.EventHandler(this.HorzWrapRadioButton_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Data Points Per Series:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataPointsPerSeriesNumericUpDown
			// 
			this.DataPointsPerSeriesNumericUpDown.Location = new System.Drawing.Point(6, 88);
			this.DataPointsPerSeriesNumericUpDown.Name = "DataPointsPerSeriesNumericUpDown";
			this.DataPointsPerSeriesNumericUpDown.Size = new System.Drawing.Size(171, 20);
			this.DataPointsPerSeriesNumericUpDown.TabIndex = 7;
			this.DataPointsPerSeriesNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.DataPointsPerSeriesNumericUpDown.ValueChanged += new System.EventHandler(this.DataPointsPerSeriesNumericUpDown_ValueChanged);
			// 
			// NLegendWrappingUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DataPointsPerSeriesNumericUpDown);
			this.Controls.Add(this.VertWrapRadioButton);
			this.Controls.Add(this.HorzWrapRadioButton);
			this.Controls.Add(this.FitAlignmentComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.LegendWidthNumericUpDown);
			this.Name = "NLegendWrappingUC";
			this.Size = new System.Drawing.Size(180, 680);
			((System.ComponentModel.ISupportInitialize)(this.LegendWidthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DataPointsPerSeriesNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// confgigure chart
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Legend Horizontal and Vertical Wrapping");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
            header.DockMode = PanelDockMode.Top;
            header.Margins = new NMarginsL(0, 10, 0, 10);
			nChartControl1.Panels.Add(header);

            NDockPanel container = new NDockPanel();
            container.DockMode = PanelDockMode.Fill;
            container.Margins = new NMarginsL(10, 10, 10, 10);
            container.PositionChildPanelsInContentBounds = true;
            nChartControl1.Panels.Add(container);

            // configure the legend
            m_Legend = new NLegend();
            m_Legend.Data.ExpandMode = LegendExpandMode.HorzWrap;
            m_Legend.Location = new NPointL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(0));
            m_Legend.BoundsMode = BoundsMode.None;
            m_Legend.Size = new NSizeL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
            m_Legend.UseAutomaticSize = false;
            container.ChildPanels.Add(m_Legend);

            // configure the chart
            m_Chart = new NCartesianChart();
            container.ChildPanels.Add(m_Chart);
            m_Chart.BoundsMode = BoundsMode.Stretch;
            m_Chart.Margins = new NMarginsL(0, 0, 10, 0);
            m_Chart.Location = new NPointL(new NLength(0), new NLength(0));
            m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
            m_Chart.DisplayOnLegend = m_Legend;
            m_Chart.Axis(StandardAxis.Depth).Visible = false;
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // add the first bar
            m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
            m_Bar1.Name = "Bar1";
            m_Bar1.MultiBarMode = MultiBarMode.Series;
            m_Bar1.Legend.Mode = SeriesLegendMode.DataPoints;
            m_Bar1.DataLabelStyle.Visible = false;

            // add the second bar
            m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
            m_Bar2.Name = "Bar2";
            m_Bar2.MultiBarMode = MultiBarMode.Stacked;
            m_Bar2.Legend.Mode = SeriesLegendMode.DataPoints;
            m_Bar2.DataLabelStyle.Visible = false;

            // add the third bar
            m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
            m_Bar3.Name = "Bar3";
            m_Bar3.Legend.Mode = SeriesLegendMode.DataPoints;
            m_Bar3.DataLabelStyle.Visible = false;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            string[] names = Enum.GetNames(typeof(ContentAlignment));
            for (int i = 0; i < names.Length; i++)
            {
                FitAlignmentComboBox.Items.Add(names[i]);
            }

            FitAlignmentComboBox.SelectedItem = ContentAlignment.TopCenter.ToString();
            LegendWidthNumericUpDown.Value = 30;
            DataPointsPerSeriesNumericUpDown.Value = 10;
            HorzWrapRadioButton.Checked = true;

            DataPointsPerSeriesNumericUpDown_ValueChanged(null, null);
		}

        private void LegendWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (m_Legend == null)
                return;

            NLength legendWidth = new NLength((float)LegendWidthNumericUpDown.Value, NRelativeUnit.ParentPercentage);
            NLength chartWidth = new NLength(100 - (float)LegendWidthNumericUpDown.Value, NRelativeUnit.ParentPercentage);

            m_Legend.Size = new NSizeL(legendWidth, m_Legend.Size.Height);
            m_Legend.Location = new NPointL(chartWidth, m_Legend.Location.Y);
            m_Chart.Size = new NSizeL(chartWidth, m_Chart.Size.Height);

            nChartControl1.Refresh();
        }

        private void FitAlignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Legend == null)
                return;

            Array values = Enum.GetValues(typeof(ContentAlignment));
            m_Legend.FitAlignment = (ContentAlignment)values.GetValue(FitAlignmentComboBox.SelectedIndex);

            nChartControl1.Refresh();
        }

        private void HorzWrapRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Legend == null)
                return;

            m_Legend.Data.ExpandMode = LegendExpandMode.HorzWrap;
            nChartControl1.Refresh();
        }

        private void VertWrapRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Legend == null)
                return;

            m_Legend.Data.ExpandMode = LegendExpandMode.VertWrap;
            nChartControl1.Refresh();
        }

        private void DataPointsPerSeriesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (m_Bar1 == null || m_Bar2 == null || m_Bar3 == null)
                return;

            // add some random data
            int nDataPointCount = (int)DataPointsPerSeriesNumericUpDown.Value;

            m_Bar1.Values.FillRandomRange(Random, nDataPointCount, 20, 100);
            m_Bar2.Values.FillRandomRange(Random, nDataPointCount, 20, 100);
            m_Bar3.Values.FillRandomRange(Random, nDataPointCount, 20, 100);

            nChartControl1.Refresh();
        }
	}
}
