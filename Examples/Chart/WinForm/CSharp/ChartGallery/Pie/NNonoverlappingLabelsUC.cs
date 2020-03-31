using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

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
			this.SuspendLayout();
			// 
			// ChangeDataButton
			// 
			this.ChangeDataButton.Location = new System.Drawing.Point(4, 9);
			this.ChangeDataButton.Name = "ChangeDataButton";
			this.ChangeDataButton.Size = new System.Drawing.Size(172, 24);
			this.ChangeDataButton.TabIndex = 0;
			this.ChangeDataButton.Text = "Change Data";
			this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			// 
			// ClockwiseCheckBox
			// 
			this.ClockwiseCheckBox.ButtonProperties.BorderOffset = 2;
			this.ClockwiseCheckBox.Location = new System.Drawing.Point(4, 116);
			this.ClockwiseCheckBox.Name = "ClockwiseCheckBox";
			this.ClockwiseCheckBox.Size = new System.Drawing.Size(165, 23);
			this.ClockwiseCheckBox.TabIndex = 3;
			this.ClockwiseCheckBox.Text = "Clockwise";
			this.ClockwiseCheckBox.CheckedChanged += new System.EventHandler(this.ClockwiseCheckBox_CheckedChanged);
			// 
			// PieStyleCombo
			// 
			this.PieStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.PieStyleCombo.ListProperties.DataSource = null;
			this.PieStyleCombo.ListProperties.DisplayMember = "";
			this.PieStyleCombo.Location = new System.Drawing.Point(4, 69);
			this.PieStyleCombo.Name = "PieStyleCombo";
			this.PieStyleCombo.Size = new System.Drawing.Size(172, 21);
			this.PieStyleCombo.TabIndex = 2;
			this.PieStyleCombo.SelectedIndexChanged += new System.EventHandler(this.PieStyleCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(165, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Pie Style:";
			// 
			// NNonoverlappingLabelsUC
			// 
			this.Controls.Add(this.PieStyleCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ClockwiseCheckBox);
			this.Controls.Add(this.ChangeDataButton);
			this.Name = "NNonoverlappingLabelsUC";
			this.Size = new System.Drawing.Size(180, 206);
			this.ResumeLayout(false);

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
	}
}
