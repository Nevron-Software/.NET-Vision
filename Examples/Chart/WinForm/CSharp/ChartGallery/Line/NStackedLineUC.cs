using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStackedLineUC : NExampleBaseUC
	{
		private const int categoriesCount = 12;
		private NChart m_Chart;
		private NLineSeries m_Line1;
		private NLineSeries m_Line2;
		private NLineSeries m_Line3;
		private Nevron.UI.WinForm.Controls.NComboBox StackModeCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox ThirdLineDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox SecondLineDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox FirstLineDataLabelsCombo;
		private Nevron.UI.WinForm.Controls.NButton PositiveOnlyButton;
		private Nevron.UI.WinForm.Controls.NButton PositiveAndNegativeValuesButton;
		private Nevron.UI.WinForm.Controls.NComboBox LineShapeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDataLabelsCheck;
		private System.ComponentModel.Container components = null;

		public NStackedLineUC()
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
			this.StackModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ThirdLineDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SecondLineDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.FirstLineDataLabelsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.PositiveOnlyButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveAndNegativeValuesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label5 = new System.Windows.Forms.Label();
			this.LineShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ShowDataLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// StackModeCombo
			// 
			this.StackModeCombo.ListProperties.CheckBoxDataMember = "";
			this.StackModeCombo.ListProperties.DataSource = null;
			this.StackModeCombo.ListProperties.DisplayMember = "";
			this.StackModeCombo.Location = new System.Drawing.Point(4, 20);
			this.StackModeCombo.Name = "StackModeCombo";
			this.StackModeCombo.Size = new System.Drawing.Size(170, 21);
			this.StackModeCombo.TabIndex = 7;
			this.StackModeCombo.SelectedIndexChanged += new System.EventHandler(this.StackModeCombo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(170, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Stack Mode:";
			// 
			// ThirdLineDataLabelsCombo
			// 
			this.ThirdLineDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.ThirdLineDataLabelsCombo.ListProperties.DataSource = null;
			this.ThirdLineDataLabelsCombo.ListProperties.DisplayMember = "";
			this.ThirdLineDataLabelsCombo.Location = new System.Drawing.Point(4, 356);
			this.ThirdLineDataLabelsCombo.Name = "ThirdLineDataLabelsCombo";
			this.ThirdLineDataLabelsCombo.Size = new System.Drawing.Size(170, 21);
			this.ThirdLineDataLabelsCombo.TabIndex = 5;
			this.ThirdLineDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.ThirdLineDataLabelsCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 340);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(170, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Third Line Data Labels:";
			// 
			// SecondLineDataLabelsCombo
			// 
			this.SecondLineDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.SecondLineDataLabelsCombo.ListProperties.DataSource = null;
			this.SecondLineDataLabelsCombo.ListProperties.DisplayMember = "";
			this.SecondLineDataLabelsCombo.Location = new System.Drawing.Point(4, 308);
			this.SecondLineDataLabelsCombo.Name = "SecondLineDataLabelsCombo";
			this.SecondLineDataLabelsCombo.Size = new System.Drawing.Size(170, 21);
			this.SecondLineDataLabelsCombo.TabIndex = 3;
			this.SecondLineDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.SecondLineDataLabelsCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 292);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Second Line Data Labels:";
			// 
			// FirstLineDataLabelsCombo
			// 
			this.FirstLineDataLabelsCombo.ListProperties.CheckBoxDataMember = "";
			this.FirstLineDataLabelsCombo.ListProperties.DataSource = null;
			this.FirstLineDataLabelsCombo.ListProperties.DisplayMember = "";
			this.FirstLineDataLabelsCombo.Location = new System.Drawing.Point(4, 260);
			this.FirstLineDataLabelsCombo.Name = "FirstLineDataLabelsCombo";
			this.FirstLineDataLabelsCombo.Size = new System.Drawing.Size(170, 21);
			this.FirstLineDataLabelsCombo.TabIndex = 1;
			this.FirstLineDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.FirstLineDataLabelsCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 244);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "First Line Data Labels:";
			// 
			// PositiveOnlyButton
			// 
			this.PositiveOnlyButton.Location = new System.Drawing.Point(4, 115);
			this.PositiveOnlyButton.Name = "PositiveOnlyButton";
			this.PositiveOnlyButton.Size = new System.Drawing.Size(170, 23);
			this.PositiveOnlyButton.TabIndex = 8;
			this.PositiveOnlyButton.Text = "Positive Values";
			this.PositiveOnlyButton.Click += new System.EventHandler(this.PositiveDataButton_Click);
			// 
			// PositiveAndNegativeValuesButton
			// 
			this.PositiveAndNegativeValuesButton.Location = new System.Drawing.Point(4, 150);
			this.PositiveAndNegativeValuesButton.Name = "PositiveAndNegativeValuesButton";
			this.PositiveAndNegativeValuesButton.Size = new System.Drawing.Size(170, 23);
			this.PositiveAndNegativeValuesButton.TabIndex = 9;
			this.PositiveAndNegativeValuesButton.Text = "Positive And Negative Values";
			this.PositiveAndNegativeValuesButton.Click += new System.EventHandler(this.PositiveAndNegativeValuesButton_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(4, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(170, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "Line Shape:";
			// 
			// LineShapeCombo
			// 
			this.LineShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.LineShapeCombo.ListProperties.DataSource = null;
			this.LineShapeCombo.ListProperties.DisplayMember = "";
			this.LineShapeCombo.Location = new System.Drawing.Point(4, 68);
			this.LineShapeCombo.Name = "LineShapeCombo";
			this.LineShapeCombo.Size = new System.Drawing.Size(170, 21);
			this.LineShapeCombo.TabIndex = 10;
			this.LineShapeCombo.SelectedIndexChanged += new System.EventHandler(this.LineShapeCombo_SelectedIndexChanged);
			// 
			// ShowDataLabelsCheck
			// 
			this.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.ShowDataLabelsCheck.Location = new System.Drawing.Point(4, 212);
			this.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck";
			this.ShowDataLabelsCheck.Size = new System.Drawing.Size(170, 21);
			this.ShowDataLabelsCheck.TabIndex = 25;
			this.ShowDataLabelsCheck.Text = "Show Data Labels";
			this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			// 
			// NStackedLineUC
			// 
			this.Controls.Add(this.ShowDataLabelsCheck);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.LineShapeCombo);
			this.Controls.Add(this.PositiveAndNegativeValuesButton);
			this.Controls.Add(this.PositiveOnlyButton);
			this.Controls.Add(this.StackModeCombo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ThirdLineDataLabelsCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SecondLineDataLabelsCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FirstLineDataLabelsCombo);
			this.Controls.Add(this.label1);
			this.Name = "NStackedLineUC";
			this.Size = new System.Drawing.Size(180, 410);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// add the first line
			m_Line1 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line1.Name = "Line 1";
			m_Line1.MultiLineMode = MultiLineMode.Series;
			m_Line1.DataLabelStyle.ArrowLength = new NLength(0, NRelativeUnit.ParentPercentage);
			m_Line1.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Line1.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			m_Line1.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = new NSizeL(6, 6);
			m_Line1.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);

			// add the second line
			m_Line2 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line2.Name = "Line 2";
			m_Line2.MultiLineMode = MultiLineMode.Stacked;
			m_Line2.DataLabelStyle.ArrowLength = new NLength(0);
			m_Line2.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Line2.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			m_Line2.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = new NSizeL(6, 6);
			m_Line2.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);

			// add the third line
			m_Line3 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line3.Name = "Line 3";
			m_Line3.MultiLineMode = MultiLineMode.Stacked;
			m_Line3.DataLabelStyle.ArrowLength = new NLength(0);
			m_Line3.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Line3.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			m_Line3.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = new NSizeL(6, 6);
			m_Line3.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Nature);
            styleSheet.Apply(nChartControl1.Document);

			// fill the data labels combos
			InitLabelsCombo(FirstLineDataLabelsCombo);
			InitLabelsCombo(SecondLineDataLabelsCombo);
			InitLabelsCombo(ThirdLineDataLabelsCombo);

			StackModeCombo.Items.Add("Stacked");
			StackModeCombo.Items.Add("Stacked %");
			StackModeCombo.SelectedIndex = 0;

			LineShapeCombo.FillFromEnum(typeof(LineSegmentShape));
            LineShapeCombo.SelectedIndex = (int)LineSegmentShape.Tape;

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
			NStandardScaleConfigurator scale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;

			switch (StackModeCombo.SelectedIndex)
			{
				case 0:
					m_Line2.MultiLineMode = MultiLineMode.Stacked; 
					m_Line3.MultiLineMode = MultiLineMode.Stacked;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					m_Line2.MultiLineMode = MultiLineMode.StackedPercent; 
					m_Line3.MultiLineMode = MultiLineMode.StackedPercent;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			nChartControl1.Refresh();
		}
		private void LineShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LineSegmentShape style = (LineSegmentShape)LineShapeCombo.SelectedIndex;

			m_Line1.LineSegmentShape = style;
			m_Line2.LineSegmentShape = style;
			m_Line3.LineSegmentShape = style;

			switch (style)
			{
				case LineSegmentShape.Tape:
					m_Line1.DepthPercent = 50;
					m_Line2.DepthPercent = 50;
					m_Line3.DepthPercent = 50;
					break;

				case LineSegmentShape.Tube:
				case LineSegmentShape.Ellipsoid:
					m_Line1.DepthPercent = 10;
					m_Line2.DepthPercent = 10;
					m_Line3.DepthPercent = 10;
					break;
			}

			nChartControl1.Refresh();
		}
		private void PositiveDataButton_Click(object sender, System.EventArgs e)
		{
			m_Line1.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Line2.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Line3.Values.FillRandomRange(Random, categoriesCount, 10, 100);

			nChartControl1.Refresh();
		}
		private void PositiveAndNegativeValuesButton_Click(object sender, System.EventArgs e)
		{
			m_Line1.Values.FillRandomRange(Random, categoriesCount, -50, 50);
			m_Line2.Values.FillRandomRange(Random, categoriesCount, -50, 50);
			m_Line3.Values.FillRandomRange(Random, categoriesCount, -50, 50);

			nChartControl1.Refresh();
		}
		private void ShowDataLabelsCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NLineSeries line0 = (NLineSeries)chart.Series[0];
			NLineSeries line1 = (NLineSeries)chart.Series[1];
			NLineSeries line2 = (NLineSeries)chart.Series[2];

			line0.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			line1.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			line2.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;

			FirstLineDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;
			SecondLineDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;
			ThirdLineDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked;

			nChartControl1.Refresh();
		}
		private void FirstLineDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Line1.DataLabelStyle.Format = GetFormatStringFromIndex(FirstLineDataLabelsCombo.SelectedIndex);
			nChartControl1.Refresh();
		}
		private void SecondLineDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Line2.DataLabelStyle.Format = GetFormatStringFromIndex(SecondLineDataLabelsCombo.SelectedIndex);
			nChartControl1.Refresh();
		}
		private void ThirdLineDataLabelsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Line3.DataLabelStyle.Format = GetFormatStringFromIndex(ThirdLineDataLabelsCombo.SelectedIndex);
			nChartControl1.Refresh();
		}
	}
}
