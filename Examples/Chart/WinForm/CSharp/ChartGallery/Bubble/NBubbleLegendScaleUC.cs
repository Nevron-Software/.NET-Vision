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
	public class NBubbleLegendScaleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private UI.WinForm.Controls.NComboBox BubbleScaleModeCombo;
		private Label label1;
		private UI.WinForm.Controls.NNumericUpDown BubbleScaleStepsUpDown;
		private Label label2;
		private UI.WinForm.Controls.NNumericUpDown TextOffsetNumericUpDown;
		private Label label3;
		private UI.WinForm.Controls.NNumericUpDown TableCellOffsetNumericUpDown;
		private Label label4;
		private UI.WinForm.Controls.NCheckBox RoundValuesCheckBox;
		private UI.WinForm.Controls.NButton StrokeStyleButton;
		private System.ComponentModel.Container components = null;

		public NBubbleLegendScaleUC()
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
			this.BubbleScaleModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BubbleScaleStepsUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.TextOffsetNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.TableCellOffsetNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.RoundValuesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.StrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.BubbleScaleStepsUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextOffsetNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TableCellOffsetNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// BubbleScaleModeCombo
			// 
			this.BubbleScaleModeCombo.ListProperties.CheckBoxDataMember = "";
			this.BubbleScaleModeCombo.ListProperties.DataSource = null;
			this.BubbleScaleModeCombo.ListProperties.DisplayMember = "";
			this.BubbleScaleModeCombo.Location = new System.Drawing.Point(10, 20);
			this.BubbleScaleModeCombo.Name = "BubbleScaleModeCombo";
			this.BubbleScaleModeCombo.Size = new System.Drawing.Size(150, 21);
			this.BubbleScaleModeCombo.TabIndex = 3;
			this.BubbleScaleModeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleScaleModeCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Bubble Scale Mode:";
			// 
			// BubbleScaleStepsUpDown
			// 
			this.BubbleScaleStepsUpDown.Location = new System.Drawing.Point(10, 193);
			this.BubbleScaleStepsUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.BubbleScaleStepsUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.BubbleScaleStepsUpDown.Name = "BubbleScaleStepsUpDown";
			this.BubbleScaleStepsUpDown.Size = new System.Drawing.Size(150, 20);
			this.BubbleScaleStepsUpDown.TabIndex = 5;
			this.BubbleScaleStepsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.BubbleScaleStepsUpDown.ValueChanged += new System.EventHandler(this.BubbleScaleStepsUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 175);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Bubble Scale Steps:";
			// 
			// TextOffsetNumericUpDown
			// 
			this.TextOffsetNumericUpDown.Location = new System.Drawing.Point(10, 76);
			this.TextOffsetNumericUpDown.Name = "TextOffsetNumericUpDown";
			this.TextOffsetNumericUpDown.Size = new System.Drawing.Size(150, 20);
			this.TextOffsetNumericUpDown.TabIndex = 7;
			this.TextOffsetNumericUpDown.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
			this.TextOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TextOffsetNumericUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(147, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Text Offset:";
			// 
			// TableCellOffsetNumericUpDown
			// 
			this.TableCellOffsetNumericUpDown.Location = new System.Drawing.Point(12, 131);
			this.TableCellOffsetNumericUpDown.Name = "TableCellOffsetNumericUpDown";
			this.TableCellOffsetNumericUpDown.Size = new System.Drawing.Size(150, 20);
			this.TableCellOffsetNumericUpDown.TabIndex = 9;
			this.TableCellOffsetNumericUpDown.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
			this.TableCellOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TableCellOffsetNumericUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(147, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Table Cell Offset:";
			// 
			// RoundValuesCheckBox
			// 
			this.RoundValuesCheckBox.ButtonProperties.BorderOffset = 2;
			this.RoundValuesCheckBox.Location = new System.Drawing.Point(10, 219);
			this.RoundValuesCheckBox.Name = "RoundValuesCheckBox";
			this.RoundValuesCheckBox.Size = new System.Drawing.Size(150, 21);
			this.RoundValuesCheckBox.TabIndex = 38;
			this.RoundValuesCheckBox.Text = "Round Values";
			this.RoundValuesCheckBox.CheckedChanged += new System.EventHandler(this.RoundValuesCheckBox_CheckedChanged);
			// 
			// StrokeStyleButton
			// 
			this.StrokeStyleButton.Location = new System.Drawing.Point(10, 322);
			this.StrokeStyleButton.Name = "StrokeStyleButton";
			this.StrokeStyleButton.Size = new System.Drawing.Size(154, 24);
			this.StrokeStyleButton.TabIndex = 39;
			this.StrokeStyleButton.Text = "Stroke Style...";
			this.StrokeStyleButton.Click += new System.EventHandler(this.StrokeStyleButton_Click);
			// 
			// NBubbleScaleUC
			// 
			this.Controls.Add(this.StrokeStyleButton);
			this.Controls.Add(this.RoundValuesCheckBox);
			this.Controls.Add(this.TableCellOffsetNumericUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TextOffsetNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BubbleScaleStepsUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BubbleScaleModeCombo);
			this.Controls.Add(this.label1);
			this.Name = "NBubbleScaleUC";
			this.Size = new System.Drawing.Size(180, 389);
			((System.ComponentModel.ISupportInitialize)(this.BubbleScaleStepsUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextOffsetNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TableCellOffsetNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bubble Scale");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add a bubble series
			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.MinSize = new NLength(7.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.MaxSize = new NLength(16.0f, NRelativeUnit.ParentPercentage);

			for (int i = 0; i < 10; i++)
			{
				m_Bubble.Values.Add(i);
				m_Bubble.Sizes.Add(i * 10 + 10);
			}
			m_Bubble.InflateMargins = true;

			NPalette palette = new NPalette();
			palette.SmoothPalette = true;
			palette.Clear();
			palette.Add(0, Color.Green);
			palette.Add(60, Color.Yellow);
			palette.Add(120, Color.Red);

			m_Bubble.Palette = palette;

			nChartControl1.Legends[0].Header.Text = "Bubble Size";

			m_Bubble.Legend.Mode = SeriesLegendMode.SeriesLogic;
			m_Bubble.BubbleSizeScale.TextOffset = new NLength(0);
			m_Bubble.BubbleSizeScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			m_Bubble.BubbleSizeScale.Mode = BubbleSizeScaleMode.ConcentricDown;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			BubbleScaleModeCombo.FillFromEnum(typeof(BubbleSizeScaleMode));
			BubbleScaleModeCombo.SelectedIndex = (int)m_Bubble.BubbleSizeScale.Mode;
			TextOffsetNumericUpDown.Value = (decimal)m_Bubble.BubbleSizeScale.TextOffset.Value;
			TableCellOffsetNumericUpDown.Value = (decimal)m_Bubble.BubbleSizeScale.TableCellOffset.Value;
			BubbleScaleStepsUpDown.Value = (decimal)m_Bubble.BubbleSizeScale.Steps;
			RoundValuesCheckBox.Checked = m_Bubble.BubbleSizeScale.RoundValues;

			BubbleScaleModeCombo_SelectedIndexChanged(null, null);
		}

		private void BubbleScaleModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_Bubble.BubbleSizeScale.Mode = (BubbleSizeScaleMode)BubbleScaleModeCombo.SelectedIndex;

			switch (m_Bubble.BubbleSizeScale.Mode)
			{
				case BubbleSizeScaleMode.ConcentricDown:
				case BubbleSizeScaleMode.ConcentricUp:
					m_Bubble.BubbleSizeScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
					TableCellOffsetNumericUpDown.Enabled = false;
					break;
				case BubbleSizeScaleMode.TableAscending:
				case BubbleSizeScaleMode.TableDescending:
					m_Bubble.BubbleSizeScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
					TableCellOffsetNumericUpDown.Enabled = true;
					break;
			}
		
			nChartControl1.Refresh();
		}

		private void TextOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Bubble.BubbleSizeScale.TextOffset = new NLength((int)TextOffsetNumericUpDown.Value);
			nChartControl1.Refresh();
		}

		private void TableCellOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Bubble.BubbleSizeScale.TableCellOffset = new NLength((int)TableCellOffsetNumericUpDown.Value);
			nChartControl1.Refresh();
		}

		private void BubbleScaleStepsUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Bubble.BubbleSizeScale.Steps = (int)BubbleScaleStepsUpDown.Value;
			nChartControl1.Refresh();
		}

		private void RoundValuesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Bubble.BubbleSizeScale.RoundValues = RoundValuesCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void StrokeStyleButton_Click(object sender, EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Bubble.BubbleSizeScale.StrokeStyle, out strokeStyleResult))
			{
				m_Bubble.BubbleSizeScale.StrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
