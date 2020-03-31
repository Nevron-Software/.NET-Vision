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
	public class NLegendSeriesAssignmentUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private NBarSeries m_Bar3;
		private bool m_bUpdateLegends;
		private Nevron.UI.WinForm.Controls.NButton FirstTextStyleButton;
		private Nevron.UI.WinForm.Controls.NButton SecondTextStyleButton;
		private Nevron.UI.WinForm.Controls.NButton ThirdTextStyleButton;
		private Nevron.UI.WinForm.Controls.NButton PositiveDataButton;
		private Nevron.UI.WinForm.Controls.NButton PositiveAndNegativeDataButton;
		private Nevron.UI.WinForm.Controls.NComboBox FirstDisplayOnLegendComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox SecondDisplayOnLegendComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox ThirdDisplayOnLegendComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox FirstSeriesLegendModeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox SecondSeriesLegendModeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox ThirdSeriesLegendModeComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox DataGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox FirstSerieGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox SecondSerieGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox ThirdSerieGroupBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown DataPointsNumericUpDown;
		private Nevron.UI.WinForm.Controls.NTextBox FirstSeriesFormatTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox SecondSeriesFormatTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox ThirdSeriesFormatTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.ComponentModel.Container components = null;

		public NLegendSeriesAssignmentUC()
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
			this.FirstSerieGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.FirstDisplayOnLegendComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.FirstSeriesLegendModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.FirstSeriesFormatTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.FirstTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SecondSerieGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.SecondDisplayOnLegendComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SecondSeriesLegendModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SecondSeriesFormatTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SecondTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ThirdSerieGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.ThirdDisplayOnLegendComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ThirdSeriesLegendModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ThirdSeriesFormatTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.ThirdTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveAndNegativeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label8 = new System.Windows.Forms.Label();
			this.DataPointsNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.DataGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.FirstSerieGroupBox.SuspendLayout();
			this.SecondSerieGroupBox.SuspendLayout();
			this.ThirdSerieGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataPointsNumericUpDown)).BeginInit();
			this.DataGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// FirstSerieGroupBox
			// 
			this.FirstSerieGroupBox.Controls.Add(this.label3);
			this.FirstSerieGroupBox.Controls.Add(this.label5);
			this.FirstSerieGroupBox.Controls.Add(this.label10);
			this.FirstSerieGroupBox.Controls.Add(this.FirstDisplayOnLegendComboBox);
			this.FirstSerieGroupBox.Controls.Add(this.FirstSeriesLegendModeComboBox);
			this.FirstSerieGroupBox.Controls.Add(this.FirstSeriesFormatTextBox);
			this.FirstSerieGroupBox.Controls.Add(this.FirstTextStyleButton);
			this.FirstSerieGroupBox.ImageIndex = 0;
			this.FirstSerieGroupBox.Location = new System.Drawing.Point(8, 0);
			this.FirstSerieGroupBox.Name = "FirstSerieGroupBox";
			this.FirstSerieGroupBox.Size = new System.Drawing.Size(168, 184);
			this.FirstSerieGroupBox.TabIndex = 0;
			this.FirstSerieGroupBox.TabStop = false;
			this.FirstSerieGroupBox.Text = "First series";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Display on legend:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 63);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Series legend mode:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 110);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(152, 16);
			this.label10.TabIndex = 6;
			this.label10.Text = "Format:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FirstDisplayOnLegendComboBox
			// 
			this.FirstDisplayOnLegendComboBox.ListProperties.CheckBoxDataMember = "";
			this.FirstDisplayOnLegendComboBox.ListProperties.DataSource = null;
			this.FirstDisplayOnLegendComboBox.ListProperties.DisplayMember = "";
			this.FirstDisplayOnLegendComboBox.Location = new System.Drawing.Point(8, 37);
			this.FirstDisplayOnLegendComboBox.Name = "FirstDisplayOnLegendComboBox";
			this.FirstDisplayOnLegendComboBox.Size = new System.Drawing.Size(152, 21);
			this.FirstDisplayOnLegendComboBox.TabIndex = 6;
			this.FirstDisplayOnLegendComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstDisplayOnLegendComboBox_SelectedIndexChanged);
			// 
			// FirstSeriesLegendModeComboBox
			// 
			this.FirstSeriesLegendModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.FirstSeriesLegendModeComboBox.ListProperties.DataSource = null;
			this.FirstSeriesLegendModeComboBox.ListProperties.DisplayMember = "";
			this.FirstSeriesLegendModeComboBox.Location = new System.Drawing.Point(8, 84);
			this.FirstSeriesLegendModeComboBox.Name = "FirstSeriesLegendModeComboBox";
			this.FirstSeriesLegendModeComboBox.Size = new System.Drawing.Size(152, 21);
			this.FirstSeriesLegendModeComboBox.TabIndex = 6;
			this.FirstSeriesLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstSeriesLegendModeComboBox_SelectedIndexChanged);
			// 
			// FirstSeriesFormatTextBox
			// 
			this.FirstSeriesFormatTextBox.Location = new System.Drawing.Point(8, 131);
			this.FirstSeriesFormatTextBox.Name = "FirstSeriesFormatTextBox";
			this.FirstSeriesFormatTextBox.Size = new System.Drawing.Size(152, 18);
			this.FirstSeriesFormatTextBox.TabIndex = 6;
			this.FirstSeriesFormatTextBox.Text = "FirstSeriesFormatTextBox";
			this.FirstSeriesFormatTextBox.TextChanged += new System.EventHandler(this.FirstSeriesFormatTextBox_TextChanged);
			// 
			// FirstTextStyleButton
			// 
			this.FirstTextStyleButton.Location = new System.Drawing.Point(8, 156);
			this.FirstTextStyleButton.Name = "FirstTextStyleButton";
			this.FirstTextStyleButton.Size = new System.Drawing.Size(152, 23);
			this.FirstTextStyleButton.TabIndex = 3;
			this.FirstTextStyleButton.Text = "Text Style";
			this.FirstTextStyleButton.Click += new System.EventHandler(this.FirstTextStyleButton_Click);
			// 
			// SecondSerieGroupBox
			// 
			this.SecondSerieGroupBox.Controls.Add(this.label1);
			this.SecondSerieGroupBox.Controls.Add(this.label6);
			this.SecondSerieGroupBox.Controls.Add(this.label9);
			this.SecondSerieGroupBox.Controls.Add(this.SecondDisplayOnLegendComboBox);
			this.SecondSerieGroupBox.Controls.Add(this.SecondSeriesLegendModeComboBox);
			this.SecondSerieGroupBox.Controls.Add(this.SecondSeriesFormatTextBox);
			this.SecondSerieGroupBox.Controls.Add(this.SecondTextStyleButton);
			this.SecondSerieGroupBox.ImageIndex = 0;
			this.SecondSerieGroupBox.Location = new System.Drawing.Point(8, 184);
			this.SecondSerieGroupBox.Name = "SecondSerieGroupBox";
			this.SecondSerieGroupBox.Size = new System.Drawing.Size(168, 184);
			this.SecondSerieGroupBox.TabIndex = 1;
			this.SecondSerieGroupBox.TabStop = false;
			this.SecondSerieGroupBox.Text = "Second series";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Display on legend:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(152, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Series legend mode:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 104);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(152, 16);
			this.label9.TabIndex = 5;
			this.label9.Text = "Format:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SecondDisplayOnLegendComboBox
			// 
			this.SecondDisplayOnLegendComboBox.ListProperties.CheckBoxDataMember = "";
			this.SecondDisplayOnLegendComboBox.ListProperties.DataSource = null;
			this.SecondDisplayOnLegendComboBox.ListProperties.DisplayMember = "";
			this.SecondDisplayOnLegendComboBox.Location = new System.Drawing.Point(8, 32);
			this.SecondDisplayOnLegendComboBox.Name = "SecondDisplayOnLegendComboBox";
			this.SecondDisplayOnLegendComboBox.Size = new System.Drawing.Size(152, 21);
			this.SecondDisplayOnLegendComboBox.TabIndex = 7;
			this.SecondDisplayOnLegendComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondDisplayOnLegendComboBox_SelectedIndexChanged);
			// 
			// SecondSeriesLegendModeComboBox
			// 
			this.SecondSeriesLegendModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.SecondSeriesLegendModeComboBox.ListProperties.DataSource = null;
			this.SecondSeriesLegendModeComboBox.ListProperties.DisplayMember = "";
			this.SecondSeriesLegendModeComboBox.Location = new System.Drawing.Point(8, 80);
			this.SecondSeriesLegendModeComboBox.Name = "SecondSeriesLegendModeComboBox";
			this.SecondSeriesLegendModeComboBox.Size = new System.Drawing.Size(152, 21);
			this.SecondSeriesLegendModeComboBox.TabIndex = 7;
			this.SecondSeriesLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondSeriesLegendModeComboBox_SelectedIndexChanged);
			// 
			// SecondSeriesFormatTextBox
			// 
			this.SecondSeriesFormatTextBox.Location = new System.Drawing.Point(8, 128);
			this.SecondSeriesFormatTextBox.Name = "SecondSeriesFormatTextBox";
			this.SecondSeriesFormatTextBox.Size = new System.Drawing.Size(152, 18);
			this.SecondSeriesFormatTextBox.TabIndex = 7;
			this.SecondSeriesFormatTextBox.Text = "textBox1";
			this.SecondSeriesFormatTextBox.TextChanged += new System.EventHandler(this.SecondSeriesFormatTextBox_TextChanged);
			// 
			// SecondTextStyleButton
			// 
			this.SecondTextStyleButton.Location = new System.Drawing.Point(8, 152);
			this.SecondTextStyleButton.Name = "SecondTextStyleButton";
			this.SecondTextStyleButton.Size = new System.Drawing.Size(152, 23);
			this.SecondTextStyleButton.TabIndex = 4;
			this.SecondTextStyleButton.Text = "Text Style";
			this.SecondTextStyleButton.Click += new System.EventHandler(this.SecondTextStyleButton_Click);
			// 
			// ThirdSerieGroupBox
			// 
			this.ThirdSerieGroupBox.Controls.Add(this.label2);
			this.ThirdSerieGroupBox.Controls.Add(this.label4);
			this.ThirdSerieGroupBox.Controls.Add(this.label7);
			this.ThirdSerieGroupBox.Controls.Add(this.ThirdDisplayOnLegendComboBox);
			this.ThirdSerieGroupBox.Controls.Add(this.ThirdSeriesLegendModeComboBox);
			this.ThirdSerieGroupBox.Controls.Add(this.ThirdSeriesFormatTextBox);
			this.ThirdSerieGroupBox.Controls.Add(this.ThirdTextStyleButton);
			this.ThirdSerieGroupBox.ImageIndex = 0;
			this.ThirdSerieGroupBox.Location = new System.Drawing.Point(8, 368);
			this.ThirdSerieGroupBox.Name = "ThirdSerieGroupBox";
			this.ThirdSerieGroupBox.Size = new System.Drawing.Size(168, 184);
			this.ThirdSerieGroupBox.TabIndex = 2;
			this.ThirdSerieGroupBox.TabStop = false;
			this.ThirdSerieGroupBox.Text = "Third series";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Display on legend:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Series legend mode:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 110);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(152, 16);
			this.label7.TabIndex = 3;
			this.label7.Text = "Format:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ThirdDisplayOnLegendComboBox
			// 
			this.ThirdDisplayOnLegendComboBox.ListProperties.CheckBoxDataMember = "";
			this.ThirdDisplayOnLegendComboBox.ListProperties.DataSource = null;
			this.ThirdDisplayOnLegendComboBox.ListProperties.DisplayMember = "";
			this.ThirdDisplayOnLegendComboBox.Location = new System.Drawing.Point(8, 37);
			this.ThirdDisplayOnLegendComboBox.Name = "ThirdDisplayOnLegendComboBox";
			this.ThirdDisplayOnLegendComboBox.Size = new System.Drawing.Size(152, 21);
			this.ThirdDisplayOnLegendComboBox.TabIndex = 8;
			this.ThirdDisplayOnLegendComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdDisplayOnLegendComboBox_SelectedIndexChanged);
			// 
			// ThirdSeriesLegendModeComboBox
			// 
			this.ThirdSeriesLegendModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.ThirdSeriesLegendModeComboBox.ListProperties.DataSource = null;
			this.ThirdSeriesLegendModeComboBox.ListProperties.DisplayMember = "";
			this.ThirdSeriesLegendModeComboBox.Location = new System.Drawing.Point(8, 84);
			this.ThirdSeriesLegendModeComboBox.Name = "ThirdSeriesLegendModeComboBox";
			this.ThirdSeriesLegendModeComboBox.Size = new System.Drawing.Size(152, 21);
			this.ThirdSeriesLegendModeComboBox.TabIndex = 8;
			this.ThirdSeriesLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdSeriesLegendModeComboBox_SelectedIndexChanged);
			// 
			// ThirdSeriesFormatTextBox
			// 
			this.ThirdSeriesFormatTextBox.Location = new System.Drawing.Point(8, 131);
			this.ThirdSeriesFormatTextBox.Name = "ThirdSeriesFormatTextBox";
			this.ThirdSeriesFormatTextBox.Size = new System.Drawing.Size(152, 18);
			this.ThirdSeriesFormatTextBox.TabIndex = 8;
			this.ThirdSeriesFormatTextBox.Text = "textBox1";
			this.ThirdSeriesFormatTextBox.TextChanged += new System.EventHandler(this.ThirdSeriesFormatTextBox_TextChanged);
			// 
			// ThirdTextStyleButton
			// 
			this.ThirdTextStyleButton.Location = new System.Drawing.Point(8, 156);
			this.ThirdTextStyleButton.Name = "ThirdTextStyleButton";
			this.ThirdTextStyleButton.Size = new System.Drawing.Size(152, 23);
			this.ThirdTextStyleButton.TabIndex = 5;
			this.ThirdTextStyleButton.Text = "Text Style";
			this.ThirdTextStyleButton.Click += new System.EventHandler(this.ThirdTextStyleButton_Click);
			// 
			// PositiveDataButton
			// 
			this.PositiveDataButton.Location = new System.Drawing.Point(8, 64);
			this.PositiveDataButton.Name = "PositiveDataButton";
			this.PositiveDataButton.Size = new System.Drawing.Size(152, 23);
			this.PositiveDataButton.TabIndex = 3;
			this.PositiveDataButton.Text = "Positive data";
			this.PositiveDataButton.Click += new System.EventHandler(this.PositiveDataButton_Click);
			// 
			// PositiveAndNegativeDataButton
			// 
			this.PositiveAndNegativeDataButton.Location = new System.Drawing.Point(8, 88);
			this.PositiveAndNegativeDataButton.Name = "PositiveAndNegativeDataButton";
			this.PositiveAndNegativeDataButton.Size = new System.Drawing.Size(152, 23);
			this.PositiveAndNegativeDataButton.TabIndex = 4;
			this.PositiveAndNegativeDataButton.Text = "Positive and Negative data";
			this.PositiveAndNegativeDataButton.Click += new System.EventHandler(this.PositiveAndNegativeDataButton_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 20);
			this.label8.TabIndex = 5;
			this.label8.Text = "Data points:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataPointsNumericUpDown
			// 
			this.DataPointsNumericUpDown.Location = new System.Drawing.Point(80, 32);
			this.DataPointsNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.DataPointsNumericUpDown.Name = "DataPointsNumericUpDown";
			this.DataPointsNumericUpDown.Size = new System.Drawing.Size(80, 20);
			this.DataPointsNumericUpDown.TabIndex = 0;
			this.DataPointsNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// DataGroupBox
			// 
			this.DataGroupBox.Controls.Add(this.label8);
			this.DataGroupBox.Controls.Add(this.PositiveAndNegativeDataButton);
			this.DataGroupBox.Controls.Add(this.DataPointsNumericUpDown);
			this.DataGroupBox.Controls.Add(this.PositiveDataButton);
			this.DataGroupBox.Location = new System.Drawing.Point(8, 552);
			this.DataGroupBox.Name = "DataGroupBox";
			this.DataGroupBox.Size = new System.Drawing.Size(168, 120);
			this.DataGroupBox.TabIndex = 6;
			this.DataGroupBox.TabStop = false;
			this.DataGroupBox.Text = "Data";
			// 
			// NLegendSeriesAssignmentUC
			// 
			this.Controls.Add(this.DataGroupBox);
			this.Controls.Add(this.ThirdSerieGroupBox);
			this.Controls.Add(this.SecondSerieGroupBox);
			this.Controls.Add(this.FirstSerieGroupBox);
			this.Name = "NLegendSeriesAssignmentUC";
			this.Size = new System.Drawing.Size(180, 680);
			this.FirstSerieGroupBox.ResumeLayout(false);
			this.SecondSerieGroupBox.ResumeLayout(false);
			this.ThirdSerieGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataPointsNumericUpDown)).EndInit();
			this.DataGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// confgigure chart
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Series Legend Assignment");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
            header.DockMode = PanelDockMode.Top;
            header.Margins = new NMarginsL(0, 10, 0, 10);
			nChartControl1.Panels.Add(header);

			// configure the legends
            NLegend leftLegend = new NLegend();
            leftLegend.DockMode = PanelDockMode.Left;
            leftLegend.Mode = LegendMode.Automatic;
            leftLegend.Data.ExpandMode = LegendExpandMode.ColsFixed;
            leftLegend.Data.ColCount = 2;
            leftLegend.BoundsMode = BoundsMode.Fit;
            leftLegend.Margins = new NMarginsL(10, 0, 0, 0);
            nChartControl1.Panels.Add(leftLegend);

			NLegend rightLegend = new NLegend();
            rightLegend.DockMode = PanelDockMode.Right;
			rightLegend.Data.ExpandMode = LegendExpandMode.ColsFixed;
			rightLegend.Data.ColCount = 2;
			rightLegend.Mode = LegendMode.Automatic;
			rightLegend.BoundsMode = BoundsMode.Fit;
            rightLegend.Margins = new NMarginsL(0, 0, 10, 0);
			nChartControl1.Panels.Add(rightLegend);

            // create the chart
			m_Chart = new NCartesianChart();
			m_Chart.Enable3D = true;
			m_Chart.DockMode = PanelDockMode.Fill;
			m_Chart.BoundsMode = BoundsMode.Fit;

            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            m_Chart.Margins = new NMarginsL(28, 10, 20, 10);
            
			nChartControl1.Panels.Add(m_Chart);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add the first bar
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.MultiBarMode = MultiBarMode.Series;

			// add the second bar
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.MultiBarMode = MultiBarMode.Stacked;

			// add the third bar
			m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar3.Name = "Bar3";
			m_Bar3.MultiBarMode = MultiBarMode.Stacked;

			// position data labels in the center of the bars
			m_Bar1.DataLabelStyle.Visible = true;
            m_Bar1.DataLabelStyle.VertAlign = VertAlign.Center;
            m_Bar1.DataLabelStyle.Format = "<value>";

            m_Bar2.DataLabelStyle.Visible = true;
            m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center;
            m_Bar2.DataLabelStyle.Format = "<value>";

            m_Bar3.DataLabelStyle.Visible = true;
            m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center;
            m_Bar3.DataLabelStyle.Format = "<value>";

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			m_bUpdateLegends = false;

			// first series legend configuration
			FirstDisplayOnLegendComboBox.Items.Add("Left");
			FirstDisplayOnLegendComboBox.Items.Add("Right");
			FirstDisplayOnLegendComboBox.SelectedIndex = 0;

			FirstSeriesLegendModeComboBox.Items.Add("None");
			FirstSeriesLegendModeComboBox.Items.Add("Series");
			FirstSeriesLegendModeComboBox.Items.Add("DataPoints");
			FirstSeriesLegendModeComboBox.Items.Add("SeriesLogic");
			FirstSeriesLegendModeComboBox.SelectedIndex = 2;

			FirstSeriesFormatTextBox.Text = m_Bar1.Legend.Format;

			// second series legend configuration
			SecondDisplayOnLegendComboBox.Items.Add("Left");
			SecondDisplayOnLegendComboBox.Items.Add("Right");
			SecondDisplayOnLegendComboBox.SelectedIndex = 0;

			SecondSeriesLegendModeComboBox.Items.Add("None");
			SecondSeriesLegendModeComboBox.Items.Add("Series");
			SecondSeriesLegendModeComboBox.Items.Add("DataPoints");
			SecondSeriesLegendModeComboBox.Items.Add("SeriesLogic");
			SecondSeriesLegendModeComboBox.SelectedIndex = 2;

			SecondSeriesFormatTextBox.Text = m_Bar2.Legend.Format;

			// third series legend configuration
            ThirdDisplayOnLegendComboBox.Items.Add("Left");
			ThirdDisplayOnLegendComboBox.Items.Add("Right");
			ThirdDisplayOnLegendComboBox.SelectedIndex = 1;

			ThirdSeriesLegendModeComboBox.Items.Add("None");
			ThirdSeriesLegendModeComboBox.Items.Add("Series");
			ThirdSeriesLegendModeComboBox.Items.Add("DataPoints");
			ThirdSeriesLegendModeComboBox.Items.Add("SeriesLogic");
			ThirdSeriesLegendModeComboBox.SelectedIndex = 2;

			ThirdSeriesFormatTextBox.Text = m_Bar2.Legend.Format;

			m_bUpdateLegends = true;

			PositiveDataButton_Click(null, null);
			ConfigureLegends();
		}


		private void ConfigureLegends()
		{
			if (m_bUpdateLegends == false)
				return;

			m_Bar1.Legend.DisplayOnLegend = (NLegend)nChartControl1.Legends[FirstDisplayOnLegendComboBox.SelectedIndex];
			m_Bar1.Legend.Mode = (SeriesLegendMode)FirstSeriesLegendModeComboBox.SelectedIndex;
			m_Bar1.Legend.Format = FirstSeriesFormatTextBox.Text;
			
			m_Bar2.Legend.DisplayOnLegend = (NLegend)nChartControl1.Legends[SecondDisplayOnLegendComboBox.SelectedIndex];
			m_Bar2.Legend.Mode = (SeriesLegendMode)SecondSeriesLegendModeComboBox.SelectedIndex;
			m_Bar3.Legend.Format = SecondSeriesFormatTextBox.Text;

			m_Bar3.Legend.Mode = (SeriesLegendMode)ThirdSeriesLegendModeComboBox.SelectedIndex;
			m_Bar3.Legend.DisplayOnLegend = (NLegend)nChartControl1.Legends[ThirdDisplayOnLegendComboBox.SelectedIndex];
			m_Bar3.Legend.Format = ThirdSeriesFormatTextBox.Text;

			nChartControl1.Refresh();
		}

		private void FirstDisplayOnLegendComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();
		}

		private void FirstSeriesLegendModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();
		}

		private void FirstSeriesFormatTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();
		}

		private void FirstTextStyleButton_Click(object sender, System.EventArgs e)
		{
			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(m_Bar1.Legend.TextStyle, out textStyleResult))
			{
				m_Bar1.Legend.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void SecondDisplayOnLegendComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();		
		}

		private void SecondSeriesLegendModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();
		}

		private void SecondSeriesFormatTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();
		}

		private void SecondTextStyleButton_Click(object sender, System.EventArgs e)
		{
			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(m_Bar2.Legend.TextStyle, out textStyleResult))
			{
				m_Bar2.Legend.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}		
		}

		private void ThirdDisplayOnLegendComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();
		}

		private void ThirdSeriesLegendModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();
		}

		private void ThirdSeriesFormatTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ConfigureLegends();
		}

		private void ThirdTextStyleButton_Click(object sender, System.EventArgs e)
		{
			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(m_Bar3.Legend.TextStyle, out textStyleResult))
			{
				m_Bar3.Legend.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void PositiveDataButton_Click(object sender, System.EventArgs e)
		{
			int nDataPoints = (int)DataPointsNumericUpDown.Value;
			m_Bar1.Values.FillRandomRange(Random, nDataPoints, 20, 100);
			m_Bar2.Values.FillRandomRange(Random, nDataPoints, 20, 100);		
			m_Bar3.Values.FillRandomRange(Random, nDataPoints, 20, 100);		
			nChartControl1.Refresh();
		}

		private void PositiveAndNegativeDataButton_Click(object sender, System.EventArgs e)
		{
			int nDataPoints = (int)DataPointsNumericUpDown.Value;
			m_Bar1.Values.FillRandomRange(Random, nDataPoints, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, nDataPoints, -100, 100);	
			m_Bar3.Values.FillRandomRange(Random, nDataPoints, -100, 100);	
			nChartControl1.Refresh();
		}
	}
}
