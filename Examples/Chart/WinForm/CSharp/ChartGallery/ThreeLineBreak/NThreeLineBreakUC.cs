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
	public class NThreeLineBreakUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton UpStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DownStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton UpFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DownFillStyleButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown LinesToBreakNumericUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox BoxWidthPercentCombo;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NTextBox textBox1;
		private Label label3;
		private NThreeLineBreakSeries m_ThreeLineBreak;

		public NThreeLineBreakUC()
		{
			InitializeComponent();

			BoxWidthPercentCombo.Items.AddRange(new string[]{ "50%", "75%", "100%" });
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
			this.UpFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DownFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.LinesToBreakNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.BoxWidthPercentCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.LinesToBreakNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// UpStrokeStyleButton
			// 
			this.UpStrokeStyleButton.Location = new System.Drawing.Point(10, 10);
			this.UpStrokeStyleButton.Name = "UpStrokeStyleButton";
			this.UpStrokeStyleButton.Size = new System.Drawing.Size(154, 24);
			this.UpStrokeStyleButton.TabIndex = 0;
			this.UpStrokeStyleButton.Text = "Up Border Style ...";
			this.UpStrokeStyleButton.Click += new System.EventHandler(this.UpStrokeStyleButton_Click);
			// 
			// DownStrokeStyleButton
			// 
			this.DownStrokeStyleButton.Location = new System.Drawing.Point(10, 41);
			this.DownStrokeStyleButton.Name = "DownStrokeStyleButton";
			this.DownStrokeStyleButton.Size = new System.Drawing.Size(154, 24);
			this.DownStrokeStyleButton.TabIndex = 1;
			this.DownStrokeStyleButton.Text = "Down Border Style...";
			this.DownStrokeStyleButton.Click += new System.EventHandler(this.DownStrokeStyleButton_Click);
			// 
			// UpFillStyleButton
			// 
			this.UpFillStyleButton.Location = new System.Drawing.Point(10, 73);
			this.UpFillStyleButton.Name = "UpFillStyleButton";
			this.UpFillStyleButton.Size = new System.Drawing.Size(154, 24);
			this.UpFillStyleButton.TabIndex = 2;
			this.UpFillStyleButton.Text = "Up Fill Style...";
			this.UpFillStyleButton.Click += new System.EventHandler(this.UpFillStyleButton_Click);
			// 
			// DownFillStyleButton
			// 
			this.DownFillStyleButton.Location = new System.Drawing.Point(10, 104);
			this.DownFillStyleButton.Name = "DownFillStyleButton";
			this.DownFillStyleButton.Size = new System.Drawing.Size(154, 24);
			this.DownFillStyleButton.TabIndex = 3;
			this.DownFillStyleButton.Text = "Down Fill Style...";
			this.DownFillStyleButton.Click += new System.EventHandler(this.DownFillStyleButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 195);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 15);
			this.label2.TabIndex = 6;
			this.label2.Text = "Number of Lines to Break:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LinesToBreakNumericUpDown
			// 
			this.LinesToBreakNumericUpDown.Location = new System.Drawing.Point(10, 213);
			this.LinesToBreakNumericUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.LinesToBreakNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LinesToBreakNumericUpDown.Name = "LinesToBreakNumericUpDown";
			this.LinesToBreakNumericUpDown.Size = new System.Drawing.Size(56, 20);
			this.LinesToBreakNumericUpDown.TabIndex = 7;
			this.LinesToBreakNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LinesToBreakNumericUpDown.ValueChanged += new System.EventHandler(this.LinesToBreakNumericUpDown_ValueChanged);
			// 
			// BoxWidthPercentCombo
			// 
			this.BoxWidthPercentCombo.ListProperties.CheckBoxDataMember = "";
			this.BoxWidthPercentCombo.ListProperties.DataSource = null;
			this.BoxWidthPercentCombo.ListProperties.DisplayMember = "";
			this.BoxWidthPercentCombo.Location = new System.Drawing.Point(10, 160);
			this.BoxWidthPercentCombo.Name = "BoxWidthPercentCombo";
			this.BoxWidthPercentCombo.Size = new System.Drawing.Size(151, 21);
			this.BoxWidthPercentCombo.TabIndex = 5;
			this.BoxWidthPercentCombo.SelectedIndexChanged += new System.EventHandler(this.BoxWidthPercentCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 142);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Box Width Percent:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(10, 257);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(154, 213);
			this.textBox1.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 240);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Current Data:";
			// 
			// NThreeLineBreakUC
			// 
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BoxWidthPercentCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LinesToBreakNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DownFillStyleButton);
			this.Controls.Add(this.UpFillStyleButton);
			this.Controls.Add(this.DownStrokeStyleButton);
			this.Controls.Add(this.UpStrokeStyleButton);
			this.Name = "NThreeLineBreakUC";
			this.Size = new System.Drawing.Size(180, 536);
			((System.ComponentModel.ISupportInitialize)(this.LinesToBreakNumericUpDown)).EndInit();
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
			NLabel title = new NLabel("Three Line Break");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			NChart chart = nChartControl1.Charts[0];

            NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            scaleY.StripStyles.Add(stripStyle);

			// setup X axis
			NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
			priceConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

			// setup line break series
            m_ThreeLineBreak = (NThreeLineBreakSeries)chart.Series.Add(SeriesType.ThreeLineBreak);
            m_ThreeLineBreak.UseXValues = true;

            GenerateData(m_ThreeLineBreak);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			BoxWidthPercentCombo.SelectedIndex = 2;
			LinesToBreakNumericUpDown.Value = 3;

			nChartControl1.MouseMove += new MouseEventHandler(nChartControl1_MouseMove);
		}

		void nChartControl1_MouseMove(object sender, MouseEventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);

			if (result.ChartElement == ChartElement.LineBreakData)
			{
				NLineBreakData lineBreakData = result.LineBreakData;
				StringBuilder builder = new StringBuilder();

				builder.AppendLine("HighY:" + lineBreakData.HighY.ToString());
				builder.AppendLine("LowY:" + lineBreakData.LowY.ToString());
				builder.AppendLine("Direction:" + lineBreakData.Direction.ToString());
				builder.AppendLine("DirectionChanged:" + lineBreakData.DirectionChanged.ToString());

				textBox1.Text = builder.ToString();
			}
			else
			{
				textBox1.Text = string.Empty;
			}
		}

		private void GenerateData(NThreeLineBreakSeries threeLineBreak)
		{
			NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.002, 2);
			dataGenerator.Reset();

			DateTime dt = new DateTime(2022, 1, 1);

			for(int i = 0; i < 100; i++)
			{
				threeLineBreak.Values.Add(dataGenerator.GetNextValue());
				threeLineBreak.XValues.Add(dt);

				dt = dt.AddDays(1);
			}
		}

		private void UpStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			if (m_ThreeLineBreak != null)
			{
				NStrokeStyle strokeStyleResult;

				if (NStrokeStyleTypeEditor.Edit(m_ThreeLineBreak.UpStrokeStyle, out strokeStyleResult))
				{
					m_ThreeLineBreak.UpStrokeStyle = strokeStyleResult;
					nChartControl1.Refresh();
				}
			}
		}

		private void DownStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			if (m_ThreeLineBreak != null)
			{
				NStrokeStyle strokeStyleResult;

				if (NStrokeStyleTypeEditor.Edit(m_ThreeLineBreak.DownStrokeStyle, out strokeStyleResult))
				{
					m_ThreeLineBreak.DownStrokeStyle = strokeStyleResult;
					nChartControl1.Refresh();
				}
			}
		}

		private void UpFillStyleButton_Click(object sender, System.EventArgs e)
		{
			if (m_ThreeLineBreak != null)
			{
				NFillStyle fillStyleResult;

				if (NFillStyleTypeEditor.Edit(m_ThreeLineBreak.UpFillStyle, out fillStyleResult))
				{
					m_ThreeLineBreak.UpFillStyle = fillStyleResult;
					nChartControl1.Refresh();
				}
			}
		}

		private void DownFillStyleButton_Click(object sender, System.EventArgs e)
		{
			if (m_ThreeLineBreak != null)
			{
				NFillStyle fillStyleResult;

				if (NFillStyleTypeEditor.Edit(m_ThreeLineBreak.DownFillStyle, out fillStyleResult))
				{
					m_ThreeLineBreak.DownFillStyle = fillStyleResult;
					nChartControl1.Refresh();
				}
			}
		}

		private void LinesToBreakNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (m_ThreeLineBreak != null)
			{
				m_ThreeLineBreak.NumberOfLinesToBreak = (int)LinesToBreakNumericUpDown.Value;
				nChartControl1.Refresh();
			}
		}

		private void BoxWidthPercentCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (m_ThreeLineBreak != null)
            {
                switch (BoxWidthPercentCombo.SelectedIndex)
                {
                    case 0:
                        m_ThreeLineBreak.BoxWidthPercent = 50;
                        break;

                    case 1:
                        m_ThreeLineBreak.BoxWidthPercent = 75;
                        break;

                    case 2:
                        m_ThreeLineBreak.BoxWidthPercent = 100;
                        break;
                }

                nChartControl1.Refresh();
            }
		}
	}
}