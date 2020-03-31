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
using System.Text;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPointAndFigureUC : NExampleBaseUC
	{
		private NPointAndFigureSeries m_PointAndFigure;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton UpStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DownStrokeStyleButton;		
		private Nevron.UI.WinForm.Controls.NCheckBox ProportionalXCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ProportionalYCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BoxSizeUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ReversalAmountUpDown;
		private Nevron.UI.WinForm.Controls.NTextBox textBox1;
		private Label label3;
		private System.ComponentModel.Container components = null;

		public NPointAndFigureUC()
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
			this.UpStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DownStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.ReversalAmountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ProportionalXCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ProportionalYCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.BoxSizeUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.textBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ReversalAmountUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxSizeUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// UpStrokeStyleButton
			// 
			this.UpStrokeStyleButton.Location = new System.Drawing.Point(5, 10);
			this.UpStrokeStyleButton.Name = "UpStrokeStyleButton";
			this.UpStrokeStyleButton.Size = new System.Drawing.Size(169, 24);
			this.UpStrokeStyleButton.TabIndex = 0;
			this.UpStrokeStyleButton.Text = "Up Stroke Style ...";
			this.UpStrokeStyleButton.Click += new System.EventHandler(this.UpStrokeStyleButton_Click);
			// 
			// DownStrokeStyleButton
			// 
			this.DownStrokeStyleButton.Location = new System.Drawing.Point(5, 41);
			this.DownStrokeStyleButton.Name = "DownStrokeStyleButton";
			this.DownStrokeStyleButton.Size = new System.Drawing.Size(169, 24);
			this.DownStrokeStyleButton.TabIndex = 1;
			this.DownStrokeStyleButton.Text = "Down Stroke Style...";
			this.DownStrokeStyleButton.Click += new System.EventHandler(this.DownStrokeStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 207);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Reversal Amount:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReversalAmountUpDown
			// 
			this.ReversalAmountUpDown.Location = new System.Drawing.Point(8, 233);
			this.ReversalAmountUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.ReversalAmountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ReversalAmountUpDown.Name = "ReversalAmountUpDown";
			this.ReversalAmountUpDown.Size = new System.Drawing.Size(155, 20);
			this.ReversalAmountUpDown.TabIndex = 7;
			this.ReversalAmountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ReversalAmountUpDown.ValueChanged += new System.EventHandler(this.ReversalAmountUpDown_ValueChanged);
			// 
			// ProportionalXCheckBox
			// 
			this.ProportionalXCheckBox.ButtonProperties.BorderOffset = 2;
			this.ProportionalXCheckBox.Location = new System.Drawing.Point(5, 84);
			this.ProportionalXCheckBox.Name = "ProportionalXCheckBox";
			this.ProportionalXCheckBox.Size = new System.Drawing.Size(165, 24);
			this.ProportionalXCheckBox.TabIndex = 2;
			this.ProportionalXCheckBox.Text = "Proportional X";
			this.ProportionalXCheckBox.CheckedChanged += new System.EventHandler(this.ProportionalXCheckBox_CheckedChanged);
			// 
			// ProportionalYCheckBox
			// 
			this.ProportionalYCheckBox.ButtonProperties.BorderOffset = 2;
			this.ProportionalYCheckBox.Location = new System.Drawing.Point(5, 109);
			this.ProportionalYCheckBox.Name = "ProportionalYCheckBox";
			this.ProportionalYCheckBox.Size = new System.Drawing.Size(165, 24);
			this.ProportionalYCheckBox.TabIndex = 3;
			this.ProportionalYCheckBox.Text = "Proportional Y";
			this.ProportionalYCheckBox.CheckedChanged += new System.EventHandler(this.ProportionalYCheckBox_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 146);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Box Size:";
			// 
			// BoxSizeUpDown
			// 
			this.BoxSizeUpDown.DecimalPlaces = 2;
			this.BoxSizeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.BoxSizeUpDown.Location = new System.Drawing.Point(8, 164);
			this.BoxSizeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.BoxSizeUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.BoxSizeUpDown.Name = "BoxSizeUpDown";
			this.BoxSizeUpDown.Size = new System.Drawing.Size(154, 20);
			this.BoxSizeUpDown.TabIndex = 5;
			this.BoxSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.BoxSizeUpDown.ValueChanged += new System.EventHandler(this.BoxSizeUpDown_ValueChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 278);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(167, 213);
			this.textBox1.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 261);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Current Data:";
			// 
			// NPointAndFigureUC
			// 
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BoxSizeUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ProportionalYCheckBox);
			this.Controls.Add(this.ProportionalXCheckBox);
			this.Controls.Add(this.ReversalAmountUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DownStrokeStyleButton);
			this.Controls.Add(this.UpStrokeStyleButton);
			this.Name = "NPointAndFigureUC";
			this.Size = new System.Drawing.Size(180, 515);
			((System.ComponentModel.ISupportInitialize)(this.ReversalAmountUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxSizeUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// remove all legends
			nChartControl1.Legends.Clear();

			// set a chart title
			NLabel title = new NLabel("Point and Figure");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			const int nInitialBoxSize = 5;

			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
			priceConfigurator.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			priceConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount;
			priceConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back };
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
			priceConfigurator.MaxTickCount = 8;

			NNumericRangeSamplerProvider provider = new NNumericRangeSamplerProvider();
			provider.SamplingMode = SamplingMode.CustomStep;
			provider.CustomStep = 1;
			provider.UseOrigin = true;
			provider.Origin = -0.5;
			priceConfigurator.MajorGridStyle.RangeSamplerProvider = provider;

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorTickMode = MajorTickMode.CustomStep;
			scaleY.CustomStep = nInitialBoxSize;
			scaleY.OuterMajorTickStyle.Width = new NLength(0);
			scaleY.InnerMajorTickStyle.Width = new NLength(0);
			scaleY.AutoMinorTicks = true;
			scaleY.MinorTickCount = 1;
			scaleY.RoundToTickMin = false;
			scaleY.RoundToTickMax = false;
			scaleY.MajorGridStyle.LineStyle.Width = new NLength(0);
			scaleY.MinorGridStyle.LineStyle.Width = new NLength(1);
			scaleY.MinorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };

			float[] highValues = new float[20]{ 21.3F, 42.4F, 11.2F, 65.7F, 38.0F, 71.3F, 49.54F, 83.7F, 13.9F, 56.12F, 27.43F, 23.1F, 31.0F, 75.4F, 9.3F, 39.12F, 10.0F, 44.23F, 21.76F, 49.2F };
			float[] lowValues = new float[20]{ 12.1F, 14.32F, 8.43F, 36.0F, 13.5F, 47.34F, 24.54F, 68.11F, 6.87F, 23.3F, 12.12F, 14.54F, 25.0F, 37.2F, 3.9F, 23.11F, 1.9F, 14.0F, 8.23F, 34.21F };

			// setup Point & Figure series
			m_PointAndFigure = (NPointAndFigureSeries)chart.Series.Add(SeriesType.PointAndFigure);
			m_PointAndFigure.UseXValues = true;

			// fill data
			m_PointAndFigure.HighValues.AddRange(highValues);
			m_PointAndFigure.LowValues.AddRange(lowValues);

			DateTime dt = new DateTime(2007, 1, 1);

			for(int i = 0; i < 20; i++)
			{
				m_PointAndFigure.XValues.Add(dt);
				dt = dt.AddDays(1);
			}

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			BoxSizeUpDown.Value = nInitialBoxSize;
			ReversalAmountUpDown.Value = 3;

			nChartControl1.MouseMove += new MouseEventHandler(nChartControl1_MouseMove);
		}

		void nChartControl1_MouseMove(object sender, MouseEventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);

			if (result.ChartElement == ChartElement.PointAndFigureData)
			{
				NPointAndFigureData pointAndFigureData = result.PointAndFigureData;

				StringBuilder builder = new StringBuilder();

				builder.AppendLine("DataIndex:" + pointAndFigureData.DataIndex.ToString());
				builder.AppendLine("ColumnIndex:" + pointAndFigureData.ColumnIndex.ToString());
				builder.AppendLine("ColumnDirection:" + pointAndFigureData.ColumnDirection.ToString());
				builder.AppendLine("HiValueIndex:" + pointAndFigureData.HiValueIndex.ToString());
				builder.AppendLine("LowValueIndexv:" + pointAndFigureData.LowValueIndex.ToString());

				textBox1.Text = builder.ToString();
			}
			else
			{
				textBox1.Text = string.Empty;
			}
		}

		private void UpStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				NStrokeStyle strokeStyleResult;

				if(NStrokeStyleTypeEditor.Edit(m_PointAndFigure.UpStrokeStyle, out strokeStyleResult))
				{
					m_PointAndFigure.UpStrokeStyle = strokeStyleResult;
					nChartControl1.Refresh();
				}
			}
		}

		private void DownStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				NStrokeStyle strokeStyleResult;

				if(NStrokeStyleTypeEditor.Edit(m_PointAndFigure.DownStrokeStyle, out strokeStyleResult))
				{
					m_PointAndFigure.DownStrokeStyle = strokeStyleResult;
					nChartControl1.Refresh();
				}
			}
		}

		private void ProportionalXCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				m_PointAndFigure.ProportionalX = ProportionalXCheckBox.Checked;
				nChartControl1.Refresh();
			}
		}

		private void ProportionalYCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				m_PointAndFigure.ProportionalY = ProportionalYCheckBox.Checked;
				nChartControl1.Refresh();		
			}
		}

		private void ReversalAmountUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				m_PointAndFigure.ReversalAmount = (int)ReversalAmountUpDown.Value;
				nChartControl1.Refresh();
			}
		}

		private void BoxSizeUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				double dBoxSize = (double)BoxSizeUpDown.Value;

				NChart chart = nChartControl1.Charts[0];
				m_PointAndFigure.BoxSize = dBoxSize;

				NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
				scaleY.CustomStep = dBoxSize;

				nChartControl1.Refresh();
			}
		}
	}
}