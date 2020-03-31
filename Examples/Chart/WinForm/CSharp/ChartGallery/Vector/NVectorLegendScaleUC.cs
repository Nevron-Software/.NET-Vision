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
	public class NVectorLegendScaleUC : NExampleBaseUC
	{
		private NVectorSeries m_Vector;
		private UI.WinForm.Controls.NComboBox VectorLengthScaleModeComboBox;
		private Label label1;
		private UI.WinForm.Controls.NNumericUpDown VectorLengthScaleStepsNumericUpDown;
		private Label label2;
		private UI.WinForm.Controls.NNumericUpDown TextOffsetNumericUpDown;
		private Label label3;
		private UI.WinForm.Controls.NNumericUpDown TableCellOffsetNumericUpDown;
		private Label label4;
		private UI.WinForm.Controls.NCheckBox RoundValuesCheckBox;
		private UI.WinForm.Controls.NButton StrokeStyleButton;
		private System.ComponentModel.Container components = null;

		public NVectorLegendScaleUC()
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
			this.VectorLengthScaleModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.VectorLengthScaleStepsNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.TextOffsetNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.TableCellOffsetNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.RoundValuesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.StrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.VectorLengthScaleStepsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextOffsetNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TableCellOffsetNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// BubbleScaleModeCombo
			// 
			this.VectorLengthScaleModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.VectorLengthScaleModeComboBox.ListProperties.DataSource = null;
			this.VectorLengthScaleModeComboBox.ListProperties.DisplayMember = "";
			this.VectorLengthScaleModeComboBox.Location = new System.Drawing.Point(10, 20);
			this.VectorLengthScaleModeComboBox.Name = "BubbleScaleModeCombo";
			this.VectorLengthScaleModeComboBox.Size = new System.Drawing.Size(150, 21);
			this.VectorLengthScaleModeComboBox.TabIndex = 3;
			this.VectorLengthScaleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VectorLengthScaleModeCombo_SelectedIndexChanged);
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
			this.VectorLengthScaleStepsNumericUpDown.Location = new System.Drawing.Point(10, 193);
			this.VectorLengthScaleStepsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.VectorLengthScaleStepsNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.VectorLengthScaleStepsNumericUpDown.Name = "BubbleScaleStepsUpDown";
			this.VectorLengthScaleStepsNumericUpDown.Size = new System.Drawing.Size(150, 20);
			this.VectorLengthScaleStepsNumericUpDown.TabIndex = 5;
			this.VectorLengthScaleStepsNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.VectorLengthScaleStepsNumericUpDown.ValueChanged += new System.EventHandler(this.VectorLengthScaleStepsUpDown_ValueChanged);
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
			// NVectorLegendScaleUC
			// 
			this.Controls.Add(this.StrokeStyleButton);
			this.Controls.Add(this.RoundValuesCheckBox);
			this.Controls.Add(this.TableCellOffsetNumericUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TextOffsetNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.VectorLengthScaleStepsNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.VectorLengthScaleModeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NVectorLegendScaleUC";
			this.Size = new System.Drawing.Size(180, 389);
			((System.ComponentModel.ISupportInitialize)(this.VectorLengthScaleStepsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextOffsetNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TableCellOffsetNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Vector Legend Scale");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);


			nChartControl1.Legends[0].Header.Text = "Vector Length";

			// setup chart
			NChart chart = nChartControl1.Charts[0];

			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup shape series
			m_Vector = (NVectorSeries)chart.Series.Add(SeriesType.Vector);
			m_Vector.FillStyle = new NColorFillStyle(Color.Red);
			m_Vector.BorderStyle.Color = Color.DarkRed;
			m_Vector.DataLabelStyle.Visible = false;
			m_Vector.InflateMargins = true;
			m_Vector.UseXValues = true;
			//m_Vector.UseZValues = true;
			m_Vector.MinArrowHeadSize = new NSizeL(2, 3);
			m_Vector.MaxArrowHeadSize = new NSizeL(4, 6);
			m_Vector.MinVectorLength = new NLength(8);
			m_Vector.MaxVectorLength = new NLength(30);
			m_Vector.Mode = VectorSeriesMode.Direction;
			m_Vector.Legend.Mode = SeriesLegendMode.SeriesLogic;

			// fill data
			FillData(m_Vector);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			VectorLengthScaleModeComboBox.FillFromEnum(typeof(VectorLengthScaleMode));
			VectorLengthScaleModeComboBox.SelectedIndex = (int)m_Vector.VectorLengthScale.Mode;
			TextOffsetNumericUpDown.Value = (decimal)m_Vector.VectorLengthScale.TextOffset.Value;
			TableCellOffsetNumericUpDown.Value = (decimal)m_Vector.VectorLengthScale.TableCellOffset.Value;
			VectorLengthScaleStepsNumericUpDown.Value = (decimal)m_Vector.VectorLengthScale.Steps;
			RoundValuesCheckBox.Checked = m_Vector.VectorLengthScale.RoundValues;

			VectorLengthScaleModeCombo_SelectedIndexChanged(null, null);
		}

		private void FillData(NVectorSeries vectorSeries)
		{
			double x = 0, y = 0;
			int k = 0;

			for (int i = 0; i < 10; i++)
			{
				x = 1;
				y += 1;

				for (int j = 0; j < 10; j++)
				{
					x += 1;

					double dx = Math.Sin(x / 3.0) * Math.Cos((x - y) / 4.0);
					double dy = Math.Cos(y / 8.0) * Math.Cos(y / 4.0);

					vectorSeries.XValues.Add(x);
					vectorSeries.Values.Add(y);
					vectorSeries.X2Values.Add(dx);
					vectorSeries.Y2Values.Add(dy);

					vectorSeries.ZValues.Add(y);
					vectorSeries.Z2Values.Add(dy);

					vectorSeries.BorderStyles[k] = new NStrokeStyle(1, ColorFromVector(dx, dy));
					k++;
				}
			}
		}

		private Color ColorFromVector(double dx, double dy)
		{
			double length = Math.Sqrt(dx * dx + dy * dy);

			double sq2 = Math.Sqrt(2);

			int r = (int)((255 / sq2) * length);
			int g = 20;
			int b = (int)((255 / sq2) * (sq2 - length));

			return Color.FromArgb(r, g, b);
		}


		private void VectorLengthScaleModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_Vector.VectorLengthScale.Mode = (VectorLengthScaleMode)VectorLengthScaleModeComboBox.SelectedIndex;

			switch (m_Vector.VectorLengthScale.Mode)
			{
				case VectorLengthScaleMode.LeftToRight:
				case VectorLengthScaleMode.RightToLeft:
					m_Vector.VectorLengthScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
					m_Vector.VectorLengthScale.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top;
					break;
				case VectorLengthScaleMode.TopToBottom:
				case VectorLengthScaleMode.BottomToTop:
					m_Vector.VectorLengthScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right;
					m_Vector.VectorLengthScale.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center;
					break;
			}
		
			nChartControl1.Refresh();
		}

		private void TextOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Vector.VectorLengthScale.TextOffset = new NLength((int)TextOffsetNumericUpDown.Value);
			nChartControl1.Refresh();
		}

		private void TableCellOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Vector.VectorLengthScale.TableCellOffset = new NLength((int)TableCellOffsetNumericUpDown.Value);
			nChartControl1.Refresh();
		}

		private void VectorLengthScaleStepsUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Vector.VectorLengthScale.Steps = (int)VectorLengthScaleStepsNumericUpDown.Value;
			nChartControl1.Refresh();
		}

		private void RoundValuesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Vector.VectorLengthScale.RoundValues = RoundValuesCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void StrokeStyleButton_Click(object sender, EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Vector.VectorLengthScale.StrokeStyle, out strokeStyleResult))
			{
				m_Vector.VectorLengthScale.StrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
