using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStackedBarUC : NExampleBaseUC
	{
		private const int categoriesCount = 6;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private NBarSeries m_Bar3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox FirstBarDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox SecondBarDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox ThirdBarDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox StackModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox BarShapeCombo;
		private Nevron.UI.WinForm.Controls.NButton PositiveNegativeData;
		private Nevron.UI.WinForm.Controls.NButton PositiveData;
		private Nevron.UI.WinForm.Controls.NCheckBox FHTE;
		private Nevron.UI.WinForm.Controls.NCheckBox SHTE;
		private Nevron.UI.WinForm.Controls.NCheckBox THTE;
		private Nevron.UI.WinForm.Controls.NCheckBox FHBE;
		private Nevron.UI.WinForm.Controls.NCheckBox SHBE;
		private Nevron.UI.WinForm.Controls.NCheckBox THBE;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDataLabelsCheck;
		private System.ComponentModel.Container components = null;

		public NStackedBarUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.FirstBarDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SecondBarDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ThirdBarDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.StackModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.PositiveNegativeData = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveData = new Nevron.UI.WinForm.Controls.NButton();
			this.label5 = new System.Windows.Forms.Label();
			this.BarShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.FHTE = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SHTE = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.THTE = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.FHBE = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SHBE = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.THBE = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowDataLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 387);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "First Bar Data Labels:";
			// 
			// FirstBarDataLabelsCombo
			// 
			this.FirstBarDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.FirstBarDataLabelsCombo.ListProperties.DataSource = null;
			this.FirstBarDataLabelsCombo.ListProperties.DisplayMember = "";
			this.FirstBarDataLabelsCombo.Location = new System.Drawing.Point(8, 403);
			this.FirstBarDataLabelsCombo.Name = "FirstBarDataLabelsCombo";
			this.FirstBarDataLabelsCombo.Size = new System.Drawing.Size(160, 21);
			this.FirstBarDataLabelsCombo.TabIndex = 1;
			this.FirstBarDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.FirstBarDataLabelsCombo_SelectedIndexChanged);
			// 
			// SecondBarDataLabelsCombo
			// 
			this.SecondBarDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.SecondBarDataLabelsCombo.ListProperties.DataSource = null;
			this.SecondBarDataLabelsCombo.ListProperties.DisplayMember = "";
			this.SecondBarDataLabelsCombo.Location = new System.Drawing.Point(8, 451);
			this.SecondBarDataLabelsCombo.Name = "SecondBarDataLabelsCombo";
			this.SecondBarDataLabelsCombo.Size = new System.Drawing.Size(160, 21);
			this.SecondBarDataLabelsCombo.TabIndex = 3;
			this.SecondBarDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.SecondBarDataLabelsCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 435);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Second Bar Data Labels:";
			// 
			// ThirdBarDataLabelsCombo
			// 
			this.ThirdBarDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.ThirdBarDataLabelsCombo.ListProperties.DataSource = null;
			this.ThirdBarDataLabelsCombo.ListProperties.DisplayMember = "";
			this.ThirdBarDataLabelsCombo.Location = new System.Drawing.Point(8, 499);
			this.ThirdBarDataLabelsCombo.Name = "ThirdBarDataLabelsCombo";
			this.ThirdBarDataLabelsCombo.Size = new System.Drawing.Size(160, 21);
			this.ThirdBarDataLabelsCombo.TabIndex = 5;
			this.ThirdBarDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.ThirdBarDataLabelsCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 483);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Third Bar Data Labels:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Stack Mode:";
			// 
			// StackModeCombo
			// 
			this.StackModeCombo.ListProperties.CheckBoxDataMember = "";
			this.StackModeCombo.ListProperties.DataSource = null;
			this.StackModeCombo.ListProperties.DisplayMember = "";
			this.StackModeCombo.Location = new System.Drawing.Point(8, 23);
			this.StackModeCombo.Name = "StackModeCombo";
			this.StackModeCombo.Size = new System.Drawing.Size(160, 21);
			this.StackModeCombo.TabIndex = 7;
			this.StackModeCombo.SelectedIndexChanged += new System.EventHandler(this.StackModeCombo_SelectedIndexChanged);
			// 
			// PositiveNegativeData
			// 
			this.PositiveNegativeData.Location = new System.Drawing.Point(8, 104);
			this.PositiveNegativeData.Name = "PositiveNegativeData";
			this.PositiveNegativeData.Size = new System.Drawing.Size(160, 32);
			this.PositiveNegativeData.TabIndex = 9;
			this.PositiveNegativeData.Text = "Positive and Negative Data";
			this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeDataButton_Click);
			// 
			// PositiveData
			// 
			this.PositiveData.Location = new System.Drawing.Point(8, 66);
			this.PositiveData.Name = "PositiveData";
			this.PositiveData.Size = new System.Drawing.Size(160, 32);
			this.PositiveData.TabIndex = 8;
			this.PositiveData.Text = "Positive Data";
			this.PositiveData.Click += new System.EventHandler(this.PositiveDataButton_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 155);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Bar Shape:";
			// 
			// BarShapeCombo
			// 
			this.BarShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.BarShapeCombo.ListProperties.DataSource = null;
			this.BarShapeCombo.ListProperties.DisplayMember = "";
			this.BarShapeCombo.Location = new System.Drawing.Point(8, 171);
			this.BarShapeCombo.Name = "BarShapeCombo";
			this.BarShapeCombo.Size = new System.Drawing.Size(160, 21);
			this.BarShapeCombo.TabIndex = 11;
			this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarShapeCombo_SelectedIndexChanged);
			// 
			// FHTE
			// 
			this.FHTE.ButtonProperties.BorderOffset = 2;
			this.FHTE.Location = new System.Drawing.Point(8, 205);
			this.FHTE.Name = "FHTE";
			this.FHTE.Size = new System.Drawing.Size(160, 22);
			this.FHTE.TabIndex = 12;
			this.FHTE.Text = "First Has Top Edge";
			this.FHTE.CheckedChanged += new System.EventHandler(this.FHTE_CheckedChanged);
			// 
			// SHTE
			// 
			this.SHTE.ButtonProperties.BorderOffset = 2;
			this.SHTE.Location = new System.Drawing.Point(8, 245);
			this.SHTE.Name = "SHTE";
			this.SHTE.Size = new System.Drawing.Size(160, 22);
			this.SHTE.TabIndex = 13;
			this.SHTE.Text = "Second Has Top Edge";
			this.SHTE.CheckedChanged += new System.EventHandler(this.SHTE_CheckedChanged);
			// 
			// THTE
			// 
			this.THTE.ButtonProperties.BorderOffset = 2;
			this.THTE.Location = new System.Drawing.Point(8, 285);
			this.THTE.Name = "THTE";
			this.THTE.Size = new System.Drawing.Size(160, 22);
			this.THTE.TabIndex = 14;
			this.THTE.Text = "Third Has Top Edge";
			this.THTE.CheckedChanged += new System.EventHandler(this.THTE_CheckedChanged);
			// 
			// FHBE
			// 
			this.FHBE.ButtonProperties.BorderOffset = 2;
			this.FHBE.Location = new System.Drawing.Point(8, 225);
			this.FHBE.Name = "FHBE";
			this.FHBE.Size = new System.Drawing.Size(160, 22);
			this.FHBE.TabIndex = 15;
			this.FHBE.Text = "First Has Bottom Edge";
			this.FHBE.CheckedChanged += new System.EventHandler(this.FHBE_CheckedChanged);
			// 
			// SHBE
			// 
			this.SHBE.ButtonProperties.BorderOffset = 2;
			this.SHBE.Location = new System.Drawing.Point(8, 265);
			this.SHBE.Name = "SHBE";
			this.SHBE.Size = new System.Drawing.Size(160, 22);
			this.SHBE.TabIndex = 16;
			this.SHBE.Text = "Second Has Bottom Edge";
			this.SHBE.CheckedChanged += new System.EventHandler(this.SHBE_CheckedChanged);
			// 
			// THBE
			// 
			this.THBE.ButtonProperties.BorderOffset = 2;
			this.THBE.Location = new System.Drawing.Point(8, 306);
			this.THBE.Name = "THBE";
			this.THBE.Size = new System.Drawing.Size(160, 22);
			this.THBE.TabIndex = 17;
			this.THBE.Text = "Third Has Bottom Edge";
			this.THBE.CheckedChanged += new System.EventHandler(this.THBE_CheckedChanged);
			// 
			// ShowDataLabelsCheck
			// 
			this.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.ShowDataLabelsCheck.Location = new System.Drawing.Point(8, 355);
			this.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck";
			this.ShowDataLabelsCheck.Size = new System.Drawing.Size(160, 21);
			this.ShowDataLabelsCheck.TabIndex = 25;
			this.ShowDataLabelsCheck.Text = "Show Data Labels";
			this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			// 
			// NStackedBarUC
			// 
			this.Controls.Add(this.ShowDataLabelsCheck);
			this.Controls.Add(this.THBE);
			this.Controls.Add(this.SHBE);
			this.Controls.Add(this.FHBE);
			this.Controls.Add(this.THTE);
			this.Controls.Add(this.SHTE);
			this.Controls.Add(this.FHTE);
			this.Controls.Add(this.BarShapeCombo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.PositiveNegativeData);
			this.Controls.Add(this.PositiveData);
			this.Controls.Add(this.StackModeCombo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ThirdBarDataLabelsCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SecondBarDataLabelsCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FirstBarDataLabelsCombo);
			this.Controls.Add(this.label1);
			this.Name = "NStackedBarUC";
			this.Size = new System.Drawing.Size(180, 538);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add the first bar
			m_Bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.MultiBarMode = MultiBarMode.Series;

			// add the second bar
			m_Bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.MultiBarMode = MultiBarMode.Stacked;

			// add the third bar
			m_Bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar3.Name = "Bar3";
			m_Bar3.MultiBarMode = MultiBarMode.Stacked;

			// setup value formatting
			m_Bar1.Values.ValueFormatter = new NNumericValueFormatter("0.###");
			m_Bar2.Values.ValueFormatter = new NNumericValueFormatter("0.###");
			m_Bar3.Values.ValueFormatter = new NNumericValueFormatter("0.###");

			// position data labels in the center of the bars
			m_Bar1.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center;

			m_Bar1.DataLabelStyle.ArrowLength = new NLength(0);
			m_Bar2.DataLabelStyle.ArrowLength = new NLength(0);
			m_Bar3.DataLabelStyle.ArrowLength = new NLength(0);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			InitLabelsCombo(FirstBarDataLabelsCombo);
			InitLabelsCombo(SecondBarDataLabelsCombo);
			InitLabelsCombo(ThirdBarDataLabelsCombo);

			StackModeCombo.Items.Add("Stacked");
			StackModeCombo.Items.Add("Stacked %");
			StackModeCombo.SelectedIndex = 0;

			BarShapeCombo.FillFromEnum(typeof(BarShape));
			BarShapeCombo.SelectedIndex = 0;

			FHTE.Checked = true;
			SHTE.Checked = true;
			THTE.Checked = true;
			FHBE.Checked = true;
			SHBE.Checked = true;
			THBE.Checked = true;

			PositiveDataButton_Click(null, null);
			ShowDataLabelsCheck_CheckedChanged(null, null);
		}
		private string GetFormatStringFromIndex(int index)
		{
			switch (index)
			{
				case 0:
					return "<value>";

				case 1:
					return "<total>";

				case 2:
					return "<cumulative>";

				case 3:
					return "<percent>";

				default:
					return "";
			}
		}
		private void InitLabelsCombo(Nevron.UI.WinForm.Controls.NComboBox comboBox)
		{
			comboBox.Items.Add("Value");
			comboBox.Items.Add("Total");
			comboBox.Items.Add("Cumulative");
			comboBox.Items.Add("Percent");
			comboBox.SelectedIndex = 0;
		}

		private void StackModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			switch (StackModeCombo.SelectedIndex)
			{
				case 0:
					m_Bar2.MultiBarMode = MultiBarMode.Stacked; 
					m_Bar3.MultiBarMode = MultiBarMode.Stacked;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					m_Bar2.MultiBarMode = MultiBarMode.StackedPercent; 
					m_Bar3.MultiBarMode = MultiBarMode.StackedPercent;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}
			
			nChartControl1.Refresh();
		}
		private void PositiveDataButton_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, 10, 100);

			nChartControl1.Refresh();
		}
		private void PositiveNegativeDataButton_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			nChartControl1.Refresh();
		}
		private void BarShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar1.BarShape = (BarShape)BarShapeCombo.SelectedIndex;
			m_Bar2.BarShape = (BarShape)BarShapeCombo.SelectedIndex;
			m_Bar3.BarShape = (BarShape)BarShapeCombo.SelectedIndex;

			bool bEnable = false;
			if (m_Bar3.BarShape == BarShape.SmoothEdgeBar || m_Bar3.BarShape == BarShape.CutEdgeBar)
			{
				bEnable = true;
			}

			ArrayList arrControls = new ArrayList();
			arrControls.Add(FHTE);
			arrControls.Add(FHBE);

			arrControls.Add(SHTE);
			arrControls.Add(SHBE);

			arrControls.Add(THTE);
			arrControls.Add(THBE);

			foreach (Nevron.UI.WinForm.Controls.NCheckBox check in arrControls)
			{
				check.Enabled = bEnable;
			}

			nChartControl1.Refresh();
		}
		private void FHTE_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Bar1.HasTopEdge = FHTE.Checked;		
			nChartControl1.Refresh();
		}
		private void FHBE_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Bar1.HasBottomEdge = FHBE.Checked;		
			nChartControl1.Refresh();
		}
		private void SHTE_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Bar2.HasTopEdge = SHTE.Checked;		
			nChartControl1.Refresh();
		}
		private void SHBE_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Bar2.HasBottomEdge = SHBE.Checked;		
			nChartControl1.Refresh();
		}
		private void THTE_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Bar3.HasTopEdge = THTE.Checked;		
			nChartControl1.Refresh();
		}
		private void THBE_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Bar3.HasBottomEdge = THBE.Checked;		
			nChartControl1.Refresh();
		}
		private void ShowDataLabelsCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries s0 = (NSeries)chart.Series[0];
			NSeries s1 = (NSeries)chart.Series[1];
			NSeries s2 = (NSeries)chart.Series[2];

			s0.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			s1.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			s2.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;

			FirstBarDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;
			SecondBarDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;
			ThirdBarDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;

			nChartControl1.Refresh();
		}
		private void FirstBarDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar1.DataLabelStyle.Format = GetFormatStringFromIndex(FirstBarDataLabelsCombo.SelectedIndex);
			nChartControl1.Refresh();
		}
		private void SecondBarDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar2.DataLabelStyle.Format = GetFormatStringFromIndex(SecondBarDataLabelsCombo.SelectedIndex);
			nChartControl1.Refresh();
		}
		private void ThirdBarDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar3.DataLabelStyle.Format = GetFormatStringFromIndex(ThirdBarDataLabelsCombo.SelectedIndex);
			nChartControl1.Refresh();
		}
	}
}
