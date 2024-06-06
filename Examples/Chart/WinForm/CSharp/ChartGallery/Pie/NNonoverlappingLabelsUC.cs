using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
	public class NNonoverlappingLabelsUC : NExampleBaseUC
	{
		private NPieSeries m_PieSeries;
		private NPieChart m_PieChart;
		private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox ClockwiseCheckBox;
		private Nevron.UI.WinForm.Controls.NComboBox PieStyleCombo;
		private Label label1;
        private Nevron.UI.WinForm.Controls.NCheckBox Enable3DCheckBox;
        private Nevron.UI.WinForm.Controls.NComboBox NonOverlappingLayoutComboBox;
        private Label label2;
        private Label label3;
        private Nevron.UI.WinForm.Controls.NNumericUpDown SweepAngleUpDown;
        private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
        private Label label4;
        private Label label5;
        private Nevron.UI.WinForm.Controls.NNumericUpDown LeadOffLengthNumericUpDown;
        private Label label6;
        private NumericUpDown ConnectorLengthNumericUpDown;
        private System.ComponentModel.Container components = null;

		public NNonoverlappingLabelsUC()
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
            this.ClockwiseCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.PieStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Enable3DCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.NonOverlappingLayoutComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SweepAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.BeginAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LeadOffLengthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ConnectorLengthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SweepAngleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadOffLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectorLengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeDataButton
            // 
            this.ChangeDataButton.Location = new System.Drawing.Point(7, 483);
            this.ChangeDataButton.Name = "ChangeDataButton";
            this.ChangeDataButton.Size = new System.Drawing.Size(180, 24);
            this.ChangeDataButton.TabIndex = 14;
            this.ChangeDataButton.Text = "Change Data";
            this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
            // 
            // ClockwiseCheckBox
            // 
            this.ClockwiseCheckBox.ButtonProperties.BorderOffset = 2;
            this.ClockwiseCheckBox.Location = new System.Drawing.Point(7, 360);
            this.ClockwiseCheckBox.Name = "ClockwiseCheckBox";
            this.ClockwiseCheckBox.Size = new System.Drawing.Size(165, 23);
            this.ClockwiseCheckBox.TabIndex = 13;
            this.ClockwiseCheckBox.Text = "Clockwise";
            this.ClockwiseCheckBox.CheckedChanged += new System.EventHandler(this.ClockwiseCheckBox_CheckedChanged);
            // 
            // PieStyleCombo
            // 
            this.PieStyleCombo.ListProperties.CheckBoxDataMember = "";
            this.PieStyleCombo.ListProperties.DataSource = null;
            this.PieStyleCombo.ListProperties.DisplayMember = "";
            this.PieStyleCombo.Location = new System.Drawing.Point(7, 33);
            this.PieStyleCombo.Name = "PieStyleCombo";
            this.PieStyleCombo.Size = new System.Drawing.Size(180, 21);
            this.PieStyleCombo.TabIndex = 1;
            this.PieStyleCombo.SelectedIndexChanged += new System.EventHandler(this.PieStyleCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pie Style:";
            // 
            // Enable3DCheckBox
            // 
            this.Enable3DCheckBox.ButtonProperties.BorderOffset = 2;
            this.Enable3DCheckBox.Location = new System.Drawing.Point(7, 336);
            this.Enable3DCheckBox.Name = "Enable3DCheckBox";
            this.Enable3DCheckBox.Size = new System.Drawing.Size(165, 23);
            this.Enable3DCheckBox.TabIndex = 12;
            this.Enable3DCheckBox.Text = "Enable 3D";
            this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
            // 
            // NonOverlappingLayoutComboBox
            // 
            this.NonOverlappingLayoutComboBox.ListProperties.CheckBoxDataMember = "";
            this.NonOverlappingLayoutComboBox.ListProperties.DataSource = null;
            this.NonOverlappingLayoutComboBox.ListProperties.DisplayMember = "";
            this.NonOverlappingLayoutComboBox.Location = new System.Drawing.Point(7, 73);
            this.NonOverlappingLayoutComboBox.Name = "NonOverlappingLayoutComboBox";
            this.NonOverlappingLayoutComboBox.Size = new System.Drawing.Size(180, 21);
            this.NonOverlappingLayoutComboBox.TabIndex = 3;
            this.NonOverlappingLayoutComboBox.SelectedIndexChanged += new System.EventHandler(this.NonOverlappingLayoutComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Non Overlapping Layout:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Begin Angle:";
            // 
            // SweepAngleUpDown
            // 
            this.SweepAngleUpDown.Location = new System.Drawing.Point(7, 168);
            this.SweepAngleUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SweepAngleUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.SweepAngleUpDown.Name = "SweepAngleUpDown";
            this.SweepAngleUpDown.Size = new System.Drawing.Size(175, 20);
            this.SweepAngleUpDown.TabIndex = 7;
            this.SweepAngleUpDown.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.SweepAngleUpDown.ValueChanged += new System.EventHandler(this.SweepAngleUpDown_ValueChanged);
            // 
            // BeginAngleUpDown
            // 
            this.BeginAngleUpDown.Location = new System.Drawing.Point(7, 125);
            this.BeginAngleUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BeginAngleUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.BeginAngleUpDown.Name = "BeginAngleUpDown";
            this.BeginAngleUpDown.Size = new System.Drawing.Size(177, 20);
            this.BeginAngleUpDown.TabIndex = 5;
            this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sweep Angle:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lead Off Length:";
            // 
            // LeadOffLengthNumericUpDown
            // 
            this.LeadOffLengthNumericUpDown.Location = new System.Drawing.Point(7, 292);
            this.LeadOffLengthNumericUpDown.Name = "LeadOffLengthNumericUpDown";
            this.LeadOffLengthNumericUpDown.Size = new System.Drawing.Size(177, 20);
            this.LeadOffLengthNumericUpDown.TabIndex = 11;
            this.LeadOffLengthNumericUpDown.ValueChanged += new System.EventHandler(this.LeadOffLengthNumericUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Connector Length:";
            // 
            // ConnectorLengthNumericUpDown
            // 
            this.ConnectorLengthNumericUpDown.Location = new System.Drawing.Point(7, 245);
            this.ConnectorLengthNumericUpDown.Name = "ConnectorLengthNumericUpDown";
            this.ConnectorLengthNumericUpDown.Size = new System.Drawing.Size(177, 20);
            this.ConnectorLengthNumericUpDown.TabIndex = 9;
            this.ConnectorLengthNumericUpDown.ValueChanged += new System.EventHandler(this.ConnectorLengthNumericUpDown_ValueChanged);
            // 
            // NNonoverlappingLabelsUC
            // 
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LeadOffLengthNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ConnectorLengthNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SweepAngleUpDown);
            this.Controls.Add(this.BeginAngleUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NonOverlappingLayoutComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Enable3DCheckBox);
            this.Controls.Add(this.PieStyleCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClockwiseCheckBox);
            this.Controls.Add(this.ChangeDataButton);
            this.Name = "NNonoverlappingLabelsUC";
            this.Size = new System.Drawing.Size(198, 638);
            ((System.ComponentModel.ISupportInitialize)(this.SweepAngleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeadOffLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectorLengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Nonoverlapping Pie Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage), 
				new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_PieChart = new NPieChart();
			m_PieChart.Enable3D = true;
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_PieChart);
			m_PieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
            m_PieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.VividCameraLight);
			m_PieChart.Location = new NPointL(
				new NLength(15, NRelativeUnit.ParentPercentage), 
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_PieChart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage), 
				new NLength(70, NRelativeUnit.ParentPercentage));

			// setup pie series
			m_PieSeries = (NPieSeries)m_PieChart.Series.Add(SeriesType.Pie);
			m_PieSeries.LabelMode = PieLabelMode.SpiderNoOverlap;
			m_PieSeries.DataLabelStyle.Format = "<label>\n<percent>";
			m_PieSeries.Values.ValueFormatter = new NNumericValueFormatter("0.##");

			double[] arrValues =
			{
				4.17, 7.19, 5.62, 7.91, 15.28, 
				0.97, 1.3, 1.12, 8.54, 9.84, 
				2.05, 5.02, 1.42, 0.63, 3.01 
			};

			for (int i = 0; i < arrValues.Length; i++)
			{
				m_PieSeries.Values.Add(arrValues[i]);
			}

			SetTexts();

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			PieStyleCombo.FillFromEnum(typeof(PieStyle));
			PieStyleCombo.SelectedIndex = 2;

            NonOverlappingLayoutComboBox.Items.Add("Spider No Ovelap");
            NonOverlappingLayoutComboBox.Items.Add("Rim No Ovelap");
			NonOverlappingLayoutComboBox.SelectedIndex = 0;

            LeadOffLengthNumericUpDown.Value = 2;
            ConnectorLengthNumericUpDown.Value = 12;
        }

		private void GenerateRandomValues(int count)
		{
			m_PieSeries.Values.Clear();

			for (int i = 0; i < count; i++)
			{
				m_PieSeries.Values.Add(Random.NextDouble() * 10);
			}
		}
		private void SetTexts()
		{
			string[] arrTexts =
			{
				"Athletics",
				"Basketball",
				"Boxing",
				"Cycling",
				"Football",
				"Golf",
				"Handball",
				"Ice Hockey",
				"Motorsports",
				"Rugby",
				"Sailing",
				"Snooker",
				"Swimming",
				"Tennis",
				"Volleyball"
			};

			for (int i = 0; i < arrTexts.Length; i++)
			{
				m_PieSeries.Labels.Add(arrTexts[i]);
			}
		}

		private void ChangeDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateRandomValues(15);
			nChartControl1.Refresh();
		}
		private void ClockwiseCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_PieChart.ClockwiseDirection = ClockwiseCheckBox.Checked;
			nChartControl1.Refresh();
		}
		private void PieStyleCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_PieSeries.PieStyle = (PieStyle)PieStyleCombo.SelectedIndex;

			nChartControl1.Refresh();
		}

        private void NonOverlappingLayoutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (NonOverlappingLayoutComboBox.SelectedIndex == 0)
			{
				m_PieSeries.LabelMode = PieLabelMode.SpiderNoOverlap;
			}
			else
			{
				m_PieSeries.LabelMode = PieLabelMode.RimNoOverlap;
            }

            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
			m_PieChart.Enable3D = Enable3DCheckBox.Checked;
			nChartControl1.Refresh();
        }

        private void ConnectorLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_PieSeries.ConnectorLength = new NLength((float)ConnectorLengthNumericUpDown.Value);
            nChartControl1.Refresh();
        }

        private void LeadOffLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_PieSeries.LeadOffArrowLength = new NLength((float)LeadOffLengthNumericUpDown.Value);
            nChartControl1.Refresh();
        }

        private void BeginAngleUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_PieChart.BeginAngle = (float)BeginAngleUpDown.Value;
            nChartControl1.Refresh();
        }

        private void SweepAngleUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_PieChart.TotalAngle = (float)SweepAngleUpDown.Value;
            nChartControl1.Refresh();
        }
    }
}
